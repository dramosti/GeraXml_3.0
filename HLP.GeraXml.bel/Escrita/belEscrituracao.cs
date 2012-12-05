using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HLP.GeraXml.bel.NFe.Estrutura;
using HLP.GeraXml.Comum;
using HLP.GeraXml.dao.ADO;
using FirebirdSql.Data.FirebirdClient;
using System.Data;
using HLP.GeraXml.Comum.Static;
using System.Windows.Forms;

namespace HLP.GeraXml.bel.Escrita
{
    public class belEscrituracao 
    {
        private belInfNFe objInfNFe;

        public bool bProdutorRural { get; set; }


        public belEscrituracao(belInfNFe pInfNFe)
        {
            try
            {
                bProdutorRural = false;
                objInfNFe = pInfNFe;
                string scdClifor = string.Empty;

                if (objInfNFe.Empresa != null)
                {
                    string sTipoLanc = TipoLancamento();
                    string sDoc = string.Empty;

                    #region Clientes/Fornecedores
                    if (objInfNFe.dest.Cnpj != null)
                    {
                        sDoc = FormataString(objInfNFe.dest.Cnpj.ToString(), "CNPJ");
                    }
                    else
                    {
                        sDoc = FormataString(objInfNFe.dest.Cpf.ToString(), "CPF");
                    }


                    if (!RegistroExiste("CLIFOR", (objInfNFe.dest.Cnpj != null ? "CD_CGC = '" : "CD_CPF ='") + sDoc + "'", "CD_CLIFOR"))
                    {

                        scdClifor = CadastraCliFor(sDoc);
                    }
                    else
                    {
                        scdClifor = BuscaCodigoClifor(sDoc);
                    }

                    objInfNFe.Cdclifor = scdClifor;
                    #endregion

                    bool bSaida = true;
                    if (sTipoLanc == "E")
                    {
                        bSaida = false;
                    }
                    Escritura(bSaida);
                }
            }
            catch (Exception ex)
            {
                new HLPexception(ex);
            }
        }

        FbConnection Conexao = HlpDbFuncoesGeral.conexao;



        private void Escritura(bool pbSaida)
        {
            string sNrSeqNF = string.Empty;

            try
            {
                sNrSeqNF = EscrituraPrincipal(pbSaida);

                EscrituraDesdobramento(sNrSeqNF, pbSaida);

                EscrituraItens(sNrSeqNF, pbSaida);

            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Não foi possível escriturar a nota de Saída {0}. Erro:" + Environment.NewLine + " {1}",
                                                   objInfNFe.ide.Nnf.ToString(),
                                                   ex.Message));
            }
        }

        public struct strucProd
        {
            public string scdcf { get; set; }
            public string scdLinha { get; set; }
        }


        private void EscrituraItens(string psNrSeqNF, bool pbSaida)
        {
            try
            {
                if (objInfNFe.det.Count > 0)
                {
                    for (int i = 0; i < objInfNFe.det.Count; i++)
                    {
                        StringBuilder sIncluiItensCampo = new StringBuilder();
                        StringBuilder sIncluiItensValor = new StringBuilder();

                        string sNrSeqItem = BuscaValorChavePrimaria("NOTAITEM", 7, "NR_SEQITEM", "NOTAITEM", objInfNFe.Empresa);

                        StringBuilder sFiltro = new StringBuilder();
                        sFiltro.Append("cd_empresa ='");
                        sFiltro.Append(objInfNFe.Empresa);
                        sFiltro.Append("'");
                        sFiltro.Append(" and ");
                        sFiltro.Append("NR_SEQITEM = '");
                        sFiltro.Append(sNrSeqItem);
                        sFiltro.Append("'");

                        if (RegistroExiste("NOTAITEM", sFiltro.ToString(), "nr_seqitem"))
                        {
                            EscrituraItens(psNrSeqNF, pbSaida);
                        }

                        strucProd objProd = BuscaProd(objInfNFe.Empresa, objInfNFe.det[i].prod);

                        sIncluiItensCampo.Append("cd_empresa");
                        sIncluiItensCampo.Append(", ");
                        sIncluiItensValor.Append("'");
                        sIncluiItensValor.Append(objInfNFe.Empresa.ToString());
                        sIncluiItensValor.Append("', ");

                        sIncluiItensCampo.Append("nr_seqitem");
                        sIncluiItensCampo.Append(", ");
                        sIncluiItensValor.Append("'");
                        sIncluiItensValor.Append(sNrSeqItem);
                        sIncluiItensValor.Append("', ");

                        sIncluiItensCampo.Append("cd_cf");
                        sIncluiItensCampo.Append(", ");

                        if (objProd.scdcf == null)
                        {
                            sIncluiItensValor.Append("null");
                            sIncluiItensValor.Append(", ");
                        }
                        else
                        {
                            sIncluiItensValor.Append("'");
                            sIncluiItensValor.Append(objProd.scdcf);
                            sIncluiItensValor.Append("', ");
                        }

                        sIncluiItensCampo.Append("cd_prod");
                        sIncluiItensCampo.Append(", ");
                        sIncluiItensValor.Append("'");
                        sIncluiItensValor.Append(objInfNFe.det[i].prod.Cprod.PadLeft(7, '0'));
                        sIncluiItensValor.Append("', ");

                        sIncluiItensCampo.Append("cd_tpunid");
                        sIncluiItensCampo.Append(", ");
                        sIncluiItensValor.Append("'");
                        sIncluiItensValor.Append(objInfNFe.det[i].prod.Ucom.ToString());
                        sIncluiItensValor.Append("', ");
                        string sdsprod = objInfNFe.det[i].prod.Xprod.ToString();
                        if (sdsprod.Length > 35)
                        {
                            sdsprod = sdsprod.Substring(0, 34);

                        }
                        sIncluiItensCampo.Append("ds_prod");
                        sIncluiItensCampo.Append(", ");
                        sIncluiItensValor.Append("'");
                        sIncluiItensValor.Append(sdsprod);
                        sIncluiItensValor.Append("', ");

                        sIncluiItensCampo.Append("nr_folre");
                        sIncluiItensCampo.Append(", ");
                        sIncluiItensValor.Append("0");
                        sIncluiItensValor.Append(", ");

                        sIncluiItensCampo.Append("nr_lre");
                        sIncluiItensCampo.Append(", ");
                        sIncluiItensValor.Append("0");
                        sIncluiItensValor.Append(", ");

                        sIncluiItensCampo.Append("nr_seqnf");
                        sIncluiItensCampo.Append(", ");
                        sIncluiItensValor.Append("'");
                        sIncluiItensValor.Append(psNrSeqNF);
                        sIncluiItensValor.Append("', ");

                        sIncluiItensCampo.Append("qt_prod");
                        sIncluiItensCampo.Append(", ");
                        sIncluiItensValor.Append(objInfNFe.det[i].prod.Qcom.ToString().Replace(",", "."));
                        sIncluiItensValor.Append(", ");

                        sIncluiItensCampo.Append("st_mob");
                        sIncluiItensCampo.Append(", ");
                        sIncluiItensValor.Append("'");
                        sIncluiItensValor.Append("N");
                        sIncluiItensValor.Append("', ");

                        if (objInfNFe.det[i].imposto.belIpi != null)
                        {
                            if (objInfNFe.det[i].imposto.belIpi.belIpitrib != null)
                            {

                                sIncluiItensCampo.Append("vl_aliipi");
                                sIncluiItensCampo.Append(", ");
                                sIncluiItensValor.Append(objInfNFe.det[i].imposto.belIpi.belIpitrib.Pipi.ToString().Replace(",", "."));
                                sIncluiItensValor.Append(", ");

                                sIncluiItensCampo.Append("vl_baseipi");
                                sIncluiItensCampo.Append(", ");
                                sIncluiItensValor.Append(objInfNFe.det[i].imposto.belIpi.belIpitrib.Vbc.ToString().Replace(",", "."));
                                sIncluiItensValor.Append(", ");

                                sIncluiItensCampo.Append("vl_ipi");
                                sIncluiItensCampo.Append(", ");
                                sIncluiItensValor.Append(objInfNFe.det[i].imposto.belIpi.belIpitrib.Vipi.ToString().Replace(",", "."));
                                sIncluiItensValor.Append(", ");
                            }
                        }

                        string sCFOP = string.Empty;

                        if (pbSaida)
                        {
                            sCFOP = objInfNFe.det[i].prod.Cfop.ToString();
                        }
                        else
                        {
                            sCFOP = AnalisaCFOPEntrada(objInfNFe.det[i].prod.Cfop.ToString());
                            switch (sCFOP.Substring(0, 1))
                            {
                                case "5":
                                    {
                                        sCFOP = "1" + sCFOP.Substring(1, 3);
                                        break;
                                    }
                                case "6":
                                    {
                                        sCFOP = "2" + sCFOP.Substring(1, 3);
                                        break;
                                    }
                                case "7":
                                    {
                                        sCFOP = "3" + sCFOP.Substring(1, 3);
                                        break;
                                    }

                            }
                        }
                        sIncluiItensCampo.Append("cd_cfop");
                        sIncluiItensCampo.Append(", ");
                        sIncluiItensValor.Append("'");
                        sIncluiItensValor.Append(sCFOP);
                        sIncluiItensValor.Append("', ");

                        if (objInfNFe.det[i].imposto.belIcms.belIcms40 != null)
                        {
                            sIncluiItensCampo.Append("vl_baseicms");
                            sIncluiItensCampo.Append(", ");
                            sIncluiItensValor.Append("0");
                            sIncluiItensValor.Append(", ");

                            sIncluiItensCampo.Append("vl_baseicmsst");
                            sIncluiItensCampo.Append(", ");
                            sIncluiItensValor.Append("0");
                            sIncluiItensValor.Append(", ");

                            sIncluiItensCampo.Append("vl_aliicms");
                            sIncluiItensCampo.Append(", ");
                            sIncluiItensValor.Append("0");
                            sIncluiItensValor.Append(", ");
                        }

                        sIncluiItensCampo.Append("vl_unit");
                        sIncluiItensCampo.Append(", ");
                        sIncluiItensValor.Append(objInfNFe.det[i].prod.Vuncom.ToString().Replace(",", "."));
                        sIncluiItensValor.Append(", ");

                        sIncluiItensCampo.Append("vl_desc");
                        sIncluiItensCampo.Append(", ");
                        sIncluiItensValor.Append(objInfNFe.det[i].prod.Vdesc.ToString().Replace(",", "."));
                        sIncluiItensValor.Append(", ");

                        sIncluiItensCampo.Append("st_canc");
                        sIncluiItensCampo.Append(", ");
                        sIncluiItensValor.Append("'");
                        sIncluiItensValor.Append("N");
                        sIncluiItensValor.Append("', ");

                        sIncluiItensCampo.Append("tp_item");
                        sIncluiItensCampo.Append(", ");
                        sIncluiItensValor.Append("'");
                        sIncluiItensValor.Append("000");
                        sIncluiItensValor.Append("', ");


                        sIncluiItensCampo.Append("vl_tot");
                        //sIncluiItensCampo.Append(", ");
                        sIncluiItensValor.Append(objInfNFe.det[i].prod.Vprod.ToString().Replace(",", "."));
                        //sIncluiItensValor.Append(", ");

                        string sInstrucao = string.Format("Insert into notaitem ({0}) values ({1})",
                                                          sIncluiItensCampo.ToString(),
                                                          sIncluiItensValor.ToString());



                        using (FbCommand cmd = new FbCommand(sInstrucao, Conexao))
                        {
                            if (Conexao.State != ConnectionState.Open)
                            {
                                Conexao.Open();
                            }
                            cmd.ExecuteNonQuery();
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Não foi possível escriturar os itens, Erro {0}",
                                                   ex.Message));
            }

        }

        private strucProd BuscaProd(string psEmp, belProd psObjProd)
        {

            psObjProd.Cprod = psObjProd.Cprod.Replace(" ", "").ToUpper();

            if (psObjProd.Cprod.Length > 7)
            {
                psObjProd.Cprod = psObjProd.Cprod.Substring(0, 7);
            }

            strucProd objProd = new strucProd();
            try
            {
                StringBuilder sFiltro = new StringBuilder();
                sFiltro.Append("cd_empresa = '");
                sFiltro.Append(psEmp);
                sFiltro.Append("'");
                sFiltro.Append(" and ");
                sFiltro.Append("ds_prod = '");
                sFiltro.Append(psObjProd.Xprod.Trim());
                sFiltro.Append("'");

                bool bAchouProd = RegistroExiste("PRODUTO", sFiltro.ToString(), "ds_prod");

                if (bAchouProd)
                {
                    psObjProd.Cprod = RetCodigoRegistro("PRODUTO", sFiltro.ToString(), "cd_prod");
                }
                else
                {
                    psObjProd.Cprod = RetornaProximoValorGenerator("PRODUTO190", 7);
                }


                if (bAchouProd)
                {


                    StringBuilder sCamposProd = new StringBuilder();
                    sCamposProd.Append("Select ");
                    sCamposProd.Append("cd_linha, ");
                    sCamposProd.Append("cd_cf ");
                    sCamposProd.Append("from Produto ");
                    sCamposProd.Append("Where ");


                    using (FbCommand cmd = new FbCommand(sCamposProd.ToString() + sFiltro.ToString(), Conexao))
                    {
                        if (Conexao.State != ConnectionState.Open)
                        {
                            Conexao.Open();
                        }

                        FbDataReader dr = cmd.ExecuteReader();
                        if (dr.Read())
                        {
                            if (dr["cd_cf"].ToString() == "")
                            {
                                objProd.scdcf = null;
                            }
                            else
                            {
                                objProd.scdcf = dr["cd_cf"].ToString();
                            }

                            objProd.scdLinha = dr["cd_linha"].ToString();
                        }


                    }
                }
                else
                {
                    string dsmcm = string.Empty;
                    dsmcm = (psObjProd.Ncm != null ? psObjProd.Ncm.ToString() : "GERAL");

                    StringBuilder sbNCM = new StringBuilder();
                    sbNCM.Append("cd_empresa ='");
                    sbNCM.Append(psEmp);
                    sbNCM.Append("'");
                    sbNCM.Append(" and ");
                    sbNCM.Append("ds_clasfis ='");
                    sbNCM.Append(dsmcm);
                    sbNCM.Append("'");

                    bool bAchouCF = RegistroExiste("CLAS_FIS", sbNCM.ToString(), "cd_cf");

                    string scf = string.Empty;

                    if (bAchouCF)
                    {
                        using (FbCommand cmd = new FbCommand("Select cd_cf from clas_fis where " + sbNCM.ToString(), Conexao))
                        {
                            if (Conexao.State != ConnectionState.Open)
                            {
                                Conexao.Open();
                            }
                            scf = cmd.ExecuteScalar().ToString();
                        }

                    }
                    else
                    {
                        scf = CadastraCF(psObjProd);
                    }


                    objProd.scdcf = scf;

                    StringBuilder sbLinha = new StringBuilder();
                    sbLinha.Append("cd_empresa ='");
                    sbLinha.Append(psEmp);
                    sbLinha.Append("'");
                    sbLinha.Append(" and ");
                    sbLinha.Append("ds_linha ='");
                    sbLinha.Append("GERAL");
                    sbLinha.Append("'");

                    bool bAchouLinha = RegistroExiste("LINHAPRO", sbLinha.ToString(), "cd_linha");

                    string sLinha = string.Empty;

                    if (bAchouLinha)
                    {
                        using (FbCommand cmd = new FbCommand("Select cd_linha from linhapro where " + sbLinha.ToString(), Conexao))
                        {
                            if (Conexao.State != ConnectionState.Open)
                            {
                                Conexao.Open();
                            }
                            sLinha = cmd.ExecuteScalar().ToString();
                        }

                    }
                    else
                    {
                        sLinha = CadastraLinha(psObjProd);
                    }
                    objProd.scdLinha = sLinha;

                    StringBuilder sbUnidade = new StringBuilder();
                    sbUnidade.Append("cd_tpunid ='");
                    sbUnidade.Append(psObjProd.Ucom.ToString());
                    sbUnidade.Append("'");

                    bool bAchouUnidade = RegistroExiste("UNIDADES", sbUnidade.ToString(), "cd_tpunid");

                    string sUnidade = string.Empty;

                    if (bAchouUnidade)
                    {
                        using (FbCommand cmd = new FbCommand("Select cd_tpunid from Unidades where " + sbUnidade.ToString(), Conexao))
                        {
                            if (Conexao.State != ConnectionState.Open)
                            {
                                Conexao.Open();
                            }
                            sUnidade = cmd.ExecuteScalar().ToString();
                        }

                    }
                    else
                    {
                        sUnidade = CadastraUnidade(psObjProd);
                    }

                    StringBuilder sbProdutoCampos = new StringBuilder();
                    StringBuilder sbProdutoValores = new StringBuilder();

                    sbProdutoCampos.Append("cd_empresa");
                    sbProdutoCampos.Append(", ");
                    sbProdutoValores.Append("'");
                    sbProdutoValores.Append(objInfNFe.Empresa.ToString());
                    sbProdutoValores.Append("', ");

                    sbProdutoCampos.Append("cd_prod");
                    sbProdutoCampos.Append(", ");
                    sbProdutoValores.Append("'");
                    sbProdutoValores.Append(psObjProd.Cprod.ToString().PadLeft(7, '0'));
                    sbProdutoValores.Append("', ");

                    sbProdutoCampos.Append("cd_cf");
                    sbProdutoCampos.Append(", ");
                    sbProdutoValores.Append("'");
                    sbProdutoValores.Append(scf);
                    sbProdutoValores.Append("', ");

                    sbProdutoCampos.Append("cd_linha");
                    sbProdutoCampos.Append(", ");
                    sbProdutoValores.Append("'");
                    sbProdutoValores.Append(sLinha);
                    sbProdutoValores.Append("', ");

                    sbProdutoCampos.Append("cd_tpunid");
                    sbProdutoCampos.Append(", ");
                    sbProdutoValores.Append("'");
                    sbProdutoValores.Append(sUnidade);
                    sbProdutoValores.Append("', ");

                    string sdsprod = psObjProd.Xprod.ToString();
                    if (sdsprod.Length > 35)
                    {
                        sdsprod = sdsprod.Substring(0, 34);
                    }
                    sbProdutoCampos.Append("ds_prod");
                    sbProdutoCampos.Append(", ");
                    sbProdutoValores.Append("'");
                    sbProdutoValores.Append(sdsprod.Trim());
                    sbProdutoValores.Append("', ");

                    sbProdutoCampos.Append("cd_alter");
                    sbProdutoValores.Append("'");
                    sbProdutoValores.Append(psObjProd.Cprod);
                    sbProdutoValores.Append("' ");

                    string sInstrucao = string.Format("insert into produto ({0}) values ({1})",
                                                      sbProdutoCampos.ToString(),
                                                      sbProdutoValores.ToString());

                    using (FbCommand cmd = new FbCommand(sInstrucao, Conexao))
                    {
                        if (Conexao.State != ConnectionState.Open)
                        {
                            Conexao.Open();
                        }
                        cmd.ExecuteNonQuery();

                    }

                }



            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Não foi possível Buscar o Item, Erro {0}",
                                                  ex.Message));
            }

            return objProd;

        }

        private string CadastraUnidade(belProd psObjProd)
        {
            string sUnidade = psObjProd.Ucom;
            try
            {
                // sUnidade = BuscaValorChavePrimaria("UNIDADES", 2, "CD_TPUNID", "UNIDADES", objInfNFe.Empresa);

                StringBuilder sbUnidadeCampos = new StringBuilder();
                StringBuilder sbUnidadeValores = new StringBuilder();

                sbUnidadeCampos.Append("cd_tpunid");
                sbUnidadeCampos.Append(", ");
                sbUnidadeValores.Append("'");
                sbUnidadeValores.Append(sUnidade);
                sbUnidadeValores.Append("', ");

                sbUnidadeCampos.Append("ds_unidade");
                sbUnidadeValores.Append("'");
                sbUnidadeValores.Append(sUnidade);
                sbUnidadeValores.Append("' ");

                string sInstrucao = string.Format("insert into Unidades ({0}) values ({1})",
                                                  sbUnidadeCampos.ToString(),
                                                  sbUnidadeValores.ToString());

                using (FbCommand cmd = new FbCommand(sInstrucao, Conexao))
                {
                    if (Conexao.State != ConnectionState.Open)
                    {
                        Conexao.Open();
                    }
                    cmd.ExecuteNonQuery();

                }


            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Não foi possível cadastrar a Unidade do Produto. Erro {0}",
                                                  ex.Message));
            }
            finally
            {
                if (Conexao.State == ConnectionState.Open)
                {
                    Conexao.Close();
                }
            }

            return sUnidade;
        }

        private string CadastraLinha(belProd psObjProd)
        {
            string sLinha = string.Empty;
            try
            {
                sLinha = BuscaValorChavePrimaria("LINHAPRO", 7, "CD_LINHA", "LINHAPRO", objInfNFe.Empresa);


                StringBuilder sFiltro = new StringBuilder();
                sFiltro.Append("cd_empresa ='");
                sFiltro.Append(objInfNFe.Empresa);
                sFiltro.Append("'");
                sFiltro.Append(" and ");
                sFiltro.Append("cd_linha = '");
                sFiltro.Append(sLinha);
                sFiltro.Append("'");

                if (!RegistroExiste("LINHAPRO", sFiltro.ToString(), "CD_LINHA"))
                {


                    StringBuilder sbLinhaCampos = new StringBuilder();
                    StringBuilder sbLinhaValores = new StringBuilder();

                    sbLinhaCampos.Append("cd_empresa");
                    sbLinhaCampos.Append(", ");
                    sbLinhaValores.Append("'");
                    sbLinhaValores.Append(objInfNFe.Empresa.ToString());
                    sbLinhaValores.Append("', ");

                    sbLinhaCampos.Append("cd_linha");
                    sbLinhaCampos.Append(", ");
                    sbLinhaValores.Append("'");
                    sbLinhaValores.Append(sLinha);
                    sbLinhaValores.Append("', ");

                    sbLinhaCampos.Append("ds_linha");
                    sbLinhaCampos.Append(", ");
                    sbLinhaValores.Append("'");
                    sbLinhaValores.Append("Geral");
                    sbLinhaValores.Append("', ");

                    sbLinhaCampos.Append("st_linha");
                    sbLinhaValores.Append("'");
                    sbLinhaValores.Append("A");
                    sbLinhaValores.Append("' ");

                    string sInstrucao = string.Format("insert into LinhaPro ({0}) values ({1})",
                                                      sbLinhaCampos.ToString(),
                                                      sbLinhaValores.ToString());
                    using (FbCommand cmd = new FbCommand(sInstrucao, Conexao))
                    {
                        if (Conexao.State != ConnectionState.Open)
                        {
                            Conexao.Open();
                        }
                        cmd.ExecuteNonQuery();

                    }
                }


            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Não foi possível cadastrar a Linha de Produto. Erro {0}",
                                                  ex.Message));
            }
            finally
            {
                if (Conexao.State == ConnectionState.Open)
                {
                    Conexao.Close();
                }
            }

            return sLinha;
        }

        private string CadastraCF(belProd psObjProd)
        {
            string scf = string.Empty;
            try
            {
                scf = BuscaValorChavePrimaria("CLAS_FIS", 7, "CD_CF", "CLAS_FIS", objInfNFe.Empresa);

                StringBuilder sbCFCampos = new StringBuilder();
                StringBuilder sbCFValores = new StringBuilder();

                string sdsMcn = (psObjProd.Ncm != null ? psObjProd.Ncm.ToString() : "GERAL");



                sbCFCampos.Append("cd_empresa");
                sbCFCampos.Append(", ");
                sbCFValores.Append("'");
                sbCFValores.Append(objInfNFe.Empresa.ToString());
                sbCFValores.Append("', ");

                sbCFCampos.Append("cd_cf");
                sbCFCampos.Append(", ");
                sbCFValores.Append("'");
                sbCFValores.Append(scf);
                sbCFValores.Append("', ");

                sbCFCampos.Append("ds_clasfis");
                sbCFCampos.Append(", ");
                sbCFValores.Append("'");
                sbCFValores.Append(sdsMcn);
                sbCFValores.Append("', ");

                sbCFCampos.Append("ds_ncm");
                sbCFCampos.Append(" ");
                sbCFValores.Append("'");
                sbCFValores.Append(sdsMcn);
                sbCFValores.Append("' ");

                string sInstrucao = string.Format("insert into clas_fis ({0}) values ({1})",
                                                  sbCFCampos.ToString(),
                                                  sbCFValores.ToString());
                using (FbCommand cmd = new FbCommand(sInstrucao, Conexao))
                {
                    if (Conexao.State != ConnectionState.Open)
                    {
                        Conexao.Open();
                    }
                    cmd.ExecuteNonQuery();

                }


            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Não foi possível cadastrar a Classificação fiscal, Erro {0}",
                                                  ex.Message));
            }
            finally
            {
                if (Conexao.State == ConnectionState.Open)
                {
                    Conexao.Close();
                }
            }
            return scf;
        }

        public struct strucCFOP
        {
            public string CFOP { get; set; }
            public decimal Aliquota { get; set; }
            public decimal Valor { get; set; }
            public string Cst { get; set; }
            public decimal Desconto { get; set; }
            public decimal ICmsST { get; set; }
            public decimal vBCICMS { get; set; }
            public decimal vBCICMSST { get; set; }
            public decimal vICMS { get; set; }
        }

        private void EscrituraDesdobramento(string psNrSeqNF, bool pbSaida)
        {
            try
            {
                string sCFOP = string.Empty;

                List<strucCFOP> lobjCFOP = new List<strucCFOP>();


                if (objInfNFe.det.Count > 0)
                {
                    for (int i = 0; i < objInfNFe.det.Count; i++)
                    {
                        strucCFOP objCFOP = new strucCFOP();
                        if (pbSaida)
                        {
                            objCFOP.CFOP = objInfNFe.det[i].prod.Cfop.ToString();
                        }
                        else
                        {
                            sCFOP = AnalisaCFOPEntrada(objInfNFe.det[i].prod.Cfop.ToString());
                            switch (sCFOP.Substring(0, 1))
                            {

                                case "5":
                                    {
                                        objCFOP.CFOP = "1" + sCFOP.Substring(1, 3);
                                        break;
                                    }
                                case "6":
                                    {
                                        objCFOP.CFOP = "2" + sCFOP.Substring(1, 3);
                                        break;
                                    }
                                case "7":
                                    {
                                        objCFOP.CFOP = "3" + sCFOP.Substring(1, 3);
                                        break;
                                    }
                                default:
                                    {
                                        objCFOP.CFOP = sCFOP;
                                        break;
                                    }

                            }
                        }


                        objCFOP.Desconto = objInfNFe.det[i].prod.Vdesc;

                        if (objInfNFe.det[i].imposto.belIcms.belIcms00 != null)
                        {

                            objCFOP.Aliquota = objInfNFe.det[i].imposto.belIcms.belIcms00.Picms;
                            objCFOP.Cst = objInfNFe.det[i].imposto.belIcms.belIcms00.Cst.ToString();
                            objCFOP.vBCICMS = objInfNFe.det[i].imposto.belIcms.belIcms00.Vbc;
                            objCFOP.vICMS = objInfNFe.det[i].imposto.belIcms.belIcms00.Vicms;

                        }
                        else if (objInfNFe.det[i].imposto.belIcms.belIcms10 != null)
                        {   //Outras + campo de observação + aliquota interna + base do icms retido + valor do icms em outros produtos
                            objCFOP.Aliquota = objInfNFe.det[i].imposto.belIcms.belIcms10.Picms;
                            objCFOP.Cst = objInfNFe.det[i].imposto.belIcms.belIcms10.Cst.ToString();

                        }
                        else if (objInfNFe.det[i].imposto.belIcms.belIcms20 != null)
                        {
                            objCFOP.Aliquota = objInfNFe.det[i].imposto.belIcms.belIcms20.Picms;
                            objCFOP.Cst = objInfNFe.det[i].imposto.belIcms.belIcms20.Cst.ToString();
                            objCFOP.vBCICMS = objInfNFe.det[i].imposto.belIcms.belIcms20.Vbc;
                            objCFOP.vICMS = objInfNFe.det[i].imposto.belIcms.belIcms20.Vicms;

                        }

                        else if (objInfNFe.det[i].imposto.belIcms.belIcms30 != null)
                        {
                            objCFOP.Aliquota = 0;
                            objCFOP.Cst = objInfNFe.det[i].imposto.belIcms.belIcms30.Cst.ToString();
                            objCFOP.vBCICMSST = objInfNFe.det[i].imposto.belIcms.belIcms30.Vbcst;
                            objCFOP.ICmsST = objInfNFe.det[i].imposto.belIcms.belIcms30.Vicmsst;

                        }
                        else if (objInfNFe.det[i].imposto.belIcms.belIcms40 != null)
                        {
                            objCFOP.Aliquota = 0;
                            objCFOP.Cst = objInfNFe.det[i].imposto.belIcms.belIcms40.Cst.ToString();

                        }
                        else if (objInfNFe.det[i].imposto.belIcms.belIcms41 != null)
                        {
                            objCFOP.Aliquota = 0;
                            objCFOP.Cst = objInfNFe.det[i].imposto.belIcms.belIcms41.Cst.ToString();


                        }
                        else if (objInfNFe.det[i].imposto.belIcms.belIcms50 != null)
                        {
                            objCFOP.Aliquota = 0;
                            objCFOP.Cst = objInfNFe.det[i].imposto.belIcms.belIcms50.Cst.ToString();

                        }
                        else if (objInfNFe.det[i].imposto.belIcms.belIcms51 != null)
                        {
                            objCFOP.Aliquota = objInfNFe.det[i].imposto.belIcms.belIcms51.Picms;
                            objCFOP.Cst = objInfNFe.det[i].imposto.belIcms.belIcms51.Cst.ToString();

                        }
                        else if (objInfNFe.det[i].imposto.belIcms.belIcms60 != null)
                        {
                            objCFOP.Aliquota = 0;
                            objCFOP.Cst = objInfNFe.det[i].imposto.belIcms.belIcms60.Cst.ToString();
                            objCFOP.ICmsST = objInfNFe.det[i].imposto.belIcms.belIcms60.Vicmsstret;
                            objCFOP.vBCICMSST = objInfNFe.det[i].imposto.belIcms.belIcms60.Vbcstret;

                        }
                        else if (objInfNFe.det[i].imposto.belIcms.belIcms70 != null)
                        {
                            objCFOP.Aliquota = objInfNFe.det[i].imposto.belIcms.belIcms70.Picms;
                            objCFOP.Cst = objInfNFe.det[i].imposto.belIcms.belIcms70.Cst.ToString();

                        }
                        else if (objInfNFe.det[i].imposto.belIcms.belIcms90 != null)
                        {
                            objCFOP.Aliquota = 0;
                            objCFOP.Cst = objInfNFe.det[i].imposto.belIcms.belIcms90.Cst.ToString();
                        }
                        else if (objInfNFe.det[i].imposto.belIcms.belICMSSN101 != null)
                        {
                            objCFOP.Aliquota = 0;
                            objCFOP.Cst = objInfNFe.det[i].imposto.belIcms.belICMSSN101.CSOSN.ToString();
                        }
                        else if (objInfNFe.det[i].imposto.belIcms.belICMSSN102 != null)
                        {
                            objCFOP.Aliquota = 0;
                            objCFOP.Cst = objInfNFe.det[i].imposto.belIcms.belICMSSN102.CSOSN.ToString();
                        }
                        else if (objInfNFe.det[i].imposto.belIcms.belICMSSN201 != null)
                        {
                            objCFOP.Aliquota = 0;
                            objCFOP.ICmsST = objInfNFe.det[i].imposto.belIcms.belICMSSN201.vICMSST;
                            objCFOP.vBCICMSST = objInfNFe.det[i].imposto.belIcms.belICMSSN201.vBCST;
                            objCFOP.Cst = objInfNFe.det[i].imposto.belIcms.belICMSSN201.CSOSN.ToString();
                        }
                        else if (objInfNFe.det[i].imposto.belIcms.belICMSSN500 != null)
                        {
                            objCFOP.Aliquota = 0;
                            objCFOP.ICmsST = objInfNFe.det[i].imposto.belIcms.belICMSSN500.vICMSSTRet;
                            objCFOP.vBCICMSST = objInfNFe.det[i].imposto.belIcms.belICMSSN500.vBCSTRet;
                            objCFOP.Cst = objInfNFe.det[i].imposto.belIcms.belICMSSN500.CSOSN.ToString();
                        }
                        else if (objInfNFe.det[i].imposto.belIcms.belICMSSN900 != null)
                        {
                            objCFOP.Aliquota = Convert.ToDecimal(objInfNFe.det[i].imposto.belIcms.belICMSSN900.pICMS);
                            objCFOP.vICMS = Convert.ToDecimal(objInfNFe.det[i].imposto.belIcms.belICMSSN900.vICMS);
                            objCFOP.vBCICMS = Convert.ToDecimal(objInfNFe.det[i].imposto.belIcms.belICMSSN900.vBC);
                            objCFOP.ICmsST = Convert.ToDecimal(objInfNFe.det[i].imposto.belIcms.belICMSSN900.vICMSST);
                            objCFOP.vBCICMSST = Convert.ToDecimal(objInfNFe.det[i].imposto.belIcms.belICMSSN900.vBCST);
                            objCFOP.Cst = objInfNFe.det[i].imposto.belIcms.belICMSSN900.CSOSN.ToString();
                        }

                        objCFOP.Valor = (objInfNFe.det[i].prod.Vprod - objInfNFe.det[i].prod.Vdesc + objInfNFe.det[i].prod.Vfrete) + objCFOP.ICmsST;


                        lobjCFOP.Add(objCFOP);
                    }
                    var vCFOPs = from c in lobjCFOP
                                 group new { c.Valor, c.vBCICMS, c.vICMS, c.vBCICMSST, c.ICmsST } by
                                     new { c.CFOP, c.Cst, c.Aliquota }
                                     into r
                                     select new
                                     {
                                         CFOP = r.Key.CFOP,
                                         CST = r.Key.Cst,
                                         Aliq = r.Key.Aliquota,
                                         valor = r.Sum(v => v.Valor),
                                         BCICMS = r.Sum(b => b.vBCICMS),
                                         VICMS = r.Sum(i => i.vICMS),
                                         VBCICMSST = r.Sum(j => j.vBCICMSST),
                                         ICMSST = r.Sum(l => l.ICmsST)
                                     };


                    bool bIndustria = false;
                    try
                    {
                        if (Conexao.State == ConnectionState.Closed)
                        {
                            Conexao.Open();
                        }

                        string sQuery = "select empresa.cd_catego from empresa where empresa.cd_empresa = '" + objInfNFe.Empresa + "'";

                        FbCommand cmd = new FbCommand(sQuery, Conexao);

                        FbDataReader dr = cmd.ExecuteReader();
                        dr.Read();

                        bIndustria = (dr["cd_catego"].ToString().Equals("2.00.01") ? true : false);



                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                        if (Conexao.State == ConnectionState.Open)
                        {
                            Conexao.Close();
                        }

                    }


                    foreach (var item in vCFOPs)
                    {
                        StringBuilder sIncluiCFOPsCampos = new StringBuilder();
                        StringBuilder sIncluiCFOPsValores = new StringBuilder();
                        string sNrSeqNFCFOP = BuscaValorChavePrimaria("NOTACFOP", 7, "NR_SEQNFCFOP", "NOTACFOP", objInfNFe.Empresa);
                        string teste = "";
                        switch (item.CST)
                        {
                            #region 00
                            case "00":
                                {
                                    sIncluiCFOPsCampos.Append("cd_empresa");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("'");
                                    sIncluiCFOPsValores.Append(objInfNFe.Empresa.ToString());
                                    sIncluiCFOPsValores.Append("', ");

                                    sIncluiCFOPsCampos.Append("NR_SEQNFCFOP");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("'");
                                    sIncluiCFOPsValores.Append(sNrSeqNFCFOP);
                                    sIncluiCFOPsValores.Append("', ");

                                    sIncluiCFOPsCampos.Append("cd_cfop");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("'");
                                    sIncluiCFOPsValores.Append(item.CFOP.ToString());
                                    sIncluiCFOPsValores.Append("', ");

                                    sIncluiCFOPsCampos.Append("cd_lancont");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("'");
                                    sIncluiCFOPsValores.Append("000");
                                    sIncluiCFOPsValores.Append("', ");

                                    sIncluiCFOPsCampos.Append("nr_seqnf");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("'");
                                    sIncluiCFOPsValores.Append(psNrSeqNF);
                                    sIncluiCFOPsValores.Append("', ");

                                    sIncluiCFOPsCampos.Append("vl_contabil");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append(item.valor.ToString().Replace(",", "."));
                                    sIncluiCFOPsValores.Append(", ");

                                    sIncluiCFOPsCampos.Append("vl_baseicm");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append(item.BCICMS.ToString().Replace(",", "."));
                                    sIncluiCFOPsValores.Append(", ");

                                    sIncluiCFOPsCampos.Append("vl_aliicm");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append(item.Aliq.ToString().Replace(",", "."));
                                    sIncluiCFOPsValores.Append(", ");

                                    sIncluiCFOPsCampos.Append("vl_icms");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append(item.VICMS.ToString().Replace(",", "."));
                                    sIncluiCFOPsValores.Append(", ");

                                    sIncluiCFOPsCampos.Append("vl_outicm");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("0");
                                    sIncluiCFOPsValores.Append(", ");

                                    sIncluiCFOPsCampos.Append("vl_isenicm");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("0");
                                    sIncluiCFOPsValores.Append(", ");

                                    sIncluiCFOPsCampos.Append("st_combustivel");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("'");
                                    sIncluiCFOPsValores.Append("N");
                                    sIncluiCFOPsValores.Append("', ");

                                    sIncluiCFOPsCampos.Append("st_canc");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("'");
                                    sIncluiCFOPsValores.Append("N");
                                    sIncluiCFOPsValores.Append("', ");

                                    sIncluiCFOPsCampos.Append("cd_lanimp");
                                    sIncluiCFOPsValores.Append("'");
                                    sIncluiCFOPsValores.Append("000'");


                                    if (bIndustria)
                                    {
                                        sIncluiCFOPsCampos.Append(", vl_outripi");
                                        sIncluiCFOPsValores.Append(", ");
                                        sIncluiCFOPsValores.Append(item.valor.ToString().Replace(",", "."));
                                    }
                                    break;
                                }
                            #endregion

                            #region 10
                            case "10":
                                {
                                    sIncluiCFOPsCampos.Append("cd_empresa");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("'");
                                    sIncluiCFOPsValores.Append(objInfNFe.Empresa.ToString());
                                    sIncluiCFOPsValores.Append("', ");

                                    sIncluiCFOPsCampos.Append("NR_SEQNFCFOP");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("'");
                                    sIncluiCFOPsValores.Append(sNrSeqNFCFOP);
                                    sIncluiCFOPsValores.Append("', ");

                                    sIncluiCFOPsCampos.Append("cd_cfop");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("'");
                                    sIncluiCFOPsValores.Append(item.CFOP.ToString());
                                    sIncluiCFOPsValores.Append("', ");

                                    sIncluiCFOPsCampos.Append("cd_lancont");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("'");
                                    sIncluiCFOPsValores.Append("000");
                                    sIncluiCFOPsValores.Append("', ");

                                    sIncluiCFOPsCampos.Append("nr_seqnf");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("'");
                                    sIncluiCFOPsValores.Append(psNrSeqNF);
                                    sIncluiCFOPsValores.Append("', ");

                                    sIncluiCFOPsCampos.Append("vl_contabil");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append(item.valor.ToString().Replace(",", "."));
                                    sIncluiCFOPsValores.Append(", ");

                                    sIncluiCFOPsCampos.Append("vl_baseicm");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("0");
                                    sIncluiCFOPsValores.Append(", ");

                                    sIncluiCFOPsCampos.Append("vl_aliicm");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("0");
                                    sIncluiCFOPsValores.Append(", ");

                                    sIncluiCFOPsCampos.Append("vl_icms");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("0");
                                    sIncluiCFOPsValores.Append(", ");

                                    sIncluiCFOPsCampos.Append("vl_outicm");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append(item.valor.ToString().Replace(",", "."));
                                    sIncluiCFOPsValores.Append(", ");

                                    sIncluiCFOPsCampos.Append("vl_isenicm");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("0");
                                    sIncluiCFOPsValores.Append(", ");

                                    sIncluiCFOPsCampos.Append("vl_icmretoup");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append(item.ICMSST.ToString().Replace(",", "."));
                                    sIncluiCFOPsValores.Append(", ");

                                    sIncluiCFOPsCampos.Append("vl_baseicmret");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append(item.VBCICMSST.ToString().Replace(",", "."));
                                    sIncluiCFOPsValores.Append(", ");

                                    sIncluiCFOPsCampos.Append("st_combustivel");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("'");
                                    sIncluiCFOPsValores.Append("N");
                                    sIncluiCFOPsValores.Append("', ");

                                    sIncluiCFOPsCampos.Append("st_canc");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("'");
                                    sIncluiCFOPsValores.Append("N");
                                    sIncluiCFOPsValores.Append("', ");

                                    sIncluiCFOPsCampos.Append("cd_lanimp");
                                    sIncluiCFOPsValores.Append("'");
                                    sIncluiCFOPsValores.Append("000");
                                    sIncluiCFOPsValores.Append("' ");


                                    if (bIndustria)
                                    {
                                        sIncluiCFOPsCampos.Append(", vl_outripi");
                                        sIncluiCFOPsValores.Append(", ");
                                        sIncluiCFOPsValores.Append(item.valor.ToString().Replace(",", "."));
                                    }
                                    break;
                                }
                            #endregion

                            #region 20
                            case "20":
                                {
                                    sIncluiCFOPsCampos.Append("cd_empresa");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("'");
                                    sIncluiCFOPsValores.Append(objInfNFe.Empresa.ToString());
                                    sIncluiCFOPsValores.Append("', ");

                                    sIncluiCFOPsCampos.Append("NR_SEQNFCFOP");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("'");
                                    sIncluiCFOPsValores.Append(sNrSeqNFCFOP);
                                    sIncluiCFOPsValores.Append("', ");

                                    sIncluiCFOPsCampos.Append("cd_cfop");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("'");
                                    sIncluiCFOPsValores.Append(item.CFOP.ToString());
                                    sIncluiCFOPsValores.Append("', ");

                                    sIncluiCFOPsCampos.Append("cd_lancont");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("'");
                                    sIncluiCFOPsValores.Append("000");
                                    sIncluiCFOPsValores.Append("', ");

                                    sIncluiCFOPsCampos.Append("nr_seqnf");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("'");
                                    sIncluiCFOPsValores.Append(psNrSeqNF);
                                    sIncluiCFOPsValores.Append("', ");

                                    sIncluiCFOPsCampos.Append("vl_contabil");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append(item.valor.ToString().Replace(",", "."));
                                    sIncluiCFOPsValores.Append(", ");

                                    sIncluiCFOPsCampos.Append("vl_baseicm");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append(item.BCICMS.ToString().Replace(",", "."));
                                    sIncluiCFOPsValores.Append(", ");

                                    sIncluiCFOPsCampos.Append("vl_aliicm");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append(item.Aliq.ToString().Replace(",", "."));
                                    sIncluiCFOPsValores.Append(", ");

                                    sIncluiCFOPsCampos.Append("vl_icms");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append(item.VICMS.ToString().Replace(",", "."));
                                    sIncluiCFOPsValores.Append(", ");

                                    sIncluiCFOPsCampos.Append("vl_outicm");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("0");
                                    sIncluiCFOPsValores.Append(", ");

                                    sIncluiCFOPsCampos.Append("vl_isenicm");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append((item.valor - item.BCICMS).ToString().Replace(",", "."));
                                    sIncluiCFOPsValores.Append(", ");

                                    sIncluiCFOPsCampos.Append("st_combustivel");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("'");
                                    sIncluiCFOPsValores.Append("N");
                                    sIncluiCFOPsValores.Append("', ");

                                    sIncluiCFOPsCampos.Append("st_canc");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("'");
                                    sIncluiCFOPsValores.Append("N");
                                    sIncluiCFOPsValores.Append("', ");

                                    sIncluiCFOPsCampos.Append("cd_lanimp");
                                    sIncluiCFOPsValores.Append("'");
                                    sIncluiCFOPsValores.Append("000'");


                                    if (bIndustria)
                                    {
                                        sIncluiCFOPsCampos.Append(", vl_outripi");
                                        sIncluiCFOPsValores.Append(", ");
                                        sIncluiCFOPsValores.Append(item.valor.ToString().Replace(",", "."));
                                    }

                                    break;
                                }
                            #endregion

                            #region 30
                            case "30":
                                {
                                    sIncluiCFOPsCampos.Append("cd_empresa");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("'");
                                    sIncluiCFOPsValores.Append(objInfNFe.Empresa.ToString());
                                    sIncluiCFOPsValores.Append("', ");

                                    sIncluiCFOPsCampos.Append("NR_SEQNFCFOP");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("'");
                                    sIncluiCFOPsValores.Append(sNrSeqNFCFOP);
                                    sIncluiCFOPsValores.Append("', ");

                                    sIncluiCFOPsCampos.Append("cd_cfop");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("'");
                                    sIncluiCFOPsValores.Append(item.CFOP.ToString());
                                    sIncluiCFOPsValores.Append("', ");

                                    sIncluiCFOPsCampos.Append("cd_lancont");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("'");
                                    sIncluiCFOPsValores.Append("000");
                                    sIncluiCFOPsValores.Append("', ");

                                    sIncluiCFOPsCampos.Append("nr_seqnf");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("'");
                                    sIncluiCFOPsValores.Append(psNrSeqNF);
                                    sIncluiCFOPsValores.Append("', ");

                                    sIncluiCFOPsCampos.Append("vl_contabil");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append((item.valor).ToString().Replace(",", "."));
                                    sIncluiCFOPsValores.Append(", ");

                                    sIncluiCFOPsCampos.Append("vl_baseicm");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("0");
                                    sIncluiCFOPsValores.Append(", ");

                                    sIncluiCFOPsCampos.Append("vl_aliicm");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("0");
                                    sIncluiCFOPsValores.Append(", ");

                                    sIncluiCFOPsCampos.Append("vl_icms");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("0");
                                    sIncluiCFOPsValores.Append(", ");

                                    sIncluiCFOPsCampos.Append("vl_outicm");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append((item.valor - item.ICMSST).ToString().Replace(",", "."));
                                    sIncluiCFOPsValores.Append(", ");

                                    sIncluiCFOPsCampos.Append("vl_isenicm");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("0");
                                    sIncluiCFOPsValores.Append(", ");

                                    sIncluiCFOPsCampos.Append("st_combustivel");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("'");
                                    sIncluiCFOPsValores.Append("N");
                                    sIncluiCFOPsValores.Append("', ");

                                    sIncluiCFOPsCampos.Append("st_canc");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("'");
                                    sIncluiCFOPsValores.Append("N");
                                    sIncluiCFOPsValores.Append("', ");

                                    sIncluiCFOPsCampos.Append("cd_lanimp");
                                    sIncluiCFOPsValores.Append("'");
                                    sIncluiCFOPsValores.Append("000'");

                                    if (item.ICMSST != 0)
                                    {
                                        sIncluiCFOPsCampos.Append(",ds_obs");
                                        sIncluiCFOPsValores.Append(",'");
                                        sIncluiCFOPsValores.Append("vBCST: " + item.VBCICMSST.ToString().Replace(",", ".") + " - vST:" + item.ICMSST.ToString().Replace(",", ".") + "'");

                                        sIncluiCFOPsCampos.Append(",vl_baseicmret");
                                        sIncluiCFOPsValores.Append(",'");
                                        sIncluiCFOPsValores.Append(item.VBCICMSST.ToString().Replace(",", ".") + "'");

                                        sIncluiCFOPsCampos.Append(",vl_icmretoup");
                                        sIncluiCFOPsValores.Append(",'");
                                        sIncluiCFOPsValores.Append(item.ICMSST.ToString().Replace(",", ".") + "'");
                                    }


                                    if (bIndustria)
                                    {
                                        sIncluiCFOPsCampos.Append(", vl_outripi");
                                        sIncluiCFOPsValores.Append(", ");
                                        sIncluiCFOPsValores.Append(item.valor.ToString().Replace(",", "."));
                                    }
                                    break;
                                }
                            #endregion

                            #region 40
                            case "40":
                                {
                                    sIncluiCFOPsCampos.Append("cd_empresa");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("'");
                                    sIncluiCFOPsValores.Append(objInfNFe.Empresa.ToString());
                                    sIncluiCFOPsValores.Append("', ");

                                    sIncluiCFOPsCampos.Append("NR_SEQNFCFOP");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("'");
                                    sIncluiCFOPsValores.Append(sNrSeqNFCFOP);
                                    sIncluiCFOPsValores.Append("', ");

                                    sIncluiCFOPsCampos.Append("cd_cfop");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("'");
                                    sIncluiCFOPsValores.Append(item.CFOP.ToString());
                                    sIncluiCFOPsValores.Append("', ");

                                    sIncluiCFOPsCampos.Append("cd_lancont");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("'");
                                    sIncluiCFOPsValores.Append("000");
                                    sIncluiCFOPsValores.Append("', ");

                                    sIncluiCFOPsCampos.Append("nr_seqnf");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("'");
                                    sIncluiCFOPsValores.Append(psNrSeqNF);
                                    sIncluiCFOPsValores.Append("', ");

                                    sIncluiCFOPsCampos.Append("vl_contabil");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append(item.valor.ToString().Replace(",", "."));
                                    sIncluiCFOPsValores.Append(", ");

                                    sIncluiCFOPsCampos.Append("vl_baseicm");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("0");
                                    sIncluiCFOPsValores.Append(", ");

                                    sIncluiCFOPsCampos.Append("vl_aliicm");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("0");
                                    sIncluiCFOPsValores.Append(", ");

                                    sIncluiCFOPsCampos.Append("vl_icms");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("0");
                                    sIncluiCFOPsValores.Append(", ");

                                    sIncluiCFOPsCampos.Append("vl_outicm");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("0");
                                    sIncluiCFOPsValores.Append(", ");

                                    sIncluiCFOPsCampos.Append("vl_isenicm");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append(item.valor.ToString().Replace(",", "."));
                                    sIncluiCFOPsValores.Append(", ");

                                    sIncluiCFOPsCampos.Append("st_combustivel");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("'");
                                    sIncluiCFOPsValores.Append("N");
                                    sIncluiCFOPsValores.Append("', ");

                                    sIncluiCFOPsCampos.Append("st_canc");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("'");
                                    sIncluiCFOPsValores.Append("N");
                                    sIncluiCFOPsValores.Append("', ");

                                    sIncluiCFOPsCampos.Append("cd_lanimp");
                                    sIncluiCFOPsValores.Append("'");
                                    sIncluiCFOPsValores.Append("000'");


                                    if (bIndustria)
                                    {
                                        sIncluiCFOPsCampos.Append(", vl_outripi");
                                        sIncluiCFOPsValores.Append(", ");
                                        sIncluiCFOPsValores.Append(item.valor.ToString().Replace(",", "."));
                                    }

                                    break;
                                }
                            #endregion

                            #region 41
                            case "41":
                                {
                                    sIncluiCFOPsCampos.Append("cd_empresa");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("'");
                                    sIncluiCFOPsValores.Append(objInfNFe.Empresa.ToString());
                                    sIncluiCFOPsValores.Append("', ");

                                    sIncluiCFOPsCampos.Append("NR_SEQNFCFOP");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("'");
                                    sIncluiCFOPsValores.Append(sNrSeqNFCFOP);
                                    sIncluiCFOPsValores.Append("', ");

                                    sIncluiCFOPsCampos.Append("cd_cfop");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("'");
                                    sIncluiCFOPsValores.Append(item.CFOP.ToString());
                                    sIncluiCFOPsValores.Append("', ");

                                    sIncluiCFOPsCampos.Append("cd_lancont");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("'");
                                    sIncluiCFOPsValores.Append("000");
                                    sIncluiCFOPsValores.Append("', ");

                                    sIncluiCFOPsCampos.Append("nr_seqnf");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("'");
                                    sIncluiCFOPsValores.Append(psNrSeqNF);
                                    sIncluiCFOPsValores.Append("', ");

                                    sIncluiCFOPsCampos.Append("vl_contabil");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append(item.valor.ToString().Replace(",", "."));
                                    sIncluiCFOPsValores.Append(", ");

                                    sIncluiCFOPsCampos.Append("vl_baseicm");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("0");
                                    sIncluiCFOPsValores.Append(", ");

                                    sIncluiCFOPsCampos.Append("vl_aliicm");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("0");
                                    sIncluiCFOPsValores.Append(", ");

                                    sIncluiCFOPsCampos.Append("vl_icms");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("0");
                                    sIncluiCFOPsValores.Append(", ");

                                    sIncluiCFOPsCampos.Append("vl_outicm");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append(item.valor.ToString().Replace(",", "."));
                                    sIncluiCFOPsValores.Append(", ");

                                    sIncluiCFOPsCampos.Append("vl_isenicm");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("0");
                                    sIncluiCFOPsValores.Append(", ");

                                    sIncluiCFOPsCampos.Append("st_combustivel");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("'");
                                    sIncluiCFOPsValores.Append("N");
                                    sIncluiCFOPsValores.Append("', ");

                                    sIncluiCFOPsCampos.Append("st_canc");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("'");
                                    sIncluiCFOPsValores.Append("N");
                                    sIncluiCFOPsValores.Append("', ");

                                    sIncluiCFOPsCampos.Append("cd_lanimp");
                                    sIncluiCFOPsValores.Append("'");
                                    sIncluiCFOPsValores.Append("000'");


                                    if (bIndustria)
                                    {
                                        sIncluiCFOPsCampos.Append(", vl_outripi");
                                        sIncluiCFOPsValores.Append(", ");
                                        sIncluiCFOPsValores.Append(item.valor.ToString().Replace(",", "."));
                                    }


                                    break;
                                }
                            #endregion

                            #region 50
                            case "50":
                                {
                                    sIncluiCFOPsCampos.Append("cd_empresa");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("'");
                                    sIncluiCFOPsValores.Append(objInfNFe.Empresa.ToString());
                                    sIncluiCFOPsValores.Append("', ");

                                    sIncluiCFOPsCampos.Append("NR_SEQNFCFOP");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("'");
                                    sIncluiCFOPsValores.Append(sNrSeqNFCFOP);
                                    sIncluiCFOPsValores.Append("', ");

                                    sIncluiCFOPsCampos.Append("cd_cfop");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("'");
                                    sIncluiCFOPsValores.Append(item.CFOP.ToString());
                                    sIncluiCFOPsValores.Append("', ");

                                    sIncluiCFOPsCampos.Append("cd_lancont");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("'");
                                    sIncluiCFOPsValores.Append("000");
                                    sIncluiCFOPsValores.Append("', ");

                                    sIncluiCFOPsCampos.Append("nr_seqnf");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("'");
                                    sIncluiCFOPsValores.Append(psNrSeqNF);
                                    sIncluiCFOPsValores.Append("', ");

                                    sIncluiCFOPsCampos.Append("vl_contabil");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append(item.valor.ToString().Replace(",", "."));
                                    sIncluiCFOPsValores.Append(", ");

                                    sIncluiCFOPsCampos.Append("vl_baseicm");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("0");
                                    sIncluiCFOPsValores.Append(", ");

                                    sIncluiCFOPsCampos.Append("vl_aliicm");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("0");
                                    sIncluiCFOPsValores.Append(", ");

                                    sIncluiCFOPsCampos.Append("vl_icms");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("0");
                                    sIncluiCFOPsValores.Append(", ");

                                    sIncluiCFOPsCampos.Append("vl_outicm");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append(item.valor.ToString().Replace(",", "."));
                                    sIncluiCFOPsValores.Append(", ");

                                    sIncluiCFOPsCampos.Append("vl_isenicm");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("0");
                                    sIncluiCFOPsValores.Append(", ");

                                    sIncluiCFOPsCampos.Append("st_combustivel");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("'");
                                    sIncluiCFOPsValores.Append("N");
                                    sIncluiCFOPsValores.Append("', ");

                                    sIncluiCFOPsCampos.Append("st_canc");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("'");
                                    sIncluiCFOPsValores.Append("N");
                                    sIncluiCFOPsValores.Append("', ");

                                    sIncluiCFOPsCampos.Append("cd_lanimp");
                                    sIncluiCFOPsValores.Append("'");
                                    sIncluiCFOPsValores.Append("000'");


                                    if (bIndustria)
                                    {
                                        sIncluiCFOPsCampos.Append(", vl_outripi");
                                        sIncluiCFOPsValores.Append(", ");
                                        sIncluiCFOPsValores.Append(item.valor.ToString().Replace(",", "."));
                                    }


                                    break;
                                }
                            #endregion

                            #region 51
                            case "51":
                                {
                                    sIncluiCFOPsCampos.Append("cd_empresa");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("'");
                                    sIncluiCFOPsValores.Append(objInfNFe.Empresa.ToString());
                                    sIncluiCFOPsValores.Append("', ");

                                    sIncluiCFOPsCampos.Append("NR_SEQNFCFOP");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("'");
                                    sIncluiCFOPsValores.Append(sNrSeqNFCFOP);
                                    sIncluiCFOPsValores.Append("', ");

                                    sIncluiCFOPsCampos.Append("cd_cfop");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("'");
                                    sIncluiCFOPsValores.Append(item.CFOP.ToString());
                                    sIncluiCFOPsValores.Append("', ");

                                    sIncluiCFOPsCampos.Append("cd_lancont");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("'");
                                    sIncluiCFOPsValores.Append("000");
                                    sIncluiCFOPsValores.Append("', ");

                                    sIncluiCFOPsCampos.Append("nr_seqnf");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("'");
                                    sIncluiCFOPsValores.Append(psNrSeqNF);
                                    sIncluiCFOPsValores.Append("', ");

                                    sIncluiCFOPsCampos.Append("vl_contabil");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append(item.valor.ToString().Replace(",", "."));
                                    sIncluiCFOPsValores.Append(", ");

                                    sIncluiCFOPsCampos.Append("vl_baseicm");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("0");
                                    sIncluiCFOPsValores.Append(", ");

                                    sIncluiCFOPsCampos.Append("vl_aliicm");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("0");
                                    sIncluiCFOPsValores.Append(", ");

                                    sIncluiCFOPsCampos.Append("vl_icms");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("0");
                                    sIncluiCFOPsValores.Append(", ");

                                    sIncluiCFOPsCampos.Append("vl_outicm");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append(item.valor.ToString().Replace(",", "."));
                                    sIncluiCFOPsValores.Append(", ");

                                    sIncluiCFOPsCampos.Append("vl_isenicm");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("0");
                                    sIncluiCFOPsValores.Append(", ");

                                    sIncluiCFOPsCampos.Append("st_combustivel");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("'");
                                    sIncluiCFOPsValores.Append("N");
                                    sIncluiCFOPsValores.Append("', ");

                                    sIncluiCFOPsCampos.Append("st_canc");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("'");
                                    sIncluiCFOPsValores.Append("N");
                                    sIncluiCFOPsValores.Append("', ");

                                    sIncluiCFOPsCampos.Append("cd_lanimp");
                                    sIncluiCFOPsValores.Append("'");
                                    sIncluiCFOPsValores.Append("000'");


                                    if (bIndustria)
                                    {
                                        sIncluiCFOPsCampos.Append(", vl_outripi");
                                        sIncluiCFOPsValores.Append(", ");
                                        sIncluiCFOPsValores.Append(item.valor.ToString().Replace(",", "."));
                                    }

                                    break;
                                }
                            #endregion

                            #region 60
                            case "60":
                                {
                                    sIncluiCFOPsCampos.Append("cd_empresa");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("'");
                                    sIncluiCFOPsValores.Append(objInfNFe.Empresa.ToString());
                                    sIncluiCFOPsValores.Append("', ");

                                    sIncluiCFOPsCampos.Append("NR_SEQNFCFOP");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("'");
                                    sIncluiCFOPsValores.Append(sNrSeqNFCFOP);
                                    sIncluiCFOPsValores.Append("', ");

                                    sIncluiCFOPsCampos.Append("cd_cfop");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("'");
                                    sIncluiCFOPsValores.Append(item.CFOP.ToString());
                                    sIncluiCFOPsValores.Append("', ");

                                    sIncluiCFOPsCampos.Append("cd_lancont");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("'");
                                    sIncluiCFOPsValores.Append("000");
                                    sIncluiCFOPsValores.Append("', ");

                                    sIncluiCFOPsCampos.Append("nr_seqnf");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("'");
                                    sIncluiCFOPsValores.Append(psNrSeqNF);
                                    sIncluiCFOPsValores.Append("', ");

                                    sIncluiCFOPsCampos.Append("vl_contabil");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append(item.valor.ToString().Replace(",", "."));
                                    sIncluiCFOPsValores.Append(", ");

                                    sIncluiCFOPsCampos.Append("vl_baseicm");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("0");
                                    sIncluiCFOPsValores.Append(", ");

                                    sIncluiCFOPsCampos.Append("vl_aliicm");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("0");
                                    sIncluiCFOPsValores.Append(", ");

                                    sIncluiCFOPsCampos.Append("vl_icms");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("0");
                                    sIncluiCFOPsValores.Append(", ");

                                    sIncluiCFOPsCampos.Append("vl_outicm");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append(item.valor.ToString().Replace(",", "."));
                                    sIncluiCFOPsValores.Append(", ");

                                    sIncluiCFOPsCampos.Append("vl_isenicm");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("0");
                                    sIncluiCFOPsValores.Append(", ");

                                    sIncluiCFOPsCampos.Append("vl_icmretoup");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append(item.ICMSST.ToString().Replace(",", "."));
                                    sIncluiCFOPsValores.Append(", ");

                                    sIncluiCFOPsCampos.Append("vl_baseicmret");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append(item.VBCICMSST.ToString().Replace(",", "."));
                                    sIncluiCFOPsValores.Append(", ");

                                    sIncluiCFOPsCampos.Append("st_combustivel");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("'");
                                    sIncluiCFOPsValores.Append("N");
                                    sIncluiCFOPsValores.Append("', ");

                                    sIncluiCFOPsCampos.Append("st_canc");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("'");
                                    sIncluiCFOPsValores.Append("N");
                                    sIncluiCFOPsValores.Append("', ");

                                    sIncluiCFOPsCampos.Append("cd_lanimp");
                                    sIncluiCFOPsValores.Append("'");
                                    sIncluiCFOPsValores.Append("000");
                                    sIncluiCFOPsValores.Append("' ");

                                    if (bIndustria)
                                    {
                                        sIncluiCFOPsCampos.Append(", vl_outripi");
                                        sIncluiCFOPsValores.Append(", ");
                                        sIncluiCFOPsValores.Append(item.valor.ToString().Replace(",", "."));
                                    }

                                    break;
                                }
                            #endregion

                            #region 70 Diego OS_24597
                            case "70":
                                {
                                    sIncluiCFOPsCampos.Append("cd_empresa");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("'");
                                    sIncluiCFOPsValores.Append(objInfNFe.Empresa.ToString());
                                    sIncluiCFOPsValores.Append("', ");

                                    sIncluiCFOPsCampos.Append("NR_SEQNFCFOP");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("'");
                                    sIncluiCFOPsValores.Append(sNrSeqNFCFOP);
                                    sIncluiCFOPsValores.Append("', ");

                                    sIncluiCFOPsCampos.Append("cd_cfop");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("'");
                                    sIncluiCFOPsValores.Append(item.CFOP.ToString());
                                    sIncluiCFOPsValores.Append("', ");

                                    sIncluiCFOPsCampos.Append("cd_lancont");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("'");
                                    sIncluiCFOPsValores.Append("000");
                                    sIncluiCFOPsValores.Append("', ");

                                    sIncluiCFOPsCampos.Append("nr_seqnf");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("'");
                                    sIncluiCFOPsValores.Append(psNrSeqNF);
                                    sIncluiCFOPsValores.Append("', ");

                                    sIncluiCFOPsCampos.Append("vl_contabil");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append(item.valor.ToString().Replace(",", "."));
                                    sIncluiCFOPsValores.Append(", ");

                                    sIncluiCFOPsCampos.Append("vl_baseicm");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("0");
                                    sIncluiCFOPsValores.Append(", ");

                                    sIncluiCFOPsCampos.Append("vl_aliicm");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("0");
                                    sIncluiCFOPsValores.Append(", ");

                                    sIncluiCFOPsCampos.Append("vl_icms");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("0");
                                    sIncluiCFOPsValores.Append(", ");

                                    sIncluiCFOPsCampos.Append("vl_outicm");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("0");
                                    sIncluiCFOPsValores.Append(", ");

                                    sIncluiCFOPsCampos.Append("vl_isenicm");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append(item.valor.ToString().Replace(",", "."));
                                    sIncluiCFOPsValores.Append(", ");

                                    sIncluiCFOPsCampos.Append("st_combustivel");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("'");
                                    sIncluiCFOPsValores.Append("N");
                                    sIncluiCFOPsValores.Append("', ");

                                    sIncluiCFOPsCampos.Append("st_canc");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("'");
                                    sIncluiCFOPsValores.Append("N");
                                    sIncluiCFOPsValores.Append("', ");

                                    sIncluiCFOPsCampos.Append("cd_lanimp");
                                    sIncluiCFOPsValores.Append("'");
                                    sIncluiCFOPsValores.Append("000'");


                                    if (bIndustria)
                                    {
                                        sIncluiCFOPsCampos.Append(", vl_outripi");
                                        sIncluiCFOPsValores.Append(", ");
                                        sIncluiCFOPsValores.Append(item.valor.ToString().Replace(",", "."));
                                    }
                                }
                                break;

                            #endregion

                            #region 90
                            case "90":
                                {
                                    sIncluiCFOPsCampos.Append("cd_empresa");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("'");
                                    sIncluiCFOPsValores.Append(objInfNFe.Empresa.ToString());
                                    sIncluiCFOPsValores.Append("', ");

                                    sIncluiCFOPsCampos.Append("NR_SEQNFCFOP");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("'");
                                    sIncluiCFOPsValores.Append(sNrSeqNFCFOP);
                                    sIncluiCFOPsValores.Append("', ");

                                    sIncluiCFOPsCampos.Append("cd_cfop");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("'");
                                    sIncluiCFOPsValores.Append(item.CFOP.ToString());
                                    sIncluiCFOPsValores.Append("', ");

                                    sIncluiCFOPsCampos.Append("cd_lancont");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("'");
                                    sIncluiCFOPsValores.Append("000");
                                    sIncluiCFOPsValores.Append("', ");

                                    sIncluiCFOPsCampos.Append("nr_seqnf");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("'");
                                    sIncluiCFOPsValores.Append(psNrSeqNF);
                                    sIncluiCFOPsValores.Append("', ");

                                    sIncluiCFOPsCampos.Append("vl_contabil");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append(item.valor.ToString().Replace(",", "."));
                                    sIncluiCFOPsValores.Append(", ");

                                    sIncluiCFOPsCampos.Append("vl_baseicm");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("0");
                                    sIncluiCFOPsValores.Append(", ");

                                    sIncluiCFOPsCampos.Append("vl_aliicm");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("0");
                                    sIncluiCFOPsValores.Append(", ");

                                    sIncluiCFOPsCampos.Append("vl_icms");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("0");
                                    sIncluiCFOPsValores.Append(", ");

                                    sIncluiCFOPsCampos.Append("vl_outicm");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append(item.valor.ToString().Replace(",", "."));
                                    sIncluiCFOPsValores.Append(", ");

                                    sIncluiCFOPsCampos.Append("vl_isenicm");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("0");
                                    sIncluiCFOPsValores.Append(", ");

                                    sIncluiCFOPsCampos.Append("st_combustivel");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("'");
                                    sIncluiCFOPsValores.Append("N");
                                    sIncluiCFOPsValores.Append("', ");

                                    sIncluiCFOPsCampos.Append("st_canc");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("'");
                                    sIncluiCFOPsValores.Append("N");
                                    sIncluiCFOPsValores.Append("', ");

                                    sIncluiCFOPsCampos.Append("cd_lanimp");
                                    sIncluiCFOPsValores.Append("'");
                                    sIncluiCFOPsValores.Append("000'");


                                    if (bIndustria)
                                    {
                                        sIncluiCFOPsCampos.Append(", vl_outripi");
                                        sIncluiCFOPsValores.Append(", ");
                                        sIncluiCFOPsValores.Append(item.valor.ToString().Replace(",", "."));
                                    }

                                    break;
                                }
                            #endregion

                            #region 101
                            case "101":
                                {
                                    sIncluiCFOPsCampos.Append("cd_empresa");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("'");
                                    sIncluiCFOPsValores.Append(objInfNFe.Empresa.ToString());
                                    sIncluiCFOPsValores.Append("', ");

                                    sIncluiCFOPsCampos.Append("NR_SEQNFCFOP");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("'");
                                    sIncluiCFOPsValores.Append(sNrSeqNFCFOP);
                                    sIncluiCFOPsValores.Append("', ");

                                    sIncluiCFOPsCampos.Append("cd_cfop");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("'");
                                    sIncluiCFOPsValores.Append(item.CFOP.ToString());
                                    sIncluiCFOPsValores.Append("', ");

                                    sIncluiCFOPsCampos.Append("cd_lancont");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("'");
                                    sIncluiCFOPsValores.Append("000");
                                    sIncluiCFOPsValores.Append("', ");

                                    sIncluiCFOPsCampos.Append("nr_seqnf");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("'");
                                    sIncluiCFOPsValores.Append(psNrSeqNF);
                                    sIncluiCFOPsValores.Append("', ");

                                    sIncluiCFOPsCampos.Append("vl_contabil");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append(item.valor.ToString().Replace(",", "."));
                                    sIncluiCFOPsValores.Append(", ");

                                    sIncluiCFOPsCampos.Append("vl_baseicm");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append(item.BCICMS.ToString().Replace(",", "."));
                                    sIncluiCFOPsValores.Append(", ");

                                    sIncluiCFOPsCampos.Append("vl_aliicm");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append(item.Aliq.ToString().Replace(",", "."));
                                    sIncluiCFOPsValores.Append(", ");

                                    sIncluiCFOPsCampos.Append("vl_icms");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append(item.VICMS.ToString().Replace(",", "."));
                                    sIncluiCFOPsValores.Append(", ");

                                    sIncluiCFOPsCampos.Append("vl_outicm");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append(item.valor.ToString().Replace(",", "."));
                                    sIncluiCFOPsValores.Append(", ");

                                    sIncluiCFOPsCampos.Append("vl_isenicm");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("0");
                                    sIncluiCFOPsValores.Append(", ");

                                    sIncluiCFOPsCampos.Append("st_combustivel");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("'");
                                    sIncluiCFOPsValores.Append("N");
                                    sIncluiCFOPsValores.Append("', ");

                                    sIncluiCFOPsCampos.Append("st_canc");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("'");
                                    sIncluiCFOPsValores.Append("N");
                                    sIncluiCFOPsValores.Append("', ");

                                    sIncluiCFOPsCampos.Append("cd_lanimp");
                                    sIncluiCFOPsValores.Append("'");
                                    sIncluiCFOPsValores.Append("000'");


                                    if (bIndustria)
                                    {
                                        sIncluiCFOPsCampos.Append(", vl_outripi");
                                        sIncluiCFOPsValores.Append(", ");
                                        sIncluiCFOPsValores.Append(item.valor.ToString().Replace(",", "."));
                                    }
                                    break;
                                }
                            #endregion

                            #region 102_103_300_400
                            #region 102
                            case "102":
                                {
                                    {
                                        sIncluiCFOPsCampos.Append("cd_empresa");
                                        sIncluiCFOPsCampos.Append(", ");
                                        sIncluiCFOPsValores.Append("'");
                                        sIncluiCFOPsValores.Append(objInfNFe.Empresa.ToString());
                                        sIncluiCFOPsValores.Append("', ");

                                        sIncluiCFOPsCampos.Append("NR_SEQNFCFOP");
                                        sIncluiCFOPsCampos.Append(", ");
                                        sIncluiCFOPsValores.Append("'");
                                        sIncluiCFOPsValores.Append(sNrSeqNFCFOP);
                                        sIncluiCFOPsValores.Append("', ");

                                        sIncluiCFOPsCampos.Append("cd_cfop");
                                        sIncluiCFOPsCampos.Append(", ");
                                        sIncluiCFOPsValores.Append("'");
                                        sIncluiCFOPsValores.Append(item.CFOP.ToString());
                                        sIncluiCFOPsValores.Append("', ");

                                        sIncluiCFOPsCampos.Append("cd_lancont");
                                        sIncluiCFOPsCampos.Append(", ");
                                        sIncluiCFOPsValores.Append("'");
                                        sIncluiCFOPsValores.Append("000");
                                        sIncluiCFOPsValores.Append("', ");

                                        sIncluiCFOPsCampos.Append("nr_seqnf");
                                        sIncluiCFOPsCampos.Append(", ");
                                        sIncluiCFOPsValores.Append("'");
                                        sIncluiCFOPsValores.Append(psNrSeqNF);
                                        sIncluiCFOPsValores.Append("', ");

                                        sIncluiCFOPsCampos.Append("vl_contabil");
                                        sIncluiCFOPsCampos.Append(", ");
                                        sIncluiCFOPsValores.Append(item.valor.ToString().Replace(",", "."));
                                        sIncluiCFOPsValores.Append(", ");

                                        sIncluiCFOPsCampos.Append("vl_baseicm");
                                        sIncluiCFOPsCampos.Append(", ");
                                        sIncluiCFOPsValores.Append("0");
                                        sIncluiCFOPsValores.Append(", ");

                                        sIncluiCFOPsCampos.Append("vl_aliicm");
                                        sIncluiCFOPsCampos.Append(", ");
                                        sIncluiCFOPsValores.Append("0");
                                        sIncluiCFOPsValores.Append(", ");

                                        sIncluiCFOPsCampos.Append("vl_icms");
                                        sIncluiCFOPsCampos.Append(", ");
                                        sIncluiCFOPsValores.Append("0");
                                        sIncluiCFOPsValores.Append(", ");

                                        sIncluiCFOPsCampos.Append("vl_outicm");
                                        sIncluiCFOPsCampos.Append(", ");
                                        sIncluiCFOPsValores.Append(item.valor.ToString().Replace(",", "."));
                                        sIncluiCFOPsValores.Append(", ");

                                        sIncluiCFOPsCampos.Append("vl_isenicm");
                                        sIncluiCFOPsCampos.Append(", ");
                                        sIncluiCFOPsValores.Append("0");
                                        sIncluiCFOPsValores.Append(", ");

                                        sIncluiCFOPsCampos.Append("st_combustivel");
                                        sIncluiCFOPsCampos.Append(", ");
                                        sIncluiCFOPsValores.Append("'");
                                        sIncluiCFOPsValores.Append("N");
                                        sIncluiCFOPsValores.Append("', ");

                                        sIncluiCFOPsCampos.Append("st_canc");
                                        sIncluiCFOPsCampos.Append(", ");
                                        sIncluiCFOPsValores.Append("'");
                                        sIncluiCFOPsValores.Append("N");
                                        sIncluiCFOPsValores.Append("', ");

                                        sIncluiCFOPsCampos.Append("cd_lanimp");
                                        sIncluiCFOPsValores.Append("'");
                                        sIncluiCFOPsValores.Append("000'");


                                        if (bIndustria)
                                        {
                                            sIncluiCFOPsCampos.Append(", vl_outripi");
                                            sIncluiCFOPsValores.Append(", ");
                                            sIncluiCFOPsValores.Append(item.valor.ToString().Replace(",", "."));
                                        }
                                        break;
                                    }
                                }
                            #endregion
                            #region 103
                            case "103":
                                {
                                    sIncluiCFOPsCampos.Append("cd_empresa");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("'");
                                    sIncluiCFOPsValores.Append(objInfNFe.Empresa.ToString());
                                    sIncluiCFOPsValores.Append("', ");

                                    sIncluiCFOPsCampos.Append("NR_SEQNFCFOP");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("'");
                                    sIncluiCFOPsValores.Append(sNrSeqNFCFOP);
                                    sIncluiCFOPsValores.Append("', ");

                                    sIncluiCFOPsCampos.Append("cd_cfop");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("'");
                                    sIncluiCFOPsValores.Append(item.CFOP.ToString());
                                    sIncluiCFOPsValores.Append("', ");

                                    sIncluiCFOPsCampos.Append("cd_lancont");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("'");
                                    sIncluiCFOPsValores.Append("000");
                                    sIncluiCFOPsValores.Append("', ");

                                    sIncluiCFOPsCampos.Append("nr_seqnf");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("'");
                                    sIncluiCFOPsValores.Append(psNrSeqNF);
                                    sIncluiCFOPsValores.Append("', ");

                                    sIncluiCFOPsCampos.Append("vl_contabil");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append(item.valor.ToString().Replace(",", "."));
                                    sIncluiCFOPsValores.Append(", ");

                                    sIncluiCFOPsCampos.Append("vl_baseicm");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("0");
                                    sIncluiCFOPsValores.Append(", ");

                                    sIncluiCFOPsCampos.Append("vl_aliicm");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("0");
                                    sIncluiCFOPsValores.Append(", ");

                                    sIncluiCFOPsCampos.Append("vl_icms");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("0");
                                    sIncluiCFOPsValores.Append(", ");

                                    sIncluiCFOPsCampos.Append("vl_outicm");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("0");
                                    sIncluiCFOPsValores.Append(", ");

                                    sIncluiCFOPsCampos.Append("vl_isenicm");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append(item.valor.ToString().Replace(",", "."));
                                    sIncluiCFOPsValores.Append(", ");

                                    sIncluiCFOPsCampos.Append("st_combustivel");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("'");
                                    sIncluiCFOPsValores.Append("N");
                                    sIncluiCFOPsValores.Append("', ");

                                    sIncluiCFOPsCampos.Append("st_canc");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("'");
                                    sIncluiCFOPsValores.Append("N");
                                    sIncluiCFOPsValores.Append("', ");

                                    sIncluiCFOPsCampos.Append("cd_lanimp");
                                    sIncluiCFOPsValores.Append("'");
                                    sIncluiCFOPsValores.Append("000'");


                                    if (bIndustria)
                                    {
                                        sIncluiCFOPsCampos.Append(", vl_outripi");
                                        sIncluiCFOPsValores.Append(", ");
                                        sIncluiCFOPsValores.Append(item.valor.ToString().Replace(",", "."));
                                    }
                                    break;
                                }
                            #endregion
                            #region 300
                            case "300":
                                {
                                    sIncluiCFOPsCampos.Append("cd_empresa");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("'");
                                    sIncluiCFOPsValores.Append(objInfNFe.Empresa.ToString());
                                    sIncluiCFOPsValores.Append("', ");

                                    sIncluiCFOPsCampos.Append("NR_SEQNFCFOP");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("'");
                                    sIncluiCFOPsValores.Append(sNrSeqNFCFOP);
                                    sIncluiCFOPsValores.Append("', ");

                                    sIncluiCFOPsCampos.Append("cd_cfop");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("'");
                                    sIncluiCFOPsValores.Append(item.CFOP.ToString());
                                    sIncluiCFOPsValores.Append("', ");

                                    sIncluiCFOPsCampos.Append("cd_lancont");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("'");
                                    sIncluiCFOPsValores.Append("000");
                                    sIncluiCFOPsValores.Append("', ");

                                    sIncluiCFOPsCampos.Append("nr_seqnf");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("'");
                                    sIncluiCFOPsValores.Append(psNrSeqNF);
                                    sIncluiCFOPsValores.Append("', ");

                                    sIncluiCFOPsCampos.Append("vl_contabil");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append(item.valor.ToString().Replace(",", "."));
                                    sIncluiCFOPsValores.Append(", ");

                                    sIncluiCFOPsCampos.Append("vl_baseicm");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("0");
                                    sIncluiCFOPsValores.Append(", ");

                                    sIncluiCFOPsCampos.Append("vl_aliicm");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("0");
                                    sIncluiCFOPsValores.Append(", ");

                                    sIncluiCFOPsCampos.Append("vl_icms");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("0");
                                    sIncluiCFOPsValores.Append(", ");

                                    sIncluiCFOPsCampos.Append("vl_outicm");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append(item.valor.ToString().Replace(",", "."));
                                    sIncluiCFOPsValores.Append(", ");

                                    sIncluiCFOPsCampos.Append("vl_isenicm");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("0");
                                    sIncluiCFOPsValores.Append(", ");

                                    sIncluiCFOPsCampos.Append("st_combustivel");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("'");
                                    sIncluiCFOPsValores.Append("N");
                                    sIncluiCFOPsValores.Append("', ");

                                    sIncluiCFOPsCampos.Append("st_canc");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("'");
                                    sIncluiCFOPsValores.Append("N");
                                    sIncluiCFOPsValores.Append("', ");

                                    sIncluiCFOPsCampos.Append("cd_lanimp");
                                    sIncluiCFOPsValores.Append("'");
                                    sIncluiCFOPsValores.Append("000'");


                                    if (bIndustria)
                                    {
                                        sIncluiCFOPsCampos.Append(", vl_outripi");
                                        sIncluiCFOPsValores.Append(", ");
                                        sIncluiCFOPsValores.Append(item.valor.ToString().Replace(",", "."));
                                    }

                                    break;
                                }
                            #endregion
                            #region 400
                            case "400":
                                {
                                    sIncluiCFOPsCampos.Append("cd_empresa");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("'");
                                    sIncluiCFOPsValores.Append(objInfNFe.Empresa.ToString());
                                    sIncluiCFOPsValores.Append("', ");

                                    sIncluiCFOPsCampos.Append("NR_SEQNFCFOP");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("'");
                                    sIncluiCFOPsValores.Append(sNrSeqNFCFOP);
                                    sIncluiCFOPsValores.Append("', ");

                                    sIncluiCFOPsCampos.Append("cd_cfop");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("'");
                                    sIncluiCFOPsValores.Append(item.CFOP.ToString());
                                    sIncluiCFOPsValores.Append("', ");

                                    sIncluiCFOPsCampos.Append("cd_lancont");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("'");
                                    sIncluiCFOPsValores.Append("000");
                                    sIncluiCFOPsValores.Append("', ");

                                    sIncluiCFOPsCampos.Append("nr_seqnf");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("'");
                                    sIncluiCFOPsValores.Append(psNrSeqNF);
                                    sIncluiCFOPsValores.Append("', ");

                                    sIncluiCFOPsCampos.Append("vl_contabil");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append(item.valor.ToString().Replace(",", "."));
                                    sIncluiCFOPsValores.Append(", ");

                                    sIncluiCFOPsCampos.Append("vl_baseicm");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("0");
                                    sIncluiCFOPsValores.Append(", ");

                                    sIncluiCFOPsCampos.Append("vl_aliicm");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("0");
                                    sIncluiCFOPsValores.Append(", ");

                                    sIncluiCFOPsCampos.Append("vl_icms");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("0");
                                    sIncluiCFOPsValores.Append(", ");

                                    sIncluiCFOPsCampos.Append("vl_outicm");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append(item.valor.ToString().Replace(",", "."));
                                    sIncluiCFOPsValores.Append(", ");

                                    sIncluiCFOPsCampos.Append("vl_isenicm");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("0");
                                    sIncluiCFOPsValores.Append(", ");

                                    sIncluiCFOPsCampos.Append("st_combustivel");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("'");
                                    sIncluiCFOPsValores.Append("N");
                                    sIncluiCFOPsValores.Append("', ");

                                    sIncluiCFOPsCampos.Append("st_canc");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("'");
                                    sIncluiCFOPsValores.Append("N");
                                    sIncluiCFOPsValores.Append("', ");

                                    sIncluiCFOPsCampos.Append("cd_lanimp");
                                    sIncluiCFOPsValores.Append("'");
                                    sIncluiCFOPsValores.Append("000'");


                                    if (bIndustria)
                                    {
                                        sIncluiCFOPsCampos.Append(", vl_outripi");
                                        sIncluiCFOPsValores.Append(", ");
                                        sIncluiCFOPsValores.Append(item.valor.ToString().Replace(",", "."));
                                    }

                                    break;
                                }
                            #endregion
                            #endregion

                            #region 201
                            case "201":
                                {
                                    sIncluiCFOPsCampos.Append("cd_empresa");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("'");
                                    sIncluiCFOPsValores.Append(objInfNFe.Empresa.ToString());
                                    sIncluiCFOPsValores.Append("', ");

                                    sIncluiCFOPsCampos.Append("NR_SEQNFCFOP");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("'");
                                    sIncluiCFOPsValores.Append(sNrSeqNFCFOP);
                                    sIncluiCFOPsValores.Append("', ");

                                    sIncluiCFOPsCampos.Append("cd_cfop");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("'");
                                    sIncluiCFOPsValores.Append(item.CFOP.ToString());
                                    sIncluiCFOPsValores.Append("', ");

                                    sIncluiCFOPsCampos.Append("cd_lancont");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("'");
                                    sIncluiCFOPsValores.Append("000");
                                    sIncluiCFOPsValores.Append("', ");

                                    sIncluiCFOPsCampos.Append("nr_seqnf");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("'");
                                    sIncluiCFOPsValores.Append(psNrSeqNF);
                                    sIncluiCFOPsValores.Append("', ");

                                    sIncluiCFOPsCampos.Append("vl_contabil");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append((item.valor).ToString().Replace(",", "."));
                                    sIncluiCFOPsValores.Append(", ");

                                    sIncluiCFOPsCampos.Append("vl_baseicm");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("0");
                                    sIncluiCFOPsValores.Append(", ");

                                    sIncluiCFOPsCampos.Append("vl_aliicm");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("0");
                                    sIncluiCFOPsValores.Append(", ");

                                    sIncluiCFOPsCampos.Append("vl_icms");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("0");
                                    sIncluiCFOPsValores.Append(", ");

                                    sIncluiCFOPsCampos.Append("vl_outicm");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append((item.valor - item.ICMSST).ToString().Replace(",", "."));
                                    sIncluiCFOPsValores.Append(", ");

                                    sIncluiCFOPsCampos.Append("vl_isenicm");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("0");
                                    sIncluiCFOPsValores.Append(", ");

                                    sIncluiCFOPsCampos.Append("st_combustivel");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("'");
                                    sIncluiCFOPsValores.Append("N");
                                    sIncluiCFOPsValores.Append("', ");

                                    sIncluiCFOPsCampos.Append("st_canc");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("'");
                                    sIncluiCFOPsValores.Append("N");
                                    sIncluiCFOPsValores.Append("', ");

                                    sIncluiCFOPsCampos.Append("cd_lanimp");
                                    sIncluiCFOPsValores.Append("'");
                                    sIncluiCFOPsValores.Append("000'");

                                    if (item.ICMSST != 0)
                                    {
                                        sIncluiCFOPsCampos.Append(",ds_obs");
                                        sIncluiCFOPsValores.Append(",'");
                                        sIncluiCFOPsValores.Append("vBCST: " + item.VBCICMSST.ToString().Replace(",", ".") + " - vST:" + item.ICMSST.ToString().Replace(",", ".") + "'");

                                        sIncluiCFOPsCampos.Append(",vl_baseicmret");
                                        sIncluiCFOPsValores.Append(",'");
                                        sIncluiCFOPsValores.Append(item.VBCICMSST.ToString().Replace(",", ".") + "'");

                                        sIncluiCFOPsCampos.Append(",vl_icmretoup");
                                        sIncluiCFOPsValores.Append(",'");
                                        sIncluiCFOPsValores.Append(item.ICMSST.ToString().Replace(",", ".") + "'");
                                    }


                                    if (bIndustria)
                                    {
                                        sIncluiCFOPsCampos.Append(", vl_outripi");
                                        sIncluiCFOPsValores.Append(", ");
                                        sIncluiCFOPsValores.Append(item.valor.ToString().Replace(",", "."));
                                    }
                                    break;
                                }
                            #endregion

                            #region 202_203
                            #region 202
                            case "202":
                                {
                                    sIncluiCFOPsCampos.Append("cd_empresa");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("'");
                                    sIncluiCFOPsValores.Append(objInfNFe.Empresa.ToString());
                                    sIncluiCFOPsValores.Append("', ");

                                    sIncluiCFOPsCampos.Append("NR_SEQNFCFOP");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("'");
                                    sIncluiCFOPsValores.Append(sNrSeqNFCFOP);
                                    sIncluiCFOPsValores.Append("', ");

                                    sIncluiCFOPsCampos.Append("cd_cfop");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("'");
                                    sIncluiCFOPsValores.Append(item.CFOP.ToString());
                                    sIncluiCFOPsValores.Append("', ");

                                    sIncluiCFOPsCampos.Append("cd_lancont");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("'");
                                    sIncluiCFOPsValores.Append("000");
                                    sIncluiCFOPsValores.Append("', ");

                                    sIncluiCFOPsCampos.Append("nr_seqnf");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("'");
                                    sIncluiCFOPsValores.Append(psNrSeqNF);
                                    sIncluiCFOPsValores.Append("', ");

                                    sIncluiCFOPsCampos.Append("vl_contabil");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append(item.valor.ToString().Replace(",", "."));
                                    sIncluiCFOPsValores.Append(", ");

                                    sIncluiCFOPsCampos.Append("vl_baseicm");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("0");
                                    sIncluiCFOPsValores.Append(", ");

                                    sIncluiCFOPsCampos.Append("vl_aliicm");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("0");
                                    sIncluiCFOPsValores.Append(", ");

                                    sIncluiCFOPsCampos.Append("vl_icms");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("0");
                                    sIncluiCFOPsValores.Append(", ");

                                    sIncluiCFOPsCampos.Append("vl_outicm");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append(item.valor.ToString().Replace(",", "."));
                                    sIncluiCFOPsValores.Append(", ");

                                    sIncluiCFOPsCampos.Append("vl_isenicm");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("0");
                                    sIncluiCFOPsValores.Append(", ");

                                    sIncluiCFOPsCampos.Append("vl_icmretoup");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append(item.ICMSST.ToString().Replace(",", "."));
                                    sIncluiCFOPsValores.Append(", ");

                                    sIncluiCFOPsCampos.Append("vl_baseicmret");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append(item.VBCICMSST.ToString().Replace(",", "."));
                                    sIncluiCFOPsValores.Append(", ");

                                    sIncluiCFOPsCampos.Append("st_combustivel");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("'");
                                    sIncluiCFOPsValores.Append("N");
                                    sIncluiCFOPsValores.Append("', ");

                                    sIncluiCFOPsCampos.Append("st_canc");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("'");
                                    sIncluiCFOPsValores.Append("N");
                                    sIncluiCFOPsValores.Append("', ");

                                    sIncluiCFOPsCampos.Append("cd_lanimp");
                                    sIncluiCFOPsValores.Append("'");
                                    sIncluiCFOPsValores.Append("000");
                                    sIncluiCFOPsValores.Append("' ");

                                    if (bIndustria)
                                    {
                                        sIncluiCFOPsCampos.Append(", vl_outripi");
                                        sIncluiCFOPsValores.Append(", ");
                                        sIncluiCFOPsValores.Append(item.valor.ToString().Replace(",", "."));
                                    }

                                    break;
                                }
                            #endregion
                            #region 203
                            case "203":
                                {
                                    sIncluiCFOPsCampos.Append("cd_empresa");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("'");
                                    sIncluiCFOPsValores.Append(objInfNFe.Empresa.ToString());
                                    sIncluiCFOPsValores.Append("', ");

                                    sIncluiCFOPsCampos.Append("NR_SEQNFCFOP");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("'");
                                    sIncluiCFOPsValores.Append(sNrSeqNFCFOP);
                                    sIncluiCFOPsValores.Append("', ");

                                    sIncluiCFOPsCampos.Append("cd_cfop");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("'");
                                    sIncluiCFOPsValores.Append(item.CFOP.ToString());
                                    sIncluiCFOPsValores.Append("', ");

                                    sIncluiCFOPsCampos.Append("cd_lancont");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("'");
                                    sIncluiCFOPsValores.Append("000");
                                    sIncluiCFOPsValores.Append("', ");

                                    sIncluiCFOPsCampos.Append("nr_seqnf");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("'");
                                    sIncluiCFOPsValores.Append(psNrSeqNF);
                                    sIncluiCFOPsValores.Append("', ");

                                    sIncluiCFOPsCampos.Append("vl_contabil");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append(item.valor.ToString().Replace(",", "."));
                                    sIncluiCFOPsValores.Append(", ");

                                    sIncluiCFOPsCampos.Append("vl_baseicm");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("0");
                                    sIncluiCFOPsValores.Append(", ");

                                    sIncluiCFOPsCampos.Append("vl_aliicm");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("0");
                                    sIncluiCFOPsValores.Append(", ");

                                    sIncluiCFOPsCampos.Append("vl_icms");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("0");
                                    sIncluiCFOPsValores.Append(", ");

                                    sIncluiCFOPsCampos.Append("vl_outicm");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append(item.valor.ToString().Replace(",", "."));
                                    sIncluiCFOPsValores.Append(", ");

                                    sIncluiCFOPsCampos.Append("vl_isenicm");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("0");
                                    sIncluiCFOPsValores.Append(", ");

                                    sIncluiCFOPsCampos.Append("vl_icmretoup");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append(item.ICMSST.ToString().Replace(",", "."));
                                    sIncluiCFOPsValores.Append(", ");

                                    sIncluiCFOPsCampos.Append("vl_baseicmret");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append(item.VBCICMSST.ToString().Replace(",", "."));
                                    sIncluiCFOPsValores.Append(", ");

                                    sIncluiCFOPsCampos.Append("st_combustivel");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("'");
                                    sIncluiCFOPsValores.Append("N");
                                    sIncluiCFOPsValores.Append("', ");

                                    sIncluiCFOPsCampos.Append("st_canc");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("'");
                                    sIncluiCFOPsValores.Append("N");
                                    sIncluiCFOPsValores.Append("', ");

                                    sIncluiCFOPsCampos.Append("cd_lanimp");
                                    sIncluiCFOPsValores.Append("'");
                                    sIncluiCFOPsValores.Append("000");
                                    sIncluiCFOPsValores.Append("' ");

                                    if (bIndustria)
                                    {
                                        sIncluiCFOPsCampos.Append(", vl_outripi");
                                        sIncluiCFOPsValores.Append(", ");
                                        sIncluiCFOPsValores.Append(item.valor.ToString().Replace(",", "."));
                                    }

                                    break;
                                }
                            #endregion
                            #endregion

                            #region 500
                            #region 500
                            case "500":
                                {
                                    sIncluiCFOPsCampos.Append("cd_empresa");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("'");
                                    sIncluiCFOPsValores.Append(objInfNFe.Empresa.ToString());
                                    sIncluiCFOPsValores.Append("', ");

                                    sIncluiCFOPsCampos.Append("NR_SEQNFCFOP");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("'");
                                    sIncluiCFOPsValores.Append(sNrSeqNFCFOP);
                                    sIncluiCFOPsValores.Append("', ");

                                    sIncluiCFOPsCampos.Append("cd_cfop");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("'");
                                    sIncluiCFOPsValores.Append(item.CFOP.ToString());
                                    sIncluiCFOPsValores.Append("', ");

                                    sIncluiCFOPsCampos.Append("cd_lancont");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("'");
                                    sIncluiCFOPsValores.Append("000");
                                    sIncluiCFOPsValores.Append("', ");

                                    sIncluiCFOPsCampos.Append("nr_seqnf");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("'");
                                    sIncluiCFOPsValores.Append(psNrSeqNF);
                                    sIncluiCFOPsValores.Append("', ");

                                    sIncluiCFOPsCampos.Append("vl_contabil");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append(item.valor.ToString().Replace(",", "."));
                                    sIncluiCFOPsValores.Append(", ");

                                    sIncluiCFOPsCampos.Append("vl_baseicm");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("0");
                                    sIncluiCFOPsValores.Append(", ");

                                    sIncluiCFOPsCampos.Append("vl_aliicm");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("0");
                                    sIncluiCFOPsValores.Append(", ");

                                    sIncluiCFOPsCampos.Append("vl_icms");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("0");
                                    sIncluiCFOPsValores.Append(", ");

                                    sIncluiCFOPsCampos.Append("vl_outicm");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append(item.valor.ToString().Replace(",", "."));
                                    sIncluiCFOPsValores.Append(", ");

                                    sIncluiCFOPsCampos.Append("vl_isenicm");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("0");
                                    sIncluiCFOPsValores.Append(", ");

                                    sIncluiCFOPsCampos.Append("vl_icmretoup");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append(item.ICMSST.ToString().Replace(",", "."));
                                    sIncluiCFOPsValores.Append(", ");

                                    sIncluiCFOPsCampos.Append("vl_baseicmret");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append(item.VBCICMSST.ToString().Replace(",", "."));
                                    sIncluiCFOPsValores.Append(", ");

                                    sIncluiCFOPsCampos.Append("st_combustivel");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("'");
                                    sIncluiCFOPsValores.Append("N");
                                    sIncluiCFOPsValores.Append("', ");

                                    sIncluiCFOPsCampos.Append("st_canc");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("'");
                                    sIncluiCFOPsValores.Append("N");
                                    sIncluiCFOPsValores.Append("', ");

                                    sIncluiCFOPsCampos.Append("cd_lanimp");
                                    sIncluiCFOPsValores.Append("'");
                                    sIncluiCFOPsValores.Append("000");
                                    sIncluiCFOPsValores.Append("' ");

                                    if (bIndustria)
                                    {
                                        sIncluiCFOPsCampos.Append(", vl_outripi");
                                        sIncluiCFOPsValores.Append(", ");
                                        sIncluiCFOPsValores.Append(item.valor.ToString().Replace(",", "."));
                                    }
                                    break;
                                }
                            #endregion
                            #endregion

                            #region 900
                            case "900":
                                {
                                    sIncluiCFOPsCampos.Append("cd_empresa");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("'");
                                    sIncluiCFOPsValores.Append(objInfNFe.Empresa.ToString());
                                    sIncluiCFOPsValores.Append("', ");

                                    sIncluiCFOPsCampos.Append("NR_SEQNFCFOP");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("'");
                                    sIncluiCFOPsValores.Append(sNrSeqNFCFOP);
                                    sIncluiCFOPsValores.Append("', ");

                                    sIncluiCFOPsCampos.Append("cd_cfop");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("'");
                                    sIncluiCFOPsValores.Append(item.CFOP.ToString());
                                    sIncluiCFOPsValores.Append("', ");

                                    sIncluiCFOPsCampos.Append("cd_lancont");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("'");
                                    sIncluiCFOPsValores.Append("000");
                                    sIncluiCFOPsValores.Append("', ");

                                    sIncluiCFOPsCampos.Append("nr_seqnf");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("'");
                                    sIncluiCFOPsValores.Append(psNrSeqNF);
                                    sIncluiCFOPsValores.Append("', ");

                                    sIncluiCFOPsCampos.Append("vl_contabil");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append(item.valor.ToString().Replace(",", "."));
                                    sIncluiCFOPsValores.Append(", ");

                                    sIncluiCFOPsCampos.Append("vl_baseicm");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("0");
                                    sIncluiCFOPsValores.Append(", ");

                                    sIncluiCFOPsCampos.Append("vl_aliicm");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("0");
                                    sIncluiCFOPsValores.Append(", ");

                                    sIncluiCFOPsCampos.Append("vl_icms");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("0");
                                    sIncluiCFOPsValores.Append(", ");

                                    sIncluiCFOPsCampos.Append("vl_outicm");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append(item.valor.ToString().Replace(",", "."));
                                    sIncluiCFOPsValores.Append(", ");

                                    sIncluiCFOPsCampos.Append("vl_isenicm");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("0");
                                    sIncluiCFOPsValores.Append(", ");

                                    sIncluiCFOPsCampos.Append("vl_icmretoup");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append(item.ICMSST.ToString().Replace(",", "."));
                                    sIncluiCFOPsValores.Append(", ");

                                    sIncluiCFOPsCampos.Append("vl_baseicmret");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append(item.VBCICMSST.ToString().Replace(",", "."));
                                    sIncluiCFOPsValores.Append(", ");

                                    sIncluiCFOPsCampos.Append("st_combustivel");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("'");
                                    sIncluiCFOPsValores.Append("N");
                                    sIncluiCFOPsValores.Append("', ");

                                    sIncluiCFOPsCampos.Append("st_canc");
                                    sIncluiCFOPsCampos.Append(", ");
                                    sIncluiCFOPsValores.Append("'");
                                    sIncluiCFOPsValores.Append("N");
                                    sIncluiCFOPsValores.Append("', ");

                                    sIncluiCFOPsCampos.Append("cd_lanimp");
                                    sIncluiCFOPsValores.Append("'");
                                    sIncluiCFOPsValores.Append("000");
                                    sIncluiCFOPsValores.Append("' ");


                                    if (bIndustria)
                                    {
                                        sIncluiCFOPsCampos.Append(", vl_outripi");
                                        sIncluiCFOPsValores.Append(", ");
                                        sIncluiCFOPsValores.Append(item.valor.ToString().Replace(",", "."));
                                    }
                                    break;
                                }
                            #endregion
                        }
                        string sQuery = "select {0} from natop where CD_CFOP = '" + item.CFOP + "'";

                        //ST_SERVICO
                        if (Conexao.State != ConnectionState.Open)
                        {
                            Conexao.Open();
                        }
                        using (FbCommand cmd = new FbCommand(string.Format(sQuery, "count(ST_SERVICO)"), Conexao))
                        {
                            if (Convert.ToInt32(cmd.ExecuteScalar().ToString()) == 0)
                            {
                                throw new Exception("CFOP = " + item.CFOP + " não encontrado no Sistema" +
                                    Environment.NewLine +
                                    Environment.NewLine +
                                    "Nota nº" + objInfNFe.ide.Nnf + " não escriturada corretamente!");
                            }
                            else
                            {
                                FbCommand cmd2 = new FbCommand(string.Format(sQuery, "coalesce(ST_SERVICO,'N') ST_SERVICO"), Conexao);

                                string sST_SERVICO = cmd2.ExecuteScalar().ToString();

                                sIncluiCFOPsCampos.Append(", ");
                                sIncluiCFOPsCampos.Append("tp_servico");
                                sIncluiCFOPsValores.Append(", ");
                                sIncluiCFOPsValores.Append("'");
                                sIncluiCFOPsValores.Append((sST_SERVICO.Equals("S") ? "S" : "N") + "'");
                            }
                        }

                        string sInstrucao = string.Format("Insert into NOTACFOP ({0}) values ({1})",
                                  sIncluiCFOPsCampos.ToString(),
                                  sIncluiCFOPsValores.ToString());

                        using (FbCommand cmd = new FbCommand(sInstrucao.ToString(), Conexao))
                        {
                            if (Conexao.State != ConnectionState.Open)
                            {
                                Conexao.Open();
                            }
                            cmd.ExecuteNonQuery();
                            Conexao.Close();
                        }
                    }

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (Conexao.State == ConnectionState.Open)
                {
                    Conexao.Close();
                }
            }
        }

        private string AnalisaCFOPEntrada(string psCFOP)
        {
            string sCFOP = psCFOP;

            switch (psCFOP)
            {
                case "5405": { sCFOP = "5403"; break; }
                case "5655": { sCFOP = "5556"; break; }
                case "5656": { sCFOP = "5653"; break; }
            }
            return sCFOP;
        }

        private string EscrituraPrincipal(bool pbSaida)
        {
            string sNrSeqNF = string.Empty;

            string sDoc = string.Empty;
            string sContrib = string.Empty;

            if (pbSaida)
            {
                if (objInfNFe.dest.Cnpj != null)
                {
                    sDoc = objInfNFe.dest.Cnpj.ToString();
                }
                else
                {
                    sDoc = objInfNFe.dest.Cpf.ToString();
                }

                if (objInfNFe.dest.Ie != null)
                {
                    sContrib = "S";
                }
                else
                {
                    sContrib = "N";
                }
            }
            else
            {
                if (!bProdutorRural)
                {
                    if (objInfNFe.emit.Cnpj != null)
                    {
                        sDoc = objInfNFe.emit.Cnpj.ToString();
                    }
                    else
                    {
                        sDoc = objInfNFe.emit.Cpf.ToString();
                    }

                    if (objInfNFe.emit.Ie != null)
                    {
                        sContrib = "S";
                    }
                    else
                    {
                        sContrib = "N";
                    }
                }
                else
                {
                    if (objInfNFe.dest.Cnpj != null)
                    {
                        sDoc = objInfNFe.dest.Cnpj.ToString();
                    }
                    else
                    {
                        sDoc = objInfNFe.dest.Cpf.ToString();
                    }

                    if ((objInfNFe.dest.Ie != null) && (objInfNFe.dest.Ie != "ISENTO"))
                    {
                        sContrib = "S";
                    }
                    else
                    {
                        sContrib = "N";
                    }
                }

            }

            try
            {
                sNrSeqNF = BuscaValorChavePrimaria("notalf", 7, "nr_seqnf", "notalf", objInfNFe.Empresa.ToString());


                StringBuilder sNotalf = new StringBuilder();
                sNotalf.Append("Insert into ");
                sNotalf.Append("notalf (");
                sNotalf.Append("cd_empresa, ");
                sNotalf.Append("nr_seqnf, ");
                sNotalf.Append("tp_livro, ");
                sNotalf.Append("cd_altercli, ");
                sNotalf.Append("st_contrib, ");
                sNotalf.Append("st_nfter, ");
                sNotalf.Append("cd_modelo, ");
                sNotalf.Append("cd_notafis, ");
                sNotalf.Append("cd_serienf, ");
                sNotalf.Append("cd_subsernf, ");
                sNotalf.Append("ds_especienf, ");
                sNotalf.Append("dt_emi, ");
                sNotalf.Append("dt_entrada, ");
                sNotalf.Append("cd_uf, ");
                sNotalf.Append("vl_contabil, ");
                sNotalf.Append("cd_cgc, ");
                sNotalf.Append("cd_insest, ");
                sNotalf.Append("dt_cad, ");
                sNotalf.Append("cd_clifor, ");
                sNotalf.Append("st_canc ");
                sNotalf.Append(")");

                sNotalf.Append("Values ( '");
                sNotalf.Append(objInfNFe.Empresa.ToString());
                sNotalf.Append("', '");
                sNotalf.Append(sNrSeqNF);
                sNotalf.Append("', '");
                sNotalf.Append((pbSaida == true ? "2" : "1"));
                sNotalf.Append("', '");
                sNotalf.Append(sDoc);
                sNotalf.Append("', '");
                sNotalf.Append(sContrib);
                sNotalf.Append("', ");
                sNotalf.Append((pbSaida == true ? "'N'" : "'S'"));
                sNotalf.Append(", '");
                sNotalf.Append(objInfNFe.ide.Mod.ToString());
                sNotalf.Append("', '");
                sNotalf.Append(objInfNFe.ide.Nnf.ToString());
                sNotalf.Append("', '");
                sNotalf.Append(objInfNFe.ide.Serie.ToString());
                sNotalf.Append("', ");
                sNotalf.Append("Null");
                sNotalf.Append(", '");
                sNotalf.Append("NFE");
                sNotalf.Append("', '");
                sNotalf.Append(objInfNFe.ide.Demi.ToString("dd.MM.yyyy"));
                sNotalf.Append("', '");
                sNotalf.Append(objInfNFe.ide.Dsaient.ToString("dd.MM.yyyy"));
                sNotalf.Append("', '");
                using (FbCommand cmd = new FbCommand("select clifor.cd_ufnor from clifor where clifor.cd_alter = '" + sDoc + "'", Conexao))
                {
                    if (Conexao.State != ConnectionState.Open)
                    {
                        Conexao.Open();
                    }
                    string sUF = "";
                    FbDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        sUF = dr["cd_ufnor"].ToString();
                    }

                    if (sUF == "")
                    {
                        sNotalf.Append((pbSaida ? objInfNFe.dest.Uf.ToString() : objInfNFe.emit.Uf.ToString()));
                    }
                    else
                    {
                        sNotalf.Append(sUF);
                    }
                }
                sNotalf.Append("', ");
                sNotalf.Append(objInfNFe.total.belIcmstot.Vnf.ToString().Replace(",", "."));
                sNotalf.Append(", '");
                sNotalf.Append(FormataString(sDoc, "CNPJ"));
                sNotalf.Append("', '");
                sNotalf.Append(objInfNFe.dest.Ie);
                sNotalf.Append("', ");
                sNotalf.Append("current_timestamp");
                sNotalf.Append(", '");
                string sTipo = (objInfNFe.dest.Cnpj != null ? "CNPJ" : "CPF");
                if (!RegistroExiste("CLIFOR", (objInfNFe.dest.Cnpj != null ? "CD_CGC = '" : "CD_CPF ='") + FormataString(sDoc, sTipo) + "'", "CD_CLIFOR"))
                {
                    sNotalf.Append(CadastraCliFor(FormataString(sDoc, "CNPJ")));
                }
                else
                {
                    sNotalf.Append(BuscaCodigoClifor(FormataString(sDoc, sTipo)));
                }
                sNotalf.Append("', '");
                sNotalf.Append("N");
                sNotalf.Append("')");

                using (FbCommand cmd = new FbCommand(sNotalf.ToString(), Conexao))
                {
                    if (Conexao.State != ConnectionState.Open)
                    {
                        Conexao.Open();
                    }
                    cmd.ExecuteNonQuery();

                }
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Não foi possível escriturar a parte principal da Nota, erro {0}",
                                                   ex.Message));
            }
            finally
            {
                if (Conexao.State == ConnectionState.Open)
                {
                    Conexao.Close();
                }

            }
            return sNrSeqNF;
        }

        private string BuscaCodigoClifor(string sDoc)
        {
            string scdClifor = "";
            try
            {
                StringBuilder sCodigoCliente = new StringBuilder();
                sCodigoCliente.Append("Select ");
                sCodigoCliente.Append("cd_clifor ");
                sCodigoCliente.Append("from Clifor ");
                sCodigoCliente.Append("where ");
                sCodigoCliente.Append((objInfNFe.dest.Cnpj != null ? "cd_cgc" : "cd_cpf"));
                sCodigoCliente.Append(" ='");
                sCodigoCliente.Append(sDoc);
                sCodigoCliente.Append("'");

                using (FbCommand cmd = new FbCommand(sCodigoCliente.ToString(), Conexao))
                {
                    if (Conexao.State != ConnectionState.Open)
                    {
                        Conexao.Open();
                    }
                    scdClifor = cmd.ExecuteScalar().ToString();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Não foi possível localizar o Código do Cliente{0}. Erro: {1}",
                                    objInfNFe.dest.Xnome.ToString(),
                                    ex.Message));
            }
            finally
            {
                if (Conexao.State == ConnectionState.Open)
                {
                    Conexao.Close();
                }
            }
            return scdClifor;
        }

        private bool NotaSaida()
        {
            bool bSaida = false;
            try
            {
                StringBuilder sSql = new StringBuilder();
                string sDoc = string.Empty;

                sSql.Append("Select ");
                if (objInfNFe.dest.Cnpj != null)
                {
                    sSql.Append("cd_cgc ");
                }
                else
                {
                    sSql.Append("cd_CPF ");
                }
                sSql.Append("from Empresa ");
                sSql.Append("where cd_empresa = '");
                sSql.Append(objInfNFe.Empresa);
                sSql.Append("'");

                using (FbCommand cmd = new FbCommand(sSql.ToString(), Conexao))
                {
                    if (Conexao.State != ConnectionState.Open)
                    {
                        Conexao.Open();
                    }

                    sDoc = Util.TiraSimbolo(cmd.ExecuteScalar().ToString(), "");
                }

                if (objInfNFe.dest.Cnpj != null)
                {
                    if (sDoc == objInfNFe.dest.Cnpj)
                    {
                        bSaida = false;
                    }
                    else
                    {
                        bSaida = true;
                    }
                }
                else
                {
                    if (sDoc == objInfNFe.dest.Cpf)
                    {
                        bSaida = false;
                    }
                    else
                    {
                        bSaida = true;
                    }
                }

            }
            catch (Exception ex)
            {

                throw new Exception(string.Format("Não foi possível definir se a Nota é de entrada ou saída. Erro {0}",
                                                   ex.Message));
            }
            finally
            {
                if (Conexao.State == ConnectionState.Open)
                {
                    Conexao.Close();
                }
            }
            return bSaida;
        }

        private string FormataString(string psValor, string psTipo)
        {
            MaskedTextBox mk = new MaskedTextBox();
            string sRetorno = string.Empty;
            if (psValor != "")
            {
                switch (psTipo)
                {
                    case "CNPJ":
                        {
                            mk.Mask = "99,999,999/9999-99";
                            mk.Text = psValor;
                            sRetorno = mk.Text;
                            break;
                        }
                    case "CPF":
                        {
                            mk.Mask = "999,999,999-99";
                            mk.Text = psValor;
                            sRetorno = mk.Text;
                            break;
                        }
                    case "CEP":
                        {
                            mk.Mask = "99999-999";
                            mk.Text = psValor;
                            sRetorno = mk.Text;
                            break;
                        }
                    case "Fone":
                        {
                            mk.Mask = "(99)9999-9999";
                            mk.Text = psValor;
                            sRetorno = mk.Text;
                            break;
                        }
                }
            }

            return sRetorno;
        }

        private string CadastraCliFor(string psDoc)
        {
            string scdClifor = string.Empty;

            try
            {
                scdClifor = BuscaValorChavePrimaria("CLIFOR", 7, "cd_clifor", "Clifor", "");

                string sPEssoaj = (PessoaJuridica() == true ? "S" : "N");
                StringBuilder sInsert = new StringBuilder();
                sInsert.Append("Insert into ");
                sInsert.Append("Clifor (");
                sInsert.Append("cd_clifor, ");
                sInsert.Append("cd_alter, ");
                sInsert.Append("nm_clifor, ");
                sInsert.Append("nm_guerra, ");
                sInsert.Append("ds_endnor, ");
                sInsert.Append("nr_endnor, ");
                sInsert.Append("nm_bairronor, ");
                sInsert.Append("nm_cidnor, ");
                sInsert.Append("cd_ufnor, ");
                sInsert.Append("cd_cepnor, ");
                sInsert.Append("cd_fonenor, ");
                sInsert.Append("cd_catego, ");
                sInsert.Append("st_pessoaj, ");

                if (sPEssoaj == "S")
                {
                    sInsert.Append("cd_cgc, ");
                }
                else
                {
                    sInsert.Append("cd_cpf, ");
                }

                sInsert.Append("cd_insest, ");
                sInsert.Append("st_zfmalc ");
                sInsert.Append(") ");
                sInsert.Append("Values ('");
                sInsert.Append(scdClifor);
                sInsert.Append("', '");
                sInsert.Append(Util.TiraSimbolo(psDoc, ""));
                sInsert.Append("', '");
                sInsert.Append(objInfNFe.dest.Xnome.ToString());
                sInsert.Append("', '");
                sInsert.Append(objInfNFe.dest.Xnome.ToString().Substring(0, 15));
                sInsert.Append("', '");
                sInsert.Append(objInfNFe.dest.Xlgr.ToString());
                sInsert.Append("', '");
                sInsert.Append(objInfNFe.dest.Nro.ToString());
                sInsert.Append("', '");
                if (objInfNFe.dest.Xbairro.ToString().Length > 20)
                {
                    objInfNFe.dest.Xbairro = objInfNFe.dest.Xbairro.ToString().Substring(0, 20);
                }
                sInsert.Append(objInfNFe.dest.Xbairro.ToString());
                sInsert.Append("', '");
                sInsert.Append(objInfNFe.dest.Xmun.ToString());
                sInsert.Append("', '");
                sInsert.Append(objInfNFe.dest.Uf.ToString());
                sInsert.Append("', '");
                sInsert.Append(objInfNFe.dest.Cep.ToString());
                sInsert.Append("', '");
                sInsert.Append((objInfNFe.dest.Fone != null ? objInfNFe.dest.Fone.ToString() : ""));
                sInsert.Append("', '");
                sInsert.Append(BuscaCategoria());
                sInsert.Append("', '");
                sInsert.Append(sPEssoaj);
                sInsert.Append("', '");
                sInsert.Append(psDoc);
                sInsert.Append("', '");
                sInsert.Append(objInfNFe.dest.Ie.ToString() != null ? objInfNFe.dest.Ie.ToString() : "Null");
                sInsert.Append("', '");
                sInsert.Append(objInfNFe.dest.Isuf != null ? "S" : "N");
                sInsert.Append("') ");

                using (FbCommand cmd = new FbCommand(sInsert.ToString(), Conexao))
                {
                    if (Conexao.State != ConnectionState.Open)
                    {
                        Conexao.Open();
                    }

                    cmd.ExecuteNonQuery();

                }

            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Não foi Possível incluir o Cliente/Fornecedor, CNPJ {0}, Erro:{1}",
                                                  psDoc,
                                                  ex.Message));
            }
            finally
            {
                if (Conexao.State == ConnectionState.Open)
                {
                    Conexao.Close();
                }
            }
            return scdClifor;
        }

        private string BuscaValorChavePrimaria(string psGenerator, int piAlinhamento, string psCampoChave, string psTabela, string psEmpresa)
        {
            psGenerator = psGenerator + psEmpresa.Trim();
            string sChave = string.Empty;
            try
            {
                // Criar Generator 09/06/2010
                StringBuilder sSql = new StringBuilder();
                sSql.Append("Select ");
                sSql.Append("cast((select ds_resultado from sp_falinha(gen_id(");
                sSql.Append(psGenerator);

                //if (psEmpresa != "")
                //{
                //    sSql.Append(psEmpresa);
                //}

                sSql.Append(",1),");
                sSql.Append(piAlinhamento.ToString());
                sSql.Append(")) as Varchar(");
                sSql.Append(piAlinhamento.ToString());
                sSql.Append(")) ");
                sSql.Append("from rdb$database ");

                using (FbCommand cmd = new FbCommand(sSql.ToString(), Conexao))
                {
                    if (Conexao.State != ConnectionState.Open)
                    {
                        Conexao.Open();
                    }
                    try
                    {
                        sChave = cmd.ExecuteScalar().ToString();
                    }
                    catch (FbException ex)
                    {
                        if (ex.Errors.Count > 0)
                        {
                            using (FbCommand cmdGernerator = new FbCommand("CREATE GENERATOR " + psGenerator, Conexao))
                            {
                                if (Conexao.State != ConnectionState.Open)
                                {
                                    Conexao.Open();
                                }
                                cmdGernerator.ExecuteScalar();
                            }
                        }
                        sChave = cmd.ExecuteScalar().ToString();
                    }
                }

                string sChaveVerificar = string.Empty;

                StringBuilder sConferenciaChave = new StringBuilder();
                if (psTabela != "LINHAPRO")
                {
                    sConferenciaChave.Append("Select ");
                    sConferenciaChave.Append("max(");
                    sConferenciaChave.Append(psCampoChave);
                    sConferenciaChave.Append(") ");
                    sConferenciaChave.Append("From ");
                    sConferenciaChave.Append(psTabela);
                }
                else
                {
                    sConferenciaChave.Append("Select ");
                    sConferenciaChave.Append("first 1 CD_LINHA ");
                    sConferenciaChave.Append("From ");
                    sConferenciaChave.Append(psTabela);

                }
                if (psEmpresa != "")
                {
                    sConferenciaChave.Append(" where cd_empresa = '");
                    sConferenciaChave.Append(psEmpresa);
                    sConferenciaChave.Append("'");
                }

                // Diego 06/09/2010 - 24456
                int icountLinhaPro = 0;
                if (psTabela.ToUpper().Equals("LINHAPRO"))
                {
                    using (FbCommand cmdCount = new FbCommand("Select count(cd_linha) from linhapro where cd_empresa= " + psEmpresa, Conexao))
                    {
                        if (Conexao.State != ConnectionState.Open)
                        {
                            Conexao.Open();
                        }
                        icountLinhaPro = Convert.ToInt32(cmdCount.ExecuteScalar());
                    }
                }
                if (psTabela.ToUpper().Equals("LINHAPRO") && icountLinhaPro == 0)
                {
                    sChaveVerificar = "1";
                }
                else
                {
                    using (FbCommand cmd = new FbCommand(sConferenciaChave.ToString(), Conexao))
                    {
                        if (Conexao.State != ConnectionState.Open)
                        {
                            Conexao.Open();
                        }
                        sChaveVerificar = cmd.ExecuteScalar().ToString().PadLeft(piAlinhamento);

                        if (psTabela != "LINHAPRO")
                        {
                            sChaveVerificar = (Convert.ToInt32(sChaveVerificar) + 1).ToString().PadLeft(piAlinhamento);
                        }

                        if (sChaveVerificar.Trim().Equals(""))
                        {
                            sChaveVerificar = "1";
                        }
                    }
                }


                if (psTabela != "LINHAPRO")
                {
                    if (Convert.ToInt32(sChaveVerificar) > Convert.ToInt32(sChave))
                    {
                        sChave = sChaveVerificar;
                        string sInstrucao = string.Empty;
                        sInstrucao = "set generator " + psGenerator + " to " + sChave;

                        using (FbCommand cmd = new FbCommand(sInstrucao, Conexao))
                        {
                            if (Conexao.State != ConnectionState.Open)
                            {
                                Conexao.Open();
                            }

                            cmd.ExecuteNonQuery();

                        }

                    }
                }
                else
                {
                    sChave = sChaveVerificar;
                }






            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Não foi possível retornar a Chave Primaria da Tabela {0}. {1} Erro: {2}",
                                                  psGenerator,
                                                  Environment.NewLine,
                                                  ex.Message));
            }
            finally
            {
                if (Conexao.State == ConnectionState.Open)
                {
                    Conexao.Close();
                }
            }
            return sChave;
        }

        private bool PessoaJuridica()
        {
            bool bPessoaj = false;
            try
            {
                if (objInfNFe.dest.Cnpj != null)
                {
                    bPessoaj = true;
                }

            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Não foi possível determinar a pessoa é Juridica ou Fisica, Erro: {0}",
                                                  ex.Message));
            }
            return bPessoaj;
        }

        private string BuscaCategoria()
        {
            string sCategoria = string.Empty;
            try
            {
                StringBuilder sSql = new StringBuilder();
                sSql.Append("Select ");
                sSql.Append("First 1 ");
                sSql.Append("cd_catego ");
                sSql.Append("from Categclf ");
                sSql.Append("where ds_catego containing ");
                sSql.Append("'geral'");

                using (FbCommand cmd = new FbCommand(sSql.ToString(), Conexao))
                {
                    if (Conexao.State != ConnectionState.Open)
                    {
                        Conexao.Open();
                    }

                    sCategoria = cmd.ExecuteScalar().ToString();

                }

            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Não foi possível utilizar uma categoria padrão.{0} Provavelmente não existe a Categoria de clientes/Fonecedores cadastrada. (Geral) {0} Erro: {1}",
                                                  Environment.NewLine,
                                                  ex.Message));
            }
            return sCategoria;
        }


        public struct strucEmpresas
        {
            public string Codigo { get; set; }
            public string Descricao { get; set; }
        }


        public List<strucEmpresas> RetornaEmpresa()
        {
            List<strucEmpresas> lobjEmpresa = new List<strucEmpresas>();
            try
            {
                using (FbCommand cmd = new FbCommand("select cd_empresa, nm_guerra from empresa order by nm_guerra", Conexao))
                {
                    if (Conexao.State != ConnectionState.Open)
                    {
                        Conexao.Open();
                    }

                    FbDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        strucEmpresas objEmpresa = new strucEmpresas();
                        objEmpresa.Codigo = dr["cd_empresa"].ToString();
                        objEmpresa.Descricao = dr["cd_empresa"].ToString() + " - " + dr["nm_guerra"].ToString();

                        lobjEmpresa.Add(objEmpresa);
                    }

                }

            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Não foi possível Trazer as Empresas, Erro: {0}",
                                                  ex.Message));
            }

            return lobjEmpresa;
        }

        public string TipoLancamento()
        {
            try
            {
                string sTipoLancamento = string.Empty;
                string sCNPJempresa = "";
                using (FbCommand cmd = new FbCommand("select cd_cgc from empresa where cd_empresa ='" + objInfNFe.Empresa + "'", Conexao))
                {
                    if (Conexao.State != ConnectionState.Open)
                    {
                        Conexao.Open();
                    }
                    sCNPJempresa = Util.TiraSimbolo(cmd.ExecuteScalar().ToString(), "");
                    Conexao.Close();
                }

                //--->  0-Entrada / 1-Saída


                if (objInfNFe.ide .Tpnf == "0")
                {
                    sTipoLancamento = "E";
                    if (objInfNFe.emit.Cnpj != null)
                    {
                        if (objInfNFe.emit.Cnpj.ToString() == sCNPJempresa)
                        {
                            bProdutorRural = true;
                        }
                    }
                    else
                    {
                        string sInstrucao = string.Empty;
                        sInstrucao = "select cd_cpf from empresa where cd_empresa ='" + objInfNFe.Empresa + "'";
                        using (FbCommand cmd = new FbCommand(sInstrucao, Conexao))
                        {
                            if (Conexao.State != ConnectionState.Open)
                            {
                                Conexao.Open();
                            }

                            string sCPF = Util.TiraSimbolo(cmd.ExecuteScalar().ToString(), "");

                            if (sCPF == objInfNFe.emit.Cpf.ToString())
                            {
                                sCPF = objInfNFe.emit.Cpf;
                                bProdutorRural = true;
                            }
                        }
                    }
                }
                else
                {

                    if (objInfNFe.emit.Cnpj != null)
                    {
                        if (objInfNFe.emit.Cnpj.ToString() == sCNPJempresa)
                        {
                            sTipoLancamento = "S";
                        }
                    }
                    if (objInfNFe.dest.Cnpj != null)
                    {
                        if (objInfNFe.dest.Cnpj.ToString() == sCNPJempresa)
                        {
                            sTipoLancamento = "E";
                        }
                    }
                }
                return sTipoLancamento;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Não foi possível definir o Tipo de Lançamento, Erro: {0}",
                                                   ex.Message));
            }

            #region Codigo Comentado
            // string sTipoLancamento = string.Empty;

            // if (objInfNFe.BelIde.Tpnf == "0")
            // {
            //     sTipoLancamento = "S";
            // }
            // else
            // {
            //     sTipoLancamento = "E";
            // }



            //try
            //{
            //    if (sTipoLancamento == "E")
            //    {
            //        if (objInfNFe.emit.Cnpj != null)
            //        {
            //            using (FbCommand cmd = new FbCommand("select cd_cgc from empresa where cd_empresa ='" + objInfNFe.Empresa + "'", Conexao))
            //            {
            //                if (Conexao.State != ConnectionState.Open)
            //                {
            //                    Conexao.Open();
            //                }
            //                GeraXMLExp objGerarXMLExp = new GeraXMLExp();

            //                string sCNPJ = objGerarXMLExp.TiraSimbolo(cmd.ExecuteScalar().ToString(), "");

            //                if (objInfNFe.emit.Cnpj.ToString() == sCNPJ)
            //                {
            //                    bProdutorRural = true;
            //                }
            //            }
            //        }
            //        else
            //        {
            //            string sInstrucao = string.Empty;
            //            sInstrucao = "select cd_cpf from empresa where cd_empresa ='" + objInfNFe.Empresa + "'";
            //            using (FbCommand cmd = new FbCommand(sInstrucao, Conexao))
            //            {
            //                if (Conexao.State != ConnectionState.Open)
            //                {
            //                    Conexao.Open();
            //                }
            //                GeraXMLExp objGerarXMLExp = new GeraXMLExp();

            //                string sCPF = objGerarXMLExp.TiraSimbolo(cmd.ExecuteScalar().ToString(), "");

            //                if (sCPF == objInfNFe.emit.Cpf.ToString())
            //                {
            //                    sCPF = objInfNFe.emit.Cpf;
            //                    bProdutorRural = true;
            //                }
            //            }
            //        }                    
            //    }


            //    return sTipoLancamento;

            //}
            //catch (Exception ex)
            //{
            //    throw new Exception(string.Format("Não foi possível definir o Tipo de Lançamento, Erro: {0}",
            //                                       ex.Message));
            //}            
            #endregion
        }

        public bool RegistroExiste(string psTabela, string psFiltro, string psChave)
        {
            bool bExiste = false;

            try
            {
                StringBuilder sSql = new StringBuilder();
                sSql.Append("Select Count(");
                sSql.Append(psChave);
                sSql.Append(") ");
                sSql.Append("from ");
                sSql.Append(psTabela);
                sSql.Append(" where ");
                sSql.Append(psFiltro);
                using (FbCommand cmd = new FbCommand(sSql.ToString(), Conexao))
                {
                    if (Conexao.State != ConnectionState.Open)
                    {
                        Conexao.Open();
                    }
                    int iTot = Convert.ToInt16(cmd.ExecuteScalar());
                    if (iTot > 0)
                    {
                        bExiste = true;
                    }
                    else
                    {
                        bExiste = false;
                    }

                }
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Não foi possível verificar a existencia do Registro, Erro: {0}",
                                                  ex.Message));
            }
            finally
            {
                if (Conexao.State == ConnectionState.Open)
                {
                    Conexao.Close();
                }
            }
            return bExiste;
        }

        public string RetCodigoRegistro(string psTabela, string psFiltro, string psChave)
        {
            try
            {
                string sCodigo = "";

                StringBuilder sSql = new StringBuilder();
                sSql.Append("Select ");
                sSql.Append("coalesce(" + psChave + ",'')" + psChave);
                sSql.Append(" from ");
                sSql.Append(psTabela);
                sSql.Append(" where ");
                sSql.Append(psFiltro);
                using (FbCommand cmd = new FbCommand(sSql.ToString(), Conexao))
                {
                    if (Conexao.State != ConnectionState.Open)
                    {
                        Conexao.Open();
                    }
                    FbDataReader dr = cmd.ExecuteReader();
                    dr.Read();
                    sCodigo = dr[psChave].ToString();
                }
                return sCodigo;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Não foi possível buscar o Código do Registro, Erro: {0}",
                                                  ex.Message));
            }
            finally
            {
                if (Conexao.State == ConnectionState.Open)
                {
                    Conexao.Close();
                }
            }
        }

        public string RetornaProximoValorGenerator(string sNomeGernerator, int sTamanho)
        {

            try
            {
                string sNumArq = "";
                FbCommand sSql = new FbCommand();

                if (Conexao.State != ConnectionState.Open)
                {
                    Conexao.Open();
                }
                sSql.Connection = Conexao;
                sSql.CommandText = "SP_CHAVEPRI";
                sSql.CommandType = CommandType.StoredProcedure;
                sSql.Parameters.Clear();

                sSql.Parameters.Add("@SNOMEGENERATOR", FbDbType.VarChar, 31).Value = sNomeGernerator;

                sNumArq = sSql.ExecuteScalar().ToString();

                return sNumArq.PadLeft(sTamanho, '0');
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Não foi possível buscar o Próximo Código para o Produto, Erro: {0}",
                                                  ex.Message));
            }
            finally
            {
                if (Conexao.State == ConnectionState.Open)
                {
                    Conexao.Close();
                }
            }
        }
    }
}
