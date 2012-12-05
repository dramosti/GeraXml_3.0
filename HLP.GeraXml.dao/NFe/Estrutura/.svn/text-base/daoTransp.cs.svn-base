using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HLP.GeraXml.Comum.Static;

namespace HLP.GeraXml.dao.NFe.Estrutura
{
    public class daoTransp
    {
        public DataTable BuscaFrete(string seqNF)
        {
            try
            {
                StringBuilder sSql = new StringBuilder();

                //Campos do Select
                sSql.Append("Select ");
                sSql.Append("coalesce(nf.st_frete, 0) modFrete, ");
                sSql.Append("transpor.nm_trans xNome, ");
                sSql.Append("transpor.st_pessoaj, ");
                sSql.Append("transpor.cd_cpf, ");
                sSql.Append("transpor.cd_cgc CNPJ, ");
                sSql.Append("transpor.nm_trans xNome, ");
                sSql.Append("transpor.cd_insest IE, ");
                sSql.Append("transpor.ds_endnor xEnder, ");
                sSql.Append("transpor.nm_cidnor xMun, ");
                sSql.Append("transpor.cd_ufnor UF, ");
                sSql.Append("coalesce(nf.qt_volumes, 0) qVol, ");
                sSql.Append((Acesso.NM_EMPRESA == "ZINCOBRIL" ? "coalesce(nf.ds_especie, '') esp, " : "coalesce(nf.ds_especie, 'VOLUME') esp, "));
                sSql.Append("COALESCE(nf.vl_pesoliq, 0) pesoL, ");
                sSql.Append("COALESCE(nf.vl_pesobru,0) pesoB, ");
                sSql.Append((Acesso.NM_EMPRESA == "ZINCOBRIL" ? "COALESCE(nf.ds_marca, '') marca, " : "COALESCE(nf.ds_marca, 'MARCA') marca, "));
                sSql.Append("CASE WHEN COALESCE (NF.cd_placa, '') <> '' then NF.cd_placa ELSE TRANSPOR.cd_placa END placa,");
                sSql.Append("transpor.cd_ufvei UF, ");
                sSql.Append("transpor.ds_rntc RNTC ");
                sSql.Append(", coalesce(nf.ds_numero,'') nVol ");
                sSql.Append("From NF ");
                sSql.Append("inner join transpor on (transpor.cd_trans = nf.cd_trans) ");
                sSql.Append("Where ");
                sSql.Append("(NF.cd_empresa ='");
                sSql.Append(Acesso.CD_EMPRESA);
                sSql.Append("')");
                sSql.Append(" and ");
                sSql.Append("(nf.cd_nfseq = '");
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
