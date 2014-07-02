using HLP.GeraXml.Comum;
using HLP.GeraXml.Comum.Static;
using HLP.GeraXml.dao;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace HLP.GeraXml.bel.MDFe.Acoes
{
    public sealed class belEventoMDFe
    {
        private TEvento evento { get; set; }
        public TRetEvento retorno { get; set; }
        public PesquisaManifestosModel objPesquisa { get; set; }
        public string sMessage { get; set; }
        public belEventoMDFe(XmlElement AnyXml, PesquisaManifestosModel objPesquisa, string tpEvento, string nSeq = "1")
        {
            this.objPesquisa = objPesquisa;
            evento = new TEvento();
            evento.versao = Acesso.versaoMDFe;
            evento.infEvento = new TEventoInfEvento();
            evento.infEvento.Id = "ID" + tpEvento + objPesquisa.chaveMDFe + nSeq.PadLeft(2,'0');
            evento.infEvento.cOrgao = Convert.ToByte(Acesso.cUF).ToString();
            evento.infEvento.tpAmb = Acesso.TP_AMB == 1 ? TAmb.Item1 : TAmb.Item2;
            evento.infEvento.CNPJ = Util.RetiraCaracterCNPJ(Acesso.CNPJ_EMPRESA);
            evento.infEvento.chMDFe = objPesquisa.chaveMDFe;
            evento.infEvento.dhEvento = daoUtil.GetDateServidor().ToString("yyyy-MM-ddTHH:mm:ss");
            evento.infEvento.tpEvento = tpEvento;
            evento.infEvento.nSeqEvento = nSeq;
            evento.infEvento.detEvento = new TEventoInfEventoDetEvento();
            evento.infEvento.detEvento.versaoEvento = Acesso.versaoMDFe;
            evento.infEvento.detEvento.Any = AnyXml;
        }
        public bool ExecuteEvento()
        {
            try
            {
                XmlSerializerNamespaces nameSpaces = new XmlSerializerNamespaces();
                nameSpaces.Add("", "");
                nameSpaces.Add("", "http://www.portalfiscal.inf.br/mdfe");

                XmlSerializer xs = new XmlSerializer(typeof(TEvento));
                MemoryStream memory = new MemoryStream();
                XmlTextWriter xmltext = new XmlTextWriter(memory, Encoding.UTF8);
                xs.Serialize(xmltext, evento, nameSpaces);
                UTF8Encoding encoding = new UTF8Encoding();
                string sEvento = encoding.GetString(memory.ToArray());
                sEvento = sEvento.Substring(1);


                belAssinaXml Assinatura = new belAssinaXml();
                sEvento = Assinatura.ConfigurarArquivo(sEvento, "infEvento", Acesso.cert_CTe);

                XmlDocument xDoc = new XmlDocument();
                xDoc.LoadXml(sEvento);
                string sPath = Pastas.PROTOCOLOS + "\\" + objPesquisa.chaveMDFe + "_ped-can-mdfe.xml";
                if (File.Exists(sPath))
                {
                    File.Delete(sPath);
                }
                xDoc.Save(sPath);
                try
                {
                    belValidaXml.ValidarXml("http://www.portalfiscal.inf.br/mdfe", Pastas.SCHEMA_MDFe + "\\eventoMDFe_v1.00.xsd", sPath);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                #region Cancelar Cte
                XmlDocument doc = new XmlDocument();
                doc.Load(sPath);
                string sRetorno = Execute(doc);
                XDocument xRet = XDocument.Parse(sRetorno);
                xRet.Save(sPath);
                retorno = SerializeClassToXml.DeserializeClasse<TRetEvento>(sPath);
                if (retorno.infEvento.cStat != "135")
                {
                    File.Delete(sPath);
                }
                sMessage = string.Format("Codigo do Retorno: {0}{1}Motivo: {2}{1}Chave: {3}{1}Protocolo: {4}{1}",
                    retorno.infEvento.cStat,
                    Environment.NewLine,
                    retorno.infEvento.xMotivo,
                    retorno.infEvento.chMDFe,
                    retorno.infEvento.nProt);

                if (retorno.infEvento.cStat == "135")
                {
                    return true;
                }
                else
                {
                    return false;
                }
                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        private string Execute(XmlDocument doc)
        {
            string sRetorno = "";

            try
            {
                //Homologação
                if (Acesso.TP_AMB == 2)
                {
                    HLP.GeraXml.WebServiceHomologacao.MDFe_Homologacao_RecepcaoEvento.mdfeCabecMsg cabec = new WebServiceHomologacao.MDFe_Homologacao_RecepcaoEvento.mdfeCabecMsg();
                    cabec.cUF = Acesso.cUF.ToString();
                    cabec.versaoDados = Acesso.versaoMDFe;
                    HLP.GeraXml.WebServiceHomologacao.MDFe_Homologacao_RecepcaoEvento.MDFeRecepcaoEvento ws = new WebServiceHomologacao.MDFe_Homologacao_RecepcaoEvento.MDFeRecepcaoEvento();
                    ws.mdfeCabecMsgValue = cabec;
                    ws.ClientCertificates.Add(Acesso.cert_CTe);
                    sRetorno = ws.mdfeRecepcaoEvento(doc).OuterXml;

                }
                //Produção
                else if (Acesso.TP_AMB == 1)
                {

                    HLP.GeraXml.WebService.MDFe_Producao_RecepcaoEvento.mdfeCabecMsg cabec = new HLP.GeraXml.WebService.MDFe_Producao_RecepcaoEvento.mdfeCabecMsg();
                    HLP.GeraXml.WebService.MDFe_Producao_RecepcaoEvento.MDFeRecepcaoEvento ws = new WebService.MDFe_Producao_RecepcaoEvento.MDFeRecepcaoEvento();
                    cabec.cUF = Acesso.cUF.ToString();
                    cabec.versaoDados = Acesso.versaoMDFe;
                    ws.mdfeCabecMsgValue = cabec;
                    ws.ClientCertificates.Add(Acesso.cert_CTe);
                    sRetorno = ws.mdfeRecepcaoEvento(doc).OuterXml;
                }
                return sRetorno;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
