using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HLP.GeraXml.Comum.Static;

namespace HLP.GeraXml.dao.NFe
{
    public class daoInutilizacao
    {
        public void InseriRegistroInutilizado(string sNFini, string sNFfim, string sCdSerie, string sJust)
        {
            try
            {
                daoGenerator objGen = new daoGenerator();
                string sPK = "";
                if (!objGen.VerificaExistenciaGenerator("GEN_INUTILIZACAO"))
                {
                    objGen.CreateGenerator("GEN_INUTILIZACAO", 0);
                }
                sPK = objGen.RetornaProximoValorGenerator("GEN_INUTILIZACAO").PadLeft(7, '0');

                StringBuilder sQuery = new StringBuilder();
                sQuery.Append("INSERT INTO nfinutilizada (");
                sQuery.Append("CD_EMPRESA, ");
                sQuery.Append("CD_NFSEQINUT, ");
                sQuery.Append("CD_CODFISC, ");
                sQuery.Append("CD_NOTAFISFIM, ");
                sQuery.Append("CD_NOTAFISINI, ");
                sQuery.Append("CD_SERIENF, ");
                sQuery.Append("CD_STDOC, ");
                sQuery.Append("DT_CAD, ");
                sQuery.Append("TP_EMIT, ");
                sQuery.Append("TP_NOTA, ");
                sQuery.Append("DS_INUTILIZACAO");
                sQuery.Append(")");
                sQuery.Append("VALUES ( '{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}');");

                string sInsert = string.Format(sQuery.ToString(),
                                    Acesso.CD_EMPRESA,
                                    sPK,
                                    "55",
                                    Convert.ToUInt32(sNFfim).ToString().PadLeft(6, '0'),
                                    Convert.ToUInt32(sNFini).ToString().PadLeft(6, '0'),
                                    sCdSerie,
                                    "5",
                                    DateTime.Now.ToString("dd.MM.yyyy"),
                                    "0",
                                    "0",
                                    sJust);

                if (HLP.GeraXml.dao.ADO.HlpDbFuncoes.fExisteCampo("DS_INUTILIZACAO", "nfinutilizada"))
                {
                    HLP.GeraXml.dao.ADO.HlpDbFuncoes.qrySeekInsert(sInsert);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
