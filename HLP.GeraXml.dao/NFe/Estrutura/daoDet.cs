using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HLP.GeraXml.Comum.Static;
using HLP.GeraXml.dao.ADO;

namespace HLP.GeraXml.dao.NFe.Estrutura
{
    public class daoDet
    {
        private class CamposSelect
        {
            public string sCampo = "";
            public string sAlias = "";
            public bool bAgrupa = false;
        }

        public static DataTable GetMed(string sNR_LANC)
        {
            try
            {
                StringBuilder sQuery = new StringBuilder();
                sQuery.Append("SELECT M.cd_prod, MED.dt_fabr, MED.dt_valid, MED.nr_lote, MED.qt_fabr ");
                sQuery.Append("FROM MOVITEM M INNER JOIN it_nf_med MED ");
                sQuery.Append("ON M.nr_lanc = MED.nr_lancmov AND M.cd_empresa = MED.cd_empresa ");
                sQuery.Append("WHERE M.nr_lanc = '{0}'  AND M.cd_empresa = '{1}' ");

                DataTable dt = HLP.GeraXml.dao.ADO.HlpDbFuncoes.qrySeekRet(string.Format(sQuery.ToString(), sNR_LANC, Acesso.CD_EMPRESA));

                return dt;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataTable BuscaItem(string seqNF, bool bEx)
        {
            List<CamposSelect> lCampos = new List<CamposSelect>();
            StringBuilder sCampos = new StringBuilder();
            StringBuilder sInnerJoin = new StringBuilder();
            StringBuilder sWhere = new StringBuilder();
            StringBuilder sGroup = new StringBuilder();

            try
            {

                #region Campos do Select
                //CD_DOC

                if (HlpDbFuncoes.fExisteCampo("CD_ANP", "PRODUTO"))
                    lCampos.Add(new CamposSelect { sCampo = "coalesce(PRODUTO.CD_ANP,'0')", sAlias = "CD_ANP" });//OS_28293
                else
                    lCampos.Add(new CamposSelect { sCampo = "'0'", sAlias = "CD_ANP" });//OS_28293

                if (HlpDbFuncoes.fExisteCampo("vl_total_impostos", "MOVITEM"))
                    lCampos.Add(new CamposSelect { sCampo = "coalesce(MOVITEM.vl_total_impostos,0)", sAlias = "vTotTrib", bAgrupa = Acesso.bAGRUPA_ITENS_NFE });//os_28878
                else
                    lCampos.Add(new CamposSelect { sCampo = "'0'", sAlias = "vTotTrib" });//os_28878

                if (HlpDbFuncoes.fExisteCampo("nr_fci", "MOVITEM"))
                    lCampos.Add(new CamposSelect { sCampo = "coalesce(MOVITEM.nr_fci,'')", sAlias = "nr_fci" });//OS_29280
                else
                    lCampos.Add(new CamposSelect { sCampo = "''", sAlias = "nr_fci" });//OS_29280

                //coalesce(m.vl_fattransp,0)vl_fattransp
                //coalesce(m.vl_aliqtransp,0)vl_aliqtransp
                lCampos.Add(new CamposSelect { sCampo = "coalesce(MOVITEM.vl_fattransp,0)", sAlias = "vl_fattransp", bAgrupa = Acesso.bAGRUPA_ITENS_NFE });//OS_29949
                lCampos.Add(new CamposSelect { sCampo = "coalesce(MOVITEM.vl_aliqtransp,0)", sAlias = "vl_aliqtransp" });//OS_29949

                lCampos.Add(new CamposSelect { sCampo = "coalesce(MOVITEM.vl_siscomex,0)", sAlias = "vl_siscomex", bAgrupa = Acesso.bAGRUPA_ITENS_NFE });//OS_28303
                lCampos.Add(new CamposSelect { sCampo = "coalesce(MOVITEM.CD_DOC,'')", sAlias = "CD_DOC" });//OS_27921
                lCampos.Add(new CamposSelect { sCampo = "coalesce(opereve.ST_ESTTERC,'N')", sAlias = "ST_ESTTERC" });//OS_27921
                lCampos.Add(new CamposSelect { sCampo = "coalesce(tpdoc.st_pauta,'N')", sAlias = "st_pauta" });//OS_25969
                lCampos.Add(new CamposSelect { sCampo = "coalesce(tpdoc.st_frete_entra_ipi_s,'N')", sAlias = "st_frete_entra_ipi_s" });//OS_26866
                lCampos.Add(new CamposSelect { sCampo = "coalesce(tpdoc.ST_FRETE_ENTRA_ICMS_S,'N')", sAlias = "ST_FRETE_ENTRA_ICMS_S" });//OS_26866
                lCampos.Add(new CamposSelect { sCampo = "coalesce(MOVITEM.vl_baseicm,0)", sAlias = "vBC_Pauta", bAgrupa = Acesso.bAGRUPA_ITENS_NFE });//OS_25969
                lCampos.Add(new CamposSelect { sCampo = "coalesce(MOVITEM.vl_icms,0)", sAlias = "vl_icms_Pauta", bAgrupa = Acesso.bAGRUPA_ITENS_NFE });//OS_25969
                lCampos.Add(new CamposSelect { sCampo = "coalesce(MOVITEM.cd_pedcli,'')", sAlias = "xPed" });//OS_25977
                lCampos.Add(new CamposSelect { sCampo = "coalesce(movitem.nr_item_ped_compra,'')", sAlias = "nItemPed" });//OS_25977
                lCampos.Add(new CamposSelect { sCampo = "coalesce(opereve.st_servico,'')", sAlias = "st_servico" });
                lCampos.Add(new CamposSelect { sCampo = "movitem.cd_oper", sAlias = "cd_oper" });
                lCampos.Add(new CamposSelect { sCampo = "coalesce(nf.st_soma_dev_tot_nf,'N')", sAlias = "st_soma_dev_tot_nf" });
                lCampos.Add(new CamposSelect { sCampo = "coalesce(produto.cd_orig_sittrib,0)", sAlias = "Orig" }); //os_26467 - CST_NOVAS
                lCampos.Add(new CamposSelect { sCampo = "movitem.cd_sittrib", sAlias = "CST" }); //CST Antiga
                lCampos.Add(new CamposSelect { sCampo = "coalesce(EMPRESA.ST_SUPERSIMPLES,'N')", sAlias = "ST_SUPERSIMPLES" }); //os_26817
                lCampos.Add(new CamposSelect { sCampo = "coalesce(MOVITEM.VL_BASEIPI,0)", sAlias = "VL_BASEIPI" }); //os_26467

                if (Acesso.IMPRIMI_NUM_PEDIDO_VENDA)
                {
                    lCampos.Add(new CamposSelect { sCampo = "coalesce(movitem.cd_pedido,'')", sAlias = "cd_pedido" });
                }
                if (Acesso.IMPRIMI_NUM_REVISAO)
                {
                    if (HlpDbFuncoes.fExisteCampo("CD_REVISAO", "MOVITEM"))
                        lCampos.Add(new CamposSelect { sCampo = "coalesce(movitem.CD_REVISAO,'')", sAlias = "CD_REVISAO" });
                    else
                        lCampos.Add(new CamposSelect { sCampo = "''", sAlias = "CD_REVISAO" });
                }

                if (Acesso.NM_RAMO == Acesso.BancoDados.INDUSTRIA) //SE FOR INDUSTRIA
                {
                    lCampos.Add(new CamposSelect { sCampo = "coalesce(tpdoc.st_compoe_vl_totprod_nf,'A')", sAlias = "st_compoe_vl_totprod_nf" });
                }
                if (Acesso.NM_EMPRESA != "MOGPLAST")
                {
                    lCampos.Add(new CamposSelect { sCampo = "case when empresa.st_codprodnfe = 'C' then produto.cd_prod else produto.cd_alter end", sAlias = "cProd" });
                }
                else
                {
                    lCampos.Add(new CamposSelect
                    {
                        sCampo = "case when empresa.nm_empresa containing 'MOGPLAST' then " +
                                 "produto.ds_detalhe " +
                                 "else " +
                                 "case when empresa.st_codprodnfe = 'C' then " +
                                 "movitem.cd_prod else " +
                                 "movitem.cd_alter end " +
                                 "End ",
                        sAlias = "cProd"
                    });
                }
                if (Acesso.COD_BARRAS_XML.ToUpper() == "TRUE")
                {
                    lCampos.Add(new CamposSelect { sCampo = "produto.cd_barras", sAlias = "cEAN" });
                }
                else
                {
                    lCampos.Add(new CamposSelect { sCampo = "produto.cd_alter", sAlias = "cEAN" });
                }
                if (Acesso.NM_EMPRESA == "NAVE_THERM")
                {
                    lCampos.Add(new CamposSelect
                    {
                        sCampo = "case when produto.ds_prod_compl is not null then " +
                            "substring(produto.ds_prod_compl from 1 for 120) " +
                            "else " +
                            "produto.ds_prod end ",
                        sAlias = "xProd"
                    });
                }
                else if (Acesso.NM_EMPRESA == "SENIRAM")
                {
                    lCampos.Add(new CamposSelect { sCampo = "produto.ds_detalhe", sAlias = "xProd" });
                }
                else
                {
                    lCampos.Add(new CamposSelect { sCampo = "movitem.ds_prod", sAlias = "xProd" });

                }
                if (Acesso.DS_DETALHE)
                {
                    if (HlpDbFuncoes.fExisteCampo("DS_DETALHE", "PRODUTO"))
                    {
                        lCampos.Add(new CamposSelect { sCampo = "produto.DS_DETALHE", sAlias = "DS_DETALHE" });
                    }
                    else
                    {
                        lCampos.Add(new CamposSelect { sCampo = "''", sAlias = "DS_DETALHE" });
                    }
                }
                lCampos.Add(new CamposSelect { sCampo = "substring(clas_fis.ds_clasfis from 1 for 15)", sAlias = "NCM" });// Diego - 21/10 Lorenzon

                lCampos.Add(new CamposSelect { sCampo = "movitem.cd_cfop", sAlias = "CFOP" });
                lCampos.Add(new CamposSelect { sCampo = "unidades.cd_unfat", sAlias = "uCom" });//Diego - OS_ 25/08/10

                lCampos.Add(new CamposSelect { sCampo = "movitem.qt_prod", sAlias = "qCom", bAgrupa = Acesso.bAGRUPA_ITENS_NFE });


                if ((Acesso.NM_EMPRESA.Equals("MAD_STA_RITA")) || (Acesso.NM_EMPRESA.Equals("CONSTRUF")))
                {
                    lCampos.Add(new CamposSelect { sCampo = "movitem.vl_comprimento", sAlias = "vl_comprimento", bAgrupa = Acesso.bAGRUPA_ITENS_NFE }); // Diego - OS_25550  
                }
                if (Acesso.NM_EMPRESA.Equals("ZINCOBRIL")) //os_25787                
                {
                    lCampos.Add(new CamposSelect { sCampo = "coalesce(opereve.tp_industrializacao,'')", sAlias = "tp_industrializacao" });
                }

                lCampos.Add(new CamposSelect { sCampo = "coalesce(vl_uniprod_sem_desc,0)", sAlias = "vl_uniprod_sem_desc", bAgrupa = Acesso.bAGRUPA_ITENS_NFE  });//cast -> OS_25771 // 6 casas decimais

                if (!bEx)
                {
                    //cast(movitem.vl_uniprod as numeric (15,5))
                    lCampos.Add(new CamposSelect { sCampo = "movitem.vl_uniprod", sAlias = "vUnCom" });//cast -> OS_25771 // 6 casas decimais
                }
                else
                {
                    lCampos.Add(new CamposSelect { sCampo = "(case when movitem.vl_uniprod_ii = 0 then movitem.vl_uniprod else movitem.vl_uniprod_ii end)", sAlias = "vUnCom", bAgrupa = Acesso.bAGRUPA_ITENS_NFE });
                }
                if (bEx) //DIEGO - OS_24730
                {
                    lCampos.Add(new CamposSelect { sCampo = "(case when movitem.vl_uniprod_ii = 0 then movitem.vl_totbruto else (movitem.vl_uniprod_ii * movitem.qt_prod) end)", sAlias = "vProd", bAgrupa = Acesso.bAGRUPA_ITENS_NFE });
                }
                else
                {
                    lCampos.Add(new CamposSelect { sCampo = "movitem.vl_totbruto", sAlias = "vProd", bAgrupa = Acesso.bAGRUPA_ITENS_NFE }); //2 casas decimais
                }//DIEGO - OS_24730 - FIM         

                lCampos.Add(new CamposSelect { sCampo = "movitem.vl_totliq", sAlias = "vl_totliq", bAgrupa = Acesso.bAGRUPA_ITENS_NFE });// Diego 0S_24595                

                if (Acesso.COD_BARRAS_XML.ToUpper() == "TRUE")
                {
                    lCampos.Add(new CamposSelect { sCampo = "produto.cd_barras", sAlias = "cEANTrib" });
                }
                else
                {
                    lCampos.Add(new CamposSelect { sCampo = "produto.cd_alter", sAlias = "cEANTrib" });
                }

                lCampos.Add(new CamposSelect { sCampo = "coalesce(movitem.vl_descsuframa,0) + coalesce(movitem.vl_desccofinssuframa,0) + coalesce(movitem.vl_descpissuframa,0)", sAlias = "vDescSuframa", bAgrupa = Acesso.bAGRUPA_ITENS_NFE });

                lCampos.Add(new CamposSelect { sCampo = "coalesce(nf.st_desc,'U')", sAlias = "st_desc" });
                lCampos.Add(new CamposSelect { sCampo = "movitem.cd_tpunid", sAlias = "uTrib" });
                lCampos.Add(new CamposSelect { sCampo = "movitem.qt_prod", sAlias = "qTrib", bAgrupa = Acesso.bAGRUPA_ITENS_NFE });


                if (!bEx)
                {
                    lCampos.Add(new CamposSelect { sCampo = "movitem.vl_uniprod", sAlias = "vUnTrib"  });
                }
                else
                {
                    // lCampos.Add(new CamposSelect { sCampo = "movitem.vl_uniprod_ii", sAlias = "vUnTrib" });
                    lCampos.Add(new CamposSelect { sCampo = "(case when movitem.vl_uniprod_ii = 0 then movitem.vl_uniprod else movitem.vl_uniprod_ii end)", sAlias = "vUnTrib" });

                    if (HlpDbFuncoes.fExisteCampo("vl_base_ii", "movitem"))
                    {
                        lCampos.Add(new CamposSelect { sCampo = "coalesce(movitem.vl_base_ii,0)", sAlias = "bii", bAgrupa = Acesso.bAGRUPA_ITENS_NFE });
                    }
                    else
                    {
                        lCampos.Add(new CamposSelect { sCampo = "'0'", sAlias = "bii" });
                    }

                    lCampos.Add(new CamposSelect { sCampo = "coalesce(movitem.vl_base_ii,0)", sAlias = "bii", bAgrupa = Acesso.bAGRUPA_ITENS_NFE });
                }
                lCampos.Add(new CamposSelect { sCampo = "coalesce(movitem.vl_ii,0)", sAlias = "vl_ii", bAgrupa = Acesso.bAGRUPA_ITENS_NFE });
                lCampos.Add(new CamposSelect { sCampo = "coalesce(nf.st_ipi,'S')", sAlias = "st_ipi" }); //OS_25673
                lCampos.Add(new CamposSelect { sCampo = "movitem.vl_alicredicms", sAlias = "pCredSN" });//NFe_2.0
                lCampos.Add(new CamposSelect { sCampo = "movitem.vl_credicms", sAlias = "vCredICMSSN", bAgrupa = Acesso.bAGRUPA_ITENS_NFE }); // **

                #region BC_ICMS
                if (!bEx)
                {
                    List<string> lClientesLiberados = new List<string>();
                    lClientesLiberados.Add("CALDLASER");
                    lClientesLiberados.Add("ALPHAFLEX");
                    lClientesLiberados.Add("BENGALAS");
                    lClientesLiberados.Add("MASTERFEW");



                    //if (lClientesLiberados.Contains(Acesso.NM_EMPRESA.ToUpper()))
                    if (true) // liberado para todos os clientes
                    {
                        lCampos.Add(new CamposSelect
                        {
                            sCampo = "coalesce(MOVITEM.vl_baseicm,0)",
                            sAlias = "vBC",
                            bAgrupa = Acesso.bAGRUPA_ITENS_NFE
                        });
                    }
                    else
                    {
                        lCampos.Add(new CamposSelect
                        {
                            sCampo = GetSelectVbc(),
                            sAlias = "vBC",
                            bAgrupa = Acesso.bAGRUPA_ITENS_NFE
                        });
                    }
                }
                else
                {
                    lCampos.Add(new CamposSelect { sCampo = "movitem.vl_baseicm", sAlias = "vBC", bAgrupa = Acesso.bAGRUPA_ITENS_NFE });
                }
                #endregion

                lCampos.Add(new CamposSelect { sCampo = "coalesce(movitem.vl_bicmproprio_subst,0) ", sAlias = "vBCProp", bAgrupa = Acesso.bAGRUPA_ITENS_NFE });// Diego OS_25278
                lCampos.Add(new CamposSelect { sCampo = "movitem.vl_aliicms", sAlias = "pICMS" });//Diego - OS_24730


                if (bEx)
                {
                    lCampos.Add(new CamposSelect { sCampo = "movitem.vl_icms", sAlias = "vICMS", bAgrupa = Acesso.bAGRUPA_ITENS_NFE });
                }
                else
                {
                    lCampos.Add(new CamposSelect { sCampo = "(movitem.vl_icms + movitem.vl_icmproprio_subst)", sAlias = "vICMS", bAgrupa = Acesso.bAGRUPA_ITENS_NFE });
                }
                //os_26817 - FIM

                lCampos.Add(new CamposSelect
                {
                    sCampo = "case when coalesce(tpdoc.st_nfcompl,'N') = 'N' then " +
                        "coalesce(movitem.vl_bicmssubst, 0) " +
                        "else " +
                        "nf.VL_BICMSSU " +
                        "end ",
                    sAlias = "vBCST",
                    bAgrupa = Acesso.bAGRUPA_ITENS_NFE
                });

                lCampos.Add(new CamposSelect { sCampo = "coalesce(icm.vl_aliinte, 0)", sAlias = "pICMSST" });

                lCampos.Add(new CamposSelect
                {
                    sCampo = "case when coalesce(tpdoc.st_nfcompl,'N') = 'N' then "
                        + "coalesce(movitem.vl_icmretsubst, 0) "
                        + "else "
                        + "nf.VL_ICMSSUB "
                        + "end ",
                    sAlias = "vICMSST",
                    bAgrupa = Acesso.bAGRUPA_ITENS_NFE
                });

                lCampos.Add(new CamposSelect { sCampo = "(100-coalesce(movitem.vl_redbase, 0)) ", sAlias = "pRedBC", bAgrupa = Acesso.bAGRUPA_ITENS_NFE });
                lCampos.Add(new CamposSelect { sCampo = "coalesce(icm.vl_alisubs, 0)", sAlias = "pMVAST" });
                lCampos.Add(new CamposSelect { sCampo = "(100-coalesce(movitem.vl_redbase, 0))", sAlias = "pRedBCST", bAgrupa = Acesso.bAGRUPA_ITENS_NFE });
                lCampos.Add(new CamposSelect { sCampo = "coalesce(movitem.vl_aliipi, 0)", sAlias = "pIPI" });
                lCampos.Add(new CamposSelect { sCampo = "coalesce(movitem.vl_ipi, 0)", sAlias = "vIPI", bAgrupa = Acesso.bAGRUPA_ITENS_NFE });
                if (Acesso.bAGRUPA_ITENS_NFE == false)
                {
                    lCampos.Add(new CamposSelect { sCampo = "nf.ds_anota", sAlias = "infAdProd", });
                }

                lCampos.Add(new CamposSelect { sCampo = "coalesce(clas_fis.st_tributacao, '1')", sAlias = "Tributa_ipi" });
                lCampos.Add(new CamposSelect { sCampo = "tpdoc.tp_doc", sAlias = "tp_doc" });

                lCampos.Add(new CamposSelect
                {
                    sCampo = "case when tpdoc.tp_doc = 'NS' then "
                        + "opereve.ST_CALCIPI_FA "
                        + "else "
                        + "opereve.st_ipi "
                        + "end ",
                    sAlias = "Calcula_IPI"
                });

                lCampos.Add(new CamposSelect { sCampo = "coalesce(opereve.st_hefrete, 'N')", sAlias = "st_hefrete" });

                lCampos.Add(new CamposSelect { sCampo = "opereve.st_piscofins", sAlias = "st_piscofins" });

                lCampos.Add(new CamposSelect { sCampo = "coalesce(movitem.vl_frete, 0)", sAlias = "vFrete", bAgrupa = Acesso.bAGRUPA_ITENS_NFE });

                if (Acesso.bAGRUPA_ITENS_NFE == false)
                {
                    lCampos.Add(new CamposSelect { sCampo = "movitem.nr_lanc", sAlias = "nr_lanc" });
                }
                else
                {
                    lCampos.Add(new CamposSelect { sCampo = "0", sAlias = "nr_lanc", bAgrupa = Acesso.bAGRUPA_ITENS_NFE });
                }
                if (bEx)
                {
                    lCampos.Add(new CamposSelect { sCampo = "coalesce(movitem.vl_aliqcofins_cif , 0)", sAlias = "vl_aliqcofins_suframa", bAgrupa = Acesso.bAGRUPA_ITENS_NFE });//DIEGO - 24730 - 02/08
                    lCampos.Add(new CamposSelect { sCampo = "coalesce(movitem.VL_ALIQPIS_CIF  , 0)", sAlias = "vl_aliqpis_suframa", bAgrupa = Acesso.bAGRUPA_ITENS_NFE });
                }
                else
                {
                    lCampos.Add(new CamposSelect { sCampo = "coalesce(movitem.vl_percofins, 0)", sAlias = "vl_aliqcofins_suframa", bAgrupa = Acesso.bAGRUPA_ITENS_NFE });
                    lCampos.Add(new CamposSelect { sCampo = "coalesce(movitem.vl_perpis, 0)", sAlias = "vl_aliqpis_suframa", bAgrupa = Acesso.bAGRUPA_ITENS_NFE });
                }
                lCampos.Add(new CamposSelect { sCampo = "endentr.ds_endent", sAlias = "xLgr" });
                lCampos.Add(new CamposSelect { sCampo = "endentr.ds_endent", sAlias = "xLgr" });
                lCampos.Add(new CamposSelect { sCampo = "endentr.nr_endent", sAlias = "nro" });
                lCampos.Add(new CamposSelect { sCampo = "endentr.nm_bairroent", sAlias = "xBairro" });
                lCampos.Add(new CamposSelect { sCampo = "endentr.nm_cident", sAlias = "cMun" });
                lCampos.Add(new CamposSelect { sCampo = "endentr.cd_ufent", sAlias = "UF" });
                lCampos.Add(new CamposSelect { sCampo = "listaserv.ds_codigo", sAlias = "cListserv" });
                lCampos.Add(new CamposSelect { sCampo = "coalesce(movitem.vl_aliqserv, 0)", sAlias = "vAliqISS", bAgrupa = Acesso.bAGRUPA_ITENS_NFE });

                lCampos.Add(new CamposSelect { sCampo = "(movitem.vl_totliq * coalesce(movitem.vl_aliqserv, 0))/100", sAlias = "vIssqn", bAgrupa = Acesso.bAGRUPA_ITENS_NFE });

                lCampos.Add(new CamposSelect { sCampo = "movitem.vl_totliq", sAlias = "vBCISS", bAgrupa = Acesso.bAGRUPA_ITENS_NFE });

                lCampos.Add(new CamposSelect { sCampo = "cidades.cd_municipio", sAlias = "cMunFG" });

                lCampos.Add(new CamposSelect { sCampo = "movitem.VL_COEF", sAlias = "VL_COEF" });
                if (bEx)  //Diego - 02/08 - 24730
                {
                    lCampos.Add(new CamposSelect { sCampo = "movitem.VL_COFINS", sAlias = "vl_cofins", bAgrupa = Acesso.bAGRUPA_ITENS_NFE });
                    lCampos.Add(new CamposSelect { sCampo = "movitem.VL_PIS", sAlias = "vl_pis", bAgrupa = Acesso.bAGRUPA_ITENS_NFE });
                }
                else
                {
                    lCampos.Add(new CamposSelect { sCampo = "movitem.vl_cofins", sAlias = "vl_cofins", bAgrupa = Acesso.bAGRUPA_ITENS_NFE });
                    lCampos.Add(new CamposSelect { sCampo = "movitem.vl_pis", sAlias = "vl_pis", bAgrupa = Acesso.bAGRUPA_ITENS_NFE });
                }
                lCampos.Add(new CamposSelect { sCampo = "movitem.vl_basecofins", sAlias = "vl_basecofins", bAgrupa = Acesso.bAGRUPA_ITENS_NFE });
                lCampos.Add(new CamposSelect { sCampo = "coalesce(movitem.vl_basepis,0)", sAlias = "vl_basepis", bAgrupa = Acesso.bAGRUPA_ITENS_NFE });

                if (Acesso.NM_RAMO == Acesso.BancoDados.INDUSTRIA)
                {
                    lCampos.Add(new CamposSelect
                    {
                        sCampo = "case when empresa.ST_RASTREABILIDADE = '1' " +
                            "then " +
                            "coalesce(movitem.nr_lote,'') " +
                            "else '' " +
                            "end",
                        sAlias = "nr_lote"
                    });
                    lCampos.Add(new CamposSelect { sCampo = "movitem.cd_prodcli", sAlias = "cd_prodcli" });
                }

                if (Acesso.NM_EMPRESA == "MARPA")
                {

                    lCampos.Add(new CamposSelect { sCampo = "nf.vl_desccomer ", sAlias = "Desconto_Valor" });
                    lCampos.Add(new CamposSelect { sCampo = "(case when coalesce(nf.vl_totnf,0) > 0 then ((nf.vl_desccomer / nf.vl_totnf)*100) else '0' end)", sAlias = "Desconto_Percentual" });
                }
                lCampos.Add(new CamposSelect { sCampo = "movitem.CD_SITTRIBCOF", sAlias = "CD_SITTRIBCOF" });
                lCampos.Add(new CamposSelect { sCampo = "movitem.CD_SITTRIBIPI", sAlias = "CD_SITTRIBIPI" });
                lCampos.Add(new CamposSelect { sCampo = "movitem.CD_SITTRIBPIS", sAlias = "CD_SITTRIBPIS" });
                lCampos.Add(new CamposSelect { sCampo = "coalesce(movitem.vl_outras,'0') ", sAlias = "vOutro" });
                lCampos.Add(new CamposSelect { sCampo = "coalesce(opereve.st_tpoper,'0')", sAlias = "st_tpoper" });
                lCampos.Add(new CamposSelect { sCampo = "coalesce(opereve.ST_ESTTERC,'N')", sAlias = "ST_ESTTERC" });//NFe_2.0 OS_25346
                lCampos.Add(new CamposSelect { sCampo = "tpdoc.cd_operval", sAlias = "cd_operval" });
                lCampos.Add(new CamposSelect { sCampo = "coalesce(Empresa.st_imp_cdpedcli, 'N')", sAlias = "st_imp_cdpedcli" });
                lCampos.Add(new CamposSelect { sCampo = "transpor.nm_trans", sAlias = "Redespacho" });
                lCampos.Add(new CamposSelect { sCampo = "transpor.ds_endnor", sAlias = "xLgrRedes" });
                lCampos.Add(new CamposSelect { sCampo = "transpor.cd_cgc", sAlias = "Transpcd_cgc" });
                lCampos.Add(new CamposSelect { sCampo = "transpor.nr_endnor", sAlias = "nroRedes" });
                lCampos.Add(new CamposSelect { sCampo = "transpor.ds_bairronor", sAlias = "xBairroRedes" });
                lCampos.Add(new CamposSelect { sCampo = "transpor.nm_cidnor", sAlias = "cmunRedes" });
                lCampos.Add(new CamposSelect { sCampo = "transpor.cd_ufnor", sAlias = "UFRedes" });

                #endregion

                sCampos.Append(Environment.NewLine + "Select " + Environment.NewLine);
                lCampos = lCampos.OrderBy(c => c.bAgrupa).ToList();
                for (int i = 0; i < lCampos.Count; i++)
                {
                    CamposSelect camp = lCampos[i];
                    string sFormat = "Sum({0}) ";
                    sCampos.Append((camp.bAgrupa ? string.Format(sFormat, camp.sCampo) : camp.sCampo) + " " + camp.sAlias + ((i + 1) != lCampos.Count() ? "," : "") + Environment.NewLine);
                }


                #region Inner Join
                //Tabelas
                sInnerJoin.Append("From MOVITEM ");

                //Relacionamentos
                sInnerJoin.Append("inner join nf on (nf.cd_empresa = movitem.cd_empresa)");
                sInnerJoin.Append(" and ");
                sInnerJoin.Append("(nf.cd_nfseq = movitem.cd_nfseq) ");
                sInnerJoin.Append("inner join empresa on (empresa.cd_empresa = movitem.cd_empresa) ");
                sInnerJoin.Append("inner join unidades on (movitem.cd_tpunid = unidades.cd_tpunid) "); // Diego - OS_ 25/08/10
                sInnerJoin.Append("left join clas_fis on (clas_fis.cd_empresa = movitem.cd_empresa)");
                sInnerJoin.Append(" and ");
                sInnerJoin.Append("(clas_fis.cd_cf = movitem.cd_cf) ");
                sInnerJoin.Append("left join icm on (icm.cd_ufnor = nf.cd_ufnor) ");
                sInnerJoin.Append("And ");
                sInnerJoin.Append("(icm.cd_aliicms = movitem.cd_aliicms) ");
                sInnerJoin.Append("left join opereve on (opereve.cd_oper = movitem.cd_oper) ");
                sInnerJoin.Append("left join tpdoc on (tpdoc.cd_tipodoc = nf.cd_tipodoc) ");
                sInnerJoin.Append("left join produto ");
                sInnerJoin.Append("on (produto.cd_empresa = movitem.cd_empresa) ");
                sInnerJoin.Append("and ");
                sInnerJoin.Append("(produto.cd_prod = movitem.cd_prod) ");
                sInnerJoin.Append("left join linhapro ");
                sInnerJoin.Append("on (linhapro.cd_empresa = produto.cd_empresa) ");
                sInnerJoin.Append("and ");
                sInnerJoin.Append("(linhapro.cd_linha = produto.cd_linha) ");
                sInnerJoin.Append("left join listaserv ");
                sInnerJoin.Append("on (listaserv.nr_lanc = linhapro.nr_lanclistaserv) ");
                sInnerJoin.Append("inner join clifor ");
                sInnerJoin.Append("on (clifor.cd_clifor = nf.cd_clifor) ");
                sInnerJoin.Append("left join cidades ");
                //sInnerJoin.Append("on (cidades.nm_cidnor = clifor.nm_cidnor) ");
                sInnerJoin.Append("on (cidades.cd_municipio = clifor.cd_municipio) ");
                //cidades.cd_municipio = clifor.cd_municipio
                sInnerJoin.Append("and ");
                sInnerJoin.Append("(cidades.cd_ufnor = clifor.cd_ufnor) ");
                sInnerJoin.Append("inner join uf on (clifor.cd_ufnor = uf.cd_uf) ");//25385
                sInnerJoin.Append("left join endentr on (endentr.cd_cliente = nf.cd_clifor) ");
                sInnerJoin.Append("and ");
                sInnerJoin.Append(" (endentr.cd_endent = nf.cd_endent) ");
                if ((Acesso.NM_EMPRESA == "NAVE_THERM") || (Acesso.NM_EMPRESA == "MOGPLAST"))
                {
                    sInnerJoin.Append("left join produto on (produto.cd_empresa = movitem.cd_empresa) ");
                    sInnerJoin.Append("And ");
                    sInnerJoin.Append("(produto.cd_prod = movitem.cd_prod)");
                }
                sInnerJoin.Append("left join transpor on (transpor.cd_trans = nf.cd_redes) ");
                #endregion

                #region Where
                sWhere.Append("Where ");
                sWhere.Append("(movitem.cd_empresa ='");
                sWhere.Append(Acesso.CD_EMPRESA);
                sWhere.Append("')");
                sWhere.Append(" and ");
                sWhere.Append("(nf.cd_nfseq = '");
                sWhere.Append(seqNF);
                sWhere.Append("') ");
                sWhere.Append((Acesso.bAGRUPA_ITENS_NFE == false ? "Order by movitem.nr_lanc" : ""));
                #endregion

                if (Acesso.bAGRUPA_ITENS_NFE)
                {
                    sGroup.Append(Environment.NewLine + " Group by " + Environment.NewLine);
                    lCampos = lCampos.Where(c => c.bAgrupa == false).ToList();
                    for (int i = 0; i < lCampos.Count; i++)
                    {
                        CamposSelect camp = lCampos[i];
                        if (camp.sCampo != "''")
                        {
                            sGroup.Append((camp.bAgrupa == false ? camp.sCampo + ((i + 1) < lCampos.Count() ? ", " : "") + Environment.NewLine : ""));
                        }
                    }
                }


                string sQueryItens = sCampos.ToString() + sInnerJoin + sWhere + (Acesso.bAGRUPA_ITENS_NFE ? sGroup.ToString() : "");

                return HlpDbFuncoes.qrySeekRet(sQueryItens.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static string GetSelectVbc()
        {
            return "case when coalesce(tpdoc.st_nfcompl, 'N') = 'N' then " +
                                             "case when coalesce(tpdoc.st_nfcompl, 'N') = 'N' then " +
                                             "case when coalesce(nf.st_ipi,'N') = 'N' then " +
                                             "CASE when (SELECT SUM(VL_TOTBRUTO) FROM movitem where ((movitem.cd_empresa = nf.cd_empresa) and (MOVITEM.cd_nfseq = NF.cd_nfseq))) > NF.vl_totprod then " +
                                             "((case when movitem.vl_redbase <> 0 then " +
                                             "case when  coalesce((select first 1 ST_ESTTERC from opereve where ((ST_ESTTERC = 'S') and ((TPDOC.cd_operval) containing cd_oper  ))),'N') = 'N' then " +
                                             "(movitem.vl_totliq - ((SELECT SUM(VL_TOTBRUTO) FROM movitem where ((movitem.cd_empresa = nf.cd_empresa) and (MOVITEM.cd_nfseq = NF.cd_nfseq))) - NF.vl_totprod) / ((SELECT COUNT(NR_LANC) FROM movitem where movitem.cd_empresa = nf.cd_empresa and MOVITEM.cd_nfseq = NF.cd_nfseq) )) - (((100-coalesce(movitem.vl_redbase, 100)) * (movitem.vl_totliq - ((SELECT SUM(VL_TOTBRUTO) FROM movitem where ((movitem.cd_empresa = nf.cd_empresa) and (MOVITEM.cd_nfseq = NF.cd_nfseq))) - NF.vl_totprod) / ((SELECT COUNT(NR_LANC) FROM movitem where movitem.cd_empresa = nf.cd_empresa and MOVITEM.cd_nfseq = NF.cd_nfseq) )))/ 100) " +
                                             "else " +
                                             "movitem.vl_totliq - (((100-coalesce(movitem.vl_redbase, 100)) * movitem.vl_totliq)/ 100) " +
                                             "end " +
                                             "else " +
                                             "movitem.vl_totliq " +
                                             "end +(case when (coalesce(tpdoc.ST_FRETE_ENTRA_ICMS_S,'N') <> 'N') AND (UF.VL_ALIICMSFRETE > 0) then  movitem.vl_frete else 0 end))) " +//OS 25385
                                             "else " +
                                             "((case when movitem.vl_redbase <> 0 then  " +
                                             "movitem.vl_totliq - (((100-coalesce(movitem.vl_redbase, 100)) * movitem.vl_totliq)/ 100) " +
                                             "else " +
                                             "movitem.vl_totliq " +
                                             "end + (case when (coalesce(tpdoc.ST_FRETE_ENTRA_ICMS_S,'N') <> 'N') AND (UF.VL_ALIICMSFRETE > 0) then  movitem.vl_frete else 0 end))) " +
                                             "end " +
                                             "else " +
                                             "(CASE when (SELECT SUM(VL_TOTBRUTO) FROM movitem where movitem.cd_empresa = nf.cd_empresa and MOVITEM.cd_nfseq = NF.cd_nfseq) > NF.vl_totprod then " +
                                             "((case when movitem.vl_redbase <> 0 then " +
                                             "(movitem.vl_totliq - ((SELECT SUM(VL_TOTBRUTO) FROM movitem where movitem.cd_empresa = nf.cd_empresa and MOVITEM.cd_nfseq = NF.cd_nfseq) - NF.vl_totprod) / ((SELECT COUNT(NR_LANC) FROM movitem where movitem.cd_empresa = nf.cd_empresa and MOVITEM.cd_nfseq = NF.cd_nfseq) )) - (((100-coalesce(movitem.vl_redbase, 100)) * (movitem.vl_totliq - ((SELECT SUM(VL_TOTBRUTO) FROM movitem where movitem.cd_empresa = nf.cd_empresa and MOVITEM.cd_nfseq = NF.cd_nfseq) - NF.vl_totprod) / ((SELECT COUNT(NR_LANC) FROM movitem where movitem.cd_EMPRESA = NF.CD_EMPRESA AND MOVITEM.cd_nfseq = NF.cd_nfseq) )))/ 100) " +
                                             "else " +
                                             "movitem.vl_totliq " +
                                             "end " +
                                             " + (case when (coalesce(tpdoc.ST_FRETE_ENTRA_ICMS_S,'N') <> 'N') AND (UF.VL_ALIICMSFRETE > 0) then  movitem.vl_frete else 0 end))) " +
                                             "else " +
                                             "((case when movitem.vl_redbase <> 0 then " +
                                             "movitem.vl_totliq - (((100-coalesce(movitem.vl_redbase, 100)) * movitem.vl_totliq)/ 100) " +
                                             "else " +
                                             "movitem.vl_totliq " +
                                             "end + (case when (coalesce(tpdoc.ST_FRETE_ENTRA_ICMS_S,'N') <> 'N') AND (UF.VL_ALIICMSFRETE > 0) then  movitem.vl_frete else 0 end))) " +
                                             "end) + movitem.vl_ipi " +
                                             " end " +
                                             " end " +
                                             " else " +
                                             " nf.vl_baseicm " +
                                             " end ";
        }

        public static string BuscaUltimoNrLancMovitem(string seqNF)
        {
            string sNr_Lanc;
            string sql = "select max(nr_lanc) from movitem where (movitem.cd_empresa ='" +
                                                 Acesso.CD_EMPRESA +
                                                 "') and " +
                                                 "(movitem.cd_nfseq = '" +
                                                 seqNF +
                                                 "') ";

            sNr_Lanc = HlpDbFuncoes.qrySeekValue("movitem", "max(nr_lanc)", "(movitem.cd_empresa ='" + Acesso.CD_EMPRESA + "') and " + "(movitem.cd_nfseq = '" + seqNF + "') ");
            return sNr_Lanc;
        }

        public static bool bIndustrializacao(string sOperacoesValidas)
        {
            bool bIndustrializacao = false;

            string sOperValid = "'" + sOperacoesValidas.Replace(",", "','");
            string sScalar = HlpDbFuncoes.qrySeekValue("opereve", "first 1 ST_ESTTERC", "(ST_ESTTERC = 'S') and (cd_oper in (" + sOperValid + "'))");
            if (sScalar.Equals("S"))
            {
                bIndustrializacao = true;
            }
            return bIndustrializacao;
        }

        /// <summary>
        ///  A NF SUFRAMA, OU SEJA NA TABELA "CLIFOR" OS CAMPOS "CD_SUFRAMA" IS NOT NULL E "ST_DESCSUFRAMA" = S
        /// </summary>
        /// <param name="sEmp"></param>
        /// <param name="seqNF"></param>
        /// <param name="Conn"></param>
        /// <returns></returns>
        public static bool VerificaNotaComSuframa(string seqNF)
        {
            try
            {
                StringBuilder sQuery = new StringBuilder();
                sQuery.Append("select nf.cd_nfseq, clifor.cd_suframa,clifor.st_descsuframa ");
                sQuery.Append("from nf inner join clifor on ");
                sQuery.Append("nf.cd_clifor = clifor.cd_clifor ");
                sQuery.Append("where  nf.cd_nfseq = '" + seqNF + "' and ");
                sQuery.Append("nf.cd_empresa = '" + Acesso.CD_EMPRESA + "'");

                bool bValida = false;

                foreach (DataRow dr in HlpDbFuncoes.qrySeekRet(sQuery.ToString()).Rows)
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

        public static decimal BuscaDescTotal(string sNF, bool pbIndustri)
        {
            decimal dvlTotProd = 0;
            decimal dvlTotItens = 0;
            decimal vl_Desconto = 0;
            decimal dQTItens = 0;

            StringBuilder SqlTotProd = new StringBuilder();
            SqlTotProd.Append("Select (vl_totprod + vl_servico) vl_totprod ");
            SqlTotProd.Append("from nf ");
            SqlTotProd.Append("where ");
            SqlTotProd.Append("(nf.cd_empresa ='");
            SqlTotProd.Append(Acesso.CD_EMPRESA);
            SqlTotProd.Append("') and ");
            SqlTotProd.Append("(nf.cd_nfseq = '");
            SqlTotProd.Append(sNF);
            SqlTotProd.Append("') ");

            DataTable dt = HlpDbFuncoes.qrySeekRet(SqlTotProd.ToString());
            {
                dvlTotProd = Math.Round(Convert.ToDecimal(dt.Rows[0]["vl_totprod"].ToString()), 2);
            }

            StringBuilder SqlTotItens = new StringBuilder();
            SqlTotItens.Append("Select sum(vl_totbruto) vl_totbruto ");
            SqlTotItens.Append("from movitem ");
            SqlTotItens.Append("where ");
            SqlTotItens.Append("(movitem.cd_empresa ='");
            SqlTotItens.Append(Acesso.CD_EMPRESA);
            SqlTotItens.Append("') and ");
            SqlTotItens.Append("(movitem.cd_nfseq = '");
            SqlTotItens.Append(sNF);
            SqlTotItens.Append("') ");

            dt = HlpDbFuncoes.qrySeekRet(SqlTotItens.ToString());
            {
                dvlTotItens = Math.Round(Convert.ToDecimal(dt.Rows[0]["vl_totbruto"].ToString()), 2);
            }

            StringBuilder SqlQtItens = new StringBuilder();
            SqlQtItens.Append("Select count(nr_lanc) contador ");
            SqlQtItens.Append("from movitem ");
            SqlQtItens.Append("where ");
            SqlQtItens.Append("(movitem.cd_empresa ='");
            SqlQtItens.Append(Acesso.CD_EMPRESA);
            SqlQtItens.Append("') and ");
            SqlQtItens.Append("(movitem.cd_nfseq = '");
            SqlQtItens.Append(sNF);
            SqlQtItens.Append("') ");

            dt = HlpDbFuncoes.qrySeekRet(SqlQtItens.ToString());
            {
                dQTItens = Math.Round(Convert.ToDecimal(dt.Rows[0]["contador"].ToString()), 2);
            }

            if (dvlTotProd < dvlTotItens)
            {
                vl_Desconto = ((dvlTotItens - dvlTotProd) / dQTItens);

            }
            if (pbIndustri)
            {
                vl_Desconto = 0;
            }
            else if (Acesso.NM_EMPRESA == "EMEB")
            {
                vl_Desconto = 0;
            }
            return vl_Desconto;
        }

        public static string VerificaEmpresaSimplesNac()
        {
            StringBuilder sqlSimplesNac = new StringBuilder();
            sqlSimplesNac.Append("Select ");
            sqlSimplesNac.Append(" coalesce(empresa.st_supersimples,'N')st_supersimples from empresa where (empresa.cd_empresa = '");
            sqlSimplesNac.Append(Acesso.CD_EMPRESA);
            sqlSimplesNac.Append("')");
            return HlpDbFuncoes.qrySeekRet(sqlSimplesNac.ToString()).Rows[0]["st_supersimples"].ToString();

        }

        public static string BuscaObsItemSimples(string psNrLanc)
        {
            string sOBS = string.Empty;
            if (!psNrLanc.Equals("0"))
            {
                try
                {
                    StringBuilder sSql = new StringBuilder();
                    sSql.Append("Select ");
                    sSql.Append("ds_obs ");
                    sSql.Append("From Movitem ");
                    sSql.Append("where cd_empresa = '");
                    sSql.Append(Acesso.CD_EMPRESA);
                    sSql.Append("'");
                    sSql.Append(" and ");
                    sSql.Append("nr_lanc = '");
                    sSql.Append(psNrLanc);
                    sSql.Append("'");
                    string x = HlpDbFuncoes.qrySeekRet(sSql.ToString()).Rows[0]["ds_obs"].ToString();
                    if (x != "")
                    {
                        sOBS += string.Format("{0}OBS {1}",
                                              (sOBS != "" ? " - " : ""),
                                              x);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(string.Format("Não foi possivel gerar a OBS dos Itens , Erro.: {0}",
                                                      ex.Message));
                }
            }
            return sOBS;
        }


    }
}
