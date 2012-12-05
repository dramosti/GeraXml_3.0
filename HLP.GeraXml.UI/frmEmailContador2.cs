using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using HLP.GeraXml.Comum.Static;
using System.IO;
using HLP.GeraXml.bel;
using System.Linq;
using ICSharpCode.SharpZipLib.Zip;
using HLP.GeraXml.Comum;

namespace HLP.GeraXml.UI
{
    public partial class frmEmailContador2 : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        private static string sPathArquivoSerializer = Pastas.ENVIADOS + "Contador_xml\\" + "Dados.xml";
        private static string sPathOldArquivo = Pastas.ENVIADOS + "\\Contador_xml\\" + "ConfigDia.txt";

        private ConfigEmailContadorXml dadosArquivos = new ConfigEmailContadorXml();
        private List<PendenciaEmail> lpendencias = new List<PendenciaEmail>();

        public frmEmailContador2()
        {
            InitializeComponent();
        }
        private void frmEmailContador2_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Acesso.EMAIL_CONTADOR.Equals(""))
                {
                    CarregaDiasDaSemana();
                    txtContador.Text = Acesso.EMAIL_CONTADOR;
                    if (File.Exists(sPathOldArquivo))
                    {
                        File.Delete(sPathOldArquivo);
                    }

                    if (File.Exists(sPathArquivoSerializer))
                    {
                        dadosArquivos = bel.belSerializeToXml.DeserializeClasse<ConfigEmailContadorXml>(sPathArquivoSerializer);
                        if (dadosArquivos.Alerta == ConfigEmailContadorXml.tpConfig.Mensalmente)
                        {
                            cbxMensalmente.Checked = true;
                            cbxSemanalmente.Checked = false;
                        }
                        else
                        {
                            cbxMensalmente.Checked = false;
                            cbxSemanalmente.Checked = true;
                            cboDia.SelectedValue = dadosArquivos.dia;
                        }
                    }
                    else
                    {
                        dadosArquivos.Alerta = ConfigEmailContadorXml.tpConfig.Mensalmente;
                        if (!Directory.Exists(Pastas.ENVIADOS + "\\Contador_xml"))
                        {
                            Directory.CreateDirectory(Pastas.ENVIADOS + "\\Contador_xml");
                        }
                    }
                    CarregaDataGrid();
                }
                else
                {
                    btnEnviar.Enabled = false;
                    txtContador.errorProvider1.SetError(txtContador, "Favor inserir o e-mail do contador no cadastro de Empresa!");
                }
            }
            catch (Exception ex)
            {
                new HLPexception(ex);
            }
        }
        void btnEnviar_Click(object sender, EventArgs e)
        {
            try
            {
                if (CompactaZip())
                {
                    List<PendenciaEmail> lEnviar = lpendencias.Where(c => c.Select).ToList();
                    belEmail objEmail = new belEmail(lEnviar, txtCopia.Text);
                    EnviaEmailTeste();
                    objEmail.EnviarEmail();
                    KryptonMessageBox.Show("E-mail enviado com sucesso!", Mensagens.CHeader, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dadosArquivos.dtUltimoEnvio = DateTime.Today;
                    bel.belSerializeToXml.SerializeClasse<ConfigEmailContadorXml>(dadosArquivos, sPathArquivoSerializer);
                    CarregaDataGrid();
                }
            }
            catch (Exception ex)
            {
                new HLPexception(ex);
            }
        }


        void CarregaDataGrid()
        {
            try
            {
                lpendencias = new List<PendenciaEmail>();
                CarregaDados(Pastas.ENVIADOS, Arquivos.tpArquivo.Enviado);
                CarregaDados(Pastas.CANCELADOS, Arquivos.tpArquivo.Cancelado);
                CarregaDados(Pastas.CCe, Arquivos.tpArquivo.CCe);
                bsPendenciaEmail.DataSource = lpendencias;

                for (int i = 0; i < dgvDados.Rows.Count; i++)
                {
                    if (!dgvDados["iFaltantes", i].Value.ToString().Equals("0"))
                    {
                        dgvDados["iFaltantes", i].Style.BackColor = Color.OldLace;
                    }

                }

            }
            catch (Exception)
            {
                throw;
            }
        }
        void CarregaDados(string sPath, Arquivos.tpArquivo tipo)
        {
            try
            {
                DirectoryInfo dinfo = new DirectoryInfo(sPath);

                foreach (DirectoryInfo item in dinfo.GetDirectories())
                {
                    if (item.Name.Length == 4)
                    {
                        string sMes = item.Name.Substring(2, 2);
                        string sAno = item.Name.Substring(0, 2);

                        PendenciaEmail objPendencias = new PendenciaEmail();
                        if (lpendencias.Where(c => c.sMes == sMes && c.sAno == sAno).Count() == 0)
                        {
                            objPendencias.sMes = sMes;
                            objPendencias.sAno = sAno;
                            objPendencias.sPathZip = Pastas.ENVIADOS + "\\Contador_xml\\" + sMes + sAno + ".zip";
                            lpendencias.Add(objPendencias);
                        }
                        else
                        {
                            objPendencias = lpendencias.FirstOrDefault(c => c.sMes == sMes && c.sAno == sAno);
                        }

                        foreach (FileInfo xml in item.GetFiles("*.xml"))
                        {
                            if (dadosArquivos.arquivosTransmitidos.Where(c => c.nameXml == xml.Name && c.tipoArquivo == tipo).Count() == 0)
                            {
                                objPendencias.larquivosPendentes.Add(new PendenciaArquivos
                                {
                                    sPathFull = xml.FullName,
                                    tipoArquivo = tipo
                                });
                            }
                        }
                        objPendencias.iFaltantes = objPendencias.larquivosPendentes.Count();
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        bool CompactaZip()
        {
            bool bCompactou = false;
            try
            {
                List<PendenciaEmail> lEnviar = lpendencias.Where(c => c.Select).ToList();
                if (lEnviar.Count() > 0)
                {
                    foreach (PendenciaEmail item in lEnviar)
                    {
                        if (File.Exists(item.sPathZip))
                        {
                            File.Delete(item.sPathZip);
                        }
                        using (ZipOutputStream objCompressed = new ZipOutputStream(File.Create(item.sPathZip)))
                        {
                            objCompressed.SetLevel(9);
                            byte[] buffer = new byte[4096];
                            ZipEntry objDateEntry = null;
                            foreach (PendenciaArquivos arquivo in item.larquivosPendentes)
                            {
                                dadosArquivos.arquivosTransmitidos.Add(new Arquivos
                                {
                                    mmYY = item.sMes + item.sAno,
                                    nameXml = Path.GetFileName(arquivo.sPathFull),
                                    tipoArquivo = arquivo.tipoArquivo
                                });
                                objDateEntry = new ZipEntry(Path.GetFileName(arquivo.sPathFull));
                                objDateEntry.DateTime = DateTime.Now;
                                objCompressed.PutNextEntry(objDateEntry);
                                using (FileStream fs = File.OpenRead(arquivo.sPathFull))
                                {
                                    int sourceBytes;
                                    do
                                    {
                                        sourceBytes = fs.Read(buffer, 0, buffer.Length);
                                        objCompressed.Write(buffer, 0, sourceBytes);

                                    } while (sourceBytes > 0);
                                }
                            }
                            objCompressed.Finish();
                            objCompressed.Close();
                            bCompactou = true;
                        }
                    }

                }
                return bCompactou;

            }
            catch (Exception ex)
            {
                bCompactou = false;
                throw ex;
            }
        }
        void EnviaEmailTeste()
        {
            try
            {
                belEmail objEmail = new belEmail();
                objEmail.EnviarEmailManual("pedidoweb@hlp.com.br", "teste", "teste");
            }
            catch (Exception ex)
            {
                throw new Exception("Configurações de email inválida." + Environment.NewLine + ex.Message);
            }
        }
        void CarregaDiasDaSemana()
        {
            try
            {
                List<DiasDaSemana> lretorno = new List<DiasDaSemana>();
                lretorno.Add(new DiasDaSemana { dia = "Domingo", day = DayOfWeek.Sunday });
                lretorno.Add(new DiasDaSemana { dia = "Segunda", day = DayOfWeek.Monday });
                lretorno.Add(new DiasDaSemana { dia = "Terça", day = DayOfWeek.Tuesday });
                lretorno.Add(new DiasDaSemana { dia = "Quarta", day = DayOfWeek.Wednesday });
                lretorno.Add(new DiasDaSemana { dia = "Quinta", day = DayOfWeek.Thursday });
                lretorno.Add(new DiasDaSemana { dia = "Sexta", day = DayOfWeek.Friday });
                lretorno.Add(new DiasDaSemana { dia = "Sabado", day = DayOfWeek.Saturday });
                cboDia.DataSource = lretorno;
                cboDia.DisplayMember = "dia";
                cboDia.ValueMember = "day";

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        struct DiasDaSemana
        {
            public string dia { get; set; }
            public DayOfWeek day { get; set; }
        }
        public bool VerificaDiaEmailContador()
        {
            try
            {
                bool bDiaDeEnvio = false;
                if (File.Exists(sPathArquivoSerializer))
                {
                    ConfigEmailContadorXml config = bel.belSerializeToXml.DeserializeClasse<ConfigEmailContadorXml>(sPathArquivoSerializer);

                    if (config.Alerta == ConfigEmailContadorXml.tpConfig.Mensalmente)
                    {
                        if ((DateTime.Today.Day == 1) && (config.dtUltimoEnvio != DateTime.Today))
                        {
                            bDiaDeEnvio = true;
                        }
                    }
                    else
                    {
                        if ((config.dia == DateTime.Today.DayOfWeek) && (config.dtUltimoEnvio != DateTime.Today))
                        {
                            bDiaDeEnvio = true;
                        }
                    }
                }
                return bDiaDeEnvio;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        void frmEmailContador2_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (btnEnviar.Enabled)
                {
                    if (cbxMensalmente.Checked)
                    {
                        dadosArquivos.Alerta = ConfigEmailContadorXml.tpConfig.Mensalmente;
                    }
                    else
                    {
                        dadosArquivos.Alerta = ConfigEmailContadorXml.tpConfig.Semanalmente;
                        dadosArquivos.dia = (DayOfWeek)cboDia.SelectedValue;
                    }
                    bel.belSerializeToXml.SerializeClasse<ConfigEmailContadorXml>(dadosArquivos, sPathArquivoSerializer);
                }
            }
            catch (Exception ex)
            {
                new HLPexception(ex);
            }
        }
        void cbxSemanalmente_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxSemanalmente.Checked)
            {
                cboDia.Enabled = true;
            }
            else
            {
                cboDia.Enabled = false;
            }
        }

        private void dgvDados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.RowIndex > -1) && (e.ColumnIndex == 0))
            {
                SendKeys.Send("{right}");
                SendKeys.Send("{left}");
            }
        }

        private void liberarParaReenvioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                List<PendenciaEmail> lLiberar = (bsPendenciaEmail.DataSource as List<PendenciaEmail>).Where(c => c.Select).ToList();

                foreach (PendenciaEmail pendencia in lLiberar)
                {
                    List<Arquivos> larq = dadosArquivos.arquivosTransmitidos.Where(c => c.mmYY == pendencia.sMes + pendencia.sAno).ToList();

                    foreach (Arquivos arq in larq)
                    {
                        dadosArquivos.arquivosTransmitidos.Remove(arq);
                    }
                }
                bel.belSerializeToXml.SerializeClasse<ConfigEmailContadorXml>(dadosArquivos, sPathArquivoSerializer);
                CarregaDataGrid();
            }
            catch (Exception ex)
            {
                new HLPexception(ex);
            }
        }
    }
}