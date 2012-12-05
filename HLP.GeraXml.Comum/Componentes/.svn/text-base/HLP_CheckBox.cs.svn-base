using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using System.Xml.Linq;

namespace HLP.GeraXml.Comum.Componentes
{
    public partial class HLP_CheckBox : UserControl
    {

        public enum CampoObrigatorio 
        {
            SIM,
            NÃO
        }

        public HLP_CheckBox()
        {
            InitializeComponent();
        }

        public int _TamanhoLabel
        {
            get { return lblDescricao.Width; }
          
        }

        private int _tamanhoMaiorLabel;
        public int _TamanhoMaiorLabel
        {
            get { return _tamanhoMaiorLabel; }
            set
            {
                _tamanhoMaiorLabel = value;
                int Margem = value - lblDescricao.Width + 3;
                this.Margin = new System.Windows.Forms.Padding(Margem, 3, 15, 3);
            }
        }

        public string _LabelText
        {
            get { return lblDescricao.Text; }
            set
            {
                lblDescricao.Text = value;
            }
        }
        public bool Checked { get { return chk.Checked; } set { chk.Checked = value; } }



        public override bool AutoSize
        {
            get { return lblDescricao.AutoSize; }
            set
            {
                lblDescricao.AutoSize = value;
            }
        }

        public new bool Enabled { get { return chk.Enabled; } set { chk.Enabled = value; } }
        private bool visible = true;
        public bool _Visible { get { return visible; } set { visible = value; } }

        public bool Value { get { return chk.Checked; } set { chk.Checked = value; } }

        private CampoObrigatorio _obrigatorio;
        public CampoObrigatorio _Obrigatorio
        {
            get { return _obrigatorio; }
            set { _obrigatorio = value; }
        }

        private void chk_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }



    }
}
