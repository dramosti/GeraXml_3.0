using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HLP.GeraXml.bel.NFe.Estrutura
{
    public class belInfadprod
    {
        /// <summary>
        /// Norma referenciada, Informaçoes complementares.
        /// </summary>
        private string _infadprid = "";

        public string Infadprid
        {
            get { return _infadprid; }
            set { _infadprid = value; }
        }

        public decimal nitem { get; set; }

    }
}
