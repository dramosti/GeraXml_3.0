using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HLP.GeraXml.Comum.Static;

namespace HLP.GeraXml.dao.NFe.Estrutura
{
    public class daoCobr
    {

        public DataTable BuscaFat(string seqNF)
        {
            try
            {
                StringBuilder sSql = new StringBuilder();
                sSql.Append("Select ");
                sSql.Append("doc_ctr.cd_dupli, ");
                sSql.Append("DOC_CTR.dt_venci, ");
                sSql.Append("DOC_CTR.vl_doc ,");
                sSql.Append("doc_ctr.vl_totdesc, ");
                sSql.Append("doc_ctr.cd_documento ");
                sSql.Append("From doc_ctr ");
                sSql.Append("INNER JOIN NF ON (NF.cd_empresa = DOC_CTR.cd_empresa) AND ");
                sSql.Append("(NF.cd_nfseq = DOC_CTR.cd_nfseq) ");
                sSql.Append("Where ");
                sSql.Append("(nf.cd_empresa ='");
                sSql.Append(Acesso.CD_EMPRESA);
                sSql.Append("') ");
                sSql.Append(" and ");
                sSql.Append("(nf.cd_nfseq ='");
                sSql.Append(seqNF);
                sSql.Append("') ");
                return HLP.GeraXml.dao.ADO.HlpDbFuncoes.qrySeekRet(sSql.ToString());
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public DataTable BuscaCobr(string seqNF)
        {
            try
            {
                StringBuilder sSql = new StringBuilder();
                sSql.Append("Select ");
                sSql.Append("nf.cd_notafis nFat, ");
                sSql.Append("coalesce((nf.vl_totnf + nf.vl_desccomer ), 0) vOrig, ");
                sSql.Append("nf.vl_desccomer vDesc, ");
                sSql.Append("nf.vl_totnf vLiq ");
                sSql.Append("from nf ");
                sSql.Append("Where ");
                sSql.Append("(nf.cd_empresa ='");
                sSql.Append(Acesso.CD_EMPRESA);
                sSql.Append("') ");
                sSql.Append(" and ");
                sSql.Append("(nf.cd_nfseq ='");
                sSql.Append(seqNF);
                sSql.Append("') ");
                return HLP.GeraXml.dao.ADO.HlpDbFuncoes.qrySeekRet(sSql.ToString());
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }


        public static string BuscaFatToImpressaoNFSE_DSF(string seqNF)
        {
            try
            {
                StringBuilder sSql = new StringBuilder();
                sSql.Append("Select ");
                sSql.Append("doc_ctr.cd_dupli, ");
                sSql.Append("DOC_CTR.dt_venci, ");
                sSql.Append("DOC_CTR.vl_doc ,");
                sSql.Append("doc_ctr.vl_totdesc, ");
                sSql.Append("doc_ctr.cd_documento ");
                sSql.Append("From doc_ctr ");
                sSql.Append("INNER JOIN NF ON (NF.cd_empresa = DOC_CTR.cd_empresa) AND ");
                sSql.Append("(NF.cd_nfseq = DOC_CTR.cd_nfseq) ");
                sSql.Append("Where ");
                sSql.Append("(nf.cd_empresa ='");
                sSql.Append(Acesso.CD_EMPRESA);
                sSql.Append("') ");
                sSql.Append(" and ");
                sSql.Append("(nf.cd_nfseq ='");
                sSql.Append(seqNF);
                sSql.Append("') ");

                string sMsg = "";
                foreach (DataRow drFat in HLP.GeraXml.dao.ADO.HlpDbFuncoes.qrySeekRet(sSql.ToString()).Rows)
                {
                    sMsg += string.Format("Dup:{0} - R${1} - Venc:{2}{3}", drFat["cd_dupli"].ToString(),
                        Math.Round(Convert.ToDecimal(drFat["vl_doc"].ToString()), 2).ToString("#0.00"),
                        System.DateTime.Parse(drFat["dt_venci"].ToString()).ToShortDateString(),
                        Environment.NewLine);
                }

                return sMsg;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

    }
}
