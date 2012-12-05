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
    public partial class HLP_ComboBox : UserControl
    {

        public enum CampoObrigatorio
        {
            SIM,
            NÃO
        }

        public HLP_ComboBox()
        {
            InitializeComponent();
        }


        [Editor(@"System.Windows.Forms.Design.StringCollectionEditor," +
        "System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
       typeof(System.Drawing.Design.UITypeEditor))]
        [TypeConverter(typeof(CsvConverter))]
        public List<String> _Itens
        {
            get
            {
                return _attributes;
            }
            set
            {
                _attributes = value;
                cbx.Items.Clear();
                foreach (string sItem in _attributes)
                {
                    cbx.Items.Add(sItem);
                }

            }
        }
        private List<String> _attributes = new List<string>();

        public class CsvConverter : TypeConverter
        {
            // Overrides the ConvertTo method of TypeConverter. 
            public override object ConvertTo(ITypeDescriptorContext context,
               System.Globalization.CultureInfo culture, object value, Type destinationType)
            {
                List<String> v = value as List<String>;
                if (destinationType == typeof(string))
                {
                    return String.Join(";", v.ToArray());
                }
                return base.ConvertTo(context, culture, value, destinationType);
            }
        }

        public int _TamanhoLabel
        {
            get { return lblDescricao.Width; }
        }
        public int _TamanhoComboBox
        {
            get { return cbx.Width; }
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

        public string _LabelText
        {
            get { return lblDescricao.Text; }
            set
            {
                lblDescricao.Text = value;
            }
        }
        public override string Text { get { return cbx.Text; } set { cbx.Text = value; } }

        public override bool AutoSize
        {
            get { return lblDescricao.AutoSize; }
            set
            {
                lblDescricao.AutoSize = value;
            }
        }
        /// <summary>
        /// Utiliza o Combobox para 0-NÃO ;1-SIM
        /// </summary>
        /// 
        private bool situacao = false;
        public bool _situacao
        {
            get { return situacao; }
            set
            {
                situacao = value;
                if (value)
                {
                    this.cbx.Items.Clear();
                    this.cbx.Items.Add("0-NÃO");
                    this.cbx.Items.Add("1-SIM");
                    _TamanhoComboBox = 80;
                }
            }
        }



        public new bool Enabled
        {
            get { return cbx.ComboBox.Enabled; }
            set
            {
                cbx.ComboBox.Enabled = value;
                if (value)
                {
                    cbx.StateNormal.ComboBox.Back.Color1 = Color;
                }
                else
                {
                    cbx.StateNormal.ComboBox.Back.Color1 = Color.FromArgb(226, 225, 230);
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
                cbx.StateNormal.ComboBox.Back.Color1 = value;
            }
        }

        private string _DisplayMember = "DisplayMember";
        public string DisplayMember
        {
            get { return _DisplayMember; }
            set
            {
                _DisplayMember = value;
                cbx.DisplayMember = value;
            }
        }
        private string _ValueMember = "ValueMember";
        public string ValueMember
        {
            get { return _ValueMember; }
            set
            {
                _ValueMember = value;
                cbx.ValueMember = value;
            }
        }

        public object DataSource
        {
            get { return cbx.DataSource; }
            set
            {
                cbx.DataSource = value;
                cbx.DisplayMember = DisplayMember;
                cbx.ValueMember = ValueMember;
            }
        }
        public int SelectedIndex { get { return cbx.SelectedIndex; } set { cbx.SelectedIndex = value; } }
        public object SelectedValue { get { return (cbx.SelectedValue != null ? Convert.ToInt32(cbx.SelectedValue) : 0); } set { cbx.SelectedValue = value; } }


        private CampoObrigatorio _obrigatorio = CampoObrigatorio.NÃO;
        public CampoObrigatorio _Obrigatorio
        {
            get { return _obrigatorio; }
            set { _obrigatorio = value; }
        }

        private void cbx_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }



    }
}
