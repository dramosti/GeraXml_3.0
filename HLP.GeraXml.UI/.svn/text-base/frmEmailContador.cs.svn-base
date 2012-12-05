using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using HLP.GeraXml.Comum;
using System.IO;
using HLP.GeraXml.Comum.Static;
using HLP.GeraXml.bel;
using HLP.GeraXml.dao;
using System.Xml.Linq;
using System.Linq;
using Ionic.Zip;
using System.Text.RegularExpressions;

namespace HLP.GeraXml.UI
{
    public partial class frmEmailContador : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        string sArqConfigDia = "";
        List<belEmailContador> objListaEmailContador = new List<belEmailContador>();
        belEmailContador objbelEmailContador = new belEmailContador();


        public frmEmailContador()
        {
            InitializeComponent();
        }
        private void frmEmailContador_Load(object sender, EventArgs e)
        {
            try
            {
                chkMensal.chk.Click += new EventHandler(chk_Click);
                chkSemanal.chk.Click += new EventHandler(chk_Click);


                txtContador.Text = Acesso.EMAIL_CONTADOR;
                RefreshGrid();

                sArqConfigDia = Pastas.ENVIADOS + "\\Contador_xml\\" + "ConfigDia.txt";
                FileInfo finfo = new FileInfo(sArqConfigDia);
                if (finfo.Exists)
                {
                    FileStream theFile = File.Open(sArqConfigDia, FileMode.Open, FileAccess.Read);
                    StreamReader reader = new StreamReader(theFile);
                    string sDia = reader.ReadToEnd().Trim();
                    if (sDia == "month")
                    {
                        cboDia.Enabled = false;
                        cboDia.SelectedIndex = -1;
                        chkMensal.Checked = true;
                        chkSemanal.Checked = false;
                    }
                    else
                    {
                        cboDia.SelectedIndex = RetornaIndex(sDia);
                        cboDia.Enabled = true;
                        chkMensal.Checked = false;
                        chkSemanal.Checked = true;
                    }
                    reader.Close();
                }
                else
                {
                    KryptonMessageBox.Show("Para utilizar essa Rotina, primeiro Acerte a Configuração de Alerta!", Mensagens.MSG_Aviso, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tab.SelectedTab = tbConfiguracao;
                }

            }
            catch (Exception ex)
            {
                new HLPexception(ex);
            }
        }


        private void chk_Click(object sender, EventArgs e)
        {
            try
            {
                KryptonCheckBox chk = (KryptonCheckBox)sender;
                cboDia.Enabled = chkSemanal.Checked;

                if (chk.Parent.Name == chkSemanal.Name)
                {
                    chkMensal.Checked = !chkSemanal.Checked;

                    if (cboDia.SelectedIndex == -1)
                    {
                        cboDia.SelectedIndex = 1;
                    }
                }
                else
                {
                    chkSemanal.Checked = !chkMensal.Checked;
                    cboDia.Enabled = false;
                    cboDia.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                new HLPexception(ex);
            }
        }
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                string sValorSave = "";
                if (chkSemanal.Checked)
                {
                    sValorSave = RetornaDia();
                }
                else
                {
                    sValorSave = "month";
                }
                DirectoryInfo info = new DirectoryInfo(Pastas.ENVIADOS + "\\Contador_xml\\");
                if (!info.Exists)
                {
                    info.Create();
                }

                FileStream FileDia = File.Create(sArqConfigDia);
                StreamWriter sw = new StreamWriter(FileDia);
                sw.WriteLine(sValorSave);
                sw.Close();
                KryptonMessageBox.Show("Configuração de Alerta Salvo com Sucesso", Mensagens.MSG_Aviso, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                new HLPexception(ex);
            }
        }
        private void btnEnviar_Click(object sender, EventArgs e)
        {
            Regex remail = new Regex(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$");
            bool ok = true;
            if (txtCopia.Text != "")
            {
                if (!remail.IsMatch(txtCopia.Text))
                {
                    ok = false;
                }
            }
            if (ok)
            {
                ProcessoEmail();
            }
            else
            {
                KryptonMessageBox.Show("E-mail no campo Cópia para Inválido", Mensagens.CHeader, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void RefreshGrid()
        {
            DirectoryInfo dPastaEnviados = new DirectoryInfo(Pastas.ENVIADOS);
            int icount = 0;
            objListaEmailContador = new List<belEmailContador>();

            foreach (FileSystemInfo pasta in dPastaEnviados.GetFileSystemInfos())
            {
                if (Acesso.NM_RAMO == Acesso.BancoDados.TRANSPORTE)
                {
                    #region Transporte
                    if (pasta.Name.Length == 5)
                    {
                        belEmailContador objEmailCont = new belEmailContador();
                        objEmailCont.iId = icount++;
                        objEmailCont.sMes = pasta.Name.Substring(0, 2);
                        objEmailCont.sAno = "20" + pasta.Name.Substring(3, 2);
                        objEmailCont.sNomeArquivo = DateTime.Now.Date.ToString("yyMMdd") + ".zip";
                        objEmailCont.sCaminhoEnviado = pasta.FullName;
                        objEmailCont.sCaminhoCancelado = Pastas.CANCELADOS + "\\" + pasta.Name;
                        DirectoryInfo dinfoEnviados = new DirectoryInfo(objEmailCont.sCaminhoEnviado);
                        DirectoryInfo dinfoCancelados = new DirectoryInfo(objEmailCont.sCaminhoCancelado);
                        objEmailCont.iFaltantes = (dinfoEnviados.Exists ? dinfoEnviados.GetFileSystemInfos().Count() : 0) + (dinfoCancelados.Exists ? dinfoCancelados.GetFileSystemInfos().Count() : 0);


                        string sCaminho = Pastas.ENVIADOS + "\\Contador_xml\\" + pasta.Name + daoUtil.GetDateServidor().Date.Day.ToString().PadLeft(2, '0') + ".xml";
                        if (File.Exists(sCaminho))
                        {
                            XDocument xmlDoc = XDocument.Load(sCaminho);
                            objEmailCont.xmlArqEnviados = xmlDoc;
                            //Count nos arquivos que já foram enviados q estão no Xml.
                            objEmailCont.iEnviadoContador = xmlDoc.Descendants("Email").Elements("Envio").Count();
                        }
                        else
                        {
                            objEmailCont.xmlArqEnviados = new XDocument();
                            objEmailCont.xmlArqEnviados.Add(new XElement("Email"));
                            objEmailCont.xmlArqEnviados.Save(sCaminho);
                        }

                        objListaEmailContador.Add(objEmailCont);
                    }
                    #endregion
                }
                else if (pasta.Name.Length == 4)
                {
                    #region Outros Ramos
                    belEmailContador objEmailCont = new belEmailContador();
                    objEmailCont.iId = icount++;
                    objEmailCont.sMes = pasta.Name.Substring(2, 2);
                    objEmailCont.sAno = "20" + pasta.Name.Substring(0, 2);
                    objEmailCont.sNomeArquivo = DateTime.Now.Date.ToString("yyMMdd") + ".zip"; ;

                    objEmailCont.sCaminhoEnviado = pasta.FullName;
                    objEmailCont.sCaminhoCancelado = Pastas.CANCELADOS + "\\" + pasta.Name;
                    objEmailCont.sCaminhoCCe = Pastas.CCe + "\\" + pasta.Name;

                    DirectoryInfo dinfoEnviados = new DirectoryInfo(objEmailCont.sCaminhoEnviado);
                    DirectoryInfo dinfoCancelados = new DirectoryInfo(objEmailCont.sCaminhoCancelado);
                    DirectoryInfo dCartaCorrecao = new DirectoryInfo(objEmailCont.sCaminhoCCe);

                    objEmailCont.iFaltantes = (dinfoEnviados.Exists ? dinfoEnviados.GetFileSystemInfos().Count() : 0) + (dinfoCancelados.Exists ? dinfoCancelados.GetFileSystemInfos().Count() : 0) +
                                              (dCartaCorrecao.Exists ? dCartaCorrecao.GetFileSystemInfos().Count() : 0);

                    if (objEmailCont.iFaltantes == 0)
                    {
                        objEmailCont.Enviado = true;
                    }

                    string sCaminho = Pastas.ENVIADOS + "\\Contador_xml\\" + pasta.Name + daoUtil.GetDateServidor().Date.Day.ToString().PadLeft(2, '0') + ".xml";
                    if (File.Exists(sCaminho))
                    {
                        XDocument xmlDoc = XDocument.Load(sCaminho);
                        objEmailCont.xmlArqEnviados = xmlDoc;
                        //Count nos arquivos que já foram enviados q estão no Xml.
                        objEmailCont.iEnviadoContador = xmlDoc.Descendants("Email").Elements("Envio").Count();
                    }
                    else
                    {
                        objEmailCont.xmlArqEnviados = new XDocument();
                        objEmailCont.xmlArqEnviados.Add(new XElement("Email"));
                        objEmailCont.xmlArqEnviados.Save(sCaminho);
                    }

                    objListaEmailContador.Add(objEmailCont);
                    #endregion
                }
            }
            dgvItens.Rows.Clear();
            belEmailContadorBindingSource.DataSource = objListaEmailContador.OrderByDescending(c => c.iId);

            foreach (belEmailContador obj in objListaEmailContador)
            {
                if (obj.iFaltantes == 0)
                {
                    obj.Enviado = true;
                }
                else
                {
                    obj.Enviado = false;
                }
            }
        }
        private string RetornaDia()
        {
            string dia = "";
            switch (cboDia.SelectedIndex)
            {
                case 0:
                    dia = "Sunday";
                    break;
                case 1:
                    dia = "Monday";
                    break;
                case 2:
                    dia = "Tuesday";
                    break;
                case 3:
                    dia = "Wednesday";
                    break;
                case 4:
                    dia = "Thursday";
                    break;
                case 5:
                    dia = "Friday";
                    break;
                case 6:
                    dia = "Saturday";
                    break;
            }
            return dia;
        }
        private int RetornaIndex(string dia)
        {
            int index = 0;
            switch (dia)
            {
                case "Sunday":
                    index = 0;
                    break;
                case "Monday":
                    index = 1;
                    break;
                case "Tuesday":
                    index = 2;
                    break;
                case "Wednesday":
                    index = 3;
                    break;
                case "Thursday":
                    index = 4;
                    break;
                case "Friday":
                    index = 5;
                    break;
                case "Saturday":
                    index = 6;
                    break;
            }
            return index;
        }


        private void ProcessoEmail()
        {
            try
            {
                bool EnviarArquivos = false;
                if (objListaEmailContador.Where(c => c.Enviar == true).Count() > 0)
                {
                    foreach (belEmailContador item in objListaEmailContador.Where(c => c.Enviar == true).ToList())
                    {
                        if (item.iFaltantes > 0 || item.iEnviadoContador > 0)
                        {
                            if (item.iFaltantes == 0)
                            {
                                if (KryptonMessageBox.Show("Não existem Arquivos pendentes de envio no Mês " + item.sMes + Environment.NewLine +
                                   "Deseja reenviar todos os arquivos novamente?", Mensagens.MSG_Confirmacao, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {
                                    CampactaZip(item, false);
                                    EnviarArquivos = true;
                                }
                            }
                            else
                            {
                                EnviaEmailTeste();
                                CampactaZip(item, true);
                                EnviarArquivos = true;

                            }
                        }
                    }
                    if (EnviarArquivos)
                    {
                        //belEmail objEmail = new belEmail(objListaEmailContador.Where(c => c.Enviar == true).ToList(), txtCopia.Text);
                        //objEmail.EnviarEmail();
                        ////KryptonMessageBox.Show("E-mail enviado com sucesso!", Mensagens.CHeader, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ////RefreshGrid();
                    }
                }
                else
                {
                    KryptonMessageBox.Show("Nenhum Mês foi selecionado", "A V I S O", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                new HLPexception(ex);
            }
        }

        private void EnviaEmailTeste()
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

        private void CampactaZip(belEmailContador item, bool Verifica)
        {
            try
            {
                List<string> lCaminhos = new List<string>();
                lCaminhos.Add(item.sCaminhoEnviado);
                lCaminhos.Add(item.sCaminhoCancelado);
                lCaminhos.Add(item.sCaminhoCCe);
                Util.CompactaArquivosXml(lCaminhos.ToArray(), item.sCaminhoZip);


                #region Compacta Enviados

                DirectoryInfo dinfoArq = new DirectoryInfo(item.sCaminhoEnviado);
                if (dinfoArq.Exists)
                {
                    foreach (FileSystemInfo arq in dinfoArq.GetFileSystemInfos())
                    {
                        if (Verifica)
                        {
                            List<XElement> xListElem = item.xmlArqEnviados.Descendants("Email").Elements("Envio").Where(c => c.Attribute("Tipo").Value.ToString() == "enviados").ToList();
                            if (xListElem.Where(x => x.Value.ToString() == arq.Name).Count() == 0)
                            {
                                item.xmlArqEnviados.Element("Email").Add(new XElement("Envio", new XAttribute("Tipo", "enviados"), arq.Name));
                            }
                        }
                    }
                }

                #endregion

                #region Compacta arquivos Cancelados
                dinfoArq = new DirectoryInfo(item.sCaminhoCancelado);
                if (dinfoArq.Exists)
                {
                    foreach (FileSystemInfo arq in dinfoArq.GetFileSystemInfos())
                    {
                        if (Verifica)
                        {
                            List<XElement> xListElem = item.xmlArqEnviados.Descendants("Email").Elements("Envio").Where(c => c.Attribute("Tipo").Value.ToString() == "cancelados").ToList();
                            if (xListElem.Where(x => x.Value.ToString() == arq.Name.ToString()).Count() == 0)
                            {
                                item.xmlArqEnviados.Element("Email").Add(new XElement("Envio", new XAttribute("Tipo", "cancelados"), arq.Name));
                            }
                        }
                    }
                }
                #endregion

                #region Compacta CCe
                if (!String.IsNullOrEmpty(item.sCaminhoCCe))
                {
                    dinfoArq = new DirectoryInfo(item.sCaminhoCCe);
                    if (dinfoArq.Exists)
                    {
                        foreach (FileSystemInfo arq in dinfoArq.GetFileSystemInfos())
                        {
                            if (Verifica)
                            {
                                List<XElement> xListElem = item.xmlArqEnviados.Descendants("Email").Elements("Envio").Where(c => c.Attribute("Tipo").Value.ToString() == "cce").ToList();
                                if (xListElem.Where(x => x.Value.ToString() == arq.Name.ToString()).Count() == 0)
                                {
                                    item.xmlArqEnviados.Element("Email").Add(new XElement("Envio", new XAttribute("Tipo", "cce"), arq.Name));
                                }
                            }
                        }
                    }
                }
                #endregion

                item.xmlArqEnviados.Save(item.dinfo.FullName + "\\" + item.sNomeArquivo.Replace("zip", "xml"));


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void frmEmailContador_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}