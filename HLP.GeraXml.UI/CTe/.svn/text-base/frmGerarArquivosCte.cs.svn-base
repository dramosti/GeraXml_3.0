using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using HLP.GeraXml.Comum.Static;
using HLP.GeraXml.bel.CTe;
using HLP.GeraXml.Comum;
using HLP.GeraXml.dao.CTe;
using System.Security.Cryptography.X509Certificates;
using HLP.GeraXml.bel;
using System.Linq;
using System.Xml;
using System.IO;
using HLP.GeraXml.Comum.DataSet;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using HLP.GeraXml.dao;

namespace HLP.GeraXml.UI.CTe
{
    public partial class frmGerarArquivosCte : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        belCriaXml objCriaXml = new belCriaXml();
        belGravaDadosRetorno objGravaDadosRetorno = new belGravaDadosRetorno();
        daoBuscaDadosGerais objGerais = new daoBuscaDadosGerais();
        List<string> Pendencias = new List<string>();
        List<string> slistaConhec = new List<string>();



        public frmGerarArquivosCte()
        {
            InitializeComponent();
            VerificaGeneratorLote();

        }

        private void frmGerarArquivosCte_Load(object sender, EventArgs e)
        {

            txtNfIni.txt.KeyPress += new KeyPressEventHandler(txt_KeyPress);
            txtNfFim.txt.KeyPress += new KeyPressEventHandler(txt_KeyPress);

            txtNfIni.txt.Validated += new EventHandler(txt_Validated);
            txtNfFim.txt.Validated += new EventHandler(txt_Validated);

            cboFiltro.cbx.SelectedIndexChanged += new EventHandler(cbx_SelectedIndexChanged);
            cboFiltro.SelectedIndex = 0;
            cboStatus.SelectedIndex = 1;

            if (Acesso.TP_EMIS == 1)
            {
                toolStripSeparator2.Visible = btnContingencia.Visible = false;
                toolStripSeparator3.Visible = btnEnvio.Visible = true;
                toolStripSeparator1.Visible = btnCancelamento.Visible = true;
                toolStripSeparator7.Visible = btnBuscaRetorno.Visible = true;
                btnConsultaSituacao.Visible = true;
            }
            else
            {
                toolStripSeparator2.Visible = btnContingencia.Visible = true;
                toolStripSeparator3.Visible = btnEnvio.Visible = false;
                toolStripSeparator1.Visible = btnCancelamento.Visible = false;
                toolStripSeparator7.Visible = btnBuscaRetorno.Visible = false;
                btnConsultaSituacao.Visible = false;
            }
            DirectoryInfo info = new DirectoryInfo(Pastas.CBARRAS);
            LimparPasta(info);
            if (Acesso.TP_EMIS == 1)
            {
                VerificaPendenciasContingencia();
                if (Pendencias.Count() > 0)
                {
                    KryptonMessageBox.Show("Existem " + Pendencias.Count.ToString() + " Conhecimentos Pendentes de Envio!", Mensagens.CHeader, MessageBoxButtons.OK, MessageBoxIcon.Warning); ;
                }
            }
            dtpIni.Value = DateTime.Now;
            dtpFim.Value = DateTime.Now;
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
        private void txt_Validated(object sender, EventArgs e)
        {
            KryptonTextBox txt = (KryptonTextBox)sender;
            txt.Text = txt.Text.PadLeft(7, '0');
        }
        private void txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }



        #region Botoes

        private class DadosImpressao
        {
            public string sCaminhoXml;
            public string sCaminhoPDF;
            public bool bArquivoEncontrado = false;
            public bool Cancelado = false;
            public string sNumeroCte;
            public string sProtocolo;
        }

        private void btnPesquisa_Click(object sender, EventArgs e)
        {
            PesquisaConhecimentos();
        }
        private void btnEnvio_Click(object sender, EventArgs e)
        {
            try
            {
                bool bContingencia = false;

                #region Verifica se Item Selecionado já  foi enviado

                for (int i = 0; i < dgvArquivos.RowCount; i++)
                {
                    if (dgvArquivos["cl_assina", i].Value != null)
                    {
                        if (dgvArquivos["cl_assina", i].Value.ToString().Equals("True"))
                        {
                            if (objGerais.VerificaCampoReciboPreenchido(dgvArquivos["nr_lanc", i].Value.ToString()) != "")
                            {
                                throw new Exception("O Conhecimento de Sequência " + dgvArquivos["nr_lanc", i].Value.ToString() + " Já tem um recibo Salvo no Banco de Dados, tente Buscar Retorno.");
                            }
                        }
                    }
                }
                #endregion

                #region Pega Notas Selecionadas na Grid

                string sCanceladas = "";
                slistaConhec = new List<string>();
                for (int i = 0; i < dgvArquivos.RowCount; i++)
                {
                    if (((dgvArquivos["cl_assina", i].Value != null) && (dgvArquivos["cl_assina", i].Value.ToString().Equals("True")))
                                && ((dgvArquivos["ds_cancelamento", i].Value == null) || (dgvArquivos["ds_cancelamento", i].Value.ToString() == "0"))
                                && (dgvArquivos["st_cte", i].Value.ToString().Equals("0")))
                    {
                        if (Convert.ToBoolean(dgvArquivos["st_cte", i].Value) == false && Convert.ToBoolean(dgvArquivos["st_contingencia", i].Value) == true)
                        {
                            bContingencia = true;
                            if (slistaConhec.Count() > 0)
                            {
                                throw new Exception("Os Conhecimentos Pendentes devem ser Enviados um por vez.");
                            }
                        }

                        slistaConhec.Add((string)dgvArquivos["nr_lanc", i].Value);
                    }
                    if ((dgvArquivos["ds_cancelamento", i].Value != null) && (dgvArquivos["ds_cancelamento", i].Value.ToString() == "1"))
                    {
                        if (dgvArquivos["cl_assina", i].Value == "1")
                        {
                            sCanceladas += "Conhecimento de Transp. " + dgvArquivos["cd_conheci", i].Value.ToString() + " - Esta Cancelado e não é Permitido o Reenvio do mesmo!" + Environment.NewLine + Environment.NewLine;
                        }
                    }
                }
                #endregion

                if (slistaConhec.Count == 0)
                {
                    KryptonMessageBox.Show("Nenhum CT-e válido foi Selecionado para Envio.", Mensagens.CHeader, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (sCanceladas != "")
                    {
                        throw new Exception(sCanceladas);
                    }
                }
                else
                {

                    if (!bContingencia)
                    {
                        #region Envio Normal

                        //verifica no banco se as sequencias são existentes.
                        List<string> objListaSeq = objGerais.ValidaSeqNoBanco(slistaConhec);
                        if (objListaSeq.Count > 0)
                        {
                            frmGerarNumeroCte objfrmGerarNum = new frmGerarNumeroCte(objListaSeq);
                            objfrmGerarNum.ShowDialog();
                        }

                        #region Popula as Classes e abre form Visualização

                        belPopulaObjetos objObjetos = new belPopulaObjetos(slistaConhec);

                        belPopulaCte objdaoInfCte = new belPopulaCte();
                        objdaoInfCte.PopulaConhecimentos(objObjetos);

                        frmVisualizaCte objFrm = new frmVisualizaCte(objObjetos);
                        objFrm.ShowDialog();


                        #endregion

                        if (objFrm.Cancelado)
                        {
                            throw new Exception("Envio do(s) Conhecimento(s) Cancelado");
                        }
                        else
                        {
                            #region Envia Lote WebService

                            daoGenerator objGerator = new daoGenerator();
                            int iNumLote = Convert.ToInt32(objGerator.RetornaProximoValorGenerator("GEN_LOTE_CTE"));

                            objGravaDadosRetorno.GravarChave(objFrm.objObjetosAlter);

                            string sRecibo = objCriaXml.GerarXml(objFrm.objObjetosAlter, iNumLote);

                            List<belStatusCte> ListaStatus = objCriaXml.ConsultaLoteEnviado(sRecibo);
                            if (sRecibo != "")
                            {
                                objGravaDadosRetorno.GravarRecibo(objFrm.objObjetosAlter, sRecibo);
                            }
                            foreach (belStatusCte cte in ListaStatus)
                            {
                                if (cte.CodRetorno != "103" && cte.CodRetorno != "104" && cte.CodRetorno != "105" && cte.CodRetorno != "100")
                                {
                                    objGravaDadosRetorno.ApagarRecibo(sRecibo);
                                }
                                else
                                {
                                    objGravaDadosRetorno.GravarProtocoloEnvio(cte.Protocolo, cte.NumeroSeq);
                                }
                            }
                            KryptonMessageBox.Show(belTrataMensagem.RetornaMensagem(ListaStatus, belTrataMensagem.Tipo.Envio), Mensagens.CHeader, MessageBoxButtons.OK, MessageBoxIcon.Information);

                            foreach (belStatusCte cte in ListaStatus.Where(C => C.Enviado == true))
                            {
                                objGravaDadosRetorno.AlterarStatusCte(cte.NumeroSeq);
                                objCriaXml.SalvaArquivoPastaEnviado(objGerais.BuscaNumeroConhecimento(cte.NumeroSeq), cte.Chave);
                            }

                            Pendencias = objGerais.VerificaPendenciasdeEnvio();
                            if (Pendencias.Count > 0)
                            {
                                btnPendencias.Visible = true;
                            }
                            else
                            {
                                btnPendencias.Visible = false;
                            }
                            PesquisaConhecimentos();
                            #endregion
                        }

                        #endregion
                    }
                    else
                    {
                        #region Envio Contingencia

                        XmlDocument doc = new XmlDocument();
                        string sChave = objGerais.BuscaChaveRetornoCteSeq(slistaConhec[0]);

                        DirectoryInfo dPastaContingencia = new DirectoryInfo(Pastas.CONTINGENCIA);
                        FileInfo[] finfo = dPastaContingencia.GetFiles("*.xml", SearchOption.AllDirectories);

                        bool ArquivoPastaEnvio = false;
                        bool ArquivoPastaEnvioMesAtual = false;
                        string sCaminho = "";

                        foreach (FileInfo arq in finfo)
                        {
                            if (arq.Name.Contains("Lote") && ArquivoPastaEnvio == false)
                            {
                                doc.Load(@arq.FullName);
                                if (doc.GetElementsByTagName("infCte")[0].Attributes["Id"].Value.ToString().Replace("CTe", "").Equals(sChave))
                                {
                                    sCaminho = @arq.FullName;
                                    string sPathDest = Pastas.ENVIO + "\\" + arq.Name;
                                    string sPathOrigem = Pastas.CONTINGENCIA + "\\" + arq.Name;

                                    if (File.Exists(sPathDest))
                                    {
                                        File.Delete(sPathDest);
                                    }
                                    File.Copy(sPathOrigem, sPathDest);
                                    ArquivoPastaEnvio = true;
                                }
                            }
                            else if (!arq.Name.Contains("Lote") && ArquivoPastaEnvioMesAtual == false)
                            {
                                string sData = daoUtil.GetDateServidor().Date.ToString("dd-MM-yyyy");
                                doc.Load(@arq.FullName);

                                if (doc.GetElementsByTagName("infCte")[0].Attributes["Id"].Value.ToString().Replace("CTe", "").Equals(sChave))
                                {
                                    string sPathDest = Pastas.ENVIO + sData.Substring(3, 2) + "-" + sData.Substring(8, 2) + @"\\" + arq.Name;
                                    string sPathOrigem = Pastas.CONTINGENCIA + sData.Substring(3, 2) + "-" + sData.Substring(8, 2) + @"\\" + arq.Name;

                                    if (File.Exists(sPathDest))
                                    {
                                        File.Delete(sPathDest);
                                    }
                                    File.Copy(sPathOrigem, sPathDest);
                                    ArquivoPastaEnvioMesAtual = true;
                                }
                            }

                            if (ArquivoPastaEnvioMesAtual && ArquivoPastaEnvio)
                            {
                                doc.Load(sCaminho);
                                string sRetorno = objCriaXml.TransmitirLote(doc);
                                string sRecibo = objCriaXml.BuscaReciboRetornoEnvio(sRetorno);


                                List<belStatusCte> ListaStatus = objCriaXml.ConsultaLoteEnviado(sRecibo);
                                if (sRecibo != "")
                                {
                                    objGravaDadosRetorno.SalvarRecibo(sRecibo, slistaConhec[0].ToString());
                                }
                                foreach (belStatusCte cte in ListaStatus)
                                {
                                    if (cte.CodRetorno != "103" && cte.CodRetorno != "104" && cte.CodRetorno != "105" && cte.CodRetorno != "100")
                                    {
                                        objGravaDadosRetorno.ApagarRecibo(sRecibo);
                                    }
                                    else
                                    {
                                        objGravaDadosRetorno.GravarProtocoloEnvio(cte.Protocolo, cte.NumeroSeq);
                                    }
                                }
                                KryptonMessageBox.Show(belTrataMensagem.RetornaMensagem(ListaStatus, belTrataMensagem.Tipo.Envio), Mensagens.CHeader, MessageBoxButtons.OK, MessageBoxIcon.Information);

                                foreach (belStatusCte cte in ListaStatus.Where(C => C.Enviado == true))
                                {
                                    objGravaDadosRetorno.AlterarStatusCte(cte.NumeroSeq);
                                    objCriaXml.SalvaArquivoPastaEnviado(objGerais.BuscaNumeroConhecimento(cte.NumeroSeq), cte.Chave);
                                }
                                btnPendencias_Click(sender, e);
                                break;
                            }
                        }
                        if (!ArquivoPastaEnvioMesAtual && !ArquivoPastaEnvio)
                        {
                            KryptonMessageBox.Show("Arquivo para Envio não Encontrado", Mensagens.CHeader, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        #endregion
                    }
                }

            }
            catch (Exception ex)
            {
                new HLPexception(ex);
            }
        }
        private void btnContingencia_Click(object sender, EventArgs e)
        {
            try
            {
                #region Verifica se Item Selecionado já  foi enviado

                for (int i = 0; i < dgvArquivos.RowCount; i++)
                {
                    if (dgvArquivos["cl_assina", i].Value != null)
                    {
                        if (dgvArquivos["cl_assina", i].Value.ToString().Equals("True"))
                        {
                            if (objGerais.VerificaCampoReciboPreenchido(dgvArquivos["nr_lanc", i].Value.ToString()) != "")
                            {
                                throw new Exception("O Conhecimento de Sequência " + dgvArquivos["nr_lanc", i].Value.ToString() + " Já tem um recibo Salvo no Banco de Dados, tente Buscar Retorno.");
                            }
                            else if (Convert.ToBoolean(dgvArquivos["st_cte", i].Value) == false && Convert.ToBoolean(dgvArquivos["st_contingencia", i].Value) == true)
                            {
                                throw new Exception("O Conhecimento de Sequência " + dgvArquivos["nr_lanc", i].Value.ToString() + " Já foi Gerado em Modo de Contingência.");
                            }
                        }
                    }
                }
                #endregion


                #region Pega Notas Selecionadas na Grid

                string sCanceladas = "";
                slistaConhec = new List<string>();
                for (int i = 0; i < dgvArquivos.RowCount; i++)
                {
                    if (((dgvArquivos["cl_assina", i].Value != null) && (dgvArquivos["cl_assina", i].Value.ToString().Equals("True")))
                                && ((dgvArquivos["ds_cancelamento", i].Value == null) || (dgvArquivos["ds_cancelamento", i].Value.ToString() == "0"))
                                && (dgvArquivos["st_cte", i].Value.ToString().Equals("0")))
                    {

                        slistaConhec.Add((string)dgvArquivos["nr_lanc", i].Value);
                    }
                    if ((dgvArquivos["ds_cancelamento", i].Value != null) && (dgvArquivos["ds_cancelamento", i].Value.ToString() == "1"))
                    {
                        if (dgvArquivos["cl_assina", i].Value == "1")
                        {
                            sCanceladas += "Conhecimento de Transp. " + dgvArquivos["cd_conheci", i].Value.ToString() + " - Esta Cancelado e não é Permitido o Reenvio do mesmo!" + Environment.NewLine + Environment.NewLine;
                        }
                    }
                }
                #endregion

                if (slistaConhec.Count == 0)
                {
                    KryptonMessageBox.Show("Nenhum CT-e válido foi Selecionado para Gerar Xml.", Mensagens.CHeader, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (sCanceladas != "")
                    {
                        throw new Exception(sCanceladas);
                    }
                }
                else if (slistaConhec.Count > 1)
                {
                    throw new Exception("Só é Possível Gerar uma Xml de Cada vez em Modo de Contingência.");
                }
                else
                {
                    //verifica no banco se as sequencias são existentes.
                    List<string> objLGerarSeq = objGerais.ValidaSeqNoBanco(slistaConhec);
                    if (objLGerarSeq.Count > 0)
                    {
                        frmGerarNumeroCte objfrmGerarNum = new frmGerarNumeroCte(objLGerarSeq);
                        objfrmGerarNum.ShowDialog();
                    }


                    #region Popula as Classes e abre form Visualização

                    belPopulaObjetos objObjetos = new belPopulaObjetos(slistaConhec);

                    belPopulaCte objdaoInfCte = new belPopulaCte();
                    objdaoInfCte.PopulaConhecimentos(objObjetos);

                    frmVisualizaCte objFrm = new frmVisualizaCte(objObjetos);
                    objFrm.ShowDialog();

                    #endregion

                    if (objFrm.Cancelado)
                    {
                        throw new Exception("Geração do XML Cancelada");
                    }
                    else
                    {
                        #region Gera XML Contingencia

                        daoGenerator objGerator = new daoGenerator();
                        int iNumLote = Convert.ToInt32(objGerator.RetornaProximoValorGenerator("GEN_LOTE_CTE"));

                        objGravaDadosRetorno.GravarChave(objFrm.objObjetosAlter);

                        string sRecibo = objCriaXml.GerarXml(objFrm.objObjetosAlter, iNumLote);

                        objGravaDadosRetorno.AlterarStatusCteContingencia(objFrm.objObjetosAlter.objListaConhecimentos[0].ide.nCT);
                        KryptonMessageBox.Show("Arquivo gravado na pasta Contingência com Sucesso!", Mensagens.CHeader, MessageBoxButtons.OK, MessageBoxIcon.Information);

                        PesquisaConhecimentos();
                        #endregion
                    }
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
                List<string> sListCodConhec = new List<string>();

                for (int i = 0; i < dgvArquivos.RowCount; i++)
                {
                    if (dgvArquivos["cl_assina", i].Value != null)
                    {
                        if (dgvArquivos["cl_assina", i].Value.ToString().Equals("True"))
                        {
                            string sRecibo = objGerais.VerificaCampoReciboPreenchido(dgvArquivos["nr_lanc", i].Value.ToString());
                            if (sRecibo != "")
                            {
                                sListCodConhec.Add(dgvArquivos["cd_conheci", i].Value.ToString());
                            }
                        }
                    }
                }
                if (sListCodConhec.Count == 1)
                {
                    frmCancJustCte objfrmCanc = new frmCancJustCte(sListCodConhec);
                    objfrmCanc.ShowDialog();
                    PesquisaConhecimentos();
                }
                else if (sListCodConhec.Count > 1)
                {
                    KryptonMessageBox.Show("Não é possível cancelar vários CT-e de uma vez!", Mensagens.MSG_Aviso, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    KryptonMessageBox.Show("Nenhum CT-e válido foi Selecionado para cancelamento.", Mensagens.MSG_Aviso, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                List<DadosImpressao> objListDados = new List<DadosImpressao>();

                DirectoryInfo dPasta = null;
                FileInfo[] fArquivoImprimir = null;

                if (Acesso.TP_EMIS == 1)
                {
                    #region Verifica Selecionadas

                    for (int i = 0; i < dgvArquivos.RowCount; i++)
                    {
                        if (dgvArquivos["cl_assina", i].Value != null)
                        {
                            if (dgvArquivos["cl_assina", i].Value.ToString().Equals("True"))
                            {
                                string sProtEnvio = objGerais.VerificaCampoProtocoloEnvio(dgvArquivos["cd_conheci", i].Value.ToString());
                                if (sProtEnvio != "")
                                {
                                    DadosImpressao objDados = new DadosImpressao();
                                    objDados.sNumeroCte = dgvArquivos["cd_conheci", i].Value.ToString();
                                    objDados.sProtocolo = sProtEnvio;
                                    if (Convert.ToBoolean(dgvArquivos["ds_cancelamento", i].Value).ToString().Equals("True"))
                                    {
                                        objDados.Cancelado = true;
                                    }
                                    objListDados.Add(objDados);
                                }

                            }
                        }
                    }

                    #endregion
                }
                else
                {
                    #region Verifica Notas em Contingencia

                    for (int i = 0; i < dgvArquivos.RowCount; i++)
                    {
                        if (dgvArquivos["cl_imprime", i].Value != null)
                        {
                            if (dgvArquivos["cl_imprime", i].Value.ToString().Equals("True") && Convert.ToBoolean(dgvArquivos["st_cte", i].Value) == false && Convert.ToBoolean(dgvArquivos["st_contingencia", i].Value) == true)
                            {
                                DadosImpressao objDados = new DadosImpressao();
                                objDados.sNumeroCte = dgvArquivos["cd_conheci", i].Value.ToString();
                                objListDados.Add(objDados);
                            }
                        }
                    }

                    #endregion
                }

                #region Popula Dataset com Cte Validos

                if (objListDados.Count > 0)
                {
                    for (int i = 0; i < objListDados.Count; i++)
                    {
                        if (Acesso.TP_EMIS == 1)
                        {
                            string sChaveCteRet = objGerais.BuscaChaveRetornoCte(objListDados[i].sNumeroCte);
                            string sPasta = sChaveCteRet.Substring(4, 2) + "-" + sChaveCteRet.Substring(2, 2);

                            if (!objListDados[i].Cancelado)
                            {
                                dPasta = new DirectoryInfo(Pastas.ENVIADOS + @"\\" + sPasta);
                            }
                            else
                            {
                                dPasta = new DirectoryInfo(Pastas.CANCELADOS + @"\\" + sPasta);
                            }
                            if (dPasta.Exists)
                            {
                                fArquivoImprimir = dPasta.GetFiles("Cte_" + sChaveCteRet + ".xml");
                                if (fArquivoImprimir.Count() == 1)
                                {
                                    objListDados[i].bArquivoEncontrado = true;
                                    objListDados[i].sCaminhoXml = dPasta.ToString() + "\\Cte_" + sChaveCteRet + ".xml";
                                }
                                else
                                {
                                    throw new Exception("Arquivo Xml do Conhecimento " + objListDados[i].sNumeroCte + " não Encontrado");
                                }
                            }
                            else
                            {
                                throw new Exception("A pasta do Mês " + sPasta + " não existe.");
                            }
                        }
                        else
                        {
                            XmlDocument doc = new XmlDocument();

                            string sChaveCteRet = objGerais.BuscaChaveRetornoCte(objListDados[i].sNumeroCte);
                            string sPasta = sChaveCteRet.Substring(4, 2) + "-" + sChaveCteRet.Substring(2, 2);

                            dPasta = new DirectoryInfo(Pastas.CONTINGENCIA + @"\\" + sPasta);
                            fArquivoImprimir = dPasta.GetFiles("*.xml", SearchOption.AllDirectories);

                            foreach (FileInfo arq in fArquivoImprimir)
                            {
                                doc.Load(@arq.FullName);
                                if (doc.GetElementsByTagName("infCte")[0].Attributes["Id"].Value.ToString().Replace("CTe", "").Equals(sChaveCteRet))
                                {
                                    objListDados[i].bArquivoEncontrado = true;
                                    objListDados[i].sCaminhoXml = arq.FullName;
                                    break;
                                }
                            }

                        }
                    }

                    belPopulaDataSet objDataSet = new belPopulaDataSet();

                    dsCTe dsPadrao = new dsCTe();
                    dsCTe dsLotacao = new dsCTe();
                    dsCTe dsPadraoCancelado = new dsCTe();
                    dsCTe dsLotacaoCancelado = new dsCTe();

                    for (int i = 0; i < objListDados.Count; i++)
                    {
                        if (objListDados[i].bArquivoEncontrado == true)
                        {
                            if (objDataSet.VerificaLotacao(objListDados[i].sCaminhoXml))
                            {
                                if (!objListDados[i].Cancelado)
                                {
                                    objDataSet.PopulaDataSet(dsLotacao, objListDados[i].sCaminhoXml, i + 1, objListDados[i].sProtocolo);
                                    GeraPDF(dsLotacao, TipoPDF.LOTACAO, objListDados[i]);

                                }
                                else
                                {
                                    objDataSet.PopulaDataSet(dsLotacaoCancelado, objListDados[i].sCaminhoXml, i + 1, objListDados[i].sProtocolo);
                                    GeraPDF(dsLotacaoCancelado, TipoPDF.LOTACAO_CANCELADO, objListDados[i]);
                                }
                            }
                            else
                            {
                                if (!objListDados[i].Cancelado)
                                {
                                    objDataSet.PopulaDataSet(dsPadrao, objListDados[i].sCaminhoXml, i + 1, objListDados[i].sProtocolo);
                                    GeraPDF(dsPadrao, TipoPDF.PADRAO, objListDados[i]);
                                }
                                else
                                {
                                    objDataSet.PopulaDataSet(dsPadraoCancelado, objListDados[i].sCaminhoXml, i + 1, objListDados[i].sProtocolo);
                                    GeraPDF(dsPadraoCancelado, TipoPDF.PADRAO_CANCELADO, objListDados[i]);
                                }
                            }
                        }
                    }

                    if (Convert.ToBoolean(Acesso.EMAIL_AUTOMATICO))
                    {
                        EnviaEmail(objListDados);
                    }
                    if (dsPadrao.infCte.Count() > 0)
                    {
                        ReportDocument rpt = new ReportDocument();
                        rpt.Load(Application.StartupPath + "\\Relatorios\\rptCtePadrao.rpt");
                        rpt.SetDataSource(dsPadrao);
                        rpt.Refresh();

                        frmRelatorio frm = new frmRelatorio(rpt, "Impressão de DACTE - Carga Fracionada");
                        frm.Show();
                    }
                    if (dsPadraoCancelado.infCte.Count() > 0)
                    {
                        ReportDocument rpt = new ReportDocument();
                        rpt.Load(Application.StartupPath + "\\Relatorios\\rptCtePadraoCancelado.rpt");
                        rpt.SetDataSource(dsPadraoCancelado);
                        rpt.Refresh();

                        frmRelatorio frm = new frmRelatorio(rpt, "Impressão de DACTE - Carga Fracionada(Cancelados)");
                        frm.Show();
                    }
                    if (dsLotacao.infCte.Count() > 0)
                    {
                        ReportDocument rpt = new ReportDocument();
                        rpt.Load(Application.StartupPath + "\\Relatorios\\rptCteLotacao.rpt");
                        rpt.SetDataSource(dsLotacao);
                        rpt.Refresh();

                        frmRelatorio frm = new frmRelatorio(rpt, "Impressão de DACTE - Lotação");
                        frm.Show();
                    }
                    if (dsLotacaoCancelado.infCte.Count() > 0)
                    {
                        ReportDocument rpt = new ReportDocument();
                        rpt.Load(Application.StartupPath + "\\Relatorios\\rptCteLotacaoCancelado.rpt");
                        rpt.SetDataSource(dsLotacaoCancelado);
                        rpt.Refresh();

                        frmRelatorio frm = new frmRelatorio(rpt, "Impressão de DACTE - Lotação(Cancelados)");
                        frm.Show();
                    }
                }
                else
                {
                    KryptonMessageBox.Show("Nenhum CT-e válido foi Selecionado para Impressão.", Mensagens.MSG_Aviso, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }



                #endregion
            }
            catch (Exception ex)
            {
                new HLPexception(ex);
            }
        }
        private void btnGeraPdf_Click(object sender, EventArgs e)
        {
            try
            {
                List<DadosImpressao> objListDados = new List<DadosImpressao>();
                FileInfo[] fArquivoImprimir = null;
                DirectoryInfo dPasta = null;

                if (Acesso.TP_EMIS == 1)
                {
                    #region Verifica Selecionadas

                    for (int i = 0; i < dgvArquivos.RowCount; i++)
                    {
                        if (dgvArquivos["cl_assina", i].Value != null)
                        {
                            if (dgvArquivos["cl_assina", i].Value.ToString().Equals("True"))
                            {
                                string sProtEnvio = objGerais.VerificaCampoProtocoloEnvio(dgvArquivos["cd_conheci", i].Value.ToString());
                                if (sProtEnvio != "")
                                {
                                    DadosImpressao objDados = new DadosImpressao();
                                    objDados.sNumeroCte = dgvArquivos["cd_conheci", i].Value.ToString();
                                    objDados.sProtocolo = sProtEnvio;
                                    if (Convert.ToBoolean(dgvArquivos["ds_cancelamento", i].Value).ToString().Equals("True"))
                                    {
                                        objDados.Cancelado = true;
                                    }
                                    objListDados.Add(objDados);
                                }

                            }
                        }
                    }

                    #endregion
                }
                else
                {
                    #region Verifica Notas em Contingencia

                    for (int i = 0; i < dgvArquivos.RowCount; i++)
                    {
                        if (dgvArquivos["cl_imprime", i].Value != null)
                        {
                            if (dgvArquivos["cl_imprime", i].Value.ToString().Equals("True") && Convert.ToBoolean(dgvArquivos["st_cte", i].Value) == false && Convert.ToBoolean(dgvArquivos["st_contingencia", i].Value) == true)
                            {
                                DadosImpressao objDados = new DadosImpressao();
                                objDados.sNumeroCte = dgvArquivos["cd_conheci", i].Value.ToString();
                                objListDados.Add(objDados);
                            }
                        }
                    }

                    #endregion
                }
                if (objListDados.Count() > 0)
                {
                    if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                    {
                        #region Busca Arquivos XML
                        for (int i = 0; i < objListDados.Count; i++)
                        {
                            if (Acesso.TP_EMIS == 1)
                            {
                                string sChaveCteRet = objGerais.BuscaChaveRetornoCte(objListDados[i].sNumeroCte);
                                string sPasta = sChaveCteRet.Substring(4, 2) + "-" + sChaveCteRet.Substring(2, 2);

                                if (!objListDados[i].Cancelado)
                                {
                                    dPasta = new DirectoryInfo(Pastas.ENVIADOS + @"\\" + sPasta);
                                }
                                else
                                {
                                    dPasta = new DirectoryInfo(Pastas.CANCELADOS + @"\\" + sPasta);
                                }
                                if (dPasta.Exists)
                                {
                                    fArquivoImprimir = dPasta.GetFiles("Cte_" + sChaveCteRet + ".xml");
                                    if (fArquivoImprimir.Count() == 1)
                                    {
                                        objListDados[i].bArquivoEncontrado = true;
                                        objListDados[i].sCaminhoXml = dPasta.ToString() + "\\Cte_" + sChaveCteRet + ".xml";
                                    }
                                    else
                                    {
                                        throw new Exception("Arquivo Xml não Encontrado");
                                    }
                                }
                            }
                            else
                            {
                                XmlDocument doc = new XmlDocument();

                                string sChaveCteRet = objGerais.BuscaChaveRetornoCte(objListDados[i].sNumeroCte);
                                string sPasta = sChaveCteRet.Substring(4, 2) + "-" + sChaveCteRet.Substring(2, 2);

                                dPasta = new DirectoryInfo(Pastas.CONTINGENCIA + @"\\" + sPasta);
                                fArquivoImprimir = dPasta.GetFiles("*.xml", SearchOption.AllDirectories);

                                foreach (FileInfo arq in fArquivoImprimir)
                                {
                                    doc.Load(@arq.FullName);
                                    if (doc.GetElementsByTagName("infCte")[0].Attributes["Id"].Value.ToString().Replace("CTe", "").Equals(sChaveCteRet))
                                    {
                                        objListDados[i].bArquivoEncontrado = true;
                                        objListDados[i].sCaminhoXml = arq.FullName;
                                        break;
                                    }
                                }

                            }
                        }
                        #endregion

                        belPopulaDataSet objDataSet = new belPopulaDataSet();

                        dsCTe dsPadrao = new dsCTe();
                        dsCTe dsLotacao = new dsCTe();
                        dsCTe dsPadraoCancelado = new dsCTe();
                        dsCTe dsLotacaoCancelado = new dsCTe();

                        int iCount = 0;
                        for (int i = 0; i < objListDados.Count; i++)
                        {
                            if (objListDados[i].bArquivoEncontrado == true)
                            {
                                if (objDataSet.VerificaLotacao(objListDados[i].sCaminhoXml))
                                {
                                    if (!objListDados[i].Cancelado)
                                    {
                                        objDataSet.PopulaDataSet(dsLotacao, objListDados[i].sCaminhoXml, i + 1, objListDados[i].sProtocolo);
                                        GeraPDF(dsLotacao, TipoPDF.LOTACAO, objListDados[i].sNumeroCte, folderBrowserDialog1.SelectedPath);
                                        iCount++;
                                    }
                                    else
                                    {
                                        objDataSet.PopulaDataSet(dsLotacaoCancelado, objListDados[i].sCaminhoXml, i + 1, objListDados[i].sProtocolo);
                                        GeraPDF(dsLotacaoCancelado, TipoPDF.LOTACAO_CANCELADO, objListDados[i].sNumeroCte, folderBrowserDialog1.SelectedPath);
                                        iCount++;
                                    }
                                }
                                else
                                {
                                    if (!objListDados[i].Cancelado)
                                    {
                                        objDataSet.PopulaDataSet(dsPadrao, objListDados[i].sCaminhoXml, i + 1, objListDados[i].sProtocolo);
                                        GeraPDF(dsPadrao, TipoPDF.PADRAO, objListDados[i].sNumeroCte, folderBrowserDialog1.SelectedPath);
                                        iCount++;
                                    }
                                    else
                                    {
                                        objDataSet.PopulaDataSet(dsPadraoCancelado, objListDados[i].sCaminhoXml, i + 1, objListDados[i].sProtocolo);
                                        GeraPDF(dsPadraoCancelado, TipoPDF.PADRAO_CANCELADO, objListDados[i].sNumeroCte, folderBrowserDialog1.SelectedPath);
                                        iCount++;
                                    }
                                }
                            }
                            else
                            {
                                KryptonMessageBox.Show("Arquivo Xml do Conhecimento " + objListDados[i].sNumeroCte + " não foi Encontrado.", Mensagens.MSG_Alerta, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        if (iCount > 0)
                        {
                            KryptonMessageBox.Show("Arquivos PDF gerados com sucesso!", Mensagens.CHeader, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                else
                {
                    KryptonMessageBox.Show("Nenhum CT-e válido foi Selecionado para gerar PDF.", Mensagens.MSG_Aviso, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
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
                List<string> sListCodConhec = new List<string>();

                for (int i = 0; i < dgvArquivos.RowCount; i++)
                {
                    if (dgvArquivos["cl_assina", i].Value != null)
                    {
                        if (dgvArquivos["cl_assina", i].Value.ToString().Equals("True"))
                        {
                            string sRecibo = objGerais.VerificaCampoReciboPreenchido(dgvArquivos["nr_lanc", i].Value.ToString());
                            if (sRecibo != "")
                            {
                                sListCodConhec.Add(sRecibo);
                                belTrataMensagem.sNumCte = dgvArquivos["nr_lanc", i].Value.ToString();
                            }
                        }
                    }
                }
                if (sListCodConhec.Count == 1)
                {

                    List<belStatusCte> ListaStatus = objCriaXml.ConsultaLoteEnviado(sListCodConhec[0]);
                    foreach (belStatusCte cte in ListaStatus)
                    {
                        if (cte.CodRetorno != "103" && cte.CodRetorno != "104" && cte.CodRetorno != "105" && cte.CodRetorno != "100")
                        {
                            objGravaDadosRetorno.ApagarRecibo(sListCodConhec[0]);
                        }
                        else
                        {
                            objGravaDadosRetorno.GravarProtocoloEnvio(cte.Protocolo, cte.NumeroSeq);
                        }
                    }
                    foreach (belStatusCte cte in ListaStatus.Where(C => C.Enviado == true))
                    {
                        objGravaDadosRetorno.AlterarStatusCte(cte.NumeroSeq);
                        objCriaXml.SalvaArquivoPastaEnviado(objGerais.BuscaNumeroConhecimento(cte.NumeroSeq), cte.Chave);
                    }

                    KryptonMessageBox.Show(belTrataMensagem.RetornaMensagem(ListaStatus, belTrataMensagem.Tipo.Individual), Mensagens.CHeader, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    PesquisaConhecimentos();
                }
                else if (sListCodConhec.Count > 1)
                {
                    KryptonMessageBox.Show("Não é possível buscar retorno de vários CT-e de uma vez!", Mensagens.MSG_Aviso, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    KryptonMessageBox.Show("Nenhum CT-e válido foi Selecionado.", Mensagens.MSG_Aviso, MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                }

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
                List<string> sListCodConhec = new List<string>();

                for (int i = 0; i < dgvArquivos.RowCount; i++)
                {
                    if (dgvArquivos["cl_assina", i].Value != null)
                    {
                        if (dgvArquivos["cl_assina", i].Value.ToString().Equals("True"))
                        {
                            string sRecibo = objGerais.VerificaCampoReciboPreenchido(dgvArquivos["nr_lanc", i].Value.ToString());
                            if (sRecibo != "")
                            {
                                sListCodConhec.Add(dgvArquivos["cd_conheci", i].Value.ToString());
                            }
                        }
                    }
                }
                if (sListCodConhec.Count == 1)
                {

                    string sChave = objGerais.BuscaChaveRetornoCte(sListCodConhec[0]);
                    List<belStatusCte> ListaStatus = objCriaXml.GerarXmlConsultaSituacao(sChave, false);

                    if (ListaStatus[0].NumeroSeq != null)
                    {
                        belTrataMensagem.sNumCte = objGerais.BuscaNumeroConhecimento(ListaStatus[0].NumeroSeq);
                    }
                    KryptonMessageBox.Show(belTrataMensagem.RetornaMensagem(ListaStatus, belTrataMensagem.Tipo.Situacao), Mensagens.CHeader, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (sListCodConhec.Count > 1)
                {
                    KryptonMessageBox.Show("Não é possível consultar vários CT-e de uma vez!", Mensagens.MSG_Aviso, MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                }
                else
                {
                    KryptonMessageBox.Show("Nenhum CT-e válido foi Selecionado.", Mensagens.MSG_Aviso, MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                }
            }
            catch (Exception ex)
            {
                new HLPexception(ex);
            }
        }
        private void btnSair_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                new HLPexception(ex);
            }
        }
        private void btnPendencias_Click(object sender, EventArgs e)
        {
            try
            {
                daoBuscaDadosGerais objdaoGerais = new daoBuscaDadosGerais();

                StringBuilder strCampos = new StringBuilder();
                strCampos.Append("c.nr_lanc, ");
                strCampos.Append("coalesce(c.cd_conheci, '') cd_conheci , ");
                strCampos.Append("cast(case when coalesce(c.st_contingencia, 'N') = 'S' then 1 else 0 end as smallint) st_contingencia , ");
                strCampos.Append("c.dt_emi, ");
                strCampos.Append("r.nm_social, ");
                strCampos.Append("c.vl_total, ");
                strCampos.Append("cast(case when coalesce(c.st_cte, 'N') = 'S' then 1 else 0 end as smallint ) st_cte, ");
                strCampos.Append("cast(case when coalesce(c.ds_cancelamento, 'N') = 'N' then 0 else 1 end as smallint) ds_cancelamento ");

                dgvArquivos.DataSource = objdaoGerais.PesquisaGridViewContingencia(strCampos.ToString());
                lblTotalRegistros.Text = dgvArquivos.Rows.Count + " Registro(s) encontrado(s)";

                for (int i = 0; i < dgvArquivos.RowCount; i++)
                {
                    if (Convert.ToBoolean(dgvArquivos["ds_cancelamento", i].Value) == true)
                    {
                        dgvArquivos.Rows[i].DefaultCellStyle.BackColor = Color.Khaki;
                    }
                    else if (Convert.ToBoolean(dgvArquivos["st_cte", i].Value) == true)
                    {
                        dgvArquivos.Rows[i].DefaultCellStyle.BackColor = Color.LightGreen;
                    }
                    else if (Convert.ToBoolean(dgvArquivos["st_cte", i].Value) == false && Convert.ToBoolean(dgvArquivos["st_contingencia", i].Value) == true)
                    {
                        dgvArquivos.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                    }

                }
                VerificaPendenciasContingencia();
            }
            catch (Exception ex)
            {
                new HLPexception(ex);
            }
        }

        #endregion

        #region Metodos

        public enum TipoPDF { PADRAO, LOTACAO, PADRAO_CANCELADO, LOTACAO_CANCELADO };

        private void GeraPDF(dsCTe ds, TipoPDF tpPdf, DadosImpressao objDados)
        {
            try
            {

                ReportDocument rpt = new ReportDocument();
                DirectoryInfo dinfo = null;

                if (tpPdf == TipoPDF.PADRAO)
                {
                    rpt.Load(Application.StartupPath + "\\Relatorios\\rptCtePadrao.rpt");
                    dinfo = new DirectoryInfo(Pastas.ENVIADOS + "\\PDF");
                }
                else if (tpPdf == TipoPDF.PADRAO_CANCELADO)
                {
                    rpt.Load(Application.StartupPath + "\\Relatorios\\rptCtePadraoCancelado.rpt");
                    dinfo = new DirectoryInfo(Pastas.CANCELADOS + "\\PDF");
                }
                else if (tpPdf == TipoPDF.LOTACAO)
                {
                    rpt.Load(Application.StartupPath + "\\Relatorios\\rptCteLotacao.rpt");
                    dinfo = new DirectoryInfo(Pastas.ENVIADOS + "\\PDF");
                }
                else if (tpPdf == TipoPDF.LOTACAO_CANCELADO)
                {
                    rpt.Load(Application.StartupPath + "\\Relatorios\\rptCteLotacaoCancelado.rpt");
                    dinfo = new DirectoryInfo(Pastas.CANCELADOS + "\\PDF");
                }
                rpt.SetDataSource(ds);
                rpt.Refresh();

                if (!dinfo.Exists)
                {
                    dinfo.Create();
                }

                string sCaminhoPDF = dinfo.FullName + "\\Cte_" + objDados.sNumeroCte + ".pdf";
                objDados.sCaminhoPDF = sCaminhoPDF;
                Util.ExportPDF(rpt, sCaminhoPDF);

            }
            catch (Exception ex)
            {
                new HLPexception(ex);
            }


        }

        private void GeraPDF(dsCTe ds, TipoPDF tpPdf, string sNumCte, string sCaminhoSalvar)
        {
            try
            {

                ReportDocument rpt = new ReportDocument();

                if (tpPdf == TipoPDF.PADRAO)
                {
                    rpt.Load(Application.StartupPath + "\\Relatorios\\rptCtePadrao.rpt");
                }
                else if (tpPdf == TipoPDF.PADRAO_CANCELADO)
                {
                    rpt.Load(Application.StartupPath + "\\Relatorios\\rptCtePadraoCancelado.rpt");
                }
                else if (tpPdf == TipoPDF.LOTACAO)
                {
                    rpt.Load(Application.StartupPath + "\\Relatorios\\rptCteLotacao.rpt");
                }
                else if (tpPdf == TipoPDF.LOTACAO_CANCELADO)
                {
                    rpt.Load(Application.StartupPath + "\\Relatorios\\rptCteLotacaoCancelado.rpt");
                }
                rpt.SetDataSource(ds);
                rpt.Refresh();



                Util.ExportPDF(rpt, sCaminhoSalvar + "\\Cte_" + sNumCte + ".pdf");

            }
            catch (Exception ex)
            {
                new HLPexception(ex);
            }
        }



        private void EnviaEmail(List<DadosImpressao> objListDados)
        {
            try
            {
                if (Acesso.VerificaDadosEmail())
                {
                    List<belEmail> objlbelEmail = new List<belEmail>();
                    for (int i = 0; i < objListDados.Count; i++)
                    {
                        belEmail objemail = new belEmail(objListDados[i].sCaminhoXml, objListDados[i].sCaminhoPDF, objListDados[i].sNumeroCte, "");
                        objlbelEmail.Add(objemail);
                    }

                    if (objlbelEmail.Count > 0)
                    {
                        frmEmail objfrmEmail = new frmEmail(objlbelEmail, belEmail.TipoEmail.CTe);
                        objfrmEmail.ShowDialog();
                    }
                }
                else
                {
                    KryptonMessageBox.Show(null, "Campos para o envio de e-mail automático não estão preenchidos corretamente!", Mensagens.CHeader, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void LimparPasta(DirectoryInfo pasta)
        {
            // Obtém a lista de arquivos dessa subpasta
            var arquivos = pasta.GetFiles();

            // Percorre a lista de arquivos da subpasta
            foreach (var a in arquivos)
            {
                // O arquivo está marcado como ReadOnly?
                if ((a.Attributes & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
                {
                    // Sim! Então remove esse atributo...
                    a.Attributes ^= FileAttributes.ReadOnly;
                }
                // Apaga o arquivo
                a.Delete();
            }
        }

        private void VerificaGeneratorLote()
        {
            try
            {
                daoGenerator objdaoGenerator = new daoGenerator();
                if (!objdaoGenerator.VerificaExistenciaGenerator("GEN_LOTE_CTE"))
                {
                    objdaoGenerator.CreateGenerator("GEN_LOTE_CTE", 0);
                }
            }
            catch (Exception ex)
            {
                new HLPexception(ex);
            }

        }

        private void VerificaPendenciasContingencia()
        {
            try
            {
                Pendencias = objGerais.VerificaPendenciasdeEnvio();
                if (Pendencias.Count > 0)
                {
                    btnPendencias.Visible = true;

                }
                else
                {
                    btnPendencias.Visible = false;
                }
            }
            catch (Exception ex)
            {
                new HLPexception(ex);
            }
        }

        public void PesquisaConhecimentos()
        {
            try
            {


                StringBuilder strCampos = new StringBuilder();
                strCampos.Append("c.nr_lanc, ");
                strCampos.Append("coalesce(c.cd_conheci, '') cd_conheci , ");
                strCampos.Append("cast(case when coalesce(c.st_contingencia, 'N') = 'S' then 1 else 0 end as smallint) st_contingencia , ");
                strCampos.Append("c.dt_emi, ");
                strCampos.Append("r.nm_social, ");
                strCampos.Append("c.vl_total, ");
                strCampos.Append("cast(case when coalesce(c.st_cte, 'N') = 'S' then 1 else 0 end as smallint ) st_cte, ");
                strCampos.Append("cast(case when coalesce(c.ds_cancelamento, 'N') = 'N' then 0 else 1 end as smallint) ds_cancelamento ");



                StringBuilder strWhere = new StringBuilder();
                strWhere.Append(" ((c.cd_empresa = '");
                strWhere.Append(Acesso.CD_EMPRESA);
                strWhere.Append("')");
                if (cboFiltro.SelectedIndex == 0)
                {
                    strWhere.Append(" and ");
                    strWhere.Append(" (c.dt_emi between '");
                    strWhere.Append(dtpIni.Value.ToString("dd.MM.yyyy"));
                    strWhere.Append("' and '");
                    strWhere.Append(dtpFim.Value.ToString("dd.MM.yyyy"));
                    strWhere.Append("')");
                }
                else
                {
                    strWhere.Append(" and ");
                    strWhere.Append(" (c.nr_lanc between '");
                    strWhere.Append(txtNfIni.Text.ToString());
                    strWhere.Append("' and '");
                    strWhere.Append(txtNfFim.Text.ToString());
                    strWhere.Append("')");
                }
                strWhere.Append(")");

                if (cboStatus.SelectedIndex == 1)
                {
                    strWhere.Append(" and ");
                    strWhere.Append("(c.st_cte = 'N' or c.st_cte is null) ");
                }
                if (cboStatus.SelectedIndex == 0)
                {
                    strWhere.Append(" and ");
                    strWhere.Append("(c.st_cte = 'S') ");
                    strWhere.Append("or (c.st_contingencia = 'S') ");
                }

                belBuscaDadosGerais objbelBuscaDadosGerais = new belBuscaDadosGerais();
                DataTable dt = objbelBuscaDadosGerais.PesquisaGridView(strCampos.ToString(), strWhere.ToString());
                dgvArquivos.DataSource = dt;
                lblTotalRegistros.Text = dt.Rows.Count + " Registro(s) encontrado(s)";

                for (int i = 0; i < dgvArquivos.RowCount; i++)
                {
                    if (Convert.ToBoolean(dgvArquivos["ds_cancelamento", i].Value) == true)
                    {
                        dgvArquivos.Rows[i].DefaultCellStyle.BackColor = Color.Khaki;
                    }
                    else if (Convert.ToBoolean(dgvArquivos["st_cte", i].Value) == true)
                    {
                        dgvArquivos.Rows[i].DefaultCellStyle.BackColor = Color.LightGreen;
                    }
                    else if (Convert.ToBoolean(dgvArquivos["st_cte", i].Value) == false && Convert.ToBoolean(dgvArquivos["st_contingencia", i].Value) == true)
                    {
                        dgvArquivos.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                    }

                }

            }
            catch (Exception ex)
            {
                new HLPexception(ex);
            }
        }

        #endregion

        private void dgvArquivos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if ((e.RowIndex > -1) && (e.ColumnIndex == 0))
                {
                    if ((dgvArquivos[0, e.RowIndex].Value == null))
                    {
                        dgvArquivos[0, e.RowIndex].Value = true;
                        SendKeys.Send("{right}");
                        SendKeys.Send("{left}");
                    }
                    else
                    {
                        if (dgvArquivos[0, e.RowIndex].Value.ToString() == "False")
                        {
                            dgvArquivos[0, e.RowIndex].Value = true;
                            SendKeys.Send("{right}");
                            SendKeys.Send("{left}");

                        }
                        else
                        {
                            dgvArquivos[0, e.RowIndex].Value = false;
                            SendKeys.Send("{right}");
                            SendKeys.Send("{left}");
                        }
                    }
                }
                if ((e.RowIndex > -1) && (e.ColumnIndex == 1))
                {
                    if ((dgvArquivos[1, e.RowIndex].Value == null))
                    {
                        dgvArquivos[1, e.RowIndex].Value = true;
                        SendKeys.Send("{left}");
                        SendKeys.Send("{right}");
                    }
                    else
                    {
                        if (dgvArquivos[1, e.RowIndex].Value.ToString() == "False")
                        {
                            dgvArquivos[1, e.RowIndex].Value = true;
                            SendKeys.Send("{left}");
                            SendKeys.Send("{right}");


                        }
                        else
                        {
                            dgvArquivos[1, e.RowIndex].Value = false;
                            SendKeys.Send("{left}");
                            SendKeys.Send("{right}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                new HLPexception(ex);
            }
        }

        bool bMarcar = false;
        private void dgvArquivos_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                bMarcar = !bMarcar;
            }
            else
            {
                bMarcar = false;
            }
            for (int i = 0; i < dgvArquivos.RowCount; i++)
            {
                if (Convert.ToBoolean(dgvArquivos["ds_cancelamento", i].Value) == true)
                {
                    dgvArquivos.Rows[i].DefaultCellStyle.BackColor = Color.Khaki;
                }
                else if (Convert.ToBoolean(dgvArquivos["st_cte", i].Value) == true)
                {
                    dgvArquivos.Rows[i].DefaultCellStyle.BackColor = Color.LightGreen;
                }
                else if (Convert.ToBoolean(dgvArquivos["st_cte", i].Value) == false && Convert.ToBoolean(dgvArquivos["st_contingencia", i].Value) == true)
                {
                    dgvArquivos.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                }
                if (e.ColumnIndex == 0)
                {
                    dgvArquivos["cl_assina", i].Value = bMarcar;
                }
            }
            if (dgvArquivos.CurrentCell != null)
            {
                if (dgvArquivos.CurrentCell.ColumnIndex == 0)
                {
                    SendKeys.Send("{right}");
                    SendKeys.Send("{left}");
                }
            }
        }

    }
}