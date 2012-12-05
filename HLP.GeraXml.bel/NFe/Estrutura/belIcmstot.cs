using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HLP.GeraXml.bel.NFe.Estrutura
{
    public class belIcmstot
    {
        /// <summary>
        /// Base de cálculo do ICMS
        /// </summary>
        private decimal _vbc;

        public decimal Vbc
        {
            get { return _vbc; }
            set { _vbc = value; }
        }

        /// <summary>
        /// Valor Total do ICMS
        /// </summary>
        private decimal _vicms;

        public decimal Vicms
        {
            get { return _vicms; }
            set { _vicms = value; }
        }

        /// <summary>
        /// Base Cálculo do ICMS ST
        /// </summary>
        private decimal _vbcst;

        public decimal Vbcst
        {
            get { return _vbcst; }
            set { _vbcst = value; }
        }

        /// <summary>
        /// Valor Total do ICMS ST
        /// </summary>
        private decimal _vst;

        public decimal Vst
        {
            get { return _vst; }
            set { _vst = value; }
        }

        /// <summary>
        /// Valor Total dos Produtos e Serviços
        /// </summary>
        private decimal _vprod;

        public decimal Vprod
        {
            get { return _vprod; }
            set { _vprod = value; }
        }

        /// <summary>
        /// Valor Total do Frete
        /// </summary>
        private decimal _vfrete;

        public decimal Vfrete
        {
            get { return _vfrete; }
            set { _vfrete = value; }
        }

        /// <summary>
        /// Valor Total do Seguro
        /// </summary>
        private decimal _vseg;

        public decimal Vseg
        {
            get { return _vseg; }
            set { _vseg = value; }
        }

        /// <summary>
        /// Valor Total do Desconto
        /// </summary>
        private decimal _vdesc;

        public decimal Vdesc
        {
            get { return _vdesc; }
            set { _vdesc = value; }
        }

        /// <summary>
        /// Valor Total do II
        /// </summary>
        private decimal _vii;

        public decimal Vii
        {
            get { return _vii; }
            set { _vii = value; }
        }

        /// <summary>
        /// Valor Total do IPI
        /// </summary>
        private decimal _vipi;

        public decimal Vipi
        {
            get { return _vipi; }
            set { _vipi = value; }
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

        /// <summary>
        /// Valor do COFINS
        /// </summary>
        private decimal _vcofins;

        public decimal Vcofins
        {
            get { return _vcofins; }
            set { _vcofins = value; }
        }

        /// <summary>
        /// Outras despesas acessórias
        /// </summary>
        private decimal _voutro;

        public decimal Voutro
        {
            get { return _voutro; }
            set { _voutro = value; }
        }

        /// <summary>
        /// Valor Total da NF-e
        /// </summary>
        private decimal _vnf;

        public decimal Vnf
        {
            get { return _vnf; }
            set { _vnf = value; }
        }
    }
}
