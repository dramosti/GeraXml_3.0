using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ComponentFactory.Krypton.Toolkit;
using System.Windows.Forms;
using HLP.GeraXml.Comum.Static;

namespace HLP.GeraXml.Comum
{
    public class HLPexception : Exception
    {


        public HLPexception(System.Exception ex)
            : base(ex.Message)
        {
            string xStackTrace = "";
            if (ex.StackTrace != null)
            {
                xStackTrace = ex.StackTrace.ToString().Trim();
            }
            string xMessage = ex.Message;
            string xInner = (ex.InnerException == null ? string.Empty : ex.InnerException.ToString());
            #region Tratamento

            if (ex.GetType() == typeof(System.Data.SqlClient.SqlException))
            {
                System.Data.SqlClient.SqlException sqlEx = ex as System.Data.SqlClient.SqlException;
                int numero = sqlEx.Number;
                if (numero == 547)
                {
                    if (ex.Message.Contains("DELETE"))
                    {
                        xMessage = "Você não pode excluir este registro porque ele está sendo usado em outra tabela";
                    }
                }
                else if (numero == 3609)
                {
                    string sMessage = "";
                    if (sqlEx.Errors.Count > 1)
                    {
                        for (int i = 0; i < sqlEx.Errors.Count; i++)
                        {
                            if (sqlEx.Errors[i].Number == 50000)
                            {
                                sMessage = sqlEx.Errors[i].Message;
                            }
                        }
                    }
                    if (sMessage == "")
                    {
                        sMessage = sqlEx.Message;
                    }
                }
            }
            #endregion

            FormException frmEx = new FormException(xMessage, xInner, xStackTrace);
            frmEx.ShowDialog();
        }
    }
}
