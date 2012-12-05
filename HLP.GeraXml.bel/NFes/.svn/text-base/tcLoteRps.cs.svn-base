using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HLP.GeraXml.Comum.Static;

namespace HLP.GeraXml.bel.NFes
{
    public class tcLoteRps
    {

        /// <summary>
        /// S-255
        /// </summary>
        private string _id = "10";
        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }

        /// <summary>
        /// (1-1)  S-15
        /// </summary>
        private string _numeroLote = "";
        public string NumeroLote
        {
            get { return _numeroLote; }
            set { _numeroLote = value; }
        }

        /// <summary>
        /// (1-1) S - 14
        /// </summary>
        private string _cnpj = "";
        public string Cnpj
        {
            get { return _cnpj; }
            set { _cnpj = Util.ValidaTamanhoMaximo(14, Util.RetiraCaracterCNPJ(value)); }
        }

        /// <summary>
        /// (1-1) S-15
        /// </summary>
        private string _inscricaoMunicipal = "";
        public string InscricaoMunicipal
        {
            get { return _inscricaoMunicipal; }
            set { _inscricaoMunicipal = Util.ValidaTamanhoMaximo(15, value); }
        }

        /// <summary>
        /// (1-1) I-4
        /// </summary>
        private int _quantidadeRps;
        public int QuantidadeRps
        {
            get { return _quantidadeRps; }
            set { _quantidadeRps = value; }
        }


        public List<TcRps> Rps { get; set; }

    }
}
