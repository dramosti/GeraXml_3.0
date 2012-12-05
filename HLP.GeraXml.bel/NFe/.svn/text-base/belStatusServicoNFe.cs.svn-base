using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using HLP.GeraXml.Comum.Static;
using System.Xml;

namespace HLP.GeraXml.bel.NFe
{
    public static class belStatusServicoNFe
    {

        public struct DadosRetorno
        {
            public string cStat { get; set; }
            public string xMotivo { get; set; }
            public int Tmed { get; set; }
            public DateTime Dhrecibo { get; set; }
            public DateTime Dhretorno { get; set; }
        }

        public static DadosRetorno RealizaConsultaStatusServico()
        {
            DadosRetorno dRetorno = new DadosRetorno();
            if (Acesso.TP_EMIS == 1 || Acesso.TP_EMIS == 2)
            {
                switch (Acesso.xUFtoWS)
                {
                    case "SP":
                        {
                            dRetorno = ConsultaServico_SP();
                        }
                        break;
                    case "RS":
                        {
                            dRetorno = ConsultaServico_RS();
                        }
                        break;
                    case "MS":
                        {
                            dRetorno = ConsultaServico_MS();
                        }
                        break;
                    case "SVRS":
                        {
                            dRetorno = ConsultaServico_SVRS();
                        }
                        break;
                    case "MG":
                        {
                            dRetorno = ConsultaServico_MG();
                        }
                        break;
                }
            }
            else if (Acesso.TP_EMIS == 3)
            {
                dRetorno = ConsultaServico_SCAN();
            }

            return dRetorno;
        }

        private static string NfeCabecMsg()
        {
            XNamespace nome = "http://www.portalfiscal.inf.br/nfe";
            XDocument doc = new XDocument(new XElement(nome + "cabecMsg", new XAttribute("versao", ""), new XAttribute("xmlns", "http://www.portalfiscal.inf.br/nfe"),
                                          new XElement(nome + "versaoDados", Acesso.versaoNFe)));
            string RetXmlString = doc.ToString();
            RetXmlString = "<?xml version=\"1.0\" encoding=\"utf-8\"?>" + RetXmlString;
            return RetXmlString;
        }

        private static XmlDocument NfeDadosMsg()
        {
            try
            {
                string NFeNamespace = "http://www.portalfiscal.inf.br/nfe";
                XmlDocument doc = new XmlDocument();
                XmlElement xraiz, xtpAmb, xcUF, xServ;
                XmlAttribute vs, xmlns;

                xraiz = doc.CreateElement("consStatServ");

                vs = doc.CreateAttribute("versao");
                vs.Value = Acesso.versaoNFe;
                xraiz.Attributes.Append(vs);

                xmlns = doc.CreateAttribute("xmlns");
                xmlns.Value = NFeNamespace;
                xraiz.Attributes.Append(xmlns);

                xtpAmb = doc.CreateElement("tpAmb");
                xtpAmb.InnerText = Acesso.TP_AMB.ToString();
                xraiz.AppendChild(xtpAmb);

                xcUF = doc.CreateElement("cUF");
                xcUF.InnerText = Acesso.cUF.ToString();
                xraiz.AppendChild(xcUF);

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

        private static DadosRetorno ConsultaServico_SP()
        {
            DadosRetorno dRetorno = new DadosRetorno();
            string snfeCabecMsg = NfeCabecMsg();
            XmlDocument xdDadosMsg = NfeDadosMsg();
            try
            {
                if (Acesso.TP_AMB == 1)
                {
                    #region Produção
                    HLP.GeraXml.WebService.v2_Producao_NFeStatusServico_SP.NfeStatusServico2 ws2 = new HLP.GeraXml.WebService.v2_Producao_NFeStatusServico_SP.NfeStatusServico2();
                    HLP.GeraXml.WebService.v2_Producao_NFeStatusServico_SP.nfeCabecMsg cabec = new HLP.GeraXml.WebService.v2_Producao_NFeStatusServico_SP.nfeCabecMsg();
                    cabec.cUF = Acesso.cUF.ToString();
                    cabec.versaoDados = Acesso.versaoNFe.ToString();
                    ws2.nfeCabecMsgValue = cabec;
                    ws2.ClientCertificates.Add(Acesso.cert_NFe);

                    XmlNode xmlDados = null;
                    xmlDados = xdDadosMsg.DocumentElement;

                    string resp = ws2.nfeStatusServicoNF2(xmlDados).OuterXml;

                    XElement Elemento = XElement.Parse(resp);

                    XNamespace xname = "http://www.portalfiscal.inf.br/nfe";

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
                    HLP.GeraXml.WebService.v2_Homologacao_NFeStatusServico_SP.NfeStatusServico2 ws2 = new HLP.GeraXml.WebService.v2_Homologacao_NFeStatusServico_SP.NfeStatusServico2();
                    HLP.GeraXml.WebService.v2_Homologacao_NFeStatusServico_SP.nfeCabecMsg cabec = new HLP.GeraXml.WebService.v2_Homologacao_NFeStatusServico_SP.nfeCabecMsg();
                    cabec.cUF = Acesso.cUF.ToString();
                    cabec.versaoDados = Acesso.versaoNFe.ToString();
                    ws2.nfeCabecMsgValue = cabec;
                    ws2.ClientCertificates.Add(Acesso.cert_NFe);

                    XmlNode xmlDados = null;
                    xmlDados = xdDadosMsg.DocumentElement;

                    string resp = ws2.nfeStatusServicoNF2(xmlDados).OuterXml;

                    XElement Elemento = XElement.Parse(resp);

                    XNamespace xname = "http://www.portalfiscal.inf.br/nfe";

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
        private static DadosRetorno ConsultaServico_MS()
        {
            DadosRetorno dRetorno = new DadosRetorno();
            string snfeCabecMsg = NfeCabecMsg();
            XmlDocument xdDadosMsg = NfeDadosMsg();
            try
            {
                if (Acesso.TP_AMB == 1)
                {
                    #region Produção
                    HLP.GeraXml.WebService.v2_Producao_NFeStatusServico_MS.NfeStatusServico2 ws2 = new HLP.GeraXml.WebService.v2_Producao_NFeStatusServico_MS.NfeStatusServico2();
                    HLP.GeraXml.WebService.v2_Producao_NFeStatusServico_MS.nfeCabecMsg cabec = new HLP.GeraXml.WebService.v2_Producao_NFeStatusServico_MS.nfeCabecMsg();
                    cabec.cUF = Acesso.cUF.ToString();
                    cabec.versaoDados = Acesso.versaoNFe.ToString();
                    ws2.nfeCabecMsgValue = cabec;
                    ws2.ClientCertificates.Add(Acesso.cert_NFe);

                    XmlNode xmlDados = null;
                    xmlDados = xdDadosMsg.DocumentElement;

                    string resp = ws2.nfeStatusServicoNF2(xmlDados).OuterXml;

                    XElement Elemento = XElement.Parse(resp);

                    XNamespace xname = "http://www.portalfiscal.inf.br/nfe";

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
                    HLP.GeraXml.WebService.v2_Homologacao_NFeStatusServico_MS.NfeStatusServico2 ws2 = new HLP.GeraXml.WebService.v2_Homologacao_NFeStatusServico_MS.NfeStatusServico2();
                    HLP.GeraXml.WebService.v2_Homologacao_NFeStatusServico_MS.nfeCabecMsg cabec = new HLP.GeraXml.WebService.v2_Homologacao_NFeStatusServico_MS.nfeCabecMsg();
                    cabec.cUF = Acesso.cUF.ToString();
                    cabec.versaoDados = Acesso.versaoNFe.ToString();
                    ws2.nfeCabecMsgValue = cabec;
                    ws2.ClientCertificates.Add(Acesso.cert_NFe);

                    XmlNode xmlDados = null;
                    xmlDados = xdDadosMsg.DocumentElement;

                    string resp = ws2.nfeStatusServicoNF2(xmlDados).OuterXml;

                    XElement Elemento = XElement.Parse(resp);

                    XNamespace xname = "http://www.portalfiscal.inf.br/nfe";

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
        private static DadosRetorno ConsultaServico_RS()
        {
            DadosRetorno dRetorno = new DadosRetorno();
            string snfeCabecMsg = NfeCabecMsg();
            XmlDocument xdDadosMsg = NfeDadosMsg();
            try
            {
                if (Acesso.TP_AMB == 1)
                {
                    #region Produção
                    HLP.GeraXml.WebService.v2_Producao_NFeStatusServico_RS.NfeStatusServico2 ws2 = new HLP.GeraXml.WebService.v2_Producao_NFeStatusServico_RS.NfeStatusServico2();
                    HLP.GeraXml.WebService.v2_Producao_NFeStatusServico_RS.nfeCabecMsg cabec = new HLP.GeraXml.WebService.v2_Producao_NFeStatusServico_RS.nfeCabecMsg();
                    cabec.cUF = Acesso.cUF.ToString();
                    cabec.versaoDados = Acesso.versaoNFe.ToString();
                    ws2.nfeCabecMsgValue = cabec;
                    ws2.ClientCertificates.Add(Acesso.cert_NFe);

                    XmlNode xmlDados = null;
                    xmlDados = xdDadosMsg.DocumentElement;

                    string resp = ws2.nfeStatusServicoNF2(xmlDados).OuterXml;

                    XElement Elemento = XElement.Parse(resp);

                    XNamespace xname = "http://www.portalfiscal.inf.br/nfe";

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
                    HLP.GeraXml.WebService.v2_Homologacao_NFeStatusServico_RS.NfeStatusServico2 ws2 = new HLP.GeraXml.WebService.v2_Homologacao_NFeStatusServico_RS.NfeStatusServico2();
                    HLP.GeraXml.WebService.v2_Homologacao_NFeStatusServico_RS.nfeCabecMsg cabec = new HLP.GeraXml.WebService.v2_Homologacao_NFeStatusServico_RS.nfeCabecMsg();
                    cabec.cUF = Acesso.cUF.ToString();
                    cabec.versaoDados = Acesso.versaoNFe.ToString();
                    ws2.nfeCabecMsgValue = cabec;
                    ws2.ClientCertificates.Add(Acesso.cert_NFe);

                    XmlNode xmlDados = null;
                    xmlDados = xdDadosMsg.DocumentElement;

                    string resp = ws2.nfeStatusServicoNF2(xmlDados).OuterXml;

                    XElement Elemento = XElement.Parse(resp);

                    XNamespace xname = "http://www.portalfiscal.inf.br/nfe";

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
        private static DadosRetorno ConsultaServico_SCAN()
        {
            DadosRetorno dRetorno = new DadosRetorno();
            string snfeCabecMsg = NfeCabecMsg();
            XmlDocument xdDadosMsg = NfeDadosMsg();
            try
            {
                if (Acesso.TP_AMB == 1)
                {
                    #region Produção
                    HLP.GeraXml.WebService.v2_SCAN_Producao_NFeStatusServico.NfeStatusServico2 ws2 = new HLP.GeraXml.WebService.v2_SCAN_Producao_NFeStatusServico.NfeStatusServico2();
                    HLP.GeraXml.WebService.v2_SCAN_Producao_NFeStatusServico.nfeCabecMsg cabec = new HLP.GeraXml.WebService.v2_SCAN_Producao_NFeStatusServico.nfeCabecMsg();
                    cabec.cUF = Acesso.cUF.ToString();
                    cabec.versaoDados = Acesso.versaoNFe.ToString();
                    ws2.nfeCabecMsgValue = cabec;
                    ws2.ClientCertificates.Add(Acesso.cert_NFe);

                    XmlNode xmlDados = null;
                    xmlDados = xdDadosMsg.DocumentElement;

                    string resp = ws2.nfeStatusServicoNF2(xmlDados).OuterXml;

                    XElement Elemento = XElement.Parse(resp);

                    XNamespace xname = "http://www.portalfiscal.inf.br/nfe";

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
                    HLP.GeraXml.WebService.v2_SCAN_Homologacao_NFeStatusServico.NfeStatusServico2 ws2 = new HLP.GeraXml.WebService.v2_SCAN_Homologacao_NFeStatusServico.NfeStatusServico2();
                    HLP.GeraXml.WebService.v2_SCAN_Homologacao_NFeStatusServico.nfeCabecMsg cabec = new HLP.GeraXml.WebService.v2_SCAN_Homologacao_NFeStatusServico.nfeCabecMsg();
                    cabec.cUF = Acesso.cUF.ToString();
                    cabec.versaoDados = Acesso.versaoNFe.ToString();
                    ws2.nfeCabecMsgValue = cabec;
                    ws2.ClientCertificates.Add(Acesso.cert_NFe);

                    XmlNode xmlDados = null;
                    xmlDados = xdDadosMsg.DocumentElement;

                    string resp = ws2.nfeStatusServicoNF2(xmlDados).OuterXml;

                    XElement Elemento = XElement.Parse(resp);

                    XNamespace xname = "http://www.portalfiscal.inf.br/nfe";

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
        private static DadosRetorno ConsultaServico_SVRS()
        {
            DadosRetorno dRetorno = new DadosRetorno();
            string snfeCabecMsg = NfeCabecMsg();
            XmlDocument xdDadosMsg = NfeDadosMsg();
            try
            {
                if (Acesso.TP_AMB == 1)
                {
                    #region Produção
                    HLP.GeraXml.WebService.V2_Producao_StatusServico_SVRS.NfeStatusServico2 ws2 = new HLP.GeraXml.WebService.V2_Producao_StatusServico_SVRS.NfeStatusServico2();
                    HLP.GeraXml.WebService.V2_Producao_StatusServico_SVRS.nfeCabecMsg cabec = new HLP.GeraXml.WebService.V2_Producao_StatusServico_SVRS.nfeCabecMsg();
                    cabec.cUF = Acesso.cUF.ToString();
                    cabec.versaoDados = Acesso.versaoNFe.ToString();
                    ws2.nfeCabecMsgValue = cabec;
                    ws2.ClientCertificates.Add(Acesso.cert_NFe);

                    XmlNode xmlDados = null;
                    xmlDados = xdDadosMsg.DocumentElement;

                    string resp = ws2.nfeStatusServicoNF2(xmlDados).OuterXml;

                    XElement Elemento = XElement.Parse(resp);

                    XNamespace xname = "http://www.portalfiscal.inf.br/nfe";

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
                    HLP.GeraXml.WebService.V2_Homologacao_StatusServico_SVRS.NfeStatusServico2 ws2 = new HLP.GeraXml.WebService.V2_Homologacao_StatusServico_SVRS.NfeStatusServico2();
                    HLP.GeraXml.WebService.V2_Homologacao_StatusServico_SVRS.nfeCabecMsg cabec = new HLP.GeraXml.WebService.V2_Homologacao_StatusServico_SVRS.nfeCabecMsg();
                    cabec.cUF = Acesso.cUF.ToString();
                    cabec.versaoDados = Acesso.versaoNFe.ToString();
                    ws2.nfeCabecMsgValue = cabec;
                    ws2.ClientCertificates.Add(Acesso.cert_NFe);

                    XmlNode xmlDados = null;
                    xmlDados = xdDadosMsg.DocumentElement;

                    string resp = ws2.nfeStatusServicoNF2(xmlDados).OuterXml;

                    XElement Elemento = XElement.Parse(resp);

                    XNamespace xname = "http://www.portalfiscal.inf.br/nfe";

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
        private static DadosRetorno ConsultaServico_MG()
        {
            DadosRetorno dRetorno = new DadosRetorno();
            string snfeCabecMsg = NfeCabecMsg();
            XmlDocument xdDadosMsg = NfeDadosMsg();
            try
            {
                if (Acesso.TP_AMB == 1)
                {
                    #region Produção
                    HLP.GeraXml.WebService.v2_Producao_NfeStatusServico_MG.NfeStatusServico2 ws2 = new HLP.GeraXml.WebService.v2_Producao_NfeStatusServico_MG.NfeStatusServico2();
                    HLP.GeraXml.WebService.v2_Producao_NfeStatusServico_MG.nfeCabecMsg cabec = new HLP.GeraXml.WebService.v2_Producao_NfeStatusServico_MG.nfeCabecMsg();
                    cabec.cUF = Acesso.cUF.ToString();
                    cabec.versaoDados = Acesso.versaoNFe.ToString();
                    ws2.nfeCabecMsgValue = cabec;
                    ws2.ClientCertificates.Add(Acesso.cert_NFe);

                    XmlNode xmlDados = null;
                    xmlDados = xdDadosMsg.DocumentElement;

                    string resp = ws2.nfeStatusServicoNF2(xmlDados).OuterXml;

                    XElement Elemento = XElement.Parse(resp);

                    XNamespace xname = "http://www.portalfiscal.inf.br/nfe";

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
                    HLP.GeraXml.WebService.v2_Homologacao_NfeStatusServico_MG.NfeStatusServico2 ws2 = new HLP.GeraXml.WebService.v2_Homologacao_NfeStatusServico_MG.NfeStatusServico2();
                    HLP.GeraXml.WebService.v2_Homologacao_NfeStatusServico_MG.nfeCabecMsg cabec = new HLP.GeraXml.WebService.v2_Homologacao_NfeStatusServico_MG.nfeCabecMsg();
                    cabec.cUF = Acesso.cUF.ToString();
                    cabec.versaoDados = Acesso.versaoNFe.ToString();
                    ws2.nfeCabecMsgValue = cabec;
                    ws2.ClientCertificates.Add(Acesso.cert_NFe);

                    XmlNode xmlDados = null;
                    xmlDados = xdDadosMsg.DocumentElement;

                    string resp = ws2.nfeStatusServicoNF2(xmlDados).OuterXml;

                    XElement Elemento = XElement.Parse(resp);

                    XNamespace xname = "http://www.portalfiscal.inf.br/nfe";

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
    }
}
