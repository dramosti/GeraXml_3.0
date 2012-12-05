using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HLP.GeraXml.bel.CTe.infCte.imp
{
    public class belICMSOutraUF
    {

        /// <summary>
        /// 1:1 N TAMANHO 2
        /// </summary>
        public string CST { get; set; }


        private string _pRedBCOutraUF = "";
        /// <summary>
        /// 1:1 N TAMANHO 3,2
        /// </summary>
        public string pRedBCOutraUF
        {
            get { return _pRedBCOutraUF; }
            set { _pRedBCOutraUF = value; }
        }

        private string _vBCOutraUF = "";
        /// <summary>
        /// 1:1 N TAMANHO 13,2
        /// </summary>
        public string vBCOutraUF
        {
            get { return _vBCOutraUF; }
            set { _vBCOutraUF = value; }
        }


        private string _pICMSOutraUF = "";
        /// <summary>
        /// 1:1 N TAMANHO 3,2
        /// </summary>
        public string pICMSOutraUF
        {
            get { return _pICMSOutraUF; }
            set { _pICMSOutraUF = value; }
        }


        private string _vICMSOutraUF = "";
        /// <summary>
        /// 0:1 N TAMANHO 13,2
        /// </summary>
        public string vICMSOutraUF
        {
            get { return _vICMSOutraUF; }
            set { _vICMSOutraUF = value; }
        }
    }
}
