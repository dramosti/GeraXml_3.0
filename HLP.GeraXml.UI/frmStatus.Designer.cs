namespace HLP.GeraXml.UI
{
    partial class frmStatus
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStatus));
            this.timerWebService = new System.Windows.Forms.Timer(this.components);
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.btnCancelar = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.lblTempo = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.lblMsg = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.timerCertificado = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timerWebService
            // 
            this.timerWebService.Interval = 1000;
            this.timerWebService.Tick += new System.EventHandler(this.timerWebService_Tick);
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.btnCancelar);
            this.kryptonPanel1.Controls.Add(this.lblTempo);
            this.kryptonPanel1.Controls.Add(this.lblMsg);
            this.kryptonPanel1.Controls.Add(this.progressBar1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(359, 96);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnCancelar.Location = new System.Drawing.Point(0, 58);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(359, 25);
            this.btnCancelar.TabIndex = 10;
            this.btnCancelar.Values.Text = "&Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // lblTempo
            // 
            this.lblTempo.AutoSize = false;
            this.lblTempo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTempo.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldPanel;
            this.lblTempo.Location = new System.Drawing.Point(0, 24);
            this.lblTempo.Name = "lblTempo";
            this.lblTempo.Size = new System.Drawing.Size(359, 24);
            this.lblTempo.StateNormal.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.lblTempo.StateNormal.ShortText.TextV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.lblTempo.TabIndex = 9;
            this.lblTempo.Values.Text = "";
            // 
            // lblMsg
            // 
            this.lblMsg.AutoSize = false;
            this.lblMsg.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblMsg.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldPanel;
            this.lblMsg.Location = new System.Drawing.Point(0, 0);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(359, 24);
            this.lblMsg.StateNormal.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.lblMsg.StateNormal.ShortText.TextV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.lblMsg.TabIndex = 8;
            this.lblMsg.Values.Text = "Verificando Conexão com Internet";
            // 
            // progressBar1
            // 
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar1.Location = new System.Drawing.Point(0, 83);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(359, 13);
            this.progressBar1.Step = 1;
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar1.TabIndex = 7;
            // 
            // timerCertificado
            // 
            this.timerCertificado.Tick += new System.EventHandler(this.timerCertificado_Tick);
            // 
            // frmStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 96);
            this.ControlBox = false;
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmStatus";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmStatus_FormClosing);
            this.Load += new System.EventHandler(this.frmStatus_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmStatus_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        public ComponentFactory.Krypton.Toolkit.KryptonLabel lblMsg;
        private System.Windows.Forms.ProgressBar progressBar1;
        public ComponentFactory.Krypton.Toolkit.KryptonLabel lblTempo;
        public System.Windows.Forms.Timer timerWebService;
        private System.Windows.Forms.Timer timerCertificado;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnCancelar;
    }
}