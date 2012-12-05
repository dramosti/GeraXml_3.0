using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HLP.GeraXml.dao.ADO;
using HLP.GeraXml.Comum.Static;

namespace HLP.GeraXml.dao.NFes
{
    public class daoBuscaDados 
    {
        public DataTable PesquisaGridView(string sCampos, string sWhere)
        {
            try
            {
                StringBuilder sQuery = new StringBuilder();
                sQuery.Append("Select ");
                sQuery.Append(sCampos);
                sQuery.Append(" from NF ");
                sQuery.Append(" Where " + sWhere);
                sQuery.Append(" order by nf.cd_notafis");

                return HlpDbFuncoes.qrySeekRet(sQuery.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public string VerificaCampoReciboPreenchido(string sSeq)
        {
            try
            {
                StringBuilder sQueryVerifica = new StringBuilder();
                sQueryVerifica.Append("Select cd_recibonfe from nf ");
                sQueryVerifica.Append("where ");
                sQueryVerifica.Append("cd_empresa ='");
                sQueryVerifica.Append(Acesso.CD_EMPRESA);
                sQueryVerifica.Append("' ");
                sQueryVerifica.Append("and ");
                sQueryVerifica.Append("cd_nfseq ='");
                sQueryVerifica.Append(sSeq);
                sQueryVerifica.Append("'");

                DataTable dt = HlpDbFuncoes.qrySeekRet(sQueryVerifica.ToString());
                return dt.Rows[0]["cd_recibonfe"].ToString();


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable BuscaRps(string sNotaFis)
        {

            try
            {
                StringBuilder sQuery = new StringBuilder();
                sQuery.Append("select nf.cd_nfseq, nf.cd_notafis, coalesce(nf.cd_serie,'00001')cd_serie from nf ");
                sQuery.Append("where nf.cd_notafis = '" + sNotaFis + "' and ");
                sQuery.Append("nf.cd_empresa = '" + Acesso.CD_EMPRESA + "'");
                sQuery.Append(" and coalesce(nf.st_nf_prod,'S') = 'N'");
                sQuery.Append(" and nf.cd_gruponf = '" + Acesso.GRUPO_SERVICO + "'");

                return HlpDbFuncoes.qrySeekRet(sQuery.ToString());

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void AlteraDuplicata(string sNotaFis, string Nfseq)
        {

            try
            {
                StringBuilder sQuery = new StringBuilder();
                sQuery.Append("UPDATE dupnotar SET dupnotar.cd_notafis = '" + sNotaFis + "' ");
                sQuery.Append("where dupnotar.cd_empresa = '" + Acesso.CD_EMPRESA + "' ");
                sQuery.Append("and dupnotar.cd_nfseq = '" + Nfseq + "' ");
                sQuery.Append("and dupnotar.cd_gruponf = '" + Acesso.GRUPO_SERVICO + "'");

                HlpDbFuncoes.qrySeekUpdate(sQuery.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
