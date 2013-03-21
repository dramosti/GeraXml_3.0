using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HLP.GeraXml.bel.NFes.DSF
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://localhost:8080/WsNFe2/lote", IsNullable = false)]
    public partial class RetornoConsultaSeqRps
    {
        public CabecalhoRetSeq Cabecalho { get; set; }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class CabecalhoRetSeq
    {

        private string codCidField;

        private string cPFCNPJRemetenteField;

        private string iMPrestadorField;

        private string nroUltimoRpsField;

        private string seriePrestacaoField;

        private string versaoField;

        /// <remarks/>
        public string CodCid
        {
            get
            {
                return this.codCidField;
            }
            set
            {
                this.codCidField = value;
            }
        }

        /// <remarks/>
        public string CPFCNPJRemetente
        {
            get
            {
                return this.cPFCNPJRemetenteField;
            }
            set
            {
                this.cPFCNPJRemetenteField = value;
            }
        }

        /// <remarks/>
        public string IMPrestador
        {
            get
            {
                return this.iMPrestadorField;
            }
            set
            {
                this.iMPrestadorField = value;
            }
        }

        /// <remarks/>
        public string NroUltimoRps
        {
            get
            {
                return this.nroUltimoRpsField;
            }
            set
            {
                this.nroUltimoRpsField = value;
            }
        }

        /// <remarks/>
        public string SeriePrestacao
        {
            get
            {
                return this.seriePrestacaoField;
            }
            set
            {
                this.seriePrestacaoField = value;
            }
        }

        /// <remarks/>
        public string Versao
        {
            get
            {
                return this.versaoField;
            }
            set
            {
                this.versaoField = value;
            }
        }
    }
}
