namespace HLP.GeraXml.UI.NFe
{
    partial class frmCancelamentoNFe
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCancelamentoNFe));
            this.kryptonPanel = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.lblContador = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.btnSair = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnCancelar = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.txtJust = new HLP.GeraXml.Comum.Componentes.HLP_TextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel)).BeginInit();
            this.kryptonPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonPanel
            // 
            this.kryptonPanel.Controls.Add(this.lblContador);
            this.kryptonPanel.Controls.Add(this.btnSair);
            this.kryptonPanel.Controls.Add(this.btnCancelar);
            this.kryptonPanel.Controls.Add(this.txtJust);
            this.kryptonPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel.Name = "kryptonPanel";
            this.kryptonPanel.Size = new System.Drawing.Size(507, 221);
            this.kryptonPanel.TabIndex = 0;
            // 
            // lblContador
            // 
            this.lblContador.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldPanel;
            this.lblContador.Location = new System.Drawing.Point(91, 175);
            this.lblContador.Name = "lblContador";
            this.lblContador.Size = new System.Drawing.Size(144, 20);
            this.lblContador.TabIndex = 7;
            this.lblContador.Values.Text = "Total de Caracteres = 0";
            // 
            // btnSair
            // 
            this.btnSair.Location = new System.Drawing.Point(389, 184);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(90, 25);
            this.btnSair.TabIndex = 6;
            this.btnSair.Values.Text = "Sair";
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(250, 184);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(133, 25);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Values.Text = "&Enviar Solicitação";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // txtJust
            // 
            this.txtJust._LabelText = "Justificativa";
            this.txtJust._Multiline = true;
            this.txtJust._Obrigatorio = HLP.GeraXml.Comum.Componentes.HLP_TextBox.CampoObrigatorio.NÃO;
            this.txtJust._Password = false;
            this.txtJust._Regex = Expressoes.Não_Aplica;
            this.txtJust._Regex_Expressao = "";
            this.txtJust._TamanhoMaiorLabel = 0;
            this.txtJust._TamanhoTextBox = 387;
            this.txtJust._Visible = true;
            this.txtJust.AutoSize = true;
            this.txtJust.BackColor = System.Drawing.Color.Transparent;
            this.txtJust.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtJust.Color = System.Drawing.Color.White;
            this.txtJust.Location = new System.Drawing.Point(12, 3);
            this.txtJust.Margin = new System.Windows.Forms.Padding(3, 3, 15, 3);
            this.txtJust.MaxLength = 32767;
            this.txtJust.Name = "txtJust";
            this.txtJust.ReadOnly = false;
            this.txtJust.Size = new System.Drawing.Size(467, 166);
            this.txtJust.TabIndex = 0;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmCancelamentoNFe
            // 
            this.AllowFormChrome = false;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(507, 221);
            this.ControlBox = false;
            this.Controls.Add(this.kryptonPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCancelamentoNFe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cancelamento de Nota Eletrônica";
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel)).EndInit();
            this.kryptonPanel.ResumeLayout(false);
            this.kryptonPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel;
        private Comum.Componentes.HLP_TextBox txtJust;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnSair;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnCancelar;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblContador;
    }
}

