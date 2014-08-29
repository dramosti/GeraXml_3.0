using HLP.GeraXml.bel;
using HLP.GeraXml.bel.NFe.ClassesSerializadas;
using HLP.GeraXml.bel.NFe.Eventos;
using HLP.GeraXml.bel.NFe.Manifestacao;
using HLP.GeraXml.dao;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HLP.GeraXml.UI.NFe
{
    public partial class frmManifestacaoEvento : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        List<KeyValuePair<string, string>> lTpEventos = new List<KeyValuePair<string, string>>();

        public frmManifestacaoEvento()
        {
            InitializeComponent();
            lTpEventos.Add(new KeyValuePair<string, string>("210200", "S"));
            lTpEventos.Add(new KeyValuePair<string, string>("210210", "C"));
            lTpEventos.Add(new KeyValuePair<string, string>("210220", "D"));
            lTpEventos.Add(new KeyValuePair<string, string>("210240", "N"));

            dtpIni.Value = dtpFim.Value = DateTime.Now;
        }

        public belManifestacaoPesquisa objPesquisa { get; set; }

        private void btnPesquisa_Click(object sender, EventArgs e)
        {
            Pesquisa();
        }

        public void Pesquisa()
        {
            try
            {

                belManifestacaoPesquisa.Filtro filtro = new belManifestacaoPesquisa.Filtro();
                string sValor1 = string.Empty;
                string sValor2 = string.Empty;
                if (cboFiltro.cbx.SelectedIndex == 0)
                {
                    filtro = belManifestacaoPesquisa.Filtro.Data;
                    sValor1 = dtpIni.Value.ToString();
                    sValor2 = dtpFim.Value.ToString();
                }
                else if (cboFiltro.cbx.SelectedIndex == 1)
                {
                    filtro = belManifestacaoPesquisa.Filtro.Cliente;
                    sValor1 = txtCliente.Text;
                }
                else if (cboFiltro.cbx.SelectedIndex == 2)
                {
                    filtro = belManifestacaoPesquisa.Filtro.Chave;
                    sValor1 = txtCliente.Text;
                }

                objPesquisa = new belManifestacaoPesquisa(filtro, sValor1, sValor2);
                bsPesquisa.DataSource = objPesquisa.lresult;
                ColoriGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmManifestacaoEvento_Load(object sender, EventArgs e)
        {
            cboFiltro.cbx.SelectedIndexChanged += new EventHandler(cbx_SelectedIndexChanged);
            cboFiltro.SelectedIndex = 0;
        }

        private void cbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtCliente.Visible = false;
            dtpIni.Visible = false;
            dtpFim.Visible = false;
            if (cboFiltro.SelectedIndex == 0)
            {
                dtpIni.Visible = true;
                dtpFim.Visible = true;
            }
            else if (cboFiltro.SelectedIndex == 1 || cboFiltro.SelectedIndex == 2)
            {
                txtCliente._TamanhoTextBox = 200;
                txtCliente.Visible = true;
            }
        }


        private void btnFindFiles_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog f = new OpenFileDialog();
                f.Filter = "XML Files|*.xml";
                f.Multiselect = true;
                objPesquisa.lresult = new List<belManifestacaoPesquisa>();

                if (f.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    belManifestacaoPesquisa obj = null;
                    nfeProc nfe = null;
                    foreach (string path in f.FileNames)
                    {
                        nfe = SerializeClassToXml.DeserializeClasse<nfeProc>(path);
                        obj = new belManifestacaoPesquisa(nfe);
                        objPesquisa.lresult.AddRange(obj.lresult);
                    }
                    bsPesquisa.DataSource = objPesquisa.lresult;
                    ColoriGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetEventos_Click(object sender, EventArgs e)
        {
            try
            {

                //var dadosParaEvento = this.objPesquisa.lresult.Where(c => c.bSeleciona && c.stManifesto == "");
                //var dadosJaComEvento = this.objPesquisa.lresult.Where(c => c.bSeleciona && c.stManifesto != "");

                var dadosParaEvento = this.objPesquisa.lresult.Where(c => c.bSeleciona);
                var dadosJaComEvento = this.objPesquisa.lresult.Where(c => c.bSeleciona && c.stManifesto == "x");
                if (dadosJaComEvento.Count() > 0)
                {
                    MessageBox.Show("Notas com evento já vinculado não podem ser manifestadas novamente.", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                belEventosNFe evento = null;
                ToolStripButton btn = sender as ToolStripButton;
                string sCodigoEvento = "";
                string sTipoRegistro = "";
                string xJust = null;

                if (btn.Name == btnCiencia.Name)
                {
                    sCodigoEvento = "210210";
                    sTipoRegistro = "C";
                }
                else if (btn.Name == btnConfirmacao.Name)
                {
                    sCodigoEvento = "210200";
                    sTipoRegistro = "S";
                }
                else if (btn.Name == btnDesconhecimento.Name)
                {
                    sCodigoEvento = "210220";
                    sTipoRegistro = "D";
                }
                else if (btn.Name == btnNaoRealizado.Name)
                {
                    sCodigoEvento = "210240";
                    sTipoRegistro = "N";
                    frmMotivoOperacaoNaoRealizada objfrm = new frmMotivoOperacaoNaoRealizada();
                    objfrm.ShowDialog();
                    if (objfrm.bValida)
                    {
                        xJust = objfrm.xJust;
                    }
                    else
                    {
                        throw new Exception("Operação cancelado pelo Usuário.");
                    }
                }


                string sMessage = string.Empty;
                //iCountEvento = 1;
                foreach (var nf in dadosParaEvento)
                {

                    evento = new belEventosNFe(nf.xChaveNFe, sCodigoEvento, belEventosNFe.tipoEvento.MANIFESTO, 1, xJust);
                    nf.sXMLretorno = evento.ExecuteEvento();
                    //ExecutaEvento(nf, sCodigoEvento, xJust);
                    sMessage = sMessage + nf.TrataRetornoManifestacao(sTipoRegistro);
                }
                this.ColoriGrid();

                MessageBox.Show(sMessage, "A V I S O", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //int iCountEvento = 1;
        //public void ExecutaEvento(belManifestacaoPesquisa o, string sCodigoEvento, string xJust)
        //{
        //    belEventosNFe evento = new belEventosNFe(o.xChaveNFe, sCodigoEvento, belEventosNFe.tipoEvento.MANIFESTO, iCountEvento, xJust);
        //    o.sXMLretorno = evento.ExecuteEvento();
        //    if (o.objRet.retEvento != null)
        //    {
        //        if (o.objRet.retEvento.infEvento.cStat == "" && iCountEvento < 3)
        //        {
        //            iCountEvento = iCountEvento + 1;
        //            ExecutaEvento(o, sCodigoEvento, xJust);
        //        }
        //    }
        //}


        private void ColoriGrid()
        {
            foreach (var item in objPesquisa.lresult)
            {
                item.stManifesto = daoUtil.GetStatusManifestacao(item.xChaveNFe);
            }
            for (int i = 0; i < dgvArquivos.RowCount; i++)
            {

                if (dgvArquivos["stManifesto", i].Value.ToString() == "C")
                {
                    dgvArquivos.Rows[i].DefaultCellStyle.BackColor = Color.LightGreen;
                }
                else if (dgvArquivos["stManifesto", i].Value.ToString() == "S")
                {
                    dgvArquivos.Rows[i].DefaultCellStyle.BackColor = Color.LightCyan;
                }
                else if (dgvArquivos["stManifesto", i].Value.ToString() == "D")
                {
                    dgvArquivos.Rows[i].DefaultCellStyle.BackColor = Color.Silver;
                }
                else if (dgvArquivos["stManifesto", i].Value.ToString() == "N")
                {
                    dgvArquivos.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                }
                else
                {
                    dgvArquivos.Rows[i].DefaultCellStyle.BackColor = Color.White;
                }
            }

        }

        bool bMarcar = false;
        bool bEmissao = false;
        bool bCdChave = false;
        bool bCNPJ = false;
        bool bRazaoSocial = false;
        bool bNFe = false;
        bool bTotal = false;

        private void dgvNF_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 0 && objPesquisa.lresult != null)
                {
                    bMarcar = !bMarcar;
                    foreach (var nota in objPesquisa.lresult)
                    {
                        nota.bSeleciona = bMarcar;
                    }

                    dgvArquivos.Refresh();
                }
                if (e.ColumnIndex == 0)
                {
                    SendKeys.Send("{right}");
                    SendKeys.Send("{left}");
                }
                else if (e.ColumnIndex == 1)
                {
                    if (bEmissao)
                        bsPesquisa.DataSource = this.objPesquisa.lresult.OrderBy(c => c.dtEmissao);
                    else
                        bsPesquisa.DataSource = this.objPesquisa.lresult.OrderByDescending(c => c.dtEmissao);
                    bEmissao = !bEmissao;

                }
                else if (e.ColumnIndex == 2)
                {
                    if (bCdChave)
                        bsPesquisa.DataSource = this.objPesquisa.lresult.OrderBy(c => c.xChaveNFe);
                    else
                        bsPesquisa.DataSource = this.objPesquisa.lresult.OrderByDescending(c => c.xChaveNFe);
                    bCdChave = !bCdChave;

                }
                else if (e.ColumnIndex == 3)
                {
                    if (bRazaoSocial)
                        bsPesquisa.DataSource = this.objPesquisa.lresult.OrderBy(c => c.xRazaoSocial);
                    else
                        bsPesquisa.DataSource = this.objPesquisa.lresult.OrderByDescending(c => c.xRazaoSocial);
                    bRazaoSocial = !bRazaoSocial;

                }
                else if (e.ColumnIndex == 4)
                {
                    if (bCNPJ)
                        bsPesquisa.DataSource = this.objPesquisa.lresult.OrderBy(c => c.xCNPJ);
                    else
                        bsPesquisa.DataSource = this.objPesquisa.lresult.OrderByDescending(c => c.xCNPJ);
                    bCNPJ = !bCNPJ;

                }
                else if (e.ColumnIndex == 5)
                {
                    if (bNFe)
                        bsPesquisa.DataSource = this.objPesquisa.lresult.OrderBy(c => c.xNumero);
                    else
                        bsPesquisa.DataSource = this.objPesquisa.lresult.OrderByDescending(c => c.xNumero);
                    bNFe = !bNFe;
                }
                else if (e.ColumnIndex == 6)
                {
                    if (bTotal)
                        bsPesquisa.DataSource = this.objPesquisa.lresult.OrderBy(c => c.dTotalNFe);
                    else
                        bsPesquisa.DataSource = this.objPesquisa.lresult.OrderByDescending(c => c.dTotalNFe);
                    bTotal = !bTotal;
                }


                if (e.ColumnIndex > 0)
                    this.ColoriGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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

    }
}
