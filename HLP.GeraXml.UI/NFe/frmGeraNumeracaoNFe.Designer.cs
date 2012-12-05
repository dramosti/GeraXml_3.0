namespace HLP.GeraXml.UI.NFe
{
    partial class frmGeraNumeracaoNFe
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGeraNumeracaoNFe));
            this.kryptonPanel = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.btnGerar = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.pgStatus = new System.Windows.Forms.ToolStripProgressBar();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.cbxGrupos = new HLP.GeraXml.Comum.Componentes.HLP_ComboBox();
            this.txtUltimo = new HLP.GeraXml.Comum.Componentes.HLP_TextBox();
            this.txtProximo = new HLP.GeraXml.Comum.Componentes.HLP_TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel)).BeginInit();
            this.kryptonPanel.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonPanel
            // 
            this.kryptonPanel.Controls.Add(this.btnGerar);
            this.kryptonPanel.Controls.Add(this.statusStrip1);
            this.kryptonPanel.Controls.Add(this.flowLayoutPanel1);
            this.kryptonPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel.Name = "kryptonPanel";
            this.kryptonPanel.Size = new System.Drawing.Size(356, 171);
            this.kryptonPanel.TabIndex = 0;
            // 
            // btnGerar
            // 
            this.btnGerar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnGerar.Location = new System.Drawing.Point(0, 94);
            this.btnGerar.Name = "btnGerar";
            this.btnGerar.Size = new System.Drawing.Size(356, 55);
            this.btnGerar.TabIndex = 8;
            this.btnGerar.Values.Text = "&Gerar Númeração";
            this.btnGerar.Click += new System.EventHandler(this.btnGerar_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.Transparent;
            this.statusStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pgStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 149);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(356, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // pgStatus
            // 
            this.pgStatus.Name = "pgStatus";
            this.pgStatus.Size = new System.Drawing.Size(100, 16);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel1.Controls.Add(this.cbxGrupos);
            this.flowLayoutPanel1.Controls.Add(this.txtUltimo);
            this.flowLayoutPanel1.Controls.Add(this.txtProximo);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(356, 94);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // cbxGrupos
            // 
            this.cbxGrupos._Itens = ((System.Collections.Generic.List<string>)(resources.GetObject("cbxGrupos._Itens")));
            this.cbxGrupos._LabelText = "Grupo de Faturamento";
            this.cbxGrupos._Obrigatorio = HLP.GeraXml.Comum.Componentes.HLP_ComboBox.CampoObrigatorio.NÃO;
            this.cbxGrupos._situacao = false;
            this.cbxGrupos._TamanhoComboBox = 175;
            this.cbxGrupos._TamanhoMaiorLabel = 155;
            this.cbxGrupos._Visible = true;
            this.cbxGrupos.AutoSize = true;
            this.cbxGrupos.BackColor = System.Drawing.Color.Transparent;
            this.cbxGrupos.Color = System.Drawing.Color.White;
            this.cbxGrupos.DataSource = null;
            this.cbxGrupos.DisplayMember = "DisplayMember";
            this.cbxGrupos.Location = new System.Drawing.Point(15, 3);
            this.cbxGrupos.Margin = new System.Windows.Forms.Padding(15, 3, 15, 3);
            this.cbxGrupos.Name = "cbxGrupos";
            this.cbxGrupos.SelectedIndex = -1;
            this.cbxGrupos.SelectedValue = 0;
            this.cbxGrupos.Size = new System.Drawing.Size(318, 21);
            this.cbxGrupos.TabIndex = 247;
            this.cbxGrupos.ValueMember = "ValueMember";
            // 
            // txtUltimo
            // 
            this.txtUltimo._LabelText = "Último Número Gerado";
            this.txtUltimo._Multiline = false;
            this.txtUltimo._Obrigatorio = HLP.GeraXml.Comum.Componentes.HLP_TextBox.CampoObrigatorio.NÃO;
            this.txtUltimo._Password = false;
            this.txtUltimo._Regex = Expressoes.Não_Aplica;
            this.txtUltimo._Regex_Expressao = "";
            this.txtUltimo._TamanhoMaiorLabel = 155;
            this.txtUltimo._TamanhoTextBox = 100;
            this.txtUltimo._Visible = true;
            this.txtUltimo.AutoSize = true;
            this.txtUltimo.BackColor = System.Drawing.Color.Transparent;
            this.txtUltimo.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtUltimo.Color = System.Drawing.Color.White;
            this.txtUltimo.Location = new System.Drawing.Point(11, 30);
            this.txtUltimo.Margin = new System.Windows.Forms.Padding(11, 3, 15, 3);
            this.txtUltimo.MaxLength = 32767;
            this.txtUltimo.Name = "txtUltimo";
            this.txtUltimo.ReadOnly = true;
            this.txtUltimo.Size = new System.Drawing.Size(247, 23);
            this.txtUltimo.TabIndex = 248;
            // 
            // txtProximo
            // 
            this.txtProximo._LabelText = "Nº a ser Emitido";
            this.txtProximo._Multiline = false;
            this.txtProximo._Obrigatorio = HLP.GeraXml.Comum.Componentes.HLP_TextBox.CampoObrigatorio.NÃO;
            this.txtProximo._Password = false;
            this.txtProximo._Regex = Expressoes.Não_Aplica;
            this.txtProximo._Regex_Expressao = "";
            this.txtProximo._TamanhoMaiorLabel = 155;
            this.txtProximo._TamanhoTextBox = 100;
            this.txtProximo._Visible = true;
            this.txtProximo.AutoSize = true;
            this.txtProximo.BackColor = System.Drawing.Color.Transparent;
            this.txtProximo.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtProximo.Color = System.Drawing.Color.White;
            this.txtProximo.Location = new System.Drawing.Point(53, 59);
            this.txtProximo.Margin = new System.Windows.Forms.Padding(53, 3, 15, 3);
            this.txtProximo.MaxLength = 6;
            this.txtProximo.Name = "txtProximo";
            this.txtProximo.ReadOnly = false;
            this.txtProximo.Size = new System.Drawing.Size(205, 23);
            this.txtProximo.TabIndex = 249;
            // 
            // frmGeraNumeracaoNFe
            // 
            this.AllowFormChrome = false;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(356, 171);
            this.Controls.Add(this.kryptonPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmGeraNumeracaoNFe";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gera Numeração";
            this.Load += new System.EventHandler(this.frmGeraNumeracaoNFe_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel)).EndInit();
            this.kryptonPanel.ResumeLayout(false);
            this.kryptonPanel.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private Comum.Componentes.HLP_TextBox txtUltimo;
        private Comum.Componentes.HLP_TextBox txtProximo;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar pgStatus;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnGerar;
        public Comum.Componentes.HLP_ComboBox cbxGrupos;
    }
}

