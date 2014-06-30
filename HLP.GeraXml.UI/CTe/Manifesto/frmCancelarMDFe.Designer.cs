namespace HLP.GeraXml.UI.CTe.Manifesto
{
    partial class frmCancelarMDFe
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
            this.txtJust = new HLP.GeraXml.Comum.Componentes.HLP_TextBox();
            this.kryptonPanel = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.btnSair = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnCancelar = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel)).BeginInit();
            this.kryptonPanel.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtJust
            // 
            this.txtJust._LabelText = "Justificativa";
            this.txtJust._Multiline = true;
            this.txtJust._Obrigatorio = HLP.GeraXml.Comum.Componentes.HLP_TextBox.CampoObrigatorio.SIM;
            this.txtJust._Password = false;
            this.txtJust._Regex = Expressoes.ER32;
            this.txtJust._Regex_Expressao = "^[!-ÿ]{1}[ -ÿ]{0,}[!-ÿ]{1}|[!-ÿ]{1}$";
            this.txtJust._TamanhoMaiorLabel = 0;
            this.txtJust._TamanhoTextBox = 323;
            this.txtJust._Visible = true;
            this.txtJust.AutoSize = true;
            this.txtJust.BackColor = System.Drawing.Color.Transparent;
            this.txtJust.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtJust.Color = System.Drawing.Color.White;
            this.txtJust.Location = new System.Drawing.Point(3, 3);
            this.txtJust.Margin = new System.Windows.Forms.Padding(3, 3, 15, 3);
            this.txtJust.MaxLength = 255;
            this.txtJust.Name = "txtJust";
            this.txtJust.ReadOnly = false;
            this.txtJust.Size = new System.Drawing.Size(403, 144);
            this.txtJust.TabIndex = 3;
            // 
            // kryptonPanel
            // 
            this.kryptonPanel.Controls.Add(this.flowLayoutPanel1);
            this.kryptonPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel.Name = "kryptonPanel";
            this.kryptonPanel.Size = new System.Drawing.Size(428, 194);
            this.kryptonPanel.TabIndex = 1;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel1.Controls.Add(this.txtJust);
            this.flowLayoutPanel1.Controls.Add(this.kryptonPanel1);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(428, 194);
            this.flowLayoutPanel1.TabIndex = 106;
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.btnSair);
            this.kryptonPanel1.Controls.Add(this.btnCancelar);
            this.kryptonPanel1.Location = new System.Drawing.Point(3, 153);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(421, 36);
            this.kryptonPanel1.TabIndex = 5;
            // 
            // btnSair
            // 
            this.btnSair.Location = new System.Drawing.Point(315, 3);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(90, 25);
            this.btnSair.TabIndex = 3;
            this.btnSair.Values.Text = "Sair";
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(219, 3);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(90, 25);
            this.btnCancelar.TabIndex = 2;
            this.btnCancelar.Values.Text = "&Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // frmCancelarMDFe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 194);
            this.Controls.Add(this.kryptonPanel);
            this.Name = "frmCancelarMDFe";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CancelarMDFe";
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel)).EndInit();
            this.kryptonPanel.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Comum.Componentes.HLP_TextBox txtJust;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnSair;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnCancelar;
    }
}