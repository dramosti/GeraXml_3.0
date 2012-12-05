using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HLP.GeraXml.Comum.Static;

namespace HLP.GeraXml.bel.NFes
{
    /// <summary>
    /// Representa dados que compõe o serviço prestado
    /// </summary>
    public class TcDadosServico
    {

        /// <summary>
        /// (1-1)
        /// </summary>
        public TcValores Valores { get; set; }

        /// <summary>
        /// </summary>
        private string _itemListaServico = "";

        /// <summary>
        /// (1-1)S-5 ( Código de item na lista de serviço
        /// </summary>
        public string ItemListaServico
        {
            get { return _itemListaServico; }
            set { _itemListaServico = Util.ValidaTamanhoMaximo(5, value); }
        }
        /// <summary>
        /// </summary>
        private string _codigoCnae = "";

        /// <summary>
        /// (0-1)S-7
        /// </summary>
        public string CodigoCnae
        {
            get { return _codigoCnae; }
            set { _codigoCnae = value; }
        }
        /// <summary>
        /// </summary>
        private string _codigoTributacaoMunicipio = "";

        /// <summary>
        /// (0-1) S-20
        /// </summary>
        public string CodigoTributacaoMunicipio
        {
            get { return _codigoTributacaoMunicipio; }
            set { _codigoTributacaoMunicipio =  Util.ValidaTamanhoMaximo(20, value); }
        }
        /// <summary>
        /// </summary>
        private string _discriminacao = "";

        /// <summary>
        /// (1-1)S-2000
        /// </summary>
        public string Discriminacao
        {
            get { return _discriminacao; }
            set { _discriminacao =  Util.ValidaTamanhoMaximo(2000, value); }
        }

        /// <summary>
        /// </summary>
        private string _codigoMunicipio = "";

        /// <summary>
        /// (1-1) I-7
        /// </summary>
        public string CodigoMunicipio
        {
            get { return _codigoMunicipio; }
            set { _codigoMunicipio = value; }
        }
    }
}
