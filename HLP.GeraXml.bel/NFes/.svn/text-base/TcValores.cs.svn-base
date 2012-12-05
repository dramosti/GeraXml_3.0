using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HLP.GeraXml.bel.NFes
{
    /// <summary>
    /// Representa um conjunto de valores que compõe o documento fiscal
    /// </summary>
    public class TcValores
    {
        /// <summary>
        /// </summary>
        private decimal _valorServicos;

        /// <summary>
        /// (1-1) N-15,2
        /// </summary>
        public decimal ValorServicos
        {
            get { return _valorServicos; }
            set { _valorServicos = value; }
        }
        /// <summary>
        /// </summary>
        private decimal _valorDeducoes;

        /// <summary>
        /// (0-1) N-15,2
        /// </summary>
        public decimal ValorDeducoes
        {
            get { return _valorDeducoes; }
            set { _valorDeducoes = value; }
        }
        /// <summary>
        /// </summary>
        private decimal _valorPis;

        /// <summary>
        /// (0-1) N-15,2
        /// </summary>
        public decimal ValorPis
        {
            get { return _valorPis; }
            set { _valorPis = value; }
        }
        /// <summary>
        /// </summary>
        private decimal _valorCofins;

        /// <summary>
        /// (0-1) N-15,2
        /// </summary>
        public decimal ValorCofins
        {
            get { return _valorCofins; }
            set { _valorCofins = value; }
        }
        /// <summary>
        /// </summary>
        private decimal _valorInss;

        /// <summary>
        /// (0-1) N-15,2
        /// </summary>
        public decimal ValorInss
        {
            get { return _valorInss; }
            set { _valorInss = value; }
        }
        /// <summary>
        /// </summary>
        private decimal _valorIr;

        /// <summary>
        /// (0-1) N-15,2
        /// </summary>
        public decimal ValorIr
        {
            get { return _valorIr; }
            set { _valorIr = value; }
        }
        /// <summary>
        /// </summary>
        private decimal _valorCsll;

        /// <summary>
        /// (0-1) N-15,2
        /// </summary>
        public decimal ValorCsll
        {
            get { return _valorCsll; }
            set { _valorCsll = value; }
        }
        /// <summary>
        /// </summary>
        private int _issRetido;

        /// <summary>
        /// (1-1) N-1 (1-SIM/2-NÃO)
        /// </summary>
        public int IssRetido
        {
            get { return _issRetido; }
            set { _issRetido = value; }
        }
        /// <summary>
        /// </summary>
        private decimal _valorIss;

        /// <summary>
        /// (0-1) N-15,2
        /// </summary>
        public decimal ValorIss
        {
            get { return _valorIss; }
            set { _valorIss = value; }
        }
        /// <summary>
        /// </summary>
        private decimal _outrasRetencoes;

        /// <summary>
        /// (0-1) N-15,2
        /// </summary>
        public decimal OutrasRetencoes
        {
            get { return _outrasRetencoes; }
            set { _outrasRetencoes = value; }
        }
        /// <summary>
        /// </summary>
        private decimal _baseCalculo;

        /// <summary>
        /// (0-1) N-15,2
        /// </summary>
        public decimal BaseCalculo
        {
            get { return _baseCalculo; }
            set { _baseCalculo = value; }
        }
        /// <summary>
        /// </summary>
        private decimal _aliquota;

        /// <summary>
        /// (0-1) N-5,4
        /// </summary>
        public decimal Aliquota
        {
            get { return _aliquota; }
            set { _aliquota = value; }
        }
        /// <summary>
        /// </summary>
        private decimal _valorLiquidoNfse;

        /// <summary>
        /// (0-1) N-15,2
        /// </summary>
        public decimal ValorLiquidoNfse
        {
            get { return _valorLiquidoNfse; }
            set { _valorLiquidoNfse = value; }
        }
        /// <summary>
        /// </summary>
        private decimal _valorIssRetido;

        /// <summary>
        /// (0-1) N-15,2
        /// </summary>
        public decimal ValorIssRetido
        {
            get { return _valorIssRetido; }
            set { _valorIssRetido = value; }
        }
        /// <summary>
        /// </summary>
        private decimal _descontoCondicionado;

        /// <summary>
        /// (0-1) N-15,2
        /// </summary>
        public decimal DescontoCondicionado
        {
            get { return _descontoCondicionado; }
            set { _descontoCondicionado = value; }
        }
        /// <summary>
        /// </summary>
        private decimal _descontoIncondicionado;

        /// <summary>
        /// (0-1) N-15,2
        /// </summary>
        public decimal DescontoIncondicionado
        {
            get { return _descontoIncondicionado; }
            set { _descontoIncondicionado = value; }
        }

        /// <summary>
        /// (Valor dos serviços-Valor PIS-Valor COFINS-Valor INSS-Valor IR-Valor CSLL-OutrasRetençoes-Valor ISS Retido-Desconto Incondicionado-Desconto Condicionado) e deve ser maior que R$ 0,00 
        /// </summary>
        /// <returns></returns>
        public decimal CalculaValorLiquido()
        {
            decimal dValorLiq = ValorServicos - ValorPis - ValorCofins - ValorInss - ValorIr - ValorCsll - OutrasRetencoes - ValorIssRetido - DescontoCondicionado - DescontoIncondicionado;

            return dValorLiq;
        }
    }
}
