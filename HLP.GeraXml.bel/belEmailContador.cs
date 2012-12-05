using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HLP.GeraXml.dao;
using System.Xml.Linq;
using System.IO;
using HLP.GeraXml.Comum.Static;

namespace HLP.GeraXml.bel
{
    public class belEmailContador : daoEmailContador
    {
        public int iId { get; set; }
        public bool Enviar { get; set; }
        public bool Enviado { get; set; }
        private string _sMes;
        public string sMes
        {
            get { return _sMes; }
            set { _sMes = value; }
        }
        public string sAno { get; set; }
        public int iFaltantes { get; set; }
        private int _iEnviadoContador;
        public int iEnviadoContador
        {
            get { return _iEnviadoContador; }
            set
            {
                _iEnviadoContador = value;
                iFaltantes = iFaltantes - _iEnviadoContador;
            }
        }
        public string sCaminhoEnviado { get; set; }
        public string sCaminhoCancelado { get; set; }
        public string sCaminhoCCe { get; set; }
        public string sCaminhoZip { get; set; }
        private string _sNomeArquivo;
        public string sNomeArquivo
        {
            get { return _sNomeArquivo; }
            set
            {
                _sNomeArquivo = value;
                sCaminhoZip = dinfo.FullName + "\\" + value.ToString();
            }
        }

        private XDocument _xmlArqEnviados;
        public XDocument xmlArqEnviados
        {
            get { return _xmlArqEnviados; }
            set { _xmlArqEnviados = value; }
        }


        public DirectoryInfo dinfo;
        public belEmailContador()
        {

            dinfo = new DirectoryInfo(Pastas.ENVIADOS + "\\Contador_xml");
            if (!dinfo.Exists)
            {
                dinfo.Create();
            }
        }
    }
}
