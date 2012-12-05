using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HLP.GeraXml.bel.CTe.infCte.infCTeNorm
{
    public class belmoto
    {
        private string _xNome = "";
        /// <summary>
        /// 1:1 C TAMANHO 1-60 
        /// </summary>
        public string xNome
        {
            get { return _xNome; }
            set { _xNome = value; }
        }

        private string _CPF = "";
        /// <summary>
        /// 1:1 N TAMANHO 11
        /// </summary>
        public string CPF
        {
            get { return _CPF; }
            set { _CPF = value; }
        }


    }
}
