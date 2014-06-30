namespace HLP.GeraXml.UI.CTe.Manifesto
{
    partial class frmEncerramentoMDFe
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.lblDescricao = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.cbxCidades = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.btnSair = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnCancelar = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbxCidades)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.lblDescricao);
            this.flowLayoutPanel1.Controls.Add(this.cbxCidades);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(256, 65);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // lblDescricao
            // 
            this.lblDescricao.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblDescricao.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldPanel;
            this.lblDescricao.Location = new System.Drawing.Point(3, 3);
            this.lblDescricao.Name = "lblDescricao";
            this.lblDescricao.Size = new System.Drawing.Size(243, 20);
            this.lblDescricao.TabIndex = 1;
            this.lblDescricao.Values.Text = "Selecione o município de encerramento.";
            // 
            // cbxCidades
            // 
            this.cbxCidades.AlwaysActive = false;
            this.cbxCidades.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbxCidades.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbxCidades.DisplayMember = "DisplayMember";
            this.cbxCidades.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxCidades.DropDownWidth = 116;
            this.cbxCidades.Location = new System.Drawing.Point(3, 29);
            this.cbxCidades.Name = "cbxCidades";
            this.cbxCidades.Size = new System.Drawing.Size(243, 21);
            this.cbxCidades.StateActive.ComboBox.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.cbxCidades.StateActive.ComboBox.Border.Color1 = System.Drawing.Color.Black;
            this.cbxCidades.StateActive.ComboBox.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.cbxCidades.StateActive.ComboBox.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.cbxCidades.StateActive.ComboBox.Border.Width = 1;
            this.cbxCidades.StateCommon.ComboBox.Border.Color1 = System.Drawing.Color.Black;
            this.cbxCidades.StateCommon.ComboBox.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.cbxCidades.StateCommon.ComboBox.Border.Width = 1;
            this.cbxCidades.StateDisabled.ComboBox.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(225)))), ((int)(((byte)(230)))));
            this.cbxCidades.StateDisabled.ComboBox.Border.Color1 = System.Drawing.Color.Black;
            this.cbxCidades.StateDisabled.ComboBox.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.cbxCidades.StateDisabled.ComboBox.Border.Width = 1;
            this.cbxCidades.TabIndex = 6;
            this.cbxCidades.ValueMember = "ValueMember";
            // 
            // btnSair
            // 
            this.btnSair.Location = new System.Drawing.Point(159, 73);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(90, 25);
            this.btnSair.TabIndex = 5;
            this.btnSair.Values.Text = "Sair";
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(5, 73);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(147, 25);
            this.btnCancelar.TabIndex = 4;
            this.btnCancelar.Values.Text = "Encerrar MDFe";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // frmEncerramentoMDFe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(256, 110);
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "frmEncerramentoMDFe";
            this.Text = "Encerramento de MDFe";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbxCidades)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        public ComponentFactory.Krypton.Toolkit.KryptonLabel lblDescricao;
        public ComponentFactory.Krypton.Toolkit.KryptonComboBox cbxCidades;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnSair;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnCancelar;

    }
}