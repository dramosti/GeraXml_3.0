using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HLP.GeraXml.Comum.Static;
using HLP.GeraXml.dao.ADO;

namespace HLP.GeraXml.dao.NFes
{
    public class daoPrestador
    {
        public DataTable BuscaDadosPrestador()
        {
            try
            {
                StringBuilder sQuery = new StringBuilder();
                sQuery.Append(" select empresa.cd_cgc, empresa.cd_inscrmu from empresa ");
                sQuery.Append(" where empresa.cd_empresa = '" + Acesso.CD_EMPRESA + "'");

                return HlpDbFuncoes.qrySeekRet(sQuery.ToString());
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
