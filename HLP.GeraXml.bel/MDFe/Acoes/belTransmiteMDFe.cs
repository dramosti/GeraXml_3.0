using HLP.GeraXml.Comum.Static;
using HLP.GeraXml.dao.CTe.MDFe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace HLP.GeraXml.bel.MDFe.Acoes
{
    public class belTransmiteMDFe
    {

        public XmlDocument xml { get; set; }
        public TEnviMDFe enviMDFe;
        /// <summary>
        /// Recibo do envio
        /// </summary>
        public retEnviMDFe recibo = null;



        public belTransmiteMDFe(string sPath, TEnviMDFe enviMDFe, string sXML = null)
        {
            this.enviMDFe = enviMDFe;
            xml = new XmlDocument();
            xml.PreserveWhitespace = true;
            if (sXML == null)
                xml.Load(sPath);
            else
                xml.LoadXml(sXML);
        }


        public string TransmitirLote()
        {

            XmlNode xNelem = xml.DocumentElement;
            string sRet = string.Empty;

            if (Acesso.TP_AMB == 1)
            {
                HLP.GeraXml.WebService.MDFe_Producao_Recepcao.mdfeCabecMsg cabec = new WebService.MDFe_Producao_Recepcao.mdfeCabecMsg();
                HLP.GeraXml.WebService.MDFe_Producao_Recepcao.MDFeRecepcao servico = new WebService.MDFe_Producao_Recepcao.MDFeRecepcao();
                cabec.cUF = Acesso.cUF.ToString();
                cabec.versaoDados = Acesso.versaoMDFe;
                servico.mdfeCabecMsgValue = cabec;
                servico.ClientCertificates.Add(Acesso.cert_CTe);
                sRet = servico.mdfeRecepcaoLote(xNelem).OuterXml;
            }
            else
            {
                HLP.GeraXml.WebServiceHomologacao.MDFe_Homologacao_Recepcao.mdfeCabecMsg cabec = new WebServiceHomologacao.MDFe_Homologacao_Recepcao.mdfeCabecMsg();
                HLP.GeraXml.WebServiceHomologacao.MDFe_Homologacao_Recepcao.MDFeRecepcao servico = new WebServiceHomologacao.MDFe_Homologacao_Recepcao.MDFeRecepcao();
                cabec.cUF = Acesso.cUF.ToString();
                cabec.versaoDados = Acesso.versaoMDFe;
                servico.mdfeCabecMsgValue = cabec;
                servico.ClientCertificates.Add(Acesso.cert_CTe);
                sRet = servico.mdfeRecepcaoLote(xNelem).OuterXml;
            }

            if (sRet != string.Empty)
            {
                sRet = sRet.Replace(" xmlns=\"http://www.portalfiscal.inf.br/mdfe\" versao=\"1.00\"", "");

                string sPathRecibo = Pastas.PROTOCOLOS + enviMDFe.idLote + "-rec.xml";
                if (System.IO.File.Exists(sPathRecibo))
                {
                    System.IO.File.Delete(sPathRecibo);
                }

                XmlDocument x = new XmlDocument();
                x.LoadXml(sRet);
                x.Save(sPathRecibo);
                recibo = SerializeClassToXml.DeserializeClasse<retEnviMDFe>(sPathRecibo);
                daoManifesto.gravaRecibo(recibo.infRec.nRec, Convert.ToInt32(enviMDFe.MDFe.infMDFe.ide.cMDF).ToString().PadLeft(7, '0'));
                daoManifesto.gravaChave(enviMDFe.MDFe.infMDFe.Id.Replace("MDFe", ""), Convert.ToInt32(enviMDFe.MDFe.infMDFe.ide.cMDF).ToString().PadLeft(7, '0'));
                return recibo.infRec.nRec;
            }
            else
                return null;
        }



    }
}
