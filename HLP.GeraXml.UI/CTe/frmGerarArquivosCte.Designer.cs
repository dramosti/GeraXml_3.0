namespace HLP.GeraXml.UI.CTe
{
    partial class frmGerarArquivosCte
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGerarArquivosCte));
            this.kryptonPanel = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.dgvArquivos = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.kryptonLabel7 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.kryptonLabel8 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.btnPendencias = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.lblTotalRegistros = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.cboStatus = new HLP.GeraXml.Comum.Componentes.HLP_ComboBox();
            this.cboFiltro = new HLP.GeraXml.Comum.Componentes.HLP_ComboBox();
            this.dtpIni = new HLP.GeraXml.Comum.Componentes.HLP_DateTimePicker();
            this.dtpFim = new HLP.GeraXml.Comum.Componentes.HLP_DateTimePicker();
            this.txtNfIni = new HLP.GeraXml.Comum.Componentes.HLP_TextBox();
            this.txtNfFim = new HLP.GeraXml.Comum.Componentes.HLP_TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.btnPesquisa = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.btnEnvio = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnContingencia = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnCancelamento = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSair = new System.Windows.Forms.ToolStripButton();
            this.btnImpressao = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.btnGeraPdf = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.btnBuscaRetorno = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.btnConsultaSituacao = new System.Windows.Forms.ToolStripButton();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.cl_assina = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.nr_lanc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cd_conheci = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dt_emi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vl_total = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewNumericUpDownColumn();
            this.nm_social = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.st_cte = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ds_cancelamento = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.st_contingencia = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel)).BeginInit();
            this.kryptonPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArquivos)).BeginInit();
            this.flowLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonPanel
            // 
            this.kryptonPanel.Controls.Add(this.dgvArquivos);
            this.kryptonPanel.Controls.Add(this.flowLayoutPanel2);
            this.kryptonPanel.Controls.Add(this.flowLayoutPanel1);
            this.kryptonPanel.Controls.Add(this.menuStrip1);
            this.kryptonPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel.Name = "kryptonPanel";
            this.kryptonPanel.Size = new System.Drawing.Size(992, 386);
            this.kryptonPanel.TabIndex = 0;
            // 
            // dgvArquivos
            // 
            this.dgvArquivos.AllowUserToAddRows = false;
            this.dgvArquivos.AllowUserToResizeRows = false;
            this.dgvArquivos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cl_assina,
            this.nr_lanc,
            this.cd_conheci,
            this.dt_emi,
            this.vl_total,
            this.nm_social,
            this.st_cte,
            this.ds_cancelamento,
            this.st_contingencia});
            this.dgvArquivos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvArquivos.Location = new System.Drawing.Point(0, 57);
            this.dgvArquivos.Name = "dgvArquivos";
            this.dgvArquivos.RowHeadersVisible = false;
            this.dgvArquivos.Size = new System.Drawing.Size(992, 300);
            this.dgvArquivos.TabIndex = 232;
            this.dgvArquivos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvArquivos_CellClick);
            this.dgvArquivos.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvArquivos_ColumnHeaderMouseClick);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel2.Controls.Add(this.panel5);
            this.flowLayoutPanel2.Controls.Add(this.kryptonLabel1);
            this.flowLayoutPanel2.Controls.Add(this.panel6);
            this.flowLayoutPanel2.Controls.Add(this.kryptonLabel2);
            this.flowLayoutPanel2.Controls.Add(this.panel2);
            this.flowLayoutPanel2.Controls.Add(this.kryptonLabel7);
            this.flowLayoutPanel2.Controls.Add(this.panel3);
            this.flowLayoutPanel2.Controls.Add(this.kryptonLabel8);
            this.flowLayoutPanel2.Controls.Add(this.btnPendencias);
            this.flowLayoutPanel2.Controls.Add(this.lblTotalRegistros);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 357);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(992, 29);
            this.flowLayoutPanel2.TabIndex = 231;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.White;
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel5.Location = new System.Drawing.Point(3, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(21, 20);
            this.panel5.TabIndex = 202;
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldPanel;
            this.kryptonLabel1.Location = new System.Drawing.Point(30, 3);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(84, 20);
            this.kryptonLabel1.TabIndex = 203;
            this.kryptonLabel1.Values.Text = "Não Enviado";
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.Khaki;
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel6.Location = new System.Drawing.Point(120, 3);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(21, 20);
            this.panel6.TabIndex = 204;
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldPanel;
            this.kryptonLabel2.Location = new System.Drawing.Point(147, 3);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(70, 20);
            this.kryptonLabel2.TabIndex = 205;
            this.kryptonLabel2.Values.Text = "Cancelado";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightGreen;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Location = new System.Drawing.Point(223, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(21, 20);
            this.panel2.TabIndex = 208;
            // 
            // kryptonLabel7
            // 
            this.kryptonLabel7.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldPanel;
            this.kryptonLabel7.Location = new System.Drawing.Point(250, 3);
            this.kryptonLabel7.Name = "kryptonLabel7";
            this.kryptonLabel7.Size = new System.Drawing.Size(57, 20);
            this.kryptonLabel7.TabIndex = 212;
            this.kryptonLabel7.Values.Text = "Enviado";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Red;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Location = new System.Drawing.Point(313, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(21, 20);
            this.panel3.TabIndex = 213;
            // 
            // kryptonLabel8
            // 
            this.kryptonLabel8.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldPanel;
            this.kryptonLabel8.Location = new System.Drawing.Point(340, 3);
            this.kryptonLabel8.Name = "kryptonLabel8";
            this.kryptonLabel8.Size = new System.Drawing.Size(66, 20);
            this.kryptonLabel8.TabIndex = 215;
            this.kryptonLabel8.Values.Text = "Pendente";
            // 
            // btnPendencias
            // 
            this.btnPendencias.Location = new System.Drawing.Point(412, 3);
            this.btnPendencias.Name = "btnPendencias";
            this.btnPendencias.Size = new System.Drawing.Size(124, 24);
            this.btnPendencias.TabIndex = 216;
            this.btnPendencias.Values.Text = "Buscar Pendências";
            this.btnPendencias.Visible = false;
            this.btnPendencias.Click += new System.EventHandler(this.btnPendencias_Click);
            // 
            // lblTotalRegistros
            // 
            this.lblTotalRegistros.AutoSize = false;
            this.lblTotalRegistros.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldPanel;
            this.lblTotalRegistros.Location = new System.Drawing.Point(542, 3);
            this.lblTotalRegistros.Name = "lblTotalRegistros";
            this.lblTotalRegistros.Size = new System.Drawing.Size(350, 25);
            this.lblTotalRegistros.TabIndex = 0;
            this.lblTotalRegistros.Values.Text = "";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel1.Controls.Add(this.cboStatus);
            this.flowLayoutPanel1.Controls.Add(this.cboFiltro);
            this.flowLayoutPanel1.Controls.Add(this.dtpIni);
            this.flowLayoutPanel1.Controls.Add(this.dtpFim);
            this.flowLayoutPanel1.Controls.Add(this.txtNfIni);
            this.flowLayoutPanel1.Controls.Add(this.txtNfFim);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 27);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(992, 30);
            this.flowLayoutPanel1.TabIndex = 229;
            // 
            // cboStatus
            // 
            this.cboStatus._Itens = ((System.Collections.Generic.List<string>)(resources.GetObject("cboStatus._Itens")));
            this.cboStatus._LabelText = "Status";
            this.cboStatus._Obrigatorio = HLP.GeraXml.Comum.Componentes.HLP_ComboBox.CampoObrigatorio.SIM;
            this.cboStatus._situacao = false;
            this.cboStatus._TamanhoComboBox = 141;
            this.cboStatus._TamanhoMaiorLabel = 0;
            this.cboStatus._Visible = true;
            this.cboStatus.AutoSize = true;
            this.cboStatus.BackColor = System.Drawing.Color.Transparent;
            this.cboStatus.Color = System.Drawing.Color.White;
            this.cboStatus.DataSource = null;
            this.cboStatus.DisplayMember = "DisplayMember";
            this.cboStatus.Location = new System.Drawing.Point(3, 3);
            this.cboStatus.Margin = new System.Windows.Forms.Padding(3, 3, 15, 3);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.SelectedIndex = -1;
            this.cboStatus.SelectedValue = 0;
            this.cboStatus.Size = new System.Drawing.Size(188, 23);
            this.cboStatus.TabIndex = 8;
            this.cboStatus.ValueMember = "ValueMember";
            // 
            // cboFiltro
            // 
            this.cboFiltro._Itens = ((System.Collections.Generic.List<string>)(resources.GetObject("cboFiltro._Itens")));
            this.cboFiltro._LabelText = "Filtro";
            this.cboFiltro._Obrigatorio = HLP.GeraXml.Comum.Componentes.HLP_ComboBox.CampoObrigatorio.SIM;
            this.cboFiltro._situacao = false;
            this.cboFiltro._TamanhoComboBox = 141;
            this.cboFiltro._TamanhoMaiorLabel = 0;
            this.cboFiltro._Visible = true;
            this.cboFiltro.AutoSize = true;
            this.cboFiltro.BackColor = System.Drawing.Color.Transparent;
            this.cboFiltro.Color = System.Drawing.Color.White;
            this.cboFiltro.DataSource = null;
            this.cboFiltro.DisplayMember = "DisplayMember";
            this.cboFiltro.Location = new System.Drawing.Point(209, 3);
            this.cboFiltro.Margin = new System.Windows.Forms.Padding(3, 3, 15, 3);
            this.cboFiltro.Name = "cboFiltro";
            this.cboFiltro.SelectedIndex = -1;
            this.cboFiltro.SelectedValue = 0;
            this.cboFiltro.Size = new System.Drawing.Size(182, 23);
            this.cboFiltro.TabIndex = 9;
            this.cboFiltro.ValueMember = "ValueMember";
            // 
            // dtpIni
            // 
            this.dtpIni._LabelText = "De";
            this.dtpIni._Obrigatorio = HLP.GeraXml.Comum.Componentes.HLP_DateTimePicker.CampoObrigatorio.SIM;
            this.dtpIni._TamanhoDateTimePicker = 90;
            this.dtpIni._TamanhoMaiorLabel = 0;
            this.dtpIni._Visible = true;
            this.dtpIni.AutoSize = true;
            this.dtpIni.BackColor = System.Drawing.Color.Transparent;
            this.dtpIni.Color = System.Drawing.Color.Empty;
            this.dtpIni.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpIni.Location = new System.Drawing.Point(409, 3);
            this.dtpIni.Margin = new System.Windows.Forms.Padding(3, 3, 15, 3);
            this.dtpIni.Name = "dtpIni";
            this.dtpIni.Size = new System.Drawing.Size(116, 23);
            this.dtpIni.TabIndex = 10;
            this.dtpIni.Value = new System.DateTime(2012, 5, 7, 14, 58, 27, 875);
            // 
            // dtpFim
            // 
            this.dtpFim._LabelText = "Até";
            this.dtpFim._Obrigatorio = HLP.GeraXml.Comum.Componentes.HLP_DateTimePicker.CampoObrigatorio.SIM;
            this.dtpFim._TamanhoDateTimePicker = 90;
            this.dtpFim._TamanhoMaiorLabel = 0;
            this.dtpFim._Visible = true;
            this.dtpFim.AutoSize = true;
            this.dtpFim.BackColor = System.Drawing.Color.Transparent;
            this.dtpFim.Color = System.Drawing.Color.Empty;
            this.dtpFim.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFim.Location = new System.Drawing.Point(543, 3);
            this.dtpFim.Margin = new System.Windows.Forms.Padding(3, 3, 15, 3);
            this.dtpFim.Name = "dtpFim";
            this.dtpFim.Size = new System.Drawing.Size(121, 23);
            this.dtpFim.TabIndex = 11;
            this.dtpFim.Value = new System.DateTime(2012, 5, 7, 14, 58, 27, 875);
            // 
            // txtNfIni
            // 
            this.txtNfIni._LabelText = "De";
            this.txtNfIni._Multiline = false;
            this.txtNfIni._Obrigatorio = HLP.GeraXml.Comum.Componentes.HLP_TextBox.CampoObrigatorio.SIM;
            this.txtNfIni._Password = false;
            this.txtNfIni._Regex = Expressoes.Não_Aplica;
            this.txtNfIni._Regex_Expressao = "";
            this.txtNfIni._TamanhoMaiorLabel = 0;
            this.txtNfIni._TamanhoTextBox = 90;
            this.txtNfIni._Visible = true;
            this.txtNfIni.AutoSize = true;
            this.txtNfIni.BackColor = System.Drawing.Color.Transparent;
            this.txtNfIni.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtNfIni.Color = System.Drawing.Color.White;
            this.txtNfIni.Location = new System.Drawing.Point(682, 3);
            this.txtNfIni.Margin = new System.Windows.Forms.Padding(3, 3, 15, 3);
            this.txtNfIni.MaxLength = 32767;
            this.txtNfIni.Name = "txtNfIni";
            this.txtNfIni.ReadOnly = false;
            this.txtNfIni.Size = new System.Drawing.Size(116, 23);
            this.txtNfIni.TabIndex = 12;
            // 
            // txtNfFim
            // 
            this.txtNfFim._LabelText = "Até";
            this.txtNfFim._Multiline = false;
            this.txtNfFim._Obrigatorio = HLP.GeraXml.Comum.Componentes.HLP_TextBox.CampoObrigatorio.SIM;
            this.txtNfFim._Password = false;
            this.txtNfFim._Regex = Expressoes.Não_Aplica;
            this.txtNfFim._Regex_Expressao = "";
            this.txtNfFim._TamanhoMaiorLabel = 0;
            this.txtNfFim._TamanhoTextBox = 90;
            this.txtNfFim._Visible = true;
            this.txtNfFim.AutoSize = true;
            this.txtNfFim.BackColor = System.Drawing.Color.Transparent;
            this.txtNfFim.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtNfFim.Color = System.Drawing.Color.White;
            this.txtNfFim.Location = new System.Drawing.Point(816, 3);
            this.txtNfFim.Margin = new System.Windows.Forms.Padding(3, 3, 15, 3);
            this.txtNfFim.MaxLength = 32767;
            this.txtNfFim.Name = "txtNfFim";
            this.txtNfFim.ReadOnly = false;
            this.txtNfFim.Size = new System.Drawing.Size(121, 23);
            this.txtNfFim.TabIndex = 13;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnPesquisa,
            this.toolStripSeparator4,
            this.btnEnvio,
            this.toolStripSeparator3,
            this.btnContingencia,
            this.toolStripSeparator2,
            this.btnCancelamento,
            this.toolStripSeparator1,
            this.btnSair,
            this.btnImpressao,
            this.toolStripSeparator5,
            this.btnGeraPdf,
            this.toolStripSeparator6,
            this.btnBuscaRetorno,
            this.toolStripSeparator7,
            this.btnConsultaSituacao});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(992, 27);
            this.menuStrip1.TabIndex = 104;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // btnPesquisa
            // 
            this.btnPesquisa.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPesquisa.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnPesquisa.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnPesquisa.Image = global::HLP.GeraXml.UI.Properties.Resources.pesquisar;
            this.btnPesquisa.ImageTransparentColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnPesquisa.Name = "btnPesquisa";
            this.btnPesquisa.Size = new System.Drawing.Size(79, 20);
            this.btnPesquisa.Text = "Pesquisar";
            this.btnPesquisa.Click += new System.EventHandler(this.btnPesquisa_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 23);
            // 
            // btnEnvio
            // 
            this.btnEnvio.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnEnvio.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnEnvio.Image = global::HLP.GeraXml.UI.Properties.Resources.send;
            this.btnEnvio.Name = "btnEnvio";
            this.btnEnvio.Size = new System.Drawing.Size(61, 20);
            this.btnEnvio.Text = "Enviar";
            this.btnEnvio.Click += new System.EventHandler(this.btnEnvio_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 23);
            // 
            // btnContingencia
            // 
            this.btnContingencia.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnContingencia.Image = global::HLP.GeraXml.UI.Properties.Resources.xml;
            this.btnContingencia.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnContingencia.Name = "btnContingencia";
            this.btnContingencia.Size = new System.Drawing.Size(159, 20);
            this.btnContingencia.Text = "Gerar Xml Contingência";
            this.btnContingencia.Click += new System.EventHandler(this.btnContingencia_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 23);
            // 
            // btnCancelamento
            // 
            this.btnCancelamento.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnCancelamento.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnCancelamento.Image = global::HLP.GeraXml.UI.Properties.Resources.cancel__3_;
            this.btnCancelamento.Name = "btnCancelamento";
            this.btnCancelamento.Size = new System.Drawing.Size(74, 20);
            this.btnCancelamento.Text = "Cancelar";
            this.btnCancelamento.Click += new System.EventHandler(this.btnCancelamento_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 23);
            // 
            // btnSair
            // 
            this.btnSair.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnSair.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSair.Image = global::HLP.GeraXml.UI.Properties.Resources.sair;
            this.btnSair.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSair.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(48, 20);
            this.btnSair.Text = "Sair";
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // btnImpressao
            // 
            this.btnImpressao.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnImpressao.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnImpressao.Image = global::HLP.GeraXml.UI.Properties.Resources.print;
            this.btnImpressao.Name = "btnImpressao";
            this.btnImpressao.Size = new System.Drawing.Size(116, 20);
            this.btnImpressao.Text = "Imprimir DACTE";
            this.btnImpressao.Click += new System.EventHandler(this.btnImpressao_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 23);
            // 
            // btnGeraPdf
            // 
            this.btnGeraPdf.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnGeraPdf.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnGeraPdf.Image = global::HLP.GeraXml.UI.Properties.Resources.pdf;
            this.btnGeraPdf.Name = "btnGeraPdf";
            this.btnGeraPdf.Size = new System.Drawing.Size(84, 20);
            this.btnGeraPdf.Text = "Gerar PDF";
            this.btnGeraPdf.Click += new System.EventHandler(this.btnGeraPdf_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 23);
            // 
            // btnBuscaRetorno
            // 
            this.btnBuscaRetorno.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnBuscaRetorno.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnBuscaRetorno.Image = global::HLP.GeraXml.UI.Properties.Resources.retorno;
            this.btnBuscaRetorno.Name = "btnBuscaRetorno";
            this.btnBuscaRetorno.Size = new System.Drawing.Size(113, 20);
            this.btnBuscaRetorno.Text = "Buscar Retorno";
            this.btnBuscaRetorno.Click += new System.EventHandler(this.btnBuscaRetorno_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 23);
            // 
            // btnConsultaSituacao
            // 
            this.btnConsultaSituacao.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnConsultaSituacao.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnConsultaSituacao.Image = global::HLP.GeraXml.UI.Properties.Resources.situacao;
            this.btnConsultaSituacao.Name = "btnConsultaSituacao";
            this.btnConsultaSituacao.Size = new System.Drawing.Size(129, 20);
            this.btnConsultaSituacao.Text = "Consultar Situação";
            this.btnConsultaSituacao.Click += new System.EventHandler(this.btnConsultaSituacao_Click);
            // 
            // cl_assina
            // 
            this.cl_assina.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cl_assina.HeaderText = "Selecionar";
            this.cl_assina.Name = "cl_assina";
            this.cl_assina.Width = 71;
            // 
            // nr_lanc
            // 
            this.nr_lanc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.nr_lanc.DataPropertyName = "nr_lanc";
            this.nr_lanc.HeaderText = "Sequência";
            this.nr_lanc.Name = "nr_lanc";
            this.nr_lanc.ReadOnly = true;
            this.nr_lanc.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.nr_lanc.Width = 90;
            // 
            // cd_conheci
            // 
            this.cd_conheci.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cd_conheci.DataPropertyName = "cd_conheci";
            this.cd_conheci.HeaderText = "Conhecimento";
            this.cd_conheci.Name = "cd_conheci";
            this.cd_conheci.ReadOnly = true;
            this.cd_conheci.Width = 115;
            // 
            // dt_emi
            // 
            this.dt_emi.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dt_emi.DataPropertyName = "dt_emi";
            this.dt_emi.HeaderText = "Emissão";
            this.dt_emi.Name = "dt_emi";
            this.dt_emi.ReadOnly = true;
            this.dt_emi.Width = 79;
            // 
            // vl_total
            // 
            this.vl_total.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.vl_total.DataPropertyName = "vl_total";
            this.vl_total.DecimalPlaces = 2;
            this.vl_total.HeaderText = "Valor Total";
            this.vl_total.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.vl_total.Maximum = new decimal(new int[] {
            1215752191,
            23,
            0,
            0});
            this.vl_total.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.vl_total.Name = "vl_total";
            this.vl_total.ReadOnly = true;
            this.vl_total.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.vl_total.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.vl_total.Width = 93;
            // 
            // nm_social
            // 
            this.nm_social.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nm_social.DataPropertyName = "nm_social";
            this.nm_social.HeaderText = "Remetente";
            this.nm_social.Name = "nm_social";
            this.nm_social.ReadOnly = true;
            // 
            // st_cte
            // 
            this.st_cte.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.st_cte.DataPropertyName = "st_cte";
            this.st_cte.HeaderText = "Enviado";
            this.st_cte.Name = "st_cte";
            this.st_cte.ReadOnly = true;
            this.st_cte.Visible = false;
            this.st_cte.Width = 59;
            // 
            // ds_cancelamento
            // 
            this.ds_cancelamento.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.ds_cancelamento.DataPropertyName = "ds_cancelamento";
            this.ds_cancelamento.HeaderText = "Cancelado";
            this.ds_cancelamento.Name = "ds_cancelamento";
            this.ds_cancelamento.ReadOnly = true;
            this.ds_cancelamento.Visible = false;
            this.ds_cancelamento.Width = 73;
            // 
            // st_contingencia
            // 
            this.st_contingencia.DataPropertyName = "st_contingencia";
            this.st_contingencia.HeaderText = "Contingência";
            this.st_contingencia.Name = "st_contingencia";
            this.st_contingencia.ReadOnly = true;
            this.st_contingencia.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.st_contingencia.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.st_contingencia.Visible = false;
            // 
            // frmGerarArquivosCte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 386);
            this.Controls.Add(this.kryptonPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmGerarArquivosCte";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gerar CT-e";
            this.Load += new System.EventHandler(this.frmGerarArquivosCte_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel)).EndInit();
            this.kryptonPanel.ResumeLayout(false);
            this.kryptonPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArquivos)).EndInit();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripButton btnPesquisa;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton btnEnvio;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnContingencia;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnCancelamento;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnSair;
        private System.Windows.Forms.ToolStripButton btnImpressao;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton btnGeraPdf;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton btnBuscaRetorno;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripButton btnConsultaSituacao;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private Comum.Componentes.HLP_ComboBox cboStatus;
        private Comum.Componentes.HLP_ComboBox cboFiltro;
        private Comum.Componentes.HLP_DateTimePicker dtpIni;
        private Comum.Componentes.HLP_DateTimePicker dtpFim;
        private Comum.Componentes.HLP_TextBox txtNfIni;
        private Comum.Componentes.HLP_TextBox txtNfFim;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView dgvArquivos;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblTotalRegistros;
        private System.Windows.Forms.Panel panel5;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private System.Windows.Forms.Panel panel6;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private System.Windows.Forms.Panel panel2;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel7;
        private System.Windows.Forms.Panel panel3;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel8;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnPendencias;
        private System.Windows.Forms.DataGridViewCheckBoxColumn cl_assina;
        private System.Windows.Forms.DataGridViewTextBoxColumn nr_lanc;
        private System.Windows.Forms.DataGridViewTextBoxColumn cd_conheci;
        private System.Windows.Forms.DataGridViewTextBoxColumn dt_emi;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewNumericUpDownColumn vl_total;
        private System.Windows.Forms.DataGridViewTextBoxColumn nm_social;
        private System.Windows.Forms.DataGridViewCheckBoxColumn st_cte;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ds_cancelamento;
        private System.Windows.Forms.DataGridViewCheckBoxColumn st_contingencia;
    }
}

