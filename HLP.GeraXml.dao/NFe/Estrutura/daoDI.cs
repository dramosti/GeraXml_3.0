using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HLP.GeraXml.Comum.Static;

namespace HLP.GeraXml.dao.NFe.Estrutura
{
    public class daoDI
    {
        public DataTable BuscaDI(string snrLanc)
        {
            try
            {
                StringBuilder sQuery = new StringBuilder();
                sQuery.Append("select ");
                sQuery.Append("impdecla.nr_lanc, ");
                sQuery.Append("impdecla.cd_empresa, ");
                sQuery.Append("coalesce(impdecla.nr_di,'') nDI, ");
                sQuery.Append("coalesce(impdecla.dt_di,'') dDI, ");
                sQuery.Append("coalesce(impdecla.ds_localdesemb ,'') xLocDesemb, ");
                sQuery.Append("coalesce(impdecla.uf_desemb,'') UFDesemb, ");
                sQuery.Append("coalesce(impdecla.dt_desemb ,'')dDesemb, ");
                sQuery.Append("coalesce(impdecla.cd_exportador,'') cExportador ");
                sQuery.Append("from impdecla ");
                sQuery.Append("where impdecla.nr_lancmovitem = '" + snrLanc + "' ");
                sQuery.Append("and impdecla.cd_empresa = '" + Acesso.CD_EMPRESA + "' ");
                return HLP.GeraXml.dao.ADO.HlpDbFuncoes.qrySeekRet(sQuery.ToString());
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable BuscaADI(string snrLanc)
        {
            try
            {
                StringBuilder sQuery = new StringBuilder();
                sQuery.Append("select ");
                sQuery.Append("impadica.nr_lanc, ");
                sQuery.Append("impadica.nr_lancimpdecla,");
                sQuery.Append("coalesce(impadica.nr_adicao,'0') nAdicao, ");
                sQuery.Append("coalesce(impadica.nr_lanc,'0') nSeqAdic, ");
                sQuery.Append(" coalesce(impadica.cd_fabricante,'') cFabricante, ");
                sQuery.Append(" coalesce(impadica.vl_descdi,'0') vDescDI ");
                sQuery.Append("from impadica ");
                sQuery.Append("where impadica.nr_lancimpdecla = '" + snrLanc + "' ");
                sQuery.Append("and impadica.cd_empresa = '" + Acesso.CD_EMPRESA + "' ");
                return HLP.GeraXml.dao.ADO.HlpDbFuncoes.qrySeekRet(sQuery.ToString());
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
