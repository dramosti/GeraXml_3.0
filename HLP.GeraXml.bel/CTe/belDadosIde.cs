using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HLP.GeraXml.dao.CTe;
using HLP.GeraXml.bel.CTe.infCte.ide;
using HLP.GeraXml.Comum.Static;

namespace HLP.GeraXml.bel.CTe
{
    public class belDadosIde : daoDadosIde
    {
        public void PopulaIde(string sCte, string sDigVerif, belinfCte objbelinfCte, string sId)
        {
            try
            {
                DataTable dt = BuscaDadosPopulaIde(sCte);

                foreach (DataRow dr in dt.Rows)
                {


                    objbelinfCte.ide = new belide();
                    bel.belUF objbelUF = new bel.belUF();

                    objbelinfCte.id = sId;
                    objbelinfCte.ide.cUF = objbelUF.RetornaCUF(dr["cUF"].ToString());
                    objbelinfCte.ide.cCT = dr["cCT"].ToString();
                    objbelinfCte.ide.CFOP = dr["CFOP"].ToString();
                    objbelinfCte.ide.natOp = dr["natOp"].ToString().Length > 60 ? dr["natOp"].ToString().Substring(0, 60) : dr["natOp"].ToString();
                    objbelinfCte.ide.forPag = Convert.ToInt32(dr["forPag"]);
                    objbelinfCte.ide.mod = "57";
                    objbelinfCte.ide.serie = Acesso.TP_EMIS == 3 ? "900" : "1";
                    objbelinfCte.ide.nCT = dr["nCT"].ToString();
                    objbelinfCte.ide.tpImp = "1";
                    objbelinfCte.ide.tpEmis = Acesso.TP_EMIS != 1 ? "5" : "1";
                    objbelinfCte.ide.cDV = sDigVerif;
                    objbelinfCte.ide.tpAmb = Convert.ToString(Acesso.TP_AMB);
                    objbelinfCte.ide.tpCTe = 0;
                    objbelinfCte.ide.procEmi = 0;
                    objbelinfCte.ide.verProc = Acesso.versaoCTe;
                    objbelinfCte.ide.xMunEnv = dr["xMunEmi"].ToString();
                    objbelinfCte.ide.UFEnv = dr["UFEmi"].ToString();
                    objbelinfCte.ide.cMunEnv = RetornaCodigoCidade(objbelinfCte.ide.xMunEnv, objbelinfCte.ide.UFEnv);
                    objbelinfCte.ide.modal = "01";
                    objbelinfCte.ide.tpServ = 0;
                    objbelinfCte.ide.xMunIni = dr["xMunIni"].ToString();
                    objbelinfCte.ide.UFIni = dr["UFIni"].ToString();
                    objbelinfCte.ide.cMunIni = dr["cMunIni"].ToString();
                    objbelinfCte.ide.xMunFim = dr["xMunFim"].ToString();
                    objbelinfCte.ide.UFFim = dr["UFFim"].ToString();
                    objbelinfCte.ide.cMunFim = dr["cMunFim"].ToString();
                    objbelinfCte.ide.retira = 0;
                    objbelinfCte.ide.xDetRetira = null;
                    if (dr["Veiculo"].ToString() != "") { objbelinfCte.ide.Veiculo.Add(dr["Veiculo"].ToString()); }
                    if (dr["Veiculo2"].ToString() != "") { objbelinfCte.ide.Veiculo.Add(dr["Veiculo2"].ToString()); }
                    if (dr["Veiculo3"].ToString() != "") { objbelinfCte.ide.Veiculo.Add(dr["Veiculo3"].ToString()); }
                    if (dr["Veiculo4"].ToString() != "") { objbelinfCte.ide.Veiculo.Add(dr["Veiculo4"].ToString()); }

                    objbelinfCte.ide.Motorista = dr["Motorista"].ToString();

                    string sTipoTomador = dr["Tomador"].ToString();
                    switch (sTipoTomador)
                    {
                        case "R": objbelinfCte.ide.toma03 = new beltoma03();
                            objbelinfCte.ide.toma03.toma = "0";
                            break;

                        case "D": objbelinfCte.ide.toma03 = new beltoma03();
                            objbelinfCte.ide.toma03.toma = "3";
                            break;

                        default: objbelinfCte.ide.toma04 = new beltoma04();
                            objbelinfCte.ide.toma04.toma = "4";
                            break;
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
