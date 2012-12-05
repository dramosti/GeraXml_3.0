using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Linq;
using HLP.GeraXml.Comum.Static;
using HLP.GeraXml.dao.NFe;
using System.Data;

namespace HLP.GeraXml.bel.NFe
{
    public class belConsultaStatusCliente : daoConsultaStatusCliente
    {
        public struct DadosRetorno
        {
            public string cStat { get; set; }
            public string xMotivo { get; set; }
            public string dhCons { get; set; }
            public string cSit { get; set; }
            public string xNome { get; set; }
            public string xRegApur { get; set; }
            public string CNAE { get; set; }
            public string dIniAtiv { get; set; }
            public string dUltSit { get; set; }
            public string dBaixa { get; set; }
        }
        private belPesquisaNotas objPesquisa = new belPesquisaNotas();
        private string sUF { get; set; }
        private string sIE { get; set; }
        private string sCNPJ { get; set; }
        private string sCPF { get; set; }

        public belConsultaStatusCliente(belPesquisaNotas _objPesquisa)
        {
            this.objPesquisa = _objPesquisa;
        }

        public DadosRetorno ConsultaCadastro()
        {
            try
            {
                foreach (DataRow item in BuscaInformacoesCliente(objPesquisa.sCD_NFSEQ).Rows)
                {
                    sUF = item["sUF"].ToString();
                    sIE = item["sIE"].ToString();
                    sCNPJ = item["sCNPJ"].ToString();
                    sCPF = item["sCPF"].ToString();
                    break;
                }

                StringBuilder sMsgRetorno = new StringBuilder();
                XmlDocument xRetorno = new XmlDocument();

                switch (Acesso.xUF)
                {
                    case "SP":
                        {
                            HLP.GeraXml.WebService.v2_Producao_NFeConsultaCadastro_SP.CadConsultaCadastro2 ws2 = new HLP.GeraXml.WebService.v2_Producao_NFeConsultaCadastro_SP.CadConsultaCadastro2();
                            HLP.GeraXml.WebService.v2_Producao_NFeConsultaCadastro_SP.nfeCabecMsg cabec = new HLP.GeraXml.WebService.v2_Producao_NFeConsultaCadastro_SP.nfeCabecMsg();
                            belUF objbelUF = new belUF();
                            cabec.cUF = objbelUF.RetornaCUF(sUF);
                            cabec.versaoDados = "2.00";
                            ws2.nfeCabecMsgValue = cabec;
                            ws2.ClientCertificates.Add(Acesso.cert_NFe);
                            XmlNode xDados = MontaMsg();
                            string sretorno = ws2.consultaCadastro2(xDados).OuterXml;                           
                            xRetorno.LoadXml(sretorno);                           
                        }
                        break;
                    case "MG":
                        {
                            HLP.GeraXml.WebService.v2_Producao_NfeConsultaCadastro_MG.CadConsultaCadastro2 ws2 = new HLP.GeraXml.WebService.v2_Producao_NfeConsultaCadastro_MG.CadConsultaCadastro2();
                            HLP.GeraXml.WebService.v2_Producao_NfeConsultaCadastro_MG.nfeCabecMsg cabec = new HLP.GeraXml.WebService.v2_Producao_NfeConsultaCadastro_MG.nfeCabecMsg();
                            belUF objbelUF = new belUF();
                            cabec.cUF = objbelUF.RetornaCUF(sUF);
                            cabec.versaoDados = "2.00";
                            ws2.nfeCabecMsgValue = cabec;
                            ws2.ClientCertificates.Add(Acesso.cert_NFe);
                            XmlNode xDados = MontaMsg();
                            string sretorno = ws2.consultaCadastro2(xDados).OuterXml;
                            xRetorno.LoadXml(sretorno);
                        }
                        break;         
                    //case "RS":
                    //    {
                    //        HLP.WebService.v2_Producao_NFeConsultaCadastro_RS.CadConsultaCadastro2 ws2 = new HLP.WebService.v2_Producao_NFeConsultaCadastro_RS.CadConsultaCadastro2();
                    //        HLP.WebService.v2_Producao_NFeConsultaCadastro_RS.nfeCabecMsg cabec = new HLP.WebService.v2_Producao_NFeConsultaCadastro_RS.nfeCabecMsg();
                    //        belUF objbelUF = new belUF();
                    //        cabec.cUF = objbelUF.RetornaCUF(sUF);
                    //        cabec.versaoDados = "2.00";
                    //        ws2.nfeCabecMsgValue = cabec;
                    //        ws2.ClientCertificates.Add(cert);
                    //        XmlNode xDados = MontaMsg();
                    //        string sretorno = ws2.consultaCadastro2(xDados).OuterXml;
                    //        XmlDocument xRetorno = new XmlDocument();
                    //        xRetorno.LoadXml(sretorno);
                    //        MontaMsgRetorno(sMsgRetorno, xRetorno);
                    //    }
                    //    break;
                    //case "MS":
                    //    {
                    //        HLP.WebService.v2_Producao_NFeConsultaCadastro_MS.CadConsultaCadastro2 ws2 = new HLP.WebService.v2_Producao_NFeConsultaCadastro_MS.CadConsultaCadastro2();
                    //        HLP.WebService.v2_Producao_NFeConsultaCadastro_MS.nfeCabecMsg cabec = new HLP.WebService.v2_Producao_NFeConsultaCadastro_MS.nfeCabecMsg();
                    //        belUF objbelUF = new belUF();
                    //        cabec.cUF = objbelUF.RetornaCUF(sUF);
                    //        cabec.versaoDados = "2.00";
                    //        ws2.nfeCabecMsgValue = cabec;
                    //        ws2.ClientCertificates.Add(cert);
                    //        XmlNode xDados = MontaMsg();
                    //        string sretorno = ws2.consultaCadastro2(xDados).OuterXml;
                    //        XmlDocument xRetorno = new XmlDocument();
                    //        xRetorno.LoadXml(sretorno);
                    //        MontaMsgRetorno(sMsgRetorno, xRetorno);
                    //    }
                    //    break;
                }
                return MontaMsgRetorno(xRetorno);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        private XmlNode MontaMsg()
        {
            try
            {
                XmlSchemaCollection myschema = new XmlSchemaCollection();
                XmlValidatingReader reader;
                XNamespace pf = "http://www.portalfiscal.inf.br/nfe";

                XDocument xdoc = new XDocument(new XElement(pf + "ConsCad", new XAttribute("versao", "2.00"),
                                                    new XElement(pf + "infCons",
                                                               new XElement(pf + "xServ", "CONS-CAD"),
                                                               new XElement(pf + "UF", sUF),
                                                               (sIE != "" ? new XElement(pf + "IE", Util.TiraSimbolo(sIE, "")) : null),
                                                               ((sCNPJ != "" && sIE == "") ? new XElement(pf + "CNPJ", Util.TiraSimbolo(sCNPJ, "")) : null),
                                                               ((sCPF != "" && sIE == "" && sCNPJ == "") ? new XElement(pf + "CPF", Util.TiraSimbolo(sCPF, "")) : null))));



                XmlParserContext context = new XmlParserContext(null, null, "", XmlSpace.None);

                reader = new XmlValidatingReader(xdoc.ToString(), XmlNodeType.Element, context);

                myschema.Add("http://www.portalfiscal.inf.br/nfe", Pastas.SCHEMA_NFE + "\\consCad_v2.00.xsd");

                reader.ValidationType = ValidationType.Schema;

                reader.Schemas.Add(myschema);

                while (reader.Read())
                { }
                string sDados = xdoc.ToString();
                XmlDocument Xmldoc = new XmlDocument();
                Xmldoc.LoadXml(sDados);
                XmlNode xNode = Xmldoc.DocumentElement;
                return xNode;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private DadosRetorno MontaMsgRetorno(XmlDocument xRetorno)
        {
            DadosRetorno objRet = new DadosRetorno();
            XmlNodeList cStat = xRetorno.GetElementsByTagName("cStat");
            XmlNodeList xMotivo = xRetorno.GetElementsByTagName("xMotivo");
            XmlNodeList dhCons = xRetorno.GetElementsByTagName("dhCons");
            XmlNodeList cSit = xRetorno.GetElementsByTagName("cSit");
            XmlNodeList xNome = xRetorno.GetElementsByTagName("xNome");
            XmlNodeList xRegApur = xRetorno.GetElementsByTagName("xRegApur");
            XmlNodeList CNAE = xRetorno.GetElementsByTagName("CNAE");
            XmlNodeList dIniAtiv = xRetorno.GetElementsByTagName("dIniAtiv");
            XmlNodeList dUltSit = xRetorno.GetElementsByTagName("dUltSit");
            XmlNodeList dBaixa = xRetorno.GetElementsByTagName("dBaixa");

            if (cStat.Count > 0)
            {
                objRet.cStat = cStat[0].InnerText.ToString();
            }

            if (xMotivo.Count > 0)
            {
                objRet.xMotivo = xMotivo[0].InnerText.ToString();
            }
            if (cSit.Count > 0)
            {
                objRet.cSit = (cSit[0].InnerText.ToString() == "0" ? "Não Habilitado" : "Habilitado.");
            }

            if (dhCons.Count > 0)
            {
                objRet.dhCons = Convert.ToDateTime(dhCons[0].InnerText).ToString("dd/MM/yyyy HH:mm:ss");
            }

            if (xNome.Count > 0)
            {
                objRet.xNome = xNome[0].InnerText.ToString();
            }

            if (xRegApur.Count > 0)
            {
                objRet.xRegApur = xRegApur[0].InnerText.ToString();
            }

            if (CNAE.Count > 0)
            {
                objRet.CNAE = CNAE[0].InnerText.ToString();
            }

            if (dIniAtiv.Count > 0)
            {
                objRet.dIniAtiv = Convert.ToDateTime(dIniAtiv[0].InnerText).ToString("dd/MM/yyyy");
            }

            if (dUltSit.Count > 0)
            {
                objRet.dUltSit = Convert.ToDateTime(dUltSit[0].InnerText).ToString("dd/MM/yyyy");
            }

            if (dBaixa.Count > 0)
            {
                objRet.dBaixa = Convert.ToDateTime(dBaixa[0].InnerText).ToString("dd/MM/yyyy");
            }
            return objRet;
        }


    }
}
