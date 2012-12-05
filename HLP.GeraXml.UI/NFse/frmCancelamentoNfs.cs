using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using HLP.GeraXml.bel.NFes;
using HLP.GeraXml.Comum;
using HLP.GeraXml.Comum.Static;
using System.Linq;

namespace HLP.GeraXml.UI.NFse
{
    public partial class frmCancelamentoNfs : ComponentFactory.Krypton.Toolkit.KryptonForm 
    {
        belCancelamentoNFse objbelCanc = new belCancelamentoNFse();
        List<belCancelamentoNFse> objListaAll = new List<belCancelamentoNFse>();
        public string sErro = "";

        public frmCancelamentoNfs()
        {
            InitializeComponent();
            txtFiltro.txt.TextChanged += new EventHandler(txt_TextChanged);
            cbxFiltro.cbx.SelectedIndexChanged += new EventHandler(cbx_SelectedIndexChanged);
            objListaAll = objbelCanc.RetListaErros();
            bsCancelamento.DataSource = objListaAll;
            cbxFiltro.SelectedIndex = 0;
            txtFiltro.Focus();
        }



        private void cbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFiltro.Text = "";
        }
        private void txt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbxFiltro.SelectedIndex == 0)
                {
                    bsCancelamento.DataSource = objListaAll.FindAll(l => l.cod.ToUpper().Contains(txtFiltro.Text.ToUpper())).ToList();
                }
                else
                {
                    bsCancelamento.DataSource = objListaAll.FindAll(l => l.msg.ToUpper().Contains(txtFiltro.Text.ToUpper())).ToList();
                }

                if (bsCancelamento.Count == 0)
                {
                    lblErro.Text = "";
                }
            }
            catch (Exception ex)
            {
                new HLPexception(ex);
            }
        }
        private void dgvTabErros_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex > -1)
                {
                    if (bsCancelamento.Count > 0)
                    {
                        txtSolucao.Text = dgvTabErros[2, e.RowIndex].Value.ToString();
                        lblErro.Text = "'" + dgvTabErros[0, e.RowIndex].Value.ToString() + "'";
                    }
                    else
                    {
                        lblErro.Text = "' '";
                    }
                }
                else
                {
                    lblErro.Text = "' '";
                }
            }
            catch (Exception ex)
            {
                new HLPexception(ex);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (bsCancelamento.Count == 0)
            {
                KryptonMessageBox.Show(null, "É necessário selecionar um Erro para cancelar a NFe-Serviço", Mensagens.MSG_Aviso, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                sErro = lblErro.Text.Replace("'", "").Trim();
                this.Close();
            }
        }


    }
}