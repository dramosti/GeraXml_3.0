using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HLP.GeraXml.dao.ADO;
using HLP.GeraXml.Comum.Static;
using System.Data;

namespace HLP.GeraXml.dao.CTe
{
    public class daoDadosVPrest
    {
        public DataTable BuscaDadosVPrest(string sCte)
        {
            try
            {
                StringBuilder sQuery = new StringBuilder();

                sQuery.Append("Select ");
                sQuery.Append("coalesce (conhecim.vl_total,'') vTPrest, ");
                sQuery.Append("coalesce (conhecim.vl_gris,'0.00') vl_gris, ");
                sQuery.Append("coalesce (conhecim.vl_vladic,'0.00') vl_vladic, ");
                sQuery.Append("coalesce (conhecim.vl_frcubagem,'') FRETECUBAGEM, ");
                sQuery.Append("coalesce (conhecim.vl_frpeso,'') FRETEPESO, ");
                sQuery.Append("coalesce (conhecim.vl_cat,'') CAT, ");
                sQuery.Append("coalesce (conhecim.vl_desp,'') DESPACHO, ");
                sQuery.Append("coalesce (conhecim.vl_pedagio,'') PEDAGIO, ");
                sQuery.Append("coalesce (conhecim.vl_outros,'') OUTROS, ");
                sQuery.Append("coalesce (conhecim.vl_adval,'') ADME, ");
                sQuery.Append("coalesce (conhecim.vl_entcole,'') ENTREGA, ");
                sQuery.Append("coalesce (conhecim.vl_frvalor,'') FRETEVALOR ");
                sQuery.Append("From conhecim  ");
                sQuery.Append("join  empresa on conhecim.cd_empresa = empresa.cd_empresa ");
                sQuery.Append("Where conhecim.nr_lanc = '" + sCte + "'");
                sQuery.Append("And empresa.cd_empresa = '" + Acesso.CD_EMPRESA + "'");


                return HlpDbFuncoes.qrySeekRet(sQuery.ToString());

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
