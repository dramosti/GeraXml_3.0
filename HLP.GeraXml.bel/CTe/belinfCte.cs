using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HLP.GeraXml.bel.CTe.infCte.vPrest;
using HLP.GeraXml.bel.CTe.infCte.imp;
using HLP.GeraXml.bel.CTe.infCte.dest;
using HLP.GeraXml.bel.CTe.infCte.rem;
using HLP.GeraXml.bel.CTe.infCte.receb;
using HLP.GeraXml.bel.CTe.infCte.exped;
using HLP.GeraXml.bel.CTe.infCte.emit;
using HLP.GeraXml.bel.CTe.infCte.ide;
using HLP.GeraXml.bel.CTe.infCte.infCTeNorm;

namespace HLP.GeraXml.bel.CTe
{
    public class belinfCte
    {

        public belinfCte() 
        {
            this.infCTeNorm = new belinfCTeNorm();
        }

        /// <summary>
        /// 1:1
        /// </summary>
        public string versao { get; set; }


        /// <summary>
        /// 1:1 C TAMANHO 47
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// 1:1
        /// </summary>
        public belide ide { get; set; }

        /// <summary>
        /// 1:1
        /// </summary>
        public belemit emit { get; set; }

        /// <summary>
        /// 0:1
        /// </summary>
        public belcompl compl { get; set; }

        /// <summary>
        /// 0:1
        /// </summary>
        public belexped exped { get; set; }

        /// <summary>
        /// 0:1
        /// </summary>
        public belreceb receb { get; set; }

        /// <summary>
        /// 0:1
        /// </summary>
        public belrem rem { get; set; }

        /// <summary>
        /// 0:1
        /// </summary>
        public beldest dest { get; set; }

        /// <summary>
        /// 1:1
        /// </summary>
        public belvPrest vPrest { get; set; }

        /// <summary>
        /// 1:1
        /// </summary>
        public belimp imp { get; set; }

        /// <summary>
        /// 1:1
        /// </summary>
        public belinfCTeNorm infCTeNorm { get; set; }

        //public belinfCteComp infCteComp { get; set; }
        //public belinfCteAnu infCteAnu { get; set; }


    }
}
