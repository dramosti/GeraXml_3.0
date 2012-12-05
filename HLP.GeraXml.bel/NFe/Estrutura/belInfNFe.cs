using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HLP.GeraXml.bel.NFe.Estrutura
{
    public class belInfNFe
    {
        private string _chaveNFe;
        public string chaveNFe
        {
            get { return _chaveNFe; }
            set
            {
                _chaveNFe = value;
                sDigVerif = value.Substring((value.Length - 1), 1);
            }
        }
        public string sDigVerif { get; set; }
        public string id { get; set; }


        public belIde ide = new belIde();
        public belEmit emit = new belEmit();
        public belAvulsa avulsa = new belAvulsa();
        public belDest dest = new belDest();
        public belEndEnt endent = new belEndEnt();
        public belRetirada retirada = new belRetirada();
        public List<belDet> det { get; set; }
        public belTotal total = new belTotal();
        public belTransp transp = new belTransp();
        public belCobr cobr = new belCobr();
        public belInfAdic infAdic = new belInfAdic();
        public belExporta exporta = new belExporta();
        public belCompra compra = new belCompra();
        public belprotNFe protNFe = new belprotNFe();

        private string _empresa;
        public string Empresa
        {
            get { return _empresa; }
            set { _empresa = value; }
        }

        private string _cdclifor;
        public string Cdclifor
        {
            get { return _cdclifor; }
            set { _cdclifor = value; }
        }
    }
}
