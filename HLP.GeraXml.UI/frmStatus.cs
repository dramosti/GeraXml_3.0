using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using HLP.GeraXml.bel.CTe;
using ComponentFactory.Krypton.Toolkit;
using HLP.GeraXml.Comum.Static;
using HLP.GeraXml.Comum;
using HLP.GeraXml.bel;

namespace HLP.GeraXml.UI
{
    public partial class frmStatus : KryptonForm
    {

        public frmStatus()
        {
            InitializeComponent();

        }
        private void frmStatus_Load(object sender, EventArgs e)
        {
            timerCertificado.Start();
        }



        int i = 0;
        private void timerWebService_Tick(object sender, EventArgs e)
        {
            if (i == 100)
            {
                timerWebService.Stop();
                belStatusServico.Mensagem = "Tempo limite de tentativas esgotado";
                belStatusServico.ServicoOperando = false;
            }
            else
            {
                progressBar1.PerformStep();
                lblTempo.Text = "Tempo Decorrido em Segundos: " + i;
                i++;
            }
        }

        private void timerCertificado_Tick(object sender, EventArgs e)
        {
            if (Acesso.bCERT_CONSULTA_SELECIONADO)
            {
                timerWebService.Start();
                progressBar1.Style = ProgressBarStyle.Blocks;
                lblMsg.Text = "Aguardando Retorno do WebService";
                lblTempo.Text = "Tempo Decorrido em Segundos: " + i;
                timerCertificado.Stop();

            }
        }

        private void frmStatus_FormClosing(object sender, FormClosingEventArgs e)
        {
            timerWebService.Stop();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            timerWebService.Stop();
            belStatusServico.Mensagem = "Ação Cancelada pelo Usuário";
            belStatusServico.ServicoOperando = false;
            belStatusServico.AcaoCancelada = true;
            this.Close();

        }

        private void frmStatus_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                btnCancelar_Click(null, null);
            }
        }
    }

}
