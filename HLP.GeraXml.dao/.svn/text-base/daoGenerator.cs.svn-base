using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FirebirdSql.Data.FirebirdClient;
using System.Data;
using HLP.GeraXml.dao.ADO;

namespace HLP.GeraXml.dao
{
    public class daoGenerator
    {
        public bool VerificaExistenciaGenerator(string sNomeGen)
        {
            FbConnection con = HlpDbFuncoesGeral.conexao;
            try
            {
                StringBuilder sQuery = new StringBuilder();
                sQuery.Append("SELECT RDB$GENERATORS.RDB$GENERATOR_NAME ");
                sQuery.Append("FROM RDB$GENERATORS ");
                sQuery.Append("WHERE (RDB$GENERATORS.RDB$GENERATOR_NAME = '" + sNomeGen + "')");
                FbCommand command = new FbCommand(sQuery.ToString(), con);
                con.Open();
                return (command.ExecuteScalar().ToString().Trim() != "" ? true : false);
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                con.Close();
            }

        }

        public void CreateGenerator(string sNomeGen, int iValorIni)
        {
            FbConnection con = HlpDbFuncoesGeral.conexao;
            try
            {
                StringBuilder sQuery = new StringBuilder();
                sQuery.Append(" CREATE GENERATOR " + sNomeGen);
                FbCommand Command = new FbCommand(sQuery.ToString(), con);
                con.Open();
                Command.ExecuteNonQuery();
                sQuery = new StringBuilder();
                sQuery.Append(" SET GENERATOR " + sNomeGen + " TO " + iValorIni.ToString());
                Command = new FbCommand(sQuery.ToString(), con);
                Command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                con.Close();
            }

        }

        public string RetornaUltimoValorGenerator(string sNomeGernerator)
        {
            FbConnection con = HlpDbFuncoesGeral.conexao;
            try
            {
                StringBuilder sSql = new StringBuilder();
                sSql.Append("Select ");
                sSql.Append("gen_id(" + sNomeGernerator.ToUpper() + ", 0) ");
                sSql.Append("from rdb$database");
                string sValor;
                FbCommand cmd = new FbCommand(sSql.ToString(), con);

                con.Open();
                sValor = cmd.ExecuteScalar().ToString();
                return sValor;

            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                con.Close();
            }

        }

        public string RetornaProximoValorGenerator(string sNomeGernerator)
        {
            FbConnection con = HlpDbFuncoesGeral.conexao;
            try
            {
                string sNumArq = "";
                FbCommand sSql = new FbCommand();
                sSql.Connection = con;
                sSql.CommandText = "SP_CHAVEPRI";
                sSql.CommandType = CommandType.StoredProcedure;
                sSql.Parameters.Clear();

                sSql.Parameters.Add("@SNOMEGENERATOR", FbDbType.VarChar, 31).Value = sNomeGernerator;
                con.Open();
                sNumArq = sSql.ExecuteScalar().ToString();
                return sNumArq;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }

        }
    }
}
