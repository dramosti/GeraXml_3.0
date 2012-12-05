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
    public partial class HLP_TextBox : UserControl
    {

        public enum CampoObrigatorio
        {
            SIM,
            NÃO
        }

        public HLP_TextBox()
        {
            InitializeComponent();
        }




        public int _TamanhoLabel
        {
            get { return lblDescricao.Width; }
        }
        public int _TamanhoTextBox
        {
            get { return txt.Width; }
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


        public override string Text { get { return txt.Text; } set { txt.Text = value; } }


        public CharacterCasing CharacterCasing
        {
            get { return txt.CharacterCasing; }
            set { txt.CharacterCasing = value; }
        }


        public new bool Enabled
        {
            get { return txt.TextBox.Enabled; }
            set
            {
                txt.TextBox.Enabled = value;
                if (!ReadOnly)
                {
                    if (value)
                    {
                        txt.StateNormal.Back.Color1 = Color;                        
                    }
                    else
                    {
                        txt.StateNormal.Back.Color1 = Color.FromArgb(226, 225, 230);
                    }
                    this.TabStop = value;
                }
            }
        }
        public bool ReadOnly
        {
            get { return txt.ReadOnly; }
            set
            {
                txt.ReadOnly = value;
                if (value)
                {
                    txt.StateNormal.Back.Color1 = Color.FromArgb(226, 225, 230);
                }
                else
                {
                    txt.StateNormal.Back.Color1 = Color;
                }
            }
        }

        public bool _Multiline
        {
            get { return txt.Multiline; }
            set
            {
                txt.Multiline = value;
            }
        }
        public bool _Password
        {
            get { return txt.UseSystemPasswordChar; }
            set
            {
                txt.UseSystemPasswordChar = value;
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
                txt.StateNormal.Back.Color1 = value;
            }
        }
        public int MaxLength { get { return txt.MaxLength; } set { txt.MaxLength = value; } }

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



        private void txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }


    }
}
