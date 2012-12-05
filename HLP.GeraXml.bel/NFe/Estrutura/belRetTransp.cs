using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HLP.GeraXml.bel.NFe.Estrutura
{
    public class belRetTransp
    {
        /// <summary>
        /// Valor do Serviço
        /// </summary>
        private decimal _vserv;

        public decimal Vserv
        {
            get { return _vserv; }
            set { _vserv = value; }
        }

        /// <summary>
        /// BC da retençao do ICMS
        /// </summary>
        private decimal _vbvret;

        public decimal Vbvret
        {
            get { return _vbvret; }
            set { _vbvret = value; }
        }

        /// <summary>
        /// Alíquota da Retenção
        /// </summary>
        private decimal _picmsret;

        public decimal Picmsret
        {
            get { return _picmsret; }
            set { _picmsret = value; }
        }
        /// <summary>
        /// Valor do ICMS Retido
        /// </summary>
        private decimal _vicmsret;

        public decimal Vicmsret
        {
            get { return _vicmsret; }
            set { _vicmsret = value; }
        }
        /// <summary>
        /// CFOP
        /// </summary>
        private string _cfop;

        public string Cfop
        {
            get { return _cfop; }
            set { _cfop = value; }
        }
        /// <summary>
        /// Código do município de ocorrência do fato gerador do ICMS do transporte.
        /// </summary>
        private string _cmunfg;

        public string Cmunfg
        {
            get { return _cmunfg; }
            set { _cmunfg = value; }
        }
    }
}
