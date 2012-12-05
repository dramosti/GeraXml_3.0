using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HLP.GeraXml.bel.NFe.Estrutura
{
    public class belObsFisco
    {
        /// <summary>
        /// Identificação do campo
        /// </summary>
        private string _xcampo;

        /// <summary>
        /// Conteúdo do campo
        /// </summary>
        private string _xtexto;

        public string Xcampo
        {
            get { return _xcampo; }
            set { _xcampo = value; }
        }

        public string Xtexto
        {
            get { return _xtexto; }
            set { _xtexto = value; }
        }
    }
}
