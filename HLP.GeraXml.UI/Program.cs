using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Deployment.Application;
using HLP.GeraXml.UI.Configuracao;
using System.IO;
using ComponentFactory.Krypton.Toolkit;
using HLP.GeraXml.Comum.Static;
using HLP.GeraXml.Comum;
using HLP.GeraXml.bel;

namespace HLP.GeraXml.UI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (MessageBox.Show("Deseja continuar ?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                //try
                //{
                //    bool bValida = false;
                //    string Protocolo = "00111231";
                //    string sVerificacao = @"C:\GeraXml\Arquivos\00111231.txt";



                //    StreamWriter sw = new StreamWriter(sVerificacao);
                //    sw.Write(DateTime.Now);
                //    sw.Close();


                //    StreamReader sr = new StreamReader(sVerificacao);
                //    string sdt = sr.ReadToEnd();
                //    sr.Close();

                //    if (File.Exists(sVerificacao))
                //    {                    
                //        DateTime dtEnvio = Convert.ToDateTime(sdt).AddMinutes(6);
                //        DateTime dtAtual = DateTime.Now;

                //        if (dtEnvio > dtAtual)
                //        {
                //            throw new Exception("Aguarde mais alguns minutos para o buscar o retorno da Nota. Aproximadamente 6 minutos após o envio.");
                //        }
                //        else
                //        {
                //            bValida = true;
                //        }
                //    }
                //    else
                //    {
                //        bValida = true;
                //    }
                //}
                //catch (Exception ex)
                //{
                //    throw;
                //}


                frmPrincipal objFrm = new frmPrincipal();
                objFrm.SetVisualandBackColor(belRegedit.BuscaNomeSkin());


                //Carrega os arquivos de configuração
                if (!Util.VerificaConfiguracaoPastasXml())
                {
                    frmLocalXml objfrm = new frmLocalXml("");
                    objfrm.ShowDialog();
                }
                else
                {
                    try
                    {
                        bool bCaminhoValido = false;
                        if (Pastas.PASTA_XML_CONFIG != "")
                        {
                            DirectoryInfo dinfo = new DirectoryInfo(Pastas.PASTA_XML_CONFIG);
                            bCaminhoValido = true;
                        }
                        if (bCaminhoValido == false)
                        {
                            KryptonMessageBox.Show(null, "O caminho configurado abaixo não foi encontrado!"
                                + Environment.NewLine
                                + Environment.NewLine
                                + Pastas.PASTA_XML_CONFIG, "A V I S O", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            frmLocalXml objfrm = new frmLocalXml(Pastas.PASTA_XML_CONFIG);
                            objfrm.ShowDialog();
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("O Sistema não conseguiu acessar o caminho hlp\\Config_xml_3 no Registro do Windows" + Environment.NewLine + ex.Message);
                    }
                }

                if (Pastas.PASTA_XML_CONFIG != null)
                {
                    //belImportaArquivos.ImportaArquivosConfig();

                    int iCountFiles = 0;
                    DirectoryInfo dPastaData = new DirectoryInfo(Pastas.PASTA_XML_CONFIG);
                    FileInfo[] finfo = dPastaData.GetFiles("*.xml");
                    foreach (FileInfo item in finfo)
                    {
                        iCountFiles++;
                    }

                    if (iCountFiles == 0)
                    {
                        if (KryptonMessageBox.Show(null, "Não existe nenhum arquivo de configuração na pasta Selecionada."
                             + Environment.NewLine
                             + Environment.NewLine
                             + "Deseja selecionar uma outra Pasta ?",
                             "A V I S O",
                             MessageBoxButtons.YesNo,
                             MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            frmLocalXml objfrm = new frmLocalXml(Pastas.PASTA_XML_CONFIG);
                            objfrm.ShowDialog();
                        }
                        else
                        {
                            frmLoginConfig objfrmLoginConfig = new frmLoginConfig();
                            objfrmLoginConfig.ShowDialog();
                        }
                    }
                    else
                    {
                        frmSelecionaConfigs objfrmSelecionaConfig = new frmSelecionaConfigs();
                        objfrmSelecionaConfig.ShowDialog();
                        if (Acesso.bESCRITA)
                        {
                            Acesso.USER_LOGADO = true;
                        }
                        else if (objfrmSelecionaConfig.ArquivoSelecionado)
                        {
                            frmLogin objfrmLogin = new frmLogin();
                            objfrmLogin.ShowDialog();
                        }
                    }
                    if (Acesso.USER_LOGADO)
                    {
                        Application.Run(new frmPrincipal());
                    }
                }
            }
        }
    }
}
