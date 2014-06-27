using HLP.GeraXml.Comum;
using HLP.GeraXml.Comum.Static;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace HLP.GeraXml.bel.MDFe.Acoes
{
    public class belConsultaStatusWebService
    {
        public TRetConsStatServ ExecuteConsulta()
        {
            TRetConsStatServ ret = null;

            try
            {
                string sReturn = string.Empty;
                if (Acesso.TP_AMB == 1) // Producao
                {
                    HLP.GeraXml.WebService.MDFe_Producao_StatusServico.MDFeStatusServico servico = new WebService.MDFe_Producao_StatusServico.MDFeStatusServico();
                    HLP.GeraXml.WebService.MDFe_Producao_StatusServico.mdfeCabecMsg cabec = new WebService.MDFe_Producao_StatusServico.mdfeCabecMsg();
                    cabec.cUF = Acesso.cUF.ToString();
                    cabec.versaoDados = Acesso.versaoMDFe.ToString();
                    servico.mdfeCabecMsgValue = cabec;
                    servico.ClientCertificates.Add(Acesso.cert_CTe);
                    sReturn = servico.mdfeStatusServicoMDF(this.GeraXml()).OuterXml;
                }
                else
                {
                    HLP.GeraXml.WebServiceHomologacao.MDFe_Homologacao_StatusServico.MDFeStatusServico servico = new HLP.GeraXml.WebServiceHomologacao.MDFe_Homologacao_StatusServico.MDFeStatusServico();
                    HLP.GeraXml.WebServiceHomologacao.MDFe_Homologacao_StatusServico.mdfeCabecMsg cabec = new HLP.GeraXml.WebServiceHomologacao.MDFe_Homologacao_StatusServico.mdfeCabecMsg();
                    cabec.cUF = Acesso.cUF.ToString();
                    cabec.versaoDados = Acesso.versaoMDFe.ToString();
                    servico.mdfeCabecMsgValue = cabec;
                    servico.ClientCertificates.Add(Acesso.cert_CTe);
                    sReturn = servico.mdfeStatusServicoMDF(this.GeraXml()).OuterXml;
                }

                if (sReturn != string.Empty)
                {
                    string sPath = Pastas.PROTOCOLOS + "\\" + DateTime.Now.ToString("ddMMyyyyHHmmSS") + "“-ret-sta.xml";
                    XmlDocument xmlRet = new XmlDocument();
                    xmlRet.LoadXml(sReturn);
                    xmlRet.Save(sPath);
                    ret = SerializeClassToXml.DeserializeClasse<TRetConsStatServ>(sPath);
                }
                else
                {
                    throw new Exception("Nenhum resultado obtido.");
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            return ret;
        }

        /// <summary>
        /// Gera Xml de consulta do status
        /// </summary>
        /// <param name="classe"></param>
        /// <returns></returns>
        public XmlNode GeraXml()
        {
            TConsStatServ classe = new TConsStatServ();
            string sPath = Pastas.PROTOCOLOS + "\\" + DateTime.Now.ToString("ddMMyyyyHHmmSS") + "“-ped-sta.xml";
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("", "http://www.portalfiscal.inf.br/mdfe");
            SerializeClassToXml.SerializeClasse<TConsStatServ>(classe: classe, sPathSave: sPath, namespac:ns);
            try
            {
                belValidaXml.ValidarXml("http://www.portalfiscal.inf.br/mdfe", Pastas.SCHEMA_MDFe + "\\consStatServMDFe_v1.00.xsd", sPath);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            XmlDocument xmlRet = new XmlDocument();
            xmlRet.Load(sPath);

            XmlNode node = xmlRet.DocumentElement;
            return node;

        }
    }
}
