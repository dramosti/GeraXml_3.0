namespace HLP.GeraXml.UI.NFse
{
    partial class frmGeraArquivoNFes
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGeraArquivoNFes));
            this.kryptonPanel = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.kryptonPanel2 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.dgvNF = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.bSeleciona = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.sCD_NOTAFIS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sCD_NFSEQ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dDT_EMI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dVL_TOTNF = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sNM_CLIFOR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bCancelado = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.bEnviado = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.belPesquisaNotasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.kryptonLabel7 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
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
            this.btnCancelamento = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSair = new System.Windows.Forms.ToolStripButton();
            this.btnVisualizar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.btnBuscaRetorno = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel)).BeginInit();
            this.kryptonPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).BeginInit();
            this.kryptonPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNF)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.belPesquisaNotasBindingSource)).BeginInit();
            this.flowLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonPanel
            // 
            this.kryptonPanel.Controls.Add(this.kryptonPanel1);
            this.kryptonPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel.Name = "kryptonPanel";
            this.kryptonPanel.Size = new System.Drawing.Size(1024, 367);
            this.kryptonPanel.TabIndex = 0;
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kryptonPanel2);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(1024, 367);
            this.kryptonPanel1.TabIndex = 1;
            // 
            // kryptonPanel2
            // 
            this.kryptonPanel2.Controls.Add(this.dgvNF);
            this.kryptonPanel2.Controls.Add(this.flowLayoutPanel2);
            this.kryptonPanel2.Controls.Add(this.flowLayoutPanel1);
            this.kryptonPanel2.Controls.Add(this.menuStrip1);
            this.kryptonPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel2.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.Size = new System.Drawing.Size(1024, 367);
            this.kryptonPanel2.TabIndex = 1;
            // 
            // dgvNF
            // 
            this.dgvNF.AllowUserToAddRows = false;
            this.dgvNF.AllowUserToDeleteRows = false;
            this.dgvNF.AllowUserToOrderColumns = true;
            this.dgvNF.AllowUserToResizeRows = false;
            this.dgvNF.AutoGenerateColumns = false;
            this.dgvNF.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.bSeleciona,
            this.sCD_NOTAFIS,
            this.sCD_NFSEQ,
            this.dDT_EMI,
            this.dVL_TOTNF,
            this.sNM_CLIFOR,
            this.bCancelado,
            this.bEnviado});
            this.dgvNF.DataSource = this.belPesquisaNotasBindingSource;
            this.dgvNF.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvNF.Location = new System.Drawing.Point(0, 57);
            this.dgvNF.Name = "dgvNF";
            this.dgvNF.RowHeadersVisible = false;
            this.dgvNF.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvNF.RowTemplate.Height = 23;
            this.dgvNF.Size = new System.Drawing.Size(1024, 281);
            this.dgvNF.TabIndex = 232;
            this.dgvNF.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvNF_CellContentClick);
            this.dgvNF.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvNF_ColumnHeaderMouseClick);
            // 
            // bSeleciona
            // 
            this.bSeleciona.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.bSeleciona.DataPropertyName = "bSeleciona";
            this.bSeleciona.HeaderText = "Selecionar";
            this.bSeleciona.Name = "bSeleciona";
            this.bSeleciona.Width = 71;
            // 
            // sCD_NOTAFIS
            // 
            this.sCD_NOTAFIS.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.sCD_NOTAFIS.DataPropertyName = "sCD_NOTAFIS";
            this.sCD_NOTAFIS.HeaderText = "RPS";
            this.sCD_NOTAFIS.Name = "sCD_NOTAFIS";
            this.sCD_NOTAFIS.ReadOnly = true;
            this.sCD_NOTAFIS.Width = 56;
            // 
            // sCD_NFSEQ
            // 
            this.sCD_NFSEQ.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.sCD_NFSEQ.DataPropertyName = "sCD_NFSEQ";
            this.sCD_NFSEQ.HeaderText = "Sequência";
            this.sCD_NFSEQ.Name = "sCD_NFSEQ";
            this.sCD_NFSEQ.ReadOnly = true;
            this.sCD_NFSEQ.Width = 90;
            // 
            // dDT_EMI
            // 
            this.dDT_EMI.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dDT_EMI.DataPropertyName = "dDT_EMI";
            this.dDT_EMI.HeaderText = "Emissão";
            this.dDT_EMI.Name = "dDT_EMI";
            this.dDT_EMI.ReadOnly = true;
            this.dDT_EMI.Width = 79;
            // 
            // dVL_TOTNF
            // 
            this.dVL_TOTNF.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dVL_TOTNF.DataPropertyName = "dVL_TOTNF";
            dataGridViewCellStyle1.Format = "n2";
            this.dVL_TOTNF.DefaultCellStyle = dataGridViewCellStyle1;
            this.dVL_TOTNF.HeaderText = "Valor";
            this.dVL_TOTNF.Name = "dVL_TOTNF";
            this.dVL_TOTNF.ReadOnly = true;
            this.dVL_TOTNF.Width = 63;
            // 
            // sNM_CLIFOR
            // 
            this.sNM_CLIFOR.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.sNM_CLIFOR.DataPropertyName = "sNM_CLIFOR";
            this.sNM_CLIFOR.HeaderText = "Cliente";
            this.sNM_CLIFOR.Name = "sNM_CLIFOR";
            this.sNM_CLIFOR.ReadOnly = true;
            // 
            // bCancelado
            // 
            this.bCancelado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.bCancelado.DataPropertyName = "bCancelado";
            this.bCancelado.HeaderText = "Cancelada";
            this.bCancelado.Name = "bCancelado";
            this.bCancelado.ReadOnly = true;
            this.bCancelado.Visible = false;
            // 
            // bEnviado
            // 
            this.bEnviado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.bEnviado.DataPropertyName = "bEnviado";
            this.bEnviado.HeaderText = "Enviada";
            this.bEnviado.Name = "bEnviado";
            this.bEnviado.ReadOnly = true;
            this.bEnviado.Visible = false;
            // 
            // belPesquisaNotasBindingSource
            // 
            this.belPesquisaNotasBindingSource.DataSource = typeof(HLP.GeraXml.bel.NFe.belPesquisaNotas);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel2.Controls.Add(this.panel5);
            this.flowLayoutPanel2.Controls.Add(this.kryptonLabel1);
            this.flowLayoutPanel2.Controls.Add(this.panel2);
            this.flowLayoutPanel2.Controls.Add(this.kryptonLabel7);
            this.flowLayoutPanel2.Controls.Add(this.panel6);
            this.flowLayoutPanel2.Controls.Add(this.kryptonLabel2);
            this.flowLayoutPanel2.Controls.Add(this.lblTotalRegistros);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 338);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(1024, 29);
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
            this.kryptonLabel1.Size = new System.Drawing.Size(83, 20);
            this.kryptonLabel1.TabIndex = 203;
            this.kryptonLabel1.Values.Text = "Não Enviada";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightGreen;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Location = new System.Drawing.Point(119, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(21, 20);
            this.panel2.TabIndex = 220;
            // 
            // kryptonLabel7
            // 
            this.kryptonLabel7.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldPanel;
            this.kryptonLabel7.Location = new System.Drawing.Point(146, 3);
            this.kryptonLabel7.Name = "kryptonLabel7";
            this.kryptonLabel7.Size = new System.Drawing.Size(56, 20);
            this.kryptonLabel7.TabIndex = 221;
            this.kryptonLabel7.Values.Text = "Enviada";
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.Khaki;
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel6.Location = new System.Drawing.Point(208, 3);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(21, 20);
            this.panel6.TabIndex = 224;
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldPanel;
            this.kryptonLabel2.Location = new System.Drawing.Point(235, 3);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(69, 20);
            this.kryptonLabel2.TabIndex = 225;
            this.kryptonLabel2.Values.Text = "Cancelada";
            // 
            // lblTotalRegistros
            // 
            this.lblTotalRegistros.AutoSize = false;
            this.lblTotalRegistros.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldPanel;
            this.lblTotalRegistros.Location = new System.Drawing.Point(310, 3);
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
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1024, 30);
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
            this.btnCancelamento,
            this.toolStripSeparator1,
            this.btnSair,
            this.btnVisualizar,
            this.toolStripSeparator5,
            this.btnBuscaRetorno});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1024, 27);
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
            // btnVisualizar
            // 
            this.btnVisualizar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnVisualizar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnVisualizar.Image = global::HLP.GeraXml.UI.Properties.Resources.print;
            this.btnVisualizar.Name = "btnVisualizar";
            this.btnVisualizar.Size = new System.Drawing.Size(79, 20);
            this.btnVisualizar.Text = "Visualizar";
            this.btnVisualizar.Click += new System.EventHandler(this.btnVisualizar_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 23);
            // 
            // btnBuscaRetorno
            // 
            this.btnBuscaRetorno.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnBuscaRetorno.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnBuscaRetorno.Image = global::HLP.GeraXml.UI.Properties.Resources.retorno;
            this.btnBuscaRetorno.Name = "btnBuscaRetorno";
            this.btnBuscaRetorno.Size = new System.Drawing.Size(73, 20);
            this.btnBuscaRetorno.Text = "Retorno";
            this.btnBuscaRetorno.Click += new System.EventHandler(this.btnBuscaRetorno_Click);
            // 
            // frmGeraArquivoNFes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 367);
            this.Controls.Add(this.kryptonPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmGeraArquivoNFes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gerar NFe-s";
            this.Load += new System.EventHandler(this.frmGeraArquivoNFes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel)).EndInit();
            this.kryptonPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).EndInit();
            this.kryptonPanel2.ResumeLayout(false);
            this.kryptonPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNF)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.belPesquisaNotasBindingSource)).EndInit();
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
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblTotalRegistros;
        private System.Windows.Forms.Panel panel5;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private System.Windows.Forms.Panel panel2;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel7;
        private System.Windows.Forms.Panel panel6;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private Comum.Componentes.HLP_ComboBox cboStatus;
        private Comum.Componentes.HLP_ComboBox cboFiltro;
        private Comum.Componentes.HLP_DateTimePicker dtpIni;
        private Comum.Componentes.HLP_DateTimePicker dtpFim;
        private Comum.Componentes.HLP_TextBox txtNfIni;
        private Comum.Componentes.HLP_TextBox txtNfFim;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripButton btnPesquisa;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton btnEnvio;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnCancelamento;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnSair;
        private System.Windows.Forms.ToolStripButton btnVisualizar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton btnBuscaRetorno;
        public ComponentFactory.Krypton.Toolkit.KryptonDataGridView dgvNF;
        private System.Windows.Forms.DataGridViewCheckBoxColumn bSelecionaDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sCDNOTAFISDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sCDNFSEQDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sCDGRUPONFDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dDTEMIDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sNMCLIFORDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dVLTOTNFDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn bCanceladoDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn bEnviadoDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn bContingenciaDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn bDenegadaDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sRECIBONFDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource belPesquisaNotasBindingSource;
        private System.Windows.Forms.DataGridViewCheckBoxColumn bSeleciona;
        private System.Windows.Forms.DataGridViewTextBoxColumn sCD_NOTAFIS;
        private System.Windows.Forms.DataGridViewTextBoxColumn sCD_NFSEQ;
        private System.Windows.Forms.DataGridViewTextBoxColumn dDT_EMI;
        private System.Windows.Forms.DataGridViewTextBoxColumn dVL_TOTNF;
        private System.Windows.Forms.DataGridViewTextBoxColumn sNM_CLIFOR;
        private System.Windows.Forms.DataGridViewCheckBoxColumn bCancelado;
        private System.Windows.Forms.DataGridViewCheckBoxColumn bEnviado;
    }
}

