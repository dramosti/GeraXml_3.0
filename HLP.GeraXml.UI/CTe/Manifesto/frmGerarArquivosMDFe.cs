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
                }
            }
            catch (Exception)
            {

                throw;
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
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        private void btnImpressao_Click(object sender, EventArgs e)
        {
            try
            {

                List<PesquisaManifestosModel> objSelect = this.objPesquisa.resultado.Where(c =>
                                       c.bEnviado == true &&
                                       c.recibo != "" && c.bSeleciona && c.protocolo != ""
                                       ).ToList();

                objSelect = objPesquisa.resultado.ToList(); // PARA TESTEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE

                List<belPrintMDFe> lResult = new List<belPrintMDFe>();
                belPrintMDFe obj;

                foreach (PesquisaManifestosModel item in objSelect)
                {
                    obj = new belPrintMDFe();
                    string sPath = Util.BuscaCaminhoArquivoXml(item.chaveMDFe, 2);
                    XmlDocument xml = new XmlDocument();
                    xml.Load(sPath);
                    XmlNodeList node = xml.GetElementsByTagName("infModal");

                    TEnviMDFe objEnvi = SerializeClassToXml.DeserializeClasse<TEnviMDFe>(sPath);
                    rodo objRodo = SerializeClassToXml.DeserializeClasseString<rodo>(node[0].InnerXml.ToString());

                    obj.xEmpresa = string.Format("CNPJ:{0} IE:{1} RNTRC:{2} Razão Social:{3} Logradouro:{4} nº {5} Bairro:{6} UF:{7} Município:{8} Cep:{9}",
                        objEnvi.MDFe.infMDFe.emit.CNPJ,
                        objEnvi.MDFe.infMDFe.emit.IE,
                        objRodo.RNTRC,
                        objEnvi.MDFe.infMDFe.emit.xNome,
                        objEnvi.MDFe.infMDFe.emit.enderEmit.xLgr,
                        objEnvi.MDFe.infMDFe.emit.enderEmit.nro,
                        objEnvi.MDFe.infMDFe.emit.enderEmit.xBairro,
                        objEnvi.MDFe.infMDFe.emit.enderEmit.UF,
                        objEnvi.MDFe.infMDFe.emit.enderEmit.xMun,
                        objEnvi.MDFe.infMDFe.emit.enderEmit.CEP);

                    obj.chave = item.chaveMDFe;
                    obj.chave = item.protocolo;
                    obj.serie = objEnvi.MDFe.infMDFe.ide.serie;
                    obj.dataEmissao = Convert.ToDateTime(objEnvi.MDFe.infMDFe.ide.dhEmi).ToShortDateString();
                    obj.CIOT = objRodo.CIOT;
                    obj.qtdeCT = objEnvi.MDFe.infMDFe.tot.qCT == null ? "0" : objEnvi.MDFe.infMDFe.tot.qCT.ToString();
                    obj.qtdeCTe = objEnvi.MDFe.infMDFe.tot.qCTe == null ? "0" : objEnvi.MDFe.infMDFe.tot.qCTe;
                    obj.qtdeNF = objEnvi.MDFe.infMDFe.tot.qNF == null ? "0" : objEnvi.MDFe.infMDFe.tot.qNF;
                    obj.qtdeNFe = objEnvi.MDFe.infMDFe.tot.qNFe == null ? "0" : objEnvi.MDFe.infMDFe.tot.qNFe;
                    obj.pesoTotal = objEnvi.MDFe.infMDFe.tot.qCarga;

                    obj.veicPlaca = objRodo.veicTracao.placa + Environment.NewLine;
                    foreach (var v in objRodo.veicReboque)
                    {
                        obj.veicPlaca += v.placa + Environment.NewLine;
                    }

                    if (objRodo.veicTracao.prop != null)
                        obj.veicRNTRC = objRodo.veicTracao.prop.RNTRC + Environment.NewLine;

                    foreach (var v in objRodo.veicReboque)
                    {
                        if (v.prop != null)
                            obj.veicRNTRC += v.prop.RNTRC + Environment.NewLine;
                    }
                    if (objRodo.veicTracao.condutor != null)
                    {
                        foreach (var cond in objRodo.veicTracao.condutor)
                        {
                            obj.Condutor_cpf += cond.CPF + Environment.NewLine;
                            obj.Condutor_Nome += cond.xNome + Environment.NewLine;
                        }
                    }

                    if (objRodo.valePed != null)
                    {
                        foreach (var vale in objRodo.valePed)
                        {
                            obj.Pedagio_Resp_cnp += vale.CNPJPg + Environment.NewLine;
                            obj.Pedagio_Forn_cnpj += vale.CNPJForn + Environment.NewLine;
                            obj.Pedagio_comprovante += vale.nCompra + Environment.NewLine;
                        }
                    }

                    string sDocEletronico = "{0} - Chave: {1}{2}";
                    foreach (var doc in objEnvi.MDFe.infMDFe.infDoc)
                    {
                        if (doc.infCTe != null)
                            foreach (var cte in doc.infCTe)
                            {
                                obj.documentos_Fiscais = string.Format(sDocEletronico, "CTe", cte.chCTe, Environment.NewLine);
                            }
                        if (doc.infNFe != null)
                            foreach (var nfe in doc.infNFe)
                            {
                                obj.documentos_Fiscais = string.Format(sDocEletronico, "NFe", nfe.chNFe, Environment.NewLine);
                            }
                        if (doc.infNF != null)
                            foreach (var nf in doc.infNF)
                            {
                                obj.documentos_Fiscais = string.Format("{0} - CNPJ{1} - Serie:{2} - Nº {3}{4}", "NF", nf.CNPJ, nf.serie, nf.nNF, Environment.NewLine);
                            }
                        if (doc.infCT != null)
                            foreach (var ct in doc.infCT)
                            {
                                obj.documentos_Fiscais = string.Format("{0} - Serie:{1} - Nº {2}{3}", "CT", ct.serie, ct.nCT, Environment.NewLine);
                            }
                    }
                    if (objEnvi.MDFe.infMDFe.infAdic != null)
                        obj.observacao = objEnvi.MDFe.infMDFe.infAdic.infCpl;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


    }
}
