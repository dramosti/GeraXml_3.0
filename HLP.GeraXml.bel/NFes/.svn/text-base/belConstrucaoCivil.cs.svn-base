using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HLP.GeraXml.dao.NFes;
using System.Data;

namespace HLP.GeraXml.bel.NFes
{
    public class belConstrucaoCivil : daoConstrucaoCivil
    {
        public tcDadosConstrucaoCivil RettcDadosConstrucaoCivil(string sNota)
        {

            try
            {
                DataTable dt = BuscaDadosContrucaoCivil(sNota);

                tcDadosConstrucaoCivil objtcDadosConstrucaoCivil = new tcDadosConstrucaoCivil();
                foreach (DataRow dr in dt.Rows)
                {
                    objtcDadosConstrucaoCivil.Art = dr["Art"].ToString();
                    objtcDadosConstrucaoCivil.CodigoObra = dr["CodigoObra"].ToString();
                }
                return objtcDadosConstrucaoCivil;


            }
            catch (Exception)
            {
                throw;
            }


        }
    }
}
