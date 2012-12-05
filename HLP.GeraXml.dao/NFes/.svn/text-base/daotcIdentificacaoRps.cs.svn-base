using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HLP.GeraXml.Comum.Static;
using HLP.GeraXml.dao.ADO;

namespace HLP.GeraXml.dao.NFes
{
    public class daotcIdentificacaoRps
    {
        public DataTable BuscaDadosRps(string sNfseq)
        {
            try
            {
                StringBuilder sQuery = new StringBuilder();
                sQuery.Append("select nf.cd_notafis, coalesce(nf.cd_serie,'00001')cd_serie from nf ");
                sQuery.Append("where nf.cd_nfseq = '" + sNfseq + "' and ");
                sQuery.Append("nf.cd_empresa = '" + Acesso.CD_EMPRESA + "'");

                return HlpDbFuncoes.qrySeekRet(sQuery.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
