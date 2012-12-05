using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HLP.GeraXml.Comum.Static;
using HLP.GeraXml.dao.ADO;
using System.Data;

namespace HLP.GeraXml.dao.CTe
{
    public class daoDadosEmit
    {
        public DataTable BuscaDadosEmit()
        {
            try
            {
                StringBuilder sQuery = new StringBuilder();

                sQuery.Append("Select ");
                sQuery.Append("coalesce (empresa.cd_cgc,'')CNPJ, ");
                sQuery.Append("coalesce (empresa.cd_insest,'') IE, ");
                sQuery.Append("empresa.nm_empresa xNome, ");
                sQuery.Append("empresa.nm_guerra xFant, ");
                sQuery.Append("coalesce (empresa.ds_endnor,'') xLgr, ");
                sQuery.Append("coalesce (empresa.ds_endcomp,'')xCpl, ");
                sQuery.Append("coalesce (empresa.nr_end,'')nro, ");
                sQuery.Append("empresa.nm_bairronor xBairro, ");
                sQuery.Append("coalesce (cidades.cd_municipio,'')cMun, ");
                sQuery.Append("empresa.nm_cidnor xMun, ");
                sQuery.Append("coalesce (empresa.cd_cepnor,'')CEP, ");
                sQuery.Append("coalesce (empresa.cd_ufnor,'') UF, ");
                sQuery.Append("coalesce (empresa.cd_fonenor,'')fone ");
                sQuery.Append("from empresa ");
                sQuery.Append("left join cidades on empresa.nm_cidnor = cidades.nm_cidnor  and cidades.cd_ufnor = empresa.cd_ufnor  ");
                sQuery.Append("where empresa.cd_empresa = '" + Acesso.CD_EMPRESA + "'");

                return HlpDbFuncoes.qrySeekRet(sQuery.ToString());


            }
            catch (Exception ex)
            {
                throw ex;
            }



        }
    }
}
