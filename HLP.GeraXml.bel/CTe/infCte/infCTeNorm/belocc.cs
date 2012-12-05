using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HLP.GeraXml.bel.CTe.infCte.infCTeNorm
{
    public class belocc
    {
        private string _serie = "";
        /// <summary>
        /// 0:1 C TAMANHO 1-3
        /// </summary>
        public string serie
        {
            get { return _serie; }
            set { _serie = value; }
        }

        /// <summary>
        /// 1:1 N TAMANHO 1-6
        /// </summary>
        public int nOcc { get; set; }

        /// <summary>
        /// 1:1 D TAMANHO 10
        /// </summary>
        public DateTime dEmi { get; set; }

        /// <summary>
        /// 1-1
        /// </summary>
        public belemiOcc emiOcc { get; set; }

    }
}
