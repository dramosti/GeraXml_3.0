using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using HLP.GeraXml.dao;
using System.IO;
using HLP.GeraXml.Comum.Static;
using System.Xml.Schema;
using HLP.GeraXml.Comum;

namespace HLP.GeraXml.bel.NFes
{
    public class belCriaXmlNFs
    {
        public string sXmlLote = "";


        public void GerarArquivoXml(tcLoteRps objLoteRpd)
        {
            try
            {
                List<string> ListaNfes = new List<string>();
                XDocument xdoc = new XDocument();
                XNamespace tipos = "http://www.ginfes.com.br/tipos_v03.xsd";
                XNamespace pf = "http://www.ginfes.com.br/servico_enviar_lote_rps_envio_v03.xsd";


                XContainer conEnviarLoteRpsEnvio = (new XElement(pf + "EnviarLoteRpsEnvio", new XAttribute("xmlns", "http://www.ginfes.com.br/servico_enviar_lote_rps_envio_v03.xsd")));

                XContainer conLoteRps = (new XElement(pf + "LoteRps", new XAttribute("Id", objLoteRpd.NumeroLote),
                                                                new XAttribute(XNamespace.Xmlns + "tipos", "http://www.ginfes.com.br/tipos_v03.xsd"),
                                                                                     new XElement(tipos + "NumeroLote", objLoteRpd.NumeroLote.ToString()),
                                                                                     new XElement(tipos + "Cnpj", objLoteRpd.Cnpj.ToString()),
                                                                                     new XElement(tipos + "InscricaoMunicipal", objLoteRpd.InscricaoMunicipal.ToString()),
                                                                                     new XElement(tipos + "QuantidadeRps", objLoteRpd.QuantidadeRps.ToString())));

                XContainer conListaRps = (new XElement(tipos + "ListaRps"));
                XContainer conRps = (new XElement(tipos + "Rps"));
                XContainer conInfRps = null;
                XContainer conSubstituto = null;
                XContainer conServico = null;
                XContainer conPrestador = null;
                XContainer conTomador = null;
                XContainer conIntermediarioServico = null;
                XContainer conConstrucaoCivil = null;

                foreach (TcRps rps in objLoteRpd.Rps)
                {
                    #region IdentificacaoRps conRps
                    try
                    {
                        conInfRps = (new XElement(tipos + "InfRps", new XElement(tipos + "IdentificacaoRps",
                                                                                     new XElement(tipos + "Numero", rps.InfRps.IdentificacaoRps.Numero),
                                                                                     new XElement(tipos + "Serie", rps.InfRps.IdentificacaoRps.Serie),
                                                                                     new XElement(tipos + "Tipo", rps.InfRps.IdentificacaoRps.Tipo)),
                                                                          new XElement(tipos + "DataEmissao", daoUtil.GetDateServidor().Date.ToString("yyyy-MM-ddTHH:mm:ss")),
                                                                          new XElement(tipos + "NaturezaOperacao", rps.InfRps.NaturezaOperacao),
                                                                         ((rps.InfRps.RegimeEspecialTributacao != 0) ? new XElement(tipos + "RegimeEspecialTributacao", rps.InfRps.RegimeEspecialTributacao) : null),
                                                                          new XElement(tipos + "OptanteSimplesNacional", rps.InfRps.OptanteSimplesNacional),
                                                                          new XElement(tipos + "IncentivadorCultural", rps.InfRps.IncentivadorCultural),
                                                                          new XElement(tipos + "Status", rps.InfRps.Status)));

                    }
                    catch (Exception x)
                    {
                        throw new Exception("Nota : " + rps.InfRps.IdentificacaoRps.Numero + "Erro na geração do XML, Regiao:('IdentificacaoRps')- "
                            + Environment.NewLine + "XML_Detalhes: "
                            + Environment.NewLine + x.Message);
                    }
                    #endregion

                    #region RpsSubstituido
                    if (rps.InfRps.RpsSubstituido != null)
                    {
                        try
                        {
                            conSubstituto = (new XElement(tipos + "RpsSubstituido",
                                                         new XElement(tipos + "Numero", rps.InfRps.RpsSubstituido.Numero),
                                                         new XElement(tipos + "Serie", rps.InfRps.RpsSubstituido.Serie),
                                                         new XElement(tipos + "Tipo", rps.InfRps.RpsSubstituido.Tipo)));
                        }
                        catch (Exception x)
                        {
                            throw new Exception("Nota : " + rps.InfRps.IdentificacaoRps.Numero + "Erro na geração do XML, Regiao:('RpsSubstituido')- "
                                + Environment.NewLine + "XML_Detalhes: "
                                + Environment.NewLine + x.Message);
                        }
                    }

                    #endregion

                    #region Servico
                    try
                    {
                        conServico = (new XElement(tipos + "Servico", new XElement(tipos + "Valores",
                                                    new XElement(tipos + "ValorServicos", rps.InfRps.Servico.Valores.ValorServicos.ToString("#0.00").Replace(",", ".")),
                                                    ((rps.InfRps.Servico.Valores.ValorDeducoes > 0) ? new XElement(tipos + "ValorDeducoes", rps.InfRps.Servico.Valores.ValorDeducoes.ToString("#0.00").Replace(",", ".")) : null),
                                                    ((rps.InfRps.Servico.Valores.ValorPis > 0) ? new XElement(tipos + "ValorPis", rps.InfRps.Servico.Valores.ValorPis.ToString("#0.00").Replace(",", ".")) : null),
                                                    ((rps.InfRps.Servico.Valores.ValorCofins > 0) ? new XElement(tipos + "ValorCofins", rps.InfRps.Servico.Valores.ValorCofins.ToString("#0.00").Replace(",", ".")) : null),
                                                    ((rps.InfRps.Servico.Valores.ValorInss > 0) ? new XElement(tipos + "ValorInss", rps.InfRps.Servico.Valores.ValorInss.ToString("#0.00").Replace(",", ".")) : null),
                                                    ((rps.InfRps.Servico.Valores.ValorIr > 0) ? new XElement(tipos + "ValorIr", rps.InfRps.Servico.Valores.ValorIr.ToString("#0.00").Replace(",", ".")) : null),
                                                    ((rps.InfRps.Servico.Valores.ValorCsll > 0) ? new XElement(tipos + "ValorCsll", rps.InfRps.Servico.Valores.ValorCsll.ToString("#0.00").Replace(",", ".")) : null),
                                                                                                      new XElement(tipos + "IssRetido", rps.InfRps.Servico.Valores.IssRetido),
                                                    ((rps.InfRps.Servico.Valores.ValorIss > 0) ? new XElement(tipos + "ValorIss", rps.InfRps.Servico.Valores.ValorIss.ToString("#0.00").Replace(",", ".")) : null),
                                                    ((rps.InfRps.Servico.Valores.ValorIssRetido > 0) ? new XElement(tipos + "ValorIssRetido", rps.InfRps.Servico.Valores.ValorIssRetido.ToString("#0.00").Replace(",", ".")) : null),
                                                    ((rps.InfRps.Servico.Valores.OutrasRetencoes > 0) ? new XElement(tipos + "OutrasRetencoes", rps.InfRps.Servico.Valores.OutrasRetencoes.ToString("#0.00").Replace(",", ".")) : null),
                                                    ((rps.InfRps.Servico.Valores.BaseCalculo > 0) ? new XElement(tipos + "BaseCalculo", rps.InfRps.Servico.Valores.BaseCalculo.ToString("#0.00").Replace(",", ".")) : null),
                                                    ((rps.InfRps.Servico.Valores.Aliquota > 0) ? new XElement(tipos + "Aliquota", (rps.InfRps.Servico.Valores.Aliquota / 100).ToString("#0.0000").Replace(",", ".")) : null),
                                                    ((rps.InfRps.Servico.Valores.ValorLiquidoNfse > 0) ? new XElement(tipos + "ValorLiquidoNfse", rps.InfRps.Servico.Valores.ValorLiquidoNfse.ToString("#0.00").Replace(",", ".")) : null),
                                                    ((rps.InfRps.Servico.Valores.DescontoCondicionado > 0) ? new XElement(tipos + "DescontoCondicionado", rps.InfRps.Servico.Valores.DescontoCondicionado.ToString("#0.00").Replace(",", ".")) : null),
                                                    ((rps.InfRps.Servico.Valores.DescontoIncondicionado > 0) ? new XElement(tipos + "DescontoIncondicionado", rps.InfRps.Servico.Valores.DescontoIncondicionado.ToString("#0.00").Replace(",", ".")) : null)),
                                                                                         new XElement(tipos + "ItemListaServico", rps.InfRps.Servico.ItemListaServico),
                                       ((rps.InfRps.Servico.CodigoCnae != "") ? new XElement(tipos + "CodigoCnae", rps.InfRps.Servico.CodigoCnae) : null),
                                       (((rps.InfRps.Servico.CodigoTributacaoMunicipio != "") && (rps.InfRps.Servico.CodigoTributacaoMunicipio != "0")) ? new XElement(tipos + "CodigoTributacaoMunicipio", rps.InfRps.Servico.CodigoTributacaoMunicipio) : null),
                                                                                         new XElement(tipos + "Discriminacao", rps.InfRps.Servico.Discriminacao),
                                       new XElement(tipos + "CodigoMunicipio", rps.InfRps.Servico.CodigoMunicipio)));
                    }
                    catch (Exception x)
                    {
                        throw new Exception("Nota : " + rps.InfRps.IdentificacaoRps.Numero + "Erro na geração do XML, Regiao:('Servico')- "
                            + Environment.NewLine + "XML_Detalhes: "
                            + Environment.NewLine + x.Message);
                    }
                    #endregion

                    #region Prestador
                    try
                    {
                        conPrestador = (new XElement(tipos + "Prestador", new XElement(tipos + "Cnpj", rps.InfRps.Prestador.Cnpj),
                                                                      ((rps.InfRps.Prestador.InscricaoMunicipal != "") ? new XElement(tipos + "InscricaoMunicipal", rps.InfRps.Prestador.InscricaoMunicipal) : null)));

                    }
                    catch (Exception x)
                    {
                        throw new Exception("Nota : " + rps.InfRps.IdentificacaoRps.Numero + "Erro na geração do XML, Regiao:('Prestador')- "
                            + Environment.NewLine + "XML_Detalhes: "
                            + Environment.NewLine + x.Message);
                    }
                    #endregion

                    #region Tomador
                    try
                    {
                        conTomador = (new XElement(tipos + "Tomador", ((rps.InfRps.Tomador.IdentificacaoTomador != null) ? new XElement(tipos + "IdentificacaoTomador", new XElement(tipos + "CpfCnpj",
                                                                                                               new XElement(tipos + (rps.InfRps.Tomador.IdentificacaoTomador.CpfCnpj.Cnpj != "" ? "Cnpj" : "Cpf"), (rps.InfRps.Tomador.IdentificacaoTomador.CpfCnpj.Cnpj != "" ? rps.InfRps.Tomador.IdentificacaoTomador.CpfCnpj.Cnpj : rps.InfRps.Tomador.IdentificacaoTomador.CpfCnpj.Cpf))),
                                                                    (rps.InfRps.Tomador.IdentificacaoTomador.InscricaoMunicipal != "" ? (new XElement(tipos + "InscricaoMunicipal", rps.InfRps.Tomador.IdentificacaoTomador.InscricaoMunicipal)) : null)) : null),
                                                                    new XElement(tipos + "RazaoSocial", rps.InfRps.Tomador.RazaoSocial),
                                                                    new XElement(tipos + "Endereco",
                                                                                       new XElement(tipos + "Endereco", rps.InfRps.Tomador.Endereco.Endereco),
                                                                                       new XElement(tipos + "Numero", rps.InfRps.Tomador.Endereco.Numero),
                                                                                      (rps.InfRps.Tomador.Endereco.Complemento != "" ? new XElement(tipos + "Complemento", rps.InfRps.Tomador.Endereco.Complemento) : null),
                                                                                       new XElement(tipos + "Bairro", rps.InfRps.Tomador.Endereco.Bairro),
                                                                                       new XElement(tipos + "CodigoMunicipio", rps.InfRps.Tomador.Endereco.CodigoMunicipio),
                                                                                       new XElement(tipos + "Uf", rps.InfRps.Tomador.Endereco.Uf),
                                                                                       new XElement(tipos + "Cep", rps.InfRps.Tomador.Endereco.Cep))));


                    }
                    catch (Exception x)
                    {
                        throw new Exception("Nota : " + rps.InfRps.IdentificacaoRps.Numero + "Erro na geração do XML, Regiao:('Tomador')- "
                            + Environment.NewLine + "XML_Detalhes: "
                            + Environment.NewLine + x.Message);
                    }

                    #endregion

                    #region IntermediarioServico
                    try
                    {
                        if (rps.InfRps.IntermediarioServico != null)
                        {
                            conIntermediarioServico = (new XElement(tipos + "IntermediarioServico", new XElement(tipos + "RazaoSocial", rps.InfRps.IntermediarioServico.RazaoSocial),
                                                                                               new XElement(tipos + "CpfCnpj", (new XElement(tipos + (rps.InfRps.IntermediarioServico.CpfCnpj.Cnpj != null ? "Cnpj" : "Cpf"), (rps.InfRps.IntermediarioServico.CpfCnpj.Cnpj != null ? rps.InfRps.IntermediarioServico.CpfCnpj.Cnpj : rps.InfRps.IntermediarioServico.CpfCnpj.Cpf)))),
                                                                                               new XElement(tipos + "InscricaoMunicipal", rps.InfRps.IntermediarioServico.InscricaoMunicipal)));
                        }
                    }
                    catch (Exception x)
                    {
                        throw new Exception("Nota : " + rps.InfRps.IdentificacaoRps.Numero + "Erro na geração do XML, Regiao:('IntermediarioServico')- "
                            + Environment.NewLine + "XML_Detalhes: "
                            + Environment.NewLine + x.Message);
                    }
                    #endregion

                    #region ConstrucaoCivil

                    try
                    {
                        if (rps.InfRps.ConstrucaoCivil != null)
                        {
                            if ((rps.InfRps.ConstrucaoCivil.CodigoObra != "") && (rps.InfRps.ConstrucaoCivil.Art != ""))
                            {
                                conConstrucaoCivil = (new XElement(tipos + "ConstrucaoCivil", new XElement(tipos + "CodigoObra", rps.InfRps.ConstrucaoCivil.CodigoObra),
                                                                                          new XElement(tipos + "Art", rps.InfRps.ConstrucaoCivil.Art)));
                            }
                        }

                    }
                    catch (Exception x)
                    {
                        throw new Exception("Nota : " + rps.InfRps.IdentificacaoRps.Numero + "Erro na geração do XML, Regiao:('ConstrucaoCivil')- "
                            + Environment.NewLine + "XML_Detalhes: "
                            + Environment.NewLine + x.Message);
                    }
                    #endregion

                    try
                    {
                        if (conSubstituto != null)
                        {
                            conInfRps.Add(conSubstituto);
                        }
                        conInfRps.Add(conServico);
                        conInfRps.Add(conPrestador);
                        conInfRps.Add(conTomador);
                        if (conIntermediarioServico != null) { conInfRps.Add(conIntermediarioServico); }
                        if (conConstrucaoCivil != null) { conInfRps.Add(conConstrucaoCivil); }
                        conRps.Add(conInfRps);

                        // string nfe = Assinatura.ConfigurarArquivo(conRps.ToString(), "InfRps", cert);
                        // XmlDocument xml = new XmlDocument();
                        // xml.LoadXml(nfe);
                        //  conListaRps.Add(xml);
                        conListaRps.Add(conRps);


                        //Salva o Rps;
                        XDocument xdocsalvanfesemlot = new XDocument(conRps);
                        string sPasta = rps.InfRps.DataEmissao.ToString("MM/yy").Replace("/", "");
                        string sNomeArquivo = rps.InfRps.DataEmissao.ToString("MM/yy").Replace("/", "") + rps.InfRps.IdentificacaoRps.Serie + rps.InfRps.IdentificacaoRps.Numero;
                        DirectoryInfo dPastaData = new DirectoryInfo(Pastas.ENVIO + "\\Servicos\\" + sPasta);
                        if (!dPastaData.Exists) { dPastaData.Create(); }
                        xdocsalvanfesemlot.Save(Pastas.ENVIO + "\\Servicos\\" + sPasta + "\\" + sNomeArquivo + "-nfes.xml");

                        conRps = (new XElement(tipos + "Rps"));
                    }
                    catch (Exception x)
                    {
                        throw new Exception("Nota de Sequência - " + "sNota" + "Erro ao assinar a nfe de sequencia " + "sNota" + x.Message);
                    }
                }

                conLoteRps.Add(conListaRps);
                conEnviarLoteRpsEnvio.Add(conLoteRps);
                //Assina Arquivo
                belAssinaXml Assinatura = new belAssinaXml();
                string nfes = Assinatura.ConfigurarArquivo(conEnviarLoteRpsEnvio.ToString(), "LoteRps", Acesso.cert_NFs);
                sXmlLote = "<?xml version=\"1.0\" encoding=\"utf-8\"?>" + nfes;
                //Grava
                string sPathLote = Pastas.ENVIO + "\\Servicos\\" + "Lote_" + objLoteRpd.NumeroLote + ".xml";
                StreamWriter sw = new StreamWriter(sPathLote);
                sw.Write(sXmlLote);
                sw.Close();

                #region Valida_Xml


                try
                {
                    if (Acesso.tipoWsNfse == Acesso.TP_WS_NFSE.GINFES)
                    {
                        belValidaXml.ValidarXml("http://www.ginfes.com.br/servico_enviar_lote_rps_envio_v03.xsd", Pastas.SCHEMA_NFSE + "\\servico_enviar_lote_rps_envio_v03.xsd", sPathLote);
                    }
                    else if (Acesso.tipoWsNfse == Acesso.TP_WS_NFSE.TIPLAN)
                    {
                        belValidaXml.ValidarXml("http://www.abrasf.org.br/ABRASF/arquivos/nfse.xsd", Pastas.SCHEMA_NFSE + "\\TIPLAN\\nfse_municipal_v01.xsd", sPathLote);
                    }
                }
                catch (XmlException x)
                {
                    File.Delete(sPathLote);
                    throw new Exception(x.Message);
                }
                catch (XmlSchemaException x)
                {
                    File.Delete(sPathLote);
                    throw new Exception(x.Message);
                }
                #endregion

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void GerarArquivoXml2(tcLoteRps objLoteRpd)
        {
            try
            {
                List<string> ListaNfes = new List<string>();
                XDocument xdoc = new XDocument();
                XNamespace pf = "http://www.abrasf.org.br/ABRASF/arquivos/nfse.xsd";


                XContainer conEnviarLoteRpsEnvio = (new XElement(pf + "EnviarLoteRpsEnvio", new XAttribute("xmlns", "http://www.abrasf.org.br/ABRASF/arquivos/nfse.xsd")));

                XContainer conLoteRps = null;
                conLoteRps = (new XElement(pf+"LoteRps", new XAttribute("Id", Convert.ToInt32(objLoteRpd.NumeroLote)),
                                                                                     new XElement(pf+"NumeroLote", objLoteRpd.NumeroLote.ToString()),
                                                                                     new XElement(pf+"Cnpj", objLoteRpd.Cnpj.ToString()),
                                                                                     new XElement(pf+"InscricaoMunicipal", objLoteRpd.InscricaoMunicipal.ToString()),
                                                                                     new XElement(pf+"QuantidadeRps", objLoteRpd.QuantidadeRps.ToString())));

                XContainer conListaRps = (new XElement(pf+"ListaRps"));
                XContainer conRps = (new XElement(pf+"Rps"));
                XContainer conInfRps = null;
                XContainer conSubstituto = null;
                XContainer conServico = null;
                XContainer conPrestador = null;
                XContainer conTomador = null;
                XContainer conIntermediarioServico = null;
                XContainer conConstrucaoCivil = null;


                belAssinaXml Assinatura = new belAssinaXml();

                foreach (TcRps rps in objLoteRpd.Rps)
                {
                    #region IdentificacaoRps conRps
                    try
                    {
                        conInfRps = (new XElement(pf + "InfRps", new XElement(pf + "IdentificacaoRps",
                                                                                     new XElement(pf + "Numero", rps.InfRps.IdentificacaoRps.Numero),
                                                                                     new XElement(pf + "Serie", rps.InfRps.IdentificacaoRps.Serie),
                                                                                     new XElement(pf + "Tipo", rps.InfRps.IdentificacaoRps.Tipo)),
                                                                          new XElement(pf + "DataEmissao", daoUtil.GetDateServidor().Date.ToString("yyyy-MM-ddTHH:mm:ss")),
                                                                          new XElement(pf + "NaturezaOperacao", rps.InfRps.NaturezaOperacao),
                                                                         ((rps.InfRps.RegimeEspecialTributacao != 0) ? new XElement(pf + "RegimeEspecialTributacao", rps.InfRps.RegimeEspecialTributacao) : null),
                                                                          new XElement(pf + "OptanteSimplesNacional", rps.InfRps.OptanteSimplesNacional),
                                                                          new XElement(pf + "IncentivadorCultural", rps.InfRps.IncentivadorCultural),
                                                                          new XElement(pf + "Status", rps.InfRps.Status)));

                    }
                    catch (Exception x)
                    {
                        throw new Exception("Nota : " + rps.InfRps.IdentificacaoRps.Numero + "Erro na geração do XML, Regiao:('IdentificacaoRps')- "
                            + Environment.NewLine + "XML_Detalhes: "
                            + Environment.NewLine + x.Message);
                    }
                    #endregion

                    #region RpsSubstituido
                    if (rps.InfRps.RpsSubstituido != null)
                    {
                        try
                        {
                            conSubstituto = (new XElement("RpsSubstituido",
                                                         new XElement("Numero", rps.InfRps.RpsSubstituido.Numero),
                                                         new XElement("Serie", rps.InfRps.RpsSubstituido.Serie),
                                                         new XElement("Tipo", rps.InfRps.RpsSubstituido.Tipo)));
                        }
                        catch (Exception x)
                        {
                            throw new Exception("Nota : " + rps.InfRps.IdentificacaoRps.Numero + "Erro na geração do XML, Regiao:('RpsSubstituido')- "
                                + Environment.NewLine + "XML_Detalhes: "
                                + Environment.NewLine + x.Message);
                        }
                    }

                    #endregion

                    #region Servico
                    try
                    {
                        conServico = (new XElement(pf + "Servico", new XElement(pf + "Valores",
                                                    new XElement(pf + "ValorServicos", rps.InfRps.Servico.Valores.ValorServicos.ToString("#0.00").Replace(",", ".")),
                                                    ((rps.InfRps.Servico.Valores.ValorDeducoes != 0) ? new XElement(pf + "ValorDeducoes", rps.InfRps.Servico.Valores.ValorDeducoes.ToString("#0.00").Replace(",", ".")) : null),
                                                    ((rps.InfRps.Servico.Valores.ValorPis != null) ? new XElement(pf + "ValorPis", rps.InfRps.Servico.Valores.ValorPis.ToString("#0.00").Replace(",", ".")) : null),
                                                    ((rps.InfRps.Servico.Valores.ValorCofins != null) ? new XElement(pf + "ValorCofins", rps.InfRps.Servico.Valores.ValorCofins.ToString("#0.00").Replace(",", ".")) : null),
                                                    ((rps.InfRps.Servico.Valores.ValorInss != null) ? new XElement(pf + "ValorInss", rps.InfRps.Servico.Valores.ValorInss.ToString("#0.00").Replace(",", ".")) : null),
                                                    ((rps.InfRps.Servico.Valores.ValorIr != null) ? new XElement(pf + "ValorIr", rps.InfRps.Servico.Valores.ValorIr.ToString("#0.00").Replace(",", ".")) : null),
                                                    ((rps.InfRps.Servico.Valores.ValorCsll != null) ? new XElement(pf + "ValorCsll", rps.InfRps.Servico.Valores.ValorCsll.ToString("#0.00").Replace(",", ".")) : null),
                                                                                                      new XElement(pf + "IssRetido", rps.InfRps.Servico.Valores.IssRetido),
                                                    ((rps.InfRps.Servico.Valores.ValorIss != null) ? new XElement(pf + "ValorIss", rps.InfRps.Servico.Valores.ValorIss.ToString("#0.00").Replace(",", ".")) : null),
                                                    ((rps.InfRps.Servico.Valores.ValorIssRetido != null) ? new XElement(pf + "ValorIssRetido", rps.InfRps.Servico.Valores.ValorIssRetido.ToString("#0.00").Replace(",", ".")) : null),
                                                    ((rps.InfRps.Servico.Valores.OutrasRetencoes != 0) ? new XElement(pf + "OutrasRetencoes", rps.InfRps.Servico.Valores.OutrasRetencoes.ToString("#0.00").Replace(",", ".")) : null),
                                                    ((rps.InfRps.Servico.Valores.BaseCalculo != 0) ? new XElement(pf + "BaseCalculo", rps.InfRps.Servico.Valores.BaseCalculo.ToString("#0.00").Replace(",", ".")) : null),
                                                    ((rps.InfRps.Servico.Valores.Aliquota != null) ? new XElement(pf + "Aliquota", (rps.InfRps.Servico.Valores.Aliquota / 100).ToString("#0.0000").Replace(",", ".")) : null),
                                                    ((rps.InfRps.Servico.Valores.ValorLiquidoNfse != 0) ? new XElement(pf + "ValorLiquidoNfse", rps.InfRps.Servico.Valores.ValorLiquidoNfse.ToString("#0.00").Replace(",", ".")) : null),
                                                    ((rps.InfRps.Servico.Valores.DescontoCondicionado != 0) ? new XElement(pf + "DescontoCondicionado", rps.InfRps.Servico.Valores.DescontoCondicionado.ToString("#0.00").Replace(",", ".")) : null),
                                                    ((rps.InfRps.Servico.Valores.DescontoIncondicionado != 0) ? new XElement(pf + "DescontoIncondicionado", rps.InfRps.Servico.Valores.DescontoIncondicionado.ToString("#0.00").Replace(",", ".")) : null)),
                                                                                         new XElement(pf + "ItemListaServico", rps.InfRps.Servico.ItemListaServico),
                                       ((rps.InfRps.Servico.CodigoCnae != "") ? new XElement(pf + "CodigoCnae", rps.InfRps.Servico.CodigoCnae) : null),
                                       (((rps.InfRps.Servico.CodigoTributacaoMunicipio != "") && (rps.InfRps.Servico.CodigoTributacaoMunicipio != "0")) ? new XElement(pf + "CodigoTributacaoMunicipio", rps.InfRps.Servico.CodigoTributacaoMunicipio) : null),
                                                                                         new XElement(pf + "Discriminacao", rps.InfRps.Servico.Discriminacao),
                                       new XElement(pf + "CodigoMunicipio", rps.InfRps.Servico.CodigoMunicipio)));
                    }
                    catch (Exception x)
                    {
                        throw new Exception("Nota : " + rps.InfRps.IdentificacaoRps.Numero + "Erro na geração do XML, Regiao:('Servico')- "
                            + Environment.NewLine + "XML_Detalhes: "
                            + Environment.NewLine + x.Message);
                    }
                    #endregion

                    #region Prestador
                    try
                    {
                        conPrestador = (new XElement(pf + "Prestador", new XElement(pf + "Cnpj", rps.InfRps.Prestador.Cnpj),
                                                                      ((rps.InfRps.Prestador.InscricaoMunicipal != "") ? new XElement(pf + "InscricaoMunicipal", rps.InfRps.Prestador.InscricaoMunicipal) : null)));

                    }
                    catch (Exception x)
                    {
                        throw new Exception("Nota : " + rps.InfRps.IdentificacaoRps.Numero + "Erro na geração do XML, Regiao:('Prestador')- "
                            + Environment.NewLine + "XML_Detalhes: "
                            + Environment.NewLine + x.Message);
                    }
                    #endregion

                    #region Tomador
                    try
                    {
                        conTomador = (new XElement(pf + "Tomador", ((rps.InfRps.Tomador.IdentificacaoTomador != null) ? new XElement(pf + "IdentificacaoTomador", new XElement(pf + "CpfCnpj",
                                                                                                               new XElement(pf + (rps.InfRps.Tomador.IdentificacaoTomador.CpfCnpj.Cnpj != "" ? "Cnpj" : "Cpf"), (rps.InfRps.Tomador.IdentificacaoTomador.CpfCnpj.Cnpj != "" ? rps.InfRps.Tomador.IdentificacaoTomador.CpfCnpj.Cnpj : rps.InfRps.Tomador.IdentificacaoTomador.CpfCnpj.Cpf))),
                                                                    (rps.InfRps.Tomador.IdentificacaoTomador.InscricaoMunicipal != "" ? (new XElement(pf + "InscricaoMunicipal", rps.InfRps.Tomador.IdentificacaoTomador.InscricaoMunicipal)) : null)) : null),
                                                                    new XElement(pf + "RazaoSocial", rps.InfRps.Tomador.RazaoSocial),
                                                                    new XElement(pf + "Endereco",
                                                                                       new XElement(pf + "Endereco", rps.InfRps.Tomador.Endereco.Endereco),
                                                                                       new XElement(pf + "Numero", rps.InfRps.Tomador.Endereco.Numero),
                                                                                      (rps.InfRps.Tomador.Endereco.Complemento != "" ? new XElement(pf + "Complemento", rps.InfRps.Tomador.Endereco.Complemento) : null),
                                                                                       new XElement(pf + "Bairro", rps.InfRps.Tomador.Endereco.Bairro),
                                                                                       new XElement(pf + "CodigoMunicipio", rps.InfRps.Tomador.Endereco.CodigoMunicipio),
                                                                                       new XElement(pf + "Uf", rps.InfRps.Tomador.Endereco.Uf),
                                                                                       new XElement(pf + "Cep", rps.InfRps.Tomador.Endereco.Cep))));


                    }
                    catch (Exception x)
                    {
                        throw new Exception("Nota : " + rps.InfRps.IdentificacaoRps.Numero + "Erro na geração do XML, Regiao:('Tomador')- "
                            + Environment.NewLine + "XML_Detalhes: "
                            + Environment.NewLine + x.Message);
                    }

                    #endregion

                    #region IntermediarioServico
                    try
                    {
                        if (rps.InfRps.IntermediarioServico != null)
                        {
                            conIntermediarioServico = (new XElement(pf + "IntermediarioServico", new XElement(pf + "RazaoSocial", rps.InfRps.IntermediarioServico.RazaoSocial),
                                                                                               new XElement(pf + "CpfCnpj", (new XElement((rps.InfRps.IntermediarioServico.CpfCnpj.Cnpj != null ? "Cnpj" : "Cpf"), (rps.InfRps.IntermediarioServico.CpfCnpj.Cnpj != null ? rps.InfRps.IntermediarioServico.CpfCnpj.Cnpj : rps.InfRps.IntermediarioServico.CpfCnpj.Cpf)))),
                                                                                               new XElement(pf + "InscricaoMunicipal", rps.InfRps.IntermediarioServico.InscricaoMunicipal)));
                        }
                    }
                    catch (Exception x)
                    {
                        throw new Exception("Nota : " + rps.InfRps.IdentificacaoRps.Numero + "Erro na geração do XML, Regiao:('IntermediarioServico')- "
                            + Environment.NewLine + "XML_Detalhes: "
                            + Environment.NewLine + x.Message);
                    }
                    #endregion

                    #region ConstrucaoCivil

                    try
                    {
                        if (rps.InfRps.ConstrucaoCivil != null)
                        {
                            if ((rps.InfRps.ConstrucaoCivil.CodigoObra != "") && (rps.InfRps.ConstrucaoCivil.Art != ""))
                            {
                                conConstrucaoCivil = (new XElement(pf + "ConstrucaoCivil", new XElement(pf + "CodigoObra", rps.InfRps.ConstrucaoCivil.CodigoObra),
                                                                                          new XElement(pf + "Art", rps.InfRps.ConstrucaoCivil.Art)));
                            }
                        }

                    }
                    catch (Exception x)
                    {
                        throw new Exception("Nota : " + rps.InfRps.IdentificacaoRps.Numero + "Erro na geração do XML, Regiao:('ConstrucaoCivil')- "
                            + Environment.NewLine + "XML_Detalhes: "
                            + Environment.NewLine + x.Message);
                    }
                    #endregion

                    try
                    {
                        if (conSubstituto != null)
                        {
                            conInfRps.Add(conSubstituto);
                        }
                        conInfRps.Add(conServico);
                        conInfRps.Add(conPrestador);
                        conInfRps.Add(conTomador);
                        if (conIntermediarioServico != null) { conInfRps.Add(conIntermediarioServico); }
                        if (conConstrucaoCivil != null) { conInfRps.Add(conConstrucaoCivil); }
                        conRps.Add(conInfRps);


                        conListaRps.Add(conRps);


                        //Salva o Rps;
                        XDocument xdocsalvanfesemlot = new XDocument(conRps);
                        string sPasta = rps.InfRps.DataEmissao.ToString("MM/yy").Replace("/", "");
                        string sNomeArquivo = rps.InfRps.DataEmissao.ToString("MM/yy").Replace("/", "") + rps.InfRps.IdentificacaoRps.Serie + rps.InfRps.IdentificacaoRps.Numero;
                        DirectoryInfo dPastaData = new DirectoryInfo(Pastas.ENVIO + "\\Servicos\\" + sPasta);
                        if (!dPastaData.Exists) { dPastaData.Create(); }
                        xdocsalvanfesemlot.Save(Pastas.ENVIO + "\\Servicos\\" + sPasta + "\\" + sNomeArquivo + "-nfes.xml");

                        conRps = (new XElement("Rps"));
                    }
                    catch (Exception x)
                    {
                        throw new Exception("Nota de Sequência - " + "sNota" + "Erro ao assinar a nfe de sequencia " + "sNota" + x.Message);
                    }
                }

                conLoteRps.Add(conListaRps);
                conEnviarLoteRpsEnvio.Add(conLoteRps);
                //Assina Arquivo
                string nfes = Assinatura.ConfigurarArquivo(conEnviarLoteRpsEnvio.ToString(), "LoteRps", Acesso.cert_NFs);
                sXmlLote = "<?xml version=\"1.0\" encoding=\"utf-8\"?>" + nfes;
                //Grava
                string sPathLote = Pastas.ENVIO + "\\Servicos\\" + "Lote_" + objLoteRpd.NumeroLote + ".xml";
                StreamWriter sw = new StreamWriter(sPathLote);
                sw.Write(sXmlLote);
                sw.Close();

                #region Valida_Xml


                try
                {
                    if (Acesso.tipoWsNfse == Acesso.TP_WS_NFSE.GINFES)
                    {
                        belValidaXml.ValidarXml("http://www.ginfes.com.br/servico_enviar_lote_rps_envio_v03.xsd", Pastas.SCHEMA_NFSE + "\\servico_enviar_lote_rps_envio_v03.xsd", sPathLote);
                    }
                    else
                    {
                        belValidaXml.ValidarXml("http://www.nfe.com.br/WSNacional/XSD/1/nfse_municipal_v01.xsd", Pastas.SCHEMA_NFSE + "\\TIPLAN\\nfse_municipal_v01.xsd", sPathLote);
                    }
                }
                catch (XmlException x)
                {
                    File.Delete(sPathLote);
                    throw new Exception(x.Message);
                }
                catch (XmlSchemaException x)
                {
                    File.Delete(sPathLote);
                    throw new Exception(x.Message);
                }
                #endregion

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



    }
}
