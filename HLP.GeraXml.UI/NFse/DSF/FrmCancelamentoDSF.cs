using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using HLP.GeraXml.bel.NFe;
using HLP.GeraXml.bel.NFes.DSF;
using HLP.GeraXml.dao;
using HLP.GeraXml.Comum.Static;
using HLP.GeraXml.Comum;
using HLP.GeraXml.bel.NFes.DSF;

namespace HLP.GeraXml.UI.NFse.DSF
{
    public partial class FrmCancelamentoDSF : KryptonForm
    {
        public List<belPesquisaNotas> objNotas { get; set; }
        public belCancelamentoDSF objCanc { get; set; }

        public FrmCancelamentoDSF(List<belPesquisaNotas> objNotas)
        {
            InitializeComponent();
            objCanc = new belCancelamentoDSF(objNotas);
            bsCanc.DataSource = objCanc.objCancelamento.lote.Nota;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                if (objCanc.objCancelamento.lote.Nota.Where(c => string.IsNullOrEmpty(c.MotivoCancelamento)).Count() > 0)
                {
                    KryptonMessageBox.Show("O Motivo do cancelamento é obrigatório.", Mensagens.MSG_Aviso, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {                                       
                    KryptonMessageBox.Show(objCanc.Cancelar(), Mensagens.MSG_Aviso, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                new HLPexception(ex);
            }
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
