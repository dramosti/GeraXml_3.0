using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HLP.GeraXml.bel.NFe;
using HLP.GeraXml.Comum.Static;
using System.IO;
using System.Xml.Serialization;
using System.Xml;
using HLP.GeraXml.Comum;
using HLP.GeraXml.dao.NFes.DSF;
using System.Threading;

namespace HLP.GeraXml.bel.NFes.DSF
{

    public class belEnviarNFSeWS : daoEnviarNFSeWS
    {
        private belCarregaDadosRPS dadosRPS { get; set; }
        private HLP.GeraXml.WebService.NFSE_Campinas.LoteRpsService lt = new WebService.NFSE_Campinas.LoteRpsService();
        private System.Windows.Forms.Timer tempo = new System.Windows.Forms.Timer();

        public belEnviarNFSeWS(belCarregaDadosRPS dadosRPS)
        {
            tempo.Interval = 5000;
            this.dadosRPS = dadosRPS;
        }

        public string Enviar()
        {
            tempo.Tick += new EventHandler(tempo_Tick);
            try
            {
                if (Acesso.TP_AMB_SERV == 1)
                {
                    lt.ClientCertificates.Add(Acesso.cert_NFs);
                }
                string x = "";
                for (int i = 5; ((i != 0) && (x == "")); i--)
                {
                    try
                    {
                        tempo.Start();
                        if (Acesso.TP_AMB_SERV == 1)
                        {
                            x = lt.enviar(dadosRPS.xmlLote.InnerXml.ToString());
                        }
                        else
                        {
                            x = lt.testeEnviar(dadosRPS.xmlLote.InnerXml.ToString());
                        }
                        tempo.Stop();
                    }
                    catch (Exception ex)
                    {
                        if (i == 0)
                        {
                            throw ex;
                        }
                    }
                }
                //Deserializa o retorno do webservice.
                XmlSerializer deserializer = new XmlSerializer(typeof(RetornoEnvioLoteRPS));
                RetornoEnvioLoteRPS ret;
                byte[] bytearray = Encoding.ASCII.GetBytes(x);
                MemoryStream valorStream = new MemoryStream(bytearray);
                ret = (RetornoEnvioLoteRPS)deserializer.Deserialize(valorStream);

                //Salva protocolo de retorno.
                StreamWriter sw = new StreamWriter(Pastas.PROTOCOLOS + "\\NFSE_LOTE_" + ret.cabec.NumeroLote + ".xml");
                sw.Write(x);
                sw.Close();

                string sMessageRetorno = "Método enviado Sincronamente";

                if (ret.cabec.Assincrono == "S")
                {
                    ReqConsultaLote consultaLote = new ReqConsultaLote();

                    consultaLote.cabec = new belConsultaLote();
                    consultaLote.cabec.CodCidade = ret.cabec.CodCidade;
                    consultaLote.cabec.CPFCNPJRemetente = ret.cabec.CPFCNPJRemetente;
                    consultaLote.cabec.NumeroLote = ret.cabec.NumeroLote;
                    consultaLote.cabec.Versao = ret.cabec.Versao.ToString();

                    //hora de salvar o numero do Lote nos RPS contidos no lote.
                    foreach (LoteRPS rps in this.dadosRPS.objLoteEnvio.lote.RPS)
                    {
                        base.SalvarRecibo(consultaLote.cabec.NumeroLote, rps.CD_NFSEQ);
                    }


                    string sPath = Pastas.PROTOCOLOS + "\\CONSULTA_LOTE_" + ret.cabec.NumeroLote + ".xml";

                    if (File.Exists(sPath))
                    {
                        File.Delete(sPath);
                    }

                    XmlSerializerNamespaces nameSpaces = new XmlSerializerNamespaces();
                    nameSpaces.Add("xsi", "http://www.w3.org/2001/XMLSchema-instance");
                    nameSpaces.Add("tipos", "http://localhost:8080/WsNFe2/tp");
                    nameSpaces.Add("ns1", "http://localhost:8080/WsNFe2/lote");

                    SerializeClassToXml.SerializeClasse<ReqConsultaLote>(consultaLote, sPath, nameSpaces);
                    sMessageRetorno = BuscaRetorno(ret.cabec.NumeroLote);

                }
                else if (ret.erros.Erro.Count() > 0)
                {
                    sMessageRetorno = "Erros:" + Environment.NewLine;
                    foreach (ErrosErro err in ret.erros.Erro)
                    {
                        sMessageRetorno += string.Format("Codigo:{0} - Descrição:{1}{2}", err.Codigo, err.Descricao, Environment.NewLine);
                    }
                    foreach (LoteRPS rps in this.dadosRPS.objLoteEnvio.lote.RPS)
                    {
                        base.LimpaCampoRecibo(rps.CD_NFSEQ);
                    }
                }
                else if (ret.alertas.alert.Count() > 0)
                {
                    sMessageRetorno = "Alertas:" + Environment.NewLine;
                    foreach (Alerta_retlote alert in ret.alertas.alert)
                    {
                        sMessageRetorno += string.Format("Codigo:{0} - Descrição:{1}{2}", alert.Codigo, alert.Descricao, Environment.NewLine);
                    }
                }

                return sMessageRetorno;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        void tempo_Tick(object sender, EventArgs e)
        {
            throw new Exception("Tempo de espera de resposta do servidor esgotado");
        }


        private void ConsultaLote(HLP.GeraXml.WebService.NFSE_Campinas.LoteRpsService _lt, string sXmlConsulta, string num_lote, out RetornoConsultaLote objretorno)
        {
            string sRetornoLote = "";
            for (int i = 5; ((i != 0) && (sRetornoLote == "")); i--)
            {
                try
                {
                    tempo.Start();
                    sRetornoLote = _lt.consultarLote(sXmlConsulta);
                    tempo.Stop();
                }
                catch (Exception ex)
                {
                    if (i == 0)
                    {
                        throw ex;
                    }
                }
            }
            sRetornoLote = _lt.consultarLote(sXmlConsulta);
            string sPathRetConsultaLote = Pastas.PROTOCOLOS + "\\Ret_Consulta_Lote_" + num_lote + ".xml";
            try
            {
                XmlDocument xDoc = new XmlDocument();
                xDoc.LoadXml(sRetornoLote);
                xDoc.Save(sPathRetConsultaLote);
            }
            catch (Exception ex)
            {
                throw new Exception("Falha ao converter o retorno do webservice do método consultarLote" + Environment.NewLine + "MSG:" + sRetornoLote.ToString() + Environment.NewLine + ex.Message);
            }
            objretorno = SerializeClassToXml.DeserializeClasse<RetornoConsultaLote>(sPathRetConsultaLote);
        }

        private string TrataRetornoConsultaLote(RetornoConsultaLote objRetoConsultaLote)
        {
            string sMessageRetorno = "";

            if (objRetoConsultaLote.alertas.alerta.Count() > 0)
            {
                sMessageRetorno += "Alertas:" + Environment.NewLine;
                foreach (Alerta alert in objRetoConsultaLote.alertas.alerta)
                {
                    sMessageRetorno = string.Format("Codigo:{0} - Descrição:{1}{2}", alert.Codigo, alert.Descricao, Environment.NewLine);
                }
            }

            if (objRetoConsultaLote.erros.Erro.Count() > 0)
            {
                sMessageRetorno += "Erros:" + Environment.NewLine;
                foreach (ErrosErroRetLote erro in objRetoConsultaLote.erros.Erro)
                {
                    sMessageRetorno += string.Format("Codigo:{0} - Descrição:{1}{2}", erro.Codigo, erro.Descricao, Environment.NewLine);
                }
                foreach (LoteRPS rps in this.dadosRPS.objLoteEnvio.lote.RPS)
                {
                    base.LimpaCampoRecibo(rps.CD_NFSEQ);
                }
            }

            if (objRetoConsultaLote.lista.ConsultaNFSe.Count() > 0)
            {
                sMessageRetorno += "Notas enviadas:" + Environment.NewLine;
                string sPathOrigem = "";
                string sPathDest = "";

                foreach (ListaNFSeConsultaNFSe notas in objRetoConsultaLote.lista.ConsultaNFSe)
                {
                    sPathOrigem = belCarregaDadosRPS.GetFilePathMonthServico(false, notas.NumeroRPS);
                    sPathDest = belCarregaDadosRPS.GetFilePathMonthServico(true, notas.NumeroNFe); //salvo na pasta envio com o numero do nfse.
                    string scd_nfseq = this.dadosRPS.objLoteEnvio.lote.RPS.FirstOrDefault(c => c.NumeroRPS == notas.NumeroRPS).CD_NFSEQ;
                    sMessageRetorno += string.Format("NF_SEQ:{0} - RPS:{1} - NumeroNFSe:{2}{3}", scd_nfseq, notas.NumeroRPS, notas.NumeroNFe, Environment.NewLine);
                    base.SalvaStatusDaNota(notas.NumeroNFe, notas.CodigoVerificacao, scd_nfseq);

                    if (File.Exists(sPathDest))
                    {
                        File.Delete(sPathDest);
                    }

                    //COLOCA O XML NA PASTA ENVIADOS
                    File.Copy(sPathOrigem, sPathDest);
                }
            }
            return sMessageRetorno;
        }

        /// <summary>
        /// Método que busca retorno do lote.
        /// </summary>
        /// <param name="sNumeroLote"></param>
        /// <returns></returns>
        public string BuscaRetorno(string sNumeroLote)
        {
            try
            {
                string sPath = Pastas.PROTOCOLOS + "\\CONSULTA_LOTE_" + sNumeroLote + ".xml";

                XmlDocument xmlConsulta = new XmlDocument();
                xmlConsulta.Load(sPath);
                belValidaXml.ValidarXml("http://localhost:8080/WsNFe2/lote", Pastas.SCHEMA_NFSE_DSF + "\\ReqConsultaLote.xsd", sPath);

                RetornoConsultaLote objretorno = null;
                ConsultaLote(lt, xmlConsulta.InnerXml, sNumeroLote, out objretorno);
                int iCount = 5;
                while ((objretorno.alertas.alerta.Where(c => c.Codigo == "203").Count() > 0) && iCount != 0)
                {
                    Thread.Sleep(1000);
                    ConsultaLote(lt, xmlConsulta.InnerXml, sNumeroLote, out objretorno);
                    iCount--;
                }
                string sMessageRetorno = TrataRetornoConsultaLote(objretorno);
                return sMessageRetorno;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



    }
}
