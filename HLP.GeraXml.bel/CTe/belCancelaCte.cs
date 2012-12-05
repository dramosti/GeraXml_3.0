using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HLP.GeraXml.dao.CTe;
using System.Data;
using HLP.GeraXml.Comum.Static;

namespace HLP.GeraXml.bel.CTe
{
    public class belCancelaCte : daoCancelaCte
    {

        private string _versao = "";
        public string versao
        {
            get { return _versao; }
            set { _versao = value; }
        }

        private string _Id = "";
        public string Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        private string _tpAmb = "";
        public string tpAmb
        {
            get { return _tpAmb; }
            set { _tpAmb = value; }
        }

        private string _xServ = "";
        public string xServ
        {
            get { return _xServ; }
            set { _xServ = value; }
        }

        private string _chCTe = "";
        public string chCTe
        {
            get { return _chCTe; }
            set { _chCTe = value; }
        }

        private string _nProt = "";
        public string nProt
        {
            get { return _nProt; }
            set { _nProt = value; }
        }

        private string _xJust = "";
        public string xJust
        {
            get { return _xJust; }
            set { _xJust = value; }
        }

        public belCancelaCte PopulaDadosCancelamento(string sCodConhecimento, string sJustificativa)
        {
            try
            {
                belCancelaCte objBelCancelaCte = new belCancelaCte();
                DataTable dt = BuscaDadosCancelamento(sCodConhecimento, sJustificativa);
                foreach (DataRow dr in dt.Rows)
                {
                    objBelCancelaCte.versao = Acesso.versaoCTe;
                    objBelCancelaCte.Id = "ID" + dr["chCTe"].ToString();
                    objBelCancelaCte.tpAmb = Acesso.TP_AMB.ToString();
                    objBelCancelaCte.xServ = "CANCELAR";
                    objBelCancelaCte.chCTe = dr["chCTe"].ToString();
                    objBelCancelaCte.nProt = dr["nProt"].ToString();
                    objBelCancelaCte.xJust = sJustificativa;
                }

                return objBelCancelaCte;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    }
}
