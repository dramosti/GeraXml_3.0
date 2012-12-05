using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HLP.GeraXml.dao.CTe;
using System.Data;
using HLP.GeraXml.bel.CTe.infCte.emit;
using HLP.GeraXml.Comum.Static;

namespace HLP.GeraXml.bel.CTe
{
    public class belDadosEmit : daoDadosEmit
    {
        public void PopulaEmit(belinfCte objbelinfCte)
        {
            try
            {
                DataTable dt = BuscaDadosEmit();

                foreach (DataRow dr in dt.Rows)
                {
                    objbelinfCte.emit = new belemit();
                    objbelinfCte.emit.enderEmit = new belenderEmit();


                    objbelinfCte.emit.CNPJ = Util.TiraSimbolo(dr["CNPJ"].ToString());
                    objbelinfCte.emit.IE = Util.TiraSimbolo(dr["IE"].ToString());
                    objbelinfCte.emit.xNome = Util.TiraSimbolo(dr["xNome"].ToString(), "");
                    objbelinfCte.emit.xFant = Util.TiraSimbolo(dr["xFant"].ToString(), "");
                    objbelinfCte.emit.enderEmit.xLgr = Util.TiraSimbolo(dr["xLgr"].ToString(), "");
                    objbelinfCte.emit.enderEmit.nro = dr["nro"].ToString();
                    objbelinfCte.emit.enderEmit.xCpl = dr["xCpl"].ToString();
                    objbelinfCte.emit.enderEmit.xBairro = Util.TiraSimbolo(dr["xBairro"].ToString(), "");
                    objbelinfCte.emit.enderEmit.UF = dr["UF"].ToString();
                    objbelinfCte.emit.enderEmit.xMun = Util.TiraSimbolo(dr["xMun"].ToString(), "");
                    objbelinfCte.emit.enderEmit.cMun = dr["cMun"].ToString();
                    objbelinfCte.emit.enderEmit.CEP = dr["CEP"].ToString() != "" ? Util.TiraSimbolo(dr["CEP"].ToString()) : "";
                    if (dr["fone"].ToString() != "")
                    {
                        objbelinfCte.emit.enderEmit.fone = Util.TiraSimbolo(dr["fone"].ToString());
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
