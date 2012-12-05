using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HLP.GeraXml.bel.NFe.Estrutura
{
    public class belIpitrib
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

        /// <summary>
        /// Alíquota do IPI
        /// </summary>
        private decimal _pipi;

        public decimal Pipi
        {
            get { return _pipi; }
            set { _pipi = value; }
        }

        /// <summary>
        /// Quantidade total na unidade padrão para tributação (somente para os produtos tributados por unidade).
        /// </summary>
        private decimal _qunid;

        public decimal Qunid
        {
            get { return _qunid; }
            set { _qunid = value; }
        }

        /// <summary>
        /// Valor do IPI
        /// </summary>
        private decimal _vipi;

        public decimal Vipi
        {
            get { return _vipi; }
            set { _vipi = value; }
        }

        /// <summary>
        /// Valor por Unidade Tributável
        /// </summary>
        private decimal _vunid;

        public decimal Vunid
        {
            get { return _vunid; }
            set { _vunid = value; }
        }

        /// <summary>
        /// Valor do BC do IPI
        /// </summary>
        private decimal _vbc;

        public decimal Vbc
        {
            get { return _vbc; }
            set { _vbc = (value < 0 ? 0 : value); }
        }
    }
}
