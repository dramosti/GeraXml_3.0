using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HLP.GeraXml.dao.CTe;
using System.Data;
using HLP.GeraXml.bel.CTe.infCte.exped;
using HLP.GeraXml.Comum.Static;

namespace HLP.GeraXml.bel.CTe
{
    public class belDadosExped : daoDadosExped
    {
        public void PopulaExped(belinfCte objbelinfCte, string sCte)
        {
            try
            {
                string sCodRedes = BuscaDadosExped(sCte);

                if (sCodRedes != "")
                {
                    DataTable dt = BuscaDadosRedes(sCodRedes);


                    objbelinfCte.exped = new belexped();
                    objbelinfCte.exped.enderExped = new belenderExped();
                    foreach (DataRow dr in dt.Rows)
                    {
                        objbelinfCte.ide.tpServ = 2;

                        objbelinfCte.exped.CNPJ = Util.TiraSimbolo(dr["CNPJ"].ToString());
                        objbelinfCte.exped.CPF = Util.TiraSimbolo(dr["CPF"].ToString());
                        objbelinfCte.exped.IE = Util.TiraSimbolo(dr["IE"].ToString());
                        objbelinfCte.exped.xNome = Util.TiraSimbolo(dr["xNome"].ToString(), "");
                        objbelinfCte.exped.fone = Util.TiraSimbolo(dr["fone"].ToString());
                        objbelinfCte.exped.enderExped.xLgr = Util.TiraSimbolo(dr["xLgr"].ToString(), "");
                        objbelinfCte.exped.enderExped.nro = dr["nro"].ToString();
                        objbelinfCte.exped.enderExped.xBairro = Util.TiraSimbolo(dr["xBairro"].ToString(), "");
                        objbelinfCte.exped.enderExped.xMun = Util.TiraSimbolo(dr["xMun"].ToString(), "");
                        objbelinfCte.exped.enderExped.CEP = Util.TiraSimbolo(dr["CEP"].ToString());
                        objbelinfCte.exped.enderExped.UF = dr["UF"].ToString();
                        objbelinfCte.exped.enderExped.cMun = dr["cMun"].ToString();
                        objbelinfCte.exped.enderExped.xPais = "Brasil";
                        objbelinfCte.exped.enderExped.cPais = "1058";
                    }
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }



        }
    }
}
