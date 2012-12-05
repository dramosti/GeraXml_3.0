using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using ComponentFactory.Krypton.Toolkit;
using HLP.GeraXml.Comum.Static;
using HLP.GeraXml.Comum;

namespace HLP.GeraXml.UI.Configuracao
{
    public partial class frmLoginConfig : KryptonForm
    {
        public frmLoginConfig()
        {
            InitializeComponent();
            if (Acesso.bALTER_CONFIG || Acesso.NM_USER.ToUpper().Contains("MASTER"))
            {
                Acesso.bALTER_CONFIG = true;
                txtSenha.Enabled = false;
            }
        }



        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Acesso.bALTER_CONFIG)
                {
                    if (txtSenha.Text.ToUpper().Equals("MASTERPC"))
                    {
                        if ((chkNovo.Checked) && (txtNomeArquivo.Text == ""))
                        {
                            errorProvider1.SetError(txtNomeArquivo, "Insira um nome para o Arquivo");
                            txtNomeArquivo.Focus();
                            throw new Exception("Verifique as Pendências");
                        }
                        if ((cbxArquivos.cbx.Items.Count == 0) && !(chkNovo.Checked))
                        {
                            errorProvider1.SetError(txtNomeArquivo, "Insira um nome para o Arquivo");
                            chkNovo.Checked = true;
                            txtNomeArquivo.Focus();
                            throw new Exception("Verifique as Pendências");
                        }
                        if (cbxArquivos.SelectedIndex == -1 && !chkNovo.Checked)
                        {
                            cbxArquivos.Focus();
                            throw new Exception("Selecione um arquivo para configurar");
                        }
                    }
                    else
                    {
                        txtSenha.Focus();
                        throw new Exception("Senha Incorreta");
                    }
                }
                this.Hide();
                if (chkNovo.Checked)
                {
                    Acesso.NM_CONFIG_TEMP = txtNomeArquivo.Text + ".xml";
                }
                else
                {
                    Acesso.NM_CONFIG_TEMP = cbxArquivos.Text;
                }
                frmConfiguracao objfrm = new frmConfiguracao();
                objfrm.ShowDialog();
                this.Close();
            }
            catch (Exception ex)
            {
                new HLPexception(ex);
            }
        }


        private void frmLoginConfig_Load(object sender, EventArgs e)
        {
            try
            {
                chkNovo.chk.CheckedChanged += new EventHandler(chkNovo_CheckedChanged);
                txtNomeArquivo.Enabled = false;
                DirectoryInfo dinfo = new DirectoryInfo(Pastas.PASTA_XML_CONFIG);
                FileInfo[] finfo = dinfo.GetFiles();

                foreach (FileInfo item in finfo)
                {
                    if (Path.GetExtension(item.FullName).ToUpper().Equals(".XML"))
                    {
                        cbxArquivos.cbx.Items.Add(item.Name);
                    }
                }
                if (!String.IsNullOrEmpty(Acesso.NM_CONFIG))
                {
                    cbxArquivos.Text = Acesso.NM_CONFIG.Replace("\\", "");
                }
                else if (cbxArquivos.cbx.Items.Count > 0)
                {
                    cbxArquivos.cbx.SelectedIndex = 0;
                }
                cbxArquivos.Focus();
            }
            catch (Exception ex)
            {
                new HLPexception(ex);
            }
        }

        private void chkNovo_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkNovo.Checked)
                {
                    txtNomeArquivo.Enabled = true;
                    cbxArquivos.Enabled = false;
                    txtNomeArquivo.Focus();
                }
                else
                {
                    txtNomeArquivo.Enabled = false;
                    txtNomeArquivo.Text = "";
                    cbxArquivos.Enabled = true;
                    cbxArquivos.Focus();
                }
            }
            catch (Exception ex)
            {
                new HLPexception(ex);
            }
        }





        private void frmLoginConfig_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }


    }
}
