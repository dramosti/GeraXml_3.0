using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HLP.GeraXml.Comum.Static;

namespace HLP.GeraXml.dao.NFe
{
    public class daoRecepcao
    {
        public void gravaRecibo(string sRecibo, string seqNF)
        {

            try
            {
                StringBuilder sSql = new StringBuilder();
                sSql.Append("update nf ");
                sSql.Append("set cd_recibonfe ='");
                sSql.Append(sRecibo);
                sSql.Append("' ");
                sSql.Append("where ");
                sSql.Append("cd_empresa ='");
                sSql.Append(Acesso.CD_EMPRESA);
                sSql.Append("' ");
                sSql.Append("and ");
                sSql.Append("cd_nfseq ='");
                sSql.Append(seqNF);
                sSql.Append("'");
                sSql.Append(" and coalesce(cd_recibonfe, '') = ''");

                HLP.GeraXml.dao.ADO.HlpDbFuncoes.qrySeekUpdate(sSql.ToString());

            }
            catch (Exception)
            {
                throw;
            }

        }

    }
}
