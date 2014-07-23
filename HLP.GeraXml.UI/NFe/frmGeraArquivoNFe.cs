using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using HLP.GeraXml.bel.NFe;
using System.Linq;
using System.Data.Entity;
using HLP.GeraXml.Comum.Static;
using HLP.GeraXml.Comum;
using HLP.GeraXml.bel.NFe.Estrutura;
using System.IO;
using HLP.GeraXml.Comum.DataSet;
using CrystalDecisions.CrystalReports.Engine;
using HLP.GeraXml.bel;
using System.Xml;
using System.Threading;
using HLP.GeraXml.dao;
using HLP.GeraXml.UI.Configuracao;

namespace HLP.GeraXml.UI.NFe
{
    public partial class frmGeraArquivoNFe : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        belPesquisaNotas belPesq = new belPesquisaNotas();

        TimerRetorno objTimerRetorno = new TimerRetorno();

        string sPathRestornos = Pastas.TIMER_RETORNOS + "Retornos_" + DateTime.Today.ToString("dd_MM_yyyy") + ".xml";

        TimeSpan tempoRestante;

        public bool bCD_NOTAFIS { get; set; }
        public bool bCD_NFSEQ { get; set; }
        public bool bDT_EMI { get; set; }
        public bool bVL_TOTNF { get; set; }


        public frmGeraArquivoNFe()
        {
            InitializeComponent();

            if (File.Exists(sPathRestornos))
            {
                objTimerRetorno = belSerializeToXml.DeserializeClasse<TimerRetorno>(sPathRestornos);
            }
            DirectoryInfo dinfo = new DirectoryInfo(Pastas.TIMER_RETORNOS);
            foreach (FileInfo item in dinfo.GetFiles("*.xml"))
            {
                if (item.CreationTime != DateTime.Today)
                {
                    item.Delete();
                }
            }

        }

        private void frmGeraArquivoNFe_Load(object sender, EventArgs e)
        {
            txtNfIni.txt.KeyPress += new KeyPressEventHandler(txt_KeyPress);
            txtNfFim.txt.KeyPress += new KeyPressEventHandler(txt_KeyPress);

            txtNfIni.txt.Validated += new EventHandler(txt_Validated);
            txtNfFim.txt.Validated += new EventHandler(txt_Validated);

            cboFiltro.cbx.SelectedIndexChanged += new EventHandler(cbx_SelectedIndexChanged);
            cboFiltro.SelectedIndex = 0;
            cboStatus.SelectedIndex = 1;

            dtpFim.Value = dtpIni.Value = DateTime.Now;
            ConfiguraMenuStrip();
        }


        #region Eventos

        private void cbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtCliente.Visible = false;
            if (cboFiltro.SelectedIndex == 0)
            {
                txtNfIni.Visible = false;
                txtNfFim.Visible = false;

                dtpIni.Visible = true;
                dtpFim.Visible = true;
            }
            else if (cboFiltro.SelectedIndex == 1)
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
            else if (cboFiltro.SelectedIndex == 3)
            {
                txtNfIni.Visible = true;
                txtNfFim.Visible = true;

                dtpIni.Visible = false;
                dtpFim.Visible = false;
            }
        }
        private void txt_Validated(object sender, EventArgs e)
        {
            KryptonTextBox txt = (KryptonTextBox)sender;
            txt.Text = txt.Text.PadLeft(6, '0');
        }
        private void txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void dgvArquivos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.RowIndex > -1) && (e.ColumnIndex == 0))
            {
                SendKeys.Send("{right}");
                SendKeys.Send("{left}");
            }
        }
        bool bMarcar = false;
        private void dgvArquivos_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (dgvArquivos.Rows.Count > 0)
                {
                    if (e.ColumnIndex == 0 && bsNotas.DataSource != null)
                    {

                        bMarcar = !bMarcar;
                        foreach (belPesquisaNotas nota in bsNotas.List)
                        {
                            nota.bSeleciona = bMarcar;
                        }

                        dgvArquivos.Refresh();
                        if (dgvArquivos.CurrentCell != null)
                        {
                            if (dgvArquivos.CurrentCell.ColumnIndex == 0)
                            {
                                SendKeys.Send("{right}");
                                SendKeys.Send("{left}");
                            }
                        }
                    }
                    else if (e.ColumnIndex == 1)
                    {
                        if (!bCD_NOTAFIS)
                            bsNotas.DataSource = belPesq.lResultPesquisa.OrderByDescending(C => C.sCD_NOTAFIS);
                        else
                            bsNotas.DataSource = belPesq.lResultPesquisa.OrderBy(C => C.sCD_NOTAFIS);

                        ColoriGrid();
                        bCD_NOTAFIS = !bCD_NOTAFIS;
                    }
                    else if (e.ColumnIndex == 2)
                    {
                        if (bCD_NFSEQ)
                            bsNotas.DataSource = belPesq.lResultPesquisa.OrderByDescending(C => C.sCD_NFSEQ);
                        else
                            bsNotas.DataSource = belPesq.lResultPesquisa.OrderBy(C => C.sCD_NFSEQ);

                        ColoriGrid();
                        bCD_NFSEQ = !bCD_NFSEQ;
                    }
                    else if (e.ColumnIndex == 3)
                    {
                        bsNotas.DataSource = belPesq.lResultPesquisa.OrderBy(C => C.sCD_GRUPONF);
                        ColoriGrid();
                    }
                    else if (e.ColumnIndex == 4)
                    {
                        if (bDT_EMI)
                            bsNotas.DataSource = belPesq.lResultPesquisa.OrderByDescending(C => C.dDT_EMI);
                        else
                            bsNotas.DataSource = belPesq.lResultPesquisa.OrderBy(C => C.dDT_EMI);
                        ColoriGrid();
                        bDT_EMI = !bDT_EMI;
                    }
                    else if (e.ColumnIndex == 5)
                    {
                        if (bVL_TOTNF)
                            bsNotas.DataSource = belPesq.lResultPesquisa.OrderByDescending(C => C.dVL_TOTNF);
                        else
                            bsNotas.DataSource = belPesq.lResultPesquisa.OrderBy(C => C.dVL_TOTNF);
                        ColoriGrid();
                        bVL_TOTNF = !bVL_TOTNF;
                    }
                    else if (e.ColumnIndex == 6)
                    {
                        if (dgvArquivos.Columns[e.ColumnIndex].Tag == null)
                        {
                            dgvArquivos.Columns[e.ColumnIndex].Tag = true;
                        }
                        if (Convert.ToBoolean(dgvArquivos.Columns[e.ColumnIndex].Tag.ToString()))
                        {
                            bsNotas.DataSource = belPesq.lResultPesquisa.OrderBy(C => C.sNM_CLIFOR);
                        }
                        else
                        {
                            bsNotas.DataSource = belPesq.lResultPesquisa.OrderByDescending(C => C.sNM_CLIFOR);
                        }
                        ColoriGrid();
                        dgvArquivos.Columns[e.ColumnIndex].Tag = !Convert.ToBoolean(dgvArquivos.Columns[e.ColumnIndex].Tag.ToString());
                    }
                    else if (e.ColumnIndex == 7)
                    {
                        if (dgvArquivos.Columns[e.ColumnIndex].Tag == null)
                        {
                            dgvArquivos.Columns[e.ColumnIndex].Tag = true;
                        }
                        if (Convert.ToBoolean(dgvArquivos.Columns[e.ColumnIndex].Tag.ToString()))
                        {
                            bsNotas.DataSource = belPesq.lResultPesquisa.OrderBy(C => C.sNM_GUERRA);
                        }
                        else
                        {
                            bsNotas.DataSource = belPesq.lResultPesquisa.OrderByDescending(C => C.sNM_GUERRA);
                        }
                        ColoriGrid();
                        dgvArquivos.Columns[e.ColumnIndex].Tag = !Convert.ToBoolean(dgvArquivos.Columns[e.ColumnIndex].Tag.ToString());
                    }
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
            PesquisaNotas();
        }
        private void btnEnvio_Click(object sender, EventArgs e)
        {
            EnviarNFe();
        }


        public void EnviarNFe()
        {
            List<belPesquisaNotas> objSelect = BuscaNotasSelecionadas().Where(c =>
                                                                   c.bEnviado == false &&
                                                                   c.bDenegada == false &&
                                                                   c.bCancelado == false &&
                                                                   c.sRECIBO_NF == "").ToList<belPesquisaNotas>();
            try
            {

                frmEnviaLotes objfrmLotes = null;
                if (objSelect.Count() > 0)
                {

                    belCarregaDados objbelCarregaDados = null;

                    if (objSelect.Where(c => c.sCD_NOTAFIS == "").Count() > 0)
                    {
                        belNumeroNF objbelNumeracao = new belNumeroNF(objSelect.Where(c => c.sCD_NOTAFIS == "").ToList());
                        frmGeraNumeracaoNFe objfrmGeraNumeracao = new frmGeraNumeracaoNFe(objbelNumeracao, false);
                        if (Acesso.TP_EMIS == 3)
                        {
                            if (String.IsNullOrEmpty(Acesso.GRUPO_SCAN))
                            {
                                throw new Exception("Sistema em modo SCAN, configure um grupo de faturamento para utilizar com a série 900");
                            }
                            else
                            {
                                objfrmGeraNumeracao.cbxGrupos.cbx.SelectedValue = Acesso.GRUPO_SCAN;
                            }
                        }
                        else
                        {
                            if (String.IsNullOrEmpty(objbelNumeracao.sGrupoNF))
                            {
                                throw new Exception("Nota fiscal sem grupo de Faturamento salvo, Impossível gerar numeração.");
                            }
                            else
                            {
                                objfrmGeraNumeracao.cbxGrupos.cbx.SelectedValue = objbelNumeracao.sGrupoNF;
                            }
                        }
                        objfrmGeraNumeracao.ShowDialog();
                        if (!objfrmGeraNumeracao.bGerou)
                        {
                            throw new Exception("Transmissão de Notas abortada");
                        }

                        //Thread workThread = new Thread(objbelNumeracao.AlteraDuplicatasNFe);
                        //workThread.Start();
                        //while (!workThread.IsAlive) ;

                    }
                    if (objSelect.Where(c => c.bContingencia).Count() > 1)
                    {
                        throw new Exception("Selecione uma nota de cada vez quando houver notas de contingêcia a ser enviada.");
                    }
                    else if ((objSelect.Where(c => c.bContingencia).Count() == 1))
                    {
                        if (objSelect.Count() > 1)
                        {
                            throw new Exception("Selecione uma nota de cada vez quando houver notas de contingêcia a ser enviada.");
                        }
                        else
                        {
                            objbelCarregaDados = new belCarregaDados();
                            DirectoryInfo dinfo = new DirectoryInfo(Pastas.CONTINGENCIA);
                            FileInfo[] files = dinfo.GetFiles("*.xml");
                            string sPath = string.Empty;
                            XmlDocument xml = new XmlDocument();
                            foreach (FileInfo f in files)
                            {
                                if (f.Name.Length == 26)
                                {
                                    xml.Load(f.FullName);
                                    if (xml.GetElementsByTagName("infNFe")[0].Attributes["Id"].Value.ToString().Replace("NFe", "").Equals(objSelect.FirstOrDefault().sCHAVENFE))
                                    {
                                        sPath = f.FullName;
                                        string sPathDest = Pastas.ENVIO + "\\" + f.Name;
                                        string sPathOrigem = Pastas.CONTINGENCIA + "\\" + f.Name;
                                        if (File.Exists(sPathDest))
                                        {
                                            File.Delete(sPathDest);
                                        }
                                        File.Copy(sPathOrigem, sPathDest);
                                    }
                                }
                                else if (f.Name.Length == 52)
                                {
                                    if (f.Name.Replace("-nfe.xml", "") == objSelect.FirstOrDefault().sCHAVENFE)
                                    {
                                        string sPathDest = Pastas.ENVIO + "\\" + objSelect.FirstOrDefault().sCHAVENFE.Substring(2, 4) + "\\" + objSelect.FirstOrDefault().sCHAVENFE + "-nfe.xml";
                                        string sPathOrigem = Util.BuscaCaminhoArquivoXml(objSelect.FirstOrDefault().sCHAVENFE, 3);
                                        if (File.Exists(sPathDest))
                                        {
                                            File.Delete(sPathDest);
                                        }
                                        File.Copy(sPathOrigem, sPathDest);
                                    }
                                }
                            }
                            if (sPath == "")
                            {
                                throw new Exception("Arquivo xml do Lote não foi encontrado na pasta de Contingência.");
                            }
                            objbelCarregaDados.objbelRecepcao.TransmitirLote(sPath, objSelect);
                        }
                    }
                    else
                    {

                        objSelect = ConsultaClienteBeforeEnvio(objSelect);

                        if (objSelect.Count() > 0)
                        {
                            objfrmLotes = new frmEnviaLotes(objSelect);
                            objfrmLotes.ShowDialog();

                            //objbelCarregaDados = new belCarregaDados(objSelect);
                            //frmVisualizaNFe objfrmVisualizaNFe = new frmVisualizaNFe(objbelCarregaDados);
                            //objfrmVisualizaNFe.ShowDialog();
                            //if (objfrmVisualizaNFe.Cancelado)
                            //{
                            //    throw new Exception("Envio da(s) Nota(s) Cancelado");
                            //}
                            //objbelCarregaDados.objbelCriaXml.GeraLoteXmlEnvio();

                            //objbelCarregaDados.objbelRecepcao.TransmitirLote(objbelCarregaDados.objbelCriaXml.sPathLote, objSelect);
                            if (objfrmLotes.bCancelado == true)
                            {
                                throw new Exception("Envio da(s) Nota(s) Cancelado.");
                            }
                        }
                    }

                    if (objfrmLotes == null)
                    {
                        if (objSelect.Count() > 0)
                        {
                            belBusRetFazenda objbelRetFazenda = new belBusRetFazenda(objSelect);
                            frmBuscaRetorno objFrmBuscaRet = new frmBuscaRetorno(objbelRetFazenda);
                            objFrmBuscaRet.ShowDialog();
                            KryptonMessageBox.Show(belTrataMensagemNFe.RetornaMensagem(objbelRetFazenda.lDadosRetorno, belTrataMensagemNFe.Tipo.Envio), Mensagens.CHeader, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            cboStatus.cbx.SelectedIndex = 2;
                            PesquisaNotas();

                            List<string> lsNotas = objbelRetFazenda.lDadosRetorno.Select(c => c.seqNota).ToList<string>();
                            List<belPesquisaNotas> dados = (from c in ((List<belPesquisaNotas>)bsNotas.DataSource)
                                                            where lsNotas.Contains(c.sCD_NFSEQ)
                                                            select c).ToList();
                            bsNotas.DataSource = dados;
                        }
                    }
                    else
                    {
                        cboStatus.cbx.SelectedIndex = 2;
                        PesquisaNotas();
                        if (objfrmLotes != null)
                        {
                            List<string> lsNotas = objfrmLotes.lDadosRetorno.Select(c => c.seqNota).ToList<string>();
                            List<belPesquisaNotas> dados = (from c in ((List<belPesquisaNotas>)bsNotas.DataSource)
                                                            where lsNotas.Contains(c.sCD_NFSEQ)
                                                            select c).ToList();
                            bsNotas.DataSource = dados;
                        }

                    }
                    cboStatus.cbx.SelectedIndex = 1;
                    ColoriGrid();
                    ValidaContadorBuscaRetorno();
                }
            }
            catch (Exception ex)
            {
                new HLPexception(ex);
                cboStatus.cbx.SelectedIndex = 1;
                PesquisaNotas();
            }
        }
        private void btnContingencia_Click(object sender, EventArgs e)
        {
            List<belPesquisaNotas> objSelect = BuscaNotasSelecionadas().Where(c =>
                                                                  c.bEnviado == false &&
                                                                  c.bDenegada == false &&
                                                                  c.bCancelado == false &&
                                                               c.sRECIBO_NF == "").ToList<belPesquisaNotas>();
            try
            {
                if (objSelect.Count() > 0)
                {

                    if (objSelect.Where(c => c.sCD_NOTAFIS == "").Count() > 0)
                    {
                        belNumeroNF objbelNumeracao = new belNumeroNF(objSelect.Where(c => c.sCD_NOTAFIS == "").ToList());
                        frmGeraNumeracaoNFe objfrmGeraNumeracao = new frmGeraNumeracaoNFe(objbelNumeracao, false);
                        objfrmGeraNumeracao.ShowDialog();
                        if (!objfrmGeraNumeracao.bGerou)
                        {
                            throw new Exception("Transmissão de Notas abortada");
                        }
                    }
                    belCarregaDados objbelCarregaDados = new belCarregaDados(objSelect);
                    objbelCarregaDados.CarregaDados();
                    frmVisualizaNFe objfrmVisualizaNFe = new frmVisualizaNFe(objbelCarregaDados.lNotas);
                    objfrmVisualizaNFe.ShowDialog();
                    if (objfrmVisualizaNFe.Cancelado)
                    {
                        throw new Exception("Envio da(s) Nota(s) Cancelado");
                    }
                    objbelCarregaDados.objbelCriaXml.GeraLoteXmlEnvio();

                    foreach (belPesquisaNotas item in objSelect)
                    {
                        item.AlteraStatusNotaParaContingenciaFS();
                    }
                    KryptonMessageBox.Show(belTrataMensagemNFe.RetornaMensagem(objSelect, belTrataMensagemNFe.Tipo.ContingenciaFS), Mensagens.CHeader, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    PesquisaNotas();
                }
            }
            catch (Exception ex)
            {
                new HLPexception(ex);
            }

        }
        private void btnCancelamento_Click(object sender, EventArgs e)
        {
            try
            {
                List<belPesquisaNotas> objSelect = BuscaNotasSelecionadas().Where(c => c.bEnviado && c.bCancelado == false).ToList<belPesquisaNotas>();

                if (objSelect.Count == 1)
                {
                    if (!daoUtil.ValidaUserToCancel())
                    {
                        if (KryptonMessageBox.Show(null, "Usuário não tem Acesso para Alterar dados da Nota Fiscal" +
                         Environment.NewLine +
                         Environment.NewLine +
                         "Deseja entrar com a Permissão de um Outro Usuário? ", Mensagens.MSG_Aviso,
                          MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            frmLogin objfrm = new frmLogin();
                            objfrm.ShowDialog();
                            if (daoUtil.ValidaUserToCancel())
                            {
                                frmCancelamentoNFe objfrmCanc = new frmCancelamentoNFe(objSelect[0]);
                                objfrmCanc.ShowDialog();
                            }
                            else
                            {
                                KryptonMessageBox.Show(null, "Usuário também não tem Permissão Para Alterar Dados da Nota Fiscal", Mensagens.MSG_Aviso, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                    else
                    {
                        frmCancelamentoNFe objfrmCanc = new frmCancelamentoNFe(objSelect[0]);
                        objfrmCanc.ShowDialog();
                    }


                }
                else if (objSelect.Count > 1)
                {
                    KryptonMessageBox.Show("Selecione apenas uma nota para cancelamento.", Mensagens.CHeader, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    KryptonMessageBox.Show("Nenhuma Nota válida foi selecionada para cancelamento.", Mensagens.CHeader, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                PesquisaNotas();
            }
            catch (Exception ex)
            {
                new HLPexception(ex);
            }
        }

        private void btnBuscaRetorno_Click(object sender, EventArgs e)
        {
            try
            {
                List<belPesquisaNotas> objSelect = BuscaNotasSelecionadas().Where(c =>
                                                                 c.sRECIBO_NF != "").ToList<belPesquisaNotas>();

                if (objSelect.Count() == 1)
                {
                    if (ValidaBuscaRetorno(objSelect))
                    {
                        //objSelect = ((List<belPesquisaNotas>)bsNotas.List).Where(c => c.sRECIBO_NF == objSelect.FirstOrDefault().sRECIBO_NF).ToList<belPesquisaNotas>();
                        belBusRetFazenda objbelRetFazenda = new belBusRetFazenda(objSelect);
                        frmBuscaRetorno objFrmBuscaRet = new frmBuscaRetorno(objbelRetFazenda);
                        objFrmBuscaRet.ShowDialog();
                        KryptonMessageBox.Show(belTrataMensagemNFe.RetornaMensagem(objbelRetFazenda.lDadosRetorno, belTrataMensagemNFe.Tipo.Envio), Mensagens.CHeader, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        PesquisaNotas();
                        ValidaContadorBuscaRetorno();
                    }
                }
                else if (objSelect.Count() > 1)
                {
                    throw new Exception("Selecione apenas uma Nota para Buscar o Retorno");
                }
                else if (objSelect.Count() == 1)
                {
                    throw new Exception("Nenhum registro válido foi selecionado. A provávelmente não tem recibo de retorno salvo na Base de Dados.");
                }
            }
            catch (Exception ex)
            {
                new HLPexception(ex);
            }

        }

        private bool ValidaBuscaRetorno(List<belPesquisaNotas> objSelect)
        {
            try
            {
                bool bvalida = true;
                Recibos recibo;
                if (objTimerRetorno.lRecibos.Where(c => c.cd_recibo == objSelect.First().sRECIBO_NF).Count() > 0)
                {
                    recibo = objTimerRetorno.lRecibos.FirstOrDefault(c => c.cd_recibo == objSelect.First().sRECIBO_NF);

                    if (recibo.dataHora.AddMinutes(3) > DateTime.Now)
                    {
                        bvalida = false;
                    }
                    else
                    {
                        recibo.dataHora = DateTime.Now;
                    }
                }
                else
                {
                    recibo = new Recibos();
                    recibo.cd_recibo = objSelect.First().sRECIBO_NF;
                    recibo.dataHora = DateTime.Now;
                    objTimerRetorno.lRecibos.Add(recibo);
                }
                belSerializeToXml.SerializeClasse<TimerRetorno>(objTimerRetorno, sPathRestornos);
                return bvalida;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void btnConsultaNFe_Click(object sender, EventArgs e)
        {
            try
            {
                List<belPesquisaNotas> objSelect = BuscaNotasSelecionadas();
                foreach (belPesquisaNotas item in objSelect)
                {
                    if (item.sCHAVENFE != "" && item.bEnviado)
                    {
                        belConsultaStatusNota objConsulta = new belConsultaStatusNota(item);
                        KryptonMessageBox.Show(belTrataMensagemNFe.RetornaMensagem(objConsulta.buscaRetorno(), belTrataMensagemNFe.Tipo.Situacao), Mensagens.CHeader, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                PesquisaNotas();
            }
            catch (Exception ex)
            {
                new HLPexception(ex);
            }
        }
        private void btnConsultaSituacao_Click(object sender, EventArgs e)
        {
            try
            {
                List<belPesquisaNotas> objSelect = BuscaNotasSelecionadas();

                if (objSelect.Count == 1)
                {
                    belConsultaStatusCliente objbelConsulta = new belConsultaStatusCliente(objSelect[0]);
                    KryptonMessageBox.Show(belTrataMensagemNFe.RetornaMensagem(objbelConsulta.ConsultaCadastro(), belTrataMensagemNFe.Tipo.SituacaoCadastral), Mensagens.CHeader, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (objSelect.Count > 1)
                {
                    KryptonMessageBox.Show("Selecione apenas uma nota para consultar a situação do cliente.", Mensagens.CHeader, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    KryptonMessageBox.Show("Nenhuma Nota válida foi selecionada para consulta.", Mensagens.CHeader, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                new HLPexception(ex);
            }

        }

        public List<belPesquisaNotas> ConsultaClienteBeforeEnvio(List<belPesquisaNotas> objSelect)
        {
            try
            {

                List<belPesquisaNotas> lret = new List<belPesquisaNotas>();
                belConsultaStatusCliente objbelConsulta;
                string sMessage = string.Empty;
                foreach (var item in objSelect)
                {
                    try
                    {
                        objbelConsulta = new belConsultaStatusCliente(item);
                        HLP.GeraXml.bel.NFe.belConsultaStatusCliente.DadosRetorno o = objbelConsulta.ConsultaCadastro();

                        if (o.cStat == "111")
                        {
                            if (!o.cSit.ToString().ToUpper().Contains("NÃO"))
                            {
                                lret.Add(item);
                            }
                            else
                            {
                                sMessage += string.Format("Sequencia: {0} - Cliente:{1}, status{2} - Motivo:{3}{4}", item.sCD_NFSEQ,
                                    item.sNM_CLIFOR,
                                    o.cStat,
                                    o.cSit, Environment.NewLine);
                            }
                        }
                        else
                        {
                            lret.Add(item);
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
                if (sMessage != "")
                {
                    sMessage = "Consulta realizada no sefaz aponta que o(s) cliente(s) listado(s) abaixo não possuem situação cadastral habilitada." + Environment.NewLine +
                        "Impossível emissão de NF-e para o(s) mesmo(s), até sua regularização!"
                        + Environment.NewLine + Environment.NewLine
                        + sMessage;

                    MessageBox.Show(sMessage, "A V I S O", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                return lret;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        #endregion


        #region Metodos

        public class DadosImpressao
        {
            public string sCaminhoXml { get; set; }

            public string sCaminhoPDF
            {
                get
                {
                    string sTipoDanfe = "";
                    if (Convert.ToBoolean(Acesso.USA_DANFE_SIMPLIFICADA))
                    {
                        sTipoDanfe = "_Simplificada";
                    }
                    else
                    {
                        sTipoDanfe = "_" + Acesso.TIPO_IMPRESSAO;
                    }
                    return string.Format((Pastas.ENVIADOS + "\\PDF\\{0}{1}{2}_{3}.pdf"), this.sCD_NOTAFIS.ToString().PadLeft(6, '0'), "_" + this.tipo.ToString(), sTipoDanfe, this.sNUM_GRUPO);
                }
            }
            public bool Cancelado = false;
            public string sCD_NFSEQ { get; set; }
            public string sCD_NOTAFIS { get; set; }
            public string sNUM_GRUPO { get; set; }
            public TipoPDF tipo { get; set; }
            private string _xStatus = "Aguardando início do processo...";

            public string xStatus
            {
                get { return _xStatus; }
                set { _xStatus = value; }
            }
        }
        public enum TipoPDF { ENVIADO, CANCELADO, CONTINGENCIA };

        private List<belPesquisaNotas> BuscaNotasSelecionadas()
        {
            try
            {
                IEnumerable<belPesquisaNotas> dados = bsNotas.List as IEnumerable<belPesquisaNotas>;
                List<belPesquisaNotas> objSelect = dados.Where(c => c.bSeleciona).ToList<belPesquisaNotas>();
                return objSelect;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

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
            belPesquisaNotas.Filtro filtro = new belPesquisaNotas.Filtro();
            string sValor1 = string.Empty;
            string sValor2 = string.Empty;

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

            belPesq = new belPesquisaNotas(st,
                                                           filtro,
                                                           sValor1,
                                                           sValor2);

            bsNotas.DataSource = belPesq.lResultPesquisa;



            ColoriGrid();
        }

        private void ColoriGrid()
        {
            if (dgvArquivos.Rows.Count > 0)
            {
                for (int i = 0; i < dgvArquivos.RowCount; i++)
                {
                    if (Convert.ToBoolean(dgvArquivos["bCancelado", i].Value) == true)
                    {
                        dgvArquivos.Rows[i].DefaultCellStyle.BackColor = Color.Khaki;
                    }
                    else if (Convert.ToBoolean(dgvArquivos["bDenegada", i].Value) == true)
                    {
                        dgvArquivos.Rows[i].DefaultCellStyle.BackColor = Color.Silver;
                    }
                    else if (Convert.ToBoolean(dgvArquivos["bEnviado", i].Value) == true)
                    {
                        dgvArquivos.Rows[i].DefaultCellStyle.BackColor = Color.LightGreen;
                    }
                    else if (Convert.ToBoolean(dgvArquivos["bEnviado", i].Value) == false && Convert.ToBoolean(dgvArquivos["bContingencia", i].Value) == true)
                    {
                        dgvArquivos.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                    }
                    else if (Convert.ToBoolean(dgvArquivos["bEnviado", i].Value) == false && dgvArquivos["sRECIBO_NF", i].Value.ToString() != "")
                    {
                        dgvArquivos.Rows[i].DefaultCellStyle.BackColor = Color.LightCyan;
                    }
                }
                lblTotalRegistros.Text = bsNotas.Count + " Registro(s) encontrado(s)";
                dgvArquivos.Refresh();
            }
        }

        private void ConfiguraMenuStrip()
        {
            if (Acesso.TP_EMIS != 2)
            {
                tseparadorContingencia.Visible = false;
                btnContingencia.Visible = false;
            }
            else
            {
                btnEnvio.Enabled = false;
                btnCancelamento.Enabled = false;
                btnBuscaRetorno.Enabled = false;
                btnConsultaNFe.Enabled = false;
                btnConsultaSituacao.Enabled = false;

            }
        }

        #endregion

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                TimeSpan subtraiSeg = new TimeSpan(0, 0, 1);
                tempoRestante = tempoRestante.Subtract(subtraiSeg);
                pbMinutos.PerformStep();
                pbMinutos.Visible = true;
                lblMinutos.Text = "Aguarde " + (DateTime.Today + tempoRestante).ToString("mm:ss") + " para buscar retorno";
                if (tempoRestante.Minutes == 0 && tempoRestante.Seconds == 0)
                {
                    timer1.Stop();
                    pbMinutos.Visible = false;
                    lblMinutos.Text = "";
                }

            }
            catch (Exception ex)
            {
                new HLPexception(ex);
            }
        }

        private void bsNotas_PositionChanged(object sender, EventArgs e)
        {
            ValidaContadorBuscaRetorno();
        }

        private void ValidaContadorBuscaRetorno()
        {
            try
            {
                timer1.Stop();
                lblMinutos.Text = "";
                pbMinutos.Visible = false;
                btnBuscaRetorno.Enabled = true;
                belPesquisaNotas nota = bsNotas.Current as belPesquisaNotas;

                if (nota != null)
                {

                    if (nota.sRECIBO_NF != "")
                    {
                        Recibos recibo;
                        if (objTimerRetorno.lRecibos.Where(c => c.cd_recibo == nota.sRECIBO_NF).Count() > 0)
                        {
                            recibo = objTimerRetorno.lRecibos.FirstOrDefault(c => c.cd_recibo == nota.sRECIBO_NF);

                            if (recibo.dataHora.AddMinutes(3) > DateTime.Now)
                            {
                                tempoRestante = (recibo.dataHora.AddMinutes(3) - DateTime.Now);
                                pbMinutos.Maximum = 180;
                                pbMinutos.Value = (180 - ((tempoRestante.Minutes * 60) + tempoRestante.Seconds));
                                pbMinutos.Step = 1;
                                timer1.Interval = 1000;
                                timer1.Start();
                                btnBuscaRetorno.Enabled = false;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                new HLPexception(ex);
            }
        }

        private void btnImpressao2_Click(object sender, EventArgs e)
        {
            try
            {
                List<DadosImpressao> objListDadosImpressao = new List<DadosImpressao>();
                string sPastaMes = "";
                List<belPesquisaNotas> objSelecionadas = belPesq.lResultPesquisa.Where(c => c.bSeleciona).ToList<belPesquisaNotas>();
                List<belPesquisaNotas> objSelect = objSelecionadas.Where(c =>
                                                                   c.bEnviado == true ||
                                                                   c.bCancelado == true ||
                                                                   c.bContingencia == true).ToList<belPesquisaNotas>();

                if (objSelect.Count() > 0)
                {
                    if (Acesso.NM_EMPRESA == "MASTERFEW")
                    {
                        int iCountNotaNETSHOES = objSelect.Where(C => C.sNM_GUERRA.ToUpper().Contains("NETSHOES")).Count();

                        if (iCountNotaNETSHOES > 0)
                        {
                            if (iCountNotaNETSHOES != objSelect.Count())
                            {
                                throw new Exception("Notas para o cliente NETSHOES devem ser impressas individualmente.");
                            }

                        }
                    }

                    foreach (belPesquisaNotas nota in objSelect)
                    {
                        DadosImpressao objDados = new DadosImpressao();
                        objDados.sCD_NFSEQ = nota.sCD_NFSEQ;
                        objDados.sCD_NOTAFIS = nota.sCD_NOTAFIS;
                        objDados.sNUM_GRUPO = nota.sCD_GRUPONF;

                        #region Busca os Arquivos selecionados

                        sPastaMes = nota.sCHAVENFE.Substring(2, 4);
                        string sCaminho = "";
                        if (nota.bContingencia)
                        {
                            sCaminho = Pastas.CONTINGENCIA + "\\" + nota.sCHAVENFE + "-nfe.xml";
                            objDados.tipo = TipoPDF.CONTINGENCIA;
                        }
                        else
                        {
                            if (nota.bCancelado)
                            {
                                sCaminho = Pastas.CANCELADOS + "\\" + sPastaMes + "\\" + nota.sCHAVENFE + "-can.xml.xml";
                                objDados.Cancelado = true;
                                objDados.tipo = TipoPDF.CANCELADO;
                            }
                            else
                            {
                                sCaminho = Pastas.ENVIADOS + sPastaMes + "\\" + nota.sCHAVENFE + "-nfe.xml";
                                objDados.tipo = TipoPDF.ENVIADO;
                            }
                        }
                        if (File.Exists(sCaminho))
                        {
                            objDados.sCaminhoXml = sCaminho;
                            objListDadosImpressao.Add(objDados);
                        }
                        else
                        {
                            throw new Exception("Arquivo Xml da NF-e nº " + nota.sCD_NOTAFIS + " não foi encontrado.");
                        }

                        #endregion
                    }



                    if (objListDadosImpressao.Count() > 0)
                    {
                        frmCarregaDadosParaVisualizarDanfe objfrmCarregar = new frmCarregaDadosParaVisualizarDanfe(objListDadosImpressao);
                        objfrmCarregar.ShowDialog();
                    }
                }
                else
                {
                    KryptonMessageBox.Show("Nenhuma nota Válida foi Selecionada", Mensagens.MSG_Aviso, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                new HLPexception(ex);
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {

        }
    }
}