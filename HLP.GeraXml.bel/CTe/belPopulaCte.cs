using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HLP.GeraXml.dao.CTe;
using System.IO;
using System.Data;
using HLP.GeraXml.dao.ADO;
using HLP.GeraXml.Comum.Static;
using HLP.GeraXml.dao;

namespace HLP.GeraXml.bel.CTe
{
    public class belPopulaCte : daoPopulaCte
    {
        belPopulaObjetos objbelObjetos = null;

        public void PopulaConhecimentos(belPopulaObjetos objbelObjetos)
        {
            this.objbelObjetos = objbelObjetos;
            try
            {

                if (File.Exists(objbelObjetos.sPath))
                {
                    File.Delete(objbelObjetos.sPath);
                }

                foreach (string sCte in objbelObjetos.objListaNumeroConhecimentos)
                {

                    string sCTe = "CTe" + GeraChave(sCte);
                    belinfCte objbelinfCte = new belinfCte();
                    belDadosIde objIde = new belDadosIde();
                    belDadosEmit objEmit = new belDadosEmit();
                    belDadosRem objRem = new belDadosRem();
                    belDadosDest objDest = new belDadosDest();
                    belDadosNf objNf = new belDadosNf();
                    belDadosExped objExped = new belDadosExped();
                    belDadosReceb objReceb = new belDadosReceb();
                    belDadosVPrest objVPrest = new belDadosVPrest();
                    belDadosImp objImp = new belDadosImp();
                    belDadosinfCarga objInfCarga = new belDadosinfCarga();
                    belDadosinfQ objInfQ = new belDadosinfQ();
                    belDadosrodo objRodo = new belDadosrodo();

                    objbelinfCte.compl = new belcompl(sCte);

                    objIde.PopulaIde(sCte, sCTe[sCTe.Length - 1].ToString(), objbelinfCte, sCTe);
                    objEmit.PopulaEmit(objbelinfCte);
                    objRem.PopulaRem(objbelinfCte, sCte);
                    objDest.PopulaDest(objbelinfCte, sCte);
                    objNf.PopulaNf(objbelinfCte, sCte);
                    objExped.PopulaExped(objbelinfCte, sCte);
                    objReceb.PopulaReceb(objbelinfCte, sCte);
                    objVPrest.PopulaVPrest(objbelinfCte, sCte);
                    objImp.PopulaImp(objbelinfCte, sCte);
                    objInfCarga.PopulainfCarga(objbelinfCte, sCte);
                    objInfQ.PopulainfQ(objbelinfCte, sCte);
                    objRodo.PopulaRodo(objbelinfCte, sCte);
                    objRodo.PopulaVeiculo(objbelinfCte,   sCte);
                    objRodo.PopulaMotorista(objbelinfCte,  sCte);

                    objbelObjetos.objListaConhecimentos.Add(objbelinfCte);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public string GeraChave(string sCte)
        {
            try
            {
                string sChave = "";
                DataTable dt = BuscaDadosChave(sCte);

                foreach (DataRow drChave in dt.Rows)
                {

                    bel.belUF objbelUf = new bel.belUF();
                    objbelUf.SiglaUF = drChave["sUF"].ToString();


                    string sData = daoUtil.GetDateServidor().Date.ToString("dd-MM-yyyy");
                    string scUF, sAAmM, sCNPJ, sMod, sSerie, snCT, scCT;

                    scUF = objbelUf.CUF;
                    sAAmM = sData.Substring(8, 2) + sData.Substring(3, 2);

                    sCNPJ = Util.TiraSimbolo(drChave["CNPJ"].ToString());
                    sCNPJ = sCNPJ.PadLeft(14, '0');
                    sMod = "57";


                    if (IsNumeric(drChave["serie"].ToString()))
                    {
                        sSerie = Acesso.TP_EMIS != 1 ? "900" : drChave["serie"].ToString().PadLeft(3, '0');
                    }
                    else
                    {
                        sSerie = Acesso.TP_EMIS != 1 ? "900" : "001";
                    }
                    snCT = drChave["nCT"].ToString().PadLeft(9, '0');
                    scCT = (Acesso.TP_EMIS != 1 ? "5" : "1") + drChave["cCT"].ToString().PadLeft(8, '0');


                    string sChaveantDig = "";

                    string sDig = "";

                    sChaveantDig = scUF.Trim() + sAAmM.Trim() + sCNPJ.Trim() + sMod.Trim() + sSerie.Trim() + snCT.Trim() + scCT.Trim();
                    sDig = CalculaDig11(sChaveantDig).ToString();

                    sChave = sChaveantDig + sDig;
                }

                return sChave;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public int CalculaDig11(string sChave)
        {

            int iDig = 0;
            int iMult = 4;
            int iTotal = 0;

            for (int i = 0; i < sChave.Length; i++)
            {
                if (iMult < 2)
                {
                    iMult = 9;
                }
                iTotal += Convert.ToInt32(sChave[i].ToString()) * iMult;
                iMult--;

            }


            int iresto = (iTotal % 11);
            if ((iresto == 0) || (iresto == 1))
            {
                iDig = 0;
            }
            else
            {
                iDig = 11 - iresto;
            }
            return iDig;
        }

        static bool IsNumeric(object Expression)
        {
            // Variable to collect the Return value of the TryParse method.
            bool isNum;

            // Define variable to collect out parameter of the TryParse method. If the conversion fails, the out parameter is zero.
            double retNum;

            // The TryParse method converts a string in a specified style and culture-specific format to its double-precision floating point number equivalent.
            // The TryParse method does not generate an exception if the conversion fails. If the conversion passes, True is returned. If it does not, False is returned.
            isNum = Double.TryParse(Convert.ToString(Expression), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);
            return isNum;
        }
    }
}
