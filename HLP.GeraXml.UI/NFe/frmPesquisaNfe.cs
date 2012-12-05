using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using System.Text.RegularExpressions;
using HLP.GeraXml.bel.NFe.Estrutura;
using HLP.GeraXml.Comum.Static;
using HLP.GeraXml.bel.NFe;

namespace HLP.GeraXml.UI.NFe
{
    public partial class frmPesquisaNfe : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        private string _campoPesquisa = "nf.cd_notafis";
        public belCampoPesquisa objbelCampoPesquisa { get; set; }

        /// <summary>
        /// Pesquisa Notas para Referenciar
        /// </summary>
        public frmPesquisaNfe()
        {
            InitializeComponent();
        }
        private void PesquisaNF_Load(object sender, EventArgs e)
        {
            cbxCampoPesquisa.cbx.SelectedIndex = 0;
            cbxOperador.cbx.SelectedIndex = 0;
            cbxModelo.cbx.SelectedIndex = 0;
            cbxTipoNf.cbx.SelectedIndex = 0;

            dgvPesquisa.Columns["cUF"].Visible = false;
            dgvPesquisa.Columns["AAMM"].Visible = false;
            dgvPesquisa.Columns["CNPJ"].Visible = false;
            dgvPesquisa.Columns["serie"].Visible = false;
            cbxCampoPesquisa.cbx.SelectionChangeCommitted += new EventHandler(cbxCampoPesquisa_SelectionChangeCommitted);
            cbxCampoPesquisaEntrada.cbx.SelectionChangeCommitted += new EventHandler(cbxCampoPesquisaEntrada_SelectionChangeCommitted);
            txtPesquisa.txt.Validated += new EventHandler(txtPesquisa_Validated);
            txtPesquisa.txt.Validating += new CancelEventHandler(txtPesquisa_Validating);
            txtPesquisa.txt.Enter += new EventHandler(txtPesquisa_Enter);
            cbxModelo.cbx.SelectedIndexChanged += new EventHandler(cbxModelo_SelectedIndexChanged);
            cbxTipoNf.cbx.SelectedIndexChanged += new EventHandler(cbxTipoNf_SelectedIndexChanged);
            cbxTipoNf.cbx.SelectedIndex = 0;
            cbxCampoPesquisaEntrada.Enabled = false;
        }



        private void Pesquisar()
        {
            StringBuilder sSql = new StringBuilder();
            try
            {
                if (txtPesquisa.Text == "")
                {
                    KryptonMessageBox.Show(txtPesquisa._LabelText + " está Vazio");
                }
                else if (cbxCampoPesquisa.cbx.SelectedIndex == -1)
                {
                    KryptonMessageBox.Show("Campo de Pesquisa está vazio");
                }
                else if (cbxOperador.cbx.SelectedIndex == -1)
                {
                    KryptonMessageBox.Show("Campo Operador esta Vazio");
                }
                else
                {
                    belPesquisaNFeRef objbelPesquisaNotas = new belPesquisaNFeRef();
                    dgvPesquisa.DataSource = objbelPesquisaNotas.PesquisaNotasRef(cbxOperador.cbx.SelectedIndex, cbxModelo.cbx.SelectedIndex, _campoPesquisa, txtPesquisa.Text.Trim());
                }
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(ex.Message); ;
            }
        }
        private void PesquisarEntrada()
        {
            StringBuilder sSql = new StringBuilder();
            try
            {
                if (txtPesquisa.Text == "")
                {
                    KryptonMessageBox.Show(txtPesquisa._LabelText + " está Vazio");
                }
                else if (cbxCampoPesquisa.cbx.SelectedIndex == -1)
                {
                    KryptonMessageBox.Show("Campo de Pesquisa está vazio");
                }
                else if (cbxOperador.cbx.SelectedIndex == -1)
                {
                    KryptonMessageBox.Show("Campo Operador esta Vazio");
                }
                else
                {
                    belPesquisaNFeRef objbelPesquisaNotas = new belPesquisaNFeRef();
                    dgvPesquisa.DataSource = objbelPesquisaNotas.PesquisaNotasRefEntrada(cbxOperador.cbx.SelectedIndex, cbxModelo.cbx.SelectedIndex, _campoPesquisa, txtPesquisa.Text.Trim());
                }
            }
            catch (Exception ex)
            {

                KryptonMessageBox.Show(ex.Message); ;
            }
        }





        private void cbxCampoPesquisa_SelectionChangeCommitted(object sender, EventArgs e)
        {
            switch (cbxCampoPesquisa.cbx.SelectedIndex)
            {
                case 0:
                    {
                        txtPesquisa.MaxLength = 7;
                        _campoPesquisa = "nf.cd_notafis";
                        break;
                    }
                case 1:
                    {
                        txtPesquisa.MaxLength = 7;
                        _campoPesquisa = "nf.cd_nfseq";
                        break;
                    }
                case 2:
                    {
                        txtPesquisa.MaxLength = 44;
                        _campoPesquisa = " nf.cd_chavenfe";
                        break;
                    }
            }

        }
        private void cbxCampoPesquisaEntrada_SelectionChangeCommitted(object sender, EventArgs e)
        {
            switch (cbxCampoPesquisaEntrada.cbx.SelectedIndex)
            {
                case 0:
                    {
                        txtPesquisa.MaxLength = 10;
                        _campoPesquisa = " movensai.cd_doc ";
                        break;
                    }
                case 1:
                    {
                        txtPesquisa.MaxLength = 9;
                        _campoPesquisa = " movensai.cd_mov ";
                        break;
                    }
                case 2:
                    {
                        txtPesquisa.MaxLength = 44;
                        _campoPesquisa = " movensai.cd_chave_nfe ";
                        break;
                    }
            }

        }
        private void btnPesquisa_Click(object sender, EventArgs e)
        {
            if (cbxTipoNf.cbx.SelectedIndex == 0)
            {
                Pesquisar();
            }
            else
            {
                PesquisarEntrada();
            }



        }
        private void dgvPesquisa_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex > -1)
            {
                objbelCampoPesquisa = new belCampoPesquisa();
                objbelCampoPesquisa = objbelCampoPesquisa.RetornaCampoSelecionado((dgvPesquisa.DataSource as List<belCampoPesquisa>), dgvPesquisa[1, e.RowIndex].Value.ToString());
                this.Close();
            }

        }
        private void txtPesquisa_Validated(object sender, EventArgs e)
        {
            switch (cbxCampoPesquisa.cbx.SelectedIndex)
            {
                case 0:
                    {
                        if (cbxTipoNf.cbx.SelectedIndex == 0)
                        {
                            txtPesquisa.Text = txtPesquisa.Text.PadLeft(6, '0');
                        }
                        break;
                    }
                case 1:
                    {
                        if (cbxTipoNf.cbx.SelectedIndex == 0)
                        {
                            txtPesquisa.Text = txtPesquisa.Text.PadLeft(6, '0');
                        }
                        else
                        {
                            txtPesquisa.Text = txtPesquisa.Text.PadLeft(7, '0');
                        }
                        break;
                    }
                case 2:
                    {
                        txtPesquisa.Text = txtPesquisa.Text.PadLeft(44, '0');
                        break;
                    }
            }
        }
        private void txtPesquisa_Validating(object sender, CancelEventArgs e)
        {
            if (txtPesquisa.Text != "")
            {
                Regex m = new Regex("^[0-9]+$");
                if (!m.IsMatch(txtPesquisa.Text))
                {
                    KryptonMessageBox.Show("Campo Numérico, não é aceito letras");
                    e.Cancel = true;
                }
            }
        }
        private void txtPesquisa_Enter(object sender, EventArgs e)
        {
            txtPesquisa.txt.SelectionLength = txtPesquisa.Text.Length;

        }
        private void cbxModelo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxModelo.cbx.SelectedIndex == 0)
            {
                dgvPesquisa.Columns["ChaveAcesso"].Visible = true;
            }
            else
            {
                dgvPesquisa.Columns["ChaveAcesso"].Visible = false;
            }
        }
        private void cbxTipoNf_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxTipoNf.cbx.SelectedIndex == 0) // Saída
            {
                cbxCampoPesquisa.Enabled = true;
                cbxCampoPesquisaEntrada.Enabled = false;
                cbxCampoPesquisa.cbx.SelectedIndex = 0;
                cbxCampoPesquisa_SelectionChangeCommitted(sender, e);
                dgvPesquisa.Columns["SeqNF"].HeaderText = "Sequencia";

            }
            else //Entrada
            {
                cbxCampoPesquisa.Enabled = false;
                cbxCampoPesquisaEntrada.Enabled = true;
                cbxCampoPesquisaEntrada.cbx.SelectedIndex = 0;
                cbxCampoPesquisaEntrada_SelectionChangeCommitted(sender, e);
                dgvPesquisa.Columns["SeqNF"].HeaderText = "Lançamento";
            }
        }
        private void label3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}