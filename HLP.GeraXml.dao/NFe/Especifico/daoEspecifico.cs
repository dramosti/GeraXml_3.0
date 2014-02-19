using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HLP.GeraXml.Comum.Static;
using System.Data;
using HLP.GeraXml.dao.ADO;

namespace HLP.GeraXml.dao.NFe.Especifico
{
    public class daoEspecifico
    {
        /// <summary>
        /// Helenge
        /// </summary>
        /// <param name="sNrLanc"></param>
        /// <returns></returns>
        public static string BuscaContratoOBS(string sNrLanc)
        {
            string sOBS = string.Empty;
            if (!sNrLanc.Equals("0"))
            {
                try
                {
                    StringBuilder sSql = new StringBuilder();
                    sSql.Append("Select ");
                    sSql.Append("cd_contrato, ");
                    sSql.Append("ds_obs ");
                    sSql.Append("From Movitem ");
                    sSql.Append("where cd_empresa = '");
                    sSql.Append(Acesso.CD_EMPRESA);
                    sSql.Append("'");
                    sSql.Append(" and ");
                    sSql.Append("nr_lanc = '");
                    sSql.Append(sNrLanc);
                    sSql.Append("'");
                    DataTable dt = HlpDbFuncoes.qrySeekRet(sSql.ToString());
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (dr["cd_contrato"].ToString() != "")
                        {
                            sOBS += string.Format("Contrato {0}",
                                                 dr["cd_contrato"].ToString());

                        }                       
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(string.Format("Não foi possivel gerar a OBS de Itens do Contrato/OBS, Erro.: {0}",
                                                      ex.Message));
                }
            }
            return sOBS;
        }

        /// <summary>
        /// FORMINGP
        /// </summary>
        /// <param name="sNRLanc"></param>
        /// <returns></returns>
        public static string BuscaSerieProd(string sNRLanc)
        {
            StringBuilder sSerieProd = new StringBuilder();
            string sNrSerieProd = string.Empty;

            if (!sNRLanc.Equals("0"))
            {
                //Campos do Select
                sSerieProd.Append("Select ");
                sSerieProd.Append("cd_NRSerie ");

                //Tabela
                sSerieProd.Append("From SERIEPROD ");

                //Where
                sSerieProd.Append("Where ");
                sSerieProd.Append("(SERIEPROD.cd_empresa ='");
                sSerieProd.Append(Acesso.CD_EMPRESA);
                sSerieProd.Append("')");
                sSerieProd.Append(" and ");
                sSerieProd.Append("(SERIEPROD.nr_lanc = '");
                sSerieProd.Append(sNRLanc.Trim());
                sSerieProd.Append("') ");

                foreach (DataRow drSerieProd in HlpDbFuncoes.qrySeekRet(sSerieProd.ToString()).Rows)
                {
                    sNrSerieProd += drSerieProd["cd_NRSerie"].ToString().Trim() + ", ";
                }

                if (sNrSerieProd != "")
                {
                    sNrSerieProd = string.Format("Numero de Serie.: {0}",
                                                sNrSerieProd.Substring(0, sNrSerieProd.Trim().Length - 1));
                }
            }
            return sNrSerieProd;
        }

        /// <summary>
        /// JAMAICA
        /// </summary>
        /// <param name="sNrLanc"></param>
        /// <returns></returns>
        public static string BuscaInformacoesLote(string sNrLanc)
        {
            try
            {
                string sRetorno = "";
                if (!sNrLanc.Equals("0"))
                {
                    StringBuilder sQuery = new StringBuilder();
                    sQuery.Append("SELECT i.nr_lancmovitem, i.cd_nfseq, coalesce(i.CD_LOTEITEM,'')CD_LOTEITEM ,coalesce(i.DT_VALIDADE,'')DT_VALIDADE,coalesce(i.QT_LOTE,0)QT_LOTE FROM loteitem i ");
                    sQuery.Append("INNER JOIN movitem m ON i.nr_lancmovitem = m.nr_lanc and i.cd_empresa = m.cd_empresa ");
                    sQuery.Append("where  m.nr_lanc = '" + sNrLanc + "'");

                    foreach (DataRow dr in HlpDbFuncoes.qrySeekRet(sQuery.ToString()).Rows)
                    {
                        string sDtValidade = dr["DT_VALIDADE"].ToString();
                        string sQtde = Convert.ToDecimal(dr["QT_LOTE"].ToString()).ToString("0.000");
                        if (sDtValidade != "")
                        {
                            sDtValidade = "Validade: " + Convert.ToDateTime(sDtValidade).ToString("dd/MM/yyyy");
                        }
                        sRetorno += string.Format("Lote:{0} Qtde:{1} {2} |", dr["CD_LOTEITEM"].ToString(), sQtde, sDtValidade);
                    }
                }
                return sRetorno;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Marpa
        /// </summary>
        /// <param name="sNrLanc"></param>
        /// <returns></returns>
        public static string MontaObsItemMarpa(string sNrLanc)
        {
            string sObs = "";
            double vl_BaseIcmsRet = 0.00;
            double vl_IcmsRet = 0.00;

            StringBuilder sSql = new StringBuilder();

            sSql.Append("Select ");
            sSql.Append("First 1 ");
            sSql.Append("MOVITEM.vl_bicmssubst, ");
            sSql.Append("MOVITEM.vl_icmretsubst, ");
            sSql.Append("PRODUTO.DS_CERTIFICADONF ");
            //Tabela
            sSql.Append("From MOVITEM ");
            //Relacionamentos
            sSql.Append("inner join Produto on (Produto.cd_empresa = movitem.cd_empresa)");
            sSql.Append(" and ");
            sSql.Append("(Produto.cd_prod = movitem.cd_prod) ");
            //Where
            sSql.Append("Where ");
            sSql.Append("(movitem.cd_empresa ='");
            sSql.Append(Acesso.CD_EMPRESA);
            sSql.Append("')");
            sSql.Append(" and ");
            sSql.Append("(movitem.nr_lanc = '");
            sSql.Append(sNrLanc);
            sSql.Append("') ");


            DataRow drObsItem = HlpDbFuncoes.qrySeekRet(sSql.ToString()).Rows[0];
            if ((drObsItem["vl_bicmssubst"].ToString() != "0") ||
                (drObsItem["vl_icmretsubst"].ToString() != "0"))
            {

                vl_BaseIcmsRet = Convert.ToDouble(drObsItem["vl_bicmssubst"].ToString());
                vl_IcmsRet = Convert.ToDouble(drObsItem["vl_icmretsubst"].ToString());

                sObs = string.Format("Base ICMS Retido: {0:C2} - Valor ICMS Retido: {1:C2}",
                                     vl_BaseIcmsRet.ToString("#0.00"),
                                     vl_IcmsRet.ToString("#0.00"));
            }
            if (drObsItem["DS_CERTIFICADONF"].ToString() != "")
            {
                if (sObs != "")
                {
                    sObs += " - " + Util.TiraSimbolo(drObsItem["DS_CERTIFICADONF"].ToString(), "-");
                }
                else
                {
                    sObs = Util.TiraSimbolo(drObsItem["DS_CERTIFICADONF"].ToString(), "-");
                }
            }
            return sObs;
        }
    }
}
