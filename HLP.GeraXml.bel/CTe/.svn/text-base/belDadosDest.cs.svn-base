using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HLP.GeraXml.dao.CTe;
using System.Data;
using HLP.GeraXml.bel.CTe.infCte.dest;
using HLP.GeraXml.Comum.Static;

namespace HLP.GeraXml.bel.CTe
{
    public class belDadosDest : daoDadosDest
    {
        public void PopulaDest(belinfCte objbelinfCte, string sCte)
        {
            try
            {
                DataTable dt = BuscaDadosDest(sCte);
                foreach (DataRow dr in dt.Rows)
                {
                    objbelinfCte.dest = new beldest();
                    objbelinfCte.dest.enderDest = new belenderDest();


                    objbelinfCte.dest.CNPJ = Util.TiraSimbolo(dr["CNPJ"].ToString());
                    objbelinfCte.dest.CPF = Util.TiraSimbolo(dr["CPF"].ToString());
                    objbelinfCte.dest.IE = Util.TiraSimbolo(dr["IE"].ToString());
                    objbelinfCte.dest.xNome = Util.TiraSimbolo(dr["xNome"].ToString(), "");
                    objbelinfCte.dest.fone = Util.TiraSimbolo(dr["fone"].ToString());
                    objbelinfCte.dest.ISUF = dr["ISUF"].ToString();

                    objbelinfCte.dest.enderDest.xLgr = Util.TiraSimbolo(dr["xLgr"].ToString(), "");
                    objbelinfCte.dest.enderDest.nro = dr["nro"].ToString();
                    objbelinfCte.dest.enderDest.xBairro = Util.TiraSimbolo(dr["xBairro"].ToString(), "");
                    objbelinfCte.dest.enderDest.xMun = Util.TiraSimbolo(dr["xMun"].ToString(), "");
                    objbelinfCte.dest.enderDest.UF = dr["UF"].ToString();
                    objbelinfCte.dest.enderDest.cMun = dr["cMun"].ToString();
                    objbelinfCte.dest.enderDest.CEP = Util.TiraSimbolo(dr["CEP"].ToString());
                    objbelinfCte.dest.enderDest.xPais = "Brasil";
                    objbelinfCte.dest.enderDest.cPais = "1058";

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }



        }
    }
}
