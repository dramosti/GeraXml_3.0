using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HLP.GeraXml.bel.CTe.infCte.infCTeNorm
{
    public class belrodo
    {

        private string _RNTRC = "";
        /// <summary>
        /// 1:1 N TAMANHO 14
        /// </summary> 
        public string RNTRC
        {
            get { return _RNTRC; }
            set { _RNTRC = value; }
        }


        private string _dPrev = "";
        /// <summary>
        /// 1:1 D TAMANHO 10
        /// </summary>
        public string dPrev
        {
            get { return _dPrev; }
            set { _dPrev = value; }
        }


        private string _lota = "";
        /// <summary>
        /// 0 - Não,
        /// 1 - Sim
        /// 1:1 N TAMANHO 1
        /// /// </summary>
        public string lota
        {
            get { return _lota; }
            set { _lota = value; }
        }

        /// <summary>
        /// 0:1  
        /// </summary>
        public belCTRB CTRB { get; set; }

        /// <summary>
        /// 0-10
        /// </summary>
        public belocc occ { get; set; }

        /// <summary>
        /// 0:1
        /// </summary>
        public belvalePed valePed { get; set; }

        /// <summary>
        /// 0:4
        /// </summary>
        public List<belveic> veic { get; set; }

        /// <summary>
        /// 0:N
        /// </summary>
        public List<bellacRodo> lacRodo { get; set; }

        /// <summary>
        /// 0:N
        /// </summary>
        public belmoto moto { get; set; }






    }
}
