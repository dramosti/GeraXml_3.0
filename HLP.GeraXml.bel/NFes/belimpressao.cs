using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HLP.GeraXml.dao.NFes;
using System.Data;

namespace HLP.GeraXml.bel.NFes
{
    public class belimpressao : daoImpressao
    {
        public string sNfSeq { get; set; }
        public string sVerificacao { get; set; }
        public string sNota { get; set; }
        public bool bCanc { get; set; }
        public DateTime dtEnvio { get; set; }


        public List<belimpressao> BuscaDadosParaImpressao(List<belimpressao> objLista)
        {
            try
            {
                for (int i = 0; i < objLista.Count; i++)
                {
                    DataTable dt = BuscaDados(objLista[i].sNfSeq);

                    foreach (DataRow dr in dt.Rows)
                    {
                        objLista[i].sNota = dr["cd_numero_nfse"].ToString();
                        objLista[i].sVerificacao = dr["cd_verificacao_nfse"].ToString();
                    }
                }
                return objLista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
