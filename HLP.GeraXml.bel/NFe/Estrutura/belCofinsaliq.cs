using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HLP.GeraXml.bel.NFe.Estrutura
{
    public class belCofinsaliq
    {
        /// <summary>
        /// Código de Situação Tributária do COFINS;
        /// TAG DE GRUPO DO COFINS, NOME DA TAG É COFINSAliq
        /// 01 - Operação Tributável (base de cálculo = valor da operação alíquota normal (cumulativo/não Cumulativo))
        /// 02 - Operaçao Tributável (base de calculo = valor da operção (alíquota diferencida))
        /// TAG DO GRUOP DE COFINS TRIBUTADO POR QTDE, NOME DA TAG É COFINSQtde
        /// 03 - Operação Tributável (base de cálculo = quantidade vendida _xserv alíquota or unidade de produto)
        /// TAG DO GRUPO DE COFINS NÃO TRIBUTADO, NOME DA TAG É COFINSNT;
        /// 04 - Operação Tributável (tributação  monofásica(aliquota zero)
        /// 06 - Operação Tributável (alpiquota zero)
        /// 07 - Operação Isenta da Contribuição
        /// 08 - Operação Sem Incidência da Contribuição
        /// 09 - Operaçao com Suspensão da contribução
        /// TAG DO GRUPO DE COFINS OUTRAS OPERAÇÕES, NOME DA TAG É COFINSOutr
        /// 99 - Outras Operação
        /// TAG DO GRUPO DE COFINS SUBISTITUIÇÃO TRIBUTARIA, NOME DA TAG É COFINSST
        /// Infomrar campos para cálculo do COFINS Substituição Tributária em percentual (T02 E t03) ou campos para COFINS em valor (T04 e T05)
        /// </summary>
        private string _cst;

        public string Cst
        {
            get { return _cst; }
            set { _cst = value; }
        }

        /// <summary>
        /// Valor do COFINS
        /// </summary>
        private decimal _vcofins;

        public decimal Vcofins
        {
            get { return _vcofins; }
            set { _vcofins = value; }
        }

        /// <summary>
        /// Aliquota da COFINS (em percentual)
        /// </summary>
        private decimal _pcofins;

        public decimal Pcofins
        {
            get { return _pcofins; }
            set { _pcofins = value; }
        }

        /// <summary>
        /// Valor da Base de Cálculo da COFINS
        /// </summary>
        private decimal _vbc;

        public decimal Vbc
        {
            get { return _vbc; }
            set { _vbc = value; }
        }
    }
}
