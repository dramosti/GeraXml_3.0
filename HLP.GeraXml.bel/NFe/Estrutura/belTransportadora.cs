using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HLP.GeraXml.bel.NFe.Estrutura
{
    public class belTransportadora
    {
        /// <summary>
        /// Informar o CNPJ ou o CPF  do Transportador, preenchendo os zeros não segnificativos.
        /// </summary>
        private string _cnpj;

        public string Cnpj
        {
            get { return _cnpj; }
            set { _cnpj = HLP.GeraXml.Comum.Static.Util.TiraSimbolo(value,""); }
        }

        /// <summary>
        /// Informar o CNPJ ou o CPF  do Transportador, preenchendo os zeros não segnificativos.
        /// </summary>
        private string _cpf;

        public string Cpf
        {
            get { return _cpf; }
            set { _cpf = HLP.GeraXml.Comum.Static.Util.TiraSimbolo(value,""); }
        }

        /// <summary>
        /// Razão Social ou Nome
        /// </summary>
        private string _xnome;

        public string Xnome
        {
            get { return _xnome; }
            set { _xnome = HLP.GeraXml.Comum.Static.Util.TiraSimbolo(value,""); }
        }

        /// <summary>
        /// Inscrição Estadual
        /// </summary>
        private string _ie;

        public string Ie
        {
            get { return _ie; }
            set { _ie = HLP.GeraXml.Comum.Static.Util.TiraSimbolo(value,""); }
        }

        /// <summary>
        /// Nome do Município
        /// </summary>
        private string _xmun;

        public string Xmun
        {
            get { return _xmun; }
            set { _xmun = HLP.GeraXml.Comum.Static.Util.TiraSimbolo(value,""); }
        }

        /// <summary>
        /// Endereço Completo
        /// </summary>
        private string _xender;

        public string Xender
        {
            get { return _xender; }
            set { _xender = HLP.GeraXml.Comum.Static.Util.TiraSimbolo(value,""); }
        }

        /// <summary>
        /// Sigla do UF
        /// </summary>
        private string _uf;

        public string Uf
        {
            get { return _uf; }
            set { _uf = value; }
        }
    }
}
