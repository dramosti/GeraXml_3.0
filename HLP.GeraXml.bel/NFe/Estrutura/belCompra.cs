using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HLP.GeraXml.bel.NFe.Estrutura
{
    public class belCompra
    {
        /// <summary>
        /// Nota de empenho, Informar a identificação da hota de Empenho, quando se trata de compras públicas
        /// </summary>
        private string _xnemp;

        public string Xnemp
        {
            get { return _xnemp; }
            set { _xnemp = value; }
        }
        /// <summary>
        /// Informar o pedido
        /// </summary>
        private string _xped;

        public string Xped
        {
            get { return _xped; }
            set { _xped = value; }
        }
        /// <summary>
        /// Informal o contatrato de compra
        /// </summary>
        private string _xcont;

        public string Xcont
        {
            get { return _xcont; }
            set { _xcont = value; }
        }
    }
}
