namespace HLP.GeraXml.UI
{
    partial class frmEmail
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEmail));
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.btnCancelar = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnEnviar = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.dgvEmail = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.Enviar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.sNumDocumento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sDestinatario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sOutros = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmail)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.btnCancelar);
            this.kryptonPanel1.Controls.Add(this.btnEnviar);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(955, 36);
            this.kryptonPanel1.TabIndex = 226;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(799, 6);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(90, 25);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Values.Text = "&Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnEnviar
            // 
            this.btnEnviar.Location = new System.Drawing.Point(703, 6);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(90, 25);
            this.btnEnviar.TabIndex = 4;
            this.btnEnviar.Values.Text = "&Enviar E-mail";
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            // 
            // dgvEmail
            // 
            this.dgvEmail.AllowUserToAddRows = false;
            this.dgvEmail.AllowUserToDeleteRows = false;
            this.dgvEmail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Enviar,
            this.sNumDocumento,
            this.sDestinatario,
            this.sOutros});
            this.dgvEmail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvEmail.Location = new System.Drawing.Point(0, 36);
            this.dgvEmail.Name = "dgvEmail";
            this.dgvEmail.Size = new System.Drawing.Size(955, 350);
            this.dgvEmail.TabIndex = 227;
            this.dgvEmail.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEmail_CellClick);
            // 
            // Enviar
            // 
            this.Enviar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Enviar.HeaderText = "Enviar";
            this.Enviar.Name = "Enviar";
            this.Enviar.Width = 49;
            // 
            // sNumDocumento
            // 
            this.sNumDocumento.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.sNumDocumento.DataPropertyName = "sNumDocumento";
            this.sNumDocumento.HeaderText = "Nº Documento";
            this.sNumDocumento.Name = "sNumDocumento";
            this.sNumDocumento.ReadOnly = true;
            this.sNumDocumento.Width = 116;
            // 
            // sDestinatario
            // 
            this.sDestinatario.DataPropertyName = "sDestinatario";
            dataGridViewCellStyle1.NullValue = "\"\"";
            this.sDestinatario.DefaultCellStyle = dataGridViewCellStyle1;
            this.sDestinatario.HeaderText = "E-mail Destinatário";
            this.sDestinatario.Name = "sDestinatario";
            this.sDestinatario.Width = 380;
            // 
            // sOutros
            // 
            this.sOutros.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.sOutros.DataPropertyName = "sOutros";
            dataGridViewCellStyle2.NullValue = "\"\"";
            this.sOutros.DefaultCellStyle = dataGridViewCellStyle2;
            this.sOutros.HeaderText = "Outros";
            this.sOutros.Name = "sOutros";
            this.sOutros.ToolTipText = "Separe os endereços de E-mail por \";\"";
            // 
            // frmEmail
            // 
            this.AllowFormChrome = false;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(955, 386);
            this.Controls.Add(this.dgvEmail);
            this.Controls.Add(this.kryptonPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmEmail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Enviar E-mail";
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnCancelar;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnEnviar;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView dgvEmail;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Enviar;
        private System.Windows.Forms.DataGridViewTextBoxColumn sNumDocumento;
        private System.Windows.Forms.DataGridViewTextBoxColumn sDestinatario;
        private System.Windows.Forms.DataGridViewTextBoxColumn sOutros;
    }
}