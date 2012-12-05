using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HLP.GeraXml.bel.NFe.Estrutura
{
    public class belFat
    {
        /// <summary>
        /// Número da Fatura
        /// </summary>
        private string _nfat;

        public string Nfat
        {
            get { return _nfat; }
            set { _nfat = HLP.GeraXml.Comum.Static.Util.TiraSimbolo(value,""); }
        }
        /// <summary>
        /// Valor Original da Fatura
        /// </summary>
        private decimal _vorig;

        public decimal Vorig
        {
            get { return _vorig; }
            set { _vorig = value; }
        }
        /// <summary>
        /// Valor do Desconto
        /// </summary>
        private decimal _vdesc;

        public decimal Vdesc
        {
            get { return _vdesc; }
            set { _vdesc = value; }
        }
        /// <summary>
        /// Valor Liquido da Fatura
        /// </summary>
        private decimal _vliq;

        public decimal Vliq
        {
            get { return _vliq; }
            set { _vliq = value; }
        }

        private List<belDup> _belDup;
        

        public List<belDup> belDup
        {
            get
            {
                return _belDup;
            }
            set
            {
                _belDup = value;
            }
        }
    }
}
