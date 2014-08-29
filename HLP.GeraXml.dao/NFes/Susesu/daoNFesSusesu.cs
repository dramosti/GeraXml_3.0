using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HLP.GeraXml.dao.ADO;
using HLP.GeraXml.Comum.Static;

namespace HLP.GeraXml.dao.NFes.Susesu
{
    public class daoNFesSusesu
    {
        public virtual DataTable BuscaDadosGerais(string sCD_NFSEQ)
        {
            StringBuilder sQuery = new StringBuilder();
            sQuery.Append("SELECT {0}");
            sQuery.Append("nf.ds_anota, ");
            if (HlpDbFuncoes.fExisteCampo("ST_ISS_NOTA", "NF"))
            {
                sQuery.Append("coalesce(nf.ST_ISS_NOTA,1) STATUS_ISS_NOTA, {0}");
            }
            else
            {
                sQuery.Append("1 STATUS_ISS_NOTA, {0}");
            }
            sQuery.Append("nf.cd_notafis NUMERO_NOTA,{0}");
            sQuery.Append("nf.dt_emi DATA_EMISSAO,{0}");
            sQuery.Append("coalesce(nf.vl_servico,0) VALOR_TOTAL_NOTA,{0}");
            sQuery.Append("coalesce(NF.vl_inss,0) INSS,{0}");
            sQuery.Append("coalesce(NF.vl_totnf,0) VALOR_LIQUIDO,{0}");
            sQuery.Append("coalesce(NF.vl_iss,0) sVALOR_ISS,{0}");
            sQuery.Append("coalesce(NF.vl_cofins_serv,0) COFINS,{0}");
            sQuery.Append("coalesce(NF.vl_pis_serv,0) PIS,{0}");
            sQuery.Append("coalesce(NF.vl_csll_serv,0) CONTRIBUICAO_SOCIAL,{0}");
            sQuery.Append("0 VALOR_DEDUCAO_MATERIAIS,{0}");
            sQuery.Append("case coalesce(clifor.cd_cgc,'') when '' then coalesce(clifor.cd_cpf,'') else coalesce(clifor.cd_cgc,'') end TOMADOR_DOCUMENTO,{0}");
            sQuery.Append("clifor.nm_clifor  TOMADOR_RAZAO,{0}");
            sQuery.Append("clifor.ds_endnor TOMADOR_LOGRADOURO,{0}");
            sQuery.Append("clifor.nm_bairronor TOMADOR_BAIRRO,{0}");
            sQuery.Append("clifor.cd_cepnor TOMADOR_CEP,{0}");
            sQuery.Append("clifor.cd_insest TOMADOR_INSCRICAO_ESTADUAL,{0}");
            sQuery.Append("coalesce(clifor.cd_inscrmu,'') TOMADOR_INSCRICAO_MUNICIPAL,{0}");
            sQuery.Append("coalesce(clifor.cd_email,'') TOMADOR_EMAIL,{0}");
            sQuery.Append("coalesce(clifor.cd_fonenor,'') TOMADOR_TELEFONE,{0}");
            sQuery.Append("cidades.cd_municipio TOMADOR_MUNICIPIO,{0}");
            sQuery.Append("cityEmp.cd_municipio COD_MUNICIPIO_EXECUCAO_SERVICO{0}");
            sQuery.Append("FROM nf {0}");
            sQuery.Append("inner join clifor on (nf.cd_clifor = clifor.cd_clifor) {0}");
            sQuery.Append("inner join empresa on (nf.cd_empresa = empresa.cd_empresa) {0}");
            //sQuery.Append("left join cidades on (cidades.nm_cidnor = clifor.nm_cidnor) {0}");
            sQuery.Append("left join cidades on (cidades.cd_municipio = clifor.cd_municipio) {0}");
            //cidades.cd_municipio = clifor.cd_municipio
            sQuery.Append("left join cidades cityEmp on (cidades.nm_cidnor = empresa.nm_cidnor) {0}");
            sQuery.Append("where nf.cd_nfseq = '{1}' and nf.cd_empresa = '{2}'");

            string sQueryFim = string.Format(sQuery.ToString(), Environment.NewLine, sCD_NFSEQ, Acesso.CD_EMPRESA);

            return HlpDbFuncoes.qrySeekRet(sQueryFim);
        }

        public virtual DataTable BuscaDadosMOVITEM(string sCD_NFSEQ)
        {
            StringBuilder sQuery = new StringBuilder();
            sQuery.Append("SELECT ");
            sQuery.Append("movitem.ds_prod, ");
            sQuery.Append("movitem.vl_totbruto, ");
            sQuery.Append("coalesce(movitem.vl_ir,0) IRRF,");
            sQuery.Append("coalesce(produto.cd_trib_municipio,'') CODIGO_ATIVIDADE, ");
            sQuery.Append("coalesce(produto.cd_lista_servico,'') CODIGO_GERAL_ATIVIDADE, "); //vl_aliqserv
            sQuery.Append("coalesce(movitem.vl_aliqserv,0) ALIQUOTA ");
            sQuery.Append("FROM MOVITEM inner join produto on ");
            sQuery.Append("movitem.cd_prod = produto.cd_prod ");
            sQuery.Append("where movitem.cd_nfseq = '{0}' and movitem.cd_empresa = '{1}'");

            string sQueryFim = string.Format(sQuery.ToString(), sCD_NFSEQ, Acesso.CD_EMPRESA);

            return HlpDbFuncoes.qrySeekRet(sQueryFim);
        }

        public virtual void AlteraStatusNota(string sCD_NFSEQ, string sCD_CHAVE)
        {
            try
            {
                StringBuilder sQuery = new StringBuilder();
                sQuery.Append("UPDATE NF SET NF.cd_recibonfe = 'enviado', NF.cd_chavenfe = '{0}',NF.st_nfe = 'S'");
                sQuery.Append("where NF.cd_nfseq = '{1}' AND NF.cd_empresa = '{2}'");
                string sQueryFim = string.Format(sQuery.ToString(), sCD_CHAVE, sCD_NFSEQ, Acesso.CD_EMPRESA);
                HlpDbFuncoes.qrySeekUpdate(sQueryFim);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public virtual string BuscaNomeCidade(string sTOMADOR_COD_MUNICIPIO)
        {
            string sQUERY = string.Format("SELECT CIDADES.nm_cidnor FROM CIDADES WHERE CIDADES.cd_municipio = '{0}'", sTOMADOR_COD_MUNICIPIO);
            return HlpDbFuncoes.qrySeekValue("CIDADES", "CIDADES.nm_cidnor || ' - ' || CIDADES.cd_ufnor", "CIDADES.cd_municipio ='" + sTOMADOR_COD_MUNICIPIO + "'"); ;
        }



    }
}
