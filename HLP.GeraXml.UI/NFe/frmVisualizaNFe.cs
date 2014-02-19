using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HLP.GeraXml.Comum.Forms;
using HLP.GeraXml.bel.NFe;
using HLP.GeraXml.bel.NFe.Estrutura;
using HLP.GeraXml.Comum;
using HLP.GeraXml.Comum.Static;
using ComponentFactory.Krypton.Toolkit;
using HLP.GeraXml.Comum.Componentes;
using HLP.GeraXml.bel;
using HLP.GeraXml.UI.Configuracao;
using HLP.GeraXml.dao.NFe.Estrutura;

namespace HLP.GeraXml.UI.NFe
{
    public partial class frmVisualizaNFe : FormPadraoVisualizacao
    {
        private bool bOrderDesc { get; set; }

        public frmVisualizaNFe(List<belInfNFe> objListaNFs)
        {

            try
            {
                InitializeComponent();
              
                cbxmotDesICMS.cbx.DropDownHeight = 150;
                cbxmotDesICMS.cbx.DropDownWidth = 600;
                cbxCSTicmsItens.cbx.DropDownHeight = 150;
                cbxCSTicmsItens.cbx.DropDownWidth = 600;
                listErros.ListBox.MouseDoubleClick += new MouseEventHandler(listErros_MouseDoubleClick);
                bsNotas.DataSource = objListaNFs;
                ValidaNotas();
                PopulaForm();
                VerificaCampos();
                CarregaComboBoxST();
                DesabilitaComponentesConatiner(flICMS.Controls);
                dgvProd.ReadOnly = true;
                tabProd.Leave += new EventHandler(tabProd_Leave);
                gbADI.Controls.Add(dgvADI);
                dgvADI.Dock = DockStyle.Fill;
                gbDI.Controls.Add(dgvDI);
                dgvDI.Dock = DockStyle.Fill;
                nudvTotTrib.Visible = false;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region Métodos

        private void PopulaForm()
        {

            try
            {
                belInfNFe nota = bsNotas.Current as belInfNFe;
                #region IDE
                txtUF.Text = nota.ide.Cuf;
                txtSeq.Text = nota.ide.Cnf;
                txtNatOp.Text = nota.ide.Natop;
                cbxIndPag.SelectedIndex = Convert.ToInt32(nota.ide.Indpag);
                txtMod.Text = "55";
                txtSerie.Text = nota.ide.Serie;
                txtNNF.Text = nota.ide.Nnf;
                //  mtbDEmi.Text = nota.ide.Demi.ToString("dd/MM/yyyy");
                mtbDEmi.Value = nota.ide.Demi;
                mtbDSaiEnt.Value = nota.ide.Dsaient;
                dtpHSaiEnt.Value = nota.ide.HSaiEnt;


                cbxTpNF.SelectedIndex = Convert.ToInt32(nota.ide.Tpnf);
                txtCMunFG.Text = nota.ide.Cmunfg;
                cbxtpImp.SelectedIndex = Convert.ToInt32(nota.ide.Tpimp) - 1;
                cbcxTpEmis.SelectedIndex = Convert.ToInt32(nota.ide.Tpemis) - 1;
                txtCDV.Text = nota.ide.Cdv;
                cbxTpAmb.SelectedIndex = Convert.ToInt32(nota.ide.Tpamb) - 1;
                cbxFinNFe.SelectedIndex = Convert.ToInt32(nota.ide.Finnfe) - 1;
                txtProcEmi.Text = nota.ide.Procemi;
                txtVerProc.Text = nota.ide.Verproc;


                #endregion

                #region Emitente

                if (nota.emit.Cnpj != null)
                {
                    cbxPessoaEmit.SelectedIndex = 1;
                    mtbCpfCnpjEmit.Mask = "00,000,000/0000-00";
                    mtbCpfCnpjEmit.Text = nota.emit.Cnpj;
                    mtbCpfCnpjEmit._Regex = Expressoes.ER4;
                }
                else
                {
                    cbxPessoaEmit.SelectedIndex = 0;
                    mtbCpfCnpjEmit.Mask = "000,000,000-00";
                    mtbCpfCnpjEmit.Text = nota.emit.Cpf; ;
                    mtbCpfCnpjEmit._Regex = Expressoes.ER7;
                }


                switch (nota.emit.CRT) // NFe_2.0
                {
                    case 1: cmbCRT.SelectedIndex = 0;
                        break;

                    case 2: cmbCRT.SelectedIndex = 1;
                        break;

                    case 3: cmbCRT.SelectedIndex = 2;
                        break;
                }
                txtXNomeEmit.Text = nota.emit.Xnome;
                txtXFantEmit.Text = nota.emit.Xfant;
                txtIEEmit.Text = nota.emit.Ie;
                txtIESTEmit.Text = nota.emit.Iest;
                txtIM.Text = nota.emit.Im;
                txtCNAE.Text = nota.emit.Cnae;

                //Endereço

                txtEnderEmitXlgr.Text = nota.emit.Xlgr;
                txtEnderEmitNum.Text = nota.emit.Nro;
                txtEnderEmitCompl.Text = nota.emit.Xcpl;
                txtEnderEmitXbairro.Text = nota.emit.Xbairro;
                txtEnderEmitCmun.Text = nota.emit.Cmun;
                txtEnderEmitXmun.Text = nota.emit.Xmun;
                txtEnderEmitUF.Text = nota.emit.Uf;
                txtEnderEmitCpais.Text = nota.emit.Cpais;
                txtEnderEmitXpais.Text = nota.emit.Xpais;
                mtbEnderEmitCep.Text = nota.emit.Cep;
                mtbEnderEmitFone.Text = nota.emit.Fone;

                //Fim - Endereço

                #endregion

                #region Destinatario

                if (nota.dest.Cnpj == "EXTERIOR")
                {
                    cbxPessoaDest.SelectedIndex = 2;
                    mtbCpfCnpjDest.Mask = "";
                    mtbCpfCnpjDest.Text = nota.dest.Cnpj;
                }
                else if (nota.dest.Cnpj != null)
                {
                    mtbCpfCnpjDest._Obrigatorio = HLP_MaskedTextBox.CampoObrigatorio.SIM;
                    mtbCpfCnpjDest.Mask = "00,000,000/0000-00";
                    mtbCpfCnpjDest.Text = nota.dest.Cnpj;
                    mtbCpfCnpjDest._Regex = Expressoes.ER4;
                }
                else
                {
                    mtbCpfCnpjDest._Obrigatorio = HLP_MaskedTextBox.CampoObrigatorio.SIM;
                    mtbCpfCnpjDest.Mask = "000,000,000-00";
                    mtbCpfCnpjDest.Text = nota.dest.Cpf;
                    mtbCpfCnpjDest._Regex = Expressoes.ER7;
                }

                if (nota.dest.tpEmit == 1)
                {
                    cbxPessoaDest.SelectedIndex = 1;
                }
                else
                {
                    cbxPessoaDest.SelectedIndex = 0;
                }

                txtXnomeDest.Text = nota.dest.Xnome;
                txtIEDest.Text = nota.dest.Ie;
                txtISUFDest.Text = nota.dest.Isuf;
                //Endereço
                txtEnderDestXlgr.Text = nota.dest.Xlgr;
                txtEnderDestCpl.Text = nota.dest.Xcpl;
                txtEnderDestNro.Text = nota.dest.Nro;
                txtEnderDestXbairro.Text = nota.dest.Xbairro;
                txtEnderDestCmun.Text = nota.dest.Cmun;
                txtEnderDestXmun.Text = nota.dest.Xmun;
                txtEnderDestUF.Text = nota.dest.Uf;

                txtEnderDestCpais.Text = nota.dest.Cpais;
                txtEnderDestXpais.Text = nota.dest.Xpais;
                mtbEnderDestCEP.Text = nota.dest.Cep;
                mtbEnderDestFone.Text = nota.dest.Fone;
                txtEmaildest.Text = nota.dest.email;

                //Fim - Endereço

                #endregion

                #region Endereço de Entrega
                if (nota.endent.Cnpj != null)
                {
                    txtEndEntXlgr.Text = nota.endent.Xlgr;
                    txtEndEntNro.Text = nota.endent.Nro;
                    txtEndEntCmun.Text = nota.endent.Cmun;
                    txtEndEntXmun.Text = nota.endent.Xmun;
                    txtEndEntUF.Text = nota.endent.Uf;
                    txtEndEntXbairro.Text = nota.endent.Xbairro; // OS_25185
                    txtEndEntCpl.Text = nota.endent.Xcpl;
                }

                #endregion

                #region Detalhes
                List<belProd> objListaBelProd = new List<belProd>();
                foreach (belDet det in nota.det)
                {
                    objListaBelProd.Add(det.prod);
                }
                bsProdutos.DataSource = objListaBelProd;
                dgvProd.Columns["clVuncom"].DefaultCellStyle.Format = "n" + Acesso.QTDE_CASAS_VL_UNIT;
                dgvProd.Columns["clVuntrib"].DefaultCellStyle.Format = "n" + Acesso.QTDE_CASAS_VL_UNIT;
                dgvProd.Columns["clvTotTrib"].DefaultCellStyle.Format = "n2";


                int IcountExport = nota.det.Where(p => (p.prod.Cfop == "7201") || (p.prod.Cfop == "7101") || (p.prod.Cfop == "7949") || (p.prod.Cfop == "7930") || (p.prod.Cfop == "7102")).Count(); //25679
                if (IcountExport > 0)
                {
                    txtUFembarque._Obrigatorio = HLP_TextBox.CampoObrigatorio.SIM;
                    txtLocalEmbarque._Obrigatorio = HLP_TextBox.CampoObrigatorio.SIM;
                    txtLocalEmbarque._Regex = Expressoes.ER32;
                }
                #endregion

                #region Totais
                nudVBC.Value = nota.total.belIcmstot.Vbc;
                nudVICMS.Value = nota.total.belIcmstot.Vicms;
                nudVBCICMSST.Value = nota.total.belIcmstot.Vbcst;
                nudVST.Value = nota.total.belIcmstot.Vst;
                nudVProd.Value = nota.total.belIcmstot.Vprod;
                nudVFrete.Value = nota.total.belIcmstot.Vfrete;
                nudVSEG.Value = nota.total.belIcmstot.Vseg;
                nudVDesc.Value = nota.total.belIcmstot.Vdesc;
                nudVII.Value = nota.total.belIcmstot.Vii;
                nudVIPI.Value = nota.total.belIcmstot.Vipi;
                nudVPIS.Value = nota.total.belIcmstot.Vpis;
                nudVCOFINS.Value = nota.total.belIcmstot.Vcofins;
                nudVOutro.Value = nota.total.belIcmstot.Voutro;
                nudVNF.Value = nota.total.belIcmstot.Vnf;
                nudvTotTrib.Value = nota.total.belIcmstot.vTotTrib;

                //ISSQNtot
                if (nota.total.belIssqntot != null)
                {
                    nudVServ.Value = nota.total.belIssqntot.Vserv;
                    nudVBCISS.Value = nota.total.belIssqntot.Vbc;
                    nudVISS.Value = nota.total.belIssqntot.Viss;
                    nudVPISISS.Value = nota.total.belIssqntot.Vpis;
                    nudVCOFINSISS.Value = nota.total.belIssqntot.Vcofins;
                }
                //Fin - ISSQNtot;

                //retTrib
                if (nota.total.belRetTrib != null)
                {
                    nudVPISRet.Value = nota.total.belRetTrib.Vretpis;
                    nudVCOFINSRet.Value = nota.total.belRetTrib.Vretcofins;
                    nudVCSLLRet.Value = nota.total.belRetTrib.Vretcsll;
                    nudVBCIRRFRet.Value = nota.total.belRetTrib.Vbcirrf;
                    nudVIRRFRet.Value = nota.total.belRetTrib.Virrf;
                    nudVBCRetPrev.Value = nota.total.belRetTrib.Vbcretprev;
                    nudVRetPrev.Value = nota.total.belRetTrib.Vretprev;
                }
                //Fim - retTrib



                #endregion

                #region Transporte

                switch (nota.transp.Modfrete)
                {
                    case "0": cbxModFrete.SelectedIndex = 0;
                        break;
                    case "1": cbxModFrete.SelectedIndex = 1;
                        break;
                    case "2": cbxModFrete.SelectedIndex = 2;
                        break;
                    case "9": cbxModFrete.SelectedIndex = 3;
                        break;
                }

                if (nota.transp.belTransportadora.Cnpj != null)
                {
                    cbxPessoaTranp.SelectedIndex = 1;
                    mtbCPJCNPJTransp.Mask = "00,000,000/0000-00";
                    mtbCPJCNPJTransp.Text = nota.transp.belTransportadora.Cnpj;
                }
                else
                {
                    cbxPessoaTranp.SelectedIndex = 0;
                    mtbCPJCNPJTransp.Mask = "000,000,000-00";
                    mtbCPJCNPJTransp.Text = nota.transp.belTransportadora.Cpf;
                }

                txtXnomeTransp.Text = nota.transp.belTransportadora.Xnome;
                txtIETransp.Text = nota.transp.belTransportadora.Ie;
                txtEnderTransp.Text = nota.transp.belTransportadora.Xender;
                txtUFTransp.Text = nota.transp.belTransportadora.Uf;
                txtXmunTransp.Text = nota.transp.belTransportadora.Xmun;

                //Fim - Transportadora

                //VeicTransp
                if (!String.IsNullOrEmpty(nota.transp.belVeicTransp.Placa))
                {
                    mtbPlacaVeicTransp.Text = nota.transp.belVeicTransp.Placa;
                    txtUFVeicTransp.Text = nota.transp.belVeicTransp.Uf;
                    txtRNTCVeicTransp.Text = Convert.ToString(nota.transp.belVeicTransp.Rntc);
                }
                //Fim -  VeicTransp

                //Reboque
                if (!String.IsNullOrEmpty(nota.transp.belReboque.Placa))
                {
                    mtbPlacaReboque.Text = nota.transp.belReboque.Placa;
                    txtUFReboque.Text = nota.transp.belReboque.Uf;
                    txtRNTCReboque.Text = nota.transp.belReboque.Rntc;
                }
                //Fim - Reboque 

                //RetTransp
                if (nota.transp.belRetTransp.Vserv > 0)
                {
                    nudVBCICMSTransp.Value = nota.transp.belRetTransp.Vbvret;
                    nudVServTransp.Value = nota.transp.belRetTransp.Vserv;
                    nudPICMSTRetTransp.Value = nota.transp.belRetTransp.Picmsret;
                    nudVICMSRet.Value = nota.transp.belRetTransp.Vicmsret;
                    txtCmunFGTransp.Text = nota.transp.belRetTransp.Cmunfg;
                    txtCFOPTransp.Text = nota.transp.belRetTransp.Cfop;
                }
                //Fim - RetTransp
                //Vol
                if (nota.transp.belVol.Qvol > 0)
                {
                    nudQvol.Value = nota.transp.belVol.Qvol;
                    txtEsp.Text = nota.transp.belVol.Esp;
                    txtMarca.Text = nota.transp.belVol.Marca;
                    txtNVol.Text = (Convert.ToString(nota.transp.belVol.Nvol));
                    nudPesoL.Value = nota.transp.belVol.PesoL;
                    nudPesoB.Value = nota.transp.belVol.PesoB;
                }
                //Fim - Vol

                #endregion

                #region Cobrança
                if (nota.cobr.Fat != null)
                {
                    txtNFat.Text = nota.cobr.Fat.Nfat;
                    nudVOrigFat.Value = nota.cobr.Fat.Vorig;
                    nudVDescFat.Value = nota.cobr.Fat.Vdesc;
                    nudVLiqFat.Value = nota.cobr.Fat.Vliq;
                    bsDuplicatas.DataSource = nota.cobr.Fat.belDup;
                }
                else
                {
                    txtNFat.Text = "";
                    nudVOrigFat.Value = 0;
                    nudVDescFat.Value = 0;
                    nudVLiqFat.Value = 0;
                    bsDuplicatas.DataSource = new List<belDup>();

                }
                #endregion

                #region Inf Adicionais
                string sInfAdd = "";

                if (nota.infAdic.Infcpl != null)
                {
                    for (int i = 0; i < nota.infAdic.Infcpl.Length; i++)
                    {
                        sInfAdd = sInfAdd + nota.infAdic.Infcpl[i];
                        if (nota.infAdic.Infcpl[i].ToString().Equals(";"))
                        {
                            sInfAdd = sInfAdd + Environment.NewLine;
                        }
                    }
                }
                txtInfAdic.Text = sInfAdd;
                lblCaracter.Text = "Total Caracter: " + sInfAdd.Length.ToString();

                #endregion

                lblNumNFe.Text = "Número NF-e: " + nota.ide.Nnf;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void SalvarAlteracao()
        {
            belInfNFe nota = bsNotas.Current as belInfNFe;
            try
            {
                #region IDE


                //nota.ide.Cuf = txtUF.Text;
                //nota.ide.Cnf = txtSeq.Text;
                //nota.ide.Natop = txtNatOp.Text;
                //nota.ide.Indpag = Convert.ToString(cbxIndPag.SelectedIndex).Trim();
                //nota.ide.Mod = txtMod.Text.Trim();
                //nota.ide.Serie = txtSerie.Text.Trim();
                //nota.ide.Nnf = txtNNF.Text.Trim();
                //nota.ide.Demi = Convert.ToDateTime(mtbDEmi.Text);
                //nota.ide.Dsaient = Convert.ToDateTime(mtbDSaiEnt.Text);
                //nota.ide.Tpnf = Convert.ToString(cbxTpNF.SelectedIndex);
                //nota.ide.Cmunfg = txtCMunFG.Text.Trim();
                //nota.ide.Tpimp = Convert.ToString((int)cbxtpImp.SelectedIndex + 1);
                //nota.ide.Tpemis = Convert.ToString((int)cbcxTpEmis.SelectedIndex + 1);
                //nota.ide.Cdv = txtCDV.Text.Trim();
                //nota.ide.Tpamb = Convert.ToString((int)cbxTpAmb.SelectedIndex + 1);
                nota.ide.Finnfe = Convert.ToString((int)cbxFinNFe.SelectedIndex + 1);
                //nota.ide.Procemi = txtProcEmi.Text.Trim();
                //nota.ide.Verproc = txtVerProc.Text.Trim();
                if (bsNFreferenciadas.Count > 0) // 25360
                {
                    List<belNFref> lObjNFref = new List<belNFref>();

                    for (int i = 0; i < bsNFreferenciadas.Count; i++)
                    {
                        lObjNFref.Add((belNFref)bsNFreferenciadas[i]);
                        if (lObjNFref[i].cUF != null)
                        {
                            if (!Util.IsNumeric(lObjNFref[i].cUF))
                            {
                                belUF objuf = new belUF();
                                lObjNFref[i].cUF = objuf.RetornaCUF((lObjNFref[i].cUF));
                                lObjNFref[i].CNPJ = (lObjNFref[i].CNPJ).Replace(",", "").Replace("/", "").Replace("-", "");
                                lObjNFref[i].nNF = (Convert.ToInt32(lObjNFref[i].nNF)).ToString();
                            }
                        }

                    }
                    nota.ide.belNFref = lObjNFref;
                }
                nota.ide.HSaiEnt = dtpHSaiEnt.Value;

                #endregion

                #region Emitente

                if (cbxPessoaEmit.SelectedIndex == 0)
                {
                    nota.emit.Cpf = mtbCpfCnpjEmit.Text;
                }
                else
                {
                    nota.emit.Cnpj = mtbCpfCnpjEmit.Text;
                }
                nota.emit.Xnome = txtXNomeEmit.Text.Trim();
                nota.emit.Xfant = txtXFantEmit.Text.Trim();
                nota.emit.Ie = txtIEEmit.Text.Trim();
                nota.emit.Iest = txtIESTEmit.Text.Trim();
                nota.emit.Im = txtIM.Text.Trim();
                nota.emit.Cnae = txtCNAE.Text;

                //Endereço

                nota.emit.Xlgr = txtEnderEmitXlgr.Text.Trim();
                nota.emit.Nro = txtEnderEmitNum.Text.Trim();
                if (txtEnderEmitCompl.Text != "")
                {
                    nota.emit.Xcpl = txtEnderEmitCompl.Text.Trim();
                }
                nota.emit.Xbairro = txtEnderEmitXbairro.Text.Trim();
                nota.emit.Cmun = txtEnderEmitCmun.Text.Trim();
                nota.emit.Xmun = txtEnderEmitXmun.Text.Trim();
                nota.emit.Uf = txtEnderEmitUF.Text.Trim();
                nota.emit.Cpais = txtEnderEmitCpais.Text.Trim();
                nota.emit.Xpais = txtEnderEmitXpais.Text.Trim();
                nota.emit.Cep = mtbEnderEmitCep.Text.Trim();
                nota.emit.Fone = mtbEnderEmitFone.Text.Trim();

                switch (cmbCRT.SelectedIndex) // NFe_2.0
                {
                    case 0: nota.emit.CRT = 1;
                        break;

                    case 1: nota.emit.CRT = 2;
                        break;

                    case 2: nota.emit.CRT = 3;
                        break;
                }
                #endregion

                #region Destinatário
                if (mtbCpfCnpjDest.Mask.Equals("00.000.000/0000-00") || mtbCpfCnpjDest.Text.ToString().ToUpper().Equals("EXTERIOR"))
                {
                    nota.dest.Cnpj = mtbCpfCnpjDest.Text.Trim();
                }
                else
                {
                    nota.dest.Cpf = mtbCpfCnpjDest.Text.Trim();
                }

                nota.dest.Xnome = (Acesso.TP_AMB == 2 ? "NF-E EMITIDA EM AMBIENTE DE HOMOLOGACAO - SEM VALOR FISCAL"
                    : txtXnomeDest.Text.Trim());

                nota.dest.Ie = txtIEDest.Text.Trim();
                nota.dest.Isuf = txtISUFDest.Text.Trim();

                //Endereço

                nota.dest.Xlgr = txtEnderDestXlgr.Text.Trim();
                nota.dest.Nro = txtEnderDestNro.Text.Trim();
                nota.dest.Xcpl = txtEnderDestCpl.Text.Trim(); //OS_26347
                nota.dest.Xbairro = txtEnderDestXbairro.Text.Trim();
                nota.dest.Cmun = txtEnderDestCmun.Text.Trim();
                nota.dest.Xmun = txtEnderDestXmun.Text.Trim();
                nota.dest.Uf = txtEnderDestUF.Text.Trim();
                nota.dest.Cpais = txtEnderDestCpais.Text.Trim();
                nota.dest.Xpais = txtEnderDestXpais.Text.Trim();
                nota.dest.Cep = mtbEnderDestCEP.Text.Trim();
                nota.dest.Fone = mtbEnderDestFone.Text.Trim();
                nota.dest.email = txtEmaildest.Text.Trim(); // NFe_2.0
                #endregion

                #region Endereço de Entrega
                if (txtEndEntXlgr.Text != "")
                {

                    if (mtbCpfCnpjDest.Mask.Equals("00.000.000/0000-00") || mtbCpfCnpjDest.Text.ToString().ToUpper().Equals("EXTERIOR"))
                    {
                        nota.endent.Cnpj = mtbCpfCnpjDest.Text.Trim();
                    }
                    else
                    {
                        nota.endent.Cpf = mtbCpfCnpjDest.Text.Trim();
                    }
                    nota.endent.Xlgr = txtEndEntXlgr.Text.Trim();
                    nota.endent.Nro = txtEndEntNro.Text.Trim();
                    nota.endent.Cmun = txtEndEntCmun.Text.Trim();
                    nota.endent.Xmun = txtEndEntXmun.Text.Trim();
                    nota.endent.Uf = txtEndEntUF.Text.Trim();
                    nota.endent.Xbairro = txtEndEntXbairro.Text.Trim(); //0S_25185
                    nota.endent.Xcpl = txtEndEntCpl.Text.Trim();//0S_25185
                }
                #endregion

                #region Detatalhes

                #endregion

                #region Totais
                nota.total.belIcmstot.Vbc = nudVBC.Value;
                nota.total.belIcmstot.Vicms = nudVICMS.Value;
                nota.total.belIcmstot.Vbcst = nudVBCICMSST.Value;
                nota.total.belIcmstot.Vst = nudVST.Value;
                nota.total.belIcmstot.Vprod = nudVProd.Value;
                nota.total.belIcmstot.Vfrete = nudVFrete.Value;
                nota.total.belIcmstot.Vseg = nudVSEG.Value;
                nota.total.belIcmstot.Vdesc = nudVDesc.Value;
                nota.total.belIcmstot.Vii = nudVII.Value;
                nota.total.belIcmstot.Vipi = nudVIPI.Value;
                nota.total.belIcmstot.Vpis = nudVPIS.Value;
                nota.total.belIcmstot.Vcofins = nudVCOFINS.Value;
                nota.total.belIcmstot.Voutro = nudVOutro.Value;
                nota.total.belIcmstot.Vnf = nudVNF.Value;
                nota.total.belIcmstot.vTotTrib = nudvTotTrib.Value;
                //Fim - Totais

                //ISSQNtot
                if (flpISSNQ.Enabled != false)
                {
                    nota.total.belIssqntot.Vserv = nudVServ.Value;
                    nota.total.belIssqntot.Vbc = nudVBCISS.Value;
                    nota.total.belIssqntot.Viss = nudVISS.Value;
                    nota.total.belIssqntot.Vpis = nudVPISISS.Value;
                    nota.total.belIssqntot.Vcofins = nudVCOFINSISS.Value;
                }
                //Fin - ISSQNtot;

                //retTrib
                if (flpRetTrib.Enabled != false)
                {
                    belRetTrib objRetTrib = new belRetTrib();

                    objRetTrib.Vretpis = nudVPISRet.Value;
                    objRetTrib.Vretcofins = nudVCOFINSRet.Value;
                    objRetTrib.Vretcsll = nudVCSLLRet.Value;
                    objRetTrib.Vbcretprev = nudVBCIRRFRet.Value;
                    objRetTrib.Virrf = nudVIRRFRet.Value;
                    objRetTrib.Vbcirrf = nudVBCIRRFRet.Value;
                    objRetTrib.Vbcretprev = nudVBCRetPrev.Value;
                    objRetTrib.Vretprev = nudVRetPrev.Value;
                }
                //Fim - retTrib
                #endregion

                #region Transporte
                switch (cbxModFrete.SelectedIndex) //Nfe_2.0
                {
                    case 0: nota.transp.Modfrete = "0";
                        break;

                    case 1: nota.transp.Modfrete = "1";
                        break;

                    case 2: nota.transp.Modfrete = "2";
                        break;

                    case 3: nota.transp.Modfrete = "9";
                        break;
                }
                //Transportadora               
                if (cbxPessoaTranp.SelectedIndex == 1)
                {
                    if (mtbCPJCNPJTransp.Text.Trim() != "")
                    {
                        nota.transp.belTransportadora.Cnpj = mtbCPJCNPJTransp.Text.Trim();
                    }
                }
                else
                {
                    if (mtbCPJCNPJTransp.Text.Trim() != "")
                    {
                        nota.transp.belTransportadora.Cpf = mtbCPJCNPJTransp.Text.Trim();
                    }
                }

                if (txtXnomeTransp.Text.Trim() != "")
                {
                    nota.transp.belTransportadora.Xnome = txtXnomeTransp.Text.Trim();
                }
                if (txtIETransp.Text.Trim() != "")
                {
                    nota.transp.belTransportadora.Ie = txtIETransp.Text.Trim();
                }
                if (txtEnderTransp.Text.Trim() != "")
                {
                    nota.transp.belTransportadora.Xender = txtEnderTransp.Text.Trim();
                }
                if (txtUFTransp.Text.Trim() != "")
                {
                    nota.transp.belTransportadora.Uf = txtUFTransp.Text.Trim();
                }
                if (txtXmunTransp.Text.Trim() != "")
                {
                    nota.transp.belTransportadora.Xmun = txtXmunTransp.Text.Trim();
                }
                //Fim - Transportadora

                //VeicTransp
                if (!mtbPlacaVeicTransp.Text.Trim().Equals(""))
                {
                    nota.transp.belVeicTransp.Placa = mtbPlacaVeicTransp.Text.Trim();
                    nota.transp.belVeicTransp.Uf = txtUFVeicTransp.Text.Trim();
                    if (txtRNTCVeicTransp.Text.Trim() != "")
                    {
                        nota.transp.belVeicTransp.Rntc = txtRNTCVeicTransp.Text.Trim();
                    }
                }
                //Fim -  VeicTransp

                //Reboque
                if (!mtbPlacaReboque.Text.Trim().Equals(""))
                {
                    nota.transp.belReboque.Placa = mtbPlacaReboque.Text.Trim();
                    nota.transp.belReboque.Uf = txtUFReboque.Text.Trim();
                    nota.transp.belReboque.Rntc = txtRNTCReboque.Text.Trim();
                }
                //Fim - Reboque 

                //RetTransp
                if (nudVServTransp.Value > 0)
                {
                    nota.transp.belRetTransp.Vbvret = nudVBCICMSTransp.Value;
                    nota.transp.belRetTransp.Vserv = nudVServTransp.Value;
                    nota.transp.belRetTransp.Picmsret = nudPICMSTRetTransp.Value;
                    nota.transp.belRetTransp.Vicmsret = nudVICMSRet.Value;
                    nota.transp.belRetTransp.Cmunfg = txtCmunFGTransp.Text.Trim();
                    nota.transp.belRetTransp.Cfop = txtCFOPTransp.Text.Trim();
                }
                //Fim - RetTransp

                if (nudQvol.Value > 0)
                {
                    nota.transp.belVol.Esp = txtEsp.Text.Trim();
                    nota.transp.belVol.Marca = txtMarca.Text.Trim();
                    if (txtNVol.Text != "")
                    {
                        nota.transp.belVol.Nvol = txtNVol.Text;
                    }
                    nota.transp.belVol.PesoB = nudPesoB.Value;
                    nota.transp.belVol.PesoL = nudPesoL.Value;
                    nota.transp.belVol.Qvol = nudQvol.Value;
                }
                #endregion

                #region Cobrança

                if (nota.cobr.Fat != null)
                {
                    nota.cobr.Fat.Nfat = txtNFat.Text.Trim();
                    nota.cobr.Fat.Vorig = nudVOrigFat.Value;
                    nota.cobr.Fat.Vdesc = nudVDescFat.Value;
                    nota.cobr.Fat.Vliq = nudVLiqFat.Value;
                    nota.cobr.Fat.belDup = bsDuplicatas.List as List<belDup>;
                }

                //if (bsDuplicatas.Count > 0)
                //{
                //    List<belDup> lObjDup = (List<belDup>)bsDuplicatas.List;

                //    for (int i = 0; i < dgvDup.RowCount; i++)
                //    {
                //        belDup objdup = new belDup();
                //        objdup.Ndup = Convert.ToString(dgvDup[0, i].Value);
                //        objdup.Dvenc = Convert.ToDateTime(dgvDup[1, i].Value);
                //        objdup.Vdup = Convert.ToDecimal(dgvDup[2, i].Value);
                //        lObjDup.Add(objdup);
                //    }
                //    nota.cobr.Fat.belDup = lObjDup;
                //}

                #endregion

                #region Inf Adicionais
                if (txtInfAdic.Text != "")
                {
                    nota.infAdic.Infcpl = null;
                    nota.infAdic.Infcpl = txtInfAdic.Text.Replace(Environment.NewLine, "").Trim().TrimEnd();
                }
                #endregion

                #region exporta
                if (txtUFembarque.Text != "")
                {
                    nota.exporta.Ufembarq = txtUFembarque.Text;
                }
                if (txtLocalEmbarque.Text != "")
                {
                    nota.exporta.Xlocembarq = txtLocalEmbarque.Text;
                }
                #endregion

            }
            catch (Exception ex)
            {
                new HLPexception(ex);
            }

        }
        private bool VerificaCampos()
        {
            belInfNFe nota = (belInfNFe)bsNotas.Current;
            int Erros = 0;
            bool Retorno = true;

            #region Identificacao

            Erros += belValidaCampos.Validar(flpIdentificacao.Controls, false);

            #endregion

            #region Emitente

            Erros += belValidaCampos.Validar(flpDadosEmit.Controls, false);
            Erros += belValidaCampos.Validar(flpEndEmit.Controls, false);


            #endregion

            #region Destinatario

            Erros += belValidaCampos.Validar(flpDadosDest.Controls, false);
            Erros += belValidaCampos.Validar(flpEndDest.Controls, false);

            #endregion

            #region Endereço de Entrega

            if (nota.endent.Cnpj != null)
            {
                Erros += belValidaCampos.Validar(flpEndEntrega.Controls, false);
            }


            #endregion

            #region Total

            Erros += belValidaCampos.Validar(flptotalGeral.Controls, false);
            Erros += belValidaCampos.Validar(flpRetTrib.Controls, false);
            Erros += belValidaCampos.Validar(flpISSNQ.Controls, false);

            #endregion

            #region Transporte
            Erros += belValidaCampos.Validar(flpTransp.Controls, false);

            if (nota.transp.belRetTransp.Vserv > 0)
            {
                Erros += belValidaCampos.Validar(flpRetICMS.Controls, false);
            }
            if (nota.transp.belVeicTransp.Placa != null)
            {
                Erros += belValidaCampos.Validar(flpVeicTransp.Controls, false);
            }
            if (nota.transp.belReboque.Placa != null)
            {
                Erros += belValidaCampos.Validar(flpReboque.Controls, false);
            }
            #endregion

            if (Erros > 0)
            {
                Retorno = false;
            }
            return Retorno;
        }
        private bool ValidaNotas()
        {
            bsNotas.MoveFirst();
            bool Retorno = true;
            belValidaCampos.LimpaErros();

            for (int i = 0; i < bsNotas.List.Count; i++)
            {
                belInfNFe nota = (belInfNFe)bsNotas.Current;
                PopulaForm();

                #region Identificacao
                belValidaCampos.ValidarTodosDocumentos(flpIdentificacao.Controls, txtNNF.Text);
                #endregion

                #region Emitente
                belValidaCampos.ValidarTodosDocumentos(flpDadosEmit.Controls, txtNNF.Text);
                belValidaCampos.ValidarTodosDocumentos(flpEndEmit.Controls, txtNNF.Text);
                #endregion

                #region Destinatario
                belValidaCampos.ValidarTodosDocumentos(flpDadosDest.Controls, txtNNF.Text);
                belValidaCampos.ValidarTodosDocumentos(flpEndDest.Controls, txtNNF.Text);
                #endregion

                #region Endereço de Entrega

                if (nota.endent.Cnpj != null)
                {
                    belValidaCampos.ValidarTodosDocumentos(flpEndEntrega.Controls, txtNNF.Text);
                }
                #endregion

                #region Total
                belValidaCampos.ValidarTodosDocumentos(flptotalGeral.Controls, txtNNF.Text);
                belValidaCampos.ValidarTodosDocumentos(flpRetTrib.Controls, txtNNF.Text);
                belValidaCampos.ValidarTodosDocumentos(flpISSNQ.Controls, txtNNF.Text);
                #endregion

                #region Transporte
                belValidaCampos.ValidarTodosDocumentos(flpTransp.Controls, txtNNF.Text);
                if (nudVServTransp.Value > 0)
                {
                    belValidaCampos.ValidarTodosDocumentos(flpRetICMS.Controls, txtNNF.Text);
                }
                if (!String.IsNullOrEmpty(nota.transp.belVeicTransp.Placa))
                {
                    belValidaCampos.ValidarTodosDocumentos(flpVeicTransp.Controls, txtNNF.Text);
                }
                if (!String.IsNullOrEmpty(nota.transp.belReboque.Placa))
                {
                    belValidaCampos.ValidarTodosDocumentos(flpReboque.Controls, txtNNF.Text);
                }
                #endregion

                #region InfAdic

                if (nota.infAdic.Infcpl != "")
                {
                    belValidaCampos.ValidarTodosDocumentos(panelInfAdic.Controls, txtNNF.Text);
                }

                #endregion

                #region Exporta
                belValidaCampos.ValidarTodosDocumentos(flExporta.Controls, txtNNF.Text);
                #endregion
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
        private void CarregaAbaICMSitens(belIcms icms)
        {
            try
            {
                DesabilitaComponentesConatiner(flICMS.Controls);


                string sEmpresaSuperSimples = daoDet.VerificaEmpresaSimplesNac();
                bool bCstSuperSimples = Util.VerificaNovaST(icms.sCst);

                if (bCstSuperSimples == true && sEmpresaSuperSimples == "S" )
                {
                    #region CTS_NOVAS
                    switch ((Util.RetornaSTnovaAserUsada(icms.sCst)))
                    {
                        case "101":
                            {
                                cbxOrigICMSitens.cbx.SelectedIndex = Convert.ToInt16(icms.belICMSSN101.orig);
                                cbxCSTicmsItens.SelectedValue = icms.belICMSSN101.CSOSN;
                                nudpCredSN.Value = icms.belICMSSN101.pCredSN;
                                nudpCredSN.Visible = true;
                                nudvCredICMSSN.Value = icms.belICMSSN101.vCredICMSSN;
                                nudvCredICMSSN.Visible = true;
                            }
                            break;

                        case "102":
                            {
                                cbxOrigICMSitens.cbx.SelectedIndex = Convert.ToInt16(icms.belICMSSN102.orig);
                                cbxCSTicmsItens.SelectedValue = icms.belICMSSN102.CSOSN;
                            }
                            break;
                        case "201":
                            {
                                cbxOrigICMSitens.cbx.SelectedIndex = Convert.ToInt16(icms.belICMSSN201.orig);
                                cbxCSTicmsItens.SelectedValue = icms.belICMSSN201.CSOSN;
                                cbxmodBCSTicmsItens.SelectedIndex = Convert.ToInt32(icms.belICMSSN201.modBCST);
                                cbxmodBCSTicmsItens.Visible = true;
                                nudpMVASTicmsItens.Value = icms.belICMSSN201.pMVAST;
                                nudpMVASTicmsItens.Visible = true;
                                nudpRedBCSTicmsItens.Value = icms.belICMSSN201.pRedBCST;
                                nudpRedBCSTicmsItens.Visible = true;
                                nudvBCSTicmsItens.Value = icms.belICMSSN201.vBCST;
                                nudvBCSTicmsItens.Visible = true;
                                nudpICMSSTicmsItens.Value = icms.belICMSSN201.pICMSST;
                                nudpICMSSTicmsItens.Visible = true;
                                nudvICMSSTicmsItens.Value = icms.belICMSSN201.vICMSST;
                                nudvICMSSTicmsItens.Visible = true;
                                nudpCredSN.Value = icms.belICMSSN201.pCredSN;
                                nudpCredSN.Visible = true;
                                nudvCredICMSSN.Value = icms.belICMSSN201.vCredICMSSN;
                                nudvCredICMSSN.Visible = true;
                            }
                            break;
                        case "500":
                            {
                                cbxOrigICMSitens.cbx.SelectedIndex = Convert.ToInt16(icms.belICMSSN500.orig);
                                cbxCSTicmsItens.SelectedValue = icms.belICMSSN500.CSOSN;
                                nudvBCSTRetIcmsItens.Value = icms.belICMSSN500.vBCSTRet;
                                nudvBCSTRetIcmsItens.Visible = true;
                                nudvICMSSTRetIcmsItens.Value = icms.belICMSSN500.vICMSSTRet;
                                nudvICMSSTRetIcmsItens.Visible = true;
                            }
                            break;
                        case "900":
                            {
                                cbxOrigICMSitens.cbx.SelectedIndex = Convert.ToInt16(icms.belICMSSN900.orig);
                                cbxCSTicmsItens.SelectedValue = icms.belICMSSN900.CSOSN;
                                cbxmodBCicmsItens.SelectedIndex = Convert.ToInt32(icms.belICMSSN900.modBC);
                                cbxmodBCicmsItens.Visible = true;
                                nudvBCicmsItens.Value = Convert.ToDecimal(icms.belICMSSN900.vBC);
                                nudvBCicmsItens.Visible = true;
                                nudpRedBCicmsItens.Value = Convert.ToDecimal(icms.belICMSSN900.pRedBC);
                                nudpRedBCicmsItens.Visible = true;
                                nudpICMSitens.Value = Convert.ToDecimal(icms.belICMSSN900.pICMS);
                                nudpICMSitens.Visible = true;
                                nudvICMSicmsItens.Value = Convert.ToDecimal(icms.belICMSSN900.vICMS);
                                nudvICMSicmsItens.Visible = true;
                                cbxmodBCSTicmsItens.SelectedIndex = Convert.ToInt32(icms.belICMSSN900.modBCST);
                                cbxmodBCSTicmsItens.Visible = true;
                                nudpMVASTicmsItens.Value = Convert.ToDecimal(icms.belICMSSN900.pMVAST);
                                nudpMVASTicmsItens.Visible = true;
                                nudpRedBCSTicmsItens.Value = Convert.ToDecimal(icms.belICMSSN900.pRedBCST);
                                nudpRedBCSTicmsItens.Visible = true;
                                nudvBCSTicmsItens.Value = Convert.ToDecimal(icms.belICMSSN900.vBCST);
                                nudvBCSTicmsItens.Visible = true;
                                nudpICMSSTicmsItens.Value = Convert.ToDecimal(icms.belICMSSN900.pICMSST);
                                nudpICMSSTicmsItens.Visible = true;
                                nudvICMSSTicmsItens.Value = Convert.ToDecimal(icms.belICMSSN900.vICMSST);
                                nudvICMSSTicmsItens.Visible = true;
                                nudpCredSN.Value = Convert.ToDecimal(icms.belICMSSN900.pCredSN);
                                nudpCredSN.Visible = true;
                                nudvCredICMSSN.Value = Convert.ToDecimal(icms.belICMSSN900.vCredICMSSN);
                                nudvCredICMSSN.Visible = true;
                            }
                            break;
                    }
                    #endregion
                   
                }
                else
                {
                    #region CST_ANTIGAS
                    switch (icms.sCst.Substring(1, 2))
                    {
                        case "00":
                            {
                                cbxOrigICMSitens.cbx.SelectedIndex = Convert.ToInt16(icms.belIcms00.Orig);
                                cbxCSTicmsItens.SelectedValue = icms.belIcms00.Cst;
                                cbxmodBCicmsItens.SelectedIndex = Convert.ToInt16(icms.belIcms00.Modbc);
                                cbxmodBCicmsItens.Visible = true;
                                nudvBCicmsItens.Value = icms.belIcms00.Vbc;
                                nudvBCicmsItens.Visible = true;
                                nudpICMSitens.Value = icms.belIcms00.Picms;
                                nudpICMSitens.Visible = true;
                                nudvICMSicmsItens.Value = icms.belIcms00.Vicms;
                                nudvICMSicmsItens.Visible = true;
                                break;
                            }
                        case "10":
                            {
                                cbxOrigICMSitens.cbx.SelectedIndex = Convert.ToInt16(icms.belIcms10.Orig);
                                cbxCSTicmsItens.SelectedValue = icms.belIcms10.Cst;
                                cbxmodBCicmsItens.SelectedIndex = Convert.ToInt16(icms.belIcms10.Modbc);
                                cbxmodBCicmsItens.Visible = true;
                                nudvBCicmsItens.Value = icms.belIcms10.Vbc;
                                nudvBCicmsItens.Visible = true;
                                nudpICMSitens.Value = icms.belIcms10.Picms;
                                nudpICMSitens.Visible = true;
                                nudvICMSicmsItens.Value = icms.belIcms10.Vicms;
                                nudvICMSicmsItens.Visible = true;
                                cbxmodBCSTicmsItens.SelectedIndex = Convert.ToInt32(icms.belIcms10.Modbcst);
                                cbxmodBCSTicmsItens.Visible = true;
                                nudpMVASTicmsItens.Value = icms.belIcms10.Pmvast;
                                nudpMVASTicmsItens.Visible = true;
                                nudpRedBCSTicmsItens.Value = icms.belIcms10.Predbcst;
                                nudpRedBCSTicmsItens.Visible = true;
                                nudvBCSTicmsItens.Value = icms.belIcms10.Vbcst;
                                nudvBCSTicmsItens.Visible = true;
                                nudpICMSSTicmsItens.Value = icms.belIcms10.Picmsst;
                                nudpICMSSTicmsItens.Visible = true;
                                nudvICMSSTicmsItens.Value = icms.belIcms10.Vicmsst;
                                nudvICMSSTicmsItens.Visible = true;
                                break;
                            }
                        case "20":
                            {
                                cbxOrigICMSitens.cbx.SelectedIndex = Convert.ToInt16(icms.belIcms20.Orig);
                                cbxCSTicmsItens.SelectedValue = icms.belIcms20.Cst;
                                cbxmodBCicmsItens.SelectedIndex = Convert.ToInt16(icms.belIcms20.Modbc);
                                cbxmodBCicmsItens.Visible = true;
                                nudpRedBCSTicmsItens.Value = icms.belIcms20.Predbc;
                                nudpRedBCSTicmsItens.Visible = true;
                                nudvBCicmsItens.Value = icms.belIcms20.Vbc;
                                nudvBCicmsItens.Visible = true;
                                nudpICMSitens.Value = icms.belIcms20.Picms;
                                nudpICMSitens.Visible = true;
                                nudvICMSicmsItens.Value = icms.belIcms20.Vicms;
                                nudvICMSicmsItens.Visible = true;
                                break;
                            }
                        case "30":
                            {
                                cbxOrigICMSitens.cbx.SelectedIndex = Convert.ToInt16(icms.belIcms30.Orig);
                                cbxCSTicmsItens.SelectedValue = icms.belIcms30.Cst;
                                cbxmodBCSTicmsItens.SelectedIndex = Convert.ToInt32(icms.belIcms30.Modbcst);
                                cbxmodBCSTicmsItens.Visible = true;
                                nudpMVASTicmsItens.Value = icms.belIcms30.Pmvast;
                                nudpMVASTicmsItens.Visible = true;
                                nudpRedBCSTicmsItens.Value = icms.belIcms30.Predbcst;
                                nudpRedBCSTicmsItens.Visible = true;
                                nudvBCSTicmsItens.Value = icms.belIcms30.Vbcst;
                                nudvBCSTicmsItens.Visible = true;
                                nudpICMSSTicmsItens.Value = icms.belIcms30.Picmsst;
                                nudpICMSSTicmsItens.Visible = true;
                                nudvICMSSTicmsItens.Value = icms.belIcms30.Vicmsst;
                                nudvICMSSTicmsItens.Visible = true;
                                break;
                            }
                        case "40":
                            {
                                cbxOrigICMSitens.cbx.SelectedIndex = Convert.ToInt16(icms.belIcms40.Orig);
                                cbxCSTicmsItens.SelectedValue = icms.belIcms40.Cst;
                                nudvICMSicmsItens.Value = icms.belIcms40.Vicms;
                                nudvICMSicmsItens.Visible = true;
                                cbxmotDesICMS.SelectedValue = icms.belIcms40.motDesICMS.ToString();
                                cbxmotDesICMS.Visible = true;
                                break;
                            }
                        case "41":
                            {
                                cbxOrigICMSitens.cbx.SelectedIndex = Convert.ToInt16(icms.belIcms40.Orig);
                                cbxCSTicmsItens.SelectedValue = icms.belIcms40.Cst;
                                nudvICMSicmsItens.Value = icms.belIcms40.Vicms;
                                nudvICMSicmsItens.Visible = true;
                                cbxmotDesICMS.cbx.SelectedValue = icms.belIcms40.motDesICMS.ToString();
                                cbxmotDesICMS.Visible = true;
                                break;
                            }
                        case "50":
                            {
                                cbxOrigICMSitens.cbx.SelectedIndex = Convert.ToInt16(icms.belIcms40.Orig);
                                cbxCSTicmsItens.SelectedValue = icms.belIcms40.Cst;
                                nudvICMSicmsItens.Value = icms.belIcms40.Vicms;
                                cbxmotDesICMS.Visible = true;
                                cbxmotDesICMS.SelectedValue = icms.belIcms40.motDesICMS.ToString();
                                cbxmotDesICMS.Visible = true;
                                break;
                            }
                        case "51":
                            {
                                cbxOrigICMSitens.cbx.SelectedIndex = Convert.ToInt16(icms.belIcms51.Orig);
                                cbxCSTicmsItens.SelectedValue = icms.belIcms51.Cst;
                                cbxmodBCicmsItens.SelectedIndex = Convert.ToInt16(icms.belIcms51.Modbc);
                                cbxmodBCicmsItens.Visible = true;
                                nudpRedBCicmsItens.Value = icms.belIcms51.Predbc;
                                nudpRedBCicmsItens.Visible = true;
                                nudvBCicmsItens.Value = icms.belIcms51.Vbc;
                                nudvBCicmsItens.Visible = true;
                                nudpICMSitens.Value = icms.belIcms51.Picms;
                                nudpICMSitens.Visible = true;
                                nudvICMSicmsItens.Value = icms.belIcms51.Vicms;
                                nudvICMSicmsItens.Visible = true;
                                break;
                            }
                        case "60":
                            {
                                cbxOrigICMSitens.cbx.SelectedIndex = Convert.ToInt16(icms.belIcms60.Orig);
                                cbxCSTicmsItens.SelectedValue = icms.belIcms60.Cst;
                                nudvBCSTRetIcmsItens.Value = icms.belIcms60.Vbcstret;
                                nudvBCSTRetIcmsItens.Visible = true;
                                nudvICMSSTRetIcmsItens.Value = icms.belIcms60.Vicmsstret;
                                nudvICMSSTRetIcmsItens.Visible = true;
                                break;
                            }

                        case "70":
                            {
                                cbxOrigICMSitens.cbx.SelectedIndex = Convert.ToInt16(icms.belIcms70.Orig);
                                cbxCSTicmsItens.SelectedValue = icms.belIcms70.Cst;
                                cbxmodBCicmsItens.SelectedIndex = Convert.ToInt16(icms.belIcms70.Modbc);
                                cbxmodBCicmsItens.Visible = true;
                                nudpRedBCicmsItens.Value = icms.belIcms70.Predbc;
                                nudpRedBCicmsItens.Visible = true;
                                nudvBCicmsItens.Value = icms.belIcms70.Vbc;
                                nudvBCicmsItens.Visible = true;
                                nudpICMSitens.Value = icms.belIcms70.Picms;
                                nudpICMSitens.Visible = true;
                                nudvICMSicmsItens.Value = icms.belIcms70.Vicms;
                                nudvICMSicmsItens.Visible = true;
                                cbxmodBCSTicmsItens.SelectedIndex = Convert.ToInt32(icms.belIcms70.Modbcst);
                                cbxmodBCSTicmsItens.Visible = true;
                                nudpMVASTicmsItens.Value = icms.belIcms70.Pmvast;
                                nudpMVASTicmsItens.Visible = true;
                                nudpRedBCSTicmsItens.Value = icms.belIcms70.Predbcst;
                                nudpRedBCSTicmsItens.Visible = true;
                                nudvBCSTicmsItens.Value = icms.belIcms70.Vbcst;
                                nudvBCSTicmsItens.Visible = true;
                                nudpICMSSTicmsItens.Value = icms.belIcms70.Picmsst;
                                nudpICMSSTicmsItens.Visible = true;
                                nudvICMSSTicmsItens.Value = icms.belIcms70.Vicmsst;
                                nudvICMSSTicmsItens.Visible = true;
                                break;
                            }

                        case "90":
                            {
                                cbxOrigICMSitens.cbx.SelectedIndex = Convert.ToInt16(icms.belIcms90.Orig);
                                cbxCSTicmsItens.SelectedValue = icms.belIcms90.Cst;
                                cbxmodBCicmsItens.SelectedIndex = Convert.ToInt16(icms.belIcms90.Modbc);
                                cbxmodBCicmsItens.Visible = true;
                                nudpRedBCicmsItens.Value = icms.belIcms90.Predbc;
                                nudpRedBCicmsItens.Visible = true;
                                nudvBCicmsItens.Value = icms.belIcms90.Vbc;
                                nudvBCicmsItens.Visible = true;
                                nudpICMSitens.Value = icms.belIcms90.Picms;
                                nudpICMSitens.Visible = true;
                                nudvICMSicmsItens.Value = icms.belIcms90.Vicms;
                                nudvICMSicmsItens.Visible = true;
                                cbxmodBCSTicmsItens.SelectedIndex = Convert.ToInt32(icms.belIcms90.Modbcst);
                                cbxmodBCSTicmsItens.Visible = true;
                                nudpMVASTicmsItens.Value = icms.belIcms90.Pmvast;
                                nudpMVASTicmsItens.Visible = true;
                                nudpRedBCSTicmsItens.Value = icms.belIcms90.Predbcst;
                                nudpRedBCSTicmsItens.Visible = true;
                                nudvBCSTicmsItens.Value = icms.belIcms90.Vbcst;
                                nudvBCSTicmsItens.Visible = true;
                                nudpICMSSTicmsItens.Value = icms.belIcms90.Picmsst;
                                nudpICMSSTicmsItens.Visible = true;
                                nudvICMSSTicmsItens.Value = icms.belIcms90.Vicmsst;
                                cbxOrigICMSitens.Visible = true;
                                break;
                            }
                    }

                    #endregion
                 
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void CarregaAbaIPIitens(belIpi ipi)
        {
            try
            {
                DesabilitaComponentesConatiner(flIPI.Controls);
                cbxCSTipi.cbx.SelectedValue = ipi.cst;
                cbxCSTipi.Visible = true;
                if ((ipi.cst.Equals("00")) || (ipi.cst.Equals("49")) || (ipi.cst.Equals("50")) || (ipi.cst.Equals("99")))
                {
                    nudvBCipiItens.Value = ipi.belIpitrib.Vbc;
                    nudvBCipiItens.Visible = true;
                    nudpIPIitens.Value = ipi.belIpitrib.Pipi;
                    nudpIPIitens.Visible = true;
                    nudqUnidipi.Value = Convert.ToDecimal(ipi.belIpitrib.Qunid);
                    nudqUnidipi.Visible = true;
                    nudvUnidipi.Value = ipi.belIpitrib.Vunid;
                    nudvUnidipi.Visible = true;
                    nudvIPIitens.Value = ipi.belIpitrib.Vipi;
                    nudvIPIitens.Visible = true;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        private void CarregaAbaII(belIi ii)
        {
            try
            {
                if (ii != null)
                {
                    nudvBCii.Value = ii.Vbc;
                    nudvDespAdu.Value = ii.Vdespadu;
                    nudvIIitens.Value = ii.Vii;
                    nudvIOFii.Value = ii.Viof;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void CarregaAbaCombustivel(belcomb comb)
        {
            try
            {
                if (comb != null)
                {
                    nudCodigoANP.Value = comb.cProdANP;
                    txtUFcons.Text = comb.UFCons;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void CarregaAbaPISitens(belPis pis)
        {
            try
            {
                DesabilitaComponentesConatiner(flPIS.Controls);
                cbxCSTpis.cbx.SelectedValue = pis.cst;
                cbxCSTpis.Visible = true;
                if (Convert.ToInt16(pis.cst) <= 2)
                {
                    nudvBCpis.Value = pis.belPisaliq.Vbc;
                    nudvBCpis.Visible = true;
                    nudpPISitens.Value = pis.belPisaliq.Ppis;
                    nudpPISitens.Visible = true;
                    nudvPISitens.Value = pis.belPisaliq.Vpis;
                    nudvPISitens.Visible = true;
                }
                else if (Convert.ToInt16(pis.cst) > 9)
                {
                    nudvBCpis.Value = pis.belPisoutr.Vbc;
                    nudvBCpis.Visible = true;
                    nudpPISitens.Value = pis.belPisoutr.Ppis;
                    nudpPISitens.Visible = true;
                    nudvPISitens.Value = pis.belPisoutr.Vpis;
                    nudvPISitens.Visible = true;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        private void CarregaAbaCofinsitens(belCofins cofins)
        {
            try
            {
                DesabilitaComponentesConatiner(flCOFINS.Controls);
                cbxCSTcofins.cbx.SelectedValue = cofins.cst;
                cbxCSTcofins.Visible = true;
                if (Convert.ToInt16(cofins.cst) <= 2)
                {
                    nudvBCcofins.Value = cofins.belCofinsaliq.Vbc;
                    nudvBCcofins.Visible = true;
                    nudpCOFINSitens.Value = cofins.belCofinsaliq.Pcofins;
                    nudpCOFINSitens.Visible = true;
                    nudvCOFINSitens.Value = cofins.belCofinsaliq.Vcofins;
                    nudvCOFINSitens.Visible = true;
                }
                else if (Convert.ToInt16(cofins.cst) > 9)
                {
                    nudvBCcofins.Value = cofins.belCofinsoutr.Vbc;
                    nudvBCcofins.Visible = true;
                    nudpCOFINSitens.Value = cofins.belCofinsoutr.Pcofins;
                    nudpCOFINSitens.Visible = true;
                    nudvCOFINSitens.Value = cofins.belCofinsoutr.Vcofins;
                    nudvCOFINSitens.Visible = true;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        private void CarregaAbaISSQN(belIss iss)
        {
            try
            {
                if (iss != null)
                {
                    nudvBCissItens.Value = iss.Vbc;
                    nudvAliqissItens.Value = iss.Valiq;
                    nudvISSQNitens.Value = iss.Vissqn;
                    txtcMunFGiss.Text = iss.Cmunfg;
                    txtcListServ.Text = iss.Clistserv.ToString();
                    cbxcSitTribIss.SelectedValue = iss.cSitTrib;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void CarregaComboBoxST()
        {
            cbxCSTicmsItens.cbx.DisplayMember = "descricao";
            cbxCSTicmsItens.cbx.ValueMember = "codigo";
            cbxCSTipi.cbx.DisplayMember = cbxCSTicmsItens.cbx.DisplayMember;
            cbxCSTipi.cbx.ValueMember = cbxCSTicmsItens.cbx.ValueMember;
            cbxCSTpis.cbx.DisplayMember = cbxCSTicmsItens.cbx.DisplayMember;
            cbxCSTpis.cbx.ValueMember = cbxCSTicmsItens.cbx.ValueMember;
            cbxCSTcofins.cbx.DisplayMember = cbxCSTicmsItens.cbx.DisplayMember;
            cbxCSTcofins.cbx.ValueMember = cbxCSTicmsItens.cbx.ValueMember;
            cbxcSitTribIss.cbx.DisplayMember = cbxCSTicmsItens.cbx.DisplayMember;
            cbxcSitTribIss.cbx.ValueMember = cbxCSTicmsItens.cbx.ValueMember;
            cbxmotDesICMS.cbx.DisplayMember = cbxCSTicmsItens.cbx.DisplayMember;
            cbxmotDesICMS.cbx.ValueMember = cbxCSTicmsItens.cbx.ValueMember;

            cbxmotDesICMS.cbx.DataSource = belImposto.CarregaMotivoDesoneracao();
            cbxcSitTribIss.cbx.DataSource = belImposto.CarregaISSQNcomboBox();
            cbxcSitTribIss.cbx.SelectedIndex = 0;
            cbxCSTcofins.cbx.DataSource = belImposto.CarregaPIS_COFINScomboBox();
            cbxCSTpis.cbx.DataSource = belImposto.CarregaPIS_COFINScomboBox();
            cbxCSTipi.cbx.DataSource = belImposto.CarregaIPIcomboBox();
            cbxCSTicmsItens.cbx.DataSource = belImposto.CarregaCSTcomboBox();
        }
        private void SalvaItensGridProd()
        {
            try
            {
                #region Detalhes Novo
                #region ICMS
                belImposto imposto = (bsNotas.Current as belInfNFe).det.First(c => c.nitem == (bsProdutos.Current as belProd).nitem).imposto;
                belIcms icms = imposto.belIcms;


                if (!Util.VerificaNovaST(icms.sCst))
                {
                    #region CST_ANTIGAS
                    switch (icms.sCst.Substring(1, 2))
                    {
                        case "00":
                            {
                                icms.belIcms00.Modbc = cbxmodBCicmsItens.SelectedIndex.ToString();
                                icms.belIcms00.Vbc = nudvBCicmsItens.Value;
                                icms.belIcms00.Picms = nudpICMSitens.Value;
                                icms.belIcms00.Vicms = nudvICMSicmsItens.Value;
                                break;
                            }
                        case "10":
                            {
                                icms.belIcms10.Modbc = cbxmodBCicmsItens.SelectedIndex.ToString();
                                icms.belIcms10.Vbc = nudvBCicmsItens.Value;
                                icms.belIcms10.Picms = nudpICMSitens.Value;
                                icms.belIcms10.Vicms = nudvICMSicmsItens.Value;
                                icms.belIcms10.Modbcst = cbxmodBCSTicmsItens.SelectedIndex;
                                icms.belIcms10.Pmvast = nudpMVASTicmsItens.Value;
                                icms.belIcms10.Predbcst = nudpRedBCSTicmsItens.Value;
                                icms.belIcms10.Vbcst = nudvBCSTicmsItens.Value;
                                icms.belIcms10.Picmsst = nudpICMSSTicmsItens.Value;
                                icms.belIcms10.Vicmsst = nudvICMSSTicmsItens.Value;
                                break;
                            }
                        case "20":
                            {
                                icms.belIcms20.Modbc = cbxmodBCicmsItens.SelectedIndex.ToString();
                                icms.belIcms20.Predbc = nudpRedBCSTicmsItens.Value;
                                icms.belIcms20.Vbc = nudvBCicmsItens.Value;
                                icms.belIcms20.Picms = nudpICMSitens.Value;
                                icms.belIcms20.Vicms = nudvICMSicmsItens.Value;
                                break;
                            }
                        case "30":
                            {
                                icms.belIcms30.Modbcst = cbxmodBCSTicmsItens.SelectedIndex;
                                icms.belIcms30.Pmvast = nudpMVASTicmsItens.Value;
                                icms.belIcms30.Predbcst = nudpRedBCSTicmsItens.Value;
                                icms.belIcms30.Vbcst = nudvBCSTicmsItens.Value;
                                icms.belIcms30.Picmsst = nudpICMSSTicmsItens.Value;
                                icms.belIcms30.Vicmsst = nudvICMSSTicmsItens.Value;
                                break;
                            }
                        case "40":
                            {
                                icms.belIcms40.Vicms = nudvICMSicmsItens.Value;
                                icms.belIcms40.motDesICMS = Convert.ToInt16(cbxmotDesICMS.SelectedValue);
                                break;
                            }
                        case "41":
                            {
                                icms.belIcms40.Vicms = nudvICMSicmsItens.Value;
                                icms.belIcms40.motDesICMS = Convert.ToInt16(cbxmotDesICMS.SelectedValue);
                                break;
                            }
                        case "50":
                            {
                                icms.belIcms40.Vicms = nudvICMSicmsItens.Value;
                                icms.belIcms40.motDesICMS = Convert.ToInt16(cbxmotDesICMS.SelectedValue);
                                break;
                            }
                        case "51":
                            {
                                icms.belIcms51.Modbc = cbxmodBCicmsItens.SelectedIndex.ToString();
                                icms.belIcms51.Predbc = nudpRedBCicmsItens.Value;
                                icms.belIcms51.Vbc = nudvBCicmsItens.Value;
                                icms.belIcms51.Picms = nudpICMSitens.Value;
                                icms.belIcms51.Vicms = nudvICMSicmsItens.Value;
                                break;
                            }
                        case "60":
                            {
                                icms.belIcms60.Vbcstret = nudvBCSTRetIcmsItens.Value;
                                icms.belIcms60.Vicmsstret = nudvICMSSTRetIcmsItens.Value;
                                break;
                            }

                        case "70":
                            {
                                icms.belIcms70.Modbc = cbxmodBCicmsItens.SelectedIndex.ToString();
                                icms.belIcms70.Predbc = nudpRedBCicmsItens.Value;
                                icms.belIcms70.Vbc = nudvBCicmsItens.Value;
                                icms.belIcms70.Picms = nudpICMSitens.Value;
                                icms.belIcms70.Vicms = nudvICMSicmsItens.Value;
                                icms.belIcms70.Modbcst = cbxmodBCSTicmsItens.SelectedIndex;
                                icms.belIcms70.Pmvast = nudpMVASTicmsItens.Value;
                                icms.belIcms70.Predbcst = nudpRedBCSTicmsItens.Value;
                                icms.belIcms70.Vbcst = nudvBCSTicmsItens.Value;
                                icms.belIcms70.Picmsst = nudpICMSSTicmsItens.Value;
                                icms.belIcms70.Vicmsst = nudvICMSSTicmsItens.Value;
                                break;
                            }

                        case "90":
                            {
                                icms.belIcms90.Modbc = cbxmodBCicmsItens.SelectedIndex.ToString();
                                icms.belIcms90.Predbc = nudpRedBCicmsItens.Value;
                                icms.belIcms90.Vbc = nudvBCicmsItens.Value;
                                icms.belIcms90.Picms = nudpICMSitens.Value;
                                icms.belIcms90.Vicms = nudvICMSicmsItens.Value;
                                icms.belIcms90.Modbcst = cbxmodBCSTicmsItens.SelectedIndex;
                                icms.belIcms90.Pmvast = nudpMVASTicmsItens.Value;
                                icms.belIcms90.Predbcst = nudpRedBCSTicmsItens.Value;
                                icms.belIcms90.Vbcst = nudvBCSTicmsItens.Value;
                                icms.belIcms90.Picmsst = nudpICMSSTicmsItens.Value;
                                icms.belIcms90.Vicmsst = nudvICMSSTicmsItens.Value;
                                break;
                            }
                    }

                    #endregion
                }
                else
                {

                    #region CTS_NOVAS
                    switch ((Util.RetornaSTnovaAserUsada(icms.sCst)))
                    {
                        case "101":
                            {
                                icms.belICMSSN101.pCredSN = nudpCredSN.Value;
                                icms.belICMSSN101.vCredICMSSN = nudvCredICMSSN.Value;
                            }
                            break;

                        case "102":
                            {
                            }
                            break;
                        case "201":
                            {
                                icms.belICMSSN201.modBCST = cbxmodBCSTicmsItens.SelectedIndex;
                                icms.belICMSSN201.pMVAST = nudpMVASTicmsItens.Value;
                                icms.belICMSSN201.pRedBCST = nudpRedBCSTicmsItens.Value;
                                icms.belICMSSN201.vBCST = nudvBCSTicmsItens.Value;
                                icms.belICMSSN201.pICMSST = nudpICMSSTicmsItens.Value;
                                icms.belICMSSN201.vICMSST = nudvICMSSTicmsItens.Value;
                                icms.belICMSSN201.pCredSN = nudpCredSN.Value;
                                icms.belICMSSN201.vCredICMSSN = nudvCredICMSSN.Value;
                            }
                            break;
                        case "500":
                            {
                                nudvBCSTRetIcmsItens.Value = icms.belICMSSN500.vBCSTRet;
                                nudvICMSSTRetIcmsItens.Value = icms.belICMSSN500.vICMSSTRet;
                            }
                            break;
                        case "900":
                            {
                                icms.belICMSSN900.modBC = cbxmodBCicmsItens.SelectedIndex;
                                icms.belICMSSN900.vBC = nudvBCicmsItens.Value;
                                icms.belICMSSN900.pRedBC = nudpRedBCicmsItens.Value;
                                icms.belICMSSN900.pICMS = nudpICMSitens.Value;
                                icms.belICMSSN900.vICMS = nudvICMSicmsItens.Value;
                                icms.belICMSSN900.modBCST = cbxmodBCSTicmsItens.SelectedIndex;
                                icms.belICMSSN900.pMVAST = nudpMVASTicmsItens.Value;
                                icms.belICMSSN900.pRedBCST = nudpRedBCSTicmsItens.Value;
                                icms.belICMSSN900.vBCST = nudvBCSTicmsItens.Value;
                                icms.belICMSSN900.pICMSST = nudpICMSSTicmsItens.Value;
                                icms.belICMSSN900.vICMSST = nudvICMSSTicmsItens.Value;
                                icms.belICMSSN900.pCredSN = nudpCredSN.Value;
                                icms.belICMSSN900.vCredICMSSN = nudvCredICMSSN.Value;
                            }
                            break;
                    }
                    #endregion
                }
                #endregion
                #region IPI
                belIpi ipi = imposto.belIpi;
                if (ipi != null)
                {
                    if ((ipi.cst.Equals("00")) || (ipi.cst.Equals("49")) || (ipi.cst.Equals("50")) || (ipi.cst.Equals("99")))
                    {
                        ipi.belIpitrib.Vbc = nudvBCipiItens.Value;
                        ipi.belIpitrib.Pipi = nudpIPIitens.Value;
                        ipi.belIpitrib.Qunid = nudqUnidipi.nud.Value;
                        ipi.belIpitrib.Vunid = nudvUnidipi.Value;
                        ipi.belIpitrib.Vipi = nudvIPIitens.Value;
                    }
                }
                #endregion
                #region II
                belIi ii = imposto.belIi;
                if (ii != null)
                {
                    ii.Vbc = nudvBCii.Value;
                    ii.Vdespadu = nudvDespAdu.Value;
                    ii.Vii = nudvIIitens.Value;
                    ii.Viof = nudvIOFii.Value;
                }
                #endregion
                #region Combustivel
                belcomb comb = (bsProdutos.Current as belProd).belcomb;
                if (comb != null)
                {
                    comb.UFCons = txtUFcons.Text;
                    comb.cProdANP = Convert.ToInt32(nudCodigoANP.Value);
                }

                #endregion
                #region PIS
                belPis pis = imposto.belPis;
                if (Convert.ToInt16(pis.cst) <= 2)
                {
                    pis.belPisaliq.Vbc = nudvBCpis.Value;
                    pis.belPisaliq.Ppis = nudpPISitens.Value;
                    pis.belPisaliq.Vpis = nudvPISitens.Value;
                }
                else if (Convert.ToInt16(pis.cst) > 9)
                {
                    pis.belPisoutr.Vbc = nudvBCpis.Value;
                    pis.belPisoutr.Ppis = nudpPISitens.Value;
                    pis.belPisoutr.Vpis = nudvPISitens.Value;
                }
                #endregion
                #region COFINS
                belCofins cofins = imposto.belCofins;
                if (Convert.ToInt16(cofins.cst) <= 2)
                {
                    cofins.belCofinsaliq.Vbc = nudvBCcofins.Value;
                    cofins.belCofinsaliq.Pcofins = nudpCOFINSitens.Value;
                    cofins.belCofinsaliq.Vcofins = nudvCOFINSitens.Value;
                }
                else if (Convert.ToInt16(cofins.cst) > 9)
                {
                    cofins.belCofinsoutr.Vbc = nudvBCcofins.Value;
                    cofins.belCofinsoutr.Pcofins = nudpCOFINSitens.Value;
                    cofins.belCofinsoutr.Vcofins = nudvCOFINSitens.Value;
                }
                #endregion
                #region ISSQN
                belIss iss = imposto.belIss;
                if (iss != null)
                {
                    iss.Vbc = nudvBCissItens.Value;
                    iss.Valiq = nudvAliqissItens.Value;
                    iss.Vissqn = nudvISSQNitens.Value;
                    iss.Cmunfg = txtcMunFGiss.Text;
                    iss.Clistserv = Convert.ToInt64(txtcListServ.Text);
                    iss.cSitTrib = cbxcSitTribIss.SelectedValue.ToString();
                }
                #endregion

            }
                #endregion

            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void DesabilitaComponentesConatiner(Control.ControlCollection ctrTela)
        {
            foreach (Control ctr in ctrTela)
            {
                if (ctr.HasChildren == true && ctr.GetType().BaseType != typeof(UserControl))
                {
                    DesabilitaComponentesConatiner(ctr.Controls);
                }
                else if (ctr.GetType() == typeof(HLP_NumericUpDown))
                {
                    ctr.Visible = false;

                }
                else if (ctr.GetType() == typeof(HLP_ComboBox))
                {
                    if (ctr.Name != "cbxCSTicmsItens" && ctr.Name != "cbxOrigICMSitens")
                    {
                        ctr.Visible = false;
                        (ctr as HLP_ComboBox).SelectedIndex = -1;
                    }
                }
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

        #region Botoes e Eventos

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
        public override void Atualizar()
        {
            if (Acesso.bALTERA_DADOS)
            {
                base.Atualizar();
                dgvProd.ReadOnly = false;
                //cbxFinNFe.Enabled = false;
                cbxTpAmb.Enabled = false;
                cbxTpNF.Enabled = false;
                cbcxTpEmis.Enabled = false;
                cbxtpImp.Enabled = false;
                cbxIndPag.Enabled = false;
                mtbDSaiEnt.Enabled = false;
                dtpHSaiEnt.Enabled = false;
                mtbDEmi.Enabled = false;
                cbxCSTicmsItens.Enabled = false;
                cbxCSTipi.Enabled = false;
                cbxCSTpis.Enabled = false;
                
                
            }
            else
            {
                if (KryptonMessageBox.Show(null, "Usuário não tem Acesso para Alterar dados da Nota Fiscal" +
                     Environment.NewLine +
                     Environment.NewLine +
                     "Deseja entrar com a Permissão de um Outro Usuário? ", Mensagens.MSG_Aviso,
                      MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    frmLogin objfrm = new frmLogin();
                    objfrm.ShowDialog();
                    if (Acesso.bALTERA_DADOS)
                    {
                        base.Atualizar();
                    }
                    else
                    {
                        KryptonMessageBox.Show(null, "Usuário também não tem Permissão Para Alterar Dados da Nota Fiscal", Mensagens.MSG_Aviso, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }

        }
        public override void Enviar()
        {
            try
            {
                if (ValidaNotas())
                {
                    base.Enviar();
                }
                else
                {
                    KryptonMessageBox.Show("Verifique Todos os Erros antes de Enviar a NF-e!", Mensagens.MSG_Alerta, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                new HLPexception(ex);
            }
        }
        public override void Salvar()
        {
            try
            {
                if (btnSalvarItens.Enabled == true)
                {

                }
                SalvarAlteracao();
                ValidaNotas();
                base.Salvar();
                dgvProd.ReadOnly = true;
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
                    base.Cancelar();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                new HLPexception(ex);
            }
        }

        private void listErros_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (listErros.SelectedValue != null)
                {
                    Control ctr = listErros.SelectedValue as Control;
                    belValidaCampos.ListaErros objerro = (belValidaCampos.ListaErros)listErros.SelectedItem;

                    int iposicao = bsNotas.IndexOf(((List<belInfNFe>)bsNotas.List).FirstOrDefault(c => c.ide.Nnf == objerro.NumeroDocumento));
                    bsNotas.Position = iposicao;
                    lblContagemNotas.Text = (bsNotas.Position + 1).ToString() + " de " + bsNotas.Count;
                    PopulaForm();
                    ProcuraTabPage(ctr);
                    ctr.Focus();
                }

            }
            catch (Exception)
            {

                throw;
            }

        }

        private void bsProdutos_CurrentItemChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvProd.Focused)
                {
                    DesabilitaCampos(panelItens.Controls, false);
                    belProd objbelProd = bsProdutos.Current as belProd;
                    belImposto objbelImp = ((belInfNFe)bsNotas.Current).det.FirstOrDefault(c => c.nitem == objbelProd.nitem).imposto;
                    CarregaAbaICMSitens(objbelImp.belIcms);
                    if (objbelImp.belIpi != null)
                    {
                        flIPI.Visible = true;
                        CarregaAbaIPIitens(objbelImp.belIpi);
                    }
                    else
                    {
                        flIPI.Visible = false;
                    }
                    CarregaAbaII(objbelImp.belIi);
                    CarregaAbaCombustivel(objbelProd.belcomb);
                    CarregaAbaPISitens(objbelImp.belPis);
                    CarregaAbaCofinsitens(objbelImp.belCofins);
                    txtInfiAdicItens.Text = ((belInfNFe)bsNotas.Current).det.FirstOrDefault(c => c.nitem == objbelProd.nitem).infAdProd.Infadprid;
                    dgvDI.Focus();
                    bsDI.DataSource = objbelProd.belDI;

                }
            }
            catch (Exception ex)
            {
                new HLPexception(ex);
            }
        }
        private void Configuracoes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((sender as AC.ExtendedRenderer.Navigator.KryptonTabControl).SelectedTab.Name == "tabProd")
            {
                dgvProd.Focus();
                bsProdutos_CurrentItemChanged(sender, e);
            }
            else if ((sender as AC.ExtendedRenderer.Navigator.KryptonTabControl).SelectedTab.Name == "tabErros")
            {
                SalvarAlteracao();
                ValidaNotas();
            }
        }
        private void btnAtualizarItens_Click(object sender, EventArgs e)
        {
            if (btnSalvar.Enabled)
            {
                if (!dgvProd.ReadOnly)
                {
                    DesabilitaCampos(panelItens.Controls, true);
                    cbxCSTicmsItens.Enabled = false;
                    cbxCSTipi.Enabled = false;
                    cbxCSTpis.Enabled = false;
                    cbxCSTcofins.Enabled = false;
                    btnAtualizarItens.Enabled = false;
                    btnSalvarItens.Enabled = true;
                }
            }
            else
            {
                KryptonMessageBox.Show("Formulário não esta em mode de Edição", "A V I S O ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void btnSalvarItens_Click(object sender, EventArgs e)
        {
            if (!dgvProd.ReadOnly)
            {
                try
                {
                    SalvaItensGridProd();
                    DesabilitaCampos(panelItens.Controls, false);
                    btnAtualizarItens.Enabled = true;
                    btnSalvarItens.Enabled = false;
                }
                catch (Exception ex)
                {
                    new HLPexception(ex);
                }
            }
        }
        #region Page de Referenciar Nota
        private void btnPesquisarNF_Click(object sender, EventArgs e)
        {
            frmPesquisaNfe frm = new frmPesquisaNfe();
            frm.ShowDialog();
            belCampoPesquisa objbelCampoPesquisa = frm.objbelCampoPesquisa;

            if (objbelCampoPesquisa != null)
            {
                if (objbelCampoPesquisa.ChaveAcesso != "")
                {
                    txtChaveAcesso.Text = objbelCampoPesquisa.ChaveAcesso;
                    tabControl1.SelectedTab = tabPageRefNfe;
                }
                else
                {
                    txtnNFref.Text = objbelCampoPesquisa.NumeroNF;
                    txtClifor.Text = objbelCampoPesquisa.sCli_For;
                    txtCNPJ.Text = objbelCampoPesquisa.CNPJ;
                    txtcUF.Text = objbelCampoPesquisa.cUF;
                    txtserieRef.Text = objbelCampoPesquisa.serie;
                    txtAAMM.Text = Convert.ToDateTime(objbelCampoPesquisa.AAMM).ToString("dd/MM/yyyy");
                    tabControl1.SelectedTab = tabPageRefNotaA1;
                }
                objbelCampoPesquisa = new belCampoPesquisa();
            }
        }
        private void btnAdicionarRef_Click(object sender, EventArgs e)
        {
            try
            {
                txtChaveAcesso.errorProvider1.Dispose();
                txtcUF.errorProvider1.Dispose();
                txtAAMM.errorProvider1.Dispose();
                txtCNPJ.errorProvider1.Dispose();
                txtserieRef.errorProvider1.Dispose();

                belNFref obj = new belNFref();
                int icountErro = 0;
                if (txtChaveAcesso.Text != "")
                {
                    if (txtChaveAcesso.Text.Length != 44)
                    {
                        icountErro++;
                        txtChaveAcesso.errorProvider1.SetError(txtChaveAcesso, "Campo Obrigatório - Chave incompleta!!");
                    }
                    obj.RefNFe = txtChaveAcesso.Text;
                }
                else
                {
                    //Valida Campos.                    
                    if (txtcUF.Text == "")
                    {
                        icountErro++;
                        txtcUF.errorProvider1.SetError(txtcUF, "Campo Obrigatório!!");
                    }
                    if (txtAAMM.Text == "")
                    {
                        icountErro++;
                        txtAAMM.errorProvider1.SetError(txtAAMM, "Campo Obrigatório!!");
                    }
                    if (txtCNPJ.Text == "")
                    {
                        icountErro++;
                        txtCNPJ.errorProvider1.SetError(txtCNPJ, "Campo Obrigatório!!");
                    }
                    if (txtserieRef.Text == "")
                    {
                        icountErro++;
                        txtserieRef.errorProvider1.SetError(txtserieRef, "Campo Obrigatório!!");
                    }
                    if (txtnNFref.Text == "")
                    {
                        icountErro++;
                        txtnNFref.errorProvider1.SetError(txtnNFref, "Campo Obrigatório!!");
                    }

                    obj.cUF = txtcUF.Text;
                    if (txtAAMM.Text != "")
                    {
                        obj.AAMM = Convert.ToDateTime(txtAAMM.Text).ToString("yyMM");
                    }
                    obj.CNPJ = txtCNPJ.Text;
                    obj.serie = txtserieRef.Text;
                    obj.nNF = txtnNFref.Text;
                    obj.mod = textBoxmod.Text;
                }
                if (icountErro == 0)
                {
                    bsNFreferenciadas.Add(obj);
                }
                else
                {
                    throw new Exception("Favor Verificar as Inconsistências !!");
                }
                txtChaveAcesso.Text = "";
                txtcUF.Text = "";
                txtAAMM.Text = "";
                txtCNPJ.Text = "";
                txtserieRef.Text = "";
                txtnNFref.Text = "";
                txtClifor.Text = "";
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(null, ex.Message, "E R R O", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void btnRemover_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvRefNFe.CurrentRow != null)
                {
                    if (dgvRefNFe[1, dgvRefNFe.CurrentRow.Index].Value != null) //Remove NFe A1
                    {
                        string sNF = dgvRefNFe[1, dgvRefNFe.CurrentRow.Index].Value.ToString();
                        for (int i = 0; i < bsNFreferenciadas.Count; i++)
                        {
                            belNFref belRemove = ((bsNFreferenciadas[i]) as belNFref);
                            if (belRemove.nNF != null)
                            {
                                if (belRemove.nNF.Equals(sNF))
                                {
                                    bsNFreferenciadas.Remove(belRemove);
                                    break;
                                }
                            }
                        }
                    }
                    else if (dgvRefNFe[0, dgvRefNFe.CurrentRow.Index].Value != null) //Remove NFe
                    {
                        string sChave = dgvRefNFe[0, dgvRefNFe.CurrentRow.Index].Value.ToString();
                        for (int i = 0; i < bsNFreferenciadas.Count; i++)
                        {
                            belNFref belRemove = ((bsNFreferenciadas[i]) as belNFref);
                            if (belRemove.RefNFe != null)
                            {
                                if (belRemove.RefNFe.Equals(sChave))
                                {
                                    bsNFreferenciadas.Remove(belRemove);
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                new HLPexception(ex);
            }
        }
        private void btnLimparRef_Click(object sender, EventArgs e)
        {
            txtChaveAcesso.Text = "";
            txtcUF.Text = "";
            txtAAMM.Text = "";
            txtCNPJ.Text = "";
            txtserieRef.Text = "";
            txtnNFref.Text = "";
            txtClifor.Text = "";
        }
        #endregion
        private void bsDI_CurrentItemChanged(object sender, EventArgs e)
        {
            // if (dgvDI.Focused)
            {
                if (bsDI.Count > 0)
                {

                    if ((bsDI.Current as belDI).adi != null)
                    {
                        bsAdi.DataSource = (bsDI.Current as belDI).adi;
                    }
                    else
                    {
                        (bsDI.Current as belDI).adi = new List<beladi>();
                        bsAdi.DataSource = (bsDI.Current as belDI).adi;
                    }
                }
            }

        }

        void tabProd_Leave(object sender, EventArgs e)
        {
            if (btnAtualizarItens.Enabled == false)
            {
                SalvaItensGridProd();
                btnAtualizarItens.Enabled = true;
                btnSalvarItens.Enabled = false;
            }
        }


        #endregion

        private void dgvProd_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgvProd.Rows.Count > 0)
            {
                if (dgvProd.Columns[e.ColumnIndex].Name == "clCprod")
                {
                    belInfNFe nota = bsNotas.Current as belInfNFe;

                    List<belDet> objListaBelDet = new List<belDet>();
                    if (bOrderDesc)
                    {
                        objListaBelDet = nota.det.OrderByDescending(c => c.Cprod).ToList();
                    }
                    else
                    {
                        objListaBelDet = nota.det.OrderBy(c => c.Cprod).ToList();
                    }
                    nota.det = objListaBelDet;
                    List<belProd> lOrdenado = new List<belProd>();
                    int iPosicao = 1;
                    foreach (belDet det in objListaBelDet)
                    {
                        det.nitem = iPosicao;
                        det.prod.nitem = iPosicao;
                        lOrdenado.Add(det.prod);
                        iPosicao++;
                    }
                    bsProdutos.DataSource = lOrdenado;

                    bOrderDesc = !bOrderDesc;

                }

            }
        }

        private void dgvProd_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

    }
}
