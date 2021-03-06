﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HLP.GeraXml.dao.ADO;
using System.Data;
using HLP.GeraXml.Comum.Static;

namespace HLP.GeraXml.dao
{
    public class daoEmail
    {
        //teste diego
        public string RetornaEmailDestinatarioCte(string sNumCte)
        {
            //antonio

            try
            {
                string email = "";
                StringBuilder sQuery = new StringBuilder();
                sQuery.Append("Select ");
                sQuery.Append("coalesce(remetent.cd_email,'')email ");
                sQuery.Append("from remetent ");
                sQuery.Append("join conhecim on remetent.cd_remetent = conhecim.cd_remetent ");
                sQuery.Append("where conhecim.cd_conheci  ='" + sNumCte + "'");


                DataTable dt = HlpDbFuncoes.qrySeekRet(sQuery.ToString());
                foreach (DataRow dr in dt.Rows)
                {
                    email = dr["email"].ToString();
                }
                return email;

            }
            catch (Exception x)
            {
                throw new Exception(x.Message);
            }

        }

        public string[] RetornaEmailDestinatarioNfe(string sSeq)
        {
            try
            {
                string[] email = null;
                StringBuilder sSql = new StringBuilder();
                sSql.Append("select ");
                sSql.Append("clifor.cd_email ");
                sSql.Append("from ");
                sSql.Append("clifor ");
                sSql.Append("left join nf ");
                sSql.Append("on ");
                sSql.Append("(nf.cd_clifor = clifor.cd_clifor) ");
                sSql.Append("where ");
                sSql.Append("nf.cd_empresa = '");
                sSql.Append(Acesso.CD_EMPRESA);
                sSql.Append("' ");
                sSql.Append("and ");
                sSql.Append("nf.cd_nfseq = '");
                sSql.Append(sSeq);
                sSql.Append("'");



                DataTable dt = HlpDbFuncoes.qrySeekRet(sSql.ToString());
                foreach (DataRow dr in dt.Rows)
                {
                    email = dt.Rows[0]["cd_email"].ToString().Split(';');
                }
                if (email == null)
                {
                    email = new string[1];
                    email[0] = "";
                }

                return email;

            }
            catch (Exception x)
            {
                throw new Exception(x.Message);
            }

        }

        public string RetornaEmailTransportador(string sSeq)
        {
            StringBuilder sSql = new StringBuilder();
            string email = "";
            try
            {
                sSql.Append("select ");
                sSql.Append("transpor.cd_email ");
                sSql.Append("from ");
                sSql.Append("transpor inner join nf ");
                sSql.Append("on transpor.cd_trans = nf.cd_trans ");
                sSql.Append("where ");
                sSql.Append("nf.cd_empresa = '");
                sSql.Append(Acesso.CD_EMPRESA);
                sSql.Append("' ");
                sSql.Append("and ");
                sSql.Append("nf.cd_nfseq = '");
                sSql.Append(sSeq);
                sSql.Append("'");


                DataTable dt = HlpDbFuncoes.qrySeekRet(sSql.ToString());
                foreach (DataRow dr in dt.Rows)
                {
                    string[] split = dt.Rows[0]["cd_email"].ToString().Split(';');

                    foreach (var i in split)
                    {
                        email = i;
                        break;
                    }
                }
                return email;
            }
            catch (Exception x)
            {
                throw new Exception(x.Message);
            }
        }


        public string RetornaEmailVendedor(string sSeq)
        {
            StringBuilder sSql = new StringBuilder();
            string email = "";
            try
            {
                sSql.Append("select vendedor.cd_email from nf inner join vendedor on nf.cd_vend1 = vendedor.cd_vend ");
                sSql.Append("where ");
                sSql.Append("nf.cd_empresa = '");
                sSql.Append(Acesso.CD_EMPRESA);
                sSql.Append("' ");
                sSql.Append("and ");
                sSql.Append("nf.cd_nfseq = '");
                sSql.Append(sSeq);
                sSql.Append("'");


                DataTable dt = HlpDbFuncoes.qrySeekRet(sSql.ToString());
                foreach (DataRow dr in dt.Rows)
                {
                    string[] split = dt.Rows[0]["cd_email"].ToString().Split(';');

                    foreach (var i in split)
                    {
                        email = i;
                        break;
                    }
                }
                return email;
            }
            catch (Exception x)
            {
                throw new Exception(x.Message);
            }
        }
    }
}
