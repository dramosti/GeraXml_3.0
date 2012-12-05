using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HLP.GeraXml.Comum.Static;

namespace HLP.GeraXml.bel.NFes
{
    /// <summary>
    /// Representa dados para identificação de órgão gerador
    /// </summary>
    public class tcIdentificacaoOrgaoGerador
    {
        /// <summary>
        /// </summary>
        private string _codigoMunicipio = "";

        /// <summary>
        /// (1-1)S-7
        /// </summary>
        public string CodigoMunicipio
        {
            get { return _codigoMunicipio; }
            set { _codigoMunicipio = value; }
        }
        /// <summary>
        /// </summary>
        private string _uf = "";

        /// <summary>
        /// (1-1)S-2
        /// </summary>
        public string Uf
        {
            get { return _uf; }
            set { _uf = Util.ValidaTamanhoMaximo(2, value); }
        }
    }
}
