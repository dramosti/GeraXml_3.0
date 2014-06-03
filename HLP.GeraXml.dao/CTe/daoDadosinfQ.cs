using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HLP.GeraXml.dao.ADO;
using HLP.GeraXml.Comum.Static;
using System.Data;

namespace HLP.GeraXml.dao.CTe
{
    public class daoDadosinfQ
    {
        public DataTable BuscaDadosinfQ(string sCte)
        {
            try
            {
                StringBuilder sQuery = new StringBuilder();
                sQuery.Append("Select ");
                sQuery.Append("coalesce(nfconhec.cd_um,'')cUnid, ");
                sQuery.Append("coalesce(nfconhec.ds_especie,'') tpMed, ");
                sQuery.Append("sum(coalesce(nfconhec.vl_volume,'')) qCarga_Volume, ");
                sQuery.Append("sum(coalesce(nfconhec.vl_peso,'')) qCarga_Peso ");
                sQuery.Append("from nfconhec ");
                sQuery.Append("join empresa on nfconhec.cd_empresa = empresa.cd_empresa ");
                sQuery.Append("where nfconhec.nr_lancconhecim ='" + sCte + "'");
                sQuery.Append("and empresa.cd_empresa ='" + Acesso.CD_EMPRESA + "'");
                sQuery.Append("group by  coalesce(nfconhec.cd_um,''), coalesce(nfconhec.ds_especie,'')");


                return HlpDbFuncoes.qrySeekRet(sQuery.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }



        }
    }
}
