using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using HLP.GeraXml.Comum.Static;
using System.Xml.Schema;
using System.Xml;
using System.IO;
using ComponentFactory.Krypton.Toolkit;
using System.Threading;
using System.Linq;
using System.Windows.Forms;

namespace HLP.GeraXml.bel.NFe
{
    public class belBusRetFazenda : dao.NFe.daoBusRetFazenda
    {
        public bool bStopRetorno = false;
        private List<belPesquisaNotas> lnotas = null;
        public KryptonLabel _lblQtde { get; set; }
        public List<DadosRetorno> lDadosRetorno = new List<DadosRetorno>();

        public class DadosRetorno
        {
            public string seqNota { get; set; }
            public string nNota { get; set; }
            public string cStat { get; set; }
            public string xMotivo { get; set; }
            public string chNFe { get; set; }
            public string nProt { get; set; }
        }

        public belBusRetFazenda(List<belPesquisaNotas> lnotas)
        {
            this.lnotas = lnotas;
        }

        public void LimpaCampoRecibo()
        {
            foreach (belPesquisaNotas n in lnotas)
            {
                base.LimpaCampoRecibo(n.sCD_NFSEQ);
            }
        }
        public void BuscaRetorno()
        {
            try
            {
                XNamespace pf = "http://www.portalfiscal.inf.br/nfe";
                XmlDocument xret = new XmlDocument();
                string sCodRetorno = string.Empty;
                xret = Exec_Cosulta(lnotas.FirstOrDefault().sRECIBO_NF);

                while (!bStopRetorno)
                {
                    sCodRetorno = "";
                    XmlNodeList nodeschNFe = xret.GetElementsByTagName("chNFe");
                    XmlNodeList nodecStat = xret.GetElementsByTagName("cStat");
                    XmlNodeList nodesxMotivo = xret.GetElementsByTagName("xMotivo");
                    DadosRetorno ret = new DadosRetorno();

                    if (nodecStat[0].InnerText == "105") // Em processamento
                    {
                        int iCount = 0;
                        //while (iCount < 2)
                        //{
                        Thread.Sleep(4000);

                        ret = new DadosRetorno();
                        xret = Exec_Cosulta(lnotas.FirstOrDefault().sRECIBO_NF);

                        nodeschNFe = xret.GetElementsByTagName("chNFe");
                        nodecStat = xret.GetElementsByTagName("cStat");
                        nodesxMotivo = xret.GetElementsByTagName("xMotivo");

                        ret.cStat = nodecStat[0].InnerText;
                        ret.xMotivo = nodesxMotivo[0].InnerText;

                        if (nodecStat[0].InnerText != "105")
                        {
                            iCount = 2;
                        }
                        iCount++;
                        //}
                        //lDadosRetorno.Add(ret);
                    }
                    if (nodecStat[0].InnerText != "104" && nodecStat[0].InnerText != "656")
                    {
                        ret.cStat = nodecStat[0].InnerText;
                        ret.xMotivo = nodesxMotivo[0].InnerText;
                        bStopRetorno = true;
                        LimpaCampoRecibo();
                        lDadosRetorno.Add(ret);
                    }
                    else if (nodecStat[0].InnerText == "656")
                    {
                        ret.cStat = nodecStat[0].InnerText;
                        ret.xMotivo = nodesxMotivo[0].InnerText;
                        bStopRetorno = true;
                        lDadosRetorno.Add(ret);
                    }
                    else
                    {
                        int iCountNProt = 0;
                        for (int i = 0; (i < nodeschNFe.Count) && !bStopRetorno; i++)
                        {
                            if (lnotas.Where(c => c.sCHAVENFE == nodeschNFe[i].InnerText).Count() > 0)
                            {
                                belPesquisaNotas nota = lnotas.FirstOrDefault(c => c.sCHAVENFE == nodeschNFe[i].InnerText);
                                ret = new DadosRetorno();
                                ret.cStat = nodecStat[i + 1].InnerText;
                                ret.xMotivo = nodesxMotivo[i + 1].InnerText;
                                ret.seqNota = nota.sCD_NFSEQ;
                                ret.nNota = nota.sCD_NOTAFIS;

                                if (nodecStat[i + 1].InnerText == "100") // 100 - Enviada com sucesso
                                {
                                    SalvaProtocoloNFe(nota.sCD_NFSEQ, nota.sCHAVENFE, xret.GetElementsByTagName("nProt")[iCountNProt].InnerText);
                                    IncluiTagInfProc(nota, xret.GetElementsByTagName("protNFe")[iCountNProt], pf);
                                    xret.Save(Pastas.PROTOCOLOS + "\\" + nota.sRECIBO_NF + "-pro-rec.xml");
                                    iCountNProt++;
                                }
                                else if (nodecStat[i + 1].InnerText == "101") // 101 - Nota Cancelada.
                                {
                                    SalvaProtocoloNFe(nota.sCD_NFSEQ, nota.sCHAVENFE, xret.GetElementsByTagName("nProt")[i].InnerText);
                                    IncluiTagInfProc(nota, xret.GetElementsByTagName("protNFe")[i], pf);
                                    DirectoryInfo dinfo = Util.BuscaDiretorioArquivoXml(nota.sCHAVENFE, 2);
                                    File.Move(Util.BuscaCaminhoArquivoXml(nota.sCHAVENFE, 2), Pastas.CANCELADOS + "\\" + nota.sCHAVENFE + "can.xml");
                                }
                                else if (nodecStat[i + 1].InnerText == "204") // Rejeição: Duplicidade de NF-e
                                {
                                    int icount = nodesxMotivo[i + 1].InnerText.Count() - (nodesxMotivo[i + 1].InnerText.IndexOf("nRec") + 6);
                                    string sRet = nodesxMotivo[i + 1].InnerText.Substring((nodesxMotivo[i + 1].InnerText.IndexOf("nRec") + 5), icount);

                                    if (sRet.Count() != 15)
                                    {
                                        AlteraStatusNotaDuplicada(nota.sCD_NFSEQ);
                                        string sPathEnvio = Util.BuscaCaminhoArquivoXml(nota.sCHAVENFE, 1);
                                        string sPathEnviados = Util.BuscaCaminhoArquivoXml(nota.sCHAVENFE, 2);
                                        if (!File.Exists(sPathEnviados))
                                        {
                                            File.Copy(sPathEnvio, sPathEnviados);
                                        }
                                    }
                                    else
                                    {
                                        SalvaRetornoNotaDuplicada(sRet, nota.sCD_NFSEQ);
                                    }
                                }
                                else if ((nodecStat[i + 1].InnerText == "110") || (nodecStat[i + 1].InnerText == "302") || (nodecStat[i + 1].InnerText == "302"))
                                {
                                    NotaDenegada(nota.sCD_NFSEQ);
                                }
                                else if (nodecStat[i + 1].InnerText != "105") // Lote em processamento
                                {
                                    LimpaCampoRecibo();
                                }
                            }
                            if (ret.cStat != null)
                            {
                                lDadosRetorno.Add(ret);
                            }
                        }
                        bStopRetorno = true;
                        foreach (DadosRetorno nota in lDadosRetorno)
                        {
                            if (nota.cStat.Equals("100"))
                            {
                                AlteraStatusNotaParaEnviada(nota.seqNota);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void IncluiTagInfProc(belPesquisaNotas nota, XmlNode xret, XNamespace pf)
        {
            //Geração do Xml da nfe Autorizado, incluindo a TAG infProc onde consta as informaçoes de retorno da nfe.

            string sCodificacao = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>";
            string sRetProc = "<nfeProc versao=\"2.00\" xmlns=\"http://www.portalfiscal.inf.br/nfe\">";
            XmlDocument xmldocteste = new XmlDocument();
            xmldocteste.Load(Util.BuscaCaminhoArquivoXml(nota.sCHAVENFE, 1));
            Util.BuscaDiretorioArquivoXml(nota.sCHAVENFE, 1);

            StreamWriter sw = new StreamWriter(Util.BuscaCaminhoArquivoXml(nota.sCHAVENFE, 2));

            if (@xmldocteste.FirstChild.Name.Equals("xml"))
            {
                sw.Write(@sRetProc + @xmldocteste.OuterXml.Remove(0, 38) + @xret.OuterXml.ToString() + @"</nfeProc>");
            }
            else
            {
                sw.Write(@sCodificacao + @sRetProc + @xmldocteste.OuterXml + @xret.OuterXml.ToString() + @"</nfeProc>");
            }
            sw.Close();
        }

        private XmlDocument Exec_Cosulta(string sRec)
        {
            try
            {
                string snfeDadosMsg = NfeDadosMsg(sRec);

                belAssinaXml Assina = new belAssinaXml();
                string sRet = string.Empty;
                string sXmlRetorno = string.Empty;

                if (Acesso.TP_EMIS == 6)
                {
                    if (Acesso.TP_AMB == 1)
                    {
                        HLP.GeraXml.WebService.v2_SVC_Producao_NfeRetRecepcao.NfeRetRecepcao2 ws2 = new HLP.GeraXml.WebService.v2_SVC_Producao_NfeRetRecepcao.NfeRetRecepcao2();
                        HLP.GeraXml.WebService.v2_SVC_Producao_NfeRetRecepcao.nfeCabecMsg cabec = new HLP.GeraXml.WebService.v2_SVC_Producao_NfeRetRecepcao.nfeCabecMsg();
                        cabec.cUF = Acesso.cUF.ToString();
                        cabec.versaoDados = Acesso.versaoNFe;
                        ws2.nfeCabecMsgValue = cabec;
                        ws2.ClientCertificates.Add(Acesso.cert_NFe);
                        XmlDocument xmlNfeDadosMsg = new XmlDocument();
                        xmlNfeDadosMsg.LoadXml(snfeDadosMsg);
                        XmlNode xNodeRet = xmlNfeDadosMsg.DocumentElement;
                        sXmlRetorno = ws2.nfeRetRecepcao2(xNodeRet).OuterXml;
                    }
                    else
                    {
                        HLP.GeraXml.WebService.v2_SVC_Homologacao_NfeRetRecepcao.NfeRetRecepcao2 ws2 = new HLP.GeraXml.WebService.v2_SVC_Homologacao_NfeRetRecepcao.NfeRetRecepcao2();
                        HLP.GeraXml.WebService.v2_SVC_Homologacao_NfeRetRecepcao.nfeCabecMsg cabec = new HLP.GeraXml.WebService.v2_SVC_Homologacao_NfeRetRecepcao.nfeCabecMsg();
                        cabec.cUF = Acesso.cUF.ToString();
                        cabec.versaoDados = Acesso.versaoNFe;
                        ws2.nfeCabecMsgValue = cabec;
                        ws2.ClientCertificates.Add(Acesso.cert_NFe);
                        XmlDocument xmlNfeDadosMsg = new XmlDocument();
                        xmlNfeDadosMsg.LoadXml(snfeDadosMsg);
                        XmlNode xNodeRet = xmlNfeDadosMsg.DocumentElement;
                        sXmlRetorno = ws2.nfeRetRecepcao2(xNodeRet).OuterXml;
                    }
                }
                else if (Acesso.TP_EMIS == 3)
                {
                    #region SCAN
                    if (Acesso.TP_AMB == 1)
                    {
                        HLP.GeraXml.WebService.v2_SCAN_Producao_NFeRetRecepcao.NfeRetRecepcao2 ws2 = new HLP.GeraXml.WebService.v2_SCAN_Producao_NFeRetRecepcao.NfeRetRecepcao2();
                        HLP.GeraXml.WebService.v2_SCAN_Producao_NFeRetRecepcao.nfeCabecMsg cabec = new HLP.GeraXml.WebService.v2_SCAN_Producao_NFeRetRecepcao.nfeCabecMsg();
                        cabec.cUF = Acesso.cUF.ToString();
                        cabec.versaoDados = Acesso.versaoNFe;
                        ws2.nfeCabecMsgValue = cabec;
                        ws2.ClientCertificates.Add(Acesso.cert_NFe);
                        XmlDocument xmlNfeDadosMsg = new XmlDocument();
                        xmlNfeDadosMsg.LoadXml(snfeDadosMsg);
                        XmlNode xNodeRet = xmlNfeDadosMsg.DocumentElement;
                        sXmlRetorno = ws2.nfeRetRecepcao2(xNodeRet).OuterXml;
                    }
                    else if (Acesso.TP_AMB == 2)
                    {
                        HLP.GeraXml.WebService.v2_SCAN_Homologacao_NFeRetRecepcao.NfeRetRecepcao2 ws2 = new HLP.GeraXml.WebService.v2_SCAN_Homologacao_NFeRetRecepcao.NfeRetRecepcao2();
                        HLP.GeraXml.WebService.v2_SCAN_Homologacao_NFeRetRecepcao.nfeCabecMsg cabec = new HLP.GeraXml.WebService.v2_SCAN_Homologacao_NFeRetRecepcao.nfeCabecMsg();
                        cabec.cUF = Acesso.cUF.ToString();
                        cabec.versaoDados = Acesso.versaoNFe;
                        ws2.nfeCabecMsgValue = cabec;
                        ws2.ClientCertificates.Add(Acesso.cert_NFe);
                        XmlDocument xmlNfeDadosMsg = new XmlDocument();
                        xmlNfeDadosMsg.LoadXml(snfeDadosMsg);
                        XmlNode xNodeRet = xmlNfeDadosMsg.DocumentElement;
                        sXmlRetorno = ws2.nfeRetRecepcao2(xNodeRet).OuterXml;
                    }
                    #endregion
                }
                else
                {
                    switch (Acesso.xUFtoWS)
                    {
                        case "SP":
                            {
                                #region Regiao_SP
                                if (Acesso.TP_AMB == 1)
                                {
                                    HLP.GeraXml.WebService.v2_Producao_NFeRetRecepcao_SP.NfeRetRecepcao2 ws2 = new HLP.GeraXml.WebService.v2_Producao_NFeRetRecepcao_SP.NfeRetRecepcao2();
                                    HLP.GeraXml.WebService.v2_Producao_NFeRetRecepcao_SP.nfeCabecMsg cabec = new HLP.GeraXml.WebService.v2_Producao_NFeRetRecepcao_SP.nfeCabecMsg();
                                    cabec.cUF = Acesso.cUF.ToString();
                                    cabec.versaoDados = Acesso.versaoNFe;
                                    ws2.nfeCabecMsgValue = cabec;
                                    ws2.ClientCertificates.Add(Acesso.cert_NFe);
                                    XmlDocument xmlNfeDadosMsg = new XmlDocument();
                                    xmlNfeDadosMsg.LoadXml(snfeDadosMsg);
                                    XmlNode xNodeRet = xmlNfeDadosMsg.DocumentElement;
                                    sXmlRetorno = ws2.nfeRetRecepcao2(xNodeRet).OuterXml;
                                }
                                else if (Acesso.TP_AMB == 2)
                                {
                                    HLP.GeraXml.WebService.v2_Homologacao_NfeRetRecepcao_SP.NfeRetRecepcao2 ws2 = new HLP.GeraXml.WebService.v2_Homologacao_NfeRetRecepcao_SP.NfeRetRecepcao2();
                                    HLP.GeraXml.WebService.v2_Homologacao_NfeRetRecepcao_SP.nfeCabecMsg cabec = new HLP.GeraXml.WebService.v2_Homologacao_NfeRetRecepcao_SP.nfeCabecMsg();
                                    cabec.cUF = Acesso.cUF.ToString();
                                    cabec.versaoDados = Acesso.versaoNFe;
                                    ws2.nfeCabecMsgValue = cabec;
                                    ws2.ClientCertificates.Add(Acesso.cert_NFe);
                                    XmlDocument xmlNfeDadosMsg = new XmlDocument();
                                    xmlNfeDadosMsg.LoadXml(snfeDadosMsg);
                                    XmlNode xNodeRet = xmlNfeDadosMsg.DocumentElement;
                                    sXmlRetorno = ws2.nfeRetRecepcao2(xNodeRet).OuterXml;
                                }
                                #endregion
                            }
                            break;
                        case "SVRS":
                            {
                                #region Regiao_SVRS
                                if (Acesso.TP_AMB == 1)
                                {
                                    HLP.GeraXml.WebService.V2_Producao_RetRecepcao_SVRS.NfeRetRecepcao2 ws2 = new HLP.GeraXml.WebService.V2_Producao_RetRecepcao_SVRS.NfeRetRecepcao2();
                                    HLP.GeraXml.WebService.V2_Producao_RetRecepcao_SVRS.nfeCabecMsg cabec = new HLP.GeraXml.WebService.V2_Producao_RetRecepcao_SVRS.nfeCabecMsg();
                                    cabec.cUF = Acesso.cUF.ToString();
                                    cabec.versaoDados = Acesso.versaoNFe;
                                    ws2.nfeCabecMsgValue = cabec;
                                    ws2.ClientCertificates.Add(Acesso.cert_NFe);
                                    XmlDocument xmlNfeDadosMsg = new XmlDocument();
                                    xmlNfeDadosMsg.LoadXml(snfeDadosMsg);
                                    XmlNode xNodeRet = xmlNfeDadosMsg.DocumentElement;
                                    sXmlRetorno = ws2.nfeRetRecepcao2(xNodeRet).OuterXml;
                                }
                                else if (Acesso.TP_AMB == 2)
                                {
                                    HLP.GeraXml.WebService.V2_Homologacao_RetRecepcao_SVRS.NfeRetRecepcao2 ws2 = new HLP.GeraXml.WebService.V2_Homologacao_RetRecepcao_SVRS.NfeRetRecepcao2();
                                    HLP.GeraXml.WebService.V2_Homologacao_RetRecepcao_SVRS.nfeCabecMsg cabec = new HLP.GeraXml.WebService.V2_Homologacao_RetRecepcao_SVRS.nfeCabecMsg();
                                    cabec.cUF = Acesso.cUF.ToString();
                                    cabec.versaoDados = Acesso.versaoNFe;
                                    ws2.nfeCabecMsgValue = cabec;
                                    ws2.ClientCertificates.Add(Acesso.cert_NFe);
                                    XmlDocument xmlNfeDadosMsg = new XmlDocument();
                                    xmlNfeDadosMsg.LoadXml(snfeDadosMsg);
                                    XmlNode xNodeRet = xmlNfeDadosMsg.DocumentElement;
                                    sXmlRetorno = ws2.nfeRetRecepcao2(xNodeRet).OuterXml;
                                }
                                #endregion
                            }
                            break;
                        case "MG":
                            {
                                #region Regiao_SP
                                if (Acesso.TP_AMB == 1)
                                {
                                    HLP.GeraXml.WebService.v2_Producao_NfeRetRecepcao_MG.NfeRetRecepcao2 ws2 = new HLP.GeraXml.WebService.v2_Producao_NfeRetRecepcao_MG.NfeRetRecepcao2();
                                    HLP.GeraXml.WebService.v2_Producao_NfeRetRecepcao_MG.nfeCabecMsg cabec = new HLP.GeraXml.WebService.v2_Producao_NfeRetRecepcao_MG.nfeCabecMsg();
                                    cabec.cUF = Acesso.cUF.ToString();
                                    cabec.versaoDados = Acesso.versaoNFe;
                                    ws2.nfeCabecMsgValue = cabec;
                                    ws2.ClientCertificates.Add(Acesso.cert_NFe);
                                    XmlDocument xmlNfeDadosMsg = new XmlDocument();
                                    xmlNfeDadosMsg.LoadXml(snfeDadosMsg);
                                    XmlNode xNodeRet = xmlNfeDadosMsg.DocumentElement;
                                    sXmlRetorno = ws2.nfeRetRecepcao2(xNodeRet).OuterXml;
                                }
                                else if (Acesso.TP_AMB == 2)
                                {
                                    HLP.GeraXml.WebService.v2_Homologacao_NfeRetRecepcao_MG.NfeRetRecepcao2 ws2 = new HLP.GeraXml.WebService.v2_Homologacao_NfeRetRecepcao_MG.NfeRetRecepcao2();
                                    HLP.GeraXml.WebService.v2_Homologacao_NfeRetRecepcao_MG.nfeCabecMsg cabec = new HLP.GeraXml.WebService.v2_Homologacao_NfeRetRecepcao_MG.nfeCabecMsg();
                                    cabec.cUF = Acesso.cUF.ToString();
                                    cabec.versaoDados = Acesso.versaoNFe;
                                    ws2.nfeCabecMsgValue = cabec;
                                    ws2.ClientCertificates.Add(Acesso.cert_NFe);
                                    XmlDocument xmlNfeDadosMsg = new XmlDocument();
                                    xmlNfeDadosMsg.LoadXml(snfeDadosMsg);
                                    XmlNode xNodeRet = xmlNfeDadosMsg.DocumentElement;
                                    sXmlRetorno = ws2.nfeRetRecepcao2(xNodeRet).OuterXml;
                                }
                                #endregion
                            }
                            break;
                        case "MS":
                            {
                                #region Regiao_SP
                                if (Acesso.TP_AMB == 1)
                                {
                                    HLP.GeraXml.WebService.v2_Producao_NFeRetRecepcao_MS.NfeRetRecepcao2 ws2 = new HLP.GeraXml.WebService.v2_Producao_NFeRetRecepcao_MS.NfeRetRecepcao2();
                                    HLP.GeraXml.WebService.v2_Producao_NFeRetRecepcao_MS.nfeCabecMsg cabec = new HLP.GeraXml.WebService.v2_Producao_NFeRetRecepcao_MS.nfeCabecMsg();
                                    cabec.cUF = Acesso.cUF.ToString();
                                    cabec.versaoDados = Acesso.versaoNFe;
                                    ws2.nfeCabecMsgValue = cabec;
                                    ws2.ClientCertificates.Add(Acesso.cert_NFe);
                                    XmlDocument xmlNfeDadosMsg = new XmlDocument();
                                    xmlNfeDadosMsg.LoadXml(snfeDadosMsg);
                                    XmlNode xNodeRet = xmlNfeDadosMsg.DocumentElement;
                                    sXmlRetorno = ws2.nfeRetRecepcao2(xNodeRet).OuterXml;
                                }
                                else if (Acesso.TP_AMB == 2)
                                {
                                    //HLP.GeraXml.WebService.v2_Homologacao_NfeRetRecepcao_MS.NfeRetRecepcao2 ws2 = new HLP.GeraXml.WebService.v2_Homologacao_NfeRetRecepcao_SP.NfeRetRecepcao2();
                                    //HLP.GeraXml.WebService.v2_Homologacao_NfeRetRecepcao_SP.nfeCabecMsg cabec = new HLP.GeraXml.WebService.v2_Homologacao_NfeRetRecepcao_SP.nfeCabecMsg();
                                    //cabec.cUF = Acesso.cUF.ToString();
                                    //cabec.versaoDados = Acesso.versaoNFe;
                                    //ws2.nfeCabecMsgValue = cabec;
                                    //ws2.ClientCertificates.Add(Acesso.cert_NFe);
                                    //XmlDocument xmlNfeDadosMsg = new XmlDocument();
                                    //xmlNfeDadosMsg.LoadXml(snfeDadosMsg);
                                    //XmlNode xNodeRet = xmlNfeDadosMsg.DocumentElement;
                                    //sXmlRetorno = ws2.nfeRetRecepcao2(xNodeRet).OuterXml;
                                }
                                #endregion
                            }
                            break;
                        case "RS":
                            {
                                #region Regiao_SP
                                if (Acesso.TP_AMB == 1)
                                {
                                    HLP.GeraXml.WebService.v2_Producao_NFeRetRecepcao_RS.NfeRetRecepcao2 ws2 = new HLP.GeraXml.WebService.v2_Producao_NFeRetRecepcao_RS.NfeRetRecepcao2();
                                    HLP.GeraXml.WebService.v2_Producao_NFeRetRecepcao_RS.nfeCabecMsg cabec = new HLP.GeraXml.WebService.v2_Producao_NFeRetRecepcao_RS.nfeCabecMsg();
                                    cabec.cUF = Acesso.cUF.ToString();
                                    cabec.versaoDados = Acesso.versaoNFe;
                                    ws2.nfeCabecMsgValue = cabec;
                                    ws2.ClientCertificates.Add(Acesso.cert_NFe);
                                    XmlDocument xmlNfeDadosMsg = new XmlDocument();
                                    xmlNfeDadosMsg.LoadXml(snfeDadosMsg);
                                    XmlNode xNodeRet = xmlNfeDadosMsg.DocumentElement;
                                    sXmlRetorno = ws2.nfeRetRecepcao2(xNodeRet).OuterXml;
                                }
                                else if (Acesso.TP_AMB == 2)
                                {
                                    HLP.GeraXml.WebService.v2_Homologacao_NFeRetRecepacao_RS.NfeRetRecepcao2 ws2 = new HLP.GeraXml.WebService.v2_Homologacao_NFeRetRecepacao_RS.NfeRetRecepcao2();
                                    HLP.GeraXml.WebService.v2_Homologacao_NFeRetRecepacao_RS.nfeCabecMsg cabec = new HLP.GeraXml.WebService.v2_Homologacao_NFeRetRecepacao_RS.nfeCabecMsg();
                                    cabec.cUF = Acesso.cUF.ToString();
                                    cabec.versaoDados = Acesso.versaoNFe;
                                    ws2.nfeCabecMsgValue = cabec;
                                    ws2.ClientCertificates.Add(Acesso.cert_NFe);
                                    XmlDocument xmlNfeDadosMsg = new XmlDocument();
                                    xmlNfeDadosMsg.LoadXml(snfeDadosMsg);
                                    XmlNode xNodeRet = xmlNfeDadosMsg.DocumentElement;
                                    sXmlRetorno = ws2.nfeRetRecepcao2(xNodeRet).OuterXml;
                                }
                                #endregion
                            }
                            break;


                    }
                    //fazer Ret Recepcao para MS E RS
                }
                XmlDocument xmlRet = new XmlDocument();
                xmlRet.LoadXml(sXmlRetorno);
                return xmlRet;
            }
            catch (Exception x)
            {
                throw x;
            }
        }

        private string NfeDadosMsg(string sRec)
        {
            XNamespace xnome = "http://www.portalfiscal.inf.br/nfe";
            XmlSchemaCollection myschema = new XmlSchemaCollection();
            XmlValidatingReader reader;
            try
            {
                XNamespace xname = "http://www.portalfiscal.inf.br/nfe";
                XDocument xdoc = new XDocument(new XElement(xname + "consReciNFe", new XAttribute("versao", "2.00"),
                                               new XElement(xname + "tpAmb", Acesso.TP_AMB.ToString()),
                                               new XElement(xname + "nRec", sRec)));

                XmlParserContext context = new XmlParserContext(null, null, "", XmlSpace.None);

                reader = new XmlValidatingReader(xdoc.ToString(), XmlNodeType.Element, context);

                myschema.Add("http://www.portalfiscal.inf.br/nfe", Pastas.SCHEMA_NFE + "\\consReciNFe_v2.00.xsd");

                reader.ValidationType = ValidationType.Schema;

                reader.Schemas.Add(myschema);

                while (reader.Read())
                { }
                return xdoc.ToString();
            }
            catch (XmlException x)
            {
                throw new Exception(x.Message.ToString());
            }
            catch (XmlSchemaException x)
            {
                throw new Exception(x.Message.ToString());
            }
        }
    }
}
