
using System.Xml.Serialization;

namespace HLP.GeraXml.bel.MDFe
{

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.portalfiscal.inf.br/mdfe")]
    [System.Xml.Serialization.XmlRootAttribute("consSitMDFe", Namespace = "http://www.portalfiscal.inf.br/mdfe", IsNullable = false)]
    public partial class TConsSitMDFe
    {

        private TAmb tpAmbField;

        private string xServField;

        private string chMDFeField;

        private string versaoField;

        public TConsSitMDFe()
        {
            this.xServField = "CONSULTAR";
        }

        /// <remarks/>
        public TAmb tpAmb
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
        public string xServ
        {
            get
            {
                return this.xServField;
            }
            set
            {
                this.xServField = value;
            }
        }

        /// <remarks/>
        public string chMDFe
        {
            get
            {
                return this.chMDFeField;
            }
            set
            {
                this.chMDFeField = value;
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