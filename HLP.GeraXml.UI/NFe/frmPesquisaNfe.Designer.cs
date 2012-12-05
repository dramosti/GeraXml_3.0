namespace HLP.GeraXml.UI.NFe
{
    partial class frmPesquisaNfe
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPesquisaNfe));
            this.kryptonPanel = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.dgvPesquisa = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SeqNF = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sCli_For = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChaveAcesso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cUF = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AAMM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CNPJ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.serie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1 = new AC.ExtendedRenderer.Navigator.KryptonTabControl();
            this.tabPageRefNotaA1 = new System.Windows.Forms.TabPage();
            this.kryptonPanel24 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.flowLayoutPanel5 = new System.Windows.Forms.FlowLayoutPanel();
            this.cbxTipoNf = new HLP.GeraXml.Comum.Componentes.HLP_ComboBox();
            this.cbxCampoPesquisa = new HLP.GeraXml.Comum.Componentes.HLP_ComboBox();
            this.cbxCampoPesquisaEntrada = new HLP.GeraXml.Comum.Componentes.HLP_ComboBox();
            this.cbxModelo = new HLP.GeraXml.Comum.Componentes.HLP_ComboBox();
            this.cbxOperador = new HLP.GeraXml.Comum.Componentes.HLP_ComboBox();
            this.txtPesquisa = new HLP.GeraXml.Comum.Componentes.HLP_TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnPesquisa = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel)).BeginInit();
            this.kryptonPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPesquisa)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPageRefNotaA1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel24)).BeginInit();
            this.kryptonPanel24.SuspendLayout();
            this.flowLayoutPanel5.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonPanel
            // 
            this.kryptonPanel.Controls.Add(this.dgvPesquisa);
            this.kryptonPanel.Controls.Add(this.tabControl1);
            this.kryptonPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel.Name = "kryptonPanel";
            this.kryptonPanel.Size = new System.Drawing.Size(896, 371);
            this.kryptonPanel.TabIndex = 0;
            // 
            // dgvPesquisa
            // 
            this.dgvPesquisa.AllowUserToAddRows = false;
            this.dgvPesquisa.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvPesquisa.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPesquisa.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.SeqNF,
            this.sCli_For,
            this.ChaveAcesso,
            this.cUF,
            this.AAMM,
            this.CNPJ,
            this.serie});
            this.dgvPesquisa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPesquisa.Location = new System.Drawing.Point(0, 149);
            this.dgvPesquisa.Name = "dgvPesquisa";
            this.dgvPesquisa.ReadOnly = true;
            this.dgvPesquisa.RowHeadersWidth = 25;
            this.dgvPesquisa.RowTemplate.Height = 19;
            this.dgvPesquisa.Size = new System.Drawing.Size(896, 222);
            this.dgvPesquisa.TabIndex = 223;
            this.dgvPesquisa.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPesquisa_CellDoubleClick);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "NumeroNF";
            this.Column1.HeaderText = "Número NF";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 110;
            // 
            // SeqNF
            // 
            this.SeqNF.DataPropertyName = "SeqNF";
            this.SeqNF.HeaderText = "Sequência NF";
            this.SeqNF.Name = "SeqNF";
            this.SeqNF.ReadOnly = true;
            this.SeqNF.Width = 110;
            // 
            // sCli_For
            // 
            this.sCli_For.DataPropertyName = "sCli_For";
            this.sCli_For.HeaderText = "Cliente / Fornecedor";
            this.sCli_For.Name = "sCli_For";
            this.sCli_For.ReadOnly = true;
            this.sCli_For.Width = 300;
            // 
            // ChaveAcesso
            // 
            this.ChaveAcesso.DataPropertyName = "ChaveAcesso";
            this.ChaveAcesso.HeaderText = "Chave de Acesso";
            this.ChaveAcesso.Name = "ChaveAcesso";
            this.ChaveAcesso.ReadOnly = true;
            this.ChaveAcesso.Width = 350;
            // 
            // cUF
            // 
            this.cUF.DataPropertyName = "cUF";
            this.cUF.HeaderText = "cUF";
            this.cUF.Name = "cUF";
            this.cUF.ReadOnly = true;
            this.cUF.Visible = false;
            // 
            // AAMM
            // 
            this.AAMM.DataPropertyName = "AAMM";
            this.AAMM.HeaderText = "AAMM";
            this.AAMM.Name = "AAMM";
            this.AAMM.ReadOnly = true;
            this.AAMM.Visible = false;
            // 
            // CNPJ
            // 
            this.CNPJ.DataPropertyName = "CNPJ";
            this.CNPJ.HeaderText = "CNPJ";
            this.CNPJ.Name = "CNPJ";
            this.CNPJ.ReadOnly = true;
            this.CNPJ.Visible = false;
            // 
            // serie
            // 
            this.serie.DataPropertyName = "serie";
            this.serie.HeaderText = "serie";
            this.serie.Name = "serie";
            this.serie.ReadOnly = true;
            this.serie.Visible = false;
            // 
            // tabControl1
            // 
            this.tabControl1.AllowCloseButton = false;
            this.tabControl1.AllowContextButton = false;
            this.tabControl1.AllowNavigatorButtons = false;
            this.tabControl1.AllowSelectedTabHigh = false;
            this.tabControl1.BorderWidth = 1;
            this.tabControl1.Controls.Add(this.tabPageRefNotaA1);
            this.tabControl1.CornerRoundRadiusWidth = 2;
            this.tabControl1.CornerSymmetry = AC.ExtendedRenderer.Navigator.KryptonTabControl.CornSymmetry.Both;
            this.tabControl1.CornerType = AC.ExtendedRenderer.Toolkit.Drawing.DrawingMethods.CornerType.Rounded;
            this.tabControl1.CornerWidth = AC.ExtendedRenderer.Navigator.KryptonTabControl.CornWidth.Null;
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabControl1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.HotTrack = true;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.PreserveTabColor = false;
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(896, 149);
            this.tabControl1.TabIndex = 222;
            this.tabControl1.UseExtendedLayout = false;
            // 
            // tabPageRefNotaA1
            // 
            this.tabPageRefNotaA1.BackColor = System.Drawing.SystemColors.Window;
            this.tabPageRefNotaA1.Controls.Add(this.kryptonPanel24);
            this.tabPageRefNotaA1.Location = new System.Drawing.Point(4, 25);
            this.tabPageRefNotaA1.Margin = new System.Windows.Forms.Padding(0);
            this.tabPageRefNotaA1.Name = "tabPageRefNotaA1";
            this.tabPageRefNotaA1.Size = new System.Drawing.Size(888, 120);
            this.tabPageRefNotaA1.TabIndex = 1;
            this.tabPageRefNotaA1.Tag = false;
            this.tabPageRefNotaA1.Text = "Filtros";
            // 
            // kryptonPanel24
            // 
            this.kryptonPanel24.Controls.Add(this.flowLayoutPanel5);
            this.kryptonPanel24.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel24.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel24.Name = "kryptonPanel24";
            this.kryptonPanel24.Size = new System.Drawing.Size(888, 120);
            this.kryptonPanel24.TabIndex = 206;
            // 
            // flowLayoutPanel5
            // 
            this.flowLayoutPanel5.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel5.Controls.Add(this.cbxTipoNf);
            this.flowLayoutPanel5.Controls.Add(this.cbxCampoPesquisa);
            this.flowLayoutPanel5.Controls.Add(this.cbxCampoPesquisaEntrada);
            this.flowLayoutPanel5.Controls.Add(this.cbxModelo);
            this.flowLayoutPanel5.Controls.Add(this.cbxOperador);
            this.flowLayoutPanel5.Controls.Add(this.txtPesquisa);
            this.flowLayoutPanel5.Controls.Add(this.panel1);
            this.flowLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel5.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel5.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel5.Name = "flowLayoutPanel5";
            this.flowLayoutPanel5.Size = new System.Drawing.Size(888, 120);
            this.flowLayoutPanel5.TabIndex = 0;
            // 
            // cbxTipoNf
            // 
            this.cbxTipoNf._Itens = ((System.Collections.Generic.List<string>)(resources.GetObject("cbxTipoNf._Itens")));
            this.cbxTipoNf._LabelText = "Tipo de Nota Fiscal";
            this.cbxTipoNf._Obrigatorio = HLP.GeraXml.Comum.Componentes.HLP_ComboBox.CampoObrigatorio.NÃO;
            this.cbxTipoNf._situacao = false;
            this.cbxTipoNf._TamanhoComboBox = 122;
            this.cbxTipoNf._TamanhoMaiorLabel = 150;
            this.cbxTipoNf._Visible = true;
            this.cbxTipoNf.AutoSize = true;
            this.cbxTipoNf.BackColor = System.Drawing.Color.Transparent;
            this.cbxTipoNf.Color = System.Drawing.Color.White;
            this.cbxTipoNf.DataSource = null;
            this.cbxTipoNf.DisplayMember = "DisplayMember";
            this.cbxTipoNf.Location = new System.Drawing.Point(32, 3);
            this.cbxTipoNf.Margin = new System.Windows.Forms.Padding(32, 3, 15, 3);
            this.cbxTipoNf.Name = "cbxTipoNf";
            this.cbxTipoNf.SelectedIndex = -1;
            this.cbxTipoNf.SelectedValue = 0;
            this.cbxTipoNf.Size = new System.Drawing.Size(243, 21);
            this.cbxTipoNf.TabIndex = 0;
            this.cbxTipoNf.ValueMember = "ValueMember";
            // 
            // cbxCampoPesquisa
            // 
            this.cbxCampoPesquisa._Itens = ((System.Collections.Generic.List<string>)(resources.GetObject("cbxCampoPesquisa._Itens")));
            this.cbxCampoPesquisa._LabelText = "Pesquisa Saida";
            this.cbxCampoPesquisa._Obrigatorio = HLP.GeraXml.Comum.Componentes.HLP_ComboBox.CampoObrigatorio.NÃO;
            this.cbxCampoPesquisa._situacao = false;
            this.cbxCampoPesquisa._TamanhoComboBox = 122;
            this.cbxCampoPesquisa._TamanhoMaiorLabel = 150;
            this.cbxCampoPesquisa._Visible = true;
            this.cbxCampoPesquisa.AutoSize = true;
            this.cbxCampoPesquisa.BackColor = System.Drawing.Color.Transparent;
            this.cbxCampoPesquisa.Color = System.Drawing.Color.White;
            this.cbxCampoPesquisa.DataSource = null;
            this.cbxCampoPesquisa.DisplayMember = "DisplayMember";
            this.cbxCampoPesquisa.Location = new System.Drawing.Point(57, 30);
            this.cbxCampoPesquisa.Margin = new System.Windows.Forms.Padding(57, 3, 15, 3);
            this.cbxCampoPesquisa.Name = "cbxCampoPesquisa";
            this.cbxCampoPesquisa.SelectedIndex = -1;
            this.cbxCampoPesquisa.SelectedValue = 0;
            this.cbxCampoPesquisa.Size = new System.Drawing.Size(218, 21);
            this.cbxCampoPesquisa.TabIndex = 1;
            this.cbxCampoPesquisa.ValueMember = "ValueMember";
            // 
            // cbxCampoPesquisaEntrada
            // 
            this.cbxCampoPesquisaEntrada._Itens = ((System.Collections.Generic.List<string>)(resources.GetObject("cbxCampoPesquisaEntrada._Itens")));
            this.cbxCampoPesquisaEntrada._LabelText = "Pesquisa Entrada";
            this.cbxCampoPesquisaEntrada._Obrigatorio = HLP.GeraXml.Comum.Componentes.HLP_ComboBox.CampoObrigatorio.NÃO;
            this.cbxCampoPesquisaEntrada._situacao = false;
            this.cbxCampoPesquisaEntrada._TamanhoComboBox = 122;
            this.cbxCampoPesquisaEntrada._TamanhoMaiorLabel = 150;
            this.cbxCampoPesquisaEntrada._Visible = true;
            this.cbxCampoPesquisaEntrada.AutoSize = true;
            this.cbxCampoPesquisaEntrada.BackColor = System.Drawing.Color.Transparent;
            this.cbxCampoPesquisaEntrada.Color = System.Drawing.Color.White;
            this.cbxCampoPesquisaEntrada.DataSource = null;
            this.cbxCampoPesquisaEntrada.DisplayMember = "DisplayMember";
            this.cbxCampoPesquisaEntrada.Location = new System.Drawing.Point(44, 57);
            this.cbxCampoPesquisaEntrada.Margin = new System.Windows.Forms.Padding(44, 3, 15, 3);
            this.cbxCampoPesquisaEntrada.Name = "cbxCampoPesquisaEntrada";
            this.cbxCampoPesquisaEntrada.SelectedIndex = -1;
            this.cbxCampoPesquisaEntrada.SelectedValue = 0;
            this.cbxCampoPesquisaEntrada.Size = new System.Drawing.Size(231, 21);
            this.cbxCampoPesquisaEntrada.TabIndex = 2;
            this.cbxCampoPesquisaEntrada.ValueMember = "ValueMember";
            // 
            // cbxModelo
            // 
            this.cbxModelo._Itens = ((System.Collections.Generic.List<string>)(resources.GetObject("cbxModelo._Itens")));
            this.cbxModelo._LabelText = "Modelo";
            this.cbxModelo._Obrigatorio = HLP.GeraXml.Comum.Componentes.HLP_ComboBox.CampoObrigatorio.NÃO;
            this.cbxModelo._situacao = false;
            this.cbxModelo._TamanhoComboBox = 122;
            this.cbxModelo._TamanhoMaiorLabel = 150;
            this.cbxModelo._Visible = true;
            this.cbxModelo.AutoSize = true;
            this.cbxModelo.BackColor = System.Drawing.Color.Transparent;
            this.cbxModelo.Color = System.Drawing.Color.White;
            this.cbxModelo.DataSource = null;
            this.cbxModelo.DisplayMember = "DisplayMember";
            this.cbxModelo.Location = new System.Drawing.Point(98, 84);
            this.cbxModelo.Margin = new System.Windows.Forms.Padding(98, 3, 15, 3);
            this.cbxModelo.Name = "cbxModelo";
            this.cbxModelo.SelectedIndex = -1;
            this.cbxModelo.SelectedValue = 0;
            this.cbxModelo.Size = new System.Drawing.Size(177, 21);
            this.cbxModelo.TabIndex = 3;
            this.cbxModelo.ValueMember = "ValueMember";
            // 
            // cbxOperador
            // 
            this.cbxOperador._Itens = ((System.Collections.Generic.List<string>)(resources.GetObject("cbxOperador._Itens")));
            this.cbxOperador._LabelText = "Operador";
            this.cbxOperador._Obrigatorio = HLP.GeraXml.Comum.Componentes.HLP_ComboBox.CampoObrigatorio.NÃO;
            this.cbxOperador._situacao = false;
            this.cbxOperador._TamanhoComboBox = 152;
            this.cbxOperador._TamanhoMaiorLabel = 150;
            this.cbxOperador._Visible = true;
            this.cbxOperador.AutoSize = true;
            this.cbxOperador.BackColor = System.Drawing.Color.Transparent;
            this.cbxOperador.Color = System.Drawing.Color.White;
            this.cbxOperador.DataSource = null;
            this.cbxOperador.DisplayMember = "DisplayMember";
            this.cbxOperador.Location = new System.Drawing.Point(377, 3);
            this.cbxOperador.Margin = new System.Windows.Forms.Padding(87, 3, 15, 3);
            this.cbxOperador.Name = "cbxOperador";
            this.cbxOperador.SelectedIndex = -1;
            this.cbxOperador.SelectedValue = 0;
            this.cbxOperador.Size = new System.Drawing.Size(218, 21);
            this.cbxOperador.TabIndex = 4;
            this.cbxOperador.ValueMember = "ValueMember";
            // 
            // txtPesquisa
            // 
            this.txtPesquisa._LabelText = "Valor de Pesquisa";
            this.txtPesquisa._Multiline = false;
            this.txtPesquisa._Obrigatorio = HLP.GeraXml.Comum.Componentes.HLP_TextBox.CampoObrigatorio.NÃO;
            this.txtPesquisa._Password = false;
            this.txtPesquisa._Regex = Expressoes.Não_Aplica;
            this.txtPesquisa._Regex_Expressao = null;
            this.txtPesquisa._TamanhoMaiorLabel = 150;
            this.txtPesquisa._TamanhoTextBox = 152;
            this.txtPesquisa._Visible = true;
            this.txtPesquisa.AutoSize = true;
            this.txtPesquisa.BackColor = System.Drawing.Color.Transparent;
            this.txtPesquisa.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtPesquisa.Color = System.Drawing.Color.White;
            this.txtPesquisa.Location = new System.Drawing.Point(330, 30);
            this.txtPesquisa.Margin = new System.Windows.Forms.Padding(40, 3, 15, 3);
            this.txtPesquisa.MaxLength = 32767;
            this.txtPesquisa.Name = "txtPesquisa";
            this.txtPesquisa.ReadOnly = false;
            this.txtPesquisa.Size = new System.Drawing.Size(265, 20);
            this.txtPesquisa.TabIndex = 5;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnPesquisa);
            this.panel1.Location = new System.Drawing.Point(293, 56);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(272, 27);
            this.panel1.TabIndex = 6;
            // 
            // btnPesquisa
            // 
            this.btnPesquisa.Location = new System.Drawing.Point(150, 1);
            this.btnPesquisa.Name = "btnPesquisa";
            this.btnPesquisa.Size = new System.Drawing.Size(105, 24);
            this.btnPesquisa.TabIndex = 4;
            this.btnPesquisa.Values.Text = "Pesquisar";
            this.btnPesquisa.Click += new System.EventHandler(this.btnPesquisa_Click);
            // 
            // frmPesquisaNfe
            // 
            this.AllowFormChrome = false;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(896, 371);
            this.Controls.Add(this.kryptonPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmPesquisaNfe";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pesquisa de Nota Fiscal";
            this.Load += new System.EventHandler(this.PesquisaNF_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel)).EndInit();
            this.kryptonPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPesquisa)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPageRefNotaA1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel24)).EndInit();
            this.kryptonPanel24.ResumeLayout(false);
            this.flowLayoutPanel5.ResumeLayout(false);
            this.flowLayoutPanel5.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel;
        private AC.ExtendedRenderer.Navigator.KryptonTabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageRefNotaA1;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel24;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel5;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView dgvPesquisa;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn SeqNF;
        private System.Windows.Forms.DataGridViewTextBoxColumn sCli_For;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChaveAcesso;
        private System.Windows.Forms.DataGridViewTextBoxColumn cUF;
        private System.Windows.Forms.DataGridViewTextBoxColumn AAMM;
        private System.Windows.Forms.DataGridViewTextBoxColumn CNPJ;
        private System.Windows.Forms.DataGridViewTextBoxColumn serie;
        private Comum.Componentes.HLP_ComboBox cbxTipoNf;
        private Comum.Componentes.HLP_ComboBox cbxCampoPesquisa;
        private Comum.Componentes.HLP_ComboBox cbxCampoPesquisaEntrada;
        private Comum.Componentes.HLP_ComboBox cbxModelo;
        private Comum.Componentes.HLP_ComboBox cbxOperador;
        private Comum.Componentes.HLP_TextBox txtPesquisa;
        private System.Windows.Forms.Panel panel1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnPesquisa;
    }
}

