using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using HLP.GeraXml.Comum;
using HLP.GeraXml.Comum.Static;
using System.Runtime.Serialization.Formatters.Soap;
using System.IO;
using System.Xml.Serialization;

namespace HLP.GeraXml.UI
{
    public partial class frmInformacao : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        string sMensagem = "";
        public frmInformacao()
        {
            InitializeComponent();
            Rectangle r = Screen.PrimaryScreen.WorkingArea;
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width - this.Width - 15, Screen.PrimaryScreen.WorkingArea.Height - this.Height - 30);
        }
        public frmInformacao(string sMensagem)
        {
            InitializeComponent();
            this.Size = new Size(265, 100);
            Rectangle r = Screen.PrimaryScreen.WorkingArea;
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width - this.Width - 15, Screen.PrimaryScreen.WorkingArea.Height - this.Height - 30);

            this.sMensagem = sMensagem;
            lblNfe.Text = sMensagem;
            lblNfs.Visible = false;
            lblCte.Visible = false;
            flpTpEmiss.Visible = false;
        }



        private void frmStatus_Load(object sender, EventArgs e)
        {
            try
            {
                if (sMensagem == "")
                {
                    if (Acesso.NM_RAMO == Acesso.BancoDados.TRANSPORTE)
                    {
                        lblNfe.Visible = false;
                        lblNfs.Visible = false;
                        lblCte.Visible = true;

                        lblCte.Text = "CT-e: " + (Acesso.TP_AMB == 1 ? "Produção" : "Homologação");
                    }
                    else
                    {
                        lblNfe.Visible = true;
                        lblNfs.Visible = true;
                        lblCte.Visible = false;

                        lblNfe.Text = "NF-e: " + (Acesso.TP_AMB == 1 ? "Produção" : "Homologação");
                        lblNfs.Text = "NF-e Serviço: " + (Acesso.TP_AMB_SERV == 1 ? "Produção" : "Homologação");
                    }
                    switch (Acesso.TP_EMIS)
                    {
                        case 1: rbNormal.Checked = true;
                            break;

                        case 2: rbCont.Checked = true;
                            break;

                        case 3: rbScan.Checked = true;
                            break;
                        case 6: rbNacional.Checked = true;
                            break;
                    }

                }
                timerLoad.Start();
            }
            catch (Exception ex)
            {
                new HLPexception(ex);
            }
        }
        private void frmStatus_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
        private void frmStatus_Deactivate(object sender, EventArgs e)
        {
            this.Close();
        }






        private void control_MouseMove(object sender, MouseEventArgs e)
        {
            timerFechaTela.Stop();
            this.Opacity = 1;
        }
        private void control_MouseLeave(object sender, EventArgs e)
        {
            iSec = 0;
            timerLoad.Start();
        }


        int iSec = 0;
        private void timerLoad_Tick(object sender, EventArgs e)
        {
            iSec++;
            if (iSec == 3)
            {
                timerLoad.Stop();
                timerFechaTela.Start();
            }
        }
        private void timerFechaTela_Tick(object sender, EventArgs e)
        {
            this.Opacity -= 0.04;
            if (this.Opacity < 0.1)
            {
                this.Close();
            }

        }

        private void frmInformacao_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                bool Fecha = false;
                if (rbNormal.Checked && Acesso.TP_EMIS != 1)
                {
                    AlteraConfig(1);
                    Fecha = true;
                }
                else if (rbCont.Checked && Acesso.TP_EMIS != 2)
                {
                    AlteraConfig(2);
                    Fecha = true;


                }
                else if (rbScan.Checked && Acesso.TP_EMIS != 3)
                {
                    AlteraConfig(3);
                    Fecha = true;
                }
                if (Fecha)
                {
                    foreach (Control crt in ((Application.OpenForms[0]) as frmPrincipal).splitContainerTela.Panel2.Controls)
                    {
                        if (crt.GetType().BaseType == typeof(KryptonForm))
                        {
                            ((Form)crt).Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                new HLPexception(ex);
            }
        }

        private void AlteraConfig(int iEmissao)
        {
            XmlSerializer s = new XmlSerializer(typeof(belConfiguracao));
            Stream file = new FileStream(Pastas.PASTA_XML_CONFIG + Acesso.NM_CONFIG,
                FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite);

            belConfiguracao objbelConfiguracao = new belConfiguracao();
            objbelConfiguracao = (belConfiguracao)s.Deserialize(file);
            file.Dispose();

            objbelConfiguracao.TP_EMIS = iEmissao;

            s = new XmlSerializer(typeof(belConfiguracao));
            FileStream f = File.Create(Pastas.PASTA_XML_CONFIG + Acesso.NM_CONFIG);
            s.Serialize(f, objbelConfiguracao);
            f.Close();
            f.Dispose();
            Acesso.TP_EMIS = iEmissao;
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}