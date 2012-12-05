using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HLP.GeraXml.Comum.Static;
using HLP.GeraXml.dao.ADO;

namespace HLP.GeraXml.dao.NFes
{
    public class daoLoteRps
    {
        public DataTable BuscaDadosNota(string sNota)
        {
            try
            {
                StringBuilder sQuery = new StringBuilder();
                sQuery.Append("SELECT   coalesce (tpdoc.cd_natureza_oper_nfse,'1')cd_natureza_oper_nfse , ");
                sQuery.Append("coalesce (empresa.st_simples,'')st_simples , ");
                sQuery.Append("coalesce (empresa.cd_regime_trib_especial,'0')RegimeEspecialTributacao , ");
                sQuery.Append("coalesce (empresa.st_insentivador_cultural,'N')st_insentivador_cultural from nf ");
                sQuery.Append("inner join tpdoc on nf.cd_tipodoc = tpdoc.cd_tipodoc ");
                sQuery.Append("inner join empresa on empresa.cd_empresa = nf.cd_empresa ");
                sQuery.Append(" where nf.cd_nfseq = '" + sNota + "' and ");
                sQuery.Append(" nf.cd_empresa = '" + Acesso.CD_EMPRESA + "'");
                
                return HlpDbFuncoes.qrySeekRet(sQuery.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
