using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using HLP.GeraXml.Comum.Componentes;

namespace HLP.GeraXml.Comum.Forms
{
    public partial class FormPadraoVisualizacao : ComponentFactory.Krypton.Toolkit.KryptonForm 
    {
        public bool Cancelado = false;
        public bool Enviado = false;
        public int iNotaAtual = 1;
        public int iTotalNotas = 0;


        public FormPadraoVisualizacao()
        {
            InitializeComponent();
        }
        private void FormPadraoVisualizacao_Load(object sender, EventArgs e)
        {
            bsNotas.MoveFirst();
            iTotalNotas = bsNotas.Count;
            lblContagemNotas.Text = "1 de " + iTotalNotas;
            DesabilitaCampos(this.Controls, false);
            EmEdicao(false);
        }
        private void FormPadraoVisualizacao_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!Enviado && !Cancelado)
            {
                if (KryptonMessageBox.Show("Deseja realmente Sair?", "A L E R T A", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Cancelado = true;
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }




        #region Botoes

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            Atualizar();
            EmEdicao(true);
        }
        public virtual void Atualizar()
        {
            DesabilitaCampos(this.Controls, true);
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Salvar();
        }
        public virtual void Salvar()
        {
            DesabilitaCampos(this.Controls, false);
            EmEdicao(false);
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            Enviar();
        }
        public virtual void Enviar()
        {
            Enviado = true;
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Cancelar();
        }
        public virtual void Cancelar()
        {
            DesabilitaCampos(this.Controls, false);
            EmEdicao(false);
        }

        public void btnPrimeiro_Click(object sender, EventArgs e)
        {
            Navegacao(sender);
        }
        private void btnAnterior_Click(object sender, EventArgs e)
        {
            Navegacao(sender);
        }
        public void btnProximo_Click(object sender, EventArgs e)
        {
            Navegacao(sender);
        }
        private void btnUltimo_Click(object sender, EventArgs e)
        {
            Navegacao(sender);
        }
        public virtual void Navegacao(object sender)
        {
            try
            {
                ToolStripButton btn = (ToolStripButton)sender;
                switch (btn.Name)
                {
                    case "btnProximo":
                        if (iNotaAtual < iTotalNotas)
                        {
                            iNotaAtual++;
                            bsNotas.MoveNext();
                        }
                        break;

                    case "btnAnterior":
                        if (iNotaAtual > 1)
                        {
                            iNotaAtual--;
                            bsNotas.MovePrevious();
                        }
                        break;

                    case "btnUltimo":
                        iNotaAtual = iTotalNotas;
                        bsNotas.MoveLast();
                        break;

                    case "btnPrimeiro":
                        iNotaAtual = 1;
                        bsNotas.MoveFirst();
                        break;

                }
                lblContagemNotas.Text = (iNotaAtual) + " de " + (iTotalNotas);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Sair();
        }
        public virtual void Sair()
        {
            if (KryptonMessageBox.Show("Deseja realmente Sair?", "A L E R T A", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Cancelado = true;
                this.Close();
            }
        }

        #endregion


        #region Metodos

        public void DesabilitaCampos(Control.ControlCollection _controls, bool blnHabilita)
        {
            try
            {

                foreach (Control crt in _controls)
                {
                    if (crt.HasChildren == true && crt.GetType().BaseType != typeof(UserControl))
                    {
                        DesabilitaCampos(crt.Controls, blnHabilita);
                    }
                    else if (crt.GetType() == typeof(KryptonDataGridView))
                    {
                        ((KryptonDataGridView)crt).ReadOnly = !blnHabilita;
                        ((KryptonDataGridView)crt).RowHeadersVisible = blnHabilita;
                        ((KryptonDataGridView)crt).ClearSelection();
                    }
                    else if (crt.GetType() == typeof(DataGridView))
                    {
                    }
                    else if (crt.GetType().BaseType == typeof(UserControl))
                    {
                        #region Controles HLP
                        if (crt.GetType() == typeof(HLP_TextBox) && crt.Name != "txtCodigo")
                        {
                            (crt as HLP_TextBox).Enabled = blnHabilita;
                        }
                        else if (crt.GetType() == typeof(HLP_MaskedTextBox))
                        {
                            (crt as HLP_MaskedTextBox).Enabled = blnHabilita;
                        }
                        else if (crt.GetType() == typeof(HLP_NumericUpDown))
                        {
                            (crt as HLP_NumericUpDown).Enabled = blnHabilita;
                        }
                        else if (crt.GetType() == typeof(HLP_ComboBox))
                        {
                            (crt as HLP_ComboBox).Enabled = blnHabilita;
                        }
                        else if (crt.GetType() == typeof(HLP_DateTimePicker))
                        {
                            (crt as HLP_DateTimePicker).Enabled = blnHabilita;
                        }
                        else if (crt.GetType() == typeof(HLP_CheckBox))
                        {
                            (crt as HLP_CheckBox).Enabled = blnHabilita;
                        }

                        #endregion
                    }
                    else
                    {
                        #region Controles Normais
                        if (crt.Parent.GetType() == typeof(KryptonTextBox))
                        {
                            crt.Enabled = blnHabilita;
                        }
                        else if (crt.GetType().BaseType == typeof(MaskedTextBox))
                        {
                            crt.Enabled = blnHabilita;
                        }
                        else if (crt.GetType().BaseType == typeof(ComboBox))
                        {
                            crt.Enabled = blnHabilita;
                        }
                        else if (crt.GetType() == typeof(KryptonDateTimePicker))
                        {
                            crt.Enabled = blnHabilita;
                        }
                        else if (crt.GetType().BaseType == typeof(RadioButton))
                        {
                            crt.Enabled = blnHabilita;
                        }
                        else if (crt.GetType() == typeof(KryptonButton))
                        {
                            crt.Enabled = blnHabilita;
                        }
                        else if (crt.GetType().BaseType == typeof(ListBox))
                        {
                            crt.Enabled = blnHabilita;
                        }
                        else if (crt.GetType().BaseType == typeof(CheckBox))
                        {
                            crt.Enabled = blnHabilita;
                        }
                        else if (crt.GetType().BaseType == typeof(RichTextBox))
                        {
                            crt.Enabled = blnHabilita;
                        }
                        else if (crt.Parent.GetType().BaseType == typeof(NumericUpDown))
                        {
                            crt.Parent.Enabled = blnHabilita;
                        }
                        #endregion
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void LimpaCampos(Control.ControlCollection ctrTela)
        {
            foreach (Control ctr in ctrTela)
            {
                if (ctr.HasChildren == true && ctr.GetType().BaseType != typeof(UserControl))
                {
                    LimpaCampos(ctr.Controls);
                }
                else if (ctr.GetType() == typeof(KryptonDataGridView))
                {
                    ((KryptonDataGridView)ctr).Rows.Clear();
                }
                else if (ctr.GetType().BaseType == typeof(UserControl))
                {
                    if (ctr.GetType() == typeof(HLP_TextBox))
                    {
                        (ctr as HLP_TextBox).Text = "";
                    }
                    else if (ctr.GetType() == typeof(HLP_NumericUpDown))
                    {
                        (ctr as HLP_NumericUpDown).Value = 0;
                        (ctr as HLP_NumericUpDown).Text = "0,00";

                    }
                    else if (ctr.GetType() == typeof(HLP_MaskedTextBox))
                    {
                        (ctr as HLP_MaskedTextBox).Text = "";
                    }
                    else if (ctr.GetType() == typeof(HLP_ComboBox))
                    {
                        (ctr as HLP_ComboBox).SelectedIndex = -1;
                    }
                    else if (ctr.GetType() == typeof(HLP_DateTimePicker))
                    {
                        (ctr as HLP_DateTimePicker).Value = DateTime.Now;
                    }
                    else if (ctr.GetType() == typeof(HLP_CheckBox))
                    {
                        (ctr as HLP_CheckBox).Checked = false;
                    }
                }
                else
                {
                    #region Controles Normais
                    if (ctr.Parent.GetType() == typeof(KryptonTextBox))
                    {
                        ((KryptonTextBox)ctr.Parent).Text = "";
                    }
                    else if (ctr.GetType().BaseType == typeof(MaskedTextBox))
                    {
                        ((KryptonMaskedTextBox)ctr).Text = "";
                    }
                    else if (ctr.GetType() == typeof(KryptonComboBox))
                    {
                        ((KryptonComboBox)ctr).SelectedIndex = -1;
                    }
                    else if (ctr.GetType() == typeof(KryptonDateTimePicker))
                    {
                        ((KryptonDateTimePicker)ctr).Value = DateTime.Now;
                    }
                    else if (ctr.Parent.GetType() == typeof(KryptonCheckedListBox))
                    {
                        ((KryptonCheckedListBox)ctr.Parent).Items.Clear();
                    }
                    else if (ctr.GetType().BaseType == typeof(CheckBox))
                    {
                        ((KryptonCheckBox)ctr).Checked = false;
                    }
                    else if (ctr.GetType().BaseType == typeof(RichTextBox))
                    {
                        ((KryptonRichTextBox)ctr).Text = "";
                    }
                    else if (ctr.Parent.GetType().BaseType == typeof(NumericUpDown))
                    {
                        ((KryptonNumericUpDown)ctr.Parent.Parent).Value = 0;
                        ((KryptonNumericUpDown)ctr.Parent.Parent).Text = "0,00";
                    }
                    #endregion
                }
            }
        }

        private void EmEdicao(bool bEmEdit)
        {
            btnAtualizar.Enabled = !bEmEdit;
            btnSalvar.Enabled = bEmEdit;
            btnCancelar.Enabled = bEmEdit;
            btnSair.Enabled = !bEmEdit;
            btnEnviar.Enabled = !bEmEdit;
        }

        #endregion




    }
}