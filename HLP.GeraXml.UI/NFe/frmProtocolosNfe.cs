using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using ComponentFactory.Krypton.Toolkit;
using HLP.GeraXml.Comum.Static;
using HLP.GeraXml.Comum;
using HLP.GeraXml.bel;

namespace HLP.GeraXml.UI.NFe
{
    public partial class frmProtocolosNfe : KryptonForm
    {
        string sPastaProtocolos = string.Empty;

        public frmProtocolosNfe()
        {
            InitializeComponent();
            cbxArquivos.cbx.SelectedIndexChanged += new EventHandler(cbxArquivos_SelectedIndexChanged);
        }

        private void PopulaGridCancelados()
        {
            try
            {
                DirectoryInfo diretorio = new DirectoryInfo(sPastaProtocolos);
                FileSystemInfo[] itens = diretorio.GetFileSystemInfos("*.xml");
                int irow = 0;
                dgvCancelamentos.Rows.Clear();
                foreach (FileSystemInfo item in itens)
                {
                    if (item.Name.Contains("ped-can"))
                    {
                        XmlDocument xml = new XmlDocument();
                        xml.Load(item.FullName);
                        dgvCancelamentos.Rows.Add();
                        dgvCancelamentos[0, irow].Value = (xml.GetElementsByTagName("infCanc").Item(0).FirstChild.InnerText == "2" ? "Homologação" : "Produção");
                        dgvCancelamentos[1, irow].Value = (xml.GetElementsByTagName("chNFe").Item(0).InnerText.Equals("") ? "S/Nota" : xml.GetElementsByTagName("chNFe").Item(0).InnerText.Substring(25, 9));
                        dgvCancelamentos[2, irow].Value = (xml.GetElementsByTagName("chNFe").Item(0).InnerText.Equals("") ? "S/Sequencia" : xml.GetElementsByTagName("chNFe").Item(0).InnerText.Substring(34, 9));
                        dgvCancelamentos[3, irow].Value = (xml.GetElementsByTagName("nProt").Item(0).InnerText.Equals("") ? "S/Protocolo" : xml.GetElementsByTagName("nProt").Item(0).InnerText);
                        dgvCancelamentos[5, irow].Value = item.Name;
                        irow++;

                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void PopulaGridInutilizados()
        {
            try
            {
                DirectoryInfo diretorio = new DirectoryInfo(sPastaProtocolos);
                FileSystemInfo[] itens = diretorio.GetFileSystemInfos("*.xml");
                int irow = 0;
                dgvInutilizacoes.Rows.Clear();

                foreach (FileSystemInfo item in itens)
                {
                    if ((item.Name.Contains("_inu")) && (!item.Name.Contains("_ped_inu")))
                    {
                        XmlDocument xml = new XmlDocument();
                        xml.Load(item.FullName);
                        dgvInutilizacoes.Rows.Add();
                        dgvInutilizacoes[0, irow].Value = (xml.GetElementsByTagName("tpAmb").Item(0).InnerText == "2" ? "Homologação" : "Produção");
                        dgvInutilizacoes[1, irow].Value = xml.GetElementsByTagName("nNFIni").Item(0).InnerText.PadLeft(9, '0');
                        dgvInutilizacoes[2, irow].Value = xml.GetElementsByTagName("nNFFin").Item(0).InnerText.PadLeft(9, '0');
                        dgvInutilizacoes[3, irow].Value = Convert.ToDateTime(xml.GetElementsByTagName("dhRecbto").Item(0).InnerText).ToString("dd/MM/yyyy");
                        dgvInutilizacoes[4, irow].Value = xml.GetElementsByTagName("nProt").Item(0).InnerText;
                        irow++;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void dgvCancelamentos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                if (e.ColumnIndex == 4)
                {
                    if (dgvCancelamentos[e.ColumnIndex, e.RowIndex].Value == null)
                    {
                        dgvCancelamentos[e.ColumnIndex, e.RowIndex].Value = false;
                    }
                    dgvCancelamentos[e.ColumnIndex, e.RowIndex].Value = !Convert.ToBoolean(dgvCancelamentos[e.ColumnIndex, e.RowIndex].Value);
                }
            }
        }

        private void btnEnviarEmail_Click(object sender, EventArgs e)
        {
            List<string> sCaminhos = new List<string>();
            for (int i = 0; i < dgvCancelamentos.RowCount; i++)
            {
                if (dgvCancelamentos[4, i].Value != null)
                {
                    if (Convert.ToBoolean(dgvCancelamentos[4, i].Value))
                    {
                        sCaminhos.Add(dgvCancelamentos[5, i].Value.ToString());
                    }
                }
            }

        }

        private void frmProtocolos_Load(object sender, EventArgs e)
        {
            try
            {
                DirectoryInfo dinfo = new DirectoryInfo(Pastas.PASTA_XML_CONFIG);
                FileInfo[] finfo = dinfo.GetFiles();

                foreach (FileInfo item in finfo)
                {
                    if (Path.GetExtension(item.FullName).ToUpper().Equals(".XML"))
                    {
                        cbxArquivos.cbx.Items.Add(item.Name);
                    }
                } if ((Acesso.NM_CONFIG_TEMP != "") && (Acesso.NM_CONFIG_TEMP != null))
                {
                    cbxArquivos.cbx.Text = Acesso.NM_CONFIG_TEMP.Replace("\\","").Trim();
                }
                else if (cbxArquivos.cbx.Items.Count > 0)
                {
                    cbxArquivos.cbx.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void cbxArquivos_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string sCaminho = Pastas.PASTA_XML_CONFIG+ "\\"+ cbxArquivos.cbx.SelectedItem.ToString();
                belConfiguracao objConfig = SerializeClassToXml.DeserializeClasse<belConfiguracao>(sCaminho);
                sPastaProtocolos = objConfig.CAMINHO_PADRAO + "\\Protocolos\\";

                PopulaGridCancelados();
                PopulaGridInutilizados();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
