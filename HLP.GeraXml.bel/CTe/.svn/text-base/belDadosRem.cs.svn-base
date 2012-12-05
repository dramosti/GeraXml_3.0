using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HLP.GeraXml.dao.CTe;
using System.Data;
using HLP.GeraXml.bel.CTe.infCte.rem;
using HLP.GeraXml.Comum.Static;

namespace HLP.GeraXml.bel.CTe
{
    public class belDadosRem : daoDadosRem
    {
        public void PopulaRem(belinfCte objbelinfCte, string sCte)
        {
            try
            {
                DataTable dt = BuscaDadosRem(sCte);

                foreach (DataRow dr in dt.Rows)
                {

                    objbelinfCte.rem = new belrem();
                    objbelinfCte.rem.enderReme = new belenderReme();


                    objbelinfCte.rem.CNPJ = Util.TiraSimbolo(dr["CNPJ"].ToString());
                    objbelinfCte.rem.CPF = Util.TiraSimbolo(dr["CPF"].ToString());
                    objbelinfCte.rem.IE = Util.TiraSimbolo(dr["IE"].ToString());
                    objbelinfCte.rem.xNome = Util.TiraSimbolo(dr["xNome"].ToString(), "");
                    objbelinfCte.rem.xFant = Util.TiraSimbolo(dr["xFant"].ToString(), "");
                    objbelinfCte.rem.fone = Util.TiraSimbolo(dr["fone"].ToString());

                    objbelinfCte.rem.enderReme.xLgr = Util.TiraSimbolo(dr["xLgr"].ToString(), "");
                    objbelinfCte.rem.enderReme.nro = dr["nro"].ToString();
                    objbelinfCte.rem.enderReme.xBairro = Util.TiraSimbolo(dr["xBairro"].ToString(), "");
                    objbelinfCte.rem.enderReme.xMun = Util.TiraSimbolo(dr["xMun"].ToString(), "");
                    objbelinfCte.rem.enderReme.UF = dr["UF"].ToString();
                    objbelinfCte.rem.enderReme.cMun = dr["cMun"].ToString();
                    objbelinfCte.rem.enderReme.CEP = Util.TiraSimbolo(dr["CEP"].ToString());
                    objbelinfCte.rem.enderReme.xPais = "Brasil";
                    objbelinfCte.rem.enderReme.cPais = "1058";

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }



        }
    }
}
