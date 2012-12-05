using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using HLP.GeraXml.Comum.Static;
using HLP.GeraXml.dao.ADO;

namespace HLP.GeraXml.dao.NFe
{
    public class daoBusRetFazenda
    {
        public void SalvaProtocoloNFe(string sSeq, string sChNfe, string sNProt)
        {
            XDocument retcab = new XDocument();
            try
            {
                StringBuilder sSql = new StringBuilder();

                sSql.Append("update nf set cd_chavenferet ='");
                sSql.Append(sChNfe);
                sSql.Append("', ");
                sSql.Append("cd_nprotnfe ='");
                sSql.Append(sNProt);
                sSql.Append("' ");
                sSql.Append("Where nf.cd_empresa = '");
                sSql.Append(Acesso.CD_EMPRESA);
                sSql.Append("' and ");
                sSql.Append("nf.cd_nfseq ='");
                sSql.Append(sSeq);
                sSql.Append("'");
                HLP.GeraXml.dao.ADO.HlpDbFuncoes.qrySeekUpdate(sSql.ToString());

                //Geração do Xml da nfe Autorizado, incluindo a TAG infProc onde consta as informaçoes de retorno da nfe.
            }
            catch (Exception x)
            {
                throw new Exception("Erro na geração do XML Protocolado, infProt - " + x.Message);
            }
        }

        public void NotaDenegada(string sNfseq)
        {
            try
            {
                string sSql = string.Format("UPDATE NF SET " +
                                                    "cd_recibonfe = 'denegada', " +
                                                    "st_nfe = 'S' " +
                                                    (HlpDbFuncoes.fExisteCampo("ST_DENEGADA", "NF") ? " ,ST_DENEGADA = 'S' " : "") +
                                                    (HlpDbFuncoes.fExisteCampo("CD_STDOC", "NF") ? " ,CD_STDOC = '04' " : "") +
                                                    "WHERE CD_NFSEQ = '{0}' AND CD_EMPRESA = '{1}'",
                                sNfseq,
                                Acesso.CD_EMPRESA);
                HlpDbFuncoes.qrySeekUpdate(sSql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        
        public virtual void LimpaCampoRecibo(string sSeq)
        {
            StringBuilder sSql = new StringBuilder();
            try
            {
                sSql.Append("update nf ");
                sSql.Append("set cd_recibonfe = null ");
                sSql.Append("where ");
                sSql.Append("cd_empresa ='");
                sSql.Append(Acesso.CD_EMPRESA);
                sSql.Append("' ");
                sSql.Append("and ");
                sSql.Append("cd_nfseq ='");
                sSql.Append(sSeq);
                sSql.Append("'");
                HlpDbFuncoes.qrySeekUpdate(sSql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SalvaRetornoNotaDuplicada(string sRecibo, string sSeq)
        {
            StringBuilder sSql = new StringBuilder();
            try
            {
                sSql.Append("UPDATE NF ");
                sSql.Append("set cd_recibonfe = '" + sRecibo + "' ");
                sSql.Append("where ");
                sSql.Append("cd_empresa ='");
                sSql.Append(Acesso.CD_EMPRESA);
                sSql.Append("' ");
                sSql.Append("and ");
                sSql.Append("cd_nfseq ='");
                sSql.Append(sSeq);
                sSql.Append("'");
                HlpDbFuncoes.qrySeekUpdate(sSql.ToString());
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void AlteraStatusNotaParaEnviada(string seqNF)
        {
            try
            {
                StringBuilder sSql = new StringBuilder();
                sSql.Append("update nf set st_nfe = 'S' Where cd_nfseq = '" + seqNF + "'");
                sSql.Append("and ");
                sSql.Append("cd_empresa = '");
                sSql.Append(Acesso.CD_EMPRESA);
                sSql.Append("'");
                HlpDbFuncoes.qrySeekUpdate(sSql.ToString());
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
