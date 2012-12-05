using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HLP.GeraXml.Comum.Static;

namespace HLP.GeraXml.bel.NFes
{
    /// <summary>
    /// Representa os dados informativos da Nota Fiscal de Serviços Eletrônica
    /// </summary>
    public class TcInfNfse
    {
        private string _id = "";
        /// <summary>
        /// S - 225 (Identificador da TAG a ser assinada)
        /// </summary>
        public string Id
        {
            get { return _id; }
            set { _id = Util.ValidaTamanhoMaximo(225, value); }
        }

        private string _numero;
        /// <summary>
        /// (1-1) I - 15
        /// </summary>
        public string Numero
        {
            get { return _numero; }
            set { _numero = value; }
        }

        private string _codigoVerificacao = "";
        /// <summary>
        /// (1-1) S - 9
        /// </summary>
        public string CodigoVerificacao
        {
            get { return _codigoVerificacao; }
            set { _codigoVerificacao = Util.ValidaTamanhoMaximo(9, value); }
        }

        private DateTime _dataEmissao;
        /// <summary>
        /// (1-1) com Hora
        /// </summary>
        public DateTime DataEmissao
        {
            get { return _dataEmissao; }
            set { _dataEmissao = value; }
        }

        public tcIdentificacaoRps IdentificacaoRps { get; set; }

        private DateTime _dataEmissaoRps;
        /// <summary>
        /// (0-1) Só data
        /// </summary>
        public DateTime DataEmissaoRps
        {
            get { return _dataEmissaoRps; }
            set { _dataEmissaoRps = value; }
        }

        private int _naturezaOperacao;
        /// <summary>
        /// (1-1) I-2 (Código de natureza da operação)
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

        private int _optanteSimplesNacional;
        /// <summary>
        /// (1-1) I-1 (1-SIM / 2-NÃO)
        /// </summary>
        public int OptanteSimplesNacional
        {
            get { return _optanteSimplesNacional; }
            set { _optanteSimplesNacional = value; }
        }

        private int _incetivadorCultural;
        /// <summary>
        /// (1-1) I-1 (1-SIM / 2-NÃO)
        /// </summary>
        public int IncetivadorCultural
        {
            get { return _incetivadorCultural; }
            set { _incetivadorCultural = value; }
        }

        private DateTime _competencia;
        /// <summary>
        /// (1-1) Só Date
        /// </summary>
        public DateTime Competencia
        {
            get { return _competencia; }
            set { _competencia = value; }
        }

        private string _nfseSubstituida;
        /// <summary>
        /// (0-1) I-15
        /// </summary>
        public string NfseSubstituida
        {
            get { return _nfseSubstituida; }
            set { _nfseSubstituida = value; }
        }

        private string _outrasInformacoes = "";
        /// <summary>
        /// (0-1) S-255
        /// </summary>
        public string OutrasInformacoes
        {
            get { return _outrasInformacoes; }
            set { _outrasInformacoes = Util.ValidaTamanhoMaximo(225, value); }
        }

        private decimal _valorCredito;
        /// <summary>
        /// (0-1) D - 15,2
        /// </summary>
        public decimal ValorCredito
        {
            get { return _valorCredito; }
            set { _valorCredito = value; }
        }

        /// <summary>
        /// 1-1
        /// </summary>
        public tcDadosPrestador PrestadorServico { get; set; }
        /// <summary>
        /// 1-1
        /// </summary>
        public tcDadosTomador TomadorServico { get; set; }
        /// <summary>
        /// 0-1
        /// </summary>
        public TcIdentificacaoIntermediarioServico IntermediarioServico { get; set; }
        /// <summary>
        /// 1-1
        /// </summary>
        public tcIdentificacaoOrgaoGerador OrgaoGerador { get; set; }
        /// <summary>
        /// 0-1
        /// </summary>
        public tcDadosConstrucaoCivil ConstrucaoCivil { get; set; }


    }
}
