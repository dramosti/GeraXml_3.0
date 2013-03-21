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
    public class RetornoEnvioLoteRPS
    {
        [XmlElement("Cabecalho")]
        public CabecalhoRetorno cabec { get; set; }

        [XmlElement("Erros")]
        public Erros erros { get; set; }

        [XmlElement("Alertas")]
        public Alertas_retlote alertas { get; set; }
    }
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public class CabecalhoRetorno
    {

        private string codCidadeField;

        private bool sucessoField;

        private string numeroLoteField;

        private string cPFCNPJRemetenteField;

        private System.DateTime dataEnvioLoteField;

        private byte qtdNotasProcessadasField;

        private byte tempoProcessamentoField;

        private byte valorTotalServicosField;

        private byte valorTotalDeducoesField;

        private byte versaoField;

        private string assincronoField;

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
        public byte QtdNotasProcessadas
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
        public byte TempoProcessamento
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
        public byte ValorTotalServicos
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
        public byte ValorTotalDeducoes
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
        public byte Versao
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
        public string Assincrono
        {
            get
            {
                return this.assincronoField;
            }
            set
            {
                this.assincronoField = value;
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
    public class Alertas_retlote
    {
        [XmlElement("Alerta")]
        public List<Alerta_retlote> alert { get; set; }
    }
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public class Alerta_retlote
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
    public class Erros
    {

        private List<ErrosErro> erroField;


        [XmlElement("Erro")]
        public List<ErrosErro> Erro
        {
            get
            {
                return this.erroField;
            }
            set
            {
                this.erroField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public class ErrosErro
    {

        private string codigoField;

        private string descricaoField;

        private ErrosErroChaveRPS chaveRPSField;

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
        public ErrosErroChaveRPS ChaveRPS
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
    public class ErrosErroChaveRPS
    {

        private string inscricaoPrestadorField;

        private string serieRPSField;

        private byte numeroRPSField;

        private System.DateTime dataEmissaoRPSField;

        private string razaoSocialPrestadorField;

        /// <remarks/>
        public string InscricaoPrestador
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
        public byte NumeroRPS
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
}
