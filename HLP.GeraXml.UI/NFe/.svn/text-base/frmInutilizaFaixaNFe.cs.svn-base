using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using HLP.GeraXml.dao;
using HLP.GeraXml.Comum.Static;
using HLP.GeraXml.bel.NFe;

namespace HLP.GeraXml.UI.NFe
{
    public partial class frmInutilizaFaixaNFe : KryptonForm
    {
        public frmInutilizaFaixaNFe()
        {
            InitializeComponent();
        }
        private void frmInutilizacao_Load(object sender, EventArgs e)
        {
            txtNNFfim.txt.Validated += new EventHandler(txtNNFfim_Validated);
            txtNNFini.txt.Validated += new EventHandler(txtNNFini_Validated);
            cbxSerie.cbx.Items.Add(daoUtil.BuscaSerieEmpresa());
            cbxSerie.cbx.Items.Add(Acesso.SERIE_SCAN);
            cbxSerie.cbx.SelectedIndex = 0;

        }

        private void txtNNFini_Validated(object sender, EventArgs e)
        {
            txtNNFini.Text = txtNNFini.Text.PadLeft(9, '0'); // Nfe_2.0
            txtNNFfim.Text = txtNNFini.Text;
        }

        private void txtNNFfim_Validated(object sender, EventArgs e)
        {
            txtNNFfim.Text = txtNNFfim.Text.PadLeft(9, '0');// Nfe_2.0
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidaCampos() == 0)
                {
                    belInutilizacao objbelInut = new belInutilizacao(txtNNFini.Text, txtNNFfim.Text, cbxSerie.cbx.Text, txtXjust.Text);
                    KryptonMessageBox.Show(belTrataMensagemNFe.RetornaMensagem(objbelInut.InutilizaNumeracao(), belTrataMensagemNFe.Tipo.Inutilizacao), Mensagens.CHeader, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    throw new Exception("Verifique os Campos Obrigatórios");
                }
                this.Close();
            }
            catch (Exception ex)
            {
                new HLP.GeraXml.Comum.HLPexception(ex);
            }
        }
        private int ValidaCampos()
        {
            int icount = 0;
            txtNNFini.errorProvider1.Dispose();
            txtNNFfim.errorProvider1.Dispose();
            txtXjust.errorProvider1.Dispose();
            if (txtNNFini.Text == "")
            {
                icount++;
                txtNNFini.errorProvider1.SetError(txtNNFini, "Campo Obrigatório");
            }
            if (txtNNFfim.Text == "")
            {
                icount++;
                txtNNFfim.errorProvider1.SetError(txtNNFfim, "Campo Obrigatório");
            }
            if (txtXjust.Text == "")
            {
                icount++;
                txtXjust.errorProvider1.SetError(txtXjust, "Campo Obrigatório");
            }
            return icount;
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmInutilizaFaixaNFe_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }


    }
}
