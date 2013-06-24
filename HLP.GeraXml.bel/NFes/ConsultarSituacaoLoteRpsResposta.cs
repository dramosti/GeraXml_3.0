using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace HLP.GeraXml.bel.NFes
{ 

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.ginfes.com.br/servico_consultar_situacao_lote_rps_resposta_v03.xsd")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.ginfes.com.br/servico_consultar_situacao_lote_rps_resposta_v03.xsd", IsNullable = false)]
    public partial class ConsultarSituacaoLoteRpsResposta
    {

        private ushort numeroLoteField;

        private byte situacaoField;

        /// <remarks/>
        public ushort NumeroLote
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
        public byte Situacao
        {
            get
            {
                return this.situacaoField;
            }
            set
            {
                this.situacaoField = value;
            }
        }
    }
}
