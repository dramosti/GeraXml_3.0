using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HLP.GeraXml.Comum.Static;
using HLP.GeraXml.dao.ADO;

namespace HLP.GeraXml.dao.CTe
{
    public class daoGravaDadosRetorno
    {
        public void SalvaChave(string Chave, string nCT)
        {
            try
            {

                StringBuilder sQuery = new StringBuilder();
                sQuery.Append("Update conhecim ");
                sQuery.Append("set conhecim.cd_chavecte='" + Chave + "' ");
                sQuery.Append("where conhecim.cd_conheci='" + nCT + "' ");
                sQuery.Append("and conhecim.cd_empresa ='" + Acesso.CD_EMPRESA + "'");

                HlpDbFuncoes.qrySeekUpdate(sQuery.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Gravar a Chave no Banco de Dados.");
            }


        }

        public void SalvarRecibo(string sRecibo, string nCT)
        {
            try
            {

                StringBuilder sQuery = new StringBuilder();
                sQuery.Append("Update conhecim ");
                sQuery.Append("set conhecim.cd_recibocte='" + sRecibo + "' ");
                sQuery.Append("where conhecim.cd_conheci='" + nCT + "' ");
                sQuery.Append("and conhecim.cd_empresa ='" + Acesso.CD_EMPRESA + "'");

                HlpDbFuncoes.qrySeekUpdate(sQuery.ToString());

            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Gravar o Recibo no Banco de Dados.");
            }

        }

        public void ApagarRecibo(string sRecibo)
        {
            try
            {
                StringBuilder sQuery = new StringBuilder();
                sQuery.Append("Update conhecim ");
                sQuery.Append("set conhecim.cd_recibocte= null ");
                sQuery.Append("where conhecim.cd_recibocte='" + sRecibo + "' ");
                sQuery.Append("and conhecim.cd_empresa ='" + Acesso.CD_EMPRESA + "'");
                HlpDbFuncoes.qrySeekUpdate(sQuery.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        public void GravarProtocoloEnvio(string Protocolo, string NumeroSeq)
        {
            try
            {

                StringBuilder sQuery = new StringBuilder();
                sQuery.Append("Update conhecim ");
                sQuery.Append("set conhecim.cd_nprotcte='" + Protocolo + "' ");
                sQuery.Append("where conhecim.nr_lanc='" + NumeroSeq + "' ");
                sQuery.Append("and conhecim.cd_empresa ='" + Acesso.CD_EMPRESA + "'");

                HlpDbFuncoes.qrySeekUpdate(sQuery.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AlterarStatusCte(string NumeroSeq)
        {
            try
            {
                StringBuilder sQuery = new StringBuilder();
                sQuery.Append("Update conhecim ");
                sQuery.Append("set  conhecim.st_cte ='S' ");
                sQuery.Append("where conhecim.nr_lanc ='" + NumeroSeq + "' ");
                sQuery.Append("and conhecim.cd_empresa ='" + Acesso.CD_EMPRESA + "'");

                HlpDbFuncoes.qrySeekUpdate(sQuery.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void AlterarStatusCteContingencia(string sNumCte)
        {
            try
            {
                StringBuilder sQuery = new StringBuilder();
                sQuery.Append("Update conhecim ");
                sQuery.Append("set  conhecim.st_contingencia ='S' ");
                sQuery.Append("where conhecim.cd_conheci ='" + sNumCte + "' ");
                sQuery.Append("and conhecim.cd_empresa ='" + Acesso.CD_EMPRESA + "'");
                HlpDbFuncoes.qrySeekUpdate(sQuery.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void GravarReciboCancelamento(string sCodConhec, string sReciboCancelamento, string sJustificativa)
        {
            try
            {
                StringBuilder sQuery = new StringBuilder();
                sQuery.Append("Update conhecim ");
                sQuery.Append("set conhecim.cd_recibocanc ='" + sReciboCancelamento + "', ");
                sQuery.Append("conhecim.ds_cancelamento='" + sJustificativa + "' ");
                sQuery.Append("where conhecim.cd_conheci='" + sCodConhec + "' ");
                sQuery.Append("and conhecim.cd_empresa ='" + Acesso.CD_EMPRESA + "'");
                HlpDbFuncoes.qrySeekUpdate(sQuery.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


    }
}
