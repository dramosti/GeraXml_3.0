using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HLP.GeraXml.bel.NFe.Estrutura
{
    public class belIcms51
    {
        /// <summary>
        /// Tributação do ICMS; 00 - Atribuida Integralmente.
        /// </summary>
        private string _cst;

        public string Cst
        {
            get { return _cst; }
            set { _cst = value; }
        }

        /// <summary>
        /// Origem da Mercadoria; 0 - Nacional; 1 - Estrangeira, Importação direta; 2 - Estrangeira, Adquirida no merdado interno.
        /// </summary>
        private string _orig;

        public string Orig
        {
            get { return _orig; }
            set { _orig = value; }
        }

        /// <summary>
        /// Modalidade de determinação da BC do ICMS
        /// </summary>
        private string _modbc;

        public string Modbc
        {
            get { return _modbc; }
            set { _modbc = value; }
        }

        /// <summary>
        /// Percentual da Redução de BC.
        /// </summary>
        private decimal _predbc;

        public decimal Predbc
        {
            get { return _predbc; }
            set { _predbc = value; }
        }

        /// <summary>
        /// Valor da BC do ICMS
        /// </summary>
        private decimal _vbc;

        public decimal Vbc
        {
            get { return _vbc; }
            set { _vbc = value; }
        }

        /// <summary>
        /// Alíquota do imposto do ICMS.
        /// </summary>
        private decimal _picms;

        public decimal Picms
        {
            get { return _picms; }
            set { _picms = value; }
        }

        /// <summary>
        /// Valor do ICMS.
        /// </summary>
        private decimal _vicms;

        public decimal Vicms
        {
            get { return _vicms; }
            set { _vicms = value; }
        }
    }
}
