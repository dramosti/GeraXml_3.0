using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HLP.GeraXml.Comum.Static;
using HLP.GeraXml.dao.ADO;
using System.Data;

namespace HLP.GeraXml.dao.CTe
{
    public class daoPopulaCte
    {
        public DataTable BuscaDadosChave(string sCte)
        {
            try
            {
                StringBuilder sQuery = new StringBuilder();
                sQuery.Append("Select ");
                sQuery.Append("coalesce(empresa.cd_serie, 1) serie, c.cd_conheci nCT, ");
                sQuery.Append("empresa.cd_cgc CNPJ, c.nr_lanc cCT, empresa.cd_ufnor sUF ");
                sQuery.Append("From ");
                sQuery.Append("conhecim c inner join empresa on (empresa.cd_empresa = c.cd_empresa) ");
                sQuery.Append("where ");
                sQuery.Append("(c.cd_empresa ='");
                sQuery.Append(Acesso.CD_EMPRESA);
                sQuery.Append("')");
                sQuery.Append(" and ");
                sQuery.Append("(c.nr_lanc = '");
                sQuery.Append(sCte);
                sQuery.Append("')");

                return HlpDbFuncoes.qrySeekRet(sQuery.ToString());
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
