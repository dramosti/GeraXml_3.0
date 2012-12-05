using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HLP.GeraXml.Comum.Static;
using HLP.GeraXml.dao.ADO;

namespace HLP.GeraXml.dao.NFes
{
    public class daoConstrucaoCivil
    {
        public DataTable BuscaDadosContrucaoCivil(string sNota)
        {
            try
            {
                StringBuilder sQuery = new StringBuilder();
                sQuery.Append("select coalesce(clifor.cd_art,'') Art, coalesce(clifor.cd_obra,'')CodigoObra {0}");
                sQuery.Append("from nf inner join clifor on nf.cd_clifor = clifor.cd_clifor {0}");
                sQuery.Append("where nf.cd_nfseq = '{1}' and nf.cd_empresa = '{2}' {0}");

                string sQueryEnd = string.Format(sQuery.ToString(), Environment.NewLine, sNota, Acesso.CD_EMPRESA);

                return HlpDbFuncoes.qrySeekRet(sQueryEnd);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
