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

namespace HLP.GeraXml.UI.CTe
{
    public partial class frmGerarNumeroCte : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        belNumeroCte objNumeroCte = new belNumeroCte();
        List<string> objlGerarConhec;
        enum tipo { CTE, MDFE };

        public frmGerarNumeroCte(List<string> objlGerarConhec)
        {
            InitializeComponent();
            this.objlGerarConhec = objlGerarConhec;
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {

            try
            {
                daoGeraNumero objdaoGeraNumero = new daoGeraNumero();
                List<belNumeroCte> objLbelConhec = objNumeroCte.GeraNumerosConhecimentos(objlGerarConhec, txtNumeroASerEmi.Text);

                pgbNF.Minimum = 0;
                pgbNF.Maximum = objLbelConhec.Count;

                for (int i = 0; i < objLbelConhec.Count; i++)
                {
                    objNumeroCte.GravaConhec(objLbelConhec[i].cdConhec, objLbelConhec[i].nfSeq);
                    pgbNF.Value++;
                }
                objdaoGeraNumero.AtualizaGenerator(objLbelConhec[objLbelConhec.Count - 1].cdConhec);

                KryptonMessageBox.Show(null, "Numeração dos Conhecimentos gerados com sucesso!", Mensagens.CHeader, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                daoNumeroCte objdaoGeraNumero = new daoNumeroCte();
                if (Acesso.NM_EMPRESA.ToUpper().Equals("SICUPIRA") || Acesso.NM_EMPRESA.ToUpper().Equals("TRANSLILO") || Acesso.NM_EMPRESA.ToUpper().Equals("GCA"))
                {
                    string sGenerator = "CONHECIM_CTE" + Acesso.CD_EMPRESA;
                    daoUtil util = new daoUtil();
                    if (!daoUtil.VerificaExistenciaGenerator(sGenerator))
                    {
                        daoUtil.CreateGenerator(sGenerator, 0);
                    }
                }
                txtNumeroUltNF.Text = objdaoGeraNumero.BuscaUltimoNumeroConhecimento().PadLeft(6, '0');
                txtNumeroASerEmi.Text = (Convert.ToInt32(txtNumeroUltNF.Text) + 1).ToString().PadLeft(6, '0');
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



    }
}