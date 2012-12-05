using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Schema;
using System.Xml;
using HLP.GeraXml.Comum.Static;
using System.Data;
using HLP.GeraXml.dao.NFe;
using System.Xml.Linq;
using System.Security.Cryptography.X509Certificates;
using System.IO;
using HLP.GeraXml.dao;

namespace HLP.GeraXml.bel.NFe
{
    public class belCancelamento : daoCancelamento
    {
        public belPesquisaNotas objPesquisa = new belPesquisaNotas();
        public struct DadosRetorno
        {
            public string nNF { get; set; }
            public string seqNF { get; set; }
            public string cstat { get; set; }
            public string xServ { get; set; }
            public string chnfe { get; set; }
            public string xMotivo { get; set; }
            public string nprot { get; set; }
        }

        public DadosRetorno EfetuaCancelamento(belPesquisaNotas _objPesquisa, string sJust)
        {
            this.objPesquisa = _objPesquisa;
            string sDados = NfeDadosMsg(sJust);
            XmlDocument xRet = new XmlDocument();

            if (Acesso.TP_EMIS == 1)
            {
                switch (Acesso.xUFtoWS)
                {
                    case "SP":
                        {
                            #region Regiao_SP
                            if (Acesso.TP_AMB == 1)
                            {
                                HLP.GeraXml.WebService.v2_Producao_NFeCancelamento_SP.NfeCancelamento2 ws2 = new HLP.GeraXml.WebService.v2_Producao_NFeCancelamento_SP.NfeCancelamento2();
                                HLP.GeraXml.WebService.v2_Producao_NFeCancelamento_SP.nfeCabecMsg cabec = new HLP.GeraXml.WebService.v2_Producao_NFeCancelamento_SP.nfeCabecMsg();

                                cabec.versaoDados = Acesso.versaoNFe;
                                cabec.cUF = Acesso.cUF.ToString();
                                ws2.ClientCertificates.Add(Acesso.cert_NFe);
                                ws2.nfeCabecMsgValue = cabec;
                                XmlDocument xmlCanc = new XmlDocument();
                                xmlCanc.LoadXml(sDados);
                                XmlNode xNodeCanc = xmlCanc.DocumentElement;
                                xRet.LoadXml(ws2.nfeCancelamentoNF2(xNodeCanc).OuterXml);

                            }
                            if (Acesso.TP_AMB == 2)
                            {
                                HLP.GeraXml.WebService.v2_Homologacao_NFeCancelamento_SP.NfeCancelamento2 ws2 = new HLP.GeraXml.WebService.v2_Homologacao_NFeCancelamento_SP.NfeCancelamento2();
                                HLP.GeraXml.WebService.v2_Homologacao_NFeCancelamento_SP.nfeCabecMsg cabec = new HLP.GeraXml.WebService.v2_Homologacao_NFeCancelamento_SP.nfeCabecMsg();

                                cabec.versaoDados = Acesso.versaoNFe;
                                cabec.cUF = Acesso.cUF.ToString();
                                ws2.ClientCertificates.Add(Acesso.cert_NFe);
                                ws2.nfeCabecMsgValue = cabec;
                                XmlDocument xmlCanc = new XmlDocument();
                                xmlCanc.LoadXml(sDados);
                                XmlNode xNodeCanc = xmlCanc.DocumentElement;
                                xRet.LoadXml(ws2.nfeCancelamentoNF2(xNodeCanc).OuterXml);

                            }
                            #endregion
                        }
                        break;
                    case "RS":
                        {
                            #region Regiao_RS
                            if (Acesso.TP_AMB == 1)
                            {
                                HLP.GeraXml.WebService.v2_Producao_NFeCancelamento_RS.NfeCancelamento2 ws2 = new HLP.GeraXml.WebService.v2_Producao_NFeCancelamento_RS.NfeCancelamento2();
                                HLP.GeraXml.WebService.v2_Producao_NFeCancelamento_RS.nfeCabecMsg cabec = new HLP.GeraXml.WebService.v2_Producao_NFeCancelamento_RS.nfeCabecMsg();

                                cabec.versaoDados = Acesso.versaoNFe;
                                cabec.cUF = Acesso.cUF.ToString();
                                ws2.ClientCertificates.Add(Acesso.cert_NFe);
                                ws2.nfeCabecMsgValue = cabec;
                                XmlDocument xmlCanc = new XmlDocument();
                                xmlCanc.LoadXml(sDados);
                                XmlNode xNodeCanc = xmlCanc.DocumentElement;
                                xRet.LoadXml(ws2.nfeCancelamentoNF2(xNodeCanc).OuterXml);

                            }
                            if (Acesso.TP_AMB == 2)
                            {
                                HLP.GeraXml.WebService.v2_Homologacao_NFeCancelamento_RS.NfeCancelamento2 ws2 = new HLP.GeraXml.WebService.v2_Homologacao_NFeCancelamento_RS.NfeCancelamento2();
                                HLP.GeraXml.WebService.v2_Homologacao_NFeCancelamento_RS.nfeCabecMsg cabec = new HLP.GeraXml.WebService.v2_Homologacao_NFeCancelamento_RS.nfeCabecMsg();

                                cabec.versaoDados = Acesso.versaoNFe;
                                cabec.cUF = Acesso.cUF.ToString();
                                ws2.ClientCertificates.Add(Acesso.cert_NFe);
                                ws2.nfeCabecMsgValue = cabec;
                                XmlDocument xmlCanc = new XmlDocument();
                                xmlCanc.LoadXml(sDados);
                                XmlNode xNodeCanc = xmlCanc.DocumentElement;
                                xRet.LoadXml(ws2.nfeCancelamentoNF2(xNodeCanc).OuterXml);

                            }
                            #endregion
                        }
                        break;
                    case "MS":
                        {
                            #region Regiao_SP
                            if (Acesso.TP_AMB == 1)
                            {
                                HLP.GeraXml.WebService.v2_Producao_NFeCancelamento_MS.NfeCancelamento2 ws2 = new HLP.GeraXml.WebService.v2_Producao_NFeCancelamento_MS.NfeCancelamento2();
                                HLP.GeraXml.WebService.v2_Producao_NFeCancelamento_MS.nfeCabecMsg cabec = new HLP.GeraXml.WebService.v2_Producao_NFeCancelamento_MS.nfeCabecMsg();

                                cabec.versaoDados = Acesso.versaoNFe;
                                cabec.cUF = Acesso.cUF.ToString();
                                ws2.ClientCertificates.Add(Acesso.cert_NFe);
                                ws2.nfeCabecMsgValue = cabec;
                                XmlDocument xmlCanc = new XmlDocument();
                                xmlCanc.LoadXml(sDados);
                                XmlNode xNodeCanc = xmlCanc.DocumentElement;
                                xRet.LoadXml(ws2.nfeCancelamentoNF2(xNodeCanc).OuterXml);

                            }
                            if (Acesso.TP_AMB == 2)
                            {
                                HLP.GeraXml.WebService.v2_Homologacao_NFeCancelamento_SP.NfeCancelamento2 ws2 = new HLP.GeraXml.WebService.v2_Homologacao_NFeCancelamento_SP.NfeCancelamento2();
                                HLP.GeraXml.WebService.v2_Homologacao_NFeCancelamento_SP.nfeCabecMsg cabec = new HLP.GeraXml.WebService.v2_Homologacao_NFeCancelamento_SP.nfeCabecMsg();

                                cabec.versaoDados = Acesso.versaoNFe;
                                cabec.cUF = Acesso.cUF.ToString();
                                ws2.ClientCertificates.Add(Acesso.cert_NFe);
                                ws2.nfeCabecMsgValue = cabec;
                                XmlDocument xmlCanc = new XmlDocument();
                                xmlCanc.LoadXml(sDados);
                                XmlNode xNodeCanc = xmlCanc.DocumentElement;
                                xRet.LoadXml(ws2.nfeCancelamentoNF2(xNodeCanc).OuterXml);

                            }
                            #endregion
                        }
                        break;
                    case "SVRS":
                        {
                            #region Regiao_SP
                            if (Acesso.TP_AMB == 1)
                            {
                                HLP.GeraXml.WebService.V2_Producao_Cancelamento_SVRS.NfeCancelamento2 ws2 = new HLP.GeraXml.WebService.V2_Producao_Cancelamento_SVRS.NfeCancelamento2();
                                HLP.GeraXml.WebService.V2_Producao_Cancelamento_SVRS.nfeCabecMsg cabec = new HLP.GeraXml.WebService.V2_Producao_Cancelamento_SVRS.nfeCabecMsg();

                                cabec.versaoDados = Acesso.versaoNFe;
                                cabec.cUF = Acesso.cUF.ToString();
                                ws2.ClientCertificates.Add(Acesso.cert_NFe);
                                ws2.nfeCabecMsgValue = cabec;
                                XmlDocument xmlCanc = new XmlDocument();
                                xmlCanc.LoadXml(sDados);
                                XmlNode xNodeCanc = xmlCanc.DocumentElement;
                                xRet.LoadXml(ws2.nfeCancelamentoNF2(xNodeCanc).OuterXml);

                            }
                            if (Acesso.TP_AMB == 2)
                            {
                                HLP.GeraXml.WebService.V2_Homologacao_Cancelamento_SVRS.NfeCancelamento2 ws2 = new HLP.GeraXml.WebService.V2_Homologacao_Cancelamento_SVRS.NfeCancelamento2();
                                HLP.GeraXml.WebService.V2_Homologacao_Cancelamento_SVRS.nfeCabecMsg cabec = new HLP.GeraXml.WebService.V2_Homologacao_Cancelamento_SVRS.nfeCabecMsg();

                                cabec.versaoDados = Acesso.versaoNFe;
                                cabec.cUF = Acesso.cUF.ToString();
                                ws2.ClientCertificates.Add(Acesso.cert_NFe);
                                ws2.nfeCabecMsgValue = cabec;
                                XmlDocument xmlCanc = new XmlDocument();
                                xmlCanc.LoadXml(sDados);
                                XmlNode xNodeCanc = xmlCanc.DocumentElement;
                                xRet.LoadXml(ws2.nfeCancelamentoNF2(xNodeCanc).OuterXml);

                            }
                            #endregion
                        }
                        break;
                    case "MG":
                        {
                            #region Regiao_MG
                            if (Acesso.TP_AMB == 1)
                            {
                                HLP.GeraXml.WebService.v2_Producao_NfeCancelamento_MG.NfeCancelamento2 ws2 = new HLP.GeraXml.WebService.v2_Producao_NfeCancelamento_MG.NfeCancelamento2();
                                HLP.GeraXml.WebService.v2_Producao_NfeCancelamento_MG.nfeCabecMsg cabec = new HLP.GeraXml.WebService.v2_Producao_NfeCancelamento_MG.nfeCabecMsg();

                                cabec.versaoDados = Acesso.versaoNFe;
                                cabec.cUF = Acesso.cUF.ToString();
                                ws2.ClientCertificates.Add(Acesso.cert_NFe);
                                ws2.nfeCabecMsgValue = cabec;
                                XmlDocument xmlCanc = new XmlDocument();
                                xmlCanc.LoadXml(sDados);
                                XmlNode xNodeCanc = xmlCanc.DocumentElement;
                                xRet.LoadXml(ws2.nfeCancelamentoNF2(xNodeCanc).OuterXml);

                            }
                            if (Acesso.TP_AMB == 2)
                            {
                                HLP.GeraXml.WebService.v2_Homologacao_NfeCancelamento_MG.NfeCancelamento2 ws2 = new HLP.GeraXml.WebService.v2_Homologacao_NfeCancelamento_MG.NfeCancelamento2();
                                HLP.GeraXml.WebService.v2_Homologacao_NfeCancelamento_MG.nfeCabecMsg cabec = new HLP.GeraXml.WebService.v2_Homologacao_NfeCancelamento_MG.nfeCabecMsg();

                                cabec.versaoDados = Acesso.versaoNFe;
                                cabec.cUF = Acesso.cUF.ToString();
                                ws2.ClientCertificates.Add(Acesso.cert_NFe);
                                ws2.nfeCabecMsgValue = cabec;
                                XmlDocument xmlCanc = new XmlDocument();
                                xmlCanc.LoadXml(sDados);
                                XmlNode xNodeCanc = xmlCanc.DocumentElement;
                                xRet.LoadXml(ws2.nfeCancelamentoNF2(xNodeCanc).OuterXml);

                            }
                            #endregion
                        }
                        break;
                }
            }
            else if (Acesso.TP_EMIS == 3)
            {
                #region SCAN
                if (Acesso.TP_AMB == 1)
                {
                    HLP.GeraXml.WebService.v2_SCAN_Producao_NFeCancelamento.NfeCancelamento2 ws2 = new HLP.GeraXml.WebService.v2_SCAN_Producao_NFeCancelamento.NfeCancelamento2();
                    HLP.GeraXml.WebService.v2_SCAN_Producao_NFeCancelamento.nfeCabecMsg cabec = new HLP.GeraXml.WebService.v2_SCAN_Producao_NFeCancelamento.nfeCabecMsg();
                    cabec.versaoDados = Acesso.versaoNFe;
                    cabec.cUF = Acesso.cUF.ToString();
                    ws2.ClientCertificates.Add(Acesso.cert_NFe);
                    ws2.nfeCabecMsgValue = cabec;
                    XmlDocument xmlCanc = new XmlDocument();
                    xmlCanc.LoadXml(sDados);
                    XmlNode xNodeCanc = xmlCanc.DocumentElement;
                    xRet.LoadXml(ws2.nfeCancelamentoNF2(xNodeCanc).OuterXml);

                }
                if (Acesso.TP_AMB == 2)
                {

                    HLP.GeraXml.WebService.v2_SCAN_Homologacao_NFeCancelamento.NfeCancelamento2 ws2 = new HLP.GeraXml.WebService.v2_SCAN_Homologacao_NFeCancelamento.NfeCancelamento2();
                    HLP.GeraXml.WebService.v2_SCAN_Homologacao_NFeCancelamento.nfeCabecMsg cabec = new HLP.GeraXml.WebService.v2_SCAN_Homologacao_NFeCancelamento.nfeCabecMsg();

                    cabec.versaoDados = Acesso.versaoNFe;
                    cabec.cUF = Acesso.cUF.ToString();
                    ws2.ClientCertificates.Add(Acesso.cert_NFe);
                    ws2.nfeCabecMsgValue = cabec;
                    XmlDocument xmlCanc = new XmlDocument();
                    xmlCanc.LoadXml(sDados);
                    XmlNode xNodeCanc = xmlCanc.DocumentElement;
                    xRet.LoadXml(ws2.nfeCancelamentoNF2(xNodeCanc).OuterXml);

                }
                #endregion
            }

            return CarregaDadosRetorno(xRet);
        }

        private DadosRetorno CarregaDadosRetorno(XmlDocument xmlret)
        {
            DadosRetorno objRetorno = new DadosRetorno();
            objRetorno.cstat = xmlret.GetElementsByTagName("cStat")[0].InnerText;
            objRetorno.xMotivo = xmlret.GetElementsByTagName("xMotivo")[0].InnerText;
            objRetorno.chnfe = objPesquisa.sCHAVENFE;
            objRetorno.nNF = objPesquisa.sCD_NOTAFIS;
            objRetorno.seqNF = objPesquisa.sCD_NFSEQ;

            if (objRetorno.cstat != "101")
            {
                objRetorno.nprot = "inexistente";
            }
            else
            {
                string nprot = xmlret.GetElementsByTagName("nProt")[0].InnerText;
                AlteraNotaParaCancelada(nprot, objPesquisa.sCD_NFSEQ);
                MoveArquivoParaPastaCancelada();
            }
            return objRetorno;
        }

        private string NfeDadosMsg(string sJust)
        {
            XmlSchemaCollection myschema = new XmlSchemaCollection();
            XmlValidatingReader reader;
            try
            {
                DataTable dt = BuscaProtocoloNFe(objPesquisa.sCD_NFSEQ);


                XNamespace xname = "http://www.portalfiscal.inf.br/nfe";
                XDocument xdoc = new XDocument(new XElement(xname + "cancNFe", new XAttribute("versao", Acesso.versaoNFe),
                                                   new XElement(xname + "infCanc", new XAttribute("Id", "ID" + objPesquisa.sCHAVENFE),
                                                       new XElement(xname + "tpAmb", Acesso.TP_AMB),
                                                       new XElement(xname + "xServ", "CANCELAR"),
                                                       new XElement(xname + "chNFe", objPesquisa.sCHAVENFE),
                                                       new XElement(xname + "nProt", dt.Rows[0]["cd_nprotnfe"].ToString()),
                                                       new XElement(xname + "xJust", sJust))));
                string sPath = Pastas.PROTOCOLOS + "\\" + objPesquisa.sCD_NFSEQ + "_ped-can.xml";
                xdoc.Save(sPath);

                belAssinaXml assinaCanc = new belAssinaXml();
                string sArquivoAssinado = assinaCanc.ConfigurarArquivo(sPath, "infCanc", Acesso.cert_NFe);

                StreamReader ler;
                ler = File.OpenText(sPath);

                XmlParserContext context = new XmlParserContext(null, null, "", XmlSpace.None);

                reader = new XmlValidatingReader(ler.ReadToEnd().ToString(), XmlNodeType.Element, context);

                myschema.Add("http://www.portalfiscal.inf.br/nfe", Pastas.SCHEMA_NFE + "\\cancNFe_v2.00.xsd");

                reader.ValidationType = ValidationType.Schema;

                reader.Schemas.Add(myschema);

                while (reader.Read())
                { }
                return sArquivoAssinado;
            }
            catch (Exception x)
            {
                throw new Exception(x.Message);
            }
        }

        private void MoveArquivoParaPastaCancelada()
        {
            DirectoryInfo dinfo = new DirectoryInfo(Pastas.ENVIADOS + "\\" + objPesquisa.sCHAVENFE.Substring(2, 4));
            FileInfo f;
            try
            {
                FileInfo[] finfo = dinfo.GetFiles();

                if (finfo.Where(c => c.Name.Contains(objPesquisa.sCHAVENFE)).Count() > 0)
                {
                    f = finfo.FirstOrDefault(c => c.Name.Contains(objPesquisa.sCHAVENFE));
                    DirectoryInfo dinfoPasta = new DirectoryInfo(Pastas.CANCELADOS + "\\" + daoUtil.GetDateServidor().Date.ToString("yyMM"));
                    if (!dinfoPasta.Exists) { dinfoPasta.Create(); }
                    File.Move(f.FullName, dinfoPasta.FullName + "\\" + f.Name.Replace("nfe", "can") + ".xml");
                    File.Delete(f.FullName);
                }
            }
            catch (Exception x)
            {
                throw new Exception("Erro ao tentar mover o arquivo - " + x.Message);
            }
        }
    }



}
