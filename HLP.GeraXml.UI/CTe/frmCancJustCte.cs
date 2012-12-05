using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using HLP.GeraXml.Comum;
using HLP.GeraXml.Comum.Static;
using System.Security.Cryptography.X509Certificates;
using HLP.GeraXml.bel;
using HLP.GeraXml.bel.CTe;
using HLP.GeraXml.dao.CTe;

namespace HLP.GeraXml.UI.CTe 
{
    public partial class frmCancJustCte : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        public string sCodConhecimento = "";
        public frmCancJustCte(List<string> sListCodConhec)
        {
            InitializeComponent();
            this.sCodConhecimento = sListCodConhec[0];
        }

        private void btnCancelar_Click(object sender, EventArgs e)
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
                    CancelaCte();
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
            throw new Exception("Cancelamento não foi Realizado.");
        }


        private void CancelaCte()
        {
            try
            {
                daoBuscaDadosGerais objdaoDadosGerais = new daoBuscaDadosGerais();
                daoGravaDadosRetorno objDadosRetorno = new daoGravaDadosRetorno();
                belCancelaCte objCancelaCte = new belCancelaCte();


                string sJustificativa = txtJust.Text;
                belCancelaCte objCte = objCancelaCte.PopulaDadosCancelamento(sCodConhecimento, sJustificativa);

                belCriaXml objXml = new belCriaXml();
                List<belStatusCte> ListaStatus = objXml.GerarXmlCancelamento(objCte);

                foreach (belStatusCte cte in ListaStatus)
                {
                    if (cte.CodRetorno == "101")
                    {
                        objDadosRetorno.GravarReciboCancelamento(sCodConhecimento, cte.Protocolo, sJustificativa);
                        objXml.SalvaArquivoPastaCancelado(objdaoDadosGerais.BuscaChaveRetornoCteSeq(cte.NumeroSeq));
                    }
                }

                KryptonMessageBox.Show(belTrataMensagem.RetornaMensagem(ListaStatus, belTrataMensagem.Tipo.Cancelamento), Mensagens.CHeader, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}