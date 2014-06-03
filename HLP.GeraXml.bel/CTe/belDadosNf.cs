using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HLP.GeraXml.dao.CTe;
using System.Data;
using HLP.GeraXml.bel.CTe.infCte.rem;
using HLP.GeraXml.bel.CTe.infCte.infCTeNorm;

namespace HLP.GeraXml.bel.CTe
{
    public class belDadosNf : daoDadosNf
    {
        public void PopulaNf(belinfCte objbelinfCte, string sCte)
        {
            try
            {
                DataTable dt = BuscaDadosNf(sCte);
                //objbelinfCte.infCTeNorm = new belinfCTeNorm();
                foreach (DataRow dr in dt.Rows)
                {
                    switch (dr["Tipo"].ToString())
                    {
                        case "N":
                            belinfNF infNf = new belinfNF();
                            infNf.mod = dr["mod"].ToString();
                            infNf.serie = dr["serie"].ToString();
                            infNf.nDoc = dr["nDoc"].ToString();
                            infNf.dEmi = dr["dEmi"].ToString() != "" ? (Convert.ToDateTime(dr["dEmi"].ToString())).ToString("dd/MM/yyyy") : "";
                            infNf.vBC = dr["vBC"].ToString() != "" ? dr["vBC"].ToString().Replace(",", ".") : "0.00";
                            infNf.vICMS = dr["vICMS"].ToString() != "" ? dr["vICMS"].ToString().Replace(",", ".") : "0.00";
                            infNf.vBCST = dr["vBCST"].ToString() != "" ? dr["vBCST"].ToString().Replace(",", ".") : "0.00";
                            infNf.vST = dr["vST"].ToString() != "" ? dr["vST"].ToString().Replace(",", ".") : "0.00";
                            infNf.vProd = dr["vProd"].ToString() != "" ? dr["vProd"].ToString().Replace(",", ".") : "0.00";
                            infNf.vNF = dr["vProd"].ToString() != "" ? dr["vProd"].ToString().Replace(",", ".") : "0.00";
                            infNf.nCFOP = dr["nCFOP"].ToString() != "" ? Convert.ToInt32(dr["nCFOP"]).ToString() : "0";

                            objbelinfCte.infCTeNorm.infDoc.infNF.Add(infNf);
                            break;

                        case "E":
                            belinfNFe infNfe = new belinfNFe();
                            infNfe.chave = dr["chave"].ToString();
                            infNfe.nDoc = dr["nDoc"].ToString();
                            objbelinfCte.infCTeNorm.infDoc.infNFe.Add(infNfe);
                            break;

                        case "00":
                            belinfOutros infDeclaracao = new belinfOutros();
                            infDeclaracao.tpDoc = "00";
                            infDeclaracao.nDoc = dr["nDoc"].ToString();
                            infDeclaracao.dEmi = dr["dEmi"].ToString() != "" ? (Convert.ToDateTime(dr["dEmi"].ToString())).ToString("dd/MM/yyyy") : "";
                            infDeclaracao.vDocFisc = dr["vProd"].ToString() != "" ? dr["vProd"].ToString().Replace(",", ".") : "0.00";

                            objbelinfCte.infCTeNorm.infDoc.infOutros.Add(infDeclaracao);
                            break;

                        case "10":
                            belinfOutros infDutoviario = new belinfOutros();
                            infDutoviario.tpDoc = "00";
                            infDutoviario.nDoc = dr["nDoc"].ToString();
                            infDutoviario.dEmi = dr["dEmi"].ToString() != "" ? (Convert.ToDateTime(dr["dEmi"].ToString())).ToString("dd/MM/yyyy") : "";
                            infDutoviario.vDocFisc = dr["vProd"].ToString() != "" ? dr["vProd"].ToString().Replace(",", ".") : "0.00";

                            objbelinfCte.infCTeNorm.infDoc.infOutros.Add(infDutoviario);
                            break;

                        case "99":
                            belinfOutros infOutros = new belinfOutros();
                            infOutros.tpDoc = "99";
                            infOutros.descOutros = dr["descOutros"].ToString();
                            infOutros.nDoc = dr["nDoc"].ToString();
                            infOutros.dEmi = dr["dEmi"].ToString() != "" ? (Convert.ToDateTime(dr["dEmi"].ToString())).ToString("dd/MM/yyyy") : "";
                            infOutros.vDocFisc = dr["vProd"].ToString() != "" ? dr["vProd"].ToString().Replace(",", ".") : "0.00";

                            objbelinfCte.infCTeNorm.infDoc.infOutros.Add(infOutros);
                            break;

                        default:
                            throw new Exception("A nota " + dr["nDoc"].ToString() + " do Conhecimento " + objbelinfCte.ide.nCT + " não tem Tipo selecionado(NF, NF-e, Declaração, Dutoviário, Outros)");
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
