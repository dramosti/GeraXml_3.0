using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HLP.GeraXml.Comum.Static;
using HLP.GeraXml.dao.ADO;
using FirebirdSql.Data.FirebirdClient;

namespace HLP.GeraXml.dao.NFes
{
    public class daoServico
    {
        public DataTable BuscaDadosServico(string sNota)
        {
            try
            {
                StringBuilder sQuery = new StringBuilder();
                sQuery.Append("Select ");
                sQuery.Append("distinct movitem.ds_prod  ,movitem.vl_totbruto,coalesce(produto.cd_trib_municipio,'')cd_trib_municipio, " +
                              " coalesce(empresa.cd_lista_servico,'')cd_lista_servico_Emp, " +
                              " coalesce(produto.cd_lista_servico,'')cd_lista_servico_Prod from movitem ");
                sQuery.Append("left join produto on movitem.cd_prod = produto.cd_prod ");
                sQuery.Append("left join empresa on movitem.cd_empresa = empresa.cd_empresa ");
                sQuery.Append("where movitem.cd_nfseq = '" + sNota + "' and ");
                sQuery.Append("movitem.cd_empresa = '" + Acesso.CD_EMPRESA + "' and ");
                sQuery.Append("produto.cd_empresa = '" + Acesso.CD_EMPRESA + "'");

                return HlpDbFuncoes.qrySeekRet(sQuery.ToString());

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable BuscaValoresServico(string sNota)
        {
            try
            {
                StringBuilder sQuery = new StringBuilder();
                sQuery.Append(" select first 1 ");
                sQuery.Append(" nf.vl_servico ValorServicos, ");
                //sQuery.Append(" nf.vl_totnf ValorDeducoes, ");
                sQuery.Append(" nf.vl_pis_serv ValorPis, ");
                sQuery.Append(" nf.vl_cofins_serv ValorCofins, ");
                sQuery.Append(" nf.vl_inss ValorInss, ");
                sQuery.Append(" nf.vl_totir  ValorIr, ");
                sQuery.Append(" nf.vl_csll_serv vl_csll_serv, ");
                sQuery.Append(" COALESCE(TPDOC.st_retem_iss,'N')IssRetido  , ");//sim ou não
                sQuery.Append(" nf.vl_iss ValorIss, ");
                //sQuery.Append(" --  nf. OutrasRetencoes, ");
                sQuery.Append(" nf.vl_servico BaseCalculo, ");
                sQuery.Append(" movitem.vl_aliqserv Aliquota, ");
                sQuery.Append(" nf.vl_iss  ValorIssRetido ");
                //sQuery.Append(" -- nf.vl_d   DescontoCondicionado, ");
                //sQuery.Append(" -- nf.vl_ DescontoIncondicionado ");
                sQuery.Append(" from nf inner join movitem ");
                sQuery.Append(" on nf.cd_nfseq = movitem.cd_nfseq and ");
                sQuery.Append(" nf.cd_empresa  = movitem.cd_empresa ");
                sQuery.Append(" inner join tpdoc on nf.cd_tipodoc = tpdoc.cd_tipodoc ");
                sQuery.Append(" where nf.cd_nfseq = '" + sNota + "' and ");
                sQuery.Append(" nf.cd_empresa = '" + Acesso.CD_EMPRESA + "'");
                return HlpDbFuncoes.qrySeekRet(sQuery.ToString());
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public FbDataReader BuscaObservacao(StringBuilder sQuery)
        {
            try
            {
                return HlpDbFuncoes.qrySeekReader(sQuery.ToString());
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
