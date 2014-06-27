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
                        objManifesto = new belDadosManifesto(m.numero, m.sequencia);
                        manifestos.Add(objManifesto);

                    }

                    if (manifestos.Count() > 0)
                    {
                        frmVisualizaMDFe frm = new frmVisualizaMDFe(manifestos);
                        frm.ShowDialog();
                    }


                    this.bsGrid.DataSource = objSelect;
                    dgvArquivos.Refresh();
                }
            }
            catch (Exception ex)
            {
                throw ex;
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
    }
}
