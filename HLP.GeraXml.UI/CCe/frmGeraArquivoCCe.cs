using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using HLP.GeraXml.Comum;
using HLP.GeraXml.bel.CCe;
using HLP.GeraXml.Comum.Static;
using System.Linq;
using CrystalDecisions.CrystalReports.Engine;
using System.IO;
using HLP.GeraXml.Comum.DataSet;
using HLP.GeraXml.bel;
using HLP.GeraXml.bel.CTe;

namespace HLP.GeraXml.UI.CCe
{
    public partial class frmGeraArquivoCCe : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        belPesquisaCCe objbelPesquisaCCe = new belPesquisaCCe();

        string sStatusPesquisa = "";

        public frmGeraArquivoCCe()
        {
            InitializeComponent();
        }

        private void frmGeraArquivoCCe_Load(object sender, EventArgs e)
        {
            cboStatus.cbx.SelectedIndexChanged += new EventHandler(cboStatus_SelectedIndexChanged);
            cboStatus.SelectedIndex = 2;

            cboFiltro.cbx.SelectedIndexChanged += new EventHandler(cboFiltro_SelectedIndexChanged);
            cboFiltro.SelectedIndex = 0;

            txtNfIni.txt.Validated += new EventHandler(txt_Validated);
            txtNfFim.txt.Validated += new EventHandler(txt_Validated);
            dtpFim.Value = DateTime.Now;
            dtpIni.Value = DateTime.Now;

        }



        #region Metodos

        public void PesquisaCartas()
        {
            bsGrid.DataSource = new List<belPesquisaCCe>();
            if (cboFiltro.SelectedIndex == 0)
            {
                bsGrid.DataSource = objbelPesquisaCCe.BuscaCCe(dtpIni.Value, dtpFim.Value, sStatusPesquisa);
            }
            else
            {
                if (Acesso.NM_RAMO != Acesso.BancoDados.TRANSPORTE)
                {
                    bsGrid.DataSource = objbelPesquisaCCe.BuscaCCe(txtNfIni.Text, txtNfFim.Text, (cboFiltro.SelectedIndex == 2 ? belPesquisaCCe.Campo.cd_notafis : belPesquisaCCe.Campo.cd_nfseq), sStatusPesquisa);
                }
                else
                {
                    bsGrid.DataSource = objbelPesquisaCCe.BuscaCCe(txtNfIni.Text, txtNfFim.Text, (cboFiltro.SelectedIndex == 2 ? belPesquisaCCe.Campo.cd_conheci : belPesquisaCCe.Campo.nr_lanc), sStatusPesquisa);
                }
            }
            for (int i = 0; i < dgvItens.RowCount; i++)
            {
                if (dgvItens["QT_ENVIO", i].Value.ToString() == "0")
                {
                    dgvItens.Rows[i].DefaultCellStyle.BackColor = Color.White;
                }
                else
                {
                    dgvItens.Rows[i].DefaultCellStyle.BackColor = Color.LightGreen;
                }
            }
            lblTotalRegistros.Text = dgvItens.Rows.Count + " Registro(s) encontrado(s)";
        }

        private void PopulaTabVisualizacao(object obj)
        {
            try
            {
                if (Acesso.NM_RAMO != Acesso.BancoDados.TRANSPORTE)
                {
                    belEvento objEvento = obj as belEvento;
                    txtNotaFis.Text = (bsGrid.DataSource as List<belPesquisaCCe>).FirstOrDefault(c => c.CHNFE == objEvento.infEvento.chNFe).CD_NOTAFIS;
                    txtChaveNFe.Text = objEvento.infEvento.chNFe;
                    txtRazaoSocial.Text = (bsGrid.DataSource as List<belPesquisaCCe>).FirstOrDefault(c => c.CHNFE == objEvento.infEvento.chNFe).NM_CLIFOR;
                    txtCondUso.Text = objEvento.infEvento.detEvento.xCondUso;
                    txtAjustes.Text = objEvento.infEvento.detEvento.xCorrecao.Replace("|", Environment.NewLine);
                }
                else
                {
                    TEvento objEvCCeCTe = obj as TEvento;
                    txtNotaFis.Text = (bsGrid.DataSource as List<belPesquisaCCe>).FirstOrDefault(c => c.CHNFE == objEvCCeCTe.infEvento.chCTe).CD_NOTAFIS;
                    txtChaveNFe.Text = objEvCCeCTe.infEvento.chCTe;
                    txtRazaoSocial.Text = (bsGrid.DataSource as List<belPesquisaCCe>).FirstOrDefault(c => c.CHNFE == objEvCCeCTe.infEvento.chCTe).NM_CLIFOR;

                    string xFile = Pastas.CCe + "\\" + (bsGrid.DataSource as List<belPesquisaCCe>).FirstOrDefault(c => c.CHNFE == objEvCCeCTe.infEvento.chCTe).CD_NRLANC + "_prevalida.xml";
                    evCCeCTe objEvCanc = SerializeClassToXml.DeserializeClasse<evCCeCTe>(xFile);
                    txtCondUso.Text = objEvCanc.xCondUso.ToString();
                    txtAjustes.Text = "";

                    foreach (var item in objEvCanc.infCorrecao)
                    {
                        txtAjustes.Text += string.Format("GRUPO: {0} - CAMPO: {1} - CORREÇÃO:{2} - {3}{4}" + Environment.NewLine,
                                                 item.grupoAlterado.ToString().ToUpper().Trim(),
                                                item.campoAlterado.ToString().ToUpper().Trim(),
                                               item.valorAlterado.ToString().ToUpper().Trim(),
                                                 (item.nroItemAlterado != null ? "INDEX:" : ""),
                                                 (item.nroItemAlterado != null ? item.nroItemAlterado.ToString() : ""));
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private void LimpaTabVisualizacao()
        {
            btnFirst.Enabled = false;
            btnPrevious.Enabled = false;
            btnNext.Enabled = false;
            btnLast.Enabled = false;

            txtNotaFis.Text = "";
            txtChaveNFe.Text = "";
            txtRazaoSocial.Text = "";
            txtCondUso.Text = "";
            txtAjustes.Text = "";
        }

        private void EnviaEmailCCe(List<belPesquisaCCe> lsNotas)
        {
            if (Acesso.VerificaDadosEmail())
            {
                List<belEmail> objlbelEmail = new List<belEmail>();

                for (int i = 0; i < lsNotas.Count; i++)
                {
                    belEmail objemail = new belEmail("", Pastas.CCe + "\\PDF\\" + lsNotas[i].CD_NOTAFIS + ".pdf", lsNotas[i].CD_NFSEQ, lsNotas[i].CD_NOTAFIS);
                    objlbelEmail.Add(objemail);
                }

                if (objlbelEmail.Count > 0)
                {
                    frmEmail objfrmEmail = new frmEmail(objlbelEmail, belEmail.TipoEmail.CCe);
                    objfrmEmail.ShowDialog();
                }
            }
            else
            {
                KryptonMessageBox.Show(null, "Campos para o envio de e-mail automático não estão preenchidos corretamente!", Mensagens.CHeader, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        #endregion


        #region Botoes
        private void btnPesquisa_Click(object sender, EventArgs e)
        {
            try
            {
                PesquisaCartas();
            }
            catch (Exception ex)
            {
                new HLPexception(ex);
            }
        }
        private void btnEnvio_Click(object sender, EventArgs e)
        {
            try
            {
                if ((bsGrid.DataSource as List<belPesquisaCCe>) != null)
                {
                    if ((bsGrid.DataSource as List<belPesquisaCCe>).Where(c => c.bSeleciona).Count() > 0)
                    {
                        if (Acesso.NM_RAMO != Acesso.BancoDados.TRANSPORTE)
                        {
                            belPesquisaCCe objbelPesqEnvio = (bsGrid.DataSource as List<belPesquisaCCe>).FirstOrDefault(c => c.bSeleciona);
                            List<belPesquisaCCe> objListaSelect = (bsGrid.DataSource as List<belPesquisaCCe>).Where(c => c.bSeleciona).ToList();
                            belGeraCCe objbelGeraCCe = new belGeraCCe(objListaSelect);
                            objbelGeraCCe.GeraXmlEnvio();
                            string sRetorno = objbelGeraCCe.TransmiteLoteCCe(objbelGeraCCe.sXMLfinal);
                            string sMessage = objbelGeraCCe.AnalisaRetornoEnvio(sRetorno);
                            KryptonMessageBox.Show(sMessage, Mensagens.CHeader, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            if ((bsGrid.DataSource as List<belPesquisaCCe>).Where(c => c.bSeleciona).Count() > 1)
                            {
                                KryptonMessageBox.Show("Somente uma carta de correção por vez é aceito!", Mensagens.MSG_Aviso, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                belPesquisaCCe objbelPesqEnvio = (bsGrid.DataSource as List<belPesquisaCCe>).FirstOrDefault(c => c.bSeleciona);
                                List<belPesquisaCCe> objListaSelect = (bsGrid.DataSource as List<belPesquisaCCe>).Where(c => c.bSeleciona).ToList();
                                belGeraCCe objbelGeraCCe = new belGeraCCe(objListaSelect);
                                HLP.GeraXml.bel.CTe.Evento.TRetEvento ret = objbelGeraCCe.TransmiteLoteCCeCTe();

                                //Testes
                                //string sPath = Pastas.PROTOCOLOS + "\\" + "35140614920065000160570010000011721000029623" + "_ret-cce.xml";
                                //HLP.GeraXml.bel.CTe.Evento.TRetEvento retorno = SerializeClassToXml.DeserializeClasse<HLP.GeraXml.bel.CTe.Evento.TRetEvento>(sPath);

                                string sMessage = objbelGeraCCe.AnalisaRetornoEnvioCCeCTe(ret, objbelPesqEnvio.CD_NOTAFIS);
                                KryptonMessageBox.Show(sMessage, Mensagens.CHeader, MessageBoxButtons.OK, MessageBoxIcon.Information);

                            }

                        }
                        PesquisaCartas();
                    }
                    else
                    {
                        KryptonMessageBox.Show("Não há Cartas de Correções válidas selecionadas!", Mensagens.MSG_Aviso, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                new HLPexception(ex);
            }
        }
        private void btnImpressao_Click(object sender, EventArgs e)
        {
            try
            {
                if ((bsGrid.DataSource as List<belPesquisaCCe>) != null)
                {

                    if ((bsGrid.DataSource as List<belPesquisaCCe>).Where(c => c.bSeleciona && c.QT_ENVIO > 0).Count() > 0)
                    {
                        belCarregaDataSet objbelCarregaDataSet = new belCarregaDataSet((bsGrid.DataSource as List<belPesquisaCCe>).Where(c => c.bSeleciona && c.QT_ENVIO > 0).ToList<belPesquisaCCe>());

                        string sCaminho = "";

                        if (Acesso.NM_RAMO != Acesso.BancoDados.TRANSPORTE)
                            sCaminho = Util.GetPathRelatorio("CCe.rpt");
                        else
                            sCaminho = Util.GetPathRelatorio("CCeCTe.rpt");
                        ReportDocument rpt = new ReportDocument();
                        rpt.Load(sCaminho);
                        DirectoryInfo dinfo = new DirectoryInfo(Pastas.CCe + "\\PDF");
                        if (!dinfo.Exists)
                        {
                            dinfo.Create();
                        }

                        string sCaminhoSave;
                        foreach (dsCCe ds in objbelCarregaDataSet.objListaDS)
                        {
                            sCaminhoSave = dinfo.FullName + "\\" + ds.CCe[0].NFE.ToString() + ".pdf";

                            rpt.SetDataSource(ds);
                            rpt.Refresh();
                            Util.ExportPDF(rpt, sCaminhoSave);
                        }

                        EnviaEmailCCe((bsGrid.DataSource as List<belPesquisaCCe>).Where(c => c.bSeleciona && c.QT_ENVIO > 0).ToList<belPesquisaCCe>());

                        rpt.Load(sCaminho);
                        rpt.Refresh();

                        frmRelatorio frm = new frmRelatorio(rpt, "Impressão de CC-e");
                        frm.Show();
                    }
                    else
                    {
                        KryptonMessageBox.Show("Não há Cartas de Correções válidas selecionadas!", Mensagens.MSG_Aviso, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        private void Navegacao_Click(object sender, EventArgs e)
        {
            try
            {
                ToolStripButton btn = (ToolStripButton)sender;
                if (btn.Name.Equals("btnFirst"))
                {
                    bsEvento.MoveFirst();
                }
                else if (btn.Name.Equals("btnLast"))
                {
                    bsEvento.MoveLast();
                }
                else if (btn.Name.Equals("btnNext"))
                {
                    bsEvento.MoveNext();
                }
                else if (btn.Name.Equals("btnPrevious"))
                {
                    bsEvento.MovePrevious();
                }
                PopulaTabVisualizacao(bsEvento.Current as belEvento);
            }
            catch (Exception ex)
            {
                new HLPexception(ex);
            }
        }
        #endregion


        #region Eventos
        private void txt_Validated(object sender, EventArgs e)
        {
            KryptonTextBox txt = (KryptonTextBox)sender;
            txt.Text = txt.Text.PadLeft(6, '0');
        }
        private void cboFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboFiltro.SelectedIndex == 0)
            {
                dtpFim.Visible = true;
                dtpIni.Visible = true;

                txtNfFim.Visible = false;
                txtNfIni.Visible = false;

                dtpIni.Focus();
            }
            else
            {
                dtpFim.Visible = false;
                dtpIni.Visible = false;

                txtNfFim.Visible = true;
                txtNfIni.Visible = true;
                txtNfIni.Focus();
            }
        }
        private void cboStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            sStatusPesquisa = cboStatus.Text;
        }


        private void tabCCe_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (tabCCe.SelectedIndex == 1)
                {
                    if (bsGrid.Count > 0)
                    {
                        if ((bsGrid.DataSource as List<belPesquisaCCe>).Where(c => c.bSeleciona).Count() > 0)
                        {
                            List<belPesquisaCCe> objLfiltro = ((bsGrid.DataSource as List<belPesquisaCCe>).Where(c => c.bSeleciona).ToList());
                            belGeraCCe objdaoGeraCCeVisual = new belGeraCCe(objLfiltro);
                            bsEvento.DataSource = objdaoGeraCCeVisual.objEnvEvento.evento;
                            if (bsEvento.Count > 0 || objdaoGeraCCeVisual.objEnvEvento != null)
                            {
                                if (Acesso.NM_RAMO != Acesso.BancoDados.TRANSPORTE)
                                    PopulaTabVisualizacao(bsEvento.Current as belEvento);
                                else
                                    PopulaTabVisualizacao(objdaoGeraCCeVisual.objEvCCeCTe);


                                if (bsEvento.Count == 1)
                                {
                                    btnFirst.Enabled = false;
                                    btnPrevious.Enabled = false;
                                    btnNext.Enabled = false;
                                    btnLast.Enabled = false;
                                }
                                else
                                {
                                    btnFirst.Enabled = true;
                                    btnPrevious.Enabled = true;
                                    btnNext.Enabled = true;
                                    btnLast.Enabled = true;
                                }
                            }
                        }
                        else
                        {
                            LimpaTabVisualizacao();
                        }
                    }
                    else
                    {
                        LimpaTabVisualizacao();
                    }
                }
            }
            catch (Exception ex)
            {
                new HLPexception(ex);
            }
        }

        private void dgvItens_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex > -1)
            {
                SendKeys.Send("{right}");
                SendKeys.Send("{left}");
            }
        }

        #endregion


    }
}