using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HLP.GeraXml.dao.ADO;
using System.Data;
using System.IO;
using HLP.GeraXml.Comum.Static;

namespace HLP.GeraXml.dao
{
    public class daoEmailContador
    {
        public static bool VerificaEmailContador()
        {
            try
            {
                DataTable dt = HlpDbFuncoes.qrySeekRet("EMPRESA", "coalesce(empresa.cd_emailcont,'')cd_emailcont ,  empresa.nm_empresa", "empresa.cd_empresa = '" + Acesso.CD_EMPRESA + "'");
                string sEmailCont = "";

                foreach (DataRow dr in dt.Rows)
                {
                    sEmailCont = dt.Rows[0]["cd_emailcont"].ToString();
                }
                Acesso.EMAIL_CONTADOR = sEmailCont;
                return sEmailCont == "" ? false : true;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool VerificaDiaParaEnviarEmail()
        {
            bool bAvisa = false;
            DirectoryInfo dinfo = new DirectoryInfo(Pastas.ENVIADOS + "\\Contador_xml");
            if (dinfo.Exists)
            {
                string sCaminhoXml = dinfo.FullName + "\\" + "ConfigDia.txt";
                if (File.Exists(sCaminhoXml))
                {
                    FileStream arquivo = File.Open(sCaminhoXml, FileMode.Open);

                    StreamReader reader = new StreamReader(arquivo);

                    string sDia = reader.ReadToEnd().Trim();

                    reader.Close();

                    if (sDia == "month")
                    {
                        if (DateTime.Now.Day.ToString().Equals("1"))
                        {
                            bAvisa = true;
                        }
                    }
                    else if (DateTime.Now.DayOfWeek.ToString().Equals(sDia))
                    {
                        bAvisa = true;
                    }

                }
            }
            return bAvisa;
        }
    }
}
