using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using FirebirdSql.Data.FirebirdClient;
using HLP.GeraXml.Comum.Static;

namespace HLP.GeraXml.dao.ADO
{
    public static class HlpDbFuncoes
    {

        public static DataTable qrySeekRet(string sExpressao)
        {
            DataTable dt = HlpDbFuncoesGeral.QrySeekRet(HlpDbFuncoesGeral.conexao, sExpressao);
            return dt;
        }

        public static FbDataReader qrySeekReader(string sExpressao)
        {
            FbDataReader dr = HlpDbFuncoesGeral.QrySeekReader(HlpDbFuncoesGeral.conexao, sExpressao);
            return dr;
        }

        public static DataTable qrySeekRet(string sTabela, string sCampos = "", List<ListaCampos> lCampos = null)
        {
            if (lCampos != null)
            {
                sCampos = MontaStringCampos(lCampos);
            }
            return (qrySeekRet(sTabela, sCampos, String.Empty, String.Empty));
        }

        public static DataTable qrySeekRet(string sTabela, string sCampos, string sWhere, List<ListaCampos> lCampos = null)
        {
            if (lCampos != null)
            {
                sCampos = MontaStringCampos(lCampos);
            }
            return (qrySeekRet(sTabela, sCampos, sWhere, String.Empty));
        }

        public static DataTable qrySeekRet(string sTabela, string sCampos, string sWhere, string sOrdem, List<ListaCampos> lCampos = null)
        {
            if (lCampos != null)
            {
                sCampos = MontaStringCampos(lCampos);
            }
            StringBuilder strExpressao = new StringBuilder();
            strExpressao.Append("SELECT ");
            if (sCampos.Trim() == String.Empty)
                strExpressao.Append("*");
            else
                strExpressao.Append(sCampos);
            strExpressao.Append(" FROM " + sTabela);

            StringBuilder strWhere = new StringBuilder();
            if ((sWhere != null) && (sWhere.Trim() != String.Empty))
                strWhere.Append(sWhere);
            if ((fExisteCampo(sTabela, "CD_EMPRESA")) &&
                (sWhere.ToUpper().IndexOf("CD_EMPRESA") < 0))
            {
                if (strWhere.Length > 0)
                    strWhere.Append(" AND ");
                strWhere.Append("(CD_EMPRESA = '" + Acesso.CD_EMPRESA + "')");
            }
            if (strWhere.Length > 0)
            {
                strWhere.Insert(0, " WHERE ");
                strExpressao.Append(strWhere.ToString());
            }

            if ((sOrdem != null) && (sOrdem.Trim() != String.Empty))
                strExpressao.Append(" ORDER BY " + sOrdem);

            DataTable dt = HlpDbFuncoesGeral.QrySeekRet(HlpDbFuncoesGeral.conexao, strExpressao.ToString());
            return dt;
        }

        public static string qrySeekValue(string sTabela, string sCampo,
            string sWhere)
        {
            return qrySeekValue(sTabela, sCampo, sWhere, false);
        }

        private static string qrySeekValue(string sTabela, string sCampo,
            string sWhere, bool bGeraErroSemRegistros)
        {

            DataTable dt = qrySeekRet(sTabela, sCampo, sWhere, null);
            String svalor = null;
            if (dt.Rows.Count > 0)
            {
                DataRow registro = dt.Rows[0];
                //svalor = registro[sCampo].ToString();
                svalor = registro[0].ToString();
            }
            else
            {
                if (bGeraErroSemRegistros)
                    throw new Exception("Não foram encontrados registros válidos!");
            }
            if (svalor == null)
                svalor = String.Empty;
            return svalor;
        }

        public static bool qrySeek(string sTabela, string[] sCampos, string[] sValores)
        {
            StringBuilder strCampos = new StringBuilder();
            StringBuilder strWhere = new StringBuilder();
            string sCampo;

            for (int i = 0; i < sCampos.Length; i++)
            {
                if (strCampos.Length > 0)
                {
                    strCampos.Append(", ");
                    strWhere.Append(" AND ");
                }
                sCampo = sCampos[i];
                strCampos.Append(sCampo);
                strWhere.Append("(" + sCampo + " = '" + sValores[i].Trim() + "')");
            }

            DataTable dt = qrySeekRet(sTabela, strWhere.ToString(), strCampos.ToString(), null);

            return (dt.Rows.Count > 0);
        }

        public static bool qrySeek(string sExpressao)
        {
            DataTable dt = qrySeekRet(sExpressao);
            return (dt.Rows.Count > 0);
        }

        public static void qrySeekUpdate(string sExpressao)
        {
            HlpDbFuncoesGeral.QrySeekUpdate(HlpDbFuncoesGeral.conexao, sExpressao);
        }

        public static void qrySeekInsert(string sExpressao)
        {
            HlpDbFuncoesGeral.QrySeekInsert(HlpDbFuncoesGeral.conexao, sExpressao);
        }

        public static bool fExisteCampo(string sNomeCampo, string sTabela)
        {
            try
            {
                string sQuery = "SELECT " +
                "RDB$FIELD_NAME CAMPO " +
                "FROM " +
                "RDB$RELATION_FIELDS " +
                "WHERE " +
                " RDB$FIELD_NAME = '{0}' AND" +
                " RDB$RELATION_NAME = '{1}'";

                FbConnection cx = HlpDbFuncoesGeral.conexao;
                if (cx.State != ConnectionState.Open)
                {
                    cx.Open();
                }
                FbCommand cmd = new FbCommand(string.Format(sQuery, sNomeCampo.ToUpper(), sTabela.ToUpper()), cx);
                object iResult = cmd.ExecuteScalar();
                cx.Close();
                if (iResult == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public struct ListaCampos
        {
            public string sCampo { get; set; }
            public string sCoalesce { get; set; }
            public string sAlias { get; set; }
        }

        private static string MontaStringCampos(List<ListaCampos> objlCampos)
        {
            string sCampos = string.Empty;

            foreach (ListaCampos item in objlCampos)
            {
                string Campo = item.sCampo == "" ? "''" : item.sCampo;

                sCampos += (item.sCoalesce == null ? Campo :
                    string.Format("coalesce({0},'{1}')",
                    Campo, item.sCoalesce)) + " " + (item.sAlias == null ? Campo : item.sAlias) + ",";
            }
            sCampos = sCampos.Remove(sCampos.Length - 1, 1);
            return sCampos;
        }

    }
}
