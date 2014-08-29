using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HLP.GeraXml.Comum.Static;
using System.Xml;
using HLP.GeraXml.dao.NFe;
using HLP.GeraXml.bel.NFe.Estrutura;
using System.IO;
using System.Windows.Forms;

namespace HLP.GeraXml.bel.NFe
{
    public class belRecepcaoNFe : daoRecepcao
    {
        public string pRec { get; set; }

        public void TransmitirLote(string sPathLote, List<belPesquisaNotas> lPesquisa)
        {
            string sRet = string.Empty;

            string sXmlLote = string.Empty;
            StreamReader reader = new StreamReader(sPathLote);
            sXmlLote = reader.ReadToEnd();


            try
            {
                if (Acesso.TP_EMIS == 1)
                {
                    switch (Acesso.xUFtoWS)
                    {
                        case "SP":
                            {
                                #region Regiao_SP
                                if (Acesso.TP_AMB == 2)
                                {
                                    HLP.GeraXml.WebService.v2_Homologacao_NFeRecepcao_SP.nfeCabecMsg cabec = new HLP.GeraXml.WebService.v2_Homologacao_NFeRecepcao_SP.nfeCabecMsg();
                                    HLP.GeraXml.WebService.v2_Homologacao_NFeRecepcao_SP.NfeRecepcao2 ws2 = new HLP.GeraXml.WebService.v2_Homologacao_NFeRecepcao_SP.NfeRecepcao2();
                                    cabec.cUF = Acesso.cUF.ToString();
                                    cabec.versaoDados = Acesso.versaoNFe;
                                    ws2.nfeCabecMsgValue = cabec;
                                    ws2.ClientCertificates.Add(Acesso.cert_NFe);
                                    XmlDocument _xmlxelem = new XmlDocument();
                                    _xmlxelem.PreserveWhitespace = true;
                                    _xmlxelem.LoadXml(sXmlLote);
                                    XmlNode xNelem = null;
                                    xNelem = _xmlxelem.DocumentElement;
                                    sRet = ws2.nfeRecepcaoLote2(xNelem).OuterXml;
                                }
                                else
                                {
                                    HLP.GeraXml.WebService.v2_Producao_NFeRecepcao_SP.nfeCabecMsg cabec = new HLP.GeraXml.WebService.v2_Producao_NFeRecepcao_SP.nfeCabecMsg();
                                    HLP.GeraXml.WebService.v2_Producao_NFeRecepcao_SP.NfeRecepcao2 ws2 = new HLP.GeraXml.WebService.v2_Producao_NFeRecepcao_SP.NfeRecepcao2();
                                    belUF objbelUf = new belUF();
                                    cabec.cUF = Acesso.cUF.ToString();
                                    cabec.versaoDados = Acesso.versaoNFe;
                                    ws2.nfeCabecMsgValue = cabec;
                                    ws2.ClientCertificates.Add(Acesso.cert_NFe);
                                    XmlDocument _xmlxelem = new XmlDocument();
                                    _xmlxelem.PreserveWhitespace = true;
                                    _xmlxelem.LoadXml(sXmlLote);
                                    XmlNode xNelem = null;
                                    xNelem = _xmlxelem.DocumentElement;
                                    sRet = ws2.nfeRecepcaoLote2(xNelem).OuterXml;
                                }
                                #endregion
                            }
                            break;
                        case "RS":
                            {
                                #region Regiao_RS
                                if (Acesso.TP_AMB == 2)
                                {
                                    HLP.GeraXml.WebService.v2_Homologacao_NFeRecepcao_RS.nfeCabecMsg cabec = new HLP.GeraXml.WebService.v2_Homologacao_NFeRecepcao_RS.nfeCabecMsg();
                                    HLP.GeraXml.WebService.v2_Homologacao_NFeRecepcao_RS.NfeRecepcao2 ws2 = new HLP.GeraXml.WebService.v2_Homologacao_NFeRecepcao_RS.NfeRecepcao2();
                                    cabec.cUF = Acesso.cUF.ToString();
                                    cabec.versaoDados = Acesso.versaoNFe;
                                    ws2.nfeCabecMsgValue = cabec;
                                    ws2.ClientCertificates.Add(Acesso.cert_NFe);
                                    XmlDocument _xmlxelem = new XmlDocument();
                                    _xmlxelem.PreserveWhitespace = true;
                                    _xmlxelem.Load(sPathLote);
                                    XmlNode xNelem = null;
                                    xNelem = _xmlxelem.DocumentElement;
                                    sRet = ws2.nfeRecepcaoLote2(xNelem).OuterXml;
                                }
                                else
                                {
                                    HLP.GeraXml.WebService.v2_Producao_NFeRecepcao_RS.nfeCabecMsg cabec = new HLP.GeraXml.WebService.v2_Producao_NFeRecepcao_RS.nfeCabecMsg();
                                    HLP.GeraXml.WebService.v2_Producao_NFeRecepcao_RS.NfeRecepcao2 ws2 = new HLP.GeraXml.WebService.v2_Producao_NFeRecepcao_RS.NfeRecepcao2();
                                    belUF objbelUf = new belUF();
                                    cabec.cUF = Acesso.cUF.ToString();
                                    cabec.versaoDados = Acesso.versaoNFe;
                                    ws2.nfeCabecMsgValue = cabec;
                                    ws2.ClientCertificates.Add(Acesso.cert_NFe);
                                    XmlDocument _xmlxelem = new XmlDocument();
                                    _xmlxelem.PreserveWhitespace = true;
                                    _xmlxelem.Load(sPathLote);
                                    XmlNode xNelem = null;
                                    xNelem = _xmlxelem.DocumentElement;
                                    sRet = ws2.nfeRecepcaoLote2(xNelem).OuterXml;
                                }
                                #endregion
                            }
                            break;
                        case "MS":
                            {
                                #region Regiao_MS
                                if (Acesso.TP_AMB == 2)
                                {
                                    HLP.GeraXml.WebService.v2_Homologacao_NFeRecepcao_MS.nfeCabecMsg cabec = new HLP.GeraXml.WebService.v2_Homologacao_NFeRecepcao_MS.nfeCabecMsg();
                                    HLP.GeraXml.WebService.v2_Homologacao_NFeRecepcao_MS.NfeRecepcao2 ws2 = new HLP.GeraXml.WebService.v2_Homologacao_NFeRecepcao_MS.NfeRecepcao2();
                                    belUF objbelUf = new belUF();
                                    cabec.cUF = Acesso.cUF.ToString();
                                    cabec.versaoDados = Acesso.versaoNFe;
                                    ws2.nfeCabecMsgValue = cabec;
                                    ws2.ClientCertificates.Add(Acesso.cert_NFe);
                                    XmlDocument _xmlxelem = new XmlDocument();
                                    _xmlxelem.PreserveWhitespace = true;
                                    _xmlxelem.LoadXml(sXmlLote);
                                    XmlNode xNelem = null;
                                    xNelem = _xmlxelem.DocumentElement;
                                    sRet = ws2.nfeRecepcaoLote2(xNelem).OuterXml;
                                }
                                else
                                {
                                    HLP.GeraXml.WebService.v2_Producao_NFeRecepcao_MS.nfeCabecMsg cabec = new HLP.GeraXml.WebService.v2_Producao_NFeRecepcao_MS.nfeCabecMsg();
                                    HLP.GeraXml.WebService.v2_Producao_NFeRecepcao_MS.NfeRecepcao2 ws2 = new HLP.GeraXml.WebService.v2_Producao_NFeRecepcao_MS.NfeRecepcao2();
                                    belUF objbelUf = new belUF();
                                    cabec.cUF = Acesso.cUF.ToString();
                                    cabec.versaoDados = Acesso.versaoNFe;
                                    ws2.nfeCabecMsgValue = cabec;
                                    ws2.ClientCertificates.Add(Acesso.cert_NFe);
                                    XmlDocument _xmlxelem = new XmlDocument();
                                    _xmlxelem.PreserveWhitespace = true;
                                    _xmlxelem.LoadXml(sXmlLote);
                                    XmlNode xNelem = null;
                                    xNelem = _xmlxelem.DocumentElement;
                                    sRet = ws2.nfeRecepcaoLote2(xNelem).OuterXml;
                                }
                                #endregion
                            }
                            break;
                        case "SVRS":
                            {
                                #region Regiao_RJ
                                if (Acesso.TP_AMB == 2)
                                {
                                    HLP.GeraXml.WebService.V2_Homologacao_Recepcao_SVRS.nfeCabecMsg cabec = new HLP.GeraXml.WebService.V2_Homologacao_Recepcao_SVRS.nfeCabecMsg();
                                    HLP.GeraXml.WebService.V2_Homologacao_Recepcao_SVRS.NfeRecepcao2 ws2 = new HLP.GeraXml.WebService.V2_Homologacao_Recepcao_SVRS.NfeRecepcao2();
                                    cabec.cUF = Acesso.cUF.ToString();
                                    cabec.versaoDados = Acesso.versaoNFe;
                                    ws2.nfeCabecMsgValue = cabec;
                                    ws2.ClientCertificates.Add(Acesso.cert_NFe);
                                    XmlDocument _xmlxelem = new XmlDocument();
                                    _xmlxelem.PreserveWhitespace = true;
                                    _xmlxelem.Load(sPathLote);
                                    XmlNode xNelem = null;
                                    xNelem = _xmlxelem.DocumentElement;
                                    sRet = ws2.nfeRecepcaoLote2(xNelem).OuterXml;
                                }
                                else
                                {

                                    HLP.GeraXml.WebService.v2_Producao_NFeRecepcao_SVRS.nfeCabecMsg cabec = new HLP.GeraXml.WebService.v2_Producao_NFeRecepcao_SVRS.nfeCabecMsg();
                                    HLP.GeraXml.WebService.v2_Producao_NFeRecepcao_SVRS.NfeRecepcao2 ws2 = new HLP.GeraXml.WebService.v2_Producao_NFeRecepcao_SVRS.NfeRecepcao2();
                                    belUF objbelUf = new belUF();
                                    cabec.cUF = Acesso.cUF.ToString();
                                    cabec.versaoDados = Acesso.versaoNFe;
                                    ws2.nfeCabecMsgValue = cabec;
                                    ws2.ClientCertificates.Add(Acesso.cert_NFe);
                                    XmlDocument _xmlxelem = new XmlDocument();
                                    _xmlxelem.PreserveWhitespace = true;
                                    _xmlxelem.Load(sPathLote);
                                    XmlNode xNelem = null;
                                    xNelem = _xmlxelem.DocumentElement;
                                    sRet = ws2.nfeRecepcaoLote2(xNelem).OuterXml;
                                }
                                #endregion
                            }
                            break;
                        case "MG":
                            {
                                #region Regiao_MG
                                if (Acesso.TP_AMB == 2)
                                {
                                    HLP.GeraXml.WebService.v2_Homologacao_NfeRecepcao_MG.nfeCabecMsg cabec = new HLP.GeraXml.WebService.v2_Homologacao_NfeRecepcao_MG.nfeCabecMsg();
                                    HLP.GeraXml.WebService.v2_Homologacao_NfeRecepcao_MG.NfeRecepcao2 ws2 = new HLP.GeraXml.WebService.v2_Homologacao_NfeRecepcao_MG.NfeRecepcao2();
                                    cabec.cUF = Acesso.cUF.ToString();
                                    cabec.versaoDados = Acesso.versaoNFe;
                                    ws2.nfeCabecMsgValue = cabec;
                                    ws2.ClientCertificates.Add(Acesso.cert_NFe);
                                    XmlDocument _xmlxelem = new XmlDocument();
                                    _xmlxelem.PreserveWhitespace = true;
                                    _xmlxelem.Load(sPathLote);
                                    XmlNode xNelem = null;
                                    xNelem = _xmlxelem.DocumentElement;
                                    sRet = ws2.nfeRecepcaoLote2(xNelem).OuterXml;
                                }
                                else
                                {

                                    HLP.GeraXml.WebService.v2_Producao_NfeRecepcao_MG.nfeCabecMsg cabec = new HLP.GeraXml.WebService.v2_Producao_NfeRecepcao_MG.nfeCabecMsg();
                                    HLP.GeraXml.WebService.v2_Producao_NfeRecepcao_MG.NfeRecepcao2 ws2 = new HLP.GeraXml.WebService.v2_Producao_NfeRecepcao_MG.NfeRecepcao2();
                                    belUF objbelUf = new belUF();
                                    cabec.cUF = Acesso.cUF.ToString();
                                    cabec.versaoDados = Acesso.versaoNFe;
                                    ws2.nfeCabecMsgValue = cabec;
                                    ws2.ClientCertificates.Add(Acesso.cert_NFe);
                                    XmlDocument _xmlxelem = new XmlDocument();
                                    _xmlxelem.PreserveWhitespace = true;
                                    _xmlxelem.Load(sPathLote);
                                    XmlNode xNelem = null;
                                    xNelem = _xmlxelem.DocumentElement;
                                    sRet = ws2.nfeRecepcaoLote2(xNelem).OuterXml;
                                }
                                #endregion
                            }
                            break;
                    }
                }
                else if (Acesso.TP_EMIS == 3)
                {
                    #region SCAN
                    if (Acesso.TP_AMB == 2)
                    {
                        HLP.GeraXml.WebService.v2_SCAN_Homologacao_NFeRecepcao.nfeCabecMsg cabec = new HLP.GeraXml.WebService.v2_SCAN_Homologacao_NFeRecepcao.nfeCabecMsg();
                        HLP.GeraXml.WebService.v2_SCAN_Homologacao_NFeRecepcao.NfeRecepcao2 ws2 = new HLP.GeraXml.WebService.v2_SCAN_Homologacao_NFeRecepcao.NfeRecepcao2();
                        cabec.cUF = Acesso.cUF.ToString();
                        cabec.versaoDados = Acesso.versaoNFe;
                        ws2.nfeCabecMsgValue = cabec;
                        ws2.ClientCertificates.Add(Acesso.cert_NFe);
                        XmlDocument _xmlxelem = new XmlDocument();
                        _xmlxelem.PreserveWhitespace = true;
                        _xmlxelem.Load(sPathLote);
                        XmlNode xNelem = null;
                        xNelem = _xmlxelem.DocumentElement;
                        sRet = ws2.nfeRecepcaoLote2(xNelem).OuterXml;
                    }
                    else
                    {
                        HLP.GeraXml.WebService.v2_SCAN_Producao_NFeRecepcao.nfeCabecMsg cabec = new HLP.GeraXml.WebService.v2_SCAN_Producao_NFeRecepcao.nfeCabecMsg();
                        HLP.GeraXml.WebService.v2_SCAN_Producao_NFeRecepcao.NfeRecepcao2 ws2 = new HLP.GeraXml.WebService.v2_SCAN_Producao_NFeRecepcao.NfeRecepcao2();
                        belUF objbelUf = new belUF();
                        cabec.cUF = Acesso.cUF.ToString();
                        cabec.versaoDados = Acesso.versaoNFe;
                        ws2.nfeCabecMsgValue = cabec;
                        ws2.ClientCertificates.Add(Acesso.cert_NFe);
                        XmlDocument _xmlxelem = new XmlDocument();
                        _xmlxelem.PreserveWhitespace = true;
                        _xmlxelem.Load(sPathLote);
                        XmlNode xNelem = null;
                        xNelem = _xmlxelem.DocumentElement;
                        sRet = ws2.nfeRecepcaoLote2(xNelem).OuterXml;
                    }
                    #endregion
                }
                else if (Acesso.TP_EMIS == 6)
                {
                    #region SCAN
                    if (Acesso.TP_AMB == 2)
                    {
                        HLP.GeraXml.WebService.v2_SVC_Homologacao_NfeRecepcao.nfeCabecMsg cabec = new HLP.GeraXml.WebService.v2_SVC_Homologacao_NfeRecepcao.nfeCabecMsg();
                        HLP.GeraXml.WebService.v2_SVC_Homologacao_NfeRecepcao.NfeRecepcao2 ws2 = new HLP.GeraXml.WebService.v2_SVC_Homologacao_NfeRecepcao.NfeRecepcao2();
                        belUF objbelUf = new belUF();
                        cabec.cUF = Acesso.cUF.ToString();
                        cabec.versaoDados = Acesso.versaoNFe;
                        ws2.nfeCabecMsgValue = cabec;
                        ws2.ClientCertificates.Add(Acesso.cert_NFe);
                        XmlDocument _xmlxelem = new XmlDocument();
                        _xmlxelem.PreserveWhitespace = true;
                        _xmlxelem.Load(sPathLote);
                        XmlNode xNelem = null;
                        xNelem = _xmlxelem.DocumentElement;
                        sRet = ws2.nfeRecepcaoLote2(xNelem).OuterXml;
                    }
                    else
                    {
                        HLP.GeraXml.WebService.v2_SVC_Producao_NfeRecepcao.nfeCabecMsg cabec = new HLP.GeraXml.WebService.v2_SVC_Producao_NfeRecepcao.nfeCabecMsg();
                        HLP.GeraXml.WebService.v2_SVC_Producao_NfeRecepcao.NfeRecepcao2 ws2 = new HLP.GeraXml.WebService.v2_SVC_Producao_NfeRecepcao.NfeRecepcao2();
                        belUF objbelUf = new belUF();
                        cabec.cUF = Acesso.cUF.ToString();
                        cabec.versaoDados = Acesso.versaoNFe;
                        ws2.nfeCabecMsgValue = cabec;
                        ws2.ClientCertificates.Add(Acesso.cert_NFe);
                        XmlDocument _xmlxelem = new XmlDocument();
                        _xmlxelem.PreserveWhitespace = true;
                        _xmlxelem.Load(sPathLote);
                        XmlNode xNelem = null;
                        xNelem = _xmlxelem.DocumentElement;
                        sRet = ws2.nfeRecepcaoLote2(xNelem).OuterXml;
                    }
                    #endregion
                }

                if (sRet != null)
                {
                    int lugar = sRet.IndexOf("<nRec>");
                    pRec = sRet.Substring(lugar + 6, 15);
                    if (pRec.ToUpper().Contains("VERSAO"))
                    {
                        throw new Exception("Ocorreu uma exceção com o webservice de Recepção. Favor verificar se os serviços estão estáveis.");
                    }

                    foreach (belPesquisaNotas nota in lPesquisa)
                    {
                        gravaRecibo(pRec, nota.sCD_NFSEQ);
                        nota.sRECIBO_NF = pRec;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
