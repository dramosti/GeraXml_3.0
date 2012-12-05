using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HLP.GeraXml.bel.NFe.Estrutura
{
    public class belCofinsst
    {
        /// <summary>
        /// Aliquota da COFINS (em percentual)
        /// </summary>
        private decimal _pcofins;

        public decimal Pcofins
        {
            get { return _pcofins; }
            set { _pcofins = value; }
        }

        /// <summary>
        /// Quantidade Vendida
        /// </summary>
        private decimal _qbcprod;

        public decimal Qbcprod
        {
            get { return _qbcprod; }
            set { _qbcprod = value; }
        }

        /// <summary>
        /// Alíquota do COFINS (em reais)
        /// </summary>
        private decimal _valiqprod;

        public decimal Valiqprod
        {
            get { return _valiqprod; }
            set { _valiqprod = value; }
        }

        /// <summary>
        /// Valor da Base de Cálculo da COFINS
        /// </summary>
        private decimal _vbc;

        public decimal Vbc
        {
            get { return _vbc; }
            set { _vbc = value; }
        }

        /// <summary>
        /// Valor do COFINS
        /// </summary>
        private decimal _vcofins;

        public decimal Vcofins
        {
            get { return _vcofins; }
            set { _vcofins = value; }
        }
    }
}
