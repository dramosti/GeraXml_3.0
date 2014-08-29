using HLP.GeraXml.Comum;
using HLP.GeraXml.Comum.Static;
using HLP.GeraXml.dao;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace HLP.GeraXml.bel.NFe.Eventos
{
    public class belEventosNFe
    {

        List<KeyValuePair<string, string>> lTpEventos = new List<KeyValuePair<string, string>>();
        public string xChaveNFe { get; set; }
        public string xProt { get; set; }
        public string xCodEvento { get; set; }
        public int iNumEvento { get; set; }
        public string xJust { get; set; }
        public tipoEvento tpEvento { get; set; }
        public enum tipoEvento { CANCELAMENTO, MANIFESTO }
        public belEventosNFe(string xChaveNFe, string xCodEvento, tipoEvento tpEvento, int iNumEvento = 1, string xJust = "", string xProt = null)
        {


            lTpEventos.Add(new KeyValuePair<string, string>("210200", "Confirmacao da Operacao"));
            lTpEventos.Add(new KeyValuePair<string, string>("210210", "Ciencia da Operacao"));
            lTpEventos.Add(new KeyValuePair<string, string>("210220", "Desconhecimento da Operacao"));
            lTpEventos.Add(new KeyValuePair<string, string>("210240", "Operacao nao Realizada"));

            this.tpEvento = tpEvento;
            this.xChaveNFe = xChaveNFe;
            this.xCodEvento = xCodEvento;
            this.xProt = xProt;
            this.iNumEvento = iNumEvento;
            this.xJust = xJust;
        }

        /// <summary>
        /// Retorna o XML em formato de string do retorno do evento;
        /// </summary>
        /// <returns></returns>
        public string ExecuteEvento()
        {
            try
            {
                string sDados = this.GetMsgDados();
                XmlDocument xRet = new XmlDocument();

                if (Acesso.TP_AMB == 1)
                {
                    HLP.GeraXml.WebService.AN_PRODUCAO_RecepcaoEvento.nfeCabecMsg cabec = new HLP.GeraXml.WebService.AN_PRODUCAO_RecepcaoEvento.nfeCabecMsg();
                    HLP.GeraXml.WebService.AN_PRODUCAO_RecepcaoEvento.RecepcaoEvento ws2 = new HLP.GeraXml.WebService.AN_PRODUCAO_RecepcaoEvento.RecepcaoEvento();

                    cabec.versaoDados = "1.00";
                    cabec.cUF = "91";// Acesso.cUF.ToString();
                    ws2.ClientCertificates.Add(Acesso.cert_NFe);
                    ws2.nfeCabecMsgValue = cabec;
                    XmlDocument xmlCanc = new XmlDocument();
                    xmlCanc.LoadXml(sDados);
                    XmlNode xNodeCanc = xmlCanc.DocumentElement;
                    string sRet = ws2.nfeRecepcaoEvento(xNodeCanc).OuterXml;
                    xRet.LoadXml(sRet);

                }
                else if (Acesso.TP_AMB == 2)
                {
                    //HLP.GeraXml.WebService.v2_Homologacao_NFeRecepcaoEvento_SP.nfeCabecMsg cabec = new HLP.GeraXml.WebService.v2_Homologacao_NFeRecepcaoEvento_SP.nfeCabecMsg();
                    //HLP.GeraXml.WebService.v2_Homologacao_NFeRecepcaoEvento_SP.RecepcaoEvento ws2 = new HLP.GeraXml.WebService.v2_Homologacao_NFeRecepcaoEvento_SP.RecepcaoEvento();


                    HLP.GeraXml.WebService.AN_HOMOLOGACAO_RecepcaoEvento.nfeCabecMsg cabec = new HLP.GeraXml.WebService.AN_HOMOLOGACAO_RecepcaoEvento.nfeCabecMsg();
                    HLP.GeraXml.WebService.AN_HOMOLOGACAO_RecepcaoEvento.RecepcaoEvento ws2 = new HLP.GeraXml.WebService.AN_HOMOLOGACAO_RecepcaoEvento.RecepcaoEvento();

                    cabec.versaoDados = "1.00";
                    cabec.cUF = "91"; // Acesso.cUF.ToString();
                    ws2.ClientCertificates.Add(Acesso.cert_NFe);
                    ws2.nfeCabecMsgValue = cabec;
                    XmlDocument xmlCanc = new XmlDocument();
                    xmlCanc.LoadXml(sDados);
                    XmlNode xNodeCanc = xmlCanc.DocumentElement;
                    string sRet = ws2.nfeRecepcaoEvento(xNodeCanc).OuterXml;
                    xRet.LoadXml(sRet);

                }
                return xRet.InnerXml;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private string GetMsgDados()
        {
            string sVersao = "1.00";
            belEnvEvento objEnvEvento = new belEnvEvento();
            objEnvEvento.idLote = Util.GetNumeroNFe(this.xChaveNFe).PadLeft(15, '0');
            objEnvEvento.versao = sVersao;
            Evento evento = new Evento();
            evento.versao = sVersao;
            evento.infEvento = new eventoInfEvento();
            evento.infEvento.tpEvento = this.xCodEvento;
            evento.infEvento.nSeqEvento = this.iNumEvento.ToString();

            evento.infEvento.nSeqEvento = iNumEvento.ToString(); // numero de evento
            evento.infEvento.Id = "ID" + evento.infEvento.tpEvento + this.xChaveNFe + evento.infEvento.nSeqEvento.PadLeft(2, '0');
            evento.infEvento.cOrgao = 91;
            evento.infEvento.tpAmb = Convert.ToByte(Acesso.TP_AMB);
            evento.infEvento.CNPJ = Util.RetiraCaracterCNPJ(Acesso.CNPJ_EMPRESA);
            evento.infEvento.chNFe = this.xChaveNFe;
            evento.infEvento.dhEvento = daoUtil.GetDateServidor().ToString("yyyy-MM-ddTHH:mm:ss" + Acesso.FUSO);
            evento.infEvento.verEvento = sVersao;
            evento.infEvento.detEvento = new eventoInfEventoDetEvento();
            evento.infEvento.detEvento.versao = sVersao;
            evento.infEvento.detEvento.descEvento = lTpEventos.FirstOrDefault(c => c.Key == this.xCodEvento).Value;
            evento.infEvento.detEvento.nProt = this.xProt;
            evento.infEvento.detEvento.xJust = this.xJust != "" ? this.xJust : null;

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

            string sXMLfinal = "<?xml version=\"1.0\" encoding=\"utf-8\"?><envEvento xmlns=\"http://www.portalfiscal.inf.br/nfe\" versao=\"1.00\"><idLote>" + objEnvEvento.idLote
                                + "</idLote>" + sEvento.Replace("<?xml version=\"1.0\" encoding=\"utf-8\"?>", "") + "</envEvento>";

            XmlDocument xDoc = new XmlDocument();
            xDoc.LoadXml(sXMLfinal);

            string sPath = "";

            if (this.tpEvento == tipoEvento.CANCELAMENTO)
            {
                sPath = Pastas.PROTOCOLOS + "\\" + objEnvEvento.idLote + "_ped-can.xml";
            }
            else if (tpEvento == tipoEvento.MANIFESTO)
            {
                sPath = Pastas.PROTOCOLOS + "\\" + objEnvEvento.idLote + "_" + this.xCodEvento + "_maniEvent.xml";
            }


            if (File.Exists(sPath))
            {
                File.Delete(sPath);
            }
            xDoc.Save(sPath);
            try
            {
                if (this.tpEvento == tipoEvento.CANCELAMENTO)
                {
                    belValidaXml.ValidarXml("http://www.portalfiscal.inf.br/nfe", Pastas.SCHEMA_CANC + "\\envEventoCancNFe_v1.00.xsd", sPath);
                }
                else if (tpEvento == tipoEvento.MANIFESTO)
                {
                    belValidaXml.ValidarXml("http://www.portalfiscal.inf.br/nfe", Pastas.SCHEMA_MANIFESTACAO + "\\envConfRecebto_v1.00.xsd", sPath);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return sXMLfinal;
        }
    }
}
