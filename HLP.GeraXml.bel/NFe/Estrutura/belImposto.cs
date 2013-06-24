using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HLP.GeraXml.bel.NFe.Estrutura
{
    public class belImposto
    {
        /// <summary>
        /// </summary>
        private belIcms _belIcms;
        private belIpi _belIpi;
        private belIi _belIi;
        private belPis _belPis;
        private belCofins _belCofins;
        private belIss _belIss;
        public decimal nitem { get; set; }
        


        public belIcms belIcms
        {
            get
            {
                return _belIcms;
            }
            set
            {
                _belIcms = value;
            }
        }

        public belIpi belIpi
        {
            get
            {
                return _belIpi;
            }
            set
            {
                _belIpi = value;
            }
        }

        public belIi belIi
        {
            get
            {
                return _belIi;
            }
            set
            {
                _belIi = value;
            }
        }

        public belPis belPis
        {
            get
            {
                return _belPis;
            }
            set
            {
                _belPis = value;
            }
        }

        public belCofins belCofins
        {
            get
            {
                return _belCofins;
            }
            set
            {
                _belCofins = value;
            }
        }

        public belIss belIss
        {
            get
            {
                return _belIss;
            }
            set
            {
                _belIss = value;
            }
        }

        public struct cbx
        {
            public string descricao { get; set; }
            public string codigo { get; set; }
        }

        public static List<cbx> CarregaMotivoDesoneracao()
        {
            List<cbx> lst = new List<cbx>();

            lst.Add(new cbx { codigo = "1", descricao = "1 – Táxi" });
            lst.Add(new cbx { codigo = "2", descricao = "2 – Deficiente Físico" });
            lst.Add(new cbx { codigo = "3", descricao = "3 – Produtor Agropecuário" });
            lst.Add(new cbx { codigo = "4", descricao = "4 – Frotista/Locadora" });
            lst.Add(new cbx { codigo = "5", descricao = "5 – Diplomático/Consular" });
            lst.Add(new cbx { codigo = "6", descricao = "6 – Utilitários e Motocicletas da Amazônia Ocidental" });
            lst.Add(new cbx { codigo = "7", descricao = "7 – SUFRAMA" });
            lst.Add(new cbx { codigo = "9", descricao = "9 – outros" });


            return lst;

        }
        public static List<cbx> CarregaCSTcomboBox()
        {
            List<cbx> lst = new List<cbx>();

            lst.Add(new cbx { codigo = "00", descricao = "00  – Tributada integralmente" });
            lst.Add(new cbx { codigo = "10", descricao = "10  – Tributada e com cobrança do ICMS por substituição tributária" });
            lst.Add(new cbx { codigo = "20", descricao = "20  – Com redução de base de cálculo" });
            lst.Add(new cbx { codigo = "30", descricao = "30  – Isenta ou não tributada e com cobrança do ICMS por substituição tributária" });
            lst.Add(new cbx { codigo = "40", descricao = "40  – Isenta" });
            lst.Add(new cbx { codigo = "41", descricao = "41  – Não tributada" });
            lst.Add(new cbx { codigo = "50", descricao = "50  – Com suspensão" });
            lst.Add(new cbx { codigo = "51", descricao = "51  – Com diferimento" });
            lst.Add(new cbx { codigo = "60", descricao = "60  – ICMS cobrado anteriormente por substituição tributária" });
            lst.Add(new cbx { codigo = "70", descricao = "70  – Com redução da base de cálculo e cobrança do ICMS por substituição tributária" });
            lst.Add(new cbx { codigo = "90", descricao = "90  – Outras" });
            lst.Add(new cbx { codigo = "101", descricao = "101 – Tributada pelo Simples Nacional com permissão de crédito" });
            lst.Add(new cbx { codigo = "102", descricao = "102 – Tributada pelo Simples Nacional sem permissão de crédito" });
            lst.Add(new cbx { codigo = "103", descricao = "103 – Isenção do ICMS no Simples Nacional para faixa de receita bruta" });
            lst.Add(new cbx { codigo = "201", descricao = "201 – Trib. pelo Simp. Nac. c/ permissão de créd e com cobr do ICMS por ST" });
            lst.Add(new cbx { codigo = "202", descricao = "202 – Trib. pelo Simp. Nac. s/ permissão de créd e com cobr do ICMS por ST" });
            lst.Add(new cbx { codigo = "203", descricao = "203 – Isenção do ICMS no Simp Nac para faixa de receita bruta e com cobrança do ICMS por ST" });
            lst.Add(new cbx { codigo = "300", descricao = "300 – Imune" });
            lst.Add(new cbx { codigo = "400", descricao = "400 – Não tributada pelo Simples Nacional" });
            lst.Add(new cbx { codigo = "500", descricao = "500 – ICMS cobrado anter por ST (substituído) ou por antecipação" });
            lst.Add(new cbx { codigo = "900", descricao = "900 – Outros" });


            return lst;

        }

        public static List<cbx> CarregaIPIcomboBox()
        {
            List<cbx> lst = new List<cbx>();
            lst.Add(new cbx { codigo = "00", descricao = "00-Entrada com recuperação de crédito" });
            lst.Add(new cbx { codigo = "49", descricao = "49-Outras entradas" });
            lst.Add(new cbx { codigo = "50", descricao = "50-Saída tributada" });
            lst.Add(new cbx { codigo = "99", descricao = "99-Outras saídas" });
            lst.Add(new cbx { codigo = "01", descricao = "01-Entrada tributada com alíquota zero" });
            lst.Add(new cbx { codigo = "02", descricao = "02-Entrada isenta" });
            lst.Add(new cbx { codigo = "03", descricao = "03-Entrada não-tributada" });
            lst.Add(new cbx { codigo = "04", descricao = "04-Entrada imune" });
            lst.Add(new cbx { codigo = "05", descricao = "05-Entrada com suspensão" });
            lst.Add(new cbx { codigo = "51", descricao = "51-Saída tributada com alíquota zero" });
            lst.Add(new cbx { codigo = "52", descricao = "52-Saída isenta" });
            lst.Add(new cbx { codigo = "53", descricao = "53-Saída não-tributada" });
            lst.Add(new cbx { codigo = "54", descricao = "54-Saída imune" });
            lst.Add(new cbx { codigo = "55", descricao = "55-Saída com suspensão" });
            return lst;
        }

        public static List<cbx> CarregaPIS_COFINScomboBox()
        {
            List<cbx> lst = new List<cbx>();
            lst.Add(new cbx { codigo = "01", descricao = "01 - Oper. Trib com Aliq Básica" });
            lst.Add(new cbx { codigo = "02", descricao = "02 - Oper. Trib com Aliq Diferenciada" });
            lst.Add(new cbx { codigo = "03", descricao = "03 - Oper. Trib com Aliq por Unidade de Medida de Produto" });
            lst.Add(new cbx { codigo = "04", descricao = "04 - Oper. Trib Monofásica - Revenda a Aliq Zero" });
            lst.Add(new cbx { codigo = "05", descricao = "05 - Oper. Trib por Substituição Tributária" });
            lst.Add(new cbx { codigo = "06", descricao = "06 - Oper. Trib a Aliq Zero" });
            lst.Add(new cbx { codigo = "07", descricao = "07 - Oper. Isenta da Contribuição" });
            lst.Add(new cbx { codigo = "08", descricao = "08 - Oper. sem Incidência da Contribuição" });
            lst.Add(new cbx { codigo = "09", descricao = "09 - Oper. com Suspensão da Contribuição" });
            lst.Add(new cbx { codigo = "49", descricao = "49 - Outras Operações de Saída" });
            lst.Add(new cbx { codigo = "50", descricao = "50 - Oper. com Direito a Créd - Vinc. Exclusiv a Receita Trib no Mercado Interno" });
            lst.Add(new cbx { codigo = "51", descricao = "51 - Oper. com Direito a Créd – Vinc. Exclusiv a Receita Não Trib no Mercado Interno" });
            lst.Add(new cbx { codigo = "52", descricao = "52 - Oper. com Direito a Créd - Vinc. Exclusiv a Receita de Export" });
            lst.Add(new cbx { codigo = "53", descricao = "53 - Oper. com Direito a Créd - Vinc. a Receitas Tribs e Não-Tribs no Mercado Interno" });
            lst.Add(new cbx { codigo = "54", descricao = "54 - Oper. com Direito a Créd - Vinc. a Receitas Tribs no Mercado Interno e de Export" });
            lst.Add(new cbx { codigo = "55", descricao = "55 - Oper. com Direito a Créd - Vinc. a Receitas Não-Tribs no Mercado Interno e de Export" });
            lst.Add(new cbx { codigo = "56", descricao = "56 - Oper. com Direito a Créd - Vinc. a Receitas Tribs e Não-Tribs no Mercado Interno, e de Export" });
            lst.Add(new cbx { codigo = "60", descricao = "60 - Créd Presum. - Oper de Aquis. Vinc. Exclusiv a Receita Trib no Mercado Interno" });
            lst.Add(new cbx { codigo = "61", descricao = "61 - Créd Presum. - Oper de Aquis. Vinc. Exclusiv a Receita Não-Trib no Mercado Interno" });
            lst.Add(new cbx { codigo = "62", descricao = "62 - Créd Presum. - Oper de Aquis. Vinc. Exclusiv a Receita de Export" });
            lst.Add(new cbx { codigo = "63", descricao = "63 - Créd Presum. - Oper de Aquis. Vinc. a Receitas Tribs e Não-Tribs no Mercado Interno" });
            lst.Add(new cbx { codigo = "64", descricao = "64 - Créd Presum. - Oper de Aquis. Vinc. a Receitas Tribs no Mercado Interno e de Export" });
            lst.Add(new cbx { codigo = "65", descricao = "65 - Créd Presum. - Oper de Aquis. Vinc. a Receitas Não-Tribs no Mercado Interno e de Export" });
            lst.Add(new cbx { codigo = "66", descricao = "66 - Créd Presum. - Oper de Aquis. Vinc. a Receitas Tribs e Não-Tribs no Mercado Interno, e de Export" });
            lst.Add(new cbx { codigo = "67", descricao = "67 - Créd Presum. - Outras Operações" });
            lst.Add(new cbx { codigo = "70", descricao = "70 - Oper. de Aquisição sem Direito a Créd" });
            lst.Add(new cbx { codigo = "71", descricao = "71 - Oper. de Aquisição com Isenção" });
            lst.Add(new cbx { codigo = "72", descricao = "72 - Oper. de Aquisição com Suspensão" });
            lst.Add(new cbx { codigo = "73", descricao = "73 - Oper. de Aquisição a Aliq Zero" });
            lst.Add(new cbx { codigo = "74", descricao = "74 - Oper. de Aquisição sem Incidência da Contribuição" });
            lst.Add(new cbx { codigo = "75", descricao = "75 - Oper. de Aquisição por Substituição Tributária" });
            lst.Add(new cbx { codigo = "98", descricao = "98 - Outras Operações de Entrada" });
            lst.Add(new cbx { codigo = "99", descricao = "99 - Outras Operações" });

            return lst;
        }

        public static List<cbx> CarregaISSQNcomboBox()
        {
            List<cbx> lst = new List<cbx>();
            lst.Add(new cbx { codigo = "N", descricao = "N – NORMAL" });
            lst.Add(new cbx { codigo = "R", descricao = "R – RETIDA" });
            lst.Add(new cbx { codigo = "S", descricao = "S – SUBSTITUTA" });
            lst.Add(new cbx { codigo = "I", descricao = "I – ISENTA" });
            return lst;
        }
    }
}
