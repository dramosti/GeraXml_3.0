using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HLP.GeraXml.dao.ADO;
using HLP.GeraXml.Comum.Static;

namespace HLP.GeraXml.dao.NFes.DSF
{
    public class daoCancelamentoDSF
    {
        public virtual DataTable GetDadosCancelemto(string sCD_NFSEQ)
        {
            string sQuery = "select empresa.cd_inscrmu, nf.cd_numero_nfse, nf.cd_verificacao_nfse "
                + "from nf inner join empresa on nf.cd_empresa = empresa.cd_empresa "
                + "where nf.cd_nfseq = '{0}' and nf.cd_empresa = '{1}' ";
            try
            {
                return HlpDbFuncoes.qrySeekRet(string.Format(sQuery, sCD_NFSEQ, Acesso.CD_EMPRESA));
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public void UpdateToCancel(string sCd_numero_nfse, string sCd_verificacao_nfse, string sMotivoCanc)
        {
            try
            {
                string sQuery = "update nf set nf.cd_recibocanc = '{0}', nf.DS_MOTIVO_CANC = '{3}' "
                + "where nf.cd_numero_nfse = '{1}' and nf.cd_verificacao_nfse = '{0}' "
                + " and nf.cd_empresa = '{2}'";

                sQuery = string.Format(sQuery.ToString(), sCd_verificacao_nfse, sCd_numero_nfse, Acesso.CD_EMPRESA, sMotivoCanc);

                HlpDbFuncoes.qrySeekUpdate(sQuery);

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
