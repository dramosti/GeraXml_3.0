using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HLP.GeraXml.bel.CTe.infCte.infCTeNorm
{
    public class belvalePed
    {
        private string _nroRE = "";
        /// <summary>
        /// 0:1 C TAMANHO 5-9
        /// </summary>
        public string nroRE
        {
            get { return _nroRE; }
            set { _nroRE = value; }
        }

        /// <summary>
        /// 0:1 N TAMANHO 13,2
        /// </summary>
        public decimal vTValePed { get; set; }

        /// <summary>
        /// 1:1 N TAMANHO 1 
        /// 0-emitente do CT-e, 1-remetente, 2-
        ///expedidor, 3-recebedor, 4-destinatário, 5-
        ///Tomador do Serviço
        /// </summary>
        public int respPg { get; set; }

        /// <summary>
        /// 0:N
        /// </summary>
        public List<beldisp> disp { get; set; }
    }
}
