using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HLP.GeraXml.Comum.Static;

namespace HLP.GeraXml.dao.CTe
{
    public class daoInutilizaFaixaCte
    {
        public DataTable RetornaDadosInutilizacao()
        {
            try
            {

                StringBuilder sQuery = new StringBuilder();
                sQuery.Append("Select ");
                sQuery.Append("coalesce(empresa.cd_ufnor,'') cUF,");
                sQuery.Append("coalesce(empresa.cd_cgc,'')CNPJ ");
                sQuery.Append("from empresa ");
                sQuery.Append("where empresa.cd_empresa ='" + Acesso.CD_EMPRESA + "' ");

                return HLP.GeraXml.dao.ADO.HlpDbFuncoes.qrySeekRet(sQuery.ToString());

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
