using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using HLP.GeraXml.bel.NFe.ClassesSerializadas;
using HLP.GeraXml.bel;
using HLP.GeraXml.Comum.Static;
using CrystalDecisions.CrystalReports.Engine;
using HLP.GeraXml.UI.Relatorios;
using System.Threading;
using System.IO;
using HLP.GeraXml.Comum.DataSet;
using HLP.GeraXml.bel.NFe;
namespace HLP.GeraXml.UI.NFe
{
    public partial class frmCarregaDadosParaVisualizarDanfe : KryptonForm
    {
        public List<HLP.GeraXml.UI.NFe.frmGeraArquivoNFe.DadosImpressao> objDadosImp { get; set; }
        //private NFe_Report objNFeToReport;
        private List<NFe_HLP> objNFeToReport;


        private dsImagens dsImg;
        dsImagens.ImagensRow rowImg;

        public frmCarregaDadosParaVisualizarDanfe(List<HLP.GeraXml.UI.NFe.frmGeraArquivoNFe.DadosImpressao> objDadosImp)
        {
            InitializeComponent();
            objNFeToReport = new List<NFe_HLP>();
            this.objDadosImp = objDadosImp;
            bsDadosImp.DataSource = objDadosImp;
            dsImg = new dsImagens();
        }
        void EnviaEmail()
        {
            try
            {
                if (Acesso.VerificaDadosEmail())
                {
                    List<belEmail> objlbelEmail = new List<belEmail>();
                    for (int i = 0; i < objDadosImp.Count; i++)
                    {
                        belEmail objemail = new belEmail(objDadosImp[i].sCaminhoXml, objDadosImp[i].sCaminhoPDF, objDadosImp[i].sCD_NFSEQ, objDadosImp[i].sCD_NOTAFIS);
                        objlbelEmail.Add(objemail);
                    }

                    if (objlbelEmail.Count > 0)
                    {
                        frmEmail objfrmEmail = new frmEmail(objlbelEmail, objDadosImp.Where(C => C.Cancelado == true).Count() > 0 ? belEmail.TipoEmail.NFe_Cancelada : belEmail.TipoEmail.NFe_Normal);
                        objfrmEmail.ShowDialog();
                    }
                }
                else
                {
                    KryptonMessageBox.Show(null, "Campos para o envio de e-mail automático não estão preenchidos corretamente!", Mensagens.CHeader, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        void GeraXMLtoPDF(HLP.GeraXml.bel.NFe.ClassesSerializadas.NFe_HLP nf)
        {
            try
            {
                NFe_Report objnfReport;
                string sFilePath = Pastas.Temp + "NFeToReportPDF_{0}.xml";
                sFilePath = string.Format(sFilePath, nf.ide_nNF);

                this.Invoke(new MethodInvoker(delegate()
                {
                    try
                    {
                        if (File.Exists(sFilePath))
                            File.Delete(sFilePath);

                        objnfReport = new NFe_Report();
                        objnfReport.Notas.Add(nf);
                        SerializeClassToXml.SerializeClasse<List<NFe_HLP>>(objnfReport.Notas, sFilePath);
                    }
                    catch (Exception ex)
                    {
                        throw;
                    }
                }));
            }
            catch (Exception ex)
            {
                throw ex;
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

        void CarregaDadosNFe(ref NFe_HLP objNFe, ref nfeProc objNfeProc, ref infNFe nfe, HLP.GeraXml.UI.NFe.frmGeraArquivoNFe.DadosImpressao dados)
        {
            //"C:\\GeraXml\\Arquivos\\VIVABEM\\Contingencia\\\\35130947853981000183550010000001872000000665-nfe.xml"

            if (dados.tipo == frmGeraArquivoNFe.TipoPDF.CONTINGENCIA)
            {
                objNfeProc = new nfeProc();
                objNfeProc.lNfe = new List<bel.NFe.ClassesSerializadas.NFe>();
                objNfeProc.lNfe.Add(SerializeClassToXml.DeserializeClasse<HLP.GeraXml.bel.NFe.ClassesSerializadas.NFe>(dados.sCaminhoXml));
            }
            else
            {
                objNfeProc = SerializeClassToXml.DeserializeClasse<nfeProc>(dados.sCaminhoXml);
            }



            if (objNfeProc != null)
            {
                nfe = objNfeProc.lNfe.FirstOrDefault().lInfNfe.FirstOrDefault();
                objNFe = new NFe_HLP();
                objNFe.Id = nfe.Id.ToUpper().Replace("NFE", "").Trim();
                objNFe.tpEmis = nfe.ideField.tpEmis.ToString().Replace("Item", "").Trim();
                objNFe.tipoPDF = dados.tipo.ToString();
                rowImg = dsImg.Imagens.NewImagensRow();

                if (objNfeProc.protNFeField != null)
                    objNFe.infprot_nprot = objNfeProc.protNFeField.FirstOrDefault().infProtField.FirstOrDefault().nProt;
                objNFe.ide_nNF = nfe.ideField.nNF;
                objNFe.natOP = nfe.ideField.natOp;
                objNFe.ide_serie = nfe.ideField.serie;
                objNFe.ide_tpNF = nfe.ideField.tpNF;
                if (nfe.ideField.dEmi != "")
                    objNFe.ide_dEmi = nfe.ideField.dEmi.ToDateTime().ToShortDateString();
                if (Convert.ToBoolean(Acesso.VISUALIZA_DATA_DANFE))
                    if (nfe.ideField.dSaiEnt != "")
                        objNFe.ide_dSaiEnt = nfe.ideField.dSaiEnt.ToDateTime().ToShortDateString();

                objNFe.emit_xNome = nfe.emitField.xNome;
                objNFe.emit_xFant = nfe.emitField.xFant;
                objNFe.emit_CPF_CNPJ = nfe.emitField.Item;
                objNFe.emit_IE = nfe.emitField.IE;
                objNFe.emit_IEST = nfe.emitField.IEST;
                objNFe.enderEmit_xLgr = nfe.emitField.enderEmit.xLgr;
                objNFe.enderEmit_nro = nfe.emitField.enderEmit.nro;
                objNFe.enderEmit_xCpl = nfe.emitField.enderEmit.xCpl;
                objNFe.enderEmit_xBairro = nfe.emitField.enderEmit.xBairro;
                objNFe.enderEmit_cMun = nfe.emitField.enderEmit.cMun;
                objNFe.enderEmit_xMun = nfe.emitField.enderEmit.xMun;
                objNFe.enderEmit_UF = nfe.emitField.enderEmit.UF;
                objNFe.enderEmit_CEP = nfe.emitField.enderEmit.CEP;
                objNFe.enderEmit_fone = nfe.emitField.enderEmit.fone;


                objNFe.dest_xNome = nfe.destField.xNome;
                objNFe.dest_CPF_CNPJ = nfe.destField.Item; // Verificar
                objNFe.dest_IE = nfe.destField.IE;

                objNFe.enderDest_xLgr = nfe.destField.enderDest.xLgr;
                objNFe.enderDest_nro = nfe.destField.enderDest.nro;
                objNFe.enderDest_xCpl = nfe.destField.enderDest.xCpl;
                objNFe.enderDest_xBairro = nfe.destField.enderDest.xBairro;
                objNFe.enderDest_cMun = nfe.destField.enderDest.cMun;
                objNFe.enderDest_xMun = nfe.destField.enderDest.xMun;
                objNFe.enderDest_UF = nfe.destField.enderDest.UF;
                objNFe.enderDest_CEP = nfe.destField.enderDest.CEP;
                objNFe.enderDest_fone = nfe.destField.enderDest.fone;


                if (nfe.transpField != null)
                {
                    if (nfe.transpField.transporta != null)
                    {
                        objNFe.transp_xNome = nfe.transpField.transporta.xNome;
                        objNFe.transp_modFrete = nfe.transpField.modFrete;
                        objNFe.transp_CFP_CNPJ = nfe.transpField.transporta.Item;
                        objNFe.transp_xEnder = nfe.transpField.transporta.xEnder;
                        objNFe.transp_xMun = nfe.transpField.transporta.xMun;
                        objNFe.transp_UF = nfe.transpField.transporta.UF;
                        objNFe.transp_IE = nfe.transpField.transporta.IE;

                        if (nfe.transpField.Items != null)
                        {
                            TVeiculo veic = nfe.transpField.Items.FirstOrDefault(c => c.GetType() == typeof(TVeiculo)) as TVeiculo;
                            if (veic != null)
                            {
                                objNFe.transp_RNTCVeic = veic.RNTC;
                                objNFe.transp_placaVeic = veic.placa;
                                objNFe.transp_UFVeic = veic.UF.ToString();
                            }
                        }
                        if (nfe.transpField.vol != null)
                        {
                            objNFe.transp_qVol = nfe.transpField.vol.FirstOrDefault().qVol;
                            objNFe.transp_esp = nfe.transpField.vol.FirstOrDefault().esp;
                            objNFe.transp_marca = nfe.transpField.vol.FirstOrDefault().marca;
                            objNFe.transp_nVol = nfe.transpField.vol.FirstOrDefault().nVol;
                            objNFe.transp_PesoB = nfe.transpField.vol.FirstOrDefault().pesoB;
                            objNFe.transp_PesoL = nfe.transpField.vol.FirstOrDefault().pesoL;

                        }
                    }
                }

                objNFe.ICMSTot_vBC = nfe.totalField.ICMSTot.vBC.Replace('.', ',');
                objNFe.ICMSTot_vICMS = nfe.totalField.ICMSTot.vICMS.Replace('.', ',');
                objNFe.ICMSTot_vBCST = nfe.totalField.ICMSTot.vBCST.Replace('.', ',');
                objNFe.ICMSTot_vST = nfe.totalField.ICMSTot.vST.Replace('.', ',');
                objNFe.ICMSTot_vProd = nfe.totalField.ICMSTot.vProd.Replace('.', ',');
                objNFe.ICMSTot_vFrete = nfe.totalField.ICMSTot.vFrete.Replace('.', ',');
                objNFe.ICMSTot_vSeg = nfe.totalField.ICMSTot.vSeg.Replace('.', ',');
                objNFe.ICMSTot_vDesc = nfe.totalField.ICMSTot.vDesc.Replace('.', ',');
                objNFe.ICMSTot_vII = nfe.totalField.ICMSTot.vII.Replace('.', ',');
                objNFe.ICMSTot_vIPI = nfe.totalField.ICMSTot.vIPI.Replace('.', ',');
                objNFe.ICMSTot_vPIS = nfe.totalField.ICMSTot.vPIS.Replace('.', ',');
                objNFe.ICMSTot_vCOFINS = nfe.totalField.ICMSTot.vCOFINS.Replace('.', ',');
                objNFe.ICMSTot_vOutro = nfe.totalField.ICMSTot.vOutro.Replace('.', ',');
                objNFe.ICMSTot_vNF = nfe.totalField.ICMSTot.vNF.Replace('.', ',');
                objNFe.ICMSTot_vTotTrib = nfe.totalField.ICMSTot.vTotTrib.Replace('.', ',');
                if (nfe.infAdicField.infCpl != null)
                {
                    objNFe.xObs = nfe.infAdicField.infCpl.Replace(";", "." + Environment.NewLine);
                }


                if (nfe.totalField.ISSQNtot != null)
                {
                    objNFe.ISSQNtot_vBC = nfe.totalField.ISSQNtot.vBC.Replace('.', ',');
                    objNFe.ISSQNtot_vServ = nfe.totalField.ISSQNtot.vServ.Replace('.', ',');
                    objNFe.ISSQNtot_vISS = nfe.totalField.ISSQNtot.vISS.Replace('.', ',');
                }
                int iCount = 1;
                if (Acesso.IMPRIMI_FATURA)
                {
                    if (nfe.cobrField != null)
                    {
                        string sDupl = "Nº:{0}-{1}-R${2}";

                        objNFe.xDuplicatas = "";
                        string sDup = "";
                        foreach (TNFeInfNFeCobrDup dupli in nfe.cobrField.dup)
                        {
                            if (Acesso.NM_EMPRESA.Equals("GIWA"))
                                sDup = dupli.nDup.ToString().Insert(dupli.nDup.Count() - 1, "-");
                            else
                                sDup = dupli.nDup.ToString().Insert(dupli.nDup.Count() - 1, "-");

                                objNFe.xDuplicatas += string.Format(sDupl, sDup, Convert.ToDateTime(dupli.dVenc).ToString("dd/MM/yy"),
                                    Convert.ToDecimal(dupli.vDup.Replace(".", ",")).ToString("#0.00").Replace(".", ",")).PadRight(33, ' ') + "|";
                            if (iCount == 3)
                                objNFe.xDuplicatas += Environment.NewLine;

                            iCount++;
                            if (iCount > 3)
                                iCount = 1;
                        }
                    }
                }
                objNFe.Produtos = new List<Produto>();
                Produto prod = null;
                iCount = 1;
                foreach (det item in nfe.lDet)
                {
                    prod = new Produto();
                    prod.count = iCount;
                    iCount++;
                    prod.ide_nNF = objNFe.ide_nNF;
                    prod.cProd = item.prodField.cProd.ToString().Trim();
                    prod.xProd = item.prodField.xProd;
                    prod.ncm = item.prodField.NCM;
                    prod.cfop = item.prodField.CFOP;
                    prod.uCom = item.prodField.uCom;
                    prod.qCom = PopulaDs.FormataQtdeComercial(item.prodField.qCom.ToString().Replace('.', ','));
                    prod.vProd = item.prodField.vProd.Replace('.', ',');
                    prod.vUnCom = item.prodField.vUnCom.Replace('.', ',');
                    prod.cEAN = item.prodField.cEAN;
                    prod.xObs = item.infAdProd == null ? "" : item.infAdProd;


                    object icms = item.impostoField.Items.FirstOrDefault(c => c.GetType() == typeof(TNFeInfNFeDetImpostoICMS));
                    if (icms != null)
                    {
                        try
                        {
                            prod.vBC = (icms as TNFeInfNFeDetImpostoICMS).Item.GetPropertyValue("vBC").ToString().Replace('.', ','); ;
                        }
                        catch (Exception) { }
                        try
                        {

                            prod.vICMS = (icms as TNFeInfNFeDetImpostoICMS).Item.GetPropertyValue("vICMS").ToString().Replace('.', ','); ;
                        }
                        catch (Exception) { }
                        try
                        {

                            prod.pICMS = (icms as TNFeInfNFeDetImpostoICMS).Item.GetPropertyValue("pICMS").ToString().Replace('.', ',');

                        }
                        catch (Exception) { }
                        string cst = "";
                        try
                        {
                            cst = (icms as TNFeInfNFeDetImpostoICMS).Item.GetPropertyValue("CST").ToString();
                        }
                        catch (Exception)
                        {
                            cst = (icms as TNFeInfNFeDetImpostoICMS).Item.GetPropertyValue("CSOSN").ToString();
                        }
                        cst = (icms as TNFeInfNFeDetImpostoICMS).Item.GetPropertyValue("orig").ToString() + cst;
                        prod.cst = cst;
                    }

                    object ipi = item.impostoField.Items.FirstOrDefault(c => c.GetType() == typeof(TNFeInfNFeDetImpostoIPI));

                    if (ipi != null)
                    {
                        try
                        {
                            prod.vIPI = (ipi as TNFeInfNFeDetImpostoIPI).Item.GetPropertyValue("vIPI").ToString().Replace('.', ',');
                        }
                        catch (Exception) { }
                        try
                        {
                            prod.pIPI = (ipi as TNFeInfNFeDetImpostoIPI).Item.GetPropertyValue("pIPI").ToString().Replace('.', ',');
                        }
                        catch (Exception) { }
                    }
                    objNFe.Produtos.Add(prod);
                }
                Byte[] bimagem = SalvaCodBarras(objNFe.Id);
                rowImg.cod_barras = bimagem;
                rowImg.LogoTipo = Util.CarregaLogoEmpresa();
                rowImg.id = objNFe.Id;
                if (Convert.ToBoolean(Acesso.VISUALIZA_HORA_DANFE))
                {
                    rowImg.hora_impressao = DateTime.Now.ToString("HH:mm");
                }

                if (objNFe.tpEmis == "2")
                {
                    objNFe.dadosNFe = this.GeraChaveDadosNFe(objNFe);
                    Byte[] bImagemDadosNfe = SalvaCodBarras(objNFe.dadosNFe);
                    rowImg.cod_barras_contingencia = bImagemDadosNfe;
                }
                dsImg.Imagens.Rows.Add(rowImg);

                objNFeToReport.Add(objNFe);

            }
        }


        private string GeraChaveDadosNFe(NFe_HLP objNFe)
        {
            string scUF = "";
            string stpEmis = "";
            string sCNPJ = "";
            string svNF = "";
            string sICMSp = "0";
            string sICMSs = "0";
            string sDD = "";
            string sDV = "";
            belUF objbelUF = new belUF();

            scUF = objbelUF.RetornaCUF(objNFe.enderDest_UF);
            stpEmis = objNFe.tpEmis;
            sCNPJ = objNFe.dest_CPF_CNPJ;
            svNF = objNFe.ICMSTot_vNF.Replace(",", "").PadLeft(14, '0');
            sDD = Convert.ToDateTime(objNFe.ide_dEmi).Day.ToString();


            if (objNFe.ICMSTot_vST != "0,00")
                sICMSs = "1";
            else
                sICMSs = "2";


            if (objNFe.ICMSTot_vICMS != "0,00")
                sICMSs = "1";
            else
                sICMSs = "2";

            string sDadosNfe = scUF + stpEmis + sCNPJ + svNF + sICMSp + sICMSs + sDD;
            string sDig = CalculaDig11(sDadosNfe).ToString();
            return (sDadosNfe + sDig).Trim();
        }

        public int CalculaDig11(string sChave)
        {

            int iDig = 0;
            int iMult = 2;
            int iTotal = 0;

            for (int i = (sChave.Length - 1); i >= 0; i--)
            {
                iTotal += Convert.ToInt32(sChave[i].ToString()) * iMult;
                iMult++;
                if (iMult > 9)
                {
                    iMult = 2;
                }

            }
            int iresto = (iTotal % 11);
            if ((iresto == 0) || (iresto == 1))
            {
                iDig = 0;
            }
            else
            {
                iDig = 11 - iresto;
            }
            return iDig;
        }



        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            NFe_HLP objNFe = null;
            nfeProc objNfeProc = null;
            infNFe nfe = null;
            int i = 0;
            string slblInfo = "{0} de {1} Arquivo(s)...";
            foreach (HLP.GeraXml.UI.NFe.frmGeraArquivoNFe.DadosImpressao dados in objDadosImp)
            {
                CarregaDadosNFe(ref objNFe, ref objNfeProc, ref nfe, dados);
                if (dados.tipo == frmGeraArquivoNFe.TipoPDF.CANCELADO)
                    objNFe.xCANC = "NFe CANCELADA";
                GeraXMLtoPDF(objNFe);
                dados.xStatus = "Dados carregados em memória...";
                this.Invoke(new MethodInvoker(delegate()
                {
                    dgvNotas.CurrentCell = dgvNotas.Rows[i].Cells[2];
                    dgvNotas.CurrentRow.DefaultCellStyle.BackColor = Color.Aquamarine;
                    lblInfo.Text = string.Format(slblInfo, (i + 1).ToString(), objNFeToReport.Count());
                    dgvNotas.Refresh();
                    lblInfo.Refresh();
                }));
                i++;
            }

            string sFileSave = Pastas.Temp + "NFeToReport.xml";
            if (File.Exists(sFileSave))
                File.Delete(sFileSave);
            SerializeClassToXml.SerializeClasse<List<NFe_HLP>>(objNFeToReport, sFileSave);
        }
        void frmCarregaDadosParaVisualizarDanfe_Load(object sender, EventArgs e)
        {
            try
            {
                timerGeraPDF.Start();
                if (worker.IsBusy != true)
                {
                    worker.RunWorkerAsync();
                }
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }
        void workerPDF_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                //string sCaminhoSave = "";
                string sFilePath = "";
                string slblInfo = "{0} de {1} Arquivo(s)...";
                DirectoryInfo dinfo = new DirectoryInfo(Pastas.ENVIADOS + "\\PDF");
                if (!dinfo.Exists)
                {
                    dinfo.Create();
                }
                ReportDocument rpt = new ReportDocument();
                if (Convert.ToBoolean(Acesso.USA_DANFE_SIMPLIFICADA))
                {
                    rpt.Load(Util.GetPathRelatorio("RelDanfeSimplificada2013.rpt"));
                }
                else if (Acesso.TIPO_IMPRESSAO.Equals("Retrato"))
                {
                    string xCNPJ = objNFeToReport.FirstOrDefault().dest_CPF_CNPJ;
                    rpt.Load(Util.GetPathRelatorio("RelDanfe2013.rpt", xCNPJ));
                }
                else
                {
                    rpt.Load(Util.GetPathRelatorio("RelDanfePaisagem2013.rpt"));
                }

                rpt.Database.Tables["Imagens"].SetDataSource(dsImg);
                DataSet dsTemp = null;
                int i = 0;
                foreach (HLP.GeraXml.bel.NFe.ClassesSerializadas.NFe_HLP nf in objNFeToReport)
                {
                    HLP.GeraXml.UI.NFe.frmGeraArquivoNFe.DadosImpressao dadosImp = objDadosImp.FirstOrDefault(c => c.sCD_NOTAFIS == nf.ide_nNF);
                    if (!File.Exists(dadosImp.sCaminhoPDF))
                    {
                        sFilePath = string.Format((Pastas.Temp + "NFeToReportPDF_{0}.xml"), nf.ide_nNF);
                        this.Invoke(new MethodInvoker(delegate()
                        {
                            try
                            {
                                dadosImp.xStatus = "Gerando PDF...";
                                this.Invoke(new MethodInvoker(delegate()
                                {
                                    dgvNotas.Refresh();
                                }));
                                dsTemp = new DataSet();
                                dsTemp.ReadXml(sFilePath);
                                rpt.SetDataSource(dsTemp);
                                rpt.Refresh();
                            }
                            catch (Exception ex)
                            {
                                throw ex;
                            }
                        }));
                        Util.ExportPDF(rpt, dadosImp.sCaminhoPDF);
                        nf.PathPDF = dadosImp.sCaminhoPDF;
                    }
                    else
                    {
                        nf.PathPDF = dadosImp.sCaminhoPDF;
                    }

                    objDadosImp.FirstOrDefault(c => c.sCD_NOTAFIS == nf.ide_nNF).xStatus = "PDF Gerado com sucesso.";

                    this.Invoke(new MethodInvoker(delegate()
                    {
                        lblInfo.Text = string.Format(slblInfo, (i + 1).ToString(), objNFeToReport.Count());
                        dgvNotas.CurrentCell = dgvNotas.Rows[i].Cells[2];
                        dgvNotas.CurrentRow.DefaultCellStyle.BackColor = Color.Wheat;
                        dgvNotas.Refresh();
                        lblInfo.Refresh();
                    }));
                    i++;
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        void timerEmail_Tick(object sender, EventArgs e)
        {
            try
            {
                if (workerPDF.IsBusy == false)
                {
                    timerEmail.Stop();
                    this.Hide();
                    EnviaEmail();
                    this.Close();
                }
            }
            catch (Exception EX)
            {
                throw EX;
            }

        }
        void timerVisualizaDANFE_Tick(object sender, EventArgs e)
        {
            try
            {

                if (worker.IsBusy == false)
                {
                    timerGeraPDF.Stop();
                    string sFileSave = Pastas.Temp + "NFeToReport.xml";
                    DataSet dsTemp = new DataSet();
                    dsTemp.ReadXml(sFileSave);


                    ReportDocument rpt = new ReportDocument();
                    if (Convert.ToBoolean(Acesso.USA_DANFE_SIMPLIFICADA))
                    {
                        rpt.Load(Util.GetPathRelatorio("RelDanfeSimplificada2013.rpt"));
                    }
                    else if (Acesso.TIPO_IMPRESSAO.Equals("Retrato"))
                    {
                        string xCNPJ = objNFeToReport.FirstOrDefault().dest_CPF_CNPJ;
                        rpt.Load(Util.GetPathRelatorio("RelDanfe2013.rpt", xCNPJ));
                    }
                    else
                    {
                        rpt.Load(Util.GetPathRelatorio("RelDanfePaisagem2013.rpt"));
                    }
                    rpt.SetDataSource(dsTemp);
                    rpt.Database.Tables["Imagens"].SetDataSource(dsImg);
                    frmRelatorio objfrmDanfe = new frmRelatorio(rpt, "Impressão de DANFE");
                    objfrmDanfe.ShowDialog();

                    if (Convert.ToBoolean(Acesso.EMAIL_AUTOMATICO))
                    {
                        timerEmail.Start();
                        if (workerPDF.IsBusy != true)
                        {
                            workerPDF.RunWorkerAsync();
                        }
                    }
                    else
                    {
                        this.Close();
                    }
                }
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }
    }
}
