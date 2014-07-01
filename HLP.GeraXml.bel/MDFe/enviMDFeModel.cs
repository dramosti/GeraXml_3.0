
using HLP.GeraXml.bel;
using System.Collections.Generic;
using System.Xml.Serialization;
using HLP.GeraXml.bel.MDFe.Generic;
namespace HLP.GeraXml.bel.MDFe
{


    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/mdfe")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.portalfiscal.inf.br/mdfe", IsNullable = false)]
    public partial class mdfeProc
    {

        private TEnviMDFe _envimdfeField;
        /// <remarks/>
        public TEnviMDFe enviMDFe
        {
            get
            {
                return this._envimdfeField;
            }
            set
            {
                this._envimdfeField = value;
            }
        }
        private string versaoField;

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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.portalfiscal.inf.br/mdfe")]
    [System.Xml.Serialization.XmlRootAttribute("enviMDFe", Namespace = "http://www.portalfiscal.inf.br/mdfe", IsNullable = false)]
    public partial class TEnviMDFe
    {

        private string idLoteField;

        private TMDFe mDFeField;

        private string versaoField;

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
        public TMDFe MDFe
        {
            get
            {
                return this.mDFeField;
            }
            set
            {
                this.mDFeField = value;
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.portalfiscal.inf.br/mdfe")]
    [System.Xml.Serialization.XmlRootAttribute("MDFe", Namespace = "http://www.portalfiscal.inf.br/mdfe", IsNullable = false)]
    public partial class TMDFe
    {

        private TMDFeInfMDFe infMDFeField;

        private SignatureType signatureField;



        public TMDFeInfMDFe infMDFe
        {
            get
            {
                return this.infMDFeField;
            }
            set
            {
                this.infMDFeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
        public SignatureType Signature
        {
            get
            {
                return this.signatureField;
            }
            set
            {
                this.signatureField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute("infMDFe", AnonymousType = true)]
    public partial class TMDFeInfMDFe
    {

        private TMDFeInfMDFeIde ideField;

        private TMDFeInfMDFeEmit emitField;

        private TMDFeInfMDFeInfModal infModalField;

        private List<TMDFeInfMDFeInfMunDescarga> infDocField;

        private TMDFeInfMDFeTot totField;

        private TMDFeInfMDFeLacres[] lacresField;

        private TMDFeInfMDFeAutXML[] autXMLField;

        private TMDFeInfMDFeInfAdic infAdicField;

        private string versaoField;

        private string idField;

        /// <remarks/>
        public TMDFeInfMDFeIde ide
        {
            get
            {
                return this.ideField;
            }
            set
            {
                this.ideField = value;
            }
        }

        /// <remarks/>
        public TMDFeInfMDFeEmit emit
        {
            get
            {
                return this.emitField;
            }
            set
            {
                this.emitField = value;
            }
        }

        /// <remarks/>
        public TMDFeInfMDFeInfModal infModal
        {
            get
            {
                return this.infModalField;
            }
            set
            {
                this.infModalField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("infMunDescarga", IsNullable = false)]
        public List<TMDFeInfMDFeInfMunDescarga> infDoc
        {
            get
            {
                return this.infDocField;
            }
            set
            {
                this.infDocField = value;
            }
        }

        /// <remarks/>
        public TMDFeInfMDFeTot tot
        {
            get
            {
                return this.totField;
            }
            set
            {
                this.totField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("lacres")]
        public TMDFeInfMDFeLacres[] lacres
        {
            get
            {
                return this.lacresField;
            }
            set
            {
                this.lacresField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("autXML")]
        public TMDFeInfMDFeAutXML[] autXML
        {
            get
            {
                return this.autXMLField;
            }
            set
            {
                this.autXMLField = value;
            }
        }

        /// <remarks/>
        public TMDFeInfMDFeInfAdic infAdic
        {
            get
            {
                return this.infAdicField;
            }
            set
            {
                this.infAdicField = value;
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

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "ID")]
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/mdfe")]
    public partial class TMDFeInfMDFeIde
    {

        private string cUFField;

        private TAmb tpAmbField;

        private TEmit tpEmitField;

        private TModMD modField;

        private string serieField;

        private string nMDFField;

        private string cMDFField;

        private string cDVField;

        private TModalMD modalField;

        private string dhEmiField;

        private TMDFeInfMDFeIdeTpEmis tpEmisField;

        private TMDFeInfMDFeIdeProcEmi procEmiField;

        private string verProcField;

        private string uFIniField;

        private string uFFimField;

        private List<TMDFeInfMDFeIdeInfMunCarrega> infMunCarregaField;

        private List<TMDFeInfMDFeIdeInfPercurso> infPercursoField;

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
        public TEmit tpEmit
        {
            get
            {
                return this.tpEmitField;
            }
            set
            {
                this.tpEmitField = value;
            }
        }

        /// <remarks/>
        public TModMD mod
        {
            get
            {
                return this.modField;
            }
            set
            {
                this.modField = value;
            }
        }

        /// <remarks/>
        public string serie
        {
            get
            {
                return this.serieField;
            }
            set
            {
                this.serieField = value;
            }
        }

        /// <remarks/>
        public string nMDF
        {
            get
            {
                return this.nMDFField;
            }
            set
            {
                this.nMDFField = value;
            }
        }

        /// <remarks/>
        public string cMDF
        {
            get
            {
                return this.cMDFField;
            }
            set
            {
                this.cMDFField = value;
            }
        }

        /// <remarks/>
        public string cDV
        {
            get
            {
                return this.cDVField;
            }
            set
            {
                this.cDVField = value;
            }
        }

        /// <remarks/>
        public TModalMD modal
        {
            get
            {
                return this.modalField;
            }
            set
            {
                this.modalField = value;
            }
        }

        /// <remarks/>
        public string dhEmi
        {
            get
            {
                return this.dhEmiField;
            }
            set
            {
                this.dhEmiField = value;
            }
        }

        /// <remarks/>
        public TMDFeInfMDFeIdeTpEmis tpEmis
        {
            get
            {
                return this.tpEmisField;
            }
            set
            {
                this.tpEmisField = value;
            }
        }

        /// <remarks/>
        public TMDFeInfMDFeIdeProcEmi procEmi
        {
            get
            {
                return this.procEmiField;
            }
            set
            {
                this.procEmiField = value;
            }
        }

        /// <remarks/>
        public string verProc
        {
            get
            {
                return this.verProcField;
            }
            set
            {
                this.verProcField = value;
            }
        }

        /// <remarks/>
        public string UFIni
        {
            get
            {
                return this.uFIniField;
            }
            set
            {
                this.uFIniField = value;
            }
        }

        /// <remarks/>
        public string UFFim
        {
            get
            {
                return this.uFFimField;
            }
            set
            {
                this.uFFimField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("infMunCarrega")]
        public List<TMDFeInfMDFeIdeInfMunCarrega> infMunCarrega
        {
            get
            {
                return this.infMunCarregaField;
            }
            set
            {
                this.infMunCarregaField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("infPercurso")]
        public List<TMDFeInfMDFeIdeInfPercurso> infPercurso
        {
            get
            {
                return this.infPercursoField;
            }
            set
            {
                this.infPercursoField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.portalfiscal.inf.br/mdfe")]
    public enum TCodUfIBGE
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("11")]
        Item11,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("12")]
        Item12,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("13")]
        Item13,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("14")]
        Item14,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("15")]
        Item15,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("16")]
        Item16,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("17")]
        Item17,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("21")]
        Item21,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("22")]
        Item22,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("23")]
        Item23,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("24")]
        Item24,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("25")]
        Item25,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("26")]
        Item26,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("27")]
        Item27,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("28")]
        Item28,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("29")]
        Item29,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("31")]
        Item31,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("32")]
        Item32,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("33")]
        Item33,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("35")]
        Item35,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("41")]
        Item41,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("42")]
        Item42,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("43")]
        Item43,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("50")]
        Item50,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("51")]
        Item51,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("52")]
        Item52,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("53")]
        Item53,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.portalfiscal.inf.br/mdfe")]
    public enum TAmb
    {

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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.portalfiscal.inf.br/mdfe")]
    public enum TEmit
    {

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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.portalfiscal.inf.br/mdfe")]
    public enum TModMD
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("58")]
        Item58,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.portalfiscal.inf.br/mdfe")]
    public enum TModalMD
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("1")]
        Item1,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("2")]
        Item2,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("3")]
        Item3,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("4")]
        Item4,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/mdfe")]
    public enum TMDFeInfMDFeIdeTpEmis
    {

        //        Prestador de Serviço de Transporte
        //Não prestador de Serviço de Transporte

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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.portalfiscal.inf.br/mdfe")]
    public enum TMDFeInfMDFeIdeProcEmi
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("0")]
        Item0,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("3")]
        Item3,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.portalfiscal.inf.br/mdfe")]
    public enum TUf
    {

        /// <remarks/>
        AC,

        /// <remarks/>
        AL,

        /// <remarks/>
        AM,

        /// <remarks/>
        AP,

        /// <remarks/>
        BA,

        /// <remarks/>
        CE,

        /// <remarks/>
        DF,

        /// <remarks/>
        ES,

        /// <remarks/>
        GO,

        /// <remarks/>
        MA,

        /// <remarks/>
        MG,

        /// <remarks/>
        MS,

        /// <remarks/>
        MT,

        /// <remarks/>
        PA,

        /// <remarks/>
        PB,

        /// <remarks/>
        PE,

        /// <remarks/>
        PI,

        /// <remarks/>
        PR,

        /// <remarks/>
        RJ,

        /// <remarks/>
        RN,

        /// <remarks/>
        RO,

        /// <remarks/>
        RR,

        /// <remarks/>
        RS,

        /// <remarks/>
        SC,

        /// <remarks/>
        SE,

        /// <remarks/>
        SP,

        /// <remarks/>
        TO,

        /// <remarks/>
        EX,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/mdfe")]
    public partial class TMDFeInfMDFeIdeInfMunCarrega
    {

        private string cMunCarregaField;

        private string xMunCarregaField;

        /// <remarks/>
        public string cMunCarrega
        {
            get
            {
                return this.cMunCarregaField;
            }
            set
            {
                this.cMunCarregaField = value;
            }
        }

        /// <remarks/>
        public string xMunCarrega
        {
            get
            {
                return this.xMunCarregaField;
            }
            set
            {
                this.xMunCarregaField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.portalfiscal.inf.br/mdfe")]
    public partial class TUnidCarga
    {

        private TtipoUnidCarga tpUnidCargaField;

        private string idUnidCargaField;

        private TUnidCargaLacUnidCarga[] lacUnidCargaField;

        private string qtdRatField;

        /// <remarks/>
        public TtipoUnidCarga tpUnidCarga
        {
            get
            {
                return this.tpUnidCargaField;
            }
            set
            {
                this.tpUnidCargaField = value;
            }
        }

        /// <remarks/>
        public string idUnidCarga
        {
            get
            {
                return this.idUnidCargaField;
            }
            set
            {
                this.idUnidCargaField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("lacUnidCarga")]
        public TUnidCargaLacUnidCarga[] lacUnidCarga
        {
            get
            {
                return this.lacUnidCargaField;
            }
            set
            {
                this.lacUnidCargaField = value;
            }
        }

        /// <remarks/>
        public string qtdRat
        {
            get
            {
                return this.qtdRatField;
            }
            set
            {
                this.qtdRatField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.portalfiscal.inf.br/mdfe")]
    public enum TtipoUnidCarga
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("1")]
        Item1,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("2")]
        Item2,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("3")]
        Item3,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("4")]
        Item4,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/mdfe")]
    public partial class TUnidCargaLacUnidCarga
    {

        private string nLacreField;

        /// <remarks/>
        public string nLacre
        {
            get
            {
                return this.nLacreField;
            }
            set
            {
                this.nLacreField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.portalfiscal.inf.br/mdfe")]
    public partial class TUnidadeTransp
    {

        private TtipoUnidTransp tpUnidTranspField;

        private string idUnidTranspField;

        private TUnidadeTranspLacUnidTransp[] lacUnidTranspField;

        private TUnidCarga[] infUnidCargaField;

        private string qtdRatField;

        /// <remarks/>
        public TtipoUnidTransp tpUnidTransp
        {
            get
            {
                return this.tpUnidTranspField;
            }
            set
            {
                this.tpUnidTranspField = value;
            }
        }

        /// <remarks/>
        public string idUnidTransp
        {
            get
            {
                return this.idUnidTranspField;
            }
            set
            {
                this.idUnidTranspField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("lacUnidTransp")]
        public TUnidadeTranspLacUnidTransp[] lacUnidTransp
        {
            get
            {
                return this.lacUnidTranspField;
            }
            set
            {
                this.lacUnidTranspField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("infUnidCarga")]
        public TUnidCarga[] infUnidCarga
        {
            get
            {
                return this.infUnidCargaField;
            }
            set
            {
                this.infUnidCargaField = value;
            }
        }

        /// <remarks/>
        public string qtdRat
        {
            get
            {
                return this.qtdRatField;
            }
            set
            {
                this.qtdRatField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.portalfiscal.inf.br/mdfe")]
    public enum TtipoUnidTransp
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("1")]
        Item1,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("2")]
        Item2,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("3")]
        Item3,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("4")]
        Item4,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("5")]
        Item5,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("6")]
        Item6,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("7")]
        Item7,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/mdfe")]
    public partial class TUnidadeTranspLacUnidTransp
    {

        private string nLacreField;

        /// <remarks/>
        public string nLacre
        {
            get
            {
                return this.nLacreField;
            }
            set
            {
                this.nLacreField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.portalfiscal.inf.br/mdfe")]
    public partial class TNFeNF
    {

        private object itemField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("infNF", typeof(TNFeNFInfNF))]
        [System.Xml.Serialization.XmlElementAttribute("infNFe", typeof(TNFeNFInfNFe))]
        public object Item
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
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/mdfe")]
    public partial class TNFeNFInfNF
    {

        private TNFeNFInfNFEmi emiField;

        private TNFeNFInfNFDest destField;

        private string serieField;

        private string nNFField;

        private string dEmiField;

        private string vNFField;

        private string pINField;

        /// <remarks/>
        public TNFeNFInfNFEmi emi
        {
            get
            {
                return this.emiField;
            }
            set
            {
                this.emiField = value;
            }
        }

        /// <remarks/>
        public TNFeNFInfNFDest dest
        {
            get
            {
                return this.destField;
            }
            set
            {
                this.destField = value;
            }
        }

        /// <remarks/>
        public string serie
        {
            get
            {
                return this.serieField;
            }
            set
            {
                this.serieField = value;
            }
        }

        /// <remarks/>
        public string nNF
        {
            get
            {
                return this.nNFField;
            }
            set
            {
                this.nNFField = value;
            }
        }

        /// <remarks/>
        public string dEmi
        {
            get
            {
                return this.dEmiField;
            }
            set
            {
                this.dEmiField = value;
            }
        }

        /// <remarks/>
        public string vNF
        {
            get
            {
                return this.vNFField;
            }
            set
            {
                this.vNFField = value;
            }
        }

        /// <remarks/>
        public string PIN
        {
            get
            {
                return this.pINField;
            }
            set
            {
                this.pINField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/mdfe")]
    public partial class TNFeNFInfNFEmi
    {

        private string cNPJField;

        private string xNomeField;

        private TUf ufField;

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
    public partial class TNFeNFInfNFDest
    {

        private string itemField;

        private ItemChoiceType1 itemElementNameField;

        private string xNomeField;

        private TUf ufField;

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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.portalfiscal.inf.br/mdfe", IncludeInSchema = false)]
    public enum ItemChoiceType1
    {

        /// <remarks/>
        CNPJ,

        /// <remarks/>
        CPF,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/mdfe")]
    public partial class TNFeNFInfNFe
    {

        private string chNFeField;

        private string pINField;

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
        public string PIN
        {
            get
            {
                return this.pINField;
            }
            set
            {
                this.pINField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.portalfiscal.inf.br/mdfe")]
    public partial class TEndReEnt
    {

        private string itemField;

        private ItemChoiceType itemElementNameField;

        private string xNomeField;

        private string xLgrField;

        private string nroField;

        private string xCplField;

        private string xBairroField;

        private string cMunField;

        private string xMunField;

        private TUf ufField;

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
        public string xLgr
        {
            get
            {
                return this.xLgrField;
            }
            set
            {
                this.xLgrField = value;
            }
        }

        /// <remarks/>
        public string nro
        {
            get
            {
                return this.nroField;
            }
            set
            {
                this.nroField = value;
            }
        }

        /// <remarks/>
        public string xCpl
        {
            get
            {
                return this.xCplField;
            }
            set
            {
                this.xCplField = value;
            }
        }

        /// <remarks/>
        public string xBairro
        {
            get
            {
                return this.xBairroField;
            }
            set
            {
                this.xBairroField = value;
            }
        }

        /// <remarks/>
        public string cMun
        {
            get
            {
                return this.cMunField;
            }
            set
            {
                this.cMunField = value;
            }
        }

        /// <remarks/>
        public string xMun
        {
            get
            {
                return this.xMunField;
            }
            set
            {
                this.xMunField = value;
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.portalfiscal.inf.br/mdfe", IncludeInSchema = false)]
    public enum ItemChoiceType
    {

        /// <remarks/>
        CNPJ,

        /// <remarks/>
        CPF,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.portalfiscal.inf.br/mdfe")]
    public partial class TLocal
    {

        private string cMunField;

        private string xMunField;

        private TUf ufField;

        /// <remarks/>
        public string cMun
        {
            get
            {
                return this.cMunField;
            }
            set
            {
                this.cMunField = value;
            }
        }

        /// <remarks/>
        public string xMun
        {
            get
            {
                return this.xMunField;
            }
            set
            {
                this.xMunField = value;
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.portalfiscal.inf.br/mdfe")]
    public partial class TEndOrg
    {

        private string xLgrField;

        private string nroField;

        private string xCplField;

        private string xBairroField;

        private string cMunField;

        private string xMunField;

        private string cEPField;

        private TUf ufField;

        private string cPaisField;

        private string xPaisField;

        private string foneField;

        /// <remarks/>
        public string xLgr
        {
            get
            {
                return this.xLgrField;
            }
            set
            {
                this.xLgrField = value;
            }
        }

        /// <remarks/>
        public string nro
        {
            get
            {
                return this.nroField;
            }
            set
            {
                this.nroField = value;
            }
        }

        /// <remarks/>
        public string xCpl
        {
            get
            {
                return this.xCplField;
            }
            set
            {
                this.xCplField = value;
            }
        }

        /// <remarks/>
        public string xBairro
        {
            get
            {
                return this.xBairroField;
            }
            set
            {
                this.xBairroField = value;
            }
        }

        /// <remarks/>
        public string cMun
        {
            get
            {
                return this.cMunField;
            }
            set
            {
                this.cMunField = value;
            }
        }

        /// <remarks/>
        public string xMun
        {
            get
            {
                return this.xMunField;
            }
            set
            {
                this.xMunField = value;
            }
        }

        /// <remarks/>
        public string CEP
        {
            get
            {
                return this.cEPField;
            }
            set
            {
                this.cEPField = value;
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

        /// <remarks/>
        public string cPais
        {
            get
            {
                return this.cPaisField;
            }
            set
            {
                this.cPaisField = value;
            }
        }

        /// <remarks/>
        public string xPais
        {
            get
            {
                return this.xPaisField;
            }
            set
            {
                this.xPaisField = value;
            }
        }

        /// <remarks/>
        public string fone
        {
            get
            {
                return this.foneField;
            }
            set
            {
                this.foneField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.portalfiscal.inf.br/mdfe")]
    public partial class TEnderFer
    {

        private string xLgrField;

        private string nroField;

        private string xCplField;

        private string xBairroField;

        private string cMunField;

        private string xMunField;

        private string cEPField;

        private TUf ufField;

        /// <remarks/>
        public string xLgr
        {
            get
            {
                return this.xLgrField;
            }
            set
            {
                this.xLgrField = value;
            }
        }

        /// <remarks/>
        public string nro
        {
            get
            {
                return this.nroField;
            }
            set
            {
                this.nroField = value;
            }
        }

        /// <remarks/>
        public string xCpl
        {
            get
            {
                return this.xCplField;
            }
            set
            {
                this.xCplField = value;
            }
        }

        /// <remarks/>
        public string xBairro
        {
            get
            {
                return this.xBairroField;
            }
            set
            {
                this.xBairroField = value;
            }
        }

        /// <remarks/>
        public string cMun
        {
            get
            {
                return this.cMunField;
            }
            set
            {
                this.cMunField = value;
            }
        }

        /// <remarks/>
        public string xMun
        {
            get
            {
                return this.xMunField;
            }
            set
            {
                this.xMunField = value;
            }
        }

        /// <remarks/>
        public string CEP
        {
            get
            {
                return this.cEPField;
            }
            set
            {
                this.cEPField = value;
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.portalfiscal.inf.br/mdfe")]
    public partial class TEndernac
    {

        private string xLgrField;

        private string nroField;

        private string xCplField;

        private string xBairroField;

        private string cMunField;

        private string xMunField;

        private string cEPField;

        private TUf ufField;

        /// <remarks/>
        public string xLgr
        {
            get
            {
                return this.xLgrField;
            }
            set
            {
                this.xLgrField = value;
            }
        }

        /// <remarks/>
        public string nro
        {
            get
            {
                return this.nroField;
            }
            set
            {
                this.nroField = value;
            }
        }

        /// <remarks/>
        public string xCpl
        {
            get
            {
                return this.xCplField;
            }
            set
            {
                this.xCplField = value;
            }
        }

        /// <remarks/>
        public string xBairro
        {
            get
            {
                return this.xBairroField;
            }
            set
            {
                this.xBairroField = value;
            }
        }

        /// <remarks/>
        public string cMun
        {
            get
            {
                return this.cMunField;
            }
            set
            {
                this.cMunField = value;
            }
        }

        /// <remarks/>
        public string xMun
        {
            get
            {
                return this.xMunField;
            }
            set
            {
                this.xMunField = value;
            }
        }

        /// <remarks/>
        public string CEP
        {
            get
            {
                return this.cEPField;
            }
            set
            {
                this.cEPField = value;
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.portalfiscal.inf.br/mdfe")]
    public partial class TEndereco
    {

        private string xLgrField;

        private string nroField;

        private string xCplField;

        private string xBairroField;

        private string cMunField;

        private string xMunField;

        private string cEPField;

        private TUf ufField;

        private string cPaisField;

        private string xPaisField;

        /// <remarks/>
        public string xLgr
        {
            get
            {
                return this.xLgrField;
            }
            set
            {
                this.xLgrField = value;
            }
        }

        /// <remarks/>
        public string nro
        {
            get
            {
                return this.nroField;
            }
            set
            {
                this.nroField = value;
            }
        }

        /// <remarks/>
        public string xCpl
        {
            get
            {
                return this.xCplField;
            }
            set
            {
                this.xCplField = value;
            }
        }

        /// <remarks/>
        public string xBairro
        {
            get
            {
                return this.xBairroField;
            }
            set
            {
                this.xBairroField = value;
            }
        }

        /// <remarks/>
        public string cMun
        {
            get
            {
                return this.cMunField;
            }
            set
            {
                this.cMunField = value;
            }
        }

        /// <remarks/>
        public string xMun
        {
            get
            {
                return this.xMunField;
            }
            set
            {
                this.xMunField = value;
            }
        }

        /// <remarks/>
        public string CEP
        {
            get
            {
                return this.cEPField;
            }
            set
            {
                this.cEPField = value;
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

        /// <remarks/>
        public string cPais
        {
            get
            {
                return this.cPaisField;
            }
            set
            {
                this.cPaisField = value;
            }
        }

        /// <remarks/>
        public string xPais
        {
            get
            {
                return this.xPaisField;
            }
            set
            {
                this.xPaisField = value;
            }
        }
    }

    //<retEnviMDFe xmlns='http://www.portalfiscal.inf.br/mdfe'> não era esperado.
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public class retEnviMDFe
    {
        private object tpAmbField;
        private string cUFField;
        private string verAplicField;
        private string cStatField;
        private string xMotivoField;
        private TRetEnviMDFeInfRec infRecField;
        private string versaoField;
        /// <remarks/>
        public object tpAmb
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
        public TRetEnviMDFeInfRec infRec
        {
            get
            {
                return this.infRecField;
            }
            set
            {
                this.infRecField = value;
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class TRetEnviMDFeInfRec
    {

        private string nRecField;

        private System.DateTime dhRecbtoField;

        private string tMedField;

        /// <remarks/>
        public string nRec
        {
            get
            {
                return this.nRecField;
            }
            set
            {
                this.nRecField = value;
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
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer")]
        public string tMed
        {
            get
            {
                return this.tMedField;
            }
            set
            {
                this.tMedField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.portalfiscal.inf.br/mdfe")]
    public partial class TEndeEmi
    {

        private string xLgrField;

        private string nroField;

        private string xCplField;

        private string xBairroField;

        private string cMunField;

        private string xMunField;

        private string cEPField;

        private string ufField;

        private string foneField;

        private string emailField;

        /// <remarks/>
        public string xLgr
        {
            get
            {
                return this.xLgrField;
            }
            set
            {
                this.xLgrField = value;
            }
        }

        /// <remarks/>
        public string nro
        {
            get
            {
                return this.nroField;
            }
            set
            {
                this.nroField = value;
            }
        }

        /// <remarks/>
        public string xCpl
        {
            get
            {
                return this.xCplField;
            }
            set
            {
                this.xCplField = value;
            }
        }

        /// <remarks/>
        public string xBairro
        {
            get
            {
                return this.xBairroField;
            }
            set
            {
                this.xBairroField = value;
            }
        }

        /// <remarks/>
        public string cMun
        {
            get
            {
                return this.cMunField;
            }
            set
            {
                this.cMunField = value;
            }
        }

        /// <remarks/>
        public string xMun
        {
            get
            {
                return this.xMunField;
            }
            set
            {
                this.xMunField = value;
            }
        }

        /// <remarks/>
        public string CEP
        {
            get
            {
                return this.cEPField;
            }
            set
            {
                this.cEPField = value;
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
        public string fone
        {
            get
            {
                return this.foneField;
            }
            set
            {
                this.foneField = value;
            }
        }

        /// <remarks/>
        public string email
        {
            get
            {
                return this.emailField;
            }
            set
            {
                this.emailField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/mdfe")]
    public partial class TMDFeInfMDFeIdeInfPercurso
    {

        private string uFPerField;

        /// <remarks/>
        public string UFPer
        {
            get
            {
                return this.uFPerField;
            }
            set
            {
                this.uFPerField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/mdfe")]
    public partial class TMDFeInfMDFeEmit
    {

        private string cNPJField;

        private string ieField;

        private string xNomeField;

        private string xFantField;

        private TEndeEmi enderEmitField;

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
        public string xFant
        {
            get
            {
                return this.xFantField;
            }
            set
            {
                this.xFantField = value;
            }
        }

        /// <remarks/>
        public TEndeEmi enderEmit
        {
            get
            {
                return this.enderEmitField;
            }
            set
            {
                this.enderEmitField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/mdfe")]
    public partial class TMDFeInfMDFeInfModal
    {

        private System.Xml.XmlElement anyField;

        private string versaoModalField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAnyElementAttribute()]
        public System.Xml.XmlElement Any
        {
            get
            {
                return this.anyField;
            }
            set
            {
                this.anyField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string versaoModal
        {
            get
            {
                return this.versaoModalField;
            }
            set
            {
                this.versaoModalField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/mdfe")]
    public partial class TMDFeInfMDFeInfMunDescarga
    {

        private string cMunDescargaField;

        private string xMunDescargaField;

        private TMDFeInfMDFeInfMunDescargaInfCTe[] infCTeField;

        private TMDFeInfMDFeInfMunDescargaInfCT[] infCTField;

        private TMDFeInfMDFeInfMunDescargaInfNFe[] infNFeField;

        private TMDFeInfMDFeInfMunDescargaInfNF[] infNFField;

        private TMDFeInfMDFeInfMunDescargaInfMDFeTransp[] infMDFeTranspField;

        /// <remarks/>
        public string cMunDescarga
        {
            get
            {
                return this.cMunDescargaField;
            }
            set
            {
                this.cMunDescargaField = value;
            }
        }

        /// <remarks/>
        public string xMunDescarga
        {
            get
            {
                return this.xMunDescargaField;
            }
            set
            {
                this.xMunDescargaField = value;
            }
        }

        /// <summary>
        /// numero do conhecimento, nao serializado.
        /// </summary>
        /// 
        [System.Xml.Serialization.XmlIgnore]
        public string nr_lanc { get; set; }
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("infCTe")]
        public TMDFeInfMDFeInfMunDescargaInfCTe[] infCTe
        {
            get
            {
                return this.infCTeField;
            }
            set
            {
                this.infCTeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("infCT")]
        public TMDFeInfMDFeInfMunDescargaInfCT[] infCT
        {
            get
            {
                return this.infCTField;
            }
            set
            {
                this.infCTField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("infNFe")]
        public TMDFeInfMDFeInfMunDescargaInfNFe[] infNFe
        {
            get
            {
                return this.infNFeField;
            }
            set
            {
                this.infNFeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("infNF")]
        public TMDFeInfMDFeInfMunDescargaInfNF[] infNF
        {
            get
            {
                return this.infNFField;
            }
            set
            {
                this.infNFField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("infMDFeTransp")]
        public TMDFeInfMDFeInfMunDescargaInfMDFeTransp[] infMDFeTransp
        {
            get
            {
                return this.infMDFeTranspField;
            }
            set
            {
                this.infMDFeTranspField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/mdfe")]
    public partial class TMDFeInfMDFeInfMunDescargaInfCTe
    {

        private string chCTeField;

        private object segCodBarraField;

        private TUnidadeTransp[] infUnidTranspField;

        /// <remarks/>
        public string chCTe
        {
            get
            {
                return this.chCTeField;
            }
            set
            {
                this.chCTeField = value;
            }
        }

        /// <remarks/>
        public object SegCodBarra
        {
            get
            {
                return this.segCodBarraField;
            }
            set
            {
                this.segCodBarraField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("infUnidTransp")]
        public TUnidadeTransp[] infUnidTransp
        {
            get
            {
                return this.infUnidTranspField;
            }
            set
            {
                this.infUnidTranspField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/mdfe")]
    public partial class TMDFeInfMDFeInfMunDescargaInfCT
    {

        private string nCTField;

        private string serieField;

        private string subserField;

        private string dEmiField;

        private string vCargaField;

        private TUnidadeTransp[] infUnidTranspField;

        /// <remarks/>
        public string nCT
        {
            get
            {
                return this.nCTField;
            }
            set
            {
                this.nCTField = value;
            }
        }

        /// <remarks/>
        public string serie
        {
            get
            {
                return this.serieField;
            }
            set
            {
                this.serieField = value;
            }
        }

        /// <remarks/>
        public string subser
        {
            get
            {
                return this.subserField;
            }
            set
            {
                this.subserField = value;
            }
        }

        /// <remarks/>
        public string dEmi
        {
            get
            {
                return this.dEmiField;
            }
            set
            {
                this.dEmiField = value;
            }
        }

        /// <remarks/>
        public string vCarga
        {
            get
            {
                return this.vCargaField;
            }
            set
            {
                this.vCargaField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("infUnidTransp")]
        public TUnidadeTransp[] infUnidTransp
        {
            get
            {
                return this.infUnidTranspField;
            }
            set
            {
                this.infUnidTranspField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/mdfe")]
    public partial class TMDFeInfMDFeInfMunDescargaInfNFe
    {

        private string chNFeField;

        private object segCodBarraField;

        private TUnidadeTransp[] infUnidTranspField;

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
        public object SegCodBarra
        {
            get
            {
                return this.segCodBarraField;
            }
            set
            {
                this.segCodBarraField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("infUnidTransp")]
        public TUnidadeTransp[] infUnidTransp
        {
            get
            {
                return this.infUnidTranspField;
            }
            set
            {
                this.infUnidTranspField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/mdfe")]
    public partial class TMDFeInfMDFeInfMunDescargaInfNF
    {

        private string cNPJField;

        private string ufField;

        private string nNFField;

        private string serieField;

        private string dEmiField;

        private string vNFField;

        private string pINField;

        private TUnidadeTransp[] infUnidTranspField;

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
        public string nNF
        {
            get
            {
                return this.nNFField;
            }
            set
            {
                this.nNFField = value;
            }
        }

        /// <remarks/>
        public string serie
        {
            get
            {
                return this.serieField;
            }
            set
            {
                this.serieField = value;
            }
        }

        /// <remarks/>
        public string dEmi
        {
            get
            {
                return this.dEmiField;
            }
            set
            {
                this.dEmiField = value;
            }
        }

        /// <remarks/>
        public string vNF
        {
            get
            {
                return this.vNFField;
            }
            set
            {
                this.vNFField = value;
            }
        }

        /// <remarks/>
        public string PIN
        {
            get
            {
                return this.pINField;
            }
            set
            {
                this.pINField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("infUnidTransp")]
        public TUnidadeTransp[] infUnidTransp
        {
            get
            {
                return this.infUnidTranspField;
            }
            set
            {
                this.infUnidTranspField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/mdfe")]
    public partial class TMDFeInfMDFeInfMunDescargaInfMDFeTransp
    {

        private string chMDFeField;

        private TUnidadeTransp[] infUnidTranspField;

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
        [System.Xml.Serialization.XmlElementAttribute("infUnidTransp")]
        public TUnidadeTransp[] infUnidTransp
        {
            get
            {
                return this.infUnidTranspField;
            }
            set
            {
                this.infUnidTranspField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/mdfe")]
    public partial class TMDFeInfMDFeTot
    {

        private string qCTeField;

        private string qCTField;

        private string qNFeField;

        private string qNFField;

        private string qMDFeField;

        private string vCargaField;

        private TMDFeInfMDFeTotCUnid cUnidField;

        private string qCargaField;

        /// <remarks/>
        public string qCTe
        {
            get
            {
                return this.qCTeField;
            }
            set
            {
                this.qCTeField = value == "0" ? null : value;
            }
        }

        /// <remarks/>
        public string qCT
        {
            get
            {
                return this.qCTField;
            }
            set
            {
                this.qCTField = value == "0" ? null : value;
            }
        }

        /// <remarks/>
        public string qNFe
        {
            get
            {
                return this.qNFeField;
            }
            set
            {
                this.qNFeField = value == "0" ? null : value;
            }
        }

        /// <remarks/>
        public string qNF
        {
            get
            {
                return this.qNFField;
            }
            set
            {
                this.qNFField = value == "0" ? null : value;
            }
        }

        /// <remarks/>
        public string qMDFe
        {
            get
            {
                return this.qMDFeField;
            }
            set
            {
                this.qMDFeField = value;
            }
        }

        /// <remarks/>
        public string vCarga
        {
            get
            {
                return this.vCargaField;
            }
            set
            {
                this.vCargaField = value;
            }
        }

        /// <remarks/>
        public TMDFeInfMDFeTotCUnid cUnid
        {
            get
            {
                return this.cUnidField;
            }
            set
            {
                this.cUnidField = value;
            }
        }

        /// <remarks/>
        public string qCarga
        {
            get
            {
                return this.qCargaField;
            }
            set
            {
                this.qCargaField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/mdfe")]
    public enum TMDFeInfMDFeTotCUnid
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("01")]
        Item01,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("02")]
        Item02,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/mdfe")]
    public partial class TMDFeInfMDFeLacres
    {

        private string nLacreField;

        /// <remarks/>
        public string nLacre
        {
            get
            {
                return this.nLacreField;
            }
            set
            {
                this.nLacreField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/mdfe")]
    public partial class TMDFeInfMDFeAutXML
    {

        private string itemField;

        private ItemChoiceType2 itemElementNameField;

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
        public ItemChoiceType2 ItemElementName
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
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.portalfiscal.inf.br/mdfe", IncludeInSchema = false)]
    public enum ItemChoiceType2
    {

        /// <remarks/>
        CNPJ,

        /// <remarks/>
        CPF,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/mdfe")]
    public partial class TMDFeInfMDFeInfAdic
    {

        private string infAdFiscoField;

        private string infCplField;

        /// <remarks/>
        public string infAdFisco
        {
            get
            {
                return this.infAdFiscoField;
            }
            set
            {
                this.infAdFiscoField = value;
            }
        }

        /// <remarks/>
        public string infCpl
        {
            get
            {
                return this.infCplField;
            }
            set
            {
                this.infCplField = value;
            }
        }
    }
}