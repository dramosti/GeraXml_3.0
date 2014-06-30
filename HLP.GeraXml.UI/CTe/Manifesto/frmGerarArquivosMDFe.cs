using HLP.GeraXml.bel.MDFe;
using HLP.GeraXml.bel.MDFe.Acoes;
using HLP.GeraXml.Comum;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace HLP.GeraXml.UI.CTe.Manifesto
{
    public partial class frmGerarArquivosMDFe : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        belPesquisaManifestros objPesquisa = new belPesquisaManifestros();
        public frmGerarArquivosMDFe()
        {
            InitializeComponent();
            this.dtpFim.Value = DateTime.Today;
            this.dtpIni.Value = DateTime.Today;
            cboStatus.SelectedIndex = 1;
        }

        private void btnPesquisa_Click(object sender, EventArgs e)
        {
            Pesquisar();
        }

        public void Pesquisar()
        {
            belPesquisaManifestros.status st;
            if (cboStatus.cbx.Text.Equals("Enviados"))
            {
                st = belPesquisaManifestros.status.Enviados;
            }
            else if (cboStatus.cbx.Text.Equals("Não Enviados"))
            {
                st = belPesquisaManifestros.status.NaoEnviados;
            }
            else
            {
                st = belPesquisaManifestros.status.Ambos;
            }
            bsGrid.DataSource = objPesquisa.ExecutePesquisa(st, dtpIni.Value, dtpFim.Value);

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
                    else if (Convert.ToBoolean(dgvArquivos["bEnviado", i].Value) == true)
                    {
                        dgvArquivos.Rows[i].DefaultCellStyle.BackColor = Color.LightGreen;
                    }
                    else if (Convert.ToBoolean(dgvArquivos["bEnviado", i].Value) == false && dgvArquivos["recibo", i].Value.ToString() != "")
                    {
                        dgvArquivos.Rows[i].DefaultCellStyle.BackColor = Color.LightCyan;
                    }
                }
                dgvArquivos.Refresh();
            }
        }

        private void btnBuscaRetorno_Click(object sender, EventArgs e)
        {
            try
            {
                BuscarRetorno();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void BuscarRetorno()
        {
            List<PesquisaManifestosModel> objSelect = this.objPesquisa.resultado.Where(c =>
                                  c.recibo != "" && c.bSeleciona
                                  ).ToList();
            if (objSelect.Count() > 0)
            {
                belBuscaRetornoMDFe objBuscaRet;
                string sMessage = "";
                foreach (PesquisaManifestosModel item in objSelect)
                {
                    objBuscaRet = new belBuscaRetornoMDFe(item);
                    objBuscaRet.BuscarRetorno();
                    sMessage += objBuscaRet.sMessage;
                }
                MessageBox.Show(sMessage, "A V I S O", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            Pesquisar();
        }
        private void btnEnvio_Click(object sender, EventArgs e)
        {
            try
            {
                List<PesquisaManifestosModel> objSelect = this.objPesquisa.resultado.Where(c =>
                                        c.bCancelado == false &&
                                        c.bEnviado == false &&
                                        c.recibo == "" && c.bSeleciona
                                        ).ToList();
                if (objSelect.Count() > 0)
                {
                    List<PesquisaManifestosModel> lnumeros = objSelect.Where(c => c.numero == "").ToList();
                    if (lnumeros.Count() > 0)
                    {
                        frmGerarNumeroMDFe frm = new frmGerarNumeroMDFe(lnumeros);
                        frm.ShowDialog();
                    }
                    List<belDadosManifesto> manifestos = new List<belDadosManifesto>();

                    belDadosManifesto objManifesto;
                    foreach (var m in objSelect)
                    {
                        objManifesto = new belDadosManifesto(m);
                        manifestos.Add(objManifesto);
                    }

                    if (manifestos.Count() > 0)
                    {
                        frmVisualizaMDFe frm = new frmVisualizaMDFe(manifestos);
                        frm.ShowDialog();
                        if (frm.bEnvia)
                        {
                            foreach (belDadosManifesto m in manifestos)
                            {
                                m.objManifesto.recibo = m.Envio.TransmitirLote();
                            }
                            Thread.Sleep(2000);
                            BuscarRetorno();
                        }
                    }
                    Pesquisar();
                }
            }
            catch (Exception ex)
            {
                throw new HLPexception(ex);
            }
        }
        private void dgvArquivos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if ((e.RowIndex > -1) && (e.ColumnIndex == 0))
                {
                    SendKeys.Send("{right}");
                    SendKeys.Send("{left}");
                    dgvArquivos.Refresh();
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
                List<PesquisaManifestosModel> objSelect = this.objPesquisa.resultado.Where(c =>
                                       c.bCancelado == false &&
                                       c.bEnviado == true &&
                                       c.protocolo != "" && c.bSeleciona
                                       ).ToList();

                if (objSelect.Count() > 1)
                {
                    MessageBox.Show("Selecione apenas um manifesto por vez.", "A V I S O", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (objSelect.Count() == 1)
                {
                    //belCancelamentoMDFe canc = new belCancelamentoMDFe(objSelect.FirstOrDefault())


                }

            }
            catch (Exception)
            {

                throw;
            }
        }


    }
}
