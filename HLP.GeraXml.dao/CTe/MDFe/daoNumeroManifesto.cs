using HLP.GeraXml.Comum.Static;
using HLP.GeraXml.dao.ADO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace HLP.GeraXml.dao.CTe.MDFe
{
    public class daoNumeroManifesto
    {
        public string BuscaUltimoNumeroConhecimento()
        {

            try
            {
                string sQuery = "";
                string sGenerator = "MANIFESTO_MDFE" + Acesso.CD_EMPRESA;
                sQuery = "SELECT GEN_ID(" + sGenerator + ", 0 ) FROM RDB$DATABASE";
                return HlpDbFuncoes.qrySeekRet(sQuery).Rows[0][0].ToString(); ;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public void GravaNumeroManifesto(string sequencia, string numero)
        {
            try
            {
                string sQuery = string.Empty;
                sQuery = "update manifest set  cd_manifisc = '" + numero.PadLeft(9, '0') + "' "
                            + "where cd_empresa = '" + Acesso.CD_EMPRESA + "' "
                            + "and cd_manifest = '" + sequencia.PadLeft(7, '0') + "'";
                HlpDbFuncoes.qrySeekUpdate(sQuery);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public void AtualizaGenerator(string sValue)
        {
            try
            {
                string sGenerator = "MANIFESTO_MDFE" + Acesso.CD_EMPRESA; ;
                string sQuery = "SET GENERATOR " + sGenerator + " TO " + sValue;

                HlpDbFuncoes.qrySeekReader(sQuery);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
