using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HLP.GeraXml.Comum.Static;
using HLP.GeraXml.dao.ADO;

namespace HLP.GeraXml.dao.NFe
{
    public class daoNumeroNF
    {
        public string sGrupoNF { get; set; }
        public List<string> lsNotas = new List<string>();
        public struct DadosGerar
        {
            public string seqNF { get; set; }
            public string nNF { get; set; }
        }
        public List<DadosGerar> lDadosGerar = new List<DadosGerar>();

        public void ValidaSequenciaNoBanco(int iProximoNumero)
        {
            try
            {

                StringBuilder sSqlSeqValidas = new StringBuilder();
                sSqlSeqValidas.Append("select ");
                sSqlSeqValidas.Append("nf.cd_nfseq ");
                sSqlSeqValidas.Append("From nf ");
                sSqlSeqValidas.Append("where ");
                sSqlSeqValidas.Append("((nf.cd_notafis is null) or (nf.cd_notafis = '')) and (");
                sSqlSeqValidas.Append("nf.cd_empresa ='");
                sSqlSeqValidas.Append(Acesso.CD_EMPRESA);
                sSqlSeqValidas.Append("') and (");
                sSqlSeqValidas.Append("nf.cd_nfseq in('");
                int iCont = 0;
                foreach (var sNfseq in lsNotas)
                {
                    iCont++;
                    sSqlSeqValidas.Append(sNfseq);
                    if (lsNotas.Count > iCont)
                    {
                        sSqlSeqValidas.Append("','");
                    }
                }
                sSqlSeqValidas.Append("')) ");
                sSqlSeqValidas.Append("Order by nf.cd_empresa, nf.cd_nfseq ");

                DataTable dt = HLP.GeraXml.dao.ADO.HlpDbFuncoes.qrySeekRet(sSqlSeqValidas.ToString());


                foreach (DataRow dr in dt.Rows)
                {
                    lDadosGerar.Add(new DadosGerar { seqNF = dr["cd_nfseq"].ToString(), nNF = iProximoNumero.ToString().PadLeft(6,'0') });
                    iProximoNumero++;
                }

                if (lDadosGerar.Count == 0)
                {
                    throw new Exception("Outro Usuário ja gerou numeração para essas Notas.");
                }

                daoRegras.VerificaNumeracaoExistente(lDadosGerar);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string BuscaUltimoNumeroNF()
        {
            try
            {
                StringBuilder sWhere = new StringBuilder();
                sWhere.Append("(NF.cd_empresa ='");
                sWhere.Append(Acesso.CD_EMPRESA);
                sWhere.Append("') and ");
                if ((sGrupoNF == "") || (sGrupoNF == "0"))
                {
                    sWhere.Append("(NF.CD_GRUPONF IS NULL OR NF.CD_GRUPONF='' OR NF.CD_GRUPONF='0') ");
                }
                else
                {
                    sWhere.Append("(CD_GRUPONF='" + sGrupoNF + "') ");
                }


                return HLP.GeraXml.dao.ADO.HlpDbFuncoes.qrySeekValue("NF", "MAX(NF.CD_NOTAFIS) AS CD_NOTAFIS", sWhere.ToString()).ToString();
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
        }

        public void AtualizaMovitem(daoNumeroNF.DadosGerar nota) 
        {
            string sFiltro = string.Empty;
            string sSqlAtualizaMovitem = string.Empty;
            sFiltro = daoRegras.OperacoesValidas(nota.seqNF);
            bool bHe131 = false; ;

            if (sFiltro.IndexOf("TIPO131") == -1)
            {
                sFiltro = daoRegras.MontaFiltroOperacoesValidas(sFiltro);
                bHe131 = false;
            }
            else
            {
                sFiltro = daoRegras.MontaFiltroOperacoesValidas(sFiltro.Replace("TIPO131", ""));
                bHe131 = true;

            }
            if (bHe131)
            {
                sSqlAtualizaMovitem = "update movitem set DT_DOC = '" + daoUtil.GetDateServidor().ToString("dd.MM.yyyy") +
                                                     "' where cd_empresa = '" + Acesso.CD_EMPRESA +
                                                     "' and cd_nfseq = '" + nota.seqNF + "'" + sFiltro;
            }
            else
            {
                sSqlAtualizaMovitem = "update movitem set cd_doc = '" + nota.nNF +
                                 "', DT_DOC = '" + daoUtil.GetDateServidor().ToString("dd.MM.yyyy") +
                                 "' where cd_empresa = '" + Acesso.CD_EMPRESA +
                                 "' and cd_nfseq = '" + nota.seqNF + "'" + sFiltro;
            }

            HlpDbFuncoes.qrySeekUpdate(sSqlAtualizaMovitem);
        }

    }
}
