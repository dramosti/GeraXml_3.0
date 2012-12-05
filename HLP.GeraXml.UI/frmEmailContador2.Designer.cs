namespace HLP.GeraXml.UI
{
    partial class frmEmailContador2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEmailContador2));
            this.kryptonPanel = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.tab = new AC.ExtendedRenderer.Navigator.KryptonTabControl();
            this.tbPrincipal = new System.Windows.Forms.TabPage();
            this.kryptonPanel2 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.dgvDados = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.selectDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.sMesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sAnoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iFaltantes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsPendenciaEmail = new System.Windows.Forms.BindingSource(this.components);
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.txtContador = new HLP.GeraXml.Comum.Componentes.HLP_TextBox();
            this.txtCopia = new HLP.GeraXml.Comum.Componentes.HLP_TextBox();
            this.btnEnviar = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.tbConfiguracao = new System.Windows.Forms.TabPage();
            this.kryptonPanel3 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbxSemanalmente = new ComponentFactory.Krypton.Toolkit.KryptonRadioButton();
            this.cbxMensalmente = new ComponentFactory.Krypton.Toolkit.KryptonRadioButton();
            this.cboDia = new HLP.GeraXml.Comum.Componentes.HLP_ComboBox();
            this.ctxReenvio = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.liberarParaReenvioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel)).BeginInit();
            this.kryptonPanel.SuspendLayout();
            this.tab.SuspendLayout();
            this.tbPrincipal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).BeginInit();
            this.kryptonPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsPendenciaEmail)).BeginInit();
            this.flowLayoutPanel2.SuspendLayout();
            this.tbConfiguracao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel3)).BeginInit();
            this.kryptonPanel3.SuspendLayout();
            this.flowLayoutPanel4.SuspendLayout();
            this.panel1.SuspendLayout();
            this.ctxReenvio.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonPanel
            // 
            this.kryptonPanel.Controls.Add(this.tab);
            this.kryptonPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel.Name = "kryptonPanel";
            this.kryptonPanel.Size = new System.Drawing.Size(374, 406);
            this.kryptonPanel.TabIndex = 0;
            // 
            // tab
            // 
            this.tab.AllowCloseButton = false;
            this.tab.AllowContextButton = false;
            this.tab.AllowNavigatorButtons = false;
            this.tab.AllowSelectedTabHigh = false;
            this.tab.BorderWidth = 1;
            this.tab.Controls.Add(this.tbPrincipal);
            this.tab.Controls.Add(this.tbConfiguracao);
            this.tab.CornerRoundRadiusWidth = 2;
            this.tab.CornerSymmetry = AC.ExtendedRenderer.Navigator.KryptonTabControl.CornSymmetry.Both;
            this.tab.CornerType = AC.ExtendedRenderer.Toolkit.Drawing.DrawingMethods.CornerType.Rounded;
            this.tab.CornerWidth = AC.ExtendedRenderer.Navigator.KryptonTabControl.CornWidth.Null;
            this.tab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tab.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tab.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tab.HotTrack = true;
            this.tab.Location = new System.Drawing.Point(0, 0);
            this.tab.Name = "tab";
            this.tab.PreserveTabColor = false;
            this.tab.SelectedIndex = 0;
            this.tab.Size = new System.Drawing.Size(374, 406);
            this.tab.TabIndex = 107;
            this.tab.UseExtendedLayout = false;
            // 
            // tbPrincipal
            // 
            this.tbPrincipal.BackColor = System.Drawing.SystemColors.Window;
            this.tbPrincipal.Controls.Add(this.kryptonPanel2);
            this.tbPrincipal.Location = new System.Drawing.Point(4, 25);
            this.tbPrincipal.Margin = new System.Windows.Forms.Padding(0);
            this.tbPrincipal.Name = "tbPrincipal";
            this.tbPrincipal.Size = new System.Drawing.Size(366, 377);
            this.tbPrincipal.TabIndex = 1;
            this.tbPrincipal.Tag = false;
            this.tbPrincipal.Text = "Envio";
            // 
            // kryptonPanel2
            // 
            this.kryptonPanel2.Controls.Add(this.dgvDados);
            this.kryptonPanel2.Controls.Add(this.flowLayoutPanel2);
            this.kryptonPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel2.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.Size = new System.Drawing.Size(366, 377);
            this.kryptonPanel2.TabIndex = 49;
            // 
            // dgvDados
            // 
            this.dgvDados.AllowUserToAddRows = false;
            this.dgvDados.AllowUserToDeleteRows = false;
            this.dgvDados.AutoGenerateColumns = false;
            this.dgvDados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.selectDataGridViewCheckBoxColumn,
            this.sMesDataGridViewTextBoxColumn,
            this.sAnoDataGridViewTextBoxColumn,
            this.iFaltantes});
            this.dgvDados.ContextMenuStrip = this.ctxReenvio;
            this.dgvDados.DataSource = this.bsPendenciaEmail;
            this.dgvDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDados.Location = new System.Drawing.Point(0, 0);
            this.dgvDados.Name = "dgvDados";
            this.dgvDados.RowHeadersWidth = 25;
            this.dgvDados.RowTemplate.Height = 21;
            this.dgvDados.Size = new System.Drawing.Size(366, 275);
            this.dgvDados.TabIndex = 51;
            this.dgvDados.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDados_CellClick);
            // 
            // selectDataGridViewCheckBoxColumn
            // 
            this.selectDataGridViewCheckBoxColumn.DataPropertyName = "Select";
            this.selectDataGridViewCheckBoxColumn.HeaderText = "Selecione";
            this.selectDataGridViewCheckBoxColumn.Name = "selectDataGridViewCheckBoxColumn";
            this.selectDataGridViewCheckBoxColumn.Width = 70;
            // 
            // sMesDataGridViewTextBoxColumn
            // 
            this.sMesDataGridViewTextBoxColumn.DataPropertyName = "sMes";
            this.sMesDataGridViewTextBoxColumn.HeaderText = "Mes";
            this.sMesDataGridViewTextBoxColumn.Name = "sMesDataGridViewTextBoxColumn";
            this.sMesDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.sMesDataGridViewTextBoxColumn.Width = 50;
            // 
            // sAnoDataGridViewTextBoxColumn
            // 
            this.sAnoDataGridViewTextBoxColumn.DataPropertyName = "sAno";
            this.sAnoDataGridViewTextBoxColumn.HeaderText = "Ano";
            this.sAnoDataGridViewTextBoxColumn.Name = "sAnoDataGridViewTextBoxColumn";
            this.sAnoDataGridViewTextBoxColumn.Width = 50;
            // 
            // iFaltantes
            // 
            this.iFaltantes.DataPropertyName = "iFaltantes";
            this.iFaltantes.HeaderText = "Faltantes";
            this.iFaltantes.MaxInputLength = 10;
            this.iFaltantes.Name = "iFaltantes";
            this.iFaltantes.Width = 80;
            // 
            // bsPendenciaEmail
            // 
            this.bsPendenciaEmail.DataSource = typeof(HLP.GeraXml.bel.PendenciaEmail);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.AutoScroll = true;
            this.flowLayoutPanel2.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel2.Controls.Add(this.txtContador);
            this.flowLayoutPanel2.Controls.Add(this.txtCopia);
            this.flowLayoutPanel2.Controls.Add(this.btnEnviar);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 275);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(366, 102);
            this.flowLayoutPanel2.TabIndex = 50;
            // 
            // txtContador
            // 
            this.txtContador._LabelText = "E-mail Contador";
            this.txtContador._Multiline = false;
            this.txtContador._Obrigatorio = HLP.GeraXml.Comum.Componentes.HLP_TextBox.CampoObrigatorio.SIM;
            this.txtContador._Password = false;
            this.txtContador._Regex = Expressoes.Não_Aplica;
            this.txtContador._Regex_Expressao = "";
            this.txtContador._TamanhoMaiorLabel = 105;
            this.txtContador._TamanhoTextBox = 225;
            this.txtContador._Visible = true;
            this.txtContador.AutoSize = true;
            this.txtContador.BackColor = System.Drawing.Color.Transparent;
            this.txtContador.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtContador.Color = System.Drawing.Color.White;
            this.txtContador.Enabled = false;
            this.txtContador.Location = new System.Drawing.Point(3, 3);
            this.txtContador.Margin = new System.Windows.Forms.Padding(3, 3, 15, 3);
            this.txtContador.MaxLength = 32767;
            this.txtContador.Name = "txtContador";
            this.txtContador.ReadOnly = false;
            this.txtContador.Size = new System.Drawing.Size(330, 23);
            this.txtContador.TabIndex = 230;
            // 
            // txtCopia
            // 
            this.txtCopia._LabelText = "Cópia para";
            this.txtCopia._Multiline = false;
            this.txtCopia._Obrigatorio = HLP.GeraXml.Comum.Componentes.HLP_TextBox.CampoObrigatorio.NÃO;
            this.txtCopia._Password = false;
            this.txtCopia._Regex = Expressoes.Não_Aplica;
            this.txtCopia._Regex_Expressao = "";
            this.txtCopia._TamanhoMaiorLabel = 105;
            this.txtCopia._TamanhoTextBox = 225;
            this.txtCopia._Visible = true;
            this.txtCopia.AutoSize = true;
            this.txtCopia.BackColor = System.Drawing.Color.Transparent;
            this.txtCopia.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtCopia.Color = System.Drawing.Color.White;
            this.txtCopia.Location = new System.Drawing.Point(35, 32);
            this.txtCopia.Margin = new System.Windows.Forms.Padding(35, 3, 15, 3);
            this.txtCopia.MaxLength = 32767;
            this.txtCopia.Name = "txtCopia";
            this.txtCopia.ReadOnly = false;
            this.txtCopia.Size = new System.Drawing.Size(298, 23);
            this.txtCopia.TabIndex = 231;
            // 
            // btnEnviar
            // 
            this.btnEnviar.Location = new System.Drawing.Point(3, 61);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(330, 25);
            this.btnEnviar.TabIndex = 232;
            this.btnEnviar.Values.Text = "Enviar";
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            // 
            // tbConfiguracao
            // 
            this.tbConfiguracao.BackColor = System.Drawing.SystemColors.Window;
            this.tbConfiguracao.Controls.Add(this.kryptonPanel3);
            this.tbConfiguracao.Location = new System.Drawing.Point(4, 25);
            this.tbConfiguracao.Margin = new System.Windows.Forms.Padding(0);
            this.tbConfiguracao.Name = "tbConfiguracao";
            this.tbConfiguracao.Size = new System.Drawing.Size(366, 377);
            this.tbConfiguracao.TabIndex = 2;
            this.tbConfiguracao.Tag = false;
            this.tbConfiguracao.Text = "Configuração de Alerta";
            // 
            // kryptonPanel3
            // 
            this.kryptonPanel3.Controls.Add(this.flowLayoutPanel4);
            this.kryptonPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel3.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel3.Name = "kryptonPanel3";
            this.kryptonPanel3.Size = new System.Drawing.Size(366, 377);
            this.kryptonPanel3.TabIndex = 75;
            // 
            // flowLayoutPanel4
            // 
            this.flowLayoutPanel4.AutoScroll = true;
            this.flowLayoutPanel4.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel4.Controls.Add(this.panel1);
            this.flowLayoutPanel4.Controls.Add(this.cboDia);
            this.flowLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel4.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel4.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel4.Name = "flowLayoutPanel4";
            this.flowLayoutPanel4.Size = new System.Drawing.Size(366, 377);
            this.flowLayoutPanel4.TabIndex = 79;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cbxSemanalmente);
            this.panel1.Controls.Add(this.cbxMensalmente);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(121, 53);
            this.panel1.TabIndex = 250;
            // 
            // cbxSemanalmente
            // 
            this.cbxSemanalmente.Location = new System.Drawing.Point(8, 29);
            this.cbxSemanalmente.Name = "cbxSemanalmente";
            this.cbxSemanalmente.Size = new System.Drawing.Size(103, 20);
            this.cbxSemanalmente.TabIndex = 1;
            this.cbxSemanalmente.Values.Text = "Semanalmente";
            this.cbxSemanalmente.CheckedChanged += new System.EventHandler(this.cbxSemanalmente_CheckedChanged);
            // 
            // cbxMensalmente
            // 
            this.cbxMensalmente.Checked = true;
            this.cbxMensalmente.Location = new System.Drawing.Point(8, 3);
            this.cbxMensalmente.Name = "cbxMensalmente";
            this.cbxMensalmente.Size = new System.Drawing.Size(96, 20);
            this.cbxMensalmente.TabIndex = 0;
            this.cbxMensalmente.Values.Text = "Mensalmente";
            this.cbxMensalmente.CheckedChanged += new System.EventHandler(this.cbxSemanalmente_CheckedChanged);
            // 
            // cboDia
            // 
            this.cboDia._Itens = ((System.Collections.Generic.List<string>)(resources.GetObject("cboDia._Itens")));
            this.cboDia._LabelText = "Dia da Semana";
            this.cboDia._Obrigatorio = HLP.GeraXml.Comum.Componentes.HLP_ComboBox.CampoObrigatorio.SIM;
            this.cboDia._situacao = false;
            this.cboDia._TamanhoComboBox = 151;
            this.cboDia._TamanhoMaiorLabel = 97;
            this.cboDia._Visible = true;
            this.cboDia.AutoSize = true;
            this.cboDia.BackColor = System.Drawing.Color.Transparent;
            this.cboDia.Color = System.Drawing.Color.White;
            this.cboDia.DataSource = null;
            this.cboDia.DisplayMember = "DisplayMember";
            this.cboDia.Enabled = false;
            this.cboDia.Location = new System.Drawing.Point(3, 62);
            this.cboDia.Margin = new System.Windows.Forms.Padding(3, 3, 15, 3);
            this.cboDia.Name = "cboDia";
            this.cboDia.SelectedIndex = -1;
            this.cboDia.SelectedValue = 0;
            this.cboDia.Size = new System.Drawing.Size(248, 24);
            this.cboDia.TabIndex = 249;
            this.cboDia.ValueMember = "ValueMember";
            // 
            // ctxReenvio
            // 
            this.ctxReenvio.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ctxReenvio.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.liberarParaReenvioToolStripMenuItem});
            this.ctxReenvio.Name = "ctxReenvio";
            this.ctxReenvio.Size = new System.Drawing.Size(179, 48);
            // 
            // liberarParaReenvioToolStripMenuItem
            // 
            this.liberarParaReenvioToolStripMenuItem.Name = "liberarParaReenvioToolStripMenuItem";
            this.liberarParaReenvioToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.liberarParaReenvioToolStripMenuItem.Text = "Liberar para reenvio";
            this.liberarParaReenvioToolStripMenuItem.Click += new System.EventHandler(this.liberarParaReenvioToolStripMenuItem_Click);
            // 
            // frmEmailContador2
            // 
            this.AllowFormChrome = false;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 406);
            this.Controls.Add(this.kryptonPanel);
            this.Name = "frmEmailContador2";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Email para Contador";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmEmailContador2_FormClosing);
            this.Load += new System.EventHandler(this.frmEmailContador2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel)).EndInit();
            this.kryptonPanel.ResumeLayout(false);
            this.tab.ResumeLayout(false);
            this.tbPrincipal.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).EndInit();
            this.kryptonPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDados)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsPendenciaEmail)).EndInit();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.tbConfiguracao.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel3)).EndInit();
            this.kryptonPanel3.ResumeLayout(false);
            this.flowLayoutPanel4.ResumeLayout(false);
            this.flowLayoutPanel4.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ctxReenvio.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel;
        private AC.ExtendedRenderer.Navigator.KryptonTabControl tab;
        private System.Windows.Forms.TabPage tbPrincipal;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel2;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView dgvDados;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private Comum.Componentes.HLP_TextBox txtContador;
        private Comum.Componentes.HLP_TextBox txtCopia;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnEnviar;
        private System.Windows.Forms.TabPage tbConfiguracao;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel4;
        private Comum.Componentes.HLP_ComboBox cboDia;
        private System.Windows.Forms.BindingSource bsPendenciaEmail;
        private System.Windows.Forms.Panel panel1;
        private ComponentFactory.Krypton.Toolkit.KryptonRadioButton cbxSemanalmente;
        private ComponentFactory.Krypton.Toolkit.KryptonRadioButton cbxMensalmente;
        private System.Windows.Forms.DataGridViewCheckBoxColumn selectDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sMesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sAnoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iFaltantes;
        private System.Windows.Forms.ContextMenuStrip ctxReenvio;
        private System.Windows.Forms.ToolStripMenuItem liberarParaReenvioToolStripMenuItem;
    }
}

