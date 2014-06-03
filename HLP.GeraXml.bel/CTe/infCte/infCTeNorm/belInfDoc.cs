using HLP.GeraXml.bel.CTe.infCte.rem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HLP.GeraXml.bel.CTe.infCte.infCTeNorm
{
    public class belInfDoc
    {
        private List<belinfNF> _infNF = new List<belinfNF>();
        public List<belinfNF> infNF
        {
            get { return _infNF; }
            set { _infNF = value; }
        }
        private List<belinfNFe> _infNFe = new List<belinfNFe>();
        public List<belinfNFe> infNFe
        {
            get { return _infNFe; }
            set { _infNFe = value; }
        }

        private List<belinfOutros> _infOutros = new List<belinfOutros>();
        public List<belinfOutros> infOutros
        {
            get { return _infOutros; }
            set { _infOutros = value; }
        }

    }

   
}
