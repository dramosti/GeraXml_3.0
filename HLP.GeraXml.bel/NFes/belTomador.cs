using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HLP.GeraXml.dao.NFes;
using System.Data;
using HLP.GeraXml.Comum.Static;

namespace HLP.GeraXml.bel.NFes
{
    public class belTomador : daoTomador
    {
        public tcDadosTomador RettcDadosTomador(string sNota)
        {
            try
            {
                DataTable dt = BuscaDadosTomador(sNota);

                tcDadosTomador objtcDadosTomador = new tcDadosTomador();
                foreach (DataRow dr in dt.Rows)
                {

                    #region tcIdentificacaoTomador
                    objtcDadosTomador.IdentificacaoTomador = new tcIdentificacaoTomador();
                    if ((dr["cd_cgc"] != null) || (dr["cd_cpf"] != null))
                    {
                        objtcDadosTomador.IdentificacaoTomador.CpfCnpj = new TcCpfCnpj();
                        if ((dr["cd_cgc"].ToString() != ""))
                        {
                            objtcDadosTomador.IdentificacaoTomador.CpfCnpj.Cnpj = dr["cd_cgc"].ToString();
                        }
                        else
                        {
                            objtcDadosTomador.IdentificacaoTomador.CpfCnpj.Cpf = dr["cd_cpf"].ToString();
                        }
                    }
                    if (dr["cd_inscrmu"] != null)
                    {
                        objtcDadosTomador.IdentificacaoTomador.InscricaoMunicipal = dr["cd_inscrmu"].ToString();
                    }
                    #endregion

                    objtcDadosTomador.RazaoSocial = dr["RazaoSocial"].ToString();

                    #region TcEndereco
                    objtcDadosTomador.Endereco = new TcEndereco();
                    if (dr["Endereco"] != null) { objtcDadosTomador.Endereco.Endereco = dr["Endereco"].ToString(); }
                    if (dr["Numero"] != null) { objtcDadosTomador.Endereco.Numero = dr["Numero"].ToString(); }
                    if (dr["Bairro"] != null) { objtcDadosTomador.Endereco.Bairro = dr["Bairro"].ToString(); }
                    if (dr["CodigoMunicipio"] != null) { objtcDadosTomador.Endereco.CodigoMunicipio = Convert.ToInt32(dr["CodigoMunicipio"].ToString()); }
                    if (dr["Uf"] != null) { objtcDadosTomador.Endereco.Uf = dr["Uf"].ToString(); }
                    if (dr["Cep"] != null) { objtcDadosTomador.Endereco.Cep = Util.TiraSimbolo(dr["Cep"].ToString(), ""); }
                    #endregion

                    #region TcContato
                    objtcDadosTomador.Contato = new TcContato();
                    if (dr["Telefone"] != null) { objtcDadosTomador.Contato.Telefone = dr["Telefone"].ToString(); }
                    if (dr["Email"] != null) { objtcDadosTomador.Contato.Email = dr["Email"].ToString(); }


                    #endregion
                }

                return objtcDadosTomador;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
