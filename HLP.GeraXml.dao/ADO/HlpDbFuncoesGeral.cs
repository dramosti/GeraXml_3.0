using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using FirebirdSql.Data.FirebirdClient;
using HLP.GeraXml.Comum.Static;

namespace HLP.GeraXml.dao.ADO
{
    public class HlpDbFuncoesGeral
    {
        public static DataTable QrySeekRet(FbConnection conexao,
         string sExpressaoSql)
        {
            try
            {
                FbDataAdapter da = new FbDataAdapter(sExpressaoSql, conexao);
                if (conexao.State != ConnectionState.Open)
                    conexao.Open();
                DataSet ds = new DataSet("dadoshlp");
                da.Fill(ds, "registro");
                DataTable dt = ds.Tables[0];
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexao.Close();
            }
        }

        public static void QrySeekUpdate(FbConnection conexao,
        string sExpressaoSql)
        {
            try
            {
                FbCommand cmdUpDateMoviPend = new FbCommand();
                cmdUpDateMoviPend.CommandText = sExpressaoSql;
                cmdUpDateMoviPend.Connection = conexao;
                if (conexao.State != ConnectionState.Open)
                    conexao.Open();
                cmdUpDateMoviPend.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexao.Close();
            }

        }

        public static void QrySeekInsert(FbConnection conexao,
       string sExpressaoSql)
        {
            try
            {
                FbCommand cmdUpDateMoviPend = new FbCommand();
                cmdUpDateMoviPend.CommandText = sExpressaoSql;
                cmdUpDateMoviPend.Connection = conexao;
                if (conexao.State != ConnectionState.Open)
                    conexao.Open();
                cmdUpDateMoviPend.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexao.Close();
            }

        }

        public static FbDataReader QrySeekReader(FbConnection conexao,
    string sExpressaoSql)
        {
            try
            {
                FbCommand cmd = new FbCommand();
                cmd.CommandText = sExpressaoSql;
                cmd.Connection = conexao;
                if (conexao.State != ConnectionState.Open)
                    conexao.Open();

                FbDataReader Reader = cmd.ExecuteReader();

                return Reader;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexao.Close();
            }
        }

        public static string MontaStringConexao()
        {
            try
            {
                StringBuilder sbConexao = new StringBuilder();
                sbConexao.Append("User =");
                sbConexao.Append("SYSDBA");
                sbConexao.Append(";");
                sbConexao.Append("Password=");
                sbConexao.Append("masterkey");
                sbConexao.Append(";");
                string sPorta = Acesso.PORTA;
                if (sPorta.Trim() != "")
                {
                    sbConexao.Append("Port=" + sPorta + ";");
                }
                sbConexao.Append("Database=");
                string sdatabase = Acesso.CAMINHO_BANCO_DADOS;
                sbConexao.Append(sdatabase);
                sbConexao.Append(";");
                sbConexao.Append("DataSource=");
                sbConexao.Append(Acesso.NM_SERVIDOR);
                sbConexao.Append(";");
                sbConexao.Append("Dialect=3; Charset=NONE;Role=;Connection lifetime=15;Pooling=true; MinPoolSize=0;MaxPoolSize=2000;Packet Size=8192;ServerType=0;");
                return (string)sbConexao.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static FbConnection _conexao;
        public static FbConnection conexao
        {
            get
            {
                //if (HlpDbFuncoesGeral._conexao == null)
                //{
                //    HlpDbFuncoesGeral._conexao = new FbConnection(MontaStringConexao());
                //}
                //return HlpDbFuncoesGeral._conexao;
                return new FbConnection(MontaStringConexao());
            }
            set
            {
                HlpDbFuncoesGeral._conexao = value;
            }
        }

        public static void NovaConexao()
        {
            HlpDbFuncoesGeral._conexao = null;
        }

    }
}
