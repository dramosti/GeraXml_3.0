using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HLP.GeraXml.dao.ADO;
using HLP.GeraXml.Comum.Static;
using System.Data;

namespace HLP.GeraXml.dao.CTe
{
    public class daoDadosNf
    {
        public DataTable BuscaDadosNf(string sCte)
        {
            try
            {
                StringBuilder sQuery = new StringBuilder();
                sQuery.Append("Select ");
                sQuery.Append("coalesce(nfconhec.st_tiponf,'')Tipo, ");
                sQuery.Append("coalesce(nfconhec.cd_mod,'01')mod, ");
                sQuery.Append("coalesce(nfconhec.cd_chave,'')chave, ");
                sQuery.Append("coalesce(nfconhec.desc_outros,'')descOutros, ");
                sQuery.Append("coalesce(nfconhec.cd_serie,'')serie, ");
                sQuery.Append("coalesce(nfconhec.cd_nf,'')nDoc, ");
                sQuery.Append("coalesce(nfconhec.dt_emi,'')dEmi, ");
                sQuery.Append("coalesce(nfconhec.vl_basecalc,'')vBC, ");
                sQuery.Append("coalesce(nfconhec.vl_totalicms,'')vICMS, ");
                sQuery.Append("coalesce(nfconhec.vl_basecalcst,'')vBCST, ");
                sQuery.Append("coalesce(nfconhec.vl_totalicmsst,'')vST, ");
                sQuery.Append("coalesce(nfconhec.vl_nf,'')vProd, ");
                sQuery.Append("coalesce(nfconhec.cd_cfop,'')nCFOP ");
                sQuery.Append("from nfconhec ");
                sQuery.Append("join empresa on nfconhec.cd_empresa = empresa.cd_empresa ");
                sQuery.Append("where nfconhec.nr_lancconhecim ='" + sCte + "'");
                sQuery.Append("and empresa.cd_empresa ='" + Acesso.CD_EMPRESA + "'");


                return HlpDbFuncoes.qrySeekRet(sQuery.ToString());

            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
    }
}
