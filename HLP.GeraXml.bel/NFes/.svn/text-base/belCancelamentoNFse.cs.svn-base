using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HLP.GeraXml.Comum.Static;
using System.Xml;
using System.Xml.Linq;
using System.IO;
using HLP.GeraXml.Comum;
using HLP.GeraXml.dao.NFes;
using FirebirdSql.Data.FirebirdClient;
using System.Data;

namespace HLP.GeraXml.bel.NFes
{
    public class belCancelamentoNFse : daoCancelamentoNFse
    {
        public string cod { get; set; }
        public string msg { get; set; }
        public string solucao { get; set; }
        public bool bNotaCancelada = false;

        public List<belCancelamentoNFse> RetListaErros()
        {
            try
            {
                List<belCancelamentoNFse> objLista = new List<belCancelamentoNFse>();

                objLista.Add(new belCancelamentoNFse
                {
                    cod = "E1",
                    msg = "Assinatura do Hash não confere",
                    solucao = "Reenvie asssinatura do Hash conforme algoritmo estabelecido no Manual de Instrução da NFS-e"
                });
                objLista.Add(new belCancelamentoNFse
                {
                    cod = "E2",
                    msg = "Mês de competência superior ao de emissão do RPS ou da Nota",
                    solucao = "Informe um mês de competência inferior ou igual ao de emissão do RPS ou da Nota."
                });
                objLista.Add(new belCancelamentoNFse
                {
                    cod = "E3",
                    msg = "Natureza da operação não informada.",
                    solucao = "Utilize um dos tipos: 01 – Tributação no municipio; 02 – Tributação fora do municipio; 03 – Isenção; 04 – Imune; 05 – Exigibilidade suspensa por decisão judicial; 06 – Exigibilidade suspensa por procedimento administrativo."
                });
                objLista.Add(new belCancelamentoNFse
                {
                    cod = "E4",
                    msg = "Esse RPS não foi enviado para a nossa base de dados",
                    solucao = "Envie o RPS para emissão da NFS-e."
                });
                objLista.Add(new belCancelamentoNFse
                {
                    cod = "E5",
                    msg = "O número da NFS-E substituída informado não existe na base de dados do município.",
                    solucao = "Informe um número de NFS-E substituída que já tenha sido emitida."
                });
                objLista.Add(new belCancelamentoNFse
                {
                    cod = "E6",
                    msg = "Essa NFS-e não pode ser cancelada através desse serviço, pois há crédito informado",
                    solucao = "O cancelamento de uma NFS-e com crédito deve ser feito através de processo administrativo aberto em uma repartição fazendária."
                });
                objLista.Add(new belCancelamentoNFse
                {
                    cod = "E7",
                    msg = "Essa NFS-e já foi substituída",
                    solucao = "Confira e informe novamente os dados da NFS-e que deseja substituir."
                });
                objLista.Add(new belCancelamentoNFse
                {
                    cod = "E8",
                    msg = "Campo de optante pelo simples nacional não informado",
                    solucao = "Utilize um dos tipos: 1 – Sim; 2 - Não."
                });
                objLista.Add(new belCancelamentoNFse
                {
                    cod = "E9",
                    msg = "Campo de incentivador cultural não informado",
                    solucao = "Utilize um dos tipos: 1 – Sim; 2 - Não"
                });
                objLista.Add(new belCancelamentoNFse
                {
                    cod = "E10",
                    msg = "RPS já informado.",
                    solucao = "Para essa Inscrição Municipal/CNPJ já existe um RPS informado com o mesmo número, série e tipo."
                });
                objLista.Add(new belCancelamentoNFse
                {
                    cod = "E11",
                    msg = "Número do RPS não informado",
                    solucao = "Informe o número do RPS"
                });
                objLista.Add(new belCancelamentoNFse
                {
                    cod = "E13",
                    msg = "Campo tipo do RPS inválido.",
                    solucao = "Utilize um dos tipos especificados: 'RPS', 'RPSC'ou 'RPSM'."
                });
                objLista.Add(new belCancelamentoNFse
                {
                    cod = "E14",
                    msg = "Data da emissão do RPS não informada",
                    solucao = "Informe a Data da emissão do RPS no formato date"
                });
                objLista.Add(new belCancelamentoNFse
                {
                    cod = "E30",
                    msg = "Item da lista de serviço inexistente",
                    solucao = "Consulte a legislação vigente."
                });
                objLista.Add(new belCancelamentoNFse
                {
                    cod = "E40",
                    msg = "Valor do ISS retido não informado.",
                    solucao = "O valor do ISS retido deve ser informado quando o campo 'IssRetido' for marcado com 1- Sim."
                });
                objLista.Add(new belCancelamentoNFse
                {
                    cod = "E57",
                    msg = "Bairro não corresponde ao CEP informado",
                    solucao = "Corrija o Bairro ou o CEP do tomador do serviço"
                });
               
                return objLista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string CancelaNfes(TcPedidoCancelamento objPedCanc)
        {
            try
            {
                string sRet = "";

                if (Acesso.tipoWsNfse == Acesso.TP_WS_NFSE.GINFES)
                {
                    if (Acesso.TP_AMB_SERV == 2)
                    {
                        WebService.Itu_servicos_Homologacao.ServiceGinfesImplService objtrans = new WebService.Itu_servicos_Homologacao.ServiceGinfesImplService();
                        objtrans.ClientCertificates.Add(Acesso.cert_NFs);
                        objtrans.Timeout = 60000;
                        sRet = objtrans.CancelarNfse(MontaXmlCancelamentoHomo(objPedCanc));
                    }
                    else if (Acesso.TP_AMB_SERV == 1)
                    {
                        WebService.Itu_servicos_Producao.ServiceGinfesImplService objtrans = new WebService.Itu_servicos_Producao.ServiceGinfesImplService();
                        objtrans.ClientCertificates.Add(Acesso.cert_NFs);
                        objtrans.Timeout = 60000;
                        sRet = objtrans.CancelarNfse(MontaXmlCancelamento(objPedCanc));

                    }
                    else
                    {
                        throw new Exception("Cadastro de Empresa não configurado para enviar NFe-serviço");
                    }
                }
                else
                {
                    WebService.riodasostras_Producao.Nfse nfse = new WebService.riodasostras_Producao.Nfse();
                    nfse.ClientCertificates.Add(Acesso.cert_NFs);
                    nfse.Timeout = 60000;
                    sRet = nfse.CancelarNfse(MontaXmlCancelamento2(objPedCanc));
                }

                return sRet;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string ConfiguraMsgRetornCancelamento2(string sRet)
        {
            string sMsg = "";
            XmlDocument xmlRet = new XmlDocument();
            xmlRet.LoadXml(sRet);
            XmlNodeList xNodeCanc = xmlRet.GetElementsByTagName("Cancelamento");
            XmlNodeList xNodeMessageRet = xmlRet.GetElementsByTagName("MensagemRetorno");

            if (xNodeCanc.Count > 0)
            {
                bNotaCancelada = true;
                sMsg = "Cancelamento efetuado com sucesso:{0}Data:{1}{0}Confirmação:{2}";
                sMsg = string.Format(sMsg,
                    Environment.NewLine,
                    xmlRet.GetElementsByTagName("DataHoraCancelamento")[0].InnerText,
                    xmlRet.GetElementsByTagName("Confirmacao")[0].Attributes[0].Value).ToString();
            }
            else if (xNodeMessageRet.Count > 0)
            {
                sMsg = "{2}Código: {0}{2}{2}Mensagem: {1}{2}{2}";
                sMsg = string.Format(sMsg,
                          xNodeMessageRet[0]["Codigo"].InnerText,
                          xNodeMessageRet[0]["Mensagem"].InnerText,
                          Environment.NewLine);
                if (xNodeMessageRet[0]["Correcao"] != null)
                {
                    sMsg += "Correção:" + xNodeMessageRet[0]["Correcao"].InnerText;
                }
            }
            return sMsg;
        }

        public string ConfiguraMsgRetornoCancelamento(string sRet)
        {
            try
            {
                string sMsg = "";
                XmlDocument xmlRet = new XmlDocument();
                xmlRet.LoadXml(sRet);

                XmlNodeList xNodeListns2 = xmlRet.GetElementsByTagName("ns2:MensagemRetorno");
                XmlNodeList xNodeList = xmlRet.GetElementsByTagName("MensagemRetorno");
                XmlNodeList xNodeSucesso = xmlRet.GetElementsByTagName("ns2:Sucesso");
                if (xNodeSucesso.Count > 0)
                {
                    if (xmlRet.GetElementsByTagName("ns2:Sucesso")[0].InnerText.Equals("true"))
                    {
                        bNotaCancelada = true;
                        sMsg = "{2}Sucesso: {0}{2}{2}Mensagem: {1}{2}{2}";
                        sMsg = string.Format(sMsg, xmlRet.GetElementsByTagName("ns2:Sucesso")[0].InnerText,
                                  xNodeListns2[0]["ns3:Mensagem"].InnerText,
                                  Environment.NewLine);

                    }
                }
                else if (xNodeListns2.Count > 0)
                {
                    sMsg = "{3}Código: {0}{3}{3}Mensagem: {1}{3}{3}Correção: {2}{3}";
                    sMsg = string.Format(sMsg, xNodeListns2[0]["ns3:Codigo"].InnerText,
                              xNodeListns2[0]["ns3:Mensagem"].InnerText,
                              xNodeListns2[0]["ns3:Correcao"].InnerText, Environment.NewLine);
                }
                else if (xNodeList.Count > 0)
                {
                    sMsg = "{3}Código: {0}{3}{3}Mensagem: {1}{3}{3}Correção: {2}{3}";
                    sMsg = string.Format(sMsg, xNodeList[0]["Codigo"].InnerText,
                              xNodeList[0]["Mensagem"].InnerText,
                              xNodeList[0]["Correcao"].InnerText, Environment.NewLine);
                }
                return sMsg;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        private string MontaXmlCancelamento2(TcPedidoCancelamento objPedCanc)
        {
            try
            {
                XNamespace pf = "http://www.abrasf.org.br/ABRASF/arquivos/nfse.xsd";
                XContainer conCancelarNfseEnvio = (new XElement(pf + "CancelarNfseEnvio", new XAttribute("xmlns", "http://www.abrasf.org.br/ABRASF/arquivos/nfse.xsd")));
                XContainer conPedido = new XElement(pf + "Pedido", new XAttribute("xmlns", "http://www.abrasf.org.br/ABRASF/arquivos/nfse.xsd"));
                XContainer conInfPedido = null;

                conInfPedido = new XElement(pf + "InfPedidoCancelamento", new XAttribute("Id", objPedCanc.InfPedidoCancelamento.Id),
                                 new XElement(pf + "IdentificacaoNfse",
                                 new XElement(pf + "Numero", objPedCanc.InfPedidoCancelamento.IdentificacaoNfse.Numero),
                                 new XElement(pf + "Cnpj", objPedCanc.InfPedidoCancelamento.IdentificacaoNfse.Cnpj),
                                 ((objPedCanc.InfPedidoCancelamento.IdentificacaoNfse.InscricaoMunicipal != "") ? new XElement(pf + "InscricaoMunicipal", objPedCanc.InfPedidoCancelamento.IdentificacaoNfse.InscricaoMunicipal) : null),
                                 new XElement(pf + "CodigoMunicipio", Acesso.cUF)),
                 new XElement(pf + "CodigoCancelamento", objPedCanc.InfPedidoCancelamento.CodigoCancelamento));

                conPedido.Add(conInfPedido);
                conCancelarNfseEnvio.Add(conPedido);

                DirectoryInfo dPastaData = new DirectoryInfo(Pastas.PROTOCOLOS + "\\Servicos");
                if (!dPastaData.Exists) { dPastaData.Create(); }
                XmlDocument xdocCanc = new XmlDocument();
                xdocCanc.LoadXml(conCancelarNfseEnvio.ToString());
                string sCaminho = Pastas.PROTOCOLOS + "\\Servicos\\ped_canc_" + objPedCanc.InfPedidoCancelamento.IdentificacaoNfse.Numero + ".xml";
                xdocCanc.Save(sCaminho);

                // belValidaXml.ValidarXml("http://www.abrasf.org.br/ABRASF/arquivos/nfse.xsd", Pastas.SCHEMA_NFSE + "\\TIPLAN\\nfse_municipal_v01.xsd", sCaminho);

                return "<?xml version=\"1.0\" encoding=\"utf-8\"?>" + conCancelarNfseEnvio.ToString();
            }
            catch (Exception ex)
            {
                return "";
                throw ex;
            }
        }

        private string MontaXmlCancelamento(TcPedidoCancelamento objPedCanc)
        {
            try
            {
                XNamespace pf = "http://www.ginfes.com.br/servico_cancelar_nfse_envio";
                XNamespace tipos = "http://www.ginfes.com.br/tipos";
                XContainer conCancelarNfseEnvio = null;
                conCancelarNfseEnvio = (new XElement(pf + "CancelarNfseEnvio", new XAttribute("xmlns", "http://www.ginfes.com.br/servico_cancelar_nfse_envio"),
                                            new XAttribute(XNamespace.Xmlns + "tipos", "http://www.ginfes.com.br/tipos"),
                                        new XElement(pf + "Prestador", new XElement(tipos + "Cnpj", objPedCanc.InfPedidoCancelamento.IdentificacaoNfse.Cnpj),
                                                                      ((objPedCanc.InfPedidoCancelamento.IdentificacaoNfse.InscricaoMunicipal != "") ? new XElement(tipos + "InscricaoMunicipal", objPedCanc.InfPedidoCancelamento.IdentificacaoNfse.InscricaoMunicipal) : null)),
                                        new XElement(pf + "NumeroNfse", objPedCanc.InfPedidoCancelamento.IdentificacaoNfse.Numero)));


                belAssinaXml Assinatura = new belAssinaXml();
                string sArquivo = Assinatura.ConfigurarArquivo(conCancelarNfseEnvio.ToString(), "NumeroNfse", Acesso.cert_NFs);


                DirectoryInfo dPastaData = new DirectoryInfo(Pastas.PROTOCOLOS + "\\Servicos");
                if (!dPastaData.Exists) { dPastaData.Create(); }
                XmlDocument xdocCanc = new XmlDocument();
                xdocCanc.LoadXml(sArquivo);
                string sCaminho = Pastas.PROTOCOLOS + "\\Servicos\\ped_canc_" + objPedCanc.InfPedidoCancelamento.IdentificacaoNfse.Numero + ".xml";
                xdocCanc.Save(sCaminho);

                // belValidaXml.ValidarXml("http://www.ginfes.com.br/servico_cancelar_nfse_envio.xsd", Pastas.SCHEMA_NFSE + "\\servico_cancelar_nfse_envio_v03.xsd", sCaminho);
                sArquivo = "<?xml version=\"1.0\" encoding=\"utf-8\"?>" + sArquivo;



                return sArquivo;
            }
            catch (Exception ex)
            {
                return "";
                throw ex;
            }
        }

        private string MontaXmlCancelamentoHomo(TcPedidoCancelamento objPedCanc)
        {
            try
            {
                XNamespace pf = "http://www.ginfes.com.br/servico_cancelar_nfse_envio";
                XContainer conCancelarNfseEnvio = null;
                conCancelarNfseEnvio = (new XElement(pf + "CancelarNfseEnvio", new XAttribute("xmlns", "http://www.ginfes.com.br/servico_cancelar_nfse_envio"),
                                        new XElement(pf + "Prestador", new XElement(pf + "Cnpj", objPedCanc.InfPedidoCancelamento.IdentificacaoNfse.Cnpj),
                                                                      ((objPedCanc.InfPedidoCancelamento.IdentificacaoNfse.InscricaoMunicipal != "") ? new XElement(pf + "InscricaoMunicipal", objPedCanc.InfPedidoCancelamento.IdentificacaoNfse.InscricaoMunicipal) : null)),
                                        new XElement(pf + "NumeroNfse", objPedCanc.InfPedidoCancelamento.IdentificacaoNfse.Numero)));


                belAssinaXml Assinatura = new belAssinaXml();
                string sArquivo = Assinatura.ConfigurarArquivo(conCancelarNfseEnvio.ToString(), "NumeroNfse", Acesso.cert_NFs);

                DirectoryInfo dPastaData = new DirectoryInfo(Pastas.PROTOCOLOS + "\\Servicos");
                if (!dPastaData.Exists) { dPastaData.Create(); }
                XmlDocument xdocCanc = new XmlDocument();
                xdocCanc.LoadXml(sArquivo);
                string sCaminho = Pastas.PROTOCOLOS + "\\Servicos\\ped_canc_" + objPedCanc.InfPedidoCancelamento.IdentificacaoNfse.Numero + ".xml";
                xdocCanc.Save(sCaminho);


                //belValidaXml.ValidarXml("http://www.ginfes.com.br/servico_cancelar_nfse_envio.xsd", Pastas.SCHEMA_NFSE + "\\servico_cancelar_nfse_envio.xsd", sCaminho);

                sArquivo = "<?xml version=\"1.0\" encoding=\"utf-8\"?>" + sArquivo;

                return sArquivo;
            }
            catch (Exception ex)
            {
                return "";
                throw ex;
            }
        }

        private string MontaXmlCancelamentoV3(TcPedidoCancelamento objPedCanc)
        {
            try
            {
                XNamespace pf = "http://www.ginfes.com.br/servico_cancelar_nfse_envio_v03.xsd";
                XNamespace tipos = "http://www.ginfes.com.br/tipos_v03.xsd";
                XNamespace xsi = "http://www.w3.org/2001/XMLSchema-instance";

                XContainer conCancelarNfseEnvio = null;
                conCancelarNfseEnvio = (new XElement(pf + "CancelarNfseEnvio", new XAttribute(xsi + "schemaLocation", "http://www.ginfes.com.br/servico_cancelar_nfse_envio_v03.xsd"),
                                                                              new XAttribute("xmlns", "http://www.ginfes.com.br/servico_cancelar_nfse_envio_v03.xsd"),
                                                                              new XAttribute(XNamespace.Xmlns + "tipos", "http://www.ginfes.com.br/tipos_v03.xsd"),
                                                                              new XAttribute(XNamespace.Xmlns + "xsi", "http://www.w3.org/2001/XMLSchema-instance"),
                                            new XElement(pf + "Pedido",
                                                new XElement(tipos + "InfPedidoCancelamento",
                                                     new XElement(tipos + "IdentificacaoNfse",
                                                         new XElement(tipos + "Numero", objPedCanc.InfPedidoCancelamento.IdentificacaoNfse.Numero),
                                                         new XElement(tipos + "Cnpj", objPedCanc.InfPedidoCancelamento.IdentificacaoNfse.Cnpj),
                                                         new XElement(tipos + "InscricaoMunicipal", objPedCanc.InfPedidoCancelamento.IdentificacaoNfse.InscricaoMunicipal),
                                                         new XElement(tipos + "CodigoMunicipio", objPedCanc.InfPedidoCancelamento.IdentificacaoNfse.CodigoMunicipio)),
                                                     new XElement(tipos + "CodigoCancelamento", objPedCanc.InfPedidoCancelamento.CodigoCancelamento)))));



                belAssinaXml Assinatura = new belAssinaXml();
                string sArquivo = Assinatura.ConfigurarArquivo(conCancelarNfseEnvio.ToString(), "tipos:InfPedidoCancelamento", Acesso.cert_NFs);

                DirectoryInfo dPastaData = new DirectoryInfo(Pastas.PROTOCOLOS + "\\Servicos");
                if (!dPastaData.Exists) { dPastaData.Create(); }
                XmlDocument xdocCanc = new XmlDocument();
                xdocCanc.LoadXml(sArquivo);
                string sCaminho = Pastas.PROTOCOLOS + "\\Servicos\\ped_canc_" + objPedCanc.InfPedidoCancelamento.IdentificacaoNfse.Numero + ".xml";
                xdocCanc.Save(sCaminho);


                // belValidaXml.ValidarXml("http://www.ginfes.com.br/servico_cancelar_nfse_envio.xsd", Pastas.SCHEMA_NFSE + "\\servico_cancelar_nfse_envio_v03.xsd", sCaminho);

                return "<?xml version=\"1.0\" encoding=\"utf-8\"?>" + sArquivo;
            }
            catch (Exception ex)
            {
                return "";
                throw ex;
            }
        }

        public TcPedidoCancelamento BuscaDadosParaCancelamento(string sCodCancelamento, string sSequencia)
        {
            try
            {
                TcPedidoCancelamento objCancelamento = new TcPedidoCancelamento();
                objCancelamento.InfPedidoCancelamento = new tcInfPedidoCancelamento();

                DataTable dt = BuscaDadosCancelamento(sSequencia);
                foreach (DataRow dr in dt.Rows)
                {
                    objCancelamento.InfPedidoCancelamento.CodigoCancelamento = sCodCancelamento;
                    objCancelamento.InfPedidoCancelamento.IdentificacaoNfse = new tcIdentificacaoNfse();
                    objCancelamento.InfPedidoCancelamento.IdentificacaoNfse.CodigoMunicipio = dr["cd_municipio"].ToString();
                    objCancelamento.InfPedidoCancelamento.IdentificacaoNfse.Numero = dr["cd_numero_nfse"].ToString();
                    objCancelamento.InfPedidoCancelamento.IdentificacaoNfse.Cnpj = dr["Cnpj"].ToString();
                    objCancelamento.InfPedidoCancelamento.IdentificacaoNfse.InscricaoMunicipal = dr["cd_inscrmu"].ToString();
                }
                return objCancelamento;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void CancelarNFseSistema(string sNumNfse)
        {
            try
            {
                CancelarNFse(sNumNfse);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
