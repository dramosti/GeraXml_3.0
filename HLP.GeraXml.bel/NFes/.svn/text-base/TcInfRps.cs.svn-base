using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HLP.GeraXml.Comum.Static;

namespace HLP.GeraXml.bel.NFes
{
    /// <summary>
    /// Representa dados informativos do Recibo Provisório de Serviço (RPS)
    /// </summary>
    public class TcInfRps
    {
        /// <summary>
        /// (1-1)
        /// </summary>
        public tcIdentificacaoRps IdentificacaoRps { get; set; }

        /// <summary>
        /// </summary>
        private string _id = "1";
        /// <summary>
        /// (1-1) C-225 (Atributo de identificação da tag a ser assinada no documento xml)
        /// </summary>
        public string Id
        {
            get { return _id; }
            set { _id = Util.ValidaTamanhoMaximo(225, value); }
        }

        /// <summary>
        /// </summary>
        private DateTime _dataEmissao;
        /// <summary>
        /// (1-1)
        /// </summary>
        public DateTime DataEmissao
        {
            get { return _dataEmissao; }
            set { _dataEmissao = value; }
        }

        /// <summary>
        /// (1-1) I-2  Código de natureza da operação
        /// </summary>
        /// <remarks>
        /// Código de natureza da operação
        /// 1 – Tributação no município
        /// 2 - Tributação fora do município
        /// 3 - Isenção
        /// 4 - Imune
        /// 5 –Exigibilidade suspensa por decisão judicial
        /// 6 – Exigibilidade suspensa por procedimento
        /// administrativo
        /// </remarks>
        private int _naturezaOperacao;


        /// <summary>
        /// (1-1) I-2  Código de natureza da operação
        /// </summary>
        /// <remarks>
        /// Código de natureza da operação
        /// 1 – Tributação no município
        /// 2 - Tributação fora do município
        /// 3 - Isenção
        /// 4 - Imune
        /// 5 –Exigibilidade suspensa por decisão judicial
        /// 6 – Exigibilidade suspensa por procedimento
        /// administrativo
        /// </remarks>
        public int NaturezaOperacao
        {
            get { return _naturezaOperacao; }
            set { _naturezaOperacao = value; }
        }

        private int _regimeEspecialTributacao;
        /// <summary>
        /// (0-1) I-2 - (Código de identificação do regime especial de tributação)
        /// </summary>
        /// <remarks>
        /// Código de identificação do regime especial de
        /// tributação
        /// 1 – Microempresa municipal
        /// 2 - Estimativa
        /// 3 – Sociedade de profissionais
        /// 4 – Cooperativa
        /// 5 - Microempresário Individual (MEI)
        /// 6 - Microempresário e Empresa de Pequeno Porte
        /// (ME EPP)
        /// </remarks>
        public int RegimeEspecialTributacao
        {
            get { return _regimeEspecialTributacao; }
            set { _regimeEspecialTributacao = value; }
        }


        /// <summary>
        /// </summary>
        /// <remarks>
        /// Código de identificação do regime especial de
        /// tributação
        /// 1 – Microempresa municipal
        /// 2 - Estimativa
        /// 3 – Sociedade de profissionais
        /// 4 – Cooperativa
        /// 5 - Microempresário Individual (MEI)
        /// 6 - Microempresário e Empresa de Pequeno Porte
        /// (ME EPP)
        /// </remarks>
        private int _optanteSimplesNacional;
        /// <summary>
        /// (1-1) I-1 (1-SIM / 2-NÃO)
        /// </summary>
        public int OptanteSimplesNacional
        {
            get { return _optanteSimplesNacional; }
            set { _optanteSimplesNacional = value; }
        }

        /// <summary>
        /// </summary>
        private int _incentivadorCultural;
        /// <summary>
        /// (1-1) I-1 (1-SIM / 2-NÃO)
        /// </summary>
        public int IncentivadorCultural
        {
            get { return _incentivadorCultural; }
            set { _incentivadorCultural = value; }
        }

        /// <summary>
        /// </summary>
        private int _status;
        /// <summary>
        /// (1-1) I-1 ( 1-NORMAL / 2-CANCELADO)
        /// </summary>
        public int Status
        {
            get { return _status; }
            set { _status = value; }
        }

        /// <summary>
        /// (0-1)
        /// </summary>
        public tcIdentificacaoRps RpsSubstituido { get; set; }
        /// <summary>
        /// (1-1)
        /// </summary>
        public TcDadosServico Servico { get; set; }
        /// <summary>
        /// (1-1)
        /// </summary>
        public tcIdentificacaoPrestador Prestador { get; set; }
        /// <summary>
        /// (1-1)
        /// </summary>
        public tcDadosTomador Tomador { get; set; }
        /// <summary>
        /// (0-1)
        /// </summary>
        public TcIdentificacaoIntermediarioServico IntermediarioServico { get; set; }
        /// <summary>
        /// (0-1)
        /// </summary>
        public tcDadosConstrucaoCivil ConstrucaoCivil { get; set; }




    }
}
