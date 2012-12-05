using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HLP.GeraXml.dao.ADO;
using HLP.GeraXml.Comum.Static;

namespace HLP.GeraXml.dao.CTe
{
    public class daoCancelaCte
    {
        public DataTable BuscaDadosCancelamento(string sCodConhecimento, string sJustificativa)
        {
            try
            {

                StringBuilder sQuery = new StringBuilder();
                sQuery.Append("Select ");
                sQuery.Append("conhecim.cd_chavecte chCTe, ");
                sQuery.Append("conhecim.cd_nprotcte nProt ");
                sQuery.Append("from conhecim ");
                sQuery.Append("where conhecim.cd_conheci ='" + sCodConhecimento + "' ");
                sQuery.Append("and conhecim.cd_empresa = '" + Acesso.CD_EMPRESA + "'");

                return HlpDbFuncoes.qrySeekRet(sQuery.ToString());

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
