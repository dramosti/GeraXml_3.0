using HLP.GeraXml.Comum.Static;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace HLP.GeraXml.bel.CTe
{
    public static class belStatusServicoCTe
    {
        private static HLP.GeraXml.bel.NFe.belStatusServicoNFe.DadosRetorno ConsultaServico_SP()
        {
            HLP.GeraXml.bel.NFe.belStatusServicoNFe.DadosRetorno dRetorno = new HLP.GeraXml.bel.NFe.belStatusServicoNFe.DadosRetorno();
            string snfeCabecMsg = NfeCabecMsg();
            XmlDocument xdDadosMsg = CteDadosMsg();
            try
            {
                if (Acesso.TP_AMB == 1)
                {
                    #region Produção
                    HLP.GeraXml.WebService.CTe_Producao_cteStatusServico.CteStatusServico ws2 = new HLP.GeraXml.WebService.CTe_Producao_cteStatusServico.CteStatusServico();
                    HLP.GeraXml.WebService.CTe_Producao_cteStatusServico.cteCabecMsg cabec = new HLP.GeraXml.WebService.CTe_Producao_cteStatusServico.cteCabecMsg();

                    cabec.cUF = Acesso.cUF.ToString();
                    cabec.versaoDados = Acesso.versaoCTe.ToString();
                    ws2.cteCabecMsgValue = cabec;
                    ws2.ClientCertificates.Add(Acesso.cert_CTe);

                    XmlNode xmlDados = null;
                    xmlDados = xdDadosMsg.DocumentElement;

                    string resp = ws2.cteStatusServicoCT(xmlDados).OuterXml;

                    XElement Elemento = XElement.Parse(resp);

                    XNamespace xname = "http://www.portalfiscal.inf.br/cte";

                    // Busca do status da conexao
                    var Status =
                        from b in Elemento.Elements(xname + "cStat")

                        select new  // Depois da query adicionamos propriedades ao var Filme para estarem acessiveis no foreach
                        {
                            Status = (string)b.Value
                        };
                    foreach (var Stat in Status)
                    {
                        dRetorno.cStat = Stat.Status;
                    }
                    //

                    // Busca do Descricao do Motivo do status                
                    var Motivo =
                        from b in Elemento.Elements(xname + "xMotivo")

                        select new  // Depois da query adicionamos propriedades ao var Filme para estarem acessiveis no foreach
                        {
                            Motivo = (string)b.Value
                        };
                    foreach (var xMotivo in Motivo)
                    {
                        dRetorno.xMotivo = xMotivo.Motivo;
                    }
                    //

                    //Mostra o tempo medio de resposta do site.                
                    var tMed =
                        from b in Elemento.Elements(xname + "tMed")

                        select new  // Depois da query adicionamos propriedades ao var Filme para estarem acessiveis no foreach
                        {
                            TempoMedio = (string)b.Value
                        };
                    foreach (var TempoMedio in tMed)
                    {
                        dRetorno.Tmed = Convert.ToInt32(TempoMedio.TempoMedio);
                    }
                    //

                    //Mostra o data e hora do recibo.                
                    var dhRecibo =
                        from b in Elemento.Elements(xname + "dhRecbto")

                        select new  // Depois da query adicionamos propriedades ao var Filme para estarem acessiveis no foreach
                        {
                            datahoraRecibo = (string)b.Value
                        };
                    foreach (var dhrec in dhRecibo)
                    {
                        dRetorno.Dhrecibo = Convert.ToDateTime(dhrec.datahoraRecibo);
                    }
                    //

                    //Mostra o data e hora do recibo.                
                    var dhRetorno =
                        from b in Elemento.Elements(xname + "dhRetorno")

                        select new  // Depois da query adicionamos propriedades ao var Filme para estarem acessiveis no foreach
                        {
                            datahoraRetorno = (string)b.Value
                        };
                    foreach (var dhret in dhRetorno)
                    {
                        dRetorno.Dhretorno = Convert.ToDateTime(dhret.datahoraRetorno);
                    }
                    #endregion

                }
                else
                {
                    #region Homologação
                    HLP.GeraXml.WebService.CTe_Homologacao_cteStatusServico.CteStatusServico ws2 = new WebService.CTe_Homologacao_cteStatusServico.CteStatusServico();
                    HLP.GeraXml.WebService.CTe_Homologacao_cteStatusServico.cteCabecMsg cabec = new WebService.CTe_Homologacao_cteStatusServico.cteCabecMsg();

                    cabec.cUF = Acesso.cUF.ToString();
                    cabec.versaoDados = Acesso.versaoCTe.ToString();
                    ws2.cteCabecMsgValue = cabec;
                    ws2.ClientCertificates.Add(Acesso.cert_CTe);

                    XmlNode xmlDados = null;
                    xmlDados = xdDadosMsg.DocumentElement;

                    string resp = ws2.cteStatusServicoCT(xmlDados).OuterXml;

                    XElement Elemento = XElement.Parse(resp);

                    XNamespace xname = "http://www.portalfiscal.inf.br/cte";

                    // Busca do status da conexao
                    var Status =
                        from b in Elemento.Elements(xname + "cStat")

                        select new  // Depois da query adicionamos propriedades ao var Filme para estarem acessiveis no foreach
                        {
                            Status = (string)b.Value
                        };
                    foreach (var Stat in Status)
                    {
                        dRetorno.cStat = Stat.Status;
                    }
                    //

                    // Busca do Descricao do Motivo do status                
                    var Motivo =
                        from b in Elemento.Elements(xname + "xMotivo")

                        select new  // Depois da query adicionamos propriedades ao var Filme para estarem acessiveis no foreach
                        {
                            Motivo = (string)b.Value
                        };
                    foreach (var xMotivo in Motivo)
                    {
                        dRetorno.xMotivo = xMotivo.Motivo;
                    }
                    //

                    //Mostra o tempo medio de resposta do site.                
                    var tMed =
                        from b in Elemento.Elements(xname + "tMed")

                        select new  // Depois da query adicionamos propriedades ao var Filme para estarem acessiveis no foreach
                        {
                            TempoMedio = (string)b.Value
                        };
                    foreach (var TempoMedio in tMed)
                    {
                        dRetorno.Tmed = Convert.ToInt32(TempoMedio.TempoMedio);
                    }
                    //

                    //Mostra o data e hora do recibo.                
                    var dhRecibo =
                        from b in Elemento.Elements(xname + "dhRecbto")

                        select new  // Depois da query adicionamos propriedades ao var Filme para estarem acessiveis no foreach
                        {
                            datahoraRecibo = (string)b.Value
                        };
                    foreach (var dhrec in dhRecibo)
                    {
                        dRetorno.Dhrecibo = Convert.ToDateTime(dhrec.datahoraRecibo);
                    }
                    //

                    //Mostra o data e hora do recibo.                
                    var dhRetorno =
                        from b in Elemento.Elements(xname + "dhRetorno")

                        select new  // Depois da query adicionamos propriedades ao var Filme para estarem acessiveis no foreach
                        {
                            datahoraRetorno = (string)b.Value
                        };
                    foreach (var dhret in dhRetorno)
                    {
                        dRetorno.Dhretorno = Convert.ToDateTime(dhret.datahoraRetorno);
                    }
                    #endregion
                }

                return dRetorno;
            }
            catch (Exception x)
            {
                throw new Exception("Problema com os WebServices - " + x.Message);
            }
        }

        private static XmlDocument CteDadosMsg()
        {
            try
            {
                string NFeNamespace = "http://www.portalfiscal.inf.br/cte";
                XmlDocument doc = new XmlDocument();
                XmlElement xraiz, xtpAmb, xServ;
                XmlAttribute vs, xmlns;

                xraiz = doc.CreateElement("consStatServCte");

                vs = doc.CreateAttribute("versao");
                vs.Value = Acesso.versaoCTe;
                xraiz.Attributes.Append(vs);

                xmlns = doc.CreateAttribute("xmlns");
                xmlns.Value = NFeNamespace;
                xraiz.Attributes.Append(xmlns);

                xtpAmb = doc.CreateElement("tpAmb");
                xtpAmb.InnerText = Acesso.TP_AMB.ToString();
                xraiz.AppendChild(xtpAmb);

                xServ = doc.CreateElement("xServ");
                xServ.InnerText = "STATUS";
                xraiz.AppendChild(xServ);

                doc.AppendChild(xraiz);
                XmlProcessingInstruction pi = doc.CreateProcessingInstruction("xml", "version=\"1.0\" encoding=\"UTF-8\"");
                doc.InsertBefore(pi, xraiz);
                return doc;
            }
            catch (Exception ex)
            {
                throw ex;
            }




        }

        public static string NfeCabecMsg()
        {
            XNamespace nome = "http://www.portalfiscal.inf.br/cte";
            XDocument doc = new XDocument(new XElement(nome + "cabecMsg", new XAttribute("versao", ""), new XAttribute("xmlns", "http://www.portalfiscal.inf.br/cte"),
                                          new XElement(nome + "cUF", Acesso.cUF),
                                          new XElement(nome + "versaoDados", Acesso.versaoCTe)));
            string RetXmlString = doc.ToString();
            RetXmlString = "<?xml version=\"1.0\" encoding=\"utf-8\"?>" + RetXmlString;
            return RetXmlString;
        }
        public static HLP.GeraXml.bel.NFe.belStatusServicoNFe.DadosRetorno RealizaConsultaStatusServico()
        {
            HLP.GeraXml.bel.NFe.belStatusServicoNFe.DadosRetorno dRetorno = new HLP.GeraXml.bel.NFe.belStatusServicoNFe.DadosRetorno();
            if (Acesso.TP_EMIS == 1 || Acesso.TP_EMIS == 2)
            {
                switch (Acesso.xUFtoWS)
                {
                    case "SP":
                        {
                            dRetorno = ConsultaServico_SP();
                        }
                        break;
                }
            }
            else if (Acesso.TP_EMIS == 3)
            {
                //dRetorno = null;// ConsultaServico_SCAN();
            }

            return dRetorno;
        }
    }
}
