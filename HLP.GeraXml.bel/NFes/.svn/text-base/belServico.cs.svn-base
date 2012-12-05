using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HLP.GeraXml.dao.NFes;
using System.Data;
using HLP.GeraXml.Comum.Static;
using System.IO;
using FirebirdSql.Data.FirebirdClient;
using HLP.GeraXml.dao.ADO;
using HLP.GeraXml.dao;

namespace HLP.GeraXml.bel.NFes
{
    public class belServico : daoServico
    {
        public TcDadosServico RetornaDadosServico(string sNota, int iNaturezaOperacao)
        {
            try
            {
                TcDadosServico objTcDadosServico = new TcDadosServico();
                objTcDadosServico.Valores = BuscaValores(sNota, iNaturezaOperacao);

                DataTable dt = BuscaDadosServico(sNota);

                objTcDadosServico.Discriminacao = "Serviço(s) Realizado(s): "; 
                foreach (DataRow dr in dt.Rows)
                {
                    if (objTcDadosServico.ItemListaServico.Equals(""))
                    {
                        string CodLista = "";
                        if (dr["cd_lista_servico_Prod"].ToString() != "")
                        {
                            CodLista = dr["cd_lista_servico_Prod"].ToString();
                        }
                        else if (dr["cd_lista_servico_Emp"].ToString() != "")
                        {
                            CodLista = dr["cd_lista_servico_Emp"].ToString();
                        }
                        else
                        {
                            throw new Exception("É Necessário Configurar o Código da lista de Serviço no Cadastro de Produto!");
                        }

                        objTcDadosServico.ItemListaServico = CodLista;
                    }
                    if (objTcDadosServico.CodigoTributacaoMunicipio.Equals(""))
                    {
                        objTcDadosServico.CodigoTributacaoMunicipio = dr["cd_trib_municipio"].ToString();
                    }
                    objTcDadosServico.Discriminacao += Environment.NewLine + "* " + dr["ds_prod"].ToString().ToUpper() + " R$ " + Convert.ToDecimal(dr["vl_totbruto"].ToString()).ToString("#0.00");
                }

                objTcDadosServico.Discriminacao += Environment.NewLine + Environment.NewLine + "Observação:" + Environment.NewLine
                                                + BuscaObs(sNota);

                if (objTcDadosServico.Discriminacao[objTcDadosServico.Discriminacao.Length - 1].ToString().Equals("}"))
                {
                    objTcDadosServico.Discriminacao = objTcDadosServico.Discriminacao.Remove(objTcDadosServico.Discriminacao.Length - 1);
                }

                StringBuilder sQuery = new StringBuilder();
                sQuery.Append(" select ");
                sQuery.Append(" cidades.cd_municipio ");
                sQuery.Append(" from  empresa ");
                sQuery.Append(" left join cidades on (cidades.nm_cidnor = empresa.nm_cidnor) ");
                sQuery.Append(" where empresa.cd_empresa = '" + Acesso.CD_EMPRESA + "'");


                FbConnection con = HlpDbFuncoesGeral.conexao;
                FbCommand Command = new FbCommand(sQuery.ToString(), con);
                con.Open();
                objTcDadosServico.CodigoMunicipio = Command.ExecuteScalar().ToString();
                objTcDadosServico.CodigoCnae = "";
                con.Close();


                return objTcDadosServico;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private TcValores BuscaValores(string sNota, int iNaturezaOperacao)
        {
            TcValores objTcValores = new TcValores();

            try
            {
                DataTable dt = BuscaValoresServico(sNota);
                bool bNaoDestacaValor = false;

                if ((iNaturezaOperacao == 1) && Convert.ToBoolean(Acesso.DESTACA_IMP_TRIB_MUN) == true)
                {
                    bNaoDestacaValor = true;
                }
                foreach (DataRow dr in dt.Rows)
                {
                    objTcValores.ValorServicos = Convert.ToDecimal(dr["ValorServicos"].ToString());
                    objTcValores.ValorDeducoes = 0; //Convert.ToDecimal(dr["ValorDeducoes"].ToString());
                    objTcValores.ValorPis = (bNaoDestacaValor == true ? 0 : Convert.ToDecimal(dr["ValorPis"].ToString())); //conceito passado pela lorenzon
                    objTcValores.ValorCofins = (bNaoDestacaValor == true ? 0 : Convert.ToDecimal(dr["ValorCofins"].ToString())); //conceito passado pela lorenzon
                    objTcValores.ValorInss = Convert.ToDecimal(dr["ValorInss"].ToString());
                    objTcValores.ValorIr = (bNaoDestacaValor == true ? 0 : Convert.ToDecimal(dr["ValorIr"].ToString())); //conceito passado pela lorenzon
                    objTcValores.ValorCsll = (bNaoDestacaValor == true ? 0 : Convert.ToDecimal(dr["vl_csll_serv"].ToString())); //conceito passado pela lorenzon
                    objTcValores.IssRetido = (dr["IssRetido"].ToString() == "S" ? 1 : 2); //OS_26219
                    objTcValores.ValorIss = (objTcValores.IssRetido == 2 ? Convert.ToDecimal(dr["ValorIss"].ToString()) : 0); // se não for retido joga no valor ISS //OS_26219
                    objTcValores.OutrasRetencoes = 0;// Convert.ToDecimal(dr["OutrasRetencoes"].ToString());
                    objTcValores.BaseCalculo = Convert.ToDecimal(dr["BaseCalculo"].ToString());
                    objTcValores.Aliquota = Convert.ToDecimal(dr["Aliquota"].ToString());
                    objTcValores.ValorIssRetido = (objTcValores.IssRetido == 1 ? Convert.ToDecimal(dr["ValorIssRetido"].ToString()) : 0); // ser for retido joga no valor iss retido //OS_26219
                    objTcValores.DescontoCondicionado = 0;// Convert.ToDecimal(dr["DescontoCondicionado"].ToString());
                    objTcValores.DescontoIncondicionado = 0;// Convert.ToDecimal(dr["DescontoIncondicionado"].ToString());
                    objTcValores.ValorLiquidoNfse = objTcValores.CalculaValorLiquido();
                }

                return objTcValores;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string BuscaObs(string sNF)
        {
            string sObs = "";
            try
            {
                StringBuilder sQuery = new StringBuilder();
                sQuery.Append("Select ");
                sQuery.Append("nf.ds_anota ");
                if (((Acesso.NM_EMPRESA == "MOGPLAST") || (Acesso.NM_EMPRESA == "TSA")) && (Acesso.CD_EMPRESA == "003"))
                {
                    sQuery.Append(", nf.cd_nfseq_fat_origem ");
                }
                if (Acesso.NM_EMPRESA == "MACROTEX")
                {
                    sQuery.Append(", vendedor.nm_vend, ");
                    sQuery.Append("nf.DS_DOCORIG ");
                }
                sQuery.Append("From NF ");
                sQuery.Append("left join vendedor on (vendedor.cd_vend = nf.cd_vend1) ");
                sQuery.Append("Where ");
                sQuery.Append("(NF.cd_empresa ='");
                sQuery.Append(Acesso.CD_EMPRESA);
                sQuery.Append("')");
                sQuery.Append(" and ");
                sQuery.Append("(nf.cd_nfseq = '");
                sQuery.Append(sNF);
                sQuery.Append("') ");

                FbDataReader dr = BuscaObservacao(sQuery);

                sObs = daoUtil.RetornaBlob(sQuery.ToString());
                if (sObs.IndexOf("\\fs") != -1)
                {
                    sObs = sObs.Substring((sObs.IndexOf("\\fs") + 6), sObs.Length - (sObs.IndexOf("\\fs") + 6));
                }

                if (Acesso.NM_EMPRESA.Equals("LORENZON"))
                {
                    StringBuilder sQueryLorenzon = new StringBuilder();
                    sQueryLorenzon.Append("select prazos.ds_prazo, vendedor.nm_vend , clifor.cd_clifor from nf ");
                    sQueryLorenzon.Append("inner join clifor on nf.cd_clifor = clifor.cd_clifor ");
                    sQueryLorenzon.Append("inner join prazos on nf.cd_prazo = prazos.cd_prazo ");
                    sQueryLorenzon.Append(" inner join vendedor  on nf.cd_vendint = vendedor.cd_vend ");
                    sQueryLorenzon.Append("where nf.cd_nfseq = '" + sNF + "' ");
                    sQueryLorenzon.Append("and nf.cd_empresa = '" + Acesso.CD_EMPRESA + "' ");

                    FbDataReader drLorenzon = HlpDbFuncoes.qrySeekReader(sQueryLorenzon.ToString());
                    string sMsgLorenzon = "";


                    while (drLorenzon.Read())
                    {
                        sMsgLorenzon = "COND.PGTO = " + drLorenzon["ds_prazo"].ToString() + " | VENDEDOR = " + drLorenzon["nm_vend"].ToString() + " | COD. CLIENTE = " + drLorenzon["cd_clifor"].ToString();
                    }

                    sMsgLorenzon = sMsgLorenzon + Environment.NewLine + Environment.NewLine;
                    if (sMsgLorenzon != "")
                    {
                        sObs = sMsgLorenzon + sObs;
                    }
                }

                return sObs;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
