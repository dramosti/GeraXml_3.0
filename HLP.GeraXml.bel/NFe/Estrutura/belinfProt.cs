using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HLP.GeraXml.bel.NFe.Estrutura
{
    public class belinfProt
    {       
        private int _tpAmb;

        public int TpAmb
        {
            get { return _tpAmb; }
            set { _tpAmb = value; }
        }
        private string _verAplic;

        public string VerAplic
        {
            get { return _verAplic; }
            set { _verAplic = value; }
        }
        private string _chNFe;

        public string ChNFe
        {
            get { return _chNFe; }
            set { _chNFe = value; }
        }
        private DateTime _chRecbto;

        public DateTime ChRecbto
        {
            get { return _chRecbto; }
            set { _chRecbto = value; }
        }
        private string _nProt;

        public string NProt
        {
            get { return _nProt; }
            set { _nProt = value; }
        }
        private string _digVal;

        public string DigVal
        {
            get { return _digVal; }
            set { _digVal = value; }
        }
        private string _cStat;

        public string CStat
        {
            get { return _cStat; }
            set { _cStat = value; }
        }
        private string _xMotivo;

        public string XMotivo
        {
            get { return _xMotivo; }
            set { _xMotivo = value; }
        }
    }
}
