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
    public partial class HLP_NumericUpDown : UserControl
    {

        public enum CampoObrigatorio
        {
            SIM,
            NÃO
        }

        public HLP_NumericUpDown()
        {
            InitializeComponent();
        }

        public int _TamanhoLabel
        {
            get { return lblDescricao.Width; }
        }
        public int _TamanhoNumericUpDown
        {
            get { return nud.Width; }
            set
            {
                this.Width = lblDescricao.Width + value;
            }
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



        public override bool AutoSize
        {
            get { return lblDescricao.AutoSize; }
            set
            {
                lblDescricao.AutoSize = value;
            }
        }

        public bool ReadOnly
        {
            get { return nud.ReadOnly; }
            set
            {
                nud.ReadOnly = value;
                if (!ReadOnly)
                {
                    if (value)
                    {
                        nud.StateNormal.Back.Color1 = Color.FromArgb(226, 225, 230);
                    }
                    else
                    {
                        nud.StateNormal.Back.Color1 = Color;
                    }
                }
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
        public override string Text
        {
            get { return nud.Text; }
            set
            {
                nud.Text = value;
                nud.Value = (value.Equals("") ? 0 : Convert.ToDecimal(value));
            }
        }

        public decimal Value { get { return (nud.Text == "" ? 0 : Convert.ToDecimal(nud.Text)); } set { nud.Text = value.ToString(); nud.Value = value; } }

        public int ValueInt { get { return (nud.Text == "" ? 0 : Convert.ToInt32(Math.Round(Convert.ToDecimal(nud.Text), 0))); } set { nud.Text = value.ToString(); nud.Value = Convert.ToDecimal(value); } }
        public new bool Enabled
        {
            get { return nud.NumericUpDown.Enabled; }
            set
            {
                nud.NumericUpDown.Enabled = value;
                if (value)
                {
                    nud.StateNormal.Back.Color1 = Color;
                }
                else
                {
                    nud.StateNormal.Back.Color1 = Color.FromArgb(226, 225, 230);
                }
            }
        }
        private bool visible = true;
        public bool _Visible { get { return visible; } set { visible = value; } }

        private Color _color = Color.White;
        public Color Color
        {
            get { return _color; }
            set
            {
                _color = value;
                nud.StateNormal.Back.Color1 = value;
            }
        }
        public decimal Maximum { get { return nud.Maximum; } set { nud.Maximum = value; } }
        public decimal Minimum { get { return nud.Minimum; } set { nud.Minimum = value; } }
        public int DecimalPlaces { get { return nud.DecimalPlaces; } set { nud.DecimalPlaces = value; } }


        private CampoObrigatorio _obrigatorio = CampoObrigatorio.NÃO;
        public CampoObrigatorio _Obrigatorio
        {
            get { return _obrigatorio; }
            set { _obrigatorio = value; }
        }


        private void nud_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }




    }
}
