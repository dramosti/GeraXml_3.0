using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography.X509Certificates;
using FirebirdSql.Data.FirebirdClient;
using System.Data;
using HLP.GeraXml.dao.ADO;
using System.Windows.Forms;


namespace HLP.GeraXml.bel.CTe
{
    public class belPopulaObjetos
    {
        public List<belinfCte> objListaConhecimentos = new List<belinfCte>();
        public string sEmp = "";
        public List<string> objListaNumeroConhecimentos;
        public string sFormEmiss = "";

        public string cUf = "";
        public string sPath = "";
        public string sNomeArq = "";

        public belPopulaObjetos(List<string> objListaNumeroConhecimentos)
        {
            this.objListaNumeroConhecimentos = objListaNumeroConhecimentos;

            sNomeArq = NomeArqCte();
            sPath = Application.StartupPath + @"\Pastas\Envio\" + @sNomeArq;

        }




        private string NomeArqCte()
        {
            FbConnection con = null;
            try
            {
                string sNomeArq = "";
                FbCommand cmd = new FbCommand();
                con = new FbConnection(HlpDbFuncoesGeral.MontaStringConexao());
                cmd.Connection = con;
                con.Open();
                cmd.CommandText = "SP_CHAVEPRI";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();

                cmd.Parameters.Add("@SNOMEGENERATOR", FbDbType.VarChar, 31).Value = "GEN_NOMEARQXML";

                sNomeArq = cmd.ExecuteScalar().ToString();

                return "Cte_" + sEmp + sNomeArq.PadLeft(15, '0') + ".xml";
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
