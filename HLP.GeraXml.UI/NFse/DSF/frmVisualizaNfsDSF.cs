using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HLP.GeraXml.Comum.Forms;
using HLP.GeraXml.bel.NFes.DSF;
using HLP.GeraXml.Comum;
using HLP.GeraXml.Comum.Static;
using ComponentFactory.Krypton.Toolkit;
using HLP.GeraXml.UI.Configuracao;

namespace HLP.GeraXml.UI.NFse.DSF
{
    public partial class frmVisualizaNfsDSF : FormPadraoVisualizacao
    {
        private ReqEnvioLoteRPS objLote;

        public frmVisualizaNfsDSF(ReqEnvioLoteRPS objLote)
        {
            InitializeComponent();
            this.objLote = objLote;

            listErros.ListBox.MouseDoubleClick += new MouseEventHandler(listErros_MouseDoubleClick);
            bsNotas.DataSource = this.objLote.lote.RPS;
            List<ListagemComboBox> objListOperacao = new List<ListagemComboBox>();
            List<ListagemComboBox> objListTributacao = new List<ListagemComboBox>();

            objListOperacao.Add(new ListagemComboBox { Valor = "A", Descr = "Sem Dedução" });
            objListOperacao.Add(new ListagemComboBox { Valor = "B", Descr = "Com Dedução/Materiais" });
            objListOperacao.Add(new ListagemComboBox { Valor = "C", Descr = "Imune/Isenta de ISSQN" });
            objListOperacao.Add(new ListagemComboBox { Valor = "D", Descr = "Devolução/Simples Remessa" });
            objListOperacao.Add(new ListagemComboBox { Valor = "J", Descr = "Intemediação" });
            cbxOperacao.DataSource = objListOperacao;
            cbxOperacao.DisplayMember = "Descr";
            cbxOperacao.ValueMember = "Valor";

            objListTributacao.Add(new ListagemComboBox { Valor = "C", Descr = "Isenta de ISS" });
            objListTributacao.Add(new ListagemComboBox { Valor = "E", Descr = "Não Incidência no Município" });
            objListTributacao.Add(new ListagemComboBox { Valor = "F", Descr = "Imune" });
            objListTributacao.Add(new ListagemComboBox { Valor = "K", Descr = "Exigibilidd Susp.Dec.J/Proc.A" });
            objListTributacao.Add(new ListagemComboBox { Valor = "N", Descr = "Não Tributável" });
            objListTributacao.Add(new ListagemComboBox { Valor = "T", Descr = "Tributável" });
            objListTributacao.Add(new ListagemComboBox { Valor = "G", Descr = "Tributável Fixo" });
            objListTributacao.Add(new ListagemComboBox { Valor = "H", Descr = "Tributável S.N." });
            objListTributacao.Add(new ListagemComboBox { Valor = "M", Descr = "Micro Empreendedor Individual (MEI)" });

            cbxTributacao.DataSource = objListTributacao;
            cbxTributacao.DisplayMember = "Descr";
            cbxTributacao.ValueMember = "Valor";

            ValidaNotas();
            PopulaForm();
            VerificaCampos();

        }

        #region Metodos
        private bool ValidaNotas()
        {
            bool Retorno = true;

            PopulaForm();

            belValidaCampos.LimpaErros();

            belValidaCampos.ValidarTodosDocumentos(flpCabecalho.Controls, txtNumeroRPS.Text);
            belValidaCampos.ValidarTodosDocumentos(flPrestador.Controls, txtNumeroRPS.Text);
            belValidaCampos.ValidarTodosDocumentos(flpTomador.Controls, txtNumeroRPS.Text);
            belValidaCampos.ValidarTodosDocumentos(flFiscal.Controls, txtNumeroRPS.Text);
            belValidaCampos.ValidarTodosDocumentos(flpValoresServico.Controls, txtNumeroRPS.Text);

            listErros.DataSource = belValidaCampos.objListaTodosErros;
            lblErro.Text = belValidaCampos.iErros.ToString() + " Erro(s)";

            if (belValidaCampos.iErros > 0)
            {
                Retorno = false;
            }

            return Retorno;
        }
        private void PopulaForm()
        {
            try
            {
                //Cabeçalho Lote
                txtCodCidade.Text = objLote.cabec.CodCidade;
                txtCPFCNPJRemetente.Text = objLote.cabec.CPFCNPJRemetente;
                txtRazaoSocialRemetente.Text = objLote.cabec.RazaoSocialRemetente;
                txtDtInicio.Text = objLote.cabec.dtInicio.ToShortDateString();
                txtDtFim.Text = objLote.cabec.dtFim.ToShortDateString();
                txtQtdRPS.Text = objLote.cabec.QtdRPS.ToString();

                nudValorTotalServicos.Value = objLote.cabec.ValorTotalServicos;
                nudValorTotalDeducoes.Value = objLote.cabec.ValorTotalDeducoes;

                LoteRPS rps = bsNotas.Current as LoteRPS;



                txtSerieRPS.Text = rps.SerieRPS;
                txtAssinatura.Text = rps.Assinatura.ToString();
                txtInscricaoMunicipalPrestador.Text = rps.InscricaoMunicipalPrestador;
                txtRazaoSocialPrestador.Text = rps.RazaoSocialPrestador;
                txtNumeroRPS.Text = rps.NumeroRPS;
                txtDataEmissaoRPS.Text = rps.DataEmissaoRPS.ToShortDateString();

                txtInscricaoMunicipalTomador.Text = rps.InscricaoMunicipalTomador;
                txtCPFCNPJTomador.Text = rps.CPFCNPJTomador;
                txtRazaoSocialTomador.Text = rps.RazaoSocialTomador;
                txtDocTomadorEstrangeiro.Text = rps.DocTomadorEstrangeiro;
                txtTipoLogradouroTomador.Text = rps.TipoLogradouroTomador;
                txtLogradouroTomador.Text = rps.LogradouroTomador;
                txtNumeroEnderecoTomador.Text = rps.NumeroEnderecoTomador;
                txtComplementoEnderecoTomador.Text = rps.ComplementoEnderecoTomador;
                txtTipoBairroTomador.Text = rps.TipoBairroTomador;
                txtBairroTomador.Text = rps.BairroTomador;
                txtCidadeTomador.Text = rps.CidadeTomador;
                txtCidadeTomadorDescricao.Text = rps.CidadeTomadorDescricao;
                txtCEPTomador.Text = rps.CEPTomador;
                txtEmailTomador.Text = rps.EmailTomador;
                txtCodigoAtividade.Text = rps.CodigoAtividade;
                nudAliquotaAtividade.Text = rps.AliquotaAtividade;

                cbxTipoRecolhimento.SelectedIndex = (rps.TipoRecolhimento == "A" ? 0 : 1);
                cbxOperacao.cbx.SelectedValue = rps.Operacao;
                cbxTributacao.cbx.SelectedValue = rps.Tributacao;


                txtMunicipioPrestacao.Text = rps.MunicipioPrestacao;
                txtMunicipioPrestacaoDescricao.Text = rps.MunicipioPrestacaoDescricao;
                nudValorPIS.Value = Convert.ToDecimal(rps.ValorPIS);
                nudValorCOFINS.Value = Convert.ToDecimal(rps.ValorCOFINS.Replace(".", ","));
                nudValorINSS.Value = Convert.ToDecimal(rps.ValorINSS);
                nudValorIR.Value = Convert.ToDecimal(rps.ValorIR);
                nudValorCSLL.Value = Convert.ToDecimal(rps.ValorCSLL);
                nudAliquotaPIS.Value = rps.AliquotaPIS;
                nudAliquotaCOFINS.Value = rps.AliquotaCOFINS;
                nudAliquotaINSS.Value = rps.AliquotaINSS;
                nudAliquotaIR.Value = rps.AliquotaIR;
                nudAliquotaCSLL.Value = rps.AliquotaCSLL;
                txtDescricaoRPS.Text = rps.DescricaoRPS;
                txtTelefonePrestador.Text = rps.TelefonePrestador;
                txtTelefoneTomador.Text = rps.TelefoneTomador;

                lblNumNota.Text = "Número RPS: " + rps.NumeroRPS.ToString();

                bsItens.DataSource = rps.Itens.Item;
                bsDeducoes.DataSource = rps.Deducoes.Deducao;
            }
            catch (Exception ex)
            {
                new HLPexception(ex);
            }
        }
        private bool VerificaCampos()
        {
            try
            {
                LoteRPS rps = bsNotas.Current as LoteRPS;
                int Erros = 0;
                bool Retorno = true;

                Erros += belValidaCampos.Validar(flpCabecalho.Controls, false);
                Erros += belValidaCampos.Validar(flPrestador.Controls, false);
                Erros += belValidaCampos.Validar(flpTomador.Controls, false);
                Erros += belValidaCampos.Validar(flFiscal.Controls, false);
                Erros += belValidaCampos.Validar(flpValoresServico.Controls, false);

                if (Erros > 0)
                {
                    Retorno = false;
                }
                return Retorno;
            }
            catch (Exception ex)
            {
                new HLPexception(ex);
                return false;
            }
        }
        private void SalvarAlteracao()
        {
            try
            {
                //Cabeçalho Lote
                objLote.cabec.CodCidade = txtCodCidade.Text;
                objLote.cabec.CPFCNPJRemetente = txtCPFCNPJRemetente.Text;
                objLote.cabec.RazaoSocialRemetente = txtRazaoSocialRemetente.Text;
                objLote.cabec.dtInicio = Convert.ToDateTime(txtDtInicio.Text);
                objLote.cabec.dtFim = Convert.ToDateTime(txtDtFim.Text);
                objLote.cabec.QtdRPS = Convert.ToInt32(txtQtdRPS.Text);
                objLote.cabec.ValorTotalServicos = nudValorTotalServicos.Value;
                objLote.cabec.ValorTotalDeducoes = nudValorTotalDeducoes.Value;

                LoteRPS rps = bsNotas.Current as LoteRPS;
                             
                rps.InscricaoMunicipalPrestador = txtInscricaoMunicipalPrestador.Text;
                rps.RazaoSocialPrestador = txtRazaoSocialPrestador.Text;
                rps.NumeroRPS = txtNumeroRPS.Text;
                rps.DataEmissaoRPS = Convert.ToDateTime(txtDataEmissaoRPS.Text);

                rps.InscricaoMunicipalTomador = txtInscricaoMunicipalTomador.Text;
                rps.CPFCNPJTomador = txtCPFCNPJTomador.Text;
                rps.RazaoSocialTomador = txtRazaoSocialTomador.Text;
                rps.DocTomadorEstrangeiro = txtDocTomadorEstrangeiro.Text;
                rps.TipoLogradouroTomador = txtTipoLogradouroTomador.Text;
                rps.LogradouroTomador = txtLogradouroTomador.Text;
                rps.NumeroEnderecoTomador = txtNumeroEnderecoTomador.Text;
                rps.ComplementoEnderecoTomador = txtComplementoEnderecoTomador.Text;
                rps.TipoBairroTomador = txtTipoBairroTomador.Text;
                rps.BairroTomador = txtBairroTomador.Text;
                rps.CidadeTomador = txtCidadeTomador.Text;
                rps.CidadeTomadorDescricao = txtCidadeTomadorDescricao.Text;
                rps.CEPTomador = txtCEPTomador.Text;
                rps.EmailTomador = txtEmailTomador.Text;
                rps.CodigoAtividade = txtCodigoAtividade.Text;
                rps.AliquotaAtividade = nudAliquotaAtividade.Text;

                rps.TipoRecolhimento = cbxTipoRecolhimento.SelectedIndex == 0 ? "A" : "R";
                rps.MunicipioPrestacao = txtMunicipioPrestacao.Text;
                rps.MunicipioPrestacaoDescricao = txtMunicipioPrestacaoDescricao.Text;
                rps.Operacao = cbxOperacao.cbx.SelectedValue.ToString();
                rps.Tributacao = cbxTributacao.cbx.SelectedValue.ToString();
                rps.ValorPIS = nudValorPIS.Text;
                rps.ValorCOFINS = nudValorCOFINS.Text;
                rps.ValorINSS = nudValorINSS.Text;
                rps.ValorIR = nudValorIR.Text;
                rps.ValorCSLL = nudValorCSLL.Text;
                rps.AliquotaPIS = Convert.ToDecimal(nudAliquotaPIS.Value);
                rps.AliquotaCOFINS = nudAliquotaCOFINS.Value;
                rps.AliquotaINSS = nudAliquotaINSS.Value;
                rps.AliquotaIR = nudAliquotaIR.Value;
                rps.AliquotaCSLL = nudAliquotaCSLL.Value;
                rps.DescricaoRPS = txtDescricaoRPS.Text;
                rps.TelefonePrestador = txtTelefonePrestador.Text;
                rps.TelefoneTomador = txtTelefoneTomador.Text;
                rps.Assinatura = belCarregaDadosRPS.GetAssinatura(rps);
                VerificaCampos();
            }
            catch (Exception ex)
            {
                new HLPexception(ex);
            }
        }
        private void ProcuraTabPage(Control controle)
        {
            if (controle.Parent != null)
            {
                if (controle.Parent.GetType() == typeof(TabPage))
                {
                    (controle.Parent.Parent as TabControl).SelectedTab = (controle.Parent as TabPage);
                }
                ProcuraTabPage(controle.Parent);
            }
        }
        #endregion

        #region Botoes
        public override void Atualizar()
        {
            if (Acesso.bALTERA_DADOS)
            {
                base.Atualizar();
            }
            else
            {
                if (KryptonMessageBox.Show(null, "Usuário não tem Acesso para Alterar dados da Nota Fiscal" +
                     Environment.NewLine +
                     Environment.NewLine +
                     "Deseja entrar com a Permissão de um Outro Usuário? ", Mensagens.MSG_Aviso,
                      MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    frmLogin objfrm = new frmLogin();
                    objfrm.ShowDialog();
                    if (Acesso.bALTERA_DADOS)
                    {
                        base.Atualizar();
                    }
                    else
                    {
                        KryptonMessageBox.Show(null, "Usuário também não tem Permissão Para Alterar Dados da Nota Fiscal", Mensagens.MSG_Aviso, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }
        public override void Salvar()
        {
            try
            {
                SalvarAlteracao();
                ValidaNotas();
                base.Salvar();
            }
            catch (Exception ex)
            {
                new HLPexception(ex);
            }

        }
        public override void Enviar()
        {
            try
            {
                if (ValidaNotas())
                {
                    base.Enviar();
                }
                else
                {
                    KryptonMessageBox.Show("Verifique Todos os Erros antes de Enviar as Notas!", Mensagens.MSG_Alerta, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            catch (Exception ex)
            {
                new HLPexception(ex);
            }
        }
        public override void Cancelar()
        {
            try
            {
                if (KryptonMessageBox.Show("Deseja Cancelar as Alterações Realizadas?", Mensagens.MSG_Confirmacao, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    base.Cancelar();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                new HLPexception(ex);
            }
        }
        public override void Sair()
        {
            base.Sair();
        }
        public override void Navegacao(object sender)
        {
            try
            {
                SalvarAlteracao();
                base.Navegacao(sender);
                PopulaForm();
                VerificaCampos();
            }
            catch (Exception ex)
            {
                new HLPexception(ex);
            }

        }
        #endregion

        private void listErros_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (listErros.SelectedValue != null)
                {
                    Control ctr = listErros.SelectedValue as Control;
                    belValidaCampos.ListaErros objerro = (belValidaCampos.ListaErros)listErros.SelectedItem;

                    int iposicao = bsNotas.IndexOf(((List<LoteRPS>)bsNotas.List).FirstOrDefault(c => c.NumeroRPS == objerro.NumeroDocumento));
                    bsNotas.Position = iposicao;
                    lblContagemNotas.Text = (bsNotas.Position + 1).ToString() + " de " + bsNotas.Count;
                    PopulaForm();
                    VerificaCampos();
                    ProcuraTabPage(ctr);
                    ctr.Focus();
                }

            }
            catch (Exception ex)
            {
                new HLPexception(ex);
            }

        }
        private void Configuracoes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((sender as AC.ExtendedRenderer.Navigator.KryptonTabControl).SelectedTab.Name == "tabErros")
            {
                SalvarAlteracao();
                ValidaNotas();
            }
        }

        private struct ListagemComboBox
        {
            public string Valor { get; set; }
            public string Descr { get; set; }
        }
    }
}
