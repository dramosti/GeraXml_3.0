using ComponentFactory.Krypton.Toolkit;
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

    public partial class frmVisualizaMDFe : FormPadraoVisualizacao
    {
        public bool bEnvia = false;

        public List<belDadosManifesto> manifestos { get; set; }
        public frmVisualizaMDFe(List<belDadosManifesto> manifestos)
        {

            this.manifestos = manifestos;
            InitializeComponent();
        }


        public override void Enviar()
        {
            bEnvia = true;
            base.Enviar();
        }
    }
}
