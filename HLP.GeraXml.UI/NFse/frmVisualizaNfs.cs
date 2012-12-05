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
using ComponentFactory.Krypton.Toolkit;
using HLP.GeraXml.UI.Configuracao;

namespace HLP.GeraXml.UI.NFse
{
    public partial class frmVisualizaNfs : FormPadraoVisualizacao
    {
        public tcLoteRps objLoteRpsAlter = null;
        tcLoteRps objLoteRps = null;

        public frmVisualizaNfs(tcLoteRps objLoteRps)
        {
            InitializeComponent();
            listErros.ListBox.MouseDoubleClick += new MouseEventHandler(listErros_MouseDoubleClick);
            this.objLoteRps = objLoteRps;
            CriaObjAlter();
            bsNotas.DataSource = this.objLoteRpsAlter.Rps;
            ValidaNotas();
            PopulaForm();
            VerificaCampos();
        }


        #region Metodos

        private void CriaObjAlter()
        {
            try
            {

                tcLoteRps obj = new tcLoteRps();
                obj.Rps = new List<TcRps>();

                obj.NumeroLote = this.objLoteRps.NumeroLote;
                obj.Cnpj = this.objLoteRps.Cnpj;
                obj.InscricaoMunicipal = this.objLoteRps.InscricaoMunicipal;
                obj.QuantidadeRps = this.objLoteRps.QuantidadeRps;



                for (int i = 0; i < this.objLoteRps.Rps.Count; i++)
                {
                    TcRps objTcTcRps = new TcRps();
                    #region Identificacao
                    objTcTcRps.InfRps = new TcInfRps();
                    objTcTcRps.InfRps.DataEmissao = this.objLoteRps.Rps[i].InfRps.DataEmissao;
                    objTcTcRps.InfRps.NaturezaOperacao = this.objLoteRps.Rps[i].InfRps.NaturezaOperacao;
                    objTcTcRps.InfRps.RegimeEspecialTributacao = this.objLoteRps.Rps[i].InfRps.RegimeEspecialTributacao;
                    objTcTcRps.InfRps.OptanteSimplesNacional = this.objLoteRps.Rps[i].InfRps.OptanteSimplesNacional;
                    objTcTcRps.InfRps.IncentivadorCultural = this.objLoteRps.Rps[i].InfRps.IncentivadorCultural;
                    objTcTcRps.InfRps.Status = this.objLoteRps.Rps[i].InfRps.Status;


                    objTcTcRps.InfRps.IdentificacaoRps = new tcIdentificacaoRps();
                    objTcTcRps.InfRps.IdentificacaoRps.Numero = this.objLoteRps.Rps[i].InfRps.IdentificacaoRps.Numero;
                    objTcTcRps.InfRps.IdentificacaoRps.Serie = this.objLoteRps.Rps[i].InfRps.IdentificacaoRps.Serie;
                    objTcTcRps.InfRps.IdentificacaoRps.Tipo = this.objLoteRps.Rps[i].InfRps.IdentificacaoRps.Tipo;
                    objTcTcRps.InfRps.IdentificacaoRps.Nfseq = this.objLoteRps.Rps[i].InfRps.IdentificacaoRps.Nfseq;



                    if (this.objLoteRps.Rps[i].InfRps.RpsSubstituido != null)
                    {
                        objTcTcRps.InfRps.RpsSubstituido = new tcIdentificacaoRps();
                        objTcTcRps.InfRps.RpsSubstituido.Numero = this.objLoteRps.Rps[i].InfRps.RpsSubstituido.Numero;
                        objTcTcRps.InfRps.RpsSubstituido.Serie = this.objLoteRps.Rps[i].InfRps.RpsSubstituido.Serie;
                        objTcTcRps.InfRps.RpsSubstituido.Tipo = this.objLoteRps.Rps[i].InfRps.RpsSubstituido.Tipo;
                    }
                    #endregion

                    #region Serviço
                    objTcTcRps.InfRps.Servico = new TcDadosServico();
                    objTcTcRps.InfRps.Servico.Valores = new TcValores();

                    objTcTcRps.InfRps.Servico.Valores.ValorServicos = this.objLoteRps.Rps[i].InfRps.Servico.Valores.ValorServicos;
                    objTcTcRps.InfRps.Servico.Valores.ValorDeducoes = this.objLoteRps.Rps[i].InfRps.Servico.Valores.ValorDeducoes;
                    objTcTcRps.InfRps.Servico.Valores.ValorCsll = this.objLoteRps.Rps[i].InfRps.Servico.Valores.ValorCsll;
                    objTcTcRps.InfRps.Servico.Valores.ValorPis = this.objLoteRps.Rps[i].InfRps.Servico.Valores.ValorPis;
                    objTcTcRps.InfRps.Servico.Valores.ValorCofins = this.objLoteRps.Rps[i].InfRps.Servico.Valores.ValorCofins;
                    objTcTcRps.InfRps.Servico.Valores.IssRetido = this.objLoteRps.Rps[i].InfRps.Servico.Valores.IssRetido;
                    objTcTcRps.InfRps.Servico.Valores.ValorInss = this.objLoteRps.Rps[i].InfRps.Servico.Valores.ValorInss;
                    objTcTcRps.InfRps.Servico.Valores.ValorIr = this.objLoteRps.Rps[i].InfRps.Servico.Valores.ValorIr;
                    objTcTcRps.InfRps.Servico.Valores.ValorIss = this.objLoteRps.Rps[i].InfRps.Servico.Valores.ValorIss;
                    objTcTcRps.InfRps.Servico.Valores.OutrasRetencoes = this.objLoteRps.Rps[i].InfRps.Servico.Valores.OutrasRetencoes;
                    objTcTcRps.InfRps.Servico.Valores.BaseCalculo = this.objLoteRps.Rps[i].InfRps.Servico.Valores.BaseCalculo;
                    objTcTcRps.InfRps.Servico.Valores.Aliquota = this.objLoteRps.Rps[i].InfRps.Servico.Valores.Aliquota;
                    objTcTcRps.InfRps.Servico.Valores.ValorLiquidoNfse = this.objLoteRps.Rps[i].InfRps.Servico.Valores.ValorLiquidoNfse;
                    objTcTcRps.InfRps.Servico.Valores.ValorIssRetido = this.objLoteRps.Rps[i].InfRps.Servico.Valores.ValorIssRetido;
                    objTcTcRps.InfRps.Servico.Valores.DescontoCondicionado = this.objLoteRps.Rps[i].InfRps.Servico.Valores.DescontoCondicionado;
                    objTcTcRps.InfRps.Servico.Valores.DescontoIncondicionado = this.objLoteRps.Rps[i].InfRps.Servico.Valores.DescontoIncondicionado;

                    objTcTcRps.InfRps.Servico.ItemListaServico = this.objLoteRps.Rps[i].InfRps.Servico.ItemListaServico;
                    objTcTcRps.InfRps.Servico.CodigoTributacaoMunicipio = this.objLoteRps.Rps[i].InfRps.Servico.CodigoTributacaoMunicipio;
                    objTcTcRps.InfRps.Servico.CodigoCnae = this.objLoteRps.Rps[i].InfRps.Servico.CodigoCnae;
                    objTcTcRps.InfRps.Servico.CodigoMunicipio = this.objLoteRps.Rps[i].InfRps.Servico.CodigoMunicipio;
                    objTcTcRps.InfRps.Servico.Discriminacao = this.objLoteRps.Rps[i].InfRps.Servico.Discriminacao;

                    #endregion

                    #region Dados Adicionais
                    objTcTcRps.InfRps.Prestador = new tcIdentificacaoPrestador();
                    objTcTcRps.InfRps.Prestador.Cnpj = this.objLoteRps.Rps[i].InfRps.Prestador.Cnpj;

                    objTcTcRps.InfRps.Prestador.InscricaoMunicipal = this.objLoteRps.Rps[i].InfRps.Prestador.InscricaoMunicipal;

                    objTcTcRps.InfRps.Tomador = new tcDadosTomador();

                    objTcTcRps.InfRps.Tomador.IdentificacaoTomador = new tcIdentificacaoTomador();
                    if (this.objLoteRps.Rps[i].InfRps.Tomador.IdentificacaoTomador.CpfCnpj != null)
                    {
                        if (this.objLoteRps.Rps[i].InfRps.Tomador.IdentificacaoTomador.CpfCnpj.Cnpj != "")
                        {
                            objTcTcRps.InfRps.Tomador.IdentificacaoTomador.CpfCnpj = new TcCpfCnpj();
                            objTcTcRps.InfRps.Tomador.IdentificacaoTomador.CpfCnpj.Cnpj = this.objLoteRps.Rps[i].InfRps.Tomador.IdentificacaoTomador.CpfCnpj.Cnpj;
                        }
                        else if (this.objLoteRps.Rps[i].InfRps.Tomador.IdentificacaoTomador.CpfCnpj.Cpf != "")
                        {
                            objTcTcRps.InfRps.Tomador.IdentificacaoTomador.CpfCnpj = new TcCpfCnpj();
                            objTcTcRps.InfRps.Tomador.IdentificacaoTomador.CpfCnpj.Cpf = this.objLoteRps.Rps[i].InfRps.Tomador.IdentificacaoTomador.CpfCnpj.Cpf;
                        }
                    }
                    objTcTcRps.InfRps.Tomador.IdentificacaoTomador.InscricaoMunicipal = this.objLoteRps.Rps[i].InfRps.Tomador.IdentificacaoTomador.InscricaoMunicipal;
                    objTcTcRps.InfRps.Tomador.RazaoSocial = this.objLoteRps.Rps[i].InfRps.Tomador.RazaoSocial;

                    if (this.objLoteRps.Rps[i].InfRps.Tomador.Endereco != null)
                    {
                        objTcTcRps.InfRps.Tomador.Endereco = new TcEndereco();

                        objTcTcRps.InfRps.Tomador.Endereco.Endereco = this.objLoteRps.Rps[i].InfRps.Tomador.Endereco.Endereco;
                        objTcTcRps.InfRps.Tomador.Endereco.Numero = this.objLoteRps.Rps[i].InfRps.Tomador.Endereco.Numero;
                        objTcTcRps.InfRps.Tomador.Endereco.Complemento = this.objLoteRps.Rps[i].InfRps.Tomador.Endereco.Complemento;
                        objTcTcRps.InfRps.Tomador.Endereco.Bairro = this.objLoteRps.Rps[i].InfRps.Tomador.Endereco.Bairro;
                        objTcTcRps.InfRps.Tomador.Endereco.Uf = this.objLoteRps.Rps[i].InfRps.Tomador.Endereco.Uf;
                        objTcTcRps.InfRps.Tomador.Endereco.CodigoMunicipio = this.objLoteRps.Rps[i].InfRps.Tomador.Endereco.CodigoMunicipio;
                        objTcTcRps.InfRps.Tomador.Endereco.Cep = this.objLoteRps.Rps[i].InfRps.Tomador.Endereco.Cep;
                    }

                    if (this.objLoteRps.Rps[i].InfRps.Tomador.Contato != null)
                    {
                        objTcTcRps.InfRps.Tomador.Contato = new TcContato();

                        objTcTcRps.InfRps.Tomador.Contato.Telefone = this.objLoteRps.Rps[i].InfRps.Tomador.Contato.Telefone;
                        objTcTcRps.InfRps.Tomador.Contato.Email = this.objLoteRps.Rps[i].InfRps.Tomador.Contato.Email;
                    }


                    if (this.objLoteRps.Rps[i].InfRps.IntermediarioServico != null)
                    {
                        objTcTcRps.InfRps.IntermediarioServico = new TcIdentificacaoIntermediarioServico();
                        objTcTcRps.InfRps.IntermediarioServico.RazaoSocial = this.objLoteRps.Rps[i].InfRps.IntermediarioServico.RazaoSocial;
                        objTcTcRps.InfRps.IntermediarioServico.InscricaoMunicipal = this.objLoteRps.Rps[i].InfRps.IntermediarioServico.InscricaoMunicipal;


                        if (this.objLoteRps.Rps[i].InfRps.IntermediarioServico.CpfCnpj != null)
                        {
                            if (this.objLoteRps.Rps[i].InfRps.IntermediarioServico.CpfCnpj.Cnpj != "")
                            {
                                objTcTcRps.InfRps.IntermediarioServico.CpfCnpj = new TcCpfCnpj();
                                objTcTcRps.InfRps.IntermediarioServico.CpfCnpj.Cnpj = this.objLoteRps.Rps[i].InfRps.IntermediarioServico.CpfCnpj.Cnpj;
                            }
                            else if (this.objLoteRps.Rps[i].InfRps.IntermediarioServico.CpfCnpj.Cpf != "")
                            {
                                objTcTcRps.InfRps.IntermediarioServico.CpfCnpj = new TcCpfCnpj();
                                objTcTcRps.InfRps.IntermediarioServico.CpfCnpj.Cpf = this.objLoteRps.Rps[i].InfRps.IntermediarioServico.CpfCnpj.Cpf;
                            }
                        }
                    }

                    if (this.objLoteRps.Rps[i].InfRps.ConstrucaoCivil != null)
                    {
                        objTcTcRps.InfRps.ConstrucaoCivil = new tcDadosConstrucaoCivil();
                        objTcTcRps.InfRps.ConstrucaoCivil.Art = this.objLoteRps.Rps[i].InfRps.ConstrucaoCivil.Art;
                        objTcTcRps.InfRps.ConstrucaoCivil.CodigoObra = this.objLoteRps.Rps[i].InfRps.ConstrucaoCivil.CodigoObra;
                    }

                    #endregion

                    obj.Rps.Add(objTcTcRps);

                }
                this.objLoteRpsAlter = obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void PopulaForm()
        {
            try
            {
                #region Identificacao

                txtNumLote.Text = this.objLoteRpsAlter.NumeroLote;
                mskCnpjLote.Text = this.objLoteRpsAlter.Cnpj;
                txtImLote.Text = this.objLoteRpsAlter.InscricaoMunicipal;
                txtQtdeRpsLote.Text = this.objLoteRpsAlter.QuantidadeRps.ToString();

                TcRps rps = (TcRps)bsNotas.Current;

                txtDataEmissao.Text = rps.InfRps.DataEmissao.ToString();
                cboNatOperacao.SelectedIndex = rps.InfRps.NaturezaOperacao - 1;
                cboRegTributacao.SelectedIndex = rps.InfRps.RegimeEspecialTributacao - 1;
                cboSimplesnacional.SelectedIndex = rps.InfRps.OptanteSimplesNacional - 1;
                cboInCultural.SelectedIndex = rps.InfRps.IncentivadorCultural - 1;
                cboStatus.SelectedIndex = rps.InfRps.Status - 1;

                //Inicio Group Identificacao Rps
                txtNumRps.Text = rps.InfRps.IdentificacaoRps.Numero.ToString();
                txtSerieRps.Text = rps.InfRps.IdentificacaoRps.Serie;
                cboTipoRps.SelectedIndex = rps.InfRps.IdentificacaoRps.Tipo - 1;

                //Inicio Group Rps Substituido
                if (rps.InfRps.RpsSubstituido != null)
                {
                    txtNumRpsSubs.Text = rps.InfRps.RpsSubstituido.Numero.ToString();
                    txtSerieRpsSubs.Text = rps.InfRps.RpsSubstituido.Serie.ToString();
                    cboTipoRpsSubs.SelectedIndex = rps.InfRps.RpsSubstituido.Tipo - 1;
                }

                #endregion

                #region Serviço

                nudValorServ.Text = rps.InfRps.Servico.Valores.ValorServicos.ToString();
                nudValorDeducao.Value = rps.InfRps.Servico.Valores.ValorDeducoes;
                nudValorCSLL.Value = rps.InfRps.Servico.Valores.ValorCsll;
                nudValorPIS.Value = rps.InfRps.Servico.Valores.ValorPis;
                nudValorCOFINS.Value = rps.InfRps.Servico.Valores.ValorCofins;
                nudValorInss.Value = rps.InfRps.Servico.Valores.ValorInss;
                nudValorIr.Value = rps.InfRps.Servico.Valores.ValorIr;
                nudValorISS.Value = rps.InfRps.Servico.Valores.ValorIss;
                nudOutrasRetencoes.Value = rps.InfRps.Servico.Valores.OutrasRetencoes;
                nudBaseCalc.Value = rps.InfRps.Servico.Valores.BaseCalculo;
                nudAliquota.Value = rps.InfRps.Servico.Valores.Aliquota;
                nudvalorNfse.Value = rps.InfRps.Servico.Valores.ValorLiquidoNfse;
                nudIssRetido.Value = rps.InfRps.Servico.Valores.ValorIssRetido;
                nudDescCond.Value = rps.InfRps.Servico.Valores.DescontoCondicionado;
                nudDescIncond.Value = rps.InfRps.Servico.Valores.DescontoIncondicionado;

                cboIssRetido.SelectedIndex = rps.InfRps.Servico.Valores.IssRetido - 1;
                //Inicio Group Serviço
                txtItemlServ.Text = rps.InfRps.Servico.ItemListaServico;
                txtCodTribMun.Text = rps.InfRps.Servico.CodigoTributacaoMunicipio;
                txtCodCnae.Text = rps.InfRps.Servico.CodigoCnae;
                txtMunPrestServ.Text = rps.InfRps.Servico.CodigoMunicipio;
                txtDiscriminacao.Text = rps.InfRps.Servico.Discriminacao;

                #endregion

                #region Dados Adicionais

                //Inicio Group Prestador
                mskPrestCnpj.Text = rps.InfRps.Prestador.Cnpj;
                txtIM.Text = rps.InfRps.Prestador.InscricaoMunicipal;


                //Inicio Group Tomador
                if (rps.InfRps.Tomador.IdentificacaoTomador.CpfCnpj != null)
                {
                    if (rps.InfRps.Tomador.IdentificacaoTomador.CpfCnpj.Cnpj != "")
                    {
                        mskCpfCnpjToma.Mask = "00,000,000/0000-00";
                        mskCpfCnpjToma.Text = rps.InfRps.Tomador.IdentificacaoTomador.CpfCnpj.Cnpj;
                        mskCpfCnpjToma._Regex = Expressoes.ER4;
                    }
                    else if (rps.InfRps.Tomador.IdentificacaoTomador.CpfCnpj.Cpf != "")
                    {
                        mskCpfCnpjToma.Mask = "000,000,000-00";
                        mskCpfCnpjToma.Text = rps.InfRps.Tomador.IdentificacaoTomador.CpfCnpj.Cpf;
                        mskCpfCnpjToma._Regex = Expressoes.ER7;
                    }
                }
                txtImToma.Text = (rps.InfRps.Tomador.IdentificacaoTomador.InscricaoMunicipal.ToUpper().Equals("ISENTO") ? "" : rps.InfRps.Tomador.IdentificacaoTomador.InscricaoMunicipal);
                txtRazaoToma.Text = rps.InfRps.Tomador.RazaoSocial;
                if (rps.InfRps.Tomador.Endereco != null)
                {
                    txtEndToma.Text = rps.InfRps.Tomador.Endereco.Endereco;
                    txtNumtoma.Text = rps.InfRps.Tomador.Endereco.Numero;
                    txtCompleToma.Text = rps.InfRps.Tomador.Endereco.Complemento;
                    txtBairroToma.Text = rps.InfRps.Tomador.Endereco.Bairro;
                    txtEstadoToma.Text = rps.InfRps.Tomador.Endereco.Uf;
                    txtCidadeToma.Text = rps.InfRps.Tomador.Endereco.CodigoMunicipio.ToString();
                    mskCepToma.Text = rps.InfRps.Tomador.Endereco.Cep.ToString();
                }
                if (rps.InfRps.Tomador.Contato != null)
                {
                    mskFoneToma.Text = rps.InfRps.Tomador.Contato.Telefone.Replace(" ", "");
                    txtEmailToma.Text = rps.InfRps.Tomador.Contato.Email;
                }

                //Inicio Group Intermediario Serviço
                if (rps.InfRps.IntermediarioServico != null)
                {
                    txtRazaoInterServ.Text = rps.InfRps.IntermediarioServico.RazaoSocial;

                    if (rps.InfRps.IntermediarioServico.CpfCnpj != null)
                    {
                        if (rps.InfRps.IntermediarioServico.CpfCnpj.Cnpj != "")
                        {
                            mskCnpjInterServ.Mask = "00,000,000/0000-00";
                            mskCnpjInterServ.Text = rps.InfRps.IntermediarioServico.CpfCnpj.Cnpj;
                        }
                        else if (rps.InfRps.IntermediarioServico.CpfCnpj.Cpf != "")
                        {
                            mskCnpjInterServ.Mask = "000,000,000-00";
                            mskCnpjInterServ.Text = rps.InfRps.IntermediarioServico.CpfCnpj.Cnpj;
                        }
                    }
                    txtImInterServ.Text = rps.InfRps.IntermediarioServico.InscricaoMunicipal;
                }


                //Inicio Group Construçao Civil
                if (rps.InfRps.ConstrucaoCivil != null)
                {
                    txtCodObra.Text = rps.InfRps.ConstrucaoCivil.CodigoObra;
                    txtArt.Text = rps.InfRps.ConstrucaoCivil.Art;
                }


                #endregion

                lblNumNota.Text = "Número NFe-s: " + rps.InfRps.IdentificacaoRps.Numero.ToString();
            }
            catch (Exception ex)
            {
                new HLPexception(ex);
            }
        }

        private bool ValidaNotas()
        {
            bsNotas.MoveFirst();
            bool Retorno = true;
            belValidaCampos.LimpaErros();

            for (int i = 0; i < bsNotas.List.Count; i++)
            {
                TcRps rps = (TcRps)bsNotas.Current;
                PopulaForm();

                belValidaCampos.ValidarTodosDocumentos(flpLote.Controls, txtNumRps.Text);
                belValidaCampos.ValidarTodosDocumentos(flpIdentificacao.Controls, txtNumRps.Text);
                belValidaCampos.ValidarTodosDocumentos(flpIntermediario.Controls, txtNumRps.Text);
                if (Acesso.NM_EMPRESA.Equals("AENGE"))
                {
                    belValidaCampos.ValidarTodosDocumentos(flpConstrucao.Controls, txtNumRps.Text);
                }
                belValidaCampos.ValidarTodosDocumentos(flpValoresServico.Controls, txtNumRps.Text);
                belValidaCampos.ValidarTodosDocumentos(flpDadosServico.Controls, txtNumRps.Text);
                belValidaCampos.ValidarTodosDocumentos(flpPrestador.Controls, txtNumRps.Text);
                belValidaCampos.ValidarTodosDocumentos(flpTomador.Controls, txtNumRps.Text);

                bsNotas.MoveNext();
            }

            btnPrimeiro_Click(btnPrimeiro, new EventArgs());
            PopulaForm();


            listErros.DataSource = belValidaCampos.objListaTodosErros;
            lblErro.Text = belValidaCampos.iErros.ToString() + " Erro(s)";

            if (belValidaCampos.iErros > 0)
            {
                Retorno = false;
            }
            return Retorno;

        }
        private bool VerificaCampos()
        {
            try
            {
                TcRps rps = (TcRps)bsNotas.Current;
                int Erros = 0;
                bool Retorno = true;


                Erros += belValidaCampos.Validar(flpLote.Controls, false);
                Erros += belValidaCampos.Validar(flpIdentificacao.Controls, false);
                Erros += belValidaCampos.Validar(flpIntermediario.Controls, false);
                if (Acesso.NM_EMPRESA.Equals("AENGE"))
                {
                    Erros += belValidaCampos.Validar(flpConstrucao.Controls, false);
                }
                Erros += belValidaCampos.Validar(flpValoresServico.Controls, false);
                Erros += belValidaCampos.Validar(flpDadosServico.Controls, false);
                Erros += belValidaCampos.Validar(flpPrestador.Controls, false);
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

        private void SalvarAlteracao()
        {
            try
            {
                #region Identificacao


                TcRps rps = (TcRps)bsNotas.Current;

                rps.InfRps.DataEmissao = Convert.ToDateTime(txtDataEmissao.Text);
                rps.InfRps.NaturezaOperacao = cboNatOperacao.SelectedIndex + 1;
                rps.InfRps.RegimeEspecialTributacao = cboRegTributacao.SelectedIndex + 1;
                rps.InfRps.OptanteSimplesNacional = cboSimplesnacional.SelectedIndex + 1;
                rps.InfRps.IncentivadorCultural = cboInCultural.SelectedIndex + 1;
                rps.InfRps.Status = cboStatus.SelectedIndex + 1;

                //Inicio Group Identificacao Rps
                rps.InfRps.IdentificacaoRps.Numero = Convert.ToString(txtNumRps.Text);
                rps.InfRps.IdentificacaoRps.Serie = txtSerieRps.Text;
                rps.InfRps.IdentificacaoRps.Tipo = cboTipoRps.SelectedIndex + 1;

                //Inicio Group Rps Substituido
                if (txtNumRpsSubs.Text != "" && txtSerieRpsSubs.Text != "" && cboTipoRpsSubs.SelectedIndex != -1)
                {
                    rps.InfRps.RpsSubstituido = new tcIdentificacaoRps();
                    rps.InfRps.RpsSubstituido.Numero = Convert.ToString(txtNumRpsSubs.Text);
                    rps.InfRps.RpsSubstituido.Serie = txtSerieRpsSubs.Text;
                    rps.InfRps.RpsSubstituido.Tipo = cboTipoRpsSubs.SelectedIndex + 1;
                }



                #endregion

                #region Serviço

                rps.InfRps.Servico.Valores.ValorServicos = nudValorServ.Value;
                rps.InfRps.Servico.Valores.ValorDeducoes = nudValorDeducao.Value;
                rps.InfRps.Servico.Valores.ValorCsll = nudValorCSLL.Value;
                rps.InfRps.Servico.Valores.ValorPis = nudValorPIS.Value;
                rps.InfRps.Servico.Valores.ValorCofins = nudValorCOFINS.Value;
                rps.InfRps.Servico.Valores.IssRetido = cboIssRetido.SelectedIndex + 1;
                rps.InfRps.Servico.Valores.ValorInss = nudValorInss.Value;
                rps.InfRps.Servico.Valores.ValorIr = nudValorIr.Value;
                rps.InfRps.Servico.Valores.ValorIss = nudValorISS.Value;
                rps.InfRps.Servico.Valores.OutrasRetencoes = nudOutrasRetencoes.Value;
                rps.InfRps.Servico.Valores.BaseCalculo = nudBaseCalc.Value;
                rps.InfRps.Servico.Valores.Aliquota = nudAliquota.Value;
                rps.InfRps.Servico.Valores.ValorLiquidoNfse = nudvalorNfse.Value;
                rps.InfRps.Servico.Valores.ValorIssRetido = nudIssRetido.Value;
                rps.InfRps.Servico.Valores.DescontoCondicionado = nudDescCond.Value;
                rps.InfRps.Servico.Valores.DescontoIncondicionado = nudDescIncond.Value;

                //Inicio Group Serviço
                rps.InfRps.Servico.ItemListaServico = txtItemlServ.Text;
                rps.InfRps.Servico.CodigoTributacaoMunicipio = txtCodTribMun.Text;
                rps.InfRps.Servico.CodigoCnae = txtCodCnae.Text;
                rps.InfRps.Servico.CodigoMunicipio = txtMunPrestServ.Text;
                rps.InfRps.Servico.Discriminacao = txtDiscriminacao.Text;

                #endregion

                #region Dados Adicionais

                //Inicio Group Prestador
                rps.InfRps.Prestador.Cnpj = mskPrestCnpj.Text;
                rps.InfRps.Prestador.InscricaoMunicipal = txtIM.Text;


                //Inicio Group Tomador
               // if (mskCpfCnpjToma.Text != "" || txtImToma.Text != "")
                {
                    rps.InfRps.Tomador.IdentificacaoTomador = new tcIdentificacaoTomador();
                    rps.InfRps.Tomador.IdentificacaoTomador.CpfCnpj = new TcCpfCnpj();
                    if (mskCpfCnpjToma.Text.Length == 14)
                    {
                        rps.InfRps.Tomador.IdentificacaoTomador.CpfCnpj.Cnpj = mskCpfCnpjToma.Text;
                    }
                    else
                    {
                        rps.InfRps.Tomador.IdentificacaoTomador.CpfCnpj.Cpf = mskCpfCnpjToma.Text;
                    }
                    rps.InfRps.Tomador.IdentificacaoTomador.InscricaoMunicipal = txtImToma.Text;
                }
                rps.InfRps.Tomador.RazaoSocial = txtRazaoToma.Text;

                if (txtEndToma.Text != "" || txtNumtoma.Text != "" || txtCompleToma.Text != "" || txtBairroToma.Text != ""
                    || txtEstadoToma.Text != "" || txtCidadeToma.Text != "" || mskCepToma.Text != "")
                {
                    rps.InfRps.Tomador.Endereco = new TcEndereco();
                    rps.InfRps.Tomador.Endereco.Endereco = txtEndToma.Text;
                    rps.InfRps.Tomador.Endereco.Numero = txtNumtoma.Text;
                    rps.InfRps.Tomador.Endereco.Complemento = txtCompleToma.Text;
                    rps.InfRps.Tomador.Endereco.Bairro = txtBairroToma.Text;
                    rps.InfRps.Tomador.Endereco.Uf = txtEstadoToma.Text;
                    if (txtCidadeToma.Text != "")
                    {
                        rps.InfRps.Tomador.Endereco.CodigoMunicipio = Convert.ToInt32(txtCidadeToma.Text);
                    }
                    if (mskCepToma.Text != "")
                    {
                        rps.InfRps.Tomador.Endereco.Cep = mskCepToma.Text;
                    }
                }

                if (mskFoneToma.Text != "" || txtEmailToma.Text != "")
                {
                    rps.InfRps.Tomador.Contato = new TcContato();
                    rps.InfRps.Tomador.Contato.Telefone = mskFoneToma.Text.Replace("-", "").Replace("(", "").Replace(")", "");
                    rps.InfRps.Tomador.Contato.Email = txtEmailToma.Text;
                }

                //Inicio Group Intermediario Serviço

                if (txtRazaoInterServ.Text != "" || mskCnpjInterServ.Text != "" || txtImInterServ.Text != "")
                {
                    rps.InfRps.IntermediarioServico = new TcIdentificacaoIntermediarioServico();
                    rps.InfRps.IntermediarioServico.CpfCnpj = new TcCpfCnpj();
                    rps.InfRps.IntermediarioServico.RazaoSocial = txtRazaoInterServ.Text;
                    if (mskCnpjInterServ.Mask == "00,000,000/0000-00")
                    {
                        rps.InfRps.IntermediarioServico.CpfCnpj.Cnpj = mskCnpjInterServ.Text;
                    }
                    else if (mskCnpjInterServ.Mask == "000,000,000-00")
                    {
                        rps.InfRps.IntermediarioServico.CpfCnpj.Cnpj = mskCnpjInterServ.Text;
                    }
                    rps.InfRps.IntermediarioServico.InscricaoMunicipal = txtImInterServ.Text;
                }


                //Inicio Group Construçao Civil
                if (txtCodObra.Text != "" || txtArt.Text != "")
                {
                    rps.InfRps.ConstrucaoCivil = new tcDadosConstrucaoCivil();
                    rps.InfRps.ConstrucaoCivil.CodigoObra = txtCodObra.Text;
                    rps.InfRps.ConstrucaoCivil.Art = txtArt.Text;
                }
                else
                {
                    rps.InfRps.ConstrucaoCivil = new tcDadosConstrucaoCivil();
                }


                #endregion

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
                    CriaObjAlter();
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

                    int iposicao = bsNotas.IndexOf(((List<TcRps>)bsNotas.List).FirstOrDefault(c => c.InfRps.IdentificacaoRps.Numero == objerro.NumeroDocumento));
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

    }
}
