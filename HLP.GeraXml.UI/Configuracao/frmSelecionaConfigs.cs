using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using HLP.GeraXml.Comum.Static;
using System.IO;
using Microsoft.Win32;
using System.Xml;
using HLP.GeraXml.Comum;
using System.Reflection;

namespace HLP.GeraXml.UI.Configuracao
{
    public partial class frmSelecionaConfigs : KryptonForm
    {
        public bool ArquivoSelecionado = false;

        public frmSelecionaConfigs()
        {
            InitializeComponent();
            if (System.Diagnostics.Debugger.IsAttached)
            {
                btnPublicar.Visible = true;
                btnPublicar.Text = string.Format(btnPublicar.Text, Assembly.GetEntryAssembly().GetName().Version);
            }

        }

        private void frmSelecionaConfigs_Load(object sender, EventArgs e)
        {
            txtXmlConfig.txt.ReadOnly = true;
            if (Pastas.PASTA_XML_CONFIG != null)
            {
                txtXmlConfig.Text = Pastas.PASTA_XML_CONFIG.ToString();
            }
            ButtonSpecAny btnPesquisar = new ButtonSpecAny();
            btnPesquisar.Image = HLP.GeraXml.UI.Properties.Resources.Pasta;
            btnPesquisar.Style = ComponentFactory.Krypton.Toolkit.PaletteButtonStyle.InputControl;
            btnPesquisar.Click += new System.EventHandler(btnCaminhoXml_Click);
            txtXmlConfig.txt.ButtonSpecs.Add(btnPesquisar);

            CarregaNomeArquivos();

        }


        private void CarregaNomeArquivos()
        {
            try
            {
                if (Pastas.PASTA_XML_CONFIG != "")
                {
                    DirectoryInfo dinfo = new DirectoryInfo(Pastas.PASTA_XML_CONFIG);
                    FileInfo[] finfo = dinfo.GetFiles();

                    foreach (FileInfo item in finfo)
                    {
                        if (Path.GetExtension(item.FullName).ToUpper().Equals(".XML"))
                        {
                            cbxConfig.cbx.Items.Add(item.Name);
                        }
                    }
                    if (cbxConfig.cbx.Items.Count > 0)
                    {
                        cbxConfig.cbx.SelectedIndex = 0;
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        private void btnCaminhoXml_Click(object sender, EventArgs e)
        {
            string scaminho = Pastas.PASTA_XML_CONFIG;
            frmLocalXml objfrm = new frmLocalXml(Pastas.PASTA_XML_CONFIG);
            objfrm.ShowDialog();
            if (scaminho != Pastas.PASTA_XML_CONFIG)
            {
                Application.Restart();
                // Application.Exit();
            }
        }

        private void btnContinuar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbxConfig.cbx.Items.Count > 0)
                {
                    if (cbxConfig.Text != "")
                    {
                        if (cbxConfig.Text.Replace(".xml", "").ToUpper().Equals("ESCRITA"))
                        {
                            Acesso.bESCRITA = true;
                        }
                        ArquivoSelecionado = true;
                        Acesso.NM_CONFIG_TEMP = cbxConfig.Text;
                        this.Close();
                    }
                    else
                    {
                        KryptonMessageBox.Show(null, "Selecione um arquivo de Configuração", Mensagens.MSG_Alerta, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    KryptonMessageBox.Show(null, "Não existem arquivos na pasta de Configuração", Mensagens.MSG_Alerta, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            }
            catch (Exception ex)
            {
                new HLPexception(ex);
            }
        }

        private void frmSelecionaConfigs_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            frmPublishVersiion frm = new frmPublishVersiion();
            frm.Show();
        }
    }
}