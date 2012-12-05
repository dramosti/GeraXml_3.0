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

namespace HLP.GeraXml.UI.NFse
{
    public partial class frmGeraArquivoNFes : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        belBuscaDados objbelBuscaDados = new belBuscaDados();

        private enum TipoFormVisualiza { frmNormal, frmSusesu };


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
            if (cboFiltro.SelectedIndex == 0)
            {
                txtNfIni.Visible = false;
                txtNfFim.Visible = false;

                dtpIni.Visible = true;
                dtpFim.Visible = true;
            }
            else
            {
                txtNfIni.Visible = true;
                txtNfFim.Visible = true;

                dtpIni.Visible = false;
                dtpFim.Visible = false;
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

            belPesquisaNotas belPesq = new belPesquisaNotas(st,
                                                           (cboFiltro.cbx.SelectedIndex == 0 ? belPesquisaNotas.Filtro.Data : belPesquisaNotas.Filtro.Sequencia),
                                                           (cboFiltro.cbx.SelectedIndex == 0 ? dtpIni.Value.ToString() : txtNfIni.Text),
                                                           (cboFiltro.cbx.SelectedIndex == 0 ? dtpFim.Value.ToString() : txtNfFim.Text), true);
            belPesquisaNotasBindingSource.DataSource = belPesq.lResultPesquisa;



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
            lblTotalRegistros.Text = belPesq.lResultPesquisa.Count + " Registro(s) encontrado(s)";
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
                if ((belPesquisaNotasBindingSource.DataSource as List<belPesquisaNotas>) != null)
                {
                    List<belPesquisaNotas> objSelecionadas = ((List<belPesquisaNotas>)belPesquisaNotasBindingSource.DataSource).Where(c => c.bSeleciona).ToList<belPesquisaNotas>();
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

                        if (Acesso.tipoWsNfse == Acesso.TP_WS_NFSE.SUSESU) // arrumar o retorno das TELAS...
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
                            string sMsgErro = objBelRecepcao.BuscaRetorno(objFrmVisualiza.objLoteRpsAlter.Rps[0].InfRps.Prestador, objfrmStatus.lblMsg, objfrmStatus.progressBarStatus);

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
                                //if (Convert.ToBoolean(Acesso.EMAIL_AUTOMATICO))
                                //{
                                //    //EnviaEmail(objBelRecepcao.objListaNfseRetorno);
                                //}
                            }
                            else
                            {
                                objBelRecepcao.LimpaRecibo(objFrmVisualiza.objLoteRpsAlter);
                                objfrmStatus.Close();
                                KryptonMessageBox.Show(null, sMsgErro + Environment.NewLine, Mensagens.CHeader, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
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
                if ((belPesquisaNotasBindingSource.DataSource as List<belPesquisaNotas>) != null)
                {
                    List<belPesquisaNotas> objSelecionadas = ((List<belPesquisaNotas>)belPesquisaNotasBindingSource.DataSource).Where(c => c.bSeleciona).ToList<belPesquisaNotas>();
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
                if ((belPesquisaNotasBindingSource.DataSource as List<belPesquisaNotas>) != null)
                {
                    List<belPesquisaNotas> objSelecionadas = ((List<belPesquisaNotas>)belPesquisaNotasBindingSource.DataSource).Where(c => c.bSeleciona).ToList<belPesquisaNotas>();
                    List<belPesquisaNotas> objSelect = objSelecionadas.Where(c =>
                                                                       c.bEnviado == true &&
                                                                       c.bDenegada == false &&
                                                                       c.bCancelado == false).ToList<belPesquisaNotas>();
                    if (objSelect.Count() == 0)
                    {
                        KryptonMessageBox.Show("Nenhuma nota Válida foi Selecionada", Mensagens.MSG_Aviso, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if (objSelect.Count == 1)
                    {
                        frmCancelamentoNfs objfrmCanc = new frmCancelamentoNfs();
                        objfrmCanc.ShowDialog();

                        if (String.IsNullOrEmpty(objfrmCanc.sErro))
                        {
                            throw new Exception("Erro não foi Selecionado");
                        }

                        belCancelamentoNFse objbelCancelamentoNFse = new belCancelamentoNFse();

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
                if ((belPesquisaNotasBindingSource.DataSource as List<belPesquisaNotas>) != null)
                {
                    List<belimpressao> sListImpressao = new List<belimpressao>();
                    belimpressao obj;

                    List<belPesquisaNotas> objSelecionadas = ((List<belPesquisaNotas>)belPesquisaNotasBindingSource.DataSource).Where(c => c.bSeleciona).ToList<belPesquisaNotas>();
                    List<belPesquisaNotas> objSelect = objSelecionadas.Where(c =>
                                                                       c.bEnviado == true ||
                                                                       c.bCancelado == true).ToList<belPesquisaNotas>();
                    foreach (belPesquisaNotas item in objSelect)
                    {
                        obj = new belimpressao();
                        obj.sNfSeq = item.sCD_NFSEQ;
                        sListImpressao.Add(obj);
                    }

                    if (sListImpressao.Count > 0)
                    {
                        if (Acesso.tipoWsNfse == Acesso.TP_WS_NFSE.SUSESU)
                        {
                            bel.NFes.Susesu.belNFesSusesu objNfe;

                            List<belNFesSusesu> lNfe = new List<belNFesSusesu>();
                            foreach (belPesquisaNotas nota in objSelect)
                            {
                                objNfe = new belNFesSusesu();
                                string sCHAVE = nota.sCHAVENFE;
                                objNfe.DATA_EMISSAO = objSelect.FirstOrDefault().dDT_EMI.ToString();
                                objNfe.NUMERO_NOTA = Convert.ToInt32(nota.sCD_NOTAFIS);
                                objNfe = belSerializeToXml.DeserializeClasse<belNFesSusesu>(objNfe.GetsFilePath(true));
                                objNfe.sCHAVE = sCHAVE;
                                lNfe.Add(objNfe);
                            }

                            ReportDocument rpt = new ReportDocument();
                            rpt.Load(Application.StartupPath + "\\Relatorios\\rptNfesSusesu.rpt");

                            rpt.SetDataSource(lNfe);

                            daoUtil dadosEmpresa = new daoUtil();
                            dadosEmpresa.SetDadosEmpresa();

                            rpt.DataDefinition.FormulaFields["NomeEmpresa"].Text = "\"" + Acesso.NM_EMPRESA + "\"";
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
                                            belEmail objemail = new belEmail("", "", sListImpressao[i].sNota, "", "", sListImpressao[i].sVerificacao);
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

        #endregion

        bool bMarcar = false;
        private void dgvNF_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 0 && belPesquisaNotasBindingSource.DataSource != null && Acesso.tipoWsNfse != Acesso.TP_WS_NFSE.SUSESU)
                {
                    bMarcar = !bMarcar;
                    foreach (belPesquisaNotas nota in belPesquisaNotasBindingSource.List)
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