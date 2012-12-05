
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HLP.GeraXml.dao.NFe.Estrutura;
using System.Data;
using HLP.GeraXml.Comum.Static;

namespace HLP.GeraXml.bel.NFe.Estrutura
{
    public class belCobr : daoCobr
    {
        public belFat Fat = new belFat();


        public void Carrega(string seqNF)
        {
            try
            {
                foreach (DataRow drCob in BuscaCobr(seqNF).Rows)
                {
                    decimal dvDup = Math.Round(Convert.ToDecimal(drCob["vOrig"].ToString()), 2);
                    decimal dDesc = Math.Round(Convert.ToDecimal(drCob["vDesc"].ToString()), 2);
                    if (drCob["nFat"].ToString().Trim() != "")
                    {
                        this.Fat.Nfat = Util.TiraSimbolo(drCob["nFat"].ToString(), "");
                    }
                    this.Fat.Vorig = dvDup;
                    if (drCob["vDesc"].ToString() != "0")
                    {
                        this.Fat.Vdesc = Math.Round(Convert.ToDecimal(dDesc.ToString()), 2);
                    }
                    if (drCob["vLiq"].ToString() != "0")
                    {
                        decimal dLiq = Math.Round(Convert.ToDecimal(drCob["vLiq"].ToString()), 2);
                        this.Fat.Vliq = dLiq;
                    }
                }
                List<belDup> objdups = new List<belDup>();

                foreach (DataRow drFat in BuscaFat(seqNF).Rows)
                {
                    belDup objdup = new belDup();
                    if (drFat["cd_dupli"].ToString() != "")
                    {
                        objdup.Ndup = Util.TiraSimbolo(drFat["cd_dupli"].ToString(), "");
                    }
                    if (!drFat["dt_venci"].Equals(string.Empty))
                    {
                        objdup.Dvenc = System.DateTime.Parse(drFat["dt_venci"].ToString());
                    }
                    decimal dvDup = Math.Round(Convert.ToDecimal(drFat["vl_doc"].ToString()), 2);
                    if (dvDup != 0)
                    {
                        objdup.Vdup = dvDup;
                    }
                    objdups.Add(objdup);
                }
                this.Fat.belDup = objdups.OrderBy(C => C.Dvenc).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
