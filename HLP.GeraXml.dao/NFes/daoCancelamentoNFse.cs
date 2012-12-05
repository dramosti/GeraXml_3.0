using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HLP.GeraXml.Comum.Static;
using HLP.GeraXml.dao.ADO;
using FirebirdSql.Data.FirebirdClient;

namespace HLP.GeraXml.dao.NFes
{
    public class daoCancelamentoNFse
    {
        public DataTable BuscaDadosCancelamento( string sSequencia)
        {
            try
            {
                StringBuilder sQuery = new StringBuilder();
                sQuery.Append("select cidades.cd_municipio, empresa.cd_cgc Cnpj, empresa.cd_inscrmu, ");
                sQuery.Append("coalesce(nf.cd_numero_nfse,'')cd_numero_nfse ");
                sQuery.Append("from nf inner join empresa on nf.cd_empresa = empresa.cd_empresa ");
                sQuery.Append("inner join cidades on (cidades.nm_cidnor = empresa.nm_cidnor) ");
                sQuery.Append("where nf.cd_nfseq = '" + sSequencia + "' and ");
                sQuery.Append("nf.cd_empresa = '" + Acesso.CD_EMPRESA + "'");

                return HlpDbFuncoes.qrySeekRet(sQuery.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void CancelarNFse(string sNumNfse)
        {
            try
            {
                StringBuilder sQuery = new StringBuilder();
                sQuery.Append("update nf ");
                sQuery.Append("set cd_recibocanc = '");
                sQuery.Append("CANCELADA");
                sQuery.Append("' ");
                sQuery.Append("where ");
                sQuery.Append("cd_empresa = '");
                sQuery.Append(Acesso.CD_EMPRESA);
                sQuery.Append("' ");
                sQuery.Append("and ");
                sQuery.Append("cd_numero_nfse = '");
                sQuery.Append(sNumNfse);
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
