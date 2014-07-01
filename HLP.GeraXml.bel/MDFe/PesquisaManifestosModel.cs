using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HLP.GeraXml.bel.MDFe
{
    public class PesquisaManifestosModel
    {
        private bool _bSeleciona = false;
        public bool bSeleciona
        {
            get { return _bSeleciona; }
            set
            {
                _bSeleciona = value;               
            }
        }
        public string cd_empresa { get; set; }
        public string sequencia { get; set; }
        public string numero { get; set; }
        public string chaveMDFe { get; set; }
        public string protocolo { get; set; } // criar
        public string recibo { get; set; }
        public string status { get; set; }
        public string dt_manife { get; set; }
        public bool bEnviado { get; set; }
        public bool bCancelado { get; set; }
        public string descricao { get; set; }
    }
}
