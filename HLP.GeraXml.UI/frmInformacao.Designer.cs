namespace HLP.GeraXml.UI
{
    partial class frmInformacao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInformacao));
            this.kryptonPanel = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.lblNfe = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.lblNfs = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.lblCte = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.flpTpEmiss = new System.Windows.Forms.FlowLayoutPanel();
            this.rbNormal = new ComponentFactory.Krypton.Toolkit.KryptonRadioButton();
            this.rbCont = new ComponentFactory.Krypton.Toolkit.KryptonRadioButton();
            this.rbScan = new ComponentFactory.Krypton.Toolkit.KryptonRadioButton();
            this.kryptonButton1 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.timerFechaTela = new System.Windows.Forms.Timer(this.components);
            this.timerLoad = new System.Windows.Forms.Timer(this.components);
            this.rbNacional = new ComponentFactory.Krypton.Toolkit.KryptonRadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel)).BeginInit();
            this.kryptonPanel.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.flpTpEmiss.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonPanel
            // 
            this.kryptonPanel.Controls.Add(this.flowLayoutPanel1);
            this.kryptonPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel.Name = "kryptonPanel";
            this.kryptonPanel.Size = new System.Drawing.Size(196, 239);
            this.kryptonPanel.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanel1.Controls.Add(this.lblNfe);
            this.flowLayoutPanel1.Controls.Add(this.lblNfs);
            this.flowLayoutPanel1.Controls.Add(this.lblCte);
            this.flowLayoutPanel1.Controls.Add(this.flpTpEmiss);
            this.flowLayoutPanel1.Controls.Add(this.kryptonButton1);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(196, 239);
            this.flowLayoutPanel1.TabIndex = 2;
            this.flowLayoutPanel1.MouseLeave += new System.EventHandler(this.control_MouseLeave);
            this.flowLayoutPanel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.control_MouseMove);
            // 
            // lblNfe
            // 
            this.lblNfe.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldPanel;
            this.lblNfe.Location = new System.Drawing.Point(3, 3);
            this.lblNfe.Name = "lblNfe";
            this.lblNfe.Size = new System.Drawing.Size(38, 20);
            this.lblNfe.TabIndex = 0;
            this.lblNfe.Values.Text = "NF-e";
            this.lblNfe.MouseLeave += new System.EventHandler(this.control_MouseLeave);
            this.lblNfe.MouseMove += new System.Windows.Forms.MouseEventHandler(this.control_MouseMove);
            // 
            // lblNfs
            // 
            this.lblNfs.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldPanel;
            this.lblNfs.Location = new System.Drawing.Point(3, 29);
            this.lblNfs.Name = "lblNfs";
            this.lblNfs.Size = new System.Drawing.Size(49, 20);
            this.lblNfs.TabIndex = 1;
            this.lblNfs.Values.Text = "NF-e S";
            this.lblNfs.MouseLeave += new System.EventHandler(this.control_MouseLeave);
            this.lblNfs.MouseMove += new System.Windows.Forms.MouseEventHandler(this.control_MouseMove);
            // 
            // lblCte
            // 
            this.lblCte.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldPanel;
            this.lblCte.Location = new System.Drawing.Point(3, 55);
            this.lblCte.Name = "lblCte";
            this.lblCte.Size = new System.Drawing.Size(35, 20);
            this.lblCte.TabIndex = 2;
            this.lblCte.Values.Text = "Ct-e";
            this.lblCte.MouseLeave += new System.EventHandler(this.control_MouseLeave);
            this.lblCte.MouseMove += new System.Windows.Forms.MouseEventHandler(this.control_MouseMove);
            // 
            // flpTpEmiss
            // 
            this.flpTpEmiss.Controls.Add(this.rbNormal);
            this.flpTpEmiss.Controls.Add(this.rbCont);
            this.flpTpEmiss.Controls.Add(this.rbScan);
            this.flpTpEmiss.Controls.Add(this.rbNacional);
            this.flpTpEmiss.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpTpEmiss.Location = new System.Drawing.Point(3, 81);
            this.flpTpEmiss.Name = "flpTpEmiss";
            this.flpTpEmiss.Size = new System.Drawing.Size(182, 118);
            this.flpTpEmiss.TabIndex = 5;
            this.flpTpEmiss.MouseLeave += new System.EventHandler(this.control_MouseLeave);
            this.flpTpEmiss.MouseMove += new System.Windows.Forms.MouseEventHandler(this.control_MouseMove);
            // 
            // rbNormal
            // 
            this.rbNormal.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldPanel;
            this.rbNormal.Location = new System.Drawing.Point(3, 3);
            this.rbNormal.Name = "rbNormal";
            this.rbNormal.Size = new System.Drawing.Size(104, 20);
            this.rbNormal.TabIndex = 0;
            this.rbNormal.Values.Text = "Modo Normal";
            this.rbNormal.MouseLeave += new System.EventHandler(this.control_MouseLeave);
            this.rbNormal.MouseMove += new System.Windows.Forms.MouseEventHandler(this.control_MouseMove);
            // 
            // rbCont
            // 
            this.rbCont.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldPanel;
            this.rbCont.Location = new System.Drawing.Point(3, 29);
            this.rbCont.Name = "rbCont";
            this.rbCont.Size = new System.Drawing.Size(154, 20);
            this.rbCont.TabIndex = 1;
            this.rbCont.Values.Text = "Modo Contingência FS";
            this.rbCont.MouseLeave += new System.EventHandler(this.control_MouseLeave);
            this.rbCont.MouseMove += new System.Windows.Forms.MouseEventHandler(this.control_MouseMove);
            // 
            // rbScan
            // 
            this.rbScan.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldPanel;
            this.rbScan.Location = new System.Drawing.Point(3, 55);
            this.rbScan.Name = "rbScan";
            this.rbScan.Size = new System.Drawing.Size(173, 20);
            this.rbScan.TabIndex = 2;
            this.rbScan.Values.Text = "Modo Contingência SCAN";
            this.rbScan.MouseLeave += new System.EventHandler(this.control_MouseLeave);
            this.rbScan.MouseMove += new System.Windows.Forms.MouseEventHandler(this.control_MouseMove);
            // 
            // kryptonButton1
            // 
            this.kryptonButton1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kryptonButton1.Location = new System.Drawing.Point(3, 205);
            this.kryptonButton1.Name = "kryptonButton1";
            this.kryptonButton1.Size = new System.Drawing.Size(182, 25);
            this.kryptonButton1.TabIndex = 6;
            this.kryptonButton1.Values.Text = "Fechar";
            this.kryptonButton1.Click += new System.EventHandler(this.kryptonButton1_Click);
            // 
            // timerFechaTela
            // 
            this.timerFechaTela.Tick += new System.EventHandler(this.timerFechaTela_Tick);
            // 
            // timerLoad
            // 
            this.timerLoad.Interval = 1000;
            this.timerLoad.Tick += new System.EventHandler(this.timerLoad_Tick);
            // 
            // rbNacional
            // 
            this.rbNacional.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldPanel;
            this.rbNacional.Location = new System.Drawing.Point(3, 81);
            this.rbNacional.Name = "rbNacional";
            this.rbNacional.Size = new System.Drawing.Size(112, 20);
            this.rbNacional.TabIndex = 3;
            this.rbNacional.Values.Text = "Modo Nacional";
            // 
            // frmInformacao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(196, 239);
            this.Controls.Add(this.kryptonPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmInformacao";
            this.Opacity = 0.9D;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Deactivate += new System.EventHandler(this.frmStatus_Deactivate);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmInformacao_FormClosing);
            this.Load += new System.EventHandler(this.frmStatus_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmStatus_KeyDown);
            this.MouseLeave += new System.EventHandler(this.control_MouseLeave);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.control_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel)).EndInit();
            this.kryptonPanel.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.flpTpEmiss.ResumeLayout(false);
            this.flpTpEmiss.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel;
        private System.Windows.Forms.Timer timerFechaTela;
        private System.Windows.Forms.Timer timerLoad;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblNfe;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblNfs;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblCte;
        private ComponentFactory.Krypton.Toolkit.KryptonRadioButton rbNormal;
        private ComponentFactory.Krypton.Toolkit.KryptonRadioButton rbScan;
        public ComponentFactory.Krypton.Toolkit.KryptonRadioButton rbCont;
        public System.Windows.Forms.FlowLayoutPanel flpTpEmiss;
        private ComponentFactory.Krypton.Toolkit.KryptonButton kryptonButton1;
        private ComponentFactory.Krypton.Toolkit.KryptonRadioButton rbNacional;
    }
}

