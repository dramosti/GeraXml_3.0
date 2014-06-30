using HLP.GeraXml.Comum.Static;
using HLP.GeraXml.dao;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace HLP.GeraXml.bel.MDFe
{
    public class belMunicipios
    {
        public belUF objUf = new belUF();
        public belMunicipios()
        {
        }


        public string xMun { get; set; }
        public string cMun { get; set; }
        private string _xUF;
        public string xUF
        {
            get { return _xUF; }
            set
            {
                _xUF = value;
                objUf.SiglaUF = value;
                this.cUF = objUf.CUF;
            }
        }

        public string cUF { get; set; }



        public static List<belMunicipios> GetMunicipios()
        {
            return daoUtil.GetCidades().AsEnumerable().Select(c =>
                new belMunicipios
                {
                    xMun = c["xMun"].ToString(),
                    cMun = c["cMun"].ToString(),
                    xUF = c["xUF"].ToString()
                }
                ).ToList();
        }

    }
}
