using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Microsoft.Win32;
using System.Security.AccessControl;
using ComponentFactory.Krypton.Toolkit;
using HLP.GeraXml.bel;
using HLP.GeraXml.Comum.Static;
using HLP.GeraXml.Comum;

namespace HLP.GeraXml.UI.Configuracao
{
    public partial class frmLocalXml : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        public frmLocalXml(string sCaminho)
        {
            InitializeComponent();
            txtCaminho.Text = @sCaminho;

            

            ButtonSpecAny btnPesquisar = new ButtonSpecAny();
            btnPesquisar.Image = HLP.GeraXml.UI.Properties.Resources.Pasta;
            btnPesquisar.Style = ComponentFactory.Krypton.Toolkit.PaletteButtonStyle.InputControl;
            btnPesquisar.Click += new System.EventHandler(btnPesquisar_Click);
            txtCaminho.txt.ButtonSpecs.Add(btnPesquisar);

        }


        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                txtCaminho.Text = fbd.SelectedPath;
            }
        }



        private void btnSair_Click_1(object sender, EventArgs e)
        {
            if (!txtCaminho.Text.Equals(""))
            {

                belRegedit.SalvarRegistro(Pastas.CONFIG.ToString(), Pastas.Caminho_xmls.ToString(), txtCaminho.Text);

                Pastas.PASTA_XML_CONFIG = txtCaminho.Text;

                this.Close();

            }
            else
            {
                if (KryptonMessageBox.Show(null, "Nenhum Caminho válido foi Selecionado, o Sistema será finalizado!"
                        + Environment.NewLine
                        + Environment.NewLine
                        + "Deseja selecionar uma outra Pasta?",
                        Mensagens.CHeader,
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) == DialogResult.No)
                {
                    this.Close();
                }

            }




        }

        private void frmLocalXml_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                btnSair_Click_1(sender, new EventArgs());
            }
        }
    }
}