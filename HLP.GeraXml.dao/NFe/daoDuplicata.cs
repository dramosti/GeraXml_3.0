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

        public void BuscaVencto(string nrseq, string cdnotafis)
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
                sSqlDup.Append("(doc_ctr.cd_nfseq = '");
                sSqlDup.Append(nrseq);
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
                    sPedseq.Append(nrseq);
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

                foreach (DataRow drEmit in dtEmit.Rows)
                {
                    objNFs = new NotasDuplicatas();

                    if (!(Acesso.NM_EMPRESA.Equals("LORENZON")))
                    {
                        if (drEmit["NOTA"].ToString() == "S")
                        {
                            iParcela++;
                            objNFs.sNF = string.Format("{0}{1}",
                                                cdnotafis.Trim(),
                                                Convert.ToChar((64 + iParcela)));
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
                    else
                    {
                        if (drEmit["cd_dupli"].ToString().Contains("/NUM"))
                        {
                            if (drEmit["NOTA"].ToString() == "S")
                            {
                                iParcela++;
                                objNFs.sNF = string.Format("{0}{1}",
                                                    cdnotafis.Trim(),
                                                    Convert.ToChar((64 + iParcela)));
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

                    sSql.Append("update ");
                    sSql.Append("doc_ctr ");
                    sSql.Append("set cd_dupli = '");
                    sSql.Append(objListNfs[i].sNF);
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

        }

       



    }
}
