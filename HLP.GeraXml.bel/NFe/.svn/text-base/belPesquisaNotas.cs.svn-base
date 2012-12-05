using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HLP.GeraXml.dao.ADO;
using System.Data;
using HLP.GeraXml.Comum.Static;

namespace HLP.GeraXml.bel.NFe
{
    public class belPesquisaNotas : dao.NFe.daoPesquisaNotas
    {
        public enum status { Enviados, NaoEnviados, Ambos };
        public enum Filtro { Data, Sequencia, Cliente };
        /// <summary>
        /// Chave de Retorno
        /// </summary>
        public string sCHAVENFE { get; set; }
        public bool bSeleciona { get; set; }
        public string sCD_NOTAFIS { get; set; }
        public string sCD_NFSEQ { get; set; }
        public string sCD_GRUPONF { get; set; }
        public DateTime dDT_EMI { get; set; }
        public string sNM_CLIFOR { get; set; }
        public double dVL_TOTNF { get; set; }
        public bool bCancelado { get; set; }
        /// <summary>
        /// ST_NFE
        /// </summary>
        public bool bEnviado { get; set; }
        /// <summary>
        /// st_contingencia
        /// </summary>
        public bool bContingencia { get; set; }
        public bool bDenegada { get; set; }
        public string sRECIBO_NF { get; set; }

        public List<belPesquisaNotas> lResultPesquisa = new List<belPesquisaNotas>();

        public belPesquisaNotas() { }

        public belPesquisaNotas(status _st, Filtro _fl, string _sValor1, string _sValor2)
        {
            lResultPesquisa = new List<belPesquisaNotas>();
            List<HlpDbFuncoes.ListaCampos> lCampos = new List<HlpDbFuncoes.ListaCampos>();
            lCampos.Add(new HlpDbFuncoes.ListaCampos { sCampo = "cd_chavenfe", sAlias = "sCHAVENFE", sCoalesce = "" });
            lCampos.Add(new HlpDbFuncoes.ListaCampos { sCampo = "cd_notafis", sAlias = "sCD_NOTAFIS" });
            lCampos.Add(new HlpDbFuncoes.ListaCampos { sCampo = "cd_nfseq", sAlias = "sCD_NFSEQ" });
            lCampos.Add(new HlpDbFuncoes.ListaCampos { sCampo = "dt_emi", sAlias = "dDT_EMI" });
            lCampos.Add(new HlpDbFuncoes.ListaCampos { sCampo = "NM_CLIFOR", sAlias = "sNM_CLIFOR" });
            lCampos.Add(new HlpDbFuncoes.ListaCampos { sCampo = "vl_totnf", sAlias = "dVL_TOTNF" });
            lCampos.Add(new HlpDbFuncoes.ListaCampos { sCampo = "NF.cd_gruponf", sAlias = "sCD_GRUPONF", sCoalesce = "" });
            lCampos.Add(new HlpDbFuncoes.ListaCampos { sCampo = "st_contingencia", sCoalesce = "N", sAlias = "bContingencia" });
            lCampos.Add(new HlpDbFuncoes.ListaCampos { sCampo = "cast(case when nf.st_nfe = 'S' then '1' else '0' end as smallint)", sAlias = "bEnviado" });
            lCampos.Add(new HlpDbFuncoes.ListaCampos { sCampo = "case when coalesce(nf.cd_recibocanc, '') = '' then '0' else '1' end", sAlias = "bCancelado" });
            if (HlpDbFuncoes.fExisteCampo("ST_DENEGADA", "NF"))
            {
                lCampos.Add(new HlpDbFuncoes.ListaCampos { sCampo = "case when coalesce(nf.st_denegada, 'N') = 'N' then '0' else '1' end", sAlias = "bDenegada" });
            }
            else
            {
                lCampos.Add(new HlpDbFuncoes.ListaCampos { sCampo = "0", sAlias = "bDenegada" });
            }
            lCampos.Add(new HlpDbFuncoes.ListaCampos { sCampo = "coalesce(cd_recibonfe,'')", sAlias = "sRECIBO_NF", sCoalesce = "" });

            StringBuilder sWhere = new StringBuilder();
            sWhere.Append("cd_empresa = '" + Acesso.CD_EMPRESA + "' and  (coalesce(nf.st_nf_prod,'S') = 'S') and ");
            if (_st != status.Ambos)
            {
                sWhere.Append(_st == status.NaoEnviados ? "(nf.st_nfe = 'N' or nf.st_nfe is null or nf.st_nfe = '') and " : "nf.st_nfe = 'S' and ");
            }
            if (_fl == Filtro.Data)
            {
                sWhere.Append("(dt_emi between '" + Convert.ToDateTime(_sValor1).ToString("dd.MM.yyyy") + "' and '" + Convert.ToDateTime(_sValor2).ToString("dd.MM.yyyy") + "')");
            }
            else if (_fl == Filtro.Sequencia)
            {
                sWhere.Append("(nf.cd_nfseq between '" + _sValor1 + "' and '" + _sValor2 + "') ");
            }
            else if (_fl == Filtro.Cliente)
            {
                sWhere.Append("clifor.nm_clifor like('%" + _sValor1.ToUpper() + "%')");
            }
            sWhere.Append(" order by cd_notafis desc");

            DataTable dt = HlpDbFuncoes.qrySeekRet("NF inner join clifor on nf.cd_clifor = clifor.cd_clifor ", "", sWhere.ToString(), lCampos);

            foreach (DataRow dr in dt.Rows)
            {
                lResultPesquisa.Add(new belPesquisaNotas
                {
                    sCHAVENFE = dr["sCHAVENFE"].ToString(),
                    sCD_NFSEQ = dr["sCD_NFSEQ"].ToString(),
                    sCD_NOTAFIS = dr["sCD_NOTAFIS"].ToString(),
                    sNM_CLIFOR = dr["sNM_CLIFOR"].ToString(),
                    sCD_GRUPONF = dr["sCD_GRUPONF"].ToString(),
                    dVL_TOTNF = Convert.ToDouble(dr["dVL_TOTNF"].ToString()),
                    dDT_EMI = Convert.ToDateTime(dr["dDT_EMI"].ToString()),
                    bEnviado = dr["bEnviado"].ToString().Equals("0") ? false : true,
                    bContingencia = (dr["bContingencia"].ToString().Equals("N") || dr["bContingencia"].ToString().Equals("")) ? false : true,
                    bCancelado = dr["bCancelado"].ToString().Equals("1") ? true : false,
                    bDenegada = dr["bDenegada"].ToString().Equals("1") ? true : false,
                    bSeleciona = false,
                    sRECIBO_NF = dr["sRECIBO_NF"].ToString()

                });
            }

        }

        public belPesquisaNotas(status _st, Filtro _fl, string _sValor1, string _sValor2, bool NotaServico)
        {
            lResultPesquisa = new List<belPesquisaNotas>();
            List<HlpDbFuncoes.ListaCampos> lCampos = new List<HlpDbFuncoes.ListaCampos>();
            lCampos.Add(new HlpDbFuncoes.ListaCampos { sCampo = "cd_notafis", sAlias = "sCD_NOTAFIS" });
            lCampos.Add(new HlpDbFuncoes.ListaCampos { sCampo = "cd_nfseq", sAlias = "sCD_NFSEQ" });
            lCampos.Add(new HlpDbFuncoes.ListaCampos { sCampo = "dt_emi", sAlias = "dDT_EMI" });
            lCampos.Add(new HlpDbFuncoes.ListaCampos { sCampo = "nm_guerra", sAlias = "sNM_CLIFOR" });
            lCampos.Add(new HlpDbFuncoes.ListaCampos { sCampo = "coalesce(cd_chavenfe,'')", sAlias = "sCHAVENFE" });
            lCampos.Add(new HlpDbFuncoes.ListaCampos { sCampo = "vl_totnf", sAlias = "dVL_TOTNF" });
            lCampos.Add(new HlpDbFuncoes.ListaCampos { sCampo = "NF.cd_gruponf", sAlias = "sCD_GRUPONF", sCoalesce = "" });
            lCampos.Add(new HlpDbFuncoes.ListaCampos { sCampo = "cast(case when nf.st_nfe = 'S' then '1' else '0' end as smallint)", sAlias = "bEnviado" });
            lCampos.Add(new HlpDbFuncoes.ListaCampos { sCampo = "case when coalesce(nf.cd_recibocanc, '') = '' then '0' else '1' end", sAlias = "bCancelado" });
            lCampos.Add(new HlpDbFuncoes.ListaCampos { sCampo = "cd_recibonfe", sAlias = "sRECIBO_NF", sCoalesce = "" });

            StringBuilder sWhere = new StringBuilder();
            sWhere.Append("cd_empresa = '" + Acesso.CD_EMPRESA + "' and  (coalesce(nf.st_nf_prod,'S') = 'N') and ");
            if (_st != status.Ambos)
            {
                sWhere.Append(_st == status.NaoEnviados ? "(nf.st_nfe = 'N' or nf.st_nfe is null) and " : "nf.st_nfe = 'S' and ");
            }
            if (_fl == Filtro.Data)
            {
                sWhere.Append("(dt_emi between '" + Convert.ToDateTime(_sValor1).ToString("dd.MM.yyyy") + "' and '" + Convert.ToDateTime(_sValor2).ToString("dd.MM.yyyy") + "')");
            }
            else
            {
                sWhere.Append("(nf.cd_nfseq between '" + _sValor1 + "' and '" + _sValor2 + "')");
            }
            sWhere.Append(" order by cd_notafis desc");

            DataTable dt = HlpDbFuncoes.qrySeekRet("NF", "", sWhere.ToString(), lCampos);

            foreach (DataRow dr in dt.Rows)
            {
                lResultPesquisa.Add(new belPesquisaNotas
                {
                    sCD_NFSEQ = dr["sCD_NFSEQ"].ToString(),
                    sCD_NOTAFIS = dr["sCD_NOTAFIS"].ToString(),
                    sNM_CLIFOR = dr["sNM_CLIFOR"].ToString(),
                    sCD_GRUPONF = dr["sCD_GRUPONF"].ToString(),
                    dVL_TOTNF = Convert.ToDouble(dr["dVL_TOTNF"].ToString()),
                    dDT_EMI = Convert.ToDateTime(dr["dDT_EMI"].ToString()),
                    bEnviado = dr["bEnviado"].ToString().Equals("0") ? false : true,
                    bCancelado = dr["bCancelado"].ToString().Equals("1") ? true : false,
                    bSeleciona = false,
                    sRECIBO_NF = dr["sRECIBO_NF"].ToString(),
                    sCHAVENFE = dr["sCHAVENFE"].ToString()
                });
            }

        }

        public void AlteraStatusNotaParaContingenciaFS()
        {
            base.AlteraStatusNotaParaContingenciaFS(this.sCD_NFSEQ);
        }

    }
}
