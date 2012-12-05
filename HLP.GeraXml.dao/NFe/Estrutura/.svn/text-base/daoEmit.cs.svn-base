using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HLP.GeraXml.Comum.Static;

namespace HLP.GeraXml.dao.NFe.Estrutura
{
    public class daoEmit
    {
        public DataTable BuscaEmit(string seqNfe)
        {
            try
            {
                //Conn.Open();
                StringBuilder sSql = new StringBuilder();

                //Campos do Select
                sSql.Append("Select ");
                sSql.Append("coalesce(empresa.cd_regime_tributacao,0) CRT, "); 
                sSql.Append("empresa.cd_cgc CNPJ, ");
                sSql.Append("empresa.nm_empresa xNome, ");
                sSql.Append("empresa.nm_guerra xFant, ");
                sSql.Append("empresa.ds_endnor xLgr, ");
                sSql.Append("empresa.ds_endcomp nro, ");
                sSql.Append("empresa.nm_bairronor xBairro, ");
                sSql.Append("cidades.cd_municipio cMun, ");
                sSql.Append("cidades.nm_cidnor xMun, ");
                sSql.Append("empresa.cd_ufnor uf, ");
                sSql.Append("empresa.cd_cepnor cep, ");
                sSql.Append("pais.cd_pais cPais, ");
                sSql.Append("pais.ds_pais xPais, ");
                sSql.Append("empresa.cd_fonenor fone, ");
                sSql.Append("empresa.cd_insest IE ");
                sSql.Append(", (select NF.CD_INSC_SUBSTITUTO from nf where nf.cd_empresa = '");
                sSql.Append(Acesso.CD_EMPRESA);
                sSql.Append("' and nf.cd_nfseq = '");
                sSql.Append(seqNfe);
                sSql.Append("') IEST ");

                //Tabela
                sSql.Append("From Empresa ");

                //Relacionamentos
                sSql.Append("left join cidades on (cidades.nm_cidnor = empresa.nm_cidnor) ");
                sSql.Append(" and ");
                sSql.Append("(cidades.cd_ufnor = empresa.cd_ufnor) ");
                sSql.Append("left join pais on (pais.cd_pais = empresa.cd_pais) ");

                //Where
                sSql.Append("Where ");
                sSql.Append("(Empresa.cd_empresa ='");
                sSql.Append(Acesso.CD_EMPRESA);
                sSql.Append("')");

                return HLP.GeraXml.dao.ADO.HlpDbFuncoes.qrySeekRet(sSql.ToString());               
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
    }
}
