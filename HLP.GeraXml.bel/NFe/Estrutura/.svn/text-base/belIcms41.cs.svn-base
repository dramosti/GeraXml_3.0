using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HLP.GeraXml.bel.NFe.Estrutura
{
    public class belIcms41
    {
        /// <summary>
        /// Tributação do ICMS; 00 - Atribuida Integralmente.
        /// </summary>
        private string _cst;

        public string Cst
        {
            get { return _cst; }
            set { _cst = value; }
        }

        /// <summary>
        /// Origem da Mercadoria; 0 - Nacional; 1 - Estrangeira, Importação direta; 2 - Estrangeira, Adquirida no merdado interno.
        /// </summary>
        private string _orig;

        public string Orig
        {
            get { return _orig; }
            set { _orig = value; }
        }
        /// <summary>
        /// Este campo será preenchido quando o campo anterior estiver preenchido. Informar o motivo da desoneração:
        /// 1 – Táxi;
        /// 2 – Deficiente Físico;
        /// 3 – Produtor Agropecuário;
        /// 4 – Frotista/Locadora;
        /// 5 – Diplomático/Consular;
        /// 6 – Utilitários e Motocicletas da Amazônia Ocidental e Áreas de Livre Comércio (Resolução 714/88 e 790/94 – CONTRAN e suas alterações);
        /// 7 – SUFRAMA;
        /// 9 – outros. (v2.0)
        /// </summary>
        public int motDesICMS { get; set; }

        /// <summary>
        /// O valor do ICMS será informado apenas nas operações com veículos beneficiados com a desoneração condicional do ICMS. (v2.0)
        /// </summary>
        public decimal Vicms { get; set; }
    }
}
