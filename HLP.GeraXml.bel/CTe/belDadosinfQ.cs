using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HLP.GeraXml.dao.CTe;
using System.Data;
using HLP.GeraXml.bel.CTe.infCte.infCTeNorm;

namespace HLP.GeraXml.bel.CTe
{
    public class belDadosinfQ : daoDadosinfQ
    {
        public void PopulainfQ(belinfCte objbelinfCte, string sCte)
        {
            try
            {
                DataTable dt = BuscaDadosinfQ(sCte);

                if (objbelinfCte.infCTeNorm == null)
                {
                    objbelinfCte.infCTeNorm = new belinfCTeNorm();
                    objbelinfCte.infCTeNorm.infCarga = new belinfCarga();
                }
                objbelinfCte.infCTeNorm.infCarga.infQ = new List<belinfQ>();

                foreach (DataRow dr in dt.Rows)
                {
                    //belinfQ objinfQ = new belinfQ();
                    //objinfQ.cUnid = dr["cUnid"].ToString();
                    //objinfQ.tpMed = dr["tpMed"].ToString();
                    //objinfQ.qCarga = Convert.ToDecimal(dr["qCarga"].ToString().Replace(".", ","));
                    //objbelinfCte.infCTeNorm.infCarga.infQ.Add(objinfQ);

                    belinfQ objinfQ = new belinfQ();
                    objinfQ.cUnid = "00";
                    objinfQ.tpMed = dr["tpMed"].ToString().ToUpper();
                    objinfQ.qCarga = Convert.ToDecimal(dr["qCarga_Volume"].ToString().Replace(".", ","));
                    objbelinfCte.infCTeNorm.infCarga.infQ.Add(objinfQ);

                    objinfQ = new belinfQ();
                    objinfQ.cUnid = dr["cUnid"].ToString();
                    objinfQ.tpMed = "PESO";
                    objinfQ.qCarga = Convert.ToDecimal(dr["qCarga_Peso"].ToString().Replace(".", ","));
                    objbelinfCte.infCTeNorm.infCarga.infQ.Add(objinfQ);


                }
            }
            catch (Exception ex)
            {
                throw ex;
            }



        }
    }
}
