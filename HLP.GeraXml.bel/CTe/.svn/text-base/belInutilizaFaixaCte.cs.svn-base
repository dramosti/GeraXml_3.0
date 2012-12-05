using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HLP.GeraXml.dao.CTe;
using HLP.GeraXml.dao;
using System.Data;
using HLP.GeraXml.Comum.Static;

namespace HLP.GeraXml.bel.CTe
{
    public class belInutilizaFaixaCte : daoInutilizaFaixaCte
    {

        private string _versao = "";
        public string versao
        {
            get { return _versao; }
            set { _versao = value; }
        }

        private string _Id = "";
        public string Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        private string _tpAmb = "";
        public string tpAmb
        {
            get { return _tpAmb; }
            set { _tpAmb = value; }
        }

        private string _xServ = "";
        public string xServ
        {
            get { return _xServ; }
            set { _xServ = value; }
        }

        private string _cUF = "";
        public string cUF
        {
            get { return _cUF; }
            set { _cUF = value; }
        }

        private string _ano = "";
        public string ano
        {
            get { return _ano; }
            set { _ano = value; }
        }

        private string _CNPJ = "";
        public string CNPJ
        {
            get { return _CNPJ; }
            set { _CNPJ = value; }
        }

        private string _mod = "";
        public string mod
        {
            get { return _mod; }
            set { _mod = value; }
        }

        private string _serie = "";
        public string serie
        {
            get { return _serie; }
            set { _serie = value; }
        }

        private string _nCTIni = "";
        public string nCTIni
        {
            get { return _nCTIni; }
            set { _nCTIni = value; }
        }

        private string _nCTFin = "";
        public string nCTFin
        {
            get { return _nCTFin; }
            set { _nCTFin = value; }
        }

        private string _xJust = "";
        public string xJust
        {
            get { return _xJust; }
            set { _xJust = value; }
        }


        public belInutilizaFaixaCte PopulaDadosInutilizacao(string sNumInicial, string sNumFinal, string sJustificativa)
        {
            try
            {

                belUF objbelUf = new belUF();
                belInutilizaFaixaCte objBelInutiliza = new belInutilizaFaixaCte();

                DataTable dt = RetornaDadosInutilizacao();

                foreach (DataRow dr in dt.Rows)
                {

                    objbelUf.SiglaUF = dr["cUF"].ToString();
                    objBelInutiliza.CNPJ = Util.TiraSimbolo(dr["CNPJ"].ToString());
                }


                objBelInutiliza.versao = "1.04";
                objBelInutiliza.tpAmb = Acesso.TP_AMB.ToString();
                objBelInutiliza.xServ = "INUTILIZAR";
                objBelInutiliza.cUF = objbelUf.CUF;
                objBelInutiliza.ano = daoUtil.GetDateServidor().ToString("yy");
                objBelInutiliza.mod = "57";
                objBelInutiliza.serie = "1";
                objBelInutiliza.nCTIni = sNumInicial;
                objBelInutiliza.nCTFin = sNumFinal;
                objBelInutiliza.xJust = sJustificativa;
                objBelInutiliza.Id = GeraChave(objBelInutiliza.cUF, objBelInutiliza.CNPJ, objBelInutiliza.nCTIni, objBelInutiliza.nCTFin);

                return objBelInutiliza;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        private string GeraChave(string sCodUf, string sCNPJ, string sNumInicial, string sNumFinal)
        {
            string sChave = "";
            try
            {

                sChave = "ID" + sCodUf + sCNPJ + "57" + "001" + sNumInicial.PadLeft(9, '0') + sNumFinal.PadLeft(9, '0');
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return sChave;
        }

    }
}
