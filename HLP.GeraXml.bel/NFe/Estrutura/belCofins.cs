using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HLP.GeraXml.bel.NFe.Estrutura
{
    public class belCofins
    {
        public string cst { get; set; }
        private belCofinsaliq _belCofinsaliq;
        private belCofinsqtde _belCofinsqtde;
        private belCofinsnt _belCofinsnt;
        private belCofinsoutr _belCofinsoutr;
        private belCofinsst _belCofinsst;
    
        public belCofinsaliq belCofinsaliq
        {
            get
            {
                return _belCofinsaliq;
            }
            set
            {
                _belCofinsaliq = value;
            }
        }

        public belCofinsqtde belCofinsqtde
        {
            get
            {
                return _belCofinsqtde;
            }
            set
            {
                _belCofinsqtde = value;
            }
        }

        public belCofinsnt belCofinsnt
        {
            get
            {
                return _belCofinsnt;
            }
            set
            {
                _belCofinsnt = value;
            }
        }

        public belCofinsoutr belCofinsoutr
        {
            get
            {
                return _belCofinsoutr;
            }
            set
            {
                _belCofinsoutr = value;
            }
        }

        public belCofinsst belCofinsst
        {
            get
            {
                return _belCofinsst;
            }
            set
            {
                _belCofinsst = value;
            }
        }
    }
}
