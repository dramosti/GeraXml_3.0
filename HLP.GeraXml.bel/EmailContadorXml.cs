using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HLP.GeraXml.Comum.Static;

namespace HLP.GeraXml.bel
{
    [Serializable]
    public class ConfigEmailContadorXml
    {
        public tpConfig Alerta { get; set; }
        public DayOfWeek dia { get; set; }
        public DateTime dtUltimoEnvio { get; set; }
        public enum tpConfig { Semanalmente, Mensalmente };
        public List<Arquivos> arquivosTransmitidos = new List<Arquivos>();
    }
    public class Arquivos
    {
        public string mmYY { get; set; }
        public string nameXml { get; set; }
        public tpArquivo tipoArquivo { get; set; }
        public enum tpArquivo { Enviado, Cancelado, CCe };
    }

    public class PendenciaEmail
    {
        public bool Select { get; set; }
        public string sMes { get; set; }
        public string sAno { get; set; }
        public int iEnviados { get; set; }
        public int iFaltantes { get; set; }
        public string sPathZip { get; set; }
        public List<PendenciaArquivos> larquivosPendentes = new List<PendenciaArquivos>();
    }

    public class PendenciaArquivos
    {
        public Arquivos.tpArquivo tipoArquivo { get; set; }
        public string sPathFull { get; set; }
    }
}
