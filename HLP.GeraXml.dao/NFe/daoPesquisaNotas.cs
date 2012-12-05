using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HLP.GeraXml.Comum.Static;

namespace HLP.GeraXml.dao.NFe
{
    public class daoPesquisaNotas
    {
        public virtual void AlteraStatusNotaParaContingenciaFS(string seqNF)
        {
            try
            {
                string sSqlAtualizaNF = "update NF set st_contingencia = '" + "S" +
                                            "' where cd_empresa = '" + Acesso.CD_EMPRESA +
                                            "' and cd_nfseq = '" + seqNF + "'";

                HLP.GeraXml.dao.ADO.HlpDbFuncoes.qrySeekUpdate(sSqlAtualizaNF.ToString());

            }
            catch (Exception)
            {
                throw;
            }
        }
              
    }
}
