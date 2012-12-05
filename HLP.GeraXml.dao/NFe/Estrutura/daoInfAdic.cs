using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HLP.GeraXml.Comum.Static;
using HLP.GeraXml.dao.ADO;
using FirebirdSql.Data.FirebirdClient;

namespace HLP.GeraXml.dao.NFe.Estrutura
{
    public class daoInfAdic
    {
        public string BuscaObs(string seqNF)
        {
            try
            {
                StringBuilder sSql = new StringBuilder();
                sSql.Append("Select ");
                sSql.Append("nf.ds_anota ");

                if (((Acesso.NM_EMPRESA == "MOGPLAST") || (Acesso.NM_EMPRESA == "TSA")) && (Acesso.CD_EMPRESA == "003"))
                {
                    sSql.Append(", nf.cd_nfseq_fat_origem ");
                }
                if ((Acesso.NM_EMPRESA == "MACROTEX") || (Acesso.NM_EMPRESA == "PAVAX"))
                {
                    sSql.Append(", coalesce(vendedor.nm_vend,'0')nm_vend , ");
                    sSql.Append("coalesce(nf.DS_DOCORIG,'0')DS_DOCORIG ");
                }
                sSql.Append("From NF ");
                sSql.Append("left join vendedor on (vendedor.cd_vend = nf.cd_vend1) ");
                sSql.Append("Where ");
                sSql.Append("(NF.cd_empresa ='");
                sSql.Append(Acesso.CD_EMPRESA);
                sSql.Append("')");
                sSql.Append(" and ");
                sSql.Append("(nf.cd_nfseq = '");
                sSql.Append(seqNF);
                sSql.Append("') ");
                string sObs = "";
                sObs = daoUtil.RetornaBlob(sSql.ToString());
                if (sObs.IndexOf("\\fs") != -1)// DIEGO - OS_24854 
                {
                    sObs = sObs.Substring((sObs.IndexOf("\\fs") + 6), sObs.Length - (sObs.IndexOf("\\fs") + 6));
                }
                if (Acesso.NM_EMPRESA == "MARPA")
                {
                    sObs += MontaObsAgrup(seqNF);
                }


                if (Acesso.NM_RAMO != Acesso.BancoDados.CERAMICA)
                {
                    StringBuilder sSuframa = new StringBuilder();
                    sSuframa.Append("Select First 1 ");
                    sSuframa.Append("nf.ds_anota, ");
                    sSuframa.Append("clifor.st_descsuframa, ");
                    sSuframa.Append("clifor.cd_suframa, ");
                    sSuframa.Append("clifor.ST_PISCOFINS_SUFRAMA, ");
                    sSuframa.Append("nf.vl_aliqcofins_suframa, ");
                    sSuframa.Append("nf.vl_aliqpis_suframa, ");
                    sSuframa.Append("nf.vl_cofins_suframa, ");
                    sSuframa.Append("NF.vl_pis_suframa, ");
                    sSuframa.Append("(select Sum(movitem.vl_descsuframa) from movitem where (movitem.cd_empresa = nf.cd_empresa) and (movitem.cd_nfseq = nf.cd_nfseq)) vl_suframa, ");
                    sSuframa.Append("icm.vl_aliquot vl_persuframa ");
                    sSuframa.Append(", ");
                    sSuframa.Append("case when empresa.vl_aliqfatcred > 0 then ");
                    sSuframa.Append("(nf.vl_totnf * empresa.vl_aliqfatcred)/100 ");
                    sSuframa.Append("else ");
                    sSuframa.Append("0 ");
                    sSuframa.Append("end aliq, ");
                    sSuframa.Append("empresa.vl_aliqfatcred, ");
                    sSuframa.Append("coalesce(tpdoc.st_hevenda,'N') st_hevenda ");
                    sSuframa.Append("From NF ");
                    sSuframa.Append("left join clifor on (clifor.cd_clifor = nf.cd_clifor) ");
                    sSuframa.Append("left join icm on (icm.cd_ufnor = clifor.cd_ufnor) ");
                    sSuframa.Append("left join movitem on (movitem.cd_empresa = nf.cd_empresa) ");
                    sSuframa.Append("and ");
                    sSuframa.Append("(movitem.cd_nfseq = nf.cd_nfseq) ");
                    sSuframa.Append("Inner join ");
                    sSuframa.Append("Empresa on ");
                    sSuframa.Append("(Empresa.cd_empresa = nf.cd_empresa) ");
                    sSuframa.Append("Left join ");
                    sSuframa.Append("TPDoc on ");
                    sSuframa.Append("(TPDoc.cd_tipodoc = nf.cd_tipodoc) ");
                    //Where
                    sSuframa.Append("Where ");
                    sSuframa.Append("(NF.cd_empresa ='");
                    sSuframa.Append(Acesso.NM_EMPRESA);
                    sSuframa.Append("')");
                    sSuframa.Append(" and ");
                    sSuframa.Append("(nf.cd_nfseq = '");
                    sSuframa.Append(seqNF);
                    sSuframa.Append("') ");

                    DataTable dt = HLP.GeraXml.dao.ADO.HlpDbFuncoes.qrySeekRet(sSuframa.ToString());
                    if (dt.Rows.Count > 0)
                    {
                        DataRow drSuframa = dt.Rows[0];

                        if (drSuframa["st_descsuframa"].ToString() == "S")
                        {
                            decimal dvlSuframa = Math.Round(Convert.ToDecimal(drSuframa["vl_suframa"].ToString()), 2);
                            decimal dvlPerSuframa = Math.Round(Convert.ToDecimal(drSuframa["vl_persuframa"].ToString()), 2);
                            if (sObs.Trim() != "")
                            {
                                sObs += string.Format(" - DESCONTO DE {0:C2} REF. AO ICMS {1:f2}% CODIGO SUFRAMA: {2}",
                                                      dvlSuframa,
                                                      dvlPerSuframa,
                                                      drSuframa["cd_suframa"].ToString());
                            }
                            else
                            {
                                sObs += string.Format("DESCONTO DE {0:C2} REF. AO ICMS 7.00% CODIGO SUFRAMA: {1}",
                                                      dvlSuframa,
                                                      drSuframa["cd_suframa"].ToString());
                            }
                        }
                        if (drSuframa["ST_PISCOFINS_SUFRAMA"].ToString() == "S")
                        {
                            decimal dvl_aliqcofins_suframa = Math.Round(Convert.ToDecimal(drSuframa["vl_aliqcofins_suframa"].ToString()), 2); //Claudinei - o.s. 24248 - 26/03/2010
                            decimal dvl_cofins_suframa = Math.Round(Convert.ToDecimal(drSuframa["vl_cofins_suframa"].ToString()), 2); //Claudinei - o.s. 24248 - 26/03/2010
                            decimal dvl_aliqpis_suframa = Math.Round(Convert.ToDecimal(drSuframa["vl_aliqpis_suframa"].ToString()), 2); //Claudinei - o.s. 24248 - 26/03/2010
                            decimal dvl_pis_suframa = Math.Round(Convert.ToDecimal(drSuframa["vl_pis_suframa"].ToString()), 2); //Claudinei - o.s. 24248 - 26/03/2010

                            if (sObs.Trim() != "")
                            {
                                sObs += string.Format(" - ABATIMENTO COFINS ({0}%) - VALOR R$ {1} - ABATIMENTO PIS ({2}%) - VALOR R$ {3} ",
                                                      dvl_aliqcofins_suframa.ToString("#0.00").Replace(',', '.'),
                                                      dvl_cofins_suframa.ToString("#0.00").Replace(',', '.'),
                                                      dvl_aliqpis_suframa.ToString("#0.00").Replace(',', '.'),
                                                      dvl_pis_suframa.ToString("#0.00").Replace(',', '.'));
                            }
                            else
                            {
                                sObs += string.Format("ABATIMENTO COFINS ({0}%) - VALOR R$ {1} - ABATIMENTO PIS ({2}%) - VALOR R$ {3} ",
                                                      dvl_aliqcofins_suframa.ToString("#0.0000").Replace(',', '.'),
                                                      dvl_cofins_suframa.ToString("#0.0000").Replace(',', '.'),
                                                      dvl_aliqpis_suframa.ToString("#0.0000").Replace(',', '.'),
                                                      dvl_pis_suframa.ToString("#0.0000").Replace(',', '.'));
                            }
                        }
                        decimal dvlnf = 0;
                        if (drSuframa["aliq"].ToString() != "")
                        {
                            dvlnf = Math.Round(Convert.ToDecimal(drSuframa["aliq"].ToString()), 2); //Claudinei - o.s. 24248 - 26/03/2010
                        }

                    }
                }

                StringBuilder sDevolucao = new StringBuilder();

                //Tabela
                sDevolucao.Append("Select ");
                sDevolucao.Append("movitem.cd_doc, ");
                sDevolucao.Append("nf.cd_clifor, ");
                sDevolucao.Append("nf.dt_emi, ");
                sDevolucao.Append("movensai.dt_emi EmissaoEntrada, ");
                sDevolucao.Append("movitem.vl_totbruto ");
                sDevolucao.Append("From Movitem ");
                sDevolucao.Append("inner join NF on ");
                sDevolucao.Append("(nf.cd_empresa = Movitem.cd_empresa) ");
                sDevolucao.Append("and ");
                sDevolucao.Append("(nf.cd_nfseq = movitem.cd_nfseq) ");
                sDevolucao.Append("inner join opereve on ");
                sDevolucao.Append("(opereve.cd_oper = movitem.cd_oper) ");
                sDevolucao.Append("left join movensai on (movensai.cd_empresa = movitem.cd_empresa) ");
                sDevolucao.Append("and ");
                sDevolucao.Append("(movensai.cd_doc = movitem.cd_doc) ");
                sDevolucao.Append("and ");
                sDevolucao.Append("(movensai.cd_clifor = nf.cd_clifor) ");

                //Where
                sDevolucao.Append("Where ");
                sDevolucao.Append("(Movitem.cd_empresa ='");
                sDevolucao.Append(Acesso.CD_EMPRESA);
                sDevolucao.Append("')");
                sDevolucao.Append(" and ");
                sDevolucao.Append("(Movitem.cd_nfseq = '");
                sDevolucao.Append(seqNF);
                sDevolucao.Append("') ");
                sDevolucao.Append("and ");
                sDevolucao.Append("(opereve.ST_ESTTERC = 'S') ");
                sDevolucao.Append("and ");
                sDevolucao.Append("Movitem.cd_oper <> '202' ");
                sDevolucao.Append("and ");
                sDevolucao.Append("Movitem.cd_oper <> '227' ");
                sDevolucao.Append("Order by movitem.cd_doc");


                DataTable dtDev = HlpDbFuncoes.qrySeekRet(sDevolucao.ToString());
                List<strucDevolucoes> Devolucoes = new List<strucDevolucoes>();
                decimal dvlTotBruto = 0;
                string scdDoc = string.Empty;
                foreach (DataRow drDevolucoes in dtDev.Rows)
                {
                    if (scdDoc != drDevolucoes["cd_doc"].ToString())
                    {
                        dvlTotBruto = 0;
                    }
                    dvlTotBruto += Math.Round(Convert.ToDecimal(drDevolucoes["vl_totbruto"].ToString()), 2);
                    StringBuilder sStore = new StringBuilder();
                    sStore.Append("SELECT ");
                    sStore.Append("QT_SALDOEN ");
                    sStore.Append("FROM SP_SALDOTER('");
                    sStore.Append(Acesso.CD_EMPRESA);
                    sStore.Append("', '");
                    sStore.Append(drDevolucoes["cd_clifor"].ToString());
                    sStore.Append("', '");
                    sStore.Append("       ");
                    sStore.Append("', '");
                    sStore.Append("|||||||");
                    sStore.Append("', '");
                    sStore.Append("X");
                    sStore.Append("', '");
                    sStore.Append("N");
                    sStore.Append("', '");
                    sStore.Append(seqNF);
                    sStore.Append("', '");
                    sStore.Append(Convert.ToDateTime(drDevolucoes["dt_emi"]).ToString("dd.MM.yyyy"));
                    sStore.Append("') ");
                    sStore.Append("where SP_SALDOTER.cd_doc ='");
                    sStore.Append(drDevolucoes["cd_doc"].ToString().Trim());
                    sStore.Append("'");
                    sStore.Append(" and ");
                    sStore.Append("SP_SALDOTER.qt_saldoen > 0");

                    FbCommand cmd = new FbCommand();
                    cmd.Connection = HlpDbFuncoesGeral.conexao;
                    cmd.Connection.Open();
                    cmd.CommandText = sStore.ToString();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();

                    Int32 iSaldoTer = Convert.ToInt32(cmd.ExecuteScalar());
                    cmd.Connection.Close();
                    strucDevolucoes Devolucao = new strucDevolucoes();
                    if (drDevolucoes["cd_doc"].ToString() != "")
                    {
                        Devolucao.scdNotafis = drDevolucoes["cd_doc"].ToString();
                        if (drDevolucoes["EmissaoEntrada"] != System.DBNull.Value)
                        {
                            Devolucao.dDtEmi = Convert.ToDateTime(drDevolucoes["EmissaoEntrada"]);
                        }
                        Devolucao.dValorNF = dvlTotBruto.ToString("#0.00");
                        Devolucao.sSaldo = (iSaldoTer > 0 ? "Parcial" : "Total");
                        if (!Devolucoes.Exists(c => c.scdNotafis == Devolucao.scdNotafis))
                        {
                            Devolucoes.Add(Devolucao);
                        }
                        else
                        {
                            for (int i = 0; i < Devolucoes.Count; i++)
                            {
                                if ((Devolucoes[i].scdNotafis == Devolucao.scdNotafis) && (Devolucoes[i].dDtEmi == Devolucao.dDtEmi)) //OS_25220
                                {
                                    Devolucoes[i] = Devolucao;
                                    break;
                                }
                            }
                        }
                    }
                    scdDoc = drDevolucoes["cd_doc"].ToString();
                }
                if ((Acesso.NM_EMPRESA != "JAMAICA")) //25618
                {
                    for (int i = 0; i < Devolucoes.Count; i++)
                    {

                        if (sObs.Trim().Length > 0)
                        {
                            sObs += string.Format(" - Retorno {0} ref. sua NF {1} de {2} de valor R$ {3}", //Claudinei - o.s. 24043 - 25/01/2010
                                                  Devolucoes[i].sSaldo,
                                                  Devolucoes[i].scdNotafis,
                                                  Devolucoes[i].dDtEmi.ToString("dd/MM/yyyy"),
                                                  Devolucoes[i].dValorNF); //Claudinei - o.s. 24043 - 25/01/2010
                        }
                        else
                        {
                            sObs += string.Format("Retorno {0} ref. sua NF {1} de {2} de valor R$ {3}", //Claudinei - o.s. 24043 - 25/01/2010
                                                  Devolucoes[i].sSaldo,
                                                  Devolucoes[i].scdNotafis,
                                                  Devolucoes[i].dDtEmi.ToString("dd/MM/yyyy"),
                                                  Devolucoes[i].dValorNF); //Claudinei - o.s. 24043 - 25/01/2010

                        }
                    }
                }
                return sObs;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }

        }



        public string BuscaMsgPIS_COFINS(string seqNF)
        {

            //Monta Mensagem de PIS, COFINS
            try
            {
                StringBuilder sQuery = new StringBuilder();
                sQuery.Append("SELECT ");
                sQuery.Append("NF.VL_COFINS, NF.VL_PIS, ");
                sQuery.Append("empresa.vl_aliqpis_suframa,empresa.vl_aliqcofins_suframa, ");
                sQuery.Append("CLIFOR.st_desc_piscofins_dupl ");
                sQuery.Append("from nf inner join empresa ");
                sQuery.Append("on (nf.cd_empresa = empresa.cd_empresa)");
                sQuery.Append("inner join clifor ");
                sQuery.Append("on (nf.cd_clifor = clifor.cd_clifor) ");
                sQuery.Append("where (empresa.cd_empresa = '");
                sQuery.Append(Acesso.NM_EMPRESA);
                sQuery.Append("') ");
                sQuery.Append("and ( nf.cd_nfseq = '");
                sQuery.Append(seqNF);
                sQuery.Append("') ");

                string sMsg = "";

                foreach (DataRow drPisCofins in HlpDbFuncoes.qrySeekRet(sQuery.ToString()).Rows)
                {
                    if ((drPisCofins["st_desc_piscofins_dupl"].ToString() == "S"))
                    {
                        if ((drPisCofins["vl_aliqpis_suframa"].ToString() != "") && (drPisCofins["vl_aliqcofins_suframa"].ToString() != ""))
                        {
                            string sMensagemPisCofins = "(PIS e COFINS retido conforme artigo 3º paragrafo 4º da |lei 10.485/02, PIS "
                                                        + drPisCofins["vl_aliqpis_suframa"].ToString()
                                                        + "% R$" + drPisCofins["VL_PIS"].ToString()
                                                        + " , COFINS "
                                                        + drPisCofins["vl_aliqcofins_suframa"].ToString()
                                                        + "% R$"
                                                        + drPisCofins["VL_COFINS"].ToString()
                                                        + " Total R$" + ((Convert.ToDouble(drPisCofins["VL_PIS"].ToString())) + (Convert.ToDouble(drPisCofins["VL_COFINS"].ToString()))).ToString() + ")";
                            sMsg += (sMsg != "" ? " - " : "") + sMensagemPisCofins;
                        }
                    }
                }
                return sMsg;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public string BuscaMsgICMSrecolhido(string seqNF)
        {
            // Diego - 15/07/2010 - OS_24665
            //Obs de ICMS Recolhido por Substituição
            try
            {
                StringBuilder sQuery = new StringBuilder();
                sQuery.Append("SELECT ");
                sQuery.Append("movitem.cd_sittrib, EMPRESA.ST_SUPERSIMPLES, EMPRESA.ST_IMP_SUPERSIMPLES ");
                sQuery.Append("from empresa INNER JOIN movitem ON (EMPRESA.cd_empresa = movitem.cd_empresa)");
                sQuery.Append("where (empresa.cd_empresa = '");
                sQuery.Append(Acesso.NM_EMPRESA);
                sQuery.Append("') ");
                sQuery.Append("and ( movitem.cd_nfseq = '");
                sQuery.Append(seqNF);
                sQuery.Append("') ");



                string sMensagemIcmsRecolhido = "";

                foreach (DataRow drIcmsRecolhido in HlpDbFuncoes.qrySeekRet(sQuery.ToString()).Rows)
                {
                    if ((drIcmsRecolhido["ST_SUPERSIMPLES"].ToString() == "S") && (drIcmsRecolhido["ST_IMP_SUPERSIMPLES"].ToString() == "S"))
                    {
                        if ((drIcmsRecolhido["cd_sittrib"].ToString().Equals("010")) ||
                                    (drIcmsRecolhido["cd_sittrib"].ToString().Equals("030")) ||
                                    (drIcmsRecolhido["cd_sittrib"].ToString().Equals("060")) ||
                                    (drIcmsRecolhido["cd_sittrib"].ToString().Equals("070")))
                        {
                            sMensagemIcmsRecolhido = "ICMS RECOLHIDO POR SUBSTITUICAO TRIBUTARIA CONFORME DECRETO 54251/09 ART 313 RICMS/2000";
                            break;
                        }
                    }
                }
                return sMensagemIcmsRecolhido;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public string MessagemTotalizaCFOP(string sCd_nfseq)
        {
            try
            {
                string sCfopsTot = "";
                if (Convert.ToBoolean(Acesso.TOTALIZA_CFOP))
                {
                    StringBuilder sQuery = new StringBuilder();
                    sQuery.Append("SELECT SUM(MOVITEM.vl_totliq) vl_totliq, MOVITEM.cd_cfop FROM MOVITEM ");
                    sQuery.Append("WHERE MOVITEM.cd_nfseq = '" + sCd_nfseq + "'  AND MOVITEM.cd_empresa = '" + Acesso.CD_EMPRESA + "'");
                    sQuery.Append("GROUP BY MOVITEM.cd_cfop");

                    foreach (DataRow dr in HlpDbFuncoes.qrySeekRet(sQuery.ToString()).Rows)
                    {
                        sCfopsTot += "CFOP " + dr["cd_cfop"].ToString() + " = " + dr["vl_totliq"].ToString() + " - ";
                    }
                    if (sCfopsTot != "")
                    {
                        sCfopsTot = sCfopsTot.Remove(sCfopsTot.Length - 2, 2);
                    }
                }
                return sCfopsTot;

            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public string MessagemFunRural(string sCd_nfseq)
        {
            try
            {
                string sMsg = string.Empty;

                if (HlpDbFuncoes.fExisteCampo("DS_ANOTA_FUNRURAL", "NF"))
                {
                    sMsg = HlpDbFuncoes.qrySeekValue("NF", "ds_anota_funrural", "NF.cd_nfseq = '" + sCd_nfseq + "' AND  NF.cd_empresa = '" + Acesso.CD_EMPRESA + "'");
                }

                return sMsg;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public string BuscaMsgJAMAICA(string seqNF, string sCNPJdest)
        {
            try
            {
                string sMesgCodDest = "";
                if (!String.IsNullOrEmpty(sCNPJdest))
                {
                    if (Acesso.NM_EMPRESA.Equals("JAMAICA"))
                    {
                        StringBuilder sQuery = new StringBuilder();
                        sQuery.Append("select coalesce(clifor.cd_alter2,'') cd_alter2 from clifor ");
                        sQuery.Append("where clifor.cd_cgc ='" + sCNPJdest + "'");

                        foreach (DataRow dr in HlpDbFuncoes.qrySeekRet(sQuery.ToString()).Rows)
                        {
                            sMesgCodDest = dr["cd_alter2"].ToString();
                        }
                        if (sMesgCodDest != "")
                        {
                            sMesgCodDest = "<<COD FORNECEDOR " + sMesgCodDest + ">> ";
                        }
                    }
                }
                return sMesgCodDest;
            }
            catch (Exception)
            { throw; }
        }

        public string BuscaMsgLORENZON(string seqNF)
        {
            try
            {
                string sMsgLorenzon = "";
                if (Acesso.NM_EMPRESA.Equals("LORENZON"))
                {
                    StringBuilder sQuery = new StringBuilder();
                    sQuery.Append("select prazos.ds_prazo, vendedor.nm_vend , clifor.cd_clifor from nf ");
                    sQuery.Append("inner join clifor on nf.cd_clifor = clifor.cd_clifor ");
                    sQuery.Append("inner join prazos on nf.cd_prazo = prazos.cd_prazo ");
                    sQuery.Append(" inner join vendedor  on nf.cd_vendint = vendedor.cd_vend ");
                    sQuery.Append("where nf.cd_nfseq = '" + seqNF + "' ");
                    sQuery.Append("and nf.cd_empresa = '" + Acesso.CD_EMPRESA + "' ");

                    foreach (DataRow dr in HlpDbFuncoes.qrySeekRet(sQuery.ToString()).Rows)
                    {
                        sMsgLorenzon = "COND.PGTO = " + dr["ds_prazo"].ToString() + " | VENDEDOR = " + dr["nm_vend"].ToString() + " | COD. CLIENTE = " + dr["cd_clifor"].ToString();
                    }
                    if (sMsgLorenzon != "")
                    {
                        sMsgLorenzon = "<< " + sMsgLorenzon + " >> ";
                    }
                }
                return sMsgLorenzon;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string MensagemSuperSimples(string scdnfseq, bool bcfopValido, string CNPJdest)
        {
            string sMensagem = string.Empty;
            string StImpCredIcms = string.Empty;

            StImpCredIcms = HlpDbFuncoes.qrySeekValue("Empresa", "Coalesce(Empresa.st_imp_credicms, 'N') st_imp_credicms", "Empresa.cd_empresa = '" + Acesso.CD_EMPRESA + "'");

            if (StImpCredIcms == "S")
            {
                StringBuilder sSql = new StringBuilder();
                sSql.Append("Select ");
                sSql.Append("coalesce(movitem.vl_alicredicms,0)vl_alicredicms , ");
                sSql.Append("sum(cast((movitem.vl_credicms) as numeric(15,4))) vl_credicms ");
                sSql.Append("from movitem ");
                sSql.Append("Where ");
                sSql.Append("(movitem.cd_empresa ='");
                sSql.Append(Acesso.CD_EMPRESA);
                sSql.Append("') ");
                sSql.Append(" and ");
                sSql.Append("(movitem.cd_nfseq ='");
                sSql.Append(scdnfseq);
                sSql.Append("') ");
                sSql.Append("group by movitem.vl_alicredicms");

                DataTable dt = HlpDbFuncoes.qrySeekRet(sSql.ToString());
                foreach (DataRow dr in dt.Rows)
                {
                    if ((Convert.ToDecimal(dr["vl_credicms"].ToString()) > 0) && (Convert.ToDecimal(dr["vl_alicredicms"].ToString()) > 0)) //os_25182
                    {
                        sMensagem = string.Format("PERMITE O APROVEITAMENTO DE CREDITO DE ICMS NO VALOR DE R$ {0:C2}, CORRESPONDENTE ALIQUOTA DE {1:P2}% NOS TERMOS DO ARTIGO 23 DA LEI No 123/06",
                                                 Convert.ToDecimal(dr["vl_credicms"].ToString()).ToString("#0.00"),
                                                 Convert.ToDecimal(dr["vl_alicredicms"].ToString()).ToString("#0.00"));
                    }
                }
            }
            if ((sMensagem != "")
                   && (String.IsNullOrEmpty(CNPJdest) == false)
                   || (Acesso.NM_EMPRESA == "TERRAVIS")
                   || (Acesso.NM_EMPRESA == "TREVISO")
                   && (bcfopValido))
            {

                return sMensagem;
            }
            else
            {
                return "";
            }

        }

        private struct strucDevolucoes
        {
            public string scdNotafis { get; set; }
            public DateTime dDtEmi { get; set; }
            public string sSaldo { get; set; }
            public string dValorNF { get; set; }
        }

        private string MontaObsAgrup(string seqNota)
        {

            string sObs = "";
            StringBuilder sSql = new StringBuilder();

            //Campos do Select
            sSql.Append("Select ");
            sSql.Append("MOVITEM.cd_cfop, ");
            sSql.Append("cast(MOVITEM.vl_aliicms as numeric(15,2)) vl_aliicms, ");
            sSql.Append("cast(case when movitem.vl_redbase = 0 then ");
            sSql.Append("cast(sum(movitem.vl_totliq) as numeric(15,2)) ");
            sSql.Append("else ");
            sSql.Append("sum((movitem.vl_totliq * movitem.vl_redbase)/100) ");
            sSql.Append("end as numeric(15,2)) vl_base, ");
            sSql.Append("cast(case when movitem.vl_redbase = 0 then ");
            sSql.Append("movitem.vl_redbase ");
            sSql.Append("else ");
            sSql.Append("sum(movitem.vl_totliq - ((movitem.vl_totliq * movitem.vl_redbase)/100) ) ");
            sSql.Append("end as numeric(15,2)) Reducao, ");
            sSql.Append("cast((case when movitem.vl_redbase = 0 then ");
            sSql.Append("cast(sum(movitem.vl_totliq) as numeric(15,2)) ");
            sSql.Append("else ");
            sSql.Append("sum((movitem.vl_totliq * movitem.vl_redbase)/100) ");
            sSql.Append("end * movitem.vl_aliicms)/100 as numeric(15,2)) icms, ");
            sSql.Append("cast(case when (case when movitem.vl_redbase = 0 then ");
            sSql.Append("movitem.vl_redbase ");
            sSql.Append("else ");
            sSql.Append("sum(movitem.vl_totliq - ((movitem.vl_totliq * movitem.vl_redbase)/100) ) ");
            sSql.Append("end) = 0 then ");
            sSql.Append("0 ");
            sSql.Append("else ");
            sSql.Append("(case when movitem.vl_redbase = 0 then ");
            sSql.Append("cast(sum(movitem.vl_totliq) as numeric(15,2)) ");
            sSql.Append("else ");
            sSql.Append("sum((movitem.vl_totliq * movitem.vl_redbase)/100) ");
            sSql.Append("end) + ");
            sSql.Append("(case when movitem.vl_redbase = 0 then ");
            sSql.Append("movitem.vl_redbase ");
            sSql.Append("else ");
            sSql.Append("sum(movitem.vl_totliq - ((movitem.vl_totliq * movitem.vl_redbase)/100) ) ");
            sSql.Append("end) ");
            sSql.Append("end as numeric(15,2)) basecalcred ");

            //Tabela
            sSql.Append("From MOVITEM ");

            //Relacionamentos

            sSql.Append("INNER JOIN NF ON (NF.CD_EMPRESA = MOVITEM.CD_EMPRESA)");
            sSql.Append(" and ");
            sSql.Append("(NF.cd_nfseq = MOVITEM.cd_nfseq) ");

            //Where
            sSql.Append("Where ");
            sSql.Append("(nf.cd_empresa ='");
            sSql.Append(Acesso.CD_EMPRESA);
            sSql.Append("')");
            sSql.Append(" and ");
            sSql.Append("(nf.cd_nfseq = '");
            sSql.Append(seqNota);
            sSql.Append("') ");

            //Group By
            sSql.Append("Group By ");
            sSql.Append("MOVITEM.cd_cfop, ");
            sSql.Append("MOVITEM.vl_aliicms, ");
            sSql.Append("MOVITEM.vl_redbase, ");
            sSql.Append("nf.st_impicms_em_subst_nf");

            foreach (DataRow drObsRes in HLP.GeraXml.dao.ADO.HlpDbFuncoes.qrySeekRet(sSql.ToString()).Rows)
            {
                sObs += string.Format("CFOP {0} - Aliquota {1:P2} - Base Calculo {2:n2} - Reducao {3:n2} - ICMS {4:n2} - Base Calc Red {5:n2} ",
                                      drObsRes["cd_cfop"].ToString(),
                                      drObsRes["vl_aliicms"].ToString(),
                                      drObsRes["vl_base"].ToString(),
                                      drObsRes["Reducao"].ToString(),
                                      drObsRes["icms"].ToString(),
                                      drObsRes["BaseCalcRed"].ToString());

            }
            return sObs.Trim();
        }
    }
}
