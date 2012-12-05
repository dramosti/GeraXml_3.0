using System;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using HLP.GeraXml.UI.Configuracao;
using HLP.GeraXml.Comum.Static;
using System.Deployment.Application;
using HLP.GeraXml.Comum;
using HLP.GeraXml.UI.CTe;
using HLP.GeraXml.bel;
using HLP.GeraXml.UI.NFe;
using HLP.GeraXml.UI.CCe;
using HLP.GeraXml.dao;
using HLP.GeraXml.UI.NFse;
using System.Threading;
using System.IO;
using System.Reflection;

namespace HLP.GeraXml.UI
{
    public partial class frmPrincipal : KryptonForm
    {
        TreeNode nodeCte = null;
        TreeNode nodeNfe = null;
        TreeNode nodeNfes = null;
        TreeNode nodeCCe = null;
        bool bLoad = true;

        Thread T;
        frmStatus frmStatusServico = null;


        public frmPrincipal()
        {
            InitializeComponent();

            SetVisualandBackColor(belRegedit.BuscaNomeSkin());
            nodeCte = (TreeNode)tvMenu.Nodes["nodeCte"].Clone();
            nodeNfe = (TreeNode)tvMenu.Nodes["nodeNfe"].Clone();
            nodeNfes = (TreeNode)tvMenu.Nodes["nodeNfes"].Clone();
            nodeCCe = (TreeNode)tvMenu.Nodes["nodeCce"].Clone();
        }
        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            try
            {
                CarregaTela();
            }
            catch (Exception ex)
            {
                new HLPexception(ex);
            }
        }



        #region Eventos Botoes

        private void VisualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ToolStripMenuItem menu = (ToolStripMenuItem)sender;
                SetVisualandBackColor(menu.Text);

                belRegedit.SalvarRegistro("Skin", "VisualGeraXml", menu.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public void SetVisualandBackColor(string sCor)
        {
            try
            {
                if (sCor.Equals("Office 2010 - Azul"))
                {
                    kryptonManager1.GlobalPaletteMode = PaletteModeManager.Office2010Blue;
                    office2010Azul.Checked = true;
                    office2010Prata.Checked = false;
                    office2010Preto.Checked = false;
                }
                else if (sCor.Equals("Office 2010 - Prata"))
                {
                    kryptonManager1.GlobalPaletteMode = PaletteModeManager.Office2010Silver;
                    office2010Azul.Checked = false;
                    office2010Prata.Checked = true;
                    office2010Preto.Checked = false;
                }
                else if (sCor.Equals("Office 2010 - Preto"))
                {
                    kryptonManager1.GlobalPaletteMode = PaletteModeManager.Office2010Black;
                    office2010Azul.Checked = false;
                    office2010Prata.Checked = false;
                    office2010Preto.Checked = true;
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        private int _cacheWidth;
        private void btnMinimiza_Click(object sender, EventArgs e)
        {
            if (bLoad)
            {
                splitContainerTela.FixedPanel = FixedPanel.None;
                bLoad = false;
            }
            splitContainerTela.SuspendLayout();
            if (splitContainerTela.FixedPanel == FixedPanel.None)
            {
                splitContainerTela.FixedPanel = FixedPanel.Panel1;
                splitContainerTela.IsSplitterFixed = true;

                _cacheWidth = headerMenuLateral.Width;
                int newWidth = headerMenuLateral.PreferredSize.Height;

                splitContainerTela.Panel1MinSize = newWidth;
                splitContainerTela.SplitterDistance = newWidth;

                headerMenuLateral.HeaderPositionPrimary = VisualOrientation.Right;
                headerMenuLateral.ButtonSpecs[0].Edge = PaletteRelativeEdgeAlign.Near;
                for (int i = 0; i < splitContainerTela.Panel1.Controls.Count; i++)
                {
                    if (splitContainerTela.Panel1.Controls[i].GetType() == typeof(KryptonButton) || splitContainerTela.Panel1.Controls[i].GetType() == typeof(KryptonSeparator))
                    {
                        splitContainerTela.Panel1.Controls[i].Visible = false;
                    }
                    else if (splitContainerTela.Panel1.Controls[i].GetType() == typeof(KryptonTextBox))
                    {
                        splitContainerTela.Panel1.Controls[i].Visible = false;
                    }
                    else if (splitContainerTela.Panel1.Controls[i].GetType() == typeof(KryptonHeader))
                    {
                        splitContainerTela.Panel1.Controls[i].Visible = false;
                    }
                }
            }
            else
            {
                splitContainerTela.FixedPanel = FixedPanel.None;
                splitContainerTela.IsSplitterFixed = false;
                splitContainerTela.Panel1MinSize = 25;
                splitContainerTela.SplitterDistance = _cacheWidth;

                headerMenuLateral.HeaderPositionPrimary = VisualOrientation.Top;
                headerMenuLateral.ButtonSpecs[0].Edge = PaletteRelativeEdgeAlign.Far;

                for (int i = 0; i < splitContainerTela.Panel1.Controls.Count; i++)
                {
                    if (splitContainerTela.Panel1.Controls[i].GetType() == typeof(KryptonButton) || splitContainerTela.Panel1.Controls[i].GetType() == typeof(KryptonSeparator))
                    {
                        splitContainerTela.Panel1.Controls[i].Visible = true;
                    }
                    else if (splitContainerTela.Panel1.Controls[i].GetType() == typeof(KryptonTextBox))
                    {
                        splitContainerTela.Panel1.Controls[i].Visible = true;
                    }
                    else if (splitContainerTela.Panel1.Controls[i].GetType() == typeof(KryptonHeader))
                    {
                        splitContainerTela.Panel1.Controls[i].Visible = true;
                    }
                }
            }
            splitContainerTela.ResumeLayout();
        }

        private void btnLateral_Click(object sender, EventArgs e)
        {
            KryptonButton btn = (KryptonButton)sender;
            string sTreeview = "";
            switch (btn.Name)
            {
                case "btnMenu": sTreeview = "tvMenu";
                    break;

                case "btnFerramentas": sTreeview = "tvFerramentas";
                    break;
            }
            foreach (Control ctr in headerMenuLateral.Panel.Controls)
            {
                if (ctr.GetType() == typeof(TreeView))
                {
                    if (ctr.Name == sTreeview)
                    {
                        ctr.Visible = true;
                        ctr.BringToFront();
                        headerMenuLateral.Text = btn.Text;
                    }
                    else
                    {
                        ctr.Visible = false;
                    }
                }
            }
        }

        #endregion


        #region Metodos

        private void CarregaTela()
        {

            lblVersao.Text = "Versão " + Assembly.GetEntryAssembly().GetName().Version;

            Byte[] bimagem = Util.CarregaImagem(Acesso.LOGOTIPO);
            if (bimagem != null)
            {
                pictureBox1.Image = Util.byteArrayToImage(bimagem);
            }
            else
            {
                pictureBox1.Image = HLP.GeraXml.UI.Properties.Resources.xml2;
            }
            if (!Acesso.bESCRITA)
            {
                tsEscritor.Visible = false;
                this.Text = "GeraXml 3.0 - " + Acesso.NM_RAZAOSOCIAL;
                lblUsuario.Text = Acesso.NM_USER;
                Acesso.NM_FANTASIA = HLP.GeraXml.dao.ADO.HlpDbFuncoes.qrySeekValue("EMPRESA", "nm_guerra", "cd_empresa = '" + Acesso.CD_EMPRESA + "'");
                lblEmpresa.Text = Acesso.CD_EMPRESA + " - " + Acesso.NM_FANTASIA;



                tvMenu.Nodes.Clear();
                if (Acesso.NM_RAMO == Acesso.BancoDados.TRANSPORTE)
                {
                    tvMenu.Nodes.Add(nodeCte);
                }
                else
                {
                    tvMenu.Nodes.Add(nodeNfe);
                    tvMenu.Nodes.Add(nodeNfes);
                    tvMenu.Nodes.Add(nodeCCe);
                }
                tvMenu.ExpandAll();
            }
            else
            {
                Acesso.CarregaAcesso();
                this.Text = "GeraXml 3.0 - Escritor Fiscal";
                splitContainerTela.Panel1Collapsed = true;
                lblUsuario.Visible = false;
                lblEmpresa.Visible = false;
                lblStatus.Visible = false;
                tsEscritor.Visible = true;
            }
        }

        private void AbreForm()
        {
            try
            {
                if (tvMenu.SelectedNode != null)
                {
                    Boolean ok = false;
                    TreeNode nodeItem = tvMenu.SelectedNode;

                    if (nodeItem.Tag != null)
                    {
                        switch (nodeItem.Tag.ToString())
                        {
                            #region CTe

                            case "Status Cte":

                                timer1.Start();
                                T = new Thread(belStatusServico.VerificaStatusServicoCte);
                                T.Start();
                                frmStatusServico = new frmStatus();
                                frmStatusServico.ShowDialog();

                                KryptonMessageBox.Show(belStatusServico.Mensagem, Mensagens.CHeader, MessageBoxButtons.OK, MessageBoxIcon.Information);

                                break;

                            case "frmInutilizaFaixaCte":

                                if (Acesso.cert_CTe == null || !belStatusServico.ServicoOperando)
                                {
                                    timer1.Start();
                                    T = new Thread(belStatusServico.VerificaStatusServicoCteTela);
                                    T.Start();
                                    frmStatusServico = new frmStatus();
                                    frmStatusServico.ShowDialog();

                                    KryptonMessageBox.Show(belStatusServico.Mensagem, Mensagens.CHeader, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                if (belStatusServico.ServicoOperando && Acesso.TP_EMIS != 2)
                                {
                                    frmInutilizaFaixaCte objfrm = new frmInutilizaFaixaCte();
                                    objfrm.ShowDialog();
                                }
                                break;


                            case "frmGerarArquivosCte":
                                AbreFormCte();

                                break;
                            #endregion

                            #region NFe
                            case "Status Nfe":

                                timer1.Start();
                                T = new Thread(belStatusServico.VerificaStatusServicoNFe);
                                T.Start();
                                frmStatusServico = new frmStatus();
                                frmStatusServico.ShowDialog();

                                KryptonMessageBox.Show(belStatusServico.Mensagem, Mensagens.CHeader, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                break;

                            case "frmInutilizaFaixaNFe":
                                if (Acesso.cert_NFe == null || !belStatusServico.ServicoOperando)
                                {
                                    timer1.Start();
                                    T = new Thread(belStatusServico.VerificaStatusServicoNFeTela);
                                    T.Start();
                                    frmStatusServico = new frmStatus();
                                    frmStatusServico.ShowDialog();

                                    KryptonMessageBox.Show(belStatusServico.Mensagem, Mensagens.CHeader, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                if (belStatusServico.ServicoOperando && Acesso.TP_EMIS != 2)
                                {
                                    frmInutilizaFaixaNFe objfrm = new frmInutilizaFaixaNFe();
                                    objfrm.ShowDialog();
                                }
                                break;
                            case "frmProtocolosNfe":
                                frmProtocolosNfe objfrmProt = new frmProtocolosNfe();
                                objfrmProt.ShowDialog();
                                break;

                            case "frmGeraArquivoNFe":
                                AbreFormNfe();
                                break;
                            #endregion

                            #region NFe Servico

                            case "frmGeraArquivoNFes":
                                AbreFormNfes();
                                break;
                            #endregion

                            #region CCe
                            case "frmGeraArquivoCCe":
                                foreach (Control crt in this.splitContainerTela.Panel2.Controls)
                                {
                                    if (crt is frmGeraArquivoCCe)
                                    {
                                        crt.BringToFront();
                                        ((Form)crt).WindowState = FormWindowState.Normal;
                                        ok = true;
                                        break;
                                    }
                                }
                                if (!ok)
                                {
                                    timer1.Start();
                                    T = new Thread(belStatusServico.VerificaStatusServicoNFeTela);
                                    T.Start();
                                    frmStatusServico = new frmStatus();
                                    frmStatusServico.ShowDialog();

                                    KryptonMessageBox.Show(belStatusServico.Mensagem, Mensagens.CHeader, MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    if (Acesso.TP_EMIS == 1)
                                    {
                                        if (belStatusServico.ServicoOperando)
                                        {
                                            frmGeraArquivoCCe objfrmCCe = new frmGeraArquivoCCe();
                                            this.AddOwnedForm(objfrmCCe);
                                            objfrmCCe.MdiParent = this;
                                            this.splitContainerTela.Panel2.Controls.Add(objfrmCCe);
                                            objfrmCCe.WindowState = FormWindowState.Normal;
                                            objfrmCCe.Dock = DockStyle.Fill;
                                            objfrmCCe.Show();
                                            objfrmCCe.BringToFront();
                                            objfrmCCe.PesquisaCartas();
                                        }
                                    }
                                } break;
                            #endregion
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                new HLPexception(ex);
            }
            finally
            {
                timer1.Stop();
                frmStatusServico = null;
                if (T != null)
                {
                    if (T.IsAlive)
                    {
                        T.Abort();
                        T = null;
                    }
                }
            }
        }
        private void AbreFormCte()
        {
            bool ok = false;
            foreach (Control crt in this.splitContainerTela.Panel2.Controls)
            {
                if (crt is frmGerarArquivosCte)
                {
                    crt.BringToFront();
                    ((Form)crt).WindowState = FormWindowState.Normal;
                    ok = true;
                    break;
                }
            }
            if (!ok)
            {
                timer1.Start();
                T = new Thread(belStatusServico.VerificaStatusServicoCteTela);
                T.Start();
                frmStatusServico = new frmStatus();
                frmStatusServico.ShowDialog();

                KryptonMessageBox.Show(belStatusServico.Mensagem, Mensagens.CHeader, MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (belStatusServico.ServicoOperando)
                {
                    frmGerarArquivosCte objfrmCte = new frmGerarArquivosCte();
                    this.AddOwnedForm(objfrmCte);
                    objfrmCte.MdiParent = this;
                    this.splitContainerTela.Panel2.Controls.Add(objfrmCte);
                    objfrmCte.WindowState = FormWindowState.Normal;
                    objfrmCte.Dock = DockStyle.Fill;
                    objfrmCte.Show();
                    objfrmCte.BringToFront();
                    objfrmCte.PesquisaConhecimentos();
                }
            }
        }
        private void AbreFormNfe()
        {

            bool ok = false;
            foreach (Control crt in this.splitContainerTela.Panel2.Controls)
            {
                if (crt is frmGeraArquivoNFe)
                {
                    crt.BringToFront();
                    ((Form)crt).WindowState = FormWindowState.Normal;
                    ok = true;
                    break;
                }
            }
            if (!ok)
            {
                timer1.Start();
                T = new Thread(belStatusServico.VerificaStatusServicoNFeTela);
                T.Start();
                frmStatusServico = new frmStatus();
                frmStatusServico.ShowDialog();

                KryptonMessageBox.Show(belStatusServico.Mensagem, Mensagens.CHeader, MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (belStatusServico.ServicoOperando)
                {
                    frmGeraArquivoNFe objfrmNfe = new frmGeraArquivoNFe();
                    this.AddOwnedForm(objfrmNfe);
                    objfrmNfe.MdiParent = this;
                    this.splitContainerTela.Panel2.Controls.Add(objfrmNfe);
                    objfrmNfe.WindowState = FormWindowState.Normal;
                    objfrmNfe.Dock = DockStyle.Fill;
                    objfrmNfe.Show();
                    objfrmNfe.BringToFront();
                    objfrmNfe.PesquisaNotas();
                }
            }
            BuscaDtVencimentoCertificado();

        }
        private void BuscaDtVencimentoCertificado()
        {
            DateTime? dtVenciCert = null;
            if (Acesso.cert_CTe != null)
            {
                dtVenciCert = Acesso.cert_CTe.NotAfter;
            }
            else if (Acesso.cert_NFe != null)
            {
                dtVenciCert = Acesso.cert_NFe.NotAfter;
            }
            else if (Acesso.cert_NFs != null)
            {
                dtVenciCert = Acesso.cert_NFs.NotAfter;
            }
            if (dtVenciCert != null)
            {
                lbldtVencCert.Visible = true;
                lbldtVencCert.Text = "Certif. Digital Vence em: " + Convert.ToDateTime(dtVenciCert).ToShortDateString();
                if (DateTime.Today.AddDays(30) > Convert.ToDateTime(dtVenciCert))
                {
                    MessageBox.Show(null, "Solicite um novo certificado digital o mais rápido possível." +
                                    Environment.NewLine + "Data de Vencimento :" + Convert.ToDateTime(dtVenciCert).ToShortDateString(), "A V I S O",
                                     MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                lbldtVencCert.Visible = false;
                lbldtVencCert.Text = "";
            }
        }
        private void AbreFormNfes()
        {
            bool ok = false;
            if (Acesso.tipoWsNfse != Acesso.TP_WS_NFSE.NENHUM)
            {

                foreach (Control crt in this.splitContainerTela.Panel2.Controls)
                {
                    if (crt is frmGeraArquivoNFes)
                    {
                        crt.BringToFront();
                        ((Form)crt).WindowState = FormWindowState.Normal;
                        ok = true;
                        break;
                    }
                }
                if (!ok)
                {

                    timer1.Start();
                    T = new Thread(belStatusServico.VerificaStatusInternetNFs);
                    T.Start();
                    frmStatusServico = new frmStatus();
                    frmStatusServico.ShowDialog();

                    if (!belStatusServico.ServicoOperando)
                    {
                        KryptonMessageBox.Show(belStatusServico.Mensagem, Mensagens.CHeader, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    if (belStatusServico.ServicoOperando)
                    {
                        if (!(Acesso.tipoWsNfse == Acesso.TP_WS_NFSE.SUSESU))
                        {
                            belStatusServico.SelecionaCertificadoNFs();
                        }
                        frmGeraArquivoNFes objfrmNfes = new frmGeraArquivoNFes();
                        this.AddOwnedForm(objfrmNfes);
                        objfrmNfes.MdiParent = this;
                        this.splitContainerTela.Panel2.Controls.Add(objfrmNfes);
                        objfrmNfes.WindowState = FormWindowState.Normal;
                        objfrmNfes.Dock = DockStyle.Fill;
                        objfrmNfes.Show();
                        objfrmNfes.BringToFront();
                        objfrmNfes.PesquisaNotas();
                    }
                }
            }
            else
            {
                KryptonMessageBox.Show("Módulo de Nota fiscal de serviço não liberado para a Cidade de " + Acesso.CIDADE_EMPRESA, Mensagens.CHeader, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        private void AbreFormConfig()
        {
            bool ok = false;
            foreach (Control crt in this.splitContainerTela.Panel2.Controls)
            {
                if (crt.GetType().BaseType == typeof(KryptonForm))
                {
                    ((Form)crt).Close();
                }
            }
            foreach (Form frm in this.MdiChildren)
            {
                if (frm is frmLoginConfig)
                {
                    frm.BringToFront();
                    ok = true;
                }
            }
            if (!ok)
            {
                frmLoginConfig objfrm = new frmLoginConfig();
                objfrm.ShowDialog();
                frmPrincipal_Load(new object(), new EventArgs());
            }
        }
        private void AbreFormAbaConfig()
        {
            try
            {
                if (tvFerramentas.SelectedNode != null)
                {
                    TreeNode nodeItem = tvFerramentas.SelectedNode;
                    switch (nodeItem.Tag.ToString())
                    {
                        case "frmLoginConfig":
                            AbreFormConfig();
                            break;

                        case "frmSelecionaConfigs":
                            foreach (Control crt in this.splitContainerTela.Panel2.Controls)
                            {
                                if (crt.GetType().BaseType == typeof(KryptonForm))
                                {
                                    ((Form)crt).Close();
                                }
                            }
                            frmSelecionaConfigs objfrmConfig = new frmSelecionaConfigs();
                            objfrmConfig.ShowDialog();
                            if (objfrmConfig.ArquivoSelecionado)
                            {
                                if (!Acesso.bESCRITA)
                                {
                                    frmLogin objfrmLogin = new frmLogin();
                                    objfrmLogin.ShowDialog();
                                }
                                frmPrincipal_Load(new object(), new EventArgs());
                            }
                            break;

                        case "frmEmailContador":
                            if (Acesso.VerificaDadosEmail())
                            {
                                frmEmailContador2 objfrmEmail = new frmEmailContador2();
                                objfrmEmail.ShowDialog();
                            }
                            else
                            {
                                KryptonMessageBox.Show(null, "Campos para o envio de e-mail não estão preenchidos corretamente!", Mensagens.CHeader, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }

                            break;

                        case "Disponibilidade":
                            System.Diagnostics.Process.Start("http://www.nfe.fazenda.gov.br/portal/disponibilidade.aspx?versao=2.00&tipoConteudo=Skeuqr8PQBY=");

                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                new HLPexception(ex);
            }
        }

        #endregion


        #region Eventos

        private void tvMenu_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            AbreForm();
        }
        private void tvMenu_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    AbreForm();
                }
            }
            catch (Exception ex)
            {
                new HLPexception(ex);
            }
            finally
            {
                if (e.KeyCode == Keys.Enter)
                {
                    timer1.Stop();
                    frmStatusServico = null;
                    if (T != null)
                    {
                        if (T.IsAlive)
                        {
                            T.Abort();
                            T = null;
                        }
                    }
                }
            }

        }

        private void tvFerramentas_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            AbreFormAbaConfig();
        }
        private void tvFerramentas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AbreFormAbaConfig();
            }
        }

        private void localDeInstalaçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (KryptonMessageBox.Show(null, Application.StartupPath + Environment.NewLine + "Deseja abrir o local ?", Mensagens.CHeader, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                System.Diagnostics.Process.Start(Application.StartupPath);
            }
        }
        private void horaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KryptonMessageBox.Show(daoUtil.GetDateServidor().ToString(), Mensagens.CHeader, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void tsImportarXmlEscritor_Click(object sender, EventArgs e)
        {
            try
            {
                bool ok = false;
                foreach (Control crt in this.splitContainerTela.Panel2.Controls)
                {
                    if (crt is frmImportaEscritorNfe)
                    {
                        crt.BringToFront();
                        ((Form)crt).WindowState = FormWindowState.Normal;
                        ok = true;
                        break;
                    }
                }
                if (!ok)
                {
                    frmImportaEscritorNfe objfrmEscrita = new frmImportaEscritorNfe();
                    this.AddOwnedForm(objfrmEscrita);
                    objfrmEscrita.MdiParent = this;
                    this.splitContainerTela.Panel2.Controls.Add(objfrmEscrita);
                    objfrmEscrita.WindowState = FormWindowState.Normal;
                    objfrmEscrita.Dock = DockStyle.Fill;
                    objfrmEscrita.Show();
                    objfrmEscrita.BringToFront();

                }
            }
            catch (Exception ex)
            {
                new HLPexception(ex);
            }
        }
        private void tsConfiguracao_Click(object sender, EventArgs e)
        {
            try
            {
                bool ok = false;
                foreach (Control crt in this.splitContainerTela.Panel2.Controls)
                {
                    if (crt.GetType().BaseType == typeof(KryptonForm))
                    {
                        ((Form)crt).Close();
                    }
                }
                foreach (Form frm in this.MdiChildren)
                {
                    if (frm is frmLoginConfig)
                    {
                        frm.BringToFront();
                        ok = true;
                    }
                }
                if (!ok)
                {
                    frmLoginConfig objfrm = new frmLoginConfig();
                    objfrm.ShowDialog();
                    frmPrincipal_Load(sender, e);
                }
            }
            catch (Exception ex)
            {
                new HLPexception(ex);
            }
        }

        private void lblStatus_Click(object sender, EventArgs e)
        {
            ShowInformacao();
        }

        private void ShowInformacao()
        {
            try
            {
                frmInformacao frm = new frmInformacao();
                if ((!Acesso.bALTER_CONFIG) && (!Acesso.NM_USER.ToUpper().Contains("MASTER")))
                {
                    frm.flpTpEmiss.Enabled = false;
                }
                else
                {
                    frm.flpTpEmiss.Enabled = true;
                }

                frm.Show();
                frm.BringToFront();
            }
            catch (Exception ex)
            {
                new HLPexception(ex);
            }
        }

        private void frmPrincipal_KeyDown(object sender, KeyEventArgs e)
        {
            bool ok = false;
            try
            {
                if (Acesso.NM_RAMO != Acesso.BancoDados.TRANSPORTE)
                {
                    if (e.Modifiers == Keys.Control && e.KeyCode == Keys.N)
                    {
                        AbreFormNfe();
                        ok = true;
                    }
                    else if (e.Modifiers == Keys.Control && e.KeyCode == Keys.S)
                    {
                        AbreFormNfes();
                        ok = true;
                    }
                }
                else
                {
                    if (e.Modifiers == Keys.Control && e.KeyCode == Keys.T)
                    {
                        AbreFormCte();
                        ok = true;
                    }
                }
                if ((e.Modifiers == Keys.Control && e.KeyCode == Keys.F) && !Acesso.bESCRITA)
                {
                    AbreFormConfig();
                }
            }
            catch (Exception ex)
            {
                new HLPexception(ex);
            }
            finally
            {
                if (ok)
                {
                    timer1.Stop();
                    frmStatusServico = null;
                    if (T != null)
                    {
                        if (T.IsAlive)
                        {
                            T.Abort();
                            T = null;
                        }
                    }
                }
            }

        }



        private void tvMenu_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            e.Node.ImageIndex = 1;
            e.Node.SelectedImageIndex = 1;
        }
        private void tvMenu_BeforeCollapse(object sender, TreeViewCancelEventArgs e)
        {
            e.Node.ImageIndex = 0;
            e.Node.SelectedImageIndex = 0;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!T.IsAlive)
            {
                timer1.Stop();
                frmStatusServico.Close();
            }
        }

        #endregion

        private void frmPrincipal_Shown(object sender, EventArgs e)
        {
            frmEmailContador2 objfrmContador = new frmEmailContador2();
            if (objfrmContador.VerificaDiaEmailContador())
            {
                try
                {
                    string sArquivo = DateTime.Now.Date.ToString("MMyy") + ".zip";
                    DirectoryInfo info = new DirectoryInfo(Pastas.ENVIADOS + "\\Contador_xml\\");
                    if (!info.Exists)
                    {
                        info.Create();
                    }
                    string sCaminho = info.FullName + "\\" + sArquivo;
                    if (!File.Exists(sCaminho))
                    {
                        frmInformacao frm = new frmInformacao("Hoje é dia de enviar Email para o Contador." + Environment.NewLine + "Verifique suas Pendências.");
                        frm.ShowDialog();
                        objfrmContador.ShowDialog();
                    }
                }
                catch (Exception ex)
                {
                    new HLPexception(ex);
                }
            }
        }

        private void btnAtualizacao_Click(object sender, EventArgs e)
        {
            string sVersao = Assembly.GetEntryAssembly().GetName().Version.ToString();
            DirectoryInfo dinfo = new DirectoryInfo(@"G:\CSharp\Desenvolvimento");
            DirectoryInfo dinfo2 = new DirectoryInfo(@"J:\D6\Industri");

            string sUrl = "";

            if ((dinfo.Exists) && (dinfo.Exists))
            {
                sUrl = "http://192.168.9.33:8081/Suporte/DownloadGeraXml.aspx?Versao=";
            }
            else
            {
                sUrl = "hlpsistemas.no-ip.org:8081/Suporte/DownloadGeraXml.aspx?Versao=" + sVersao;
            }


            bool ok = false;

            foreach (Form frm in this.MdiChildren)
            {
                if (frm is frmDownloadVersao)
                {
                    frm.BringToFront();
                    ok = true;
                }
            }
            if (!ok)
            {
                frmDownloadVersao objfrm = new frmDownloadVersao(sUrl);
                this.AddOwnedForm(objfrm);
                objfrm.MdiParent = this;
                this.splitContainerTela.Panel2.Controls.Add(objfrm);
                objfrm.WindowState = FormWindowState.Normal;
                objfrm.Dock = DockStyle.Fill;
                objfrm.Show();
                objfrm.BringToFront();
            }
        }
    }
}
