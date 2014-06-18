using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HLP.GeraXml.Comum.Static;
using HLP.GeraXml.dao.ADO;
using System.Data;

namespace HLP.GeraXml.dao.CTe
{
    public class daoDadosIde
    {
        public DataTable BuscaDadosPopulaIde(string sCte)
        {
            try
            {

                StringBuilder sQuery = new StringBuilder();
                sQuery.Append("select ");
                sQuery.Append("coalesce(conhecim.cd_consignat,'')cd_consignat, ");
                sQuery.Append("coalesce(empresa.cd_ufnor,'') cUF,");
                sQuery.Append("coalesce(conhecim.cd_respons,'') Tomador,");
                sQuery.Append("coalesce(conhecim.nr_lanc,'') cCT,");
                sQuery.Append("coalesce(conhecim.cd_cfop,'') CFOP,");
                sQuery.Append("coalesce(natop.ds_natop,'') natOp ,");
                sQuery.Append("coalesce(conhecim.cd_serie,'') serie,");
                sQuery.Append("coalesce(conhecim.cd_conheci,'') nCT,");
                sQuery.Append("coalesce(empresa.nm_cidnor,'') xMunEmi,");
                sQuery.Append("coalesce(empresa.cd_ufnor,'') UFEmi,");
                sQuery.Append("coalesce(cidade1.cd_municipio,'') cMunIni,");
                sQuery.Append("coalesce(conhecim.ds_cidcole,'') xMunIni,");
                sQuery.Append("coalesce(conhecim.cd_ufcole,'') UFIni,");
                sQuery.Append("coalesce(destino.cd_uf,'') UFFim, ");
                sQuery.Append("coalesce(cidade2.cd_municipio,'') cMunFim,");
                sQuery.Append("coalesce(conhecim.ds_calc,'') xMunFim,");
                sQuery.Append("coalesce(conhecim.st_forpag,'1') forPag,");
                sQuery.Append("coalesce(conhecim.cd_veiculo,'') Veiculo,");
                sQuery.Append("coalesce(conhecim.cd_veiculo2,'') Veiculo2,");
                sQuery.Append("coalesce(conhecim.cd_veiculo3,'') Veiculo3,");
                sQuery.Append("coalesce(conhecim.cd_veiculo4,'') Veiculo4,");
                sQuery.Append("coalesce(conhecim.cd_motoris,'') Motorista ");
                sQuery.Append("from conhecim left join natop  on conhecim.cd_cfop = natop.cd_cfop ");
                sQuery.Append("left join empresa on conhecim.cd_empresa = empresa.cd_empresa ");
                sQuery.Append("left join remetent destino on (destino.cd_remetent = conhecim.cd_redes and conhecim.cd_redes is not null) ");
                sQuery.Append("or (destino.cd_remetent = conhecim.cd_destinat and conhecim.cd_redes is null) ");
                sQuery.Append("left join clifor on conhecim.cd_clifor = clifor.cd_clifor ");
                sQuery.Append("left join cidades cidade1 on  cidade1.nm_cidnor = conhecim.ds_cidcole  and cidade1.cd_ufnor = conhecim.cd_ufcole  ");
                sQuery.Append("left join cidades cidade2 on  cidade2.nm_cidnor = conhecim.ds_calc  and cidade2.cd_ufnor = destino.cd_uf  ");

                //sQuery.Append("from conhecim left join natop  on conhecim.cd_cfop = natop.cd_cfop ");
                //sQuery.Append("left join empresa on conhecim.cd_empresa = empresa.cd_empresa ");
                //sQuery.Append("left join clifor on conhecim.cd_clifor = clifor.cd_clifor ");
                //sQuery.Append("left join cidades cidade1 on  cidade1.nm_cidnor = conhecim.ds_cidcole  and cidade1.cd_ufnor = conhecim.cd_ufcole  ");
                //sQuery.Append("left join cidades cidade2 on  cidade2.nm_cidnor = conhecim.ds_calc  and cidade2.cd_ufnor = destino.cd_uf  ");
                //sQuery.Append("left join cidades cidade2 on  cidade2.nm_cidnor = conhecim.ds_calc ");
                sQuery.Append("where empresa.cd_empresa ='" + Acesso.CD_EMPRESA);
                sQuery.Append("' and conhecim.nr_lanc ='" + sCte + "'");

                return HlpDbFuncoes.qrySeekRet(sQuery.ToString());

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public string RetornaCodigoCidade(string sCidade, string sUf)
        {
            try
            {

                StringBuilder sQuery = new StringBuilder();
                sQuery.Append("Select coalesce(cidades.cd_municipio,'') cd_municipio from cidades ");
                sQuery.Append("Where cidades.nm_cidnor ='" + sCidade + "'");
                sQuery.Append(" and cidades.cd_ufnor='" + sUf + "'");

                DataTable dt = HlpDbFuncoes.qrySeekRet(sQuery.ToString());

                return dt.Rows[0]["cd_municipio"].ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
