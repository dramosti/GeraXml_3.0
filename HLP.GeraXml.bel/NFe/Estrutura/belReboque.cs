using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HLP.GeraXml.bel.NFe.Estrutura
{
    public class belReboque
    {
        /// <summary>
        /// Placa do veículo
        /// </summary>
        private string _placa;

        public string Placa
        {
            get { return _placa; }
            set { _placa = value; }
        }
        /// <summary>
        /// Sigla UF
        /// </summary>
        private string _uf;

        public string Uf
        {
            get { return _uf; }
            set { _uf = value; }
        }
        /// <summary>
        /// Registro Nacional de Transportador de Carga (ANTT)
        /// </summary>
        private string _rntc;

        public string Rntc
        {
            get { return _rntc; }
            set { _rntc = value; }
        }
    }
}
