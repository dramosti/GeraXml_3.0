using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HLP.GeraXml.Comum.Forms;
using HLP.GeraXml.bel.NFes;
using HLP.GeraXml.Comum;
using HLP.GeraXml.Comum.Static;
using HLP.GeraXml.bel.NFes.Susesu;
using HLP.GeraXml.UI.Configuracao;
using ComponentFactory.Krypton.Toolkit;
using System.Threading;

namespace HLP.GeraXml.UI.NFse.Susesu
{
    public partial class frmVisualizaNfsSusesu : FormPadraoVisualizacao
    {
        public belNFesSusesu objNfesAlter = null;
        belNFesSusesu objNfes = null;

        public frmVisualizaNfsSusesu(belNFesSusesu objNfes)
        {
            InitializeComponent();

            btnPrimeiro.Visible = false;
            btnProximo.Visible = false;
            btnUltimo.Visible = false;
            btnAnterior.Visible = false;
            lblContagemNotas.Visible = false;
            toolStripSeparator1.Visible = false;

            cbxLocExec.cbx.DataSource = dao.daoUtil.GetCidades();
            cbxLocExec.cbx.DisplayMember = "xMunicipio";
            cbxLocExec.cbx.ValueMember = "idMunicipio";
            cbxLocExec.cbx.SelectedIndexChanged += new EventHandler(cbx_SelectedIndexChanged);

            listErros.ListBox.MouseDoubleClick += new MouseEventHandler(listErros_MouseDoubleClick);
            this.objNfes = objNfes;
            objNfesAlter = objNfes;
            ValidaNota();
            PopulaForm();
            VerificaCampos();

        }

        void cbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtCodMunicipio.Text = cbxLocExec.cbx.SelectedValue.ToString();
        }


        private void listErros_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (listErros.SelectedValue != null)
                {
                    Control ctr = listErros.SelectedValue as Control;
                    belValidaCampos.ListaErros objerro = (belValidaCampos.ListaErros)listErros.SelectedItem;

                    ProcuraTabPage(ctr);
                    ctr.Focus();
                }

            }
            catch (Exception ex)
            {
                new HLPexception(ex);
            }

        }

        private bool ValidaNota()
        {
            bool Retorno = true;

            PopulaForm();

            belValidaCampos.LimpaErros();

            belValidaCampos.ValidarTodosDocumentos(flpIdentificacao.Controls, txtNumNota.Text);
            belValidaCampos.ValidarTodosDocumentos(flpValoresServico.Controls, txtNumNota.Text);
            belValidaCampos.ValidarTodosDocumentos(flpDadosServico.Controls, txtNumNota.Text);
            belValidaCampos.ValidarTodosDocumentos(flpTomador.Controls, txtNumNota.Text);

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
                txtNfseq.Text = objNfes.CD_NFSEQ;
                txtCodPrefeitura.Text = Acesso.COD_PREFEITURA.ToString();
                txtNumNota.Text = objNfes.NUMERO_NOTA.ToString();
                txtDtEmissao.Text = objNfes.DATA_EMISSAO;
                txtCodGeralAtv.Text = objNfes.CODIGO_GERAL_ATIVIDADE;
                txtCodAtv.Text = objNfes.CODIGO_ATIVIDADE;
                txtInformacoes.Text = objNfes.OUTRAS_INFORMACOES;

                txtCodMunicipio.Text = objNfes.COD_MUNICIPIO_EXECUCAO_SERVICO.ToString(); ;
                cbxLocExec.cbx.SelectedValue = objNfes.COD_MUNICIPIO_EXECUCAO_SERVICO;
                cbxStatusNFs.SelectedIndex = objNfes.STATUS_ISS_NOTA;
                txtValorTotalNfs.Text = objNfes.VALOR_TOTAL_NOTA.ToString();
                txtServicosPres.Text = objNfes.DESCRICAO_SERVICOS;

                nudValorIr.Value = Convert.ToDecimal(objNfes.IRRF);
                nudValorInss.Value = Convert.ToDecimal(objNfes.INSS);
                nudValorPIS.Value = Convert.ToDecimal(objNfes.PIS);
                nudValorCOFINS.Value = Convert.ToDecimal(objNfes.COFINS);
                nudContrSocial.Value = Convert.ToDecimal(objNfes.CONTRIBUICAO_SOCIAL);
                nudValLiquido.Value = Convert.ToDecimal(objNfes.VALOR_LIQUIDO);
                nudValDeducMat.Value = Convert.ToDecimal(objNfes.VALOR_DEDUCAO_MATERIAIS);
                nudAliquota.Value = Convert.ToDecimal(objNfes.ALIQUOTA);
                nudRegEspec.Value = objNfes.PORCENTAGEM_REGIME_ESPECIAL;
                nudValorISS.Value = Convert.ToDecimal(objNfes.sVALOR_ISS);

                mskCpfCnpjToma.Text = objNfes.TOMADOR_DOCUMENTO.ToString();
                txtRazaoToma.Text = objNfes.TOMADOR_RAZAO;
                cbxEstrangeiro.SelectedIndex = objNfes.TOMADOR_ESTRANGEIRO == "N" ? 0 : 1;
                txtIm.Text = objNfes.TOMADOR_INSCRICAO_MUNICIPAL;
                txtIe.Text = objNfes.TOMADOR_INSCRICAO_ESTADUAL;
                mskCepToma.Text = objNfes.TOMADOR_CEP;
                txtMunicipio.Text = objNfes.TOMADOR_MUNICIPIO.ToString();
                txtLogradouro.Text = objNfes.TOMADOR_LOGRADOURO;
                mskFone.Text = objNfes.TOMADOR_TELEFONE;
                txtEmail.Text = objNfes.TOMADOR_EMAIL;


                lblNumNota.Text = "Número NFe-s: " + objNfesAlter.NUMERO_NOTA.ToString();

            }
            catch (Exception ex)
            {
                new HLPexception(ex);
            }
        }

        private void PopulaObjeto()
        {
            try
            {
                Acesso.COD_PREFEITURA = txtCodPrefeitura.Text;
                objNfesAlter.NUMERO_NOTA = Convert.ToInt32(txtNumNota.Text);
                objNfesAlter.DATA_EMISSAO = txtDtEmissao.Text;
                objNfesAlter.CODIGO_GERAL_ATIVIDADE = txtCodGeralAtv.Text;
                objNfesAlter.CODIGO_ATIVIDADE = txtCodAtv.Text;
                objNfesAlter.OUTRAS_INFORMACOES = txtInformacoes.Text;

                objNfesAlter.COD_MUNICIPIO_EXECUCAO_SERVICO = Convert.ToInt32(txtCodMunicipio.Text);
                objNfesAlter.LOCAL_EXECUCAO_SERVICO = cbxLocExec.cbx.Text.ToUpper();
                objNfesAlter.STATUS_ISS_NOTA = cbxStatusNFs.SelectedIndex;
                objNfesAlter.VALOR_TOTAL_NOTA = txtValorTotalNfs.Text;
                objNfesAlter.DESCRICAO_SERVICOS = txtServicosPres.Text;

                objNfesAlter.IRRF = nudValorIr.Value.ToString();
                objNfesAlter.INSS = nudValorInss.Value.ToString();
                objNfesAlter.PIS = nudValorPIS.Value.ToString();
                objNfesAlter.COFINS = nudValorCOFINS.Value.ToString();
                objNfesAlter.CONTRIBUICAO_SOCIAL = nudContrSocial.Value.ToString();
                objNfesAlter.VALOR_LIQUIDO = nudValLiquido.Value.ToString();
                objNfesAlter.VALOR_DEDUCAO_MATERIAIS = nudValDeducMat.Value.ToString();
                objNfesAlter.ALIQUOTA = nudAliquota.Value.ToString();
                objNfesAlter.PORCENTAGEM_REGIME_ESPECIAL = Convert.ToInt32(nudRegEspec.Value);

                objNfesAlter.TOMADOR_DOCUMENTO = mskCpfCnpjToma.Text;
                objNfesAlter.TOMADOR_RAZAO = txtRazaoToma.Text;
                objNfesAlter.TOMADOR_ESTRANGEIRO = cbxEstrangeiro.SelectedValue.Equals("0") ? "N" : "S";
                objNfesAlter.TOMADOR_INSCRICAO_MUNICIPAL = txtIm.Text;
                objNfesAlter.TOMADOR_INSCRICAO_ESTADUAL = txtIe.Text;
                objNfesAlter.TOMADOR_CEP = mskCepToma.Text;
                objNfesAlter.TOMADOR_MUNICIPIO = Convert.ToInt32(txtMunicipio.Text);
                objNfesAlter.TOMADOR_LOGRADOURO = txtLogradouro.Text;
                objNfesAlter.TOMADOR_TELEFONE = mskFone.Text;
                objNfesAlter.TOMADOR_EMAIL = txtEmail.Text;


                VerificaCampos();

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
                int Erros = 0;
                bool Retorno = true;


                Erros += belValidaCampos.Validar(flpIdentificacao.Controls, false);
                Erros += belValidaCampos.Validar(flpValoresServico.Controls, false);
                Erros += belValidaCampos.Validar(flpDadosServico.Controls, false);
                Erros += belValidaCampos.Validar(flpTomador.Controls, false);


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
                PopulaObjeto();
                ValidaNota();
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
                if (ValidaNota())
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
                    objNfesAlter = objNfes;
                    PopulaForm();
                    VerificaCampos();
                    base.Cancelar();
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




    }
}
