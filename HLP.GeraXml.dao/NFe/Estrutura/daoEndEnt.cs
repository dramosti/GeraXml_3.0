using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HLP.GeraXml.Comum.Static;

namespace HLP.GeraXml.dao.NFe.Estrutura
{
    public class daoEndEnt
    {
        public DataTable BuscaEndEnt(string seqNF)
        {
            try
            {
                StringBuilder sSql = new StringBuilder();
                //Campos do Select
                sSql.Append("Select ");
                sSql.Append("case when endentr.cd_cgcent is not null then ");
                sSql.Append("endentr.cd_cgcent ");
                sSql.Append("else ");
                sSql.Append("nf.cd_cgc ");
                sSql.Append("end CNPJ, ");
                sSql.Append("endentr.ds_endent xLgr, ");
                sSql.Append("endentr.nr_endent nro, ");
                sSql.Append("endentr.nm_bairroent xBairro, ");
                sSql.Append("cidades.cd_municipio cMun, ");
                sSql.Append("cidades.nm_cidnor xMun, ");
                sSql.Append("endentr.cd_ufent UF ");
                //Tabela
                sSql.Append("From nf ");

                //Relacionamentos
                sSql.Append("inner join endentr on (endentr.cd_cliente = nf.cd_clifor) ");
                sSql.Append("and ");
                sSql.Append(" (endentr.cd_endent = nf.cd_endent) ");
                sSql.Append("inner join cidades on (cidades.nm_cidnor = endentr.nm_cident) ");
                sSql.Append("and ");
                sSql.Append("(cidades.cd_ufnor = endentr.cd_ufent) ");

                //Where
                sSql.Append("Where ");
                sSql.Append("(nf.cd_empresa ='");
                sSql.Append(Acesso.CD_EMPRESA);
                sSql.Append("') ");
                sSql.Append(" and ");
                sSql.Append("(nf.cd_nfseq ='");
                sSql.Append(seqNF);
                sSql.Append("') ");

                return HLP.GeraXml.dao.ADO.HlpDbFuncoes.qrySeekRet(sSql.ToString());                
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
    }
}
