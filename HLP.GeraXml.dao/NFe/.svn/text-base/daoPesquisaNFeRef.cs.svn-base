using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HLP.GeraXml.Comum.Static;

namespace HLP.GeraXml.dao.NFe
{
    public class daoPesquisaNFeRef
    {
        public DataTable BuscaNotas(int iOperador, int iModelo, string _campoPesquisa, string sfiltro) 
        {
            try
            {
                StringBuilder sSql = new StringBuilder();
                sSql.Append("select ");
                sSql.Append("nf.cd_nfseq NFSEQ, ");
                sSql.Append("nf.cd_notafis nNF, ");
                sSql.Append("nf.cd_chavenfe CHAVE, ");
                sSql.Append("nf.nm_clifornor, ");
                sSql.Append("nf.cd_ufnor cUF, ");
                sSql.Append("nf.dt_emi AAMM, ");
                sSql.Append(" nf.cd_cgc CNPJ, ");
                sSql.Append("coalesce(nf.cd_serie,'') serie ");
                sSql.Append("from nf ");
                sSql.Append("where cd_empresa = '");
                sSql.Append(Acesso.CD_EMPRESA);
                sSql.Append("' ");
                sSql.Append("and ");
                sSql.Append(_campoPesquisa);

                switch (iOperador)
                {
                    case 0:
                        {
                            sSql.Append(" = ");
                            sSql.Append("'");
                            sSql.Append(sfiltro);
                            break;
                        }
                    case 1:
                        {
                            sSql.Append(" > ");
                            sSql.Append("'");
                            sSql.Append(sfiltro);
                            break;
                        }
                    case 2:
                        {
                            sSql.Append(" >= ");
                            sSql.Append("'");
                            sSql.Append(sfiltro);
                            break;
                        }
                    case 3:
                        {
                            sSql.Append(" < ");
                            sSql.Append("'");
                            sSql.Append(sfiltro);
                            break;
                        }
                    case 4:
                        {
                            sSql.Append(" <= ");
                            sSql.Append("'");
                            sSql.Append(sfiltro);
                            break;
                        }
                    case 5:
                        {
                            sSql.Append(" like ");
                            sSql.Append("'%");
                            sSql.Append(sfiltro);
                            sSql.Append("%");
                            break;
                        }
                }
                sSql.Append("' ");
                if (iModelo == 0)
                {
                    sSql.Append("and  ");
                    sSql.Append("nf.st_nfe = 'S'");
                }

                return HLP.GeraXml.dao.ADO.HlpDbFuncoes.qrySeekRet(sSql.ToString());

            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }

        public DataTable BuscaNotasEntrada(int iOperador, int iModelo, string _campoPesquisa, string sfiltro)
        {
            try
            {
                StringBuilder sSql = new StringBuilder();
                sSql.Append("select ");
                sSql.Append("movensai.cd_doc nNF, ");
                sSql.Append("movensai.cd_mov Lancamento, ");
                sSql.Append("movensai.cd_chave_nfe CHAVE, ");
                sSql.Append("clifor.nm_clifor  nm_clifornor, ");
                sSql.Append("clifor.cd_ufnor cUF, ");
                sSql.Append("movensai.dt_emi AAMM, ");
                sSql.Append("clifor.cd_cgc CNPJ, ");
                sSql.Append("movensai.cd_serienf serie ");
                sSql.Append("from movensai  inner join clifor on movensai.cd_clifor = clifor.cd_clifor ");
                sSql.Append("where movensai.cd_empresa = '");
                sSql.Append(Acesso.CD_EMPRESA);
                sSql.Append("' ");
                sSql.Append("and ");
                sSql.Append(_campoPesquisa);
                switch (iOperador)
                {
                    case 0:
                        {
                            sSql.Append(" = ");
                            sSql.Append("'");
                            sSql.Append(sfiltro);
                            break;
                        }
                    case 1:
                        {
                            sSql.Append(" > ");
                            sSql.Append("'");
                            sSql.Append(sfiltro);
                            break;
                        }
                    case 2:
                        {
                            sSql.Append(" >= ");
                            sSql.Append("'");
                            sSql.Append(sfiltro);
                            break;
                        }
                    case 3:
                        {
                            sSql.Append(" < ");
                            sSql.Append("'");
                            sSql.Append(sfiltro);
                            break;
                        }
                    case 4:
                        {
                            sSql.Append(" <= ");
                            sSql.Append("'");
                            sSql.Append(sfiltro);
                            break;
                        }
                    case 5:
                        {
                            sSql.Append(" like ");
                            sSql.Append("'%");
                            sSql.Append(sfiltro);
                            sSql.Append("%");
                            break;
                        }
                }

                sSql.Append("' ");
                if (iModelo == 0)
                {
                    sSql.Append("and  ");
                    sSql.Append("movensai.cd_chave_nfe is not null ");
                }

                return HLP.GeraXml.dao.ADO.HlpDbFuncoes.qrySeekRet(sSql.ToString());

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
