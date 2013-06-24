using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using HLP.GeraXml.Comum.Static;
using System.IO;
using System.Xml;
using HLP.GeraXml.Comum;
using HLP.GeraXml.bel.NFe;
using HLP.GeraXml.dao;
using HLP.GeraXml.dao.NFes.DSF;

namespace HLP.GeraXml.bel.NFes.DSF
{
    /// <summary>
    /// 
    /// </summary>
    public class belCancelamentoDSF : daoCancelamentoDSF
    {
        List<belPesquisaNotas> objNotas;
        public ReqCancelamentoNFSe objCancelamento { get; set; }
        public belCancelamentoDSF(List<belPesquisaNotas> objNotas)
        {
            this.objNotas = objNotas;
            objCancelamento = new ReqCancelamentoNFSe();
            objCancelamento.cabec = new CabecalhoRetCanc();
            objCancelamento.cabec.CodCidade = daoUtil.GetCodigoSiafiByNome(Acesso.CIDADE_EMPRESA);
            objCancelamento.cabec.CPFCNPJRemetente = Util.RetiraCaracterCNPJ(Acesso.CNPJ_EMPRESA);
            objCancelamento.cabec.Versao = "1";
            objCancelamento.cabec.transacao = true;

            objCancelamento.lote = new LoteCanc();
            objCancelamento.lote.Id = "Lote:" + DateTime.Now.ToString("ddMMyymmss");
            objCancelamento.lote.Nota = new List<LoteNota>();
            foreach (belPesquisaNotas nf in objNotas)
            {
                LoteNota nota = new LoteNota();
                nota.CarregaDados(nf.sCD_NFSEQ);
                nota.Id = "lote:" + nota.NumeroNota;
                objCancelamento.lote.Nota.Add(nota);
            }
        }


        public string Cancelar()
        {
            try
            {
                XmlSerializerNamespaces nameSpaces = new XmlSerializerNamespaces();
                nameSpaces.Add("xsi", "http://www.w3.org/2001/XMLSchema-instance");
                nameSpaces.Add("tipos", "http://localhost:8080/WsNFe2/tp");
                nameSpaces.Add("ns1", "http://localhost:8080/WsNFe2/lote");

                string sPath = Pastas.PROTOCOLOS + "\\REQ_CANC_LOTE_" + objCancelamento.lote.Id.Replace("Lote:", "") + ".xml";
                if (File.Exists(sPath))
                {
                    File.Delete(sPath);
                }

                string sXmlSerializer = null;
                XmlSerializer xs = new XmlSerializer(typeof(ReqCancelamentoNFSe));
                MemoryStream memory = new MemoryStream();
                XmlTextWriter xmltext = new XmlTextWriter(memory, Encoding.UTF8);
                xs.Serialize(xmltext, objCancelamento, nameSpaces);
                UTF8Encoding encoding = new UTF8Encoding();
                sXmlSerializer = encoding.GetString(memory.ToArray());
                sXmlSerializer = sXmlSerializer.Substring(1);

                belAssinaXml Assinatura = new belAssinaXml();
                sXmlSerializer = Assinatura.ConfigurarArquivo(sXmlSerializer, "Lote", Acesso.cert_NFs);


                //SerializeClassToXml.SerializeClasse<ReqCancelamentoNFSe>(objCancelamento, sPath, nameSpaces);

                XmlDocument xmlConsulta = new XmlDocument();
                xmlConsulta.LoadXml(sXmlSerializer);
                xmlConsulta.Save(sPath);
                belValidaXml.ValidarXml("http://localhost:8080/WsNFe2/lote", Pastas.SCHEMA_NFSE_DSF + "\\ReqCancelamentoNFSe.xsd", sPath);

                string sPathRetConsultaCanc = Pastas.PROTOCOLOS + "\\Ret_CANC_LOTE_" + objCancelamento.lote.Id.Replace("Lote:", "") + ".xml";



                HLP.GeraXml.WebService.NFSE_Campinas.LoteRpsService lt = new WebService.NFSE_Campinas.LoteRpsService();
                string sRetornoLote = lt.cancelar(xmlConsulta.InnerXml);

                xmlConsulta = new XmlDocument();
                xmlConsulta.LoadXml(sRetornoLote);
                xmlConsulta.Save(sPathRetConsultaCanc);


                //   sPathRetConsultaCanc = @"D:\Ret_CANC_LOTE_2805131157.xml";

                RetornoCancelamentoNFSe objretorno = SerializeClassToXml.DeserializeClasse<RetornoCancelamentoNFSe>(sPathRetConsultaCanc);

                string sMessageRetorno = TrataRetornoCancelamento(objretorno);
                return sMessageRetorno;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private string TrataRetornoCancelamento(RetornoCancelamentoNFSe objretorno)
        {
            string sRetorno = "Retorno não tratado.";

            if (objretorno.erros.Erro.Count() > 0)
            {
                sRetorno = "Erros Entrontrados no Lote de Cancelamento: " + Environment.NewLine;
                foreach (ErrosErroCanc erro in objretorno.erros.Erro)
                {
                    sRetorno += string.Format("Código:{0} - Msg:{1}.{2}", erro.Codigo, erro.Descricao, Environment.NewLine);
                }
            }
            if (objretorno.alertas.Alerta.Count() > 0)
            {
                foreach (AlertaCanc nota in objretorno.alertas.Alerta)
                {
                    sRetorno = "Alerta: " + nota.Descricao + Environment.NewLine;
                    if (nota.Codigo == "1301")
                    {
                        sRetorno += string.Format("Nota:{0}{1}", nota.ChaveNFe.NumeroNFe, Environment.NewLine);
                        base.UpdateToCancel(nota.ChaveNFe.NumeroNFe.ToString(), nota.ChaveNFe.CodigoVerificacao.ToString(), objCancelamento.lote.Nota.FirstOrDefault(c => c.CodigoVerificacao == nota.ChaveNFe.CodigoVerificacao).MotivoCancelamento);
                        DateTime dDT_EMISSAO = objNotas.FirstOrDefault(c => c.scd_numero_nfse == nota.ChaveNFe.NumeroNFe.ToString()).dDT_EMI;

                        if (dDT_EMISSAO != null)
                        {


                            string sFileOrigem = belCancelamentoDSF.GetFilePathMonthServico(true, nota.ChaveNFe.NumeroNFe.ToString(), dDT_EMISSAO);
                            string sFileDestino = belCancelamentoDSF.GetFilePathMonthServico(false, nota.ChaveNFe.NumeroNFe.ToString(), dDT_EMISSAO); //salvo na pasta envio com o numero do nfse.
                            if (File.Exists(sFileOrigem))
                            {
                                File.Move(sFileOrigem, sFileDestino);
                            }
                        }
                    }
                    else
                    {
                        sRetorno += string.Format("Código:{0} - Msg:{1}.{2}", nota.Codigo, nota.Descricao, Environment.NewLine);
                    }

                }
            }
            if (objretorno.notasCanc.Nota.Count() > 0)
            {
                sRetorno = "Notas Canceladas: " + Environment.NewLine;
                foreach (NotasCanceladasNota nota in objretorno.notasCanc.Nota)
                {
                    sRetorno += string.Format("Nota:{0}{1}", nota.NumeroNota, Environment.NewLine);
                    base.UpdateToCancel(nota.NumeroNota.ToString(), nota.CodigoVerificacao.ToString(), objCancelamento.lote.Nota.FirstOrDefault(c => c.CodigoVerificacao == nota.CodigoVerificacao).MotivoCancelamento);

                    DateTime dDT_EMISSAO = objNotas.FirstOrDefault(c => c.scd_numero_nfse == nota.NumeroNota.ToString()).dDT_EMI;

                    if (dDT_EMISSAO != null)
                    {


                        string sFileOrigem = belCancelamentoDSF.GetFilePathMonthServico(true, nota.NumeroNota.ToString(), dDT_EMISSAO);
                        string sFileDestino = belCancelamentoDSF.GetFilePathMonthServico(false, nota.NumeroNota.ToString(), dDT_EMISSAO); //salvo na pasta envio com o numero do nfse.
                        if (File.Exists(sFileOrigem))
                        {
                            File.Move(sFileOrigem, sFileDestino);
                        }
                    }
                }
            }
            return sRetorno;
        }

        /// <summary>
        /// true- enviados
        /// false- cancelados
        /// </summary>
        /// <param name="bStatus"></param>
        /// <param name="sNumero">NUMERO DO RPS </param>
        /// <returns></returns>
        public static string GetFilePathMonthServico(bool bStatus, string sNumero, DateTime dt)
        {

            string sDirectory = (bStatus ? Pastas.ENVIADOS : Pastas.CANCELADOS) + "\\Servicos\\" + dt.Date.Year.ToString().Substring(2, 2) + dt.Month.ToString().PadLeft(2, '0') + "\\";
            if (!Directory.Exists(sDirectory))
            {
                Directory.CreateDirectory(sDirectory);
            }

            string sName = (bStatus ? "NFSE_" : "NFSE_CANC_") + sNumero;

            return sDirectory + sName + ".xml";
        }






    }
}
