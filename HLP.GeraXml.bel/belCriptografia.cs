using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HLP.GeraXml.bel
{
    public static class belCriptografia
    {
        public static string Encripta(string strTexto)
        {
            char[] arraysenha = strTexto.ToCharArray();
            for (int i = 0; i < arraysenha.Length; i++)
            {
                int digito = (arraysenha[i] + 125 + i + 1);
                arraysenha[i] = (char)digito;
            }
            string strResultado = new string(arraysenha);
            return strResultado;
        }

        public static string Decripta(string strTexto)
        {
            char[] arraysenha = strTexto.ToCharArray();
            for (int i = 0; i < arraysenha.Length; i++)
            {
                int digito = (arraysenha[i] - 125 - i - 1);
                arraysenha[i] = (char)digito;
            }
            string strResultado = new string(arraysenha);
            return strResultado;
        }
    }
}
