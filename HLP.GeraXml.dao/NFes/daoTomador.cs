using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HLP.GeraXml.Comum.Static;
using HLP.GeraXml.dao.ADO;

namespace HLP.GeraXml.dao.NFes
{
    public class daoTomador
    {
        public DataTable BuscaDadosTomador(string sNota)
        {
            try
            {
                StringBuilder sQuery = new StringBuilder();
                sQuery.Append(" Select ");
                sQuery.Append("clifor.cd_cgc, ");
                sQuery.Append("clifor.cd_cpf, ");
                sQuery.Append("coalesce(clifor.cd_inscrmu,'') cd_inscrmu, ");
                sQuery.Append("clifor.nm_clifor RazaoSocial, ");
                sQuery.Append("clifor.ds_endnor Endereco, ");
                sQuery.Append("clifor.nr_endnor Numero, ");
                sQuery.Append("clifor.nm_bairronor Bairro, ");
                sQuery.Append("cidades.cd_municipio  CodigoMunicipio, ");
                sQuery.Append("clifor.cd_ufnor  Uf, ");
                sQuery.Append("clifor.cd_cepnor Cep, ");
                sQuery.Append("clifor.cd_fonenor Telefone, ");
                sQuery.Append("clifor.cd_email Email ");
                sQuery.Append(" from  nf inner join clifor on nf.cd_clifor = clifor.cd_clifor");
                sQuery.Append(" left join cidades on (cidades.cd_municipio = clifor.cd_municipio) ");
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
