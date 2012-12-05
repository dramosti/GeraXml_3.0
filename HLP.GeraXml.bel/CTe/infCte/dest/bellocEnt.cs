using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HLP.GeraXml.bel.CTe.infCte.dest
{
    public class bellocEnt
    {
        /// <summary>
        /// 1:1 N TAMANHO 14
        /// </summary>
        public int CNPJ { get; set; }

        /// <summary>
        /// 1:1 C TAMANHO 1-60
        /// </summary>
        public int CPF { get; set; }

        private string _xNome = "";
        /// <summary>
        /// 1:1 C TAMANHO 1-60
        /// </summary>
        public string xNome
        {
            get { return _xNome; }
            set { _xNome = value; }
        }

        private string _xLgr = "";
        /// <summary>
        /// 1:1 C TAMANHO 1-255
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

        /// <summary>
        /// 1:1 N TAMANHO 7
        /// </summary>
        public int cMun { get; set; }

        private string _xMun = "";
        /// <summary>
        /// 1:1 C TAMANHO 1-60
        /// </summary>
        public string xMun
        {
            get { return _xMun; }
            set { _xMun = value; }
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
    }
}
