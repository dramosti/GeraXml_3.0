using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Schema;
using System.Xml;
using System.Xml.Linq;
using HLP.GeraXml.Comum.Static;
using HLP.GeraXml.Comum;
using System.IO;

namespace HLP.GeraXml.bel.NFe
{

    public class belConsultaStatusNota
    {
        public const string sversaoLayoutCons = "2.01";
        public struct DadosRetorno
        {
            public string seqNota { get; set; }
            public string nNota { get; set; }
            public string cStat { get; set; }
            public string xMotivo { get; set; }
            public string chNFe { get; set; }
            public string dhRecbto { get; set; }
            public string nProt { get; set; }
            public string digVal { get; set; }

        }
        private belPesquisaNotas objPesquisa = null;
        public belConsultaStatusNota(belPesquisaNotas objPesquisa)
        {
            this.objPesquisa = objPesquisa;
        }


        private string consultaNFe()
        {
            XmlSchemaCollection myschema = new XmlSchemaCollection();
            string sxdoc = "";
            XNamespace pf = "http://www.portalfiscal.inf.br/nfe";

            try
            {
                XDocument xdoc = new XDocument(new XElement(pf + "consSitNFe", new XAttribute("versao", sversaoLayoutCons),//sversaoLayoutCons),
                                                  new XElement(pf + "tpAmb", Acesso.TP_AMB.ToString()),
                                                   new XElement(pf + "xServ", "CONSULTAR"),
                                                   new XElement(pf + "chNFe", objPesquisa.sCHAVENFE)));

                string sCaminhoConsulta = Pastas.PROTOCOLOS + "Consulta_" + objPesquisa.sCHAVENFE + ".xml";
                if (File.Exists(sCaminhoConsulta))
                {
                    File.Delete(sCaminhoConsulta);
                }
                StreamWriter writer = new StreamWriter(sCaminhoConsulta);
                writer.Write(xdoc.ToString());
                writer.Close();
                //belValidaXml.ValidarXml("http://www.portalfiscal.inf.br/nfe", Pastas.SCHEMA_NFE + "\\2.01\\consSitNFe_v2.01.xsd", sCaminhoConsulta);
                sxdoc = xdoc.ToString();

            }
            catch (XmlException x)
            {
                throw new Exception(x.Message.ToString());
            }
            catch (XmlSchemaException x)
            {
                throw new Exception(x.Message.ToString());
            }
            return sxdoc;
        }

        public DadosRetorno buscaRetorno()
        {
            string sDados = consultaNFe();
            XmlDocument xmlConsulta = new XmlDocument();
            XmlDocument xret = new XmlDocument();
            try
            {
                if (Acesso.TP_EMIS == 1)
                {
                    switch (Acesso.xUFtoWS)
                    {
                        case "SP":
                            {
                                if (Acesso.TP_AMB == 2)
                                {
                                    HLP.GeraXml.WebService.v2_Homologacao_NFeConsulta_SP.NfeConsulta2 ws2 = new HLP.GeraXml.WebService.v2_Homologacao_NFeConsulta_SP.NfeConsulta2();
                                    HLP.GeraXml.WebService.v2_Homologacao_NFeConsulta_SP.nfeCabecMsg cabec = new HLP.GeraXml.WebService.v2_Homologacao_NFeConsulta_SP.nfeCabecMsg();
                                    cabec.versaoDados = sversaoLayoutCons;
                                    belUF objUf = new belUF();
                                    cabec.cUF = objUf.RetornaCUF(Acesso.xUF);
                                    ws2.nfeCabecMsgValue = cabec;
                                    ws2.ClientCertificates.Add(Acesso.cert_NFe);
                                    xmlConsulta.LoadXml(sDados);
                                    XmlNode xNodeConsulta = xmlConsulta.DocumentElement;
                                    xmlConsulta.LoadXml(ws2.nfeConsultaNF2(xNodeConsulta).OuterXml);

                                }
                                else
                                {
                                    HLP.GeraXml.WebService.v2_Producao_NFeConsulta_SP.NfeConsulta2 ws2 = new HLP.GeraXml.WebService.v2_Producao_NFeConsulta_SP.NfeConsulta2();
                                    HLP.GeraXml.WebService.v2_Producao_NFeConsulta_SP.nfeCabecMsg cabec = new HLP.GeraXml.WebService.v2_Producao_NFeConsulta_SP.nfeCabecMsg();
                                    cabec.versaoDados = sversaoLayoutCons;
                                    belUF objUf = new belUF();
                                    cabec.cUF = objUf.RetornaCUF(Acesso.xUF);
                                    ws2.nfeCabecMsgValue = cabec;
                                    ws2.ClientCertificates.Add(Acesso.cert_NFe);
                                    xmlConsulta.LoadXml(sDados);
                                    XmlNode xNodeConsulta = xmlConsulta.DocumentElement;
                                    xmlConsulta.LoadXml(ws2.nfeConsultaNF2(xNodeConsulta).OuterXml);
                                }
                            }
                            break;
                        case "RS":
                            {
                                if (Acesso.TP_AMB == 2)
                                {
                                    HLP.GeraXml.WebService.v2_Homologacao_NFeConsulta_RS.NfeConsulta2 ws2 = new HLP.GeraXml.WebService.v2_Homologacao_NFeConsulta_RS.NfeConsulta2();
                                    HLP.GeraXml.WebService.v2_Homologacao_NFeConsulta_RS.nfeCabecMsg cabec = new HLP.GeraXml.WebService.v2_Homologacao_NFeConsulta_RS.nfeCabecMsg();
                                    cabec.versaoDados = sversaoLayoutCons;
                                    belUF objUf = new belUF();
                                    cabec.cUF = objUf.RetornaCUF(Acesso.xUF);
                                    ws2.nfeCabecMsgValue = cabec;
                                    ws2.ClientCertificates.Add(Acesso.cert_NFe);
                                    xmlConsulta.LoadXml(sDados);
                                    XmlNode xNodeConsulta = xmlConsulta.DocumentElement;
                                    xmlConsulta.LoadXml(ws2.nfeConsultaNF2(xNodeConsulta).OuterXml);

                                }
                                else
                                {
                                    HLP.GeraXml.WebService.v2_Producao_NFeConsulta_RS.NfeConsulta2 ws2 = new HLP.GeraXml.WebService.v2_Producao_NFeConsulta_RS.NfeConsulta2();
                                    HLP.GeraXml.WebService.v2_Producao_NFeConsulta_RS.nfeCabecMsg cabec = new HLP.GeraXml.WebService.v2_Producao_NFeConsulta_RS.nfeCabecMsg();
                                    cabec.versaoDados = sversaoLayoutCons;
                                    belUF objUf = new belUF();
                                    cabec.cUF = objUf.RetornaCUF(Acesso.xUF);
                                    ws2.nfeCabecMsgValue = cabec;
                                    ws2.ClientCertificates.Add(Acesso.cert_NFe);
                                    xmlConsulta.LoadXml(sDados);
                                    XmlNode xNodeConsulta = xmlConsulta.DocumentElement;
                                    xmlConsulta.LoadXml(ws2.nfeConsultaNF2(xNodeConsulta).OuterXml);
                                }
                            }
                            break;
                        case "MS":
                            {
                                if (Acesso.TP_AMB == 2)
                                {
                                    HLP.GeraXml.WebService.v2_Homologacao_NFeConsulta_MS.NfeConsulta2 ws2 = new HLP.GeraXml.WebService.v2_Homologacao_NFeConsulta_MS.NfeConsulta2();
                                    HLP.GeraXml.WebService.v2_Homologacao_NFeConsulta_MS.nfeCabecMsg cabec = new HLP.GeraXml.WebService.v2_Homologacao_NFeConsulta_MS.nfeCabecMsg();
                                    cabec.versaoDados = sversaoLayoutCons;
                                    belUF objUf = new belUF();
                                    cabec.cUF = objUf.RetornaCUF(Acesso.xUF);
                                    ws2.nfeCabecMsgValue = cabec;
                                    ws2.ClientCertificates.Add(Acesso.cert_NFe);
                                    xmlConsulta.LoadXml(sDados);
                                    XmlNode xNodeConsulta = xmlConsulta.DocumentElement;
                                    xmlConsulta.LoadXml(ws2.nfeConsultaNF2(xNodeConsulta).OuterXml);

                                }
                                else
                                {
                                    HLP.GeraXml.WebService.v2_Producao_NFeConsulta_MS.NfeConsulta2 ws2 = new HLP.GeraXml.WebService.v2_Producao_NFeConsulta_MS.NfeConsulta2();
                                    HLP.GeraXml.WebService.v2_Producao_NFeConsulta_MS.nfeCabecMsg cabec = new HLP.GeraXml.WebService.v2_Producao_NFeConsulta_MS.nfeCabecMsg();
                                    cabec.versaoDados = sversaoLayoutCons;
                                    belUF objUf = new belUF();
                                    cabec.cUF = objUf.RetornaCUF(Acesso.xUF);
                                    ws2.nfeCabecMsgValue = cabec;
                                    ws2.ClientCertificates.Add(Acesso.cert_NFe);
                                    xmlConsulta.LoadXml(sDados);
                                    XmlNode xNodeConsulta = xmlConsulta.DocumentElement;
                                    xmlConsulta.LoadXml(ws2.nfeConsultaNF2(xNodeConsulta).OuterXml);
                                }
                            }
                            break;
                        case "SVRS":
                            {
                                if (Acesso.TP_AMB == 2)
                                {
                                    HLP.GeraXml.WebService.V2_Homologacao_Consulta_SVRS.NfeConsulta2 ws2 = new HLP.GeraXml.WebService.V2_Homologacao_Consulta_SVRS.NfeConsulta2();
                                    HLP.GeraXml.WebService.V2_Homologacao_Consulta_SVRS.nfeCabecMsg cabec = new HLP.GeraXml.WebService.V2_Homologacao_Consulta_SVRS.nfeCabecMsg();
                                    cabec.versaoDados = sversaoLayoutCons;
                                    belUF objUf = new belUF();
                                    cabec.cUF = objUf.RetornaCUF(Acesso.xUF);
                                    ws2.nfeCabecMsgValue = cabec;
                                    ws2.ClientCertificates.Add(Acesso.cert_NFe);
                                    xmlConsulta.LoadXml(sDados);
                                    XmlNode xNodeConsulta = xmlConsulta.DocumentElement;
                                    xmlConsulta.LoadXml(ws2.nfeConsultaNF2(xNodeConsulta).OuterXml);

                                }
                                else
                                {
                                    HLP.GeraXml.WebService.V2_Producao_Consulta_SVRS.NfeConsulta2 ws2 = new HLP.GeraXml.WebService.V2_Producao_Consulta_SVRS.NfeConsulta2();
                                    HLP.GeraXml.WebService.V2_Producao_Consulta_SVRS.nfeCabecMsg cabec = new HLP.GeraXml.WebService.V2_Producao_Consulta_SVRS.nfeCabecMsg();
                                    cabec.versaoDados = sversaoLayoutCons;
                                    belUF objUf = new belUF();
                                    cabec.cUF = objUf.RetornaCUF(Acesso.xUF);
                                    ws2.nfeCabecMsgValue = cabec;
                                    ws2.ClientCertificates.Add(Acesso.cert_NFe);
                                    xmlConsulta.LoadXml(sDados);
                                    XmlNode xNodeConsulta = xmlConsulta.DocumentElement;
                                    xmlConsulta.LoadXml(ws2.nfeConsultaNF2(xNodeConsulta).OuterXml);
                                }
                            }
                            break;
                        case "MG":
                            {
                                if (Acesso.TP_AMB == 2)
                                {
                                    HLP.GeraXml.WebService.v2_Homologacao_NfeConsultaProtocolo_MG.NfeConsulta2 ws2 = new HLP.GeraXml.WebService.v2_Homologacao_NfeConsultaProtocolo_MG.NfeConsulta2();
                                    HLP.GeraXml.WebService.v2_Homologacao_NfeConsultaProtocolo_MG.nfeCabecMsg cabec = new HLP.GeraXml.WebService.v2_Homologacao_NfeConsultaProtocolo_MG.nfeCabecMsg();
                                    cabec.versaoDados = sversaoLayoutCons;
                                    belUF objUf = new belUF();
                                    cabec.cUF = objUf.RetornaCUF(Acesso.xUF);
                                    ws2.nfeCabecMsgValue = cabec;
                                    ws2.ClientCertificates.Add(Acesso.cert_NFe);
                                    xmlConsulta.LoadXml(sDados);
                                    XmlNode xNodeConsulta = xmlConsulta.DocumentElement;
                                    xmlConsulta.LoadXml(ws2.nfeConsultaNF2(xNodeConsulta).OuterXml);

                                }
                                else
                                {
                                    HLP.GeraXml.WebService.v2_Producao_NfeConsultaProtocolo_MG.NfeConsulta2 ws2 = new HLP.GeraXml.WebService.v2_Producao_NfeConsultaProtocolo_MG.NfeConsulta2();
                                    HLP.GeraXml.WebService.v2_Producao_NfeConsultaProtocolo_MG.nfeCabecMsg cabec = new HLP.GeraXml.WebService.v2_Producao_NfeConsultaProtocolo_MG.nfeCabecMsg();
                                    cabec.versaoDados = sversaoLayoutCons;
                                    belUF objUf = new belUF();
                                    cabec.cUF = objUf.RetornaCUF(Acesso.xUF);
                                    ws2.nfeCabecMsgValue = cabec;
                                    ws2.ClientCertificates.Add(Acesso.cert_NFe);
                                    xmlConsulta.LoadXml(sDados);
                                    XmlNode xNodeConsulta = xmlConsulta.DocumentElement;
                                    xmlConsulta.LoadXml(ws2.nfeConsultaNF2(xNodeConsulta).OuterXml);
                                }
                            }
                            break;

                    }
                }
                else if (Acesso.TP_EMIS == 3)
                {
                    if (Acesso.TP_AMB == 2)
                    {
                        HLP.GeraXml.WebService.v2_SCAN_Homologacao_NFeConsulta.NfeConsulta2 ws2 = new HLP.GeraXml.WebService.v2_SCAN_Homologacao_NFeConsulta.NfeConsulta2();
                        HLP.GeraXml.WebService.v2_SCAN_Homologacao_NFeConsulta.nfeCabecMsg cabec = new HLP.GeraXml.WebService.v2_SCAN_Homologacao_NFeConsulta.nfeCabecMsg();
                        cabec.versaoDados = sversaoLayoutCons;
                        belUF objUf = new belUF();
                        cabec.cUF = objUf.RetornaCUF(Acesso.xUF);
                        ws2.nfeCabecMsgValue = cabec;
                        ws2.ClientCertificates.Add(Acesso.cert_NFe);
                        xmlConsulta.LoadXml(sDados);
                        XmlNode xNodeConsulta = xmlConsulta.DocumentElement;
                        xmlConsulta.LoadXml(ws2.nfeConsultaNF2(xNodeConsulta).OuterXml);

                    }
                    else
                    {
                        HLP.GeraXml.WebService.v2_SCAN_Producao_NFeConsulta.NfeConsulta2 ws2 = new HLP.GeraXml.WebService.v2_SCAN_Producao_NFeConsulta.NfeConsulta2();
                        HLP.GeraXml.WebService.v2_SCAN_Producao_NFeConsulta.nfeCabecMsg cabec = new HLP.GeraXml.WebService.v2_SCAN_Producao_NFeConsulta.nfeCabecMsg();
                        cabec.versaoDados = sversaoLayoutCons;
                        belUF objUf = new belUF();
                        cabec.cUF = objUf.RetornaCUF(Acesso.xUF);
                        ws2.nfeCabecMsgValue = cabec;
                        ws2.ClientCertificates.Add(Acesso.cert_NFe);
                        xmlConsulta.LoadXml(sDados);
                        XmlNode xNodeConsulta = xmlConsulta.DocumentElement;
                        xmlConsulta.LoadXml(ws2.nfeConsultaNF2(xNodeConsulta).OuterXml);
                    }

                }

                return CarregaDadosRetorno(xmlConsulta);
            }
            catch (Exception)
            {

                throw;
            }

        }

        private DadosRetorno CarregaDadosRetorno(XmlDocument xmlret)
        {
            DadosRetorno objRetorno = new DadosRetorno();
            objRetorno.cStat = xmlret.GetElementsByTagName("cStat")[0].InnerText;
            if ((objRetorno.cStat == "100") || (objRetorno.cStat == "101") || (objRetorno.cStat == "110"))
            {
                string[] split = xmlret.GetElementsByTagName("dhRecbto")[0].InnerText.Split('T');
                string datahoranfe = "";
                int i = 0;
                foreach (var item in split)
                {
                    i++;
                    if (i == 1)
                    {
                        datahoranfe = datahoranfe + Convert.ToDateTime(item).ToString("dd-MM-yyyy") + " ";
                    }
                    else
                    {
                        datahoranfe = datahoranfe + item;
                    }
                }
                objRetorno.dhRecbto = datahoranfe;
                objRetorno.nProt = xmlret.GetElementsByTagName("nProt")[0].InnerText;
                objRetorno.digVal = (xmlret.GetElementsByTagName("digVal")[0] != null ? xmlret.GetElementsByTagName("digVal")[0].InnerText : "");
            }
            else
            {
                objRetorno.dhRecbto = "s/data";
                objRetorno.nProt = "inexistente";
                objRetorno.digVal = "inexistente";
            }
            objRetorno.xMotivo = xmlret.GetElementsByTagName("xMotivo")[0].InnerText;
            objRetorno.chNFe = xmlret.GetElementsByTagName("chNFe")[0].InnerText;
            objRetorno.nNota = objPesquisa.sCD_NOTAFIS;
            objRetorno.seqNota = objPesquisa.sCD_NFSEQ;
            return objRetorno;
        }

    }



}
