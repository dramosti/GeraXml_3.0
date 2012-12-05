using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HLP.GeraXml.Comum.Static;
using HLP.GeraXml.dao.ADO;

namespace HLP.GeraXml.dao.NFe.Estrutura
{
    public class daoTotal
    {
       

        public DataRow BuscaTotais(string seqNF, bool pbIndustri, bool bEX)
        {
            try
            {
                string sStImpICMS_Em_Subst_NF = BuscaSTICMSEMSUBSTNF(seqNF);
                StringBuilder sSql = new StringBuilder();
                sSql.Append("Select ");
                sSql.Append("First 1 ");
                if ((pbIndustri) || (Acesso.NM_EMPRESA == "CMENDES"))
                {
                    if (sStImpICMS_Em_Subst_NF == "S")
                    {
                        sSql.Append("(coalesce(nf.vl_baseicm,0) + coalesce(nf.VL_BICMPROPRIO_SUBST,0)) vBC, ");
                    }
                    else
                    {
                        sSql.Append("coalesce(nf.vl_baseicm,0) vBC, ");
                    }
                }

                if (sStImpICMS_Em_Subst_NF == "S")
                {
                    sSql.Append("(COALESCE(nf.vl_toticms,0) + COALESCE(NF.VL_TICMPROPRIO_SUBST,0)) vICMS, ");
                    sSql.Append("(coalesce(nf.vl_baseicm,0) + coalesce(nf.VL_BICMPROPRIO_SUBST,0)) vBC, ");
                }
                else
                {
                    sSql.Append("COALESCE(nf.vl_toticms,0)  vICMS, ");
                    sSql.Append("coalesce(nf.vl_baseicm,0) vBC, ");
                }
                sSql.Append("nf.vl_bicmssu vBCST, ");
                sSql.Append("nf.vl_icmssub vST, ");
                if (pbIndustri)
                {
                    if (Acesso.TP_INDUSTRIALIZACAO == 1)
                    {
                        if (!bEX)
                        {
                            sSql.Append("(select sum(movitem.vl_totbruto) from movitem inner join opereve on (opereve.cd_oper = movitem.cd_oper) where ((movitem.cd_empresa = nf.cd_empresa) and (movitem.cd_nfseq = nf.cd_nfseq)) and (opereve.ST_ESTTERC <> 'S')) vProd, ");
                        }
                        else
                        {
                            sSql.Append("coalesce(nf.vl_totprod, 0) vProd, ");
                        }
                    }
                    else
                    {
                        if (bEX)
                        {
                            sSql.Append("coalesce(nf.vl_totprod, 0) vProd, ");
                        }
                        else
                        {
                            sSql.Append("coalesce(nf.vl_totprod, 0) vProd, ");
                        }
                    }
                }
                else
                {
                    if (Acesso.NM_EMPRESA != "NAVE_THERM")
                    {
                        if (Acesso.TP_INDUSTRIALIZACAO == 1)
                        {
                            if (!bEX)
                            {
                                sSql.Append(" case when coalesce(opereve.st_hefrete, 'N') = 'N' then ");
                                sSql.Append(" (nf.vl_totprod + nf.vl_desccomer + nf.vl_servico) ");
                                sSql.Append("else ");
                                sSql.Append("(nf.vl_totprod + nf.vl_desccomer ) ");
                                sSql.Append("end vProd,");
                            }
                            else
                            {
                                sSql.Append("coalesce(nf.vl_totprod, 0) vProd, ");
                            }
                        }
                        else
                        {
                            if (!bEX)
                            {
                                sSql.Append("coalesce(nf.vl_totprod, 0) vProd,");
                            }
                            else
                            {
                                sSql.Append("coalesce(nf.vl_totprod, 0) vProd, ");
                            }
                        }
                    }
                    else
                    {
                        sSql.Append("(nf.vl_totprod + nf.vl_servico) vProd, ");

                        if (sStImpICMS_Em_Subst_NF == "S")
                        {
                            if (!bEX)
                            {
                                sSql.Append("(coalesce(nf.vl_baseicm,0) + coalesce(nf.VL_BICMPROPRIO_SUBST,0)) vBC, ");
                            }
                            else
                            {
                                sSql.Append("(coalesce(nf.vl_baseicm,0) + coalesce(nf.VL_BICMPROPRIO_SUBST,0) + coalesce( nf.vl_impimport,0)) vBC, ");
                            }
                        }
                        else
                        {
                            if (!bEX)
                            {
                                sSql.Append("coalesce(nf.vl_baseicm,0) vBC, ");
                            }
                            else
                            {
                                sSql.Append("(coalesce(nf.vl_baseicm,0)+ (coalesce( nf.vl_impimport,0)) vBC, ");
                            }
                        }
                    }
                }
                sSql.Append("nf.vl_frete vFrete, ");
                sSql.Append("nf.vl_seg vSeg, ");
                bool bNfSuframa = VerificaNotaComSuframa(seqNF);
                sSql.Append(bNfSuframa == false ? "nf.vl_desccomer vDesc, " : "(coalesce(nf.vl_cofins_suframa,0)+ coalesce(nf.vl_pis_suframa,0)+ coalesce(nf.vl_desc_suframa,0)) vDesc, ");
                sSql.Append("nf.vl_impimport vII, ");
                sSql.Append("nf.vl_totipi vIPI, ");
                sSql.Append("nf.vl_pis vPIS, ");
                sSql.Append("nf.vl_cofins vCOFINS, ");
                sSql.Append("nf.vl_outras vOutro, ");

                if (bEX)//os_26817
                {
                    sSql.Append("nf.vl_totnf vNF, ");
                }
                else
                {
                    if (Acesso.TP_INDUSTRIALIZACAO == 1)
                    {
                        sSql.Append("(select sum(movitem.vl_totbruto) from movitem where ((movitem.cd_empresa = nf.cd_empresa) and (movitem.cd_nfseq = nf.cd_nfseq))) + coalesce(nf.vl_frete,0) vNF, "); //Claudinei - 24162 - 22/02/2010 
                    }
                    else
                    {
                        sSql.Append("nf.vl_totnf vNF, ");
                    }
                }
                sSql.Append("coalesce(tpdoc.st_pauta,'N') st_pauta ");
                sSql.Append(", nf.vl_servico vServ ");
                sSql.Append(", nf.vl_iss Viss ");
                sSql.Append(", nf.vl_pis_serv PisIss ");
                sSql.Append(", nf.vl_cofins_serv cofinsIss ");
                //Tabela
                sSql.Append("From NF ");
                //Relacionamentos
                sSql.Append("inner join movitem on (movitem.cd_empresa = nf.cd_empresa) and (movitem.cd_nfseq = nf.cd_nfseq) ");
                sSql.Append("inner join opereve on (opereve.cd_oper = movitem.cd_oper)");
                sSql.Append("inner join tpdoc on (tpdoc.cd_tipodoc = nf.cd_tipodoc) ");
                //Where
                sSql.Append("Where ");
                sSql.Append("(NF.cd_empresa ='");
                sSql.Append(Acesso.CD_EMPRESA);
                sSql.Append("')");
                sSql.Append(" and ");
                sSql.Append("(nf.cd_nfseq = '");
                sSql.Append(seqNF);
                sSql.Append("') ");

                DataTable dt = HlpDbFuncoes.qrySeekRet(sSql.ToString());
                DataRow drTotais = dt.Rows[0];               
                return drTotais;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        private string BuscaSTICMSEMSUBSTNF(string sNF)
        {
            string sRetorno = "N";

            try
            {
                StringBuilder sb = new StringBuilder();

                sb.Append("select ");
                sb.Append("Coalesce(TPDOC.ST_IMPICMS_EM_SUBST_NF, 'N') ST_IMPICMS_EM_SUBST_NF ");
                sb.Append("from ");
                sb.Append("nf ");
                sb.Append("inner join tpdoc ");
                sb.Append("on (tpdoc.cd_tipodoc = nf.cd_tipodoc) ");
                sb.Append("Where ");
                sb.Append("nf.cd_empresa = '");
                sb.Append(Acesso.CD_EMPRESA);
                sb.Append("' and ");
                sb.Append("nf.cd_nfseq = '");
                sb.Append(sNF);
                sb.Append("'");
                sRetorno = HlpDbFuncoes.qrySeekRet(sb.ToString()).Rows[0]["ST_IMPICMS_EM_SUBST_NF"].ToString();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Não foi possível buscar o conteúdo do campo ST_IMPICMS_EM_SUBST_NF, erro: ",
                                                  ex.Message));
            }

            return sRetorno;
        }

        private bool VerificaNotaComSuframa(string sNF)
        {
            try
            {
                StringBuilder sQuery = new StringBuilder();
                sQuery.Append("select nf.cd_nfseq, clifor.cd_suframa,clifor.st_descsuframa ");
                sQuery.Append("from nf inner join clifor on ");
                sQuery.Append("nf.cd_clifor = clifor.cd_clifor ");
                sQuery.Append("where  nf.cd_nfseq = '" + sNF + "' and ");
                sQuery.Append("nf.cd_empresa = '" + Acesso.CD_EMPRESA + "'");

                DataTable dt = HlpDbFuncoes.qrySeekRet(sQuery.ToString());
                bool bValida = false;
                foreach (DataRow dr in dt.Rows)
                {
                    if ((dr["st_descsuframa"].ToString().Equals("S")) && (dr["cd_suframa"] != null))
                    {
                        bValida = true;
                    }
                    else
                    {
                        bValida = false;
                    }
                }
                return bValida;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
