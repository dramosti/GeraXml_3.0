namespace HLP.GeraXml.UI.NFe
{
    partial class frmCarregaDadosParaVisualizarDanfe
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
            this.bsDadosImp = new System.Windows.Forms.BindingSource(this.components);
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.dgvNotas = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.sCaminhoXmlDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sCaminhoPDFDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sCDNFSEQDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sCDNOTAFISDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.xStatusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.worker = new System.ComponentModel.BackgroundWorker();
            this.timerGeraPDF = new System.Windows.Forms.Timer(this.components);
            this.workerPDF = new System.ComponentModel.BackgroundWorker();
            this.lblInfo = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.timerEmail = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.bsDadosImp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNotas)).BeginInit();
            this.SuspendLayout();
            // 
            // bsDadosImp
            // 
            this.bsDadosImp.DataSource = typeof(HLP.GeraXml.UI.NFe.frmGeraArquivoNFe.DadosImpressao);
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.lblInfo);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 229);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(621, 23);
            this.kryptonPanel1.TabIndex = 1;
            // 
            // dgvNotas
            // 
            this.dgvNotas.AllowUserToAddRows = false;
            this.dgvNotas.AllowUserToDeleteRows = false;
            this.dgvNotas.AutoGenerateColumns = false;
            this.dgvNotas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.sCaminhoXmlDataGridViewTextBoxColumn,
            this.sCaminhoPDFDataGridViewTextBoxColumn,
            this.sCDNFSEQDataGridViewTextBoxColumn,
            this.sCDNOTAFISDataGridViewTextBoxColumn,
            this.tipoDataGridViewTextBoxColumn,
            this.xStatusDataGridViewTextBoxColumn});
            this.dgvNotas.DataSource = this.bsDadosImp;
            this.dgvNotas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvNotas.Location = new System.Drawing.Point(0, 0);
            this.dgvNotas.Name = "dgvNotas";
            this.dgvNotas.ReadOnly = true;
            this.dgvNotas.Size = new System.Drawing.Size(621, 229);
            this.dgvNotas.TabIndex = 2;
            // 
            // sCaminhoXmlDataGridViewTextBoxColumn
            // 
            this.sCaminhoXmlDataGridViewTextBoxColumn.DataPropertyName = "sCaminhoXml";
            this.sCaminhoXmlDataGridViewTextBoxColumn.HeaderText = "sCaminhoXml";
            this.sCaminhoXmlDataGridViewTextBoxColumn.Name = "sCaminhoXmlDataGridViewTextBoxColumn";
            this.sCaminhoXmlDataGridViewTextBoxColumn.ReadOnly = true;
            this.sCaminhoXmlDataGridViewTextBoxColumn.Visible = false;
            // 
            // sCaminhoPDFDataGridViewTextBoxColumn
            // 
            this.sCaminhoPDFDataGridViewTextBoxColumn.DataPropertyName = "sCaminhoPDF";
            this.sCaminhoPDFDataGridViewTextBoxColumn.HeaderText = "sCaminhoPDF";
            this.sCaminhoPDFDataGridViewTextBoxColumn.Name = "sCaminhoPDFDataGridViewTextBoxColumn";
            this.sCaminhoPDFDataGridViewTextBoxColumn.ReadOnly = true;
            this.sCaminhoPDFDataGridViewTextBoxColumn.Visible = false;
            // 
            // sCDNFSEQDataGridViewTextBoxColumn
            // 
            this.sCDNFSEQDataGridViewTextBoxColumn.DataPropertyName = "sCD_NFSEQ";
            this.sCDNFSEQDataGridViewTextBoxColumn.HeaderText = "Sequencia";
            this.sCDNFSEQDataGridViewTextBoxColumn.Name = "sCDNFSEQDataGridViewTextBoxColumn";
            this.sCDNFSEQDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // sCDNOTAFISDataGridViewTextBoxColumn
            // 
            this.sCDNOTAFISDataGridViewTextBoxColumn.DataPropertyName = "sCD_NOTAFIS";
            this.sCDNOTAFISDataGridViewTextBoxColumn.HeaderText = "NFe";
            this.sCDNOTAFISDataGridViewTextBoxColumn.Name = "sCDNOTAFISDataGridViewTextBoxColumn";
            this.sCDNOTAFISDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tipoDataGridViewTextBoxColumn
            // 
            this.tipoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.tipoDataGridViewTextBoxColumn.DataPropertyName = "tipo";
            this.tipoDataGridViewTextBoxColumn.HeaderText = "tipo";
            this.tipoDataGridViewTextBoxColumn.Name = "tipoDataGridViewTextBoxColumn";
            this.tipoDataGridViewTextBoxColumn.ReadOnly = true;
            this.tipoDataGridViewTextBoxColumn.Visible = false;
            // 
            // xStatusDataGridViewTextBoxColumn
            // 
            this.xStatusDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.xStatusDataGridViewTextBoxColumn.DataPropertyName = "xStatus";
            this.xStatusDataGridViewTextBoxColumn.HeaderText = "Status";
            this.xStatusDataGridViewTextBoxColumn.Name = "xStatusDataGridViewTextBoxColumn";
            this.xStatusDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // worker
            // 
            this.worker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.worker_DoWork);
            // 
            // timerGeraPDF
            // 
            this.timerGeraPDF.Tick += new System.EventHandler(this.timerVisualizaDANFE_Tick);
            // 
            // workerPDF
            // 
            this.workerPDF.DoWork += new System.ComponentModel.DoWorkEventHandler(this.workerPDF_DoWork);
            // 
            // lblInfo
            // 
            this.lblInfo.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblInfo.Location = new System.Drawing.Point(0, 0);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(6, 23);
            this.lblInfo.TabIndex = 0;
            this.lblInfo.Values.Text = "";
            // 
            // timerEmail
            // 
            this.timerEmail.Tick += new System.EventHandler(this.timerEmail_Tick);
            // 
            // frmCarregaDadosParaVisualizarDanfe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(621, 252);
            this.Controls.Add(this.dgvNotas);
            this.Controls.Add(this.kryptonPanel1);
            this.Name = "frmCarregaDadosParaVisualizarDanfe";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Visualização de Notas ...";
            this.Load += new System.EventHandler(this.frmCarregaDadosParaVisualizarDanfe_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bsDadosImp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNotas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource bsDadosImp;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView dgvNotas;
        private System.Windows.Forms.DataGridViewTextBoxColumn sCaminhoXmlDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sCaminhoPDFDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sCDNFSEQDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sCDNOTAFISDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn xStatusDataGridViewTextBoxColumn;
        private System.ComponentModel.BackgroundWorker worker;
        private System.Windows.Forms.Timer timerGeraPDF;
        private System.ComponentModel.BackgroundWorker workerPDF;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblInfo;
        private System.Windows.Forms.Timer timerEmail;

    }
}