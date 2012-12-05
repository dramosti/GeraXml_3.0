using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HLP.GeraXml.dao.ADO;
using System.Data;

namespace HLP.GeraXml.dao.CCe
{
    public class daoPesquisaCCe
    {
        public DataTable RetornaDados(StringBuilder sQuery)
        {
            try
            {
                return HlpDbFuncoes.qrySeekRet(sQuery.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
