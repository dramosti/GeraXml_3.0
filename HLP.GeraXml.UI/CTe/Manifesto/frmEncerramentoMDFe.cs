using ComponentFactory.Krypton.Toolkit;
using HLP.GeraXml.bel.MDFe;
using HLP.GeraXml.bel.MDFe.Acoes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HLP.GeraXml.UI.CTe.Manifesto
{
    public partial class frmEncerramentoMDFe : KryptonForm
    {
        PesquisaManifestosModel objPesquisa;
        public frmEncerramentoMDFe(PesquisaManifestosModel objPesquisa)
        {
            this.objPesquisa = objPesquisa;
            InitializeComponent();
            cbxCidades.DataSource = belMunicipios.GetMunicipios();
            cbxCidades.DisplayMember = "xMun";
            cbxCidades.ValueMember = "cMun";

        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbxCidades.SelectedIndex > -1)
                {
                    belMunicipios mun = cbxCidades.SelectedItem as belMunicipios;
                    belEncerramentoMDFe encerramento = new belEncerramentoMDFe(this.objPesquisa, mun.cUF, mun.cMun);
                    string sMessage = encerramento.Encerramento();
                    MessageBox.Show(sMessage, "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
