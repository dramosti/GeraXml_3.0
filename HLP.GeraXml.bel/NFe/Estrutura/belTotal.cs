using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HLP.GeraXml.dao.NFe.Estrutura;
using System.Data;
using HLP.GeraXml.Comum.Static;
namespace HLP.GeraXml.bel.NFe.Estrutura
{
    public class belTotal : daoTotal
    {
        public belIcmstot   belIcmstot = new belIcmstot();
        public belIssqntot belIssqntot = new belIssqntot();
        public belRetTrib belRetTrib = new belRetTrib();

        public void Carrega(string seqNF, bool pbIndustri, bool bEX)
        {
            try
            {
                decimal dTotbaseICMS = 0;
                decimal dTotValorICMS = 0;
                decimal dTotPis = 0;
                decimal dTotCofins = 0;
                decimal dTotServ = 0;
                decimal dTotBCISS = 0;
                decimal dTotISS = 0;
                decimal dTotPisISS = 0;
                decimal dTotCofinsISS = 0;

                DataRow drTotais = BuscaTotais(seqNF, pbIndustri, bEX);

                if ((pbIndustri) && (Acesso.NM_EMPRESA != "TECNOZ"))
                {
                    dTotbaseICMS = Math.Round(Convert.ToDecimal(drTotais["vBCST"].ToString()), 2);
                }
                if ((pbIndustri) && (Acesso.NM_EMPRESA == "MOGPLAST"))
                {
                    dTotbaseICMS = Math.Round(Convert.ToDecimal(drTotais["vBC"].ToString()), 2);
                }
                dTotbaseICMS = Math.Round(Convert.ToDecimal(drTotais["vBC"].ToString()), 2);
                this.belIcmstot.Vbc = Math.Round(Convert.ToDecimal(dTotbaseICMS.ToString()), 2);
                dTotValorICMS = Math.Round(Convert.ToDecimal(drTotais["vICMS"].ToString()), 2);
                this.belIcmstot.Vicms = Math.Round(Convert.ToDecimal(dTotValorICMS.ToString()), 2);
                if (!drTotais["vBCST"].Equals(string.Empty))
                {
                    decimal dvBCST = Math.Round(Convert.ToDecimal(drTotais["vBCST"].ToString()), 2);
                    this.belIcmstot.Vbcst = dvBCST;
                }
                if (!drTotais["vST"].Equals(string.Empty))
                {
                    decimal dvST = Math.Round(Convert.ToDecimal(drTotais["vST"].ToString()), 2);
                    this.belIcmstot.Vst = (Acesso.CD_EMPRESA != "LORENZON" ? dvST : 0);
                }
                if (drTotais["vProd"].ToString() != "")
                {
                    decimal dvProd = Math.Round(Convert.ToDecimal(drTotais["vProd"].ToString()), 2);
                    this.belIcmstot.Vprod = dvProd;
                }
                else
                {
                    this.belIcmstot.Vprod = 0;
                }
                if (!drTotais["vFrete"].Equals(string.Empty))
                {
                    decimal dvFrete = Math.Round(Convert.ToDecimal(drTotais["vFrete"].ToString()), 2);
                    this.belIcmstot.Vfrete = dvFrete;
                }
                if (!drTotais["vSeg"].Equals(string.Empty))
                {
                    decimal dvSeg = Math.Round(Convert.ToDecimal(drTotais["vSeg"].ToString()), 2);
                    this.belIcmstot.Vseg = dvSeg;
                }
                decimal dvDesc = Math.Round(Convert.ToDecimal(drTotais["vDesc"].ToString()), 2);
                this.belIcmstot.Vdesc = dvDesc;
                if (!drTotais["vII"].Equals(string.Empty))
                {
                    decimal dvII = Math.Round(Convert.ToDecimal(drTotais["vII"].ToString()), 2);
                    this.belIcmstot.Vii = dvII;
                }
                if (!drTotais["vIPI"].Equals(string.Empty))
                {
                    decimal dvIPI = Math.Round(Convert.ToDecimal(drTotais["vIPI"].ToString()), 2);
                    this.belIcmstot.Vipi = (Acesso.NM_EMPRESA != "LORENZON" ? dvIPI : 0);
                }
                if (Acesso.TP_INDUSTRIALIZACAO == 2)
                {
                    dTotPis = Math.Round(Convert.ToDecimal(drTotais["vPIS"].ToString()), 2);
                }
                this.belIcmstot.Vpis = Math.Round(Convert.ToDecimal(drTotais["vPIS"].ToString()), 2);
                if (Acesso.TP_INDUSTRIALIZACAO == 2)
                {
                    dTotCofins = Math.Round(Convert.ToDecimal(drTotais["vCOFINS"].ToString()), 2);
                }
                this.belIcmstot.Vcofins = Math.Round(Convert.ToDecimal(dTotCofins.ToString()), 2);
                if (!drTotais["vOutro"].Equals(string.Empty))
                {
                    decimal dvOutro = Math.Round(Convert.ToDecimal(drTotais["vOutro"].ToString()), 2);
                    this.belIcmstot.Voutro = dvOutro;
                }
                if (!drTotais["vNF"].Equals(string.Empty))
                {
                    decimal dvNF = Math.Round(Convert.ToDecimal(drTotais["vNF"].ToString()), 2);
                    this.belIcmstot.Vnf = dvNF;
                }
                if (Acesso.TP_INDUSTRIALIZACAO == 2)
                {
                    dTotServ = Math.Round(Convert.ToDecimal(drTotais["vServ"].ToString()), 2);
                }
                if (dTotServ != 0)
                {
                    belIssqntot objisstot = new belIssqntot();
                    if (dTotServ != 0)
                    {
                        objisstot.Vserv = Math.Round(Convert.ToDecimal(dTotServ.ToString()), 2);
                    }
                    if (Acesso.TP_INDUSTRIALIZACAO == 2)
                    {
                        dTotBCISS = Math.Round(Convert.ToDecimal(drTotais["vServ"].ToString()), 2);
                    }
                    if (dTotBCISS != 0)
                    {
                        objisstot.Vbc = Math.Round(Convert.ToDecimal(dTotBCISS.ToString()), 2);
                    }
                    if (Acesso.TP_INDUSTRIALIZACAO == 2)
                    {
                        dTotISS = Math.Round(Convert.ToDecimal(drTotais["Viss"].ToString()), 2);
                    }
                    if (dTotISS != 0)
                    {
                        objisstot.Viss = Math.Round(Convert.ToDecimal(dTotISS.ToString()), 2);
                    }
                    if (Acesso.TP_INDUSTRIALIZACAO == 2)
                    {
                        dTotPisISS = Math.Round(Convert.ToDecimal(drTotais["PisIss"].ToString()), 2);
                    }
                    if (dTotPisISS != 0)
                    {
                        objisstot.Vpis = Math.Round(Convert.ToDecimal(dTotPisISS.ToString()), 2);
                    }
                    if (Acesso.TP_INDUSTRIALIZACAO == 2)
                    {
                        dTotCofinsISS = Math.Round(Convert.ToDecimal(drTotais["cofinsIss"].ToString()), 2);
                    }
                    if (dTotCofinsISS != 0)
                    {
                        objisstot.Vcofins = Math.Round(Convert.ToDecimal(dTotCofinsISS.ToString()), 2);
                    }
                    this.belIssqntot = objisstot;
                }                
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
