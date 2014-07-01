using HLP.GeraXml.dao.ADO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace HLP.GeraXml.dao.CTe.MDFe
{
    public class daoPesquisaManifesto
    {

        public DataTable Execute(string sWhere)
        {
            StringBuilder sQuery = new StringBuilder();
            sQuery.Append("Select ");
            sQuery.Append("m.cd_empresa, ");
            sQuery.Append("coalesce(m.CD_PROTMDFE, '')protocolo, ");
            sQuery.Append("m.cd_manifest sequencia, ");
            sQuery.Append("m.cd_manifisc numero, ");
            sQuery.Append("coalesce(m.CD_CHAVEMDFE,'') chave, ");
            sQuery.Append("m.dt_cad, ");
            sQuery.Append("coalesce(m.cd_recibomdfe,'') recibo, ");
            sQuery.Append("coalesce(m.st_mdfe,'') status, ");
            sQuery.Append("cast(case when m.st_mdfe <> '' then '1' else '0' end as smallint) bEnviado, ");
            sQuery.Append("(case when coalesce(m.cd_recibocanc, '') = '' then '0' else '1' end) bCancelado , ");
            sQuery.Append("v.cd_placa descricao ");
            sQuery.Append("from manifest m inner join veiculo v on m.cd_veiculo = v.cd_veiculo where {0}");

            return HlpDbFuncoes.qrySeekRet(string.Format(sQuery.ToString(), sWhere));
        }
    }
}
