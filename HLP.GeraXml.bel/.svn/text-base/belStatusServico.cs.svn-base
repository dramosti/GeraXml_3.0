using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using HLP.GeraXml.Comum.Static;
using HLP.GeraXml.bel.NFe;
using HLP.GeraXml.bel.CTe;


namespace HLP.GeraXml.bel
{
    public static class belStatusServico
    {
        public static bool ServicoOperando = false;
        public static bool AcaoCancelada = false;
        public static string Mensagem = "";


        public static void VerificaStatusServicoCte()
        {
            try
            {
                Acesso.bCERT_CONSULTA_SELECIONADO = false;

                Mensagem = "";

                InternetCS objVerificaInternet = new InternetCS();
                if (objVerificaInternet.Conexao())
                {
                    X509Certificate2 cert = new X509Certificate2();
                    cert = belCertificadoDigital.BuscaNome("");
                    if (!belCertificadoDigital.ValidaCertificado(cert))
                    {
                        Mensagem = "Certificado Inválido";
                    }
                    else
                    {
                        Acesso.bCERT_CONSULTA_SELECIONADO = true;
                        Acesso.cert_CTe = cert;
                        belCriaXml objCriaXml = new belCriaXml();
                        List<belStatusCte> ListaStatus = objCriaXml.GerarXmlConsultaStatus();
                        Mensagem = belTrataMensagem.RetornaMensagem(ListaStatus, belTrataMensagem.Tipo.Status);

                    }
                }
                else
                {
                    Mensagem = "A internet parece estar Indisponível";
                }
            }
            catch (Exception ex)
            {
                Mensagem = ex.Message;
            }

        }
        public static void VerificaStatusServicoCteTela()
        {
            try
            {
                Acesso.bCERT_CONSULTA_SELECIONADO = false;
                ServicoOperando = false;
                AcaoCancelada = false;
                Mensagem = "";

                X509Certificate2 cert = new X509Certificate2();
                cert = belCertificadoDigital.BuscaNome("");
                if (!belCertificadoDigital.ValidaCertificado(cert))
                {
                    Mensagem = "Certificado Inválido";
                }
                else
                {
                    Acesso.cert_CTe = cert;
                    InternetCS objVerificaInternet = new InternetCS();
                    if (objVerificaInternet.Conexao())
                    {
                        Acesso.bCERT_CONSULTA_SELECIONADO = true;
                        belCriaXml objCriaXml = new belCriaXml();
                        List<belStatusCte> ListaStatus = objCriaXml.GerarXmlConsultaStatus();
                        Mensagem = belTrataMensagem.RetornaMensagem(ListaStatus, belTrataMensagem.Tipo.Status);

                        if (!AcaoCancelada)
                        {
                            foreach (belStatusCte status in ListaStatus)
                            {
                                if (status.CodRetorno == "107")
                                {
                                    if (Acesso.TP_EMIS != 1)
                                    {
                                        Mensagem += Environment.NewLine + Environment.NewLine + "O Sefaz está Operante." + Environment.NewLine + "Altere o Sistema para Modo Normal";
                                    }
                                    else
                                    {
                                        ServicoOperando = true;
                                    }
                                }
                                else if (status.CodRetorno != "107" && Acesso.TP_EMIS == 1)
                                {
                                    Mensagem += Environment.NewLine + Environment.NewLine + "O Sefaz não está Operante." + Environment.NewLine + "Caso queira emitir Conhecimentos utilizando o formulário de segurança," + Environment.NewLine +
                                     "Altere o Sistema para Modo Contingência FS.";
                                }
                                else
                                {
                                    ServicoOperando = true;
                                }
                            }
                        }
                    }
                    else
                    {
                        Mensagem = "A internet parece estar Indisponível";
                        if (Acesso.TP_EMIS == 2)
                        {
                            ServicoOperando = true;
                        }
                        else
                        {
                            Mensagem += Environment.NewLine + Environment.NewLine + "O Sistema não está Operante."
                                 + Environment.NewLine + "Caso queira emitir Conhecimentos utilizando o formulário de segurança," + Environment.NewLine +
                                    "Altere o Sistema para Modo Contingência FS.";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Mensagem = ex.Message;
            }
        }


        public static void VerificaStatusServicoNFeTela()
        {
            try
            {
                Acesso.bCERT_CONSULTA_SELECIONADO = false;
                ServicoOperando = false;
                AcaoCancelada = false;
                Mensagem = "";

                X509Certificate2 cert = new X509Certificate2();
                cert = belCertificadoDigital.BuscaNome("");
                if (!belCertificadoDigital.ValidaCertificado(cert))
                {
                    Mensagem = "Certificado Inválido";
                }
                else
                {
                    Acesso.cert_NFe = cert;
                    InternetCS objVerificaInternet = new InternetCS();
                    if (objVerificaInternet.Conexao())
                    {
                        Acesso.bCERT_CONSULTA_SELECIONADO = true;
                        HLP.GeraXml.bel.NFe.belStatusServicoNFe.DadosRetorno objStatus = belStatusServicoNFe.RealizaConsultaStatusServico();
                        Mensagem = belTrataMensagemNFe.RetornaMensagem(objStatus, belTrataMensagemNFe.Tipo.Status);

                        if (!AcaoCancelada)
                        {
                            if (objStatus.cStat == "107")
                            {
                                if (Acesso.TP_EMIS == 2)
                                {
                                    Mensagem += Environment.NewLine + Environment.NewLine + "O Sefaz está Operante." + Environment.NewLine + "Altere o Sistema para Modo Normal.";
                                }
                                else
                                {
                                    ServicoOperando = true;
                                }
                            }
                            else if (objStatus.cStat != "107" && Acesso.TP_EMIS == 1)
                            {
                                Mensagem += Environment.NewLine + Environment.NewLine + "O Sefaz não está Operante." + Environment.NewLine + "Caso queira emitir Notas utilizando o formulário de segurança," + Environment.NewLine +
                                    "Altere o Sistema para Modo Contingência FS.";
                            }
                            else
                            {
                                ServicoOperando = true;
                            }
                        }
                    }
                    else
                    {
                        Mensagem = "A internet parece estar Indisponível";
                        if (Acesso.TP_EMIS == 2)
                        {
                            ServicoOperando = true;
                        }
                        else
                        {
                            Mensagem += Environment.NewLine + Environment.NewLine + "O Sistema não está Operante."
                                + Environment.NewLine + "Caso queira emitir Notas utilizando o formulário de segurança," + Environment.NewLine +
                                   "Altere o Sistema para Modo Contingência FS.";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Mensagem = ex.Message;
            }

        }
        public static void VerificaStatusServicoNFe()
        {
            try
            {
                Acesso.bCERT_CONSULTA_SELECIONADO = false;
                Mensagem = "";
                InternetCS objVerificaInternet = new InternetCS();
                if (objVerificaInternet.Conexao())
                {
                    X509Certificate2 cert = new X509Certificate2();
                    cert = belCertificadoDigital.BuscaNome("");
                    if (!belCertificadoDigital.ValidaCertificado(cert))
                    {
                        Mensagem = "Certificado Inválido";
                    }
                    else
                    {
                        Acesso.bCERT_CONSULTA_SELECIONADO = true;
                        Acesso.cert_NFe = cert;
                        HLP.GeraXml.bel.NFe.belStatusServicoNFe.DadosRetorno objStatus = belStatusServicoNFe.RealizaConsultaStatusServico();
                        Mensagem = belTrataMensagemNFe.RetornaMensagem(objStatus, belTrataMensagemNFe.Tipo.Status);
                    }
                }
                else
                {
                    Mensagem = "A internet parece estar Indisponível";
                }
            }

            catch (Exception ex)
            {
                Mensagem = ex.Message;
            }


        }

        public static void VerificaStatusInternetNFs()
        {
            try
            {
                ServicoOperando = false;
                Mensagem = "";
                InternetCS objVerificaInternet = new InternetCS();
                if (!objVerificaInternet.Conexao())
                {

                    Mensagem = "A internet parece estar Indisponível";
                }
                else
                {
                    ServicoOperando = true;
                }
            }
            catch (Exception ex)
            {
                Mensagem = ex.Message;
            }


        }

        public static void SelecionaCertificadoNFs()
        {
            try
            {
                X509Certificate2 cert = new X509Certificate2();
                cert = belCertificadoDigital.BuscaNome("");
                if (!belCertificadoDigital.ValidaCertificado(cert))
                {
                    throw new InvalidOperationException("Certificado não Selecionado.");
                }
                Acesso.cert_NFs = cert;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


    }
}
