using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HLP.GeraXml.dao.ADO;
using System.Data;
using HLP.GeraXml.Comum.Static;

namespace HLP.GeraXml.dao.CTe
{
    public class daoDadosExped
    {
        public string BuscaDadosExped(string sCte)
        {
            try
            {
                StringBuilder sQuery = new StringBuilder();


                sQuery.Append("Select ");
                sQuery.Append("coalesce(conhecim.cd_redes,'')cd_redes ");
                sQuery.Append("from conhecim ");
                sQuery.Append("join empresa  on  conhecim.cd_empresa = empresa.cd_empresa ");
                sQuery.Append("where conhecim.nr_lanc ='" + sCte + "'");
                sQuery.Append("and empresa.cd_empresa='" + Acesso.CD_EMPRESA + "'");

                DataTable dt = HlpDbFuncoes.qrySeekRet(sQuery.ToString());
                return dt.Rows[0]["cd_redes"].ToString();


            }
            catch (Exception ex)
            {
                throw ex;
            }



        }

        public DataTable BuscaDadosRedes(string sCodRedes)
        {
            try
            {
                StringBuilder sQuery = new StringBuilder();

                sQuery.Append("Select ");
                sQuery.Append("coalesce(remetent.cd_cgc,'')CNPJ, ");
                sQuery.Append("coalesce(remetent.cd_cpf,'')CPF, ");
                sQuery.Append("coalesce(remetent.cd_insest,'')IE, ");
                sQuery.Append("coalesce(remetent.nm_guerra,'')xNome, ");
                sQuery.Append("coalesce(remetent.cd_fone,'')fone, ");
                sQuery.Append("coalesce(remetent.ds_ende,'')xLgr, ");
                sQuery.Append("coalesce(remetent.nr_end,'')nro, ");
                sQuery.Append("coalesce(remetent.ds_bairro,'')xBairro, ");
                sQuery.Append("coalesce (cidades.cd_municipio,'')cMun, ");
                sQuery.Append("coalesce(remetent.nm_cida,'')xMun, ");
                sQuery.Append("coalesce(remetent.cd_cep,'')CEP, ");
                sQuery.Append("coalesce(remetent.cd_uf,'')UF, ");
                sQuery.Append("coalesce(remetent.cd_pais,'')cPais ");
                sQuery.Append("from remetent ");
                sQuery.Append("left join cidades on remetent.nm_cida = cidades.nm_cidnor  and cidades.cd_ufnor = remetent.cd_uf  ");
                sQuery.Append("where remetent.cd_remetent ='" + sCodRedes + "'");


                return HlpDbFuncoes.qrySeekRet(sQuery.ToString());


            }
            catch (Exception ex)
            {
                throw ex;
            }



        }
    }
}
