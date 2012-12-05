using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HLP.GeraXml.dao.CTe;
using System.Data;
using HLP.GeraXml.bel.CTe.infCte.vPrest;

namespace HLP.GeraXml.bel.CTe
{
    public class belDadosVPrest : daoDadosVPrest
    {
        public void PopulaVPrest(belinfCte objbelinfCte, string sCte)
        {
            try
            {
                DataTable dt = BuscaDadosVPrest(sCte);

                objbelinfCte.vPrest = new belvPrest();
                objbelinfCte.vPrest.Comp = new List<belComp>();

                foreach (DataRow dr in dt.Rows)
                {

                    objbelinfCte.vPrest.vTPrest = dr["vTPrest"].ToString();
                    objbelinfCte.vPrest.vRec = dr["vTPrest"].ToString();

                    belComp Comp = new belComp();
                    if (dr["FRETEVALOR"].ToString() != "0.00")
                    {
                        Comp = new belComp();
                        Comp.xNome = "FRETE VALOR";
                        Comp.vComp = dr["FRETEVALOR"].ToString();
                        objbelinfCte.vPrest.Comp.Add(Comp);
                    }
                    if (dr["FRETECUBAGEM"].ToString() != "0.00")
                    {
                        Comp = new belComp();
                        Comp.xNome = "FRETE CUBAGEM";
                        Comp.vComp = dr["FRETECUBAGEM"].ToString();
                        objbelinfCte.vPrest.Comp.Add(Comp);
                    }
                    if (dr["FRETEPESO"].ToString() != "0.00")
                    {
                        Comp = new belComp();
                        Comp.xNome = "FRETE PESO";
                        Comp.vComp = dr["FRETEPESO"].ToString();
                        objbelinfCte.vPrest.Comp.Add(Comp);
                    }
                    if (dr["CAT"].ToString() != "0.00")
                    {
                        Comp = new belComp();
                        Comp.xNome = "CAT";
                        Comp.vComp = dr["CAT"].ToString();
                        objbelinfCte.vPrest.Comp.Add(Comp);
                    }
                    if (dr["DESPACHO"].ToString() != "0.00")
                    {
                        Comp = new belComp();
                        Comp.xNome = "DESPACHO";
                        Comp.vComp = dr["DESPACHO"].ToString();
                        objbelinfCte.vPrest.Comp.Add(Comp);
                    }
                    if (dr["PEDAGIO"].ToString() != "0.00")
                    {
                        Comp = new belComp();
                        Comp.xNome = "PEDAGIO";
                        Comp.vComp = dr["PEDAGIO"].ToString();
                        objbelinfCte.vPrest.Comp.Add(Comp);
                    }
                    if (dr["OUTROS"].ToString() != "0.00")
                    {
                        Comp = new belComp();
                        Comp.xNome = "OUTROS";
                        Comp.vComp = dr["OUTROS"].ToString();
                        objbelinfCte.vPrest.Comp.Add(Comp);
                    }
                    if (dr["ADME"].ToString() != "0.00")
                    {
                        Comp = new belComp();
                        Comp.xNome = "ADME";
                        Comp.vComp = dr["ADME"].ToString();
                        objbelinfCte.vPrest.Comp.Add(Comp);
                    }
                    if (dr["ENTREGA"].ToString() != "0.00")
                    {
                        Comp = new belComp();
                        Comp.xNome = "ENTREGA";
                        Comp.vComp = dr["ENTREGA"].ToString();
                        objbelinfCte.vPrest.Comp.Add(Comp);
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
