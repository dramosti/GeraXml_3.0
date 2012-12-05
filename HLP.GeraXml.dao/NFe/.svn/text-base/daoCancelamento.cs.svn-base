using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HLP.GeraXml.Comum.Static;

namespace HLP.GeraXml.dao.NFe
{
    public class daoCancelamento
    {
        public DataTable BuscaProtocoloNFe(string sCD_NFSEQ)
        {
            try
            {
                StringBuilder sSql = new StringBuilder();
                sSql.Append("select ");
                sSql.Append("cd_nprotnfe ");
                sSql.Append("from nf ");
                sSql.Append("where ");
                sSql.Append("(cd_empresa = '");
                sSql.Append(Acesso.CD_EMPRESA);
                sSql.Append("') ");
                sSql.Append("and ");
                sSql.Append("(cd_nfseq = '");
                sSql.Append(sCD_NFSEQ);
                sSql.Append("')");

                return HLP.GeraXml.dao.ADO.HlpDbFuncoes.qrySeekRet(sSql.ToString());
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void AlteraNotaParaCancelada(string nprot, string seqNF)
        {
            try
            {
                StringBuilder sSql = new StringBuilder();
                sSql.Append("update nf ");
                sSql.Append("set cd_recibocanc = '");
                sSql.Append(nprot);
                sSql.Append("' ");
                sSql.Append("where ");
                sSql.Append("cd_empresa = '");
                sSql.Append(Acesso.CD_EMPRESA);
                sSql.Append("' ");
                sSql.Append("and ");
                sSql.Append("cd_nfseq = '");
                sSql.Append(seqNF);
                sSql.Append("'");

                HLP.GeraXml.dao.ADO.HlpDbFuncoes.qrySeekUpdate(sSql.ToString());
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
