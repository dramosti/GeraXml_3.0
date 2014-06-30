using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HLP.GeraXml.bel
{
    public class belUF
    {

        /// <summary>
        /// Código do Estado
        /// </summary>
        private string _cUF;
        public string CUF { get { return _cUF; } }



        /// <summary>
        /// Descrição do Estado
        /// </summary>
        private string _xUF;



        /// <summary>
        /// Sigla do Estado
        /// </summary>
        private string _siglaUF;
        public string SiglaUF
        {
            get { return _siglaUF; }
            set
            {
                _siglaUF = value;
                _cUF = RetornaCUF(_siglaUF);
            }
        }//Danner - o.s. 24091 - 04/02/2010

        public bool RetornaUF(string sCUF)
        {
            bool bret = true;
            if ((sCUF != null) && (sCUF != ""))
            {

                List<belUF> objUFs = new List<belUF>();
                belUF objUF = new belUF();

                #region Region_Norte


                objUF._cUF = "11";
                objUF._siglaUF = "RO";
                objUF._xUF = "Rondônia";

                objUFs.Add(objUF);

                objUF = new belUF();

                objUF._cUF = "12";
                objUF._siglaUF = "AC";
                objUF._xUF = "Acre";

                objUFs.Add(objUF);

                objUF = new belUF();

                objUF._cUF = "13";
                objUF._siglaUF = "AM";
                objUF._xUF = "Amazonas";

                objUFs.Add(objUF);

                objUF = new belUF();

                objUF._cUF = "14";
                objUF._siglaUF = "RR";
                objUF._xUF = "Roraima";

                objUFs.Add(objUF);

                objUF = new belUF();

                objUF._cUF = "15";
                objUF._siglaUF = "PA";
                objUF._xUF = "Pará";

                objUFs.Add(objUF);

                objUF = new belUF();

                objUF._cUF = "16";
                objUF._siglaUF = "AP";
                objUF._xUF = "Amapá";

                objUFs.Add(objUF);

                objUF = new belUF();

                objUF._cUF = "17";
                objUF._siglaUF = "TO";
                objUF._xUF = "Tocantins";

                objUFs.Add(objUF);


                #endregion

                #region Regiao_Nordeste

                objUF = new belUF();

                objUF._cUF = "21";
                objUF._siglaUF = "MA";
                objUF._xUF = "Maranhão";

                objUFs.Add(objUF);

                objUF = new belUF();

                objUF._cUF = "22";
                objUF._siglaUF = "PI";
                objUF._xUF = "Piauí";

                objUFs.Add(objUF);

                objUF = new belUF();

                objUF._cUF = "23";
                objUF._siglaUF = "CE";
                objUF._xUF = "Ceará";

                objUFs.Add(objUF);

                objUF = new belUF();

                objUF._cUF = "24";
                objUF._siglaUF = "RN";
                objUF._xUF = "Rio Grande do Norte";

                objUFs.Add(objUF);

                objUF = new belUF();

                objUF._cUF = "25";
                objUF._siglaUF = "PB";
                objUF._xUF = "Paraíba";

                objUFs.Add(objUF);

                objUF = new belUF();

                objUF._cUF = "26";
                objUF._siglaUF = "PE";
                objUF._xUF = "Pernambuco";

                objUFs.Add(objUF);

                objUF = new belUF();

                objUF._cUF = "28";
                objUF._siglaUF = "SE";
                objUF._xUF = "Sergipe";

                objUFs.Add(objUF);

                objUF = new belUF();

                objUF._cUF = "29";
                objUF._siglaUF = "BA";
                objUF._xUF = "Bahía";

                objUFs.Add(objUF);


                #endregion

                #region Regiao_Sudeste

                objUF = new belUF();

                objUF._cUF = "31";
                objUF._siglaUF = "MG";
                objUF._xUF = "Minas Gerais";

                objUFs.Add(objUF);

                objUF = new belUF();

                objUF._cUF = "32";
                objUF._siglaUF = "ES";
                objUF._xUF = "Espírito Santo";

                objUFs.Add(objUF);

                objUF = new belUF();

                objUF._cUF = "33";
                objUF._siglaUF = "RJ";
                objUF._xUF = "Rio de Janeiro";

                objUFs.Add(objUF);

                objUF = new belUF();

                objUF._cUF = "35";
                objUF._siglaUF = "SP";
                objUF._xUF = "São Paulo";

                objUFs.Add(objUF);

                #endregion

                #region Região_Sul

                objUF = new belUF();

                objUF._cUF = "41";
                objUF._siglaUF = "PR";
                objUF._xUF = "Paraná";

                objUFs.Add(objUF);

                objUF = new belUF();

                objUF._cUF = "42";
                objUF._siglaUF = "SC";
                objUF._xUF = "Santa Catarina";

                objUFs.Add(objUF);

                objUF = new belUF();

                objUF._cUF = "43";
                objUF._siglaUF = "RS";
                objUF._xUF = "Rio Grande do Sul";

                objUFs.Add(objUF);

                #endregion

                #region Região_Centro_Oeste

                objUF = new belUF();

                objUF._cUF = "50";
                objUF._siglaUF = "MS";
                objUF._xUF = "Mato Grosso do Sul";

                objUFs.Add(objUF);

                objUF = new belUF();

                objUF._cUF = "51";
                objUF._siglaUF = "MT";
                objUF._xUF = "Mato Grosso";

                objUFs.Add(objUF);

                objUF = new belUF();

                objUF._cUF = "52";
                objUF._siglaUF = "GO";
                objUF._xUF = "Goias";

                objUFs.Add(objUF);

                objUF = new belUF();

                objUF._cUF = "53";
                objUF._siglaUF = "DF";
                objUF._xUF = "Distrito Federal";

                objUFs.Add(objUF);

                #endregion

                bool ctrl = false;


                foreach (var x in objUFs)
                {
                    if (x._cUF == sCUF)
                        ctrl = true;

                }
                if (ctrl == false)
                    throw new Exception("Código do Estado Inexistente");


            }
            else
            {
                bret = false;
                throw new Exception("Código do Estado está vazio ou nulo");

            }

            return bret;
        }
        public List<belUF> retListaUF()
        {
            List<belUF> objUFs = new List<belUF>();
            belUF objUF = new belUF();

            #region Region_Norte


            objUF._cUF = "11";
            objUF._siglaUF = "RO";
            objUF._xUF = "Rondônia";

            objUFs.Add(objUF);

            objUF = new belUF();

            objUF._cUF = "12";
            objUF._siglaUF = "AC";
            objUF._xUF = "Acre";

            objUFs.Add(objUF);

            objUF = new belUF();

            objUF._cUF = "13";
            objUF._siglaUF = "AM";
            objUF._xUF = "Amazonas";

            objUFs.Add(objUF);

            objUF = new belUF();

            objUF._cUF = "14";
            objUF._siglaUF = "RR";
            objUF._xUF = "Roraima";

            objUFs.Add(objUF);

            objUF = new belUF();

            objUF._cUF = "15";
            objUF._siglaUF = "PA";
            objUF._xUF = "Pará";

            objUFs.Add(objUF);

            objUF = new belUF();

            objUF._cUF = "16";
            objUF._siglaUF = "AP";
            objUF._xUF = "Amapá";

            objUFs.Add(objUF);

            objUF = new belUF();

            objUF._cUF = "17";
            objUF._siglaUF = "TO";
            objUF._xUF = "Tocantins";

            objUFs.Add(objUF);


            #endregion

            #region Regiao_Nordeste

            objUF = new belUF();

            objUF._cUF = "21";
            objUF._siglaUF = "MA";
            objUF._xUF = "Maranhão";

            objUFs.Add(objUF);

            objUF = new belUF();

            objUF._cUF = "22";
            objUF._siglaUF = "PI";
            objUF._xUF = "Piauí";

            objUFs.Add(objUF);

            objUF = new belUF();

            objUF._cUF = "23";
            objUF._siglaUF = "CE";
            objUF._xUF = "Ceará";

            objUFs.Add(objUF);

            objUF = new belUF();

            objUF._cUF = "24";
            objUF._siglaUF = "RN";
            objUF._xUF = "Rio Grande do Norte";

            objUFs.Add(objUF);

            objUF = new belUF();

            objUF._cUF = "25";
            objUF._siglaUF = "PB";
            objUF._xUF = "Paraíba";

            objUFs.Add(objUF);

            objUF = new belUF();

            objUF._cUF = "26";
            objUF._siglaUF = "PE";
            objUF._xUF = "Pernambuco";

            objUFs.Add(objUF);

            objUF = new belUF();

            objUF._cUF = "27";
            objUF._siglaUF = "AL";
            objUF._xUF = "Alagoas";

            objUFs.Add(objUF);

            objUF = new belUF();

            objUF._cUF = "28";
            objUF._siglaUF = "SE";
            objUF._xUF = "Sergipe";

            objUFs.Add(objUF);

            objUF = new belUF();

            objUF._cUF = "29";
            objUF._siglaUF = "BA";
            objUF._xUF = "Bahía";

            objUFs.Add(objUF);


            #endregion

            #region Regiao_Sudeste

            objUF = new belUF();

            objUF._cUF = "31";
            objUF._siglaUF = "MG";
            objUF._xUF = "Minas Gerais";

            objUFs.Add(objUF);

            objUF = new belUF();

            objUF._cUF = "32";
            objUF._siglaUF = "ES";
            objUF._xUF = "Espírito Santo";

            objUFs.Add(objUF);

            objUF = new belUF();

            objUF._cUF = "33";
            objUF._siglaUF = "RJ";
            objUF._xUF = "Rio de Janeiro";

            objUFs.Add(objUF);

            objUF = new belUF();

            objUF._cUF = "35";
            objUF._siglaUF = "SP";
            objUF._xUF = "São Paulo";

            objUFs.Add(objUF);

            #endregion

            #region Região_Sul

            objUF = new belUF();

            objUF._cUF = "41";
            objUF._siglaUF = "PR";
            objUF._xUF = "Paraná";

            objUFs.Add(objUF);

            objUF = new belUF();

            objUF._cUF = "42";
            objUF._siglaUF = "SC";
            objUF._xUF = "Santa Catarina";

            objUFs.Add(objUF);

            objUF = new belUF();

            objUF._cUF = "43";
            objUF._siglaUF = "RS";
            objUF._xUF = "Rio Grande do Sul";

            objUFs.Add(objUF);

            #endregion

            #region Região_Centro_Oeste

            objUF = new belUF();

            objUF._cUF = "50";
            objUF._siglaUF = "MS";
            objUF._xUF = "Mato Grosso do Sul";

            objUFs.Add(objUF);

            objUF = new belUF();

            objUF._cUF = "51";
            objUF._siglaUF = "MT";
            objUF._xUF = "Mato Grosso";

            objUFs.Add(objUF);

            objUF = new belUF();

            objUF._cUF = "52";
            objUF._siglaUF = "GO";
            objUF._xUF = "Goias";

            objUFs.Add(objUF);

            objUF = new belUF();

            objUF._cUF = "53";
            objUF._siglaUF = "DF";
            objUF._xUF = "Distrito Federal";

            objUFs.Add(objUF);

            #endregion

            return objUFs;

        }

        public string RetornaCUF(string sUF)
        {
            try
            {
                List<belUF> objlistUF = new List<belUF>();
                objlistUF = retListaUF();
                string cUF = objlistUF.FirstOrDefault(UF => UF.SiglaUF == sUF).CUF;
                return cUF;
            }
            catch (Exception ex)
            {
                return "";
            }
        }

        public string RetornaSiglaUF(string cUF)
        {
            try
            {
                List<belUF> objlistUF = new List<belUF>();
                objlistUF = retListaUF();
                return objlistUF.FirstOrDefault(UF => UF.CUF == cUF).SiglaUF;

            }
            catch (Exception ex)
            {
                throw;
            }
        }


    }
}
