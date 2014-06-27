using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using HLP.GeraXml.bel.CTe;
using HLP.GeraXml.Comum.Static;
using HLP.GeraXml.dao.CTe;
using HLP.GeraXml.dao;
using HLP.GeraXml.bel.MDFe;
using HLP.GeraXml.dao.CTe.MDFe;
using System.Linq;
using HLP.GeraXml.bel.MDFe.Acoes;

namespace HLP.GeraXml.UI.CTe
{
    public partial class frmGerarNumeroMDFe : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        belNumeroManifesto objNumeroManifesto = new belNumeroManifesto();
        List<PesquisaManifestosModel> objlLista;


        public frmGerarNumeroMDFe(List<PesquisaManifestosModel> objlGerarNumManifesto)
        {
            InitializeComponent();
            this.objlLista = objlGerarNumManifesto;
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            try
            {
                int iValor = Convert.ToInt32(txtNumeroASerEmi.Text);
                pgbNF.Minimum = 0;
                pgbNF.Maximum = objlLista.Count;
                foreach (var item in objlLista)
                {
                    item.numero = iValor.ToString().PadLeft(9, '0');
                    objNumeroManifesto.GravaNumeroManifesto(item.sequencia, item.numero);
                    iValor = iValor + 1;
                    pgbNF.Value++;
                }
                objNumeroManifesto.AtualizaGenerator(Convert.ToInt32(objlLista.LastOrDefault().numero).ToString());
                KryptonMessageBox.Show(null, "Numeração dos manifestos gerados com sucesso!", Mensagens.CHeader, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void frmGerarNumeroCte_Load(object sender, EventArgs e)
        {
            try
            {               
                string sGenerator = "MANIFESTO_MDFE" + Acesso.CD_EMPRESA;
                daoUtil util = new daoUtil();
                if (!daoUtil.VerificaExistenciaGenerator(sGenerator))
                {
                    daoUtil.CreateGenerator(sGenerator, 0);
                }
                txtNumeroUltNF.Text = objNumeroManifesto.BuscaUltimoNumeroConhecimento().PadLeft(9, '0');
                txtNumeroASerEmi.Text = (Convert.ToInt32(txtNumeroUltNF.Text) + 1).ToString().PadLeft(9, '0');
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



    }
}