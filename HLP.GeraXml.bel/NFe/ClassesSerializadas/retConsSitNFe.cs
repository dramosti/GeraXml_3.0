using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HLP.GeraXml.bel.NFe.ClassesSerializadas
{
    /// <summary>
    /// Classe responsavel por deserializar o Retorno da consulta de uma NFe
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.portalfiscal.inf.br/nfe", IsNullable = false)]
    public partial class retConsSitNFe
    {

        private string tpAmbField;

        private string verAplicField;

        private string cStatField;

        private string xMotivoField;

        private string cUFField;

        private string chNFeField;

        private retConsSitNFeProtNFe protNFeField;

        private List<retConsSitNFeProcEventoNFe> procEventoNFeField;

        private decimal versaoField;

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
        public string cUF
        {
            get
            {
                return this.cUFField;
            }
            set
            {
                this.cUFField = value;
            }
        }

        /// <remarks/>
        //[System.Xml.Serialization.XmlElementAttribute(DataType = "integer")]
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
        public retConsSitNFeProtNFe protNFe
        {
            get
            {
                return this.protNFeField;
            }
            set
            {
                this.protNFeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("procEventoNFe")]
        public List<retConsSitNFeProcEventoNFe> procEventoNFe
        {
            get
            {
                return this.procEventoNFeField;
            }
            set
            {
                this.procEventoNFeField = value;
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
    public partial class retConsSitNFeProtNFe
    {

        private retConsSitNFeProtNFeInfProt infProtField;

        private decimal versaoField;

        /// <remarks/>
        public retConsSitNFeProtNFeInfProt infProt
        {
            get
            {
                return this.infProtField;
            }
            set
            {
                this.infProtField = value;
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
    public partial class retConsSitNFeProtNFeInfProt
    {

        private string tpAmbField;

        private string verAplicField;

        private string chNFeField;

        private System.DateTime dhRecbtoField;

        private string nProtField;

        private string digValField;

        private string cStatField;

        private string xMotivoField;

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
        public System.DateTime dhRecbto
        {
            get
            {
                return this.dhRecbtoField;
            }
            set
            {
                this.dhRecbtoField = value;
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
        public string digVal
        {
            get
            {
                return this.digValField;
            }
            set
            {
                this.digValField = value;
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
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public partial class retConsSitNFeProcEventoNFe
    {

        private retConsSitNFeProcEventoNFeEvento eventoField;

        private retConsSitNFeProcEventoNFeRetEvento retEventoField;

        private decimal versaoField;

        /// <remarks/>
        public retConsSitNFeProcEventoNFeEvento evento
        {
            get
            {
                return this.eventoField;
            }
            set
            {
                this.eventoField = value;
            }
        }

        /// <remarks/>
        public retConsSitNFeProcEventoNFeRetEvento retEvento
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
    public partial class retConsSitNFeProcEventoNFeEvento
    {

        private retConsSitNFeProcEventoNFeEventoInfEvento infEventoField;

        private decimal versaoField;

        /// <remarks/>
        public retConsSitNFeProcEventoNFeEventoInfEvento infEvento
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
    public partial class retConsSitNFeProcEventoNFeEventoInfEvento
    {

        private string cOrgaoField;

        private string tpAmbField;

        private string cNPJField;

        private string chNFeField;

        private System.DateTime dhEventoField;

        private string tpEventoField;

        private string nSeqEventoField;

        private decimal verEventoField;

        private retConsSitNFeProcEventoNFeEventoInfEventoDetEvento detEventoField;

        private string idField;

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
        public System.DateTime dhEvento
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
        public decimal verEvento
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
        public retConsSitNFeProcEventoNFeEventoInfEventoDetEvento detEvento
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
    public partial class retConsSitNFeProcEventoNFeEventoInfEventoDetEvento
    {

        private string descEventoField;

        private string nProtField;

        private bool nProtFieldSpecified;

        private string xJustField;

        private string xCorrecaoField;

        private string xCondUsoField;

        private decimal versaoField;

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
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool nProtSpecified
        {
            get
            {
                return this.nProtFieldSpecified;
            }
            set
            {
                this.nProtFieldSpecified = value;
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
        public string xCorrecao
        {
            get
            {
                return this.xCorrecaoField;
            }
            set
            {
                this.xCorrecaoField = value;
            }
        }

        /// <remarks/>
        public string xCondUso
        {
            get
            {
                return this.xCondUsoField;
            }
            set
            {
                this.xCondUsoField = value;
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
    public partial class retConsSitNFeProcEventoNFeRetEvento
    {

        private retConsSitNFeProcEventoNFeRetEventoInfEvento infEventoField;

        private decimal versaoField;

        /// <remarks/>
        public retConsSitNFeProcEventoNFeRetEventoInfEvento infEvento
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
    public partial class retConsSitNFeProcEventoNFeRetEventoInfEvento
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
