using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HLP.GeraXml.Comum.Static;

namespace HLP.GeraXml.bel.NFes
{
    /// <summary>
    /// Representa dados para identificação de intermediário do serviço
    /// </summary>
    public class TcIdentificacaoIntermediarioServico
    {
        /// <summary>
        /// </summary>
        private string _razaoSocial = "";

        /// <summary>
        /// (1-1) C-115
        /// </summary>
        public string RazaoSocial
        {
            get { return _razaoSocial; }
            set { _razaoSocial = Util.ValidaTamanhoMaximo(115, value); }
        }
        /// <summary>
        /// (1-1)
        /// </summary>
        public TcCpfCnpj CpfCnpj { get; set; }

        /// <summary>
        /// </summary>
        private string _inscricaoMunicipal = "";

        /// <summary>
        /// (0-1) S-15
        /// </summary>
        public string InscricaoMunicipal
        {
            get { return _inscricaoMunicipal; }
            set { _inscricaoMunicipal = Util.ValidaTamanhoMaximo(15, value); }
        }


    }
}
