using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HLP.GeraXml.UI.Relatorios;
using HLP.GeraXml.Comum.Static;

namespace HLP.GeraXml.UI.NFe
{
    public partial class frmContratoContingenciaNfe : Form
    {
        public bool bImprime { get; set; }

        public frmContratoContingenciaNfe()
        {
            InitializeComponent();
            relAvisoContingencia rpt = new relAvisoContingencia();
            rpt.DataDefinition.FormulaFields["Empresa"].Text = "'" + Acesso.NM_EMPRESA + "'";

            crystalReportViewer1.ReportSource = rpt;
            rpt.Refresh();
        }

        private void btnConcordo_Click(object sender, EventArgs e)
        {
            bImprime = true;
            this.Close();
        }

        private void btnCancela_Click(object sender, EventArgs e)
        {
            bImprime = false;
            this.Close();
        }
    }
}
