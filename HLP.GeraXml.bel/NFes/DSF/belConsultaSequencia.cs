using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HLP.GeraXml.dao;
using HLP.GeraXml.Comum.Static;
using System.IO;
using System.Xml.Serialization;
using System.Xml;

namespace HLP.GeraXml.bel.NFes.DSF
{

    public class belConsultaSequencia
    {
        private HLP.GeraXml.WebService.NFSE_Campinas.LoteRpsService lt = new WebService.NFSE_Campinas.LoteRpsService();
        public string GetSequenciaNota(string sIMPrestador, string sCD_NFSEQ)
        {
            try
            {
                int iSeqRetorno = 0;
                ConsultaSeqRps consulta = new ConsultaSeqRps();
                consulta.Cabecalho = new CabecalhoSeq();
                consulta.Cabecalho.CodCid = daoUtil.GetCodigoSiafiByNome(Acesso.CIDADE_EMPRESA);
                consulta.Cabecalho.CPFCNPJRemetente = Util.RetiraCaracterCNPJ(Acesso.CNPJ_EMPRESA.ToString());
                consulta.Cabecalho.IMPrestador = sIMPrestador;
                consulta.Cabecalho.SeriePrestacao = "99";
                consulta.Cabecalho.Versao = "1";


                string sPath = Pastas.PROTOCOLOS + "\\Busca_SeqNFSe_Camp_" + sCD_NFSEQ + ".xml";

                if (File.Exists(sPath))
                {
                    File.Delete(sPath);
                }

                XmlSerializerNamespaces nameSpaces = new XmlSerializerNamespaces();
                nameSpaces.Add("xsi", "http://www.w3.org/2001/XMLSchema-instance");
                nameSpaces.Add("tipos", "http://localhost:8080/WsNFe2/tp");
                nameSpaces.Add("ns1", "http://localhost:8080/WsNFe2/lote");

                String sXML = null;
                XmlSerializer x = new XmlSerializer(consulta.GetType());
                MemoryStream memoryStream = new MemoryStream();
                XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);
                x.Serialize(xmlTextWriter, consulta, nameSpaces);
                memoryStream = (MemoryStream)xmlTextWriter.BaseStream;
                UTF8Encoding encoding = new UTF8Encoding();
                sXML = encoding.GetString(memoryStream.ToArray());
                sXML = sXML.Substring(1);

                XmlDocument xDoc = new XmlDocument();
                xDoc.LoadXml(sXML);
                xDoc.Save(sPath);

                if (Acesso.TP_AMB_SERV == 1)
                {
                    lt.ClientCertificates.Add(Acesso.cert_NFs);
                }

                string sXmlRet = lt.consultarSequencialRps(sXML);

                if (!string.IsNullOrEmpty(sXmlRet))
                {
                    sPath = Pastas.PROTOCOLOS + "\\Retorno_SeqNFSe_Camp_" + sCD_NFSEQ + ".xml";
                    xDoc = new XmlDocument();
                    xDoc.LoadXml(sXmlRet);
                    xDoc.Save(sPath);

                    //Deserializa o retorno do webservice.
                    XmlSerializer deserializer = new XmlSerializer(typeof(RetornoEnvioLoteRPS));
                    RetornoConsultaSeqRps ret = SerializeClassToXml.DeserializeClasse<RetornoConsultaSeqRps>(sPath);
                    iSeqRetorno = Convert.ToInt32(ret.Cabecalho.NroUltimoRps) + 1;
                }
                return iSeqRetorno.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
