using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HLP.GeraXml.bel.CTe.infCte.imp
{
    public class belICMSSN
    {
        /// <summary>
        /// 1:1 N TAMANHO 1
        /// </summary>
        public string indSN { get; set; }


        private string _infAdFisco = "";
        /// <summary>
        /// 0:1 N TAMANHO 2000
        /// </summary>
        public string infAdFisco
        {
            get { return _infAdFisco; }
            set { _infAdFisco = value; }
        }
    }
}
