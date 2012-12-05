using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HLP.GeraXml.dao.NFes;
using System.Data;
using HLP.GeraXml.dao;
using HLP.GeraXml.Comum.Static;
using HLP.GeraXml.bel.NFe;

namespace HLP.GeraXml.bel.NFes
{
    public class belLoteRps : daoLoteRps
    {
        public tcLoteRps BuscaDadosNFes(List<belPesquisaNotas> objListaNotas)
        {

            try
            {
                tcLoteRps objLoteRps = new tcLoteRps();

                objLoteRps.Rps = new List<TcRps>();
                foreach (belPesquisaNotas Nota in objListaNotas)
                {
                    TcRps objTcRps = new TcRps();

                    #region IdentificacaoRps - TcIdentificacaoRps

                    beltcIdentificacaoRps objbeltcIdentificacaoRps = new beltcIdentificacaoRps();
                    objTcRps.InfRps = new TcInfRps();

                    objTcRps.InfRps.DataEmissao = daoUtil.GetDateServidor();
                    objTcRps.InfRps.Status = 1;//Normal;

                    DataTable dt = BuscaDadosNota(Nota.sCD_NFSEQ);
                    foreach (DataRow dr in dt.Rows)
                    {
                        objTcRps.InfRps.NaturezaOperacao = Convert.ToInt16(dr["cd_natureza_oper_nfse"].ToString());
                        objTcRps.InfRps.OptanteSimplesNacional = (dr["st_simples"].ToString().Equals("S") ? 1 : 2);
                        objTcRps.InfRps.IncentivadorCultural = (dr["st_insentivador_cultural"].ToString().Equals("S") ? 1 : 2);
                        if (objTcRps.InfRps.OptanteSimplesNacional == 1)
                        {
                            objTcRps.InfRps.RegimeEspecialTributacao = Convert.ToInt16(dr["RegimeEspecialTributacao"].ToString());
                        }
                        else
                        {
                            objTcRps.InfRps.RegimeEspecialTributacao = 0;
                        }
                    }

                    objTcRps.InfRps.IdentificacaoRps = objbeltcIdentificacaoRps.BuscatcIdentificacaoRps(Nota.sCD_NFSEQ);

                    #endregion

                    #region   Servico - TcDadosServico

                    belServico objbelServico = new belServico();
                    objTcRps.InfRps.Servico = objbelServico.RetornaDadosServico(Nota.sCD_NFSEQ, objTcRps.InfRps.NaturezaOperacao);

                    #endregion

                    #region   Prestador - tcIdentificacaoPrestador

                    belPrestador objbelPrestador = new belPrestador();
                    objTcRps.InfRps.Prestador = objbelPrestador.RettcIdentificacaoPrestador(Nota.sCD_NFSEQ);
                    objLoteRps.Cnpj = objTcRps.InfRps.Prestador.Cnpj;
                    objLoteRps.InscricaoMunicipal = objTcRps.InfRps.Prestador.InscricaoMunicipal;

                    #endregion

                    #region Tomador - TcDadosTomador

                    belTomador objbelTomador = new belTomador();
                    objTcRps.InfRps.Tomador = objbelTomador.RettcDadosTomador(Nota.sCD_NFSEQ);

                    #endregion


                    #region  ConstrucaoCivil - TcDadosContrucaoCivil - Tratado na Visualização da Nota

                    if (Acesso.NM_EMPRESA.Equals("AENGE"))
                    {
                        belConstrucaoCivil objbelConstrucaoCivil = new belConstrucaoCivil();
                        objTcRps.InfRps.ConstrucaoCivil = objbelConstrucaoCivil.RettcDadosConstrucaoCivil(Nota.sCD_NFSEQ);
                    }
                    #endregion

                    objLoteRps.Rps.Add(objTcRps);
                }
                daoUtil objdaoUtil = new daoUtil();
                objLoteRps.NumeroLote = objdaoUtil.RetornaProximoValorGenerator("GEN_LOTE_NFES", 15);
                objLoteRps.QuantidadeRps = objLoteRps.Rps.Count;

                return objLoteRps;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
    }
}
