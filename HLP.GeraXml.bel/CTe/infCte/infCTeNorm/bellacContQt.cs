using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HLP.GeraXml.bel.CTe.infCte.infCTeNorm
{
    public class bellacContQt
    {
        private string _nLacre = "";
        /// <summary>
        /// 1:1 C TAMANHO 1-20
        /// </summary>
        public string nLacre
        {
            get { return _nLacre; }
            set { _nLacre = value; }
        }

        /// <summary>
        /// 0:1 D TAMANHO 10
        /// </summary>
        public DateTime dPrev { get; set; }

    }
}
