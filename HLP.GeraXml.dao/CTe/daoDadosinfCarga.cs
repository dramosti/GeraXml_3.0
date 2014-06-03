using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HLP.GeraXml.dao.ADO;
using HLP.GeraXml.Comum.Static;

namespace HLP.GeraXml.dao.CTe
{
    public class daoDadosinfCarga
    {
        public DataTable BuscaDadosinfCarga(string sCte)
        {
            try
            {
                StringBuilder sQuery = new StringBuilder();
                sQuery.Append("Select ");
                sQuery.Append("coalesce(conhecim.ds_prodpred,'')proPred, ");
                sQuery.Append("coalesce(nfconhec.vl_nf,'')vMerc ");
                sQuery.Append("from conhecim ");
                sQuery.Append("inner JOIN nfconhec ON  (conhecim.nr_lanc = nfconhec.nr_lancconhecim) and ");
                sQuery.Append("(conhecim.cd_empresa = nfconhec.cd_empresa) ");
                sQuery.Append("where   conhecim.nr_lanc ='" + sCte + "' ");
                sQuery.Append("and conhecim.cd_empresa ='" + Acesso.CD_EMPRESA + "'");



                return HlpDbFuncoes.qrySeekRet(sQuery.ToString());

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
