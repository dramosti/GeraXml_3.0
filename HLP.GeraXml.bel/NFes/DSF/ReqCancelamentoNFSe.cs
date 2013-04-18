using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using HLP.GeraXml.dao.NFes.DSF;
using System.Data;

namespace HLP.GeraXml.bel.NFes.DSF
{

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://localhost:8080/WsNFe2/lote", IsNullable = false)]
    public class ReqCancelamentoNFSe
    {
        [System.Xml.Serialization.XmlAttributeAttribute(AttributeName = "schemaLocation", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
        public string schemaLocation = "http://localhost:8080/WsNFe2/lote http://localhost:8080/WsNFe2/xsd/ReqCancelamentoNFSe.xsd";

        [XmlElement("Cabecalho")]
        public CabecalhoRetCanc cabec { get; set; }

        [XmlElement("Lote")]
        public LoteCanc lote { get; set; }
    }


    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute("Cabecalho", Namespace = "", IsNullable = false)]
    public partial class CabecalhoRetCanc
    {

        private string codCidadeField;

        private string cPFCNPJRemetenteField;

        private bool transacaoField;

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
    [System.Xml.Serialization.XmlRootAttribute("Lote", Namespace = "", IsNullable = false)]
    public class LoteCanc
    {

        private List<LoteNota> notaField;

        private string idField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Nota")]
        public List<LoteNota> Nota
        {
            get
            {
                return this.notaField;
            }
            set
            {
                this.notaField = value;
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
    public class LoteNota : daoCancelamentoDSF
    {
        public LoteNota() { }
        public void CarregaDados(string sCD_NFSEQ)
        {
            DataTable dt = base.GetDadosCancelemto(sCD_NFSEQ);
            foreach (DataRow row in dt.Rows)
            {
                this.CodigoVerificacao = row["cd_verificacao_nfse"].ToString();
                this.InscricaoMunicipalPrestador = row["cd_inscrmu"].ToString();
                this.NumeroNota = row["cd_numero_nfse"].ToString();
                break;
            }
        }



        private string inscricaoMunicipalPrestadorField;

        private string numeroNotaField;

        private string codigoVerificacaoField;

        private string motivoCancelamentoField;

        private string idField;

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
        public string NumeroNota
        {
            get
            {
                return this.numeroNotaField;
            }
            set
            {
                this.numeroNotaField = value;
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
        public string MotivoCancelamento
        {
            get
            {
                return this.motivoCancelamentoField;
            }
            set
            {
                this.motivoCancelamentoField = value;
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

}
