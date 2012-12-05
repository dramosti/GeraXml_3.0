using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HLP.GeraXml.dao.CTe;
using System.Data;

namespace HLP.GeraXml.bel.CTe
{
    public class belNumeroCte : daoNumeroCte
    {
        public string nfSeq { get; set; }
        public string cdConhec { get; set; }

        public List<belNumeroCte> GeraNumerosConhecimentos(List<string> lsSeq, string sNumAserEmiti)
        {
            try
            {
                List<belNumeroCte> objlbelNumConhec = new List<belNumeroCte>();
                belNumeroCte objbelNumConhec = null;
                int iCdConhec = Convert.ToInt32(sNumAserEmiti);

                DataTable dt = BuscaDadosNumerosConhecimentos(lsSeq, sNumAserEmiti);
                foreach (DataRow  dr in dt.Rows)
                {
                    objbelNumConhec = new belNumeroCte();
                    objbelNumConhec.nfSeq = dr["nr_lanc"].ToString();
                    objbelNumConhec.cdConhec = iCdConhec.ToString();
                    objlbelNumConhec.Add(objbelNumConhec);
                    iCdConhec++;
                }
                
                return objlbelNumConhec;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }


    }
}
