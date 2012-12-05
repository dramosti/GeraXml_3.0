using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HLP.GeraXml.bel.CTe.infCte.infCTeNorm
{
    public class belemiDocAnt
    {
        /// <summary>
        /// 1:1 N TAMANHO 14
        /// </summary>
        public int CNPJ { get; set; }

        /// <summary>
        /// 1:1 N TAMANHO 11
        /// </summary>
        public int CPF { get; set; }

        private string _IE = "";
        /// <summary>
        /// 1:1 C TAMANHO 2-14
        /// </summary>
        public string IE
        {
            get { return _IE; }
            set { _IE = value; }
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

        private string _xNome = "";
        /// <summary>
        /// 1:1 C TAMANHO 1-60
        /// </summary>
        public string xNome
        {
            get { return _xNome; }
            set { _xNome = value; }
        }

        /// <summary>
        /// 1-2
        /// </summary>
        public belidDocAnt idDocAnt { get; set; }
    }
}
