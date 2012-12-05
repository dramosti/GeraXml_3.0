using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HLP.GeraXml.bel.CTe.infCte.receb
{
    public class belenderReceb
    { 
        private string _xLgr = "";
        /// <summary>
        /// 1:1 C TAMANHO 1:255
        /// </summary>
        public string xLgr
        {
            get { return _xLgr; }
            set { _xLgr = value; }
        }

        private string _nro = "";
        /// <summary>
        /// 1:1 C TAMANHO 1-60
        /// </summary>
        public string nro
        {
            get { return _nro; }
            set { _nro = value; }
        }

        private string _xCpl = "";
        /// <summary>
        /// 0:1 C TAMANHO 1-60
        /// </summary>
        public string xCpl
        {
            get { return _xCpl; }
            set { _xCpl = value; }
        }

        private string _xBairro = "";
        /// <summary>
        /// 1:1 C TAMANHO 1-60
        /// </summary>
        public string xBairro
        {
            get { return _xBairro; }
            set { _xBairro = value; }
        }


        private string _cMun = "";
        /// <summary>
        /// 1:1 N TAMANHO 7
        /// </summary>
        public string cMun
        {
            get { return _cMun; }
            set { _cMun = value; }
        }

        private string _xMun = "";
        /// <summary>
        /// 1:1 C TAMANHO 1-60
        /// </summary>
        public string xMun
        {
            get { return _xMun; }
            set { _xMun = value; }
        }


        private string _CEP = "";
        /// <summary>
        /// 0:1 N TAMANHO 8
        /// </summary>
        public string CEP
        {
            get { return _CEP; }
            set { _CEP = value; }
        }


        private string _UF = "";
        /// <summary>
        /// 1:1 C TAMANHO 2
        /// </summary>
        public string UF
        {
            get { return _UF; }
            set { _UF = value; }
        }


        private string _cPais = "";
        /// <summary>
        /// 0:1 N TAMANHO 1-4
        /// </summary>
        public string cPais
        {
            get { return _cPais; }
            set { _cPais = value; }
        }

        private string _xPais = "";
        /// <summary>
        /// 0:1 C TAMANHO 1-60
        /// </summary>
        public string xPais
        {
            get { return _xPais; }
            set { _xPais = value; }
        }
    }
}
