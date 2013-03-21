using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace HLP.GeraXml.bel.NFes.DSF
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://localhost:8080/WsNFe2/lote", IsNullable = false)]
    public class RetornoConsultaLote
    {
        /// <remarks/>
        [XmlElement("Cabecalho")]
        public CabecalhoRetLote cabecalho { get; set; }

        /// <remarks/>
        [XmlElement("Alertas")]
        public Alertas alertas { get; set; }
        /// <remarks/>
        [XmlElement("Erros")]
        public ErrosRetLote erros { get; set; }
        /// <remarks/>
        [XmlElement("ListaNFSe")]
        public ListaNFSe lista { get; set; }

    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public class Alertas
    {
        /// <remarks/>
        [XmlElement("Alerta")]
        public List<Alerta> alerta { get; set; }
    }
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public class Alerta
    {
        public string Codigo { get; set; }
        public string Descricao { get; set; }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public class CabecalhoRetLote
    {

        private string codCidadeField;

        private bool sucessoField;

        private string numeroLoteField;

        private ulong cPFCNPJRemetenteField;

        private string razaoSocialRemetenteField;

        private System.DateTime dataEnvioLoteField;

        private string qtdNotasProcessadasField;

        private string tempoProcessamentoField;

        private string valorTotalServicosField;

        private string valorTotalDeducoesField;

        private string versaoField;

        /// <remarks/>
        public string CodCidade
        {
            get
            {
                return this.codCidadeField;
            }
            set
            {
                this.codCidadeField = value;
            }
        }

        /// <remarks/>
        public bool Sucesso
        {
            get
            {
                return this.sucessoField;
            }
            set
            {
                this.sucessoField = value;
            }
        }

        /// <remarks/>
        public string NumeroLote
        {
            get
            {
                return this.numeroLoteField;
            }
            set
            {
                this.numeroLoteField = value;
            }
        }

        /// <remarks/>
        public ulong CPFCNPJRemetente
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
        public string RazaoSocialRemetente
        {
            get
            {
                return this.razaoSocialRemetenteField;
            }
            set
            {
                this.razaoSocialRemetenteField = value;
            }
        }

        /// <remarks/>
        public System.DateTime DataEnvioLote
        {
            get
            {
                return this.dataEnvioLoteField;
            }
            set
            {
                this.dataEnvioLoteField = value;
            }
        }

        /// <remarks/>
        public string QtdNotasProcessadas
        {
            get
            {
                return this.qtdNotasProcessadasField;
            }
            set
            {
                this.qtdNotasProcessadasField = value;
            }
        }

        /// <remarks/>
        public string TempoProcessamento
        {
            get
            {
                return this.tempoProcessamentoField;
            }
            set
            {
                this.tempoProcessamentoField = value;
            }
        }

        /// <remarks/>
        public string ValorTotalServicos
        {
            get
            {
                return this.valorTotalServicosField;
            }
            set
            {
                this.valorTotalServicosField = value;
            }
        }

        /// <remarks/>
        public string ValorTotalDeducoes
        {
            get
            {
                return this.valorTotalDeducoesField;
            }
            set
            {
                this.valorTotalDeducoesField = value;
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

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public class ErrosRetLote
    {
        private List<ErrosErroRetLote> errosField;
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Erro")]
        public List<ErrosErroRetLote> Erro
        {
            get
            {
                return this.errosField;
            }
            set
            {
                this.errosField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public class ErrosErroRetLote
    {

        private string codigoField;

        private string descricaoField;

        private ErrosErroChaveRPSretLote chaveRPSField;

        /// <remarks/>
        public string Codigo
        {
            get
            {
                return this.codigoField;
            }
            set
            {
                this.codigoField = value;
            }
        }

        /// <remarks/>
        public string Descricao
        {
            get
            {
                return this.descricaoField;
            }
            set
            {
                this.descricaoField = value;
            }
        }

        /// <remarks/>
        public ErrosErroChaveRPSretLote ChaveRPS
        {
            get
            {
                return this.chaveRPSField;
            }
            set
            {
                this.chaveRPSField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public class ErrosErroChaveRPSretLote
    {

        private uint inscricaoPrestadorField;

        private string serieRPSField;

        private string numeroRPSField;

        private System.DateTime dataEmissaoRPSField;

        private string razaoSocialPrestadorField;

        /// <remarks/>
        public uint InscricaoPrestador
        {
            get
            {
                return this.inscricaoPrestadorField;
            }
            set
            {
                this.inscricaoPrestadorField = value;
            }
        }

        /// <remarks/>
        public string SerieRPS
        {
            get
            {
                return this.serieRPSField;
            }
            set
            {
                this.serieRPSField = value;
            }
        }

        /// <remarks/>
        public string NumeroRPS
        {
            get
            {
                return this.numeroRPSField;
            }
            set
            {
                this.numeroRPSField = value;
            }
        }

        /// <remarks/>
        public System.DateTime DataEmissaoRPS
        {
            get
            {
                return this.dataEmissaoRPSField;
            }
            set
            {
                this.dataEmissaoRPSField = value;
            }
        }

        /// <remarks/>
        public string RazaoSocialPrestador
        {
            get
            {
                return this.razaoSocialPrestadorField;
            }
            set
            {
                this.razaoSocialPrestadorField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public class ListaNFSe
    {

        private List<ListaNFSeConsultaNFSe> consultaNFSeField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ConsultaNFSe")]
        public List<ListaNFSeConsultaNFSe> ConsultaNFSe
        {
            get
            {
                return this.consultaNFSeField;
            }
            set
            {
                this.consultaNFSeField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public class ListaNFSeConsultaNFSe
    {

        private uint inscricaoPrestadorField;

        private string numeroNFeField;

        private string codigoVerificacaoField;

        private string serieRPSField;

        private string numeroRPSField;

        private System.DateTime dataEmissaoRPSField;

        private string razaoSocialPrestadorField;

        private string tipoRecolhimentoField;

        private string valorDeduzirField;

        private string valorTotalField;

        private string aliquotaField;

        /// <remarks/>
        public uint InscricaoPrestador
        {
            get
            {
                return this.inscricaoPrestadorField;
            }
            set
            {
                this.inscricaoPrestadorField = value;
            }
        }

        /// <remarks/>
        public string NumeroNFe
        {
            get
            {
                return this.numeroNFeField;
            }
            set
            {
                this.numeroNFeField = value;
            }
        }

        /// <remarks/>
        public string CodigoVerificacao
        {
            get
            {
                return this.codigoVerificacaoField;
            }
            set
            {
                this.codigoVerificacaoField = value;
            }
        }

        /// <remarks/>
        public string SerieRPS
        {
            get
            {
                return this.serieRPSField;
            }
            set
            {
                this.serieRPSField = value;
            }
        }

        /// <remarks/>
        public string NumeroRPS
        {
            get
            {
                return this.numeroRPSField;
            }
            set
            {
                this.numeroRPSField = value;
            }
        }

        /// <remarks/>
        public System.DateTime DataEmissaoRPS
        {
            get
            {
                return this.dataEmissaoRPSField;
            }
            set
            {
                this.dataEmissaoRPSField = value;
            }
        }

        /// <remarks/>
        public string RazaoSocialPrestador
        {
            get
            {
                return this.razaoSocialPrestadorField;
            }
            set
            {
                this.razaoSocialPrestadorField = value;
            }
        }

        /// <remarks/>
        public string TipoRecolhimento
        {
            get
            {
                return this.tipoRecolhimentoField;
            }
            set
            {
                this.tipoRecolhimentoField = value;
            }
        }

        /// <remarks/>
        public string ValorDeduzir
        {
            get
            {
                return this.valorDeduzirField;
            }
            set
            {
                this.valorDeduzirField = value;
            }
        }

        /// <remarks/>
        public string ValorTotal
        {
            get
            {
                return this.valorTotalField;
            }
            set
            {
                this.valorTotalField = value;
            }
        }

        /// <remarks/>
        public string Aliquota
        {
            get
            {
                return this.aliquotaField;
            }
            set
            {
                this.aliquotaField = value;
            }
        }
    }

}
