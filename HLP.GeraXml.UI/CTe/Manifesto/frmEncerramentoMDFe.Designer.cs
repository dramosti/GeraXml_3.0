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
            this.btnSair = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnCancelar = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.lblDescricao = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.cbxCidades = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.cbxCidades)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSair
            // 
            this.btnSair.Location = new System.Drawing.Point(167, 73);
            this.btnSair.Name = "btnSair";
            this.btnSair.TabIndex = 5;
            this.btnSair.Values.Text = "Sair";
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(17, 73);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(137, 25);
            this.btnCancelar.TabIndex = 4;
            this.btnCancelar.Values.Text = "Encerrar MDFe";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // lblDescricao
            // 
            this.lblDescricao.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldPanel;
            this.lblDescricao.Location = new System.Drawing.Point(14, 0);
            this.lblDescricao.Name = "lblDescricao";
            this.lblDescricao.Size = new System.Drawing.Size(243, 20);
            this.lblDescricao.TabIndex = 7;
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
            this.cbxCidades.Location = new System.Drawing.Point(17, 29);
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
            this.cbxCidades.TabIndex = 8;
            this.cbxCidades.ValueMember = "ValueMember";
            // 
            // frmEncerramentoMDFe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(274, 110);
            this.Controls.Add(this.lblDescricao);
            this.Controls.Add(this.cbxCidades);
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.btnCancelar);
            this.Name = "frmEncerramentoMDFe";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Encerramento.";
            this.Load += new System.EventHandler(this.frmEncerramentoMDFe_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cbxCidades)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonButton btnSair;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnCancelar;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblDescricao;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cbxCidades;

    }
}