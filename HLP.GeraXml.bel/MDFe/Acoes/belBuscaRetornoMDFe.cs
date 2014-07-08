using HLP.GeraXml.Comum.Static;
using HLP.GeraXml.dao.CTe.MDFe;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace HLP.GeraXml.bel.MDFe.Acoes
{
    public class belBuscaRetornoMDFe
    {
        PesquisaManifestosModel objPesquisa;
        XmlDocument xmlConsulta = null;
        XmlDocument xmlRetorno = null;
        public string sMessage { get; set; }

        public belBuscaRetornoMDFe(PesquisaManifestosModel objPesquisa)
        {
            this.objPesquisa = objPesquisa;
            TConsReciMDFe objconsulta = new TConsReciMDFe();
            objconsulta.versao = Acesso.versaoMDFe;
            objconsulta.tpAmb = Acesso.TP_AMB == 1 ? TAmb.Item1 : TAmb.Item2;
            objconsulta.nRec = this.objPesquisa.recibo;
            string sPathSave = Pastas.PROTOCOLOS + "Rec_" + this.objPesquisa.numero + ".xml";
            if (File.Exists(sPathSave))
                File.Delete(sPathSave);
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("", "http://www.portalfiscal.inf.br/mdfe");
            SerializeClassToXml.SerializeClasse<TConsReciMDFe>(objconsulta, sPathSave, ns);
            xmlConsulta = new XmlDocument();
            xmlConsulta.PreserveWhitespace = false;
            xmlConsulta.Load(sPathSave);
        }

        public void BuscarRetorno()
        {
            daoManifesto.AlteraUltimoRetorno(objPesquisa.sequencia);
            string sRetorno = string.Empty;
            XmlNode xNodeRet = xmlConsulta.DocumentElement;
            if (Acesso.TP_AMB == 1)
            {
                HLP.GeraXml.WebService.MDFe_Producao_RetRecepcao.mdfeCabecMsg cabec = new WebService.MDFe_Producao_RetRecepcao.mdfeCabecMsg();
                HLP.GeraXml.WebService.MDFe_Producao_RetRecepcao.MDFeRetRecepcao ws = new WebService.MDFe_Producao_RetRecepcao.MDFeRetRecepcao();
                cabec.cUF = Acesso.cUF.ToString();
                cabec.versaoDados = Acesso.versaoMDFe;
                ws.mdfeCabecMsgValue = cabec;
                ws.ClientCertificates.Add(Acesso.cert_CTe);
                sRetorno = ws.mdfeRetRecepcao(xNodeRet).OuterXml;
            }
            else
            {
                HLP.GeraXml.WebServiceHomologacao.MDFe_Homologacao_RetRecepcao.mdfeCabecMsg cabec = new WebServiceHomologacao.MDFe_Homologacao_RetRecepcao.mdfeCabecMsg();
                HLP.GeraXml.WebServiceHomologacao.MDFe_Homologacao_RetRecepcao.MDFeRetRecepcao ws = new WebServiceHomologacao.MDFe_Homologacao_RetRecepcao.MDFeRetRecepcao();
                cabec.cUF = Acesso.cUF.ToString();
                cabec.versaoDados = Acesso.versaoMDFe;
                ws.mdfeCabecMsgValue = cabec;
                ws.ClientCertificates.Add(Acesso.cert_CTe);
                sRetorno = ws.mdfeRetRecepcao(xNodeRet).OuterXml;
            }

            if (sRetorno != "")
            {
                string sPath = Pastas.PROTOCOLOS + Convert.ToInt32(objPesquisa.numero) + "-pro-rec.xml";
                if (File.Exists(sPath))
                    File.Delete(sPath);
                xmlRetorno = new XmlDocument();
                xmlRetorno.LoadXml(sRetorno);
                xmlRetorno.Save(sPath);
                TRetConsReciMDFe recepacao = SerializeClassToXml.DeserializeClasse<TRetConsReciMDFe>(sPath);

                sMessage = string.Format("Sequencia: {0}{4}Numero: {1}{4}Motivo: {2}{4}Status: {3}{4}",
                        objPesquisa.sequencia,
                        objPesquisa.numero,
                        recepacao.protMDFe != null ? recepacao.protMDFe.infProt.xMotivo : recepacao.xMotivo,
                        recepacao.cStat,
                        Environment.NewLine);

                if (recepacao.cStat != "104")
                {

                    daoManifesto.LimpaRecibo(objPesquisa.sequencia);
                }
                else
                {
                    if (recepacao.protMDFe != null)
                    {
                        //if (recepacao.cStat == "104")
                        //{
                        //    string sRec = recepacao.protMDFe.infProt.xMotivo.Substring(recepacao.protMDFe.infProt.xMotivo.IndexOf("nRec:"), 20).Replace("nRec:", "");
                        //    daoManifesto.gravaRecibo(sRec, objPesquisa.sequencia);
                        //    daoManifesto.AlteraStatusMDFe(objPesquisa.sequencia, "S");
                        //    daoManifesto.AlteraUltimoRetornoNULL(objPesquisa.sequencia);
                        //    //IncluiTagInfProc();
                        //}
                        //else
                        if (recepacao.protMDFe.infProt.cStat == "100")
                        {
                            daoManifesto.gravaProtocolo(recepacao.protMDFe.infProt.nProt, objPesquisa.sequencia);
                            daoManifesto.AlteraStatusMDFe(objPesquisa.sequencia, "S");
                            IncluiTagInfProc();
                        }
                        else if (recepacao.protMDFe.infProt.cStat == "101") //CANCELADO.
                        {
                            daoManifesto.gravaProtocolo(recepacao.nRec, objPesquisa.sequencia);

                        }
                        else if (recepacao.protMDFe.infProt.cStat == "204") //DUPLICADO.
                        {
                            string sRec = recepacao.protMDFe.infProt.xMotivo.Substring(recepacao.protMDFe.infProt.xMotivo.IndexOf("nRec:"), 20).Replace("nRec:", "");
                            daoManifesto.gravaRecibo(sRec, objPesquisa.sequencia);
                            daoManifesto.AlteraStatusMDFe(objPesquisa.sequencia, "S");
                            //IncluiTagInfProc();
                            daoManifesto.AlteraUltimoRetornoNULL(objPesquisa.sequencia);
                            // BuscarRetorno();

                        }
                        else if (recepacao.protMDFe.infProt.cStat == "105") //LOTE EM PROCESSAMENTO.
                        {
                            daoManifesto.gravaProtocolo(recepacao.nRec, objPesquisa.sequencia);
                        }
                        else
                        {
                            daoManifesto.LimpaRecibo(objPesquisa.sequencia);
                        }
                    }
                    else
                    {
                        daoManifesto.LimpaRecibo(objPesquisa.sequencia);
                    }
                }
            }
        }





        private void IncluiTagInfProc()
        {
            try
            {

                XNamespace pf = "http://www.portalfiscal.inf.br/mdfe";
                //Geração do Xml da nfe Autorizado, incluindo a TAG infProc onde consta as informaçoes de retorno da nfe.

                string sCodificacao = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>";
                string sRetProc = "<mdfeProc versao=\"1.00\" xmlns=\"http://www.portalfiscal.inf.br/mdfe\">";
                XmlDocument xmldoc = new XmlDocument();
                xmldoc.Load(Pastas.ENVIO + this.objPesquisa.chaveMDFe.Substring(2, 4) + "\\Lote_" + Convert.ToInt32(this.objPesquisa.numero).ToString() + ".xml");

                XmlNode xret = xmlRetorno.GetElementsByTagName("protMDFe")[0];
                StreamWriter sw = new StreamWriter(Util.BuscaCaminhoArquivoXml(this.objPesquisa.chaveMDFe, 2));

                if (xmldoc.FirstChild.Name.Equals("xml"))
                {
                    sw.Write(@sRetProc + xmldoc.OuterXml.Remove(0, 38) + @xret.OuterXml.ToString() + @"</mdfeProc>");
                }
                else
                {
                    sw.Write(@sCodificacao + @sRetProc + xmldoc.OuterXml + @xret.OuterXml.ToString() + @"</mdfeProc>");
                }
                sw.Close();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



    }
}
