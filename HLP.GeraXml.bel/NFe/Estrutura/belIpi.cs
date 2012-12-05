using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HLP.GeraXml.bel.NFe.Estrutura
{
    public class belIpi
    {
        public string cst { get; set; }
        /// <summary>
        /// Preenchimento conforme Atos Normativos editados pela receita Federal (Observação 4).
        /// </summary>
        private string _clenq;

        public string Clenq
        {
            get { return _clenq; }
            set { _clenq = value; }
        }
        /// <summary>
        /// CNPJ do produtor da mercadoria, quando diferente do emitente. Somente para os caso de exportação direta ou indireta.
        /// </summary>
        private string _cnpjprod;

        public string Cnpjprod
        {
            get { return _cnpjprod; }
            set { _cnpjprod = value; }
        }
        /// <summary>
        /// Código do Selo de controle do IPI. Preenchimento conforme Atos Normtivos editado pela Receita Federa (Observação 3)
        /// </summary>
        private string _cselo;

        public string Cselo
        {
            get { return _cselo; }
            set { _cselo = value; }
        }
        /// <summary>
        /// Quantidade de selo de controle
        /// </summary>
        private string _qselo;

        public string Qselo
        {
            get { return _qselo; }
            set { _qselo = value; }
        }
        /// <summary>
        /// Código de enquadramento Lega do IPI. Tablea a ser criada ela RFB, Informar 999 quando a tabela nao for criada.
        /// </summary>
        private string _cenq;

        public string Cenq
        {
            get { return _cenq; }
            set { _cenq = value; }
        }

        public belIpint belIpint { get; set; }
        public belIpitrib belIpitrib { get; set; }

    }
}
