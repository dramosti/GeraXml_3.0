using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HLP.GeraXml.bel.NFe.Estrutura
{
    public class belProcRef
    {
        /// <summary>
        /// Indentificador do processo ou ato concessório
        /// </summary>
        private string _nproc;

        public string Nproc
        {
            get { return _nproc; }
            set { _nproc = value; }
        }
        /// <summary>
        /// Indcador da origem do processo; 0 - SEFAZ;
        ///  1- Justiça Federal; 2 - Justiça Estudal; 3 - Secex/RFB; 9 - Outros
        /// </summary>
        private string _indproc;

        public string Indproc
        {
            get { return _indproc; }
            set { _indproc = value; }
        }
    }
}
