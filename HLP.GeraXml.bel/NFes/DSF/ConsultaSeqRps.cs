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
    public partial class ConsultaSeqRps
    {
        [System.Xml.Serialization.XmlAttributeAttribute(AttributeName = "schemaLocation", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
        public string schemaLocation = "http://localhost:8080/WsNFe2/lote http://localhost:8080/WsNFe2/xsd/ConsultaSeqRps.xsd";

        public CabecalhoSeq Cabecalho { get; set; }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class CabecalhoSeq
    {

        private string codCidField;

        private string iMPrestadorField;

        private string cPFCNPJRemetenteField;

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
