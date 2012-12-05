using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HLP.GeraXml.bel.NFe.Estrutura
{
    public class belIcms90
    {
        /// <summary>
        /// Tributação do ICMS; 00 - Atribuida Integralmente.
        /// </summary>
        private string _cst;

        /// <summary>
        /// Modalidade de determinação da BC do ICMS
        /// </summary>
        private string _modbc;

        /// <summary>
        /// Modalidade de determinação da BC do ICMAS ST; 0 - Preço tabelado ou máximo sugerido; 1 - Lsta Negativa (valor); 2 - Lista Positiva (valor); Lista Neutra (valor); 4 - Margem Valor agregado (%); 5 - Pauta (valor).
        /// </summary>
        private decimal _modbcst;

        /// <summary>
        /// Origem da Mercadoria; 0 - Nacional; 1 - Estrangeira, Importação direta; 2 - Estrangeira, Adquirida no merdado interno.
        /// </summary>
        private string _orig;

        /// <summary>
        /// Alíquota do imposto do ICMS.
        /// </summary>
        private decimal _picms;

        /// <summary>
        /// Alíquita do imposto do ICMS ST.
        /// </summary>
        private decimal _picmsst;

        /// <summary>
        /// Percentual da margem de valor adicionado do ICMS ST;
        /// </summary>
        private decimal _pmvast;

        /// <summary>
        /// Percentual da Redução de BC.
        /// </summary>
        private decimal _predbc;

        /// <summary>
        /// Precentual da Redução de BC do  ICMS ST;
        /// </summary>
        private decimal _predbcst;

        /// <summary>
        /// Valor da BC do ICMS
        /// </summary>
        private decimal _vbc;

        /// <summary>
        /// Valor da BC do ICMS ST.
        /// </summary>
        private decimal _vbcst;

        /// <summary>
        /// Valor do ICMS.
        /// </summary>
        private decimal _vicms;

        /// <summary>
        /// Valor do ICMS ST
        /// </summary>
        private decimal _vicmsst;

        public string Cst
        {
            get { return _cst; }
            set { _cst = value; }
        }

        public string Modbc
        {
            get { return _modbc; }
            set { _modbc = value; }
        }

        public decimal Modbcst
        {
            get { return _modbcst; }
            set { _modbcst = value; }
        }

        public string Orig
        {
            get { return _orig; }
            set { _orig = value; }
        }

        public decimal Picms
        {
            get { return _picms; }
            set { _picms = value; }
        }

        public decimal Picmsst
        {
            get { return _picmsst; }
            set { _picmsst = value; }
        }

        public decimal Pmvast
        {
            get { return _pmvast; }
            set { _pmvast = value; }
        }

        public decimal Predbc
        {
            get { return _predbc; }
            set { _predbc = value; }
        }

        public decimal Predbcst
        {
            get { return _predbcst; }
            set { _predbcst = value; }
        }

        public decimal Vbc
        {
            get { return _vbc; }
            set { _vbc = value; }
        }

        public decimal Vbcst
        {
            get { return _vbcst; }
            set { _vbcst = value; }
        }

        public decimal Vicms
        {
            get { return _vicms; }
            set { _vicms = value; }
        }

        public decimal Vicmsst
        {
            get { return _vicmsst; }
            set { _vicmsst = value; }
        }
    }
}
