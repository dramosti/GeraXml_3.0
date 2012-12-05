using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;
using System.IO;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalDecisions.Windows.Forms;
using System.Drawing;
using ICSharpCode.SharpZipLib.Zip;

namespace HLP.GeraXml.Comum.Static
{
    public static class Util
    {
        public static bool VerificaConfiguracaoPastasXml()
        {
            try
            {
                RegistryKey key = Registry.CurrentConfig.OpenSubKey(Pastas.REGISTRY_CONFIG);
                if (key != null)
                {
                    Pastas.PASTA_XML_CONFIG = key.GetValue(Pastas.Caminho_xmls, "").ToString();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static string TiraSimbolo(string sString)
        {
            sString = sString.Replace("\\viewkind4\\uc1\\pard\\f0\\fs16 ", "");
            sString = sString.Replace("{\\colortbl ;\\red0\\green0\\blue255;}\\viewkind4\\uc1 d\\cf1\\lang1046\\fs16   ", "");
            sString = sString.Replace("\\viewkind4\\uc1 d\\b\\fs16 ", "");
            sString = sString.Replace("\\f1\\'c7", "C");
            sString = sString.Replace("\\'c3", "A");
            sString = sString.Replace("\\f0 ", "");
            sString = sString.Replace("\\par", " ");
            sString = sString.Replace("}\0", "");
            sString = sString.Replace("\\f0", "");
            sString = sString.Replace("\\'ba", "o");
            sString = sString.Replace("\\f1", "");
            sString = sString.Replace("\\'cd", "I");
            sString = sString.Replace("\\'aa", "a");
            sString = sString.Replace("\\'e1", "a");
            sString = sString.Replace("\\'e7\\'e3", "ca");
            sString = sString.Replace("\\b0", ".");
            sString = sString.Replace("\\'e3", "a");
            sString = sString.Replace("\\'ea", "e");
            sString = sString.Replace("\\c9", "E");
            sString = sString.Replace(" ", "");
            sString = sString.Replace("_", "");
            sString = sString.Replace(")", "");
            sString = sString.Replace("(", "");
            string[,] sSimbolos = {   
                                    { "á", "a" },
                                    { "Á", "A" },
                                    { "é", "e" },
                                    { "É", "E" },
                                    { "í", "i" },
                                    { "Í", "I" },
                                    { "ó", "o" },
                                    { "Ó", "O" },
                                    { "ú", "u" },
                                    { "Ú", "U" },
                                    { "ã", "a" },
                                    { "Ã", "A" },
                                    { "õ", "o" },
                                    { "Õ", "O" },
                                    { "â", "a" },
                                    { "Â", "A" },
                                    { "ê", "e" },
                                    { "Ê", "E" },
                                    { "ô", "o" },
                                    { "Ô", "O" },
                                    { "/", "" },
                                    { "ç", "c" },
                                    { "Ç", "C" },
                                    { "-", "" },
                                    { "  ", "" },
                                    { ".", "" },
                                    { "(", "" },
                                    { ")", "" },
                                    { "°", "o" },
                                    { "�", " "},
                                    { "&", "E"},
                                    { "*", ""},
                                    { "º", "o"},
                                    { "\"", ""},
                                    { "Ø", ""},
                                    { "'", ""}
                                };

            string Resultado = "";
            string sCar = "";

            for (int i = 0; i <= (sString.Length - 1); i++)
            {
                sCar = sString[i].ToString();
                for (int y = 0; y <= (sSimbolos.GetLength(0) - 1); y++)
                {
                    if ((sCar == sSimbolos[y, 0]))
                    {
                        sString = sString.Replace(sCar, sSimbolos[y, 1]);
                    }
                }

            }
            Resultado = sString;
            return Resultado;
        }

        public static string TiraSimbolo(string sString, string sIgnorar)
        {
            sString = sString.Replace("\\viewkind4\\uc1\\pard\\f0\\fs16 ", "");
            sString = sString.Replace("\\f1\\'c7", "C");
            sString = sString.Replace("\\'c3", "A");
            sString = sString.Replace("\\f0 ", "");
            sString = sString.Replace("\\par", " ");
            sString = sString.Replace("}\0", "");
            sString = sString.Replace("\\f0", "");
            sString = sString.Replace("{\\colortbl ;\\red0\\green0\\blue255;}\\viewkind4\\uc1 d\\cf1\\lang1046\\fs16   ", "");
            sString = sString.Replace("\\'ba", "o");
            sString = sString.Replace("\\f1", "");
            sString = sString.Replace("\\'cd", "I");
            sString = sString.Replace("\\viewkind4\\uc1 d\\b\\fs16 ", "");
            sString = sString.Replace("\\'aa", "a");
            sString = sString.Replace("\\'e1", "a");
            sString = sString.Replace("\\'e7\\'e3", "ca");
            sString = sString.Replace("\\b0", ".");
            sString = sString.Replace("\\'e3", "a");
            sString = sString.Replace("\\'ea", "e");
            sString = sString.Replace("\\c9", "E");


            string[,] sSimbolos = {   
                                    { "á", "a" },
                                    { "Á", "A" },
                                    { "é", "e" },
                                    { "É", "E" },
                                    { "í", "i" },
                                    { "Í", "I" },
                                    { "ó", "o" },
                                    { "Ó", "O" },
                                    { "ú", "u" },
                                    { "Ú", "U" },
                                    { "ã", "a" },
                                    { "Ã", "A" },
                                    { "õ", "o" },
                                    { "Õ", "O" },
                                    { "â", "a" },
                                    { "Â", "A" },
                                    { "ê", "e" },
                                    { "Ê", "E" },
                                    { "ô", "o" },
                                    { "Ô", "O" },
                                    { "/", "" },
                                    { "ç", "c" },
                                    { "Ç", "C" },
                                    { "-", "" },
                                    { "  ", "" },
                                    { ".", "" },
                                    { "(", "" },
                                    { ")", "" },
                                    { "°", "o" },
                                    { "�", " "},
                                    { "&", "E"},
                                    { "*", ""},
                                    { "º", "o"},
                                    { "\"", ""},
                                    { "Ø", ""},
                                    { "'", ""}                                    
                                };

            string Resultado = "";
            string sCar = "";

            for (int i = 0; i <= (sString.Length - 1); i++)
            {
                sCar = sString[i].ToString();
                for (int y = 0; y <= (sSimbolos.GetLength(0) - 1); y++)
                {
                    if ((sCar == sSimbolos[y, 0]) && (sCar != sIgnorar))
                    {
                        sString = sString.Replace(sCar, sSimbolos[y, 1]);
                    }
                }

            }

            while (sString.Contains("  "))
            {
                sString = sString.Replace("  ", " ");

            }
            Resultado = sString.Trim();

            return Resultado;
        }

        public static bool VerificaSeEstaNaHLP()
        {
            try
            {
                DirectoryInfo dinfo = new DirectoryInfo(@"G:\CSharp\Desenvolvimento");
                DirectoryInfo dinfo2 = new DirectoryInfo(@"J:\D6\Industri");

                if ((dinfo.Exists) && (dinfo.Exists))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }

        public static bool IsNumeric(object Expression)
        {
            bool isNum;
            double retNum;
            isNum = Double.TryParse(Convert.ToString(Expression), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);
            return isNum;
        }

        public static bool ValidacEAN(string scodigo)
        {
            try
            {
                if (((scodigo.Length == 8) || (scodigo.Length == 12) || (scodigo.Length == 13) || (scodigo.Length == 14))
                    && (Convert.ToBoolean(Acesso.COD_BARRAS_XML)))
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool ValidaCean13(string CodigoEAN)
        {
            try
            {
                bool result = (CodigoEAN.Length == 8 || CodigoEAN.Length == 12 || CodigoEAN.Length == 13 || CodigoEAN.Length == 14);
                if (result)
                {
                    string checkSum = "";

                    if (CodigoEAN.Length == 8)
                    {
                        checkSum = "3131313";
                    }
                    else if (CodigoEAN.Length == 12)
                    {
                        checkSum = "31313131313";
                    }
                    else if (CodigoEAN.Length == 13)
                    {
                        checkSum = "131313131313";
                    }
                    else if (CodigoEAN.Length == 14)
                    {
                        checkSum = "3131313131313";
                    }

                    int digito =
                    int.Parse(CodigoEAN[CodigoEAN.Length - 1].ToString());
                    string ean = CodigoEAN.Substring(0, CodigoEAN.Length - 1);

                    int sum = 0;
                    for (int i = 0; i <= ean.Length - 1; i++)
                    {
                        sum += int.Parse(ean[i].ToString()) *
                        int.Parse(checkSum[i].ToString());
                    }
                    int calculo = 10 - (sum % 10);
                    if (calculo == 10)
                    {
                        calculo = 0;
                    }

                    result = (digito == calculo);
                }
                else if (CodigoEAN.Length == 0)
                {
                    result = true;
                }
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static bool VerificaNovaST(string scst)
        {
            try
            {
                if (scst == "")
                {
                    throw new Exception("Situação Tributária dos Itens esta vazia e o Sistema não pode continuar.");
                }
                List<NovasCst> objList = new List<NovasCst>()
                    {
                        new NovasCst{ nsct = "101",sgrupo="101"},
                        new NovasCst{ nsct = "102",sgrupo="102"},
                        new NovasCst{ nsct = "103",sgrupo="102"},
                        new NovasCst{ nsct = "300",sgrupo="102"},
                        new NovasCst{ nsct = "400",sgrupo="102"},
                        new NovasCst{ nsct = "201",sgrupo="201"},
                        new NovasCst{ nsct = "202",sgrupo="201"},
                        new NovasCst{ nsct = "203",sgrupo="201"},
                        new NovasCst{ nsct = "500",sgrupo="500"},
                        new NovasCst{ nsct = "900",sgrupo="900"}
                    };

                return (objList.Count(b => b.nsct == scst) > 0 ? true : false);

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static string RetornaSTnovaAserUsada(string scst)
        {
            List<NovasCst> objList = new List<NovasCst>()
                    {
                        new NovasCst{ nsct = "101",sgrupo="101"},
                        new NovasCst{ nsct = "102",sgrupo="102"},
                        new NovasCst{ nsct = "103",sgrupo="102"},
                        new NovasCst{ nsct = "300",sgrupo="102"},
                        new NovasCst{ nsct = "400",sgrupo="102"},
                        new NovasCst{ nsct = "201",sgrupo="201"},
                        new NovasCst{ nsct = "202",sgrupo="201"},
                        new NovasCst{ nsct = "203",sgrupo="201"},
                        new NovasCst{ nsct = "500",sgrupo="500"},
                        new NovasCst{ nsct = "900",sgrupo="900"}
                    };

            return (objList.FirstOrDefault(b => b.nsct == scst)).sgrupo;

        }

        public static string ValidaTamanhoMaximo(int imaximo, string svalor)
        {
            try
            {
                if (svalor != "")
                {
                    svalor = svalor.Trim();
                    if (svalor.Length > imaximo)
                    {
                        return svalor.Substring(0, imaximo);
                    }
                    else
                    {
                        return svalor;
                    }
                }
                else
                {
                    return svalor;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static string RetiraCaracterCNPJ(string sCNPJ)
        {
            if (sCNPJ != "EXTERIOR")
            {
                return sCNPJ.Replace(".", "").Replace("/", "").Replace("-", "");
            }
            else
            {
                return sCNPJ;
            }

        }

        private struct NovasCst
        {
            public string nsct { get; set; }
            public string sgrupo { get; set; }
        }

        public static string TiraCaracterEstranho(string sString)
        {
            sString = sString.Replace("{\\colortbl ;\\red0\\green0\\blue0;}\\viewkind4\\uc1\\pard\\cf1\\lang1046\\f0\\fs16 ", "");
            sString = sString.Replace(@"{\colortbl ;\red0\green0\blue255;}\viewkind4\uc1\pard\cf1\lang1046\f0\fs16 ", "");
            sString = sString.Replace("\\viewkind4\\uc1\\pard\\f0\\fs16 ", "");
            sString = sString.Replace("\\viewkind4\\uc1\\pard\\lang1046\\f0\\fs16 ", "");
            sString = sString.Replace("\\viewkind4\\uc1 d\\lang1046 ", "");
            sString = sString.Replace("\\f1\\'c7", "C");
            sString = sString.Replace("\\'c3", "A");
            sString = sString.Replace("\\f0 ", "");
            sString = sString.Replace("\\par", " ");
            sString = sString.Replace("}\0", "");
            sString = sString.Replace("\\f0", "");
            sString = sString.Replace("{\\colortbl ;\\red0\\green0\\blue255;}\\viewkind4\\uc1 d\\cf1\\lang1046\\fs16   ", "");
            sString = sString.Replace("\\'ba", "o");
            sString = sString.Replace("\\f1", "");
            sString = sString.Replace("\\'cd", "I");
            sString = sString.Replace("\\viewkind4\\uc1 d\\b\\fs16 ", "");
            sString = sString.Replace("\\'aa", "a");
            sString = sString.Replace("\\'e1", "a");
            sString = sString.Replace("\\'e7\\'e3", "ca");
            sString = sString.Replace("\\b0", ".");
            sString = sString.Replace("\\'e3", "a");
            sString = sString.Replace("\\'ea", "e");
            sString = sString.Replace("\\c9", "E");
            sString = sString.Replace("\\c9", "E");
            sString = sString.Replace("\\fs52", "");
            sString = sString.Replace("\\fs16", "");

            while (sString.Contains("  "))
            {
                sString = sString.Replace("  ", " ");

            }

            return sString.Trim();
        }

        public static Byte[] CarregaLogoEmpresa()
        {
            FileStream fs = null;
            BinaryReader br = null;
            if (Acesso.LOGOTIPO != "")
            {
                try
                {
                    fs = new FileStream(Acesso.LOGOTIPO, FileMode.Open, FileAccess.Read);
                    br = new BinaryReader(fs);
                }
                catch (Exception ex)
                {
                    br = null;
                }

                if (br != null)
                {
                    return (br.ReadBytes(Convert.ToInt32(br.BaseStream.Length)));
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        public static Byte[] CarregaImagem(string fileName)
        {
            FileStream fs = null;
            BinaryReader br = null;
            try
            {
                fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                br = new BinaryReader(fs);
            }
            catch (Exception ex)
            {

                //KryptonMessageBox.Show(null,"Caminho do logotipo não encontrado ou arquivo não encontrado! " + ex.Message,"ERRO DE IMPRESSÃO DE DANFE", MessageBoxButtons.OK, MessageBoxIcon.Error);

                br = null;
            }

            if (br != null)
            {
                return (br.ReadBytes(Convert.ToInt32(br.BaseStream.Length)));
            }
            else
            {
                return null;
            }


        }

        public static Image byteArrayToImage(byte[] byteArrayIn)
        {
            Image returnImage = null;
            if (byteArrayIn != null)
            {
                MemoryStream ms = new MemoryStream(byteArrayIn);
                returnImage = Image.FromStream(ms);
            }
            return returnImage;
        }

        public static void ExportPDF(ReportDocument rpt, string sCaminhoSave)
        {
            CrystalReportViewer cryView = new CrystalReportViewer();
            ExportOptions CrExportOptions;
            DiskFileDestinationOptions CrDiskFileDestinationOptions = new DiskFileDestinationOptions();
            PdfRtfWordFormatOptions CrFormatTypeOptions = new PdfRtfWordFormatOptions();
            CrDiskFileDestinationOptions.DiskFileName = sCaminhoSave;
            CrExportOptions = rpt.ExportOptions;
            {
                CrExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                CrExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                CrExportOptions.DestinationOptions = CrDiskFileDestinationOptions;
                CrExportOptions.FormatOptions = CrFormatTypeOptions;
            }
            rpt.Export();
        }

        /// <summary>
        /// Busca Caminho do Arquivo Xml de NFe
        /// </summary>
        /// <param name="sChaveNFe">Chave NFe</param>
        /// <param name="iTipo">1 - Envio / 2 - Enviados / 3 - Contingencia</param>
        /// <returns></returns>
        public static string BuscaCaminhoArquivoXml(string sChaveNFe, int iTipo)
        {
            try
            {
                string sCaminho = string.Empty;
                if (iTipo == 3)
                {
                    sCaminho = Pastas.CONTINGENCIA + sChaveNFe + "-nfe.xml";
                }
                else
                {
                    if (!Directory.Exists((iTipo == 2 ? Pastas.ENVIADOS : Pastas.ENVIO) + sChaveNFe.Substring(2, 4)))
                    {
                        Directory.CreateDirectory((iTipo == 2 ? Pastas.ENVIADOS : Pastas.ENVIO) + sChaveNFe.Substring(2, 4));
                    }
                    sCaminho = (iTipo == 2 ? Pastas.ENVIADOS : Pastas.ENVIO) + sChaveNFe.Substring(2, 4) + "\\" + sChaveNFe + "-nfe.xml";
                }
                return sCaminho;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Busca Diretorio do Arquivo Xml de NFe
        /// </summary>
        /// <param name="sChaveNFe">Chave NFe</param>
        /// <param name="iTipo">1 - Envio / 2 - Enviados</param>
        /// <returns></returns>
        public static DirectoryInfo BuscaDiretorioArquivoXml(string sChaveNFe, int iTipo)
        {
            try
            {
                string sCaminhoPasta = (iTipo == 2 ? Pastas.ENVIADOS : Pastas.ENVIO) + "\\" + sChaveNFe.Substring(2, 4);

                DirectoryInfo dPastaData = new DirectoryInfo(sCaminhoPasta);
                if (!dPastaData.Exists) { dPastaData.Create(); }

                return dPastaData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool CompactaArquivosXml(string[] sPath, string sPathFileSave)
        {
            try
            {
                bool bCompactou = false;
                if (File.Exists(sPathFileSave))
                {
                    File.Delete(sPathFileSave);
                }
                using (ZipOutputStream objCompressed = new ZipOutputStream(File.Create(sPathFileSave)))
                {
                    foreach (string pasta in sPath)
                    {

                        if (Directory.Exists(pasta))
                        {
                            DirectoryInfo dinfo = new DirectoryInfo(pasta);
                            if (dinfo.GetFiles("*.xml").Count() > 0)
                            {

                                objCompressed.SetLevel(9);
                                byte[] buffer = new byte[4096];

                                foreach (FileInfo finfo in dinfo.GetFiles("*.xml"))
                                {
                                    ZipEntry objDateEntry = new ZipEntry(finfo.Name);

                                    objDateEntry.DateTime = DateTime.Now;
                                    objCompressed.PutNextEntry(objDateEntry);

                                    using (FileStream objFileStream = File.OpenRead(finfo.FullName))
                                    {
                                        int sourceBytes = objFileStream.Read(buffer, 0, buffer.Length);

                                        while (sourceBytes > 0)
                                        {
                                            sourceBytes = objFileStream.Read(buffer, 0, buffer.Length);
                                            objCompressed.Write(buffer, 0, sourceBytes);
                                        }
                                    }
                                }
                            }
                        }
                    }
                    objCompressed.Finish();
                    objCompressed.Close();
                    bCompactou = true;
                }

                return bCompactou;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public static bool CompactaArquivos(string[] sPath, string sPathFileSave)
        {
            try
            {
                bool bCompactou = false;
                if (File.Exists(sPathFileSave))
                {
                    File.Delete(sPathFileSave);
                }
                using (ZipOutputStream objCompressed = new ZipOutputStream(File.Create(sPathFileSave)))
                {
                    foreach (string pasta in sPath)
                    {

                        if (Directory.Exists(pasta))
                        {
                            DirectoryInfo dinfo = new DirectoryInfo(pasta);
                            if (dinfo.GetFiles().Count() > 0)
                            {

                                objCompressed.SetLevel(9);
                                byte[] buffer = new byte[4096];

                                foreach (FileInfo finfo in dinfo.GetFiles())
                                {
                                    ZipEntry objDateEntry = new ZipEntry(finfo.Name);

                                    objDateEntry.DateTime = DateTime.Now;
                                    objCompressed.PutNextEntry(objDateEntry);

                                    using (FileStream objFileStream = File.OpenRead(finfo.FullName))
                                    {
                                        int sourceBytes = objFileStream.Read(buffer, 0, buffer.Length);

                                        while (sourceBytes > 0)
                                        {
                                            sourceBytes = objFileStream.Read(buffer, 0, buffer.Length);
                                            objCompressed.Write(buffer, 0, sourceBytes);
                                        }
                                    }
                                }
                            }
                        }
                    }
                    objCompressed.Finish();
                    objCompressed.Close();
                    bCompactou = true;
                }

                return bCompactou;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public static List<string> GetListaCFOPcombustivel()
        {
            List<string> lista = new List<string>();
            lista.Add("1651");
            lista.Add("1652");
            lista.Add("1653");
            lista.Add("1658");
            lista.Add("1659");
            lista.Add("1660");
            lista.Add("1661");
            lista.Add("1662");
            lista.Add("1663");
            lista.Add("1664");
            lista.Add("2651");
            lista.Add("2652");
            lista.Add("2653");
            lista.Add("2658");
            lista.Add("2659");
            lista.Add("2660");
            lista.Add("2661");
            lista.Add("2662");
            lista.Add("2663");
            lista.Add("2664");
            lista.Add("3651");
            lista.Add("3652");
            lista.Add("3653");
            lista.Add("5651");
            lista.Add("5652");
            lista.Add("5653");
            lista.Add("5654");
            lista.Add("5655");
            lista.Add("5656");
            lista.Add("5657");
            lista.Add("5658");
            lista.Add("5659");
            lista.Add("5660");
            lista.Add("5661");
            lista.Add("5662");
            lista.Add("5663");
            lista.Add("5664");
            lista.Add("5665");
            lista.Add("5666");
            lista.Add("5667");
            lista.Add("6651");
            lista.Add("6652");
            lista.Add("6653");
            lista.Add("6654");
            lista.Add("6655");
            lista.Add("6656");
            lista.Add("6657");
            lista.Add("6658");
            lista.Add("6659");
            lista.Add("6660");
            lista.Add("6661");
            lista.Add("6662");
            lista.Add("6663");
            lista.Add("6664");
            lista.Add("6665");
            lista.Add("6666");
            lista.Add("6667");
            lista.Add("7651");
            lista.Add("7654");
            lista.Add("7667");
            return lista;
        }

    }
}
