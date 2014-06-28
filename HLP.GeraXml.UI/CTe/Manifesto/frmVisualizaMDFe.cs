using ComponentFactory.Krypton.Toolkit;
using HLP.GeraXml.bel.MDFe;
using HLP.GeraXml.bel.MDFe.Acoes;
using HLP.GeraXml.Comum.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HLP.GeraXml.UI.CTe.Manifesto
{
    /*
     * Horário de o.s. no dia 28/06
     * 
     * 10:41 - 12:53
     * 
     * */
    public partial class frmVisualizaMDFe : FormPadraoVisualizacao
    {
        public bool bEnvia = false;

        public List<belDadosManifesto> manifestos { get; set; }
        public frmVisualizaMDFe(List<belDadosManifesto> manifestos)
        {

            this.manifestos = manifestos;
            InitializeComponent();

            this.bsNotas.DataSource = manifestos;

            this.CarregaSelectedItem();
        }

        private void CarregaSelectedItem()
        {
            //infMDFE
            txtId.Text =
                (this.bsNotas.Current as belDadosManifesto).enviMDFe.idLote;

            //ide
            txtcUF.Text = (this.bsNotas.Current as belDadosManifesto).enviMDFe.MDFe.infMDFe.ide.cUF;
            cbotpAmb.SelectedValue = (this.bsNotas.Current as belDadosManifesto).enviMDFe.MDFe.infMDFe.ide.tpAmb;
            cboTpEmit.SelectedValue = (this.bsNotas.Current as belDadosManifesto).enviMDFe.MDFe.infMDFe.ide.tpEmis;
            txtMod.Text = (this.bsNotas.Current as belDadosManifesto).enviMDFe.MDFe.infMDFe.ide.mod.ToString(); //TODO: CAMPO ST
            txtSerie.Text = (this.bsNotas.Current as belDadosManifesto).enviMDFe.MDFe.infMDFe.ide.serie;
            txtNmdf.Text = (this.bsNotas.Current as belDadosManifesto).enviMDFe.MDFe.infMDFe.ide.nMDF;
            txtCmdf.Text = (this.bsNotas.Current as belDadosManifesto).enviMDFe.MDFe.infMDFe.ide.cMDF;
            txtCdv.Text = (this.bsNotas.Current as belDadosManifesto).enviMDFe.MDFe.infMDFe.ide.cDV;
            txtModal.Text = (this.bsNotas.Current as belDadosManifesto).enviMDFe.MDFe.infMDFe.ide.modal.ToString(); //TODO: CAMPO ST
            txtDhEmi.Text = (this.bsNotas.Current as belDadosManifesto).enviMDFe.MDFe.infMDFe.ide.dhEmi;
            cboTpEmis.SelectedValue = (this.bsNotas.Current as belDadosManifesto).enviMDFe.MDFe.infMDFe.ide.tpEmis;
            txtProcEmi.Text = (this.bsNotas.Current as belDadosManifesto).enviMDFe.MDFe.infMDFe.ide.procEmi.ToString(); //TODO: CAMPO ST
            txtVerPro.Text = (this.bsNotas.Current as belDadosManifesto).enviMDFe.MDFe.infMDFe.ide.verProc;
            txtUfIni.Text = (this.bsNotas.Current as belDadosManifesto).enviMDFe.MDFe.infMDFe.ide.UFIni;
            txtUfFim.Text = (this.bsNotas.Current as belDadosManifesto).enviMDFe.MDFe.infMDFe.ide.UFFim;

            //infMunCarrega
            this.bsInfMunicipios.DataSource = (this.bsNotas.Current as belDadosManifesto).enviMDFe.MDFe.infMDFe.ide.infMunCarrega;

            //emit
            this.txtCnpj.Text = (this.bsNotas.Current as belDadosManifesto).enviMDFe.MDFe.infMDFe.emit.CNPJ;
            this.txtIe.Text = (this.bsNotas.Current as belDadosManifesto).enviMDFe.MDFe.infMDFe.emit.IE;
            this.txtXNome.Text = (this.bsNotas.Current as belDadosManifesto).enviMDFe.MDFe.infMDFe.emit.xNome;
            this.txtXFant.Text = (this.bsNotas.Current as belDadosManifesto).enviMDFe.MDFe.infMDFe.emit.xFant;
            this.txtLgr.Text = (this.bsNotas.Current as belDadosManifesto).enviMDFe.MDFe.infMDFe.emit.enderEmit.xLgr;
            this.txtNro.Text = (this.bsNotas.Current as belDadosManifesto).enviMDFe.MDFe.infMDFe.emit.enderEmit.nro;
            this.txtXCpl.Text = (this.bsNotas.Current as belDadosManifesto).enviMDFe.MDFe.infMDFe.emit.enderEmit.xCpl;
            this.txtXBairro.Text = (this.bsNotas.Current as belDadosManifesto).enviMDFe.MDFe.infMDFe.emit.enderEmit.xBairro;
            this.txtCMun.Text = (this.bsNotas.Current as belDadosManifesto).enviMDFe.MDFe.infMDFe.emit.enderEmit.cMun;
            this.txtXMun.Text = (this.bsNotas.Current as belDadosManifesto).enviMDFe.MDFe.infMDFe.emit.enderEmit.xMun;
            this.txtCep.Text = (this.bsNotas.Current as belDadosManifesto).enviMDFe.MDFe.infMDFe.emit.enderEmit.CEP;
            this.txtUf.Text = (this.bsNotas.Current as belDadosManifesto).enviMDFe.MDFe.infMDFe.emit.enderEmit.UF;
            this.txtFone.Text = (this.bsNotas.Current as belDadosManifesto).enviMDFe.MDFe.infMDFe.emit.enderEmit.fone;
            this.txtEmail.Text = (this.bsNotas.Current as belDadosManifesto).enviMDFe.MDFe.infMDFe.emit.enderEmit.email;


            this.txtCMunDescarg.Text = (this.bsNotas.Current as belDadosManifesto).enviMDFe.MDFe.infMDFe.infDoc.FirstOrDefault().cMunDescarga;
            this.txtXMumDescarga.Text = (this.bsNotas.Current as belDadosManifesto).enviMDFe.MDFe.infMDFe.infDoc.FirstOrDefault().xMunDescarga;

            this.bsInfCte.DataSource = (this.bsNotas.Current as belDadosManifesto).enviMDFe.MDFe.infMDFe.infDoc.FirstOrDefault().infCTe;
            this.bsInfCt.DataSource = (this.bsNotas.Current as belDadosManifesto).enviMDFe.MDFe.infMDFe.infDoc.FirstOrDefault().infCT;
            this.bsInfNfe.DataSource = (this.bsNotas.Current as belDadosManifesto).enviMDFe.MDFe.infMDFe.infDoc.FirstOrDefault().infNFe;
            this.bsInfNf.DataSource = (this.bsNotas.Current as belDadosManifesto).enviMDFe.MDFe.infMDFe.infDoc.FirstOrDefault().infNF;

            //Tot
            this.txtQCte.Text = (this.bsNotas.Current as belDadosManifesto).enviMDFe.MDFe.infMDFe.tot.qCTe;
            this.txtQCt.Text = (this.bsNotas.Current as belDadosManifesto).enviMDFe.MDFe.infMDFe.tot.qCT;
            this.txtQNfe.Text = (this.bsNotas.Current as belDadosManifesto).enviMDFe.MDFe.infMDFe.tot.qNFe;
            this.txtQNf.Text = (this.bsNotas.Current as belDadosManifesto).enviMDFe.MDFe.infMDFe.tot.qNF;
            this.txtVCarga.Text = (this.bsNotas.Current as belDadosManifesto).enviMDFe.MDFe.infMDFe.tot.vCarga;
            this.txtCUnid.Text = (this.bsNotas.Current as belDadosManifesto).enviMDFe.MDFe.infMDFe.tot.cUnid.ToString(); //TODO: CAMPO ST;
            this.txtQCarga.Text = (this.bsNotas.Current as belDadosManifesto).enviMDFe.MDFe.infMDFe.tot.qCarga;

            this.txtInfCpl.Text = (this.bsNotas.Current as belDadosManifesto).enviMDFe.MDFe.infMDFe.infAdic.infCpl;

            //rodo
            this.txtXRntrc.Text = (this.bsNotas.Current as belDadosManifesto).objRodo.RNTRC;
            this.txtCiot.Text = (this.bsNotas.Current as belDadosManifesto).objRodo.CIOT;

            //veicTracao
            this.txtCInt.Text = (this.bsNotas.Current as belDadosManifesto).objRodo.veicTracao.cInt;
            this.txtPlaca.Text = (this.bsNotas.Current as belDadosManifesto).objRodo.veicTracao.placa;
            this.txtTara.Text = (this.bsNotas.Current as belDadosManifesto).objRodo.veicTracao.tara;
            this.txtCapKG.Text = (this.bsNotas.Current as belDadosManifesto).objRodo.veicTracao.capKG;
            this.txtCapM3.Text = (this.bsNotas.Current as belDadosManifesto).objRodo.veicTracao.capM3;
            if ((this.bsNotas.Current as belDadosManifesto).objRodo.veicTracao.prop.ItemElementName.ToString().ToUpper()
                == "CNPJ")
            {
                this.txtPropCNPJ.Text =
                    (this.bsNotas.Current as belDadosManifesto).objRodo.veicTracao.prop.Item;
            }
            else
            {
                this.txtPropCpf.Text = (this.bsNotas.Current as belDadosManifesto).objRodo.veicTracao.prop.Item;
            }
            this.txtPropRntrc.Text = (this.bsNotas.Current as belDadosManifesto).objRodo.veicTracao.prop.RNTRC;
            this.txtPropXNome.Text = (this.bsNotas.Current as belDadosManifesto).objRodo.veicTracao.prop.xNome;
            this.txtIe.Text = (this.bsNotas.Current as belDadosManifesto).objRodo.veicTracao.prop.IE;
            this.txtUf.Text = (this.bsNotas.Current as belDadosManifesto).objRodo.veicTracao.prop.UF;
            this.cboTpProp.SelectedValue = (this.bsNotas.Current as belDadosManifesto).objRodo.veicTracao.prop.tpProp;
            this.cboTpRod.SelectedValue = (this.bsNotas.Current as belDadosManifesto).objRodo.veicTracao.tpRod;
            this.cboTpCar.SelectedValue = (this.bsNotas.Current as belDadosManifesto).objRodo.veicTracao.tpCar;
            this.txtPropUf.Text = (this.bsNotas.Current as belDadosManifesto).objRodo.veicTracao.UF.ToString();

            this.bsCondutorVeiculo.DataSource = (this.bsNotas.Current as belDadosManifesto).objRodo.veicTracao.condutor;

            this.bsVeicReboc.DataSource = (this.bsNotas.Current as belDadosManifesto).objRodo.veicReboque;

        }

        public override void Enviar()
        {
            bEnvia = true;
            base.Enviar();
        }

        private void tabPage7_Click(object sender, EventArgs e)
        {

        }

        private void bsVeicReboc_CurrentItemChanged(object sender, EventArgs e)
        {
            if (this.bsVeicReboc.Current != null)
            {

                if ((this.bsVeicReboc.Current as rodoVeicReboque).prop != null)
                {
                    if ((this.bsVeicReboc.Current as rodoVeicReboque).prop.ItemElementName.ToString().ToUpper()
                        == "CNPJ")
                    {
                        this.txtPropRebocCNPJ.Text =
                            (this.bsVeicReboc.Current as rodoVeicReboque).prop.Item;
                    }
                    else
                    {
                        this.txtPropRebocCpf.Text = (this.bsVeicReboc.Current as rodoVeicReboque).prop.Item;
                    }

                    this.txtPropRebocXNome.Text = (this.bsVeicReboc.Current as rodoVeicReboque).prop.xNome;
                    this.txtPropRebocIe.Text = (this.bsVeicReboc.Current as rodoVeicReboque).prop.IE;
                    this.txtPropRebocUf.Text = (this.bsVeicReboc.Current as rodoVeicReboque).prop.UF;
                    this.cboTpPropReboc.SelectedValue = (this.bsVeicReboc.Current as rodoVeicReboque).prop.tpProp;
                }
            }
        }
    }
}
