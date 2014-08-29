using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using HLP.GeraXml.Comum.Static;
using HLP.GeraXml.Comum;
using HLP.GeraXml.bel.NFes;
using HLP.GeraXml.UI.NFe;
using HLP.GeraXml.bel.NFe;
using System.Linq;
using HLP.GeraXml.dao;
using HLP.GeraXml.bel;
using HLP.GeraXml.bel.NFes.Susesu;
using CrystalDecisions.CrystalReports.Engine;
using HLP.GeraXml.bel.NFes.DSF;
using HLP.GeraXml.UI.NFse.DSF;
using HLP.GeraXml.Comum.DataSet;
using System.IO;
using HLP.GeraXml.dao.NFe.Estrutura;

namespace HLP.GeraXml.UI.NFse
{
    public partial class frmGeraArquivoNFes : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        belPesquisaNotas belPesq = new belPesquisaNotas();
        belBuscaDados objbelBuscaDados = new belBuscaDados();

        private enum TipoFormVisualiza { frmNormal, frmSusesu };

        public bool bCD_NOTAFIS { get; set; }
        public bool bCD_NFSEQ { get; set; }

        public frmGeraArquivoNFes()
        {
            InitializeComponent();
            VerificaGeneratorLote();
            if (Acesso.tipoWsNfse == Acesso.TP_WS_NFSE.SUSESU)
            {
                btnBuscaRetorno.Visible = false;
                btnCancelamento.Visible = false;
            }
        }

        private void frmGeraArquivoNFes_Load(object sender, EventArgs e)
        {
            txtNfIni.txt.Validated += new EventHandler(txtNfIni_Validated);
            txtNfFim.txt.Validated += new EventHandler(txtNfFim_Validated);

            txtNfIni.txt.KeyPress += new KeyPressEventHandler(txt_KeyPress);
            txtNfFim.txt.KeyPress += new KeyPressEventHandler(txt_KeyPress);

            cboFiltro.cbx.SelectedIndexChanged += new EventHandler(cbx_SelectedIndexChanged);
            cboFiltro.SelectedIndex = 0;
            cboStatus.SelectedIndex = 1;
            dtpIni.Value = DateTime.Now;
            dtpFim.Value = DateTime.Now;

            if (Acesso.NM_EMPRESA.Equals("LORENZON"))
                sCD_NOTAFIS.HeaderText = "RPS";
            else
                sCD_NOTAFIS.HeaderText = "NF";
        }


        private void txtNfIni_Validated(object sender, EventArgs e)
        {
            txtNfIni.Text = txtNfIni.Text.PadLeft(6, '0');
            txtNfFim.Text = txtNfIni.Text;
        }
        private void txtNfFim_Validated(object sender, EventArgs e)
        {
            txtNfFim.Text = txtNfFim.Text.PadLeft(6, '0');
        }
        private void txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }
        private void cbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Por Data
            //Por Sequência
            //Por Cliente
            //NF
            //NFS-e
            txtCliente.Visible = false;
            if (cboFiltro.SelectedIndex == 0)
            {
                txtNfIni.Visible = false;
                txtNfFim.Visible = false;
                dtpIni.Visible = true;
                dtpFim.Visible = true;
            }
            else if (cboFiltro.SelectedIndex == 1 || cboFiltro.SelectedIndex == 3 || cboFiltro.SelectedIndex == 4)
            {
                txtNfIni.Visible = true;
                txtNfFim.Visible = true;
                dtpIni.Visible = false;
                dtpFim.Visible = false;
            }
            else if (cboFiltro.SelectedIndex == 2)
            {
                txtNfIni.Visible = false;
                txtNfFim.Visible = false;
                dtpIni.Visible = false;
                dtpFim.Visible = false;
                txtCliente._TamanhoTextBox = 200;
                txtCliente.Visible = true;
            }
        }

        private void dgvNF_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex == 0)
            {
                SendKeys.Send("{right}");
                SendKeys.Send("{left}");
            }
        }

        #region Metodos

        public void PesquisaNotas()
        {
            belPesquisaNotas.status st;
            if (cboStatus.cbx.Text.Equals("Enviados"))
            {
                st = belPesquisaNotas.status.Enviados;
            }
            else if (cboStatus.cbx.Text.Equals("Não Enviados"))
            {
                st = belPesquisaNotas.status.NaoEnviados;
            }
            else
            {
                st = belPesquisaNotas.status.Ambos;
            }
            //Por Data
            //Por Sequência
            //Por Cliente
            //NF
            //NFS-e
            string sValor1 = string.Empty;
            string sValor2 = string.Empty;
            belPesquisaNotas.Filtro filtro = belPesquisaNotas.Filtro.Data;
            if (cboFiltro.cbx.SelectedIndex == 0)
            {
                filtro = belPesquisaNotas.Filtro.Data;
                sValor1 = dtpIni.Value.ToString();
                sValor2 = dtpFim.Value.ToString();
            }
            else if (cboFiltro.cbx.SelectedIndex == 1)
            {
                filtro = belPesquisaNotas.Filtro.Sequencia;
                sValor1 = txtNfIni.Text;
                sValor2 = txtNfFim.Text;
            }
            else if (cboFiltro.cbx.SelectedIndex == 2)
            {
                filtro = belPesquisaNotas.Filtro.Cliente;
                sValor1 = txtCliente.Text;
            }
            else if (cboFiltro.cbx.SelectedIndex == 3)
            {
                filtro = belPesquisaNotas.Filtro.NF;
                sValor1 = txtNfIni.Text;
                sValor2 = txtNfFim.Text;
            }
            else if (cboFiltro.cbx.SelectedIndex == 4)
            {
                filtro = belPesquisaNotas.Filtro.NFSe;
                sValor1 = txtNfIni.Text;
                sValor2 = txtNfFim.Text;
            }



            belPesq = new belPesquisaNotas(st,
                                                           filtro,
                                                           sValor1,
                                                           sValor2, true);
            bsNotas.DataSource = belPesq.lResultPesquisa;

            ColoriGrid();
            lblTotalRegistros.Text = belPesq.lResultPesquisa.Count + " Registro(s) encontrado(s)";
        }

        private void ColoriGrid()
        {
            for (int i = 0; i < dgvNF.RowCount; i++)
            {

                if (Convert.ToBoolean(dgvNF["bCancelado", i].Value.ToString()) == true)
                {
                    dgvNF.Rows[i].DefaultCellStyle.BackColor = Color.Khaki;
                }
                else if (Convert.ToBoolean(dgvNF["bEnviado", i].Value.ToString()) == true)
                {
                    dgvNF.Rows[i].DefaultCellStyle.BackColor = Color.LightGreen;
                }
            }
        }

        private void VerificaGeneratorLote()
        {
            try
            {
                daoGenerator objdaoGenerator = new daoGenerator();
                if (!objdaoGenerator.VerificaExistenciaGenerator("GEN_LOTE_NFES"))
                {
                    objdaoGenerator.CreateGenerator("GEN_LOTE_NFES", 0);
                }
            }
            catch (Exception ex)
            {
                new HLPexception(ex);
            }
        }

        #endregion

        #region Botoes

        private void btnPesquisa_Click(object sender, EventArgs e)
        {
            try
            {
                PesquisaNotas();
            }
            catch (Exception ex)
            {
                new HLPexception(ex);
            }

        }

        private void btnEnvio_Click(object sender, EventArgs e)
        {

            frmStatusEnvioNfs objfrmStatus = null;

            try
            {
                if (belPesq.lResultPesquisa != null)
                {
                    List<belPesquisaNotas> objSelecionadas = belPesq.lResultPesquisa.Where(c => c.bSeleciona).ToList<belPesquisaNotas>();
                    List<belPesquisaNotas> objSelect = objSelecionadas.Where(c =>
                                                                       c.bEnviado == false &&
                                                                       c.bDenegada == false &&
                                                                       c.bCancelado == false).ToList<belPesquisaNotas>();

                    if (Acesso.tipoWsNfse == Acesso.TP_WS_NFSE.SUSESU && objSelect.Count > 1)
                    {
                        throw new Exception("Para Enviar, só é permitido selecionar uma Nota por vez!");
                    }

                    if (objSelect.Count() > 0)
                    {
                        if (objSelect.Where(C => C.sRECIBO_NF != "").Count() > 0)
                        {
                            foreach (belPesquisaNotas nota in objSelect.Where(C => C.sRECIBO_NF != ""))
                            {
                                throw new Exception("A Nota de Sequência " + nota.sCD_NFSEQ + " Já tem um retorno Salvo no Banco de Dados, tente Buscar Retorno");
                            }
                        }
                        if (objSelect.Where(c => c.sCD_NOTAFIS == "").Count() > 0)
                        {
                            HLP.GeraXml.bel.NFe.Estrutura.belNumeroNF objbelNumeracao = new HLP.GeraXml.bel.NFe.Estrutura.belNumeroNF(objSelect.Where(c => c.sCD_NOTAFIS == "").ToList());
                            frmGeraNumeracaoNFe objfrmGeraNumeracao = new frmGeraNumeracaoNFe(objbelNumeracao, true);
                            objfrmGeraNumeracao.ShowDialog();
                        }
                        if (Acesso.tipoWsNfse == Acesso.TP_WS_NFSE.DSF)
                        {
                            belCarregaDadosRPS objCarregaDados = new belCarregaDadosRPS(objSelect);
                            frmVisualizaNfsDSF objfrm = new frmVisualizaNfsDSF(objCarregaDados.objLoteEnvio);
                            objfrm.ShowDialog();
                            if (objfrm.Cancelado)
                            {
                                throw new Exception("Envio da(s) Nota(s) de serviço foi Cancelado.");
                            }
                            objCarregaDados.CriarXml();
                            belEnviarNFSeWS objEnvio = new belEnviarNFSeWS(objCarregaDados);
                            KryptonMessageBox.Show(objEnvio.Enviar(), Mensagens.MSG_Aviso, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else if (Acesso.tipoWsNfse == Acesso.TP_WS_NFSE.SUSESU) // arrumar o retorno das TELAS...
                        {
                            if (objSelect.Count > 1)
                            {
                                throw new Exception("Só é permitido selecionar uma Nota por vez!");
                            }

                            bel.NFes.Susesu.belNFesSusesu objNFes = new bel.NFes.Susesu.belNFesSusesu(objSelect.FirstOrDefault());
                            Susesu.frmVisualizaNfsSusesu objFrmVisualizaSusesu = new Susesu.frmVisualizaNfsSusesu(objNFes);
                            objFrmVisualizaSusesu.ShowDialog();
                            if (!objFrmVisualizaSusesu.Cancelado)
                            {
                                objNFes.TransmiteRPS();
                            }
                        }
                        else
                        {
                            bool isCancelado = false;
                            belLoteRps objbelLoteRps = new belLoteRps();
                            tcLoteRps objLoteRps = objbelLoteRps.BuscaDadosNFes(objSelect);
                            frmVisualizaNfs objFrmVisualiza = new frmVisualizaNfs(objLoteRps);
                            objFrmVisualiza.ShowDialog();
                            isCancelado = objFrmVisualiza.Cancelado;
                            if (isCancelado)
                            {
                                throw new Exception("Envio da(s) Nota(s) Cancelado");
                            }

                            objfrmStatus = new frmStatusEnvioNfs();
                            objfrmStatus.Show();
                            objfrmStatus.lblMsg.Text = "Montando Xml...";
                            objfrmStatus.lblMsg.Refresh();
                            objfrmStatus.Refresh();

                            belCriaXmlNFs objbelCriaXmlNFs = new belCriaXmlNFs();
                            if (Acesso.tipoWsNfse == Acesso.TP_WS_NFSE.GINFES)
                            {
                                objbelCriaXmlNFs.GerarArquivoXml(objFrmVisualiza.objLoteRpsAlter);
                            }
                            else
                            {
                                objbelCriaXmlNFs.GerarArquivoXml2(objFrmVisualiza.objLoteRpsAlter);
                            }

                            objfrmStatus.lblMsg.Text = "Enviando Lote para o Webservice...";
                            objfrmStatus.lblMsg.Refresh();

                            belRecepcao objBelRecepcao = new belRecepcao(objbelCriaXmlNFs.sXmlLote, objFrmVisualiza.objLoteRpsAlter);
                            if (objBelRecepcao.sMsgTransmissao != "")
                            {
                                throw new Exception(objBelRecepcao.sMsgTransmissao);
                            }

                            objfrmStatus.lblMsg.Text = "Gravando recibo na base de dados...";
                            objfrmStatus.lblMsg.Refresh();
                            objBelRecepcao.GravaRecibo(objBelRecepcao.Protocolo, objFrmVisualiza.objLoteRpsAlter);
                            objfrmStatus.Close();
                            KryptonMessageBox.Show(null, "Lote enviado com sucesso, aguarde aproximadamente 6 min. para buscar o Retorno.", Mensagens.CHeader, MessageBoxButtons.OK, MessageBoxIcon.Information);

                            //string sMsgErro = objBelRecepcao.BuscaRetorno(objFrmVisualiza.objLoteRpsAlter.Rps[0].InfRps.Prestador, objfrmStatus.lblMsg, objfrmStatus.progressBarStatus);

                            //if (objBelRecepcao.sCodigoRetorno.Equals("E4"))
                            //{
                            //    objfrmStatus.Close();
                            //    KryptonMessageBox.Show(null, sMsgErro + Environment.NewLine + Environment.NewLine + "IMPORTANTE: Tente Buscar Retorno da NFs-e, pois o serviço do WebService está demorando para responder. ", Mensagens.CHeader, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //}
                            //else if (objBelRecepcao.objListaNfseRetorno.Count > 0)
                            //{
                            //    objfrmStatus.lblMsg.Text = "Alterando Status da Nota...";
                            //    objfrmStatus.lblMsg.Refresh();
                            //    objBelRecepcao.AlteraStatusDaNota(objBelRecepcao.objListaNfseRetorno);
                            //    objfrmStatus.Close();
                            //    objBelRecepcao.VerificaNotasParaCancelar(objBelRecepcao.objListaNfseRetorno);

                            //    KryptonMessageBox.Show(null, objBelRecepcao.MontaMsgDeRetornoParaCliente(), Mensagens.CHeader, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //    //if (Convert.ToBoolean(Acesso.EMAIL_AUTOMATICO))
                            //    //{
                            //    //    //EnviaEmail(objBelRecepcao.objListaNfseRetorno);
                            //    //}
                            //}
                            //else
                            //{
                            //    objBelRecepcao.LimpaRecibo(objFrmVisualiza.objLoteRpsAlter);
                            //    objfrmStatus.Close();
                            //    KryptonMessageBox.Show(null, sMsgErro + Environment.NewLine, Mensagens.CHeader, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //}
                        }
                    }
                    else
                    {
                        KryptonMessageBox.Show("Nenhuma nota Válida foi Selecionada", Mensagens.MSG_Aviso, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                PesquisaNotas();
            }
            catch (Exception ex)
            {
                if (objfrmStatus != null)
                {
                    objfrmStatus.Close();
                }

                new HLPexception(ex);
                PesquisaNotas();
            }
        }

        private void btnBuscaRetorno_Click(object sender, EventArgs e)
        {
            frmStatusEnvioNfs objfrmStatus = null;
            try
            {
                if (belPesq.lResultPesquisa != null)
                {
                    List<belPesquisaNotas> objSelecionadas = belPesq.lResultPesquisa.Where(c => c.bSeleciona).ToList<belPesquisaNotas>();
                    List<belPesquisaNotas> objSelect = objSelecionadas.Where(c =>
                                                                       c.bDenegada == false &&
                                                                       c.bCancelado == false).ToList<belPesquisaNotas>();

                    if (objSelect.Count() == 0)
                    {
                        KryptonMessageBox.Show("Nenhuma nota Válida foi Selecionada", Mensagens.MSG_Aviso, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if (objSelect.Count == 1)
                    {
                        if (Acesso.tipoWsNfse == Acesso.TP_WS_NFSE.DSF)
                        {
                            belPesquisaNotas objPesquisa = new belPesquisaNotas(objSelect.FirstOrDefault().sRECIBO_NF);
                            bsNotas.DataSource = objPesquisa.lResultPesquisa;
                            belCarregaDadosRPS objCarregarNotasLote = new belCarregaDadosRPS(objPesquisa.lResultPesquisa, objPesquisa.lResultPesquisa.FirstOrDefault().sRECIBO_NF);
                            belEnviarNFSeWS objEnvio = new belEnviarNFSeWS(objCarregarNotasLote);
                            string sNumeroLote = objCarregarNotasLote.objLoteEnvio.cabec.NumeroLote.ToString();
                            KryptonMessageBox.Show(objEnvio.BuscaRetorno(sNumeroLote), Mensagens.MSG_Aviso, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            PesquisaNotas();
                        }
                        else
                        {
                            belPrestador objbelPrestador = new belPrestador();
                            belRecepcao objBelRecepcao = new belRecepcao();
                            objBelRecepcao.Protocolo = objBelRecepcao.BuscaNumProtocolo(objSelect[0].sCD_NFSEQ);

                            objfrmStatus = new frmStatusEnvioNfs();
                            objfrmStatus.Show();
                            objfrmStatus.Refresh();

                            string sMsgErro = objBelRecepcao.BuscaRetorno(objbelPrestador.RettcIdentificacaoPrestador(objSelect[0].sCD_NFSEQ), objfrmStatus.lblMsg, objfrmStatus.progressBarStatus);

                            if (objBelRecepcao.sCodigoRetorno.Equals("E4"))
                            {
                                objfrmStatus.Close();
                                KryptonMessageBox.Show(null, sMsgErro + Environment.NewLine + Environment.NewLine + "IMPORTANTE: Tente Buscar Retorno da NFs-e, pois o serviço do WebService está demorando para responder. ", Mensagens.CHeader, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else if (objBelRecepcao.objListaNfseRetorno.Count > 0)
                            {
                                objfrmStatus.lblMsg.Text = "Alterando Status da Nota...";
                                objfrmStatus.lblMsg.Refresh();
                                objBelRecepcao.AlteraStatusDaNota(objBelRecepcao.objListaNfseRetorno);
                                objfrmStatus.Close();
                                objBelRecepcao.VerificaNotasParaCancelar(objBelRecepcao.objListaNfseRetorno);

                                KryptonMessageBox.Show(null, objBelRecepcao.MontaMsgDeRetornoParaCliente(), Mensagens.CHeader, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                //EnviaEmail(objBelRecepcao.objListaNfseRetorno);
                            }
                            else
                            {
                                objBelRecepcao.LimpaRecibo();
                                objfrmStatus.Close();
                                KryptonMessageBox.Show(null, sMsgErro + Environment.NewLine, Mensagens.CHeader, MessageBoxButtons.OK, MessageBoxIcon.Information);

                            }


                            PesquisaNotas();
                            VerificaGeneratorLote();
                        }
                    }
                    else
                    {
                        KryptonMessageBox.Show("Selecione apenas uma Nota para consultar o lote", Mensagens.MSG_Aviso, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        PesquisaNotas();
                    }
                }
            }
            catch (Exception ex)
            {
                if (objfrmStatus != null)
                {
                    objfrmStatus.Close();
                }
                VerificaGeneratorLote();
                new HLPexception(ex);
            }
        }

        private void btnCancelamento_Click(object sender, EventArgs e)
        {
            try
            {
                if (belPesq.lResultPesquisa != null)
                {
                    List<belPesquisaNotas> objSelecionadas = belPesq.lResultPesquisa.Where(c => c.bSeleciona).ToList<belPesquisaNotas>();
                    List<belPesquisaNotas> objSelect = objSelecionadas.Where(c =>
                                                                       c.bEnviado == true &&
                                                                       c.bDenegada == false &&
                                                                       c.bCancelado == false).ToList<belPesquisaNotas>();
                    if (objSelect.Count() == 0)
                    {
                        KryptonMessageBox.Show("Nenhuma nota Válida foi Selecionada", Mensagens.MSG_Aviso, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    if (!daoUtil.ValidaUserToCancel())
                    {
                        KryptonMessageBox.Show("Usuário sem Acesso para cancelar Notas Fiscais.", Mensagens.MSG_Aviso, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    if (Acesso.tipoWsNfse == Acesso.TP_WS_NFSE.DSF)
                    {
                        FrmCancelamentoDSF objfrm = new FrmCancelamentoDSF(objSelect);
                        objfrm.ShowDialog();
                    }
                    else if (objSelect.Count == 1)
                    {
                        frmCancelamentoNfs objfrmCanc = new frmCancelamentoNfs();
                        if (Acesso.tipoWsNfse != Acesso.TP_WS_NFSE.TIPLAN)
                        {
                            objfrmCanc.ShowDialog();
                        }

                        if (String.IsNullOrEmpty(objfrmCanc.sErro))
                        {
                            throw new Exception("Erro não foi Selecionado");
                        }

                        belCancelamentoNFse objbelCancelamentoNFse = new belCancelamentoNFse();

                        if (KryptonMessageBox.Show("Deseja realmente cancelar essa Nota Fiscal ?", Mensagens.MSG_Confirmacao, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            TcPedidoCancelamento objTcPediCanc = objbelCancelamentoNFse.BuscaDadosParaCancelamento(objfrmCanc.sErro, objSelect[0].sCD_NFSEQ);
                            string sXmlRet = objbelCancelamentoNFse.CancelaNfes(objTcPediCanc);
                            string sMsgRet = "";
                            if (Acesso.tipoWsNfse == Acesso.TP_WS_NFSE.GINFES)
                            {
                                sMsgRet = objbelCancelamentoNFse.ConfiguraMsgRetornoCancelamento(sXmlRet);
                            }
                            else
                            {
                                sMsgRet = objbelCancelamentoNFse.ConfiguraMsgRetornCancelamento2(sXmlRet);
                            }

                            if (objbelCancelamentoNFse.bNotaCancelada)
                            {
                                objbelCancelamentoNFse.CancelarNFseSistema(objTcPediCanc.InfPedidoCancelamento.IdentificacaoNfse.Numero);
                            }
                            KryptonMessageBox.Show(sMsgRet, Mensagens.CHeader, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        KryptonMessageBox.Show("Não é possível cancelar várias notas de uma vez", Mensagens.MSG_Aviso, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                PesquisaNotas();
            }
            catch (Exception ex)
            {
                new HLPexception(ex);
            }
        }

        private void btnVisualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (belPesq.lResultPesquisa != null)
                {
                    List<belimpressao> sListImpressao = new List<belimpressao>();
                    belimpressao obj;

                    List<belPesquisaNotas> objSelecionadas = belPesq.lResultPesquisa.Where(c => c.bSeleciona).ToList<belPesquisaNotas>();
                    List<belPesquisaNotas> objSelect = objSelecionadas.Where(c =>
                                                                       c.bEnviado == true ||
                                                                       c.bCancelado == true).ToList<belPesquisaNotas>();
                    foreach (belPesquisaNotas item in objSelect)
                    {
                        obj = new belimpressao();
                        obj.sNfSeq = item.sCD_NFSEQ;
                        obj.sNota = item.scd_numero_nfse;
                        obj.bCanc = item.bCancelado;
                        obj.dtEnvio = item.dDT_EMI;
                        sListImpressao.Add(obj);
                    }

                    if (sListImpressao.Count > 0)
                    {
                        if (Acesso.tipoWsNfse == Acesso.TP_WS_NFSE.DSF)
                        {
                            if (sListImpressao.Count > 1)
                            {
                                throw new Exception("Imprima uma nota de cada vez !");
                            }
                            else
                            {

                                daoUtil dadosEmpresa = new daoUtil();
                                dadosEmpresa.SetDadosEmpresa();

                                string sEnderPrestador = string.Format("{0}, - BAIRRO: {1} ",
                                    dadosEmpresa.RuaEmpresa, dadosEmpresa.BairroEmpresa);
                                string sRPS = daoUtil.GetNumRPSbyCD_NFSEQ(sListImpressao.FirstOrDefault().sNfSeq);

                                string sPathXml = "";

                                if (sListImpressao.FirstOrDefault().bCanc)
                                {
                                    sPathXml = belCancelamentoDSF.GetFilePathMonthServico(false, sListImpressao.FirstOrDefault().sNota, sListImpressao.FirstOrDefault().dtEnvio);
                                }
                                else
                                {
                                    sPathXml = belCancelamentoDSF.GetFilePathMonthServico(true, sListImpressao.FirstOrDefault().sNota, sListImpressao.FirstOrDefault().dtEnvio);
                                }
                                if (!Directory.Exists(Pastas.ENVIADOS + "PDF\\"))
                                {
                                    Directory.CreateDirectory(Pastas.ENVIADOS + "PDF\\");
                                }

                                string sPathPDFdsf = "";
                                if (sListImpressao.FirstOrDefault().bCanc)
                                {
                                    sPathPDFdsf = Pastas.ENVIADOS + "PDF\\" + sListImpressao.FirstOrDefault().sNota + "_canc.pdf"; //belCancelamentoDSF
                                }
                                else
                                {
                                    sPathPDFdsf = Pastas.ENVIADOS + "PDF\\" + sListImpressao.FirstOrDefault().sNota + ".pdf";
                                }

                                LoteRPS nota = SerializeClassToXml.DeserializeClasse<LoteRPS>(sPathXml);
                                nota.CD_NFSEQ = sListImpressao.FirstOrDefault().sNfSeq;

                                nota.NumeroRPS = sListImpressao.FirstOrDefault().sNota;
                                foreach (LoteRPSItensItem item in nota.Itens.Item)
                                {
                                    item.NumeroRPS = nota.NumeroRPS;
                                }
                                List<LoteRPS> lNotas = new List<LoteRPS>();
                                lNotas.Add(nota);

                                ReportDocument rpt = new ReportDocument();
                                rpt.Load(Util.GetPathRelatorio("rptNFSeCamp.rpt"));


                                dsNFSeCampinas ds = CarregaDataSet(sListImpressao.FirstOrDefault().sNfSeq, dadosEmpresa, sEnderPrestador, nota);
                                rpt.SetDataSource(ds);
                                rpt.DataDefinition.FormulaFields["F_BAIRRO_TOMADOR"].Text = "\"" + nota.BairroTomador + "\"";
                                decimal vl_iss = Math.Round(nota.Itens.Item.Sum(c => c.ValorTotal) * (Convert.ToDecimal(nota.AliquotaAtividade.Replace('.', ',')) / 100), 2);
                                rpt.DataDefinition.FormulaFields["F_VALOR_ISS"].Text = "\"" + "R$    " + vl_iss.ToString().Replace('.', ',') + "\"";





                                //try { rpt.SetParameterValue("PathImage", Acesso.LOGOTIPO); }
                                //catch (System.Exception ex) { };

                                if (objSelect.FirstOrDefault().bCancelado)
                                {
                                    string sMotivoCanc = daoUtil.GetMOTIVO_CANC(sListImpressao.FirstOrDefault().sNfSeq);
                                    rpt.DataDefinition.FormulaFields["F_MOTIVO_CANC"].Text = "\"" + sMotivoCanc + "\"";
                                }


                                rpt.Refresh();


                                if (Convert.ToBoolean(Acesso.EMAIL_AUTOMATICO))
                                {
                                    if (KryptonMessageBox.Show("Deseja enviar email da Nota para o Tomador ?", Mensagens.MSG_Confirmacao, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                                    {
                                        if (Acesso.VerificaDadosEmail())
                                        {
                                            List<belEmail> objlbelEmail = new List<belEmail>();
                                            if (File.Exists(sPathPDFdsf))
                                            {
                                                try
                                                {
                                                    File.Delete(sPathPDFdsf);
                                                }
                                                catch (Exception) { }
                                            }

                                            if (!File.Exists(sPathPDFdsf))
                                            {
                                                Util.ExportPDF(rpt, sPathPDFdsf);
                                            }
                                            for (int i = 0; i < sListImpressao.Count; i++)
                                            {
                                                belEmail objemail = new belEmail(sPathXml, sPathPDFdsf, sListImpressao.FirstOrDefault().sNfSeq, "", "", sListImpressao[i].sVerificacao);
                                                objlbelEmail.Add(objemail);
                                            }
                                            if (objlbelEmail.Count > 0)
                                            {
                                                frmEmail objfrmEmail = new frmEmail(objlbelEmail, belEmail.TipoEmail.NF_ServicoDSF);
                                                objfrmEmail.ShowDialog();
                                            }
                                        }
                                        else
                                        {
                                            KryptonMessageBox.Show("Campos para o envio de e-mail automático não estão preenchidos corretamente!", Mensagens.CHeader, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                    }
                                }



                                frmRelatorio frm = new frmRelatorio(rpt, "Impressão de Relatório de Nota Fiscal Eletrônica de Serviço");
                                frm.Show();
                            }
                        }
                        else if (Acesso.tipoWsNfse == Acesso.TP_WS_NFSE.SUSESU)
                        {
                            bel.NFes.Susesu.belNFesSusesu objNfe;

                            List<belNFesSusesu> lNfe = new List<belNFesSusesu>();
                            foreach (belPesquisaNotas nota in objSelect)
                            {
                                objNfe = new belNFesSusesu();
                                string sCHAVE = nota.sCHAVENFE;
                                objNfe.DATA_EMISSAO = objSelect.FirstOrDefault().dDT_EMI.ToString();
                                objNfe.NUMERO_NOTA = Convert.ToInt32(nota.sCD_NOTAFIS);
                                objNfe = belSerializeToXml.DeserializeClasse<belNFesSusesu>(objNfe.GetsFilePathServico(true));
                                objNfe.sCHAVE = sCHAVE;
                                lNfe.Add(objNfe);
                            }

                            ReportDocument rpt = new ReportDocument();
                            rpt.Load(Util.GetPathRelatorio("rptNfesSusesu.rpt"));

                            rpt.SetDataSource(lNfe);

                            daoUtil dadosEmpresa = new daoUtil();
                            dadosEmpresa.SetDadosEmpresa();
                            string sNomeCidade = lNfe.FirstOrDefault().BuscaNomeCidade(Util.TiraSimbolo(lNfe.FirstOrDefault().TOMADOR_MUNICIPIO.ToString()));

                            rpt.DataDefinition.FormulaFields["NM_MUNICIPIO_TOMADOR"].Text = "\"" + sNomeCidade + "\"";
                            rpt.DataDefinition.FormulaFields["NomeEmpresa"].Text = "\"" + Acesso.NM_RAZAOSOCIAL + "\"";
                            rpt.DataDefinition.FormulaFields["DocEmpresa"].Text = "\"" + Acesso.CNPJ_EMPRESA + "\"";
                            rpt.DataDefinition.FormulaFields["IMEmpresa"].Text = "\"" + dadosEmpresa.ImEmpresa + "\"";
                            rpt.DataDefinition.FormulaFields["IEEmpresa"].Text = "\"" + dadosEmpresa.IeEmpresa + "\"";
                            rpt.DataDefinition.FormulaFields["FoneEmpresa"].Text = "\"" + dadosEmpresa.FoneEmpresa + "\"";
                            rpt.DataDefinition.FormulaFields["EnderecoEmpresa"].Text = "\"" + dadosEmpresa.RuaEmpresa + "\"";
                            rpt.DataDefinition.FormulaFields["BairroEmpresa"].Text = "\"" + dadosEmpresa.BairroEmpresa + "\"";
                            rpt.DataDefinition.FormulaFields["CidadeEmpresa"].Text = "\"" + Acesso.CIDADE_EMPRESA + " - " + Acesso.xUF + "\"";
                            rpt.DataDefinition.FormulaFields["EmailEmpresa"].Text = "\"" + dadosEmpresa.EmailEmpresa + "\"";

                            rpt.Refresh();
                            try { rpt.SetParameterValue("PathImage", Acesso.LOGOTIPO); }
                            catch (System.Exception) { };

                            frmRelatorio frm = new frmRelatorio(rpt, "Impressão de Relatório de Nota Fiscal Eletrônica de Serviço");
                            frm.Show();

                        }
                        else
                        {
                            belimpressao objbelimpressao = new belimpressao();
                            sListImpressao = objbelimpressao.BuscaDadosParaImpressao(sListImpressao);


                            if (KryptonMessageBox.Show("Deseja enviar email da Nota para o Tomador ?", Mensagens.MSG_Confirmacao, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                            {
                                if (Convert.ToBoolean(Acesso.EMAIL_AUTOMATICO))
                                {
                                    if (Acesso.VerificaDadosEmail())
                                    {
                                        List<belEmail> objlbelEmail = new List<belEmail>();
                                        for (int i = 0; i < sListImpressao.Count; i++)
                                        {
                                            belEmail objemail = new belEmail("", "", sListImpressao[i].sNfSeq, sListImpressao[i].sNota, "", sListImpressao[i].sVerificacao);
                                            objlbelEmail.Add(objemail);
                                        }
                                        if (objlbelEmail.Count > 0)
                                        {
                                            frmEmail objfrmEmail = new frmEmail(objlbelEmail, belEmail.TipoEmail.NF_Servico);
                                            objfrmEmail.ShowDialog();
                                        }
                                    }
                                    else
                                    {
                                        KryptonMessageBox.Show("Campos para o envio de e-mail automático não estão preenchidos corretamente!", Mensagens.CHeader, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                }
                            }

                            if (Acesso.tipoWsNfse == Acesso.TP_WS_NFSE.GINFES)
                            {

                                for (int i = 0; i < sListImpressao.Count; i++)
                                {
                                    System.Diagnostics.Process.Start("iexplore", "visualizar.ginfes" + (Acesso.TP_AMB_SERV == 2 ? "h" : "") + ".com.br/report/consultarNota?__report=nfs_ver4&cdVerificacao=" + sListImpressao[i].sVerificacao + "&numNota=" + sListImpressao[i].sNota);
                                }
                            }
                            else
                            {
                                //https://spe.riodasostras.rj.gov.br/nfse/nfse.aspx?ccm=99999999&nf=999999999&cod=XXXXXXXX

                                for (int i = 0; i < sListImpressao.Count; i++)
                                {
                                    System.Diagnostics.Process.Start("iexplore", string.Format("https://spe.riodasostras.rj.gov.br/nfse/nfse.aspx?ccm=2747&nf={0}&cod={1}", sListImpressao[i].sNota, sListImpressao[i].sVerificacao.Replace("-", "")));
                                }
                            }
                        }
                    }
                    else
                    {
                        KryptonMessageBox.Show("Nenhuma nota Válida foi Selecionada", Mensagens.MSG_Aviso, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                new HLPexception(ex);
            }
        }


        private static dsNFSeCampinas CarregaDataSet(string sCD_NFSEQ, daoUtil dadosEmpresa, string sEnderPrestador, LoteRPS nota)
        {
            dsNFSeCampinas ds = new dsNFSeCampinas();
            dsNFSeCampinas.NotaRow row = ds.Nota.NewNotaRow();

            row.RazaoSocialPrestador = nota.RazaoSocialPrestador;
            row.NumeroRPS = nota.NumeroRPS;
            row.DataEmissaoRPS = nota.DataEmissaoRPS;
            row.CPFCNPJTomador = nota.CPFCNPJTomador;
            row.RazaoSocialTomador = nota.RazaoSocialTomador;
            row.TipoLogradouroTomador = nota.TipoLogradouroTomador.ToUpper();
            row.LogradouroTomador = nota.LogradouroTomador;
            row.NumeroEnderecoTomador = nota.NumeroEnderecoTomador;
            row.TipoBairroTomador = nota.TipoBairroTomador;
            row.CEPTomador = nota.CEPTomador;
            row.EmailTomador = nota.EmailTomador;
            row.CodigoAtividade = nota.CodigoAtividade;
            row.AliquotaAtividade = nota.AliquotaAtividade.ToString();

            switch (nota.TipoRecolhimento)
            {
                case "A": row.TipoRecolhimento = "A Recolher";
                    break;
                case "R": row.TipoRecolhimento = "Retido na fonte";
                    break;
            }
            row.MunicipioPrestacaoDescricao = nota.MunicipioPrestacaoDescricao;
            switch (nota.Tributacao)
            {
                case "C": row.Tributacao = "Isenta de ISS";
                    break;
                case "E": row.Tributacao = "Não Incidência no Município";
                    break;
                case "F": row.Tributacao = "Imune";
                    break;
                case "K": row.Tributacao = "Exigibilidd Susp.Dec.J/Proc.A";
                    break;
                case "N": row.Tributacao = "Não Tributável";
                    break;
                case "T": row.Tributacao = "Tributável";
                    break;
                case "G": row.Tributacao = "Tributável Fixo";
                    break;
                case "H": row.Tributacao = "Tributável S.N.";
                    break;
                case "M": row.Tributacao = "Micro Empreendedor Individual (MEI)";
                    break;
            }
            row.AliquotaPIS = nota.AliquotaPIS;
            row.AliquotaCOFINS = nota.AliquotaCOFINS;
            row.AliquotaINSS = nota.AliquotaINSS;
            row.AliquotaIR = nota.AliquotaIR;
            row.AliquotaCSLL = nota.AliquotaCSLL;

            row.ValorCOFINS = Convert.ToDecimal(nota.ValorCOFINS.ToString().Replace(".", ","));
            row.ValorCSLL = Convert.ToDecimal(nota.ValorCSLL.ToString().Replace(".", ","));
            row.ValorINSS = Convert.ToDecimal(nota.ValorINSS.ToString().Replace(".", ","));
            row.ValorIR = Convert.ToDecimal(nota.ValorIR.ToString().Replace(".", ","));
            row.ValorPIS = Convert.ToDecimal(nota.ValorPIS.ToString().Replace(".", ","));

            row.DescricaoRPS = nota.DescricaoRPS;
            row.F_ENDER_TOMADOR =
            row.F_RECOLHIMENTO =
            row.F_TRIBUTACAO =
            row.F_CD_VERIFICACAO = daoUtil.GetCodVerificacaoByCD_NFSEQ(sCD_NFSEQ);
            row.F_CNPJ_PRESTADOR = Acesso.CNPJ_EMPRESA;
            row.F_ENDERECO_PRESTADOR = sEnderPrestador;
            row.F_MUNICIPIO_PRESTADOR = Acesso.CIDADE_EMPRESA;
            row.F_UF_PRESTADOR = daoUtil.GetUfByNome(nota.CidadeTomadorDescricao);
            row.F_EMAIL_PRESTADOR = dadosEmpresa.EmailEmpresa;
            //row.F_UF_TOMADOR = daoUtil.GetUfByNome(nota.CidadeTomadorDescricao);
            row.F_UF_TOMADOR = daoUtil.GetUfTomador(nota.CD_NFSEQ);
            row.F_MES_RECOLHIMENTO = nota.DataEmissaoRPS.ToString("MM/yyyy");
            if (nota.Deducoes.Deducao.Count() > 0)
            {
                row.F_VALOR_DECUCAO = nota.Deducoes.Deducao.Sum(c => c.ValorDeduzir);
            }
            else
            {
                row.F_VALOR_DECUCAO = 0;
            }
            row.CidadeTomadorDescricao = nota.CidadeTomadorDescricao;
            row.InscricaoPrestador = nota.InscricaoMunicipalPrestador;

            row.Duplicatas = daoCobr.BuscaFatToImpressaoNFSE_DSF(nota.CD_NFSEQ);

            ds.Nota.AddNotaRow(row);

            dsNFSeCampinas.ItensRow rowItem;
            foreach (LoteRPSItensItem item in nota.Itens.Item)
            {
                rowItem = ds.Itens.NewItensRow();
                rowItem.DiscriminacaoServico = item.DiscriminacaoServico;
                rowItem.Quantidade = item.Quantidade;
                rowItem.ValorTotal = item.ValorTotal;
                rowItem.ValorUnitario = item.ValorUnitario;
                rowItem.NumeroRPS = nota.NumeroRPS;
                ds.Itens.AddItensRow(rowItem);
            }



            return ds;
        }

        #endregion

        bool bMarcar = false;
        private void dgvNF_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 0 && bsNotas.DataSource != null && Acesso.tipoWsNfse != Acesso.TP_WS_NFSE.SUSESU)
                {
                    bMarcar = !bMarcar;
                    foreach (belPesquisaNotas nota in bsNotas.List)
                    {
                        nota.bSeleciona = bMarcar;
                    }

                    dgvNF.Refresh();
                    if (dgvNF.CurrentCell != null)
                    {
                        if (dgvNF.CurrentCell.ColumnIndex == 0)
                        {
                            SendKeys.Send("{right}");
                            SendKeys.Send("{left}");
                        }
                    }
                }

                if (dgvNF.Columns[e.ColumnIndex].Name == "sCD_NOTAFIS")
                {
                    if (dgvNF.Columns[e.ColumnIndex].Tag == null)
                    {
                        dgvNF.Columns[e.ColumnIndex].Tag = true;
                    }
                    if (Convert.ToBoolean(dgvNF.Columns[e.ColumnIndex].Tag.ToString()))
                    {
                        bsNotas.DataSource = belPesq.lResultPesquisa.OrderBy(C => C.sCD_NOTAFIS);
                    }
                    else
                    {
                        bsNotas.DataSource = belPesq.lResultPesquisa.OrderByDescending(C => C.sCD_NOTAFIS);
                    }
                    ColoriGrid();
                    dgvNF.Columns[e.ColumnIndex].Tag = !Convert.ToBoolean(dgvNF.Columns[e.ColumnIndex].Tag.ToString());
                }
                else if (dgvNF.Columns[e.ColumnIndex].Name == "sCD_NFSEQ")
                {
                    if (dgvNF.Columns[e.ColumnIndex].Tag == null)
                    {
                        dgvNF.Columns[e.ColumnIndex].Tag = true;
                    }
                    if (Convert.ToBoolean(dgvNF.Columns[e.ColumnIndex].Tag.ToString()))
                    {
                        bsNotas.DataSource = belPesq.lResultPesquisa.OrderBy(C => C.sCD_NFSEQ);
                    }
                    else
                    {
                        bsNotas.DataSource = belPesq.lResultPesquisa.OrderByDescending(C => C.sCD_NFSEQ);
                    }
                    ColoriGrid();
                    dgvNF.Columns[e.ColumnIndex].Tag = !Convert.ToBoolean(dgvNF.Columns[e.ColumnIndex].Tag.ToString());
                }
                else if (dgvNF.Columns[e.ColumnIndex].Name == "scd_numero_nfse")
                {
                    if (dgvNF.Columns[e.ColumnIndex].Tag == null)
                    {
                        dgvNF.Columns[e.ColumnIndex].Tag = true;
                    }
                    if (Convert.ToBoolean(dgvNF.Columns[e.ColumnIndex].Tag.ToString()))
                    {
                        bsNotas.DataSource = belPesq.lResultPesquisa.OrderBy(C => C.scd_numero_nfse);
                    }
                    else
                    {
                        bsNotas.DataSource = belPesq.lResultPesquisa.OrderByDescending(C => C.scd_numero_nfse);
                    }
                    ColoriGrid();
                    dgvNF.Columns[e.ColumnIndex].Tag = !Convert.ToBoolean(dgvNF.Columns[e.ColumnIndex].Tag.ToString());
                }
                else if (dgvNF.Columns[e.ColumnIndex].Name == "dDT_EMI")
                {
                    if (dgvNF.Columns[e.ColumnIndex].Tag == null)
                    {
                        dgvNF.Columns[e.ColumnIndex].Tag = true;
                    }
                    if (Convert.ToBoolean(dgvNF.Columns[e.ColumnIndex].Tag.ToString()))
                    {
                        bsNotas.DataSource = belPesq.lResultPesquisa.OrderBy(C => C.dDT_EMI);
                    }
                    else
                    {
                        bsNotas.DataSource = belPesq.lResultPesquisa.OrderByDescending(C => C.dDT_EMI);
                    }
                    ColoriGrid();
                    dgvNF.Columns[e.ColumnIndex].Tag = !Convert.ToBoolean(dgvNF.Columns[e.ColumnIndex].Tag.ToString());
                }
                else if (dgvNF.Columns[e.ColumnIndex].Name == "dVL_TOTNF")
                {
                    if (dgvNF.Columns[e.ColumnIndex].Tag == null)
                    {
                        dgvNF.Columns[e.ColumnIndex].Tag = true;
                    }
                    if (Convert.ToBoolean(dgvNF.Columns[e.ColumnIndex].Tag.ToString()))
                    {
                        bsNotas.DataSource = belPesq.lResultPesquisa.OrderBy(C => C.dVL_TOTNF);
                    }
                    else
                    {
                        bsNotas.DataSource = belPesq.lResultPesquisa.OrderByDescending(C => C.dVL_TOTNF);
                    }
                    ColoriGrid();
                    dgvNF.Columns[e.ColumnIndex].Tag = !Convert.ToBoolean(dgvNF.Columns[e.ColumnIndex].Tag.ToString());
                }
                else if (dgvNF.Columns[e.ColumnIndex].Name == "sNM_GUERRA")
                {
                    if (dgvNF.Columns[e.ColumnIndex].Tag == null)
                    {
                        dgvNF.Columns[e.ColumnIndex].Tag = true;
                    }
                    if (Convert.ToBoolean(dgvNF.Columns[e.ColumnIndex].Tag.ToString()))
                    {
                        bsNotas.DataSource = belPesq.lResultPesquisa.OrderBy(C => C.sNM_GUERRA);
                    }
                    else
                    {
                        bsNotas.DataSource = belPesq.lResultPesquisa.OrderByDescending(C => C.sNM_CLIFOR);
                    }
                    ColoriGrid();
                    dgvNF.Columns[e.ColumnIndex].Tag = !Convert.ToBoolean(dgvNF.Columns[e.ColumnIndex].Tag.ToString());
                }
                else if (dgvNF.Columns[e.ColumnIndex].Name == "sNM_CLIFOR")
                {
                    if (dgvNF.Columns[e.ColumnIndex].Tag == null)
                    {
                        dgvNF.Columns[e.ColumnIndex].Tag = true;
                    }
                    if (Convert.ToBoolean(dgvNF.Columns[e.ColumnIndex].Tag.ToString()))
                    {
                        bsNotas.DataSource = belPesq.lResultPesquisa.OrderBy(C => C.sNM_GUERRA);
                    }
                    else
                    {
                        bsNotas.DataSource = belPesq.lResultPesquisa.OrderByDescending(C => C.sNM_GUERRA);
                    }
                    ColoriGrid();
                    dgvNF.Columns[e.ColumnIndex].Tag = !Convert.ToBoolean(dgvNF.Columns[e.ColumnIndex].Tag.ToString());
                }

            }
            catch (Exception ex)
            {
                new HLPexception(ex);
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}