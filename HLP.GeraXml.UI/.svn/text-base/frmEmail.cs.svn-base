using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HLP.GeraXml.bel;
using ComponentFactory.Krypton.Toolkit;
using System.Text.RegularExpressions;
using HLP.GeraXml.Comum.Static;
using HLP.GeraXml.Comum;

namespace HLP.GeraXml.UI
{
    public partial class frmEmail : KryptonForm
    {
        Regex remail = new Regex(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$");
        public List<belEmail> objListaEmail;
        belEmail.TipoEmail tipo;




        public frmEmail(List<belEmail> objListaEmail, belEmail.TipoEmail tipo)
        {
            InitializeComponent();
            try
            {
                this.objListaEmail = objListaEmail;
                this.tipo = tipo;
                PopulaDataGrid();
                VerificaEmail();
            }
            catch (Exception ex)
            {
                new HLPexception(ex);
            }
        }


        private void PopulaDataGrid()
        {
            try
            {
                for (int i = 0; i < objListaEmail.Count; i++)
                {
                    dgvEmail.Rows.Add();

                    dgvEmail["Enviar", i].Value = true;
                    dgvEmail["sNumDocumento", i].Value = objListaEmail[i].sSeq;
                    dgvEmail["sDestinatario", i].Value = objListaEmail[i].sDestinatario;
                    dgvEmail["sOutros", i].Value = objListaEmail[i].sOutros;
                }
            }
            catch (Exception ex)
            {
                new HLPexception(ex);
            }
        }
        private bool VerificaEmail()
        {
            bool ret = true;
            for (int i = 0; i < dgvEmail.RowCount; i++)
            {
                if (Convert.ToBoolean(dgvEmail[0, i].Value))
                {

                    if (!remail.IsMatch(dgvEmail["sDestinatario", i].Value.ToString()))
                    {
                        dgvEmail["sDestinatario", i].Style.BackColor = Color.Red;
                        ret = false;
                    }
                    else
                    {
                        dgvEmail["sDestinatario", i].Style.BackColor = Color.White;
                    }
                    if (!VerificaCampoOutros(i))
                    {
                        ret = false;
                    }
                }                


            }
            return ret;
        }
        private bool VerificaCampoOutros(int row)
        {
            bool ret = true;
            string sOutros = dgvEmail["sOutros", row].Value.ToString();
            if (sOutros != "")
            {
                string[] Outros = sOutros.Split(';');
                foreach (string Copia in Outros)
                {
                    if (Copia.Trim() != "")
                    {
                        if (!remail.IsMatch(Copia.Trim()))
                        {
                            dgvEmail["sOutros", row].Style.BackColor = Color.Red;
                            ret = false;
                        }
                    }
                }
            }
            else
            {
                dgvEmail["sOutros", row].Style.BackColor = Color.White;
            }
            return ret;
        }


        private void btnEnviar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!VerificaEmail())
                {
                    KryptonMessageBox.Show(null,
                        "Existem erros de nomenclatura de Email, Favor verificar as tarjas vermelhas", Mensagens.CHeader,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                else
                {
                    for (int i = 0; i < dgvEmail.RowCount; i++)
                    {
                        objListaEmail[i].Enviar = Convert.ToBoolean(dgvEmail["Enviar", i].Value);
                        objListaEmail[i].sDestinatario = dgvEmail["sDestinatario", i].Value.ToString();
                        objListaEmail[i].sOutros = dgvEmail["sOutros", i].Value.ToString();
                    }
                    belEmail objEmail = new belEmail(tipo);
                    objEmail.EnviarEmail(objListaEmail);
                    KryptonMessageBox.Show("E-mail enviado com sucesso!", Mensagens.CHeader, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                new HLPexception(ex);
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvEmail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 0 && e.RowIndex > -1)
                {
                    SendKeys.Send("{right}");
                    SendKeys.Send("{left}");
                }
            }
            catch (Exception ex)
            {
                new HLPexception(ex);
            }
        }


    }
}
