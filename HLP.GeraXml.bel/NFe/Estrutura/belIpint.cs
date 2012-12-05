using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HLP.GeraXml.bel.NFe.Estrutura
{
    public class belIpint
    {
        /// <summary>
        /// 00 - Entrada com recuperação de crédito; 49 - Outras entradas; 50 - Saídas tributadas; 99 - Outras saídas.
        /// </summary>
        private string _cst;

        public string Cst
        {
            get { return _cst; }
            set { _cst = value; }
        }
    }
}
