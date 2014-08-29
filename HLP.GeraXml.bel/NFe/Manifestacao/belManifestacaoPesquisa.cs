using HLP.GeraXml.bel.NFe.ClassesSerializadas;
using HLP.GeraXml.Comum.Static;
using HLP.GeraXml.dao;
using HLP.GeraXml.dao.ADO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace HLP.GeraXml.bel.NFe.Manifestacao
{
    public class belManifestacaoPesquisa
    {
        private bool _bSeleciona = false;

        public bool bSeleciona
        {
            get { return _bSeleciona; }
            set { _bSeleciona = value; }
        }

        public string xCd_Clifor { get; set; }

        private string _xChaveNFe;

        public string xChaveNFe
        {
            get { return _xChaveNFe; }
            set
            {
                this.xSerie = Util.GetSerie(value);
                this.xCNPJ = Util.GetCNPJ(value);
                this.xNumero = Util.GetNumeroNFe(value);
                _xChaveNFe = value;

            }
        }


        /// <summary>
        /// preenchida automáticamente
        /// </summary>
        public string xSerie { get; set; }

        /// <summary>
        /// preenchida automáticamente
        /// </summary>
        public string xNumero { get; set; }

        /// <summary>
        /// preenchida automáticamente
        /// </summary>
        public string xCNPJ { get; set; }

        public string xIE { get; set; }

        public string xRazaoSocial { get; set; }

        public DateTime dtEmissao { get; set; }

        private string stManifesto_ = "";

        public string stManifesto
        {
            get { return stManifesto_; }
            set { stManifesto_ = value; }
        }


        public decimal dTotalNFe { get; set; }

        public string sXMLretorno { get; set; }

        public List<belManifestacaoPesquisa> lresult { get; set; }

        public belManifestacaoPesquisa()
        {
        }

        public belManifestacaoPesquisa(Filtro stFiltro, string sValor1, string sValor2)
        {
            try
            {
                this.lresult = new List<belManifestacaoPesquisa>();
                List<HlpDbFuncoes.ListaCampos> lCampos = new List<HlpDbFuncoes.ListaCampos>();
                //ms.vl_totnf,
                lCampos.Add(new HlpDbFuncoes.ListaCampos { sCampo = "ms.vl_totnf", sAlias = "dTotalNFe", sCoalesce = "0" });
                lCampos.Add(new HlpDbFuncoes.ListaCampos { sCampo = "ms.cd_clifor", sAlias = "xCd_Clifor", sCoalesce = "" });
                lCampos.Add(new HlpDbFuncoes.ListaCampos { sCampo = "ms.cd_chave_nfe", sAlias = "xChaveNFe", sCoalesce = "" });
                lCampos.Add(new HlpDbFuncoes.ListaCampos { sCampo = "c.cd_insest", sAlias = "xIE", sCoalesce = "" });
                lCampos.Add(new HlpDbFuncoes.ListaCampos { sCampo = "c.nm_clifor", sAlias = "xRazaoSocial", sCoalesce = "" });
                lCampos.Add(new HlpDbFuncoes.ListaCampos { sCampo = "ms.dt_emi", sAlias = "dtEmissao" });

                StringBuilder sWhere = new StringBuilder();
                sWhere.Append("ms.cd_empresa = '" + Acesso.CD_EMPRESA + "' and ms.cd_chave_nfe is not null and ");

                if (stFiltro == Filtro.Data)
                {
                    sWhere.Append("(ms.dt_emi between '" + Convert.ToDateTime(sValor1).ToString("dd.MM.yyyy") + "' and '" + Convert.ToDateTime(sValor2).ToString("dd.MM.yyyy") + "')");
                }
                else if (stFiltro == Filtro.Cliente)
                {
                    sWhere.Append("ms.nm_clifor like('%" + sValor1.ToUpper() + "%')");
                }
                else if (stFiltro == Filtro.Chave)
                {
                    sWhere.Append("ms.cd_chave_nfe like('%" + sValor1.ToUpper() + "%')");
                }
                sWhere.Append(" order by c.nm_clifor ");

                DataTable dt = HlpDbFuncoes.qrySeekRet("movensai ms inner join clifor c on ms.cd_clifor = c.cd_clifor ", "", sWhere.ToString(), lCampos);


                foreach (DataRow row in dt.Rows)
                {
                    lresult.Add(new belManifestacaoPesquisa
                    {
                        xCd_Clifor = row["xCd_Clifor"].ToString(),
                        xChaveNFe = row["xChaveNFe"].ToString(),
                        xIE = row["xIE"].ToString(),
                        xRazaoSocial = row["xRazaoSocial"].ToString(),
                        dtEmissao = Convert.ToDateTime(row["dtEmissao"].ToString()),
                        dTotalNFe = Convert.ToDecimal(row["dTotalNFe"].ToString().Replace(".", ","))
                    });
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public belManifestacaoPesquisa(nfeProc nfe)
        {
            this.lresult = new List<belManifestacaoPesquisa>();

            foreach (var notas in nfe.lNfe.FirstOrDefault().lInfNfe)
            {
                this.lresult.Add(new belManifestacaoPesquisa
                          {
                              xChaveNFe = notas.Id.Replace("NFe", ""),
                              xIE = notas.emitField.IE,
                              xRazaoSocial = notas.emitField.xNome,
                              dtEmissao = Convert.ToDateTime(notas.ideField.dEmi),
                              dTotalNFe = Convert.ToDecimal(notas.totalField.ICMSTot.vNF.Replace(".", ","))
                          });
            }

        }

        public enum Filtro { Data, Cliente, Chave };

        public  belRetEventoCancelamento objRet{ get; set; }
        public string TrataRetornoManifestacao(string sTipoRegistro)
        {
            try
            {
                if (this.sXMLretorno != "")
                {
                    objRet = SerializeClassToXml.DeserializeClasseString<belRetEventoCancelamento>(this.sXMLretorno);

                    if (objRet.cStat == "128")
                        if (objRet.retEvento.infEvento.cStat == "135")
                        {
                            daoUtil.SetStatusManifestacao(this.xChaveNFe, sTipoRegistro);
                            this.stManifesto = sTipoRegistro;
                        }
                    return string.Format("NFe: {0} - Status: {1} - Motivo: {2}{3}", this.xNumero, objRet.cStat, objRet.retEvento != null?
                        objRet.retEvento.infEvento.xMotivo: objRet.xMotivo, Environment.NewLine);
                }
                else
                {
                    return "Nenhum evento registrado.";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
