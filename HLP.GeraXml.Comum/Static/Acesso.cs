using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Soap;
using System.Data;
using System.Windows.Forms;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Serialization;

namespace HLP.GeraXml.Comum.Static
{
    public static class Acesso
    {
        public enum BancoDados { INDUSTRIA, COMERCIO, CERAMICA, TRANSPORTE }


        private static string _NM_CONFIG;
        public static string NM_CONFIG
        {
            get { return Acesso._NM_CONFIG; }
            set { Acesso._NM_CONFIG = value; }
        }

        private static string _NM_CONFIG_TEMP = "";
        public static string NM_CONFIG_TEMP
        {
            get { return Acesso._NM_CONFIG_TEMP; }
            set { Acesso._NM_CONFIG_TEMP = "\\" + value; }
        }

        public static bool USER_LOGADO { get; set; }
        public static string EMAIL_CONTADOR { get; set; }
        public static BancoDados NM_RAMO { get; set; }
        public static string NM_RAZAOSOCIAL { get; set; }
        public static string NM_EMPRESA { get; set; }
        public static string NM_FANTASIA { get; set; }

        private static int _TP_AMB;
        /// <summary>
        /// 1-Produção / 2-Homologação
        /// </summary>
        public static int TP_AMB
        {
            get { return Acesso._TP_AMB; }
            set
            {
                Acesso._TP_AMB = value;
               //Acesso._TP_AMB = 1;
            }
        }

        private static int _TP_AMB_SERV;
        /// <summary>
        /// 1-Produção / 2-Homologação
        /// </summary>
        public static int TP_AMB_SERV
        {
            get { return Acesso._TP_AMB_SERV; }
            set
            {
                Acesso._TP_AMB_SERV = value;
                Acesso.URL_WEBSERVICE_DSF = "http://issdigital.campinas.sp.gov.br/WsNFe2/LoteRps.jws";
            }
        }
        public static string URL_WEBSERVICE_DSF { get; set; }
        /// <summary>
        /// 1 - NORMAL / 2 - EXEÇÃO
        /// </summary>
        public static int TP_INDUSTRIALIZACAO = 2;
        private static string _CIDADE_EMPRESA;

        public static string CIDADE_EMPRESA
        {
            get { return Acesso._CIDADE_EMPRESA; }
            set
            {
                Acesso._CIDADE_EMPRESA = value;
                if (lCidadesNFSE_GINFES.Contains(value.ToUpper()))
                {
                    tipoWsNfse = TP_WS_NFSE.GINFES;
                }
                else if (lCidadesNFSE_SUSESU.Contains(value.ToUpper()))
                {
                    tipoWsNfse = TP_WS_NFSE.SUSESU;
                }
                else if (lCidadesNFSE_TIPLAN.Contains(value.ToUpper()))
                {
                    tipoWsNfse = TP_WS_NFSE.TIPLAN;
                }
                else if (lCidadesNFSE_DSF.Contains(value.ToUpper()))
                {
                    tipoWsNfse = TP_WS_NFSE.DSF;
                }
                else
                {
                    tipoWsNfse = TP_WS_NFSE.NENHUM;
                }
            }
        }
        public static string CNPJ_EMPRESA { get; set; }
        private static int _cUF;
        public static int cUF
        {
            get { return _cUF; }
            set { _cUF = value; }
        }
        
        public static string xUF { get; set; }
        private static string _NM_USER = "";
        public static string NM_USER
        {
            get { return Acesso._NM_USER; }
            set
            {
                Acesso._NM_USER = value;
            }
        }

        public static bool bALTERA_DADOS { get; set; }
        public static bool bAGRUPA_ITENS_NFE { get; set; }
        public static bool bAGRUPA_ITENS_NFSE { get; set; }
        public static bool bESCRITA { get; set; }
        public static string SERIE_SCAN = "900";
        public static X509Certificate2 cert_CTe = null;
        public static X509Certificate2 cert_NFe = null;
        public static X509Certificate2 cert_NFs = null;
        public static bool bCERT_CONSULTA_SELECIONADO = false;
        public static string versaoNFe = "2.00";
        public static string versaoCTe = "2.00";
        public static string versaoMDFe = "1.00";
        public static TP_WS_NFSE tipoWsNfse { get; set; }
        public enum TP_WS_NFSE { GINFES, SUSESU, TIPLAN, DSF, NENHUM }
        public static string xUFtoWS
        {
            get
            {
                if (Acesso.xUF == "RJ")
                {
                    return "SVRS";
                }
                else
                {
                    return Acesso.xUF;
                }
            }
        }


        #region CONFIG
        public static string USA_DANFE_SIMPLIFICADA { get; set; }
        public static string CAMINHO_PADRAO { get; set; }
        public static string CAMINHO_RELATORIO_ESPECIFICO { get; set; }
        public static string CAMINHO_ESPECIFICO_ENVIADOS { get; set; }
        public static string CAMINHO_BANCO_DADOS { get; set; }
        public static string NM_SERVIDOR { get; set; }
        public static string PORTA { get; set; }
        public static string USUARIO { get; set; }
        public static string SENHA { get; set; }
        public static string CD_EMPRESA { get; set; }
        public static string GRAVA_NUM_NF_DUPL { get; set; }
        public static string GRUPO_SERVICO { get; set; }
        public static string GRUPO_SCAN { get; set; }
        public static bool DS_DETALHE { get; set; }
        public static string FUSO { get; set; }
        public static int TRANSPARENCIA { get; set; }
        public static string TIPO_IMPRESSAO { get; set; }
        public static string HOST_SERVIDOR { get; set; }
        public static string PORTA_SERVIDOR { get; set; }
        public static string EMAIL_REMETENTE { get; set; }
        public static string SENHA_REMETENTE { get; set; }
        public static string REQUER_SSL { get; set; }
        public static string EMAIL_AUTOMATICO { get; set; }
        public static string DESTACA_IMP_TRIB_MUN { get; set; }
        public static string LOGOTIPO { get; set; }
        public static string QTDE_CASAS_PRODUTOS { get; set; }
        public static string QTDE_CASAS_VL_UNIT { get; set; }
        public static string VISUALIZA_HORA_DANFE { get; set; }
        public static string VISUALIZA_DATA_DANFE { get; set; }
        public static string COD_BARRAS_XML { get; set; }
        public static string TOTALIZA_CFOP { get; set; }
        public static bool bALTER_CONFIG { get; set; }
        /// <summary>
        /// 1 - NORMAL
        /// 2 - CONTINGENCIA FS
        /// 3 - CONTIGENCIA SCAN
        /// 6 - SVC-AN
        /// </summary>
        public static int TP_EMIS { get; set; }
        public static bool IMPRIMI_NUM_NOTA_ENTRADA { get; set; }
        public static bool IMPRIMI_NUM_PEDIDO_VENDA { get; set; }
        public static bool IMPRIMI_NUM_REVISAO { get; set; }
        public static bool IMPRIMI_RETORNO { get; set; }
        private static bool _IMPRIMI_FATURA = true;

        public static bool IMPRIMI_FATURA
        {
            get { return Acesso._IMPRIMI_FATURA; }
            set { Acesso._IMPRIMI_FATURA = value; }
        }
        public static string COD_PREFEITURA { get; set; }
        public static string SENHA_WEB_NFES { get; set; }
        public static bool VISUALIZA_DADOS_NFE { get; set; }

        #endregion

        private static List<string> lCidadesNFSE_SUSESU = new List<string>();
        private static List<string> lCidadesNFSE_GINFES = new List<string>();
        private static List<string> lCidadesNFSE_TIPLAN = new List<string>();
        private static List<string> lCidadesNFSE_DSF = new List<string>();


        public static void CarregaDadosBanco()
        {

            if (File.Exists(Pastas.PASTA_XML_CONFIG + Acesso.NM_CONFIG_TEMP))
            {
                XmlSerializer s = new XmlSerializer(typeof(belConfiguracao));
                Stream file = new FileStream(Pastas.PASTA_XML_CONFIG + Acesso.NM_CONFIG_TEMP,
                    FileMode.Open, FileAccess.Read, FileShare.Read);
                belConfiguracao obj = (belConfiguracao)s.Deserialize(file);
                file.Dispose();

                if (obj != null)
                {
                    Acesso.CAMINHO_BANCO_DADOS = obj.CAMINHO_BANCO_DADOS;
                    Acesso.NM_SERVIDOR = obj.NM_SERVIDOR;
                    Acesso.PORTA = obj.PORTA;

                    if (obj.CAMINHO_BANCO_DADOS.ToUpper().Contains("INDUSTRI"))
                    {
                        Acesso.NM_RAMO = BancoDados.INDUSTRIA;
                    }
                    else if (obj.CAMINHO_BANCO_DADOS.ToUpper().Contains("COMERC"))
                    {
                        Acesso.NM_RAMO = BancoDados.COMERCIO;
                    }
                    else if (obj.CAMINHO_BANCO_DADOS.ToUpper().Contains("CERAM"))
                    {
                        Acesso.NM_RAMO = BancoDados.CERAMICA;
                    }
                    else if (obj.CAMINHO_BANCO_DADOS.ToUpper().Contains("TRANSP"))
                    {
                        Acesso.NM_RAMO = BancoDados.TRANSPORTE;
                    }
                }
            }
        }
        public static void CarregaAcesso()
        {
            lCidadesNFSE_SUSESU.Add("IPEUNA");
            //GINFES
            lCidadesNFSE_GINFES.Add("JUNDIAI");
            lCidadesNFSE_GINFES.Add("ITU");
            //TIPLAN
            lCidadesNFSE_TIPLAN.Add("SAO PAULO");
            lCidadesNFSE_TIPLAN.Add("RIO DAS OSTRAS");
            //DSF
            lCidadesNFSE_DSF.Add("CAMPINAS");
            lCidadesNFSE_DSF.Add("SOROCABA");


            if (File.Exists(Pastas.PASTA_XML_CONFIG + Acesso.NM_CONFIG))
            {
                XmlSerializer s = new XmlSerializer(typeof(belConfiguracao));
                Stream file = new FileStream(Pastas.PASTA_XML_CONFIG + Acesso.NM_CONFIG,
                    FileMode.Open, FileAccess.Read, FileShare.Read);
                belConfiguracao obj = (belConfiguracao)s.Deserialize(file);
                file.Dispose();

                if (obj != null)
                {
                    Pastas.Pasta_StartupPath = Application.StartupPath;
                    Acesso.CD_EMPRESA = obj.CD_EMPRESA;
                    Acesso.CAMINHO_PADRAO = obj.CAMINHO_PADRAO;
                    Acesso.USA_DANFE_SIMPLIFICADA = obj.USA_DANFE_SIMPLIFICADA;
                    Acesso.CAMINHO_RELATORIO_ESPECIFICO = obj.CAMINHO_RELATORIO_ESPECIFICO;
                    Acesso.CAMINHO_ESPECIFICO_ENVIADOS = obj.CAMINHO_ESPECIFICO_ENVIADOS;
                    Acesso.CAMINHO_BANCO_DADOS = obj.CAMINHO_BANCO_DADOS;
                    Acesso.NM_SERVIDOR = obj.NM_SERVIDOR;
                    Acesso.PORTA = obj.PORTA;
                    Acesso.USUARIO = obj.USUARIO;
                    Acesso.SENHA = obj.SENHA;
                    Acesso.CD_EMPRESA = obj.CD_EMPRESA;
                    Acesso.GRAVA_NUM_NF_DUPL = obj.GRAVA_NUM_NF_DUPL;
                    Acesso.GRUPO_SERVICO = obj.GRUPO_SERVICO;
                    Acesso.GRUPO_SCAN = obj.GRUPO_SCAN;
                    Acesso.DS_DETALHE = obj.DS_DETALHE;
                    Acesso.FUSO = obj.FUSO;
                    Acesso.TRANSPARENCIA = obj.TRANSPARENCIA;
                    Acesso.TIPO_IMPRESSAO = obj.TIPO_IMPRESSAO;
                    Acesso.HOST_SERVIDOR = obj.HOST_SERVIDOR;
                    Acesso.PORTA_SERVIDOR = obj.PORTA_SERVIDOR;
                    Acesso.EMAIL_REMETENTE = obj.EMAIL_REMETENTE;
                    Acesso.SENHA_REMETENTE = obj.SENHA_REMETENTE;
                    Acesso.REQUER_SSL = obj.REQUER_SSL;
                    Acesso.EMAIL_AUTOMATICO = obj.EMAIL_AUTOMATICO;
                    Acesso.DESTACA_IMP_TRIB_MUN = obj.DESTACA_IMP_TRIB_MUN;
                    Acesso.LOGOTIPO = obj.LOGOTIPO;
                    Acesso.QTDE_CASAS_PRODUTOS = obj.QTDE_CASAS_PRODUTOS;
                    Acesso.QTDE_CASAS_VL_UNIT = obj.QTDE_CASAS_VL_UNIT;
                    Acesso.VISUALIZA_HORA_DANFE = obj.VISUALIZA_HORA_DANFE;
                    Acesso.VISUALIZA_DATA_DANFE = obj.VISUALIZA_DATA_DANFE;
                    Acesso.COD_BARRAS_XML = obj.COD_BARRAS_XML;
                    Acesso.TOTALIZA_CFOP = obj.TOTALIZA_CFOP;
                    Acesso.TP_EMIS = obj.TP_EMIS;
                    Acesso.IMPRIMI_NUM_NOTA_ENTRADA = obj.IMPRIMI_NUM_NOTA_ENTRADA;
                    Acesso.IMPRIMI_NUM_PEDIDO_VENDA = obj.IMPRIMI_NUM_PEDIDO_VENDA;
                    Acesso.IMPRIMI_NUM_REVISAO = obj.IMPRIMI_NUM_REVISAO;
                    Acesso.IMPRIMI_RETORNO = obj.IMPRIMI_RETORNO;
                    Acesso.IMPRIMI_FATURA = obj.IMPRIMI_FATURA;
                    Acesso.SENHA_WEB_NFES = obj.SENHA_WEB_NFES;
                    Acesso.COD_PREFEITURA = obj.COD_PREFEITURA;
                    Acesso.VISUALIZA_DADOS_NFE = obj.VISUALIZA_DADOS_NFE;


                    if (Acesso.CAMINHO_BANCO_DADOS.ToUpper().Contains("INDUSTRI"))
                    {
                        Acesso.NM_RAMO = BancoDados.INDUSTRIA;
                    }
                    else if (Acesso.CAMINHO_BANCO_DADOS.ToUpper().Contains("COMERC"))
                    {
                        Acesso.NM_RAMO = BancoDados.COMERCIO;
                    }
                    else if (Acesso.CAMINHO_BANCO_DADOS.ToUpper().Contains("CERAM"))
                    {
                        Acesso.NM_RAMO = BancoDados.CERAMICA;
                    }
                    else if (Acesso.CAMINHO_BANCO_DADOS.ToUpper().Contains("TRANSP"))
                    {
                        Acesso.NM_RAMO = BancoDados.TRANSPORTE;
                    }
                }
            }
        }

        public static bool VerificaDadosEmail()
        {
            if (!String.IsNullOrEmpty(HOST_SERVIDOR) && !String.IsNullOrEmpty(PORTA_SERVIDOR)
                && !String.IsNullOrEmpty(EMAIL_REMETENTE) && !String.IsNullOrEmpty(SENHA_REMETENTE))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
