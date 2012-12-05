using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace HLP.GeraXml.Comum.Static
{
    public static class Pastas
    {

        private static string _REGISTRY_CONFIG = "hlp\\Config_xml_3";
        public static string REGISTRY_CONFIG
        {
            get { return Pastas._REGISTRY_CONFIG; }
            set { Pastas._REGISTRY_CONFIG = value; }
        }


        private static string _CONFIG = "Config_xml_3";
        public static string CONFIG
        {
            get { return Pastas._CONFIG; }
            set { Pastas._CONFIG = value; }
        }

        private static string _LOCAL_XML = "LOCAL_XML_3";
        public static string LOCAL_XML
        {
            get { return Pastas._LOCAL_XML; }
            set { Pastas._LOCAL_XML = value; }
        }

        private static string _Caminho_xmls = "Caminho_xmls_3";
        public static string Caminho_xmls
        {
            get { return Pastas._Caminho_xmls; }
            set { Pastas._Caminho_xmls = value; }
        }


        private static string _PASTA_XML_CONFIG;
        public static string PASTA_XML_CONFIG
        {
            get
            {
                string sCaminho = _PASTA_XML_CONFIG;
                DirectoryInfo info = new DirectoryInfo(sCaminho);
                if (!info.Exists)
                {
                    info.Create();
                }
                return sCaminho.Trim();
            }
            set
            {
                Pastas._PASTA_XML_CONFIG = value;
            }
        }


        public static string Pasta_StartupPath { get; set; }


        private static string _CANCELADOS = "Cancelados\\";
        public static string CANCELADOS
        {
            get
            {
                string sCaminho = Acesso.CAMINHO_PADRAO + "\\" + Pastas._CANCELADOS;
                DirectoryInfo info = new DirectoryInfo(sCaminho);
                if (!info.Exists)
                {
                    info.Create();
                }
                return sCaminho.Trim();
            }
            set { Pastas._CANCELADOS = value; }
        }

        private static string _CONTINGENCIA = "Contingencia\\";
        public static string CONTINGENCIA
        {
            get
            {
                string sCaminho = Acesso.CAMINHO_PADRAO + "\\" + Pastas._CONTINGENCIA;
                DirectoryInfo info = new DirectoryInfo(sCaminho);
                if (!info.Exists)
                {
                    info.Create();
                }
                return sCaminho.Trim();
            }
            set { Pastas._CONTINGENCIA = value; }
        }

        private static string _ENVIADOS = "Enviados\\";
        public static string ENVIADOS
        {
            get
            {
                string sCaminho = Acesso.CAMINHO_PADRAO + "\\" + Pastas._ENVIADOS;
                DirectoryInfo info = new DirectoryInfo(sCaminho);
                if (!info.Exists)
                {
                    info.Create();
                }
                return sCaminho.Trim();
            }
            set { Pastas._ENVIADOS = value; }
        }

        private static string _ENVIO = "Envio\\";
        public static string ENVIO
        {
            get
            {
                string sCaminho = Acesso.CAMINHO_PADRAO + "\\" + Pastas._ENVIO;
                DirectoryInfo info = new DirectoryInfo(sCaminho);
                if (!info.Exists)
                {
                    info.Create();
                }
                return sCaminho.Trim();
            }
            set { Pastas._ENVIO = value; }
        }

        private static string _PROTOCOLOS = "Protocolos\\";
        public static string PROTOCOLOS
        {
            get
            {
                string sCaminho = Acesso.CAMINHO_PADRAO + "\\" + Pastas._PROTOCOLOS;
                DirectoryInfo info = new DirectoryInfo(sCaminho);
                if (!info.Exists)
                {
                    info.Create();
                }
                return sCaminho.Trim();
            }
            set { Pastas._PROTOCOLOS = value; }
        }

        private static string _CBARRAS = "CBarras\\";
        public static string CBARRAS
        {
            get
            {
                string sCaminho = Acesso.CAMINHO_PADRAO + "\\" + Pastas._CBARRAS;
                DirectoryInfo info = new DirectoryInfo(sCaminho);
                if (!info.Exists)
                {
                    info.Create();
                }
                return sCaminho.Trim();
            }
            set { Pastas._CBARRAS = value; }
        }

        private static string _RETORNO = "Retorno\\";
        public static string RETORNO
        {
            get
            {
                string sCaminho = Acesso.CAMINHO_PADRAO + "\\" + Pastas._RETORNO;
                DirectoryInfo info = new DirectoryInfo(sCaminho);
                if (!info.Exists)
                {
                    info.Create();
                }
                return sCaminho.Trim();
            }
            set { Pastas._RETORNO = value; }
        }

        private static string _CCe = "CCe\\";
        public static string CCe
        {
            get
            {
                try
                {
                    string sCaminho = Acesso.CAMINHO_PADRAO + "\\" + Pastas._CCe;
                    DirectoryInfo info = new DirectoryInfo(sCaminho);
                    if (!info.Exists)
                    {
                        info.Create();
                    }
                    return sCaminho.Trim();
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
            set { Pastas._CCe = value; }
        }

        private static string _TIMER_RETORNOS = "BuscaRetorno\\";
        public static string TIMER_RETORNOS
        {
            get
            {
                try
                {
                    string sCaminho = Acesso.CAMINHO_PADRAO + "\\" + Pastas._TIMER_RETORNOS;
                    DirectoryInfo info = new DirectoryInfo(sCaminho);
                    if (!info.Exists)
                    {
                        info.Create();
                    }
                    return sCaminho.Trim();
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
            set { Pastas._TIMER_RETORNOS = value; }
        }

        public static string SCHEMA_NFE { get { return Pasta_StartupPath + "\\Schema\\NFe\\"; } }
        public static string SCHEMA_NFSE { get { return Pasta_StartupPath + "\\Schema\\NFe-s\\"; } }
        public static string SCHEMA_CCE { get { return Pasta_StartupPath + "\\Schema\\CCe\\"; } }
        public static string SCHEMA_CTE { get { return Pasta_StartupPath + "\\Schema\\CTe\\"; } }

    }
}
