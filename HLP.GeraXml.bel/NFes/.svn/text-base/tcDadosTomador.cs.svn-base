using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HLP.GeraXml.Comum.Static;

namespace HLP.GeraXml.bel.NFes
{
    /// <summary>
    /// Representa dados do tomador de serviço
    /// </summary>
    public class tcDadosTomador
    {
        /// <summary>
        /// </summary>
        private string _razaoSocial = "";

        /// <summary>
        /// (0-1) C-115
        /// </summary>
        public string RazaoSocial
        {
            get { return _razaoSocial; }
            set { _razaoSocial = Util.ValidaTamanhoMaximo(115, value); }
        }

        /// <summary>
        /// (0-1)
        /// </summary>
        public tcIdentificacaoTomador IdentificacaoTomador { get; set; }

        /// <summary>
        /// (0-1)
        /// </summary>
        public TcEndereco Endereco { get; set; }

        /// <summary>
        /// (0-1)
        /// </summary>
        public TcContato Contato { get; set; }
    }
}
