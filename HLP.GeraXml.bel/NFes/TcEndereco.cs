using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HLP.GeraXml.Comum.Static;

namespace HLP.GeraXml.bel.NFes
{
    /// <summary>
    /// Representação completa do endereço
    /// </summary>
    public class TcEndereco
    {
        /// <summary>
        /// </summary>
        private string _endereco = "";
        /// <summary>
        /// (0-1)S-125
        /// </summary>
        public string Endereco
        {
            get { return _endereco; }
            set { _endereco = Util.ValidaTamanhoMaximo(125, value); }
        }

        /// <summary>
        /// </summary>
        private string _numero = "";
        /// <summary>
        /// (0-1)C-10
        /// </summary>
        public string Numero
        {
            get { return _numero; }
            set { _numero = value; }
        }

        /// <summary>
        /// </summary>
        private string _complemento = "";
        /// <summary>
        /// (0-1)S-60
        /// </summary>
        public string Complemento
        {
            get { return _complemento; }
            set { _complemento = Util.ValidaTamanhoMaximo(60, value); }
        }

        /// <summary>
        /// </summary>
        private string _bairro = "";
        /// <summary>
        /// (0-1) S-60
        /// </summary>
        public string Bairro
        {
            get { return _bairro; }
            set { _bairro = Util.ValidaTamanhoMaximo(60, value); }
        }

        /// <summary>
        /// </summary>
        private int _codigoMunicipio;
        /// <summary>
        /// (0-1)i - 6
        /// </summary>
        public int CodigoMunicipio
        {
            get { return _codigoMunicipio; }
            set { _codigoMunicipio = value; }
        }



        /// <summary>
        /// </summary>
        private string _uf = "";
        /// <summary>
        /// (0-1)S-2
        /// </summary>
        public string Uf
        {
            get { return _uf; }
            set { _uf = Util.ValidaTamanhoMaximo(2, value); }
        }


        /// <summary>
        /// </summary>
        private string _cep = "";
        /// <summary>
        /// (0-1)I-8
        /// </summary>
        public string Cep
        {
            get { return _cep; }
            set { _cep = value; }
        }




    }
}
