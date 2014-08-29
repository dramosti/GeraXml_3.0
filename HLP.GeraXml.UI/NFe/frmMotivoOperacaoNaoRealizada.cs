using ComponentFactory.Krypton.Toolkit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HLP.GeraXml.UI.NFe
{
    public partial class frmMotivoOperacaoNaoRealizada : KryptonForm
    {
        public frmMotivoOperacaoNaoRealizada()
        {
            InitializeComponent();
        }
        public string xJust { get; set; }
        public bool bValida = false;
        private void btnEnviar_Click(object sender, EventArgs e)
        {
            if (txtJust.Text.Count() <= 15)
            {
                MessageBox.Show("Mínimo de caracteres não foi atingido.","A V I S O", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                this.xJust = txtJust.Text;
                bValida = true;
                this.Close();
            }
            
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
