using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HLP.GeraXml.Comum.Forms;
using HLP.GeraXml.bel.CTe;
using HLP.GeraXml.bel.CTe.infCte.infCTeNorm;
using HLP.GeraXml.bel.CTe.infCte.imp;
using HLP.GeraXml.bel.CTe.infCte.vPrest;
using HLP.GeraXml.bel.CTe.infCte.rem;
using HLP.GeraXml.bel.CTe.infCte.receb;
using HLP.GeraXml.bel.CTe.infCte.exped;
using HLP.GeraXml.bel.CTe.infCte.dest;
using HLP.GeraXml.bel.CTe.infCte.emit;
using HLP.GeraXml.bel.CTe.infCte.ide;
using HLP.GeraXml.Comum.Static;
using HLP.GeraXml.Comum;
using ComponentFactory.Krypton.Toolkit;

namespace HLP.GeraXml.UI.CTe
{
    public partial class frmVisualizaCte : FormPadraoVisualizacao
    {
        belPopulaObjetos objObjetos = null;
        public belPopulaObjetos objObjetosAlter = null;

        public frmVisualizaCte(belPopulaObjetos objObjetos)
        {
            InitializeComponent();
            listErros.ListBox.MouseDoubleClick += new MouseEventHandler(listErros_MouseDoubleClick);
            this.objObjetos = objObjetos;
            CriaObjAlter();
            bsNotas.DataSource = this.objObjetosAlter.objListaConhecimentos;
            ValidaConhecimentos();
            PopulaForm();
            VerificaCampos();
        }

        private void frmVisualizaCte_Load(object sender, EventArgs e)
        {
            cbotoma.cbx.SelectedIndexChanged += new EventHandler(cbotoma_SelectedIndexChanged);
            cboCST.cbx.SelectedIndexChanged += new EventHandler(cboCST_SelectedIndexChanged);
        }

        #region Eventos

        private void cboCST_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboCST.SelectedIndex != -1)
                {
                    HabilitaCamposValores(cboCST.SelectedIndex);
                }
            }
            catch (Exception ex)
            {
                new HLPexception(ex);
            }
        }
        private void cbotoma_SelectedIndexChanged(object sender, EventArgs e)
        {
            HabilitaCamposToma();
        }

        private void listErros_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (listErros.SelectedValue != null)
                {
                    Control ctr = listErros.SelectedValue as Control;
                    belValidaCampos.ListaErros objerro = (belValidaCampos.ListaErros)listErros.SelectedItem;

                    int iposicao = bsNotas.IndexOf(((List<belinfCte>)bsNotas.List).FirstOrDefault(c => c.ide.nCT == objerro.NumeroDocumento));
                    bsNotas.Position = iposicao;
                    lblContagemNotas.Text = (bsNotas.Position + 1).ToString() + " de " + bsNotas.Count;
                    PopulaForm();
                    VerificaCampos();
                    ProcuraTabPage(ctr);
                    ctr.Focus();
                }

            }
            catch (Exception ex)
            {
                new HLPexception(ex);
            }

        }

        #endregion

        #region Metodos

        private void CriaObjAlter()
        {
            try
            {
                List<belinfCte> objList = new List<belinfCte>();

                for (int i = 0; i < this.objObjetos.objListaConhecimentos.Count; i++)
                {
                    belinfCte objbelinfCte = new belinfCte();
                    belinfCte obj = this.objObjetos.objListaConhecimentos[i];

                    #region Identificacao
                    objbelinfCte.id = obj.id;
                    objbelinfCte.ide = new belide();

                    objbelinfCte.ide.cUF = obj.ide.cUF;
                    objbelinfCte.ide.cCT = obj.ide.cCT;
                    objbelinfCte.ide.CFOP = obj.ide.CFOP;
                    objbelinfCte.ide.natOp = obj.ide.natOp;
                    objbelinfCte.ide.forPag = obj.ide.forPag;
                    objbelinfCte.ide.mod = obj.ide.mod;
                    objbelinfCte.ide.serie = obj.ide.serie;
                    objbelinfCte.ide.nCT = obj.ide.nCT;
                    objbelinfCte.ide.tpImp = obj.ide.tpImp;
                    objbelinfCte.ide.tpEmis = obj.ide.tpEmis;
                    objbelinfCte.ide.cDV = obj.ide.cDV;
                    objbelinfCte.ide.tpAmb = obj.ide.tpAmb;
                    objbelinfCte.ide.tpCTe = obj.ide.tpCTe;
                    objbelinfCte.ide.procEmi = obj.ide.procEmi;
                    objbelinfCte.ide.verProc = obj.ide.verProc;
                    objbelinfCte.ide.cMunEnv = obj.ide.cMunEnv;
                    objbelinfCte.ide.xMunEnv = obj.ide.xMunEnv;
                    objbelinfCte.ide.UFEnv = obj.ide.UFEnv;
                    objbelinfCte.ide.modal = obj.ide.modal;
                    objbelinfCte.ide.tpServ = obj.ide.tpServ;
                    objbelinfCte.ide.cMunIni = obj.ide.cMunIni;
                    objbelinfCte.ide.xMunIni = obj.ide.xMunIni;
                    objbelinfCte.ide.UFIni = obj.ide.UFIni;
                    objbelinfCte.ide.cMunFim = obj.ide.cMunFim;
                    objbelinfCte.ide.xMunFim = obj.ide.xMunFim;
                    objbelinfCte.ide.UFFim = obj.ide.UFFim;
                    objbelinfCte.ide.retira = obj.ide.retira;
                    objbelinfCte.ide.xDetRetira = obj.ide.xDetRetira;

                    #endregion

                    #region Tomador
                    if (obj.ide.toma03 != null)
                    {
                        objbelinfCte.ide.toma03 = new beltoma03();
                        objbelinfCte.ide.toma03.toma = obj.ide.toma03.toma;
                    }
                    else if (obj.ide.toma04 != null)
                    {
                        objbelinfCte.ide.toma04 = new beltoma04();
                        objbelinfCte.ide.toma04.toma = obj.ide.toma04.toma;
                        objbelinfCte.ide.toma04.CNPJ = obj.ide.toma04.CNPJ;
                        objbelinfCte.ide.toma04.CPF = obj.ide.toma04.CPF;
                        objbelinfCte.ide.toma04.IE = obj.ide.toma04.IE;
                        objbelinfCte.ide.toma04.xNome = obj.ide.toma04.xNome;
                        objbelinfCte.ide.toma04.xFant = obj.ide.toma04.xFant;
                        objbelinfCte.ide.toma04.fone = obj.ide.toma04.fone;

                        objbelinfCte.ide.toma04.enderToma = new belenderToma();
                        objbelinfCte.ide.toma04.enderToma.xLgr = obj.ide.toma04.enderToma.xLgr;
                        objbelinfCte.ide.toma04.enderToma.nro = obj.ide.toma04.enderToma.nro;
                        objbelinfCte.ide.toma04.enderToma.xCpl = obj.ide.toma04.enderToma.xCpl;
                        objbelinfCte.ide.toma04.enderToma.xBairro = obj.ide.toma04.enderToma.xBairro;
                        objbelinfCte.ide.toma04.enderToma.cMun = obj.ide.toma04.enderToma.cMun;
                        objbelinfCte.ide.toma04.enderToma.xMun = obj.ide.toma04.enderToma.xMun;
                        objbelinfCte.ide.toma04.enderToma.CEP = obj.ide.toma04.enderToma.CEP;
                        objbelinfCte.ide.toma04.enderToma.UF = obj.ide.toma04.enderToma.UF;
                        objbelinfCte.ide.toma04.enderToma.cPais = obj.ide.toma04.enderToma.cPais;
                        objbelinfCte.ide.toma04.enderToma.xPais = obj.ide.toma04.enderToma.xPais;

                    }

                    #endregion

                    #region Emitente
                    objbelinfCte.emit = new belemit();

                    objbelinfCte.emit.CNPJ = obj.emit.CNPJ;
                    objbelinfCte.emit.IE = obj.emit.IE;
                    objbelinfCte.emit.xNome = obj.emit.xNome;
                    objbelinfCte.emit.xFant = obj.emit.xFant;

                    objbelinfCte.emit.enderEmit = new belenderEmit();

                    objbelinfCte.emit.enderEmit.xLgr = obj.emit.enderEmit.xLgr;
                    objbelinfCte.emit.enderEmit.nro = obj.emit.enderEmit.nro;
                    objbelinfCte.emit.enderEmit.xCpl = obj.emit.enderEmit.xCpl;
                    objbelinfCte.emit.enderEmit.xBairro = obj.emit.enderEmit.xBairro;
                    objbelinfCte.emit.enderEmit.cMun = obj.emit.enderEmit.cMun;
                    objbelinfCte.emit.enderEmit.xMun = obj.emit.enderEmit.xMun;
                    objbelinfCte.emit.enderEmit.CEP = obj.emit.enderEmit.CEP;
                    objbelinfCte.emit.enderEmit.UF = obj.emit.enderEmit.UF;
                    objbelinfCte.emit.enderEmit.fone = obj.emit.enderEmit.fone;

                    #endregion

                    #region Remetente
                    objbelinfCte.rem = new belrem();

                    objbelinfCte.rem.CNPJ = obj.rem.CNPJ;
                    objbelinfCte.rem.CPF = obj.rem.CPF;
                    objbelinfCte.rem.IE = obj.rem.IE;
                    objbelinfCte.rem.xNome = obj.rem.xNome;
                    objbelinfCte.rem.xFant = obj.rem.xFant;
                    objbelinfCte.rem.fone = obj.rem.fone;

                    objbelinfCte.rem.enderReme = new belenderReme();

                    objbelinfCte.rem.enderReme.xLgr = obj.rem.enderReme.xLgr;
                    objbelinfCte.rem.enderReme.nro = obj.rem.enderReme.nro;
                    objbelinfCte.rem.enderReme.xCpl = obj.rem.enderReme.xCpl;
                    objbelinfCte.rem.enderReme.xBairro = obj.rem.enderReme.xBairro;
                    objbelinfCte.rem.enderReme.cMun = obj.rem.enderReme.cMun;
                    objbelinfCte.rem.enderReme.xMun = obj.rem.enderReme.xMun;
                    try
                    {
                        objbelinfCte.rem.enderReme.CEP = obj.rem.enderReme.CEP;
                    }
                    catch (Exception)
                    {
                    }
                    
                    objbelinfCte.rem.enderReme.UF = obj.rem.enderReme.UF;
                    objbelinfCte.rem.enderReme.xPais = obj.rem.enderReme.xPais;
                    objbelinfCte.rem.enderReme.cPais = obj.rem.enderReme.cPais;

                    #endregion

                    #region Destinatario

                    objbelinfCte.dest = new beldest();

                    objbelinfCte.dest.CNPJ = obj.dest.CNPJ;
                    objbelinfCte.dest.CPF = obj.dest.CPF;
                    objbelinfCte.dest.IE = obj.dest.IE;
                    objbelinfCte.dest.xNome = obj.dest.xNome;
                    objbelinfCte.dest.fone = obj.dest.fone;
                    objbelinfCte.dest.ISUF = obj.dest.ISUF;

                    objbelinfCte.dest.enderDest = new belenderDest();

                    objbelinfCte.dest.enderDest.xLgr = obj.dest.enderDest.xLgr;
                    objbelinfCte.dest.enderDest.nro = obj.dest.enderDest.nro;
                    objbelinfCte.dest.enderDest.xCpl = obj.dest.enderDest.xCpl;
                    objbelinfCte.dest.enderDest.xBairro = obj.dest.enderDest.xBairro;
                    objbelinfCte.dest.enderDest.cMun = obj.dest.enderDest.cMun;
                    objbelinfCte.dest.enderDest.xMun = obj.dest.enderDest.xMun;
                    objbelinfCte.dest.enderDest.CEP = obj.dest.enderDest.CEP;
                    objbelinfCte.dest.enderDest.UF = obj.dest.enderDest.UF;
                    objbelinfCte.dest.enderDest.xPais = obj.dest.enderDest.xPais;
                    objbelinfCte.dest.enderDest.cPais = obj.dest.enderDest.cPais;

                    #endregion

                    #region Expedidor
                    if (obj.exped != null)
                    {
                        objbelinfCte.exped = new belexped();

                        objbelinfCte.exped.CNPJ = obj.exped.CNPJ;
                        objbelinfCte.exped.CPF = obj.exped.CPF;
                        objbelinfCte.exped.IE = obj.exped.IE;
                        objbelinfCte.exped.xNome = obj.exped.xNome;
                        objbelinfCte.exped.fone = obj.exped.fone;

                        objbelinfCte.exped.enderExped = new belenderExped();

                        objbelinfCte.exped.enderExped.xLgr = obj.exped.enderExped.xLgr;
                        objbelinfCte.exped.enderExped.nro = obj.exped.enderExped.nro;
                        objbelinfCte.exped.enderExped.xCpl = obj.exped.enderExped.xCpl;
                        objbelinfCte.exped.enderExped.xBairro = obj.exped.enderExped.xBairro;
                        objbelinfCte.exped.enderExped.cMun = obj.exped.enderExped.cMun;
                        objbelinfCte.exped.enderExped.xMun = obj.exped.enderExped.xMun;
                        objbelinfCte.exped.enderExped.CEP = obj.exped.enderExped.CEP;
                        objbelinfCte.exped.enderExped.UF = obj.exped.enderExped.UF;
                        objbelinfCte.exped.enderExped.xPais = obj.exped.enderExped.xPais;
                        objbelinfCte.exped.enderExped.cPais = obj.exped.enderExped.cPais;


                    }


                    #endregion

                    #region Recebedor
                    if (obj.receb != null)
                    {
                        objbelinfCte.receb = new belreceb();

                        objbelinfCte.receb.CNPJ = obj.receb.CNPJ;
                        objbelinfCte.receb.CPF = obj.receb.CPF;
                        objbelinfCte.receb.IE = obj.receb.IE;
                        objbelinfCte.receb.xNome = obj.receb.xNome;
                        objbelinfCte.receb.fone = obj.receb.fone;

                        objbelinfCte.receb.enderReceb = new belenderReceb();

                        objbelinfCte.receb.enderReceb.xLgr = obj.receb.enderReceb.xLgr;
                        objbelinfCte.receb.enderReceb.nro = obj.receb.enderReceb.nro;
                        objbelinfCte.receb.enderReceb.xCpl = obj.receb.enderReceb.xCpl;
                        objbelinfCte.receb.enderReceb.xBairro = obj.receb.enderReceb.xBairro;
                        objbelinfCte.receb.enderReceb.cMun = obj.receb.enderReceb.cMun;
                        objbelinfCte.receb.enderReceb.xMun = obj.receb.enderReceb.xMun;
                        objbelinfCte.receb.enderReceb.CEP = obj.receb.enderReceb.CEP;
                        objbelinfCte.receb.enderReceb.UF = obj.receb.enderReceb.UF;
                        objbelinfCte.receb.enderReceb.xPais = obj.receb.enderReceb.xPais;
                        objbelinfCte.receb.enderReceb.cPais = obj.receb.enderReceb.cPais;


                    }


                    #endregion

                    #region Informacoes da NF
                    objbelinfCte.infCTeNorm.infDoc.infNF = obj.infCTeNorm.infDoc.infNF;
                    //objbelinfCte.infCTeNorm.infDoc.infNF = new List<belinfNF>();
                    //for (int j = 0; j < obj.infCTeNorm.infDoc.infNF.Count; j++)
                    //{
                    //    belinfNF nf = new belinfNF();
                    //    nf.mod = obj.infCTeNorm.infDoc.infNF[j].mod;
                    //    nf.nDoc = obj.infCTeNorm.infDoc.infNF[j].nDoc;
                    //    nf.serie = obj.infCTeNorm.infDoc.infNF[j].serie;
                    //    nf.dEmi = obj.infCTeNorm.infDoc.infNF[j].dEmi;
                    //    nf.vBC = obj.infCTeNorm.infDoc.infNF[j].vBC;
                    //    nf.vICMS = obj.infCTeNorm.infDoc.infNF[j].vICMS;
                    //    nf.vBCST = obj.infCTeNorm.infDoc.infNF[j].vBCST;
                    //    nf.vST = obj.infCTeNorm.infDoc.infNF[j].vST;
                    //    nf.vProd = obj.infCTeNorm.infDoc.infNF[j].vProd;
                    //    nf.vNF = obj.infCTeNorm.infDoc.infNF[j].vNF;
                    //    nf.nCFOP = Convert.ToInt32(obj.infCTeNorm.infDoc.infNF[j].nCFOP).ToString();

                    //    objbelinfCte.infCTeNorm.infDoc.infNF.Add(nf);
                    //}

                    objbelinfCte.infCTeNorm.infDoc.infNFe = obj.infCTeNorm.infDoc.infNFe;
                    //objbelinfCte.infCTeNorm.infDoc.infNFe = new List<belinfNFe>();
                    //for (int n = 0; n < obj.infCTeNorm.infDoc.infNFe.Count; n++)
                    //{
                    //    belinfNFe nfe = new belinfNFe();
                    //    nfe.chave = obj.infCTeNorm.infDoc.infNFe[n].chave;
                    //    nfe.nDoc = obj.infCTeNorm.infDoc.infNFe[n].nDoc;

                    //    objbelinfCte.infCTeNorm.infDoc.infNFe.Add(nfe);
                    //}

                    #endregion

                    #region Outros Documentos

                    objbelinfCte.infCTeNorm.infDoc.infOutros = obj.infCTeNorm.infDoc.infOutros;
                    //objbelinfCte.infCTeNorm.infDoc.infOutros = new List<belinfOutros>();
                    //for (int j = 0; j < obj.infCTeNorm.infDoc.infOutros.Count; j++)
                    //{
                    //    belinfOutros infOutros = new belinfOutros();
                    //    infOutros.tpDoc = obj.infCTeNorm.infDoc.infOutros[j].tpDoc;
                    //    infOutros.descOutros = obj.infCTeNorm.infDoc.infOutros[j].descOutros;
                    //    infOutros.nDoc = obj.infCTeNorm.infDoc.infOutros[j].nDoc;
                    //    infOutros.dEmi = obj.infCTeNorm.infDoc.infOutros[j].dEmi;
                    //    infOutros.vDocFisc = obj.infCTeNorm.infDoc.infOutros[j].vDocFisc;

                    //    objbelinfCte.infCTeNorm.infDoc.infOutros.Add(infOutros);
                    //}


                    #endregion

                    #region Valores

                    objbelinfCte.vPrest = new belvPrest();
                    objbelinfCte.vPrest.vTPrest = obj.vPrest.vTPrest;
                    objbelinfCte.vPrest.vRec = obj.vPrest.vRec;

                    objbelinfCte.vPrest.Comp = obj.vPrest.Comp;



                    objbelinfCte.imp = new belimp();
                    objbelinfCte.imp.ICMS = new belICMS();

                    if (obj.imp.ICMS.ICMS00 != null)
                    {
                        objbelinfCte.imp.ICMS.ICMS00 = new belICMS00();
                        objbelinfCte.imp.ICMS.ICMS00.CST = obj.imp.ICMS.ICMS00.CST;
                        objbelinfCte.imp.ICMS.ICMS00.vBC = obj.imp.ICMS.ICMS00.vBC;
                        objbelinfCte.imp.ICMS.ICMS00.pICMS = obj.imp.ICMS.ICMS00.pICMS;
                        objbelinfCte.imp.ICMS.ICMS00.vICMS = obj.imp.ICMS.ICMS00.vICMS;
                    }
                    else if (obj.imp.ICMS.ICMS20 != null)
                    {
                        objbelinfCte.imp.ICMS.ICMS20 = new belICMS20();
                        objbelinfCte.imp.ICMS.ICMS20.CST = obj.imp.ICMS.ICMS20.CST;
                        objbelinfCte.imp.ICMS.ICMS20.pRedBC = obj.imp.ICMS.ICMS20.pRedBC;
                        objbelinfCte.imp.ICMS.ICMS20.vBC = obj.imp.ICMS.ICMS20.vBC;
                        objbelinfCte.imp.ICMS.ICMS20.pICMS = obj.imp.ICMS.ICMS20.pICMS;
                        objbelinfCte.imp.ICMS.ICMS20.vICMS = obj.imp.ICMS.ICMS20.vICMS;
                    }
                    else if (obj.imp.ICMS.ICMS45 != null)
                    {
                        objbelinfCte.imp.ICMS.ICMS45 = new belICMS45();
                        objbelinfCte.imp.ICMS.ICMS45.CST = obj.imp.ICMS.ICMS45.CST;
                    }
                    else if (obj.imp.ICMS.ICMS60 != null)
                    {
                        objbelinfCte.imp.ICMS.ICMS60 = new belICMS60();
                        objbelinfCte.imp.ICMS.ICMS60.CST = obj.imp.ICMS.ICMS60.CST;
                        objbelinfCte.imp.ICMS.ICMS60.vBCSTRet = obj.imp.ICMS.ICMS60.vBCSTRet;
                        objbelinfCte.imp.ICMS.ICMS60.vICMSSTRet = obj.imp.ICMS.ICMS60.vICMSSTRet;
                        objbelinfCte.imp.ICMS.ICMS60.pICMSSTRet = obj.imp.ICMS.ICMS60.pICMSSTRet;
                        objbelinfCte.imp.ICMS.ICMS60.vCred = obj.imp.ICMS.ICMS60.vCred;
                    }
                    else if (obj.imp.ICMS.ICMS90 != null)
                    {
                        objbelinfCte.imp.ICMS.ICMS90 = new belICMS90();
                        objbelinfCte.imp.ICMS.ICMS90.CST = obj.imp.ICMS.ICMS90.CST;
                        objbelinfCte.imp.ICMS.ICMS90.pRedBC = obj.imp.ICMS.ICMS90.pRedBC;
                        objbelinfCte.imp.ICMS.ICMS90.vBC = obj.imp.ICMS.ICMS90.vBC;
                        objbelinfCte.imp.ICMS.ICMS90.pICMS = obj.imp.ICMS.ICMS90.pICMS;
                        objbelinfCte.imp.ICMS.ICMS90.vICMS = obj.imp.ICMS.ICMS90.vICMS;
                        objbelinfCte.imp.ICMS.ICMS90.vCred = obj.imp.ICMS.ICMS90.vCred;
                    }
                    else if (obj.imp.ICMS.ICMSOutraUF != null)
                    {
                        objbelinfCte.imp.ICMS.ICMSOutraUF = new belICMSOutraUF();
                        objbelinfCte.imp.ICMS.ICMSOutraUF.CST = obj.imp.ICMS.ICMSOutraUF.CST;
                        objbelinfCte.imp.ICMS.ICMSOutraUF.pRedBCOutraUF = obj.imp.ICMS.ICMSOutraUF.pRedBCOutraUF;
                        objbelinfCte.imp.ICMS.ICMSOutraUF.vBCOutraUF = obj.imp.ICMS.ICMSOutraUF.vBCOutraUF;
                        objbelinfCte.imp.ICMS.ICMSOutraUF.pICMSOutraUF = obj.imp.ICMS.ICMSOutraUF.pICMSOutraUF;
                        objbelinfCte.imp.ICMS.ICMSOutraUF.vICMSOutraUF = obj.imp.ICMS.ICMSOutraUF.vICMSOutraUF;
                    }


                    #endregion

                    #region InformacoesCarga

                    //objbelinfCte.infCTeNorm = new belinfCTeNorm();
                    objbelinfCte.infCTeNorm.infCarga = new belinfCarga();

                    objbelinfCte.infCTeNorm.infCarga.vCarga = obj.infCTeNorm.infCarga.vCarga;
                    objbelinfCte.infCTeNorm.infCarga.proPred = obj.infCTeNorm.infCarga.proPred;
                    objbelinfCte.infCTeNorm.infCarga.xOutCat = obj.infCTeNorm.infCarga.xOutCat;

                    objbelinfCte.infCTeNorm.infCarga.infQ = new List<belinfQ>();
                    for (int j = 0; j < obj.infCTeNorm.infCarga.infQ.Count; j++)
                    {
                        belinfQ objInfQ = new belinfQ();
                        objInfQ.cUnid = obj.infCTeNorm.infCarga.infQ[j].cUnid;
                        objInfQ.tpMed = obj.infCTeNorm.infCarga.infQ[j].tpMed;
                        objInfQ.qCarga = obj.infCTeNorm.infCarga.infQ[j].qCarga;

                        objbelinfCte.infCTeNorm.infCarga.infQ.Add(objInfQ);
                    }

                    #endregion

                    #region Rodoviario

                    objbelinfCte.infCTeNorm.seg = new belseg();
                    objbelinfCte.infCTeNorm.rodo = new belrodo();

                    objbelinfCte.infCTeNorm.seg.respSeg = obj.infCTeNorm.seg.respSeg;
                    objbelinfCte.infCTeNorm.seg.nApol = obj.infCTeNorm.seg.nApol;
                    objbelinfCte.infCTeNorm.rodo.RNTRC = obj.infCTeNorm.rodo.RNTRC;
                    objbelinfCte.infCTeNorm.rodo.dPrev = obj.infCTeNorm.rodo.dPrev;
                    objbelinfCte.infCTeNorm.rodo.lota = obj.infCTeNorm.rodo.lota;

                    #endregion

                    #region Obs
                    objbelinfCte.compl = new belcompl();
                    objbelinfCte.compl.ObsCont.xTexto = obj.compl.ObsCont.xTexto;
                    #endregion

                    #region Veiculo

                    objbelinfCte.infCTeNorm.rodo.veic = new List<belveic>();
                    for (int v = 0; v < obj.infCTeNorm.rodo.veic.Count; v++)
                    {
                        belveic veic = new belveic();

                        veic.RENAVAM = obj.infCTeNorm.rodo.veic[v].RENAVAM;
                        veic.placa = obj.infCTeNorm.rodo.veic[v].placa;
                        veic.tara = obj.infCTeNorm.rodo.veic[v].tara;
                        veic.capKG = obj.infCTeNorm.rodo.veic[v].capKG;
                        veic.capM3 = obj.infCTeNorm.rodo.veic[v].capM3;
                        veic.tpProp = obj.infCTeNorm.rodo.veic[v].tpProp;
                        veic.tpVeic = obj.infCTeNorm.rodo.veic[v].tpVeic;
                        veic.tpRod = obj.infCTeNorm.rodo.veic[v].tpRod;
                        veic.tpCar = obj.infCTeNorm.rodo.veic[v].tpCar;
                        veic.UF = obj.infCTeNorm.rodo.veic[v].UF;

                        if (obj.infCTeNorm.rodo.veic[v].prop != null)
                        {
                            veic.prop = new belprop();

                            veic.prop.CPFCNPJ = obj.infCTeNorm.rodo.veic[v].prop.CPFCNPJ;
                            veic.prop.RNTRC = obj.infCTeNorm.rodo.veic[v].prop.RNTRC;
                            veic.prop.xNome = obj.infCTeNorm.rodo.veic[v].prop.xNome;
                            veic.prop.IE = obj.infCTeNorm.rodo.veic[v].prop.IE;
                            veic.prop.UF = obj.infCTeNorm.rodo.veic[v].prop.UF;
                            veic.prop.tpProp = obj.infCTeNorm.rodo.veic[v].prop.tpProp;
                        }

                        objbelinfCte.infCTeNorm.rodo.veic.Add(veic);
                    }
                    if (obj.infCTeNorm.rodo.moto != null)
                    {
                        objbelinfCte.infCTeNorm.rodo.moto = new belmoto();
                        objbelinfCte.infCTeNorm.rodo.moto.xNome = obj.infCTeNorm.rodo.moto.xNome;
                        objbelinfCte.infCTeNorm.rodo.moto.CPF = obj.infCTeNorm.rodo.moto.CPF;
                    }
                    #endregion

                    objList.Add(objbelinfCte);

                }
                this.objObjetosAlter = new belPopulaObjetos(objObjetos.objListaNumeroConhecimentos);
                this.objObjetosAlter.objListaConhecimentos = objList;
                this.objObjetosAlter.sFormEmiss = objObjetos.sFormEmiss;
                this.objObjetosAlter.sNomeArq = objObjetos.sNomeArq;
                this.objObjetosAlter.sPath = objObjetos.sPath;

                bsNotas.DataSource = this.objObjetosAlter.objListaConhecimentos;
                bsNotas.MoveFirst();
                lblContagemNotas.Text = "1 de " + bsNotas.Count;

            }
            catch (Exception ex)
            {
                new HLPexception(ex);
            }
        }
        private void PopulaForm()
        {
            try
            {
                belinfCte objInfCte = (belinfCte)bsNotas.Current;

                #region Identificacao

                txtcUF.Text = objInfCte.ide.cUF;
                txtcCT.Text = objInfCte.ide.cCT;
                txtCFOP.Text = objInfCte.ide.CFOP;
                txtnatOp.Text = objInfCte.ide.natOp;
                cboforPag.SelectedIndex = objInfCte.ide.forPag;
                txtmod.Text = objInfCte.ide.mod;
                txtserie.Text = objInfCte.ide.serie;
                txtnCT.Text = objInfCte.ide.nCT;
                if (objInfCte.ide.tpEmis != "")
                {
                    switch (objInfCte.ide.tpEmis)
                    {
                        case "1": cbotpEmis.SelectedIndex = 0;
                            break;

                        case "5": cbotpEmis.SelectedIndex = 1;
                            break;
                    }
                }
                else { cbotpEmis.SelectedIndex = -1; }
                txtcDV.Text = objInfCte.ide.cDV;
                cbotpCTe.SelectedIndex = objInfCte.ide.tpCTe;
                txtverProc.Text = objInfCte.ide.verProc;
                txtcMunEmi.Text = objInfCte.ide.cMunEnv;
                txtxMunEmi.Text = objInfCte.ide.xMunEnv;
                txtUFEmi.Text = objInfCte.ide.UFEnv;
                cbomodal.SelectedIndex = objInfCte.ide.modal != "" ? Convert.ToInt32(objInfCte.ide.modal) - 1 : -1;
                cbotpServ.SelectedIndex = objInfCte.ide.tpServ;
                txtcMunIni.Text = objInfCte.ide.cMunIni;
                txtxMunIni.Text = objInfCte.ide.xMunIni;
                txtUFIni.Text = objInfCte.ide.UFIni;
                txtcMunFim.Text = objInfCte.ide.cMunFim;
                txtxMunFim.Text = objInfCte.ide.xMunFim;
                txtUFFim.Text = objInfCte.ide.UFFim;
                cboretira.SelectedIndex = objInfCte.ide.retira;


                #endregion

                #region Tomador
                if (objInfCte.ide.toma03 != null)
                {
                    cbotoma.SelectedIndex = Convert.ToInt32(objInfCte.ide.toma03.toma);
                }
                if (objInfCte.ide.toma04 != null)
                {
                    cbotoma.SelectedIndex = Convert.ToInt32(objInfCte.ide.toma04.toma);
                    if (objInfCte.ide.toma04.CNPJ != "")
                    {

                        mskCNPJtoma.Mask = "00,000,000/0000-00";
                        mskCNPJtoma.Text = objInfCte.ide.toma04.CNPJ.ToString();
                        mskCNPJtoma._Regex = Expressoes.ER4;
                    }
                    else if (objInfCte.ide.toma04.CPF != "")
                    {
                        mskCNPJtoma.Mask = "000,000,000-00";
                        mskCNPJtoma.Text = objInfCte.ide.toma04.CPF.ToString();
                        mskCNPJtoma._Regex = Expressoes.ER7;
                    }

                    txtIEToma.Text = objInfCte.ide.toma04.IE;
                    txtxNomeToma.Text = objInfCte.ide.toma04.xNome;
                    txtxFantToma.Text = objInfCte.ide.toma04.xFant;
                    txtfoneToma.Text = objInfCte.ide.toma04.fone.ToString();

                    txtxLgrToma.Text = objInfCte.ide.toma04.enderToma.xLgr;
                    txtnroToma.Text = objInfCte.ide.toma04.enderToma.nro;
                    txtxCplToma.Text = objInfCte.ide.toma04.enderToma.xCpl;
                    txtxBairroToma.Text = objInfCte.ide.toma04.enderToma.xBairro;
                    txtcMunToma.Text = objInfCte.ide.toma04.enderToma.cMun.ToString();
                    txtxMunToma.Text = objInfCte.ide.toma04.enderToma.xMun;
                    mskCEPToma.Text = objInfCte.ide.toma04.enderToma.CEP.ToString();
                    txtUFToma.Text = objInfCte.ide.toma04.enderToma.UF;
                    txtcPaisToma.Text = objInfCte.ide.toma04.enderToma.cPais.ToString();
                    txtxPaisToma.Text = objInfCte.ide.toma04.enderToma.xPais;

                }
                HabilitaCamposToma();
                #endregion

                #region Emitente


                mskCNPJEmit.Text = objInfCte.emit.CNPJ;
                txtIEEmit.Text = objInfCte.emit.IE;
                txtxNomeEmit.Text = objInfCte.emit.xNome;
                txtxFantEmit.Text = objInfCte.emit.xFant;

                txtxLgrEmit.Text = objInfCte.emit.enderEmit.xLgr;
                txtnroEmit.Text = objInfCte.emit.enderEmit.nro;
                txtxCplEmit.Text = objInfCte.emit.enderEmit.xCpl;
                txtxBairroEmit.Text = objInfCte.emit.enderEmit.xBairro;
                txtcMunEmit.Text = objInfCte.emit.enderEmit.cMun.ToString();
                txtxMunEmit.Text = objInfCte.emit.enderEmit.xMun;
                mskCEPEmit.Text = objInfCte.emit.enderEmit.CEP;
                txtUFEmit.Text = objInfCte.emit.enderEmit.UF;
                txtfoneEmit.Text = objInfCte.emit.enderEmit.fone.ToString();

                #endregion

                #region Remetente

                if (objInfCte.rem.CNPJ != "")
                {
                    mskCNPJrem.Mask = "00,000,000/0000-00";
                    mskCNPJrem._Regex = Expressoes.ER4;
                    mskCNPJrem.Text = objInfCte.rem.CNPJ;
                }
                else if (objInfCte.rem.CPF != "")
                {
                    mskCNPJtoma.Mask = "000,000,000-00";
                    mskCNPJtoma._Regex = Expressoes.ER7;
                    mskCNPJrem.Text = objInfCte.rem.CPF;
                }

                txtIErem.Text = objInfCte.rem.IE;
                txtxNomerem.Text = objInfCte.rem.xNome;
                txtxFantrem.Text = objInfCte.rem.xFant;
                txtfonerem.Text = objInfCte.rem.fone;


                txtxLgrrem.Text = objInfCte.rem.enderReme.xLgr;
                txtnrorem.Text = objInfCte.rem.enderReme.nro;
                txtxCplrem.Text = objInfCte.rem.enderReme.xCpl;
                txtxBairrorem.Text = objInfCte.rem.enderReme.xBairro;
                txtcMunrem.Text = objInfCte.rem.enderReme.cMun;
                txtxMunrem.Text = objInfCte.rem.enderReme.xMun;
                mskCEPrem.Text = objInfCte.rem.enderReme.CEP;
                txtUFrem.Text = objInfCte.rem.enderReme.UF;
                xPaisrem.Text = objInfCte.rem.enderReme.xPais;
                txtcPaisrem.Text = objInfCte.rem.enderReme.cPais;

                #endregion

                #region Destinatario

                if (objInfCte.dest.CNPJ != "")
                {
                    mskCNPJdest.Mask = "00,000,000/0000-00";
                    mskCNPJdest._Regex = Expressoes.ER4;
                    mskCNPJdest.Text = objInfCte.dest.CNPJ;
                }
                else if (objInfCte.dest.CPF != "")
                {
                    mskCNPJdest.Mask = "000,000,000-00";
                    mskCNPJdest._Regex = Expressoes.ER7;
                    mskCNPJdest.Text = objInfCte.dest.CPF;
                }

                txtIEdest.Text = objInfCte.dest.IE;
                txtxNomedest.Text = objInfCte.dest.xNome;
                txtfonedest.Text = objInfCte.dest.fone;
                txtISUFdest.Text = objInfCte.dest.ISUF;



                txtxLgrdest.Text = objInfCte.dest.enderDest.xLgr;
                txtnrodest.Text = objInfCte.dest.enderDest.nro;
                txtxCpldest.Text = objInfCte.dest.enderDest.xCpl;
                txtxBairrodest.Text = objInfCte.dest.enderDest.xBairro;
                txtcMundest.Text = objInfCte.dest.enderDest.cMun;
                txtxMundest.Text = objInfCte.dest.enderDest.xMun;
                mskCEPdest.Text = objInfCte.dest.enderDest.CEP;
                txtUFdest.Text = objInfCte.dest.enderDest.UF;
                txtxPaisdest.Text = objInfCte.dest.enderDest.xPais;
                txtcPaisdest.Text = objInfCte.dest.enderDest.cPais;

                #endregion

                #region Expedidor
                if (objInfCte.exped != null)
                {

                    if (objInfCte.exped.CNPJ != "")
                    {
                        mskCNPJexped.Mask = "00,000,000/0000-00";
                        mskCNPJexped._Regex = Expressoes.ER4;
                        mskCNPJexped.Text = objInfCte.exped.CNPJ;
                    }
                    else if (objInfCte.exped.CPF != "")
                    {
                        mskCNPJexped.Mask = "000,000,000-00";
                        mskCNPJexped._Regex = Expressoes.ER7;
                        mskCNPJexped.Text = objInfCte.exped.CPF;
                    }

                    txtIEexped.Text = objInfCte.exped.IE;
                    txtxNomeexped.Text = objInfCte.exped.xNome;
                    txtfoneexped.Text = objInfCte.exped.fone;


                    txtxLgrexped.Text = objInfCte.exped.enderExped.xLgr;
                    txtnroexped.Text = objInfCte.exped.enderExped.nro;
                    txtxBairroexped.Text = objInfCte.exped.enderExped.xBairro;
                    txtxCplexped.Text = objInfCte.exped.enderExped.xCpl;
                    txtcMunexped.Text = objInfCte.exped.enderExped.cMun;
                    txtxMunexped.Text = objInfCte.exped.enderExped.xMun;
                    mskCEPexped.Text = objInfCte.exped.enderExped.CEP;
                    txtUFexped.Text = objInfCte.exped.enderExped.UF;
                    txtxPaisexped.Text = objInfCte.exped.enderExped.xPais;
                    txtcPaisexped.Text = objInfCte.exped.enderExped.cPais;


                }


                #endregion

                #region Recebedor
                if (objInfCte.receb != null)
                {

                    if (objInfCte.receb.CNPJ != "")
                    {
                        mskCpfCnpfreceb.Mask = "00,000,000/0000-00";
                        mskCpfCnpfreceb._Regex = Expressoes.ER4;
                        mskCpfCnpfreceb.Text = objInfCte.receb.CNPJ;
                    }
                    else if (objInfCte.exped.CPF != "")
                    {
                        mskCpfCnpfreceb.Mask = "000,000,000-00";
                        mskCpfCnpfreceb._Regex = Expressoes.ER7;
                        mskCpfCnpfreceb.Text = objInfCte.receb.CPF;
                    }

                    txtIEreceb.Text = objInfCte.receb.IE;
                    txtxNomereceb.Text = objInfCte.receb.xNome;
                    txtfonereceb.Text = objInfCte.receb.fone;


                    txtxLgrreceb.Text = objInfCte.receb.enderReceb.xLgr;
                    txtnroreceb.Text = objInfCte.receb.enderReceb.nro;
                    txtxCplreceb.Text = objInfCte.receb.enderReceb.xCpl;
                    txtxBairroreceb.Text = objInfCte.receb.enderReceb.xBairro;
                    txtcMunreceb.Text = objInfCte.receb.enderReceb.cMun;
                    txtxMunreceb.Text = objInfCte.receb.enderReceb.xMun;
                    mskCEPreceb.Text = objInfCte.receb.enderReceb.CEP;
                    txtUFreceb.Text = objInfCte.receb.enderReceb.UF;
                    txtxPaisreceb.Text = objInfCte.receb.enderReceb.xPais;
                    txtcPaisreceb.Text = objInfCte.receb.enderReceb.cPais;


                }


                #endregion

                #region Informacoes da NF

                this.bsInfNF.DataSource = objInfCte.infCTeNorm.infDoc.infNF;

                //gridNfNormal.Rows.Clear();
                //for (int j = 0; j < objInfCte.infCTeNorm.infDoc.infNF.Count; j++)
                //{
                //    gridNfNormal.Rows.Add();

                //    switch (objInfCte.infCTeNorm.infDoc.infNF[j].mod)
                //    {
                //        case "01": gridNfNormal.Rows[j].Cells["mod"].Value = mod.Items[0];
                //            break;
                //        case "04": gridNfNormal.Rows[j].Cells["mod"].Value = mod.Items[1];
                //            break;
                //    }
                //    gridNfNormal.Rows[j].Cells["nDoc"].Value = objInfCte.infCTeNorm.infDoc.infNF[j].nDoc;
                //    gridNfNormal.Rows[j].Cells["serie"].Value = objInfCte.infCTeNorm.infDoc.infNF[j].serie;
                //    gridNfNormal.Rows[j].Cells["dEmi"].Value = Convert.ToDateTime(objInfCte.infCTeNorm.infDoc.infNF[j].dEmi);
                //    gridNfNormal.Rows[j].Cells["vBC"].Value = Convert.ToDecimal(objInfCte.infCTeNorm.infDoc.infNF[j].vBC.Replace(".", ","));
                //    gridNfNormal.Rows[j].Cells["vICMS"].Value = Convert.ToDecimal(objInfCte.infCTeNorm.infDoc.infNF[j].vICMS.Replace(".", ","));
                //    gridNfNormal.Rows[j].Cells["vBCST"].Value = Convert.ToDecimal(objInfCte.infCTeNorm.infDoc.infNF[j].vBCST.Replace(".", ","));
                //    gridNfNormal.Rows[j].Cells["vST"].Value = Convert.ToDecimal(objInfCte.infCTeNorm.infDoc.infNF[j].vST.Replace(".", ","));
                //    gridNfNormal.Rows[j].Cells["vProd"].Value = Convert.ToDecimal(objInfCte.infCTeNorm.infDoc.infNF[j].vProd.Replace(".", ","));
                //    gridNfNormal.Rows[j].Cells["vNF"].Value = Convert.ToDecimal(objInfCte.infCTeNorm.infDoc.infNF[j].vNF.Replace(".", ","));
                //    gridNfNormal.Rows[j].Cells["nCFOP"].Value = Convert.ToInt32(objInfCte.infCTeNorm.infDoc.infNF[j].nCFOP.Replace(".", ","));

                //}
                this.bsInfNFe.DataSource = objInfCte.infCTeNorm.infDoc.infNFe;

                //gridNfe.Rows.Clear();
                //for (int n = 0; n < objInfCte.infCTeNorm.infDoc.infNFe.Count; n++)
                //{
                //    gridNfe.Rows.Add();
                //    gridNfe.Rows[n].Cells[0].Value = objInfCte.infCTeNorm.infDoc.infNFe[n].chave;
                //}


                #endregion

                #region Outros Documentos
                gridDocumentos.Rows.Clear();
                for (int j = 0; j < objInfCte.infCTeNorm.infDoc.infOutros.Count; j++)
                {
                    gridDocumentos.Rows.Add();
                    switch (objInfCte.infCTeNorm.infDoc.infOutros[j].tpDoc)
                    {
                        case "00":
                            gridDocumentos.Rows[j].Cells["tpDoc"].Value = tpDoc.Items[0];
                            break;
                        case "10":
                            gridDocumentos.Rows[j].Cells["tpDoc"].Value = tpDoc.Items[1];
                            break;
                        case "99":
                            gridDocumentos.Rows[j].Cells["tpDoc"].Value = tpDoc.Items[2];
                            break;
                    }
                    gridDocumentos.Rows[j].Cells["descOutros"].Value = objInfCte.infCTeNorm.infDoc.infOutros[j].descOutros;
                    gridDocumentos.Rows[j].Cells["nDoc_"].Value = objInfCte.infCTeNorm.infDoc.infOutros[j].nDoc;
                    gridDocumentos.Rows[j].Cells["dEmi_"].Value = Convert.ToDateTime(objInfCte.infCTeNorm.infDoc.infOutros[j].dEmi);
                    gridDocumentos.Rows[j].Cells["vDocFisc"].Value = Convert.ToDecimal(objInfCte.infCTeNorm.infDoc.infOutros[j].vDocFisc.Replace(".", ","));

                }


                #endregion

                #region Valores

                nudvTPrest.Value = Convert.ToDecimal(objInfCte.vPrest.vTPrest.Replace(".", ","));
                nudvRec.Value = Convert.ToDecimal(objInfCte.vPrest.vRec.Replace(".", ","));

                if (objInfCte.vPrest.Comp != null)
                {
                    for (int i = 0; i < objInfCte.vPrest.Comp.Count; i++)
                    {
                        switch (objInfCte.vPrest.Comp[i].xNome)
                        {
                            case "FRETE VALOR":
                                nudvFrete.Value = Convert.ToDecimal(objInfCte.vPrest.Comp[i].vComp.Replace(".", ","));
                                break;

                            case "FRETE CUBAGEM":
                                nudFreteCubagem.Value = Convert.ToDecimal(objInfCte.vPrest.Comp[i].vComp.Replace(".", ","));
                                break;

                            case "FRETE PESO":
                                nudFretePeso.Value = Convert.ToDecimal(objInfCte.vPrest.Comp[i].vComp.Replace(".", ","));
                                break;

                            case "CAT":
                                nudCat.Value = Convert.ToDecimal(objInfCte.vPrest.Comp[i].vComp.Replace(".", ","));
                                break;

                            case "DESPACHO":
                                nudDespacho.Value = Convert.ToDecimal(objInfCte.vPrest.Comp[i].vComp.Replace(".", ","));
                                break;

                            case "PEDAGIO":
                                nudPedagio.Value = Convert.ToDecimal(objInfCte.vPrest.Comp[i].vComp.Replace(".", ","));
                                break;

                            case "OUTROS":
                                nudOutros.Value = Convert.ToDecimal(objInfCte.vPrest.Comp[i].vComp.Replace(".", ","));
                                break;

                            case "ADME":
                                nudAdme.Value = Convert.ToDecimal(objInfCte.vPrest.Comp[i].vComp.Replace(".", ","));
                                break;

                            case "ENTREGA":
                                nudEntrega.Value = Convert.ToDecimal(objInfCte.vPrest.Comp[i].vComp.Replace(".", ","));
                                break;


                            case "GRIS":
                                nudGris.Value = Convert.ToDecimal(objInfCte.vPrest.Comp[i].vComp.Replace(".", ","));
                                break;
                            case "VALOR ADICIONAL":
                                nudValoraAdic.Value = Convert.ToDecimal(objInfCte.vPrest.Comp[i].vComp.Replace(".", ","));
                                break;

                        }
                    }
                }


                if (objInfCte.imp.ICMS.ICMS00 != null)
                {
                    cboCST.SelectedIndex = 0;
                    nudvBC.Value = Convert.ToDecimal(objInfCte.imp.ICMS.ICMS00.vBC.Replace(".", ","));
                    nudpICMS.Value = Convert.ToDecimal(objInfCte.imp.ICMS.ICMS00.pICMS.Replace(".", ","));
                    nudvICMS.Value = Convert.ToDecimal(objInfCte.imp.ICMS.ICMS00.vICMS.Replace(".", ","));

                    HabilitaCamposValores(0);
                }
                else if (objInfCte.imp.ICMS.ICMS20 != null)
                {
                    cboCST.SelectedIndex = 1;
                    nudpRedBC.Value = Convert.ToDecimal(objInfCte.imp.ICMS.ICMS20.pRedBC.Replace(".", ","));
                    nudvBC.Value = Convert.ToDecimal(objInfCte.imp.ICMS.ICMS20.vBC.Replace(".", ","));
                    nudpICMS.Value = Convert.ToDecimal(objInfCte.imp.ICMS.ICMS20.pICMS.Replace(".", ","));
                    nudvICMS.Value = Convert.ToDecimal(objInfCte.imp.ICMS.ICMS20.vICMS.Replace(".", ","));


                    HabilitaCamposValores(1);
                }
                else if (objInfCte.imp.ICMS.ICMS45 != null)
                {
                    switch (objInfCte.imp.ICMS.ICMS45.CST)
                    {
                        case "40": cboCST.SelectedIndex = 2;
                            HabilitaCamposValores(2);
                            break;

                        case "41": cboCST.SelectedIndex = 3;
                            HabilitaCamposValores(3);
                            break;

                        case "51": cboCST.SelectedIndex = 4;
                            HabilitaCamposValores(4);
                            break;
                    }



                }
                else if (objInfCte.imp.ICMS.ICMS60 != null)
                {
                    cboCST.SelectedIndex = 5;
                    nudvBC.Value = Convert.ToDecimal(objInfCte.imp.ICMS.ICMS60.vBCSTRet.Replace(".", ","));
                    nudvICMS.Value = Convert.ToDecimal(objInfCte.imp.ICMS.ICMS60.vICMSSTRet.Replace(".", ","));
                    nudpICMS.Value = Convert.ToDecimal(objInfCte.imp.ICMS.ICMS60.pICMSSTRet.Replace(".", ","));

                    HabilitaCamposValores(5);
                }
                else if (objInfCte.imp.ICMS.ICMS90 != null)
                {
                    cboCST.SelectedIndex = 6;
                    nudpRedBC.Value = Convert.ToDecimal(objInfCte.imp.ICMS.ICMS90.pRedBC.Replace(".", ","));
                    nudvBC.Value = Convert.ToDecimal(objInfCte.imp.ICMS.ICMS90.vBC.Replace(".", ","));
                    nudpICMS.Value = Convert.ToDecimal(objInfCte.imp.ICMS.ICMS90.pICMS.Replace(".", ","));
                    nudvICMS.Value = Convert.ToDecimal(objInfCte.imp.ICMS.ICMS90.vICMS.Replace(".", ","));

                    HabilitaCamposValores(6);
                }
                else if (objInfCte.imp.ICMS.ICMSOutraUF != null)
                {
                    cboCST.SelectedIndex = 7;
                    nudpRedBC.Value = Convert.ToDecimal(objInfCte.imp.ICMS.ICMSOutraUF.pRedBCOutraUF.Replace(".", ","));
                    nudvBC.Value = Convert.ToDecimal(objInfCte.imp.ICMS.ICMSOutraUF.vBCOutraUF.Replace(".", ","));
                    nudpICMS.Value = Convert.ToDecimal(objInfCte.imp.ICMS.ICMSOutraUF.pICMSOutraUF.Replace(".", ","));
                    nudvICMS.Value = Convert.ToDecimal(objInfCte.imp.ICMS.ICMSOutraUF.vICMSOutraUF.Replace(".", ","));

                    HabilitaCamposValores(7);
                }

                #endregion

                #region InformacoesCarga

                nudvMerc.Value = objInfCte.infCTeNorm.infCarga.vCarga;
                txtproPred.Text = objInfCte.infCTeNorm.infCarga.proPred;
                txtxOutCat.Text = objInfCte.infCTeNorm.infCarga.xOutCat;

                bsInfQ.DataSource = objInfCte.infCTeNorm.infCarga.infQ;

                //gridinfQ.Rows.Clear();
                //for (int j = 0; j < objInfCte.infCTeNorm.infCarga.infQ.Count; j++)
                //{
                //    gridinfQ.Rows.Add();
                //    switch (objInfCte.infCTeNorm.infCarga.infQ[j].cUnid)
                //    {
                //        case "00": gridinfQ.Rows[j].Cells[0].Value = cUnid.Items[0];
                //            break;
                //        case "01": gridinfQ.Rows[j].Cells[0].Value = cUnid.Items[1];
                //            break;
                //        case "02": gridinfQ.Rows[j].Cells[0].Value = cUnid.Items[2];
                //            break;
                //        case "03": gridinfQ.Rows[j].Cells[0].Value = cUnid.Items[3];
                //            break;
                //        case "04": gridinfQ.Rows[j].Cells[0].Value = cUnid.Items[4];
                //            break;
                //    }
                //    gridinfQ.Rows[j].Cells[1].Value = objInfCte.infCTeNorm.infCarga.infQ[j].tpMed;
                //    gridinfQ.Rows[j].Cells[2].Value = objInfCte.infCTeNorm.infCarga.infQ[j].qCarga;
                //}

                #endregion

                #region Rodoviario

                cborespSeg.SelectedIndex = objInfCte.infCTeNorm.seg.respSeg != "" ? Convert.ToInt32(objInfCte.infCTeNorm.seg.respSeg) : -1;
                txtnApol.Text = objInfCte.infCTeNorm.seg.nApol;
                txtRNTRC.Text = objInfCte.infCTeNorm.rodo.RNTRC;
                mskdPrev.Text = objInfCte.infCTeNorm.rodo.dPrev != "" ? Convert.ToDateTime(objInfCte.infCTeNorm.rodo.dPrev).ToString("dd-MM-yyyy") : "";
                if (objInfCte.infCTeNorm.rodo.lota != "")
                {
                    cbolota.SelectedIndex = objInfCte.infCTeNorm.rodo.lota != "" ? Convert.ToInt32(objInfCte.infCTeNorm.rodo.lota) : -1;
                }
                #endregion

                #region Veiculo

                lblTotalVeiculo.Text = "0 de " + objInfCte.infCTeNorm.rodo.veic.Count().ToString();
                bsVeiculos.DataSource = objInfCte.infCTeNorm.rodo.veic;
                if (objInfCte.infCTeNorm.rodo.veic.Count() > 0)
                {
                    lblTotalVeiculo.Text = "1 de " + objInfCte.infCTeNorm.rodo.veic.Count().ToString();
                    txtRENAVAM.Text = objInfCte.infCTeNorm.rodo.veic[0].RENAVAM;
                    txtplaca.Text = objInfCte.infCTeNorm.rodo.veic[0].placa;
                    nudtara.Value = Convert.ToInt32(objInfCte.infCTeNorm.rodo.veic[0].tara);
                    nudcapKG.Value = Convert.ToInt32(objInfCte.infCTeNorm.rodo.veic[0].capKG);
                    nudcapM3.Value = Convert.ToInt32(objInfCte.infCTeNorm.rodo.veic[0].capM3);
                    switch (objInfCte.infCTeNorm.rodo.veic[0].tpProp)
                    {
                        case "P":
                            cbotpProp.SelectedIndex = 0;
                            break;
                        case "T":
                            cbotpProp.SelectedIndex = 1;
                            break;
                        default:
                            cbotpProp.SelectedIndex = -1;
                            break;
                    }
                    cbotpVeic.SelectedIndex = objInfCte.infCTeNorm.rodo.veic[0].tpVeic != "" ? Convert.ToInt32(objInfCte.infCTeNorm.rodo.veic[0].tpVeic) : -1;
                    cbotpRod.SelectedIndex = objInfCte.infCTeNorm.rodo.veic[0].tpRod != "" ? Convert.ToInt32(objInfCte.infCTeNorm.rodo.veic[0].tpRod) : -1;
                    cbotpCar.SelectedIndex = objInfCte.infCTeNorm.rodo.veic[0].tpCar != "" ? Convert.ToInt32(objInfCte.infCTeNorm.rodo.veic[0].tpCar) : -1;
                    txtUF.Text = objInfCte.infCTeNorm.rodo.veic[0].UF;

                    if (objInfCte.infCTeNorm.rodo.veic[0].prop != null)
                    {
                        txtCPFprop.Text = objInfCte.infCTeNorm.rodo.veic[0].prop.CPFCNPJ;
                        txtRNTRCprop.Text = objInfCte.infCTeNorm.rodo.veic[0].prop.RNTRC;
                        txtxNomeprop.Text = objInfCte.infCTeNorm.rodo.veic[0].prop.xNome;
                        txtIEprop.Text = objInfCte.infCTeNorm.rodo.veic[0].prop.IE;
                        txtUFprop.Text = objInfCte.infCTeNorm.rodo.veic[0].prop.UF;
                        cbotpPropprop.SelectedIndex = Convert.ToInt32(objInfCte.infCTeNorm.rodo.veic[0].prop.tpProp);
                    }

                }
                if (objInfCte.infCTeNorm.rodo.moto != null)
                {
                    txtxNomemoto.Text = objInfCte.infCTeNorm.rodo.moto.xNome;
                    txtCPFmoto.Text = objInfCte.infCTeNorm.rodo.moto.CPF;
                }
                #endregion

                #region Obs
                if (objInfCte.compl != null)
                    txtxTexto.Text = objInfCte.compl.ObsCont.xTexto;


                #endregion

                lblNumCte.Text = "Número CT-e: " + objInfCte.ide.nCT;


            }
            catch (Exception ex)
            {
                new HLPexception(ex);
            }
        }
        private void SalvarAlteracao()
        {
            try
            {
                belinfCte objInfCte = (belinfCte)bsNotas.Current;

                #region Identificacao
                objInfCte.ide.cUF = txtcUF.Text;
                objInfCte.ide.cCT = txtcCT.Text;
                objInfCte.ide.CFOP = txtCFOP.Text;
                objInfCte.ide.natOp = txtnatOp.Text;
                objInfCte.ide.forPag = cboforPag.SelectedIndex;
                objInfCte.ide.mod = txtmod.Text;
                objInfCte.ide.serie = txtserie.Text;
                objInfCte.ide.nCT = txtnCT.Text;
                switch (cbotpEmis.SelectedIndex)
                {
                    case 0: objInfCte.ide.tpEmis = "1";
                        break;
                    case 1: objInfCte.ide.tpEmis = "5";
                        break;


                    default: objInfCte.ide.tpEmis = "";
                        break;
                }

                objInfCte.ide.cDV = txtcDV.Text;
                objInfCte.ide.tpCTe = cbotpCTe.SelectedIndex;
                objInfCte.ide.verProc = txtverProc.Text;
                objInfCte.ide.cMunEnv = txtcMunEmi.Text;
                objInfCte.ide.xMunEnv = txtxMunEmi.Text;
                objInfCte.ide.UFEnv = txtUFEmi.Text;
                objInfCte.ide.modal = "0" + (cbomodal.SelectedIndex + 1).ToString();
                objInfCte.ide.tpServ = cbotpServ.SelectedIndex;
                objInfCte.ide.cMunIni = txtcMunIni.Text;
                objInfCte.ide.xMunIni = txtxMunIni.Text;
                objInfCte.ide.UFIni = txtUFIni.Text;
                objInfCte.ide.cMunFim = txtcMunFim.Text;
                objInfCte.ide.xMunFim = txtxMunFim.Text;
                objInfCte.ide.UFFim = txtUFFim.Text;
                objInfCte.ide.retira = cboretira.SelectedIndex;


                #endregion

                #region Tomador
                objInfCte.ide.toma03 = null;

                objInfCte.ide.toma04 = null;

                if (cbotoma.SelectedIndex != -1)
                {
                    if (cbotoma.SelectedIndex != 4)
                    {
                        objInfCte.ide.toma03 = new beltoma03();
                        objInfCte.ide.toma03.toma = cbotoma.SelectedIndex.ToString();
                    }
                    else
                    {
                        objInfCte.ide.toma04 = new beltoma04();
                        objInfCte.ide.toma04.enderToma = new belenderToma();
                        objInfCte.ide.toma04.toma = cbotoma.SelectedIndex.ToString();

                        string sCnpj = mskCNPJtoma.Text;
                        if (sCnpj != "")
                        {
                            if (mskCNPJtoma.Text.Length == 14)
                            {
                                objInfCte.ide.toma04.CNPJ = sCnpj;
                            }
                            else if (mskCNPJtoma.Text.Length == 11)
                            {
                                objInfCte.ide.toma04.CPF = sCnpj;
                            }
                        }
                        objInfCte.ide.toma04.IE = txtIEToma.Text;
                        objInfCte.ide.toma04.xNome = txtxNomeToma.Text;
                        objInfCte.ide.toma04.xFant = txtxFantToma.Text;
                        if (txtfoneToma.Text != "")
                        {
                            objInfCte.ide.toma04.fone = txtfoneToma.Text;
                        }
                        objInfCte.ide.toma04.enderToma.xLgr = txtxLgrToma.Text;
                        objInfCte.ide.toma04.enderToma.nro = txtnroToma.Text;
                        objInfCte.ide.toma04.enderToma.xCpl = txtxCplToma.Text;
                        objInfCte.ide.toma04.enderToma.xBairro = txtxBairroToma.Text;
                        if (txtcMunToma.Text != "")
                        {
                            objInfCte.ide.toma04.enderToma.cMun = txtcMunToma.Text;
                        }
                        objInfCte.ide.toma04.enderToma.xMun = txtxMunToma.Text;

                        string sCep = mskCEPToma.Text.Replace(" ", "").Replace("-", "");
                        objInfCte.ide.toma04.enderToma.CEP = sCep;

                        objInfCte.ide.toma04.enderToma.UF = txtUFToma.Text;
                        if (txtcPaisToma.Text != "")
                        {
                            objInfCte.ide.toma04.enderToma.cPais = txtcPaisToma.Text;
                        }
                        objInfCte.ide.toma04.enderToma.xPais = txtxPaisToma.Text;

                    }
                }
                #endregion

                #region Emitente

                objInfCte.emit.CNPJ = mskCNPJEmit.Text.Replace(" ", "").Replace("-", "").Replace("/", "").Replace(".", ""); ;
                objInfCte.emit.IE = txtIEEmit.Text;
                objInfCte.emit.xNome = txtxNomeEmit.Text;
                objInfCte.emit.xFant = txtxFantEmit.Text;

                objInfCte.emit.enderEmit.xLgr = txtxLgrEmit.Text;
                objInfCte.emit.enderEmit.nro = txtnroEmit.Text;
                objInfCte.emit.enderEmit.xCpl = txtxCplEmit.Text;
                objInfCte.emit.enderEmit.xBairro = txtxBairroEmit.Text;
                if (txtcMunEmit.Text != "")
                {
                    objInfCte.emit.enderEmit.cMun = txtcMunEmit.Text;
                }
                objInfCte.emit.enderEmit.xMun = txtxMunEmit.Text;

                string sCepemit = mskCEPEmit.Text.Replace(" ", "").Replace("-", "");
                if (sCepemit != "")
                {
                    objInfCte.emit.enderEmit.CEP = sCepemit;
                }
                objInfCte.emit.enderEmit.UF = txtUFEmit.Text;
                if (txtfoneEmit.Text != "")
                {
                    objInfCte.emit.enderEmit.fone = txtfoneEmit.Text;
                }

                #endregion

                #region Remetente
                objInfCte.rem = new belrem();
                objInfCte.rem.enderReme = new belenderReme();

                if (objInfCte.rem.CNPJ != "")
                {
                    if (mskCNPJrem.Text.Length == 14)
                    {
                        objInfCte.rem.CNPJ = mskCNPJrem.Text;
                    }
                }
                else if (objInfCte.rem.CPF != "")
                {
                    if (mskCNPJrem.Text.Length == 11)
                    {
                        objInfCte.rem.CPF = mskCNPJrem.Text;
                    }
                }
                else
                {
                    if (mskCNPJrem.Text.Length == 14)
                    {
                        objInfCte.rem.CNPJ = mskCNPJrem.Text;
                    }
                    else if (mskCNPJrem.Text.Length == 11)
                    {
                        objInfCte.rem.CPF = mskCNPJrem.Text;
                    }
                }
                objInfCte.rem.IE = txtIErem.Text;
                objInfCte.rem.xNome = txtxNomerem.Text;
                objInfCte.rem.xFant = txtxFantrem.Text;
                objInfCte.rem.fone = txtfonerem.Text;


                objInfCte.rem.enderReme.xLgr = txtxLgrrem.Text;
                objInfCte.rem.enderReme.nro = txtnrorem.Text;
                objInfCte.rem.enderReme.xCpl = txtxCplrem.Text;
                objInfCte.rem.enderReme.xBairro = txtxBairrorem.Text;
                objInfCte.rem.enderReme.cMun = txtcMunrem.Text;
                objInfCte.rem.enderReme.xMun = txtxMunrem.Text;
                objInfCte.rem.enderReme.CEP = mskCEPrem.Text;
                objInfCte.rem.enderReme.UF = txtUFrem.Text;
                objInfCte.rem.enderReme.xPais = xPaisrem.Text;
                objInfCte.rem.enderReme.cPais = txtcPaisrem.Text;

                #endregion

                #region Destinatario

                objInfCte.dest = new beldest();
                objInfCte.dest.enderDest = new belenderDest();

                if (objInfCte.dest.CNPJ != "")
                {
                    if (mskCNPJdest.Text.Length == 14)
                    {
                        objInfCte.dest.CNPJ = mskCNPJdest.Text;
                    }
                }
                else if (objInfCte.dest.CPF != "")
                {
                    if (mskCNPJdest.Text.Length == 11)
                    {
                        objInfCte.dest.CPF = mskCNPJdest.Text;
                    }
                }
                else
                {
                    if (mskCNPJdest.Text.Length == 14)
                    {
                        objInfCte.dest.CNPJ = mskCNPJdest.Text;
                    }
                    else if (mskCNPJdest.Text.Length == 11)
                    {
                        objInfCte.dest.CPF = mskCNPJdest.Text;
                    }
                }

                objInfCte.dest.IE = txtIEdest.Text;
                objInfCte.dest.xNome = txtxNomedest.Text;
                objInfCte.dest.fone = txtfonedest.Text;
                objInfCte.dest.ISUF = txtISUFdest.Text;


                objInfCte.dest.enderDest.xLgr = txtxLgrdest.Text;
                objInfCte.dest.enderDest.nro = txtnrodest.Text;
                objInfCte.dest.enderDest.xCpl = txtxCpldest.Text;
                objInfCte.dest.enderDest.xBairro = txtxBairrodest.Text;
                objInfCte.dest.enderDest.cMun = txtcMundest.Text;
                objInfCte.dest.enderDest.xMun = txtxMundest.Text;
                objInfCte.dest.enderDest.CEP = mskCEPdest.Text;
                objInfCte.dest.enderDest.UF = txtUFdest.Text;
                objInfCte.dest.enderDest.xPais = txtxPaisdest.Text;
                objInfCte.dest.enderDest.cPais = txtcPaisdest.Text;

                #endregion

                #region Expedidor
                if (objInfCte.exped != null)
                {
                    if (objInfCte.exped.CNPJ != "")
                    {
                        if (mskCNPJexped.Text.Length == 14)
                        {
                            objInfCte.exped.CNPJ = mskCNPJexped.Text;
                        }
                    }
                    else if (objInfCte.exped.CPF != "")
                    {
                        if (mskCNPJexped.Text.Length == 11)
                        {
                            objInfCte.exped.CPF = mskCNPJexped.Text;
                        }
                    }
                    else
                    {
                        if (mskCNPJexped.Text.Length == 14)
                        {
                            objInfCte.exped.CNPJ = mskCNPJexped.Text;
                        }
                        else if (mskCNPJexped.Text.Length == 11)
                        {
                            objInfCte.exped.CPF = mskCNPJexped.Text;
                        }
                    }

                    objInfCte.exped.IE = txtIEexped.Text;
                    objInfCte.exped.xNome = txtxNomeexped.Text;
                    objInfCte.exped.fone = txtfoneexped.Text;


                    objInfCte.exped.enderExped.xLgr = txtxLgrexped.Text;
                    objInfCte.exped.enderExped.nro = txtnroexped.Text;
                    objInfCte.exped.enderExped.xBairro = txtxBairroexped.Text;
                    objInfCte.exped.enderExped.xCpl = txtxCplexped.Text;
                    objInfCte.exped.enderExped.cMun = txtcMunexped.Text;
                    objInfCte.exped.enderExped.xMun = txtxMunexped.Text;
                    objInfCte.exped.enderExped.CEP = mskCEPexped.Text;
                    objInfCte.exped.enderExped.UF = txtUFexped.Text;
                    objInfCte.exped.enderExped.xPais = txtxPaisexped.Text;
                    objInfCte.exped.enderExped.cPais = txtcPaisexped.Text;

                }


                #endregion

                #region Recebedor
                if (objInfCte.receb != null)
                {
                    if (objInfCte.receb.CNPJ != "")
                    {
                        if (mskCpfCnpfreceb.Text.Length == 14)
                        {
                            objInfCte.receb.CNPJ = mskCpfCnpfreceb.Text;
                        }
                    }
                    else if (objInfCte.receb.CPF != "")
                    {
                        if (mskCpfCnpfreceb.Text.Length == 11)
                        {
                            objInfCte.receb.CPF = mskCpfCnpfreceb.Text;
                        }
                    }
                    else
                    {
                        if (mskCpfCnpfreceb.Text.Length == 14)
                        {
                            objInfCte.receb.CNPJ = mskCpfCnpfreceb.Text;
                        }
                        else if (mskCpfCnpfreceb.Text.Length == 11)
                        {
                            objInfCte.receb.CPF = mskCpfCnpfreceb.Text;
                        }
                    }

                    objInfCte.receb.IE = txtIEreceb.Text;
                    objInfCte.receb.xNome = txtxNomereceb.Text;
                    objInfCte.receb.fone = txtfonereceb.Text;

                    objInfCte.receb.enderReceb.xLgr = txtxLgrreceb.Text;
                    objInfCte.receb.enderReceb.nro = txtnroreceb.Text;
                    objInfCte.receb.enderReceb.xBairro = txtxBairroreceb.Text;
                    objInfCte.receb.enderReceb.xCpl = txtxCplreceb.Text;
                    objInfCte.receb.enderReceb.cMun = txtcMunreceb.Text;
                    objInfCte.receb.enderReceb.xMun = txtxMunreceb.Text;
                    objInfCte.receb.enderReceb.CEP = mskCEPreceb.Text;
                    objInfCte.receb.enderReceb.UF = txtUFreceb.Text;
                    objInfCte.receb.enderReceb.xPais = txtxPaisreceb.Text;
                    objInfCte.receb.enderReceb.cPais = txtcPaisreceb.Text;

                }


                #endregion

                #region Informacoes da NF

                //objInfCte.infCTeNorm.infDoc.infNF = new List<belinfNF>();
                //for (int j = 0; j < gridNfNormal.RowCount; j++)
                //{
                //    belinfNF nf = new belinfNF();

                //    switch (gridNfNormal.Rows[j].Cells["mod"].Value.ToString())
                //    {
                //        case "01 - NF Modelo 01/1A e Avulsa": nf.mod = "01";
                //            break;
                //        case "04 - NF de Produtor": nf.mod = "04";
                //            break;
                //    }
                //    nf.nDoc = gridNfNormal.Rows[j].Cells["nDoc"].Value == null ? "" : gridNfNormal.Rows[j].Cells["nDoc"].Value.ToString();
                //    nf.serie = gridNfNormal.Rows[j].Cells["serie"].Value == null ? "" : gridNfNormal.Rows[j].Cells["serie"].Value.ToString();
                //    nf.dEmi = gridNfNormal.Rows[j].Cells["dEmi"].Value == null ? "" : gridNfNormal.Rows[j].Cells["dEmi"].Value.ToString();
                //    nf.vBC = gridNfNormal.Rows[j].Cells["vBC"].Value == null ? "" : gridNfNormal.Rows[j].Cells["vBC"].Value.ToString().Replace(",", ".");
                //    nf.vICMS = gridNfNormal.Rows[j].Cells["vICMS"].Value == null ? "" : gridNfNormal.Rows[j].Cells["vICMS"].Value.ToString().Replace(",", ".");
                //    nf.vBCST = gridNfNormal.Rows[j].Cells["vBCST"].Value == null ? "" : gridNfNormal.Rows[j].Cells["vBCST"].Value.ToString().Replace(",", ".");
                //    nf.vST = gridNfNormal.Rows[j].Cells["vST"].Value == null ? "" : gridNfNormal.Rows[j].Cells["vST"].Value.ToString().Replace(",", ".");
                //    nf.vProd = gridNfNormal.Rows[j].Cells["vProd"].Value == null ? "" : gridNfNormal.Rows[j].Cells["vProd"].Value.ToString().Replace(",", ".");
                //    nf.vNF = gridNfNormal.Rows[j].Cells["vNF"].Value == null ? "" : gridNfNormal.Rows[j].Cells["vNF"].Value.ToString().Replace(",", ".");
                //    nf.nCFOP = gridNfNormal.Rows[j].Cells["nCFOP"].Value == null ? "" : gridNfNormal.Rows[j].Cells["nCFOP"].Value.ToString();
                //    objInfCte.infCTeNorm.infDoc.infNF.Add(nf);
                //}
                objInfCte.infCTeNorm.infDoc.infNF = this.bsInfNF.DataSource as List<belinfNF>; // 2.0

                objInfCte.infCTeNorm.infDoc.infNFe = this.bsInfNFe.DataSource as List<belinfNFe>; //2.0
                //for (int n = 0; n < gridNfe.RowCount; n++)
                //{
                //    belinfNFe nfe = new belinfNFe();
                //    nfe.chave = gridNfe.Rows[n].Cells[0].Value == null ? "" : gridNfe.Rows[n].Cells[0].Value.ToString();

                //    objInfCte.infCTeNorm.infDoc.infNFe.Add(nfe);
                //}



                #endregion

                #region Outros Documentos

                objInfCte.infCTeNorm.infDoc.infOutros = new List<belinfOutros>();
                for (int j = 0; j < gridDocumentos.RowCount; j++)
                {
                    belinfOutros infOutros = new belinfOutros();
                    switch (gridDocumentos.Rows[j].Cells["tpDoc"].Value.ToString())
                    {
                        case "00 - Declaração":
                            infOutros.tpDoc = "00";
                            break;
                        case "10 - Dutoviário":
                            infOutros.tpDoc = "10";
                            break;
                        case "99 - Outros":
                            infOutros.tpDoc = "99";
                            break;
                    }
                    infOutros.descOutros = gridDocumentos.Rows[j].Cells["descOutros"].Value == null ? "" : gridDocumentos.Rows[j].Cells["descOutros"].Value.ToString();
                    infOutros.nDoc = gridDocumentos.Rows[j].Cells["nDoc_"].Value == null ? "" : gridDocumentos.Rows[j].Cells["nDoc_"].Value.ToString();
                    infOutros.dEmi = gridDocumentos.Rows[j].Cells["dEmi_"].Value == null ? "" : gridDocumentos.Rows[j].Cells["dEmi_"].Value.ToString();
                    infOutros.vDocFisc = gridDocumentos.Rows[j].Cells["vDocFisc"].Value == null ? "" : gridDocumentos.Rows[j].Cells["vDocFisc"].Value.ToString().Replace(",", ".");

                    objInfCte.infCTeNorm.infDoc.infOutros.Add(infOutros);
                }

                #endregion

                #region Valores

                objInfCte.vPrest.vTPrest = nudvTPrest.Value.ToString().Replace(",", ".");
                objInfCte.vPrest.vRec = nudvRec.Value.ToString().Replace(",", ".");

                objInfCte.vPrest.Comp = new List<belComp>();
                belComp Comp = new belComp();

                #region Componentes
                if (nudvFrete.Value > 0)
                {
                    Comp.xNome = "FRETE VALOR";
                    Comp.vComp = nudvFrete.Text.Replace(",", ".");
                    objInfCte.vPrest.Comp.Add(Comp);
                }
                if (nudFreteCubagem.Value > 0)
                {
                    Comp = new belComp();
                    Comp.xNome = "FRETE CUBAGEM";
                    Comp.vComp = nudFreteCubagem.Text.Replace(",", ".");
                    objInfCte.vPrest.Comp.Add(Comp);
                }

                if (nudFretePeso.Value > 0)
                {
                    Comp = new belComp();
                    Comp.xNome = "FRETE PESO";
                    Comp.vComp = nudFretePeso.Text.Replace(",", ".");
                    objInfCte.vPrest.Comp.Add(Comp);
                }

                if (nudCat.Value > 0)
                {
                    Comp = new belComp();
                    Comp.xNome = "CAT";
                    Comp.vComp = nudCat.Text.Replace(",", ".");
                    objInfCte.vPrest.Comp.Add(Comp);
                }

                if (nudDespacho.Value > 0)
                {
                    Comp = new belComp();
                    Comp.xNome = "DESPACHO";
                    Comp.vComp = nudDespacho.Text.Replace(",", ".");
                    objInfCte.vPrest.Comp.Add(Comp);
                }

                if (nudPedagio.Value > 0)
                {
                    Comp = new belComp();
                    Comp.xNome = "PEDAGIO";
                    Comp.vComp = nudPedagio.Text.Replace(",", ".");
                    objInfCte.vPrest.Comp.Add(Comp);
                }

                if (nudOutros.Value > 0)
                {
                    Comp = new belComp();
                    Comp.xNome = "OUTROS";
                    Comp.vComp = nudOutros.Text.Replace(",", ".");
                    objInfCte.vPrest.Comp.Add(Comp);
                }

                if (nudAdme.Value > 0)
                {
                    Comp = new belComp();
                    Comp.xNome = "ADME";
                    Comp.vComp = nudAdme.Text.Replace(",", ".");
                    objInfCte.vPrest.Comp.Add(Comp);
                }

                if (nudEntrega.Value > 0)
                {
                    Comp = new belComp();
                    Comp.xNome = "ENTREGA";
                    Comp.vComp = nudEntrega.Text.Replace(",", ".");
                    objInfCte.vPrest.Comp.Add(Comp);
                }

                if (nudGris.Value > 0)
                {
                    Comp = new belComp();
                    Comp.xNome = "GRIS";
                    Comp.vComp = nudGris.Text.Replace(",", ".");
                    objInfCte.vPrest.Comp.Add(Comp);
                }

                if (nudValoraAdic.Value > 0)
                {
                    Comp = new belComp();
                    Comp.xNome = "VALOR ADICIONAL";
                    Comp.vComp = nudValoraAdic.Text.Replace(",", ".");
                    objInfCte.vPrest.Comp.Add(Comp);
                }
                #endregion




                objInfCte.imp.ICMS = new belICMS();
                if (cboCST.SelectedIndex == 0)
                {
                    objInfCte.imp.ICMS.ICMS00 = new belICMS00();
                    objInfCte.imp.ICMS.ICMS00.CST = "00";
                    objInfCte.imp.ICMS.ICMS00.vBC = nudvBC.Value.ToString().Replace(",", ".");
                    objInfCte.imp.ICMS.ICMS00.pICMS = nudpICMS.Value.ToString().Replace(",", ".");
                    objInfCte.imp.ICMS.ICMS00.vICMS = nudvICMS.Value.ToString().Replace(",", ".");
                }
                else if (cboCST.SelectedIndex == 1)
                {
                    objInfCte.imp.ICMS.ICMS20 = new belICMS20();
                    objInfCte.imp.ICMS.ICMS20.CST = "20";
                    objInfCte.imp.ICMS.ICMS20.pRedBC = nudpRedBC.Value.ToString().Replace(",", ".");
                    objInfCte.imp.ICMS.ICMS20.vBC = nudvBC.Value.ToString().Replace(",", ".");
                    objInfCte.imp.ICMS.ICMS20.pICMS = nudpICMS.Value.ToString().Replace(",", ".");
                    objInfCte.imp.ICMS.ICMS20.vICMS = nudvICMS.Value.ToString().Replace(",", ".");
                }
                else if (cboCST.SelectedIndex == 2 || cboCST.SelectedIndex == 3 || cboCST.SelectedIndex == 4)
                {
                    objInfCte.imp.ICMS.ICMS45 = new belICMS45();
                    switch (cboCST.SelectedIndex)
                    {
                        case 2: objInfCte.imp.ICMS.ICMS45.CST = "40";
                            break;
                        case 3: objInfCte.imp.ICMS.ICMS45.CST = "41";
                            break;
                        case 4: objInfCte.imp.ICMS.ICMS45.CST = "51";
                            break;
                    }
                }
                else if (cboCST.SelectedIndex == 5)
                {
                    objInfCte.imp.ICMS.ICMS60 = new belICMS60();
                    objInfCte.imp.ICMS.ICMS60.CST = "60";
                    objInfCte.imp.ICMS.ICMS60.vBCSTRet = nudvBC.Value.ToString().Replace(",", ".");
                    objInfCte.imp.ICMS.ICMS60.vICMSSTRet = nudvICMS.Value.ToString().Replace(",", ".");
                    objInfCte.imp.ICMS.ICMS60.pICMSSTRet = nudpICMS.Value.ToString().Replace(",", ".");
                }
                else if (cboCST.SelectedIndex == 6)
                {
                    objInfCte.imp.ICMS.ICMS90 = new belICMS90();
                    objInfCte.imp.ICMS.ICMS90.CST = "90";
                    objInfCte.imp.ICMS.ICMS90.pRedBC = nudpRedBC.Value.ToString().Replace(",", ".");
                    objInfCte.imp.ICMS.ICMS90.vBC = nudvBC.Value.ToString().Replace(",", ".");
                    objInfCte.imp.ICMS.ICMS90.pICMS = nudpICMS.Value.ToString().Replace(",", ".");
                    objInfCte.imp.ICMS.ICMS90.vICMS = nudvICMS.Value.ToString().Replace(",", ".");
                }
                else if (cboCST.SelectedIndex == 7)
                {
                    objInfCte.imp.ICMS.ICMSOutraUF = new belICMSOutraUF();
                    objInfCte.imp.ICMS.ICMSOutraUF.CST = "90";
                    objInfCte.imp.ICMS.ICMSOutraUF.pRedBCOutraUF = nudpRedBC.Value.ToString().Replace(",", ".");
                    objInfCte.imp.ICMS.ICMSOutraUF.vBCOutraUF = nudvBC.Value.ToString().Replace(",", ".");
                    objInfCte.imp.ICMS.ICMSOutraUF.pICMSOutraUF = nudpICMS.Value.ToString().Replace(",", ".");
                    objInfCte.imp.ICMS.ICMSOutraUF.vICMSOutraUF = nudvICMS.Value.ToString().Replace(",", ".");
                }



                #endregion

                #region InformacoesCarga

                objInfCte.infCTeNorm.infCarga.vCarga = nudvMerc.Value;
                objInfCte.infCTeNorm.infCarga.proPred = txtproPred.Text;
                objInfCte.infCTeNorm.infCarga.xOutCat = txtxOutCat.Text;


                objInfCte.infCTeNorm.infCarga.infQ = bsInfQ.DataSource as List<belinfQ>;

                //for (int j = 0; j < gridinfQ.RowCount; j++)
                //{
                //    belinfQ obj = new belinfQ();
                //    if (gridinfQ.Rows[j].Cells[0].Value == null)
                //    {
                //        obj.cUnid = "";
                //    }
                //    else
                //    {
                //        switch (gridinfQ.Rows[j].Cells[0].Value.ToString())
                //        {
                //            case "00-M3": obj.cUnid = "00";
                //                break;
                //            case "01-KG": obj.cUnid = "01";
                //                break;
                //            case "02-Ton": obj.cUnid = "02";
                //                break;
                //            case "03-Unidade": obj.cUnid = "03";
                //                break;
                //            case "04-Litros": obj.cUnid = "04";
                //                break;
                //        }
                //    }
                //    if (gridinfQ.Rows[j].Cells[1].Value == null)
                //    {
                //        obj.tpMed = "";
                //    }
                //    else
                //    {
                //        obj.tpMed = gridinfQ.Rows[j].Cells[1].Value.ToString();
                //    }
                //    if (gridinfQ.Rows[j].Cells[2].Value == null)
                //    {
                //        obj.qCarga = 0;
                //    }
                //    else
                //    {
                //        obj.qCarga = Convert.ToDecimal(gridinfQ.Rows[j].Cells[2].Value.ToString());
                //    }

                //    objInfCte.infCTeNorm.infCarga.infQ.Add(obj);
                //}

                #endregion

                #region Rodoviario

                objInfCte.infCTeNorm.seg.respSeg = cborespSeg.SelectedIndex != -1 ? cborespSeg.SelectedIndex.ToString() : "";

                objInfCte.infCTeNorm.rodo.dPrev = mskdPrev.Text.Replace(" ", "").Replace("/", "").Replace('_', ' ').Trim() != "" ? Convert.ToDateTime(mskdPrev.Text).ToShortDateString() : "";
                objInfCte.infCTeNorm.seg.nApol = txtnApol.Text;
                objInfCte.infCTeNorm.rodo.RNTRC = txtRNTRC.Text;
                objInfCte.infCTeNorm.rodo.lota = cbolota.SelectedIndex != -1 ? cbolota.SelectedIndex.ToString() : "";

                #endregion

                #region Veiculo

                if (objInfCte.infCTeNorm.rodo.veic.Count() > 0)
                {
                    if (VerificaCamposVeiculo() || objInfCte.infCTeNorm.rodo.lota == "1")
                    {
                        belveic veic = (belveic)bsVeiculos.Current;

                        veic.RENAVAM = txtRENAVAM.Text;
                        veic.placa = txtplaca.Text;
                        veic.tara = nudtara.Value.ToString();
                        veic.capKG = nudcapKG.Value.ToString();
                        veic.capM3 = nudcapM3.Value.ToString();
                        switch (cbotpProp.SelectedIndex)
                        {
                            case 0:
                                veic.tpProp = "P";
                                break;
                            case 1:
                                veic.tpProp = "T";
                                break;
                            default:
                                veic.tpProp = "";
                                break;
                        }
                        veic.tpVeic = cbotpVeic.SelectedIndex != -1 ? cbotpVeic.SelectedIndex.ToString() : "";
                        veic.tpRod = cbotpRod.SelectedIndex != -1 ? "0" + cbotpRod.SelectedIndex.ToString() : "";
                        veic.tpCar = cbotpCar.SelectedIndex != -1 ? "0" + cbotpCar.SelectedIndex.ToString() : "";
                        veic.UF = txtUF.Text;

                        if (veic.tpProp == "T")
                        {
                            veic.prop = new belprop();
                            veic.prop.CPFCNPJ = txtCPFprop.Text;
                            veic.prop.RNTRC = txtRNTRCprop.Text;
                            veic.prop.xNome = txtxNomeprop.Text;
                            veic.prop.IE = txtIEprop.Text;
                            veic.prop.UF = txtUFprop.Text;
                            veic.prop.tpProp = cbotpPropprop.SelectedIndex != -1 ? cbotpCar.SelectedIndex.ToString() : "";
                        }
                        else
                        {
                            veic.prop = null;
                        }
                    }
                }

                if (VerificaCamposProprietarioVeiculo() || objInfCte.infCTeNorm.rodo.lota == "1")
                {
                    objInfCte.infCTeNorm.rodo.moto = new belmoto();
                    objInfCte.infCTeNorm.rodo.moto.xNome = txtxNomemoto.Text;
                    objInfCte.infCTeNorm.rodo.moto.CPF = txtCPFmoto.Text;
                }
                else
                {
                    objInfCte.infCTeNorm.rodo.moto = null;
                }

                #endregion

                #region Obs
                objInfCte.compl.ObsCont.xTexto = objInfCte.compl.ObsCont.xTexto;
                #endregion

                VerificaCampos();

            }
            catch (Exception ex)
            {
                new HLPexception(ex);
            }
        }
        private bool VerificaCampos()
        {
            belinfCte objInfCte = (belinfCte)bsNotas.Current;
            int Erros = 0;
            bool Retorno = true;

            #region Identificacao

            Erros += belValidaCampos.Validar(flpIdentificacao.Controls, false);

            #endregion

            #region Tomador
            Erros += belValidaCampos.Validar(flpTomador.Controls, false);
            if (cbotoma.SelectedIndex == 4)
            {
                Erros += belValidaCampos.Validar(flpDadosTomador.Controls, false);
                Erros += belValidaCampos.Validar(flpEndTomador.Controls, false);
            }

            #endregion

            #region Emitente

            Erros += belValidaCampos.Validar(flpDadosEmit.Controls, false);
            Erros += belValidaCampos.Validar(flpEndEmit.Controls, false);


            #endregion

            #region Remetente
            Erros += belValidaCampos.Validar(flpDadosRem.Controls, false);
            Erros += belValidaCampos.Validar(flpEndRem.Controls, false);

            #endregion

            #region Destinatario

            Erros += belValidaCampos.Validar(flpDadosDest.Controls, false);
            Erros += belValidaCampos.Validar(flpEndDest.Controls, false);

            #endregion

            #region Expedidor

            if (objInfCte.exped != null)
            {
                Erros += belValidaCampos.Validar(flpDadosExped.Controls, false);
                Erros += belValidaCampos.Validar(flpEndExped.Controls, false);
            }


            #endregion

            #region Recebedor
            if (objInfCte.receb != null)
            {
                Erros += belValidaCampos.Validar(flpDadosReceb.Controls, false);
                Erros += belValidaCampos.Validar(flpEndReceb.Controls, false);
            }


            #endregion

            #region Valores
            Erros += belValidaCampos.Validar(flpValores.Controls, false);
            Erros += belValidaCampos.Validar(flpImposto.Controls, false);

            #endregion

            #region InformacoesCarga
            Erros += belValidaCampos.Validar(flpInfCarga.Controls, false);

            bool bErroCarga = false;
            //if (gridinfQ.RowCount > 1)
            //{

            //    for (int i = 0; i < gridinfQ.RowCount - 1; i++)
            //    {
            //        if (gridinfQ.Rows[i].Cells[0].Value == null) { errErro.SetError(gridinfQ, "Preencha Todos os Campos!"); bErroCarga = true; }
            //        if (gridinfQ.Rows[i].Cells[1].Value == null) { errErro.SetError(gridinfQ, "Preencha Todos os Campos!"); bErroCarga = true; }
            //        if (gridinfQ.Rows[i].Cells[2].Value == null) { errErro.SetError(gridinfQ, "Preencha Todos os Campos!"); bErroCarga = true; }
            //    }
            //}
            //else if (gridinfQ.RowCount == 1)
            //{
            //    if (gridinfQ.Rows[0].Cells[0].Value == null) { errErro.SetError(gridinfQ, "Preencha Todos os Campos!"); bErroCarga = true; }
            //    if (gridinfQ.Rows[0].Cells[1].Value == null) { errErro.SetError(gridinfQ, "Preencha Todos os Campos!"); bErroCarga = true; }
            //    if (gridinfQ.Rows[0].Cells[2].Value == null) { errErro.SetError(gridinfQ, "Preencha Todos os Campos!"); bErroCarga = true; }
            //}
            if (bErroCarga)
            {
                Erros++;
            }

            #endregion

            #region Rodoviario

            Erros += belValidaCampos.Validar(flpRodoviario.Controls, false);

            #endregion

            #region Veiculo

            Erros += VerificaCamposObrigatoriosVeiculo();

            #endregion

            if (txtxNomemoto.Text != "" || txtCPFmoto.Text != "" || cbolota.SelectedIndex == 1)
            {
                Erros += belValidaCampos.Validar(flpMotorista.Controls, false);
            }



            if (Erros > 0)
            {
                Retorno = false;
            }
            return Retorno;
        }
        private int VerificaCamposObrigatoriosVeiculo()
        {
            int Erros = 0;
            if (cbolota.SelectedIndex == 1 || VerificaCamposVeiculo())
            {
                Erros += belValidaCampos.Validar(flpVeiculo.Controls, false);

                if (cbotpProp.SelectedIndex == 1 || VerificaCamposProprietarioVeiculo())
                {
                    Erros += belValidaCampos.Validar(flpPropVeiculo.Controls, false);
                }
            }
            return Erros;
        }
        private bool VerificaCamposVeiculo()
        {
            try
            {
                if (txtRENAVAM.Text != "" || txtplaca.Text != "" || nudtara.Value != 0 || nudcapKG.Value != 0 || nudcapM3.Value != 0 ||
                    cbotpProp.SelectedIndex != -1 || cbotpVeic.SelectedIndex != -1 || cbotpRod.SelectedIndex != -1 || cbotpCar.SelectedIndex != -1 || txtUF.Text != "")
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
        private bool VerificaCamposProprietarioVeiculo()
        {
            try
            {

                if (txtCPFprop.Text != "" || txtRNTRCprop.Text != "" || txtxNomeprop.Text != "" || txtIEprop.Text != "" || txtUFprop.Text != "" || cbotpPropprop.SelectedIndex != -1)
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
        private bool ValidaConhecimentos()
        {
            try
            {
                bsNotas.MoveFirst();
                bool Retorno = true;
                belValidaCampos.LimpaErros();

                for (int i = 0; i < bsNotas.List.Count; i++)
                {
                    belinfCte objInfCte = (belinfCte)bsNotas.Current;
                    PopulaForm();

                    if (objInfCte.infCTeNorm.infCarga.infQ.Count() == 0)
                    {
                        MessageBox.Show("Informações de quantidade da carga do CT-e é obrigatório");
                    }

                    #region Identificacao

                    belValidaCampos.ValidarTodosDocumentos(flpIdentificacao.Controls, txtnCT.Text);

                    #endregion

                    #region Tomador
                    belValidaCampos.ValidarTodosDocumentos(flpTomador.Controls, txtnCT.Text);
                    if (cbotoma.SelectedIndex == 4)
                    {
                        belValidaCampos.ValidarTodosDocumentos(flpDadosTomador.Controls, txtnCT.Text);
                    }

                    #endregion

                    #region Emitente

                    belValidaCampos.ValidarTodosDocumentos(flpDadosEmit.Controls, txtnCT.Text);
                    belValidaCampos.ValidarTodosDocumentos(flpEndEmit.Controls, txtnCT.Text);


                    #endregion

                    #region Remetente
                    belValidaCampos.ValidarTodosDocumentos(flpDadosRem.Controls, txtnCT.Text);
                    belValidaCampos.ValidarTodosDocumentos(flpEndRem.Controls, txtnCT.Text);

                    #endregion

                    #region Destinatario

                    belValidaCampos.ValidarTodosDocumentos(flpDadosDest.Controls, txtnCT.Text);
                    belValidaCampos.ValidarTodosDocumentos(flpEndDest.Controls, txtnCT.Text);

                    #endregion

                    #region Expedidor

                    if (objInfCte.exped != null)
                    {
                        belValidaCampos.ValidarTodosDocumentos(flpDadosExped.Controls, txtnCT.Text);
                        belValidaCampos.ValidarTodosDocumentos(flpEndExped.Controls, txtnCT.Text);
                    }


                    #endregion

                    #region Recebedor
                    if (objInfCte.receb != null)
                    {
                        belValidaCampos.ValidarTodosDocumentos(flpDadosReceb.Controls, txtnCT.Text);
                        belValidaCampos.ValidarTodosDocumentos(flpEndReceb.Controls, txtnCT.Text);
                    }


                    #endregion

                    #region Valores
                    belValidaCampos.ValidarTodosDocumentos(flpValores.Controls, txtnCT.Text);
                    belValidaCampos.ValidarTodosDocumentos(flpImposto.Controls, txtnCT.Text);

                    #endregion

                    #region InformacoesCarga
                    belValidaCampos.ValidarTodosDocumentos(flpInfCarga.Controls, txtnCT.Text);

                    bool bErroCarga = false;
                    //if (gridinfQ.RowCount > 1)
                    //{

                    //    for (int j = 0; j < gridinfQ.RowCount - 1; j++)
                    //    {
                    //        if (gridinfQ.Rows[i].Cells[0].Value == null) { errErro.SetError(gridinfQ, "Preencha Todos os Campos!"); bErroCarga = true; }
                    //        if (gridinfQ.Rows[i].Cells[1].Value == null) { errErro.SetError(gridinfQ, "Preencha Todos os Campos!"); bErroCarga = true; }
                    //        if (gridinfQ.Rows[i].Cells[2].Value == null) { errErro.SetError(gridinfQ, "Preencha Todos os Campos!"); bErroCarga = true; }
                    //    }
                    //}
                    //else if (gridinfQ.RowCount == 1)
                    //{
                    //    if (gridinfQ.Rows[0].Cells[0].Value == null) { errErro.SetError(gridinfQ, "Preencha Todos os Campos!"); bErroCarga = true; }
                    //    if (gridinfQ.Rows[0].Cells[1].Value == null) { errErro.SetError(gridinfQ, "Preencha Todos os Campos!"); bErroCarga = true; }
                    //    if (gridinfQ.Rows[0].Cells[2].Value == null) { errErro.SetError(gridinfQ, "Preencha Todos os Campos!"); bErroCarga = true; }
                    //}
                    if (bErroCarga)
                    {
                        belValidaCampos.iErros++;
                    }

                    #endregion

                    #region Rodoviario

                    belValidaCampos.ValidarTodosDocumentos(flpRodoviario.Controls, txtnCT.Text);

                    #endregion

                    #region Veiculo

                    belValidaCampos.iErros += VerificaCamposObrigatoriosVeiculo();

                    #endregion

                    objInfCte.compl = new belcompl();
                    objInfCte.compl.ObsCont.xTexto = txtxTexto.Text;

                    if (txtxNomemoto.Text != "" || txtCPFmoto.Text != "" || cbolota.SelectedIndex == 1)
                    {
                        belValidaCampos.ValidarTodosDocumentos(flpMotorista.Controls, txtnCT.Text);
                    }
                    bsNotas.MoveNext();
                }
                bsNotas.MoveFirst();
                lblContagemNotas.Text = "1 de " + bsNotas.Count;
                PopulaForm();


                listErros.DataSource = belValidaCampos.objListaTodosErros;
                lblErro.Text = belValidaCampos.iErros.ToString() + " Erro(s)";

                if (belValidaCampos.iErros > 0)
                {
                    Retorno = false;
                }
                return Retorno;
            }
            catch (Exception ex)
            {
                new HLPexception(ex);
                return false;
            }
        }
        private void HabilitaCamposToma()
        {
            if (cbotoma.SelectedIndex == 4)
            {
                flpDadosTomador.Enabled = true;
                flpEndTomador.Enabled = true;
            }
            else
            {
                flpDadosTomador.Enabled = false;
                flpEndTomador.Enabled = false;
            }
        }

        /// <summary>
        ///(0) 00 - Tributação normal ICMS
        ///(1) 20 - Tributação com BC reduzida do ICMS
        ///(2) 40 - ICMS isenção
        ///(3) 41 - ICMS não tributada
        ///(4) 51 - ICMS diferido
        ///(5) 60 - ICMS cobrado anteriormente por substituição tributária
        ///(6) 90 - ICMS outros
        ///(7) 90 - ICMS outros (ICMS devido à UF de origem da prestação, quando diferente da UF do emitente)
        /// </summary>
        /// <param name="index"></param>
        private void HabilitaCamposValores(int index)
        {
            switch (index)
            {
                //(0) 00 - Tributação normal ICMS
                case 0:
                    nudvBC.Enabled = true;
                    nudpICMS.Enabled = true;
                    nudvICMS.Enabled = true;
                    nudpRedBC.Enabled = false;
                    break;

                //(1) 20 - Tributação com BC reduzida do ICMS
                case 1:
                    nudvBC.Enabled = true;
                    nudpICMS.Enabled = true;
                    nudvICMS.Enabled = true;
                    nudpRedBC.Enabled = true;
                    break;

                //(2) 40 - ICMS isenção
                case 2:
                    nudvBC.Enabled = false;
                    nudpICMS.Enabled = false;
                    nudvICMS.Enabled = false;
                    nudpRedBC.Enabled = false;
                    break;

                //(3) 41 - ICMS não tributada
                case 3:
                    nudvBC.Enabled = false;
                    nudpICMS.Enabled = false;
                    nudvICMS.Enabled = false;
                    nudpRedBC.Enabled = false;
                    break;

                //(4) 51 - ICMS diferido
                case 4:
                    nudvBC.Enabled = false;
                    nudpICMS.Enabled = false;
                    nudvICMS.Enabled = false;
                    nudpRedBC.Enabled = false;
                    break;


                //(5) 60 - ICMS cobrado anteriormente por substituição tributária
                case 5:
                    nudvBC.Enabled = true;
                    nudpICMS.Enabled = true;
                    nudvICMS.Enabled = true;
                    nudpRedBC.Enabled = false;
                    break;

                //(6) 90 - ICMS outros
                case 6:
                    nudvBC.Enabled = true;
                    nudpICMS.Enabled = true;
                    nudvICMS.Enabled = true;
                    nudpRedBC.Enabled = true;
                    break;

                //(7) 90 - ICMS outros (ICMS devido à UF de origem da prestação, quando diferente da UF do emitente)
                case 7:
                    nudvBC.Enabled = true;
                    nudpICMS.Enabled = true;
                    nudvICMS.Enabled = true;
                    nudpRedBC.Enabled = true;
                    break;
            }

        }

        private void ProcuraTabPage(Control controle)
        {
            if (controle.Parent != null)
            {
                if (controle.Parent.GetType() == typeof(TabPage))
                {
                    (controle.Parent.Parent as TabControl).SelectedTab = (controle.Parent as TabPage);
                }
                ProcuraTabPage(controle.Parent);
            }
        }

        #endregion

        #region Botoes

        public override void Atualizar()
        {
            base.Atualizar();
        }
        public override void Salvar()
        {
            try
            {
                SalvarAlteracao();
                ValidaConhecimentos();
                base.Salvar();
            }
            catch (Exception ex)
            {
                new HLPexception(ex);
            }

        }
        public override void Enviar()
        {
            try
            {
                if (ValidaConhecimentos())
                {
                    base.Enviar();
                }
                else
                {
                    KryptonMessageBox.Show("Verifique Todos os Erros antes de Enviar o CT-e!", Mensagens.MSG_Alerta, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            catch (Exception ex)
            {
                new HLPexception(ex);
            }
        }
        public override void Cancelar()
        {
            try
            {
                if (KryptonMessageBox.Show("Deseja Cancelar as Alterações Realizadas?", Mensagens.MSG_Confirmacao, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    CriaObjAlter();
                    LimpaCampos(this.Controls);
                    ValidaConhecimentos();
                    PopulaForm();
                    VerificaCampos();
                    base.Cancelar();
                }
            }
            catch (Exception ex)
            {
                new HLPexception(ex);
            }
        }
        public override void Sair()
        {
            base.Sair();
        }
        public override void Navegacao(object sender)
        {
            try
            {
                SalvarAlteracao();
                base.Navegacao(sender);
                PopulaForm();
                VerificaCampos();
            }
            catch (Exception ex)
            {
                new HLPexception(ex);
            }

        }

        #endregion

        private void Configuracoes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((sender as AC.ExtendedRenderer.Navigator.KryptonTabControl).SelectedTab.Name == "tabErros")
            {
                SalvarAlteracao();
                ValidaConhecimentos();
            }
        }

        private void belinfNFeBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }



    }
}
