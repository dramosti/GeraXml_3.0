using System.Windows.Forms;
namespace HLP.GeraXml.UI
{
    partial class frmPrincipal
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Enviar NF-e (Ctrl + N)", 2, 2);
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Inutilizar", 2, 2);
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Status Sefaz", 2, 2);
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Protocolos", 2, 2);
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Manifestacao de Eventos", 2, 2);
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("NF-e", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode5});
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Enviar NF-e Serviço (Ctrl + S)", 2, 2);
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("NF-e Serviço", new System.Windows.Forms.TreeNode[] {
            treeNode7});
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Enviar CC-e", 2, 2);
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("CC-e", new System.Windows.Forms.TreeNode[] {
            treeNode9});
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("Enviar CT-e (Ctrl + T)");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("Enviar MDF-e (Ctrl + M)");
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("Inutilizar", 2, 2);
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("Status Sefaz", 2, 2);
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("CT-e", new System.Windows.Forms.TreeNode[] {
            treeNode11,
            treeNode12,
            treeNode13,
            treeNode14});
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrincipal));
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("E-mail", 3, 3);
            System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("Empresa", 5, 5);
            System.Windows.Forms.TreeNode treeNode18 = new System.Windows.Forms.TreeNode("Configuração (Ctrl + F)", 4, 4);
            System.Windows.Forms.TreeNode treeNode19 = new System.Windows.Forms.TreeNode("Consultar Disponibilidade ", 6, 6);
            this.kryptonManager1 = new ComponentFactory.Krypton.Toolkit.KryptonManager(this.components);
            this.toolStripContainer2 = new System.Windows.Forms.ToolStripContainer();
            this.kryptonPanel = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.splitContainerTela = new ComponentFactory.Krypton.Toolkit.KryptonSplitContainer();
            this.headerMenuLateral = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.btnMinimiza = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.tvMenu = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tvFerramentas = new System.Windows.Forms.TreeView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.kryptonSeparator1 = new ComponentFactory.Krypton.Toolkit.KryptonSeparator();
            this.btnMenu = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnFerramentas = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbldtVencCert = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblVersao = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblUsuario = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblEmpresa = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.tsEscritor = new System.Windows.Forms.ToolStripMenuItem();
            this.tsImportarXmlEscritor = new System.Windows.Forms.ToolStripMenuItem();
            this.tsConfiguracao = new System.Windows.Forms.ToolStripMenuItem();
            this.visualToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.office2010Azul = new System.Windows.Forms.ToolStripMenuItem();
            this.office2010Prata = new System.Windows.Forms.ToolStripMenuItem();
            this.office2010Preto = new System.Windows.Forms.ToolStripMenuItem();
            this.ajudaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.localDeInstalaçãoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.horaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnAtualizacao = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.toolStripContainer2.ContentPanel.SuspendLayout();
            this.toolStripContainer2.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel)).BeginInit();
            this.kryptonPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerTela)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerTela.Panel1)).BeginInit();
            this.splitContainerTela.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerTela.Panel2)).BeginInit();
            this.splitContainerTela.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.headerMenuLateral)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerMenuLateral.Panel)).BeginInit();
            this.headerMenuLateral.Panel.SuspendLayout();
            this.headerMenuLateral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSeparator1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonManager1
            // 
            this.kryptonManager1.GlobalPaletteMode = ComponentFactory.Krypton.Toolkit.PaletteModeManager.Office2010Silver;
            this.kryptonManager1.GlobalStrings.Abort = "Abortar";
            this.kryptonManager1.GlobalStrings.Cancel = "Cancelar";
            this.kryptonManager1.GlobalStrings.Close = "Fechar";
            this.kryptonManager1.GlobalStrings.Ignore = "Ignorar";
            this.kryptonManager1.GlobalStrings.No = "Não";
            this.kryptonManager1.GlobalStrings.Retry = "Tentar Novamente";
            this.kryptonManager1.GlobalStrings.Today = "Hoje";
            this.kryptonManager1.GlobalStrings.Yes = "Sim";
            // 
            // toolStripContainer2
            // 
            // 
            // toolStripContainer2.ContentPanel
            // 
            this.toolStripContainer2.ContentPanel.Controls.Add(this.kryptonPanel);
            this.toolStripContainer2.ContentPanel.Controls.Add(this.statusStrip1);
            this.toolStripContainer2.ContentPanel.Size = new System.Drawing.Size(722, 429);
            this.toolStripContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer2.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer2.Name = "toolStripContainer2";
            this.toolStripContainer2.Size = new System.Drawing.Size(722, 453);
            this.toolStripContainer2.TabIndex = 37;
            this.toolStripContainer2.Text = "toolStripContainer2";
            // 
            // toolStripContainer2.TopToolStripPanel
            // 
            this.toolStripContainer2.TopToolStripPanel.Controls.Add(this.menuStrip);
            // 
            // kryptonPanel
            // 
            this.kryptonPanel.Controls.Add(this.splitContainerTela);
            this.kryptonPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel.Name = "kryptonPanel";
            this.kryptonPanel.Padding = new System.Windows.Forms.Padding(5);
            this.kryptonPanel.Size = new System.Drawing.Size(722, 405);
            this.kryptonPanel.TabIndex = 0;
            // 
            // splitContainerTela
            // 
            this.splitContainerTela.Cursor = System.Windows.Forms.Cursors.Default;
            this.splitContainerTela.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerTela.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainerTela.Location = new System.Drawing.Point(5, 5);
            this.splitContainerTela.Name = "splitContainerTela";
            // 
            // splitContainerTela.Panel1
            // 
            this.splitContainerTela.Panel1.Controls.Add(this.headerMenuLateral);
            this.splitContainerTela.Panel1.Controls.Add(this.kryptonSeparator1);
            this.splitContainerTela.Panel1.Controls.Add(this.btnMenu);
            this.splitContainerTela.Panel1.Controls.Add(this.btnFerramentas);
            // 
            // splitContainerTela.Panel2
            // 
            this.splitContainerTela.Panel2.AutoScroll = true;
            this.splitContainerTela.Panel2.PanelBackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.HeaderCustom2;
            this.splitContainerTela.Size = new System.Drawing.Size(712, 395);
            this.splitContainerTela.SplitterDistance = 224;
            this.splitContainerTela.TabIndex = 3;
            // 
            // headerMenuLateral
            // 
            this.headerMenuLateral.AutoSize = true;
            this.headerMenuLateral.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup[] {
            this.btnMinimiza});
            this.headerMenuLateral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerMenuLateral.HeaderVisibleSecondary = false;
            this.headerMenuLateral.Location = new System.Drawing.Point(0, 0);
            this.headerMenuLateral.Name = "headerMenuLateral";
            // 
            // headerMenuLateral.Panel
            // 
            this.headerMenuLateral.Panel.Controls.Add(this.tvMenu);
            this.headerMenuLateral.Panel.Controls.Add(this.tvFerramentas);
            this.headerMenuLateral.Panel.Controls.Add(this.pictureBox1);
            this.headerMenuLateral.Panel.Padding = new System.Windows.Forms.Padding(2);
            this.headerMenuLateral.Size = new System.Drawing.Size(224, 335);
            this.headerMenuLateral.StateNormal.HeaderPrimary.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headerMenuLateral.TabIndex = 73;
            this.headerMenuLateral.ValuesPrimary.Heading = "Menu";
            this.headerMenuLateral.ValuesPrimary.Image = null;
            // 
            // btnMinimiza
            // 
            this.btnMinimiza.Type = ComponentFactory.Krypton.Toolkit.PaletteButtonSpecStyle.ArrowLeft;
            this.btnMinimiza.UniqueName = "266203CDA201483E72BF18ACC2C492DD";
            this.btnMinimiza.Click += new System.EventHandler(this.btnMinimiza_Click);
            // 
            // tvMenu
            // 
            this.tvMenu.BackColor = System.Drawing.SystemColors.Window;
            this.tvMenu.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tvMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvMenu.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tvMenu.ImageIndex = 0;
            this.tvMenu.ImageList = this.imageList1;
            this.tvMenu.Location = new System.Drawing.Point(2, 111);
            this.tvMenu.Name = "tvMenu";
            treeNode1.ImageIndex = 2;
            treeNode1.Name = "Node6";
            treeNode1.SelectedImageIndex = 2;
            treeNode1.Tag = "frmGeraArquivoNFe";
            treeNode1.Text = "Enviar NF-e (Ctrl + N)";
            treeNode2.ImageIndex = 2;
            treeNode2.Name = "Node8";
            treeNode2.SelectedImageIndex = 2;
            treeNode2.Tag = "frmInutilizaFaixaNFe";
            treeNode2.Text = "Inutilizar";
            treeNode3.ImageIndex = 2;
            treeNode3.Name = "Node9";
            treeNode3.SelectedImageIndex = 2;
            treeNode3.Tag = "Status Nfe";
            treeNode3.Text = "Status Sefaz";
            treeNode4.ImageIndex = 2;
            treeNode4.Name = "Node2";
            treeNode4.SelectedImageIndex = 2;
            treeNode4.Tag = "frmProtocolosNfe";
            treeNode4.Text = "Protocolos";
            treeNode5.ImageIndex = 2;
            treeNode5.Name = "Node0";
            treeNode5.SelectedImageIndex = 2;
            treeNode5.Tag = "frmManifestacaoEvento";
            treeNode5.Text = "Manifestacao de Eventos";
            treeNode6.Name = "nodeNfe";
            treeNode6.Text = "NF-e";
            treeNode7.ImageIndex = 2;
            treeNode7.Name = "Node5";
            treeNode7.SelectedImageIndex = 2;
            treeNode7.Tag = "frmGeraArquivoNFes";
            treeNode7.Text = "Enviar NF-e Serviço (Ctrl + S)";
            treeNode8.Name = "nodeNfes";
            treeNode8.Text = "NF-e Serviço";
            treeNode9.ImageIndex = 2;
            treeNode9.Name = "Node4";
            treeNode9.SelectedImageIndex = 2;
            treeNode9.Tag = "frmGeraArquivoCCe";
            treeNode9.Text = "Enviar CC-e";
            treeNode10.Name = "nodeCce";
            treeNode10.Text = "CC-e";
            treeNode11.ImageIndex = 2;
            treeNode11.Name = "nodeEnvCte";
            treeNode11.SelectedImageKey = "Form_Win32.png";
            treeNode11.Tag = "frmGerarArquivosCte";
            treeNode11.Text = "Enviar CT-e (Ctrl + T)";
            treeNode12.ImageIndex = 2;
            treeNode12.Name = "nodEnvMDFe";
            treeNode12.SelectedImageKey = "Form_Win32.png";
            treeNode12.Tag = "frmGerarArquivosMDFe";
            treeNode12.Text = "Enviar MDF-e (Ctrl + M)";
            treeNode13.ImageIndex = 2;
            treeNode13.Name = "nodeInutCte";
            treeNode13.SelectedImageIndex = 2;
            treeNode13.Tag = "frmInutilizaFaixaCte";
            treeNode13.Text = "Inutilizar";
            treeNode14.ImageIndex = 2;
            treeNode14.Name = "nodeSefazCte";
            treeNode14.SelectedImageIndex = 2;
            treeNode14.Tag = "Status Cte";
            treeNode14.Text = "Status Sefaz";
            treeNode15.Name = "nodeCte";
            treeNode15.Text = "CT-e";
            this.tvMenu.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode6,
            treeNode8,
            treeNode10,
            treeNode15});
            this.tvMenu.SelectedImageIndex = 0;
            this.tvMenu.ShowLines = false;
            this.tvMenu.Size = new System.Drawing.Size(218, 193);
            this.tvMenu.TabIndex = 10;
            this.tvMenu.BeforeCollapse += new System.Windows.Forms.TreeViewCancelEventHandler(this.tvMenu_BeforeCollapse);
            this.tvMenu.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.tvMenu_BeforeExpand);
            this.tvMenu.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvMenu_NodeMouseDoubleClick);
            this.tvMenu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tvMenu_KeyDown);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Folder_Closed.png");
            this.imageList1.Images.SetKeyName(1, "Folder_Open.png");
            this.imageList1.Images.SetKeyName(2, "Form_Win32.png");
            this.imageList1.Images.SetKeyName(3, "Message.png");
            this.imageList1.Images.SetKeyName(4, "Tools.png");
            this.imageList1.Images.SetKeyName(5, "Producao_.png");
            this.imageList1.Images.SetKeyName(6, "send.ico");
            // 
            // tvFerramentas
            // 
            this.tvFerramentas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tvFerramentas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvFerramentas.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tvFerramentas.ImageIndex = 0;
            this.tvFerramentas.ImageList = this.imageList1;
            this.tvFerramentas.Location = new System.Drawing.Point(2, 111);
            this.tvFerramentas.Name = "tvFerramentas";
            treeNode16.ImageIndex = 3;
            treeNode16.Name = "nodeEmail";
            treeNode16.SelectedImageIndex = 3;
            treeNode16.Tag = "frmEmailContador";
            treeNode16.Text = "E-mail";
            treeNode17.ImageIndex = 5;
            treeNode17.Name = "nodeEmpresa";
            treeNode17.SelectedImageIndex = 5;
            treeNode17.Tag = "frmSelecionaConfigs";
            treeNode17.Text = "Empresa";
            treeNode18.ImageIndex = 4;
            treeNode18.Name = "nodeConfig";
            treeNode18.SelectedImageIndex = 4;
            treeNode18.Tag = "frmLoginConfig";
            treeNode18.Text = "Configuração (Ctrl + F)";
            treeNode19.ImageIndex = 6;
            treeNode19.Name = "nodeDisponibilidade";
            treeNode19.SelectedImageIndex = 6;
            treeNode19.Tag = "Disponibilidade";
            treeNode19.Text = "Consultar Disponibilidade ";
            this.tvFerramentas.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode16,
            treeNode17,
            treeNode18,
            treeNode19});
            this.tvFerramentas.SelectedImageIndex = 0;
            this.tvFerramentas.ShowLines = false;
            this.tvFerramentas.Size = new System.Drawing.Size(218, 193);
            this.tvFerramentas.TabIndex = 13;
            this.tvFerramentas.BeforeCollapse += new System.Windows.Forms.TreeViewCancelEventHandler(this.tvMenu_BeforeCollapse);
            this.tvFerramentas.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.tvMenu_BeforeExpand);
            this.tvFerramentas.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvFerramentas_NodeMouseDoubleClick);
            this.tvFerramentas.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tvFerramentas_KeyDown);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Image = global::HLP.GeraXml.UI.Properties.Resources.xml2;
            this.pictureBox1.Location = new System.Drawing.Point(2, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Padding = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.pictureBox1.Size = new System.Drawing.Size(218, 109);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 69;
            this.pictureBox1.TabStop = false;
            // 
            // kryptonSeparator1
            // 
            this.kryptonSeparator1.AllowMove = false;
            this.kryptonSeparator1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kryptonSeparator1.Location = new System.Drawing.Point(0, 335);
            this.kryptonSeparator1.Name = "kryptonSeparator1";
            this.kryptonSeparator1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.kryptonSeparator1.Size = new System.Drawing.Size(224, 8);
            this.kryptonSeparator1.TabIndex = 70;
            // 
            // btnMenu
            // 
            this.btnMenu.ButtonStyle = ComponentFactory.Krypton.Toolkit.ButtonStyle.NavigatorStack;
            this.btnMenu.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnMenu.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnMenu.Location = new System.Drawing.Point(0, 343);
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.OverrideFocus.Border.Draw = ComponentFactory.Krypton.Toolkit.InheritBool.True;
            this.btnMenu.OverrideFocus.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnMenu.OverrideFocus.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnMenu.Size = new System.Drawing.Size(224, 26);
            this.btnMenu.StateCommon.Content.Image.ImageH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.btnMenu.StateCommon.Content.Image.ImageV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.btnMenu.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenu.StatePressed.Back.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnMenu.StateTracking.Back.ColorAngle = 1F;
            this.btnMenu.StateTracking.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounded;
            this.btnMenu.StateTracking.Back.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnMenu.StateTracking.Border.Draw = ComponentFactory.Krypton.Toolkit.InheritBool.True;
            this.btnMenu.StateTracking.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnMenu.StateTracking.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnMenu.TabIndex = 1;
            this.btnMenu.Values.Text = "Menu";
            this.btnMenu.Click += new System.EventHandler(this.btnLateral_Click);
            // 
            // btnFerramentas
            // 
            this.btnFerramentas.ButtonStyle = ComponentFactory.Krypton.Toolkit.ButtonStyle.NavigatorStack;
            this.btnFerramentas.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnFerramentas.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnFerramentas.Location = new System.Drawing.Point(0, 369);
            this.btnFerramentas.Name = "btnFerramentas";
            this.btnFerramentas.OverrideFocus.Border.Draw = ComponentFactory.Krypton.Toolkit.InheritBool.True;
            this.btnFerramentas.OverrideFocus.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnFerramentas.OverrideFocus.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnFerramentas.Size = new System.Drawing.Size(224, 26);
            this.btnFerramentas.StateCommon.Content.Image.ImageH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.btnFerramentas.StateCommon.Content.Image.ImageV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.btnFerramentas.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFerramentas.StateCommon.Content.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.btnFerramentas.StateTracking.Back.ColorAngle = 1F;
            this.btnFerramentas.StateTracking.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounded;
            this.btnFerramentas.StateTracking.Back.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnFerramentas.StateTracking.Border.Draw = ComponentFactory.Krypton.Toolkit.InheritBool.True;
            this.btnFerramentas.StateTracking.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnFerramentas.StateTracking.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnFerramentas.TabIndex = 2;
            this.btnFerramentas.Values.Text = "Ferramentas";
            this.btnFerramentas.Click += new System.EventHandler(this.btnLateral_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel2,
            this.lbldtVencCert,
            this.lblVersao,
            this.lblStatus,
            this.lblUsuario,
            this.lblEmpresa});
            this.statusStrip1.Location = new System.Drawing.Point(0, 405);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode;
            this.statusStrip1.Size = new System.Drawing.Size(722, 24);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(477, 19);
            this.toolStripStatusLabel2.Spring = true;
            this.toolStripStatusLabel2.Text = "Copyright © 2012 - HLP Informática Ltda";
            this.toolStripStatusLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbldtVencCert
            // 
            this.lbldtVencCert.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.lbldtVencCert.Name = "lbldtVencCert";
            this.lbldtVencCert.Size = new System.Drawing.Size(70, 19);
            this.lbldtVencCert.Text = "dtVencCert";
            this.lbldtVencCert.Visible = false;
            // 
            // lblVersao
            // 
            this.lblVersao.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.lblVersao.Name = "lblVersao";
            this.lblVersao.Size = new System.Drawing.Size(46, 19);
            this.lblVersao.Text = "Versão";
            // 
            // lblStatus
            // 
            this.lblStatus.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.lblStatus.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.lblStatus.IsLink = true;
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(77, 19);
            this.lblStatus.Text = "Informações";
            this.lblStatus.Click += new System.EventHandler(this.lblStatus_Click);
            // 
            // lblUsuario
            // 
            this.lblUsuario.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.lblUsuario.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(51, 19);
            this.lblUsuario.Text = "Usuario";
            // 
            // lblEmpresa
            // 
            this.lblEmpresa.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.lblEmpresa.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.lblEmpresa.Name = "lblEmpresa";
            this.lblEmpresa.Size = new System.Drawing.Size(56, 19);
            this.lblEmpresa.Text = "Empresa";
            // 
            // menuStrip
            // 
            this.menuStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsEscritor,
            this.visualToolStripMenuItem,
            this.ajudaToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(722, 24);
            this.menuStrip.TabIndex = 33;
            this.menuStrip.Text = "MenuStrip";
            // 
            // tsEscritor
            // 
            this.tsEscritor.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsImportarXmlEscritor,
            this.tsConfiguracao});
            this.tsEscritor.Name = "tsEscritor";
            this.tsEscritor.Size = new System.Drawing.Size(66, 20);
            this.tsEscritor.Text = "Arquivos";
            // 
            // tsImportarXmlEscritor
            // 
            this.tsImportarXmlEscritor.Name = "tsImportarXmlEscritor";
            this.tsImportarXmlEscritor.Size = new System.Drawing.Size(215, 22);
            this.tsImportarXmlEscritor.Text = "Importar  Xml para Escritor";
            this.tsImportarXmlEscritor.Click += new System.EventHandler(this.tsImportarXmlEscritor_Click);
            // 
            // tsConfiguracao
            // 
            this.tsConfiguracao.Name = "tsConfiguracao";
            this.tsConfiguracao.Size = new System.Drawing.Size(215, 22);
            this.tsConfiguracao.Text = "Configuração";
            this.tsConfiguracao.Click += new System.EventHandler(this.tsConfiguracao_Click);
            // 
            // visualToolStripMenuItem
            // 
            this.visualToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.office2010Azul,
            this.office2010Prata,
            this.office2010Preto});
            this.visualToolStripMenuItem.Name = "visualToolStripMenuItem";
            this.visualToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.visualToolStripMenuItem.Text = "Visual";
            // 
            // office2010Azul
            // 
            this.office2010Azul.Name = "office2010Azul";
            this.office2010Azul.Size = new System.Drawing.Size(172, 22);
            this.office2010Azul.Text = "Office 2010 - Azul";
            this.office2010Azul.Click += new System.EventHandler(this.VisualToolStripMenuItem_Click);
            // 
            // office2010Prata
            // 
            this.office2010Prata.Checked = true;
            this.office2010Prata.CheckState = System.Windows.Forms.CheckState.Checked;
            this.office2010Prata.Name = "office2010Prata";
            this.office2010Prata.Size = new System.Drawing.Size(172, 22);
            this.office2010Prata.Text = "Office 2010 - Prata";
            this.office2010Prata.Click += new System.EventHandler(this.VisualToolStripMenuItem_Click);
            // 
            // office2010Preto
            // 
            this.office2010Preto.Name = "office2010Preto";
            this.office2010Preto.Size = new System.Drawing.Size(172, 22);
            this.office2010Preto.Text = "Office 2010 - Preto";
            this.office2010Preto.Click += new System.EventHandler(this.VisualToolStripMenuItem_Click);
            // 
            // ajudaToolStripMenuItem
            // 
            this.ajudaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.localDeInstalaçãoToolStripMenuItem,
            this.horaToolStripMenuItem,
            this.toolStripSeparator1,
            this.btnAtualizacao});
            this.ajudaToolStripMenuItem.Name = "ajudaToolStripMenuItem";
            this.ajudaToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.ajudaToolStripMenuItem.Text = "Sobre";
            // 
            // localDeInstalaçãoToolStripMenuItem
            // 
            this.localDeInstalaçãoToolStripMenuItem.Name = "localDeInstalaçãoToolStripMenuItem";
            this.localDeInstalaçãoToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.localDeInstalaçãoToolStripMenuItem.Text = "Local de Instalação";
            this.localDeInstalaçãoToolStripMenuItem.Click += new System.EventHandler(this.localDeInstalaçãoToolStripMenuItem_Click);
            // 
            // horaToolStripMenuItem
            // 
            this.horaToolStripMenuItem.Name = "horaToolStripMenuItem";
            this.horaToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.horaToolStripMenuItem.Text = "Hora do Servidor";
            this.horaToolStripMenuItem.Click += new System.EventHandler(this.horaToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(171, 6);
            // 
            // btnAtualizacao
            // 
            this.btnAtualizacao.Name = "btnAtualizacao";
            this.btnAtualizacao.Size = new System.Drawing.Size(174, 22);
            this.btnAtualizacao.Text = "Atualizações";
            this.btnAtualizacao.Click += new System.EventHandler(this.btnAtualizacao_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmPrincipal
            // 
            this.AllowFormChrome = false;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(722, 453);
            this.Controls.Add(this.toolStripContainer2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "frmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GeraXml 3.0";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmPrincipal_Load);
            this.Shown += new System.EventHandler(this.frmPrincipal_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmPrincipal_KeyDown);
            this.toolStripContainer2.ContentPanel.ResumeLayout(false);
            this.toolStripContainer2.ContentPanel.PerformLayout();
            this.toolStripContainer2.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer2.TopToolStripPanel.PerformLayout();
            this.toolStripContainer2.ResumeLayout(false);
            this.toolStripContainer2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel)).EndInit();
            this.kryptonPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerTela.Panel1)).EndInit();
            this.splitContainerTela.Panel1.ResumeLayout(false);
            this.splitContainerTela.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerTela.Panel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerTela)).EndInit();
            this.splitContainerTela.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.headerMenuLateral.Panel)).EndInit();
            this.headerMenuLateral.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.headerMenuLateral)).EndInit();
            this.headerMenuLateral.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSeparator1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.ToolStripContainer toolStripContainer2;
        public ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem visualToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem office2010Azul;
        private System.Windows.Forms.ToolStripMenuItem office2010Prata;
        private System.Windows.Forms.ToolStripMenuItem office2010Preto;
        public ComponentFactory.Krypton.Toolkit.KryptonManager kryptonManager1;
        private System.Windows.Forms.ToolStripMenuItem ajudaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem localDeInstalaçãoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem horaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsEscritor;
        private System.Windows.Forms.ToolStripMenuItem tsImportarXmlEscritor;
        private System.Windows.Forms.ToolStripMenuItem tsConfiguracao;
        public ComponentFactory.Krypton.Toolkit.KryptonSplitContainer splitContainerTela;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel2;
        private ToolStripStatusLabel lblVersao;
        private ToolStripStatusLabel lblStatus;
        private ToolStripStatusLabel lblUsuario;
        private ToolStripStatusLabel lblEmpresa;
        private ToolTip toolTip1;
        private ImageList imageList1;
        private Timer timer1;
        private ComponentFactory.Krypton.Toolkit.KryptonSeparator kryptonSeparator1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnMenu;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnFerramentas;
        public ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup headerMenuLateral;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnMinimiza;
        private TreeView tvMenu;
        private TreeView tvFerramentas;
        private PictureBox pictureBox1;
        private ToolStripMenuItem btnAtualizacao;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripStatusLabel lbldtVencCert;
    }
}



