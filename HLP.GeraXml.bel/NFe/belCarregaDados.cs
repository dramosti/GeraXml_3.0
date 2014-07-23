using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HLP.GeraXml.bel.NFe.Estrutura;
using HLP.GeraXml.Comum.Static;
using HLP.GeraXml.dao;

namespace HLP.GeraXml.bel.NFe
{
    /// <summary>
    /// Carrega os dados da nota 
    /// 
    /// </summary>
    public class belCarregaDados
    {
        private List<belPesquisaNotas> lPesquisa = new List<belPesquisaNotas>();
        public List<belInfNFe> lNotas = new List<belInfNFe>();
        public belCriaXmlNFe objbelCriaXml = null;
        public belRecepcaoNFe objbelRecepcao = new belRecepcaoNFe();
        public belCarregaDados(List<belPesquisaNotas> _lPesquisa)
        {
            this.lPesquisa = _lPesquisa;
            //CarregaDados();
            //objbelCriaXml = new belCriaXmlNFe(lNotas);

        }
        public belCarregaDados() { }

        public void CarregaDados()
        {
            try
            {

                lNotas = new List<belInfNFe>();
                foreach (belPesquisaNotas nota in lPesquisa)
                {
                    belInfNFe objInfNFe = new belInfNFe();
                    nota.sCHAVENFE = daoUtil.GeraChaveNFe(nota.sCD_NFSEQ);
                    objInfNFe.chaveNFe = "NFe" + nota.sCHAVENFE;

                    objInfNFe.ide.Carrega(nota.sCD_NFSEQ, objInfNFe.sDigVerif);

                    objInfNFe.emit.Carrega(nota.sCD_NFSEQ);

                    objInfNFe.dest.Carrega(nota.sCD_NFSEQ);
                    bool bEX = (objInfNFe.dest.Uf.Equals("EX") ? true : false);

                    objInfNFe.endent.Carrega(nota.sCD_NFSEQ);
                    belDet objbelDet = new belDet();
                    objInfNFe.det = objbelDet.Carrega(nota.sCD_NFSEQ, bEX, objInfNFe.dest.Uf);
                    #region RetiraValorBCICMSret dos Totais;
                    decimal dVbcIcmsRt = objInfNFe.det.Where(p => p.imposto.belIcms.belICMSSN500 != null).Select(p => p.imposto.belIcms.belICMSSN500.vBCSTRet).Sum();
                    decimal dVIcmsRt = objInfNFe.det.Where(p => p.imposto.belIcms.belICMSSN500 != null).Select(p => p.imposto.belIcms.belICMSSN500.vICMSSTRet).Sum();
                    #endregion

                    objInfNFe.total.Carrega(nota.sCD_NFSEQ, objbelDet.pbIndustri, bEX);
                    objInfNFe.total.belIcmstot.Vbcst = objInfNFe.total.belIcmstot.Vbcst - dVbcIcmsRt;
                    objInfNFe.total.belIcmstot.Vst = objInfNFe.total.belIcmstot.Vst - dVIcmsRt;
                    objInfNFe.total.belIcmstot.vTotTrib = objInfNFe.det.Sum(c => c.prod.vTotTrib);

                    objInfNFe.transp.Carrega(nota.sCD_NFSEQ);

                    objInfNFe.cobr.Carrega(nota.sCD_NFSEQ);

                    objInfNFe.infAdic.Carrega(nota.sCD_NFSEQ, objInfNFe.det, objInfNFe.dest.Cnpj, dVbcIcmsRt, dVIcmsRt);

                    if (Acesso.TRANSPARENCIA == 0 || Acesso.TRANSPARENCIA == 2)
                    {
                        string sMsg = objInfNFe.infAdic.Infcpl;
                        objInfNFe.infAdic.Infcpl = null;
                        objInfNFe.infAdic.Infcpl = daoUtil.CarregaObsTransparenciaNF(nota.sCD_NFSEQ) + sMsg;
                    }

                    if (Acesso.NM_EMPRESA.Equals("GIWA"))
                    {
                        if (objInfNFe.cobr != null)
                        {
                            if (objInfNFe.cobr.Fat != null)
                            {
                                if (objInfNFe.cobr.Fat.belDup != null)
                                {
                                    
                                    string sparecelas = string.Empty;
                                    foreach (var item in objInfNFe.cobr.Fat.belDup)
                                    {
                                        sparecelas += string.Format("{0}{1} VALOR R$ {2} | ", item.Dvenc.ToShortDateString(), (sparecelas == "" ? "" : " -")
                                            , item.Vdup.ToString("#0.00"));
                                    }
                                    if (objInfNFe.cobr.Fat.belDup.Count() > 0)
                                        objInfNFe.infAdic.Infcpl = "PARCELA(S): " + sparecelas;
                                }
                            }
                        }
                    }


                    lNotas.Add(objInfNFe);
                }
                objbelCriaXml = new belCriaXmlNFe(lNotas);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
