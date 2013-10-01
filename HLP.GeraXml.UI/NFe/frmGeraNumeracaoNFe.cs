using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using HLP.GeraXml.bel.NFe.Estrutura;
using System.Linq;
using System.Data.Entity;
using HLP.GeraXml.Comum.Static;
namespace HLP.GeraXml.UI.NFe
{
    public partial class frmGeraNumeracaoNFe : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        public bool bGerouNumeracao = false;
        private belNumeroNF objbelNumeracao = null;
        public bool bGerou = false;
        private bool bNotaServico;
        public frmGeraNumeracaoNFe(belNumeroNF _objbelNumeracao, bool _bNotaServico)
        {
            InitializeComponent();
            this.bNotaServico = _bNotaServico;
            this.objbelNumeracao = _objbelNumeracao;
            cbxGrupos.DisplayMember = "ds_descvalor";
            cbxGrupos.ValueMember = "ds_valor";
            dao.daoConfiguracao objdaoConfig = new dao.daoConfiguracao();
            cbxGrupos.DataSource = objdaoConfig.populaComboGruposFat();
            cbxGrupos.cbx.Enabled = false;
            if (!string.IsNullOrEmpty(Acesso.GRUPO_SERVICO))
            {
                cbxGrupos.cbx.SelectedValue = Acesso.GRUPO_SERVICO;
            }
        }

        private void frmGeraNumeracaoNFe_Load(object sender, EventArgs e)
        {
            try
            {
                txtUltimo.Text = objbelNumeracao.BuscaUltimoNumeroNF().PadLeft(6, '0');
                txtUltimo.txt.ReadOnly = true;
                int iNumeroASerEmi = Convert.ToInt32(txtUltimo.Text);
                iNumeroASerEmi++;
                txtProximo.Text = iNumeroASerEmi.ToString().PadLeft(6, '0');
                btnGerar.Focus();
            }
            catch (Exception ex)
            {
                new HLP.GeraXml.Comum.HLPexception(ex);
            }

        }

        private void btnGerar_Click(object sender, EventArgs e)
        {
            btnGerar.Enabled = false;
            pgStatus.Style = ProgressBarStyle.Marquee;
            if (worker.IsBusy != true)
            {
                worker.RunWorkerAsync();
            }
        }

        private void GerarNumeracao(DoWorkEventArgs e)
        {
            try
            {
                this.Invoke(new MethodInvoker(delegate()
                {
                    lblStatus.Text = "Validando sequencias no banco, aguarde...";
                    statusStrip1.Refresh();
                }));
                objbelNumeracao.ValidaSequenciaNoBanco(Convert.ToInt32(txtProximo.Text));
                if (!this.worker.CancellationPending)
                {
                    this.Invoke(new MethodInvoker(delegate()
                    {
                        lblStatus.Text = "Alterando duplicatas...";
                        statusStrip1.Refresh();
                    }));
                    objbelNumeracao.AlteraDuplicatas(bNotaServico);
                }
                else
                {
                    e.Cancel = true;                    
                }

                if (!this.worker.CancellationPending)
                {
                    this.Invoke(new MethodInvoker(delegate()
                   {
                       this.Hide();
                       KryptonMessageBox.Show(null, "Numeração gerada com sucesso!", "Gerar Números de Notas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                       bGerou = true;
                       this.Close();
                   }));
                }
                else
                {
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                new HLP.GeraXml.Comum.HLPexception(ex);
            }
        }

        private void frmGeraNumeracaoNFe_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (worker.IsBusy)
            {
                worker.CancelAsync();               
            }
        }

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            GerarNumeracao(e);
        }
    }
}