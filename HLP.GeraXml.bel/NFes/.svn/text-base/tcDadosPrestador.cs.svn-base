using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HLP.GeraXml.Comum.Static;

namespace HLP.GeraXml.bel.NFes
{
    /// <summary>
    /// Representa dados do prestador do serviço
    /// </summary>
    public class tcDadosPrestador
    {
        /// <summary>
        /// </summary>
        private string _razaoSocial = "";

        /// <summary>
        /// (1-1) S-115
        /// </summary>
        public string RazaoSocial
        {
            get { return _razaoSocial; }
            set { _razaoSocial =  Util.ValidaTamanhoMaximo(115, value); }
        }
        /// <summary>
        /// </summary>
        private string _nomeFantasia = "";

        /// <summary>
        /// (0-1) S-60
        /// </summary>
        public string NomeFantasia
        {
            get { return _nomeFantasia; }
            set { _nomeFantasia = value; }
        }

        /// <summary>
        /// (1-1)
        /// </summary>
        public tcIdentificacaoPrestador IdentificacaoPrestador { get; set; }
        /// <summary>
        /// (1-1)
        /// </summary>
        public TcEndereco Endereco { get; set; }
        /// <summary>
        /// (0-1)
        /// </summary>
        public TcContato Contato { get; set; }




    }
}
