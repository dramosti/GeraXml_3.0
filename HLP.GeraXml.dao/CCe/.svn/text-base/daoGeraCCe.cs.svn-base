using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HLP.GeraXml.Comum.Static;
using HLP.GeraXml.dao.ADO;
using System.Data;

namespace HLP.GeraXml.dao.CCe
{
    public class daoGeraCCe
    {

        public string BuscaCorrecoes(string sNR_LANC)
        {
            try
            {
                StringBuilder sQuery = new StringBuilder();
                sQuery.Append("SELECT i.ds_item, i.ds_correto FROM ITCARTAC i ");
                sQuery.Append("where i.cd_carta = '" + sNR_LANC + "' ");
                sQuery.Append("and i.cd_empresa = '" + Acesso.CD_EMPRESA + "' ");
                sQuery.Append("and coalesce(i.ds_correto,'') <> '' ");

                DataTable dt = HlpDbFuncoes.qrySeekRet(sQuery.ToString());
                string sXcorrecao = "";
                foreach (DataRow dr in dt.Rows)
                {
                    sXcorrecao += string.Format("IRREGULARIDADE: {0} - RETIFICAÇÃO: {1} |",
                                                 dr["ds_item"].ToString().ToUpper().Trim(),
                                                 dr["ds_correto"].ToString().ToUpper().Trim());
                }
                if (sXcorrecao.Length > 1)
                {
                    sXcorrecao = sXcorrecao.Remove(sXcorrecao.Length - 1, 1).Trim();
                }
                return sXcorrecao;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public string BuscaCorrecoesPulandoLinha(string sNR_LANC)
        {
            try
            {

                StringBuilder sQuery = new StringBuilder();
                sQuery.Append("SELECT i.ds_item, i.ds_correto FROM ITCARTAC i ");
                sQuery.Append("where i.cd_carta = '" + sNR_LANC + "' ");
                sQuery.Append("and i.cd_empresa = '" + Acesso.CD_EMPRESA + "' ");
                sQuery.Append("and coalesce(i.ds_correto,'') <> '' ");
                DataTable dt = HlpDbFuncoes.qrySeekRet(sQuery.ToString());
                string sXcorrecao = "";

                foreach (DataRow dr in dt.Rows)
                {
                    sXcorrecao += string.Format("IRREGULARIDADE: {0} - RETIFICAÇÃO: {1} " + Environment.NewLine,
                                                 dr["ds_item"].ToString().ToUpper().Trim(),
                                                 dr["ds_correto"].ToString().ToUpper().Trim());
                }
                if (sXcorrecao.Length > 1)
                {
                    sXcorrecao = sXcorrecao.Remove(sXcorrecao.Length - 1, 1).Trim();
                }
                return sXcorrecao;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void AtualizaContadorCCe(string _sNR_LANC, int _iQT_ENVIO)
        {
            try
            {
                string sQuery = string.Format("update cartacor set qt_envio = '{0}' where cartacor.nr_lanc = '{1}' and cartacor.cd_empresa = '{2}'", _iQT_ENVIO + 1, _sNR_LANC, Acesso.CD_EMPRESA);
                HlpDbFuncoes.qrySeekUpdate(sQuery.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }








    }
}
