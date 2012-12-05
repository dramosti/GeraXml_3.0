using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HLP.GeraXml.dao.NFe.Estrutura;
using HLP.GeraXml.Comum.Static;
using HLP.GeraXml.dao.NFe.Especifico;

namespace HLP.GeraXml.bel.NFe.Estrutura
{
    public class belDet : daoDet
    {
        public string tp_industrializacao { get; set; }
        public bool pbIndustri = false;
        public decimal nitem { get; set; }

        public decimal dTotbaseICMS = 0;
        public decimal dTotValorICMS = 0;
        public decimal dTotPisISS = 0;
        public decimal dTotCofinsISS = 0;
        public decimal dTotServ = 0;
        public decimal dTotBCISS = 0;
        public decimal dTotISS = 0;

        public string Cprod = "";

        public belProd prod = new belProd();
        public belImposto imposto = new belImposto();
        public belInfadprod infAdProd = new belInfadprod();


        private static string RetiraCaracterEsquerda(string sCOnteudo, char sCaracter)
        {
            string Retorno = sCOnteudo;
            int iQtCaracter = 0;

            for (int i = 0; i < Retorno.Length; i++)
            {
                if (Retorno[i] == sCaracter)
                {
                    iQtCaracter++;
                }
                else
                {
                    Retorno = Retorno.Remove(0, iQtCaracter);
                    break;
                }
            }

            return Retorno.Trim();
        }

        public List<belDet> Carrega(string seqNF, bool bEx, string xUFclifor)
        {
            try
            {
                List<belDet> objListaRet = new List<belDet>();
                DataTable dt = BuscaItem(seqNF, bEx);
                string sNr_Lanc = BuscaUltimoNrLancMovitem(seqNF);
                int iSeqItem = 0;
                decimal dTotPis = 0;
                string sSimplesNac = VerificaEmpresaSimplesNac();
                foreach (DataRow drIItem in dt.Rows)
                {
                    belDet objDet = new belDet();
                    try
                    {
                        int indTot = 1;
                        objDet.Cprod = Util.TiraSimbolo(drIItem["cProd"].ToString().Trim(), "");
                        #region prod
                        if (Acesso.NM_RAMO == Acesso.BancoDados.INDUSTRIA)
                        {
                            if (drIItem["st_compoe_vl_totprod_nf"].ToString().Equals("A")) //Verifica se ambos os produtos vão entrar no total da nota
                            {
                                indTot = 1;
                            }
                            else if (drIItem["st_compoe_vl_totprod_nf"].ToString().Equals("D")) // verifica se movimenta estoque terceiro!! S - SIM / N-NÃO
                            {
                                indTot = (drIItem["ST_ESTTERC"].ToString().Equals("S") ? 1 : 0);
                            }
                            else if (drIItem["st_compoe_vl_totprod_nf"].ToString().Equals("P"))
                            {
                                indTot = (drIItem["st_tpoper"].ToString().Equals("0") ? 1 : 0);  // verifica se representa faturamento!! 0- SIM - 1 -NÃO
                            }
                            //OS_25346 INICIO - FIM 
                        }
                        else
                        {
                            indTot = 1;
                        }

                        belImposto objimp = new belImposto();
                        iSeqItem++;
                        objDet.nitem = Convert.ToDecimal(iSeqItem.ToString().Trim());
                        objDet.prod.nitem = objDet.nitem;
                        objDet.prod.Cprod = Util.TiraSimbolo(drIItem["cProd"].ToString().Trim(), "");

                        if (Acesso.NM_EMPRESA == "ZINCOBRIL") // OS_25787
                        {
                            objDet.tp_industrializacao = drIItem["tp_industrializacao"].ToString();
                        }
                        if (Acesso.NM_EMPRESA == "ESTACAHC")
                        {
                            objDet.prod.Xprod = drIItem["qCom"].ToString() + "  " + drIItem["xProd"].ToString().Trim();
                        }
                        else
                        {
                            objDet.prod.Xprod = drIItem["xProd"].ToString().Trim();
                        }

                        if (Acesso.DS_DETALHE)
                        {
                            if (drIItem["DS_DETALHE"].ToString().Trim().Equals(drIItem["xProd"].ToString().Trim()))
                            {
                                objDet.prod.Xprod = drIItem["xProd"].ToString().Trim();
                            }
                            else
                            {
                                if (!drIItem["DS_DETALHE"].ToString().Trim().Equals(""))
                                {
                                    objDet.prod.Xprod = drIItem["xProd"].ToString().Trim() + " - " + drIItem["DS_DETALHE"].ToString().Trim();
                                }
                                else
                                {
                                    objDet.prod.Xprod = drIItem["xProd"].ToString().Trim();
                                }
                            }

                            if (objDet.prod.Xprod.Length > 120)
                            {
                                objDet.prod.Xprod = objDet.prod.Xprod.Substring(0, 119);
                            }
                        }

                        if (drIItem["NCM"].ToString() != "")
                        {
                            objDet.prod.Ncm = ((Util.TiraSimbolo(drIItem["NCM"].ToString(), "")).PadRight(8, '0')).Substring(0, 8);
                        }
                        objDet.prod.Cean = (Util.IsNumeric(drIItem["cEAN"].ToString()) ? (Util.ValidacEAN(drIItem["cEAN"].ToString()) ? drIItem["cEAN"].ToString() : "") : "");

                        if (!Util.ValidaCean13(objDet.prod.Cean))
                        {
                            throw new Exception(string.Format("Código de Barras inválido!!{3}{3}Produto: {1}{3}Codigo: {2}{3}Codigo de barras: {0}.{3}Favor acertar o cadastro.{3}",
                                        objDet.prod.Xprod, objDet.prod.Cprod, objDet.prod.Cean, Environment.NewLine));
                        }
                        objDet.prod.Cfop = drIItem["CFOP"].ToString();
                        objDet.prod.Ucom = Util.TiraSimbolo(drIItem["uCom"].ToString(), "");
                        if (Acesso.NM_EMPRESA.Equals("ESTACAHC"))
                        {
                            decimal dqCom = Math.Round(Convert.ToDecimal(drIItem["qCom"].ToString()) * Convert.ToDecimal(drIItem["vl_coef"].ToString()), 4);
                            objDet.prod.Qcom = dqCom;
                        }
                        else if (Acesso.NM_EMPRESA.Equals("MAD_STA_RITA"))
                        {
                            decimal dqCom = Math.Round(Convert.ToDecimal(drIItem["qCom"].ToString()), 4);
                            decimal dComprimento = Math.Round(Convert.ToDecimal(drIItem["vl_comprimento"].ToString()), 4);
                            if (dComprimento == 0)
                            {
                                objDet.prod.Qcom = dqCom;
                            }
                            else
                            {
                                objDet.prod.Qcom = dqCom * dComprimento;
                            }
                        }
                        else
                        {
                            decimal dqCom = Math.Round(Convert.ToDecimal(drIItem["qCom"].ToString()), 4);
                            objDet.prod.Qcom = dqCom;
                        }
                        decimal dvUnCom = Math.Round(Convert.ToDecimal(drIItem["vUnCom"].ToString()), Convert.ToInt32(Acesso.QTDE_CASAS_VL_UNIT));
                        objDet.prod.Vuncom = dvUnCom;
                        decimal dvProd = 0;
                        decimal vl_prodDesc = 0;
                        decimal vl_desconto = 0;
                        if (Acesso.NM_EMPRESA == "ESTACAHC")
                        {
                            dvProd = Math.Round(Convert.ToDecimal(drIItem["vl_totliq"].ToString()), 2);
                        }
                        else
                        {
                            dvProd = Math.Round(Convert.ToDecimal(drIItem["vProd"].ToString()), 2);
                        }
                        if (drIItem["st_desc"].ToString().Equals("U"))
                        {
                            vl_prodDesc = dvProd;
                        }
                        else
                        {
                            if (Acesso.NM_EMPRESA == "LORENZON")
                            {

                                decimal dValorProdSemDesc;

                                if (drIItem["vl_uniprod_sem_desc"].ToString() != "0")
                                {
                                    dValorProdSemDesc = Convert.ToDecimal(drIItem["vl_uniprod_sem_desc"].ToString()) * objDet.prod.Qcom;
                                }
                                else
                                {
                                    dValorProdSemDesc = dvProd;
                                }
                                vl_prodDesc = Math.Round((dValorProdSemDesc) * Convert.ToDecimal(drIItem["VL_COEF"].ToString()), 2);
                            }
                            else
                            {
                                vl_prodDesc = Math.Round(dvProd * Convert.ToDecimal(drIItem["VL_COEF"].ToString()), 2);
                            }
                        }
                        this.pbIndustri = bIndustrializacao(drIItem["cd_operval"].ToString());

                        if (VerificaNotaComSuframa(seqNF)) //NFe_2.0
                        {
                            vl_desconto = Convert.ToDecimal(drIItem["vDescSuframa"].ToString());
                        }
                        else
                        {
                            vl_desconto = dvProd - vl_prodDesc;
                        }

                        if (vl_desconto == 0)
                        {
                            vl_desconto = BuscaDescTotal(seqNF, this.pbIndustri);
                        }
                        if (drIItem["st_hefrete"].ToString() == "S")
                        {
                            dvProd = 0;
                        }
                        objDet.prod.Vprod = dvProd;
                        objDet.prod.Ceantrib = objDet.prod.Cean;
                        objDet.prod.Utrib = Util.TiraSimbolo(drIItem["uTrib"].ToString(), "");
                        objDet.prod.VOutro = Convert.ToDecimal(drIItem["vOutro"].ToString().Replace('.', ',')); // NFe_2.0
                        objDet.prod.IndTot = indTot;
                        if (Acesso.NM_EMPRESA.Equals("ESTACAHC"))
                        {
                            decimal dvqCom = Math.Round(Convert.ToDecimal(drIItem["qCom"].ToString()) * Convert.ToDecimal(drIItem["vl_coef"].ToString()), 4);
                            objDet.prod.Qtrib = dvqCom;
                        }
                        else if (Acesso.NM_EMPRESA.Equals("MAD_STA_RITA"))
                        {
                            objDet.prod.Qtrib = objDet.prod.Qcom;
                        }
                        else
                        {
                            decimal dvqCom = Math.Round(Convert.ToDecimal(drIItem["qCom"].ToString()), 4); // o.s. 24248 - 26/03/2010
                            objDet.prod.Qtrib = dvqCom;
                        }
                        decimal dvUnTrib = Math.Round(Convert.ToDecimal(drIItem["vUnTrib"].ToString()), Convert.ToInt32(Acesso.QTDE_CASAS_VL_UNIT));

                        objDet.prod.Vuntrib = dvUnTrib;
                        if (drIItem["vFrete"].ToString() != "0")
                        {
                            decimal dvFrete = Math.Round(Convert.ToDecimal(drIItem["vFrete"].ToString()), 2); // o.s. 24248 - 26/03/2010
                            objDet.prod.Vfrete = dvFrete;
                        }
                        if (vl_desconto > 0)
                        {
                            objDet.prod.Vdesc = vl_desconto;
                        }

                        if (bEx)
                        {
                            belDI objbelDI = new belDI();
                            objDet.prod.belDI = objbelDI.Carrega(drIItem["nr_lanc"].ToString());
                        }
                        objDet.prod.XPed = drIItem["xPed"].ToString();
                        objDet.prod.NItemPed = drIItem["nItemPed"].ToString();
                        #endregion

                        //Impostos

                        objimp.nitem = objDet.nitem;


                        if (Util.GetListaCFOPcombustivel().Contains(objDet.prod.Cfop))
                        {
                            objDet.prod.belcomb = new belcomb();
                            if (drIItem["CD_ANP"].ToString() != null)
                            {
                                objDet.prod.belcomb.cProdANP = Convert.ToInt32(drIItem["CD_ANP"].ToString());
                            }
                            objDet.prod.belcomb.UFCons = xUFclifor;
                        }

                        #region ICMS
                        belIcms objicms = new belIcms();
                        string sCST = drIItem["CST"].ToString();
                        decimal dvBC = 0;
                        decimal dvBCProp = 0; //25278
                        if (sSimplesNac == "N" || sSimplesNac == "")
                        {
                            dvBC = Math.Round(Convert.ToDecimal(drIItem["vBC"].ToString()), 2);

                            if (drIItem["vBCProp"].ToString() != "0")
                            {
                                dvBCProp = Math.Round(Convert.ToDecimal(drIItem["vBCProp"].ToString().Replace(".", ",")), 2); //25278
                            }
                        }
                        bool bPauta = drIItem["st_pauta"].ToString().Equals("N") ? false : true; //OS_25969
                        decimal dvICMS = (bPauta == false ? (drIItem["vICMS"].ToString() != "" ? Math.Round(Convert.ToDecimal(drIItem["vICMS"].ToString()), 2) : 0) : Math.Round(Convert.ToDecimal(drIItem["vl_icms_Pauta"].ToString()), 2)); //o.s. 24248 - 26/03/2010  - //OS_25969
                        decimal dvBC_pauta = Convert.ToDecimal(drIItem["vBC_Pauta"].ToString()); //OS_25969
                        if (sCST != "")
                        {
                            objicms.sCst = sCST;
                        }

                        if (!Util.VerificaNovaST(sCST))
                        {
                            #region CST_ANTIGAS
                            switch (sCST.Substring(1, 2))
                            {
                                case "00":
                                    {
                                        #region 00
                                        belIcms00 obj00 = new belIcms00();
                                        obj00.Orig = sCST.ToString().Substring(0, 1);
                                        obj00.Cst = sCST.ToString().Substring(1, 2);
                                        obj00.Modbc = "3";
                                        obj00.Vbc = (bPauta ? dvBC_pauta : dvBC);
                                        decimal dpICMS = Math.Round(Convert.ToDecimal(drIItem["pICMS"].ToString()), 2); //o.s. 24248 - 26/03/2010
                                        obj00.Picms = dpICMS;
                                        obj00.Vicms = dvICMS;
                                        objicms.belIcms00 = obj00;
                                        #endregion

                                        break;
                                    }
                                case "10":
                                    {
                                        #region 010
                                        belIcms10 obj10 = new belIcms10();
                                        obj10.Orig = sCST.ToString().Substring(0, 1);
                                        obj10.Cst = sCST.ToString().Substring(1, 2);
                                        obj10.Modbc = "0";
                                        obj10.Vbc = (bPauta ? dvBC_pauta : (dvBCProp == 0 ? (dvICMS == 0 ? 0 : dvBC) : dvBCProp)); // 25278
                                        decimal dpICMS = Math.Round(Convert.ToDecimal(drIItem["pICMS"].ToString()), 2);
                                        obj10.Picms = dpICMS;
                                        //dvICMS = (dvBC * dpICMS) / 100;
                                        obj10.Vicms = dvICMS;
                                        obj10.Modbcst = 4;
                                        decimal dpMVAST = Math.Round(Convert.ToDecimal(drIItem["pMVAST"].ToString()), 2);
                                        obj10.Pmvast = dpMVAST;
                                        decimal dvBCST = Math.Round(Convert.ToDecimal(drIItem["vBCST"].ToString()), 2);
                                        obj10.Vbcst = dvBCST;
                                        decimal dpICMSST = Math.Round(Convert.ToDecimal(drIItem["pICMSST"].ToString()), 2);
                                        obj10.Picmsst = dpICMSST;
                                        decimal dvICMSST = Math.Round(Convert.ToDecimal(drIItem["vICMSST"].ToString()), 2);
                                        obj10.Vicmsst = dvICMSST;
                                        objicms.belIcms10 = obj10;
                                        break;
                                        #endregion
                                    }
                                case "20":
                                    {
                                        #region 020
                                        belIcms20 obj20 = new belIcms20();
                                        obj20.Orig = sCST.ToString().Substring(0, 1);
                                        obj20.Cst = sCST.ToString().Substring(1, 2);
                                        obj20.Modbc = "3";
                                        decimal dpRedBC = Math.Round(Convert.ToDecimal(drIItem["pRedBC"].ToString()), 2); // o.s. 24248 - 26/03/2010
                                        if (dpRedBC == 100)
                                        {
                                            dpRedBC = 0;
                                        }
                                        obj20.Predbc = dpRedBC;
                                        obj20.Vbc = (bPauta ? dvBC_pauta : dvBC);
                                        decimal dpICMS = Math.Round(Convert.ToDecimal(drIItem["pICMS"].ToString()), 2); // o.s. 24248 - 26/03/2010
                                        obj20.Picms = dpICMS;
                                        obj20.Vicms = dvICMS;
                                        objicms.belIcms20 = obj20;
                                        break;
                                        #endregion
                                    }
                                case "30":
                                    {
                                        #region 030
                                        belIcms30 obj30 = new belIcms30();
                                        obj30.Orig = sCST.ToString().Substring(0, 1);
                                        obj30.Cst = sCST.ToString().Substring(1, 2);
                                        obj30.Modbcst = 3;
                                        decimal dpMVAST = Math.Round(Convert.ToDecimal(drIItem["pMVAST"].ToString()), 2); // o.s. 24248 - 26/03/2010
                                        obj30.Pmvast = dpMVAST;
                                        decimal dpRedBCST = Math.Round(Convert.ToDecimal(drIItem["pRedBCST"].ToString()), 2); // o.s. 24248 - 26/03/2010
                                        obj30.Predbcst = dpRedBCST;
                                        decimal dvBCST = Math.Round(Convert.ToDecimal(drIItem["vBCST"].ToString()), 2); // o.s. 24248 - 26/03/2010
                                        obj30.Vbcst = dvBCST;
                                        decimal dpICMSST = Math.Round(Convert.ToDecimal(drIItem["pICMSST"].ToString()), 2); // o.s. 24248 - 26/03/2010
                                        obj30.Picmsst = dpICMSST;
                                        decimal dvICMSST = Math.Round(Convert.ToDecimal(drIItem["vICMSST"].ToString()), 2); // o.s. 24248 - 26/03/2010
                                        obj30.Vicmsst = dvICMSST;
                                        objicms.belIcms30 = obj30;
                                        break;
                                        #endregion
                                    }
                                case "40":
                                    {
                                        #region 040
                                        belIcms40 obj40 = new belIcms40();
                                        obj40.Orig = sCST.ToString().Substring(0, 1);
                                        obj40.Cst = sCST.ToString().Substring(1, 2);
                                        obj40.Vicms = dvICMS; // NFe_2.0
                                        obj40.motDesICMS = (dvICMS > 0 ? (VerificaNotaComSuframa(seqNF) == false ? 9 : 7) : 9); // NFe_2.0
                                        dvBC = (bPauta ? dvBC_pauta : 0);
                                        objicms.belIcms40 = obj40;
                                        break;
                                        #endregion
                                    }
                                case "41":
                                    {
                                        #region 041
                                        belIcms40 obj41 = new belIcms40();
                                        obj41.Orig = sCST.ToString().Substring(0, 1);
                                        obj41.Cst = sCST.ToString().Substring(1, 2);
                                        obj41.Vicms = dvICMS; // NFe_2.0
                                        obj41.motDesICMS = (dvICMS > 0 ? (VerificaNotaComSuframa(seqNF) == false ? 9 : 7) : 9); // NFe_2.0
                                        dvBC = (bPauta ? dvBC_pauta : 0);
                                        objicms.belIcms40 = obj41;
                                        break;
                                        #endregion
                                    }
                                case "50":
                                    {
                                        #region 050
                                        belIcms40 obj50 = new belIcms40();
                                        obj50.Orig = sCST.ToString().Substring(0, 1);
                                        obj50.Cst = sCST.ToString().Substring(1, 2);
                                        obj50.Vicms = dvICMS; // NFe_2.0
                                        obj50.motDesICMS = (dvICMS > 0 ? (VerificaNotaComSuframa(seqNF) == false ? 9 : 7) : 9); // NFe_2.0
                                        dvBC = (bPauta ? dvBC_pauta : 0);
                                        objicms.belIcms40 = obj50;
                                        break;
                                        #endregion
                                    }
                                case "51":
                                    {
                                        #region 051
                                        belIcms51 obj51 = new belIcms51();
                                        obj51.Orig = sCST.ToString().Substring(0, 1);
                                        obj51.Cst = sCST.ToString().Substring(1, 2);
                                        obj51.Modbc = "3";
                                        decimal dpRedBC = Math.Round(Convert.ToDecimal(drIItem["pRedBC"].ToString()), 2); // o.s. 24248 - 26/03/2010
                                        if (dpRedBC == 100)
                                        {
                                            dpRedBC = 0;
                                        }
                                        obj51.Predbc = dpRedBC;
                                        obj51.Vbc = (bPauta ? dvBC_pauta : 0);// Math.Round(Convert.ToDecimal(drIItem["vBC"].ToString()), 2); // DIEGO- OS_24591 - 26/06/2010 INICIO E FIM
                                        decimal dpICMS = Math.Round(Convert.ToDecimal(drIItem["pICMS"].ToString()), 2); // o.s. 24248 - 26/03/2010
                                        obj51.Picms = dpICMS;
                                        obj51.Vicms = dvICMS;
                                        objicms.belIcms51 = obj51;
                                        break;
                                        #endregion
                                    }
                                case "60":
                                    {
                                        #region 060
                                        belIcms60 obj60 = new belIcms60();
                                        obj60.Orig = sCST.ToString().Substring(0, 1);
                                        obj60.Cst = sCST.ToString().Substring(1, 2);
                                        decimal dvBCST = Math.Round(Convert.ToDecimal(drIItem["vBCST"].ToString()), 2); // o.s. 24248 - 26/03/2010
                                        obj60.Vbcstret = dvBCST;
                                        decimal dvICMSST = Math.Round(Convert.ToDecimal(drIItem["vICMSST"].ToString()), 2); // o.s. 24248 - 26/03/2010
                                        obj60.Vicmsstret = dvICMSST;
                                        objicms.belIcms60 = obj60;
                                        break;
                                        #endregion
                                    }

                                case "70":
                                    {
                                        #region 070
                                        belIcms70 obj70 = new belIcms70();
                                        obj70.Orig = sCST.ToString().Substring(0, 1);
                                        obj70.Cst = sCST.ToString().Substring(1, 2);
                                        obj70.Modbc = "3";
                                        decimal dpRedBC = Math.Round(Convert.ToDecimal(drIItem["pRedBC"].ToString()), 2); // o.s. 24248 - 26/03/2010
                                        if (dpRedBC == 100)
                                        {
                                            dpRedBC = 0;
                                        }
                                        obj70.Predbc = dpRedBC;
                                        obj70.Vbc = (bPauta ? dvBC_pauta : (dvBCProp == 0 ? (dvICMS == 0 ? 0 : dvBC) : dvBCProp));
                                        decimal dpICMS = Math.Round(Convert.ToDecimal(drIItem["pICMS"].ToString()), 2); // o.s. 24248 - 26/03/20103
                                        obj70.Picms = dpICMS;
                                        //dvICMS = (dvBC * dpICMS) / 100; //OS_25856

                                        obj70.Vicms = dvICMS;
                                        obj70.Modbcst = 0;
                                        decimal dpMVAST = Math.Round(Convert.ToDecimal(drIItem["pMVAST"].ToString()), 2); // o.s. 24248 - 26/03/2010
                                        obj70.Pmvast = dpMVAST;
                                        decimal dpRedBCST = Math.Round(Convert.ToDecimal(drIItem["pRedBCST"].ToString()), 2); // o.s. 24248 - 26/03/2010
                                        if (dpRedBCST == 100)
                                        {
                                            dpRedBCST = 0;
                                        }
                                        obj70.Predbcst = dpRedBCST;
                                        if (!drIItem["vBCST"].Equals(string.Empty))
                                        {
                                            decimal dvBCST = Math.Round(Convert.ToDecimal(drIItem["vBCST"].ToString()), 2); // o.s. 24248 - 26/03/2010
                                            obj70.Vbcst = dvBCST;
                                        }
                                        if (!drIItem["pICMSST"].Equals(string.Empty))
                                        {
                                            decimal dpICMSST = Math.Round(Convert.ToDecimal(drIItem["pICMSST"].ToString()), 2); // o.s. 24248 - 26/03/2010
                                            obj70.Picmsst = dpICMSST;
                                        }
                                        if (!drIItem["vICMSST"].Equals(string.Empty))
                                        {
                                            decimal dvICMSST = Math.Round(Convert.ToDecimal(drIItem["vICMSST"].ToString()), 2); ;
                                            obj70.Vicmsst = dvICMSST;
                                        }
                                        objicms.belIcms70 = obj70;
                                        break;
                                        #endregion
                                    }

                                case "90":
                                    {
                                        #region 090
                                        belIcms90 obj90 = new belIcms90();
                                        obj90.Orig = sCST.ToString().Substring(0, 1);
                                        obj90.Cst = sCST.ToString().Substring(1, 2);
                                        obj90.Modbc = "3";
                                        dvBC = 0;
                                        obj90.Vbc = (bPauta ? dvBC_pauta : dvBC);
                                        decimal dpRedBC = Math.Round(Convert.ToDecimal(drIItem["pRedBC"].ToString()), 2); //Claudinei - o.s. 24248 - 26/03/2010
                                        dpRedBC = 0;
                                        if (dpRedBC != 0)
                                        {
                                            obj90.Predbc = dpRedBC;
                                        }
                                        decimal dpICMS = Math.Round(Convert.ToDecimal(drIItem["pICMS"].ToString()), 2); //Claudinei - o.s. 24248 - 26/03/2010
                                        dpICMS = 0;
                                        obj90.Picms = dpICMS;

                                        dvICMS = 0;
                                        obj90.Vicms = dvICMS;
                                        obj90.Modbcst = 3;
                                        if (drIItem["pMVAST"].ToString() != "0")
                                        {
                                            decimal dpMVAST = Math.Round(Convert.ToDecimal(drIItem["pMVAST"].ToString()), 2); //Claudinei - o.s. 24248 - 26/03/2010
                                            dpMVAST = 0;
                                            obj90.Pmvast = dpMVAST;
                                        }
                                        decimal dpRedBCST = Math.Round(Convert.ToDecimal(drIItem["pRedBCST"].ToString()), 2); //Claudinei - o.s. 24248 - 26/03/2010
                                        dpRedBCST = 0;
                                        if (dpRedBCST != 0)
                                        {
                                            obj90.Predbcst = dpRedBCST;
                                        }
                                        decimal dvBCST = Math.Round(Convert.ToDecimal(drIItem["vBCST"].ToString()), 2); //Claudinei - o.s. 24248 - 26/03/2010
                                        dvBCST = 0;
                                        obj90.Vbcst = dvICMS;
                                        decimal dpICMSST = Math.Round(Convert.ToDecimal(drIItem["pICMSST"].ToString()), 2); //Claudinei - o.s. 24248 - 26/03/2010
                                        dpICMSST = 0;
                                        obj90.Picmsst = dpICMSST;
                                        decimal dvICMSST = Math.Round(Convert.ToDecimal(drIItem["vICMSST"].ToString()), 2);
                                        dvICMSST = 0;
                                        obj90.Vicmsst = dvICMSST;
                                        objicms.belIcms90 = obj90;
                                        break;
                                        #endregion
                                    }
                            }

                            #endregion
                        }
                        else
                        {
                            string sOrig = drIItem["Orig"].ToString();

                            #region CTS_NOVAS
                            switch ((Util.RetornaSTnovaAserUsada(sCST)))
                            {
                                case "101":
                                    {
                                        #region 101
                                        belICMSSN101 obj101 = new belICMSSN101();
                                        obj101.orig = sOrig;//(objdest.Uf.Equals("EX") ? "1" : "0");
                                        obj101.CSOSN = sCST.ToString();
                                        obj101.pCredSN = Math.Round(Convert.ToDecimal(drIItem["pCredSN"].ToString()), 2);//NFe_2.0
                                        obj101.vCredICMSSN = Math.Round(Convert.ToDecimal(drIItem["vCredICMSSN"].ToString()), 2); //NFe_2.0
                                        objicms.belICMSSN101 = obj101;
                                        #endregion
                                    }
                                    break;

                                case "102":
                                    {
                                        #region 102
                                        belICMSSN102 obj102 = new belICMSSN102();
                                        obj102.orig = sOrig; //(objdest.Uf.Equals("EX") ? "1" : "0");
                                        obj102.CSOSN = sCST.ToString();
                                        objicms.belICMSSN102 = obj102;
                                        #endregion
                                    }
                                    break;
                                case "201":
                                    {
                                        #region 201
                                        belICMSSN201 obj201 = new belICMSSN201();
                                        decimal dpRedBCST = Math.Round(Convert.ToDecimal(drIItem["pRedBCST"].ToString()), 2);
                                        decimal dpICMSST = Math.Round(Convert.ToDecimal(drIItem["pICMSST"].ToString()), 2);
                                        decimal dvICMSST = Math.Round(Convert.ToDecimal(drIItem["vICMSST"].ToString()), 2);

                                        obj201.orig = sOrig;
                                        obj201.CSOSN = sCST.ToString();
                                        obj201.modBCST = 3;
                                        obj201.pMVAST = Math.Round(Convert.ToDecimal(drIItem["pMVAST"].ToString()), 2);
                                        obj201.vBCST = Math.Round(Convert.ToDecimal(drIItem["vBCST"].ToString()), 2);
                                        obj201.pICMSST = dpICMSST;
                                        obj201.vICMSST = dvICMSST;
                                        obj201.pCredSN = Math.Round(Convert.ToDecimal(drIItem["pCredSN"].ToString()), 2);//NFe_2.0
                                        obj201.vCredICMSSN = Math.Round(Convert.ToDecimal(drIItem["vCredICMSSN"].ToString()), 2); //NFe_2.0                                   
                                        if (dpRedBCST != 0)
                                        {
                                            obj201.pRedBCST = dpRedBCST;
                                        }
                                        objicms.belICMSSN201 = obj201;
                                        #endregion
                                    }
                                    break;
                                case "500":
                                    {
                                        #region 500
                                        belICMSSN500 obj500 = new belICMSSN500();
                                        obj500.orig = sOrig;
                                        obj500.CSOSN = sCST.ToString();
                                        decimal dvBCSTRet = Math.Round(Convert.ToDecimal(drIItem["vBCST"].ToString()), 2);
                                        decimal dvICMSSTRet = Math.Round(Convert.ToDecimal(drIItem["vICMSST"].ToString()), 2);
                                        obj500.vBCSTRet = dvBCSTRet;
                                        obj500.vICMSSTRet = dvICMSSTRet;
                                        objicms.belICMSSN500 = obj500;
                                        #endregion
                                    }
                                    break;
                                case "900":
                                    {
                                        #region 900
                                        belICMSSN900 obj900 = new belICMSSN900();
                                        decimal dpRedBCST = Math.Round(Convert.ToDecimal(drIItem["pRedBCST"].ToString()), 2);
                                        decimal dpICMSST = Math.Round(Convert.ToDecimal(drIItem["pICMSST"].ToString()), 2);
                                        decimal dvICMSST = Math.Round(Convert.ToDecimal(drIItem["vICMSST"].ToString()), 2);
                                        decimal dvBCSTRet = Math.Round(Convert.ToDecimal(drIItem["vBCST"].ToString()), 2);
                                        decimal dvICMSSTRet = Math.Round(Convert.ToDecimal(drIItem["vICMSST"].ToString()), 2);

                                        obj900.orig = sOrig;
                                        obj900.CSOSN = sCST.ToString();
                                        obj900.modBC = 3;
                                        obj900.vBC = (bPauta ? dvBC_pauta : dvBC);
                                        decimal dpRedBC = Math.Round(Convert.ToDecimal(drIItem["pRedBC"].ToString()), 2);
                                        if (dpRedBC != 0)
                                        {
                                            obj900.pRedBC = dpRedBC;
                                        }
                                        obj900.vICMS = dvICMS;
                                        obj900.modBCST = 3;
                                        obj900.pMVAST = Math.Round(Convert.ToDecimal(drIItem["pMVAST"].ToString()), 2);
                                        if (dpRedBCST != 0)
                                        {
                                            obj900.pRedBCST = dpRedBCST;
                                        }
                                        decimal dvBCST = Math.Round(Convert.ToDecimal(drIItem["vBCST"].ToString()), 2);
                                        obj900.vBCST = dvBCST;
                                        obj900.pICMSST = dpICMSST;
                                        obj900.vICMSST = dvICMSST;
                                        obj900.vBCSTRet = dvBCSTRet;
                                        obj900.vICMSSTRet = dvICMSSTRet;
                                        obj900.pCredSN = Math.Round(Convert.ToDecimal(drIItem["pCredSN"].ToString()), 2);//NFe_2.0
                                        obj900.vCredICMSSN = Math.Round(Convert.ToDecimal(drIItem["vCredICMSSN"].ToString()), 2); //NFe_2.0                                    

                                        // Alteração feita por motivo de NFe para a Lorenzon

                                        obj900.modBC = null;
                                        obj900.vBC = null;
                                        obj900.pRedBC = null;
                                        obj900.pICMS = null;
                                        obj900.vICMS = null;
                                        obj900.modBCST = null;
                                        obj900.pMVAST = null;
                                        obj900.pRedBCST = null;
                                        obj900.vBCST = null;
                                        obj900.pICMSST = null;
                                        obj900.vICMSST = null;
                                        obj900.vBCSTRet = null;
                                        obj900.vICMSSTRet = null;
                                        obj900.pCredSN = null;//NFe_2.0
                                        obj900.vCredICMSSN = null; //NFe_2.0                                    

                                        objicms.belICMSSN900 = obj900;
                                        #endregion
                                    }
                                    break;
                            }
                            #endregion
                        }

                        if ((dvBC != 0) && (Convert.ToDecimal(drIItem["pICMS"].ToString()) != 0))
                        {
                            objDet.dTotbaseICMS += dvBC;
                            objDet.dTotValorICMS += dvICMS;
                        }
                        objimp.belIcms = objicms;
                        #endregion

                        #region IPI
                        belIpi objipi = new belIpi();
                        if (drIItem["CD_SITTRIBIPI"].ToString() == "")
                            throw new Exception("Situação Tributária do IPI está vazia na NF, O Sistema não pode continuar!");

                        string sTributaIPI = drIItem["cd_sittribipi"].ToString().PadLeft(2, '0');
                        objipi.cst = sTributaIPI;
                        if ((sTributaIPI == "49") || (sTributaIPI == "00") || (sTributaIPI == "50") || (sTributaIPI == "99"))
                        {
                            belIpitrib objipitrib = new belIpitrib();
                            objipi.Cenq = "999";
                            objipitrib.Cst = sTributaIPI;
                            decimal ddvBC = 0;
                            if (drIItem["ST_SUPERSIMPLES"].ToString() == "N")
                            {
                                if (!drIItem["vBC"].Equals(string.Empty))
                                {
                                    if (bEx)
                                    {
                                        ddvBC = Convert.ToDecimal(drIItem["VL_BASEIPI"].ToString());
                                        objipitrib.Vbc = ddvBC;
                                    }
                                    else
                                    {
                                        if (sTributaIPI != "99") //OS_27583 
                                        {
                                            if (Acesso.NM_EMPRESA == "CALDLASER")
                                            {
                                                ddvBC = Convert.ToDecimal(drIItem["VL_BASEIPI"].ToString());
                                            }
                                            else
                                            {
                                                ddvBC = Math.Round(Convert.ToDecimal(drIItem["vBC"].ToString()), 2); //Claudinei - o.s. 24248 - 26/03/2010

                                                if (drIItem["st_frete_entra_ipi_s"].ToString().Equals("S") && drIItem["ST_FRETE_ENTRA_ICMS_S"].ToString().Equals("N")) //OS_26866
                                                {
                                                    ddvBC = ddvBC + objDet.prod.Vfrete;
                                                }
                                                else if (drIItem["st_frete_entra_ipi_s"].ToString().Equals("N") && drIItem["ST_FRETE_ENTRA_ICMS_S"].ToString().Equals("S")) //OS_26866
                                                {
                                                    if (objDet.prod.Vfrete < ddvBC)
                                                    {
                                                        ddvBC = ddvBC - objDet.prod.Vfrete;
                                                    }
                                                }
                                            }
                                        }
                                        objipitrib.Vbc = ddvBC;
                                    }
                                }
                                if (!drIItem["pIPI"].Equals(string.Empty))
                                {
                                    decimal dpIPI = Math.Round(Convert.ToDecimal(drIItem["pIPI"].ToString()), 2); //Claudinei - o.s. 24248 - 26/03/2010
                                    objipitrib.Pipi = dpIPI;
                                }
                                if (!drIItem["vIPI"].Equals(string.Empty))
                                {
                                    decimal dvIPI = Math.Round(Convert.ToDecimal(drIItem["vIPI"].ToString()), 2); //Claudinei - o.s. 24248 - 26/03/2010
                                    objipitrib.Vipi = dvIPI;
                                }

                                if ((Acesso.NM_EMPRESA.Equals("EMBALATEC")) && (drIItem["st_ipi"].ToString().Equals("S")))//OS_25673
                                {
                                    objipitrib.Vbc = objipitrib.Vbc - objipitrib.Vipi;
                                }
                            }
                            objipi.belIpitrib = objipitrib;
                        }
                        else
                        {
                            belIpint objipint = new belIpint();
                            objipi.Cenq = "999";
                            objipint.Cst = sTributaIPI;
                            objipi.belIpint = objipint;
                        }
                        objimp.belIpi = objipi;
                        #endregion

                        #region II
                        //Imposto de importação
                        belIi objii = new belIi();
                        objii.Vbc = (bEx ? Convert.ToDecimal(drIItem["vUnTrib"].ToString()) : 0);
                        objii.Vdespadu = Convert.ToDecimal(drIItem["vl_siscomex"].ToString());
                        objii.Vii = (bEx ? Convert.ToDecimal(drIItem["VL_II"].ToString()) : 0); ;
                        objii.Viof = 0;
                        objimp.belIi = objii;
                        //Fim - II                    
                        #endregion

                        #region PIS

                        if (drIItem["CD_SITTRIBPIS"].ToString() == "")
                        {
                            throw new Exception("Situação Tributária do PIS está vazia e o Sistema não pode continuar.");
                        }
                        string sCst = drIItem["CD_SITTRIBPIS"].ToString().PadLeft(2, '0'); //o.s. 23672 - 10/09/2009
                        belPis objpis = new belPis();
                        objpis.cst = sCst;
                        if ((Convert.ToInt16(sCst) <= 2))
                        {
                            belPisaliq objpisaliq = new belPisaliq();
                            objpisaliq.Cst = sCst;
                            decimal dvlBasepis = Math.Round(Convert.ToDecimal(drIItem["vl_basepis"].ToString()), 2);
                            objpisaliq.Vbc = dvlBasepis; //24872
                            decimal dpPis = Math.Round(Convert.ToDecimal(drIItem["vl_aliqpis_suframa"].ToString()), 2);
                            objpisaliq.Ppis = dpPis;
                            decimal dvPIS = Math.Round(Convert.ToDecimal(drIItem["vl_pis"].ToString()), 2);
                            dTotPis += dvPIS;
                            objpisaliq.Vpis = dvPIS;
                            objpis.belPisaliq = objpisaliq;
                        }
                        else if (Convert.ToInt16(sCst) > 9)
                        {
                            belPisoutr objpisoutr = new belPisoutr();
                            objpisoutr.Cst = sCst;

                            decimal dvlBasepis = Math.Round(Convert.ToDecimal(drIItem["vl_basepis"].ToString()), 2);
                            objpisoutr.Vbc = dvlBasepis; //24872

                            decimal dpPis = Math.Round(Convert.ToDecimal(drIItem["vl_aliqpis_suframa"].ToString()), 2);
                            objpisoutr.Ppis = dpPis;

                            decimal dvPIS = Math.Round(Convert.ToDecimal(drIItem["vl_pis"].ToString()), 2);
                            dTotPis += dvPIS;

                            objpisoutr.Vpis = dvPIS;
                            objpis.belPisoutr = objpisoutr;
                        }
                        else
                        {
                            belPisnt objpisnt = new belPisnt();
                            objpisnt.Cst = sCst;
                            objpis.belPisnt = objpisnt;
                        }
                        objimp.belPis = objpis;
                        #endregion

                        #region Cofins
                        if (drIItem["cd_sittribcof"].ToString() == "")
                        {
                            throw new Exception("Situação Tributária do COFINS está vazia e o Sistema não pode Continuar");
                        }
                        belCofins objcofins = new belCofins();
                        objcofins.cst = drIItem["cd_sittribcof"].ToString();
                        if ((Convert.ToInt16(drIItem["cd_sittribcof"].ToString()) <= 2))
                        {
                            belCofinsaliq objcofinsaliq = new belCofinsaliq();
                            objcofinsaliq.Cst = drIItem["cd_sittribcof"].ToString().PadLeft(2, '0');
                            decimal dvlBaseCofins = Math.Round(Convert.ToDecimal(drIItem["vl_basepis"].ToString()), 2);
                            objcofinsaliq.Vbc = dvlBaseCofins;
                            decimal dpCofins = Math.Round(Convert.ToDecimal(drIItem["vl_aliqcofins_suframa"].ToString()), 2); //o.s. 24248 - 26/03/2010
                            objcofinsaliq.Pcofins = dpCofins;
                            decimal dvCofins = Math.Round(Convert.ToDecimal(drIItem["vl_cofins"].ToString()), 2); //o.s. 24248 - 26/03/2010
                            objcofinsaliq.Vcofins = dvCofins;
                            objcofins.belCofinsaliq = objcofinsaliq;
                        }
                        else if ((drIItem["cd_sittribcof"].ToString()) == "04"
                            || (drIItem["cd_sittribcof"].ToString()) == "06"
                            || (drIItem["cd_sittribcof"].ToString()) == "07"
                            || (drIItem["cd_sittribcof"].ToString()) == "08"
                            || (drIItem["cd_sittribcof"].ToString()) == "09")
                        {
                            belCofinsnt objcofinsnt = new belCofinsnt();
                            objcofinsnt.Cst = drIItem["cd_sittribcof"].ToString().PadLeft(2, '0');
                            objcofins.belCofinsnt = objcofinsnt;
                        }
                        else
                        {
                            belCofinsoutr objcofinsoutr = new belCofinsoutr();
                            objcofinsoutr.Cst = drIItem["cd_sittribcof"].ToString().PadLeft(2, '0');
                            decimal dvlBaseCofins = Math.Round(Convert.ToDecimal(drIItem["vl_basepis"].ToString()), 2);
                            objcofinsoutr.Vbc = dvlBaseCofins;
                            decimal dpCofins = Math.Round(Convert.ToDecimal(drIItem["vl_aliqcofins_suframa"].ToString()), 2); //o.s. 24248 - 26/03/2010
                            objcofinsoutr.Pcofins = dpCofins;
                            decimal dvCofins = Math.Round(Convert.ToDecimal(drIItem["vl_cofins"].ToString()), 2); //o.s. 24248 - 26/03/2010
                            objcofinsoutr.Vcofins = dvCofins;
                            objcofins.belCofinsoutr = objcofinsoutr;
                        } // Diego - OS_24585 - 25/06/2010 - FIM
                        objimp.belCofins = objcofins;
                        //Fim - Cofins                    
                        #endregion

                        #region ISS
                        if ((drIItem["vAliqISS"].ToString() != "") && (drIItem["vAliqISS"].ToString() != "0"))
                        {
                            belIss objiss = new belIss();
                            decimal dvBCISS = Math.Round(Convert.ToDecimal(drIItem["vBCISS"].ToString()), 2); //o.s. 24248 - 26/03/2010
                            objDet.dTotServ += dvBCISS;
                            objDet.dTotBCISS = objDet.dTotServ;
                            objiss.Vbc = dvBCISS;
                            decimal dvAliqISS = Math.Round(Convert.ToDecimal(drIItem["vAliqISS"].ToString()), 2); //o.s. 24248 - 26/03/2010
                            objiss.Valiq = dvAliqISS;
                            decimal dvISSQN = Convert.ToDecimal(drIItem["vIssqn"].ToString());
                            objDet.dTotISS += dvISSQN;
                            objDet.dTotPisISS += Math.Round(Convert.ToDecimal(drIItem["vl_pis"].ToString()), 2); //o.s. 24248 - 26/03/2010
                            objDet.dTotCofinsISS += Math.Round(Convert.ToDecimal(drIItem["vl_cofins"].ToString()), 2);  //o.s. 24248 - 26/03/2010
                            objiss.Vissqn = dvISSQN;
                            objiss.Cmunfg = drIItem["cMunFG"].ToString();
                            if (drIItem["cListserv"].ToString() != "")
                            {
                                Int64 icListServ = Convert.ToInt64(drIItem["cListserv"].ToString());
                                objiss.Clistserv = icListServ;
                            }
                            objimp.belIss = objiss;
                        }
                        #endregion

                        #region Obs
                        belInfadprod objinf = new belInfadprod();
                        objinf.nitem = objDet.nitem;
                        string sObsItem = "";
                        if (Acesso.NM_EMPRESA == "HELENGE")
                        {
                            sObsItem += (daoEspecifico.BuscaContratoOBS(drIItem["nr_lanc"].ToString())).Replace(Environment.NewLine, "-");
                        }
                        if (Acesso.NM_EMPRESA == "FORMINGP")
                        {
                            sObsItem += daoEspecifico.BuscaSerieProd(drIItem["nr_lanc"].ToString());
                        }
                        if (Acesso.NM_EMPRESA == "JAMAICA")
                        {
                            sObsItem += daoEspecifico.BuscaInformacoesLote(drIItem["nr_lanc"].ToString());
                        }
                        sObsItem = BuscaObsItemSimples(drIItem["nr_lanc"].ToString()) + sObsItem;

                        if (drIItem["st_imp_cdpedcli"].ToString() != "N")
                        {
                            if (drIItem["xPed"].ToString() != "")
                            {
                                sObsItem += string.Format("SEU PEDIDO.: {0}",
                                                              drIItem["xPed"].ToString().Trim());
                            }
                            if (drIItem["nItemPed"].ToString() != "")
                            {
                                sObsItem += string.Format("ITEM NUMERO.: {0}",
                                                              drIItem["nItemPed"].ToString().Trim());
                            }
                            if (Acesso.NM_RAMO == Acesso.BancoDados.INDUSTRIA)
                            {
                                if (drIItem["nr_lote"].ToString() != "")
                                {
                                    sObsItem += " " + string.Format("Lote: {0}", drIItem["nr_lote"].ToString());
                                }

                                if (drIItem["cd_prodcli"].ToString() != "")
                                {
                                    if (sObsItem == "")
                                    {
                                        sObsItem += string.Format("PRD_CLI.: {0}",
                                                                  drIItem["cd_prodcli"].ToString().Trim());

                                    }
                                    else
                                    {
                                        sObsItem += string.Format(" PRD_CLI.: {0}",
                                                                  drIItem["cd_prodcli"].ToString().Trim());
                                    }
                                }
                            }
                        }

                        if (Acesso.NM_EMPRESA == "MARPA")
                        {
                            sObsItem = daoEspecifico.MontaObsItemMarpa(drIItem["nr_lanc"].ToString());
                            if (sObsItem != "")
                            {
                                if (drIItem["nr_lanc"].ToString() == sNr_Lanc)
                                {
                                    if (drIItem["xLgr"].ToString().Trim() != "")
                                    {
                                        sObsItem += string.Format(" - Endereco de Entrega.: {0} {1} - Bairro.: {2} - Cidade.: {3} - UF.: {4} ",
                                                                  Util.TiraSimbolo(drIItem["xLgr"].ToString().Trim(), ""),
                                                                  Util.TiraSimbolo(drIItem["nro"].ToString().Trim(), ""),
                                                                  Util.TiraSimbolo(drIItem["xBairro"].ToString().Trim(), ""),
                                                                  RetiraCaracterEsquerda(Util.TiraSimbolo(drIItem["cMun"].ToString().Trim(), ""), '0'),
                                                                  Util.TiraSimbolo(drIItem["UF"].ToString().Trim(), ""));
                                    }
                                    if (drIItem["Desconto_Valor"].ToString() != "0")
                                    {
                                        decimal dDesconto_Valor = Convert.ToDecimal(drIItem["Desconto_Valor"].ToString());
                                        decimal dDesconto_Percentual = (Convert.ToDecimal(drIItem["Desconto_Percentual"].ToString()) / 100);

                                        sObsItem += string.Format(" - Desconto.: ({0:p2}) {1:f2}",
                                                                  dDesconto_Percentual,
                                                                  dDesconto_Valor);


                                    }
                                }
                                objinf.Infadprid = Util.TiraSimbolo(sObsItem.Trim(), "");
                            }
                            else
                            {
                                if (drIItem["nr_lanc"].ToString() == sNr_Lanc)
                                {
                                    if (drIItem["Desconto_Valor"].ToString() != "0")
                                    {
                                        decimal dDesconto_Valor = Convert.ToDecimal(drIItem["Desconto_Valor"].ToString());
                                        decimal dDesconto_Percentual = (Convert.ToDecimal(drIItem["Desconto_Percentual"].ToString()) / 100);

                                        sObsItem = string.Format("Desconto.: ({0:p2}) {1:f2}",
                                                                  dDesconto_Percentual,
                                                                  dDesconto_Valor);

                                        objinf.Infadprid = Util.TiraSimbolo(sObsItem.Trim(), "");
                                    }
                                }
                            }
                        }
                        else
                        {

                            if (drIItem["nr_lanc"].ToString() == sNr_Lanc)
                            {
                                if (drIItem["xLgr"].ToString().Trim() != "")
                                {
                                    sObsItem += string.Format("Endereco de Entrega.: {0}, {1} - Bairro.: {2} - Cidade.: {3} - UF.: {4} ",
                                                                 drIItem["xLgr"].ToString().Trim(),
                                                                 drIItem["nro"].ToString().Trim(),
                                                                 drIItem["xBairro"].ToString().Trim(),
                                                                 RetiraCaracterEsquerda(drIItem["cMun"].ToString().Trim(), '0'),
                                                                 drIItem["UF"].ToString().Trim());

                                    if (sObsItem != "")
                                    {
                                        objinf.Infadprid = Util.TiraSimbolo(sObsItem.Trim(), "");
                                    }
                                }
                                else
                                {
                                    if (sObsItem != "")
                                    {
                                        objinf.Infadprid = Util.TiraSimbolo(sObsItem.Trim(), "").Replace(Environment.NewLine, "-");
                                    }
                                }
                            }
                            else
                            {
                                if (sObsItem != "")
                                {
                                    objinf.Infadprid = Util.TiraSimbolo(sObsItem.Trim(), "");
                                }

                            }

                        }

                        if (drIItem["nr_lanc"].ToString() == sNr_Lanc)
                        {
                            if (drIItem["xLgrRedes"].ToString().Trim() != "")
                            {
                                string sTransportadora = "";

                                sTransportadora = string.Format((Acesso.NM_EMPRESA == "TORCETEX" ? "FRETE A PAGAR DESTINO - TRANSP . DE REDESPACHO.: " : "Redespacho.:")
                                                          + "{5} - {0} {1} - Bairro.: {2} - Cidade.: {3} - UF.: {4} ",
                                                          Util.TiraSimbolo(drIItem["xLgrRedes"].ToString().Trim(), ""),
                                                          Util.TiraSimbolo(drIItem["nroRedes"].ToString().Trim(), ""),
                                                          Util.TiraSimbolo(drIItem["xBairroRedes"].ToString().Trim(), ""),
                                                          RetiraCaracterEsquerda(Util.TiraSimbolo(drIItem["cmunRedes"].ToString().Trim(), ""), '0'),
                                                          Util.TiraSimbolo(drIItem["UFRedes"].ToString().Trim(), ""),
                                                          Util.TiraSimbolo(drIItem["redespacho"].ToString().Trim(), ""));
                                sTransportadora += ";";
                                sObsItem = sTransportadora + sObsItem;
                                objinf.Infadprid = Util.TiraSimbolo(sObsItem.Trim(), "-");
                            }
                        }
                        if (Acesso.IMPRIMI_NUM_NOTA_ENTRADA)
                        {
                            if (drIItem["ST_ESTTERC"].ToString().Equals("S"))
                            {
                                if (!drIItem["CD_DOC"].ToString().Trim().Equals(""))
                                {
                                    objinf.Infadprid += "NF-" + drIItem["CD_DOC"].ToString().Trim();
                                }
                            }
                        }
                        if (Acesso.IMPRIMI_NUM_PEDIDO_VENDA)
                        {
                            if (!drIItem["CD_PEDIDO"].ToString().Trim().Equals(""))
                            {
                                objinf.Infadprid += "PEDIDO-" + drIItem["CD_PEDIDO"].ToString().Trim();
                            }
                        }
                        if (Acesso.IMPRIMI_NUM_REVISAO)
                        {
                            if (!drIItem["CD_REVISAO"].ToString().Trim().Equals(""))
                            {
                                objinf.Infadprid += (objinf.Infadprid != "" ? " " : "") + "REV.:" + drIItem["CD_REVISAO"].ToString().Trim();
                            }
                        }

                        if ((Acesso.NM_EMPRESA.Equals("TORCETEX")))
                        {
                            if (objinf.Infadprid != null)
                            {
                                if ((objinf.Infadprid.Contains("FRETE A PAGAR DESTINO") == false))
                                {
                                    objinf.Infadprid = objinf.Infadprid.Replace("REDESPACHO ", "");
                                }
                            }
                        }
                        if (objinf.Infadprid != null)
                        {
                            if (objinf.Infadprid.Length > 500)
                            {
                                objinf.Infadprid = objinf.Infadprid.Substring(0, 500);
                            }
                        }
                        //Fim - Obs                    
                        #endregion

                        objDet.imposto = objimp;
                        objDet.infAdProd = objinf;
                        objListaRet.Add(objDet);

                    }
                    catch (Exception ex)
                    {
                        throw new Exception(string.Format("Erro no produto Item: {0}, Nome:{1}",
                                objDet.prod.Cprod, objDet.prod.Xprod) + " - " + ex.Message);
                    }
                }
                return objListaRet;

            }
            catch (Exception Ex)
            {
                throw Ex;
            }


        }
    }
}
