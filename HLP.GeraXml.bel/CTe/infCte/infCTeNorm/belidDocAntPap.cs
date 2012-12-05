using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HLP.GeraXml.bel.CTe.infCte.infCTeNorm
{
    public class belidDocAntPap
    {
        /// <summary>
        /// 1:1 N TAMANHO 2
        /// 00-CTRC
        ///01-CTAC
        ///02-ACT
        ///03 - NF Modelo 7
        ///04 - NF Modelo 27
        ///05-Conhecimento Aéreo Nacional
        ///06-CTMC
        ///07-ATRE
        ///08-DTA (Despacho de Transito
        ///Aduaneiro)
        ///09-Conhecimento Aéreo Internacional
        ///10 – Conhecimento - Carta de Porte
        ///Internacional
        ///11 – Conhecimento Avulso
        ///12-TIF (Transporte Internacional
        ///Ferroviário)
        ///99 - outros
        /// </summary>
        public int tpDoc { get; set; }

        private string _serie = "";
        /// <summary>
        /// 1:1 C TAMANHO 1-3
        /// </summary>
        public string serie
        {
            get { return _serie; }
            set { _serie = value; }
        }

        private string _subser = "";
        /// <summary>
        /// 0:1 C TAMANHO 1-2
        /// </summary>
        public string subser
        {
            get { return _subser; }
            set { _subser = value; }
        }

        /// <summary>
        /// 1:1 N TAMANHO 1-20
        /// </summary>
        public int nDoc { get; set; }

        /// <summary>
        /// 1:1 D TAMANHO 10
        /// </summary>
        public DateTime dEmi { get; set; }


    }
}
