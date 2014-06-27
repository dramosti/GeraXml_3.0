using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HLP.GeraXml.dao.ADO;
using HLP.GeraXml.Comum.Static;
using System.Data;
using FirebirdSql.Data.FirebirdClient;

namespace HLP.GeraXml.dao.CTe
{
    public class daoNumeroCte
    {
        public string BuscaUltimoNumeroConhecimento()
        {

            try
            {
                string sQuery = "";
                if (Acesso.NM_EMPRESA.ToUpper().Equals("SICUPIRA") || Acesso.NM_EMPRESA.ToUpper().Equals("TRANSLILO") || Acesso.NM_EMPRESA.ToUpper().Equals("GCA"))
                {
                    string sGenerator = "CONHECIM_CTE" + Acesso.CD_EMPRESA;
                    sQuery = "SELECT GEN_ID(" + sGenerator + ", 0 ) FROM RDB$DATABASE";                    
                }
                else
                {
                    sQuery = "select max(c.cd_conheci) from conhecim c where c.cd_empresa = '" + Acesso.CD_EMPRESA + "'";                    
                }
                return HlpDbFuncoes.qrySeekRet(sQuery).Rows[0][0].ToString(); ;
            }
            catch (Exception ex)
            {
                throw ex;
            }           

        }

        public DataTable BuscaDadosNumerosConhecimentos(List<string> lsSeq, string sNumAserEmiti)
        {
            try
            {
                StringBuilder sQuery = new StringBuilder();
                sQuery.Append("select c.nr_lanc from conhecim c ");
                sQuery.Append("where ((c.cd_conheci is null) or (c.cd_conheci = '')) ");
                sQuery.Append("and");
                sQuery.Append("((c.cd_empresa = '" + Acesso.CD_EMPRESA + "') and ");
                sQuery.Append("(c.nr_lanc in ('");
                int iCont = 0;
                foreach (var sSeq in lsSeq)
                {
                    iCont++;
                    sQuery.Append(sSeq);
                    if (lsSeq.Count > iCont)
                    {
                        sQuery.Append("','");
                    }
                }
                sQuery.Append("')))");
                sQuery.Append(" order by  c.nr_lanc");

                return HlpDbFuncoes.qrySeekRet(sQuery.ToString());

            }
            catch (Exception ex)
            {
                throw ex;
            }


        }



        public void GravaConhec(string sequencia, string numero)
        {
            try
            {
                string sQuery = string.Empty;

                if (Acesso.NM_EMPRESA.ToUpper().Equals("SICUPIRA"))
                {
                    sQuery = "update conhecim set  cd_conheci = '" + sequencia.PadLeft(6, '0') + "' "
                                + "where cd_empresa = '" + Acesso.CD_EMPRESA + "' "
                                + "and nr_lanc = '" + numero.PadLeft(7, '0') + "'";
                }
                else
                {
                    sQuery = "update conhecim set  cd_conheci = '" + sequencia.PadLeft(6, '0') + "' "
                                  + "where cd_empresa = '" + Acesso.CD_EMPRESA + "' "
                                  + "and nr_lanc = '" + numero.PadLeft(7, '0') + "'";
                }

                HlpDbFuncoes.qrySeekUpdate(sQuery);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

      
    }
}
