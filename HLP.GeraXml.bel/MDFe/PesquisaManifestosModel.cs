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
                if (value == true)
                {
                    if (this.recibo != "")
                    {
                        DateTime? d = HLP.GeraXml.dao.CTe.MDFe.daoManifesto.GetUltimoRetorno(this.sequencia);

                        if (d != null)
                        {
                            if (((DateTime)d).AddMinutes(2) < dao.daoUtil.GetDateServidor())
                                _bSeleciona = value;
                            else
                            {
                                _bSeleciona = false;
                                MessageBox.Show(string.Format("Último retorno foi a menos de 2 minutos ({0}), aguarde mais um pouco.", d.ToString()), "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
            }
        }

        public string cd_empresa { get; set; }
        public string sequencia { get; set; }
        public string numero { get; set; }
        public string chaveMDFe { get; set; }
        public string recibo { get; set; }
        public string dt_manife { get; set; }
        public bool bEnviado { get; set; }
        public bool bCancelado { get; set; }
        public string descricao { get; set; }
    }
}
