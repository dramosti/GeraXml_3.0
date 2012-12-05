using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HLP.GeraXml.dao.ADO;
using HLP.GeraXml.Comum.Static;

namespace HLP.GeraXml.dao.CTe
{
    public class daoBuscaDadosGerais 
    {
        public DataTable PesquisaGridView(string sCampos, string sWhere)
        {
            try
            {
                string sQuery = "Select "
                                + sCampos
                                + " from conhecim c inner join remetent r on c.cd_remetent = r.cd_remetent"
                                + " Where " + sWhere;


                return HlpDbFuncoes.qrySeekRet(sQuery.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataTable PesquisaGridViewContingencia(string sCampos)
        {
            try
            {
                string sQuery = "Select "
                                + sCampos
                                + " from conhecim c inner join remetent r on c.cd_remetent = r.cd_remetent"
                                + " where conhecim.st_contingencia ='S'  and (conhecim.st_cte='N' or  conhecim.st_cte is null)";

                return HlpDbFuncoes.qrySeekRet(sQuery.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
           
        }

        public string VerificaCampoReciboPreenchido(string sSeq)
        {
            try
            {
                string sValidaRecibo = "";
                StringBuilder sQuery = new StringBuilder();
                sQuery.Append("Select coalesce(cd_recibocte,'')cd_recibocte from conhecim ");
                sQuery.Append("where ");
                sQuery.Append("cd_empresa ='");
                sQuery.Append(Acesso.CD_EMPRESA);
                sQuery.Append("' ");
                sQuery.Append("and ");
                sQuery.Append("nr_lanc ='");
                sQuery.Append(sSeq);
                sQuery.Append("'");

                DataTable dt = HlpDbFuncoes.qrySeekRet(sQuery.ToString());
                return sValidaRecibo = dt.Rows[0]["cd_recibocte"].ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string VerificaCampoProtocoloEnvio(string sNumCte)
        {
            try
            {


                StringBuilder sQuery = new StringBuilder();
                sQuery.Append("Select coalesce(conhecim.cd_nprotcte,'')cd_nprotcte ");
                sQuery.Append("from conhecim  ");
                sQuery.Append("where conhecim.cd_conheci ='" + sNumCte + "' ");
                sQuery.Append("and conhecim.cd_empresa ='" + Acesso.CD_EMPRESA + "'");

                DataTable dt = HlpDbFuncoes.qrySeekRet(sQuery.ToString());
                return dt.Rows[0]["cd_nprotcte"].ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public List<string> VerificaPendenciasdeEnvio()
        {
            try
            {
                List<string> ListaConhecimento = new List<string>();
                StringBuilder sQuery = new StringBuilder();
                sQuery.Append("Select conhecim.nr_lanc from conhecim ");
                sQuery.Append("where conhecim.st_contingencia ='S' ");
                sQuery.Append("and (conhecim.st_cte='N' or  conhecim.st_cte is null)");

                DataTable dt = HlpDbFuncoes.qrySeekRet(sQuery.ToString());
                foreach (DataRow dr in dt.Rows)
                {
                    ListaConhecimento.Add(dr["nr_lanc"].ToString());
                }
                return ListaConhecimento;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public string BuscaNumeroConhecimento(string sSeq)
        {

            try
            {
                StringBuilder sQuery = new StringBuilder();
                sQuery.Append("Select  conhecim.cd_conheci ");
                sQuery.Append("from conhecim  ");
                sQuery.Append("where conhecim.nr_lanc ='" + sSeq + "' ");
                sQuery.Append("and conhecim.cd_empresa ='" + Acesso.CD_EMPRESA + "'");

                DataTable dt = HlpDbFuncoes.qrySeekRet(sQuery.ToString());
                return dt.Rows[0]["cd_conheci"].ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public string BuscaChaveRetornoCte(string sNumCte)
        {
            try
            {
                StringBuilder sQuery = new StringBuilder();
                sQuery.Append("Select coalesce(conhecim.cd_chavecte,'')cd_chavecte ");
                sQuery.Append("from conhecim  ");
                sQuery.Append("where conhecim.cd_conheci ='" + sNumCte + "' ");
                sQuery.Append("and conhecim.cd_empresa ='" + Acesso.CD_EMPRESA + "'");

                DataTable dt = HlpDbFuncoes.qrySeekRet(sQuery.ToString());
                return dt.Rows[0]["cd_chavecte"].ToString();

            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        public string BuscaChaveRetornoCteSeq(string sNumSeq)
        {
            try
            {
                StringBuilder sQuery = new StringBuilder();
                sQuery.Append("Select coalesce(conhecim.cd_chavecte,'')cd_chavecte ");
                sQuery.Append("from conhecim  ");
                sQuery.Append("where conhecim.nr_lanc ='" + sNumSeq + "' ");
                sQuery.Append("and conhecim.cd_empresa ='" + Acesso.CD_EMPRESA + "'");
                DataTable dt = HlpDbFuncoes.qrySeekRet(sQuery.ToString());
                return dt.Rows[0]["cd_chavecte"].ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<string> ValidaSeqNoBanco(List<string> sListSeq)
        {
            try
            {

                StringBuilder sQuery = new StringBuilder();
                sQuery.Append("select ");
                sQuery.Append("c.nr_lanc ");
                sQuery.Append("From conhecim c ");
                sQuery.Append("where ");
                sQuery.Append("((c.cd_conheci is null) or (c.cd_conheci = '')) and (");
                sQuery.Append("c.cd_empresa ='");
                sQuery.Append(Acesso.CD_EMPRESA);
                sQuery.Append("') and (");
                sQuery.Append("c.nr_lanc in('");

                int iCont = 0;
                foreach (var seq in sListSeq)
                {
                    iCont++;
                    sQuery.Append(seq);
                    if (sListSeq.Count > iCont)
                    {
                        sQuery.Append("','");
                    }
                }
                sQuery.Append("')) ");
                sQuery.Append("Order by c.cd_empresa, c.nr_lanc ");

                DataTable dt = HlpDbFuncoes.qrySeekRet(sQuery.ToString());

                List<string> lsSeqValidos = new List<string>();
                foreach (DataRow dr in dt.Rows)
                {
                    lsSeqValidos.Add(dr["nr_lanc"].ToString());
                }

                return lsSeqValidos;

            }
            catch (Exception)
            {

                throw;
            }


        }
    }
}
