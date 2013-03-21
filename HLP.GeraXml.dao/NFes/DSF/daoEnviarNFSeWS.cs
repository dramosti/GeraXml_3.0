using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HLP.GeraXml.Comum.Static;
using HLP.GeraXml.dao.ADO;

namespace HLP.GeraXml.dao.NFes.DSF
{
    public partial class daoEnviarNFSeWS
    {
        /// <summary>
        /// Método que salva o numero do Lote no campo de recibo da tabela nf.
        /// </summary>
        /// <param name="sRecibo"></param>
        /// <param name="sSeq"></param>
        public void SalvarRecibo(string sRecibo, string sSeq)
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

        public void LimpaCampoRecibo(string sSeq)
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

        public void SalvaStatusDaNota(string NumeroNFSE, string CodigoVerificacao, string Nfseq)
        {
            try
            {
                StringBuilder sQuery = new StringBuilder();
                sQuery.Append("update nf set st_nfe = 'S' ,");
                sQuery.Append("CD_NUMERO_NFSE ='" + NumeroNFSE + "' ,");
                sQuery.Append("CD_VERIFICACAO_NFSE  = '" + CodigoVerificacao + "' ");
                sQuery.Append("Where cd_nfseq = '" + Nfseq + "' ");
                sQuery.Append("and ");
                sQuery.Append("cd_empresa = '");
                sQuery.Append(Acesso.CD_EMPRESA);
                sQuery.Append("'");

                HlpDbFuncoes.qrySeekUpdate(sQuery.ToString());

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
