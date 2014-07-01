using HLP.GeraXml.bel;
using HLP.GeraXml.bel.MDFe;
using HLP.GeraXml.bel.MDFe.Acoes;
using HLP.GeraXml.Comum;
using HLP.GeraXml.Comum.Static;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using HLP.GeraXml.UI.Relatorios;
using System.IO;
using CrystalDecisions.CrystalReports.Engine;

namespace HLP.GeraXml.UI.CTe.Manifesto
{
    public partial class frmGerarArquivosMDFe : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        public bool bMarcar { get; set; }
        private dsMDFe dsMdfe;
        dsMDFe.MDFeRow rowMdfe;
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
                    else if (Convert.ToBoolean(dgvArquivos["bEnviado", i].Value) == true && dgvArquivos["status", i].Value.ToString() == "S")
                    {
                        dgvArquivos.Rows[i].DefaultCellStyle.BackColor = Color.DeepSkyBlue;
                    }
                    else if (Convert.ToBoolean(dgvArquivos["bEnviado", i].Value) == false && dgvArquivos["recibo", i].Value.ToString() != "")
                    {
                        dgvArquivos.Rows[i].DefaultCellStyle.BackColor = Color.LightCyan;
                    }
                    else if (Convert.ToBoolean(dgvArquivos["bEnviado", i].Value) == true && dgvArquivos["status", i].Value.ToString() == "E") // ENCERRADO
                    {
                        dgvArquivos.Rows[i].DefaultCellStyle.BackColor = Color.LightGreen;
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
                                  c.recibo != "" && c.bSeleciona && (c.status == "S" || c.status == "")
                                  ).ToList();
            if (objSelect.Count() > 0)
            {
                bool bValida = false;
                if (objSelect.FirstOrDefault().recibo != "")
                {
                    DateTime? d = HLP.GeraXml.dao.CTe.MDFe.daoManifesto.GetUltimoRetorno(objSelect.FirstOrDefault().sequencia);
                    if (d != null)
                    {
                        if (((DateTime)d).AddMinutes(2) < dao.daoUtil.GetDateServidor())
                            bValida = true;
                        else
                        {
                            bValida = false;
                            MessageBox.Show(string.Format("Último retorno foi a menos de 2 minutos ({0}), aguarde mais um pouco.", d.ToString()), "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                if (bValida)
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
                        m.chaveMDFe = objManifesto.enviMDFe.MDFe.infMDFe.Id.Replace("MDFe", "");
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
                                       c.status != "" &&
                                       c.protocolo != "" && c.bSeleciona
                                       ).ToList();

                if (objSelect.Count() > 1)
                {
                    MessageBox.Show("Selecione apenas um manifesto por vez.", "A V I S O", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (objSelect.Count() == 1)
                {

                    //belCancelamentoMDFe canc = new belCancelamentoMDFe(objSelect.FirstOrDefault())
                    frmCancelarMDFe objfrm = new frmCancelarMDFe(objSelect.FirstOrDefault());
                    objfrm.ShowDialog();
                    Pesquisar();
                }
            }
            catch (Exception ex)
            {

                throw new HLPexception(ex);
            }
        }

        private void btnEncerramento_Click(object sender, EventArgs e)
        {
            try
            {
                List<PesquisaManifestosModel> objSelect = this.objPesquisa.resultado.Where(c =>
                                       c.bCancelado == false &&
                                       c.bEnviado == true &&
                                       c.status == "S" &&
                                       c.protocolo != "" && c.bSeleciona
                                       ).ToList();

                if (objSelect.Count() > 1)
                {
                    MessageBox.Show("Selecione apenas um manifesto por vez.", "A V I S O", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (objSelect.Count() == 1)
                {
                    frmEncerramentoMDFe objfrm = new frmEncerramentoMDFe(objSelect.FirstOrDefault());
                    objfrm.ShowDialog();
                    Pesquisar();
                }
            }
            catch (Exception ex)
            {

                throw new HLPexception(ex);
            }

        }


        public static Byte[] SalvaCodBarras(string sValor)
        {
            BarcodeLib.Barcode barcod = new BarcodeLib.Barcode(sValor, BarcodeLib.TYPE.CODE128C);
            barcod.Encode(BarcodeLib.TYPE.CODE128, sValor, 300, 150);

            string sCaminho = "";
            sCaminho = Pastas.CBARRAS + "\\Barras_" + sValor + ".JPG";
            barcod.SaveImage(@sCaminho, BarcodeLib.SaveTypes.JPG);

            return Util.CarregaImagem(sCaminho);
        }
        private void btnImpressao_Click(object sender, EventArgs e)
        {
            try
            {

                List<PesquisaManifestosModel> objSelect = this.objPesquisa.resultado.Where(c =>
                                       c.bEnviado == true &&
                                       c.recibo != "" && c.bSeleciona && c.protocolo != ""
                                       ).ToList();

                dsMdfe = new dsMDFe();
                foreach (PesquisaManifestosModel item in objSelect)
                {
                    rowMdfe = dsMdfe.MDFe.NewMDFeRow();
                    Byte[] bimagem = SalvaCodBarras(item.chaveMDFe);
                    rowMdfe.barras = bimagem;
                    rowMdfe.logotipo = Util.CarregaLogoEmpresa();

                    string sPath = "";

                    if (item.bCancelado)
                        sPath = Util.BuscaCaminhoArquivoXml(item.chaveMDFe, 2, true);
                    else
                        sPath = Util.BuscaCaminhoArquivoXml(item.chaveMDFe, 2);
                    XmlDocument xml = new XmlDocument();
                    xml.Load(sPath);
                    XmlNodeList node = xml.GetElementsByTagName("infModal");

                    mdfeProc objEnvi = SerializeClassToXml.DeserializeClasse<mdfeProc>(sPath);
                    rodo objRodo = SerializeClassToXml.DeserializeClasseString<rodo>(node[0].InnerXml.ToString());
                    rowMdfe.xEmpresa = string.Format("{0}{10}CNPJ:{1} - IE:{2}, RNTRC:{3} - Logradouro:{4}, nº{5} - Bairro:{6}, {7}/{8} Cep:{9}",
                        objEnvi.enviMDFe.MDFe.infMDFe.emit.xNome,
                        objEnvi.enviMDFe.MDFe.infMDFe.emit.CNPJ,
                        objEnvi.enviMDFe.MDFe.infMDFe.emit.IE,
                        objRodo.RNTRC,
                        objEnvi.enviMDFe.MDFe.infMDFe.emit.enderEmit.xLgr,
                        objEnvi.enviMDFe.MDFe.infMDFe.emit.enderEmit.nro,
                        objEnvi.enviMDFe.MDFe.infMDFe.emit.enderEmit.xBairro,
                        objEnvi.enviMDFe.MDFe.infMDFe.emit.enderEmit.UF,
                        objEnvi.enviMDFe.MDFe.infMDFe.emit.enderEmit.xMun,
                        objEnvi.enviMDFe.MDFe.infMDFe.emit.enderEmit.CEP, Environment.NewLine);

                    rowMdfe.ufCarreg = objEnvi.enviMDFe.MDFe.infMDFe.ide.UFIni;
                    rowMdfe.numero = item.numero;
                    rowMdfe.chave = item.chaveMDFe;
                    rowMdfe.protocolo = item.protocolo;
                    rowMdfe.serie = objEnvi.enviMDFe.MDFe.infMDFe.ide.serie;
                    rowMdfe.dataEmissao = Convert.ToDateTime(objEnvi.enviMDFe.MDFe.infMDFe.ide.dhEmi).ToShortDateString();
                    rowMdfe.CIOT = objRodo.CIOT;
                    rowMdfe.qtdeCT = objEnvi.enviMDFe.MDFe.infMDFe.tot.qCT == null ? "0" : objEnvi.enviMDFe.MDFe.infMDFe.tot.qCT.ToString();
                    rowMdfe.qtdeCTE = objEnvi.enviMDFe.MDFe.infMDFe.tot.qCTe == null ? "0" : objEnvi.enviMDFe.MDFe.infMDFe.tot.qCTe;
                    rowMdfe.qtdeNF = objEnvi.enviMDFe.MDFe.infMDFe.tot.qNF == null ? "0" : objEnvi.enviMDFe.MDFe.infMDFe.tot.qNF;
                    rowMdfe.qtdeNFe = objEnvi.enviMDFe.MDFe.infMDFe.tot.qNFe == null ? "0" : objEnvi.enviMDFe.MDFe.infMDFe.tot.qNFe;
                    rowMdfe.pesoTotal = objEnvi.enviMDFe.MDFe.infMDFe.tot.qCarga;

                    rowMdfe.veicPlaca = objRodo.veicTracao.placa + Environment.NewLine;
                    foreach (var v in objRodo.veicReboque)
                    {
                        rowMdfe.veicPlaca += v.placa + Environment.NewLine;
                    }

                    if (objRodo.veicTracao.prop != null)
                        rowMdfe.veicRNTRC = objRodo.veicTracao.prop.RNTRC + Environment.NewLine;

                    foreach (var v in objRodo.veicReboque)
                    {
                        if (v.prop != null)
                            rowMdfe.veicRNTRC += v.prop.RNTRC + Environment.NewLine;
                    }
                    if (objRodo.veicTracao.condutor != null)
                    {
                        foreach (var cond in objRodo.veicTracao.condutor)
                        {
                            rowMdfe.Condutor_cpf += cond.CPF + Environment.NewLine;
                            rowMdfe.Condutor_Nome += cond.xNome + Environment.NewLine;
                        }
                    }

                    if (objRodo.valePed != null)
                    {
                        foreach (var vale in objRodo.valePed)
                        {
                            rowMdfe.Pedagio_Resp_cnp += vale.CNPJPg + Environment.NewLine;
                            rowMdfe.Pedagio_Forn_cnpj += vale.CNPJForn + Environment.NewLine;
                            rowMdfe.Pedagio_comprovante += vale.nCompra + Environment.NewLine;
                        }
                    }

                    string sDocEletronico = "{0} - Chave: {1}{2}";
                    rowMdfe.documentos_Fiscais = "";
                    foreach (var doc in objEnvi.enviMDFe.MDFe.infMDFe.infDoc)
                    {
                        if (doc.infCTe != null)
                            foreach (var cte in doc.infCTe)
                            {
                                rowMdfe.documentos_Fiscais += string.Format(sDocEletronico, "CTe", cte.chCTe, Environment.NewLine);
                            }
                        if (doc.infNFe != null)
                            foreach (var nfe in doc.infNFe)
                            {
                                rowMdfe.documentos_Fiscais += string.Format(sDocEletronico, "NFe", nfe.chNFe, Environment.NewLine);
                            }
                        if (doc.infNF != null)
                            foreach (var nf in doc.infNF)
                            {
                                rowMdfe.documentos_Fiscais += string.Format("{0} - CNPJ{1} - Serie:{2} - Nº {3}{4}", "NF", nf.CNPJ, nf.serie, nf.nNF, Environment.NewLine);
                            }
                        if (doc.infCT != null)
                            foreach (var ct in doc.infCT)
                            {
                                rowMdfe.documentos_Fiscais += string.Format("{0} - Serie:{1} - Nº {2}{3}", "CT", ct.serie, ct.nCT, Environment.NewLine);
                            }
                    }
                    if (objEnvi.enviMDFe.MDFe.infMDFe.infAdic != null)
                        rowMdfe.observacao = objEnvi.enviMDFe.MDFe.infMDFe.infAdic.infCpl;

                    if (item.bCancelado)
                        rowMdfe.observacao = "***** CONHECIMENTO CANCELADO *****" + Environment.NewLine + rowMdfe.observacao;

                    // objPrint.ldados.Add(obj);
                    dsMdfe.MDFe.Rows.Add(rowMdfe);
                }
                Print();

            }
            catch (Exception ex)
            {
                throw new HLPexception(ex);
            }

        }

        private void Print()
        {
            ReportDocument rpt = new ReportDocument();
            rpt.Load(Util.GetPathRelatorio("RelDamdfe.rpt"));
            rpt.SetDataSource(dsMdfe);
            frmRelatorio objfrmDanfe = new frmRelatorio(rpt, "Impressão de DAMDFE");
            objfrmDanfe.ShowDialog();
        }

        private void dgvArquivos_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (dgvArquivos.Rows.Count > 0)
                {
                    if (e.ColumnIndex == 0 && bsGrid.DataSource != null)
                    {

                        bMarcar = !bMarcar;
                        foreach (PesquisaManifestosModel nota in bsGrid.List)
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
                }
            }
            catch (Exception ex)
            {
                throw new HLPexception(ex);
            }
        }


    }
}
