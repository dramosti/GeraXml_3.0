using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HLP.GeraXml.dao.ADO;
using HLP.GeraXml.Comum.Static;
using System.Xml.Serialization;

namespace HLP.GeraXml.dao.NFes.DSF
{
    public class daoRPS
    {
        [XmlIgnore]
        public DataTable dtRPS { get; set; }
        [XmlIgnore]
        public DataTable dtItem { get; set; }
        public virtual void GetRps(string cd_nfseq)
        {
            try
            {
                StringBuilder sQuery = new StringBuilder();
                sQuery.Append("Select emp.cd_inscrmu InscricaoMunicipalPrestador , {0}");
                sQuery.Append("emp.nm_empresa  RazaoSocialPrestador, {0}");
                sQuery.Append("coalesce(emp.cd_cnae,'') CodigoAtividade, {0}");
                sQuery.Append("emp.cd_fonenor TelefonePrestador, {0}");
                
                sQuery.Append("nf.vl_pis_serv ValorPIS, {0}");
                sQuery.Append("nf.vl_cofins_serv  ValorCOFINS, {0}");
                sQuery.Append("nf.vl_csll_serv ValorCSLL, {0}");
                sQuery.Append("nf.vl_inss ValorINSS, {0}");


                sQuery.Append("clifor.vl_aliqcsll AliquotaCSLL, {0}");
                sQuery.Append("nf.dt_emi  DataEmissaoRPS, {0}");
                sQuery.Append("clifor.vl_aliqpis_servico AliquotaPIS, {0}");
                sQuery.Append("clifor.vl_aliqcofins_servico AliquotaCOFINS, {0}");
                sQuery.Append("clifor.vl_aliqirrf AliquotaIR, {0}");
                sQuery.Append("clifor.vl_aliqinss AliquotaINSS, {0}");


                sQuery.Append("nf.ds_anota DescricaoRPS, {0}");
                sQuery.Append("coalesce(clifor.cd_inscrmu,'') InscricaoMunicipalTomador, {0}");
                sQuery.Append("coalesce(clifor.cd_cgc,'0') CNPJ_Tomador, {0}");
                sQuery.Append("coalesce(clifor.cd_cpf,'0') CPF_Tomador, {0}");
                sQuery.Append("clifor.nm_clifor  RazaoSocialTomador, {0}");
                sQuery.Append("coalesce(clifor.tp_logradouro,'Rua') TipoLogradouroTomador,{0}");
                sQuery.Append("coalesce(clifor.ds_endnor,'') LogradouroTomador, {0}");
                sQuery.Append("coalesce(clifor.nr_endnor,'')  NumeroEnderecoTomador, {0}");
                sQuery.Append("coalesce(clifor.nm_complemento,'')  ComplementoEnderecoTomador, {0}");
                sQuery.Append("'Bairro'  TipoBairroTomador, {0}");
                sQuery.Append("coalesce(clifor.nm_bairronor,'')  BairroTomador, {0}");
                sQuery.Append("cidades.cd_municipio CidadeTomador, {0}");
                sQuery.Append("cidades.nm_cidnor CidadeTomadorDescricao, {0}");
                sQuery.Append("coalesce(clifor.cd_cepnor,'') CEPTomador, {0}");
                sQuery.Append("coalesce(clifor.cd_email,'') EmailTomador, {0}");
                sQuery.Append("coalesce(clifor.cd_fonenor,'') TelefoneTomador, {0}");
                sQuery.Append("'N' SituacaoRPS, {0}");//Item a ser tratado
                sQuery.Append("'' SerieRPSSubstituido, {0}");//Item a ser tratado
                sQuery.Append("0 NumeroRPSSubstituido, {0}");//Item a ser tratado
                sQuery.Append("0 NumeroNFSeSubstituida, {0}");//Item a ser tratado
                sQuery.Append("'01/01/1900' DataEmissaoNFSeSubstituida, {0}");//Item a ser tratado
                sQuery.Append("99 SeriePrestacao, {0}");//Item a ser tratado
                sQuery.Append("'' DocTomadorEstrangeiro, {0}");//Item a ser tratado
                sQuery.Append("'A'TipoRecolhimento, {0}");//Item a ser tratado
                sQuery.Append("'A' Operacao, {0}");//Item a ser tratado
                sQuery.Append("'H' Tributacao ");//Item a ser tratado
                sQuery.Append("from nf inner join empresa emp {0}");
                sQuery.Append("on (nf.cd_empresa = emp.cd_empresa) inner join clifor {0}");
                sQuery.Append("on (clifor.cd_clifor = nf.cd_clifor) left join cidades {0}");
                sQuery.Append("on (cidades.nm_cidnor = clifor.nm_cidnor) {0}");
                sQuery.Append("where nf.cd_nfseq = '{1}' and nf.cd_empresa = '{2}'");

                string sQueryFim = string.Format(sQuery.ToString(), Environment.NewLine, cd_nfseq, Acesso.CD_EMPRESA);
                dtRPS = HlpDbFuncoes.qrySeekRet(sQueryFim);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public virtual void GetItens(string cd_nfseq)
        {
            try
            {
                StringBuilder sQuery = new StringBuilder();
                sQuery.Append("select ");
                sQuery.Append("'S' Tributavel, ");
                sQuery.Append("m.ds_prod DiscriminacaoServico, ");
                sQuery.Append("m.cd_oper, ");
                sQuery.Append("m.cd_clifor, ");
                sQuery.Append("m.qt_prod Quantidade, ");
                sQuery.Append("m.vl_uniprod ValorUnitario, ");
                sQuery.Append("m.vl_totbruto ValorTotal ");
                sQuery.Append("from movitem m ");
                sQuery.Append("where m.cd_nfseq = '{0}' and m.cd_empresa ='{1}'");
                dtItem = HlpDbFuncoes.qrySeekRet(string.Format(sQuery.ToString(), cd_nfseq, Acesso.CD_EMPRESA));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public decimal GetAliquotaAtividade(string cd_clifor, string cd_oper)
        {
            try
            {
                decimal dAliquotaAtividade = Convert.ToDecimal(HlpDbFuncoes.qrySeekValue("issclifor", "coalesce(vl_aliqiss,0)", string.Format("cd_clifor= '{0}' and cd_oper = '{1}'", cd_clifor, cd_oper)));
                return dAliquotaAtividade;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public double GetValorIR(string cd_nfseq)
        {
            try
            {
                double dIR = Convert.ToDouble(HlpDbFuncoes.qrySeekValue("MOVITEM", "sum(coalesce(vl_ir,0))", string.Format("cd_nfseq = '{0}' and cd_empresa = '{1}'", cd_nfseq, Acesso.CD_EMPRESA)));
                return dIR;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public double GetAliqIR(string cd_nfseq)
        {
            try
            {
                double dAliqIR = Convert.ToDouble(HlpDbFuncoes.qrySeekValue("MOVITEM", "first 1 coalesce(m.vl_aliir,0)", string.Format("cd_nfseq = '{0}' and cd_empresa = '{1}'", cd_nfseq, Acesso.CD_EMPRESA)));
                return dAliqIR;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public double GetAliqINSS(string cd_nfseq)
        {
            try
            {
                double dAliqIR = Convert.ToDouble(HlpDbFuncoes.qrySeekValue("movitem inner join opereve on movitem.cd_oper = opereve.cd_oper ",
                    "first 1 coalesce(opereve.vl_aliinss,0)",
                    string.Format("movitem.cd_nfseq = '{0}' and movitem.cd_empresa = '{1}'", cd_nfseq, Acesso.CD_EMPRESA)));

                return dAliqIR;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string GetDescricaoRPS(string cd_nfseq)
        {
            string squery = "select ds_anota DescricaoRPS from nf where cd_nfseq = '{0}' and cd_empresa ='{1}'";
            return daoUtil.RetornaBlob(string.Format(squery, cd_nfseq, Acesso.CD_EMPRESA));
        }

        public string GetCodCidadeEmpresa()
        {
            return HlpDbFuncoes.qrySeekValue("empresa e inner join cidades c on e.nm_cidnor = c.nm_cidnor", "cd_municipio", "e.CD_EMPRESA='" + Acesso.CD_EMPRESA + "'");
        }

        public string GetInscricaoMunicipal()
        {
            return HlpDbFuncoes.qrySeekValue("EMPRESA", "cd_inscrmu", "CD_EMPRESA='" + Acesso.CD_EMPRESA + "'");
        }


        public string GetNumeroRPSsalvo(string cd_nfseq)
        {
            try
            {
                int iRPS = Convert.ToInt32(HlpDbFuncoes.qrySeekValue("nf", "coalesce(cd_rps,0)", string.Format("cd_nfseq = '{0}' and cd_empresa = '{1}'", cd_nfseq, Acesso.CD_EMPRESA)));

                if (iRPS == 0)
                {
                    return Convert.ToInt32(cd_nfseq).ToString();
                }
                else
                {
                    return iRPS.ToString();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void SaveNumRPS(string cd_nfseq, string sCD_RPS)
        {
            try
            {
                string sQuery = string.Format("update nf set cd_rps = '{0}' where cd_nfseq = '{1}' and cd_empresa = '{2}'", sCD_RPS, cd_nfseq, Acesso.CD_EMPRESA);
                HlpDbFuncoes.qrySeekUpdate(sQuery.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }




    }
}
