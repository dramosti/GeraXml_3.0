using HLP.GeraXml.bel.NFes.DSF;
namespace HLP.GeraXml.UI.NFse.DSF
{
    partial class FrmCancelamentoDSF
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
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.kryptonButton2 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnCancelar = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.kryptonDataGridView1 = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.inscricaoMunicipalPrestadorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numeroNotaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codigoVerificacaoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.motivoCancelamentoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsCanc = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonDataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCanc)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kryptonButton2);
            this.kryptonPanel1.Controls.Add(this.btnCancelar);
            this.kryptonPanel1.Controls.Add(this.kryptonDataGridView1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(674, 298);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // kryptonButton2
            // 
            this.kryptonButton2.Location = new System.Drawing.Point(552, 268);
            this.kryptonButton2.Name = "kryptonButton2";
            this.kryptonButton2.Size = new System.Drawing.Size(112, 25);
            this.kryptonButton2.TabIndex = 2;
            this.kryptonButton2.Values.Text = "Abortar";
            this.kryptonButton2.Click += new System.EventHandler(this.kryptonButton2_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(371, 268);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(161, 25);
            this.btnCancelar.TabIndex = 1;
            this.btnCancelar.Values.Text = "Prosseguir Cancelamento";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // kryptonDataGridView1
            // 
            this.kryptonDataGridView1.AllowUserToAddRows = false;
            this.kryptonDataGridView1.AllowUserToDeleteRows = false;
            this.kryptonDataGridView1.AutoGenerateColumns = false;
            this.kryptonDataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.inscricaoMunicipalPrestadorDataGridViewTextBoxColumn,
            this.numeroNotaDataGridViewTextBoxColumn,
            this.codigoVerificacaoDataGridViewTextBoxColumn,
            this.motivoCancelamentoDataGridViewTextBoxColumn,
            this.idDataGridViewTextBoxColumn});
            this.kryptonDataGridView1.DataSource = this.bsCanc;
            this.kryptonDataGridView1.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonDataGridView1.Location = new System.Drawing.Point(0, 0);
            this.kryptonDataGridView1.Name = "kryptonDataGridView1";
            this.kryptonDataGridView1.RowHeadersWidth = 20;
            this.kryptonDataGridView1.Size = new System.Drawing.Size(674, 262);
            this.kryptonDataGridView1.TabIndex = 0;
            // 
            // inscricaoMunicipalPrestadorDataGridViewTextBoxColumn
            // 
            this.inscricaoMunicipalPrestadorDataGridViewTextBoxColumn.DataPropertyName = "InscricaoMunicipalPrestador";
            this.inscricaoMunicipalPrestadorDataGridViewTextBoxColumn.HeaderText = "IM";
            this.inscricaoMunicipalPrestadorDataGridViewTextBoxColumn.Name = "inscricaoMunicipalPrestadorDataGridViewTextBoxColumn";
            this.inscricaoMunicipalPrestadorDataGridViewTextBoxColumn.ReadOnly = true;
            this.inscricaoMunicipalPrestadorDataGridViewTextBoxColumn.Width = 80;
            // 
            // numeroNotaDataGridViewTextBoxColumn
            // 
            this.numeroNotaDataGridViewTextBoxColumn.DataPropertyName = "NumeroNota";
            this.numeroNotaDataGridViewTextBoxColumn.HeaderText = "Nota";
            this.numeroNotaDataGridViewTextBoxColumn.Name = "numeroNotaDataGridViewTextBoxColumn";
            this.numeroNotaDataGridViewTextBoxColumn.ReadOnly = true;
            this.numeroNotaDataGridViewTextBoxColumn.Width = 80;
            // 
            // codigoVerificacaoDataGridViewTextBoxColumn
            // 
            this.codigoVerificacaoDataGridViewTextBoxColumn.DataPropertyName = "CodigoVerificacao";
            this.codigoVerificacaoDataGridViewTextBoxColumn.HeaderText = "Cod. Verificacao";
            this.codigoVerificacaoDataGridViewTextBoxColumn.Name = "codigoVerificacaoDataGridViewTextBoxColumn";
            this.codigoVerificacaoDataGridViewTextBoxColumn.ReadOnly = true;
            this.codigoVerificacaoDataGridViewTextBoxColumn.Width = 120;
            // 
            // motivoCancelamentoDataGridViewTextBoxColumn
            // 
            this.motivoCancelamentoDataGridViewTextBoxColumn.DataPropertyName = "MotivoCancelamento";
            this.motivoCancelamentoDataGridViewTextBoxColumn.HeaderText = "MotivoCancelamento";
            this.motivoCancelamentoDataGridViewTextBoxColumn.MaxInputLength = 80;
            this.motivoCancelamentoDataGridViewTextBoxColumn.Name = "motivoCancelamentoDataGridViewTextBoxColumn";
            this.motivoCancelamentoDataGridViewTextBoxColumn.Width = 350;
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.Visible = false;
            // 
            // bsCanc
            // 
            this.bsCanc.DataSource = typeof(LoteNota);
            // 
            // FrmCancelamentoDSF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 298);
            this.Controls.Add(this.kryptonPanel1);
            this.Name = "FrmCancelamentoDSF";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cancelamento de NFe-Serviço";
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonDataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCanc)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView kryptonDataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn inscricaoMunicipalPrestadorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numeroNotaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigoVerificacaoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn motivoCancelamentoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource bsCanc;
        private ComponentFactory.Krypton.Toolkit.KryptonButton kryptonButton2;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnCancelar;

    }
}