using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using HLP.GeraXml.Comum.Static;
using HLP.GeraXml.Comum;
using System.Security.Cryptography.X509Certificates;
using HLP.GeraXml.bel;
using HLP.GeraXml.bel.CTe;

namespace HLP.GeraXml.UI.CTe
{
    public partial class frmInutilizaFaixaCte : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        belInutilizaFaixaCte objbelInutilizaFaixaCte = new belInutilizaFaixaCte();


        public frmInutilizaFaixaCte()
        {
            InitializeComponent();
        }

        private void frmInutilizaFaixaCte_Load(object sender, EventArgs e)
        {
            txtnCTFin.txt.KeyPress += new KeyPressEventHandler(SomenteNumero_KeyPress);
            txtnCTIni.txt.KeyPress += new KeyPressEventHandler(SomenteNumero_KeyPress);
        }



        private void InutilizaCte()
        {
            try
            {
                belInutilizaFaixaCte objBelInutiliza = objbelInutilizaFaixaCte.PopulaDadosInutilizacao(txtnCTIni.Text, txtnCTFin.Text, txtJust.Text);
                belCriaXml objXml = new belCriaXml();
                List<belStatusCte> ListaStatus = objXml.GerarXmlInutilizacao(objBelInutiliza);

                KryptonMessageBox.Show(belTrataMensagem.RetornaMensagem(ListaStatus, belTrataMensagem.Tipo.Inutilizacao), Mensagens.CHeader, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnInutilizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtJust.Text.Length < 15)
                {
                    KryptonMessageBox.Show("Justificativa inválida." + Environment.NewLine + "Mínimo de caracteres esperado.", Mensagens.CHeader, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    belValidaCampos.Validar(this.Controls);
                    InutilizaCte();
                }
            }
            catch (Exception ex)
            {
                new HLPexception(ex);
            }
        }
        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
            throw new Exception("Inutilização não foi Realizada.");
        }


        private void SomenteNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }




    }
}