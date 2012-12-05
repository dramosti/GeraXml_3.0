using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HLP.GeraXml.dao.NFes;
using HLP.GeraXml.Comum.Static;
using System.Data;

namespace HLP.GeraXml.bel.NFes
{
    public class beltcIdentificacaoRps : daotcIdentificacaoRps
    {
        public tcIdentificacaoRps BuscatcIdentificacaoRps(string sNfseq)
        {
            try
            {
                tcIdentificacaoRps objtcIdentificacaoRps = new tcIdentificacaoRps();
                DataTable dt = BuscaDadosRps(sNfseq);

                foreach (DataRow dr in dt.Rows)
                {
                    objtcIdentificacaoRps.Nfseq = sNfseq;
                    objtcIdentificacaoRps.Numero = dr["cd_notafis"].ToString();
                    objtcIdentificacaoRps.Serie = dr["cd_serie"].ToString();
                    objtcIdentificacaoRps.Tipo = 1;
                }
                return objtcIdentificacaoRps;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
