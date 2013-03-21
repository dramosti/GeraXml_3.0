using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HLP.GeraXml.bel.NFe
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
    [System.Xml.Serialization.XmlRootAttribute("envEvento", Namespace = "http://www.portalfiscal.inf.br/nfe", IsNullable = false)]
    public class belCancelamento2
    {
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string versao { get; set; }
        public string idLote { get; set; }
        public Evento evento { get; set; }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
    [System.Xml.Serialization.XmlRootAttribute("evento", Namespace = "http://www.portalfiscal.inf.br/nfe", IsNullable = false)]
    public partial class Evento
    {
        private eventoInfEvento infEventoField;

        private string versaoField;

        /// <remarks/>
        public eventoInfEvento infEvento
        {
            get
            {
                return this.infEventoField;
            }
            set
            {
                this.infEventoField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string versao
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

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public partial class eventoInfEvento
    {

        private byte cOrgaoField;

        private byte tpAmbField;

        private string cNPJField;

        private string chNFeField;

        private string dhEventoField;

        private string tpEventoField = "110111";

        private string nSeqEventoField;

        private string verEventoField;

        private eventoInfEventoDetEvento detEventoField;

        private string idField;

        /// <remarks/>
        public byte cOrgao
        {
            get
            {
                return this.cOrgaoField;
            }
            set
            {
                this.cOrgaoField = value;
            }
        }

        /// <remarks/>
        public byte tpAmb
        {
            get
            {
                return this.tpAmbField;
            }
            set
            {
                this.tpAmbField = value;
            }
        }

        /// <remarks/>
        public string CNPJ
        {
            get
            {
                return this.cNPJField;
            }
            set
            {
                this.cNPJField = value;
            }
        }

        /// <remarks/>
        public string chNFe
        {
            get
            {
                return this.chNFeField;
            }
            set
            {
                this.chNFeField = value;
            }
        }

        /// <remarks/>
        public string dhEvento
        {
            get
            {
                return this.dhEventoField;
            }
            set
            {
                this.dhEventoField = value;
            }
        }

        /// <remarks/>
        public string tpEvento
        {
            get
            {
                return this.tpEventoField;
            }
            set
            {
                this.tpEventoField = value;
            }
        }

        /// <remarks/>
        public string nSeqEvento
        {
            get
            {
                return this.nSeqEventoField;
            }
            set
            {
                this.nSeqEventoField = value;
            }
        }

        /// <remarks/>
        public string verEvento
        {
            get
            {
                return this.verEventoField;
            }
            set
            {
                this.verEventoField = value;
            }
        }

        /// <remarks/>
        public eventoInfEventoDetEvento detEvento
        {
            get
            {
                return this.detEventoField;
            }
            set
            {
                this.detEventoField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public partial class eventoInfEventoDetEvento
    {

        private string descEventoField;

        private string nProtField;

        private string xJustField;

        private string versaoField;

        /// <remarks/>
        public string descEvento
        {
            get
            {
                return this.descEventoField;
            }
            set
            {
                this.descEventoField = value;
            }
        }

        /// <remarks/>
        public string nProt
        {
            get
            {
                return this.nProtField;
            }
            set
            {
                this.nProtField = value;
            }
        }

        /// <remarks/>
        public string xJust
        {
            get
            {
                return this.xJustField;
            }
            set
            {
                this.xJustField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string versao
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
