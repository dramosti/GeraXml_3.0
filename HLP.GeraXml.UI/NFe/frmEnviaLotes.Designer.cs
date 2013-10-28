namespace HLP.GeraXml.UI.NFe
{
    partial class frmEnviaLotes
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
            this.async_work = new System.ComponentModel.BackgroundWorker();
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.btnParar = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.bsLotes = new System.Windows.Forms.BindingSource(this.components);
            this.txtInfoLote = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.dgvLotes = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.iLoteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iQtdeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.xStatusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsLotes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLotes)).BeginInit();
            this.SuspendLayout();
            // 
            // async_work
            // 
            this.async_work.WorkerReportsProgress = true;
            this.async_work.WorkerSupportsCancellation = true;
            this.async_work.DoWork += new System.ComponentModel.DoWorkEventHandler(this.worker_DoWork);
            this.async_work.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.async_work_ProgressChanged);
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.btnParar);
            this.kryptonPanel1.Controls.Add(this.progressBar1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 350);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(574, 24);
            this.kryptonPanel1.TabIndex = 4;
            // 
            // btnParar
            // 
            this.btnParar.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnParar.Location = new System.Drawing.Point(484, 0);
            this.btnParar.Name = "btnParar";
            this.btnParar.Size = new System.Drawing.Size(90, 24);
            this.btnParar.TabIndex = 4;
            this.btnParar.Values.Text = "Fechar";
            this.btnParar.Click += new System.EventHandler(this.btnParar_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.BackColor = System.Drawing.Color.White;
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Left;
            this.progressBar1.Location = new System.Drawing.Point(0, 0);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(193, 24);
            this.progressBar1.Step = 1;
            this.progressBar1.TabIndex = 3;
            // 
            // bsLotes
            // 
            this.bsLotes.DataSource = typeof(HLP.GeraXml.UI.NFe.frmEnviaLotes.lotes);
            // 
            // txtInfoLote
            // 
            this.txtInfoLote.AlwaysActive = false;
            this.txtInfoLote.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtInfoLote.Location = new System.Drawing.Point(0, 200);
            this.txtInfoLote.Multiline = true;
            this.txtInfoLote.Name = "txtInfoLote";
            this.txtInfoLote.ReadOnly = true;
            this.txtInfoLote.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtInfoLote.Size = new System.Drawing.Size(574, 150);
            this.txtInfoLote.StateActive.Back.Color1 = System.Drawing.Color.White;
            this.txtInfoLote.StateActive.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.txtInfoLote.StateActive.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.txtInfoLote.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.txtInfoLote.StateCommon.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.txtInfoLote.StateCommon.Border.Rounding = 6;
            this.txtInfoLote.StateCommon.Border.Width = 2;
            this.txtInfoLote.TabIndex = 6;
            this.txtInfoLote.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dgvLotes
            // 
            this.dgvLotes.AllowUserToAddRows = false;
            this.dgvLotes.AllowUserToDeleteRows = false;
            this.dgvLotes.AutoGenerateColumns = false;
            this.dgvLotes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iLoteDataGridViewTextBoxColumn,
            this.iQtdeDataGridViewTextBoxColumn,
            this.xStatusDataGridViewTextBoxColumn});
            this.dgvLotes.DataSource = this.bsLotes;
            this.dgvLotes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLotes.Location = new System.Drawing.Point(0, 0);
            this.dgvLotes.Name = "dgvLotes";
            this.dgvLotes.ReadOnly = true;
            this.dgvLotes.RowHeadersWidth = 25;
            this.dgvLotes.RowTemplate.Height = 20;
            this.dgvLotes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLotes.Size = new System.Drawing.Size(574, 200);
            this.dgvLotes.TabIndex = 7;
            this.dgvLotes.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvLotes_CellMouseClick);
            // 
            // iLoteDataGridViewTextBoxColumn
            // 
            this.iLoteDataGridViewTextBoxColumn.DataPropertyName = "iLote";
            this.iLoteDataGridViewTextBoxColumn.HeaderText = "Lote";
            this.iLoteDataGridViewTextBoxColumn.Name = "iLoteDataGridViewTextBoxColumn";
            this.iLoteDataGridViewTextBoxColumn.ReadOnly = true;
            this.iLoteDataGridViewTextBoxColumn.Width = 60;
            // 
            // iQtdeDataGridViewTextBoxColumn
            // 
            this.iQtdeDataGridViewTextBoxColumn.DataPropertyName = "iQtde";
            this.iQtdeDataGridViewTextBoxColumn.HeaderText = "Qtde";
            this.iQtdeDataGridViewTextBoxColumn.Name = "iQtdeDataGridViewTextBoxColumn";
            this.iQtdeDataGridViewTextBoxColumn.ReadOnly = true;
            this.iQtdeDataGridViewTextBoxColumn.Width = 60;
            // 
            // xStatusDataGridViewTextBoxColumn
            // 
            this.xStatusDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.xStatusDataGridViewTextBoxColumn.DataPropertyName = "xStatus";
            this.xStatusDataGridViewTextBoxColumn.HeaderText = "Status do processo";
            this.xStatusDataGridViewTextBoxColumn.Name = "xStatusDataGridViewTextBoxColumn";
            this.xStatusDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // timer1
            // 
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmEnviaLotes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 374);
            this.ControlBox = false;
            this.Controls.Add(this.dgvLotes);
            this.Controls.Add(this.txtInfoLote);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmEnviaLotes";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Envio de Lotes";
            this.Load += new System.EventHandler(this.frmEnviaLotes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bsLotes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLotes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource bsLotes;
        private System.ComponentModel.BackgroundWorker async_work;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnParar;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtInfoLote;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView dgvLotes;
        private System.Windows.Forms.DataGridViewTextBoxColumn iLoteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iQtdeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn xStatusDataGridViewTextBoxColumn;
        private System.Windows.Forms.Timer timer1;
    }
}