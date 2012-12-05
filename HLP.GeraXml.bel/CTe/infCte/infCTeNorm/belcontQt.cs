using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HLP.GeraXml.bel.CTe.infCte.infCTeNorm
{
    public class belcontQt
    {
        /// <summary>
        /// 1:1 N TAMANHO 1-20
        /// </summary>
        public int nCont { get; set; }

        /// <summary>
        /// 0:N
        /// </summary>
        public List<bellacContQt> lacContQt { get; set; }

    }
}
