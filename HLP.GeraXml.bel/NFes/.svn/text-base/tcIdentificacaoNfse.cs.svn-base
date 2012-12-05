using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HLP.GeraXml.Comum.Static;

namespace HLP.GeraXml.bel.NFes
{
    /// <summary>
    /// Representa dados que identificam uma Nota Fiscal de Serviços Eletrônica
    /// </summary>
    public class tcIdentificacaoNfse
    {
        /// <summary>
        /// S15
        /// </summary>
        private string _numero;

        /// <summary>
        /// (1-1) I - 15
        /// </summary>
        public string Numero
        {
            get { return _numero; }
            set { _numero = value; }
        }
        /// <summary>
        /// </summary>
        private string _cnpj = "";

        /// <summary>
        /// (1-1) S - 15
        /// </summary>
        public string Cnpj
        {
            get { return _cnpj; }
            set { _cnpj = Util.TiraSimbolo(value, ""); }
        }
        /// <summary>
        /// </summary>
        private string _inscricaoMunicipal = "";

        /// <summary>
        /// (0-1) S - 15
        /// </summary>
        public string InscricaoMunicipal
        {
            get { return _inscricaoMunicipal; }
            set { _inscricaoMunicipal = Util.ValidaTamanhoMaximo(15, value); }
        }
        /// <summary>
        /// </summary>
        private string _codigoMunicipio = "";

        /// <summary>
        /// (1-1) S - 7
        /// </summary>
        public string CodigoMunicipio
        {
            get { return _codigoMunicipio; }
            set { _codigoMunicipio = value; }
        }
    }
}
