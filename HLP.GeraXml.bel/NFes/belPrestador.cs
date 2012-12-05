using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HLP.GeraXml.dao.NFes;
using System.Data;

namespace HLP.GeraXml.bel.NFes
{
    public class belPrestador : daoPrestador
    {
        public tcIdentificacaoPrestador RettcIdentificacaoPrestador(string sNota)
        {
            try
            {
                tcIdentificacaoPrestador objtcIdentificacaoPrestador = new tcIdentificacaoPrestador();
                DataTable dt = BuscaDadosPrestador();
                foreach (DataRow dr in dt.Rows)
                {

                    if (dr["cd_cgc"] != null)
                    {
                        objtcIdentificacaoPrestador.Cnpj = dr["cd_cgc"].ToString();
                    }
                    else
                    {
                        throw new Exception("Prestador cadastrado sem CNPJ, Item é obrigatório!");
                    }
                    if (dr["cd_inscrmu"] != null)
                    {
                        objtcIdentificacaoPrestador.InscricaoMunicipal = dr["cd_inscrmu"].ToString();
                    }
                }
                return objtcIdentificacaoPrestador;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
