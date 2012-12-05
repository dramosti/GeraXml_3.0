using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HLP.GeraXml.bel.NFe.Estrutura
{
    public class belRetTrib
    {
        /// <summary>
        /// Valor retido dE PIS
        /// </summary>
        private decimal _vretpis;

        public decimal Vretpis
        {
            get { return _vretpis; }
            set { _vretpis = value; }
        }

        /// <summary>
        /// Valor retido do COFINS
        /// </summary>
        private decimal _vretcofins;

        public decimal Vretcofins
        {
            get { return _vretcofins; }
            set { _vretcofins = value; }
        }

        /// <summary>
        /// Base  de cálculo  do IRRF
        /// </summary>
        private decimal _vretcsll;

        public decimal Vretcsll
        {
            get { return _vretcsll; }
            set { _vretcsll = value; }
        }
        //Danner - o.s. 24091 - 08/02/2010
        /// <summary>
        /// Base de Cálculo do IRRF
        /// </summary>
        private decimal _vbcirrf;

        public decimal Vbcirrf
        {
            get { return _vbcirrf; }
            set { _vbcirrf = value; }
        }
        //Fim - Danner - o.s. 24091 - 08/02/2010
        /// <summary>
        /// Valor Retido do IRRF
        /// </summary>
        private decimal _virrf;

        public decimal Virrf
        {
            get { return _virrf; }
            set { _virrf = value; }
        }

        /// <summary>
        /// Base de Cálculo da Retenção da previdência socia
        /// </summary>
        private decimal _vbcretprev;

        public decimal Vbcretprev
        {
            get { return _vbcretprev; }
            set { _vbcretprev = value; }
        }

        /// <summary>
        /// Valor da Retenção  da Previdência Social
        /// </summary>
        private decimal _vretprev;

        public decimal Vretprev
        {
            get { return _vretprev; }
            set { _vretprev = value; }
        }
    }
}
