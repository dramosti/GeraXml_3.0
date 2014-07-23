using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using HLP.GeraXml.bel.NFe.Estrutura;
using HLP.GeraXml.bel.NFe;
using System.Threading;
using HLP.GeraXml.Comum.Static;
using HLP.GeraXml.Comum;

namespace HLP.GeraXml.UI.NFe
{
    public partial class frmEnviaLotes : KryptonForm
    {
        List<List<belPesquisaNotas>> lotesSep;
        List<lotes> lLotes;
        public bool bCancelado = false;
        public List<HLP.GeraXml.bel.NFe.belBusRetFazenda.DadosRetorno> lDadosRetorno;

        public frmEnviaLotes(List<belPesquisaNotas> lNotas)
        {
            InitializeComponent();
            lDadosRetorno = new List<belBusRetFazenda.DadosRetorno>();

            lotesSep = lNotas
                .Select((x, i) => new { Index = i, Value = x })
                .GroupBy(x => x.Index / 50)
                .Select(x => x.Select(v => v.Value).ToList())
                .ToList();

            lLotes = new List<lotes>();
            lotes objLote = null;

            for (int i = 0; i < lotesSep.Count; i++)
            {
                objLote = new lotes();
                objLote.iLote = i + 1;
                objLote.xStatus = "Aguardando ...";
                objLote.objDados = new belCarregaDados(lotesSep[i]);
                objLote.lNotasPesquisa = lotesSep[i];
                lLotes.Add(objLote);
            }
            bsLotes.DataSource = lLotes;

        }
        int iTentativas = 0;
        private void TransmiteLote(object l)
        {
            try
            {
                lotes lote = l as lotes;
                try
                {
                    lote.objDados.objbelCriaXml.GeraLoteXmlEnvio();
                    lote.objDados.objbelRecepcao.TransmitirLote(lote.objDados.objbelCriaXml.sPathLote, lote.lNotasPesquisa);
                    belBusRetFazenda objbelRetFazenda = new belBusRetFazenda(lote.lNotasPesquisa);
                    objbelRetFazenda.BuscaRetorno();
                    lote.xStatus = belTrataMensagemNFe.RetornaMensagem(objbelRetFazenda.lDadosRetorno, belTrataMensagemNFe.Tipo.Envio);
                    lDadosRetorno.AddRange(objbelRetFazenda.lDadosRetorno);
                    iTentativas = 0;
                }
                catch (Exception ex)
                {
                    if (ex.Message.Contains("A conexão subjacente") && iTentativas < 4)
                    {
                        iTentativas++;
                        TransmiteLote(lote);
                    }
                    else
                    {
                        lote.xStatus = "Problema com o lote, Verifique a informação abaixo:" + Environment.NewLine + ex.Message;
                        iTentativas = 0;
                    }
                }
                this.Invoke(new MethodInvoker(delegate()
                {
                    dgvLotes.Refresh();
                    txtInfoLote.Text = lote.xStatus;
                }));

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                BackgroundWorker w = sender as BackgroundWorker;
                for (int i = 0; i < lLotes.Count; i++)
                {
                    try
                    {
                        lLotes[i].xStatus = "Carregando dados ...";
                        this.Invoke(new MethodInvoker(delegate()
                        {
                            dgvLotes.CurrentCell = dgvLotes.Rows[i].Cells[0];
                            dgvLotes.CurrentRow.DefaultCellStyle.BackColor = Color.Aquamarine;
                            progressBar1.Maximum = lLotes.Count();
                            dgvLotes.Refresh();
                        }));

                        lLotes[i].objDados.CarregaDados();
                        w.ReportProgress(lLotes.Count() / 100);

                        if (!Acesso.VISUALIZA_DADOS_NFE)
                        {
                            lLotes[i].xStatus = "Preparando para envio...";
                            this.Invoke(new MethodInvoker(delegate()
                            {
                                dgvLotes.CurrentCell = dgvLotes.Rows[i].Cells[0];
                                dgvLotes.Refresh();
                            }));


                            // Inicia rotina de envio das notas.
                            ParameterizedThreadStart p = new ParameterizedThreadStart(TransmiteLote);
                            Thread t = new Thread(p);
                            t.Start(lLotes[i]);
                        }
                        else
                        {
                            lLotes[i].xStatus = "Dados carregados na memória...";
                            this.Invoke(new MethodInvoker(delegate()
                            {
                                dgvLotes.CurrentCell = dgvLotes.Rows[i].Cells[0];
                                dgvLotes.Refresh();
                            }));
                        }
                    }
                    catch (Exception ex)
                    {
                        lLotes[i].xStatus = ex.Message;
                        this.Invoke(new MethodInvoker(delegate()
                        {
                            dgvLotes.Refresh();
                        }));
                    }
                }

                if (Acesso.VISUALIZA_DADOS_NFE)
                {
                    List<belInfNFe> objListaNFs = new List<belInfNFe>();

                    foreach (lotes lote in lLotes)
                    {
                        objListaNFs.AddRange(lote.objDados.lNotas);
                    }

                    if (objListaNFs.Count > 0)
                    {
                        this.Invoke(new MethodInvoker(delegate()
                      {
                          frmVisualizaNFe objFrmVisualizaDados = new frmVisualizaNFe(objListaNFs);
                          objFrmVisualizaDados.ShowDialog();
                          if (objFrmVisualizaDados.Cancelado)
                          {
                              throw new Exception("cancelado.");
                          }


                          foreach (lotes lote in lLotes)
                          {
                              lote.xStatus = "Lote sendo transmitido...";
                              this.Invoke(new MethodInvoker(delegate()
                              {
                                  dgvLotes.Refresh();
                              }));
                              // Inicia rotina de envio das notas.
                              ParameterizedThreadStart p = new ParameterizedThreadStart(TransmiteLote);
                              Thread t = new Thread(p);
                              t.Start(lote);
                          }
                      }));
                    }
                }
            }
            catch (Exception ex)
            {
//                new HLPexception(ex);
                bCancelado = true;
                //async_work.CancelAsync();
                //timer1.Start();
                this.Invoke(new MethodInvoker(delegate()
                {
                    this.Close();
                }));
            }

        }

        private void async_work_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.PerformStep();
        }

        private void btnParar_Click(object sender, EventArgs e)
        {
            if (async_work.IsBusy)
            {
                KryptonMessageBox.Show(null, "Procedimento não pode ser abortado, envio de dados para o sefaz ja esta em andamento!",
                            Mensagens.MSG_Aviso,
                             MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                this.Close();
            }
        }

        private void dgvLotes_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                string sValor = dgvLotes["xStatusDataGridViewTextBoxColumn", e.RowIndex].Value.ToString();
                txtInfoLote.Text = sValor;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public class lotes
        {
            public int iLote { get; set; }
            public int iQtde { get { return objDados != null ? objDados.lNotas.Count : 0; } }
            public string xStatus { get; set; }
            public belCarregaDados objDados { get; set; }
            public List<belPesquisaNotas> lNotasPesquisa { get; set; }

        }

        private void frmEnviaLotes_Load(object sender, EventArgs e)
        {
            try
            {
                if (async_work.IsBusy != true)
                {
                    async_work.RunWorkerAsync();
                }
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Thread.Sleep(100);
            btnParar_Click(async_work, e);
            timer1.Stop();
        }


    }
}
