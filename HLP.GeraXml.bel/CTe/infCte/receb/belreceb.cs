using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HLP.GeraXml.bel.CTe.infCte.receb
{
    public class belreceb
    {

        private string _CNPJ = "";
        /// <summary>
        /// 1:1 N TAMANHO 14 
        /// </summary>
        public string CNPJ
        {
            get { 
                return _CNPJ; 
            }
            set { _CNPJ = value; }
        }



        private string _CPF = "";
        /// <summary>
        /// 1:1 N TAMANHO 11 
        /// </summary>
        public string CPF
        {
            get { return _CPF; }
            set { _CPF = value; }
        }


        private string _IE = "";
        /// <summary>
        /// 1:1 C TAMANHO 0-14
        /// </summary>
        public string IE
        {
            get { return _IE; }
            set { _IE = value; }
        }

        private string _xNome = "";
        /// <summary>
        /// 1:1 C TAMANHO 1-60
        /// </summary>
        public string xNome
        {
            get
            {
                if (HLP.GeraXml.Comum.Static.Acesso.TP_AMB == 2)
                {
                    return "CT-E EMITIDO EM AMBIENTE DE HOMOLOGACAO – SEM VALOR FISCAL";
                   // return _xNome;
                }
                else
                {
                    return _xNome;
                }
            }
            set { _xNome = value; }
        }


        private string _fone = "";
        /// <summary>
        /// 0:1 N TAMANHO 7-12
        /// </summary>
        public string fone
        {
            get { return _fone; }
            set { _fone = value; }
        }


        /// <summary>
        /// 1:1
        /// </summary>
        public belenderReceb enderReceb { get; set; }
    }
}
