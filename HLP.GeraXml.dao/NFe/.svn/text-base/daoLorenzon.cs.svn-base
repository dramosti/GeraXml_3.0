using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HLP.GeraXml.Comum.Static;

namespace HLP.GeraXml.dao.NFe
{
    public class daoLorenzon
    {
        public void AlteraDuplicataLorenzon(string Cdnotafis, string Nfseq)
        {
            try
            {
                StringBuilder sQuery = new StringBuilder();
                sQuery.Append("UPDATE dupnotar SET dupnotar.cd_notafis = '" + Cdnotafis + "' ");
                sQuery.Append("where dupnotar.cd_empresa = '" + Acesso.CD_EMPRESA + "' ");
                sQuery.Append("and dupnotar.cd_nfseq = '" + Nfseq + "'");
                HLP.GeraXml.dao.ADO.HlpDbFuncoes.qrySeekUpdate(sQuery.ToString());
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
