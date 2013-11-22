using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HLP.GeraXml.Comum.Static;
using HLP.GeraXml.dao.ADO;
using System.Data;
using FirebirdSql.Data.FirebirdClient;

namespace HLP.GeraXml.dao.NFes
{
    public class daoRecepcaoServ
    {
        public void SalvaRecibo(string sReciboProt, string Nfseq)
        {

            try
            {

                StringBuilder sQuery = new StringBuilder();
                sQuery.Append("update nf ");
                sQuery.Append("set cd_recibonfe ='");
                sQuery.Append(sReciboProt);
                sQuery.Append("' ");
                sQuery.Append("where ");
                sQuery.Append("cd_empresa ='");
                sQuery.Append(Acesso.CD_EMPRESA);
                sQuery.Append("' ");
                sQuery.Append("and ");
                sQuery.Append("cd_nfseq ='");
                sQuery.Append(Nfseq);
                sQuery.Append("'");
                sQuery.Append(" and coalesce(cd_recibonfe, '') = ''");

                HlpDbFuncoes.qrySeekUpdate(sQuery.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        public void SalvaStatusDaNota(string Numero, string CodigoVerificacao, string Nfseq)
        {
            try
            {
                StringBuilder sQuery = new StringBuilder();
                sQuery.Append("update nf set st_nfe = 'S' ,");
                sQuery.Append("CD_NUMERO_NFSE ='" + Numero + "' ,");
                sQuery.Append("CD_VERIFICACAO_NFSE  = '" + CodigoVerificacao + "' ");
                sQuery.Append("Where cd_nfseq = '" + Nfseq + "' ");
                sQuery.Append("and ");
                sQuery.Append("cd_empresa = '");
                sQuery.Append(Acesso.CD_EMPRESA);
                sQuery.Append("'");

                HlpDbFuncoes.qrySeekUpdate(sQuery.ToString());

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void SalvaNotasParaCancelar(string NfseSubstituida)
        {
            try
            {

                StringBuilder sQuery = new StringBuilder();
                sQuery.Append("update nf ");
                sQuery.Append("set cd_recibocanc = '");
                sQuery.Append(NfseSubstituida);
                sQuery.Append("' ");
                sQuery.Append("where ");
                sQuery.Append("cd_empresa = '");
                sQuery.Append(Acesso.CD_EMPRESA);
                sQuery.Append("' ");
                sQuery.Append("and ");
                sQuery.Append("cd_numero_nfse = '");
                sQuery.Append(NfseSubstituida);
                sQuery.Append("'");
                HlpDbFuncoes.qrySeekUpdate(sQuery.ToString());

            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        public void ApagaRecibo(string Nfseq)
        {
            try
            {
                StringBuilder sQuery = new StringBuilder();

                sQuery = new StringBuilder();
                sQuery.Append("update nf ");
                sQuery.Append("set cd_recibonfe ='' ");
                sQuery.Append("where ");
                sQuery.Append("cd_empresa ='");
                sQuery.Append(Acesso.CD_EMPRESA);
                sQuery.Append("' ");
                sQuery.Append("and ");
                sQuery.Append("cd_nfseq ='");
                sQuery.Append(Nfseq);
                sQuery.Append("'");

                HlpDbFuncoes.qrySeekUpdate(sQuery.ToString());


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string BuscaProtocolo(string sSequencia)
        {
            try
            {
                StringBuilder sQuery = new StringBuilder();
                sQuery.Append("select coalesce(nf.cd_recibonfe,'')cd_recibonfe from nf ");
                sQuery.Append("where ");
                sQuery.Append("cd_empresa ='");
                sQuery.Append(Acesso.CD_EMPRESA);
                sQuery.Append("' ");
                sQuery.Append("and ");
                sQuery.Append("cd_nfseq ='");
                sQuery.Append(sSequencia);
                sQuery.Append("'");

                DataTable dt = HlpDbFuncoes.qrySeekRet(sQuery.ToString());
                return dt.Rows[0]["cd_recibonfe"].ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public List<string> BuscaListaLote(string sReciboProt)
        {
            try
            {
                StringBuilder sQuery = new StringBuilder();
                sQuery.Append("select nf.cd_nfseq from nf ");
                sQuery.Append("where ");
                sQuery.Append("cd_empresa ='");
                sQuery.Append(Acesso.CD_EMPRESA);
                sQuery.Append("' ");
                sQuery.Append("and ");
                sQuery.Append("cd_recibonfe ='");
                sQuery.Append(sReciboProt);
                sQuery.Append("'");


                //FbDataReader dr = HlpDbFuncoes.qrySeekReader(sQuery.ToString());

                List<string> objListaSequencias = HlpDbFuncoes.qrySeekRet(sQuery.ToString()).AsEnumerable().Select(c => c["cd_nfseq"].ToString()).ToList();

                //while (dr.Read())
                //{
                //    objListaSequencias.Add(dr["cd_nfseq"].ToString());
                //}
                return objListaSequencias;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
