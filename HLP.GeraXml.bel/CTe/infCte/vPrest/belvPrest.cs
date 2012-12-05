using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HLP.GeraXml.bel.CTe.infCte.vPrest
{
    public class belvPrest
    {
        /// <summary>
        /// 1:1 N TAMANHO 13,2
        /// </summary>
        public string vTPrest { get; set; }

        /// <summary>
        /// 1:1 N TAMANHO 13,2
        /// </summary>
        public string vRec { get; set; }

        /// <summary>
        /// 0:N
        /// </summary>
        public List<belComp> Comp { get; set; }

    }
}
