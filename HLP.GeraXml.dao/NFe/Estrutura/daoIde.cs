using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HLP.GeraXml.Comum.Static;
using System.Data;
using HLP.GeraXml.dao.ADO;

namespace HLP.GeraXml.dao.NFe.Estrutura
{
    public class daoIde
    {
        public DataTable BuscaIde(string sNF)
        {           
            try
            {
                StringBuilder sSql = new StringBuilder();
                //Campos do Select
                sSql.Append("Select First 1 ");
                sSql.Append("coalesce(tpdoc.st_ref_outra_nf,'S') st_ref_outra_nf, ");
                sSql.Append("uf.nr_ufnfe cUF, ");
                sSql.Append("nf.cd_nfseq cNF, ");
                sSql.Append("nf.ds_cfop natop, ");
                sSql.Append("coalesce(PRAZOS.ST_FPAGNFE,0) indPag, ");
                sSql.Append("'55' mod, ");
                sSql.Append("coalesce(nf.cd_serie, 1) serie, ");
                sSql.Append("nf.cd_notafis nNF, ");
                sSql.Append("nf.dt_emi dEmi, ");
                sSql.Append("nf.dt_sainf dSaiEnt, ");
                sSql.Append("case when tpdoc.tp_doc = 'NS' then '1' else '0' end tpNF, ");
                sSql.Append("cidades.cd_municipio cMunFg, ");
                sSql.Append("'1' tpImp, ");
                sSql.Append("'1' tpEmis, ");
                sSql.Append("coalesce(empresa.st_ambiente, '2') tpAmb, ");
                sSql.Append("case when tpdoc.st_nfcompl = 'S' then '2' else '1' end finNFe, ");
                sSql.Append("'0' procEmi, ");
                sSql.Append("'");
                sSql.Append(Acesso.versaoNFe);
                sSql.Append("' verProc ");
                //Tabela
                sSql.Append("From NF ");
                //Relacionamentos
                sSql.Append("left join tpdoc on (tpdoc.cd_tipodoc = nf.cd_tipodoc)");
                sSql.Append("inner join empresa on (empresa.cd_empresa = nf.cd_empresa)");
                sSql.Append("left join uf on (uf.cd_uf = empresa.cd_ufnor)");
                sSql.Append("left join cidades on (cidades.nm_cidnor = empresa.nm_cidnor)");
                sSql.Append(" and ");
                sSql.Append("(cidades.cd_ufnor = empresa.cd_ufnor) ");
                sSql.Append("left join  prazos on (prazos.cd_prazo = nf.cd_prazo)");
                //Where
                sSql.Append("Where ");
                sSql.Append("(nf.cd_empresa ='");
                sSql.Append(Acesso.CD_EMPRESA);
                sSql.Append("')");
                sSql.Append(" and ");
                sSql.Append("(nf.cd_nfseq = '");
                sSql.Append(sNF);
                sSql.Append("') ");

                return HlpDbFuncoes.qrySeekRet(sSql.ToString());              
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
    }
}
