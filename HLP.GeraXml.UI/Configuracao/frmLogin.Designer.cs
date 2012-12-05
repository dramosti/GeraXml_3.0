namespace HLP.GeraXml.UI.Configuracao
{
    partial class frmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            this.kryptonPanel = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.btnSair = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnEntrar = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.txtSenha = new HLP.GeraXml.Comum.Componentes.HLP_TextBox();
            this.txtUsuario = new HLP.GeraXml.Comum.Componentes.HLP_TextBox();
            this.kryptonLabel4 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel)).BeginInit();
            this.kryptonPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonPanel
            // 
            this.kryptonPanel.Controls.Add(this.btnSair);
            this.kryptonPanel.Controls.Add(this.btnEntrar);
            this.kryptonPanel.Controls.Add(this.txtSenha);
            this.kryptonPanel.Controls.Add(this.txtUsuario);
            this.kryptonPanel.Controls.Add(this.kryptonLabel4);
            this.kryptonPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel.Name = "kryptonPanel";
            this.kryptonPanel.Size = new System.Drawing.Size(258, 158);
            this.kryptonPanel.TabIndex = 0;
            // 
            // btnSair
            // 
            this.btnSair.Location = new System.Drawing.Point(132, 121);
            this.btnSair.Name = "btnSair";
            this.btnSair.TabIndex = 4;
            this.btnSair.Values.Text = "Sair";
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // btnEntrar
            // 
            this.btnEntrar.Location = new System.Drawing.Point(36, 121);
            this.btnEntrar.Name = "btnEntrar";
            this.btnEntrar.TabIndex = 3;
            this.btnEntrar.Values.Text = "&Entrar";
            this.btnEntrar.Click += new System.EventHandler(this.btnEntrar_Click);
            // 
            // txtSenha
            // 
            this.txtSenha._LabelText = "Senha";
            this.txtSenha._Multiline = false;
            this.txtSenha._Obrigatorio = HLP.GeraXml.Comum.Componentes.HLP_TextBox.CampoObrigatorio.SIM;
            this.txtSenha._Password = true;
            this.txtSenha._Regex = Expressoes.Não_Aplica;
            this.txtSenha._Regex_Expressao = "";
            this.txtSenha._TamanhoMaiorLabel = 46;
            this.txtSenha._TamanhoTextBox = 145;
            this.txtSenha._Visible = true;
            this.txtSenha.AutoSize = true;
            this.txtSenha.BackColor = System.Drawing.Color.Transparent;
            this.txtSenha.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSenha.Color = System.Drawing.Color.White;
            this.txtSenha.Location = new System.Drawing.Point(38, 82);
            this.txtSenha.Margin = new System.Windows.Forms.Padding(3, 3, 15, 3);
            this.txtSenha.MaxLength = 20;
            this.txtSenha.Name = "txtSenha";
            this.txtSenha.ReadOnly = false;
            this.txtSenha.Size = new System.Drawing.Size(191, 23);
            this.txtSenha.TabIndex = 2;
            // 
            // txtUsuario
            // 
            this.txtUsuario._LabelText = "Usuário";
            this.txtUsuario._Multiline = false;
            this.txtUsuario._Obrigatorio = HLP.GeraXml.Comum.Componentes.HLP_TextBox.CampoObrigatorio.SIM;
            this.txtUsuario._Password = false;
            this.txtUsuario._Regex = Expressoes.Não_Aplica;
            this.txtUsuario._Regex_Expressao = "";
            this.txtUsuario._TamanhoMaiorLabel = 46;
            this.txtUsuario._TamanhoTextBox = 145;
            this.txtUsuario._Visible = true;
            this.txtUsuario.AutoSize = true;
            this.txtUsuario.BackColor = System.Drawing.Color.Transparent;
            this.txtUsuario.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtUsuario.Color = System.Drawing.Color.White;
            this.txtUsuario.Location = new System.Drawing.Point(29, 53);
            this.txtUsuario.Margin = new System.Windows.Forms.Padding(0, 3, 15, 3);
            this.txtUsuario.MaxLength = 20;
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.ReadOnly = false;
            this.txtUsuario.Size = new System.Drawing.Size(200, 23);
            this.txtUsuario.TabIndex = 1;
            // 
            // kryptonLabel4
            // 
            this.kryptonLabel4.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalPanel;
            this.kryptonLabel4.Location = new System.Drawing.Point(21, 12);
            this.kryptonLabel4.Name = "kryptonLabel4";
            this.kryptonLabel4.Size = new System.Drawing.Size(216, 30);
            this.kryptonLabel4.StateNormal.ShortText.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel4.TabIndex = 96;
            this.kryptonLabel4.Values.Text = "GeraXml  -  Acesso";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            this.errorProvider1.Icon = ((System.Drawing.Icon)(resources.GetObject("errorProvider1.Icon")));
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(258, 158);
            this.ControlBox = false;
            this.Controls.Add(this.kryptonPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmLogin_FormClosing);
            this.Load += new System.EventHandler(this.frmLogin_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmLogin_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel)).EndInit();
            this.kryptonPanel.ResumeLayout(false);
            this.kryptonPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel;
        private Comum.Componentes.HLP_TextBox txtSenha;
        private Comum.Componentes.HLP_TextBox txtUsuario;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel4;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnSair;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnEntrar;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}

