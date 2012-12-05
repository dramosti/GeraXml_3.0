using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ComponentFactory.Krypton.Toolkit;
using System.Windows.Forms;
using HLP.GeraXml.Comum.Static;
using System.Xml;
using System.IO;
using System.Xml.Schema;
using System.Xml.Linq;
using HLP.GeraXml.dao.NFes;
using System.Data;
using HLP.GeraXml.Comum;

namespace HLP.GeraXml.bel.NFes
{
    public class belRecepcao : daoRecepcao
    {
        string sReciboProt;
        daoBuscaDados objdaoBuscaDados = new daoBuscaDados();
        private string sLoteXml;
        private tcLoteRps objLoteRpsAlter;
        private TcInfNfse objNfseRetorno;

        public List<TcInfNfse> objListaNfseRetorno = new List<TcInfNfse>();
        public string sCodigoRetorno = "";
        public string NumeroLote { get; set; }
        private string _Protocolo;

        public string Protocolo
        {
            get { return _Protocolo; }
            set { _Protocolo = Convert.ToInt32(value).ToString(); }
        }

        public string sMsgTransmissao { get; set; }

        public belRecepcao() { }

        public belRecepcao(string sLoteXml, tcLoteRps objLoteRpsAlter)
        {
            this.sLoteXml = sLoteXml;
            this.objLoteRpsAlter = objLoteRpsAlter;
            TransmitirLote();
        }

        private void TransmitirLote()
        {
            string sRet = "";
            sMsgTransmissao = "";
            try
            {
                if (Acesso.tipoWsNfse == Acesso.TP_WS_NFSE.GINFES)
                {
                    if (Acesso.TP_AMB_SERV == 2)
                    {
                        WebService.Itu_servicos_Homologacao.ServiceGinfesImplService objtrans = new WebService.Itu_servicos_Homologacao.ServiceGinfesImplService();
                        objtrans.ClientCertificates.Add(Acesso.cert_NFs);
                        objtrans.Timeout = 60000;
                        sRet = objtrans.RecepcionarLoteRpsV3(NfeCabecMsg(), sLoteXml);
                    }
                    else if (Acesso.TP_AMB_SERV == 1)
                    {
                        WebService.Itu_servicos_Producao.ServiceGinfesImplService objtrans = new WebService.Itu_servicos_Producao.ServiceGinfesImplService();
                        objtrans.ClientCertificates.Add(Acesso.cert_NFs);
                        objtrans.Timeout = 60000;
                        sRet = objtrans.RecepcionarLoteRpsV3(NfeCabecMsg(), sLoteXml);
                    }
                    else
                    {
                        throw new Exception("Cadastro de Empresa não configurado para enviar NFe-serviço");
                    }
                }
                else if (Acesso.tipoWsNfse == Acesso.TP_WS_NFSE.TIPLAN)
                {
                    WebService.riodasostras_Producao.Nfse nfse = new WebService.riodasostras_Producao.Nfse();
                    nfse.ClientCertificates.Add(Acesso.cert_NFs);
                    nfse.Timeout = 60000;

                    sRet = nfse.RecepcionarLoteRps(sLoteXml);
                }
                ConfiguraMsgdeTransmissao(sRet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ConfiguraMsgdeTransmissao(string sRet)
        {
            XmlDocument xmlRet = new XmlDocument();
            xmlRet.LoadXml(sRet);

            XmlNodeList xNodeList = null;

            if (xmlRet.GetElementsByTagName((Acesso.tipoWsNfse == Acesso.TP_WS_NFSE.GINFES ? "ns3:" : "") + "EnviarLoteRpsResposta").Count > 0)
            {
                xNodeList = xmlRet.GetElementsByTagName((Acesso.tipoWsNfse == Acesso.TP_WS_NFSE.GINFES ? "ns3:" : "") + "EnviarLoteRpsResposta");
            }
            if (xmlRet.GetElementsByTagName((Acesso.tipoWsNfse == Acesso.TP_WS_NFSE.GINFES ? "ns2:" : "") + "MensagemRetorno").Count > 0)
            {
                xNodeList = xmlRet.GetElementsByTagName((Acesso.tipoWsNfse == Acesso.TP_WS_NFSE.GINFES ? "nss:" : "") + "MensagemRetorno");
            }

            foreach (XmlNode node in xNodeList)
            {
                if (node[(Acesso.tipoWsNfse == Acesso.TP_WS_NFSE.GINFES ? "ns3:" : "") + "Protocolo"] != null)
                {
                    this.NumeroLote = node[(Acesso.tipoWsNfse == Acesso.TP_WS_NFSE.GINFES ? "ns3:" : "") + "NumeroLote"].InnerText;
                    this.Protocolo = node[(Acesso.tipoWsNfse == Acesso.TP_WS_NFSE.GINFES ? "ns3:" : "") + "Protocolo"].InnerText;

                    //Salva Protocolo do Lote
                    DirectoryInfo dPastaData = new DirectoryInfo(Pastas.PROTOCOLOS + "\\Servicos\\");
                    if (!dPastaData.Exists) { dPastaData.Create(); }
                    xmlRet.Save(Pastas.PROTOCOLOS + "\\Servicos\\" + "lote_" + this.NumeroLote.PadLeft(15, '0') + "_prot_" + this.Protocolo + ".xml");
                }
                else
                {
                    sMsgTransmissao = "{3}Código: {0}{3}{3}Mensagem: {1}{3}{3}Correção: {2}{3}";
                    sMsgTransmissao = string.Format(sMsgTransmissao, node[(Acesso.tipoWsNfse == Acesso.TP_WS_NFSE.GINFES ? "ns2:" : "") + "Codigo"].InnerText,
                                              node[(Acesso.tipoWsNfse == Acesso.TP_WS_NFSE.GINFES ? "ns2:" : "") + "Mensagem"].InnerText,
                                              node[(Acesso.tipoWsNfse == Acesso.TP_WS_NFSE.GINFES ? "ns2:" : "") + "Correcao"].InnerText, Environment.NewLine);

                }

            }
        }

        public string BuscaRetorno(tcIdentificacaoPrestador Prestador, KryptonLabel lblStatus, ProgressBar ProgresStatus)
        {

            bool parar = false;
            string sMensagemErro = "";
            int iCountBuscaRet = 1;

            ProgresStatus.Step = 1;
            ProgresStatus.Minimum = 0;
            ProgresStatus.Maximum = 20;
            ProgresStatus.MarqueeAnimationSpeed = 20;
            ProgresStatus.Value = 0;

            try
            {
                for (; ; )
                {
                    ProgresStatus.PerformStep();
                    ProgresStatus.Refresh();
                    lblStatus.Text = "O Sistema está tentando buscar Retorno..." + Environment.NewLine + "Tentativa " + iCountBuscaRet.ToString() + " de 21";
                    lblStatus.Refresh();
                    string sRetConsulta = BuscaRetornoWebService(Prestador);
                    XmlDocument xmlRet = new XmlDocument();
                    xmlRet.LoadXml(sRetConsulta);
                    
                    XmlNodeList xNodeList = xmlRet.GetElementsByTagName((Acesso.tipoWsNfse == Acesso.TP_WS_NFSE.GINFES ? "ns4:" : "")+"MensagemRetorno");

                    if (xNodeList.Count > 0)
                    {
                        sMensagemErro = "{3}Lote: " + NumeroLote + "{3}{3}Código: {0}{3}{3}Mensagem: {1}{3}{3}Correção: {2}{3}{3}Protocolo: " + Protocolo;

                        foreach (XmlNode node in xNodeList)
                        {
                            sCodigoRetorno = node[(Acesso.tipoWsNfse == Acesso.TP_WS_NFSE.GINFES ? "ns4:" : "") + "Codigo"].InnerText;

                            if (sCodigoRetorno.Equals("E4") && iCountBuscaRet <= 20)
                            {
                                iCountBuscaRet++;
                            }
                            else
                            {
                                sMensagemErro = string.Format(sMensagemErro, node[(Acesso.tipoWsNfse == Acesso.TP_WS_NFSE.GINFES ? "ns4:" : "") + "Codigo"].InnerText,
                                                      "Esse RPS ainda não se encontra em nossa base de dados.",
                                                      node[(Acesso.tipoWsNfse == Acesso.TP_WS_NFSE.GINFES ? "ns4:" : "") + "Correcao"].InnerText, Environment.NewLine);
                                parar = true;
                            }
                        }
                    }
                    else if (xmlRet.GetElementsByTagName((Acesso.tipoWsNfse == Acesso.TP_WS_NFSE.GINFES ? "ns3:" : "") + "CompNfse").Count > 0)
                    {
                        this.sCodigoRetorno = "";
                        sMensagemErro = "";
                        bool bAlteraDupl = Convert.ToBoolean(Acesso.GRAVA_NUM_NF_DUPL);


                        for (int i = 0; i < xmlRet.GetElementsByTagName((Acesso.tipoWsNfse == Acesso.TP_WS_NFSE.GINFES ? "ns3:" : "") + "CompNfse").Count; i++)
                        {
                            #region Salva Arquivo por arquivo
                            string sPasta = Convert.ToDateTime(xmlRet.GetElementsByTagName((Acesso.tipoWsNfse == Acesso.TP_WS_NFSE.GINFES ? "ns4:" : "") + "InfNfse")[i][(Acesso.tipoWsNfse == Acesso.TP_WS_NFSE.GINFES ? "ns4:" : "") + "DataEmissao"].InnerText).ToString("MM/yy").Replace("/", "");
                            //Numero da nota no sefaz + numero da sequencia no sistema
                            string sNomeArquivo = sPasta + (xmlRet.GetElementsByTagName((Acesso.tipoWsNfse == Acesso.TP_WS_NFSE.GINFES ? "ns4:" : "") + "InfNfse")[i][(Acesso.tipoWsNfse == Acesso.TP_WS_NFSE.GINFES ? "ns4:" : "") + "Numero"].InnerText.PadLeft(6, '0'))
                                                 + (xmlRet.GetElementsByTagName((Acesso.tipoWsNfse == Acesso.TP_WS_NFSE.GINFES ? "ns4:" : "") + "IdentificacaoRps")[i][(Acesso.tipoWsNfse == Acesso.TP_WS_NFSE.GINFES ? "ns4:" : "") + "Numero"].InnerText.PadLeft(6, '0'));

                            XmlDocument xmlSaveNfes = new XmlDocument();
                            xmlSaveNfes.LoadXml(xmlRet.GetElementsByTagName((Acesso.tipoWsNfse == Acesso.TP_WS_NFSE.GINFES ? "ns4:" : "") + "Nfse")[i].InnerXml);
                            DirectoryInfo dPastaData = new DirectoryInfo(Pastas.ENVIADOS + "\\Servicos\\" + sPasta);
                            if (!dPastaData.Exists) { dPastaData.Create(); }
                            xmlSaveNfes.Save(Pastas.ENVIADOS + "\\Servicos\\" + sPasta + "\\" + sNomeArquivo + "-nfes.xml");
                            #endregion

                            objNfseRetorno = new TcInfNfse();
                            objNfseRetorno.Numero = xmlRet.GetElementsByTagName((Acesso.tipoWsNfse == Acesso.TP_WS_NFSE.GINFES ? "ns4:" : "") + "InfNfse")[i][(Acesso.tipoWsNfse == Acesso.TP_WS_NFSE.GINFES ? "ns4:" : "") + "Numero"].InnerText;
                            objNfseRetorno.CodigoVerificacao = xmlRet.GetElementsByTagName((Acesso.tipoWsNfse == Acesso.TP_WS_NFSE.GINFES ? "ns4:" : "") + "InfNfse")[i][(Acesso.tipoWsNfse == Acesso.TP_WS_NFSE.GINFES ? "ns4:" : "") + "CodigoVerificacao"].InnerText;

                            tcIdentificacaoRps objIdentRps = BuscatcIdentificacaoRps(xmlRet.GetElementsByTagName((Acesso.tipoWsNfse == Acesso.TP_WS_NFSE.GINFES ? "ns4:" : "") + "IdentificacaoRps")[i][(Acesso.tipoWsNfse == Acesso.TP_WS_NFSE.GINFES ? "ns4:" : "") + "Numero"].InnerText.PadLeft(6, '0'));


                            if (Acesso.NM_EMPRESA.Equals("LORENZON"))
                            {
                                AlteraDuplicataNumNFse(objIdentRps, xmlRet.GetElementsByTagName((Acesso.tipoWsNfse == Acesso.TP_WS_NFSE.GINFES ? "ns4:" : "") + "InfNfse")[i][(Acesso.tipoWsNfse == Acesso.TP_WS_NFSE.GINFES ? "ns4:" : "") + "Numero"].InnerText);
                            }

                            if (xmlRet.GetElementsByTagName((Acesso.tipoWsNfse == Acesso.TP_WS_NFSE.GINFES ? "ns4:" : "") + "SubstituicaoNfse")[i] != null)
                            {
                                objNfseRetorno.NfseSubstituida = xmlRet.GetElementsByTagName((Acesso.tipoWsNfse == Acesso.TP_WS_NFSE.GINFES ? "ns4:" : "") + "SubstituicaoNfse")[i][(Acesso.tipoWsNfse == Acesso.TP_WS_NFSE.GINFES ? "ns4:" : "") + "NfseSubstituidora"].InnerText;
                            }
                            objNfseRetorno.IdentificacaoRps = objIdentRps;
                            objListaNfseRetorno.Add(objNfseRetorno);

                        }
                        parar = true;
                    }

                    if (parar) break;
                }
                return sMensagemErro;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void AlteraDuplicataNumNFse(tcIdentificacaoRps objIdentRps, string sNotaFis)
        {
            try
            {
                objdaoBuscaDados.AlteraDuplicata(sNotaFis, objIdentRps.Nfseq);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }






        public tcIdentificacaoRps BuscatcIdentificacaoRps(string sNotaFis)
        {

            try
            {
                DataTable dt = objdaoBuscaDados.BuscaRps(sNotaFis);
                tcIdentificacaoRps objtcIdentificacaoRps = new tcIdentificacaoRps();

                foreach (DataRow dr in dt.Rows)
                {
                    objtcIdentificacaoRps.Nfseq = dr["cd_nfseq"].ToString();
                    objtcIdentificacaoRps.Numero = dr["cd_notafis"].ToString();
                    objtcIdentificacaoRps.Serie = dr["cd_serie"].ToString();
                }

                return objtcIdentificacaoRps;

            }
            catch (Exception)
            {
                throw new Exception("O Grupo de faturamento da nota " + sNotaFis + " deve ser igual ao Grupo de faturamento parametrizado no Config.");
            }

        }

        private string BuscaRetornoWebService(tcIdentificacaoPrestador Prestador)
        {
            try
            {

                if (Acesso.tipoWsNfse == Acesso.TP_WS_NFSE.GINFES)
                {
                    if (Acesso.TP_AMB_SERV == 2)
                    {
                        WebService.Itu_servicos_Homologacao.ServiceGinfesImplService objtrans = new WebService.Itu_servicos_Homologacao.ServiceGinfesImplService();
                        objtrans.ClientCertificates.Add(Acesso.cert_NFs);
                        objtrans.Timeout = 60000;
                        return objtrans.ConsultarLoteRpsV3(NfeCabecMsg(), MontaXmlConsultaLote(Prestador));

                    }
                    else if (Acesso.TP_AMB_SERV == 1)
                    {
                        WebService.Itu_servicos_Producao.ServiceGinfesImplService objtrans = new WebService.Itu_servicos_Producao.ServiceGinfesImplService();
                        objtrans.ClientCertificates.Add(Acesso.cert_NFs);
                        objtrans.Timeout = 60000;
                        return objtrans.ConsultarLoteRpsV3(NfeCabecMsg(), MontaXmlConsultaLote(Prestador));
                    }
                    else
                    {
                        throw new Exception("Cadastro de Empresa não configurado para enviar NFe-serviço");
                    }
                }
                else
                {
                    WebService.riodasostras_Producao.Nfse nfse = new WebService.riodasostras_Producao.Nfse();
                    nfse.ClientCertificates.Add(Acesso.cert_NFs);
                    nfse.Timeout = 60000;
                    return nfse.ConsultarLoteRps(MontaXmlConsultaLote2(Prestador));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private string MontaXmlConsultaLote(tcIdentificacaoPrestador objPrestador)
        {
            XmlSchemaCollection myschema = new XmlSchemaCollection();
            XmlValidatingReader reader;
            try
            {
                XNamespace tipos = "http://www.ginfes.com.br/tipos_v03.xsd";
                XNamespace pf = "http://www.ginfes.com.br/servico_consultar_lote_rps_envio_v03.xsd";
                XContainer conPrestador = null;
                XContainer conProtocolo = null;

                XContainer conConsultarLoteRpsEnvio = (new XElement(pf + "ConsultarLoteRpsEnvio", new XAttribute("xmlns", "http://www.ginfes.com.br/servico_consultar_lote_rps_envio_v03.xsd"),
                                                                        new XAttribute(XNamespace.Xmlns + "tipos", "http://www.ginfes.com.br/tipos_v03.xsd")));

                conPrestador = (new XElement(pf + "Prestador",
                    new XElement(tipos + "Cnpj", objPrestador.Cnpj),
                                                                     ((objPrestador.InscricaoMunicipal != "") ? new XElement(tipos + "InscricaoMunicipal", objPrestador.InscricaoMunicipal) : null)));

                conProtocolo = new XElement(pf + "Protocolo", Protocolo);


                conConsultarLoteRpsEnvio.Add(conPrestador);
                conConsultarLoteRpsEnvio.Add(conProtocolo);
                belAssinaXml Assinatura = new belAssinaXml();
                string sArquivo = Assinatura.ConfigurarArquivo(conConsultarLoteRpsEnvio.ToString(), "Protocolo", Acesso.cert_NFs);



                XmlParserContext context = new XmlParserContext(null, null, "", XmlSpace.None);

                reader = new XmlValidatingReader(sArquivo, XmlNodeType.Element, context);

                myschema.Add("http://www.ginfes.com.br/servico_consultar_lote_rps_envio_v03.xsd", Pastas.SCHEMA_NFSE + "\\servico_consultar_lote_rps_envio_v03.xsd");

                reader.ValidationType = ValidationType.Schema;

                reader.Schemas.Add(myschema);

                while (reader.Read())
                { }


                return sArquivo;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private string MontaXmlConsultaLote2(tcIdentificacaoPrestador objPrestador)
        {
            try
            {
                XNamespace pf = "http://www.abrasf.org.br/ABRASF/arquivos/nfse.xsd";
                XContainer conPrestador = null;
                XContainer conProtocolo = null;

                XContainer conConsultarLoteRpsEnvio = (new XElement(pf + "ConsultarLoteRpsEnvio", new XAttribute("xmlns", "http://www.abrasf.org.br/ABRASF/arquivos/nfse.xsd")));

                conPrestador = (new XElement(pf + "Prestador",
                    new XElement(pf + "Cnpj", objPrestador.Cnpj),
                                                                     ((objPrestador.InscricaoMunicipal != "") ? new XElement(pf + "InscricaoMunicipal", objPrestador.InscricaoMunicipal) : null)));
                conProtocolo = new XElement(pf + "Protocolo", Protocolo);


                conConsultarLoteRpsEnvio.Add(conPrestador);
                conConsultarLoteRpsEnvio.Add(conProtocolo);
                string sPathLote = Pastas.PROTOCOLOS + "\\Servicos\\" + "Prot_ConsultaLote_Serv_" + Protocolo + ".xml";
                StreamWriter sw = new StreamWriter(sPathLote);
                sw.Write(conConsultarLoteRpsEnvio.ToString());
                sw.Close();

                try
                {
                    belValidaXml.ValidarXml("http://www.nfe.com.br/WSNacional/XSD/1/nfse_municipal_v01.xsd", Pastas.SCHEMA_NFSE + "\\TIPLAN\\nfse_municipal_v01.xsd", sPathLote);
                }
                catch (XmlException x)
                {
                    File.Delete(sPathLote);
                    throw new Exception(x.Message);
                }
                catch (XmlSchemaException x)
                {
                    File.Delete(sPathLote);
                    throw new Exception(x.Message);
                }

                //XmlParserContext context = new XmlParserContext(null, null, "", XmlSpace.None);

                //reader = new XmlValidatingReader(sArquivo, XmlNodeType.Element, context);

                //myschema.Add("http://www.ginfes.com.br/servico_consultar_lote_rps_envio_v03.xsd", Pastas.SCHEMA_NFSE + "\\servico_consultar_lote_rps_envio_v03.xsd");

                //reader.ValidationType = ValidationType.Schema;

                //reader.Schemas.Add(myschema);

                //while (reader.Read())
                //{ }


                return conConsultarLoteRpsEnvio.ToString();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private string NfeCabecMsg()
        {
            try
            {
                XNamespace ns2 = "http://www.ginfes.com.br/cabecalho_v03.xsd";
                XContainer xdoc = (new XElement(ns2 + "cabecalho", new XAttribute("versao", "3"), new XAttribute(XNamespace.Xmlns + "ns2", "http://www.ginfes.com.br/cabecalho_v03.xsd"),
                                              new XElement("versaoDados", "3")));


                //<ns2:cabecalho versao="3" xmlns:ns2="http://www.ginfes.com.br/cabecalho_v03.xsd">
                //    <versaoDados>3</versaoDados>
                //</ns2:cabecalho>

                XmlSchemaCollection myschema = new XmlSchemaCollection();
                XmlValidatingReader reader;


                XmlParserContext context = new XmlParserContext(null, null, "", XmlSpace.None);

                reader = new XmlValidatingReader(xdoc.ToString(), XmlNodeType.Element, context);

                myschema.Add("http://www.ginfes.com.br/cabecalho_v03.xsd", Pastas.SCHEMA_NFSE + "\\cabecalho_v03.xsd");

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

        public string MontaMsgDeRetornoParaCliente()
        {
            try
            {
                string sMsgNota = "Nota nº {0}{1}";
                string sMsgFinal = "Notas de Serviço Enviadas com Sucesso: " + Environment.NewLine
                    + "______________________________________"
                    + Environment.NewLine + Environment.NewLine;

                for (int i = 0; i < objListaNfseRetorno.Count; i++)
                {
                    sMsgFinal += string.Format(sMsgNota,
                                                objListaNfseRetorno[i].Numero.ToString()
                                                , Environment.NewLine);
                }
                return sMsgFinal;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public void GravaRecibo(string sReciboProt, bel.NFes.tcLoteRps objLoteRpsAlter)
        {
            try
            {
                for (int i = 0; i < objLoteRpsAlter.Rps.Count; i++)
                {
                    SalvaRecibo(sReciboProt, objLoteRpsAlter.Rps[i].InfRps.IdentificacaoRps.Nfseq);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AlteraStatusDaNota(List<TcInfNfse> objListaNFse)
        {
            try
            {
                for (int i = 0; i < objListaNFse.Count; i++)
                {
                    SalvaStatusDaNota(objListaNFse[i].Numero, objListaNFse[i].CodigoVerificacao, objListaNFse[i].IdentificacaoRps.Nfseq);

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void VerificaNotasParaCancelar(List<TcInfNfse> objListaNFse)
        {
            try
            {
                for (int i = 0; i < objListaNFse.Count; i++)
                {
                    if (objListaNFse[i].NfseSubstituida != "")
                    {
                        SalvaNotasParaCancelar(objListaNFse[i].NfseSubstituida);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void LimpaRecibo(tcLoteRps objListaLote)
        {
            StringBuilder sSql = new StringBuilder();
            try
            {
                for (int i = 0; i < objListaLote.Rps.Count; i++)
                {
                    ApagaRecibo(objLoteRpsAlter.Rps[i].InfRps.IdentificacaoRps.Nfseq);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void LimpaRecibo()
        {
            StringBuilder sSql = new StringBuilder();
            List<string> objListaNfseq = BuscaListaDeNotasLote();
            try
            {
                for (int i = 0; i < objListaNfseq.Count; i++)
                {
                    ApagaRecibo(objListaNfseq[i]);

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public string BuscaNumProtocolo(string sSequencia)
        {
            try
            {
                this.sReciboProt = BuscaProtocolo(sSequencia);
                return sReciboProt;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        private List<string> BuscaListaDeNotasLote()
        {
            try
            {
                List<string> objListaSequencias = BuscaListaLote(this.sReciboProt);

                return objListaSequencias;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
