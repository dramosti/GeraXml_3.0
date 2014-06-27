namespace HLP.GeraXml.UI.CTe
{
    partial class frmGerarNumeroMDFe
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGerarNumeroMDFe));
            this.kryptonPanel = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.txtNumeroUltNF = new HLP.GeraXml.Comum.Componentes.HLP_TextBox();
            this.txtNumeroASerEmi = new HLP.GeraXml.Comum.Componentes.HLP_TextBox();
            this.kryptonButton1 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.pgbNF = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel)).BeginInit();
            this.kryptonPanel.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonPanel
            // 
            this.kryptonPanel.Controls.Add(this.flowLayoutPanel1);
            this.kryptonPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel.Name = "kryptonPanel";
            this.kryptonPanel.Size = new System.Drawing.Size(378, 148);
            this.kryptonPanel.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel1.Controls.Add(this.txtNumeroUltNF);
            this.flowLayoutPanel1.Controls.Add(this.txtNumeroASerEmi);
            this.flowLayoutPanel1.Controls.Add(this.kryptonButton1);
            this.flowLayoutPanel1.Controls.Add(this.pgbNF);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(378, 148);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // txtNumeroUltNF
            // 
            this.txtNumeroUltNF._LabelText = "Nº último Manifesto";
            this.txtNumeroUltNF._Multiline = false;
            this.txtNumeroUltNF._Obrigatorio = HLP.GeraXml.Comum.Componentes.HLP_TextBox.CampoObrigatorio.NÃO;
            this.txtNumeroUltNF._Password = false;
            this.txtNumeroUltNF._Regex = Expressoes.Não_Aplica;
            this.txtNumeroUltNF._Regex_Expressao = "";
            this.txtNumeroUltNF._TamanhoMaiorLabel = 155;
            this.txtNumeroUltNF._TamanhoTextBox = 125;
            this.txtNumeroUltNF._Visible = true;
            this.txtNumeroUltNF.AutoSize = true;
            this.txtNumeroUltNF.BackColor = System.Drawing.Color.Transparent;
            this.txtNumeroUltNF.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtNumeroUltNF.Color = System.Drawing.Color.White;
            this.txtNumeroUltNF.Location = new System.Drawing.Point(28, 3);
            this.txtNumeroUltNF.Margin = new System.Windows.Forms.Padding(28, 3, 15, 3);
            this.txtNumeroUltNF.MaxLength = 32767;
            this.txtNumeroUltNF.Name = "txtNumeroUltNF";
            this.txtNumeroUltNF.ReadOnly = true;
            this.txtNumeroUltNF.Size = new System.Drawing.Size(255, 23);
            this.txtNumeroUltNF.TabIndex = 0;
            // 
            // txtNumeroASerEmi
            // 
            this.txtNumeroASerEmi._LabelText = "Nº a ser Emitido";
            this.txtNumeroASerEmi._Multiline = false;
            this.txtNumeroASerEmi._Obrigatorio = HLP.GeraXml.Comum.Componentes.HLP_TextBox.CampoObrigatorio.NÃO;
            this.txtNumeroASerEmi._Password = false;
            this.txtNumeroASerEmi._Regex = Expressoes.Não_Aplica;
            this.txtNumeroASerEmi._Regex_Expressao = "";
            this.txtNumeroASerEmi._TamanhoMaiorLabel = 155;
            this.txtNumeroASerEmi._TamanhoTextBox = 125;
            this.txtNumeroASerEmi._Visible = true;
            this.txtNumeroASerEmi.AutoSize = true;
            this.txtNumeroASerEmi.BackColor = System.Drawing.Color.Transparent;
            this.txtNumeroASerEmi.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtNumeroASerEmi.Color = System.Drawing.Color.White;
            this.txtNumeroASerEmi.Location = new System.Drawing.Point(53, 32);
            this.txtNumeroASerEmi.Margin = new System.Windows.Forms.Padding(53, 3, 15, 3);
            this.txtNumeroASerEmi.MaxLength = 6;
            this.txtNumeroASerEmi.Name = "txtNumeroASerEmi";
            this.txtNumeroASerEmi.ReadOnly = false;
            this.txtNumeroASerEmi.Size = new System.Drawing.Size(230, 23);
            this.txtNumeroASerEmi.TabIndex = 1;
            // 
            // kryptonButton1
            // 
            this.kryptonButton1.Location = new System.Drawing.Point(3, 61);
            this.kryptonButton1.Name = "kryptonButton1";
            this.kryptonButton1.Size = new System.Drawing.Size(366, 51);
            this.kryptonButton1.TabIndex = 7;
            this.kryptonButton1.Values.Text = "&Gerar Número Manifesto";
            this.kryptonButton1.Click += new System.EventHandler(this.kryptonButton1_Click);
            // 
            // pgbNF
            // 
            this.pgbNF.Location = new System.Drawing.Point(3, 118);
            this.pgbNF.Name = "pgbNF";
            this.pgbNF.Size = new System.Drawing.Size(366, 21);
            this.pgbNF.Step = 1;
            this.pgbNF.TabIndex = 8;
            // 
            // frmGerarNumeroMDFe
            // 
            this.AllowFormChrome = false;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(378, 148);
            this.ControlBox = false;
            this.Controls.Add(this.kryptonPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmGerarNumeroMDFe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Geração do Número dos Manifestos";
            this.Load += new System.EventHandler(this.frmGerarNumeroCte_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel)).EndInit();
            this.kryptonPanel.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private Comum.Componentes.HLP_TextBox txtNumeroUltNF;
        private Comum.Componentes.HLP_TextBox txtNumeroASerEmi;
        private ComponentFactory.Krypton.Toolkit.KryptonButton kryptonButton1;
        private System.Windows.Forms.ProgressBar pgbNF;
    }
}

