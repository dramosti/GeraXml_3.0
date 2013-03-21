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
    public class ReqConsultaLote
    {
        [System.Xml.Serialization.XmlAttributeAttribute(AttributeName = "schemaLocation", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
        public string schemaLocation = "http://localhost:8080/WsNFe2/lote http://localhost:8080/WsNFe2/xsd/ReqConsultaLote.xsd";

        [XmlElement("Cabecalho")]
        public belConsultaLote cabec { get; set; }
    }


    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://localhost:8080/WsNFe2/lote", IsNullable = false)]
    public class belConsultaLote
    {
        public string CodCidade { get; set; }
        public string CPFCNPJRemetente { get; set; }
        public string Versao { get; set; }
        public string NumeroLote { get; set; }
    }


}
