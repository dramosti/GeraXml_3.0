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
    public partial class HLP_DateTimePicker : UserControl
    {

        public HLP_DateTimePicker()
        {
            InitializeComponent();
        }

        public enum CampoObrigatorio
        {
            SIM,
            NÃO
        }

        public int _TamanhoLabel
        {
            get { return lblDescricao.Width; }

        }
        public int _TamanhoDateTimePicker
        {
            get { return dtp.Width; }
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

        public string _LabelText
        {
            get { return lblDescricao.Text; }
            set
            {
                lblDescricao.Text = value;
            }
        }
        public override string Text { get { return dtp.Text; } set { dtp.Text = value; } }



        public new bool Enabled
        {
            get { return dtp.Enabled; }
            set
            {
                dtp.Enabled = value;

                if (value)
                {
                    dtp.StateNormal.Back.Color1 = Color;
                }
                else
                {
                    dtp.StateNormal.Back.Color1 = Color.FromArgb(226, 225, 230);
                }
            }
        }


        private bool visible = true;
        public bool _Visible { get { return visible; } set { visible = value; } }

        public Color Color { get { return dtp.StateNormal.Back.Color1; } set { dtp.StateNormal.Back.Color1 = value; } }

        public DateTimePickerFormat Format { get { return dtp.Format; } set { dtp.Format = value; } }
        public DateTime Value { get { return dtp.Value; } set { dtp.Value = value; } }

        private CampoObrigatorio _obrigatorio = CampoObrigatorio.NÃO;
        public CampoObrigatorio _Obrigatorio
        {
            get { return _obrigatorio; }
            set { _obrigatorio = value; }
        }



        private void dtp_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }
    }
}
