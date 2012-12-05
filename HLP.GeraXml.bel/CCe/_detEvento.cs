using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HLP.GeraXml.bel.CCe
{
    public class _detEvento
    {
        /// <summary>
        /// Descrição: versão da carta de correção  
        /// Ocorrencia:1-1
        /// </summary>
        public string versao { get; set; }
        /// <summary>
        /// Descrição: “Carta de Correção”
        /// Ocorrencia:1-1
        /// </summary>

        public string descEvento
        {
            get { return "Carta de Correção"; }
        }
        /// <summary>
        /// Descrição: Correção a ser considerada, texto livre. A correção mais recente substitui as anteriores. 
        /// Ocorrencia:1-1
        /// Tamanho:15 - 1000
        /// </summary>
        public string xCorrecao { get; set; }
        /// <summary>
        /// Descrição: ondições de uso da Carta de Correção, informar a literal PADRAO.
        /// Ocorrencia:1-1
        /// </summary>

        public string xCondUso
        {
            get
            {
                return "A Carta de Correção é disciplinada pelo § 1º-A do art. 7º do Convênio S/N, de 15 de dezembro de 1970 e pode ser utilizada para regularização de erro ocorrido na emissão de documento fiscal, desde que o erro não esteja relacionado com: I - as variáveis que determinam o valor do imposto tais como: base de cálculo, alíquota, diferença de preço, quantidade, valor da operação ou da prestação; II - a correção de dados cadastrais que implique mudança do remetente ou do destinatário; III - a data de emissão ou de saída.";
            }
        }
    }
}
