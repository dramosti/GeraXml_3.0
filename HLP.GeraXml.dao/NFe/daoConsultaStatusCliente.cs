using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HLP.GeraXml.Comum.Static;

namespace HLP.GeraXml.dao.NFe
{
    public class daoConsultaStatusCliente
    {
        public DataTable BuscaInformacoesCliente(string seqNF)
        {
            StringBuilder sQuery = new StringBuilder();
            sQuery.Append("SELECT coalesce(clifor.cd_cgc,'')sCNPJ ,coalesce(clifor.cd_insest,'')sIE ,coalesce(clifor.cd_cpf,'')sCPF ,coalesce(clifor.cd_ufnor,'')sUF from ");
            sQuery.Append(" nf inner join clifor on nf.cd_clifor = clifor.cd_clifor ");
            sQuery.Append("where nf.cd_empresa = '");
            sQuery.Append(Acesso.CD_EMPRESA + "' and nf.cd_nfseq = '");
            sQuery.Append(seqNF + "'");

            return HLP.GeraXml.dao.ADO.HlpDbFuncoes.qrySeekRet(sQuery.ToString());
        }
    }
}
