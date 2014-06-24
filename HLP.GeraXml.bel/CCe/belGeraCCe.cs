using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HLP.GeraXml.dao.CCe;
using HLP.GeraXml.dao;
using HLP.GeraXml.Comum.Static;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Linq;
using System.IO;
using System.Data;
using HLP.GeraXml.bel.CTe;
using HLP.GeraXml.bel.CTe.Evento;
using System.Xml.Serialization;
using HLP.GeraXml.Comum;

namespace HLP.GeraXml.bel.CCe
{
    public class belGeraCCe : daoGeraCCe
    {
        private string _VERSAO = "1.00";
        private string _TPEVENTO = "110110";

        public string sXMLfinal = "";
        private List<belPesquisaCCe> objlItensPesquisa = new List<belPesquisaCCe>();
        /// <summary>
        /// Evento para NFe
        /// </summary>
        public belEnvEvento objEnvEvento = new belEnvEvento();

        /// <summary>
        /// Evento para CTe
        /// </summary>
        public TEvento objEvCCeCTe = new TEvento();


        /// <summary>
        /// chave, xml
        /// </summary>
        public Dictionary<string, string> objXmlsSeparados = new Dictionary<string, string>();
        private struct Motivos
        {
            public string chave { get; set; }
            public string xMotivo { get; set; }
            public string Status { get; set; }

        }


        public belGeraCCe()
        {

        }
        public belGeraCCe(List<belPesquisaCCe> _objlItensPesquisa)
        {
            objlItensPesquisa = _objlItensPesquisa;
            if (Acesso.NM_RAMO != Acesso.BancoDados.TRANSPORTE)
            {
                foreach (belPesquisaCCe obj in _objlItensPesquisa)
                {
                    CarregaItensEventoCartaCorrecao(obj);
                }
            }
            else
            {
                CarregaItensEventoCartaCorrecao(objlItensPesquisa.FirstOrDefault());
            }
        }



        private void CarregaItensEventoCartaCorrecao(belPesquisaCCe objbelPesquisa)
        {
            try
            {
                if (Acesso.NM_RAMO != Acesso.BancoDados.TRANSPORTE)
                {
                    objEnvEvento = new belEnvEvento();
                    objEnvEvento.versao = this._VERSAO;
                    objEnvEvento.id = objbelPesquisa.CD_NRLANC;
                    belEvento objEvento = new belEvento();
                    objEvento.versao = _VERSAO;
                    objEvento.infEvento = new _infEvento();
                    objEvento.infEvento.CNPJ = objbelPesquisa.CNPJ;
                    objEvento.infEvento.CPF = objbelPesquisa.CPF;
                    objEvento.infEvento.dhEvento = daoUtil.GetDateServidor().ToString("yyyy-MM-ddTHH:mm:ss" + Acesso.FUSO);
                    objEvento.infEvento.verEvento = _VERSAO;
                    objEvento.infEvento.tpAmb = Acesso.TP_AMB;
                    objEvento.infEvento.chNFe = objbelPesquisa.CHNFE;
                    objEvento.infEvento.cOrgao = Acesso.cUF.ToString();
                    objEvento.infEvento.detEvento = new _detEvento
                    {
                        versao = _VERSAO
                    };
                    objEvento.infEvento.detEvento.xCorrecao = BuscaCorrecoes(objbelPesquisa.CD_NRLANC);
                    objEvento.infEvento.nSeqEvento = objbelPesquisa.QT_ENVIO + 1;
                    objEvento.idLote = "ID" + objEvento.infEvento.tpEvento + objEvento.infEvento.chNFe + objEvento.infEvento.nSeqEvento.ToString().PadLeft(2, '0');
                    objEnvEvento.evento.Add(objEvento);
                }
                else
                {

                    objEvCCeCTe = new TEvento();

                    objEvCCeCTe.versao = Acesso.versaoCTe;
                    objEvCCeCTe.infEvento = new  TEventoInfEvento();
                    objEvCCeCTe.infEvento.tpEvento = "110110";
                    objEvCCeCTe.infEvento.nSeqEvento = (objbelPesquisa.QT_ENVIO + 1).ToString();// numero de evento
                    objEvCCeCTe.infEvento.Id = "ID" + objEvCCeCTe.infEvento.tpEvento + objlItensPesquisa.FirstOrDefault().CHNFE + objEvCCeCTe.infEvento.nSeqEvento.ToString().PadLeft(2, '0');
                    //objEvCCeCTe.infEvento.Id = "ID" + objlItensPesquisa.FirstOrDefault().CHNFE;                   
                    objEvCCeCTe.infEvento.cOrgao = Convert.ToByte(Acesso.cUF);
                    objEvCCeCTe.infEvento.tpAmb = Acesso.TP_AMB == 1 ? TAmb.Item1 : TAmb.Item2;
                    objEvCCeCTe.infEvento.CNPJ = Util.RetiraCaracterCNPJ(Acesso.CNPJ_EMPRESA);
                    objEvCCeCTe.infEvento.chCTe = objbelPesquisa.CHNFE;
                    objEvCCeCTe.infEvento.dhEvento = daoUtil.GetDateServidor().ToString("yyyy-MM-ddTHH:mm:ss");
                    objEvCCeCTe.infEvento.detEvento = new TEventoInfEventoDetEvento();
                    objEvCCeCTe.infEvento.detEvento.versaoEvento = Acesso.versaoCTe;

                    evCCeCTe objEvCanc = new evCCeCTe();
                    objEvCanc.descEvento = evCCeCTeDescEvento.CartadeCorrecao;
                    objEvCanc.infCorrecao = new List<evCCeCTeInfCorrecao>();
                    objEvCanc.CD_NRLANC = objbelPesquisa.CD_NRLANC;
                    foreach (DataRow item in BuscaCorrecoesCTe(objbelPesquisa.CD_NRLANC).Rows)
                    {
                        objEvCanc.infCorrecao.Add(new evCCeCTeInfCorrecao
                        {
                            grupoAlterado = item["grupoAlterado"].ToString(),
                            campoAlterado = item["campoAlterado"].ToString(),
                            valorAlterado = item["valorAlterado"].ToString(),
                            nroItemAlterado = item["nroItemAlterado"].ToString(),
                        });
                    }
                    objEvCanc.xCondUso = evCCeCTeXCondUso.ACartadeCorreçãoédisciplinadapeloArt58BdoCONVÊNIOSINIEF0689FicapermitidaautilizaçãodecartadecorreçãopararegularizaçãodeerroocorridonaemissãodedocumentosfiscaisrelativosàprestaçãodeserviçodetransportedesdequeoerronãoestejarelacionadocomIasvariáveisquedeterminamovalordoimpostotaiscomobasedecálculoalíquotadiferençadepreçoquantidadevalordaprestaçãoIIacorreçãodedadoscadastraisqueimpliquemudançadoemitentetomadorremetenteoudodestinatárioIIIadatadeemissãooudesaída;
                    string xFile = Pastas.CCe + "\\" + objEvCanc.CD_NRLANC + "_prevalida.xml";
                    SerializeClassToXml.SerializeClasse<evCCeCTe>(objEvCanc, xFile);
                    XmlDocument xml = new XmlDocument();
                    xml.Load(xFile);
                    objEvCCeCTe.infEvento.detEvento.Any = (System.Xml.XmlElement)xml.DocumentElement;


                    XmlSerializer xs = new XmlSerializer(typeof(TEvento));
                    MemoryStream memory = new MemoryStream();
                    XmlTextWriter xmltext = new XmlTextWriter(memory, Encoding.UTF8);
                    xs.Serialize(xmltext, objEvCCeCTe);
                    UTF8Encoding encoding = new UTF8Encoding();
                    this.sXMLfinal = encoding.GetString(memory.ToArray());
                    this.sXMLfinal = this.sXMLfinal.Substring(1);

                    belAssinaXml Assinatura = new belAssinaXml();
                    this.sXMLfinal = Assinatura.ConfigurarArquivo(this.sXMLfinal, "infEvento", Acesso.cert_CTe);

                    xml = new XmlDocument();
                    xml.LoadXml(this.sXMLfinal);
                    string sPath = Pastas.PROTOCOLOS + "\\" + objbelPesquisa.CHNFE + "_ped-cce.xml";
                    if (File.Exists(sPath))
                    {
                        File.Delete(sPath);
                    }
                    xml.Save(sPath);
                    try
                    {
                        belValidaXml.ValidarXml("http://www.portalfiscal.inf.br/cte", Pastas.SCHEMA_CTE + "\\eventoCTe_v2.00.xsd", sPath);
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void GeraXmlEnvio()
        {
            try
            {
                belAssinaXml Assinatura = new belAssinaXml();
                XDocument xdoc = new XDocument();
                XNamespace pf = "http://www.portalfiscal.inf.br/nfe";
                XContainer xContEnvEvento = new XElement(pf + "envEvento", new XAttribute("xmlns", "http://www.portalfiscal.inf.br/nfe"),
                                                                    new XAttribute("versao", objEnvEvento.versao),
                                                                    new XElement(pf + "idLote", objEnvEvento.id));

                //List<string> ListaEventos = new List<string>();
                objXmlsSeparados = new Dictionary<string, string>();
                foreach (var obj in objEnvEvento.evento)
                {
                    XContainer xConEvento = new XElement(pf + "evento", new XAttribute("xmlns", "http://www.portalfiscal.inf.br/nfe"),
                                                                   new XAttribute("versao", obj.versao),
                                                                   new XElement(pf + "infEvento", new XAttribute("Id", obj.idLote),
                                                                       new XElement(pf + "cOrgao", obj.infEvento.cOrgao),
                                                                       new XElement(pf + "tpAmb", obj.infEvento.tpAmb),
                                                                       new XElement(pf + (obj.infEvento.CNPJ != "" ? "CNPJ" : "CPF"), (obj.infEvento.CNPJ != "" ? obj.infEvento.CNPJ : obj.infEvento.CPF)),
                                                                       new XElement(pf + "chNFe", obj.infEvento.chNFe),
                                                                       new XElement(pf + "dhEvento", obj.infEvento.dhEvento),//-02:00
                                                                       new XElement(pf + "tpEvento", obj.infEvento.tpEvento),
                                                                       new XElement(pf + "nSeqEvento", obj.infEvento.nSeqEvento),
                                                                       new XElement(pf + "verEvento", obj.infEvento.verEvento),
                                                                       new XElement(pf + "detEvento", new XAttribute("versao", obj.versao),
                                                                                    new XElement(pf + "descEvento", obj.infEvento.detEvento.descEvento),
                                                                                    new XElement(pf + "xCorrecao", obj.infEvento.detEvento.xCorrecao),
                                                                                    new XElement(pf + "xCondUso", obj.infEvento.detEvento.xCondUso))));


                    objXmlsSeparados.Add(obj.infEvento.chNFe, Assinatura.ConfigurarArquivo(xConEvento.ToString(), "infEvento", Acesso.cert_NFe));
                }


                string sEventos = "";
                foreach (KeyValuePair<string, string> sInfEvento in objXmlsSeparados)
                {
                    sEventos += sInfEvento.Value;
                }

                sXMLfinal = "<?xml version=\"1.0\" encoding=\"utf-8\"?><envEvento xmlns=\"http://www.portalfiscal.inf.br/nfe\" versao=\"1.00\"><idLote>" + objEnvEvento.id.ToString()
                                + "</idLote>" + sEventos + "</envEvento>";

                StreamWriter sr = new StreamWriter(Pastas.CCe + "\\" + objEnvEvento.evento.FirstOrDefault().idLote + "_prevalida.xml");
                sr.Write(sXMLfinal);
                sr.Close();


                #region Valida_Xml


                XmlValidatingReader reader;
                try
                {
                    XmlSchemaCollection myschema = new XmlSchemaCollection();
                    myschema.Add("http://www.portalfiscal.inf.br/nfe", Pastas.SCHEMA_CCE + "\\envCCe_v1.00.xsd");

                    XmlParserContext context = new XmlParserContext(null, null, "", XmlSpace.None);
                    reader = new XmlValidatingReader(sXMLfinal, XmlNodeType.Element, context);
                    reader.ValidationType = ValidationType.Schema;
                    reader.Schemas.Add(myschema);
                    while (reader.Read())
                    {

                    }
                }
                catch (XmlException x)
                {
                    throw new Exception(x.Message);
                }
                catch (XmlSchemaException x)
                {
                    throw new Exception(x.Message);
                }
                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public string AnalisaRetornoEnvio(string sRet)
        {
            try
            {
                string sCabec = "";
                string sDetalhes = "";
                XElement xDoc = XElement.Parse(sRet, LoadOptions.None);
                List<Motivos> objListMotivos = new List<Motivos>();

                foreach (XElement item in xDoc.Descendants())
                {
                    switch (item.Name.LocalName.ToString())
                    {
                        case "xMotivo":
                            {
                                if (sCabec == "")
                                {
                                    sCabec = string.Format("{0} {1}{1}", item.Value.ToString(), Environment.NewLine);
                                }
                            }
                            break;
                    }
                    if (item.Name.LocalName.ToString().Equals("retEvento"))
                    {
                        Motivos objMotivo = new Motivos();
                        foreach (XElement st in item.Descendants())
                        {
                            switch (st.Name.LocalName.ToString())
                            {
                                case "xMotivo": { objMotivo.xMotivo = st.Value.ToString(); }
                                    break;
                                case "chNFe": { objMotivo.chave = st.Value.ToString(); }
                                    break;
                                case "cStat": { objMotivo.Status = st.Value.ToString(); }
                                    break;
                            }
                        }
                        objListMotivos.Add(objMotivo);

                    }
                }

                foreach (Motivos mot in objListMotivos)
                {
                    string sNota = objlItensPesquisa.FirstOrDefault(c => c.CHNFE == mot.chave).CD_NOTAFIS;
                    int iQT_ENVIO = objlItensPesquisa.FirstOrDefault(c => c.CHNFE == mot.chave).QT_ENVIO;
                    string sNR_LANC = objlItensPesquisa.FirstOrDefault(c => c.CHNFE == mot.chave).CD_NRLANC;
                    if (mot.Status == "135")
                    {
                        AtualizaContadorCCe(sNR_LANC, iQT_ENVIO);
                        // SaveXmlPastaCCe(mot.chave);
                        SalvaRetornoCCe(mot.chave, sRet);

                    }
                    sDetalhes += string.Format("CCe da NFe: {0} - '{1}'{2}", sNota, mot.xMotivo, Environment.NewLine);
                }

                return sCabec + sDetalhes;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public string AnalisaRetornoEnvioCCeCTe(HLP.GeraXml.bel.CTe.Evento.TRetEvento ret, string sNotaFis)
        {
            try
            {
                //string sNota = "";
                if (ret.infEvento.cStat == "135")
                {
                    //sNota = objlItensPesquisa.FirstOrDefault(c => c.CHNFE == ret.infEvento.chCTe).CD_NOTAFIS;
                    int iQT_ENVIO = objlItensPesquisa.FirstOrDefault(c => c.CHNFE == ret.infEvento.chCTe).QT_ENVIO;
                    string sNR_LANC = objlItensPesquisa.FirstOrDefault(c => c.CHNFE == ret.infEvento.chCTe).CD_NRLANC;
                    AtualizaContadorCCe(sNR_LANC, iQT_ENVIO);
                    string sPath = Pastas.CCe + "\\" + ret.infEvento.chCTe.Substring(2, 4);
                    DirectoryInfo dPastaData = new DirectoryInfo(sPath);
                    if (!dPastaData.Exists) { dPastaData.Create(); }
                    sPath = sPath + "\\35140614920065000160570010000011721000029623" + "_ret-cce.xml";
                    SerializeClassToXml.SerializeClasse<HLP.GeraXml.bel.CTe.Evento.TRetEvento>(ret, sPath);
                }

                return string.Format("CCe do CTe: {0} - '{1}'{2}", sNotaFis, ret.infEvento.xMotivo, Environment.NewLine);

            }
            catch (Exception)
            {
                throw;
            }
        }

        private void SalvaRetornoCCe(string sChave, string sRet)
        {
            try
            {
                DirectoryInfo dPastaData = new DirectoryInfo(Pastas.CCe + "\\" + sChave.Substring(2, 4));
                if (!dPastaData.Exists) { dPastaData.Create(); }
                XDocument xml = XDocument.Parse("<?xml version=\"1.0\" encoding=\"utf-8\"?>" + sRet, LoadOptions.PreserveWhitespace);
                xml.Save(Pastas.CCe + "\\" + sChave.Substring(2, 4) + "\\" + sChave + "-cce.xml");
            }
            catch (Exception ex)
            {
                throw new Exception("O Caminho para salvar os arquivos Xmls de CCe não foi configurado!"); ;
            }
        }

        private void SaveXmlPastaCCe(string sChave)
        {
            try
            {
                DirectoryInfo dPastaData = new DirectoryInfo(Pastas.CCe + "\\" + sChave.Substring(2, 4));
                if (!dPastaData.Exists) { dPastaData.Create(); }
                XDocument xml = XDocument.Parse("<?xml version=\"1.0\" encoding=\"utf-8\"?>" + objXmlsSeparados.First(c => c.Key == sChave).Value, LoadOptions.PreserveWhitespace);
                xml.Save(Pastas.CCe + "\\" + sChave.Substring(2, 4) + "\\" + sChave + "-cce.xml");
            }
            catch (Exception ex)
            {
                throw new Exception("O Caminho para salvar os arquivos Xmls de CCe não foi configurado!"); ;
            }
        }

        public string TransmiteLoteCCe(string sXmlLote)
        {
            try
            {
                string sRet = "";
                if (Acesso.TP_EMIS == 1)
                {
                    switch (Acesso.xUFtoWS)
                    {
                        case "SP":
                            {
                                if (Acesso.TP_AMB == 2)
                                {
                                    #region sp_homologacao
                                    HLP.GeraXml.WebService.v2_Homologacao_NFeRecepcaoEvento_SP.nfeCabecMsg cabec = new HLP.GeraXml.WebService.v2_Homologacao_NFeRecepcaoEvento_SP.nfeCabecMsg();
                                    HLP.GeraXml.WebService.v2_Homologacao_NFeRecepcaoEvento_SP.RecepcaoEvento ws2 = new HLP.GeraXml.WebService.v2_Homologacao_NFeRecepcaoEvento_SP.RecepcaoEvento();

                                    cabec.cUF = Acesso.cUF.ToString();
                                    cabec.versaoDados = "1.00";
                                    ws2.nfeCabecMsgValue = cabec;
                                    ws2.ClientCertificates.Add(Acesso.cert_NFe);

                                    XmlDocument _xmlxelem = new XmlDocument();
                                    _xmlxelem.PreserveWhitespace = true;
                                    _xmlxelem.LoadXml(sXmlLote);

                                    XmlNode xNelem = null;
                                    xNelem = _xmlxelem.DocumentElement;

                                    sRet = ws2.nfeRecepcaoEvento(xNelem).OuterXml;
                                    #endregion
                                }
                                else
                                {
                                    #region sp_producao
                                    HLP.GeraXml.WebService.v2_Producao_NFeRecepcaoEvento_SP.nfeCabecMsg cabec = new HLP.GeraXml.WebService.v2_Producao_NFeRecepcaoEvento_SP.nfeCabecMsg();
                                    HLP.GeraXml.WebService.v2_Producao_NFeRecepcaoEvento_SP.RecepcaoEvento ws2 = new HLP.GeraXml.WebService.v2_Producao_NFeRecepcaoEvento_SP.RecepcaoEvento();

                                    cabec.cUF = Acesso.cUF.ToString();
                                    cabec.versaoDados = "1.00";
                                    ws2.nfeCabecMsgValue = cabec;
                                    ws2.ClientCertificates.Add(Acesso.cert_NFe);

                                    XmlDocument _xmlxelem = new XmlDocument();
                                    _xmlxelem.PreserveWhitespace = true;
                                    _xmlxelem.LoadXml(sXmlLote);

                                    XmlNode xNelem = null;
                                    xNelem = _xmlxelem.DocumentElement;

                                    sRet = ws2.nfeRecepcaoEvento(xNelem).OuterXml;

                                    #endregion
                                }
                            }
                            break;
                        case "RS":
                            {
                                if (Acesso.TP_AMB == 2)
                                {
                                    #region RS_homologacao

                                    HLP.GeraXml.WebService.v2_Homologacao_NFeRecepcaoEvento_RS.nfeCabecMsg cabec = new HLP.GeraXml.WebService.v2_Homologacao_NFeRecepcaoEvento_RS.nfeCabecMsg();
                                    HLP.GeraXml.WebService.v2_Homologacao_NFeRecepcaoEvento_RS.RecepcaoEvento ws2 = new HLP.GeraXml.WebService.v2_Homologacao_NFeRecepcaoEvento_RS.RecepcaoEvento();

                                    cabec.cUF = Acesso.cUF.ToString();
                                    cabec.versaoDados = "1.00";
                                    ws2.nfeCabecMsgValue = cabec;
                                    ws2.ClientCertificates.Add(Acesso.cert_NFe);

                                    XmlDocument _xmlxelem = new XmlDocument();
                                    _xmlxelem.PreserveWhitespace = true;
                                    _xmlxelem.LoadXml(sXmlLote);

                                    XmlNode xNelem = null;
                                    xNelem = _xmlxelem.DocumentElement;

                                    sRet = ws2.nfeRecepcaoEvento(xNelem).OuterXml;
                                    #endregion
                                }
                                else
                                {
                                    #region RS_producao
                                    HLP.GeraXml.WebService.v2_Producao_NFeRecepcaoEvento_RS.nfeCabecMsg cabec = new HLP.GeraXml.WebService.v2_Producao_NFeRecepcaoEvento_RS.nfeCabecMsg();
                                    HLP.GeraXml.WebService.v2_Producao_NFeRecepcaoEvento_RS.RecepcaoEvento ws2 = new HLP.GeraXml.WebService.v2_Producao_NFeRecepcaoEvento_RS.RecepcaoEvento();

                                    cabec.cUF = Acesso.cUF.ToString();
                                    cabec.versaoDados = "1.00";
                                    ws2.nfeCabecMsgValue = cabec;
                                    ws2.ClientCertificates.Add(Acesso.cert_NFe);

                                    XmlDocument _xmlxelem = new XmlDocument();
                                    _xmlxelem.PreserveWhitespace = true;
                                    _xmlxelem.LoadXml(sXmlLote);

                                    XmlNode xNelem = null;
                                    xNelem = _xmlxelem.DocumentElement;

                                    sRet = ws2.nfeRecepcaoEvento(xNelem).OuterXml;
                                    #endregion
                                }
                            }
                            break;
                        case "MS":
                            {
                                if (Acesso.TP_AMB == 2)
                                {
                                    #region MS_homologacao
                                    HLP.GeraXml.WebService.v2_Homologacao_NFeRetRecepcao_MS.nfeCabecMsg cabec = new HLP.GeraXml.WebService.v2_Homologacao_NFeRetRecepcao_MS.nfeCabecMsg();
                                    HLP.GeraXml.WebService.v2_Homologacao_NFeRetRecepcao_MS.NfeRetRecepcao2 ws2 = new HLP.GeraXml.WebService.v2_Homologacao_NFeRetRecepcao_MS.NfeRetRecepcao2();

                                    cabec.cUF = Acesso.cUF.ToString();
                                    cabec.versaoDados = "1.00";
                                    ws2.nfeCabecMsgValue = cabec;
                                    ws2.ClientCertificates.Add(Acesso.cert_NFe);

                                    XmlDocument _xmlxelem = new XmlDocument();
                                    _xmlxelem.PreserveWhitespace = true;
                                    _xmlxelem.LoadXml(sXmlLote);

                                    XmlNode xNelem = null;
                                    xNelem = _xmlxelem.DocumentElement;

                                    sRet = ws2.nfeRetRecepcao2(xNelem).OuterXml;
                                    # endregion
                                }
                                else
                                {
                                    #region MS_producao
                                    HLP.GeraXml.WebService.v2_Producao_NFeRecepcaoEvento_MS.nfeCabecMsg cabec = new HLP.GeraXml.WebService.v2_Producao_NFeRecepcaoEvento_MS.nfeCabecMsg();
                                    HLP.GeraXml.WebService.v2_Producao_NFeRecepcaoEvento_MS.RecepcaoEvento ws2 = new HLP.GeraXml.WebService.v2_Producao_NFeRecepcaoEvento_MS.RecepcaoEvento();

                                    cabec.cUF = Acesso.cUF.ToString();
                                    cabec.versaoDados = "1.00";
                                    ws2.nfeCabecMsgValue = cabec;
                                    ws2.ClientCertificates.Add(Acesso.cert_NFe);

                                    XmlDocument _xmlxelem = new XmlDocument();
                                    _xmlxelem.PreserveWhitespace = true;
                                    _xmlxelem.LoadXml(sXmlLote);

                                    XmlNode xNelem = null;
                                    xNelem = _xmlxelem.DocumentElement;

                                    sRet = ws2.nfeRecepcaoEvento(xNelem).OuterXml;
                                    #endregion
                                }

                            }
                            break;
                        case "SVRS":
                            {
                                if (Acesso.TP_AMB == 2)
                                {
                                    #region MS_homologacao
                                    HLP.GeraXml.WebService.V2_Homologacao_RetRecepcao_SVRS.nfeCabecMsg cabec = new HLP.GeraXml.WebService.V2_Homologacao_RetRecepcao_SVRS.nfeCabecMsg();
                                    HLP.GeraXml.WebService.V2_Homologacao_RetRecepcao_SVRS.NfeRetRecepcao2 ws2 = new HLP.GeraXml.WebService.V2_Homologacao_RetRecepcao_SVRS.NfeRetRecepcao2();

                                    cabec.cUF = Acesso.cUF.ToString();
                                    cabec.versaoDados = "1.00";
                                    ws2.nfeCabecMsgValue = cabec;
                                    ws2.ClientCertificates.Add(Acesso.cert_NFe);

                                    XmlDocument _xmlxelem = new XmlDocument();
                                    _xmlxelem.PreserveWhitespace = true;
                                    _xmlxelem.LoadXml(sXmlLote);

                                    XmlNode xNelem = null;
                                    xNelem = _xmlxelem.DocumentElement;

                                    sRet = ws2.nfeRetRecepcao2(xNelem).OuterXml;
                                    # endregion
                                }
                                else
                                {
                                    #region MS_producao
                                    HLP.GeraXml.WebService.V2_Producao_RecepcaoEvento_SVRS.nfeCabecMsg cabec = new HLP.GeraXml.WebService.V2_Producao_RecepcaoEvento_SVRS.nfeCabecMsg();
                                    HLP.GeraXml.WebService.V2_Producao_RecepcaoEvento_SVRS.RecepcaoEvento ws2 = new HLP.GeraXml.WebService.V2_Producao_RecepcaoEvento_SVRS.RecepcaoEvento();

                                    cabec.cUF = Acesso.cUF.ToString();
                                    cabec.versaoDados = "1.00";
                                    ws2.nfeCabecMsgValue = cabec;
                                    ws2.ClientCertificates.Add(Acesso.cert_NFe);

                                    XmlDocument _xmlxelem = new XmlDocument();
                                    _xmlxelem.PreserveWhitespace = true;
                                    _xmlxelem.LoadXml(sXmlLote);

                                    XmlNode xNelem = null;
                                    xNelem = _xmlxelem.DocumentElement;

                                    sRet = ws2.nfeRecepcaoEvento(xNelem).OuterXml;
                                    #endregion
                                }
                            }
                            break;
                        case "MG":
                            {
                                if (Acesso.TP_AMB == 2)
                                {
                                    #region MS_homologacao
                                    HLP.GeraXml.WebService.v2_Homologacao_RecepcaoEvento_MG.nfeCabecMsg cabec = new HLP.GeraXml.WebService.v2_Homologacao_RecepcaoEvento_MG.nfeCabecMsg();
                                    HLP.GeraXml.WebService.v2_Homologacao_RecepcaoEvento_MG.RecepcaoEvento ws2 = new HLP.GeraXml.WebService.v2_Homologacao_RecepcaoEvento_MG.RecepcaoEvento();

                                    cabec.cUF = Acesso.cUF.ToString();
                                    cabec.versaoDados = "1.00";
                                    ws2.nfeCabecMsgValue = cabec;
                                    ws2.ClientCertificates.Add(Acesso.cert_NFe);

                                    XmlDocument _xmlxelem = new XmlDocument();
                                    _xmlxelem.PreserveWhitespace = true;
                                    _xmlxelem.LoadXml(sXmlLote);

                                    XmlNode xNelem = null;
                                    xNelem = _xmlxelem.DocumentElement;

                                    sRet = ws2.nfeRecepcaoEvento(xNelem).OuterXml;
                                    # endregion
                                }
                                else
                                {
                                    #region MS_producao
                                    HLP.GeraXml.WebService.v2_Producao_RecepcaoEvento_MG.nfeCabecMsg cabec = new HLP.GeraXml.WebService.v2_Producao_RecepcaoEvento_MG.nfeCabecMsg();
                                    HLP.GeraXml.WebService.v2_Producao_RecepcaoEvento_MG.RecepcaoEvento ws2 = new HLP.GeraXml.WebService.v2_Producao_RecepcaoEvento_MG.RecepcaoEvento();

                                    cabec.cUF = Acesso.cUF.ToString();
                                    cabec.versaoDados = "1.00";
                                    ws2.nfeCabecMsgValue = cabec;
                                    ws2.ClientCertificates.Add(Acesso.cert_NFe);

                                    XmlDocument _xmlxelem = new XmlDocument();
                                    _xmlxelem.PreserveWhitespace = true;
                                    _xmlxelem.LoadXml(sXmlLote);

                                    XmlNode xNelem = null;
                                    xNelem = _xmlxelem.DocumentElement;

                                    sRet = ws2.nfeRecepcaoEvento(xNelem).OuterXml;
                                    #endregion
                                }

                            }
                            break;
                    }
                }
                else if (Acesso.TP_EMIS == 3)
                {
                    if (Acesso.TP_AMB == 2)
                    {
                        #region SCAN_homologacao
                        HLP.GeraXml.WebService.v2_SCAN_Homologacao_NFeRetRecepcao.nfeCabecMsg cabec = new HLP.GeraXml.WebService.v2_SCAN_Homologacao_NFeRetRecepcao.nfeCabecMsg();
                        HLP.GeraXml.WebService.v2_SCAN_Homologacao_NFeRetRecepcao.NfeRetRecepcao2 ws2 = new HLP.GeraXml.WebService.v2_SCAN_Homologacao_NFeRetRecepcao.NfeRetRecepcao2();

                        cabec.cUF = Acesso.cUF.ToString();
                        cabec.versaoDados = "1.00";
                        ws2.nfeCabecMsgValue = cabec;
                        ws2.ClientCertificates.Add(Acesso.cert_NFe);

                        XmlDocument _xmlxelem = new XmlDocument();
                        _xmlxelem.PreserveWhitespace = true;
                        _xmlxelem.LoadXml(sXmlLote);

                        XmlNode xNelem = null;
                        xNelem = _xmlxelem.DocumentElement;

                        sRet = ws2.nfeRetRecepcao2(xNelem).OuterXml;
                        # endregion
                    }
                    else
                    {
                        #region SCAN_producao
                        HLP.GeraXml.WebService.v2_SCAN_Producao_NFeRetRecepcao.nfeCabecMsg cabec = new HLP.GeraXml.WebService.v2_SCAN_Producao_NFeRetRecepcao.nfeCabecMsg();
                        HLP.GeraXml.WebService.v2_SCAN_Producao_NFeRetRecepcao.NfeRetRecepcao2 ws2 = new HLP.GeraXml.WebService.v2_SCAN_Producao_NFeRetRecepcao.NfeRetRecepcao2();

                        cabec.cUF = Acesso.cUF.ToString();
                        cabec.versaoDados = "1.00";
                        ws2.nfeCabecMsgValue = cabec;
                        ws2.ClientCertificates.Add(Acesso.cert_NFe);

                        XmlDocument _xmlxelem = new XmlDocument();
                        _xmlxelem.PreserveWhitespace = true;
                        _xmlxelem.LoadXml(sXmlLote);

                        XmlNode xNelem = null;
                        xNelem = _xmlxelem.DocumentElement;

                        sRet = ws2.nfeRetRecepcao2(xNelem).OuterXml;
                        #endregion
                    }

                }

                return sRet;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public HLP.GeraXml.bel.CTe.Evento.TRetEvento TransmiteLoteCCeCTe()
        {
            string sRetorno = "";

            XmlDocument _xmlxelem = new XmlDocument();
            _xmlxelem.PreserveWhitespace = true;
            _xmlxelem.LoadXml(this.sXMLfinal);

            XmlNode xNelem = null;
            xNelem = _xmlxelem.DocumentElement;
            try
            {
                //Homologação
                if (Acesso.TP_AMB == 2)
                {
                    HLP.GeraXml.WebService.CTe_Homologacao_cteCancelamento.cteCabecMsg objCabecCancelamento = new HLP.GeraXml.WebService.CTe_Homologacao_cteCancelamento.cteCabecMsg();
                    objCabecCancelamento.cUF = Acesso.cUF.ToString();
                    objCabecCancelamento.versaoDados = Acesso.versaoCTe;

                    HLP.GeraXml.WebService.CTe_Homologacao_cteCancelamento.CteCancelamento objCancelamento = new HLP.GeraXml.WebService.CTe_Homologacao_cteCancelamento.CteCancelamento();
                    objCancelamento.cteCabecMsgValue = objCabecCancelamento;
                    objCancelamento.ClientCertificates.Add(Acesso.cert_CTe);
                    sRetorno = objCancelamento.cteCancelamentoCT(xNelem).OuterXml;
                }
                //Produção
                else if (Acesso.TP_AMB == 1)
                {
                    HLP.GeraXml.WebService.CTe_Producao_evento.cteCabecMsg cabec = new WebService.CTe_Producao_evento.cteCabecMsg();
                    HLP.GeraXml.WebService.CTe_Producao_evento.CteRecepcaoEvento objCancelamento = new WebService.CTe_Producao_evento.CteRecepcaoEvento();
                    cabec.cUF = Acesso.cUF.ToString();
                    cabec.versaoDados = Acesso.versaoCTe;
                    objCancelamento.cteCabecMsgValue = cabec;
                    objCancelamento.ClientCertificates.Add(Acesso.cert_CTe);
                    sRetorno = objCancelamento.cteRecepcaoEvento(xNelem).OuterXml;
                }

                XDocument xRet = XDocument.Parse(sRetorno);
                string sPath = Pastas.PROTOCOLOS + "\\" + this.objlItensPesquisa.FirstOrDefault().CHNFE + "_ret-cce.xml";
                xRet.Save(sPath);
                HLP.GeraXml.bel.CTe.Evento.TRetEvento retorno = SerializeClassToXml.DeserializeClasse<HLP.GeraXml.bel.CTe.Evento.TRetEvento>(sPath);
                return retorno;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
