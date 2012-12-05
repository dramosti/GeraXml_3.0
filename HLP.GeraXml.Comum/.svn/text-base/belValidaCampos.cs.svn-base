using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HLP.GeraXml.Comum.Componentes;
using System.Text.RegularExpressions;
using HLP.GeraXml.Comum.Static;

namespace HLP.GeraXml.Comum
{
    public static class belValidaCampos
    {
        static List<Control> Componentes = null;
        static string CAMPO_OBRIGATORIO = "Campo Obrigatório";
        static string CAMPO_INVALIDO = "Valor do Campo Inválido";

        private static string sNOME_TAB = "";
        public struct ListaErros
        {
            public string Descricao { get; set; }
            public string NumeroDocumento { get; set; }
            public Control controle { get; set; }
        }
        public static int iErros = 0;
        public static List<ListaErros> objListaTodosErros;


        public static int Validar(Control.ControlCollection controls, bool GerarException = true)
        {
            try
            {
                Componentes = new List<Control>();
                CarregaComponentes(controls);
                int iErros = 0;

                Regex reg = null;
                foreach (Control ctr in Componentes)
                {

                    #region ComboBox

                    if (ctr.GetType() == typeof(HLP_ComboBox))
                    {
                        ((HLP_ComboBox)ctr).errorProvider1.Dispose();
                        if (((HLP_ComboBox)ctr)._Obrigatorio == HLP_ComboBox.CampoObrigatorio.SIM && ((HLP_ComboBox)ctr).SelectedIndex == -1)
                        {
                            ((HLP_ComboBox)ctr).errorProvider1.SetError(((HLP_ComboBox)ctr), CAMPO_OBRIGATORIO);
                            iErros++;
                        }
                    }

                    #endregion

                    #region DateTimePicker

                    if (ctr.GetType() == typeof(HLP_DateTimePicker))
                    {
                        ((HLP_DateTimePicker)ctr).errorProvider1.Dispose();
                        if (((HLP_DateTimePicker)ctr)._Obrigatorio == HLP_DateTimePicker.CampoObrigatorio.SIM && ((HLP_DateTimePicker)ctr).Value == null)
                        {
                            ((HLP_DateTimePicker)ctr).errorProvider1.SetError(((HLP_DateTimePicker)ctr), CAMPO_OBRIGATORIO);
                            iErros++;
                        }
                    }

                    #endregion

                    #region MaskedTextBox

                    if (ctr.GetType() == typeof(HLP_MaskedTextBox))
                    {
                        bool MaskValido = true;
                       
                        ((HLP_MaskedTextBox)ctr).errorProvider1.Dispose();
                        if (((HLP_MaskedTextBox)ctr)._Obrigatorio == HLP_MaskedTextBox.CampoObrigatorio.SIM && ((HLP_MaskedTextBox)ctr).Text.Equals(""))
                        {
                            ((HLP_MaskedTextBox)ctr).errorProvider1.SetError(((HLP_MaskedTextBox)ctr), CAMPO_OBRIGATORIO);
                            iErros++;
                            MaskValido = false;
                        }
                        if (MaskValido)
                        {
                            if (((HLP_MaskedTextBox)ctr)._Regex != Expressoes.Não_Aplica)
                            {
                                if (((HLP_MaskedTextBox)ctr)._Obrigatorio == HLP_MaskedTextBox.CampoObrigatorio.NÃO && !((HLP_MaskedTextBox)ctr).Text.Equals(""))
                                {
                                    reg = new Regex(RetornaExpressao(((HLP_MaskedTextBox)ctr)._Regex));
                                    if (!reg.IsMatch(((HLP_MaskedTextBox)ctr).Text))
                                    {
                                        ((HLP_MaskedTextBox)ctr).errorProvider1.SetError(((HLP_MaskedTextBox)ctr), CAMPO_INVALIDO);
                                        iErros++;
                                    }
                                }
                                else if (((HLP_MaskedTextBox)ctr)._Obrigatorio == HLP_MaskedTextBox.CampoObrigatorio.SIM)
                                {
                                    reg = new Regex(RetornaExpressao(((HLP_MaskedTextBox)ctr)._Regex));
                                    if (!reg.IsMatch(((HLP_MaskedTextBox)ctr).Text))
                                    {
                                        ((HLP_MaskedTextBox)ctr).errorProvider1.SetError(((HLP_MaskedTextBox)ctr), CAMPO_INVALIDO);
                                        iErros++;
                                    }
                                }
                            }
                        }
                    }

                    #endregion

                    #region NumericUpDown

                    if (ctr.GetType() == typeof(HLP_NumericUpDown))
                    {
                        ((HLP_NumericUpDown)ctr).errorProvider1.Dispose();
                        if (((HLP_NumericUpDown)ctr)._Obrigatorio == HLP_NumericUpDown.CampoObrigatorio.SIM && ((HLP_NumericUpDown)ctr).Text.Equals(""))
                        {
                            ((HLP_NumericUpDown)ctr).errorProvider1.SetError(((HLP_NumericUpDown)ctr), CAMPO_OBRIGATORIO);
                            iErros++;
                        }
                    }

                    #endregion

                    #region TextBox

                    if (ctr.GetType() == typeof(HLP_TextBox))
                    {
                        bool TextValido = true;
                        ((HLP_TextBox)ctr).errorProvider1.Dispose();
                        if (((HLP_TextBox)ctr)._Obrigatorio == HLP_TextBox.CampoObrigatorio.SIM && ((HLP_TextBox)ctr).Text.Equals(""))
                        {
                            ((HLP_TextBox)ctr).errorProvider1.SetError(((HLP_TextBox)ctr), CAMPO_OBRIGATORIO);
                            iErros++;
                            TextValido = false;
                        }
                        if (TextValido)
                        {
                            if (((HLP_TextBox)ctr)._Regex != Expressoes.Não_Aplica)
                            {
                                if (((HLP_TextBox)ctr)._Obrigatorio == HLP_TextBox.CampoObrigatorio.NÃO && !((HLP_TextBox)ctr).Text.Equals(""))
                                {
                                    reg = new Regex(RetornaExpressao(((HLP_TextBox)ctr)._Regex));
                                    if (!reg.IsMatch(((HLP_TextBox)ctr).Text))
                                    {
                                        ((HLP_TextBox)ctr).errorProvider1.SetError(((HLP_TextBox)ctr), CAMPO_INVALIDO);
                                        iErros++;
                                    }
                                }
                                else if (((HLP_TextBox)ctr)._Obrigatorio == HLP_TextBox.CampoObrigatorio.SIM)
                                {
                                    reg = new Regex(RetornaExpressao(((HLP_TextBox)ctr)._Regex));
                                    if (!reg.IsMatch(((HLP_TextBox)ctr).Text))
                                    {
                                        ((HLP_TextBox)ctr).errorProvider1.SetError(((HLP_TextBox)ctr), CAMPO_INVALIDO);
                                        iErros++;
                                    }
                                }
                            }
                        }
                    }

                    #endregion

                }

                if (iErros > 0)
                {
                    if (GerarException)
                    {
                        throw new Exception(Mensagens.CCampoVazio_Incorreto);
                    }
                }
                return iErros;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static void BuscaNomeTabPage(Control ctr)
        {
            if (ctr.GetType() == typeof(TabPage))
            {
                sNOME_TAB = ctr.Text;
            }
            else
            {
                BuscaNomeTabPage(ctr.Parent);
            }
        }

        public static void ValidarTodosDocumentos(Control.ControlCollection controls, string sNumeroDocumento)
        {
            try
            {

                Componentes = new List<Control>();
                CarregaComponentes(controls);
                if (Componentes.Count > 0)
                {
                    sNOME_TAB = "";
                    BuscaNomeTabPage(Componentes[0]);
                }

                Regex reg = null;
                foreach (Control ctr in Componentes)
                {

                    ListaErros objErros = new ListaErros();
                    objErros.NumeroDocumento = sNumeroDocumento;



                    #region ComboBox

                    if (ctr.GetType() == typeof(HLP_ComboBox))
                    {
                        ((HLP_ComboBox)ctr).errorProvider1.Dispose();
                        if (((HLP_ComboBox)ctr)._Obrigatorio == HLP_ComboBox.CampoObrigatorio.SIM && ((HLP_ComboBox)ctr).SelectedIndex == -1)
                        {
                            ((HLP_ComboBox)ctr).errorProvider1.SetError(((HLP_ComboBox)ctr), CAMPO_OBRIGATORIO);
                            iErros++;
                            objErros.Descricao += sNOME_TAB + " - " + ((HLP_ComboBox)ctr)._LabelText + " - " + CAMPO_OBRIGATORIO + Environment.NewLine;
                        }
                    }

                    #endregion

                    #region DateTimePicker

                    if (ctr.GetType() == typeof(HLP_DateTimePicker))
                    {
                        ((HLP_DateTimePicker)ctr).errorProvider1.Dispose();
                        if (((HLP_DateTimePicker)ctr)._Obrigatorio == HLP_DateTimePicker.CampoObrigatorio.SIM && ((HLP_DateTimePicker)ctr).Value == null)
                        {
                            ((HLP_DateTimePicker)ctr).errorProvider1.SetError(((HLP_DateTimePicker)ctr), CAMPO_OBRIGATORIO);
                            iErros++;
                            objErros.Descricao += sNOME_TAB + " - " + ((HLP_DateTimePicker)ctr)._LabelText + " - " + CAMPO_OBRIGATORIO + Environment.NewLine;
                        }
                    }

                    #endregion

                    #region MaskedTextBox

                    if (ctr.GetType() == typeof(HLP_MaskedTextBox))
                    {
                        bool MaskValido = true;
                        ((HLP_MaskedTextBox)ctr).errorProvider1.Dispose();
                        if (((HLP_MaskedTextBox)ctr)._Obrigatorio == HLP_MaskedTextBox.CampoObrigatorio.SIM && ((HLP_MaskedTextBox)ctr).Text.Equals(""))
                        {
                            ((HLP_MaskedTextBox)ctr).errorProvider1.SetError(((HLP_MaskedTextBox)ctr), CAMPO_OBRIGATORIO);
                            iErros++;
                            objErros.Descricao += sNOME_TAB + " - " + ((HLP_MaskedTextBox)ctr)._LabelText + " - " + CAMPO_OBRIGATORIO + Environment.NewLine;
                            MaskValido = false;
                        }
                        if (MaskValido)
                        {
                            if (((HLP_MaskedTextBox)ctr)._Regex != Expressoes.Não_Aplica)
                            {
                                if (((HLP_MaskedTextBox)ctr)._Obrigatorio == HLP_MaskedTextBox.CampoObrigatorio.NÃO && !((HLP_MaskedTextBox)ctr).Text.Equals(""))
                                {
                                    reg = new Regex(RetornaExpressao(((HLP_MaskedTextBox)ctr)._Regex));
                                    if (!reg.IsMatch(((HLP_MaskedTextBox)ctr).Text))
                                    {
                                        ((HLP_MaskedTextBox)ctr).errorProvider1.SetError(((HLP_MaskedTextBox)ctr), CAMPO_INVALIDO);
                                        iErros++;
                                        objErros.Descricao += sNOME_TAB + " - " + ((HLP_MaskedTextBox)ctr)._LabelText + " - " + CAMPO_INVALIDO + Environment.NewLine;
                                    }
                                }
                                else if (((HLP_MaskedTextBox)ctr)._Obrigatorio == HLP_MaskedTextBox.CampoObrigatorio.SIM)
                                {
                                    reg = new Regex(RetornaExpressao(((HLP_MaskedTextBox)ctr)._Regex));
                                    if (!reg.IsMatch(((HLP_MaskedTextBox)ctr).Text))
                                    {
                                        ((HLP_MaskedTextBox)ctr).errorProvider1.SetError(((HLP_MaskedTextBox)ctr), CAMPO_INVALIDO);
                                        iErros++;
                                        objErros.Descricao += sNOME_TAB + " - " + ((HLP_MaskedTextBox)ctr)._LabelText + " - " + CAMPO_INVALIDO + Environment.NewLine;
                                    }
                                }
                            }
                        }
                    }

                    #endregion

                    #region NumericUpDown

                    if (ctr.GetType() == typeof(HLP_NumericUpDown))
                    {
                        ((HLP_NumericUpDown)ctr).errorProvider1.Dispose();
                        if (((HLP_NumericUpDown)ctr)._Obrigatorio == HLP_NumericUpDown.CampoObrigatorio.SIM && ((HLP_NumericUpDown)ctr).Text.Equals(""))
                        {
                            ((HLP_NumericUpDown)ctr).errorProvider1.SetError(((HLP_NumericUpDown)ctr), CAMPO_OBRIGATORIO);
                            iErros++;
                            objErros.Descricao += sNOME_TAB + " - " + ((HLP_NumericUpDown)ctr)._LabelText + " - " + CAMPO_OBRIGATORIO + Environment.NewLine;
                        }
                    }

                    #endregion

                    #region TextBox

                    if (ctr.GetType() == typeof(HLP_TextBox))
                    {
                        bool TextValido = true;
                        ((HLP_TextBox)ctr).errorProvider1.Dispose();
                        if (((HLP_TextBox)ctr)._Obrigatorio == HLP_TextBox.CampoObrigatorio.SIM && ((HLP_TextBox)ctr).Text.Equals(""))
                        {
                            ((HLP_TextBox)ctr).errorProvider1.SetError(((HLP_TextBox)ctr), CAMPO_OBRIGATORIO);
                            iErros++;
                            objErros.Descricao += sNOME_TAB + " - " + ((HLP_TextBox)ctr)._LabelText + " - " + CAMPO_OBRIGATORIO + Environment.NewLine;
                            TextValido = false;
                        }
                        if (TextValido)
                        {
                            if (((HLP_TextBox)ctr)._Regex != Expressoes.Não_Aplica)
                            {
                                if (((HLP_TextBox)ctr)._Obrigatorio == HLP_TextBox.CampoObrigatorio.NÃO && !((HLP_TextBox)ctr).Text.Equals(""))
                                {
                                    reg = new Regex(RetornaExpressao(((HLP_TextBox)ctr)._Regex));
                                    if (!reg.IsMatch(((HLP_TextBox)ctr).Text))
                                    {
                                        ((HLP_TextBox)ctr).errorProvider1.SetError(((HLP_TextBox)ctr), CAMPO_INVALIDO);
                                        iErros++;
                                        objErros.Descricao += sNOME_TAB + " - " + ((HLP_TextBox)ctr)._LabelText + " - " + CAMPO_INVALIDO + Environment.NewLine;
                                    }
                                }
                                else if (((HLP_TextBox)ctr)._Obrigatorio == HLP_TextBox.CampoObrigatorio.SIM)
                                {
                                    reg = new Regex(RetornaExpressao(((HLP_TextBox)ctr)._Regex));
                                    if (!reg.IsMatch(((HLP_TextBox)ctr).Text))
                                    {
                                        ((HLP_TextBox)ctr).errorProvider1.SetError(((HLP_TextBox)ctr), CAMPO_INVALIDO);
                                        iErros++;
                                        objErros.Descricao += sNOME_TAB + " - " + ((HLP_TextBox)ctr)._LabelText + " - " + CAMPO_INVALIDO + Environment.NewLine;
                                    }
                                }
                            }
                        }
                    }

                    #endregion

                    if (objErros.Descricao != null)
                    {
                        objErros.Descricao = "Nº Documento :" + objErros.NumeroDocumento + " - " + objErros.Descricao;
                        objErros.controle = ctr;
                        objListaTodosErros.Add(objErros);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void LimpaErros()
        {
            iErros = 0;
            objListaTodosErros = new List<ListaErros>();
        }

        private static void CarregaComponentes(Control.ControlCollection controls)
        {
            foreach (Control crt in controls)
            {
                if (crt.HasChildren == true && crt.GetType().BaseType != typeof(UserControl))
                {
                    CarregaComponentes(crt.Controls);
                }
                else if (crt.GetType().BaseType == typeof(UserControl))
                {
                    if (!Componentes.Contains(crt))
                    {
                        Componentes.Add(crt);
                    }
                }
            }
        }

        public static string RetornaExpressao(Expressoes reg)
        {
            string Ex = "";
            switch (reg)
            {
                case Expressoes.ER1:
                    Ex = @"^[0-9]{2}$";
                    break;

                case Expressoes.ER2:
                    Ex = @"[0-9]{7}$";
                    break;

                case Expressoes.ER3:
                    Ex = @"[0-9]{44}$";
                    break;

                case Expressoes.ER4:
                    Ex = @"^[0-9]{14}$";
                    break;

                case Expressoes.ER5:
                    Ex = @"^[0-9]{3,14}$";
                    break;

                case Expressoes.ER6:
                    Ex = @"^[0-9]{0}|[0-9]{14}$";
                    break;

                case Expressoes.ER7:
                    Ex = @"^[0-9]{11}$";
                    break;

                case Expressoes.ER8:
                    Ex = @"^[0-9]{3,11}$";
                    break;

                case Expressoes.ER9:
                    Ex = @"^(((20(([02468][048])|([13579][26]))-02-29))|(20[0-9][0-9])-((((0[1-9])|(1[0-2]))-((0[1-9])|(1\d)|(2[0-8])))|((((0[13578])|(1[02]))-31)|(((0[1,3-9])|(1[0-2]))-(29|30)))))$";
                    break;

                case Expressoes.ER10:
                    Ex = @"^0|0\.[0-9]{2}|[1-9]{1}[0-9]{0,2}(\.[0-9]{2})?$";
                    break;

                case Expressoes.ER11:
                    Ex = @"^0\.[0-9]{1}[1-9]{1}|0\.[1-9]{1}[0-9]{1}|[1-9]{1}[0-9]{0,2}(\.[0-9]{2})?$";
                    break;

                case Expressoes.ER12:
                    Ex = @"^0|0\.[0-9]{3}|[1-9]{1}[0-9]{0,7}(\.[0-9]{3})?$";
                    break;

                case Expressoes.ER13:
                    Ex = @"^0\.[1-9]{1}[0-9]{2}|0\.[0-9]{2}[1-9]{1}|0\.[0-9]{1}[1-9]{1}[0-9]{1}|[1-9]{1}[0-9]{0,7}(\.[0-9]{3})?$";
                    break;

                case Expressoes.ER14:
                    Ex = @"^0|0\.[0-9]{4}|[1-9]{1}[0-9]{0,7}(\.[0-9]{4})?$";
                    break;

                case Expressoes.ER15:
                    Ex = @"^0\.[1-9]{1}[0-9]{3}|0\.[0-9]{3}[1-9]{1}|0\.[0-9]{2}[1-9]{1}[0-9]{1}|0\.[0-9]{1}[1-9]{1}[0-9]{2}|[1-9]{1}[0-9]{0,7}(\.[0-9]{4})?$";
                    break;

                case Expressoes.ER16:
                    Ex = @"^0\.[1-9]{1}[0-9]{5}|0\.[0-9]{1}[1-9]{1}[0-9]{4}|0\.[0-9]{2}[1-9]{1}[0-9]{3}|0\.[0-9]{3}[1-9]{1}[0-9]{2}|0\.[0-9]{4}[1-9]{1}[0-9]{1}|0\.[0-9]{5}[1-9]{1}|[1-9]{1}[0-
                         9]{0,8}(\.[0-9]{6})?$";
                    break;

                case Expressoes.ER17:
                    Ex = @"^0|0\.[0-9]{4}|[1-9]{1}[0-9]{0,10}(\.[0-9]{4})?$";
                    break;


                case Expressoes.ER18:
                    Ex = @"^0\.[1-9]{1}[0-9]{3}|0\.[0-9]{3}[1-9]{1}|0\.[0-9]{2}[1-9]{1}[0-9]{1}|0\.[0-9]{1}[1-9]{1}[0-9]{2}|[1-9]{1}[0-9]{0,10}(\.[0-9]{4})?$";
                    break;

                case Expressoes.ER19:
                    Ex = @"^0|0\.[0-9]{3}|[1-9]{1}[0-9]{0,11}(\.[0-9]{3})?$";
                    break;


                case Expressoes.ER20:
                    Ex = @"^0\.[1-9]{1}[0-9]{2}|0\.[0-9]{2}[1-9]{1}|0\.[0-9]{1}[1-9]{1}[0-9]{1}|[1-9]{1}[0-9]{0,11}(\.[0-9]{3})?$";
                    break;

                case Expressoes.ER21:
                    Ex = @"^0|0\.[0-9]{4}|[1-9]{1}[0-9]{0,11}(\.[0-9]{4})?$";
                    break;

                case Expressoes.ER22:
                    Ex = @"^0\.[1-9]{1}[0-9]{3}|0\.[0-9]{3}[1-9]{1}|0\.[0-9]{2}[1-9]{1}[0-9]{1}|0\.[0-9]{1}[1-9]{1}[0-9]{2}|[1-9]{1}[0-9]{0,11}(\.[0-9]{4})?$";
                    break;

                case Expressoes.ER23:
                    Ex = @"^0|0\.[0-9]{2}|[1-9]{1}[0-9]{0,12}(\.[0-9]{2})?$";
                    break;

                case Expressoes.ER24:
                    Ex = @"^0\.[0-9]{1}[1-9]{1}|0\.[1-9]{1}[0-9]{1}|[1-9]{1}[0-9]{0,12}(\.[0-9]{2})?$";
                    break;

                case Expressoes.ER25:
                    Ex = @"^[0-9]{2,14}$";
                    break;

                case Expressoes.ER26:
                    Ex = @"^[0-9]{0,14}|ISENTO|PR[0-9]{4,8}$";
                    break;

                case Expressoes.ER27:
                    Ex = @"^[0-9]{1,4}$";
                    break;

                case Expressoes.ER28:
                    Ex = @"^[1-9]{1}[0-9]{0,8}$";
                    break;

                case Expressoes.ER29:
                    Ex = @"^[0-9]{15}$";
                    break;


                case Expressoes.ER30:
                    Ex = @"^0|[1-9]{1}[0-9]{0,2}$";
                    break;

                case Expressoes.ER31:
                    Ex = @"^[0-9]{3}$";
                    break;

                case Expressoes.ER32:
                    Ex = @"^[!-ÿ]{1}[ -ÿ]{0,}[!-ÿ]{1}|[!-ÿ]{1}$";
                    break;

                case Expressoes.ER33:
                    Ex = @"^[0-9]{8}$";
                    break;

                case Expressoes.ER34:
                    Ex = @"^(((20(([02468][048])|([13579][26]))-02-29))|(20[0-9][0-9])-((((0[1-9])|(1[0-2]))-((0[1-9])|(1\d)|(2[0-8])))|((((0[13578])|(1[02]))-31)|(((0[1,3-9])|(1[0-2]))-
                        (29|30)))))T(20|21|22|23|[0-1]\d):[0-5]\d:[0-5]\d$";
                    break;

                case Expressoes.ER35:
                    Ex = @"^[0-9]{1}$";
                    break;

                case Expressoes.ER36:
                    Ex = @"^[!-ÿ]{1}[ -ÿ]{0,}[!-ÿ]{1}|[!-ÿ]{1}$";
                    break;

                case Expressoes.ER37:
                    Ex = @"^[1-9]{1}[0-9]{1,8}$";
                    break;

                case Expressoes.ER38:
                    Ex = @"^[0-9]{8,9}$";
                    break;

                case Expressoes.ER39:
                    Ex = @"^[0-9]{1,20}$";
                    break;

                case Expressoes.ER40:
                    Ex = @"^1\.04$";
                    break;


                case Expressoes.ER41:
                    Ex = @"^[1-9]{1}[0-9]{0,3}|ND$";
                    break;

                case Expressoes.ER42:
                    Ex = @"^[A-Z0-9]+$";
                    break;

                case Expressoes.ER43:
                    Ex = @"^[0-9]{1,6}$";
                    break;

                case Expressoes.ER44:
                    Ex = @"^CTe[0-9]{44}$";
                    break;

                case Expressoes.ER45:
                    Ex = @"^[0-9]{7,10}$";
                    break;

                case Expressoes.ER46:
                    Ex = @"^[123567][0-9]([0-9][1-9]|[1-9][0-9])$";
                    break;

                case Expressoes.ER47:
                    Ex = @"^[^@]+@[^\.]+\..+$";
                    break;

                case Expressoes.ER48:
                    Ex = @"^[0-9]{1,15}$";
                    break;

                case Expressoes.ER49:
                    Ex = @"^(([0-1][0-9])|([2][0-3])):([0-5][0-9]):([0-5][0-9])$";
                    break;

                case Expressoes.ER50:
                    Ex = @"^[A-Z]{3}(([1-9]\d{3})|(0[1-9]\d{2})|(00[1-9]\d)|(000[1-9]))$";
                    break;

                case Expressoes.ER51:
                    Ex = @"^[0-9]{12}$";
                    break;

                case Expressoes.ER52:
                    Ex = @"^[1-9]{1}[0-9]{0,5}$";
                    break;

                case Expressoes.ER53:
                    Ex = @"^0|[1-9]{1}[0-9]{0,5}$";
                    break;

                case Expressoes.ER54:
                    Ex = @"^[0-9]{9}$";
                    break;

                case Expressoes.ER55:
                    Ex = @"^M$";
                    break;

                case Expressoes.ER56:
                    Ex = @"^[1-9]{1}[0-9]{0,9}$";
                    break;
            }
            return Ex;
        }
    }
}
