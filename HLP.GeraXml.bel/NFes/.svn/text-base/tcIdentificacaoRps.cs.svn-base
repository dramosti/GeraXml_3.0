using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HLP.GeraXml.Comum.Static;

namespace HLP.GeraXml.bel.NFes
{
    /// <summary>
    /// Dados de identificação do RPS
    /// </summary>
    public class tcIdentificacaoRps
    {
        /// <summary>
        /// Meramente informativo
        /// </summary>      
        private string _nfseq = "";

        public string Nfseq
        {
            get { return _nfseq; }
            set { _nfseq = value; }
        }

        /// <summary>
        /// </summary>
        private string _numero = "";

        /// <summary>
        /// (1-1)S-15
        /// </summary>
        public string Numero
        {
            get { return _numero; }
            set { _numero = value.PadLeft(15, '0'); }
        }
        /// <summary>
        /// </summary>
        private string _serie = "";

        /// <summary>
        /// (1-1)C-5
        /// </summary>
        public string Serie
        {
            get { return _serie; }
            set { _serie = (Util.ValidaTamanhoMaximo(5, value)).PadLeft(5, '0'); }
        }
        /// <summary>
        /// </summary>
        private int _tipo;

        /// <summary>
        /// (1-1)I-1
        /// </summary>
        public int Tipo
        {
            get { return _tipo; }
            set { _tipo = value; }
        }
    }
}
