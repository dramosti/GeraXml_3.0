using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HLP.GeraXml.Comum.Static;
using HLP.GeraXml.dao;
using System.Net.Mail;
using System.IO;
using System.Net;
using System.Xml;
using HLP.GeraXml.bel.CCe;

namespace HLP.GeraXml.bel
{
    public class belEmail : daoEmail
    {
        public bool Enviar = false;
        public string sSeq = "";
        public string sNotaFis = "";
        public string sDestinatario = "";
        public string sOutros = "";
        public string sCaminhoXml = "";
        public string sCaminhoPDF = "";
        string sChaveNFe = "";
        string sCodigoVerificacaoNFservico = "";
        string CorpoEmail = "";
        string AssuntoEmail = "";
        TipoEmail tipo;

        List<PendenciaEmail> lPendenciaContador = new List<PendenciaEmail>();


        public enum TipoEmail
        {
            CTe,
            NFe_Normal,
            NFe_Cancelada,
            CCe,
            NF_Servico,
            NF_ServicoDSF
        }

        public belEmail(TipoEmail tipo)
        {
            this.tipo = tipo;
        }

        public belEmail(string sCaminhoXml, string sCaminhoPDF, string sCD_NFSEQ, string sCD_NOTAFIS, string sChaveNFe = "", string sCodigoVerificacaoNFservico = "")
        {
            this.sCaminhoXml = sCaminhoXml;
            this.sCaminhoPDF = sCaminhoPDF;
            this.sSeq = sCD_NFSEQ;
            this.sNotaFis = sCD_NOTAFIS;
            this.sChaveNFe = sChaveNFe;
            this.sCodigoVerificacaoNFservico = sCodigoVerificacaoNFservico;
            string[] aux;
            if (Acesso.NM_RAMO != Acesso.BancoDados.TRANSPORTE)
                aux = RetornaEmailDestinatarioNfe(sCD_NFSEQ);
            else
            {
                aux = RetornaEmailDestinatarioCte(sCD_NFSEQ).Split(';');
            }
            this.sDestinatario = Acesso.NM_RAMO == Acesso.BancoDados.TRANSPORTE ? RetornaEmailDestinatarioCte(sCD_NFSEQ) : aux[0];


            if (Acesso.NM_RAMO != Acesso.BancoDados.TRANSPORTE)
            {
                this.sOutros = RetornaEmailTransportador(sCD_NFSEQ) != "" ? RetornaEmailTransportador(sCD_NFSEQ) + "; " : "";
                this.sOutros += RetornaEmailVendedor(sCD_NFSEQ);
                for (int i = 1; i < aux.Length; i++)
                {
                    if ((i + 1) < aux.Length)
                    {
                        this.sOutros += aux[i].Trim() + "; ";
                    }
                    else
                    {
                        this.sOutros += aux[i].Trim();
                    }

                }
            }
            else
            {
                this.sOutros = "";
            }
            //this.sOutros = Acesso.NM_RAMO != Acesso.BancoDados.TRANSPORTE ? RetornaEmailTransportador(sCD_NFSEQ) : "";

        }

        public belEmail(List<PendenciaEmail> lPendenciaContador, string Copia)
        {
            this.lPendenciaContador = lPendenciaContador;
            this.sOutros = Copia;
        }

        public belEmail() { }


        public void EnviarEmailManual(string sdestinatario, string sBody, string sAssunto)
        {
            SmtpClient cliente = new SmtpClient(Acesso.HOST_SERVIDOR, Convert.ToInt16(Acesso.PORTA_SERVIDOR));
            cliente.EnableSsl = Convert.ToBoolean(Acesso.REQUER_SSL);
            cliente.Timeout = 200000;

            NetworkCredential credenciais = new NetworkCredential(Acesso.EMAIL_REMETENTE, Acesso.SENHA_REMETENTE);
            cliente.UseDefaultCredentials = false;
            cliente.Credentials = credenciais;
            MailAddress remetente = new MailAddress(Acesso.EMAIL_REMETENTE);
            MailAddress destinatario = new MailAddress(sdestinatario);
            MailMessage mensagem = new MailMessage(remetente, destinatario);
            mensagem.Body = "Teste Envio";
            mensagem.Subject = "Teste de envio";
            cliente.Send(mensagem);
        }



        /// <summary>
        /// Usado para Envio ao Cliente
        /// </summary>
        /// <param name="objListaEmail"></param>
        public void EnviarEmail(List<belEmail> objListaEmail)
        {
            try
            {

                SmtpClient cliente = new SmtpClient(Acesso.HOST_SERVIDOR, Convert.ToInt16(Acesso.PORTA_SERVIDOR));
                cliente.EnableSsl = Convert.ToBoolean(Acesso.REQUER_SSL);
                cliente.Timeout = 200000;
                MailAddress remetente = new MailAddress(Acesso.EMAIL_REMETENTE);


                NetworkCredential credenciais = new NetworkCredential(Acesso.EMAIL_REMETENTE, Acesso.SENHA_REMETENTE);
                cliente.UseDefaultCredentials = false;
                cliente.Credentials = credenciais;

                foreach (belEmail email in objListaEmail.Where(C => C.Enviar == true))
                {
                    MailAddress destinatario = new MailAddress(email.sDestinatario);
                    MailMessage mensagem = new MailMessage(remetente, destinatario);

                    string[] Outros = email.sOutros.Split(';');
                    foreach (string Copia in Outros)
                    {
                        if (Copia.Trim() != "")
                        {
                            MailAddress cc = new MailAddress(Copia.Trim());
                            mensagem.To.Add(cc);
                        }
                    }
                    mensagem.IsBodyHtml = true;
                    mensagem.Body = GeraCorpoEmail(email);
                    mensagem.Subject = GeraAssunto();

                    if (!String.IsNullOrEmpty(email.sCaminhoXml))
                    {
                        Attachment anexo1 = new Attachment(email.sCaminhoXml);
                        mensagem.Attachments.Add(anexo1);
                    }
                    if (!String.IsNullOrEmpty(email.sCaminhoPDF))
                    {
                        Attachment anexo2 = new Attachment(email.sCaminhoPDF);
                        mensagem.Attachments.Add(anexo2);
                    }

                    cliente.Send(mensagem);

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// Usado para Envio ao Contador
        /// </summary>
        public void EnviarEmail()
        {
            try
            {
                SmtpClient cliente = new SmtpClient(Acesso.HOST_SERVIDOR, Convert.ToInt16(Acesso.PORTA_SERVIDOR));
                cliente.EnableSsl = Convert.ToBoolean(Acesso.REQUER_SSL);
                cliente.Timeout = 200000;
                MailAddress remetente = new MailAddress(Acesso.EMAIL_REMETENTE);
                MailAddress destinatario = new MailAddress(Acesso.EMAIL_CONTADOR);


                NetworkCredential credenciais = new NetworkCredential(Acesso.EMAIL_REMETENTE, Acesso.SENHA_REMETENTE);
                cliente.UseDefaultCredentials = false;
                cliente.Credentials = credenciais;

                MailMessage mensagem = new MailMessage(remetente, destinatario);
                mensagem.IsBodyHtml = true;
                mensagem.Body = Acesso.NM_RAMO == Acesso.BancoDados.TRANSPORTE ? GeraCorpoEmailContadorCte() : GeraCorpoEmailContadorNfe();
                mensagem.Subject = Acesso.NM_RAMO == Acesso.BancoDados.TRANSPORTE ? "Conhecimento de Transporte Eletrônico - Empresa " + Acesso.NM_FANTASIA : "Nota Fiscal Eletrônica - Empresa " + Acesso.NM_FANTASIA;
                if (sOutros != "")
                {
                    MailAddress dest_Trasnp = new MailAddress(sOutros);
                    mensagem.To.Add(dest_Trasnp);
                }

                if (lPendenciaContador.Count > 0)
                {
                    foreach (PendenciaEmail item in lPendenciaContador)
                    {
                        Attachment anexo = new Attachment(item.sPathZip);
                        mensagem.Attachments.Add(anexo);
                    }
                }

                cliente.Send(mensagem);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        private string GeraCorpoEmail(belEmail email)
        {
            string Corpo = "";
            switch (tipo)
            {
                case TipoEmail.CTe:
                    Corpo = GeraCorpoEmailCte(email);
                    break;
                case TipoEmail.NFe_Normal:
                    Corpo = GeraCorpoEmailNfe_Normal(email);
                    break;
                case TipoEmail.NFe_Cancelada:
                    Corpo = GeraCorpoEmailNfe_Cancelada(email);
                    break;
                case TipoEmail.CCe:
                    Corpo = GeraCorpoEmailCCe(email);
                    break;
                case TipoEmail.NF_Servico:
                    Corpo = GeraCorpoEmailNF_Servico(email);
                    break;
                case TipoEmail.NF_ServicoDSF:
                    Corpo = GeraCorpoEmailNF_ServicoDSF(email);
                    break;
            }
            return Corpo;
        }

        private string GeraCorpoEmailCte(belEmail email)
        {
            try
            {
                XmlDocument xmldoc = new XmlDocument();
                StringBuilder sCorpo = new StringBuilder();
                xmldoc.Load(email.sCaminhoXml);

                XmlNodeList emit = xmldoc.GetElementsByTagName("emit");
                string chave = xmldoc.GetElementsByTagName("infCte")[0].Attributes["Id"].Value.Replace("CTe", "");

                string protocolo = "";
                if (xmldoc.GetElementsByTagName("nProt")[0] != null)
                {
                    protocolo = xmldoc.GetElementsByTagName("nProt")[0].InnerText;
                }
                sCorpo.Append("<font face='Segoe UI' size='2'><H3>Sr. Contribuinte,</H3>");
                sCorpo.Append("Esta mensagem refere-se ao Conhecimento de Transporte Eletrônico número " + email.sSeq + " emitido por:<br><br>");
                sCorpo.Append("Razão Social: " + Acesso.NM_RAZAOSOCIAL + "<br>");
                sCorpo.Append("CNPJ: " + Acesso.CNPJ_EMPRESA + "<br><br><br>");
                sCorpo.Append("Para verificar o Conhecimento mencionado, ");
                sCorpo.Append("acesse o site https://www.cte.fazenda.gov.br/FormularioDePesquisa.aspx?tipoconsulta=resumo <br><br>");
                sCorpo.Append("Chave de Acesso: " + chave + "<br>");
                sCorpo.Append("Protocolo: " + protocolo + "<br><br>");
                sCorpo.Append("Esse é um e-mail automático gerado por nosso sistema transmissor de CT-e</font>");
                sCorpo.Append(AssinaturaEmail());

                return sCorpo.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private string GeraCorpoEmailNfe_Normal(belEmail email)
        {
            try
            {
                XmlDocument xmldoc = new XmlDocument();
                StringBuilder scorpo = new StringBuilder();

                xmldoc.Load(email.sCaminhoXml);
                string chave = xmldoc.GetElementsByTagName("infNFe")[0].Attributes["Id"].Value.Replace("NFe", "");
                string protocolo = "";
                if (xmldoc.GetElementsByTagName("nProt")[0] != null)
                {
                    protocolo = xmldoc.GetElementsByTagName("nProt")[0].InnerText;
                }
                string scaminhoLink = "https://www.nfe.fazenda.gov.br/portal/consulta.aspx?tipoConsulta=completa&tipoConteudo=XbSeqxE8pl8=";


                scorpo.Append("<font face='Segoe UI' size='2'><H3>Sr. Contribuinte,</H3>");
                scorpo.Append("Esta mensagem refere-se a Nota Fiscal Eletrônica de série/número " + email.sNotaFis + " emitida por: <br><br>");
                scorpo.Append("Razao Social: " + Acesso.NM_RAZAOSOCIAL + "<br>");
                scorpo.Append("CNPJ: " + Acesso.CNPJ_EMPRESA + "<br><br><br>");
                scorpo.Append("Visualize a NF-e ");
                scorpo.Append("<a href=" + scaminhoLink + ">aqui!</a><br>");
                scorpo.Append("Chave de Acesso: " + chave + "<br>");
                scorpo.Append("Protocolo: " + protocolo + "<br><br>");
                scorpo.Append("Esse é um e-mail automático gerado por nosso sistema transmissor de NF-e</font>");
                scorpo.Append(AssinaturaEmail());

                return scorpo.ToString();

            }
            catch (Exception x)
            {
                throw new Exception(x.Message);
            }
        }
        private string GeraCorpoEmailNfe_Cancelada(belEmail email)
        {
            try
            {
                XmlDocument xmldoc = new XmlDocument();
                xmldoc.Load(email.sCaminhoXml);
                string chave = xmldoc.GetElementsByTagName("infNFe")[0].Attributes["Id"].Value.Replace("NFe", "");
                string protocolo = xmldoc.GetElementsByTagName("nProt")[0].InnerText;

                string scaminhoLink = "https://www.nfe.fazenda.gov.br/portal/consulta.aspx?tipoConsulta=completa&tipoConteudo=XbSeqxE8pl8= ";

                StringBuilder sCorpo = new StringBuilder();
                sCorpo.Append("<font face='Segoe UI' size='2'><H3>Sr. Contribuinte,</H3>");
                sCorpo.Append("Esta mensagem refere-se ao CANCELAMENTO da Nota Fiscal Eletrônica de série/número " + email.sNotaFis + " emitida por: <br><br>");
                sCorpo.Append("Razao Social: " + Acesso.NM_RAZAOSOCIAL + "<br>");
                sCorpo.Append("CNPJ: " + Acesso.CNPJ_EMPRESA + "<br><br><br>");
                sCorpo.Append("Visualize a NF-e ");
                sCorpo.Append("<a href=" + scaminhoLink + ">aqui!</a><br>");
                sCorpo.Append("Chave de Acesso: " + chave + "<br>");
                sCorpo.Append("Protocolo: " + protocolo + "<br><br>");
                sCorpo.Append("Esse é um e-mail automático gerado por nosso sistema transmissor de NF-e</font>");
                sCorpo.Append(AssinaturaEmail());

                return sCorpo.ToString();

            }
            catch (Exception x)
            {
                throw new Exception(x.Message);
            }
        }
        private string GeraCorpoEmailCCe(belEmail email)
        {
            try
            {
                string scaminhoLink = (Acesso.NM_RAMO != Acesso.BancoDados.TRANSPORTE) ? 
                    "https://www.nfe.fazenda.gov.br/portal/consulta.aspx?tipoConsulta=completa&tipoConteudo=XbSeqxE8pl8=" :
                    "http://www.cte.fazenda.gov.br/consulta.aspx?tipoConsulta=completa&tipoConteudo=mCK/KoCqru0=";
                string sSistema = (Acesso.NM_RAMO != Acesso.BancoDados.TRANSPORTE) ? "NFe" : "CTe";

                StringBuilder sCorpo = new StringBuilder();
                sCorpo.Append("<font face='Segoe UI' size='2'><H3>Sr. Contribuinte,</H3>");
                sCorpo.Append("Esta mensagem refere-se a Carta de Correção Eletrônica efetuada na ");
                sCorpo.Append(sSistema + " de número " + email.sNotaFis + " emitida por: <br><br>");
                sCorpo.Append("Razao Social: " + Acesso.NM_RAZAOSOCIAL + "<br>");
                sCorpo.Append("CNPJ: " + Acesso.CNPJ_EMPRESA + "<br><br><br>");
                sCorpo.Append("Visualize a " + sSistema);
                sCorpo.Append(" <a href=" + scaminhoLink + ">aqui!</a><br>");
                sCorpo.Append("Chave de Acesso: " + email.sChaveNFe + "<br><br>");
                sCorpo.Append("Esse é um e-mail automático gerado por nosso sistema transmissor de " + sSistema + "</font>");
                sCorpo.Append(AssinaturaEmail());

                return sCorpo.ToString();
            }
            catch (Exception x)
            {
                throw new Exception(x.Message);
            }
        }
        private string GeraCorpoEmailNF_Servico(belEmail email)
        {
            try
            {
                string scaminhoLink = "";
                if (Acesso.tipoWsNfse == Acesso.TP_WS_NFSE.GINFES)
                {
                    scaminhoLink = "visualizar.ginfes" + (Acesso.TP_AMB_SERV == 2 ? "h" : "") + ".com.br/report/consultarNota?__report=nfs_ver4&cdVerificacao=" + email.sCodigoVerificacaoNFservico + "&numNota=" + email.sSeq;
                }
                else
                {
                    scaminhoLink = string.Format("https://spe.riodasostras.rj.gov.br/nfse/nfse.aspx?ccm=2747&nf={0}&cod={1}", email.sSeq, email.sCodigoVerificacaoNFservico.Replace("-", ""));
                }

                StringBuilder sCorpo = new StringBuilder();
                sCorpo.Append("<font face='Segoe UI' size='2'><H3>Sr. Contribuinte,</H3>");
                sCorpo.Append("Esta mensagem refere-se à Nota Fiscal Eletrônica de Serviços N° " + email.sNotaFis + " emitida por: <br><br>");
                sCorpo.Append("Razao Social: " + Acesso.NM_RAZAOSOCIAL + "<br>");
                sCorpo.Append("CNPJ: " + Acesso.CNPJ_EMPRESA + "<br><br><br>");
                sCorpo.Append("Visualize a NF-e Serviço");
                sCorpo.Append("<a href=" + scaminhoLink + ">aqui!</a><br>");
                sCorpo.Append("Esse é um e-mail automático gerado por nosso sistema transmissor de NF-e</font>");
                sCorpo.Append(AssinaturaEmail());

                return sCorpo.ToString();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private string GeraCorpoEmailNF_ServicoDSF(belEmail email)
        {
            try
            {

                StringBuilder sCorpo = new StringBuilder();
                sCorpo.Append("<font face='Segoe UI' size='2'><H3>Sr. Contribuinte,</H3>");
                sCorpo.Append("Esta mensagem refere-se à Nota Fiscal Eletrônica de Serviços N° " + email.sNotaFis + " emitida por: <br><br>");
                sCorpo.Append("Razao Social: " + Acesso.NM_RAZAOSOCIAL + "<br>");
                sCorpo.Append("CNPJ: " + Acesso.CNPJ_EMPRESA + "<br><br><br>");
                sCorpo.Append("Esse é um e-mail automático gerado por nosso sistema transmissor de NF-e</font>");
                sCorpo.Append(AssinaturaEmail());

                return sCorpo.ToString();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        private string GeraCorpoEmailContadorNfe()
        {
            try
            {
                StringBuilder sCorpo = new StringBuilder();
                sCorpo.Append("<font face='Segoe UI' size='2'><H3>Caros Srs,</H3>");
                sCorpo.Append("Segue anexo os Xml's de envio ref. aos meses citados abaixo:<br>");
                foreach (PendenciaEmail item in lPendenciaContador)
                {
                    sCorpo.Append(item.sMes + " / " + item.sAno + "<br>");
                }
                sCorpo.Append("<br>Esse é um e-mail automático gerado por nosso sistema transmissor de NF-e <br><br>");
                sCorpo.Append("Att: " + Acesso.NM_FANTASIA + "</font>");
                sCorpo.Append(AssinaturaEmail());
                return sCorpo.ToString();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private string GeraCorpoEmailContadorCte()
        {
            try
            {
                StringBuilder sCorpo = new StringBuilder();
                sCorpo.Append("<font face='Segoe UI' size='2'><H3>Caros Srs,</H3>");
                sCorpo.Append("Segue anexo os Xml's de envio ref. aos meses citados abaixo:<br>");
                foreach (PendenciaEmail item in lPendenciaContador)
                {
                    sCorpo.Append(item.sMes + " / " + item.sAno + "<br>");
                }
                sCorpo.Append("<br>Esse é um e-mail automático gerado por nosso sistema transmissor de CT-e <br><br>");
                sCorpo.Append("Att: " + Acesso.NM_FANTASIA + "</font>");
                sCorpo.Append(AssinaturaEmail());
                return sCorpo.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private string GeraAssunto()
        {
            string Assunto = "";
            switch (tipo)
            {
                case TipoEmail.CTe:
                    Assunto = GeraAssuntoEmailCte();
                    break;
                case TipoEmail.NFe_Normal:
                    Assunto = GeraAssuntoNfe_Normal();
                    break;
                case TipoEmail.NFe_Cancelada:
                    Assunto = GeraAssuntoEmailNfe_Cancelada();
                    break;
                case TipoEmail.CCe:
                    Assunto = GeraAssuntoEmailCCe();
                    break;
                case TipoEmail.NF_Servico:
                    Assunto = GeraAssuntoEmailNF_Servico();
                    break;
            }
            return Assunto;
        }
        private string GeraAssuntoEmailCte()
        {
            return "Mensagem Automática de Conhecimento de Transporte Eletrônico de " + Acesso.NM_FANTASIA;
        }
        private string GeraAssuntoNfe_Normal()
        {
            return "Mensagem Automática de Nota Fiscal Eletrônica de " + Acesso.NM_FANTASIA;
        }
        private string GeraAssuntoEmailNfe_Cancelada()
        {
            return "Mensagem Automática de Cancelamento de Nota Fiscal Eletrônica de " + Acesso.NM_FANTASIA;
        }
        private string GeraAssuntoEmailCCe()
        {
            return "Mensagem Automática de Carta de Correção Eletrônica de " + Acesso.NM_FANTASIA;
        }
        private string GeraAssuntoEmailNF_Servico()
        {
            return "Mensagem Automática de Nota Fiscal Eletrônica de Serviço de " + Acesso.NM_FANTASIA;
        }

        private string AssinaturaEmail()
        {
            StringBuilder Assina = new StringBuilder();
            Assina.Append("<br><br><br><I><font face='Segoe UI' size='2' color = " + "\"" + "#c0c0c0" + "\"" + " size = 2>HLP - Estratégia em Software</I><br>");
            Assina.Append("<a href=" + "\"" + "http://www.hlp.com.br" + "\"" + ">www.hlp.com.br</a></font>");

            return Assina.ToString();
        }


    }
}

