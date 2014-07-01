using ComponentFactory.Krypton.Toolkit;
using HLP.GeraXml.bel.MDFe;
using HLP.GeraXml.bel.MDFe.Acoes;
using HLP.GeraXml.Comum;
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
    public partial class frmCancelarMDFe : Form
    {
        PesquisaManifestosModel objPesquisa;
        public frmCancelarMDFe(PesquisaManifestosModel objPesquisa)
        {
            this.objPesquisa = objPesquisa;
            InitializeComponent();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
            throw new Exception("Cancelamento não foi Realizado.");
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtJust.Text.Length < 15)
                {
                    MessageBox.Show("Mínimo de caracteres esperado.", "A V I S O", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    belCancelamentoMDFe objcanc = new belCancelamentoMDFe(this.objPesquisa, txtJust.Text);
                    string sMessage = objcanc.ExecuteCancelamento();
                    MessageBox.Show(sMessage, "A V I S O", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                this.Close();
            }
            catch (Exception ex)
            {
                new HLPexception(ex);
            }
        }
    }
}
