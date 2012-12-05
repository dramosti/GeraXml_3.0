using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HLP.GeraXml.dao.ADO;
using HLP.GeraXml.Comum.Static;

namespace HLP.GeraXml.dao.NFes
{
    public class daoImpressao
    {
        public DataTable BuscaDados(string sNfSeq)
        {
            try
            {

                StringBuilder sQuery = new StringBuilder();
                sQuery.Append("select nf.cd_verificacao_nfse, nf.cd_numero_nfse from nf ");
                sQuery.Append("where nf.cd_nfseq = '" + sNfSeq + "' and ");
                sQuery.Append("nf.cd_empresa = '" + Acesso.CD_EMPRESA + "'");

                return HlpDbFuncoes.qrySeekRet(sQuery.ToString());

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
