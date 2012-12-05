using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Schema;
using System.Xml;
using HLP.GeraXml.dao;
using HLP.GeraXml.Comum.Static;
using System.Xml.Linq;
using HLP.GeraXml.Comum;
using HLP.GeraXml.dao.NFe;

namespace HLP.GeraXml.bel.NFe
{
    public class belInutilizacao :  daoInutilizacao
    {
        public string _nnfini { get; set; }
        public string _nnffim { get; set; }
        public string _serie { get; set; }
        public string _sjust { get; set; }
        public string _id { get; set; }
        public string _mod = "55";
        public string _sPath { get; set; }
        public XNamespace pf = "http://www.portalfiscal.inf.br/nfe";

        public struct DadosRetorno
        {
            public string tpAmb { get; set; }
            public string cStat { get; set; }
            public string xMotivo { get; set; }
            public string ano { get; set; }
            public string mod { get; set; }
            public string serie { get; set; }
            public string nNFIni { get; set; }
            public string nNFFin { get; set; }
            public string dhRecbto { get; set; }
            public string nProt { get; set; }


        }

        public belInutilizacao(string nnfini, string nnffim, string serie, string sjust)
        {
            _nnffim = nnffim;
            _nnfini = nnfini;
            _serie = serie;
            _sjust = sjust;
        }


        public DadosRetorno InutilizaNumeracao()
        {
            try
            {
                string sRetorno = string.Empty;
                NfeDadosMgs();
                if (Acesso.TP_EMIS == 1)
                {
                    switch (Acesso.xUFtoWS)
                    {
                        case "SP":
                            {
                                if (Acesso.TP_AMB == 1)
                                {
                                    HLP.GeraXml.WebService.v2_Producao_NFeInutilizacao_SP.nfeCabecMsg cabec = new HLP.GeraXml.WebService.v2_Producao_NFeInutilizacao_SP.nfeCabecMsg();
                                    HLP.GeraXml.WebService.v2_Producao_NFeInutilizacao_SP.NfeInutilizacao2 ws2 = new HLP.GeraXml.WebService.v2_Producao_NFeInutilizacao_SP.NfeInutilizacao2();
                                    cabec.cUF = Acesso.cUF.ToString();
                                    cabec.versaoDados = Acesso.versaoNFe;
                                    ws2.ClientCertificates.Add(Acesso.cert_NFe);
                                    ws2.nfeCabecMsgValue = cabec;

                                    XmlDocument xmlInut = new XmlDocument();
                                    xmlInut.Load(_sPath);
                                    XmlNode xNodeInut = xmlInut.DocumentElement;
                                    sRetorno = ws2.nfeInutilizacaoNF2(xNodeInut).OuterXml;

                                }
                                else
                                {
                                    HLP.GeraXml.WebService.v2_Homologacao_NFeInutilizacao_SP.nfeCabecMsg cabec = new HLP.GeraXml.WebService.v2_Homologacao_NFeInutilizacao_SP.nfeCabecMsg();
                                    HLP.GeraXml.WebService.v2_Homologacao_NFeInutilizacao_SP.NfeInutilizacao2 ws2 = new HLP.GeraXml.WebService.v2_Homologacao_NFeInutilizacao_SP.NfeInutilizacao2();
                                    cabec.cUF = Acesso.cUF.ToString();
                                    cabec.versaoDados = "2.00";
                                    ws2.ClientCertificates.Add(Acesso.cert_NFe);
                                    ws2.nfeCabecMsgValue = cabec;

                                    XmlDocument xmlInut = new XmlDocument();
                                    xmlInut.Load(_sPath);
                                    XmlNode xNodeInut = xmlInut.DocumentElement;
                                    sRetorno = ws2.nfeInutilizacaoNF2(xNodeInut).OuterXml;

                                }
                            }
                            break;
                        case "MS":
                            {
                                if (Acesso.TP_AMB == 1)
                                {
                                    HLP.GeraXml.WebService.v2_Producao_NFeInutilizacao_MS.nfeCabecMsg cabec = new HLP.GeraXml.WebService.v2_Producao_NFeInutilizacao_MS.nfeCabecMsg();
                                    HLP.GeraXml.WebService.v2_Producao_NFeInutilizacao_MS.NfeInutilizacao2 ws2 = new HLP.GeraXml.WebService.v2_Producao_NFeInutilizacao_MS.NfeInutilizacao2();
                                    cabec.cUF = Acesso.cUF.ToString();
                                    cabec.versaoDados = Acesso.versaoNFe;
                                    ws2.ClientCertificates.Add(Acesso.cert_NFe);
                                    ws2.nfeCabecMsgValue = cabec;

                                    XmlDocument xmlInut = new XmlDocument();
                                    xmlInut.Load(_sPath);
                                    XmlNode xNodeInut = xmlInut.DocumentElement;
                                    sRetorno = ws2.nfeInutilizacaoNF2(xNodeInut).OuterXml;

                                }
                                else
                                {
                                    HLP.GeraXml.WebService.v2_Homologacao_NFeInutilizacao_MS.nfeCabecMsg cabec = new HLP.GeraXml.WebService.v2_Homologacao_NFeInutilizacao_MS.nfeCabecMsg();
                                    HLP.GeraXml.WebService.v2_Homologacao_NFeInutilizacao_MS.NfeInutilizacao2 ws2 = new HLP.GeraXml.WebService.v2_Homologacao_NFeInutilizacao_MS.NfeInutilizacao2();
                                    cabec.cUF = Acesso.cUF.ToString();
                                    cabec.versaoDados = "2.00";
                                    ws2.ClientCertificates.Add(Acesso.cert_NFe);
                                    ws2.nfeCabecMsgValue = cabec;

                                    XmlDocument xmlInut = new XmlDocument();
                                    xmlInut.Load(_sPath);
                                    XmlNode xNodeInut = xmlInut.DocumentElement;
                                    sRetorno = ws2.nfeInutilizacaoNF2(xNodeInut).OuterXml;

                                }
                            }
                            break;
                        case "RS":
                            {
                                if (Acesso.TP_AMB == 1)
                                {
                                    HLP.GeraXml.WebService.v2_Producao_NFeInutilizacao_RS.nfeCabecMsg cabec = new HLP.GeraXml.WebService.v2_Producao_NFeInutilizacao_RS.nfeCabecMsg();
                                    HLP.GeraXml.WebService.v2_Producao_NFeInutilizacao_RS.NfeInutilizacao2 ws2 = new HLP.GeraXml.WebService.v2_Producao_NFeInutilizacao_RS.NfeInutilizacao2();
                                    cabec.cUF = Acesso.cUF.ToString();
                                    cabec.versaoDados = Acesso.versaoNFe;
                                    ws2.ClientCertificates.Add(Acesso.cert_NFe);
                                    ws2.nfeCabecMsgValue = cabec;

                                    XmlDocument xmlInut = new XmlDocument();
                                    xmlInut.Load(_sPath);
                                    XmlNode xNodeInut = xmlInut.DocumentElement;
                                    sRetorno = ws2.nfeInutilizacaoNF2(xNodeInut).OuterXml;

                                }
                                else
                                {
                                    HLP.GeraXml.WebService.v2_Homologacao_NFeInutilizacao_RS.nfeCabecMsg cabec = new HLP.GeraXml.WebService.v2_Homologacao_NFeInutilizacao_RS.nfeCabecMsg();
                                    HLP.GeraXml.WebService.v2_Homologacao_NFeInutilizacao_RS.NfeInutilizacao2 ws2 = new HLP.GeraXml.WebService.v2_Homologacao_NFeInutilizacao_RS.NfeInutilizacao2();
                                    cabec.cUF = Acesso.cUF.ToString();
                                    cabec.versaoDados = "2.00";
                                    ws2.ClientCertificates.Add(Acesso.cert_NFe);
                                    ws2.nfeCabecMsgValue = cabec;

                                    XmlDocument xmlInut = new XmlDocument();
                                    xmlInut.Load(_sPath);
                                    XmlNode xNodeInut = xmlInut.DocumentElement;
                                    sRetorno = ws2.nfeInutilizacaoNF2(xNodeInut).OuterXml;

                                }
                            }
                            break;
                        case "SVRS":
                            {
                                if (Acesso.TP_AMB == 1)
                                {
                                    HLP.GeraXml.WebService.V2_Producao_Inutilizacao_SVRS.nfeCabecMsg cabec = new HLP.GeraXml.WebService.V2_Producao_Inutilizacao_SVRS.nfeCabecMsg();
                                    HLP.GeraXml.WebService.V2_Producao_Inutilizacao_SVRS.NfeInutilizacao2 ws2 = new HLP.GeraXml.WebService.V2_Producao_Inutilizacao_SVRS.NfeInutilizacao2();
                                    cabec.cUF = Acesso.cUF.ToString();
                                    cabec.versaoDados = Acesso.versaoNFe;
                                    ws2.ClientCertificates.Add(Acesso.cert_NFe);
                                    ws2.nfeCabecMsgValue = cabec;

                                    XmlDocument xmlInut = new XmlDocument();
                                    xmlInut.Load(_sPath);
                                    XmlNode xNodeInut = xmlInut.DocumentElement;
                                    sRetorno = ws2.nfeInutilizacaoNF2(xNodeInut).OuterXml;

                                }
                                else
                                {
                                    HLP.GeraXml.WebService.V2_Homologacao_Inutilizacao_SVRS.nfeCabecMsg cabec = new HLP.GeraXml.WebService.V2_Homologacao_Inutilizacao_SVRS.nfeCabecMsg();
                                    HLP.GeraXml.WebService.V2_Homologacao_Inutilizacao_SVRS.NfeInutilizacao2 ws2 = new HLP.GeraXml.WebService.V2_Homologacao_Inutilizacao_SVRS.NfeInutilizacao2();
                                    cabec.cUF = Acesso.cUF.ToString();
                                    cabec.versaoDados = "2.00";
                                    ws2.ClientCertificates.Add(Acesso.cert_NFe);
                                    ws2.nfeCabecMsgValue = cabec;

                                    XmlDocument xmlInut = new XmlDocument();
                                    xmlInut.Load(_sPath);
                                    XmlNode xNodeInut = xmlInut.DocumentElement;
                                    sRetorno = ws2.nfeInutilizacaoNF2(xNodeInut).OuterXml;

                                }
                            }
                            break;
                        case "MG":
                            {
                                if (Acesso.TP_AMB == 1)
                                {
                                    HLP.GeraXml.WebService.v2_Producao_NfeInutilizacao_MG.nfeCabecMsg cabec = new HLP.GeraXml.WebService.v2_Producao_NfeInutilizacao_MG.nfeCabecMsg();
                                    HLP.GeraXml.WebService.v2_Producao_NfeInutilizacao_MG.NfeInutilizacao2 ws2 = new HLP.GeraXml.WebService.v2_Producao_NfeInutilizacao_MG.NfeInutilizacao2();
                                    cabec.cUF = Acesso.cUF.ToString();
                                    cabec.versaoDados = Acesso.versaoNFe;
                                    ws2.ClientCertificates.Add(Acesso.cert_NFe);
                                    ws2.nfeCabecMsgValue = cabec;

                                    XmlDocument xmlInut = new XmlDocument();
                                    xmlInut.Load(_sPath);
                                    XmlNode xNodeInut = xmlInut.DocumentElement;
                                    sRetorno = ws2.nfeInutilizacaoNF2(xNodeInut).OuterXml;

                                }
                                else
                                {
                                    HLP.GeraXml.WebService.v2_Homologacao_NfeInutilizacao_MG.nfeCabecMsg cabec = new HLP.GeraXml.WebService.v2_Homologacao_NfeInutilizacao_MG.nfeCabecMsg();
                                    HLP.GeraXml.WebService.v2_Homologacao_NfeInutilizacao_MG.NfeInutilizacao2 ws2 = new HLP.GeraXml.WebService.v2_Homologacao_NfeInutilizacao_MG.NfeInutilizacao2();
                                    cabec.cUF = Acesso.cUF.ToString();
                                    cabec.versaoDados = "2.00";
                                    ws2.ClientCertificates.Add(Acesso.cert_NFe);
                                    ws2.nfeCabecMsgValue = cabec;

                                    XmlDocument xmlInut = new XmlDocument();
                                    xmlInut.Load(_sPath);
                                    XmlNode xNodeInut = xmlInut.DocumentElement;
                                    sRetorno = ws2.nfeInutilizacaoNF2(xNodeInut).OuterXml;

                                }
                            }
                            break;
                    }
                }
                else if (Acesso.TP_EMIS == 3)
                {
                    if (Acesso.TP_AMB == 1)
                    {
                        HLP.GeraXml.WebService.v2_SCAN_Producao_NFeInutilizacao.nfeCabecMsg cabec = new HLP.GeraXml.WebService.v2_SCAN_Producao_NFeInutilizacao.nfeCabecMsg();
                        HLP.GeraXml.WebService.v2_SCAN_Producao_NFeInutilizacao.NfeInutilizacao2 ws2 = new HLP.GeraXml.WebService.v2_SCAN_Producao_NFeInutilizacao.NfeInutilizacao2();
                        cabec.cUF = Acesso.cUF.ToString();
                        cabec.versaoDados = Acesso.versaoNFe;
                        ws2.ClientCertificates.Add(Acesso.cert_NFe);
                        ws2.nfeCabecMsgValue = cabec;
                        XmlDocument xmlInut = new XmlDocument();
                        xmlInut.Load(_sPath);
                        XmlNode xNodeInut = xmlInut.DocumentElement;
                        sRetorno = ws2.nfeInutilizacaoNF2(xNodeInut).OuterXml;

                    }
                    else
                    {
                        HLP.GeraXml.WebService.v2_SCAN_Homologacao_NFeInutilizacao.nfeCabecMsg cabec = new HLP.GeraXml.WebService.v2_SCAN_Homologacao_NFeInutilizacao.nfeCabecMsg();
                        HLP.GeraXml.WebService.v2_SCAN_Homologacao_NFeInutilizacao.NfeInutilizacao2 ws2 = new HLP.GeraXml.WebService.v2_SCAN_Homologacao_NFeInutilizacao.NfeInutilizacao2();
                        cabec.cUF = Acesso.cUF.ToString();
                        cabec.versaoDados = Acesso.versaoNFe;
                        ws2.ClientCertificates.Add(Acesso.cert_NFe);
                        ws2.nfeCabecMsgValue = cabec;
                        XmlDocument xmlInut = new XmlDocument();
                        xmlInut.Load(_sPath);
                        XmlNode xNodeInut = xmlInut.DocumentElement;
                        sRetorno = ws2.nfeInutilizacaoNF2(xNodeInut).OuterXml;
                    }

                }

                DadosRetorno ret = new DadosRetorno();
                XmlDocument xmldoc = new XmlDocument();
                xmldoc.LoadXml(sRetorno);
                ret.tpAmb = (xmldoc.GetElementsByTagName("tpAmb")[0] != null ? xmldoc.GetElementsByTagName("tpAmb")[0].InnerText : "");
                ret.cStat = (xmldoc.GetElementsByTagName("cStat")[0] != null ? xmldoc.GetElementsByTagName("cStat")[0].InnerText : "");
                ret.xMotivo = (xmldoc.GetElementsByTagName("xMotivo")[0] != null ? xmldoc.GetElementsByTagName("xMotivo")[0].InnerText : "");
                ret.ano = (xmldoc.GetElementsByTagName("ano")[0] != null ? xmldoc.GetElementsByTagName("ano")[0].InnerText : "");
                ret.mod = (xmldoc.GetElementsByTagName("mod")[0] != null ? xmldoc.GetElementsByTagName("mod")[0].InnerText : "");
                ret.serie = (xmldoc.GetElementsByTagName("serie")[0] != null ? xmldoc.GetElementsByTagName("serie")[0].InnerText : "");
                ret.nNFIni = (xmldoc.GetElementsByTagName("nNFIni")[0] != null ? xmldoc.GetElementsByTagName("nNFIni")[0].InnerText : "");
                ret.nNFFin = (xmldoc.GetElementsByTagName("nNFFin")[0] != null ? xmldoc.GetElementsByTagName("nNFFin")[0].InnerText : "");
                ret.dhRecbto = (xmldoc.GetElementsByTagName("dhRecbto")[0] != null ? xmldoc.GetElementsByTagName("dhRecbto")[0].InnerText.Replace('T', ' ') : "");
                ret.nProt = (xmldoc.GetElementsByTagName("nProt")[0] != null ? xmldoc.GetElementsByTagName("nProt")[0].InnerText : "");

                if (ret.cStat.Equals("102"))
                {
                    xmldoc.Save(Pastas.PROTOCOLOS + "\\" + ret.nProt + "_inu.xml");
                    InseriRegistroInutilizado(_nnfini, _nnffim, _serie, _sjust);                 
                }

                return ret;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void NfeDadosMgs()
        {
            string _ano = daoUtil.GetDateServidor().ToString("yy");
            _id = Acesso.cUF + _ano + Util.RetiraCaracterCNPJ(Acesso.CNPJ_EMPRESA) + _mod + _serie + _nnfini + _nnffim;
            try
            {
                XDocument xDados = new XDocument(new XElement(pf + "inutNFe", new XAttribute("versao", Acesso.versaoNFe),
                                                    new XElement(pf + "infInut", new XAttribute("Id", "ID" + _id),
                                                        new XElement(pf + "tpAmb", Acesso.TP_AMB),
                                                        new XElement(pf + "xServ", "INUTILIZAR"),
                                                        new XElement(pf + "cUF", Acesso.cUF),
                                                        new XElement(pf + "ano", daoUtil.GetDateServidor().ToString("yy")),
                                                        new XElement(pf + "CNPJ", Util.RetiraCaracterCNPJ(Acesso.CNPJ_EMPRESA)),
                                                        new XElement(pf + "mod", _mod),
                                                        new XElement(pf + "serie", Convert.ToInt16(_serie)),
                                                        new XElement(pf + "nNFIni", Convert.ToInt32(_nnfini)),
                                                        new XElement(pf + "nNFFin", Convert.ToInt32(_nnffim)),
                                                        new XElement(pf + "xJust", _sjust))));

                _sPath = Pastas.PROTOCOLOS + _id + "_ped_inu.xml";
                xDados.Save(Pastas.PROTOCOLOS + _id + "_ped_inu.xml");
                belAssinaXml assina = new belAssinaXml();
                assina.Assinar(_sPath, "infInut", Acesso.cert_NFe);
                belValidaXml.ValidarXml("http://www.portalfiscal.inf.br/nfe", Pastas.SCHEMA_NFE + "\\inutNFe_v2.00.xsd", _sPath);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
