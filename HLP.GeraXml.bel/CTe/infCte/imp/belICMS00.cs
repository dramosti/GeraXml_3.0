using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HLP.GeraXml.bel.CTe.infCte.imp
{
    public class belICMS00
    {
        /// <summary>
        /// 1:1 N TAMANHO 2
        /// </summary>
        public string CST { get; set; }


        private string _vBC = "";
        /// <summary>
        /// 1:1 N TAMANHO 13,2
        /// </summary>
        public string vBC
        {
            get { return _vBC; }
            set { _vBC = value; }
        }


        private string _pICMS = "";
        /// <summary>
        /// 1:1 N TAMANHO 3,2
        /// </summary>
        public string pICMS
        {
            get { return _pICMS; }
            set { _pICMS = value; }
        }



        private string _vICMS = "";
        /// <summary>
        /// 1:1 N TAMANHO 13,2
        /// </summary>
        public string vICMS
        {
            get { return _vICMS; }
            set { _vICMS = value; }
        }

    }
}
