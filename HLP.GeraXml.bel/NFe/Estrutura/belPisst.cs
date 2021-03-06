﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HLP.GeraXml.bel.NFe.Estrutura
{
    public class belPisst
    {
        /// <summary>
        /// Alíquita do PIS
        /// </summary>
        private decimal _ppis;

        public decimal Ppis
        {
            get { return _ppis; }
            set { _ppis = value; }
        }

        /// <summary>
        /// Alíquota do Pis (em reais)
        /// </summary>
        private decimal _valiqprod;

        public decimal Valiqprod
        {
            get { return _valiqprod; }
            set { _valiqprod = value; }
        }

        /// <summary>
        /// Valor da Base de Cálculos do PIS
        /// </summary>
        private decimal _vbc;

        public decimal Vbc
        {
            get { return _vbc; }
            set { _vbc = value; }
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
        /// Valor do PIS
        /// </summary>
        private decimal _vpis;

        public decimal Vpis
        {
            get { return _vpis; }
            set { _vpis = value; }
        }
    }
}
