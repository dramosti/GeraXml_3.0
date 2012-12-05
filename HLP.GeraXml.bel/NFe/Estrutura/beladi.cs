using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HLP.GeraXml.bel.NFe.Estrutura
{
    public class beladi
    {
        /// <summary>
        /// 1-3 Numero da adição
        /// </summary>
        public int nAdicao { get; set; }
        /// <summary>
        /// 1-3 Numero seqüencial do item dentro da adição
        /// </summary>
        private int _nSeqAdic;

        public int nSeqAdic
        {
            get { return _nSeqAdic; }
            set
            {
                if (value.ToString().Count() > 3)
                {
                    _nSeqAdic = Convert.ToInt32(value.ToString().Substring(0, 3));
                }
                else
                {
                    _nSeqAdic = value;
                }
            }
        }
        /// <summary>
        /// 1-60 Código do fabricante estrangeiro
        /// </summary>
        private string _cFabricante;

        public string cFabricante
        {
            get { return _cFabricante; }
            set { _cFabricante = value.ToUpper(); }
        }

        /// <summary>
        /// 15,2 Valor do desconto do item da DI – Adição
        /// </summary>
        public decimal vDescDI { get; set; }

    }
}

