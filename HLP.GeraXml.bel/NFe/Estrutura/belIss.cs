using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HLP.GeraXml.bel.NFe.Estrutura
{
    public class belIss
    {
        /// <summary>
        /// Valor do ISSQN
        /// </summary>
        private decimal _vissqn;

        public decimal Vissqn
        {
            get { return _vissqn; }
            set { _vissqn = value; }
        }

        /// <summary>
        /// Valor de Cálculo do ISSQN
        /// </summary>
        private decimal _vbc;

        public decimal Vbc
        {
            get { return _vbc; }
            set { _vbc = value; }
        }

        /// <summary>
        /// Alíquota do ISSQN
        /// </summary>
        private decimal _valiq;

        public decimal Valiq
        {
            get { return _valiq; }
            set { _valiq = value; }
        }

        /// <summary>
        /// Código do município de ocorrência do fato gerador do ISSQN
        /// </summary>
        private string _cmunfg;

        public string Cmunfg
        {
            get { return _cmunfg; }
            set { _cmunfg = value; }
        }

        /// <summary>
        /// Código da Lista de Serviços
        /// </summary>
        private Int64 _clistserv;

        public Int64 Clistserv
        {
            get { return _clistserv; }
            set { _clistserv = value; }
        }

        private string _cSitTrib = "N";

        public string cSitTrib
        {
            get { return _cSitTrib; }
            set { _cSitTrib = value; }
        }
    }
}
