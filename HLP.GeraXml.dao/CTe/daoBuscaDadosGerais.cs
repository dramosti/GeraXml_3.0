using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HLP.GeraXml.dao.ADO;
using HLP.GeraXml.Comum.Static;
using System.IO;
using System.Xml;

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

        public bool VerificaDataUltimoRetorno(string sSeq)
        {
            try
            {
                string sDT_ULTRET = "";
                StringBuilder sQuery = new StringBuilder();
                sQuery.Append("Select coalesce(DT_ULTRET,'')DT_ULTRET from conhecim ");
                sQuery.Append("where ");
                sQuery.Append("cd_empresa ='");
                sQuery.Append(Acesso.CD_EMPRESA);
                sQuery.Append("' ");
                sQuery.Append("and ");
                sQuery.Append("nr_lanc ='");
                sQuery.Append(sSeq);
                sQuery.Append("'");

                DataTable dt = HlpDbFuncoes.qrySeekRet(sQuery.ToString());
                sDT_ULTRET = dt.Rows[0]["DT_ULTRET"].ToString();

                bool bRet = true;
                if (sDT_ULTRET != "")
                {
                    DateTime dtRet = Convert.ToDateTime(sDT_ULTRET.Trim());
                    if (!(dtRet.AddMinutes(5) <= DateTime.Now))
                        bRet = false;
                }
                return bRet;
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
                sQuery.Append("and conhecim.st_cte = 'S'");

                DataTable dt = HlpDbFuncoes.qrySeekRet(sQuery.ToString());
                return dt.Rows[0]["cd_nprotcte"].ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public string VerificaCampoProtocoloEnvioByChave(string sNumCte, bool bCancelado)
        {
            try
            {
                daoBuscaDadosGerais objGerais = new daoBuscaDadosGerais();
                string sChaveCteRet = objGerais.BuscaChaveRetornoCte(sNumCte);
                string sPasta = sChaveCteRet.Substring(4, 2) + "-" + sChaveCteRet.Substring(2, 2);
                DirectoryInfo dPasta = null;
                if (bCancelado == false)
                {
                    dPasta = new DirectoryInfo(Pastas.ENVIADOS + @"\\" + sPasta);
                }
                else
                {
                    dPasta = new DirectoryInfo(Pastas.CANCELADOS + @"\\" + sPasta);
                }

                string sPath = dPasta.ToString() + "\\Cte_" + sChaveCteRet + ".xml";
                XmlDocument doc = new XmlDocument();
                doc.Load(sPath);
                XmlNodeList infProt = doc.GetElementsByTagName("infProt");
                string nProt = "";
                for (int a = 0; a < infProt.Count; a++)
                {
                    for (int j = 0; j < infProt[a].ChildNodes.Count; j++)
                    {
                        switch (infProt[a].ChildNodes[j].LocalName)
                        {
                            case "nProt": nProt = infProt[a].ChildNodes[j].InnerText;
                                break;
                        }
                    }
                }

                StringBuilder sSql = new StringBuilder();
                sSql.Append("update conhecim set cd_nprotcte = '");
                sSql.Append(nProt);
                sSql.Append("'");
                sSql.Append(" Where conhecim.cd_empresa = '");
                sSql.Append(Acesso.CD_EMPRESA);
                sSql.Append("' and ");
                sSql.Append("conhecim.cd_conheci = '");
                sSql.Append(sNumCte);
                sSql.Append("'");
                try
                {
                    HlpDbFuncoes.qrySeekUpdate(sSql.ToString());
                }
                catch (Exception)
                {
                    throw;
                }
                return nProt;

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



        public string BuscaChaveRetornoCteSeq(string sChaveCTe)
        {

            // Sequencia...
            try
            {
                StringBuilder sQuery = new StringBuilder();
                sQuery.Append("Select coalesce(conhecim.cd_chavecte,'')cd_chavecte ");
                sQuery.Append("from conhecim  ");
                sQuery.Append("where conhecim.nr_lanc ='" + Util.GetNRLANC(sChaveCTe) + "' ");
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
