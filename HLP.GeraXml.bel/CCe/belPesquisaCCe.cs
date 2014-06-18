using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HLP.GeraXml.dao.CCe;
using HLP.GeraXml.Comum.Static;
using System.Data;

namespace HLP.GeraXml.bel.CCe
{
    public class belPesquisaCCe : daoPesquisaCCe
    {
        public string CD_NRLANC { get; set; }
        public string CD_CLIFOR { get; set; }
        public string NM_CLIFOR { get; set; }
        public string CNPJ { get; set; }
        public string CPF { get; set; }
        public string CHNFE { get; set; }

        public string CD_NOTAFIS { get; set; }
        public string CD_NFSEQ { get; set; }
        public DateTime DT_EMI { get; set; }
        public DateTime DT_LANC { get; set; }
        public int QT_ENVIO { get; set; }

        private bool _bSeleciona = false;
        public bool bSeleciona
        {
            get { return _bSeleciona; }
            set { _bSeleciona = value; }
        }


        StringBuilder sQuery = new StringBuilder();
        public enum Campo { cd_notafis, cd_nfseq, cd_conheci, nr_lanc };
        public List<belPesquisaCCe> objLPesquisa = new List<belPesquisaCCe>();

        private void AddCamposAquery()
        {
            sQuery = new StringBuilder();
            sQuery.Append("select ");
            sQuery.Append("cartacor.nr_lanc , ");
            sQuery.Append("cartacor.cd_clifor, ");
            sQuery.Append("clifor.nm_clifor, ");
            sQuery.Append("cartacor.cd_notafis, ");
            sQuery.Append("cartacor.cd_nfseq, ");
            sQuery.Append("cartacor.dt_emi, ");
            sQuery.Append("cartacor.dt_lanc, ");
            sQuery.Append("coalesce(cartacor.QT_ENVIO,0)QT_ENVIO, ");
            sQuery.Append("(case when coalesce(nf.cd_chavenferet,'') = '' then coalesce(nf.cd_chavenfe,'') else coalesce(nf.cd_chavenferet,'') end)CHNFE ");
            sQuery.Append("from cartacor inner join clifor on cartacor.cd_clifor = clifor.cd_clifor ");
            sQuery.Append("              inner join nf on nf.cd_nfseq = cartacor.cd_nfseq and nf.cd_notafis = cartacor.cd_notafis and nf.cd_empresa = cartacor.cd_empresa ");
        }

        private void AddCamposAqueryCte()
        {
            sQuery = new StringBuilder();
            sQuery.Append("select ");
            sQuery.Append("cartacor.nr_lanc , ");
            sQuery.Append("cartacor.cd_clifor, ");
            sQuery.Append("clifor.nm_clifor, ");
            sQuery.Append("cartacor.cd_conhecim cd_notafis, ");
            sQuery.Append("conhecim.nr_lanc cd_nfseq, ");
            sQuery.Append("cartacor.cd_nfseq, ");
            sQuery.Append("cartacor.dt_emi, ");
            sQuery.Append("cartacor.dt_lanc, ");
            sQuery.Append("coalesce(cartacor.QT_ENVIO,0)QT_ENVIO, ");
            sQuery.Append("conhecim.cd_chavecte CHNFE ");
            sQuery.Append("from cartacor left join clifor on cartacor.cd_clifor = clifor.cd_clifor ");
            sQuery.Append("              left join conhecim on  cartacor.cd_conhecim  = conhecim.cd_conheci ");
            sQuery.Append("              and conhecim.cd_empresa = cartacor.cd_empresa ");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dtInicial"></param>
        /// <param name="dtFinal"></param>
        /// <param name="status">Enviado, Pendente</param>
        /// <returns></returns>
        public List<belPesquisaCCe> BuscaCCe(DateTime dtInicial, DateTime dtFinal, string status)
        {
            try
            {

                if (Acesso.NM_RAMO != Acesso.BancoDados.TRANSPORTE)
                {
                    AddCamposAquery();
                    sQuery.Append(string.Format("where coalesce(nf.cd_recibocanc,'') = '' and cartacor.dt_emi between '{0}' and '{1}' and cartacor.cd_empresa = '{2}' ", dtInicial.ToString("dd.MM.yyyy"), dtFinal.ToString("dd.MM.yyyy"), Acesso.CD_EMPRESA));
                }
                else
                {
                    AddCamposAqueryCte();
                    sQuery.Append(string.Format("where conhecim.dt_emi > '01.05.2014' and coalesce(conhecim.cd_recibocanc,'') = '' and cartacor.dt_emi between '{0}' and '{1}' and cartacor.cd_empresa = '{2}' ", dtInicial.ToString("dd.MM.yyyy"), dtFinal.ToString("dd.MM.yyyy"), Acesso.CD_EMPRESA));
                }

                AddWhereStatus(status);
                ExecuteQuery();

                return objLPesquisa;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<belPesquisaCCe> BuscaCCe(string sVl_inicial, string sVl_final, Campo campo, string status)
        {
            try
            {
                if (Acesso.NM_RAMO != Acesso.BancoDados.TRANSPORTE)
                {
                    AddCamposAquery();
                    sQuery.Append(string.Format("where coalesce(nf.cd_recibocanc,'') = '' and cartacor." + campo.ToString() + " between '{0}' and '{1}'  and cartacor.cd_empresa = '{2}'", sVl_inicial, sVl_final, Acesso.CD_EMPRESA));
                }
                else
                {
                    AddCamposAqueryCte();
                    sQuery.Append(string.Format("where coalesce(conhecim.cd_recibocanc,'') = '' and conhecim." + campo.ToString() + " between '{0}' and '{1}'  and cartacor.cd_empresa = '{2}'", sVl_inicial, sVl_final, Acesso.CD_EMPRESA));
                }

                AddWhereStatus(status);
                ExecuteQuery();


                return objLPesquisa;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ExecuteQuery()
        {
            try
            {
                sQuery.Append(" order by cartacor.nr_lanc ");
                objLPesquisa = new List<belPesquisaCCe>();

                DataTable dt = RetornaDados(sQuery);

                foreach (DataRow dr in dt.Rows)
                {
                    objLPesquisa.Add(new belPesquisaCCe
                    {
                        CD_CLIFOR = dr["cd_clifor"].ToString(),
                        CD_NFSEQ = dr["cd_nfseq"].ToString(),
                        CD_NOTAFIS = dr["cd_notafis"].ToString(),
                        CNPJ = Acesso.CNPJ_EMPRESA,
                        CPF = "",
                        CHNFE = dr["CHNFE"].ToString(),
                        DT_EMI = Convert.ToDateTime(dr["dt_emi"].ToString()),
                        DT_LANC = Convert.ToDateTime(dr["dt_lanc"].ToString()),
                        NM_CLIFOR = dr["nm_clifor"].ToString(),
                        CD_NRLANC = dr["nr_lanc"].ToString(),
                        QT_ENVIO = Convert.ToInt32(dr["QT_ENVIO"].ToString())
                    });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void AddWhereStatus(string status)
        {
            if (status.Equals("Enviados"))
            {
                sQuery.Append("and coalesce(cartacor.qt_envio,0) <> 0 ");
            }
            else if (status.Equals("Não Enviados"))
            {
                sQuery.Append("and  coalesce(cartacor.qt_envio,0) = 0 ");
            }
        }
    }
}
