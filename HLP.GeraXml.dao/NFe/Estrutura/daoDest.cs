using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HLP.GeraXml.Comum.Static;
using HLP.GeraXml.dao.ADO;

namespace HLP.GeraXml.dao.NFe.Estrutura
{
    public class daoDest
    {
        public DataTable BuscaDest(string seqNF)
        {
            try
            {
                StringBuilder sSql = new StringBuilder();

                //Campos do Select
                sSql.Append("Select ");
                sSql.Append("case when clifor.cd_ufnor <> 'EX' then clifor.cd_cgc else 'EXTERIOR' END CNPJ, ");
                sSql.Append("case when clifor.cd_ufnor <> 'EX' then clifor.cd_cpf else 'EXTERIOR' end CPF, ");
                sSql.Append("clifor.st_pessoaj, ");
                sSql.Append("coalesce(clifor.st_prodrural,'N') st_prodrural, "); //OS_27026
                sSql.Append("clifor.nm_clifor xNome, ");
                sSql.Append("coalesce(clifor.nm_complemento,'') xCpl, ");
                sSql.Append( HlpDbFuncoes.fExisteCampo("TP_LOGRADOURO","CLIFOR") ? "clifor.TP_LOGRADOURO tpLgr, " : "'' tpLgr, ");
                sSql.Append("clifor.nm_guerra xFant, ");
                sSql.Append("clifor.ds_endnor xlgr, ");
                sSql.Append("clifor.nr_endnor nro, ");
                sSql.Append("clifor.cd_email email, "); // NFe_2.0
                sSql.Append("clifor.nm_bairronor xBairro, ");
                sSql.Append("case when clifor.cd_ufnor <> 'EX' then cidades.cd_municipio else '9999999' END cMun, ");
                sSql.Append("case when clifor.cd_ufnor <> ' EX' then cidades.nm_cidnor else 'EXTERIOR' END xMun, ");
                sSql.Append("clifor.cd_ufnor uf, ");
                sSql.Append("clifor.cd_cepnor cep, ");
                sSql.Append("case when pais.cd_pais is null then ");
                sSql.Append("(select cd_pais from pais where pais.ds_pais = 'BRASIL') ");
                sSql.Append("else ");
                sSql.Append("pais.cd_pais END ");
                sSql.Append(" cPais, ");
                sSql.Append("pais.ds_pais xPais, ");
                sSql.Append("clifor.cd_fonenor fone, ");
                sSql.Append("case when clifor.cd_ufnor <> 'EX' then clifor.cd_insest else 'EXTERIOR' END IE, ");
                sSql.Append("clifor.cd_suframa ");
                //Tabela
                sSql.Append("From nf ");

                //Relacionamentos
                sSql.Append("inner join clifor on (clifor.cd_clifor = nf.cd_clifor) ");
                //sSql.Append("left join cidades on (cidades.nm_cidnor = clifor.nm_cidnor) ");
                sSql.Append("left join cidades on (cidades.cd_municipio = clifor.cd_municipio) ");
                //cidades.cd_municipio = clifor.cd_municipio
                sSql.Append(" and (cidades.cd_ufnor = clifor.cd_ufnor) ");
                sSql.Append("left join pais on (pais.cd_pais = clifor.cd_pais) ");

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

        public string BuscaTipoLogradouro(string sValor)
        {
            try
            {
                string sTpLgr = HlpDbFuncoes.qrySeekValue("HLPSTATUS", "ds_descvalor", "ds_referencia = 'TP_LOGRADOURO' and ds_valor = '" + sValor + "'");
                return sTpLgr;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
