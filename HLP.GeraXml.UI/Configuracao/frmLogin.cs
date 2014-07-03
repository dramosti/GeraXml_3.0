using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using HLP.GeraXml.Comum.Static;
using HLP.GeraXml.bel;
using HLP.GeraXml.dao.NFe;
using HLP.GeraXml.dao.ADO;
using HLP.GeraXml.Comum;
using HLP.GeraXml.dao;

namespace HLP.GeraXml.UI.Configuracao
{
    public partial class frmLogin : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        bool Login = false;

        public frmLogin()
        {
            InitializeComponent();
        }


        private void btnEntrar_Click(object sender, EventArgs e)
        {
            try
            {
                errorProvider1.Dispose();
                if (txtUsuario.Text.Equals("")) { errorProvider1.SetError(txtUsuario, "Campo Obrigatório"); }
                else if (txtSenha.Text.Equals("")) { errorProvider1.SetError(txtSenha, "Campo Obrigatório"); }
                else
                {
                    HlpDbFuncoesGeral.NovaConexao();
                    Acesso.CarregaDadosBanco();
                    string sUser = txtUsuario.Text.ToUpper().Trim().PadLeft(10, '0');
                    string sSenha = txtSenha.Text.ToUpper().Trim();

                    int iCountUser = Convert.ToInt32(HlpDbFuncoes.qrySeekValue("ACESSO", "count(acesso.CD_OPERADO)", "acesso.CD_OPERADO = '" + sUser + "'"));

                    string sTipoUsuario = "";

                    if (iCountUser > 0)
                    {

                        StringBuilder sQuery = new StringBuilder();
                        if (Acesso.NM_RAMO != Acesso.BancoDados.TRANSPORTE)
                        {

                            sQuery.Append("select acesso.tp_operado, acesso.cd_senha, COALESCE(acesso.st_altera_dados_nfe,'S') st_altera_dados_nfe ");
                            if (HlpDbFuncoes.fExisteCampo("ST_ACESSA_CONFIG_NFE", "ACESSO"))
                            {
                                sQuery.Append(", COALESCE(ACESSO.ST_ACESSA_CONFIG_NFE,'N')ST_ACESSA_CONFIG_NFE ");
                            }
                            else
                            {
                                sQuery.Append(", 'N' ST_ACESSA_CONFIG_NFE ");
                            }

                            sQuery.Append("from acesso ");
                            sQuery.Append("where acesso.cd_senha = '" + belCriptografia.Encripta(sSenha) + "' ");
                            sQuery.Append("and acesso.CD_OPERADO = '" + sUser + "'");
                        }
                        else
                        {
                            sQuery.Append("select acesso.tp_operado, acesso.cd_senha ");
                            sQuery.Append("from acesso ");
                            sQuery.Append("where acesso.cd_senha = '" + belCriptografia.Encripta(sSenha) + "' ");
                            sQuery.Append("and acesso.CD_OPERADO = '" + sUser + "'");
                        }

                        DataTable dt = HlpDbFuncoes.qrySeekRet(sQuery.ToString());

                        foreach (DataRow dr in dt.Rows)
                        {
                            sTipoUsuario = dr["tp_operado"].ToString();
                            if (Acesso.NM_RAMO != Acesso.BancoDados.TRANSPORTE)
                            {
                                Acesso.bALTERA_DADOS = (dr["st_altera_dados_nfe"].ToString().Equals("N") ? false : true);
                                Acesso.bALTER_CONFIG = (dr["ST_ACESSA_CONFIG_NFE"].ToString().Equals("S") ? true : false);
                            }
                        }

                        if (sTipoUsuario != "")
                        {
                            Login = true;
                            Acesso.NM_CONFIG = Acesso.NM_CONFIG_TEMP;
                            Acesso.USER_LOGADO = true;
                            Acesso.CarregaAcesso();
                            CarregaVariavesSistema();
                            Acesso.NM_USER = sUser;
                            this.Close();
                             
                        }
                        else
                        {
                            errorProvider1.SetError(txtSenha, "Senha Incorreta");
                            txtSenha.Focus();
                            txtSenha.Text = "";
                        }
                    }
                    else
                    {
                        errorProvider1.SetError(txtUsuario, "Usuário Incorreto");
                        txtUsuario.Focus();
                        txtUsuario.Text = "";
                    }
                }

              
            }
            catch (Exception ex)
            {
                new HLPexception(ex);
            }
        }



        private void CarregaVariavesSistema()
        {
            //if (Acesso.NM_RAMO != HLP.GeraXml.Comum.Static.Acesso.BancoDados.TRANSPORTE)
            {
                Acesso.NM_EMPRESA = HlpDbFuncoes.qrySeekValue("control", "cd_conteud", "cd_nivel = '0016'");
            }
            //else
            //{
            //    Acesso.NM_EMPRESA = HlpDbFuncoes.qrySeekValue("EMPRESA", "NM_GUERRA", "cd_empresa = '" + Acesso.CD_EMPRESA + "'");
            //}

            DataTable dt = new DataTable();
            if (Acesso.NM_RAMO != HLP.GeraXml.Comum.Static.Acesso.BancoDados.TRANSPORTE)
            {
                dt = HlpDbFuncoes.qrySeekRet(
                                         "EMPRESA left join uf on (uf.cd_uf = empresa.cd_ufnor)",
                                         "empresa.cd_ufnor,empresa.nm_cidnor, nm_empresa, coalesce(empresa.st_ambiente_nfse,'2')tpAmb_Servico, coalesce(empresa.st_ambiente, '2') tpAmb, UF.nr_ufnfe, cd_cgc",
                                         "cd_empresa = '" + Acesso.CD_EMPRESA + "'");
            }
            else
            {
                dt = HlpDbFuncoes.qrySeekRet(
                                         "EMPRESA",
                                         "nm_empresa,empresa.nm_cidnor,cd_cgc,cd_ufnor,coalesce(empresa.st_ambiente, '2') tpAmb ",
                                         "cd_empresa = '" + Acesso.CD_EMPRESA + "'");
            }
            if (Util.VerificaSeEstaNaHLP())
            //if(false)
            {
                Acesso.TP_AMB = 2;
                Acesso.TP_AMB_SERV = 2;
            }
            else
            {
                if (dt.Rows[0]["tpAmb"].ToString().Equals("0"))
                {
                    throw new Exception("Empresa não habilitada para emitir NFe, verifique o cadastro de empresa!");
                }
                Acesso.TP_AMB = Convert.ToInt16(dt.Rows[0]["tpAmb"].ToString());
                try
                {Acesso.TP_AMB_SERV = Convert.ToInt16(dt.Rows[0]["tpAmb_Servico"].ToString());}catch (Exception){}
            }
            Acesso.NM_RAZAOSOCIAL = dt.Rows[0]["nm_empresa"].ToString();
            Acesso.CNPJ_EMPRESA = dt.Rows[0]["cd_cgc"].ToString();
            Acesso.CIDADE_EMPRESA = dt.Rows[0]["nm_cidnor"].ToString().ToUpper();

            if (Acesso.NM_RAMO != HLP.GeraXml.Comum.Static.Acesso.BancoDados.TRANSPORTE)
            {
                Acesso.cUF = Convert.ToInt16(dt.Rows[0]["nr_ufnfe"].ToString());
                Acesso.xUF = dt.Rows[0]["cd_ufnor"].ToString();
                Acesso.TP_AMB_SERV = Convert.ToInt16(dt.Rows[0]["tpAmb_Servico"].ToString());
            }
            else
            {
                belUF objUf = new belUF();
                objUf.SiglaUF = dt.Rows[0]["cd_ufnor"].ToString();
                Acesso.cUF = Convert.ToInt32(objUf.CUF);
                Acesso.xUF = objUf.SiglaUF;
            }
            Acesso.bAGRUPA_ITENS_NFE = daoRegras.VerificaSeAgrupaItensNFe();
            Acesso.bAGRUPA_ITENS_NFSE = daoRegras.VerificaSeAgrupaItensNFeServico();
            daoEmailContador.VerificaEmailContador();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void frmLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (!Login && !String.IsNullOrEmpty(Acesso.NM_CONFIG))
                {
                    Acesso.NM_CONFIG_TEMP = Acesso.NM_CONFIG;
                    HlpDbFuncoesGeral.NovaConexao();
                    Acesso.CarregaDadosBanco();
                }
            }
            catch (Exception ex)
            {
                new HLPexception(ex);
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

    }
}