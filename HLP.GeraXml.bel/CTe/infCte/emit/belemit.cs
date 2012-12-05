using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HLP.GeraXml.bel.CTe.infCte.emit
{
    public class belemit
    {

        private string _CNPJ = ""; 
        /// <summary>
        /// 1:1 N TAMANHO 14 
        /// </summary>
        public string CNPJ
        {
            get { return _CNPJ; }
            set { _CNPJ = value; }
        }

        private string _IE = "";
        /// <summary>
        /// 1:1 c TAMANHO 2-14
        /// </summary>
        public string IE
        {
            get { return _IE; }
            set { _IE = value; }
        }

        private string _xNome = "";
        /// <summary>
        /// 1:1 C TAMANHO 1-60 
        /// </summary>
        public string xNome
        {
            get { return _xNome; }
            set { _xNome = value; }
        }

        private string _xFant = "";
        /// <summary>
        /// 0:1 C TAMANHO 1-60 
        /// </summary>
        public string xFant
        {
            get { return _xFant; }
            set { _xFant = value; }
        }

        /// <summary>
        /// 1:1
        /// </summary>
        public belenderEmit enderEmit { get; set; }

    }
}
