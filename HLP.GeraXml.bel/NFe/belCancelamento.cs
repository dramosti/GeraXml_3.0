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
using System.Xml.Serialization;
using HLP.GeraXml.Comum;

namespace HLP.GeraXml.bel.NFe
{
    public class belCancelamento : daoCancelamento
    {
        public DadosRetorno objRetorno = new DadosRetorno();
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

        public void EfetuaCancelamento(belPesquisaNotas _objPesquisa, string sJust, int iNumEvento)
        {
            this.objPesquisa = _objPesquisa;
            string sDados = NFeDadosMsg2(_objPesquisa, sJust, iNumEvento);
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
                                HLP.GeraXml.WebService.v2_Producao_NFeRecepcaoEvento_SP.RecepcaoEvento ws2 = new WebService.v2_Producao_NFeRecepcaoEvento_SP.RecepcaoEvento();
                                HLP.GeraXml.WebService.v2_Producao_NFeRecepcaoEvento_SP.nfeCabecMsg cabec = new WebService.v2_Producao_NFeRecepcaoEvento_SP.nfeCabecMsg();

                                cabec.versaoDados = "1.00";
                                cabec.cUF = Acesso.cUF.ToString();
                                ws2.ClientCertificates.Add(Acesso.cert_NFe);
                                ws2.nfeCabecMsgValue = cabec;
                                XmlDocument xmlCanc = new XmlDocument();
                                xmlCanc.LoadXml(sDados);
                                XmlNode xNodeCanc = xmlCanc.DocumentElement;
                                string sRet = ws2.nfeRecepcaoEvento(xNodeCanc).OuterXml;
                                xRet.LoadXml(sRet);

                            }
                            if (Acesso.TP_AMB == 2)
                            {
                                HLP.GeraXml.WebService.v2_Homologacao_NFeRecepcaoEvento_SP.nfeCabecMsg cabec = new HLP.GeraXml.WebService.v2_Homologacao_NFeRecepcaoEvento_SP.nfeCabecMsg();
                                HLP.GeraXml.WebService.v2_Homologacao_NFeRecepcaoEvento_SP.RecepcaoEvento ws2 = new HLP.GeraXml.WebService.v2_Homologacao_NFeRecepcaoEvento_SP.RecepcaoEvento();

                                cabec.versaoDados = "1.00";
                                cabec.cUF = Acesso.cUF.ToString();
                                ws2.ClientCertificates.Add(Acesso.cert_NFe);
                                ws2.nfeCabecMsgValue = cabec;
                                XmlDocument xmlCanc = new XmlDocument();
                                xmlCanc.LoadXml(sDados);
                                XmlNode xNodeCanc = xmlCanc.DocumentElement;
                                string sRet = ws2.nfeRecepcaoEvento(xNodeCanc).OuterXml;
                                xRet.LoadXml(sRet);

                            }
                            #endregion
                        }
                        break;
                    case "RS":
                        {
                            #region Regiao_RS
                            if (Acesso.TP_AMB == 1)
                            {
                                HLP.GeraXml.WebService.v2_Producao_NFeRecepcaoEvento_RS.RecepcaoEvento ws2 = new WebService.v2_Producao_NFeRecepcaoEvento_RS.RecepcaoEvento();
                                HLP.GeraXml.WebService.v2_Producao_NFeRecepcaoEvento_RS.nfeCabecMsg cabec = new WebService.v2_Producao_NFeRecepcaoEvento_RS.nfeCabecMsg();

                                cabec.versaoDados = "1.00";
                                cabec.cUF = Acesso.cUF.ToString();
                                ws2.ClientCertificates.Add(Acesso.cert_NFe);
                                ws2.nfeCabecMsgValue = cabec;
                                XmlDocument xmlCanc = new XmlDocument();
                                xmlCanc.LoadXml(sDados);
                                XmlNode xNodeCanc = xmlCanc.DocumentElement;
                                string sRet = ws2.nfeRecepcaoEvento(xNodeCanc).OuterXml;
                                xRet.LoadXml(sRet);

                            }
                            if (Acesso.TP_AMB == 2)
                            {
                                HLP.GeraXml.WebService.v2_Homologacao_NFeRecepcaoEvento_RS.nfeCabecMsg cabec = new HLP.GeraXml.WebService.v2_Homologacao_NFeRecepcaoEvento_RS.nfeCabecMsg();
                                HLP.GeraXml.WebService.v2_Homologacao_NFeRecepcaoEvento_RS.RecepcaoEvento ws2 = new HLP.GeraXml.WebService.v2_Homologacao_NFeRecepcaoEvento_RS.RecepcaoEvento();

                                cabec.versaoDados = "1.00";
                                cabec.cUF = Acesso.cUF.ToString();
                                ws2.ClientCertificates.Add(Acesso.cert_NFe);
                                ws2.nfeCabecMsgValue = cabec;
                                XmlDocument xmlCanc = new XmlDocument();
                                xmlCanc.LoadXml(sDados);
                                XmlNode xNodeCanc = xmlCanc.DocumentElement;
                                string sRet = ws2.nfeRecepcaoEvento(xNodeCanc).OuterXml;
                                xRet.LoadXml(sRet);

                            }
                            #endregion
                        }
                        break;
                    case "MS":
                        {
                            #region Regiao_SP
                            if (Acesso.TP_AMB == 1)
                            {
                                HLP.GeraXml.WebService.v2_Producao_NFeRecepcaoEvento_MS.nfeCabecMsg cabec = new HLP.GeraXml.WebService.v2_Producao_NFeRecepcaoEvento_MS.nfeCabecMsg();
                                HLP.GeraXml.WebService.v2_Producao_NFeRecepcaoEvento_MS.RecepcaoEvento ws2 = new HLP.GeraXml.WebService.v2_Producao_NFeRecepcaoEvento_MS.RecepcaoEvento();

                                cabec.versaoDados = "1.00";
                                cabec.cUF = Acesso.cUF.ToString();
                                ws2.ClientCertificates.Add(Acesso.cert_NFe);
                                ws2.nfeCabecMsgValue = cabec;
                                XmlDocument xmlCanc = new XmlDocument();
                                xmlCanc.LoadXml(sDados);
                                XmlNode xNodeCanc = xmlCanc.DocumentElement;
                                string sRet = ws2.nfeRecepcaoEvento(xNodeCanc).OuterXml;
                                xRet.LoadXml(sRet);

                            }
                            if (Acesso.TP_AMB == 2)
                            {
                                throw new Exception("Não implementado");

                            }
                            #endregion
                        }
                        break;
                    case "SVRS":
                        {
                            #region Regiao_SP
                            if (Acesso.TP_AMB == 1)
                            {
                                HLP.GeraXml.WebService.V2_Producao_RecepcaoEvento_SVRS.nfeCabecMsg cabec = new HLP.GeraXml.WebService.V2_Producao_RecepcaoEvento_SVRS.nfeCabecMsg();
                                HLP.GeraXml.WebService.V2_Producao_RecepcaoEvento_SVRS.RecepcaoEvento ws2 = new HLP.GeraXml.WebService.V2_Producao_RecepcaoEvento_SVRS.RecepcaoEvento();

                                cabec.versaoDados = "1.00";
                                cabec.cUF = Acesso.cUF.ToString();
                                ws2.ClientCertificates.Add(Acesso.cert_NFe);
                                ws2.nfeCabecMsgValue = cabec;
                                XmlDocument xmlCanc = new XmlDocument();
                                xmlCanc.LoadXml(sDados);
                                XmlNode xNodeCanc = xmlCanc.DocumentElement;
                                string sRet = ws2.nfeRecepcaoEvento(xNodeCanc).OuterXml;
                                xRet.LoadXml(sRet);
                            }
                            if (Acesso.TP_AMB == 2)
                            {                                
                                throw new Exception("Não implementado para o RJ em modo de homologação.");
                            }
                            #endregion
                        }
                        break;
                    case "MG":
                        {
                            #region Regiao_MG
                            if (Acesso.TP_AMB == 1)
                            {
                                HLP.GeraXml.WebService.v2_Producao_RecepcaoEvento_MG.nfeCabecMsg cabec = new HLP.GeraXml.WebService.v2_Producao_RecepcaoEvento_MG.nfeCabecMsg();
                                HLP.GeraXml.WebService.v2_Producao_RecepcaoEvento_MG.RecepcaoEvento ws2 = new HLP.GeraXml.WebService.v2_Producao_RecepcaoEvento_MG.RecepcaoEvento();

                                cabec.versaoDados = "1.00";
                                cabec.cUF = Acesso.cUF.ToString();
                                ws2.ClientCertificates.Add(Acesso.cert_NFe);
                                ws2.nfeCabecMsgValue = cabec;
                                XmlDocument xmlCanc = new XmlDocument();
                                xmlCanc.LoadXml(sDados);
                                XmlNode xNodeCanc = xmlCanc.DocumentElement;
                                string sRet = ws2.nfeRecepcaoEvento(xNodeCanc).OuterXml;
                                xRet.LoadXml(sRet);

                            }
                            if (Acesso.TP_AMB == 2)
                            {
                                HLP.GeraXml.WebService.v2_Homologacao_RecepcaoEvento_MG.nfeCabecMsg cabec = new HLP.GeraXml.WebService.v2_Homologacao_RecepcaoEvento_MG.nfeCabecMsg();
                                HLP.GeraXml.WebService.v2_Homologacao_RecepcaoEvento_MG.RecepcaoEvento ws2 = new HLP.GeraXml.WebService.v2_Homologacao_RecepcaoEvento_MG.RecepcaoEvento();

                                cabec.versaoDados = "1.00";
                                cabec.cUF = Acesso.cUF.ToString();
                                ws2.ClientCertificates.Add(Acesso.cert_NFe);
                                ws2.nfeCabecMsgValue = cabec;
                                XmlDocument xmlCanc = new XmlDocument();
                                xmlCanc.LoadXml(sDados);
                                XmlNode xNodeCanc = xmlCanc.DocumentElement;
                                string sRet = ws2.nfeRecepcaoEvento(xNodeCanc).OuterXml;
                                xRet.LoadXml(sRet);

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
            else if (Acesso.TP_EMIS == 6)
            {
                #region SCAN
                if (Acesso.TP_AMB == 1)
                {
                    HLP.GeraXml.WebService.v2_SVC_Producao_RecepcaoEvento.RecepcaoEvento ws2 = new WebService.v2_SVC_Producao_RecepcaoEvento.RecepcaoEvento();
                    HLP.GeraXml.WebService.v2_SVC_Producao_RecepcaoEvento.nfeCabecMsg cabec = new WebService.v2_SVC_Producao_RecepcaoEvento.nfeCabecMsg();

                    cabec.versaoDados = "1.00";
                    cabec.cUF = Acesso.cUF.ToString();
                    ws2.ClientCertificates.Add(Acesso.cert_NFe);
                    ws2.nfeCabecMsgValue = cabec;
                    XmlDocument xmlCanc = new XmlDocument();
                    xmlCanc.LoadXml(sDados);
                    XmlNode xNodeCanc = xmlCanc.DocumentElement;
                    string sRet = ws2.nfeRecepcaoEvento(xNodeCanc).OuterXml;
                    xRet.LoadXml(sRet);

                }
                if (Acesso.TP_AMB == 2)
                {
                    HLP.GeraXml.WebService.v2_SVC_Homologacao_RecepcaoEvento.RecepcaoEvento ws2 = new WebService.v2_SVC_Homologacao_RecepcaoEvento.RecepcaoEvento();
                    HLP.GeraXml.WebService.v2_SVC_Homologacao_RecepcaoEvento.nfeCabecMsg cabec = new WebService.v2_SVC_Homologacao_RecepcaoEvento.nfeCabecMsg();

                    cabec.versaoDados = "1.00";
                    cabec.cUF = Acesso.cUF.ToString();
                    ws2.ClientCertificates.Add(Acesso.cert_NFe);
                    ws2.nfeCabecMsgValue = cabec;
                    XmlDocument xmlCanc = new XmlDocument();
                    xmlCanc.LoadXml(sDados);
                    XmlNode xNodeCanc = xmlCanc.DocumentElement;
                    string sRet = ws2.nfeRecepcaoEvento(xNodeCanc).OuterXml;
                    xRet.LoadXml(sRet);
                }
                #endregion
            }


            string sPath = Pastas.PROTOCOLOS + "\\" + objPesquisa.sCD_NFSEQ + "_Ret_Pedcan" + DateTime.Now.ToString("ddMMyyHHmmss") + ".xml";
            xRet.Save(sPath);

            belRetEventoCancelamento objRet = SerializeClassToXml.DeserializeClasse<belRetEventoCancelamento>(sPath);

            if (objRet.retEvento.infEvento.cStat == "573")
            {
                objRetorno = new DadosRetorno();
                iNumEvento = iNumEvento + 1;
                EfetuaCancelamento(_objPesquisa, sJust, iNumEvento);
            }
            else
            {
              objRetorno =  CarregaDadosRetorno(objRet);
            }            
        }

        private DadosRetorno CarregaDadosRetorno(belRetEventoCancelamento objret)
        {
            DadosRetorno objRetorno = new DadosRetorno();

            objRetorno.cstat = objret.retEvento.infEvento.cStat.ToString();
            objRetorno.xMotivo = objret.retEvento.infEvento.xMotivo;
            objRetorno.chnfe = objret.retEvento.infEvento.chNFe;
            objRetorno.nNF = objPesquisa.sCD_NOTAFIS;
            objRetorno.seqNF = objPesquisa.sCD_NFSEQ;

            //if (objRetorno.cstat != "101" && objRetorno.cstat != "151" && objRetorno.cstat != "155")
            if (objRetorno.cstat != "135" && objRetorno.cstat != "136")
            {
                objRetorno.nprot = "inexistente";
            }
            else
            {
                string nprot = objret.retEvento.infEvento.nProt.ToString();
                AlteraNotaParaCancelada(nprot, objPesquisa.sCD_NFSEQ);
                MoveArquivoParaPastaCancelada(objPesquisa);
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


        private string NFeDadosMsg2(belPesquisaNotas nota, string sJust, int iNumEvento)
        {
            string sVersao = "1.00";
            belCancelamento2 objcanc = new belCancelamento2();
            objcanc.idLote = nota.sCD_NFSEQ.PadLeft(15, '0');
            objcanc.versao = sVersao;
            Evento evento = new Evento();
            evento.versao = sVersao;
            evento.infEvento = new eventoInfEvento();

            evento.infEvento.nSeqEvento = iNumEvento.ToString(); // numero de evento
            evento.infEvento.Id = "ID" + evento.infEvento.tpEvento + nota.sCHAVENFE + evento.infEvento.nSeqEvento.PadLeft(2, '0');
            evento.infEvento.cOrgao = Convert.ToByte(Acesso.cUF);
            evento.infEvento.tpAmb = Convert.ToByte(Acesso.TP_AMB);
            evento.infEvento.CNPJ = Util.RetiraCaracterCNPJ(Acesso.CNPJ_EMPRESA);
            evento.infEvento.chNFe = nota.sCHAVENFE;
            evento.infEvento.dhEvento = daoUtil.GetDateServidor().ToString("yyyy-MM-ddTHH:mm:ss" + Acesso.FUSO);
            evento.infEvento.verEvento = sVersao;
            evento.infEvento.detEvento = new eventoInfEventoDetEvento();
            evento.infEvento.detEvento.versao = sVersao;
            evento.infEvento.detEvento.descEvento = "Cancelamento";
            evento.infEvento.detEvento.nProt = nota.cd_nprotnfe;
            evento.infEvento.detEvento.xJust = sJust;

            string sEvento = "";

            XmlSerializerNamespaces nameSpaces = new XmlSerializerNamespaces();
            nameSpaces.Add("", "");
            nameSpaces.Add("", "http://www.portalfiscal.inf.br/nfe");


            XmlSerializer xs = new XmlSerializer(typeof(Evento));
            MemoryStream memory = new MemoryStream();
            XmlTextWriter xmltext = new XmlTextWriter(memory, Encoding.UTF8);
            xs.Serialize(xmltext, evento, nameSpaces);
            UTF8Encoding encoding = new UTF8Encoding();
            sEvento = encoding.GetString(memory.ToArray());
            sEvento = sEvento.Substring(1);

            

            belAssinaXml Assinatura = new belAssinaXml();
            sEvento = Assinatura.ConfigurarArquivo(sEvento, "infEvento", Acesso.cert_NFe);

            string sXMLfinal = "<?xml version=\"1.0\" encoding=\"utf-8\"?><envEvento xmlns=\"http://www.portalfiscal.inf.br/nfe\" versao=\"1.00\"><idLote>" + nota.sCD_NFSEQ.PadLeft(15, '0')
                                + "</idLote>" + sEvento.Replace("<?xml version=\"1.0\" encoding=\"utf-8\"?>", "") + "</envEvento>";

            XmlDocument xDoc = new XmlDocument();
            xDoc.LoadXml(sXMLfinal);
            string sPath = Pastas.PROTOCOLOS + "\\" + objPesquisa.sCD_NFSEQ + "_ped-can.xml";
            if (File.Exists(sPath))
            {
                File.Delete(sPath);
            }
            xDoc.Save(sPath);
            try
            {
                belValidaXml.ValidarXml("http://www.portalfiscal.inf.br/nfe", Pastas.SCHEMA_CANC + "\\envEventoCancNFe_v1.00.xsd", sPath);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return sXMLfinal;
        }


        private string NfeDadosMsg3(string sJust)
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


                string sXMLfinal = "<?xml version=\"1.0\" encoding=\"utf-8\"?><procCancNFe xmlns=\"http://www.portalfiscal.inf.br/nfe\" versao=\"2.00\">"
                    + sArquivoAssinado.Replace("<?xml version=\"1.0\" encoding=\"utf-8\"?>", "") + "</procCancNFe>";

                XmlDocument xDoc = new XmlDocument();
                xDoc.LoadXml(sXMLfinal);
                if (File.Exists(sPath))
                {
                    File.Delete(sPath);
                }
                xDoc.Save(sPath);
                try
                {
                    belValidaXml.ValidarXml("http://www.portalfiscal.inf.br/nfe", Pastas.SCHEMA_CANC + "\\procEventoCancNFe_v1.00.xsd", sPath);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return sXMLfinal;
            }
            catch (Exception x)
            {
                throw new Exception(x.Message);
            }
        }
               

        public static void MoveArquivoParaPastaCancelada(belPesquisaNotas objPesquisa)
        {
            DirectoryInfo dinfo = new DirectoryInfo(Pastas.ENVIADOS + "\\" + objPesquisa.sCHAVENFE.Substring(2, 4));
            FileInfo f;
            
            try
            {
                FileInfo[] finfo = dinfo.GetFiles();

                if (finfo.Where(c => c.Name.Contains(objPesquisa.sCHAVENFE)).Count() > 0)
                {
                    f = finfo.FirstOrDefault(c => c.Name.Contains(objPesquisa.sCHAVENFE));
                    DirectoryInfo dinfoPasta = new DirectoryInfo(Pastas.CANCELADOS + "\\" + objPesquisa.dDT_EMI.Date.ToString("yyMM"));
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
