using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using HLP.GeraXml.Comum.Static;
using System.ComponentModel.DataAnnotations;

namespace HLP.GeraXml.bel.NFes.DSF
{

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://localhost:8080/WsNFe2/lote", IsNullable = false)]
    public class ReqEnvioLoteRPS
    {
        [System.Xml.Serialization.XmlAttributeAttribute(AttributeName = "schemaLocation", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
        public string schemaLocation = "http://localhost:8080/WsNFe2/lote http://localhost:8080/WsNFe2/xsd/ReqEnvioLoteRPS.xsd";

        private Cabecalho _cabec;
        private Lote _lote;

        /// <summary>
        /// Cabeçalho
        /// </summary>
        [XmlElement("Cabecalho")]
        public Cabecalho cabec
        {
            get { return _cabec; }
            set { _cabec = value; }
        }
        /// <summary>
        /// Lote
        /// </summary>
        [XmlElement("Lote")]
        public Lote lote
        {
            get { return _lote; }
            set { _lote = value; }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public class Cabecalho
    {

        private string codCidadeField;

        private string cPFCNPJRemetenteField;

        private string razaoSocialRemetenteField;

        private bool transacaoField;

        private System.DateTime dtInicioField;

        private System.DateTime dtFimField;

        private int qtdRPSField;

        private decimal valorTotalServicosField;

        private decimal valorTotalDeducoesField;

        private byte versaoField;

        private string metodoEnvioField;

        [System.Xml.Serialization.XmlIgnore]
        public string NumeroLote { get; set; }

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
        public bool transacao
        {
            get
            {
                return this.transacaoField;
            }
            set
            {
                this.transacaoField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date")]
        public System.DateTime dtInicio
        {
            get
            {
                return this.dtInicioField;
            }
            set
            {
                this.dtInicioField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date")]
        public System.DateTime dtFim
        {
            get
            {
                return this.dtFimField;
            }
            set
            {
                this.dtFimField = value;
            }
        }

        /// <remarks/>
        public int QtdRPS
        {
            get
            {
                return this.qtdRPSField;
            }
            set
            {
                this.qtdRPSField = value;
            }
        }

        /// <remarks/>
        public decimal ValorTotalServicos
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
        public decimal ValorTotalDeducoes
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
        public string MetodoEnvio
        {
            get
            {
                return this.metodoEnvioField;
            }
            set
            {
                this.metodoEnvioField = value;
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
    public class Lote
    {

        private List<LoteRPS> rPSField;

        private string idField = "0";

        [XmlElement("RPS")]
        public List<LoteRPS> RPS
        {
            get
            {
                return this.rPSField;
            }
            set
            {
                this.rPSField = value;
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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public class LoteRPS
    {

        [System.Xml.Serialization.XmlIgnore]
        public bool bSerialize { get; set; }

        private string inscricaoMunicipalPrestadorField;

        private string razaoSocialPrestadorField;

        private string tipoRPSField;

        private string serieRPSField;

        private string numeroRPSField;

        private System.DateTime dataEmissaoRPSField;

        private string situacaoRPSField;

        private string serieRPSSubstituidoField;

        private byte numeroRPSSubstituidoField;

        private byte numeroNFSeSubstituidaField;

        private System.DateTime dataEmissaoNFSeSubstituidaField;

        private byte seriePrestacaoField;

        private string inscricaoMunicipalTomadorField;

        private string cPFCNPJTomadorField;

        private string razaoSocialTomadorField;

        private string tipoLogradouroTomadorField;

        private string logradouroTomadorField;

        private string numeroEnderecoTomadorField;

        private string tipoBairroTomadorField;

        private string bairroTomadorField;

        private string cidadeTomadorField;

        private string cidadeTomadorDescricaoField;

        private string cEPTomadorField;

        private string emailTomadorField;

        private string codigoAtividadeField;

        private string aliquotaAtividadeField;

        private string tipoRecolhimentoField;

        private string municipioPrestacaoField;

        private string municipioPrestacaoDescricaoField;

        private string operacaoField;

        private string tributacaoField;

        private string valorPISField;

        private string valorCOFINSField;

        private string valorINSSField;

        private string valorIRField;

        private string valorCSLLField;

        private decimal aliquotaPISField;

        private decimal aliquotaCOFINSField;

        private decimal aliquotaINSSField;

        private decimal aliquotaIRField;

        private decimal aliquotaCSLLField;

        private string descricaoRPSField;

        private byte dDDPrestadorField;

        private string telefonePrestadorField;

        private byte dDDTomadorField;

        private string telefoneTomadorField;

        private string motCancelamentoField;

        private LoteRPSDeducoes deducoesField;

        private LoteRPSItens itensField;

        private string idField;

        public string Assinatura { get; set; }

        /// <remarks/>
        public string InscricaoMunicipalPrestador
        {
            get
            {
                return this.inscricaoMunicipalPrestadorField;
            }
            set
            {
                this.inscricaoMunicipalPrestadorField = value;
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
        public string TipoRPS
        {
            get
            {
                return this.tipoRPSField;
            }
            set
            {
                this.tipoRPSField = value;
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


        [XmlIgnoreAttribute]
        public string CD_NFSEQ { get; set; }

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
        public string SituacaoRPS
        {
            get
            {
                return this.situacaoRPSField;
            }
            set
            {
                this.situacaoRPSField = value;
            }
        }

        /// <remarks/>
        public string SerieRPSSubstituido
        {
            get
            {
                return this.serieRPSSubstituidoField;
            }
            set
            {
                this.serieRPSSubstituidoField = value;
            }
        }

        /// <remarks/>
        public byte NumeroRPSSubstituido
        {
            get
            {
                return this.numeroRPSSubstituidoField;
            }
            set
            {
                this.numeroRPSSubstituidoField = value;
            }
        }

        /// <remarks/>
        public byte NumeroNFSeSubstituida
        {
            get
            {
                return this.numeroNFSeSubstituidaField;
            }
            set
            {
                this.numeroNFSeSubstituidaField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date")]
        public System.DateTime DataEmissaoNFSeSubstituida
        {
            get
            {
                return this.dataEmissaoNFSeSubstituidaField;
            }
            set
            {
                this.dataEmissaoNFSeSubstituidaField = value;
            }
        }

        /// <remarks/>
        public byte SeriePrestacao
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
        public string InscricaoMunicipalTomador
        {
            get
            {
                return this.inscricaoMunicipalTomadorField;
            }
            set
            {
                this.inscricaoMunicipalTomadorField = value;
            }
        }

        /// <remarks/>
        public string CPFCNPJTomador
        {
            get
            {
                return this.cPFCNPJTomadorField;
            }
            set
            {
                this.cPFCNPJTomadorField = value;
            }
        }

        /// <remarks/>
        public string RazaoSocialTomador
        {
            get
            {
                return this.razaoSocialTomadorField;
            }
            set
            {
                this.razaoSocialTomadorField = value;
            }
        }

        public string DocTomadorEstrangeiro { get; set; }

        /// <remarks/>
        public string TipoLogradouroTomador
        {
            get
            {
                return this.tipoLogradouroTomadorField;
            }
            set
            {
                this.tipoLogradouroTomadorField = value;
            }
        }

        /// <remarks/>
        public string LogradouroTomador
        {
            get
            {
                return this.logradouroTomadorField;
            }
            set
            {
                this.logradouroTomadorField = value;
            }
        }

        /// <remarks/>
        public string NumeroEnderecoTomador
        {
            get
            {
                return this.numeroEnderecoTomadorField;
            }
            set
            {
                this.numeroEnderecoTomadorField = value;
            }
        }

        public string ComplementoEnderecoTomador { get; set; }

        /// <remarks/>
        public string TipoBairroTomador
        {
            get
            {
                return this.tipoBairroTomadorField;
            }
            set
            {
                this.tipoBairroTomadorField = value;
            }
        }

        /// <remarks/>
        public string BairroTomador
        {
            get
            {
                return this.bairroTomadorField;
            }
            set
            {
                this.bairroTomadorField = value;
            }
        }

        /// <remarks/>
        public string CidadeTomador
        {
            get
            {
                return this.cidadeTomadorField;
            }
            set
            {
                this.cidadeTomadorField = value;
            }
        }

        /// <remarks/>
        public string CidadeTomadorDescricao
        {
            get
            {
                return this.cidadeTomadorDescricaoField;
            }
            set
            {
                this.cidadeTomadorDescricaoField = value;
            }
        }

        /// <remarks/>
        public string CEPTomador
        {
            get
            {
                return this.cEPTomadorField;
            }
            set
            {
                this.cEPTomadorField = value;
            }
        }

        /// <remarks/>
        public string EmailTomador
        {
            get
            {
                return this.emailTomadorField;
            }
            set
            {
                this.emailTomadorField = value;
            }
        }

        /// <remarks/>
        public string CodigoAtividade
        {
            get
            {
                return this.codigoAtividadeField;
            }
            set
            {
                this.codigoAtividadeField = value;
            }
        }

        /// <remarks/>
        public string AliquotaAtividade
        {
            get
            {
                return this.aliquotaAtividadeField.Replace(',', '.');
            }
            set
            {
                this.aliquotaAtividadeField = value;
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
                if (value.Equals("N"))
                {
                    this.tipoRecolhimentoField = "A";
                }
                else
                {
                    this.tipoRecolhimentoField = "R";
                }
            }
        }

        /// <remarks/>
        public string MunicipioPrestacao
        {
            get
            {
                return this.municipioPrestacaoField;
            }
            set
            {
                this.municipioPrestacaoField = value;
            }
        }

        /// <remarks/>
        public string MunicipioPrestacaoDescricao
        {
            get
            {
                return this.municipioPrestacaoDescricaoField;
            }
            set
            {
                this.municipioPrestacaoDescricaoField = value;
            }
        }

        /// <remarks/>
        public string Operacao
        {
            get
            {
                return this.operacaoField;
            }
            set
            {
                this.operacaoField = value;
            }
        }

        /// <remarks/>
        public string Tributacao
        {
            get
            {
                return this.tributacaoField;
            }
            set
            {
                this.tributacaoField = value;
            }
        }

        /// <remarks/>
        public string ValorPIS
        {
            get
            {
                return (bSerialize ? Convert.ToDecimal(this.valorPISField).ToString("#0.00").Replace(",", ".") : this.valorPISField);
            }
            set
            {
                this.valorPISField = value;
            }
        }

        /// <remarks/>
        public string ValorCOFINS
        {
            get
            {
                return (bSerialize ? Convert.ToDecimal(this.valorCOFINSField).ToString("#0.00").Replace(",", ".") : this.valorCOFINSField);
            }
            set
            {
                this.valorCOFINSField = value.Replace(".", ",");
            }
        }

        /// <remarks/>
        public string ValorINSS
        {
            get
            {
                return (bSerialize ? Convert.ToDecimal(this.valorINSSField).ToString("#0.00").Replace(",", ".") : this.valorINSSField);
            }
            set
            {
                this.valorINSSField = value;
            }
        }

        /// <remarks/>
        public string ValorIR
        {
            get
            {
                return (bSerialize ? Convert.ToDecimal(this.valorIRField).ToString("#0.00").Replace(",", ".") : this.valorIRField);
            }
            set
            {
                this.valorIRField = value;
            }
        }

        /// <remarks/>
        public string ValorCSLL
        {
            get
            {
                return (bSerialize ? Convert.ToDecimal(this.valorCSLLField).ToString("#0.00").Replace(",", ".") : this.valorCSLLField);
            }
            set
            {
                this.valorCSLLField = value;
            }
        }

        /// <remarks/>
        public decimal AliquotaPIS
        {
            get
            {
                return this.aliquotaPISField;
            }
            set
            {
                this.aliquotaPISField = value;
            }
        }

        /// <remarks/>
        public decimal AliquotaCOFINS
        {
            get
            {
                return this.aliquotaCOFINSField;
            }
            set
            {
                this.aliquotaCOFINSField = value;
            }
        }

        /// <remarks/>
        public decimal AliquotaINSS
        {
            get
            {
                return this.aliquotaINSSField;
            }
            set
            {
                this.aliquotaINSSField = value;
            }
        }

        /// <remarks/>
        public decimal AliquotaIR
        {
            get
            {
                return this.aliquotaIRField;
            }
            set
            {
                this.aliquotaIRField = value;
            }
        }

        /// <remarks/>
        public decimal AliquotaCSLL
        {
            get
            {
                return this.aliquotaCSLLField;
            }
            set
            {
                this.aliquotaCSLLField = value;
            }
        }

        /// <remarks/>
        public string DescricaoRPS
        {
            get
            {
                return this.descricaoRPSField;
            }
            set
            {
                this.descricaoRPSField = value;
            }
        }

        public string DDDPrestador { get; set; }
        private string _TelefonePrestador;
        public string TelefonePrestador
        {
            get { return _TelefonePrestador; }
            set
            {
                _TelefonePrestador = TrataNumeroTelefone(Util.TiraSimbolo(value));
                this.DDDPrestador = TrataDDDTelefone(Util.TiraSimbolo(value).Replace(_TelefonePrestador, ""));
            }
        }
        public string DDDTomador { get; set; }
        private string _TelefoneTomador;
        public string TelefoneTomador
        {
            get { return _TelefoneTomador; }
            set
            {
                _TelefoneTomador = TrataNumeroTelefone(Util.TiraSimbolo(value));
                this.DDDTomador = TrataDDDTelefone(Util.TiraSimbolo(value).Replace(_TelefoneTomador, ""));
            }
        }

        /// <remarks/>
        public string MotCancelamento
        {
            get
            {
                return this.motCancelamentoField;
            }
            set
            {
                this.motCancelamentoField = value;
            }
        }

        public string CpfCnpjIntermediario { get; set; }

        /// <remarks/>
        public LoteRPSDeducoes Deducoes
        {
            get
            {
                return this.deducoesField;
            }
            set
            {
                this.deducoesField = value;
            }
        }

        /// <remarks/>
        public LoteRPSItens Itens
        {
            get
            {
                return this.itensField;
            }
            set
            {
                this.itensField = value;
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

        private static string TrataNumeroTelefone(string sNumero)
        {
            if (sNumero.Count() > 8)
            {
                sNumero = sNumero.Substring((sNumero.Count() - 8), 8);
            }
            else
            {
                sNumero = sNumero.PadLeft(8, '0');
            }
            return sNumero;
        }

        private static string TrataDDDTelefone(string sNumero)
        {
            if (sNumero.Count() >= 3)
            {
                return sNumero.Substring(0, 3);
            }
            else
            {
                return sNumero.PadLeft(3, '0');
            }
        }



    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public class LoteRPSDeducoes
    {

        private List<LoteRPSDeducoesDeducao> deducaoField;

        [XmlElement("Deducao")]
        public List<LoteRPSDeducoesDeducao> Deducao
        {
            get
            {
                return this.deducaoField;
            }
            set
            {
                this.deducaoField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public class LoteRPSDeducoesDeducao
    {

        private string deducaoPorField;

        private string tipoDeducaoField;

        private ulong cPFCNPJReferenciaField;

        private byte numeroNFReferenciaField;

        private decimal valorTotalReferenciaField;

        private decimal percentualDeduzirField;

        private decimal valorDeduzirField;

        /// <remarks/>
        public string DeducaoPor
        {
            get
            {
                return this.deducaoPorField;
            }
            set
            {
                this.deducaoPorField = value;
            }
        }

        /// <remarks/>
        public string TipoDeducao
        {
            get
            {
                return this.tipoDeducaoField;
            }
            set
            {
                this.tipoDeducaoField = value;
            }
        }

        /// <remarks/>
        public ulong CPFCNPJReferencia
        {
            get
            {
                return this.cPFCNPJReferenciaField;
            }
            set
            {
                this.cPFCNPJReferenciaField = value;
            }
        }

        /// <remarks/>
        public byte NumeroNFReferencia
        {
            get
            {
                return this.numeroNFReferenciaField;
            }
            set
            {
                this.numeroNFReferenciaField = value;
            }
        }

        /// <remarks/>
        public decimal ValorTotalReferencia
        {
            get
            {
                return this.valorTotalReferenciaField;
            }
            set
            {
                this.valorTotalReferenciaField = value;
            }
        }

        /// <remarks/>
        public decimal PercentualDeduzir
        {
            get
            {
                return this.percentualDeduzirField;
            }
            set
            {
                this.percentualDeduzirField = value;
            }
        }

        /// <remarks/>
        public decimal ValorDeduzir
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
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public class LoteRPSItens
    {

        private List<LoteRPSItensItem> itemField;

        [XmlElement("Item")]
        public List<LoteRPSItensItem> Item
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public class LoteRPSItensItem
    {
        [XmlIgnore]
        public string NumeroRPS { get; set; }

        private string discriminacaoServicoField;

        private byte quantidadeField;

        private decimal valorUnitarioField;

        private decimal valorTotalField;

        /// <remarks/>
        public string DiscriminacaoServico
        {
            get
            {
                return this.discriminacaoServicoField;
            }
            set
            {
                this.discriminacaoServicoField = value;
            }
        }

        /// <remarks/>
        public byte Quantidade
        {
            get
            {
                return this.quantidadeField;
            }
            set
            {
                this.quantidadeField = value;
            }
        }

        /// <remarks/>
        public decimal ValorUnitario
        {
            get
            {
                return this.valorUnitarioField;
            }
            set
            {
                this.valorUnitarioField = value;
            }
        }

        /// <remarks/>
        public decimal ValorTotal { get; set; }
    }
}