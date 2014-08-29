using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HLP.GeraXml.dao.ADO;
using HLP.GeraXml.Comum.Static;
using System.Data;

namespace HLP.GeraXml.dao.NFe
{
    public class daoDuplicata
    {
        public struct NotasDuplicatas
        {
            public string sNF { get; set; }
            public string sNrDoc { get; set; }
        }

        public void BuscaVencto(string nfseq, string cdnotafis, string cd_nfse = "")
        {
            string ssGravarCdDupli = HlpDbFuncoes.qrySeekValue("control", "control.cd_conteud", "cd_nivel = '1355'");
            string ssGravardteminf = HlpDbFuncoes.qrySeekValue("control", "control.cd_conteud", "cd_nivel = '1363'");

            if (ssGravarCdDupli == "S")
            {
                StringBuilder sSqlDup = new StringBuilder();
                //Campos do Select
                sSqlDup.Append("Select ");
                sSqlDup.Append("doc_ctr.nr_doc, ");
                sSqlDup.Append("doc_ctr.cd_documento, ");
                sSqlDup.Append("doc_ctr.cd_dupli, doc_ctr.cd_seqped, ");
                sSqlDup.Append("'S' Nota ");
                //Tabela
                sSqlDup.Append("From Doc_ctr ");
                //Where
                sSqlDup.Append("Where ");
                sSqlDup.Append("(doc_ctr.cd_empresa ='");
                sSqlDup.Append(Acesso.CD_EMPRESA);
                sSqlDup.Append("') ");
                sSqlDup.Append("and ");
                sSqlDup.Append("(doc_ctr.cd_nfseq = '");
                sSqlDup.Append(nfseq);
                sSqlDup.Append("') ");

                #region MASTERFEW
                if (Acesso.NM_EMPRESA == "MASTERFEW")
                {
                    StringBuilder sPedseq = new StringBuilder();
                    sPedseq.Append("Select ");
                    sPedseq.Append("pedseq.cd_pedido, ");
                    sPedseq.Append("pedseq.cd_seqped ");
                    sPedseq.Append("from pedseq ");
                    sPedseq.Append("where ");
                    sPedseq.Append("(pedseq.cd_empresa = '");
                    sPedseq.Append(Acesso.CD_EMPRESA);
                    sPedseq.Append("') ");
                    sPedseq.Append("and ");
                    sPedseq.Append("(pedseq.cd_nfseq = '");
                    sPedseq.Append(nfseq);
                    sPedseq.Append("') ");


                    DataTable drPedseq = HlpDbFuncoes.qrySeekRet(sPedseq.ToString());

                    if (drPedseq.Rows.Count > 0)
                    {
                        int iSeq = Convert.ToInt16(drPedseq.Rows[0]["cd_seqped"].ToString());
                        iSeq++;

                        //União
                        sSqlDup.Append("Union ");
                        //Campos do Select
                        sSqlDup.Append("Select ");
                        sSqlDup.Append("doc_ctr.nr_doc, ");
                        sSqlDup.Append("doc_ctr.cd_documento,  ");
                        sSqlDup.Append("doc_ctr.cd_dupli, ");
                        sSqlDup.Append("'N' Nota ");
                        //Tabela
                        sSqlDup.Append("From Doc_ctr ");
                        //Where
                        sSqlDup.Append("Where ");
                        sSqlDup.Append("(doc_ctr.cd_empresa ='");
                        sSqlDup.Append(Acesso.CD_EMPRESA);
                        sSqlDup.Append("') ");
                        sSqlDup.Append("and ");
                        sSqlDup.Append("(doc_ctr.CD_PEDIDO = '");
                        sSqlDup.Append(drPedseq.Rows[0]["cd_pedido"].ToString());
                        sSqlDup.Append("') ");
                        sSqlDup.Append("and ");
                        sSqlDup.Append("(doc_ctr.CD_SEQPED = '");
                        sSqlDup.Append(iSeq.ToString().PadLeft(2, '0'));
                        sSqlDup.Append("') ");
                    }
                }
                #endregion

                sSqlDup.Append("order by 1 ");

                DataTable dtEmit = HlpDbFuncoes.qrySeekRet(sSqlDup.ToString());
                int iParcela = 0;
                int iSemNota = 0;
                List<NotasDuplicatas> objListNfs = new List<NotasDuplicatas>();
                NotasDuplicatas objNFs = new NotasDuplicatas();

                string sNumGerador = (cd_nfse != "" ? cd_nfse : cdnotafis).Trim();

                foreach (DataRow drEmit in dtEmit.Rows)
                {
                    objNFs = new NotasDuplicatas();

                    if (!(Acesso.NM_EMPRESA.Equals("LORENZON")))
                    {
                        if (drEmit["NOTA"].ToString() == "S")
                        {
                            iParcela++;
                            objNFs.sNF = string.Format("{0}-{1}",
                                                sNumGerador,
                                                iParcela);
                            objNFs.sNrDoc = drEmit["NR_DOC"].ToString();
                        }
                        else
                        {
                            iSemNota++;
                            objNFs.sNF = string.Format("{0}/{1}",
                                                Convert.ToInt64(sNumGerador).ToString().PadLeft(5, '0'),
                                                iSemNota.ToString().Trim());
                            objNFs.sNrDoc = drEmit["NR_DOC"].ToString();

                        }
                        objListNfs.Add(objNFs);
                    }
                    else
                    {
                        if (drEmit["cd_dupli"].ToString().Contains("/NUM"))
                        {
                            if (drEmit["NOTA"].ToString() == "S")
                            {
                                iParcela++;
                                objNFs.sNF = string.Format("{0}{1}",
                                                    cdnotafis.Trim(),
                                                    dtEmit.Rows.Count > 1 ? Convert.ToChar((64 + iParcela)).ToString() : "");
                                objNFs.sNrDoc = drEmit["NR_DOC"].ToString();
                            }
                            else
                            {
                                iSemNota++;
                                objNFs.sNF = string.Format("{0}/{1}",
                                                    Convert.ToInt64(cdnotafis).ToString().PadLeft(5, '0'),
                                                    iSemNota.ToString().Trim());
                                objNFs.sNrDoc = drEmit["NR_DOC"].ToString();

                            }
                            objListNfs.Add(objNFs);
                        }
                    }
                }

                if (Acesso.NM_EMPRESA != "DARONYL")
                    if (objListNfs.Count == 1)
                    {
                        objNFs = objListNfs[0];
                        objNFs.sNF = objListNfs[0].sNF.Replace("-1", "").PadLeft(7, '0'); //Claudinei - o.s. 24103 - 05/02/2010
                        objListNfs = new List<NotasDuplicatas>();
                        objListNfs.Add(objNFs);
                    }

                for (int i = 0; i < objListNfs.Count; i++)
                {

                    StringBuilder sSql = new StringBuilder();
                    string sNumDup = "";
                    if (objListNfs[i].sNF.Count() > 7)
                        sNumDup = objListNfs[i].sNF.Substring((objListNfs[i].sNF.Count() - 7), 7);
                    else
                        sNumDup = objListNfs[i].sNF.PadLeft(7, '0');

                    sSql.Append("update ");
                    sSql.Append("doc_ctr ");
                    sSql.Append("set cd_dupli = '");
                    sSql.Append(sNumDup);
                    sSql.Append("' Where ");
                    sSql.Append("(cd_empresa = '");
                    sSql.Append(Acesso.CD_EMPRESA);
                    sSql.Append("')");
                    sSql.Append(" and ");
                    sSql.Append("(nr_doc = '");
                    sSql.Append(objListNfs[i].sNrDoc);
                    sSql.Append("')");

                    HlpDbFuncoes.qrySeekUpdate(sSql.ToString());
                }
            }
            if (Acesso.NM_RAMO == Acesso.BancoDados.INDUSTRIA)
                this.BuscaVenctoCancelado(nfseq, cdnotafis, cd_nfse);
        }

        public void BuscaVenctoCancelado(string nfseq, string cdnotafis, string cd_nfse = "")
        {
            bool bExistCampo = HlpDbFuncoes.fExisteCampo("TP_DUPCANC", "EMPRESA");

            if (bExistCampo)
            {
                string sTP_DUPCANC = HlpDbFuncoes.qrySeekValue("EMPRESA", "COALESCE(TP_DUPCANC,'P')", string.Format("CD_EMPRESA = '{0}'", Acesso.CD_EMPRESA));

                if (sTP_DUPCANC.Equals("N"))
                {
                    string ssGravarCdDupli = HlpDbFuncoes.qrySeekValue("control", "control.cd_conteud", "cd_nivel = '1355'");
                    string ssGravardteminf = HlpDbFuncoes.qrySeekValue("control", "control.cd_conteud", "cd_nivel = '1363'");

                    if (ssGravarCdDupli == "S")
                    {
                        //List<string> lPedidos = new List<string>();
                        //string sQuery = string.Format("select distinct m.cd_pedido from movitem m where m.cd_nfseq = '{0}' and m.cd_empresa = '{1}'", nfseq, Acesso.CD_EMPRESA);

                        //DataTable drPedidos = HlpDbFuncoes.qrySeekRet(sQuery);

                        //foreach (DataRow item in drPedidos.Rows)
                        //{
                        //    lPedidos.Add(item["cd_pedido"].ToString());
                        //}


                        //if (lPedidos.Count > 0)
                        //{
                        //foreach (string CD_PEDIDO in lPedidos)
                        //{
                        StringBuilder sSqlDup = new StringBuilder();
                        //Campos do Select
                        sSqlDup.Append("Select ");
                        sSqlDup.Append("doc_ctr.nr_doc, ");
                        sSqlDup.Append("doc_ctr.cd_documento, ");
                        sSqlDup.Append("doc_ctr.cd_dupli, ");
                        sSqlDup.Append("'S' Nota ");
                        //Tabela
                        sSqlDup.Append("From Doc_ctr ");
                        //Where
                        sSqlDup.Append("Where ");
                        sSqlDup.Append("(doc_ctr.cd_empresa ='");
                        sSqlDup.Append(Acesso.CD_EMPRESA);
                        sSqlDup.Append("') ");
                        sSqlDup.Append("and ");
                        sSqlDup.Append("(doc_ctr.cd_nfseq_conversao = '");
                        sSqlDup.Append(nfseq);
                        sSqlDup.Append("') ");

                        #region MASTERFEW
                        if (Acesso.NM_EMPRESA == "MASTERFEW")
                        {
                            StringBuilder sPedseq = new StringBuilder();
                            sPedseq.Append("Select ");
                            sPedseq.Append("pedseq.cd_pedido, ");
                            sPedseq.Append("pedseq.cd_seqped ");
                            sPedseq.Append("from pedseq ");
                            sPedseq.Append("where ");
                            sPedseq.Append("(pedseq.cd_empresa = '");
                            sPedseq.Append(Acesso.CD_EMPRESA);
                            sPedseq.Append("') ");
                            sPedseq.Append("and ");
                            sPedseq.Append("(pedseq.cd_nfseq = '");
                            sPedseq.Append(nfseq);
                            sPedseq.Append("') ");


                            DataTable drPedseq = HlpDbFuncoes.qrySeekRet(sPedseq.ToString());

                            int iSeq = Convert.ToInt16(drPedseq.Rows[0]["cd_seqped"].ToString());
                            iSeq++;

                            //União
                            sSqlDup.Append("Union ");
                            //Campos do Select
                            sSqlDup.Append("Select ");
                            sSqlDup.Append("doc_ctr.nr_doc, ");
                            sSqlDup.Append("doc_ctr.cd_documento, ");
                            sSqlDup.Append("doc_ctr.cd_dupli, ");
                            sSqlDup.Append("'N' Nota ");
                            //Tabela
                            sSqlDup.Append("From Doc_ctr ");
                            //Where
                            sSqlDup.Append("Where ");
                            sSqlDup.Append("(doc_ctr.cd_empresa ='");
                            sSqlDup.Append(Acesso.CD_EMPRESA);
                            sSqlDup.Append("') ");
                            sSqlDup.Append("and ");
                            sSqlDup.Append("(doc_ctr.CD_PEDIDO = '");
                            sSqlDup.Append(drPedseq.Rows[0]["cd_pedido"].ToString());
                            sSqlDup.Append("') ");
                            sSqlDup.Append("and ");
                            sSqlDup.Append("(doc_ctr.CD_SEQPED = '");
                            sSqlDup.Append(iSeq.ToString().PadLeft(2, '0'));
                            sSqlDup.Append("') ");
                        }
                        #endregion

                        sSqlDup.Append("order by 1 ");

                        DataTable dtEmit = HlpDbFuncoes.qrySeekRet(sSqlDup.ToString());
                        int iParcela = 0;
                        int iSemNota = 0;
                        List<NotasDuplicatas> objListNfs = new List<NotasDuplicatas>();
                        NotasDuplicatas objNFs = new NotasDuplicatas();

                        string sNumGerador = (cd_nfse != "" ? cd_nfse : cdnotafis).Trim();

                        foreach (DataRow drEmit in dtEmit.Rows)
                        {
                            objNFs = new NotasDuplicatas();

                            if (!(Acesso.NM_EMPRESA.Equals("LORENZON")))
                            {
                                if (drEmit["NOTA"].ToString() == "S")
                                {
                                    iParcela++;
                                    objNFs.sNF = string.Format("{0}-{1}",
                                                        sNumGerador,
                                                         iParcela + 10);
                                    objNFs.sNrDoc = drEmit["NR_DOC"].ToString();
                                }
                                else
                                {
                                    iSemNota++;
                                    objNFs.sNF = string.Format("{0}/{1}",
                                                        Convert.ToInt64(sNumGerador).ToString().PadLeft(5, '0'),
                                                        iSemNota.ToString().Trim());
                                    objNFs.sNrDoc = drEmit["NR_DOC"].ToString();

                                }
                                objListNfs.Add(objNFs);
                            }
                            else
                            {
                                if (drEmit["cd_dupli"].ToString().Contains("/NUM"))
                                {
                                    if (drEmit["NOTA"].ToString() == "S")
                                    {
                                        iParcela++;
                                        objNFs.sNF = string.Format("{0}-{1}",
                                                            cdnotafis.Trim(),
                                                            iParcela);
                                        objNFs.sNrDoc = drEmit["NR_DOC"].ToString();
                                    }
                                    else
                                    {
                                        iSemNota++;
                                        objNFs.sNF = string.Format("{0}/{1}",
                                                            Convert.ToInt64(cdnotafis).ToString().PadLeft(5, '0'),
                                                            iSemNota.ToString().Trim());
                                        objNFs.sNrDoc = drEmit["NR_DOC"].ToString();

                                    }
                                    objListNfs.Add(objNFs);
                                }
                            }
                        }

                        if (objListNfs.Count == 1)
                        {
                            objNFs = objListNfs[0];
                            objNFs.sNF = objListNfs[0].sNF.Replace("A", "").PadLeft(7, '0'); //Claudinei - o.s. 24103 - 05/02/2010
                            objListNfs = new List<NotasDuplicatas>();
                            objListNfs.Add(objNFs);
                        }

                        for (int i = 0; i < objListNfs.Count; i++)
                        {

                            StringBuilder sSql = new StringBuilder();
                            string sNumDup = "";
                            if (objListNfs[i].sNF.Count() > 7)
                                sNumDup = objListNfs[i].sNF.Substring((objListNfs[i].sNF.Count() - 7), 7);
                            else
                                sNumDup = objListNfs[i].sNF.PadLeft(7, '0');

                            sSql.Append("update ");
                            sSql.Append("doc_ctr ");
                            sSql.Append("set cd_dupli = '");
                            sSql.Append(sNumDup);
                            sSql.Append("' Where ");
                            sSql.Append("(cd_empresa = '");
                            sSql.Append(Acesso.CD_EMPRESA);
                            sSql.Append("')");
                            sSql.Append(" and ");
                            sSql.Append("(nr_doc = '");
                            sSql.Append(objListNfs[i].sNrDoc);
                            sSql.Append("')");

                            HlpDbFuncoes.qrySeekUpdate(sSql.ToString());
                        }
                        //}
                        //}
                    }
                }
            }

        }
    }
}
