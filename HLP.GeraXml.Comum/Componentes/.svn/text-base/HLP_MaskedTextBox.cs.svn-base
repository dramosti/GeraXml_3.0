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
    public partial class HLP_MaskedTextBox : UserControl
    {

        public enum CampoObrigatorio
        {
            SIM,
            NÃO
        }

        public HLP_MaskedTextBox()
        {
            InitializeComponent();
        }

        public int _TamanhoLabel
        {
            get { return lblDescricao.Width; }
        }
        public int _TamanhoMaskedTextBox
        {
            get { return msk.Width; }
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
        public override string Text { get { return msk.Text; } set { msk.Text = value; } }

        public MaskFormat MaskFormat
        {
            get { return msk.TextMaskFormat; }
            set { msk.TextMaskFormat = value; }
        }




        public new bool Enabled
        {
            get { return msk.MaskedTextBox.Enabled; }
            set
            {
                msk.MaskedTextBox.Enabled = value;
                if (!ReadOnly)
                {
                    if (value)
                    {
                        msk.StateNormal.Back.Color1 = Color;
                    }
                    else
                    {
                        msk.StateNormal.Back.Color1 = Color.FromArgb(226, 225, 230);
                    }
                }
            }
        }
        public bool ReadOnly
        {
            get { return msk.ReadOnly; }
            set
            {
                msk.ReadOnly = value;
                if (value)
                {
                    msk.StateNormal.Back.Color1 = Color.FromArgb(226, 225, 230);
                }
                else
                {
                    msk.StateNormal.Back.Color1 = Color;
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
                msk.StateNormal.Back.Color1 = value;
            }
        }
        public int MaxLength { get { return msk.MaxLength; } set { msk.MaxLength = value; } }
        public string Mask { get { return msk.Mask; } set { msk.Mask = value; } }


        private CampoObrigatorio _obrigatorio = CampoObrigatorio.NÃO;
        public CampoObrigatorio _Obrigatorio
        {
            get { return _obrigatorio; }
            set { _obrigatorio = value; }
        }

        private Expressoes _regex = Expressoes.Não_Aplica;
        public Expressoes _Regex
        {
            get { return _regex; }
            set
            {
                _regex = value;
                _regex_Expressao = belValidaCampos.RetornaExpressao(value);
            }
        }

        private string _regex_Expressao;
        public string _Regex_Expressao
        {
            get { return _regex_Expressao; }
            set { _regex_Expressao = value; }
        }


        private void msk_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }
    }
}
