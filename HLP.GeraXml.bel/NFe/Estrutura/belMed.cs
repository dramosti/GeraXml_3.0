using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HLP.GeraXml.dao.NFe.Estrutura;

namespace HLP.GeraXml.bel.NFe.Estrutura
{
    public class belMed 
    {
        /// <summary>
        /// Numero do Lote de Medicamento
        /// </summary>
        private string _nlote;

        public string Nlote
        {
            get { return _nlote; }
            set { _nlote = value; }
        }
        /// <summary>
        /// Quantidade de produto no Lote de medicamento
        /// </summary>
        private string _qlote;

        public string Qlote
        {
            get { return _qlote; }
            set { _qlote = value; }
        }
        /// <summary>
        /// Data de Fabricação, Formatação "AAAA-MM-DD"
        /// </summary>
        DateTime _dFab;

        public DateTime DFab
        {
            get { return _dFab; }
            set { _dFab = value; }
        }
        /// <summary>
        /// Data de Validade, Formatação "AAAA-MM-DD"
        /// </summary>
        private DateTime _dval;

        public DateTime Dval
        {
            get { return _dval; }
            set { _dval = value; }
        }
        /// <summary>
        /// Preço máximo consumidor.
        /// </summary>
        private decimal _vpmc;

        public decimal Vpmc
        {
            get { return _vpmc; }
            set { _vpmc = value; }
        }
    }
}
