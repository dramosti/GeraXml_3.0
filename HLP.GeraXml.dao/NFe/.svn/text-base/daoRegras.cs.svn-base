using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HLP.GeraXml.Comum.Static;
using HLP.GeraXml.dao.ADO;
using System.Data;

namespace HLP.GeraXml.dao.NFe
{
    public class daoRegras
    {
        public static void AlteraDuplicatasNfe(string Cdnotafis, string Nfseq, bool bNotaServico)
        {
            try
            {
                string sSqlAtualizaNF = string.Empty;

                if (Acesso.TP_EMIS == 3 && bNotaServico)
                {
                    sSqlAtualizaNF = "update NF set cd_notafis = '" + Cdnotafis +
                                     "', st_contingencia = '" + "N" +
                                     "', cd_serie = '" + Acesso.SERIE_SCAN +
                                     "' where cd_empresa = '" + Acesso.CD_EMPRESA +
                                     "' and cd_nfseq = '" + Nfseq + "'";
                }
                else if (Acesso.TP_EMIS == 2 && bNotaServico)
                {
                    sSqlAtualizaNF = "update NF set cd_notafis = '" + Cdnotafis +
                                     "', st_contingencia = '" + "S" +
                                     "' where cd_empresa = '" + Acesso.CD_EMPRESA +
                                     "' and cd_nfseq = '" + Nfseq + "'";
                }
                else
                {

                    sSqlAtualizaNF = "update NF set cd_notafis = '" + Cdnotafis +
                                     "', st_contingencia = '" + "N" +
                                     "' where cd_empresa = '" + Acesso.CD_EMPRESA +
                                     "' and cd_nfseq = '" + Nfseq + "'";
                }

                HlpDbFuncoes.qrySeekUpdate(sSqlAtualizaNF);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static string OperacoesValidas(string scdnfseq)
        {
            try
            {
                StringBuilder sSql = new StringBuilder();
                string sOperacoesValidas = string.Empty;
                string sTipo131 = string.Empty;
                sSql.Append("select ");
                sSql.Append("distinct ");
                sSql.Append("movitem.cd_oper, ");
                sSql.Append("nf.cd_tipodoc ");
                sSql.Append("from nf ");
                sSql.Append("inner join movitem on (movitem.cd_empresa = nf.cd_empresa) and ");
                sSql.Append("(movitem.cd_nfseq = nf.cd_nfseq) ");
                sSql.Append("where ");
                sSql.Append("((nf.cd_empresa = '");
                sSql.Append(Acesso.CD_EMPRESA);
                sSql.Append("')");
                sSql.Append(" and ");
                sSql.Append("(nf.cd_nfseq = '");
                sSql.Append(scdnfseq);
                sSql.Append("'))");

                DataTable dtOperValidas = HlpDbFuncoes.qrySeekRet(sSql.ToString());

                foreach (DataRow dr in dtOperValidas.Rows)
                {
                    sOperacoesValidas += "," + dr["cd_oper"].ToString().Trim();
                    if (dr["cd_tipodoc"].ToString() == "131")
                    {
                        sTipo131 = "TIPO131";
                    }
                }
                sOperacoesValidas = sOperacoesValidas.Replace(",", "','");
                if (sTipo131 != "")
                {
                    sOperacoesValidas += "TIPO131";
                }
                return sOperacoesValidas;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static string MontaFiltroOperacoesValidas(string sOperacoesValidas)
        {
            try
            {
                string sWhere = string.Empty;
                StringBuilder sSql = new StringBuilder();
                sSql = new StringBuilder();
                sSql.Append("select ");
                sSql.Append("opereve.cd_oper ");
                sSql.Append("from opereve ");
                sSql.Append("where ");
                sSql.Append("(opereve.cd_oper ");
                sSql.Append("in ('");
                sSql.Append(sOperacoesValidas);
                sSql.Append("') ");
                sSql.Append("and ");
                sSql.Append("((ST_ESTTERC = 'S') ");
                sSql.Append("and ");
                sSql.Append("(ST_OPER='0')))");

                DataTable dtOperValidas = HlpDbFuncoes.qrySeekRet(sSql.ToString());
                string sFiltro = string.Empty;
                foreach (DataRow dr in dtOperValidas.Rows)
                {
                    sFiltro += "," + dr["cd_oper"].ToString();
                }
                if (sFiltro.Trim() != "")
                {
                    sFiltro = sFiltro.Substring(1, (sFiltro.Length - 1));
                    sFiltro = sFiltro.Replace(",", "','");
                    sWhere = " And (NOT(CD_OPER IN('" + sFiltro + "')))";
                }
                return sWhere;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public static string retGrupoFaturamento(string sNota)
        {
            try
            {
                return HlpDbFuncoes.qrySeekValue("nf", "coalesce(tpdoc.cd_gruponf,'')cd_gruponf", "nf.cd_empresa = '" + Acesso.CD_EMPRESA + "' and nf.cd_nfseq = '" + sNota + "'");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool NumeroExistente(string Cdnotafis, string Nfseq)
        {
            string sQueryValida = "Select count(nf.cd_notafis)cd_notafis from nf where nf.cd_empresa = '" + Acesso.CD_EMPRESA +
                     "' and  nf.cd_notafis = '" + Cdnotafis +
                     "' and nf.cd_gruponf = " +
                     " (select nf.cd_gruponf from nf where nf.cd_empresa = '" + Acesso.CD_EMPRESA +
                     "' and  nf.cd_nfseq = '" + Nfseq + "')";

            if (Convert.ToInt16(HlpDbFuncoes.qrySeekRet(sQueryValida).Rows[0]["cd_notafis"]) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void AlteraEmpresaParaHomologacao()
        {
            try
            {
                StringBuilder sSql = new StringBuilder();
                sSql.Append("update empresa set st_ambiente = '2' ");// o.s.23984 - 07/01/2010
                sSql.Append("Where empresa.cd_empresa = '");
                sSql.Append(Acesso.CD_EMPRESA);
                sSql.Append("'");
                HlpDbFuncoes.qrySeek(sSql.ToString());
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void VerificaNumeracaoExistente(List<HLP.GeraXml.dao.NFe.daoNumeroNF.DadosGerar> objNumeroNfs)
        {
            for (int i = 0; i < objNumeroNfs.Count; i++)
            {
                string sValor = HLP.GeraXml.dao.ADO.HlpDbFuncoes.qrySeekValue("nf",
                                                                "count(nf.cd_notafis)",
                                                                "nf.cd_empresa = '" + Acesso.CD_EMPRESA +
                                                                     "' and  nf.cd_notafis = '" + objNumeroNfs[i].nNF.ToString() +
                                                                     "' and nf.cd_gruponf = " +
                                                                     " (select nf.cd_gruponf from nf where nf.cd_empresa = '" + Acesso.CD_EMPRESA +
                                                                     "' and  nf.cd_nfseq = '" + objNumeroNfs[i].seqNF.ToString() + "')");

                if (Convert.ToInt16(sValor) > 0)
                {
                    throw new Exception("O Sistema verificou que existe nota com numeração ja gerada por outro usuário.");
                }
            }
        }

        public static bool VerificaSeAgrupaItens()
        {
            try
            {
                string sValor = HLP.GeraXml.dao.ADO.HlpDbFuncoes.qrySeekValue("control", "control.cd_conteud", "control.cd_nivel = '1350'");
                return (sValor.Equals("S") ? true : false);
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
