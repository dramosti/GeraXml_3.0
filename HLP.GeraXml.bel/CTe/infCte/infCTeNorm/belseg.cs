using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HLP.GeraXml.bel.CTe.infCte.infCTeNorm
{
    public class belseg
    {

        private string _respSeg = "";
        /// <summary>
        /// 1:1 N TAMANHO 1
        /// 0- Remetente,
        ///1- Expedidor,
        ///2 - Recebedor,
        ///3 - Destinatário,
        ///4 - Emitente do CT-e,
        ///5 - Tomador de Serviço.
        /// </summary>
        public string respSeg
        {
            get { return _respSeg; }
            set { _respSeg = value; }
        }

        private string _xSeg = "";
        /// <summary>
        /// 0:1 C TAMANHO 1-30
        /// </summary>
        public string xSeg
        {
            get { return _xSeg; }
            set { _xSeg = value; }
        }

        private string _nApol = "";
        /// <summary>
        /// 0:1 C TAMANHO 1-20
        /// </summary>
        public string nApol
        {
            get { return _nApol; }
            set { _nApol = value; }
        }

        private string _nAver = "";
        /// <summary>
        /// 0:1 C TAMANHO 20
        /// </summary>
        public string nAver
        {
            get { return _nAver; }
            set { _nAver = value; }
        }

        /// <summary>
        /// 0:1 N TAMANHO 12,3
        /// </summary> 
        public decimal vMerc { get; set; }


    }
}
