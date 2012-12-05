using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HLP.GeraXml.bel.CTe.infCte.rem
{
    public class belinfNF
    {

        private string _nRoma = "";
        public string nRoma
        {
            get { return _nRoma; }
            set { _nRoma = value; }
        }

        private string _nPed = "";
        public string nPed
        {
            get { return _nPed; }
            set { _nPed = value; }
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

        private string _nDoc = "";
        public string nDoc
        {
            get { return _nDoc; }
            set { _nDoc = value; }
        }

        private string _dEmi = "";
        public string dEmi
        {
            get { return _dEmi; }
            set { _dEmi = value; }
        }

        private string _vBC = "";
        public string vBC
        {
            get { return _vBC; }
            set { _vBC = value; }
        }

        private string _vICMS = "";
        public string vICMS
        {
            get { return _vICMS; }
            set { _vICMS = value; }
        }

        private string _vBCST = "";
        public string vBCST
        {
            get { return _vBCST; }
            set { _vBCST = value; }
        }

        private string _vST = "";
        public string vST
        {
            get { return _vST; }
            set { _vST = value; }
        }

        private string _vProd = "";
        public string vProd
        {
            get { return _vProd; }
            set { _vProd = value; }
        }

        private string _vNF = "";
        public string vNF
        {
            get { return _vNF; }
            set { _vNF = value; }
        }

        private string _nCFOP = "";
        public string nCFOP
        {
            get { return _nCFOP; }
            set { _nCFOP = value; }
        }

        private string _nPeso = "";
        public string nPeso
        {
            get { return _nPeso; }
            set { _nPeso = value; }
        }

        private string _PIN = "";
        public string PIN
        {
            get { return _PIN; }
            set { _PIN = value; }
        }

        public bellocRet locRet { get; set; }


    }
}
