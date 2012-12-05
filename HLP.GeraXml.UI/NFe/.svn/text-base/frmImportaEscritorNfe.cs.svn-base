using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using HLP.GeraXml.bel.NFe.Estrutura;
using HLP.GeraXml.bel.Escrita;
using HLP.GeraXml.Comum;
using System.IO;
using HLP.GeraXml.Comum.Static;

namespace HLP.GeraXml.UI.NFe
{
    public partial class frmImportaEscritorNfe : KryptonForm
    {
        struct strucArquivo
        {
            public string Arquivo { get; set; }
            public String NFE { get; set; }
            public string Nota { get; set; }
            public string Emitente { get; set; }
            public string Destinatario { get; set; }
            public DateTime Emissao { get; set; }
        }
        struct strucXmlValidacao
        {
            public string Xml { get; set; }
            public string Motivo { get; set; }
        }
        bool bMarcar = false;


        public frmImportaEscritorNfe()
        {
            InitializeComponent();

            ButtonSpecAny btnPastaPadrao = new ButtonSpecAny();
            btnPastaPadrao.UniqueName = "btnPastaPadrao";
            btnPastaPadrao.Image = HLP.GeraXml.UI.Properties.Resources.Pasta;
            btnPastaPadrao.Style = ComponentFactory.Krypton.Toolkit.PaletteButtonStyle.InputControl;
            btnPastaPadrao.Click += new EventHandler(btnPastaPadrao_Click);
            txtXml.txt.ButtonSpecs.Add(btnPastaPadrao);
        }
        private void frmImportaEscritorNfe_Load(object sender, EventArgs e)
        {
            try
            {
                belInfNFe objInfNFe = new belInfNFe();
                belEscrituracao objEscrituracao = new belEscrituracao(objInfNFe);

                cbxEmpresas.DisplayMember = "Descricao";
                cbxEmpresas.ValueMember = "Codigo";

                cbxEmpresas.DataSource = objEscrituracao.RetornaEmpresa();
            }
            catch (Exception ex)
            {
                new HLPexception(ex);
            }
        }


        #region Metodos

        private List<strucArquivo> MontaStrucArquivos(string[] Arquivos)
        {
            List<strucArquivo> objArquivos = new List<strucArquivo>();
            List<strucXmlValidacao> objLisXmlNaoValidado = new List<strucXmlValidacao>();

            string sNomearq = string.Empty;

            try
            {
                foreach (string sArquivo in Arquivos)
                {
                    strucArquivo objArquivo = new strucArquivo();
                    objArquivo.Arquivo = sArquivo.ToString();
                    sNomearq = sArquivo;
                    belImportaXmlNFe xmlEscritor = new belImportaXmlNFe(sNomearq);

                    try
                    {
                        belInfNFe objInfNFe = xmlEscritor.MontaInfNFe();
                        if (objInfNFe != null)
                        {
                            objArquivo.Nota = objInfNFe.ide.Nnf;
                            objArquivo.Emitente = objInfNFe.emit.Xnome;
                            objArquivo.Destinatario = objInfNFe.dest.Xnome;
                            objArquivo.Emissao = objInfNFe.ide.Demi;
                            objArquivo.NFE = objInfNFe.id;

                            objArquivos.Add(objArquivo);
                        }
                        else
                        {
                            strucXmlValidacao obj = new strucXmlValidacao();
                            obj.Xml = sNomearq;
                            obj.Motivo = "Não foi encontrado a Tag 'protNFe'.  Xml não é válid0";
                            objLisXmlNaoValidado.Add(obj);
                        }
                    }
                    catch (Exception ex)
                    {
                        strucXmlValidacao obj = new strucXmlValidacao();
                        obj.Xml = sNomearq;
                        obj.Motivo = ex.Message;
                        objLisXmlNaoValidado.Add(obj);
                    }
                }

            }
            catch (Exception ex)
            {
                //throw new Exception(string.Format("Não foi possivel ler o arquivo {0}, devido ao Erro.: {1}",
                //                                  sNomearq,
                //                                  ex.Message));
                strucXmlValidacao obj = new strucXmlValidacao();
                obj.Xml = sNomearq;
                obj.Motivo = ex.Message;
                objLisXmlNaoValidado.Add(obj);
            }
            dgvXmlNaoValidado.DataSource = objLisXmlNaoValidado;
            if (objLisXmlNaoValidado.Count > 0)
            {
                lblXmlNaoValidado.Text = objLisXmlNaoValidado.Count.ToString() + " arquivo(s) não válido(s)";
            }
            else
            {
                lblXmlNaoValidado.Text = "";
            }

            return objArquivos;
        }
        private void MarcadesmarcaTodos(bool Marca, int coluna)
        {
            for (int i = 0; i < dgvXmls.RowCount; i++)
            {
                dgvXmls.Rows[i].Cells[coluna].Value = Marca;
            }
        }

        #endregion



        private void btnPastaPadrao_Click(object sender, EventArgs e)
        {
            if (fbdImportar.ShowDialog() == DialogResult.OK)
            {
                txtXml.Text = fbdImportar.SelectedPath;
            }
        }
        private void btnPesquisa_Click(object sender, EventArgs e)
        {
            lblarquivosEscriturados.Text = "";
            List<strucArquivo> objArquivos = new List<strucArquivo>();
            try
            {
                if (txtXml.Text == "")
                {
                    throw new Exception("Pasta dos Arquivos Xml não foi selecionada");
                }

                if (cbxEmpresas.SelectedValue.ToString() == "")
                {
                    throw new Exception("Empresa para Importação não foi selecionada");
                }

                string[] Arquivos = Directory.GetFiles(@txtXml.Text, "*.xml");

                objArquivos = MontaStrucArquivos(Arquivos);
                lblStatusScrituracao.Text = objArquivos.Count.ToString() + "  arquivo(s) válido(s)";

            }
            catch (Exception ex)
            {
                new HLPexception(ex);
            }

            dgvXmls.DataSource = objArquivos;
            for (int i = 0; i < dgvXmls.RowCount; i++)
            {
                dgvXmls[0, i].Value = false;
            }
        }
        private void btnImporta_Click(object sender, EventArgs e)
        {
            string sArquivoXML = string.Empty;
            try
            {
                if (txtXml.Text == "")
                {
                    throw new Exception("Pasta dos Arquivos Xml não foi selecionada");
                }

                if (cbxEmpresas.SelectedValue.ToString() == "")
                {
                    throw new Exception("Empresa para Importação não foi selecionada");
                }

                List<string> lsXmls = new List<string>();

                for (int i = 0; i < dgvXmls.RowCount; i++)
                {
                    if (((dgvXmls["Selecionar", i].Value != null) && (dgvXmls["Selecionar", i].Value.ToString().Equals("True"))))
                    {
                        lsXmls.Add((string)dgvXmls["Arquivo", i].Value);
                    }

                }

                if (lsXmls.Count > 0)
                {
                    pgbNF.Step = 1;
                    pgbNF.Minimum = 0;
                    pgbNF.Maximum = lsXmls.Count;
                    pgbNF.MarqueeAnimationSpeed = lsXmls.Count;
                    pgbNF.Value = 0;

                    for (int i = 0; i < lsXmls.Count; i++)
                    {
                        try
                        {
                            lblStatusScrituracao.Text = "Escriturando " + (i + 1).ToString() + " de " + lsXmls.Count.ToString();
                            pgbNF.PerformStep();
                            statusStrip1.Refresh();
                            this.Refresh();
                            sArquivoXML = lsXmls[i];
                            belImportaXmlNFe xmlEscritor = new belImportaXmlNFe(lsXmls[i]);
                            belInfNFe objInfNFe = xmlEscritor.MontaInfNFe();
                            objInfNFe.Empresa = cbxEmpresas.SelectedValue.ToString();
                            belEscrituracao objEscrituracao = new belEscrituracao(objInfNFe);
                        }
                        catch (Exception ex)
                        {
                            new HLPexception(ex);
                        }

                    }
                    KryptonMessageBox.Show(null,
                                    string.Format("Importação efetuada com Sucesso!"),
                                    "Importação de XML",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    pgbNF.Value = 0;
                    //toolStripButton2_Click(sender, e);
                    lblarquivosEscriturados.Text = "Escriturado " + lsXmls.Count.ToString() + " registro(s) de " + lsXmls.Count.ToString();



                }
                else
                {
                    KryptonMessageBox.Show(null,
                                    string.Format("Nenhum Xml Foi selecionado!"),
                                    "Importação de XML",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);

                }
            }
            catch (Exception ex)
            {
                if (!String.IsNullOrEmpty(sArquivoXML))
                {

                    KryptonMessageBox.Show(null,
                                    string.Format("Não foi possível importar o Xml. Erro {0}, Lendo o Arquivo {1}",
                                                  ex.Message,
                                                  sArquivoXML),
                                    Mensagens.MSG_Aviso,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                }
                else
                {
                    new HLPexception(ex);
                }
            }
        }


        private void dgvXmls_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.RowIndex > -1) && (e.ColumnIndex == 0))
            {
                if (dgvXmls[0, e.RowIndex].Value.ToString() == "False")
                {
                    dgvXmls[0, e.RowIndex].Value = true;
                    SendKeys.Send("{right}");
                    SendKeys.Send("{left}");

                }
                else
                {
                    dgvXmls[0, e.RowIndex].Value = false;
                    SendKeys.Send("{right}");
                    SendKeys.Send("{left}");
                    //SendKeys.Send("{LEFT}");
                }
            }
        }
        private void dgvXmls_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (((e.ColumnIndex == 0)) && (dgvXmls.DataSource != null))
            {
                if (bMarcar == false)
                {
                    MarcadesmarcaTodos(true, e.ColumnIndex);
                    bMarcar = true;
                    SendKeys.Send("{ENTER}");
                }
                else
                {
                    MarcadesmarcaTodos(false, e.ColumnIndex);
                    bMarcar = false;
                    SendKeys.Send("{ENTER}");
                }
            }
        }
    }
}