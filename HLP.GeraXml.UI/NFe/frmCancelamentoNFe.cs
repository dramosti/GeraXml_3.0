using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using HLP.GeraXml.Comum.Static;
using HLP.GeraXml.bel.NFe;
using HLP.GeraXml.Comum;

namespace HLP.GeraXml.UI.NFe
{
    public partial class frmCancelamentoNFe : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        public belPesquisaNotas objbelPesquisa = new belPesquisaNotas();
        public frmCancelamentoNFe(belPesquisaNotas _objPesquisa)
        {
            InitializeComponent();
            this.objbelPesquisa = _objPesquisa;
            txtJust.txt.ScrollBars = ScrollBars.Vertical;
            txtJust.txt.CharacterCasing = CharacterCasing.Upper;
            txtJust.txt.KeyPress += new KeyPressEventHandler(txt_KeyPress);
        }


        private void txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            errorProvider1.Dispose();
            lblContador.Text = "Total de Caracteres = " + txtJust.Text.Length.ToString();
            if (txtJust.Text.Length < 15 || txtJust.Text.Length > 256)
            {
                errorProvider1.SetError(txtJust, "Justificativa inválida." + Environment.NewLine + "Mínimo de 15 e máximo de 256 caractéres esperado.");
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                errorProvider1.Dispose();
                string sValorJust = txtJust.Text.Trim();
                if (sValorJust != "" && sValorJust.Length >= 15 && sValorJust.Length <= 256)
                {
                    belCancelamento objbelCanc = new belCancelamento();
                    objbelCanc.EfetuaCancelamento(objbelPesquisa, sValorJust, 1);
                    KryptonMessageBox.Show(belTrataMensagemNFe.RetornaMensagem(objbelCanc.objRetorno, belTrataMensagemNFe.Tipo.Cancelamento), Mensagens.CHeader, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    errorProvider1.SetError(txtJust, "Justificatíva inválida.");
                    KryptonMessageBox.Show("Justificativa inválida." + Environment.NewLine + "Mínimo de 15 e máximo de 256 caractéres esperado.", Mensagens.CHeader, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                new HLPexception(ex);
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}