using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HLP.GeraXml.dao.NFe;
using HLP.GeraXml.bel.NFe.Estrutura;
using System.Data;

namespace HLP.GeraXml.bel.NFe
{
    public class belPesquisaNFeRef : daoPesquisaNFeRef
    {

        public List<belCampoPesquisa> PesquisaNotasRef(int iOperador, int iModelo, string _campoPesquisa, string sfiltro)
        {
            List<belCampoPesquisa> lCampoPesquisa = new List<belCampoPesquisa>();

            foreach (DataRow dr in BuscaNotas(iOperador, iModelo, _campoPesquisa, sfiltro).Rows)
            {
                belCampoPesquisa objCampo = new belCampoPesquisa();
                objCampo.ChaveAcesso = dr["CHAVE"].ToString();
                objCampo.NumeroNF = dr["nNF"].ToString();
                objCampo.SeqNF = dr["NFSEQ"].ToString();
                objCampo.sCli_For = dr["nm_clifornor"].ToString();
                objCampo.cUF = dr["cUF"].ToString();
                objCampo.AAMM = dr["AAMM"].ToString();
                objCampo.CNPJ = dr["CNPJ"].ToString();
                objCampo.serie = dr["serie"].ToString();
                lCampoPesquisa.Add(objCampo);
            }
            return lCampoPesquisa;
        }

        public List<belCampoPesquisa> PesquisaNotasRefEntrada(int iOperador, int iModelo, string _campoPesquisa, string sfiltro)
        {
            List<belCampoPesquisa> lCampoPesquisa = new List<belCampoPesquisa>();

            foreach (DataRow dr in BuscaNotasEntrada(iOperador, iModelo, _campoPesquisa, sfiltro).Rows)
            {
                belCampoPesquisa objCampo = new belCampoPesquisa();
                objCampo.ChaveAcesso = dr["CHAVE"].ToString();
                objCampo.NumeroNF = dr["nNF"].ToString();
                objCampo.SeqNF = dr["Lancamento"].ToString();
                objCampo.sCli_For = dr["nm_clifornor"].ToString();
                objCampo.cUF = dr["cUF"].ToString();
                objCampo.AAMM = dr["AAMM"].ToString();
                objCampo.CNPJ = dr["CNPJ"].ToString();
                objCampo.serie = dr["serie"].ToString();
                lCampoPesquisa.Add(objCampo);
            }
            return lCampoPesquisa;
        }
    }
}
