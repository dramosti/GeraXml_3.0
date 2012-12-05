using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HLP.GeraXml.Comum.Static;
using HLP.GeraXml.dao.ADO;
using System.Data;

namespace HLP.GeraXml.dao.CCe
{
    public class daoCarregaDataSet 
    {
        public string BuscaDadosEmpresa()
        {
            try
            {
                string sQuery = "select e.cd_cgc, e.ds_endnor, e.nm_bairronor,e.nm_cidnor,e.cd_ufnor from empresa e " +
                                "where e.cd_empresa = '" + Acesso.CD_EMPRESA + "'";

                DataTable dt = HlpDbFuncoes.qrySeekRet(sQuery.ToString());

                StringBuilder sDados = new StringBuilder();
                foreach (DataRow dr in dt.Rows)
                {
                    sDados.Append(Acesso.NM_RAZAOSOCIAL + Environment.NewLine);
                    sDados.Append(dr["cd_cgc"].ToString() + Environment.NewLine);
                    sDados.Append(dr["ds_endnor"].ToString() + ", " + dr["nm_bairronor"].ToString() + Environment.NewLine + dr["nm_cidnor"].ToString() + "/" + dr["cd_ufnor"].ToString());
                }
                return sDados.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string BuscaDadosCliente(string sCD_CLIFOR)
        {
            try
            {
                string sQuery = "select e.nm_clifor,(case when e.cd_cpf is null then e.cd_cgc else e.cd_cpf end)cd_cgc, " +
                                " coalesce(e.ds_endnor,'')ds_endnor,coalesce(e.nr_endnor,'')nr_endnor, coalesce(e.nm_bairronor,'')nm_bairronor,coalesce(e.nm_cidnor,'')nm_cidnor,coalesce(e.cd_ufnor,'')cd_ufnor from clifor e " +
                                "where e.cd_clifor = '" + sCD_CLIFOR + "'";

                DataTable dt = HlpDbFuncoes.qrySeekRet(sQuery.ToString());

                StringBuilder sDados = new StringBuilder();

                foreach (DataRow dr in dt.Rows)
                {
                    sDados.Append(dr["nm_clifor"].ToString() + Environment.NewLine);
                    sDados.Append(dr["cd_cgc"].ToString() + Environment.NewLine);
                    sDados.Append(dr["ds_endnor"].ToString() + " , Nº " + dr["nr_endnor"].ToString() + " - " + dr["nm_bairronor"].ToString() + Environment.NewLine + dr["nm_cidnor"].ToString() + "/" + dr["cd_ufnor"].ToString());
                }
                return sDados.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
