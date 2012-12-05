using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HLP.GeraXml.bel.NFe.Estrutura
{
    public class belInfNFe
    {
        /// <summary>
        /// Versão do leiaute.
        /// </summary>
        private string versao;
        /// <summary>
        /// Identificador da TAG a ser assinada. Informar a chave de acesso da NF-e precedida do literal 'NF-e'.
        /// </summary>
        private string _id;

        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }
        /// <summary>
        /// Regra de validação do item de detalhe da NF-e , comapo de contro de Schema XML, o contribuinte não deve se preocpar  com o preenchimento desse campo.
        /// </summary>
        private string pk_nitem;
        private belIde _belIde;

        public belIde BelIde
        {
            get { return _belIde; }
            set { _belIde = value; }
        }
        private belEmit _belEmit;

        public belEmit BelEmit
        {
            get { return _belEmit; }
            set { _belEmit = value; }
        }
        private belAvulsa _belavulsa;

        public belAvulsa Belavulsa
        {
            get { return _belavulsa; }
            set { _belavulsa = value; }
        }
        private belDest _belDest;

        public belDest BelDest
        {
            get { return _belDest; }
            set { _belDest = value; }
        }
        private belRetirada _belRetirada;

        public belRetirada BelRetirada
        {
            get { return _belRetirada; }
            set { _belRetirada = value; }
        }
        private List<belDet> _belDet;

        public List<belDet> BelDet
        {
            get { return _belDet; }
            set { _belDet = value; }
        }
        private belTotal _beTotal;

        public belTotal BelTotal
        {
            get { return _beTotal; }
            set { _beTotal = value; }
        }
        private belTransp _belTransp;

        public belTransp BelTransp
        {
            get { return _belTransp; }
            set { _belTransp = value; }
        }
        private belCobr _belCobr;

        public belCobr BelCobr
        {
            get { return _belCobr; }
            set { _belCobr = value; }
        }
        private belInfAdic _belinfAdic;

        public belInfAdic BelinfAdic
        {
            get { return _belinfAdic; }
            set { _belinfAdic = value; }
        }
        private belExporta _belExporta;

        public belExporta BelExporta
        {
            get { return _belExporta; }
            set { _belExporta = value; }
        }

        private belCompra _belCompra;

        public belCompra BelCompra
        {
            get { return _belCompra; }
            set { _belCompra = value; }
        }

        private belprotNFe _belProtNFe;

        public belprotNFe BelProtNFe
        {
            get { return _belProtNFe; }
            set { _belProtNFe = value; }
        }

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
