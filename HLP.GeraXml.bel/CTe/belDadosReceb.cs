using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HLP.GeraXml.dao.CTe;
using System.Data;
using HLP.GeraXml.bel.CTe.infCte.receb;
using HLP.GeraXml.Comum.Static;

namespace HLP.GeraXml.bel.CTe
{
    public class belDadosReceb : daoDadosReceb
    {
        public void PopulaReceb(belinfCte objbelinfCte, string sCte)
        {
            try
            {
                string sCodConsig = BuscaDadosReceb(sCte);

                if (sCodConsig != "")
                {
                    DataTable dt = BuscaDadosConsig(sCodConsig);


                    objbelinfCte.receb = new belreceb();
                    objbelinfCte.receb.enderReceb = new belenderReceb();

                    foreach (DataRow dr in dt.Rows)
                    {
                        objbelinfCte.ide.tpServ = 2;

                        objbelinfCte.receb.CNPJ = Util.TiraSimbolo(dr["CNPJ"].ToString());
                        objbelinfCte.receb.CPF = Util.TiraSimbolo(dr["CPF"].ToString());
                        objbelinfCte.receb.IE = Util.TiraSimbolo(dr["IE"].ToString());
                        objbelinfCte.receb.xNome = Util.TiraSimbolo(dr["xNome"].ToString(), "");
                        objbelinfCte.receb.fone = Util.TiraSimbolo(dr["fone"].ToString());

                        objbelinfCte.receb.enderReceb.xLgr = Util.TiraSimbolo(dr["xLgr"].ToString(), "");
                        objbelinfCte.receb.enderReceb.nro = dr["nro"].ToString();
                        objbelinfCte.receb.enderReceb.xBairro = Util.TiraSimbolo(dr["xBairro"].ToString(), "");
                        objbelinfCte.receb.enderReceb.xMun = Util.TiraSimbolo(dr["xMun"].ToString(), "");
                        objbelinfCte.receb.enderReceb.CEP = Util.TiraSimbolo(dr["CEP"].ToString());
                        objbelinfCte.receb.enderReceb.UF = dr["UF"].ToString();
                        objbelinfCte.receb.enderReceb.cMun = dr["cMun"].ToString();
                        objbelinfCte.receb.enderReceb.xPais = "Brasil";
                        objbelinfCte.receb.enderReceb.cPais = "1058";
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
