using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HLP.GeraXml.dao.NFes.Susesu;
using System.Data;
using HLP.GeraXml.Comum.Static;
using HLP.GeraXml.bel.NFe;
using HLP.GeraXml.dao;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace HLP.GeraXml.bel.NFes.Susesu
{
    [Serializable]
    [XmlRoot("NOTA")]
    public class belNFesSusesu : daoNFesSusesu
    {
        public belNFesSusesu(belPesquisaNotas objBelPesquisaNota)
        {
            this.CD_NFSEQ = objBelPesquisaNota.sCD_NFSEQ;
            BuscaDadosGerais(objBelPesquisaNota.sCD_NFSEQ);
        }

        public belNFesSusesu()
        {
        }


        [XmlIgnore]
        public string sCHAVE { get; set; }
        [XmlIgnore]
        public string sVALOR_ISS { get; set; }

        [XmlIgnore]
        /// <summary>
        /// PK NF
        /// </summary>
        public string CD_NFSEQ { get; set; }
        /// <summary>
        /// nf.cd_notafis
        /// Número da nota fiscal, deve ser sequencial e não repetir.
        /// </summary>
        public int NUMERO_NOTA { get; set; }
        private string _DATA_EMISSAO;
        /// <summary>
        /// nf.dt_emi
        /// Data de emissão da nota fiscal, não pode ser maior que a data de hoje ou menor que a data da última nota.
        /// </summary>
        public string DATA_EMISSAO
        {
            get { return _DATA_EMISSAO; }
            set { _DATA_EMISSAO = Convert.ToDateTime(value).ToShortDateString(); }
        }
        /// <summary>
        /// Produto.cd_lista_servico_Prod
        /// Código da geral atividade, no caso do município de Piracaia e Santa Gertrudes deve ser em branco, nos outros casos deve contém o código geral da atividade.
        /// </summary>
        public string CODIGO_GERAL_ATIVIDADE { get; set; }
        /// <summary>
        /// Produto.CD_TRIB_MINICIPIO
        /// No caso do munícipio de Piracaia, Santa Gertrudes e Ipeúna deve contém o código da 
        /// atividade da nota em questão que está no site da Nota Fiscal Digital em "Minhas Atividades". 
        /// A atividade principal está no cadastro do Contribuinte e, caso não esteja em "Minhas Atividades", 
        /// deve ser solicitado a Prefeitura o cadastramento desta atividade na lista de atividade do Contribuinte. 
        /// Nos demais municípios deve ser em branco.
        /// </summary>
        public string CODIGO_ATIVIDADE { get; set; }
        /// <summary>
        /// NF.DS_ANOTA
        /// Outras informações relativas a nota
        /// </summary>
        public string OUTRAS_INFORMACOES { get; set; }
        private string _DESCRICAO_SERVICOS;
        /// <summary>
        /// ds_prod _ +" - "+ vl_totbruto
        /// Descrição dos serviços prestados
        /// </summary>
        public string DESCRICAO_SERVICOS
        {
            get { return _DESCRICAO_SERVICOS; }
            set
            {
                _DESCRICAO_SERVICOS = value;
            }
        }
        private string _VALOR_TOTAL_NOTA = "0";
        /// <summary>
        /// nf.vl_servico
        /// Valor total da nota,
        /// </summary>
        public string VALOR_TOTAL_NOTA
        {
            get { return _VALOR_TOTAL_NOTA; }
            set { _VALOR_TOTAL_NOTA = Convert.ToDecimal(value).ToString("#0.00"); }
        }
        private int _STATUS_ISS_NOTA = 1;
        /// <summary>       
        /// NF.ST_ISS_NOTA
        ///Status da nota:
        ///1 = Normal
        ///3 = Retida
        ///4 = Simples Nacional
        ///6 = M.E.I Micro Empresa Individual
        ///7 = Iss Devido Fora Do Município
        /// </summary>
        public int STATUS_ISS_NOTA
        {
            get { return _STATUS_ISS_NOTA; }
            set { _STATUS_ISS_NOTA = value; }
        }
        private string _IRRF = "0";
        /// <summary>
        /// movitem.vl_ir
        /// IRRF
        /// </summary>
        public string IRRF
        {
            get { return _IRRF; }
            set
            {
                _IRRF = Convert.ToDecimal(value).ToString("#0.00");
            }
        }
        private string _INSS = "0";
        /// <summary>
        /// NF.vl_inss
        /// INSS
        /// </summary>
        public string INSS
        {
            get { return _INSS; }
            set { _INSS = Convert.ToDecimal(value).ToString("#0.00"); }
        }
        private string _PIS = "0";
        /// <summary>
        /// NF.VL_PIS
        /// PIS
        /// </summary>
        public string PIS
        {
            get { return _PIS; }
            set { _PIS = Convert.ToDecimal(value).ToString("#0.00"); }
        }
        private string _COFINS = "0";
        /// <summary>
        /// NF.VL_COFINS
        /// COFINS
        /// </summary>
        public string COFINS
        {
            get { return _COFINS; }
            set { _COFINS = Convert.ToDecimal(value).ToString("#0.00"); ; }
        }
        private string _CONTRIBUICAO_SOCIAL = "0";
        /// <summary>
        /// nf.vl_csll_serv
        /// Contribuição social
        /// </summary>
        public string CONTRIBUICAO_SOCIAL
        {
            get { return _CONTRIBUICAO_SOCIAL; }
            set { _CONTRIBUICAO_SOCIAL = Convert.ToDecimal(value).ToString("#0.00"); }
        }
        private string _VALOR_LIQUIDO;
        /// <summary>
        /// vl_servico - (IRRF + INSS + PIS + COFINS)
        /// Valor líquido
        /// </summary>
        public string VALOR_LIQUIDO
        {
            get
            {
                return _VALOR_LIQUIDO; //(Convert.ToDecimal(_VALOR_TOTAL_NOTA) - (Convert.ToDecimal(_IRRF) + Convert.ToDecimal(_INSS) + Convert.ToDecimal(_PIS) + Convert.ToDecimal(_COFINS))).ToString("#0.00");
            }
            set { _VALOR_LIQUIDO = Convert.ToDecimal(value).ToString("#0.00"); }
        }
        private string _VALOR_DEDUCAO_MATERIAIS = "0";
        /// <summary>
        /// Valor dedução material
        /// A VERIFICAR
        /// </summary>
        public string VALOR_DEDUCAO_MATERIAIS
        {
            get { return _VALOR_DEDUCAO_MATERIAIS; }
            set { _VALOR_DEDUCAO_MATERIAIS = Convert.ToDecimal(value).ToString("#0.00"); }
        }
        /// <summary>
        /// cidade.cd_municipio
        /// </summary>
        public int COD_MUNICIPIO_EXECUCAO_SERVICO { get; set; }
        /// <summary>
        /// Cidade de execução do serviço
        /// </summary>
        public string LOCAL_EXECUCAO_SERVICO { get; set; }
        private string _TOMADOR_ESTRANGEIRO = "N";
        /// <summary>
        /// Tomador estrangeiro, caso o tomador do serviço seja estrangeiro o documento do mesmo não será validado, conteudo S = Sim ou N = Não
        /// </summary>
        public string TOMADOR_ESTRANGEIRO
        {
            get { return _TOMADOR_ESTRANGEIRO; }
            set { _TOMADOR_ESTRANGEIRO = value; }
        }
        /// <summary>
        /// case coalesce(clifor.cd_cgc,'') when '' then coalesce(clifor.cd_cpf,'') else coalesce(clifor.cd_cgc,'')
        /// Tomador documento, CNPJ/CPF/DOC do tomador.
        /// </summary>
        public string TOMADOR_DOCUMENTO { get; set; }
        /// <summary>
        /// clifor.nm_clifor
        /// </summary>
        public string TOMADOR_RAZAO { get; set; }
        /// <summary>
        /// clifor.ds_endnor
        /// </summary>
        public string TOMADOR_LOGRADOURO { get; set; }
        /// <summary>
        /// clifor.nm_bairronor
        /// </summary>
        public string TOMADOR_BAIRRO { get; set; }

        private string _TOMADOR_CEP;
        /// <summary>
        /// clifor.cd_cepnor
        /// </summary>
        public string TOMADOR_CEP
        {
            get { return _TOMADOR_CEP; }
            set { _TOMADOR_CEP = Util.TiraSimbolo(value); }
        }
        private string _TOMADOR_INSCRICAO_ESTADUAL;
        /// <summary>
        /// clifor.cd_insest
        /// </summary>
        public string TOMADOR_INSCRICAO_ESTADUAL
        {
            get { return _TOMADOR_INSCRICAO_ESTADUAL; }
            set { _TOMADOR_INSCRICAO_ESTADUAL = (value == "" ? "ISENTO" : value); }
        }
        private string _TOMADOR_INSCRICAO_MUNICIPAL;
        /// <summary>
        /// coalesce(clifor.cd_inscrmu,'')
        /// </summary>
        public string TOMADOR_INSCRICAO_MUNICIPAL
        {
            get { return _TOMADOR_INSCRICAO_MUNICIPAL; }
            set { _TOMADOR_INSCRICAO_MUNICIPAL = (value == "" ? "ISENTO" : value); }
        }
        /// <summary>
        /// coalesce(clifor.cd_email,'')
        /// </summary>
        public string TOMADOR_EMAIL { get; set; }
        private string _TOMADOR_TELEFONE;
        /// <summary>
        /// coalesce(clifor.cd_fonenor,'')
        /// </summary>
        public string TOMADOR_TELEFONE
        {
            get { return _TOMADOR_TELEFONE; }
            set { _TOMADOR_TELEFONE = Util.TiraSimbolo(value); }
        }
        /// <summary>
        /// cidades.cd_municipio
        /// </summary>
        public int TOMADOR_MUNICIPIO { get; set; }
        private string _ALIQUOTA;
        /// <summary>
        /// movitem.vl_aliqserv
        /// </summary>
        public string ALIQUOTA
        {
            get { return _ALIQUOTA; }
            set { _ALIQUOTA = Convert.ToDecimal(value).ToString("#0.00"); }
        }
        private int _PORCENTAGEM_REGIME_ESPECIAL;
        /// <summary>
        /// A VERIFICAR
        /// </summary>
        public int PORCENTAGEM_REGIME_ESPECIAL
        {
            get { return _PORCENTAGEM_REGIME_ESPECIAL; }
            set { _PORCENTAGEM_REGIME_ESPECIAL = value; }
        }

        #region Métodos Publicos
        /// <summary>
        /// Transmite a nota e salva o arquivo xml na pasta enviado
        /// </summary>
        public void TransmiteRPS()
        {
            try
            {

                if (File.Exists(this.GetsFilePath(false)))
                {
                    File.Delete(this.GetsFilePath(false));
                }
                belSerializeToXml.SerializeClasse<belNFesSusesu>(this, this.GetsFilePath(false));

                XmlDocument xml = new XmlDocument();
                xml.Load(this.GetsFilePath(false));

                string sRetorno = "";
                if (Acesso.SENHA_WEB_NFES == "" || Acesso.COD_PREFEITURA == "")
                {
                    throw new Exception("Verifique os parametros abaixo na configuração do GeraXml." + Environment.NewLine + "'Codigo da Prefeitura' e 'Senha acesso sistema NFe-Serviço'");
                }

                string sCNPJ = Util.TiraSimbolo(Acesso.CNPJ_EMPRESA);
                string sSenha = Acesso.SENHA_WEB_NFES;
                int iCodPrefeitura = Convert.ToInt32(Acesso.COD_PREFEITURA);
                string sXmlEnvio = xml.InnerXml;

                if (Acesso.TP_AMB_SERV == 1)
                {
                    HLP.GeraXml.WebService.Susessu_Producao_Servico.ServicoNfd rps = new WebService.Susessu_Producao_Servico.ServicoNfd();
                    sRetorno = rps.EnviarNota(iCodPrefeitura, sXmlEnvio, sCNPJ, sSenha);
                }
                else
                {
                    HLP.GeraXml.WebService.Susesu_Homologacao_Servico.ServicoNfd rps = new WebService.Susesu_Homologacao_Servico.ServicoNfd();
                    sRetorno = rps.EnviarNota(iCodPrefeitura, sXmlEnvio, sCNPJ, sSenha);
                }

                if (sRetorno[0] == '1')
                {
                    base.AlteraStatusNota(this.CD_NFSEQ, sRetorno);

                    FileInfo f = new FileInfo(this.GetsFilePath(true));

                    File.Copy(this.GetsFilePath(false), this.GetsFilePath(true));

                    KryptonMessageBox.Show(null, string.Format("Nota de serviço enviada com sucesso!{0}Chave de Retorno: {1}", Environment.NewLine, sRetorno), Mensagens.CHeader, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    throw new Exception("Nota recusada pelo servidor da prefeitura, verifique a informação abaixo:" + Environment.NewLine + sRetorno);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Métodos privados
        /// <summary>
        /// Busca Local Para Salvar XML - "False" = Envio || "True" = Enviados
        /// </summary>
        /// <param name="bEnvio">"False" = Envio || "True" = Enviados</param>
        /// <returns>Caminho</returns>
        public string GetsFilePath(bool bStatus)
        {

            string sDirectory = (bStatus ? Pastas.ENVIADOS : Pastas.ENVIO) + "\\Servicos\\" + Convert.ToDateTime(_DATA_EMISSAO).Date.Month.ToString().PadLeft(2, '0') + Convert.ToDateTime(_DATA_EMISSAO).Date.Year.ToString().Substring(2, 2) + "\\";
            if (!Directory.Exists(sDirectory))
            {
                Directory.CreateDirectory(sDirectory);
            }
            return sDirectory + this.NUMERO_NOTA + ".xml";
        }
        /// <summary>
        /// Carrega Dados da NOTA
        /// </summary>
        /// <param name="sCD_NFSEQ"></param>
        private void BuscaDadosGerais(string sCD_NFSEQ)
        {
            try
            {
                DataTable dt = base.BuscaDadosGerais(sCD_NFSEQ);

                foreach (DataRow dr in dt.Rows)
                {
                    this.NUMERO_NOTA = Convert.ToInt32(dr["NUMERO_NOTA"]);
                    this.DATA_EMISSAO = dr["DATA_EMISSAO"].ToString();
                    this.VALOR_TOTAL_NOTA = dr["VALOR_TOTAL_NOTA"].ToString();
                    this.INSS = dr["INSS"].ToString();
                    this.COFINS = dr["COFINS"].ToString();
                    this.PIS = dr["PIS"].ToString();
                    this.CONTRIBUICAO_SOCIAL = dr["CONTRIBUICAO_SOCIAL"].ToString();
                    this.VALOR_DEDUCAO_MATERIAIS = dr["VALOR_DEDUCAO_MATERIAIS"].ToString();
                    this.TOMADOR_DOCUMENTO = Util.TiraSimbolo(dr["TOMADOR_DOCUMENTO"].ToString());
                    this.TOMADOR_RAZAO = dr["TOMADOR_RAZAO"].ToString();
                    this.TOMADOR_LOGRADOURO = dr["TOMADOR_LOGRADOURO"].ToString();
                    this.TOMADOR_BAIRRO = dr["TOMADOR_BAIRRO"].ToString();
                    this.TOMADOR_CEP = dr["TOMADOR_CEP"].ToString();
                    this.TOMADOR_INSCRICAO_ESTADUAL = dr["TOMADOR_INSCRICAO_ESTADUAL"].ToString();
                    this.TOMADOR_INSCRICAO_MUNICIPAL = dr["TOMADOR_INSCRICAO_MUNICIPAL"].ToString();
                    this.TOMADOR_EMAIL = dr["TOMADOR_EMAIL"].ToString();
                    this.TOMADOR_TELEFONE = dr["TOMADOR_TELEFONE"].ToString();
                    this.TOMADOR_MUNICIPIO = Convert.ToInt32(dr["TOMADOR_MUNICIPIO"].ToString());
                    this.LOCAL_EXECUCAO_SERVICO = Acesso.CIDADE_EMPRESA;
                    this.COD_MUNICIPIO_EXECUCAO_SERVICO = Convert.ToInt32(dr["COD_MUNICIPIO_EXECUCAO_SERVICO"].ToString());
                    this.STATUS_ISS_NOTA = Convert.ToInt32(dr["STATUS_ISS_NOTA"].ToString());
                    this.VALOR_LIQUIDO = dr["VALOR_LIQUIDO"].ToString();
                    this.sVALOR_ISS = dr["sVALOR_ISS"].ToString();


                    BuscaDadosMOVITEM(sCD_NFSEQ);
                    string sObs = daoUtil.RetornaBlob(string.Format("SELECT ds_anota FROM NF WHERE NF.CD_NFSEQ = '{0}' AND NF.CD_EMPRESA = '{1}'", sCD_NFSEQ, Acesso.CD_EMPRESA));
                    if (sObs.IndexOf("\\fs") != -1)
                    {
                        sObs = sObs.Substring((sObs.IndexOf("\\fs") + 6), sObs.Length - (sObs.IndexOf("\\fs") + 6));
                    }
                    this.OUTRAS_INFORMACOES = sObs.Replace("}", "").Trim();
                    break;
                }

            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Carrega dados do serviço - MOVITEM
        /// </summary>
        /// <param name="sCD_NFSEQ"></param>
        private void BuscaDadosMOVITEM(string sCD_NFSEQ)
        {
            DataTable dt = base.BuscaDadosMOVITEM(sCD_NFSEQ);

            this.DESCRICAO_SERVICOS = "Serviço(s) Realizado(s): " + Environment.NewLine;
            foreach (DataRow dr in dt.Rows)
            {
                this.CODIGO_ATIVIDADE = dr["CODIGO_ATIVIDADE"].ToString();
                this.CODIGO_GERAL_ATIVIDADE = dr["CODIGO_GERAL_ATIVIDADE"].ToString();
                this.ALIQUOTA = dr["ALIQUOTA"].ToString();
                this.DESCRICAO_SERVICOS += "* " + dr["ds_prod"].ToString().ToUpper() + " R$ " + Convert.ToDecimal(dr["vl_totbruto"].ToString()).ToString("#0.00") + Environment.NewLine;
                this.IRRF += Convert.ToDecimal(dr["IRRF"].ToString());
            }
        }
        #endregion

    }
}
