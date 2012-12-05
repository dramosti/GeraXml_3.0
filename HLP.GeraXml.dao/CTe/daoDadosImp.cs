using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HLP.GeraXml.dao.ADO;
using HLP.GeraXml.Comum.Static;
using System.Data;

namespace HLP.GeraXml.dao.CTe
{
    public class daoDadosImp
    {
        public DataTable BuscaDadosImp(string sCte)
        {


            try
            {
                StringBuilder sQuery = new StringBuilder();

                sQuery.Append("Select ");
                sQuery.Append("coalesce (conhecim.cd_sittrib,'') CST, ");
                sQuery.Append("coalesce (conhecim.vl_redbase,'') pRedBC, ");
                sQuery.Append("coalesce (conhecim.vl_base,'') vBC, ");
                sQuery.Append("coalesce (conhecim.vl_aliq,'') pICMS, ");
                sQuery.Append("coalesce (conhecim.vl_icms,'') vICMS ");
                sQuery.Append("From conhecim  ");
                sQuery.Append("join  empresa on conhecim.cd_empresa = empresa.cd_empresa ");
                sQuery.Append("Where conhecim.nr_lanc = '" + sCte + "'");
                sQuery.Append("And empresa.cd_empresa = '" + Acesso.CD_EMPRESA + "'");


                return HlpDbFuncoes.qrySeekRet(sQuery.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
