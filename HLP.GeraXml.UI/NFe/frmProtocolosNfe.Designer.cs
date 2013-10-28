using ComponentFactory.Krypton.Toolkit;
using AC.ExtendedRenderer.Navigator;

namespace HLP.GeraXml.UI.NFe
{
    partial class frmProtocolosNfe
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProtocolosNfe));
            this.tabControl1 = new AC.ExtendedRenderer.Navigator.KryptonTabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dgvInutilizacoes = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.tpAmbiente = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.nNFIni = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.nNFFin = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.dhRecbto = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.nProt = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dgvCancelamentos = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.tpAmb = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.cNF = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.cSeq = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.cProtocolo = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.Email = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewCheckBoxColumn();
            this.caminho = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.dataGridViewTextBoxColumn1 = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.cbxArquivos = new HLP.GeraXml.Comum.Componentes.HLP_ComboBox();
            this.btnPesquisar = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInutilizacoes)).BeginInit();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCancelamentos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.AllowCloseButton = false;
            this.tabControl1.AllowContextButton = false;
            this.tabControl1.AllowNavigatorButtons = false;
            this.tabControl1.AllowSelectedTabHigh = false;
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.BorderWidth = 1;
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.CornerRoundRadiusWidth = 12;
            this.tabControl1.CornerSymmetry = AC.ExtendedRenderer.Navigator.KryptonTabControl.CornSymmetry.Both;
            this.tabControl1.CornerType = AC.ExtendedRenderer.Toolkit.Drawing.DrawingMethods.CornerType.Rounded;
            this.tabControl1.CornerWidth = AC.ExtendedRenderer.Navigator.KryptonTabControl.CornWidth.Thin;
            this.tabControl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabControl1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.HotTrack = true;
            this.tabControl1.Location = new System.Drawing.Point(5, 35);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.PreserveTabColor = false;
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(648, 361);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.UseExtendedLayout = false;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dgvInutilizacoes);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(0);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(640, 332);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Tag = false;
            this.tabPage2.Text = "Notas Inutilizadas";
            this.toolTip1.SetToolTip(this.tabPage2, "As informações abaixo, são de Numerações Inutilizadas.");
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgvInutilizacoes
            // 
            this.dgvInutilizacoes.AllowUserToAddRows = false;
            this.dgvInutilizacoes.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvInutilizacoes.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvInutilizacoes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tpAmbiente,
            this.nNFIni,
            this.nNFFin,
            this.dhRecbto,
            this.nProt});
            this.dgvInutilizacoes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvInutilizacoes.Location = new System.Drawing.Point(0, 0);
            this.dgvInutilizacoes.Name = "dgvInutilizacoes";
            this.dgvInutilizacoes.ReadOnly = true;
            this.dgvInutilizacoes.Size = new System.Drawing.Size(640, 332);
            this.dgvInutilizacoes.TabIndex = 2;
            this.toolTip1.SetToolTip(this.dgvInutilizacoes, "Todas as notas que foram Inutilizadas estão sendo informadas abaixo.");
            // 
            // tpAmbiente
            // 
            this.tpAmbiente.HeaderText = "Ambiente";
            this.tpAmbiente.Name = "tpAmbiente";
            this.tpAmbiente.ReadOnly = true;
            this.tpAmbiente.Width = 120;
            // 
            // nNFIni
            // 
            this.nNFIni.HeaderText = "Nota Inicial";
            this.nNFIni.Name = "nNFIni";
            this.nNFIni.ReadOnly = true;
            this.nNFIni.Width = 100;
            // 
            // nNFFin
            // 
            this.nNFFin.HeaderText = "Nota Final";
            this.nNFFin.Name = "nNFFin";
            this.nNFFin.ReadOnly = true;
            this.nNFFin.Width = 100;
            // 
            // dhRecbto
            // 
            this.dhRecbto.HeaderText = "Data_Inutilização";
            this.dhRecbto.Name = "dhRecbto";
            this.dhRecbto.ReadOnly = true;
            this.dhRecbto.Width = 120;
            // 
            // nProt
            // 
            this.nProt.HeaderText = "Protocolo";
            this.nProt.Name = "nProt";
            this.nProt.ReadOnly = true;
            this.nProt.Width = 150;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.Transparent;
            this.tabPage1.Controls.Add(this.dgvCancelamentos);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(0);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(640, 332);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Tag = false;
            this.tabPage1.Text = "Solicitações de Cancelamento";
            this.toolTip1.SetToolTip(this.tabPage1, "Nem todas as notas abaixo podem ter sido canceladas, mas ao menos ocorreu uma sol" +
        "icitação de cancelamento!");
            // 
            // dgvCancelamentos
            // 
            this.dgvCancelamentos.AllowUserToAddRows = false;
            this.dgvCancelamentos.AllowUserToDeleteRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvCancelamentos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCancelamentos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tpAmb,
            this.cNF,
            this.cSeq,
            this.cProtocolo,
            this.Email,
            this.caminho});
            this.dgvCancelamentos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCancelamentos.Location = new System.Drawing.Point(0, 0);
            this.dgvCancelamentos.Name = "dgvCancelamentos";
            this.dgvCancelamentos.ReadOnly = true;
            this.dgvCancelamentos.Size = new System.Drawing.Size(640, 332);
            this.dgvCancelamentos.TabIndex = 2;
            this.dgvCancelamentos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCancelamentos_CellClick);
            // 
            // tpAmb
            // 
            this.tpAmb.HeaderText = "Ambiente";
            this.tpAmb.Name = "tpAmb";
            this.tpAmb.ReadOnly = true;
            this.tpAmb.Width = 100;
            // 
            // cNF
            // 
            this.cNF.HeaderText = "Nota Fiscal";
            this.cNF.Name = "cNF";
            this.cNF.ReadOnly = true;
            this.cNF.Width = 100;
            // 
            // cSeq
            // 
            this.cSeq.HeaderText = "Sequência";
            this.cSeq.Name = "cSeq";
            this.cSeq.ReadOnly = true;
            this.cSeq.Width = 100;
            // 
            // cProtocolo
            // 
            this.cProtocolo.HeaderText = "Protocolo";
            this.cProtocolo.Name = "cProtocolo";
            this.cProtocolo.ReadOnly = true;
            this.cProtocolo.Width = 150;
            // 
            // Email
            // 
            this.Email.DataPropertyName = "Email";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.NullValue = false;
            this.Email.DefaultCellStyle = dataGridViewCellStyle3;
            this.Email.FalseValue = null;
            this.Email.HeaderText = "Email";
            this.Email.IndeterminateValue = null;
            this.Email.Name = "Email";
            this.Email.ReadOnly = true;
            this.Email.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Email.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Email.TrueValue = null;
            this.Email.Visible = false;
            this.Email.Width = 50;
            // 
            // caminho
            // 
            this.caminho.HeaderText = "caminho";
            this.caminho.Name = "caminho";
            this.caminho.ReadOnly = true;
            this.caminho.Visible = false;
            this.caminho.Width = 100;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Ambiente";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 100;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Nota Fiscal";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 100;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Sequência";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 100;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Protocolo";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 120;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Ambiente";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 150;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "Nota Inicial";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 100;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "Nota Final";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Width = 100;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.HeaderText = "Data Inutilização";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Width = 100;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.HeaderText = "Protocolo";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.Width = 150;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.HeaderText = "caminho";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            this.dataGridViewTextBoxColumn10.Visible = false;
            this.dataGridViewTextBoxColumn10.Width = 100;
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.btnPesquisar);
            this.kryptonPanel1.Controls.Add(this.cbxArquivos);
            this.kryptonPanel1.Controls.Add(this.tabControl1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(656, 399);
            this.kryptonPanel1.TabIndex = 191;
            // 
            // cbxArquivos
            // 
            this.cbxArquivos._Itens = ((System.Collections.Generic.List<string>)(resources.GetObject("cbxArquivos._Itens")));
            this.cbxArquivos._LabelText = "Selecione o config";
            this.cbxArquivos._Obrigatorio = HLP.GeraXml.Comum.Componentes.HLP_ComboBox.CampoObrigatorio.NÃO;
            this.cbxArquivos._situacao = false;
            this.cbxArquivos._TamanhoComboBox = 228;
            this.cbxArquivos._TamanhoMaiorLabel = 0;
            this.cbxArquivos._Visible = true;
            this.cbxArquivos.AutoSize = true;
            this.cbxArquivos.BackColor = System.Drawing.Color.Transparent;
            this.cbxArquivos.Color = System.Drawing.Color.White;
            this.cbxArquivos.DataSource = null;
            this.cbxArquivos.DisplayMember = "DisplayMember";
            this.cbxArquivos.Location = new System.Drawing.Point(12, 4);
            this.cbxArquivos.Margin = new System.Windows.Forms.Padding(3, 3, 15, 3);
            this.cbxArquivos.Name = "cbxArquivos";
            this.cbxArquivos.SelectedIndex = -1;
            this.cbxArquivos.SelectedValue = 0;
            this.cbxArquivos.Size = new System.Drawing.Size(345, 25);
            this.cbxArquivos.TabIndex = 1;
            this.cbxArquivos.ValueMember = "ValueMember";
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.Location = new System.Drawing.Point(375, 3);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(90, 24);
            this.btnPesquisar.TabIndex = 2;
            this.btnPesquisar.Values.Text = "Pesquisar";
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            // 
            // frmProtocolosNfe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(656, 399);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmProtocolosNfe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Protocolos";
            this.Load += new System.EventHandler(this.frmProtocolos_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInutilizacoes)).EndInit();
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCancelamentos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private AC.ExtendedRenderer.Navigator.KryptonTabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private KryptonDataGridView dgvCancelamentos;
        private KryptonDataGridView dgvInutilizacoes;
        private KryptonDataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private KryptonDataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private KryptonDataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private KryptonDataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private KryptonDataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private KryptonDataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private KryptonDataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private KryptonDataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private KryptonDataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.ToolTip toolTip1;
        private KryptonDataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private KryptonDataGridViewTextBoxColumn tpAmbiente;
        private KryptonDataGridViewTextBoxColumn nNFIni;
        private KryptonDataGridViewTextBoxColumn nNFFin;
        private KryptonDataGridViewTextBoxColumn dhRecbto;
        private KryptonDataGridViewTextBoxColumn nProt;
        private Comum.Componentes.HLP_ComboBox cbxArquivos;
        private KryptonDataGridViewTextBoxColumn tpAmb;
        private KryptonDataGridViewTextBoxColumn cNF;
        private KryptonDataGridViewTextBoxColumn cSeq;
        private KryptonDataGridViewTextBoxColumn cProtocolo;
        private KryptonDataGridViewCheckBoxColumn Email;
        private KryptonDataGridViewTextBoxColumn caminho;
        private KryptonButton btnPesquisar;

    }
}