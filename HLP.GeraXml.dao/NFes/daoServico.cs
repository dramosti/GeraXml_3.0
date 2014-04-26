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
        private class CamposSelect
        {
            public string sCampo = "";
            public string sAlias = "";
            public bool bAgrupa = false;
        }

        public DataTable BuscaDadosServico(string sNota)
        {
            try
            {
                List<CamposSelect> lCampos = new List<CamposSelect>();
                StringBuilder sCampos = new StringBuilder();
                StringBuilder sInnerJoin = new StringBuilder();
                StringBuilder sWhere = new StringBuilder();
                StringBuilder sGroup = new StringBuilder();

                lCampos.Add(new CamposSelect { sCampo = "movitem.ds_prod", sAlias = "ds_prod" });
                lCampos.Add(new CamposSelect { sCampo = "coalesce(movitem.ds_obs,'')", sAlias = "ds_obs" });
                lCampos.Add(new CamposSelect { sCampo = "movitem.vl_totbruto", sAlias = "vl_totbruto", bAgrupa = Acesso.bAGRUPA_ITENS_NFSE });
                lCampos.Add(new CamposSelect { sCampo = "coalesce(produto.cd_trib_municipio,'')", sAlias = "cd_trib_municipio" });
                lCampos.Add(new CamposSelect { sCampo = "coalesce(empresa.cd_lista_servico,'')", sAlias = "cd_lista_servico_Emp" });
                lCampos.Add(new CamposSelect { sCampo = "coalesce(produto.cd_lista_servico,'')", sAlias = "cd_lista_servico_Prod" });
                
                sCampos.Append(Environment.NewLine + "Select " + Environment.NewLine);
                lCampos = lCampos.OrderBy(c => c.bAgrupa).ToList();
                for (int i = 0; i < lCampos.Count; i++)
                {
                    CamposSelect camp = lCampos[i];
                    string sFormat = "Sum({0}) ";
                    sCampos.Append((camp.bAgrupa ? string.Format(sFormat, camp.sCampo) : camp.sCampo) + " " + camp.sAlias + ((i + 1) != lCampos.Count() ? "," : "") + Environment.NewLine);
                }

                sInnerJoin.Append("from movitem ");
                sInnerJoin.Append("left join produto on movitem.cd_prod = produto.cd_prod ");
                sInnerJoin.Append("left join empresa on movitem.cd_empresa = empresa.cd_empresa ");

                #region Where
                sWhere.Append("Where ");
                sWhere.Append("movitem.cd_nfseq = '" + sNota + "' and ");
                sWhere.Append("movitem.cd_empresa = '" + Acesso.CD_EMPRESA + "' and ");
                sWhere.Append("produto.cd_empresa = '" + Acesso.CD_EMPRESA + "'" );
                #endregion
                if (Acesso.bAGRUPA_ITENS_NFSE)
                {
                    sGroup.Append(Environment.NewLine + " Group by " + Environment.NewLine);
                    lCampos = lCampos.Where(c => c.bAgrupa == false).ToList();
                    for (int i = 0; i < lCampos.Count; i++)
                    {
                        CamposSelect camp = lCampos[i];
                        if (camp.sCampo != "''")
                        {
                            sGroup.Append((camp.bAgrupa == false ? camp.sCampo + ((i + 1) < lCampos.Count() ? ", " : "") + Environment.NewLine : ""));
                        }
                    }
                }

                string sQueryItens = sCampos.ToString() + sInnerJoin + sWhere + (Acesso.bAGRUPA_ITENS_NFSE ? sGroup.ToString() : "");
                return HlpDbFuncoes.qrySeekRet(sQueryItens.ToString());

                //StringBuilder sQuery = new StringBuilder();
                //sQuery.Append("Select ");
                //sQuery.Append("distinct movitem.ds_prod, coalesce(movitem.ds_obs,'')ds_obs  ,movitem.vl_totbruto,coalesce(produto.cd_trib_municipio,'')cd_trib_municipio, " +
                //              " coalesce(empresa.cd_lista_servico,'')cd_lista_servico_Emp, " +
                //              " coalesce(produto.cd_lista_servico,'')cd_lista_servico_Prod from movitem ");
                //sQuery.Append("left join produto on movitem.cd_prod = produto.cd_prod ");
                //sQuery.Append("left join empresa on movitem.cd_empresa = empresa.cd_empresa ");
                //sQuery.Append("where movitem.cd_nfseq = '" + sNota + "' and ");
                //sQuery.Append("movitem.cd_empresa = '" + Acesso.CD_EMPRESA + "' and ");
                //sQuery.Append("produto.cd_empresa = '" + Acesso.CD_EMPRESA + "'");

                //return HlpDbFuncoes.qrySeekRet(sQuery.ToString());
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
                sQuery.Append(" nf.vl_totnf ValorDeducoes, ");
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


        public decimal SumValorMovitem(string sNFSEQ, string sFIELD)
        {
            try
            {
                decimal dValor = 0;

                string sResult = HlpDbFuncoes.qrySeekValue("MOVITEM", "SUM(" + sFIELD + ")", string.Format("cd_nfseq= '{0}' and cd_empresa = '{1}'", sNFSEQ, Acesso.CD_EMPRESA));

                if (sResult != "")
                {
                    dValor = Convert.ToDecimal(sResult);
                }
                return dValor;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
