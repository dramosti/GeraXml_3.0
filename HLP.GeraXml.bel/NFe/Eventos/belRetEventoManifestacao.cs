using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HLP.GeraXml.bel.NFe.Eventos
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
    [System.Xml.Serialization.XmlRootAttribute("retEnvEvento", Namespace = "http://www.portalfiscal.inf.br/nfe", IsNullable = false)]
    class belRetEventoManifestacao
    {
        private string idLoteField;

        private string tpAmbField;

        private string verAplicField;

        private string cOrgaoField;

        private string cStatField;

        private string xMotivoField;

        private retEnvEventoRetEventoManifestacao retEventoField;

        private decimal versaoField;

        /// <remarks/>
        public string idLote
        {
            get
            {
                return this.idLoteField;
            }
            set
            {
                this.idLoteField = value;
            }
        }

        /// <remarks/>
        public string tpAmb
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
        public string verAplic
        {
            get
            {
                return this.verAplicField;
            }
            set
            {
                this.verAplicField = value;
            }
        }

        /// <remarks/>
        public string cOrgao
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
        public string cStat
        {
            get
            {
                return this.cStatField;
            }
            set
            {
                this.cStatField = value;
            }
        }

        /// <remarks/>
        public string xMotivo
        {
            get
            {
                return this.xMotivoField;
            }
            set
            {
                this.xMotivoField = value;
            }
        }

        /// <remarks/>
        public retEnvEventoRetEventoManifestacao retEvento
        {
            get
            {
                return this.retEventoField;
            }
            set
            {
                this.retEventoField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal versao
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
    public partial class retEnvEventoRetEventoManifestacao
    {

        private retEnvEventoRetEventoInfEventoManifestacao infEventoField;

        private decimal versaoField;

        /// <remarks/>
        public retEnvEventoRetEventoInfEventoManifestacao infEvento
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
        public decimal versao
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
    public partial class retEnvEventoRetEventoInfEventoManifestacao 
    {

        private string tpAmbField;

        private string verAplicField;

        private string cOrgaoField;

        private string cStatField;

        private string xMotivoField;

        private string chNFeField;

        private string tpEventoField;

        private string xEventoField;

        private string nSeqEventoField;

        private string cPFDestField;

        private string CNPJDestField;

        public string CNPJDest
        {
            get { return CNPJDestField; }
            set { CNPJDestField = value; }
        }
        private string emailDest_;

        public string emailDest
        {
            get { return emailDest_; }
            set { emailDest_ = value; }
        }
        

        private System.DateTime dhRegEventoField;

        private string nProtField;

        /// <remarks/>
        public string tpAmb
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
        public string verAplic
        {
            get
            {
                return this.verAplicField;
            }
            set
            {
                this.verAplicField = value;
            }
        }

        /// <remarks/>
        public string cOrgao
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
        public string cStat
        {
            get
            {
                return this.cStatField;
            }
            set
            {
                this.cStatField = value;
            }
        }

        /// <remarks/>
        public string xMotivo
        {
            get
            {
                return this.xMotivoField;
            }
            set
            {
                this.xMotivoField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer")]
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
        public string xEvento
        {
            get
            {
                return this.xEventoField;
            }
            set
            {
                this.xEventoField = value;
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
        public string CPFDest
        {
            get
            {
                return this.cPFDestField;
            }
            set
            {
                this.cPFDestField = value;
            }
        }

        /// <remarks/>
        public System.DateTime dhRegEvento
        {
            get
            {
                return this.dhRegEventoField;
            }
            set
            {
                this.dhRegEventoField = value;
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
    }
}
