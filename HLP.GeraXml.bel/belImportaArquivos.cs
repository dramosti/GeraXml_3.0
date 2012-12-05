using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using HLP.GeraXml.Comum.Static;
using System.Xml;
using HLP.GeraXml.Comum;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace HLP.GeraXml.bel
{
    public static class belImportaArquivos
    {


        public static void ImportaArquivosConfig()
        {
            try
            {
                belConfiguracao objbelConfiguracao = new belConfiguracao();

                DirectoryInfo dPasta = new DirectoryInfo(Pastas.PASTA_XML_CONFIG);
                FileInfo[] finfo = dPasta.GetFiles("*.xml");

                foreach (FileInfo item in finfo)
                {
                    XDocument doc = XDocument.Load(item.FullName);
                    if (doc.Element("nfe_configuracoes") != null)
                    {
                        objbelConfiguracao = new belConfiguracao();
                        XElement e = doc.Element("nfe_configuracoes");

                        objbelConfiguracao.CAMINHO_PADRAO = e.Element("CaminhoPadrao") != null ? e.Element("CaminhoPadrao").Value : null;
                        objbelConfiguracao.CAMINHO_BANCO_DADOS = e.Element("BancoDados") != null ? e.Element("BancoDados").Value : null;
                        objbelConfiguracao.LOGOTIPO = e.Element("Logotipo") != null ? e.Element("Logotipo").Value : null;
                        objbelConfiguracao.QTDE_CASAS_PRODUTOS = e.Element("QtdeCasasProdutos") != null ? e.Element("QtdeCasasProdutos").Value : null;
                        objbelConfiguracao.QTDE_CASAS_VL_UNIT = e.Element("QtdeCasasVlUnit") != null ? e.Element("QtdeCasasVlUnit").Value : null;
                        objbelConfiguracao.GRAVA_NUM_NF_DUPL = e.Element("GravaNumNFseDupl") != null ? e.Element("GravaNumNFseDupl").Value : null;
                        objbelConfiguracao.VISUALIZA_HORA_DANFE = e.Element("VisualizaHoraDanfe") != null ? e.Element("VisualizaHoraDanfe").Value : null;
                        objbelConfiguracao.VISUALIZA_DATA_DANFE = e.Element("VisualizaDataDanfe") != null ? e.Element("VisualizaDataDanfe").Value : null;
                        objbelConfiguracao.USA_DANFE_SIMPLIFICADA = e.Element("UsaDanfeSimplificada") != null ? e.Element("UsaDanfeSimplificada").Value : null;
                        objbelConfiguracao.FUSO = e.Element("Fuso") != null ? e.Element("Fuso").Value : null;
                        objbelConfiguracao.COD_BARRAS_XML = e.Element("CodBarrasXml") != null ? e.Element("CodBarrasXml").Value : null;
                        objbelConfiguracao.TOTALIZA_CFOP = e.Element("TotalizaCFOP") != null ? e.Element("TotalizaCFOP").Value : null;
                        objbelConfiguracao.NM_SERVIDOR = e.Element("Servidor") != null ? e.Element("Servidor").Value : null;
                        objbelConfiguracao.PORTA = e.Element("Porta") != null ? e.Element("Porta").Value : null;
                        objbelConfiguracao.CD_EMPRESA = e.Element("Empresa") != null ? e.Element("Empresa").Value : null;
                        objbelConfiguracao.REQUER_SSL = e.Element("RequerSSL") != null ? e.Element("RequerSSL").Value : null;
                        objbelConfiguracao.DESTACA_IMP_TRIB_MUN = e.Element("DestacaImpTribMun") != null ? e.Element("DestacaImpTribMun").Value : null;
                        objbelConfiguracao.GRUPO_SERVICO = e.Element("GrupoServico") != null ? e.Element("GrupoServico").Value : null;
                        objbelConfiguracao.GRUPO_SCAN = null;
                        objbelConfiguracao.DS_DETALHE = false;
                        objbelConfiguracao.TIPO_IMPRESSAO = e.Element("TipoImpressao") != null ? e.Element("TipoImpressao").Value : null;
                        objbelConfiguracao.HOST_SERVIDOR = e.Element("HostServidor") != null ? e.Element("HostServidor").Value : null;
                        objbelConfiguracao.PORTA_SERVIDOR = e.Element("PortaServidor") != null ? e.Element("PortaServidor").Value : null;
                        objbelConfiguracao.EMAIL_REMETENTE = e.Element("EmailRemetente") != null ? e.Element("EmailRemetente").Value : null;
                        objbelConfiguracao.SENHA_REMETENTE = e.Element("SenhaRemetente") != null ? e.Element("SenhaRemetente").Value : null;
                        objbelConfiguracao.EMAIL_AUTOMATICO = e.Element("EmailAutomatico") != null ? e.Element("EmailAutomatico").Value : null;
                        objbelConfiguracao.TP_EMIS = 1;


                        #region Importa Arquivos

                        string sCaminhoBkp = string.Empty;

                        if (String.IsNullOrEmpty(objbelConfiguracao.CAMINHO_PADRAO))
                        {
                            objbelConfiguracao.CAMINHO_PADRAO = dPasta.FullName + @"\Arquivos\" + item.Name.Replace(".xml", "");

                            Acesso.CAMINHO_PADRAO = objbelConfiguracao.CAMINHO_PADRAO;
                            Pastas.ENVIO.ToString();
                            Pastas.ENVIADOS.ToString();
                            Pastas.CONTINGENCIA.ToString();
                            Pastas.CCe.ToString();
                            Pastas.CBARRAS.ToString();
                            Pastas.CANCELADOS.ToString();
                            Pastas.RETORNO.ToString();
                            Pastas.PROTOCOLOS.ToString();


                            DirectoryInfo dImporta = new DirectoryInfo(objbelConfiguracao.CAMINHO_PADRAO);
                            if (!dImporta.Exists)
                            {
                                dImporta.Create();
                            }
                            DirectoryInfo para;
                            DirectoryInfo deOrigem = null;

                            if (!String.IsNullOrEmpty(e.Element("PastaXmlEnviado").Value))
                            {
                                para = new DirectoryInfo(Pastas.ENVIADOS);
                                deOrigem = new DirectoryInfo(e.Element("PastaXmlEnviado").Value);
                                CopiaArquivos(deOrigem, para);
                                sCaminhoBkp = deOrigem.Parent.FullName + "\\backup\\";
                                if (!Directory.Exists(sCaminhoBkp))
                                {
                                    Directory.CreateDirectory(sCaminhoBkp);
                                }
                                MovePastaParaBkp(sCaminhoBkp, deOrigem);
                            }

                            if (!String.IsNullOrEmpty(e.Element("PastaXmlEnvio").Value))
                            {
                                para = new DirectoryInfo(Pastas.ENVIO);
                                deOrigem = new DirectoryInfo(e.Element("PastaXmlEnvio").Value);
                                CopiaArquivos(deOrigem, para);
                                MovePastaParaBkp(sCaminhoBkp, deOrigem);
                            }

                            if (!String.IsNullOrEmpty(e.Element("PastaXmlCancelados").Value))
                            {
                                para = new DirectoryInfo(Pastas.CANCELADOS);
                                deOrigem = new DirectoryInfo(e.Element("PastaXmlCancelados").Value);
                                CopiaArquivos(deOrigem, para);
                                MovePastaParaBkp(sCaminhoBkp, deOrigem);

                            }

                            if (!String.IsNullOrEmpty(e.Element("PastaProtocolos").Value))
                            {
                                para = new DirectoryInfo(Pastas.PROTOCOLOS);
                                deOrigem = new DirectoryInfo(e.Element("PastaProtocolos").Value);
                                CopiaArquivos(deOrigem, para);
                                MovePastaParaBkp(sCaminhoBkp, deOrigem);
                            }

                            if (!String.IsNullOrEmpty(e.Element("PastaContingencia").Value))
                            {
                                para = new DirectoryInfo(Pastas.CONTINGENCIA);
                                deOrigem = new DirectoryInfo(e.Element("PastaContingencia").Value);
                                CopiaArquivos(deOrigem, para);
                                MovePastaParaBkp(sCaminhoBkp, deOrigem);
                            }

                            if (!String.IsNullOrEmpty(e.Element("PastaCCe").Value))
                            {
                                para = new DirectoryInfo(Pastas.CCe);
                                deOrigem = new DirectoryInfo(e.Element("PastaCCe").Value);
                                CopiaArquivos(deOrigem, para);
                                MovePastaParaBkp(sCaminhoBkp, deOrigem);
                            }
                            if (!String.IsNullOrEmpty(e.Element("CodBarras").Value))
                            {
                                para = new DirectoryInfo(Pastas.CBARRAS);
                                deOrigem = new DirectoryInfo(e.Element("CodBarras").Value);
                                CopiaArquivos(deOrigem, para);
                                MovePastaParaBkp(sCaminhoBkp, deOrigem);
                            }
                        }

                        if (!sCaminhoBkp.Equals(""))
                        {
                            item.MoveTo(sCaminhoBkp + "\\" + item.Name);
                        }

                        #endregion

                    }

                    XmlSerializer s = new XmlSerializer(typeof(belConfiguracao));
                    FileStream f = File.Create(Pastas.PASTA_XML_CONFIG + "\\" + item.Name);
                    s.Serialize(f, objbelConfiguracao);
                    f.Close();
                    f.Dispose();

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static void MovePastaParaBkp(string sCaminhoBkp, DirectoryInfo deOrigem)
        {
            if (deOrigem.Exists)
            {
                deOrigem.MoveTo(sCaminhoBkp + "\\" + deOrigem.Name);
            }
        }

        public static void CopiaArquivos(DirectoryInfo de, DirectoryInfo para)
        {
            if (!de.Exists)
            {
                return;
            }
            if (!para.Exists)
            {
                para.Create();
            }

            FileInfo[] files = de.GetFiles();
            foreach (FileInfo file in files)
            {
                if (!File.Exists(para.FullName + "\\" + file))
                {
                    file.CopyTo(Path.Combine(para.FullName, file.Name));
                }
            }

            DirectoryInfo[] dirs = de.GetDirectories();
            foreach (DirectoryInfo dir in dirs)
            {
                string destino = Path.Combine(para.FullName, dir.Name);
                CopiaArquivos(dir, new DirectoryInfo(destino));
            }


        }
    }
}
