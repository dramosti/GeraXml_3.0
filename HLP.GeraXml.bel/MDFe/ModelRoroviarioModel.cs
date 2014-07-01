using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HLP.GeraXml.bel.MDFe
{

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/mdfe")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.portalfiscal.inf.br/mdfe", IsNullable = false)]
    public partial class rodo
    {

        private string rNTRCField;

        private string cIOTField;

        private rodoVeicTracao veicTracaoField;

        private List<rodoVeicReboque> veicReboqueField;

        private List<rodoDisp> valePedField;

        /// <remarks/>
        public string RNTRC
        {
            get
            {
                return this.rNTRCField;
            }
            set
            {
                this.rNTRCField = value;
            }
        }

        /// <remarks/>
        public string CIOT
        {
            get
            {
                return this.cIOTField;
            }
            set
            {
                this.cIOTField = value;
            }
        }

        /// <remarks/>
        public rodoVeicTracao veicTracao
        {
            get
            {
                return this.veicTracaoField;
            }
            set
            {
                this.veicTracaoField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("veicReboque")]
        public List<rodoVeicReboque> veicReboque
        {
            get
            {
                return this.veicReboqueField;
            }
            set
            {
                this.veicReboqueField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("disp", IsNullable = false)]
        public List<rodoDisp> valePed
        {
            get
            {
                return this.valePedField;
            }
            set
            {
                this.valePedField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/mdfe")]
    public partial class rodoVeicTracao
    {

        private string cIntField;

        private string placaField;

        private string taraField;

        private string capKGField;

        private string capM3Field;

        private rodoVeicTracaoProp propField;

        private rodoVeicTracaoCondutor[] condutorField;

        private rodoVeicTracaoTpRod tpRodField;

        private rodoVeicTracaoTpCar tpCarField;

        private TUf ufField;

        /// <remarks/>
        public string cInt
        {
            get
            {
                return this.cIntField;
            }
            set
            {
                this.cIntField = value;
            }
        }

        /// <remarks/>
        public string placa
        {
            get
            {
                return this.placaField;
            }
            set
            {
                this.placaField = value;
            }
        }

        /// <remarks/>
        public string tara
        {
            get
            {
                return this.taraField;
            }
            set
            {
                this.taraField = value;
            }
        }

        /// <remarks/>
        public string capKG
        {
            get
            {
                return this.capKGField;
            }
            set
            {
                this.capKGField = value;
            }
        }

        /// <remarks/>
        public string capM3
        {
            get
            {
                return this.capM3Field;
            }
            set
            {
                this.capM3Field = value;
            }
        }

        /// <remarks/>
        public rodoVeicTracaoProp prop
        {
            get
            {
                return this.propField;
            }
            set
            {
                this.propField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("condutor")]
        public rodoVeicTracaoCondutor[] condutor
        {
            get
            {
                return this.condutorField;
            }
            set
            {
                this.condutorField = value;
            }
        }

        /// <remarks/>
        public rodoVeicTracaoTpRod tpRod
        {
            get
            {
                return this.tpRodField;
            }
            set
            {
                this.tpRodField = value;
            }
        }

        /// <remarks/>
        public rodoVeicTracaoTpCar tpCar
        {
            get
            {
                return this.tpCarField;
            }
            set
            {
                this.tpCarField = value;
            }
        }

        /// <remarks/>
        public TUf UF
        {
            get
            {
                return this.ufField;
            }
            set
            {
                this.ufField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/mdfe")]
    public partial class rodoVeicTracaoProp
    {

        private string itemField;

        private ItemChoiceType itemElementNameField;

        private string rNTRCField;

        private string xNomeField;

        private string ieField;

        private string ufField;

        private rodoVeicTracaoPropTpProp tpPropField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("CNPJ", typeof(string))]
        [System.Xml.Serialization.XmlElementAttribute("CPF", typeof(string))]
        [System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemElementName")]
        public string Item
        {
            get
            {
                return this.itemField;
            }
            set
            {
                this.itemField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public ItemChoiceType ItemElementName
        {
            get
            {
                return this.itemElementNameField;
            }
            set
            {
                this.itemElementNameField = value;
            }
        }

        /// <remarks/>
        public string RNTRC
        {
            get
            {
                return this.rNTRCField;
            }
            set
            {
                this.rNTRCField = value;
            }
        }

        /// <remarks/>
        public string xNome
        {
            get
            {
                return this.xNomeField;
            }
            set
            {
                this.xNomeField = value;
            }
        }

        /// <remarks/>
        public string IE
        {
            get
            {
                return this.ieField;
            }
            set
            {
                this.ieField = value;
            }
        }

        /// <remarks/>
        public string UF
        {
            get
            {
                return this.ufField;
            }
            set
            {
                this.ufField = value;
            }
        }

        /// <remarks/>
        public rodoVeicTracaoPropTpProp tpProp
        {
            get
            {
                return this.tpPropField;
            }
            set
            {
                this.tpPropField = value;
            }
        }
    }




    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/mdfe")]
    public enum rodoVeicTracaoPropTpProp
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("0")]
        Item0,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("1")]
        Item1,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("2")]
        Item2,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/mdfe")]
    public partial class rodoVeicTracaoCondutor
    {

        private string xNomeField;

        private string cPFField;

        /// <remarks/>
        public string xNome
        {
            get
            {
                return this.xNomeField;
            }
            set
            {
                this.xNomeField = value;
            }
        }

        /// <remarks/>
        public string CPF
        {
            get
            {
                return this.cPFField;
            }
            set
            {
                this.cPFField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/mdfe")]
    public enum rodoVeicTracaoTpRod
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("01")]
        Item01,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("02")]
        Item02,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("03")]
        Item03,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("04")]
        Item04,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("05")]
        Item05,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("06")]
        Item06,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/mdfe")]
    public enum rodoVeicTracaoTpCar
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("00")]
        Item00,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("01")]
        Item01,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("02")]
        Item02,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("03")]
        Item03,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("04")]
        Item04,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("05")]
        Item05,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/mdfe")]
    public partial class rodoVeicReboque
    {

        private string cIntField;

        private string placaField;

        private string taraField;

        private string capKGField;

        private string capM3Field;

        private rodoVeicReboqueProp propField;

        private rodoVeicReboqueTpCar tpCarField;

        private string ufField;

        /// <remarks/>
        public string cInt
        {
            get
            {
                return this.cIntField;
            }
            set
            {
                this.cIntField = value;
            }
        }

        /// <remarks/>
        public string placa
        {
            get
            {
                return this.placaField;
            }
            set
            {
                this.placaField = value;
            }
        }

        /// <remarks/>
        public string tara
        {
            get
            {
                return this.taraField;
            }
            set
            {
                this.taraField = value;
            }
        }

        /// <remarks/>
        public string capKG
        {
            get
            {
                return this.capKGField;
            }
            set
            {
                this.capKGField = value;
            }
        }

        /// <remarks/>
        public string capM3
        {
            get
            {
                return this.capM3Field;
            }
            set
            {
                this.capM3Field = value;
            }
        }

        /// <remarks/>
        public rodoVeicReboqueProp prop
        {
            get
            {
                return this.propField;
            }
            set
            {
                this.propField = value;
            }
        }

        /// <remarks/>
        /// 

        public string xTpCar
        {
            get
            {
                switch (this.tpCar)
                {
                    case rodoVeicReboqueTpCar.Item00:
                        return "Não Aplicável";
                    case rodoVeicReboqueTpCar.Item01:
                        return "Aberta";
                    case rodoVeicReboqueTpCar.Item02:
                        return "Fechada/Baú";
                    case rodoVeicReboqueTpCar.Item03:
                        return "Granelera";
                    case rodoVeicReboqueTpCar.Item04:
                        return "Porta-contêiner";
                    case rodoVeicReboqueTpCar.Item05:
                    default:
                        return "Sider";
                }
            }
        }

        public rodoVeicReboqueTpCar tpCar
        {
            get
            {
                return this.tpCarField;
            }
            set
            {
                this.tpCarField = value;
            }
        }

        /// <remarks/>
        public string UF
        {
            get
            {
                return this.ufField;
            }
            set
            {
                this.ufField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/mdfe")]
    public partial class rodoVeicReboqueProp
    {

        private string itemField;

        private ItemChoiceType1 itemElementNameField;

        private string rNTRCField;

        private string xNomeField;

        private string ieField;

        private string ufField;

        private rodoVeicReboquePropTpProp tpPropField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("CNPJ", typeof(string))]
        [System.Xml.Serialization.XmlElementAttribute("CPF", typeof(string))]
        [System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemElementName")]
        public string Item
        {
            get
            {
                return this.itemField;
            }
            set
            {
                this.itemField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public ItemChoiceType1 ItemElementName
        {
            get
            {
                return this.itemElementNameField;
            }
            set
            {
                this.itemElementNameField = value;
            }
        }

        /// <remarks/>
        public string RNTRC
        {
            get
            {
                return this.rNTRCField;
            }
            set
            {
                this.rNTRCField = value;
            }
        }

        /// <remarks/>
        public string xNome
        {
            get
            {
                return this.xNomeField;
            }
            set
            {
                this.xNomeField = value;
            }
        }

        /// <remarks/>
        public string IE
        {
            get
            {
                return this.ieField;
            }
            set
            {
                this.ieField = value;
            }
        }

        /// <remarks/>
        public string UF
        {
            get
            {
                return this.ufField;
            }
            set
            {
                this.ufField = value;
            }
        }

        /// <remarks/>
        public rodoVeicReboquePropTpProp tpProp
        {
            get
            {
                return this.tpPropField;
            }
            set
            {
                this.tpPropField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/mdfe")]
    public enum rodoVeicReboquePropTpProp
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("0")]
        Item0,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("1")]
        Item1,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("2")]
        Item2,
    }


    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/mdfe")]
    public enum rodoVeicReboqueTpCar
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("00")]
        Item00,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("01")]
        Item01,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("02")]
        Item02,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("03")]
        Item03,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("04")]
        Item04,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("05")]
        Item05,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/mdfe")]
    public partial class rodoDisp
    {

        private string cNPJFornField;

        private string cNPJPgField;

        private string nCompraField;

        /// <remarks/>
        public string CNPJForn
        {
            get
            {
                return this.cNPJFornField;
            }
            set
            {
                this.cNPJFornField = value;
            }
        }

        /// <remarks/>
        public string CNPJPg
        {
            get
            {
                return this.cNPJPgField;
            }
            set
            {
                this.cNPJPgField = value;
            }
        }

        /// <remarks/>
        public string nCompra
        {
            get
            {
                return this.nCompraField;
            }
            set
            {
                this.nCompraField = value;
            }
        }
    }
}
