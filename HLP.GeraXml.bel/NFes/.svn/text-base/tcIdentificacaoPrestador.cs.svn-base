using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HLP.GeraXml.Comum.Static;

namespace HLP.GeraXml.bel.NFes
{
    /// <summary>
    /// Representa dados para identificação do prestador de serviço
    /// </summary>
    public class tcIdentificacaoPrestador
    {
        /// <summary>
        /// </summary>
        private string _cnpj = "";

        /// <summary>
        /// (1-1)C-14
        /// </summary>
        public string Cnpj
        {
            get { return _cnpj; }
            set { _cnpj = Util.ValidaTamanhoMaximo(14, Util.RetiraCaracterCNPJ(value)); }
        }
        /// <summary>
        /// </summary>
        private string _inscricaoMunicipal = "";

        /// <summary>
        /// (0-1)C-15
        /// </summary>
        public string InscricaoMunicipal
        {
            get { return _inscricaoMunicipal; }
            set { _inscricaoMunicipal = Util.ValidaTamanhoMaximo(15, value); }
        }
    }
}
