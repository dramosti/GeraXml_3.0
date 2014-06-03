using HLP.GeraXml.Comum.Static;
using HLP.GeraXml.dao.ADO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HLP.GeraXml.dao.CTe
{
    public class daoGeraNumero
    {
        public void AtualizaGenerator(string sValue)
        {
            try
            {
                string sGenerator = "";
                if (Acesso.NM_EMPRESA.ToUpper().Equals("SICUPIRA") || Acesso.NM_EMPRESA.ToUpper().Equals("TRANSLILO") || Acesso.NM_EMPRESA.ToUpper().Equals("GCA"))
                {
                    sGenerator = "CONHECIM_CTE" + Acesso.CD_EMPRESA; ;
                }
                else
                {
                    sGenerator = "CONHECIM_CTE";
                }

                string sQuery = "SET GENERATOR " + sGenerator + " TO " + sValue;

                HlpDbFuncoes.qrySeekReader(sQuery);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
