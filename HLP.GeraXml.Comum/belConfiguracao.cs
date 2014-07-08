using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HLP.GeraXml.Comum
{
    [Serializable()]
    public class belConfiguracao
    {
        public string CAMINHO_PADRAO { get; set; }
        public string USA_DANFE_SIMPLIFICADA { get; set; }
        public string CAMINHO_RELATORIO_ESPECIFICO { get; set; }
        public string CAMINHO_ESPECIFICO_ENVIADOS { get; set; }
        public string CAMINHO_BANCO_DADOS { get; set; }
        public string NM_SERVIDOR { get; set; }
        public string PORTA { get; set; }
        public string USUARIO { get; set; }
        public string SENHA { get; set; }
        public string CD_EMPRESA { get; set; }
        public string GRAVA_NUM_NF_DUPL { get; set; }
        public string GRUPO_SERVICO { get; set; }
        public string GRUPO_SCAN { get; set; }
        public bool DS_DETALHE { get; set; }
        public string FUSO { get; set; }
        public int TRANSPARENCIA { get; set; }
        public string TIPO_IMPRESSAO { get; set; }
        public string HOST_SERVIDOR { get; set; }
        public string PORTA_SERVIDOR { get; set; }
        public string EMAIL_REMETENTE { get; set; }
        public string SENHA_REMETENTE { get; set; }
        public string REQUER_SSL { get; set; }
        public string EMAIL_AUTOMATICO { get; set; }
        public string DESTACA_IMP_TRIB_MUN { get; set; }
        public string LOGOTIPO { get; set; }
        public string QTDE_CASAS_PRODUTOS { get; set; }
        public string QTDE_CASAS_VL_UNIT { get; set; }
        public string VISUALIZA_HORA_DANFE { get; set; }
        public string VISUALIZA_DATA_DANFE { get; set; }
        private bool _VISUALIZA_DADOS_NFE = true;
        public bool VISUALIZA_DADOS_NFE
        {
            get { return _VISUALIZA_DADOS_NFE; }
            set { _VISUALIZA_DADOS_NFE = value; }
        }
        public string COD_BARRAS_XML { get; set; }
        public string TOTALIZA_CFOP { get; set; }
        public int TP_EMIS { get; set; }
        public bool IMPRIMI_NUM_NOTA_ENTRADA { get; set; }
        public bool IMPRIMI_NUM_PEDIDO_VENDA { get; set; }
        public bool IMPRIMI_NUM_REVISAO { get; set; }
        private bool _IMPRIMI_RETORNO = true;
        public bool IMPRIMI_RETORNO
        {
            get { return _IMPRIMI_RETORNO; }
            set { _IMPRIMI_RETORNO = value; }
        }
        private bool _IMPRIMI_FATURA = true;

        public bool IMPRIMI_FATURA
        {
            get { return _IMPRIMI_FATURA; }
            set { _IMPRIMI_FATURA = value; }
        }

        public string COD_PREFEITURA { get; set; }
        public string SENHA_WEB_NFES { get; set; }
    }
}
