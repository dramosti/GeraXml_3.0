using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HLP.GeraXml.dao.CTe;
using System.Data;
using HLP.GeraXml.bel.CTe.infCte.infCTeNorm;
using HLP.GeraXml.Comum.Static;

namespace HLP.GeraXml.bel.CTe
{
    public class belDadosinfCarga : daoDadosinfCarga
    {
        public void PopulainfCarga(belinfCte objbelinfCte, string sCte)
        {
            try
            {
                DataTable dt = BuscaDadosinfCarga(sCte);

                //objbelinfCte.infCTeNorm = new belinfCTeNorm();
                objbelinfCte.infCTeNorm.infCarga = new belinfCarga();

                foreach (DataRow dr in dt.Rows)
                {
                    objbelinfCte.infCTeNorm.infCarga.vCarga += Convert.ToDecimal(dr["vMerc"].ToString().Replace(".", ","));
                    objbelinfCte.infCTeNorm.infCarga.proPred = Util.TiraSimbolo(dr["proPred"].ToString(), "");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
