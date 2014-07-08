using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using System.IO;
using HLP.GeraXml.bel;
using HLP.GeraXml.dao;
using System.Runtime.Serialization.Formatters.Soap;
using HLP.GeraXml.Comum.Componentes;
using HLP.GeraXml.Comum;
using HLP.GeraXml.Comum.Static;
using System.Xml.Serialization;

namespace HLP.GeraXml.UI.Configuracao
{
    public partial class frmConfiguracao : KryptonForm
    {
        belConfiguracao objbelConfiguracao = new belConfiguracao();
        daoConfiguracao objdaoConfig = new daoConfiguracao();
        public int Erros = 0;


        public frmConfiguracao()
        {
            InitializeComponent();
            if (Acesso.NM_RAMO != Acesso.BancoDados.TRANSPORTE)
            {
                txtPastaEnviados.Visible = false;
            }
        }
        private void frmConfiguracao_Load(object sender, EventArgs e)
        {
            try
            {
                ButtonSpecAny btnPastaPadrao = new ButtonSpecAny();
                btnPastaPadrao.UniqueName = "btnPastaPadrao";
                btnPastaPadrao.Image = HLP.GeraXml.UI.Properties.Resources.Pasta;
                btnPastaPadrao.Style = ComponentFactory.Krypton.Toolkit.PaletteButtonStyle.InputControl;
                btnPastaPadrao.Click += new System.EventHandler(btnPastas_Click);
                ButtonSpecAny btnPastaRelatorio = new ButtonSpecAny();
                btnPastaRelatorio.UniqueName = "btnPastaRelatorio";
                btnPastaRelatorio.Image = HLP.GeraXml.UI.Properties.Resources.Pasta;
                btnPastaRelatorio.Style = ComponentFactory.Krypton.Toolkit.PaletteButtonStyle.InputControl;
                btnPastaRelatorio.Click += new System.EventHandler(btnPastas_Click);
                ButtonSpecAny btnCaminhoLogo = new ButtonSpecAny();
                btnCaminhoLogo.Image = HLP.GeraXml.UI.Properties.Resources.Pasta;
                btnCaminhoLogo.UniqueName = "btnCaminhoLogo";
                btnCaminhoLogo.Style = ComponentFactory.Krypton.Toolkit.PaletteButtonStyle.InputControl;
                btnCaminhoLogo.Click += new System.EventHandler(btnPastas_Click);
                ButtonSpecAny btnCaminhoBanco = new ButtonSpecAny();
                btnCaminhoBanco.UniqueName = "btnCaminhoBanco";
                btnCaminhoBanco.Image = HLP.GeraXml.UI.Properties.Resources.Pasta;
                btnCaminhoBanco.Style = ComponentFactory.Krypton.Toolkit.PaletteButtonStyle.InputControl;
                btnCaminhoBanco.Click += new System.EventHandler(btnPastas_Click);
                ButtonSpecAny btnPastaPesquisar = new ButtonSpecAny();
                btnPastaPadrao.UniqueName = "btnPastaPesquisar";
                btnPastaPadrao.Image = HLP.GeraXml.UI.Properties.Resources.Pasta;
                btnPastaPadrao.Style = ComponentFactory.Krypton.Toolkit.PaletteButtonStyle.InputControl;
                btnPastaPadrao.Click += new System.EventHandler(btnPastas_Click);


                // txtCaminhoPadrao.txt.ReadOnly = true;
                txtCaminhoPadrao.txt.ButtonSpecs.Add(btnPastaPadrao);

                txtPastaEnviados.txt.ButtonSpecs.Add(btnPastaPadrao);

                //txtCaminhoPastaRelatorio.txt.ReadOnly = true;
                txtCaminhoPastaRelatorio.txt.ButtonSpecs.Add(btnPastaRelatorio);

                //txtCaminhoLogo.txt.ReadOnly = true;
                txtCaminhoLogo.txt.ButtonSpecs.Add(btnCaminhoLogo);

                //txtBancoDados.txt.ReadOnly = true;
                txtBancoDados.txt.ButtonSpecs.Add(btnCaminhoBanco);

                CarregarDados();

            }
            catch (Exception ex)
            {
                new HLPexception(ex);
            }
        }
        protected void btnPastas_Click(object sender, EventArgs e)
        {
            ButtonSpecAny btn = (ButtonSpecAny)sender;

            if (
                (btn.UniqueName.Equals("btnPastaPadrao")) ||
                (btn.UniqueName.Equals("btnPastaRelatorio"))||
                (btn.UniqueName.Equals("btnPastaPesquisar")))
            {
                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    switch (btn.UniqueName)
                    {
                        case "btnPastaPadrao": txtCaminhoPadrao.Text = folderBrowserDialog1.SelectedPath;
                            break;
                        case "btnPastaRelatorio": txtCaminhoPastaRelatorio.Text = folderBrowserDialog1.SelectedPath;
                            break;
                        case "btnPastaPesquisar": txtPastaEnviados.Text = folderBrowserDialog1.SelectedPath;
                            break;
                    }
                }
            }
            else
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    switch (btn.UniqueName)
                    {
                        case "btnCaminhoLogo": txtCaminhoLogo.Text = openFileDialog1.FileName.ToString();
                            break;
                        case "btnCaminhoBanco": txtBancoDados.Text = openFileDialog1.FileName.ToString();
                            break;
                    }
                }
            }
        }


        private void btnSair_Click(object sender, EventArgs e)
        {
            try
            {
                errorProvider1.Dispose();
                Erros = belValidaCampos.Validar(this.Controls, false);
                if (Erros == 0)
                {
                    SalvarXml();
                    KryptonMessageBox.Show(null, "Todas as Alterações foram Salvas", Mensagens.MSG_Aviso, MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Acesso.CarregaDadosBanco();

                    if (daoUtil.VerificaConexaoOk())
                    {
                        if (Acesso.USER_LOGADO)
                        {
                            Acesso.CarregaAcesso();
                            this.Close();
                        }
                        else
                        {
                            Application.Restart();
                        }
                    }
                    else
                    {
                        KryptonMessageBox.Show(null, "Configuração de Conexão com o Banco de Dados é inválida.", Mensagens.MSG_Aviso, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

            }
            catch (Exception ex)
            {
                new HLPexception(ex);
                if (KryptonMessageBox.Show(null, "Deseja Sair sem Salvar ?", Mensagens.MSG_Alerta, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                    this.Close();
            }

        }





        private void CarregarDados()
        {
            nudQtd_Vl_unitario.Value = 2;
            nupCasasQtdeProd.Value = 2;

            cbxTpEmiss.DisplayMember = "ds_descvalor";
            cbxTpEmiss.ValueMember = "ds_valor";
            cbxTpEmiss.DataSource = objdaoConfig.CarregaComboModoSistema();
            cbxTpEmiss.cbx.SelectedIndex = 0;

            cbxFormDanfe.cbx.SelectedIndex = 0;
            cbxFusoHorario.cbx.SelectedIndex = 2;

            if (File.Exists(Pastas.PASTA_XML_CONFIG + Acesso.NM_CONFIG_TEMP))
            {
                cbxGruposServico.DisplayMember = "ds_descvalor";
                cbxGruposServico.ValueMember = "ds_valor";
                cbxGruposSCAN.DisplayMember = cbxGruposServico.DisplayMember;
                cbxGruposSCAN.ValueMember = cbxGruposServico.ValueMember;

                cbxGruposServico.cbx.DataSource = objdaoConfig.populaComboGruposFat();
                cbxGruposSCAN.cbx.DataSource = objdaoConfig.populaComboGruposFat();
                cbxGruposSCAN.cbx.SelectedIndex = -1;
                cbxGruposServico.cbx.SelectedIndex = -1;

                XmlSerializer s = new XmlSerializer(typeof(belConfiguracao));
                Stream file = new FileStream(Pastas.PASTA_XML_CONFIG + Acesso.NM_CONFIG_TEMP,
                    FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite);

                objbelConfiguracao = new belConfiguracao();
                objbelConfiguracao = (belConfiguracao)s.Deserialize(file);
                file.Dispose();

                this.txtCaminhoPadrao.Text = objbelConfiguracao.CAMINHO_PADRAO;
                this.txtCaminhoPastaRelatorio.Text = objbelConfiguracao.CAMINHO_RELATORIO_ESPECIFICO;
                this.txtPastaEnviados.Text = objbelConfiguracao.CAMINHO_ESPECIFICO_ENVIADOS;
                this.txtBancoDados.Text = objbelConfiguracao.CAMINHO_BANCO_DADOS;
                this.txtCaminhoLogo.Text = objbelConfiguracao.LOGOTIPO;
                this.nupCasasQtdeProd.Value = Convert.ToDecimal(objbelConfiguracao.QTDE_CASAS_PRODUTOS);
                this.nudQtd_Vl_unitario.Value = Convert.ToDecimal(objbelConfiguracao.QTDE_CASAS_VL_UNIT);
                this.chkGravaNumNFseDup.Checked = Convert.ToBoolean(objbelConfiguracao.GRAVA_NUM_NF_DUPL);
                this.hlP_CheckBox1.Checked = Convert.ToBoolean(objbelConfiguracao.VISUALIZA_HORA_DANFE);
                this.ckbDataSaidaDanfe.Checked = Convert.ToBoolean(objbelConfiguracao.VISUALIZA_DATA_DANFE);
                this.ckbDanfeSimplificada.Checked = Convert.ToBoolean(objbelConfiguracao.USA_DANFE_SIMPLIFICADA);
                this.cbxFusoHorario.Text = objbelConfiguracao.FUSO;
                this.chkCodBarras.Checked = Convert.ToBoolean(objbelConfiguracao.COD_BARRAS_XML);
                this.chkTotCfop.Checked = Convert.ToBoolean(objbelConfiguracao.TOTALIZA_CFOP);
                this.txtServerDados.Text = objbelConfiguracao.NM_SERVIDOR;
                this.nudPorta.Text = objbelConfiguracao.PORTA;
                this.txtCodEmpresa.Text = objbelConfiguracao.CD_EMPRESA;
                this.chkDetalheProd.Checked = objbelConfiguracao.DS_DETALHE;
                this.chkNumNotaEntrada.Checked = objbelConfiguracao.IMPRIMI_NUM_NOTA_ENTRADA;
                this.chkNumPedidoVendaItens.Checked = objbelConfiguracao.IMPRIMI_NUM_PEDIDO_VENDA;
                this.chkVisualizaDadosNFe.Checked = objbelConfiguracao.VISUALIZA_DADOS_NFE;
                this.chkNumRevisaoItens.Checked = objbelConfiguracao.IMPRIMI_NUM_REVISAO;
                this.chkImprimeRetorno.Checked = objbelConfiguracao.IMPRIMI_RETORNO;
                this.ckbImprimiFaturaDanfe.Checked = objbelConfiguracao.IMPRIMI_FATURA;
                this.txtSenhaWebNFse.Text = objbelConfiguracao.SENHA_WEB_NFES;
                this.txtCodPrefeitura.Text = objbelConfiguracao.COD_PREFEITURA;

                this.ckbRequerSSL.Checked = Convert.ToBoolean(objbelConfiguracao.REQUER_SSL);
                this.chkTribMunicipio.Checked = Convert.ToBoolean(objbelConfiguracao.DESTACA_IMP_TRIB_MUN);
                if (cbxGruposServico.cbx.Items.Count > 0)
                {
                    if (!String.IsNullOrEmpty(objbelConfiguracao.GRUPO_SERVICO))
                    {
                        cbxGruposServico.SelectedValue = objbelConfiguracao.GRUPO_SERVICO;
                    }
                }
                if (cbxGruposSCAN.cbx.Items.Count > 0)
                {
                    if (!String.IsNullOrEmpty(objbelConfiguracao.GRUPO_SCAN))
                    {
                        cbxGruposSCAN.SelectedValue = objbelConfiguracao.GRUPO_SCAN;
                    }
                }
                this.cbxTransparencia.SelectedIndex = objbelConfiguracao.TRANSPARENCIA;
                this.cbxTpEmiss.cbx.SelectedValue = objbelConfiguracao.TP_EMIS.ToString();
                this.cbxFormDanfe.Text = objbelConfiguracao.TIPO_IMPRESSAO;
                this.hlP_TextBox1.Text = objbelConfiguracao.HOST_SERVIDOR;
                this.nudPortaHostEmail.Value = Convert.ToDecimal(objbelConfiguracao.PORTA_SERVIDOR);
                this.txtEmailRemetente.Text = objbelConfiguracao.EMAIL_REMETENTE;
                this.txtSenhaEmail.Text = objbelConfiguracao.SENHA_REMETENTE;
                this.ckbEmailAutomatico.Checked = Convert.ToBoolean(objbelConfiguracao.EMAIL_AUTOMATICO);

            }

        }

        private void SalvarXml()
        {
            try
            {
                objbelConfiguracao = new belConfiguracao();
                objbelConfiguracao.CAMINHO_PADRAO = this.txtCaminhoPadrao.Text.ToString().Trim();
                objbelConfiguracao.CAMINHO_RELATORIO_ESPECIFICO = this.txtCaminhoPastaRelatorio.Text;
                objbelConfiguracao.CAMINHO_ESPECIFICO_ENVIADOS = this.txtPastaEnviados.Text;
                objbelConfiguracao.CAMINHO_BANCO_DADOS = this.txtBancoDados.Text;
                objbelConfiguracao.LOGOTIPO = this.txtCaminhoLogo.Text;
                objbelConfiguracao.QTDE_CASAS_PRODUTOS = this.nupCasasQtdeProd.Value.ToString();
                objbelConfiguracao.QTDE_CASAS_VL_UNIT = this.nudQtd_Vl_unitario.Value.ToString();
                objbelConfiguracao.GRAVA_NUM_NF_DUPL = this.chkGravaNumNFseDup.Checked.ToString();
                objbelConfiguracao.VISUALIZA_HORA_DANFE = this.hlP_CheckBox1.Checked.ToString();
                objbelConfiguracao.VISUALIZA_DATA_DANFE = this.ckbDataSaidaDanfe.Checked.ToString();
                objbelConfiguracao.USA_DANFE_SIMPLIFICADA = this.ckbDanfeSimplificada.Checked.ToString();
                if (cbxFusoHorario.Text != "")
                {
                    objbelConfiguracao.FUSO = cbxFusoHorario.Text.ToString();
                }
                else
                {
                    objbelConfiguracao.FUSO = "-02:00";
                }

                if (cbxTransparencia.Text != "")
                {
                    objbelConfiguracao.TRANSPARENCIA = cbxTransparencia.SelectedIndex;
                }
                else
                {
                    objbelConfiguracao.TRANSPARENCIA = 0;
                }

                objbelConfiguracao.COD_BARRAS_XML = this.chkCodBarras.Checked.ToString();
                objbelConfiguracao.TOTALIZA_CFOP = this.chkTotCfop.Checked.ToString();
                objbelConfiguracao.NM_SERVIDOR = this.txtServerDados.Text;
                objbelConfiguracao.PORTA = this.nudPorta.Text.Trim() == "0" ? "3050" : this.nudPorta.Text.Trim();
                objbelConfiguracao.CD_EMPRESA = this.txtCodEmpresa.Text;

                objbelConfiguracao.REQUER_SSL = this.ckbRequerSSL.Checked.ToString();
                objbelConfiguracao.DESTACA_IMP_TRIB_MUN = this.chkTribMunicipio.Checked.ToString();
                objbelConfiguracao.IMPRIMI_NUM_NOTA_ENTRADA = chkNumNotaEntrada.Checked;
                objbelConfiguracao.IMPRIMI_NUM_PEDIDO_VENDA = chkNumPedidoVendaItens.Checked;
                objbelConfiguracao.IMPRIMI_FATURA = ckbImprimiFaturaDanfe.Checked;
                objbelConfiguracao.IMPRIMI_NUM_REVISAO = chkNumRevisaoItens.Checked;
                objbelConfiguracao.IMPRIMI_RETORNO = chkImprimeRetorno.Checked;
                objbelConfiguracao.SENHA_WEB_NFES = this.txtSenhaWebNFse.Text;
                objbelConfiguracao.COD_PREFEITURA = this.txtCodPrefeitura.Text;
                objbelConfiguracao.VISUALIZA_DADOS_NFE = chkVisualizaDadosNFe.Checked;


                if (cbxGruposServico.cbx.Items.Count > 0)
                {
                    if (cbxGruposServico.SelectedValue != null)
                    {
                        objbelConfiguracao.GRUPO_SERVICO = cbxGruposServico.SelectedValue.ToString();
                    }
                }
                if (cbxGruposSCAN.cbx.Items.Count > 0)
                {
                    if (cbxGruposSCAN.SelectedValue != null)
                    {
                        objbelConfiguracao.GRUPO_SCAN = cbxGruposSCAN.SelectedValue.ToString();
                    }
                }
                objbelConfiguracao.DS_DETALHE = chkDetalheProd.Checked;
                objbelConfiguracao.TIPO_IMPRESSAO = cbxFormDanfe.Text.ToString();
                objbelConfiguracao.HOST_SERVIDOR = this.hlP_TextBox1.Text.Trim();
                objbelConfiguracao.PORTA_SERVIDOR = this.nudPortaHostEmail.Value.ToString().Trim();
                objbelConfiguracao.EMAIL_REMETENTE = this.txtEmailRemetente.Text.Trim();
                objbelConfiguracao.SENHA_REMETENTE = this.txtSenhaEmail.Text.Trim();
                objbelConfiguracao.EMAIL_AUTOMATICO = this.ckbEmailAutomatico.Checked.ToString();
                objbelConfiguracao.TP_EMIS = Convert.ToInt16(this.cbxTpEmiss.cbx.SelectedValue);

                try
                {
                    XmlSerializer s = new XmlSerializer(typeof(belConfiguracao));
                    FileStream f = File.Create(Pastas.PASTA_XML_CONFIG + Acesso.NM_CONFIG_TEMP);
                    s.Serialize(f, objbelConfiguracao);
                    f.Close();
                    f.Dispose();
                }
                catch (Exception)
                {
                    throw new Exception("Erro ao serializar a classe.");
                }
                // Cria Todas as Pastas.
                Acesso.CAMINHO_PADRAO = objbelConfiguracao.CAMINHO_PADRAO;
                Pastas.ENVIO.ToString();
                Pastas.ENVIADOS.ToString();
                Pastas.CONTINGENCIA.ToString();
                Pastas.CCe.ToString();
                Pastas.CBARRAS.ToString();
                Pastas.CANCELADOS.ToString();
                Pastas.RETORNO.ToString();
                Pastas.PROTOCOLOS.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



        private void frmConfiguracao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                btnSair_Click(sender, new EventArgs());
            }
        }



    }
}