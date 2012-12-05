using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HLP.GeraXml.bel.CTe.infCte.rem
{
    public class belinfNFe
    {
        private string _chave = "";
        public string chave
        {
            get { return _chave; }
            set { _chave = value; }
        }

        private string _nDoc = "";

        public string nDoc
        {
            get { return _nDoc; }
            set { _nDoc = value; }
        }

        public int PIN { get; set; }

    }
}
