using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HLP.GeraXml.bel.NFe.Estrutura;
using HLP.GeraXml.Comum.Static;
using HLP.GeraXml.dao;
using System.IO;
using System.Xml.Linq;
using System.Xml.Schema;
using System.Xml;
using HLP.GeraXml.Comum;

namespace HLP.GeraXml.bel.NFe
{
    public class belCriaXmlNFe
    {
        List<belInfNFe> lNotas = null;

        public belCriaXmlNFe(List<belInfNFe> lNotas)
        {
            this.lNotas = lNotas;
        }
        public string sPathLote { get; set; }

        public void GeraLoteXmlEnvio()
        {
            try
            {
                string sNomeArquivo = daoUtil.RetornaNomeArqNFe();
                this.sPathLote = (Acesso.TP_EMIS == 2 ? Pastas.CONTINGENCIA + sNomeArquivo : Pastas.ENVIO + sNomeArquivo);
                List<string> nfes = new List<string>();
                belIde objide;
                int iCount = 0;

                if (File.Exists(sPathLote))
                {
                    File.Delete(sPathLote);
                }
                string sCasasVlUnit = (Acesso.QTDE_CASAS_VL_UNIT == "" ? "000000" : ("").PadLeft(Convert.ToInt32(Acesso.QTDE_CASAS_VL_UNIT), '0'));

                foreach (belInfNFe nota in lNotas)
                {
                    string sUF;
                    XDocument xdoc = new XDocument();


                    #region XML_Cabeçalho
                    XNamespace pf = "http://www.portalfiscal.inf.br/nfe";
                    XContainer concabec = (new XElement(pf + "NFe", new XAttribute("xmlns", "http://www.portalfiscal.inf.br/nfe")));
                    XContainer coninfnfe = (new XElement(pf + "infNFe", new XAttribute("Id", nota.chaveNFe),
                                                                        new XAttribute("versao", "2.00")));
                    #endregion

                    #region Ide
                    XContainer conide;
                    try
                    {
                        objide = nota.ide;
                        #region XML_ide
                        conide = (new XElement(pf + "ide", new XElement(pf + "cUF", objide.Cuf.ToString()),
                                                                    new XElement(pf + "cNF", objide.Cnf.ToString()),
                                                                    new XElement(pf + "natOp", objide.Natop.ToString()),
                                                                    new XElement(pf + "indPag", objide.Indpag.ToString()),
                                                                    new XElement(pf + "mod", objide.Mod.ToString()),
                                                                    new XElement(pf + "serie", objide.Serie.ToString()),
                                                                    new XElement(pf + "nNF", objide.Nnf.ToString()),
                                                                    new XElement(pf + "dEmi", objide.Demi.ToString("yyyy-MM-dd")),
                                                                    new XElement(pf + "dSaiEnt", objide.Dsaient.ToString("yyyy-MM-dd")),
                                                                    new XElement(pf + "hSaiEnt", daoUtil.GetDateServidor().ToString("HH:mm:ss")), // NFe_2.0
                                                                    new XElement(pf + "tpNF", objide.Tpnf.ToString()),
                                                                    new XElement(pf + "cMunFG", objide.Cmunfg.ToString()),
                                                                    (objide.belNFref != null ?
                                                                    (from c in objide.belNFref
                                                                     select new XElement(pf + "NFref",
                                                                                 (!String.IsNullOrEmpty(c.RefNFe) ? new XElement(pf + "refNFe", c.RefNFe) : null),
                                                                                 (!String.IsNullOrEmpty(c.cUF) ? (new XElement(pf + "refNF",
                                                                                 (!String.IsNullOrEmpty(c.cUF) ? new XElement(pf + "cUF", c.cUF) : null),
                                                                                 (!String.IsNullOrEmpty(c.AAMM) ? new XElement(pf + "AAMM", c.AAMM) : null),
                                                                                 (!String.IsNullOrEmpty(c.CNPJ) ? new XElement(pf + "CNPJ", c.CNPJ) : null),
                                                                                 (!String.IsNullOrEmpty(c.mod) ? new XElement(pf + "mod", c.mod) : null),
                                                                                 (!String.IsNullOrEmpty(c.serie) ? new XElement(pf + "serie", c.serie) : null),
                                                                                 (!String.IsNullOrEmpty(c.nNF) ? new XElement(pf + "nNF", c.nNF) : null))) : null))) : null),//NFe_2.0_Verificar ID B14 - B20a - B20i - 
                                                                    new XElement(pf + "tpImp", objide.Tpimp.ToString()),
                                                                    new XElement(pf + "tpEmis", objide.Tpemis.ToString()),
                                                                    new XElement(pf + "cDV", objide.Cdv.ToString()),
                                                                    new XElement(pf + "tpAmb", objide.Tpamb.ToString()),
                                                                    new XElement(pf + "finNFe", objide.Finnfe.ToString()),
                                                                    new XElement(pf + "procEmi", objide.Procemi.ToString()),
                                                                    new XElement(pf + "verProc", objide.Verproc.ToString()),

                                                                    ((objide.Tpemis.Equals("2")) || (objide.Tpemis.Equals("3")) || (objide.Tpemis.Equals("6")) ? // os_svc
                                                                                          new XElement(pf + "dhCont", daoUtil.GetDateServidor().ToString("yyyy-MM-ddTHH:mm:ss")) : null), // NFe_2.0
                                                                    ((objide.Tpemis.Equals("2")) || (objide.Tpemis.Equals("3")) || (objide.Tpemis.Equals("6")) ?
                                                                                          new XElement(pf + "xJust", (Acesso.TP_EMIS == 2 ? "FALHA DE CONEXÃO COM INTERNET" : "FALHA COM WEB SERVICE DO ESTADO")) : null)));// NFe_2.0
                        #endregion
                    }
                    catch (Exception x)
                    {
                        throw new Exception("Nota de Sequência - " + nota.ide.Cnf + "Erro na geração do XML, Regiao XML_ide - " + x.Message);
                    }
                    #endregion

                    #region Emit

                    XContainer conemit;
                    try
                    {
                        belEmit objemit = nota.emit;
                        #region XML_Emit

                        conemit = (new XElement(pf + "emit", (new XElement(pf + "CNPJ", objemit.Cnpj.ToString())),
                                                  new XElement(pf + "xNome", objemit.Xnome.ToString()),
                                                  new XElement(pf + "xFant", objemit.Xfant.ToString()),
                                                          new XElement(pf + "enderEmit",
                                                                  new XElement(pf + "xLgr", objemit.Xlgr.ToString()),
                                                                  new XElement(pf + "nro", objemit.Nro.ToString()),
                                                                  (!String.IsNullOrEmpty(objemit.Xcpl) ? new XElement(pf + "xCpl", objemit.Xcpl.ToString()) : null),
                                                                  new XElement(pf + "xBairro", objemit.Xbairro.ToString()),
                                                                  new XElement(pf + "cMun", objemit.Cmun.ToString()),
                                                                  new XElement(pf + "xMun", objemit.Xmun.ToString()),
                                                                  new XElement(pf + "UF", objemit.Uf.ToString()),
                                                                  new XElement(pf + "CEP", objemit.Cep.ToString()),
                                                                  new XElement(pf + "cPais", objemit.Cpais.ToString()),
                                                                  new XElement(pf + "xPais", objemit.Xpais.ToString()),
                                                                  (!String.IsNullOrEmpty(objemit.Fone) ? new XElement(pf + "fone", objemit.Fone.ToString()) : null)),
                                                  (!String.IsNullOrEmpty(objemit.Ie) ? new XElement(pf + "IE", objemit.Ie.ToString()) : null),
                                                  (!String.IsNullOrEmpty(objemit.Iest) ? new XElement(pf + "IEST", objemit.Iest.ToString()) : null),
                                                  (!String.IsNullOrEmpty(objemit.Im) ? new XElement(pf + "IM", objemit.Im.ToString()) : null),
                                                  (!String.IsNullOrEmpty(objemit.Cnae) ? new XElement(pf + "CNAE", objemit.Cnae.ToString()) : null),
                                                  new XElement(pf + "CRT", objemit.CRT.ToString()))); // NFe_2.0

                        #endregion
                    }
                    catch (Exception x)
                    {
                        throw new Exception("Nota de Sequência - " + nota.ide.Cnf + "Erro na geração do XML, Regiao XML_Emit - " + x.Message);
                    }
                    #endregion

                    #region Dest
                    XContainer condest;
                    try
                    {

                        belDest objdest = nota.dest;
                        sUF = objdest.Uf.ToString();
                        #region XML_Dest
                        objdest.Ie = (objdest.Ie == null ? "" : objdest.Ie);


                        condest = (new XElement(pf + "dest",
                                                  (objdest.Cnpj == "EXTERIOR" ? new XElement(pf + "CNPJ") :
                                                     (!String.IsNullOrEmpty(objdest.Cnpj) ? new XElement(pf + "CNPJ", objdest.Cnpj) :
                                                                            new XElement(pf + "CPF", objdest.Cpf))),
                                                  new XElement(pf + "xNome", (Acesso.TP_EMIS == 2 ? "NF-E EMITIDA EM AMBIENTE DE HOMOLOGACAO - SEM VALOR FISCAL" : objdest.Xnome.ToString().Trim())),
                                                  new XElement(pf + "enderDest",
                                                      new XElement(pf + "xLgr", objdest.Xlgr.ToString()),
                                                      new XElement(pf + "nro", (!String.IsNullOrEmpty(objdest.Nro) ? objdest.Nro.ToString() : "0")),
                                                      (objdest.Xcpl != "" ? new XElement(pf + "xCpl", objdest.Xcpl.ToString()) : null),
                                                      new XElement(pf + "xBairro", objdest.Xbairro.ToString()),
                                                      new XElement(pf + "cMun", objdest.Cmun.ToString()),
                                                      new XElement(pf + "xMun", objdest.Xmun.ToString()),
                                                      new XElement(pf + "UF", objdest.Uf.ToString()),
                                                      (!String.IsNullOrEmpty(objdest.Cep) ? new XElement(pf + "CEP", objdest.Cep.ToString()) : null),
                                                      new XElement(pf + "cPais", objdest.Cpais.ToString()),
                                                      (!String.IsNullOrEmpty(objdest.Xpais) ? new XElement(pf + "xPais", objdest.Xpais.ToString()) : null),
                                                      (!String.IsNullOrEmpty(objdest.Fone) ? new XElement(pf + "fone", objdest.Fone.ToString()) : null)),
                                                      (!String.IsNullOrEmpty(objdest.Ie) ? (objdest.Ie != "EXTERIOR" ? new XElement(pf + "IE", objdest.Ie.ToString().Trim()) : new XElement(pf + "IE")) : null),
                                                      (!String.IsNullOrEmpty(objdest.Isuf) ? new XElement(pf + "ISUF", objdest.Isuf.ToString()) : null)));


                        #endregion
                    }
                    catch (Exception x)
                    {
                        throw new Exception("Nota de Sequência - " + nota.ide.Cnf + "Erro na geração do XML, Regiao XML_Dest - " + x.Message);
                    }

                    #endregion

                    #region Det
                    List<XElement> lcondet = new List<XElement>();
                    try
                    {
                        List<belDet> objdet = nota.det;
                        #region XML_Detalhes

                        List<string> lCfopNotTagII = new List<string>();
                        lCfopNotTagII.Add("3201");
                        lCfopNotTagII.Add("3202");
                        lCfopNotTagII.Add("3211");
                        lCfopNotTagII.Add("3503");
                        lCfopNotTagII.Add("3553");



                        foreach (belDet det in objdet)
                        {
                            //det.imposto.belIpi = null;
                            XElement condet = (new XElement(pf + "det", new XAttribute("nItem", det.nitem),
                                               new XElement(pf + "prod",
                                                   (!String.IsNullOrEmpty(det.prod.Cprod) ? new XElement(pf + "cProd", det.prod.Cprod.ToString().Replace(" ", "")) : null),
                                                   (new XElement(pf + "cEAN", det.prod.Cean.ToString())),
                                                   (!String.IsNullOrEmpty(det.prod.Xprod) ? new XElement(pf + "xProd", det.prod.Xprod.ToString()) : null),
                                                   (!String.IsNullOrEmpty(det.prod.Ncm) ? new XElement(pf + "NCM", det.prod.Ncm.ToString()) : new XElement(pf + "NCM", det.prod.Ncm = "00000000")), //Claudinei - o.s. 24200 - 01/03/2010
                                                   (!String.IsNullOrEmpty(det.prod.Extipi) ? new XElement(pf + "EXTIPI", det.prod.Extipi.ToString()) : null),
                                                   (!String.IsNullOrEmpty(det.prod.Genero) ? new XElement(pf + "genero", det.prod.Genero.ToString()) : null),
                                                   (!String.IsNullOrEmpty(det.prod.Cfop) ? new XElement(pf + "CFOP", det.prod.Cfop.ToString()) : null),
                                                   (!String.IsNullOrEmpty(det.prod.Ucom) ? new XElement(pf + "uCom", det.prod.Ucom.ToString()) : null),
                                                   (new XElement(pf + "qCom", det.prod.Qcom.ToString("#0.0000").Replace(",", "."))),
                                                   (new XElement(pf + "vUnCom", det.prod.Vuncom.ToString("#0." + sCasasVlUnit).Replace(",", "."))),
                                                   (new XElement(pf + "vProd", det.prod.Vprod.ToString("#0.00").Replace(",", "."))),
                                                   (new XElement(pf + "cEANTrib", det.prod.Ceantrib.ToString())),
                                                   (!String.IsNullOrEmpty(det.prod.Utrib) ? new XElement(pf + "uTrib", det.prod.Utrib.ToString()) : null),
                                                   (new XElement(pf + "qTrib", det.prod.Qtrib.ToString("#0.0000").Replace(",", "."))),
                                                   (new XElement(pf + "vUnTrib", det.prod.Vuntrib.ToString("#0." + sCasasVlUnit).Replace(",", "."))),
                                                   (det.prod.Vfrete != 0 ? new XElement(pf + "vFrete", det.prod.Vfrete.ToString("#0.00").Replace(",", ".")) : null),
                                                   (det.prod.Vseg != 0 ? new XElement(pf + "vSeg", det.prod.Vseg.ToString("#0.00").Replace(",", ".")) : null),
                                                   (det.prod.Vdesc > 0 ? new XElement(pf + "vDesc", det.prod.Vdesc.ToString("#0.00").Replace(",", ".")) : null),
                                                   (det.prod.VOutro != 0 ? new XElement(pf + "vOutro", det.prod.VOutro.ToString("#0.00").Replace(",", ".")) : null), //NFe_2.0 
                                                   (det.prod.IndTot != null ? new XElement(pf + "indTot", det.prod.IndTot.ToString()) : null), //NFe_2.0                                                   
                                                   ((det.prod.belDI != null) ? from DI in det.prod.belDI
                                                                               where DI.nDI != null
                                                                                     && DI.xLocDesemb != null
                                                                                     && DI.UFDesemb != null
                                                                                     && DI.cExportador != null
                                                                               select new XElement(pf + "DI",
                                                                                  (DI.nDI != "" ? new XElement(pf + "nDI", DI.nDI) : null),
                                                                                   new XElement(pf + "dDI", DI.DDI.ToString("yyyy-MM-dd")),
                                                                                  (DI.xLocDesemb != "" ? new XElement(pf + "xLocDesemb", DI.xLocDesemb) : null),
                                                                                  (DI.UFDesemb != "" ? new XElement(pf + "UFDesemb", DI.UFDesemb) : null),
                                                                                   new XElement(pf + "dDesemb", DI.dDesemb.ToString("yyyy-MM-dd")),
                                                                                  (DI.cExportador != "" ? new XElement(pf + "cExportador", DI.cExportador) : null),
                                                                                   from adic in DI.adi
                                                                                   where adic.cFabricante != null
                                                                                   select new XElement(pf + "adi",
                                                                                       new XElement(pf + "nAdicao", adic.nAdicao),
                                                                                       new XElement(pf + "nSeqAdic", adic.nSeqAdic),
                                                                                      (adic.cFabricante != "" ? new XElement(pf + "cFabricante", adic.cFabricante) : null),
                                                                                       new XElement(pf + "vDescDI", adic.vDescDI))) : null),
                                                 ((det.prod.XPed != "") ? new XElement(pf + "xPed", det.prod.XPed) : null),
                                                 ((det.prod.NItemPed != "") ? new XElement(pf + "nItemPed", det.prod.NItemPed) : null),
                                                 (det.prod.nFCI != "" ? new XElement(pf + "nFCI", det.prod.nFCI.ToString()) : null), //29280

                                                 (det.prod.belMed != null ?
                                                            from med in det.prod.belMed
                                                            select new XElement(pf + "med",
                                                                            new XElement(pf + "nLote", med.Nlote),
                                                                            new XElement(pf + "qLote", Convert.ToDecimal(med.Qlote).ToString("#0.000").Replace(",", ".")),
                                                                            new XElement(pf + "dFab", med.DFab.ToString("yyyy-MM-dd")),
                                                                            new XElement(pf + "dVal", med.Dval.ToString("yyyy-MM-dd")),
                                                                            new XElement(pf + "vPMC", med.Vpmc)) : null),

                                                 (det.prod.belcomb != null ?
                                                        new XElement(pf + "comb",
                                                                            new XElement(pf + "cProdANP", det.prod.belcomb.cProdANP),
                                                                            new XElement(pf + "UFCons", det.prod.belcomb.UFCons)) : null)),

                                                                                          new XElement(pf + "imposto",
                                new XElement(pf + "vTotTrib", det.prod.vTotTrib.ToString("#0.00").Replace(",", ".")),

                                                   //---------------ICMS-----------------//

                                                   new XElement(pf + "ICMS",

                                                       //-------------ICMS00-------------//

                                                       (det.imposto.belIcms.belIcms00 != null ?
                                                       new XElement(pf + "ICMS00",
                                                            (det.imposto.belIcms.belIcms00.Orig != null ? new XElement(pf + "orig", det.imposto.belIcms.belIcms00.Orig.ToString()) : null),
                                                            (det.imposto.belIcms.belIcms00.Cst != null ? new XElement(pf + "CST", det.imposto.belIcms.belIcms00.Cst.ToString()) : null),
                                                            (det.imposto.belIcms.belIcms00.Modbc != null ? new XElement(pf + "modBC", det.imposto.belIcms.belIcms00.Modbc.ToString()) : null),
                                                            (det.imposto.belIcms.belIcms00.Vbc != null ? new XElement(pf + "vBC", det.imposto.belIcms.belIcms00.Vbc.ToString("#0.00").Replace(",", ".")) : null),
                                                            (det.imposto.belIcms.belIcms00.Picms != null ? new XElement(pf + "pICMS", det.imposto.belIcms.belIcms00.Picms.ToString("#0.00").Replace(",", ".")) : null),
                                                            (det.imposto.belIcms.belIcms00.Vicms != null ? new XElement(pf + "vICMS", det.imposto.belIcms.belIcms00.Vicms.ToString("#0.00").Replace(",", ".")) : null)) : null),

                                                        //-------------ICMS10-------------//

                                                        (det.imposto.belIcms.belIcms10 != null ?
                                                        new XElement(pf + "ICMS10",
                                                            (det.imposto.belIcms.belIcms10.Orig != null ? new XElement(pf + "orig", det.imposto.belIcms.belIcms10.Orig.ToString()) : null),
                                                            (det.imposto.belIcms.belIcms10.Cst != null ? new XElement(pf + "CST", det.imposto.belIcms.belIcms10.Cst.ToString()) : null),
                                                            (det.imposto.belIcms.belIcms10.Modbc != null ? new XElement(pf + "modBC", det.imposto.belIcms.belIcms10.Modbc.ToString()) : null),
                                                            (det.imposto.belIcms.belIcms10.Vbc != null ? new XElement(pf + "vBC", det.imposto.belIcms.belIcms10.Vbc.ToString("#0.00").Replace(",", ".")) : null),
                                                            (det.imposto.belIcms.belIcms10.Picms != null ? new XElement(pf + "pICMS", det.imposto.belIcms.belIcms10.Picms.ToString("#0.00").Replace(",", ".")) : null),
                                                            (det.imposto.belIcms.belIcms10.Vicms != null ? new XElement(pf + "vICMS", det.imposto.belIcms.belIcms10.Vicms.ToString("#0.00").Replace(",", ".")) : null),
                                                            (det.imposto.belIcms.belIcms10.Modbcst != null ? new XElement(pf + "modBCST", det.imposto.belIcms.belIcms10.Modbcst.ToString()) : null),
                                                            (det.imposto.belIcms.belIcms10.Pmvast != 0 ? new XElement(pf + "pMVAST", det.imposto.belIcms.belIcms10.Pmvast.ToString("#0.00").Replace(",", ".")) : null), //Claudinei - o.s. sem - 11/03/2010
                                                            (det.imposto.belIcms.belIcms10.Predbcst.ToString() != "0" ? new XElement(pf + "pRedBCST", det.imposto.belIcms.belIcms10.Predbcst.ToString("#0.00").Replace(",", ".")) : null),
                                                            (det.imposto.belIcms.belIcms10.Vbcst != null ? new XElement(pf + "vBCST", det.imposto.belIcms.belIcms10.Vbcst.ToString("#0.00").Replace(",", ".")) : null),
                                                            (det.imposto.belIcms.belIcms10.Picmsst != null ? new XElement(pf + "pICMSST", det.imposto.belIcms.belIcms10.Picmsst.ToString("#0.00").Replace(",", ".")) : null),
                                                            (det.imposto.belIcms.belIcms10.Vicmsst != null ? new XElement(pf + "vICMSST", det.imposto.belIcms.belIcms10.Vicmsst.ToString("#0.00").Replace(",", ".")) : null)) : null),

                                                        //-------------ICMS20-------------//

                                                        (det.imposto.belIcms.belIcms20 != null ?
                                                        new XElement(pf + "ICMS20",
                                                            (det.imposto.belIcms.belIcms20.Orig != null ? new XElement(pf + "orig", det.imposto.belIcms.belIcms20.Orig.ToString()) : null),
                                                            (det.imposto.belIcms.belIcms20.Cst != null ? new XElement(pf + "CST", det.imposto.belIcms.belIcms20.Cst.ToString()) : null),
                                                            (det.imposto.belIcms.belIcms20.Modbc != null ? new XElement(pf + "modBC", det.imposto.belIcms.belIcms20.Modbc.ToString()) : null),
                                                            (det.imposto.belIcms.belIcms20.Predbc != null ? new XElement(pf + "pRedBC", det.imposto.belIcms.belIcms20.Predbc.ToString("#0.00").Replace(",", ".")) : null),
                                                            (det.imposto.belIcms.belIcms20.Vbc != null ? new XElement(pf + "vBC", det.imposto.belIcms.belIcms20.Vbc.ToString("#0.00").Replace(",", ".")) : null),
                                                            (det.imposto.belIcms.belIcms20.Picms != null ? new XElement(pf + "pICMS", det.imposto.belIcms.belIcms20.Picms.ToString("#0.00").Replace(",", ".")) : null),
                                                            (det.imposto.belIcms.belIcms20.Vicms != null ? new XElement(pf + "vICMS", det.imposto.belIcms.belIcms20.Vicms.ToString("#0.00").Replace(",", ".")) : null)) : null),

                                                        //-------------ICMS30-------------//

                                                        (det.imposto.belIcms.belIcms30 != null ?
                                                        new XElement(pf + "ICMS30",
                                                            (det.imposto.belIcms.belIcms30.Orig != null ? new XElement(pf + "orig", det.imposto.belIcms.belIcms30.Orig.ToString()) : null),
                                                            (det.imposto.belIcms.belIcms30.Cst != null ? new XElement(pf + "CST", det.imposto.belIcms.belIcms30.Cst.ToString()) : null),
                                                            (det.imposto.belIcms.belIcms30.Modbcst != null ? new XElement(pf + "modBCST", det.imposto.belIcms.belIcms30.Modbcst.ToString()) : null),
                                                            (det.imposto.belIcms.belIcms30.Pmvast != 0 ? new XElement(pf + "pMVAST", det.imposto.belIcms.belIcms30.Pmvast.ToString("#0.00").Replace(",", ".")) : null), //Claudinei - o.s. sem - 12/03/2010
                                                            (det.imposto.belIcms.belIcms30.Predbcst.ToString() != "0" ? new XElement(pf + "pRedBCST", det.imposto.belIcms.belIcms30.Predbcst.ToString("#0.00").Replace(",", ".")) : null),
                                                            (det.imposto.belIcms.belIcms30.Vbcst != null ? new XElement(pf + "vBCST", det.imposto.belIcms.belIcms30.Vbcst.ToString("#0.00").Replace(",", ".")) : null),
                                                            (det.imposto.belIcms.belIcms30.Picmsst != null ? new XElement(pf + "pICMSST", det.imposto.belIcms.belIcms30.Picmsst.ToString("#0.00").Replace(",", ".")) : null),
                                                            (det.imposto.belIcms.belIcms30.Vicmsst != null ? new XElement(pf + "vICMSST", det.imposto.belIcms.belIcms30.Vicmsst.ToString("#0.00").Replace(",", ".")) : null)) : null),

                                                        //-------------ICMS40-------------//

                                                        (det.imposto.belIcms.belIcms40 != null ?
                                                        new XElement(pf + "ICMS40",
                                                            (det.imposto.belIcms.belIcms40.Orig != null ? new XElement(pf + "orig", det.imposto.belIcms.belIcms40.Orig.ToString()) : null),
                                                            (det.imposto.belIcms.belIcms40.Cst != null ? new XElement(pf + "CST", det.imposto.belIcms.belIcms40.Cst.ToString()) : null),
                                                            (det.imposto.belIcms.belIcms40.Vicms > 0 ? new XElement(pf + "vICMS", det.imposto.belIcms.belIcms40.Vicms.ToString("#0.00").Replace(",", ".")) : null), //NFe_2.0
                                                            (det.imposto.belIcms.belIcms40.Vicms > 0 ? new XElement(pf + "motDesICMS", det.imposto.belIcms.belIcms40.motDesICMS.ToString()) : null)) : null),//NFe_2.0

                                                        //-------------ICMS41-------------//

                                                        (det.imposto.belIcms.belIcms41 != null ?
                                                        new XElement(pf + "ICMS41",
                                                            (det.imposto.belIcms.belIcms41.Orig != null ? new XElement(pf + "orig", det.imposto.belIcms.belIcms41.Orig.ToString()) : null),
                                                            (det.imposto.belIcms.belIcms41.Cst != null ? new XElement(pf + "CST", det.imposto.belIcms.belIcms41.Cst.ToString()) : null),
                                                            (det.imposto.belIcms.belIcms41.Vicms > 0 ? new XElement(pf + "vICMS", det.imposto.belIcms.belIcms41.Vicms.ToString("#0.00").Replace(",", ".")) : null),//NFe_2.0
                                                            (det.imposto.belIcms.belIcms41.motDesICMS > 0 ? new XElement(pf + "motDesICMS", det.imposto.belIcms.belIcms41.motDesICMS.ToString()) : null)) : null),//NFe_2.0

                                                        //-------------ICMS50-------------//

                                                        (det.imposto.belIcms.belIcms50 != null ?
                                                        new XElement(pf + "ICMS50",
                                                            (det.imposto.belIcms.belIcms50.Orig != null ? new XElement(pf + "orig", det.imposto.belIcms.belIcms50.Orig.ToString()) : null),
                                                            (det.imposto.belIcms.belIcms50.Cst != null ? new XElement(pf + "CST", det.imposto.belIcms.belIcms50.Cst.ToString()) : null),
                                                                (det.imposto.belIcms.belIcms50.Vicms > 0 ? new XElement(pf + "vICMS", det.imposto.belIcms.belIcms50.Vicms.ToString("#0.00").Replace(",", ".")) : null),//NFe_2.0
                                                            (det.imposto.belIcms.belIcms50.motDesICMS > 0 ? new XElement(pf + "motDesICMS", det.imposto.belIcms.belIcms50.motDesICMS.ToString()) : null)) : null),//NFe_2.0

                                                        //-------------ICMS51-------------//

                                                        (det.imposto.belIcms.belIcms51 != null ?
                                                        new XElement(pf + "ICMS51",
                                                            (det.imposto.belIcms.belIcms51.Orig != null ? new XElement(pf + "orig", det.imposto.belIcms.belIcms51.Orig.ToString()) : null),
                                                            (det.imposto.belIcms.belIcms51.Cst != null ? new XElement(pf + "CST", det.imposto.belIcms.belIcms51.Cst.ToString()) : null),
                                                            (det.imposto.belIcms.belIcms51.Modbc != null ? new XElement(pf + "modBC", det.imposto.belIcms.belIcms51.Modbc.ToString()) : null),
                                                            (det.imposto.belIcms.belIcms51.Predbc != null ? new XElement(pf + "pRedBC", det.imposto.belIcms.belIcms51.Predbc.ToString("#0.00").Replace(",", ".")) : null),
                                                            (det.imposto.belIcms.belIcms51.Vbc != null ? new XElement(pf + "vBC", det.imposto.belIcms.belIcms51.Vbc.ToString("#0.00").Replace(",", ".")) : null),
                                                            (det.imposto.belIcms.belIcms51.Picms != null ? new XElement(pf + "pICMS", det.imposto.belIcms.belIcms51.Picms.ToString("#0.00").Replace(",", ".")) : null),
                                                            (det.imposto.belIcms.belIcms51.Vicms != null ? new XElement(pf + "vICMS", det.imposto.belIcms.belIcms51.Vicms.ToString("#0.00").Replace(",", ".")) : null)) : null),

                                                        //-------------ICMS60-------------//

                                                        (det.imposto.belIcms.belIcms60 != null ?
                                                        new XElement(pf + "ICMS60",//Danner - o.s. sem - 12/03/2010
                                                            (det.imposto.belIcms.belIcms60.Orig != null ? new XElement(pf + "orig", det.imposto.belIcms.belIcms60.Orig.ToString()) : null),
                                                            (det.imposto.belIcms.belIcms60.Cst != null ? new XElement(pf + "CST", det.imposto.belIcms.belIcms60.Cst.ToString()) : null),
                                                            (det.imposto.belIcms.belIcms60.Vbcstret != null ? new XElement(pf + "vBCSTRet", det.imposto.belIcms.belIcms60.Vbcstret.ToString("#0.00").Replace(",", ".")) : null),//NFe_2.0 - Mudança de nome de Tag
                                                            (det.imposto.belIcms.belIcms60.Vicmsstret != null ? new XElement(pf + "vICMSSTRet", det.imposto.belIcms.belIcms60.Vicmsstret.ToString("#0.00").Replace(",", ".")) : null)) : null),//NFe_2.0 Mudança de nome de Tag

                                                        //-------------ICMS70-------------//

                                                        (det.imposto.belIcms.belIcms70 != null ?
                                                        new XElement(pf + "ICMS70",
                                                            (det.imposto.belIcms.belIcms70.Orig != null ? new XElement(pf + "orig", det.imposto.belIcms.belIcms70.Orig.ToString()) : null),
                                                            (det.imposto.belIcms.belIcms70.Cst != null ? new XElement(pf + "CST", det.imposto.belIcms.belIcms70.Cst.ToString()) : null),
                                                            (det.imposto.belIcms.belIcms70.Modbc != null ? new XElement(pf + "modBC", det.imposto.belIcms.belIcms70.Modbc.ToString()) : null),
                                                            (det.imposto.belIcms.belIcms70.Predbc != null ? new XElement(pf + "pRedBC", det.imposto.belIcms.belIcms70.Predbc.ToString("#0.00").Replace(',', '.')) : null), //Danner - o.s. 24091 - 06/02/2010
                                                            (det.imposto.belIcms.belIcms70.Vbc != null ? new XElement(pf + "vBC", det.imposto.belIcms.belIcms70.Vbc.ToString("#0.00").Replace(",", ".")) : null),
                                                            (det.imposto.belIcms.belIcms70.Picms != null ? new XElement(pf + "pICMS", det.imposto.belIcms.belIcms70.Picms.ToString("#0.00").Replace(",", ".")) : null),
                                                            (det.imposto.belIcms.belIcms70.Vicms != null ? new XElement(pf + "vICMS", det.imposto.belIcms.belIcms70.Vicms.ToString("#0.00").Replace(",", ".")) : null),
                                                            (det.imposto.belIcms.belIcms70.Modbcst != null ? new XElement(pf + "modBCST", det.imposto.belIcms.belIcms70.Modbcst.ToString()) : null),
                                                            (det.imposto.belIcms.belIcms70.Pmvast != 0 ? new XElement(pf + "pMVAST", det.imposto.belIcms.belIcms70.Pmvast.ToString("#0.00").Replace(",", ".")) : null), //Claudinei - o.s. sem - 12/03/2010
                                                            (det.imposto.belIcms.belIcms70.Predbcst.ToString() != "0" ? new XElement(pf + "pRedBCST", det.imposto.belIcms.belIcms70.Predbcst.ToString("#0.00").Replace(",", ".")) : null),
                                                            (det.imposto.belIcms.belIcms70.Vbcst != null ? new XElement(pf + "vBCST", det.imposto.belIcms.belIcms70.Vbcst.ToString("#0.00").Replace(",", ".")) : null),
                                                            (det.imposto.belIcms.belIcms70.Picmsst != null ? new XElement(pf + "pICMSST", det.imposto.belIcms.belIcms70.Picmsst.ToString("#0.00").Replace(",", ".")) : null),
                                                            (det.imposto.belIcms.belIcms70.Vicmsst != null ? new XElement(pf + "vICMSST", det.imposto.belIcms.belIcms70.Vicmsst.ToString("#0.00").Replace(",", ".")) : null)) : null),

                                                        //-------------ICMS90-------------//

                                                        (det.imposto.belIcms.belIcms90 != null ?
                                                        new XElement(pf + "ICMS90",
                                                            (det.imposto.belIcms.belIcms90.Orig != null ? new XElement(pf + "orig", det.imposto.belIcms.belIcms90.Orig.ToString()) : null),
                                                            (det.imposto.belIcms.belIcms90.Cst != null ? new XElement(pf + "CST", det.imposto.belIcms.belIcms90.Cst.ToString()) : null),
                                                            (det.imposto.belIcms.belIcms90.Modbc != null ? new XElement(pf + "modBC", det.imposto.belIcms.belIcms90.Modbc.ToString()) : null),
                                                            (det.imposto.belIcms.belIcms90.Vbc != null ? new XElement(pf + "vBC", det.imposto.belIcms.belIcms90.Vbc.ToString("#0.00").Replace(",", ".")) : null),
                                                            (det.imposto.belIcms.belIcms90.Predbc != 0 ? new XElement(pf + "pRedBC", det.imposto.belIcms.belIcms90.Predbc.ToString("#0.00").Replace(',', '.')) : null), //Danner - o.s. 24091 - 06/02/2010 //Claudinei - o.s. sem - 24/02/2010
                                                            (det.imposto.belIcms.belIcms90.Picms != null ? new XElement(pf + "pICMS", det.imposto.belIcms.belIcms90.Picms.ToString("#0.00").Replace(",", ".")) : null),
                                                            (det.imposto.belIcms.belIcms90.Vicms != null ? new XElement(pf + "vICMS", det.imposto.belIcms.belIcms90.Vicms.ToString("#0.00").Replace(",", ".")) : null),
                                                            (det.imposto.belIcms.belIcms90.Modbcst != null ? new XElement(pf + "modBCST", det.imposto.belIcms.belIcms90.Modbcst.ToString()) : null),
                                                            (det.imposto.belIcms.belIcms90.Pmvast != 0 ? new XElement(pf + "pMVAST", det.imposto.belIcms.belIcms90.Pmvast.ToString("#0.00").Replace(",", ".")) : null), //Claudinei - o.s. 24076 - 01/02/2010
                                                            (det.imposto.belIcms.belIcms90.Predbcst != 0 ? new XElement(pf + "pRedBCST", det.imposto.belIcms.belIcms90.Predbcst.ToString("#0.00").Replace(",", ".")) : null), //Claudinei - o.s. 24076 - 01/02/2010
                                                            (det.imposto.belIcms.belIcms90.Vbcst != null ? new XElement(pf + "vBCST", det.imposto.belIcms.belIcms90.Vbcst.ToString("#0.00").Replace(",", ".")) : null),
                                                            (det.imposto.belIcms.belIcms90.Picmsst != null ? new XElement(pf + "pICMSST", det.imposto.belIcms.belIcms90.Picmsst.ToString("#0.00").Replace(",", ".")) : null),
                                                            (det.imposto.belIcms.belIcms90.Vicmsst != null ? new XElement(pf + "vICMSST", det.imposto.belIcms.belIcms90.Vicmsst.ToString("#0.00").Replace(",", ".")) : null)) : null),

                                                       //-------------ICMSSN101--------------//
                                                       (det.imposto.belIcms.belICMSSN101 != null ?
                                                            new XElement(pf + "ICMSSN101",
                                                               (det.imposto.belIcms.belICMSSN101.orig != null ? new XElement(pf + "orig", det.imposto.belIcms.belICMSSN101.orig.ToString()) : null),
                                                               new XElement(pf + "CSOSN", det.imposto.belIcms.belICMSSN101.CSOSN.ToString()),
                                                               (det.imposto.belIcms.belICMSSN101.pCredSN != null ? new XElement(pf + "pCredSN", det.imposto.belIcms.belICMSSN101.pCredSN.ToString("#0.00").Replace(",", ".")) : null),
                                                               (det.imposto.belIcms.belICMSSN101.vCredICMSSN != null ? new XElement(pf + "vCredICMSSN", det.imposto.belIcms.belICMSSN101.vCredICMSSN.ToString("#0.00").Replace(",", ".")) : null)) : null),

                                                      //-------------ICMSSN102--------------//
                                                       (det.imposto.belIcms.belICMSSN102 != null ?
                                                            new XElement(pf + "ICMSSN102",
                                                               (det.imposto.belIcms.belICMSSN102.orig != null ? new XElement(pf + "orig", det.imposto.belIcms.belICMSSN102.orig.ToString()) : null),
                                                               new XElement(pf + "CSOSN", det.imposto.belIcms.belICMSSN102.CSOSN.ToString())) : null),

                                                      //-------------ICMSSN201--------------//
                                                       (det.imposto.belIcms.belICMSSN201 != null ?
                                                            new XElement(pf + (det.imposto.belIcms.belICMSSN201.CSOSN.Equals("201") ? "ICMSSN201" : "ICMSSN202"),
                                                               (det.imposto.belIcms.belICMSSN201.orig != null ? new XElement(pf + "orig", det.imposto.belIcms.belICMSSN201.orig.ToString()) : null),
                                                               new XElement(pf + "CSOSN", det.imposto.belIcms.belICMSSN201.CSOSN.ToString()),
                                                               (det.imposto.belIcms.belICMSSN201.modBCST != null ? new XElement(pf + "modBCST", det.imposto.belIcms.belICMSSN201.modBCST.ToString()) : null),
                                                               (det.imposto.belIcms.belICMSSN201.pMVAST != 0 ? new XElement(pf + "pMVAST", det.imposto.belIcms.belICMSSN201.pMVAST.ToString("#0.00").Replace(",", ".")) : null),
                                                               (det.imposto.belIcms.belICMSSN201.pRedBCST.ToString() != "0" ? new XElement(pf + "pRedBCST", det.imposto.belIcms.belICMSSN201.pRedBCST.ToString("#0.00").Replace(",", ".")) : null),
                                                               (det.imposto.belIcms.belICMSSN201.vBCST != null ? new XElement(pf + "vBCST", det.imposto.belIcms.belICMSSN201.vBCST.ToString("#0.00").Replace(",", ".")) : null),
                                                               (det.imposto.belIcms.belICMSSN201.pICMSST != null ? new XElement(pf + "pICMSST", det.imposto.belIcms.belICMSSN201.pICMSST.ToString("#0.00").Replace(",", ".")) : null),
                                                               (det.imposto.belIcms.belICMSSN201.vICMSST != null ? new XElement(pf + "vICMSST", det.imposto.belIcms.belICMSSN201.vICMSST.ToString("#0.00").Replace(",", ".")) : null),
                                                               ((det.imposto.belIcms.belICMSSN201.pCredSN != null && det.imposto.belIcms.belICMSSN201.CSOSN.Equals("201")) ? new XElement(pf + "pCredSN", det.imposto.belIcms.belICMSSN201.pCredSN.ToString("#0.00").Replace(",", ".")) : null),
                                                               ((det.imposto.belIcms.belICMSSN201.vCredICMSSN != null && det.imposto.belIcms.belICMSSN201.CSOSN.Equals("201")) ? new XElement(pf + "vCredICMSSN", det.imposto.belIcms.belICMSSN201.vCredICMSSN.ToString("#0.00").Replace(",", ".")) : null)) : null),

                                                      //-------------ICMSSN500--------------//
                                                       (det.imposto.belIcms.belICMSSN500 != null ?
                                                            new XElement(pf + "ICMSSN500",
                                                               (det.imposto.belIcms.belICMSSN500.orig != null ? new XElement(pf + "orig", det.imposto.belIcms.belICMSSN500.orig.ToString()) : null),
                                                               new XElement(pf + "CSOSN", det.imposto.belIcms.belICMSSN500.CSOSN.ToString()),
                                                               (det.imposto.belIcms.belICMSSN500.vBCSTRet != null ? new XElement(pf + "vBCSTRet", det.imposto.belIcms.belICMSSN500.vBCSTRet.ToString("#0.00").Replace(",", ".")) : null),
                                                               (det.imposto.belIcms.belICMSSN500.vICMSSTRet != null ? new XElement(pf + "vICMSSTRet", det.imposto.belIcms.belICMSSN500.vICMSSTRet.ToString("#0.00").Replace(",", ".")) : null)) : null),

                                                      //-------------ICMSSN900--------------//
                                //(det.imposto.belIcms.belICMSSN900 != null ?
                                //     new XElement(pf + "ICMSSN900",
                                //        (det.imposto.belIcms.belICMSSN900.orig != null ? new XElement(pf + "orig", det.imposto.belIcms.belICMSSN900.orig.ToString()) : null),
                                //        new XElement(pf + "CSOSN", det.imposto.belIcms.belICMSSN900.CSOSN.ToString())) : null)),
                                //(det.imposto.belIcms.belICMSSN900.modBC != null ? new XElement(pf + "modBC", det.imposto.belIcms.belICMSSN900.modBC.ToString()) : null),
                                //(det.imposto.belIcms.belICMSSN900.vBC != null ? new XElement(pf + "vBC", det.imposto.belIcms.belICMSSN900.vBC.ToString("#0.00").Replace(",", ".")) : null),
                                //(det.imposto.belIcms.belICMSSN900.pRedBC != null ? new XElement(pf + "pRedBC", det.imposto.belIcms.belICMSSN900.pRedBC.ToString("#0.00").Replace(",", ".")) : null),
                                //(det.imposto.belIcms.belICMSSN900.pICMS != null ? new XElement(pf + "pICMS", det.imposto.belIcms.belICMSSN900.pICMS.ToString("#0.00").Replace(",", ".")) : null),
                                //(det.imposto.belIcms.belICMSSN900.vICMS != null ? new XElement(pf + "vICMS", det.imposto.belIcms.belICMSSN900.vICMS.ToString("#0.00").Replace(",", ".")) : null),
                                //(det.imposto.belIcms.belICMSSN900.modBCST != null ? new XElement(pf + "modBCST", det.imposto.belIcms.belICMSSN900.modBCST.ToString()) : null),
                                //(det.imposto.belIcms.belICMSSN900.pMVAST != null ? new XElement(pf + "pMVAST", det.imposto.belIcms.belICMSSN900.pMVAST.ToString("#0.00").Replace(",", ".")) : null),
                                //(det.imposto.belIcms.belICMSSN900.pRedBCST != null ? new XElement(pf + "pRedBCST", det.imposto.belIcms.belICMSSN900.pRedBCST.ToString("#0.00").Replace(",", ".")) : null),
                                //(det.imposto.belIcms.belICMSSN900.vBCST != null ? new XElement(pf + "vBCST", det.imposto.belIcms.belICMSSN900.vBCST.ToString("#0.00").Replace(",", ".")) : null),
                                //(det.imposto.belIcms.belICMSSN900.pICMSST != null ? new XElement(pf + "pICMSST", det.imposto.belIcms.belICMSSN900.pICMSST.ToString("#0.00").Replace(",", ".")) : null),
                                //(det.imposto.belIcms.belICMSSN900.vICMSST != null ? new XElement(pf + "vICMSST", det.imposto.belIcms.belICMSSN900.vICMSST.ToString("#0.00").Replace(",", ".")) : null),
                                //(det.imposto.belIcms.belICMSSN900.vBCSTRet != null ? new XElement(pf + "vBCSTRet", det.imposto.belIcms.belICMSSN900.vBCSTRet.ToString("#0.00").Replace(",", ".")) : null),
                                //(det.imposto.belIcms.belICMSSN900.vICMSSTRet != null ? new XElement(pf + "vICMSSTRet", det.imposto.belIcms.belICMSSN900.vICMSSTRet.ToString("#0.00").Replace(",", ".")) : null),
                                //(det.imposto.belIcms.belICMSSN900.pCredSN != null ? new XElement(pf + "pCredSN", det.imposto.belIcms.belICMSSN900.pCredSN.ToString("#0.00").Replace(",", ".")) : null),
                                //(det.imposto.belIcms.belICMSSN900.vCredICMSSN != null ? new XElement(pf + "vCredICMSSN", det.imposto.belIcms.belICMSSN900.vCredICMSSN.ToString("#0.00").Replace(",", ".")) : null)) : null)),

                                (det.imposto.belIcms.belICMSSN900 != null ?
                                                            new XElement(pf + "ICMSSN900",
                                                               (det.imposto.belIcms.belICMSSN900.orig != null ? new XElement(pf + "orig", det.imposto.belIcms.belICMSSN900.orig.ToString()) : null),
                                                               new XElement(pf + "CSOSN", det.imposto.belIcms.belICMSSN900.CSOSN.ToString()),
                                                                    (det.imposto.belIcms.belICMSSN900.modBC != null ? new XElement(pf + "modBC", det.imposto.belIcms.belICMSSN900.modBC.ToString()) : null),
                                                                    (det.imposto.belIcms.belICMSSN900.vBC != null ? new XElement(pf + "vBC", Convert.ToDecimal(det.imposto.belIcms.belICMSSN900.vBC).ToString("#0.00").Replace(",", ".")) : null),
                                                                    (det.imposto.belIcms.belICMSSN900.pRedBC > 0 ? new XElement(pf + "pRedBC", Convert.ToDecimal(det.imposto.belIcms.belICMSSN900.pRedBC).ToString("#0.00").Replace(",", ".")) : null),
                                                                    (det.imposto.belIcms.belICMSSN900.pICMS != null ? new XElement(pf + "pICMS", Convert.ToDecimal(det.imposto.belIcms.belICMSSN900.pICMS).ToString("#0.00").Replace(",", ".")) : null),
                                                                    (det.imposto.belIcms.belICMSSN900.vICMS != null ? new XElement(pf + "vICMS", Convert.ToDecimal(det.imposto.belIcms.belICMSSN900.vICMS).ToString("#0.00").Replace(",", ".")) : null),
                                                                    (det.imposto.belIcms.belICMSSN900.modBCST != null ? new XElement(pf + "modBCST", Convert.ToDecimal(det.imposto.belIcms.belICMSSN900.modBCST).ToString()) : null),
                                                                    (det.imposto.belIcms.belICMSSN900.pMVAST > 0 ? new XElement(pf + "pMVAST", Convert.ToDecimal(det.imposto.belIcms.belICMSSN900.pMVAST).ToString("#0.00").Replace(",", ".")) : null),
                                                                    (det.imposto.belIcms.belICMSSN900.pRedBCST > 0 ? new XElement(pf + "pRedBCST", Convert.ToDecimal(det.imposto.belIcms.belICMSSN900.pRedBCST).ToString("#0.00").Replace(",", ".")) : null),
                                                                    (det.imposto.belIcms.belICMSSN900.vBCST != null ? new XElement(pf + "vBCST", Convert.ToDecimal(det.imposto.belIcms.belICMSSN900.vBCST).ToString("#0.00").Replace(",", ".")) : null),
                                                                    (det.imposto.belIcms.belICMSSN900.pICMSST != null ? new XElement(pf + "pICMSST", Convert.ToDecimal(det.imposto.belIcms.belICMSSN900.pICMSST).ToString("#0.00").Replace(",", ".")) : null),
                                                                    (det.imposto.belIcms.belICMSSN900.vICMSST != null ? new XElement(pf + "vICMSST", Convert.ToDecimal(det.imposto.belIcms.belICMSSN900.vICMSST).ToString("#0.00").Replace(",", ".")) : null),
                                                                    //(det.imposto.belIcms.belICMSSN900.vBCSTRet != null ? new XElement(pf + "vBCSTRet", Convert.ToDecimal(det.imposto.belIcms.belICMSSN900.vBCSTRet).ToString("#0.00").Replace(",", ".")) : null),
                                                                    //(det.imposto.belIcms.belICMSSN900.vICMSSTRet != null ? new XElement(pf + "vICMSSTRet", Convert.ToDecimal(det.imposto.belIcms.belICMSSN900.vICMSSTRet).ToString("#0.00").Replace(",", ".")) : null),
                                                                    (det.imposto.belIcms.belICMSSN900.pCredSN != null ? new XElement(pf + "pCredSN", Convert.ToDecimal(det.imposto.belIcms.belICMSSN900.pCredSN).ToString("#0.00").Replace(",", ".")) : null),
                                                                    (det.imposto.belIcms.belICMSSN900.vCredICMSSN != null ? new XElement(pf + "vCredICMSSN", Convert.ToDecimal(det.imposto.belIcms.belICMSSN900.vCredICMSSN).ToString("#0.00").Replace(",", ".")) : null)) : null)),

                                        //---------------IPI-------------//
                                            (det.imposto.belIpi != null ?
                                            new XElement(pf + "IPI",
                                                (det.imposto.belIpi.Clenq != null ?
                                                    new XElement(pf + "clEnq", det.imposto.belIpi.Clenq.ToString()) : null),
                                                (det.imposto.belIpi.Cnpjprod != null ?
                                                    new XElement(pf + "CNPJProd", det.imposto.belIpi.Cnpjprod.ToString()) : null),
                                                (det.imposto.belIpi.Cselo != null ?
                                                    new XElement(pf + "cSelo", det.imposto.belIpi.Cselo.ToString()) : null),
                                                (det.imposto.belIpi.Qselo != null ?
                                                    new XElement(pf + "qSelo", det.imposto.belIpi.Qselo.ToString()) : null),
                                                (det.imposto.belIpi.Cenq != null ?
                                                    new XElement(pf + "cEnq", det.imposto.belIpi.Cenq.ToString()) : null),

                                                //-----------IPITrib-----------//    

                                                (det.imposto.belIpi.belIpitrib != null ?
                                                new XElement(pf + "IPITrib",
                                                    (det.imposto.belIpi.belIpitrib.Cst != null ? new XElement(pf + "CST", det.imposto.belIpi.belIpitrib.Cst.ToString()) : null),
                                                    (det.imposto.belIpi.belIpitrib.Vbc != null ? new XElement(pf + "vBC", det.imposto.belIpi.belIpitrib.Vbc.ToString("#0.00").Replace(",", ".")) : null),
                                                    (det.imposto.belIpi.belIpitrib.Qunid > 0 ? new XElement(pf + "qUnid", det.imposto.belIpi.belIpitrib.Qunid.ToString("#0.0000").Replace(",", ".")) : null),
                                                    (det.imposto.belIpi.belIpitrib.Vunid > 0 ? new XElement(pf + "vUnid", det.imposto.belIpi.belIpitrib.Vunid.ToString("#0.0000").Replace(",", ".")) : null),
                                                    (det.imposto.belIpi.belIpitrib.Pipi != null ? new XElement(pf + "pIPI", det.imposto.belIpi.belIpitrib.Pipi.ToString("#0.00").Replace(",", ".")) : null),
                                                    (det.imposto.belIpi.belIpitrib.Vipi != null ? new XElement(pf + "vIPI", det.imposto.belIpi.belIpitrib.Vipi.ToString("#0.00").Replace(",", ".")) : null)) : null),

                                                //-----------IPINT-----------//

                                                (det.imposto.belIpi.belIpint != null ?
                                                new XElement(pf + "IPINT",
                                                    (det.imposto.belIpi.belIpint != null ? new XElement(pf + "CST", det.imposto.belIpi.belIpint.Cst.ToString()) : null)) : null)) : null),




                                       //--------------II--------------//             
                                       ((!lCfopNotTagII.Contains(det.prod.Cfop)) ?
                                       new XElement(pf + "II",
                                           (det.imposto.belIi.Vbc != null ? new XElement(pf + "vBC", det.imposto.belIi.Vbc.ToString("#0.00").Replace(',', '.')) : null),
                                           (det.imposto.belIi.Vdespadu != null ? new XElement(pf + "vDespAdu", det.imposto.belIi.Vdespadu.ToString("#0.00").Replace(',', '.')) : null),
                                           (det.imposto.belIi.Vii != null ? new XElement(pf + "vII", det.imposto.belIi.Vii.ToString("0.00").Replace(',', '.')) : null),
                                           (det.imposto.belIi.Viof != null ? new XElement(pf + "vIOF", det.imposto.belIi.Viof.ToString("#0.00").Replace(',', '.')) : null)) : null),



                               //----------------PIS------------//

                                 (det.imposto.belPis != null ?
                                 new XElement(pf + "PIS",

                                     //-----------PISAliq----------//

                                     (det.imposto.belPis.belPisaliq != null ?
                                     new XElement(pf + "PISAliq",
                                         (det.imposto.belPis.belPisaliq.Cst != null ? new XElement(pf + "CST", det.imposto.belPis.belPisaliq.Cst.ToString()) : null),
                                         (det.imposto.belPis.belPisaliq.Vbc != null ? new XElement(pf + "vBC", det.imposto.belPis.belPisaliq.Vbc.ToString("#0.00").Replace(",", ".")) : null),
                                         (det.imposto.belPis.belPisaliq.Ppis != null ? new XElement(pf + "pPIS", det.imposto.belPis.belPisaliq.Ppis.ToString("#0.00").Replace(",", ".")) : null),
                                         (det.imposto.belPis.belPisaliq.Vpis != null ? new XElement(pf + "vPIS", det.imposto.belPis.belPisaliq.Vpis.ToString("#0.00").Replace(",", ".")) : null)) : null),

                                    //-----------PISQtde-----------//                               
                                     (det.imposto.belPis.belPisqtde != null ?
                                     new XElement(pf + "PISQtde",
                                         (det.imposto.belPis.belPisqtde.Cst != null ? new XElement(pf + "CST", det.imposto.belPis.belPisqtde.Cst.ToString()) : null),
                                         (det.imposto.belPis.belPisqtde.Qbcprod != 0 ? new XElement(pf + "qBCProd", det.imposto.belPis.belPisqtde.Qbcprod.ToString()) : null),
                                         (det.imposto.belPis.belPisqtde.Valiqprod != null ? new XElement(pf + "vAliqProd", det.imposto.belPis.belPisqtde.Valiqprod.ToString("#0.00").Replace(",", ".")) : null),
                                         (det.imposto.belPis.belPisqtde.Vpis != null ? new XElement(pf + "vPIS", det.imposto.belPis.belPisqtde.Vpis.ToString("#0.00").Replace(",", ".")) : null)) : null),

                                     //----------PISNT------------//

                                     (det.imposto.belPis.belPisnt != null ?
                                     new XElement(pf + "PISNT",
                                         (det.imposto.belPis.belPisnt.Cst != null ? new XElement(pf + "CST", det.imposto.belPis.belPisnt.Cst.ToString()) : null)) : null),

                                     //----------PISOutr-----------//

                                     (det.imposto.belPis.belPisoutr != null ?
                                     new XElement(pf + "PISOutr",
                                         (det.imposto.belPis.belPisoutr.Cst != null ? new XElement(pf + "CST", det.imposto.belPis.belPisoutr.Cst.ToString()) : null),
                                         (det.imposto.belPis.belPisoutr.Vbc != null ? new XElement(pf + "vBC", det.imposto.belPis.belPisoutr.Vbc.ToString("#0.00").Replace(",", ".")) : null),
                                         (det.imposto.belPis.belPisoutr.Ppis != null ? new XElement(pf + "pPIS", det.imposto.belPis.belPisoutr.Ppis.ToString("#0.00").Replace(",", ".")) : null),
                                         (det.imposto.belPis.belPisoutr.Qbcprod != 0 ? new XElement(pf + "qBCProd", det.imposto.belPis.belPisoutr.Qbcprod.ToString()) : null),
                                         (det.imposto.belPis.belPisoutr.Valiqprod != 0 ? new XElement(pf + "vAliqProd", det.imposto.belPis.belPisoutr.Valiqprod.ToString("#0.0000").Replace(",", ".")) : null),
                                         (det.imposto.belPis.belPisoutr.Vpis != null ? new XElement(pf + "vPIS", det.imposto.belPis.belPisoutr.Vpis.ToString("#0.00").Replace(",", ".")) : null)) : null)) : null),







                                 //---------------COFINS---------------//
                                 (det.imposto.belCofins != null ?
                                 new XElement(pf + "COFINS",

                                     //-----------COFINSAliq------------//

                                     (det.imposto.belCofins.belCofinsaliq != null ?
                                     new XElement(pf + "COFINSAliq",
                                         new XElement(pf + "CST", det.imposto.belCofins.belCofinsaliq.Cst.ToString()),
                                         new XElement(pf + "vBC", det.imposto.belCofins.belCofinsaliq.Vbc.ToString("#0.00").Replace(",", ".")),
                                         new XElement(pf + "pCOFINS", det.imposto.belCofins.belCofinsaliq.Pcofins.ToString("#0.00").Replace(",", ".")),
                                         new XElement(pf + "vCOFINS", det.imposto.belCofins.belCofinsaliq.Vcofins.ToString("#0.00").Replace(",", "."))) : null),

                                     //------------COFINSQtde------------//

                                     (det.imposto.belCofins.belCofinsqtde != null ?
                                     new XElement(pf + "COFINSQtde",
                                         new XElement(pf + "CST", det.imposto.belCofins.belCofinsqtde.Cst.ToString()),
                                         new XElement(pf + "pBCProd", det.imposto.belCofins.belCofinsqtde.Qbcprod.ToString()),
                                         new XElement(pf + "vAliqProd", det.imposto.belCofins.belCofinsqtde.Valiqprod.ToString("#0.00").Replace(",", ".")),
                                         new XElement(pf + "vCOFINS", det.imposto.belCofins.belCofinsqtde.Vcofins.ToString("#0.00").Replace(",", "."))) : null),

                                     //------------COFINSNT--------------//

                                     (det.imposto.belCofins.belCofinsnt != null ?
                                     new XElement(pf + "COFINSNT",
                                         (det.imposto.belCofins.belCofinsnt.Cst != null ? new XElement(pf + "CST", det.imposto.belCofins.belCofinsnt.Cst.ToString()) : null)) : null),

                                     //------------COFINSOutr--------------//

                                     (det.imposto.belCofins.belCofinsoutr != null ?
                                     new XElement(pf + "COFINSOutr",
                                         new XElement(pf + "CST", det.imposto.belCofins.belCofinsoutr.Cst.ToString()),
                                         new XElement(pf + "vBC", det.imposto.belCofins.belCofinsoutr.Vbc.ToString("#0.00").Replace(",", ".")),
                                         new XElement(pf + "pCOFINS", det.imposto.belCofins.belCofinsoutr.Pcofins.ToString("#0.00").Replace(",", ".")),
                                         new XElement(pf + "vCOFINS", det.imposto.belCofins.belCofinsoutr.Vcofins.ToString("#0.00").Replace(",", "."))) : null)) : null),


                                 //----------------ISSQN-----------------//

                                 (det.imposto.belIss != null ?
                                 new XElement(pf + "ISSQN",
                                     (det.imposto.belIss.Vbc != 0 ? new XElement(pf + "vBC", det.imposto.belIss.Vbc.ToString("#0.00").Replace(",", ".")) : null),
                                     (det.imposto.belIss.Valiq != 0 ? new XElement(pf + "vAliq", det.imposto.belIss.Valiq.ToString("#0.00").Replace(",", ".")) : null),
                                     (det.imposto.belIss.Vissqn != 0 ? new XElement(pf + "vISSQN", det.imposto.belIss.Vissqn.ToString("#0.00").Replace(",", ".")) : null),
                                     (det.imposto.belIss.Cmunfg != null ? new XElement(pf + "cMunFG", det.imposto.belIss.Cmunfg.ToString()) : null),
                                     (det.imposto.belIss.Clistserv != 0 ? new XElement(pf + "cListServ", det.imposto.belIss.Clistserv.ToString()) : null),
                                     (det.imposto.belIss.cSitTrib != null ? new XElement(pf + "cSitTrib", det.imposto.belIss.cSitTrib.ToString()) : null)) : null)), // NFe_2.0 Tratar item


                                 //-----------INFADPROD-------------//

                                 (!String.IsNullOrEmpty(det.infAdProd.Infadprid) ?
                                     (new XElement(pf + "infAdProd", det.infAdProd.Infadprid.ToString())) : null)));

                            lcondet.Add(condet);
                        }
                        #endregion
                    }
                    catch (Exception x)
                    {
                        throw new Exception("Nota de Sequência - " + nota.ide.Cnf + "Erro na geração do XML, Regiao XML_Detalhes - " + x.Message);
                    }
                    #endregion

                    //Total
                    XContainer contotal;

                    try
                    {
                        belTotal objtotal = nota.total;
                        #region XML_Total

                        contotal = (new XElement(pf + "total",
                                                (objtotal.belIcmstot != null ? new XElement(pf + "ICMSTot",
                                                      new XElement(pf + "vBC", objtotal.belIcmstot.Vbc.ToString("#0.00").Replace(",", ".")),//Danner - o.s. 24271 - 15/03/2010
                                                      new XElement(pf + "vICMS", objtotal.belIcmstot.Vicms.ToString("#0.00").Replace(",", ".")),
                                                      new XElement(pf + "vBCST", objtotal.belIcmstot.Vbcst.ToString("#0.00").Replace(",", ".")),
                                                      new XElement(pf + "vST", objtotal.belIcmstot.Vst.ToString("#0.00").Replace(",", ".")),
                                                      new XElement(pf + "vProd", objtotal.belIcmstot.Vprod.ToString("#0.00").Replace(",", ".")),
                                                      new XElement(pf + "vFrete", objtotal.belIcmstot.Vfrete.ToString("#0.00").Replace(",", ".")),
                                                      new XElement(pf + "vSeg", objtotal.belIcmstot.Vseg.ToString("#0.00").Replace(",", ".")),
                                                      new XElement(pf + "vDesc", objtotal.belIcmstot.Vdesc.ToString("#0.00").Replace(",", ".")),
                                                      new XElement(pf + "vII", objtotal.belIcmstot.Vii.ToString("#0.00").Replace(",", ".")),
                                                      new XElement(pf + "vIPI", objtotal.belIcmstot.Vipi.ToString("#0.00").Replace(",", ".")),
                                                      new XElement(pf + "vPIS", objtotal.belIcmstot.Vpis.ToString("#0.00").Replace(",", ".")),
                                                      new XElement(pf + "vCOFINS", objtotal.belIcmstot.Vcofins.ToString("#0.00").Replace(",", ".")),
                                                      new XElement(pf + "vOutro", objtotal.belIcmstot.Voutro.ToString("#0.00").Replace(",", ".")),
                                                      new XElement(pf + "vNF", objtotal.belIcmstot.Vnf.ToString("#0.00").Replace(",", "."))
                            , new XElement(pf + "vTotTrib", objtotal.belIcmstot.vTotTrib.ToString("#0.00").Replace(",", "."))
                                                      ) : null),



                                                (objtotal.belIssqntot.Vserv > 0 ? new XElement(pf + "ISSQNtot",
                                                    new XElement(pf + "vServ", objtotal.belIssqntot.Vserv.ToString("#0.00").Replace(",", ".")),
                                                    new XElement(pf + "vBC", objtotal.belIssqntot.Vbc.ToString("#0.00").Replace(",", ".")),
                                                    new XElement(pf + "vISS", objtotal.belIssqntot.Viss.ToString("#0.00").Replace(",", ".")),
                                                    (objtotal.belIssqntot.Vpis != 0 ? new XElement(pf + "vPIS", objtotal.belIssqntot.Vpis.ToString("#0.00").Replace(",", ".")) : null),
                                                    (objtotal.belIssqntot.Vcofins != 0 ? new XElement(pf + "vCOFINS", objtotal.belIssqntot.Vcofins.ToString("#0.00").Replace(",", ".")) : null)

                                                    ) : null)));

                        #endregion
                    }
                    catch (Exception x)
                    {
                        throw new Exception("Nota de Sequência - " + nota.ide.Cnf + "Erro na geração do XML, Regiao XML_Total - " + x.Message);
                    }
                    //Fim - Total

                    //Frete
                    XContainer contransp = null;
                    belTransp objtransp;
                    try
                    {
                        objtransp = nota.transp;
                        #region XML_Transporte
                        contransp = (new XElement(pf + "transp",
                                                   new XElement(pf + "modFrete", objtransp.Modfrete.ToString()),
                                                  (objtransp.Modfrete != "9" ? new XElement(pf + "transporta",
                                                       (!String.IsNullOrEmpty(objtransp.belTransportadora.Cnpj) ? new XElement(pf + "CNPJ", objtransp.belTransportadora.Cnpj.ToString()) :
                                                                                                   (objtransp.belTransportadora.Cpf != null ? new XElement(pf + "CPF", objtransp.belTransportadora.Cpf.ToString()) : null)),
                                                       (!String.IsNullOrEmpty(objtransp.belTransportadora.Xnome) ? new XElement(pf + "xNome", objtransp.belTransportadora.Xnome.ToString()) : null),
                                                       (!String.IsNullOrEmpty(objtransp.belTransportadora.Ie) ? new XElement(pf + "IE", objtransp.belTransportadora.Ie.ToString()) : null),
                                                       (!String.IsNullOrEmpty(objtransp.belTransportadora.Xender) ? new XElement(pf + "xEnder", objtransp.belTransportadora.Xender.ToString()) : null),
                                                       (!String.IsNullOrEmpty(objtransp.belTransportadora.Xmun) ? new XElement(pf + "xMun", objtransp.belTransportadora.Xmun.ToString()) : null),
                                                       (!String.IsNullOrEmpty(objtransp.belTransportadora.Uf) ? new XElement(pf + "UF", objtransp.belTransportadora.Uf.ToString()) : null)) : null),
                (objtransp.belRetTransp.Cfop != null && objtransp.Modfrete != "9" ? (new XElement(pf + "retTransp",
                                                       new XElement(pf + "vServ", objtransp.belRetTransp.Vserv.ToString("#0.00").Replace(',', '.')),
                                                       new XElement(pf + "vBCRet", objtransp.belRetTransp.Vbvret.ToString("#0.00").Replace(',', '.')),
                                                       new XElement(pf + "pICMSRet", objtransp.belRetTransp.Picmsret.ToString()),
                                                       new XElement(pf + "vICMSRet", objtransp.belRetTransp.Vicmsret.ToString("#0.00").Replace(',', '.')),
                                                       (!String.IsNullOrEmpty(objtransp.belRetTransp.Cfop) ? new XElement(pf + "CFOP", objtransp.belRetTransp.Cfop.ToString()) : null),
                                                       (!String.IsNullOrEmpty(objtransp.belRetTransp.Cmunfg) ? new XElement(pf + "cMunFG", objtransp.belRetTransp.Cmunfg.ToString()) : null))) : null),
                (objtransp.belVeicTransp.Placa != null && objtransp.Modfrete != "9" ? (new XElement(pf + "veicTransp",
                                                       (!String.IsNullOrEmpty(objtransp.belVeicTransp.Placa) ? new XElement(pf + "placa", objtransp.belVeicTransp.Placa.ToString()) : null),
                                                       (!String.IsNullOrEmpty(objtransp.belVeicTransp.Uf) ? new XElement(pf + "UF", objtransp.belVeicTransp.Uf.ToString()) : null),
                                                       (!String.IsNullOrEmpty(objtransp.belVeicTransp.Rntc) ? new XElement(pf + "RNTC", objtransp.belVeicTransp.Rntc.ToString()) : null))) : null),
                   (objtransp.belReboque.Placa != null && objtransp.Modfrete != "9" ? new XElement(pf + "reboque",
                                                       (!String.IsNullOrEmpty(objtransp.belReboque.Placa) ? new XElement(pf + "placa", objtransp.belReboque.Placa.ToString()) : null),
                                                       (!String.IsNullOrEmpty(objtransp.belReboque.Uf) ? new XElement(pf + "UF", objtransp.belReboque.Uf.ToString()) : null),
                                                       (!String.IsNullOrEmpty(objtransp.belReboque.Rntc) ? new XElement(pf + "RNTC", objtransp.belReboque.Rntc.ToString()) : null)) : null),
                       (objtransp.belVol != null && objtransp.Modfrete != "9" ? new XElement(pf + "vol",
                                                       (objtransp.belVol.Qvol > 0 ? new XElement(pf + "qVol", Convert.ToInt32(objtransp.belVol.Qvol).ToString()) : null),
                                                       (!String.IsNullOrEmpty(objtransp.belVol.Esp) ? new XElement(pf + "esp", objtransp.belVol.Esp.ToString()) : null),
                                                       (!String.IsNullOrEmpty(objtransp.belVol.Marca) ? new XElement(pf + "marca", objtransp.belVol.Marca.ToString()) : null),
                                                       (!String.IsNullOrEmpty(objtransp.belVol.Nvol) ? new XElement(pf + "nVol", objtransp.belVol.Nvol.ToString()) : null),
                                                       new XElement(pf + "pesoL", objtransp.belVol.PesoL.ToString("#0.000").Replace(",", ".")),
                                                       new XElement(pf + "pesoB", objtransp.belVol.PesoB.ToString("#0.000").Replace(",", "."))) : null),
                   (objtransp.belLacres.Nlacre != null && objtransp.Modfrete != "9" ? new XElement(pf + "lacres",
                                                       new XElement(pf + "nLacre", "")) : null)));



                        #endregion
                    }
                    catch (Exception x)
                    {
                        throw new Exception("Nota de Sequência - " + nota.ide.Cnf + " - Erro na geração do XML, Regiao XML_Transporte - " + x.Message);
                    }
                    //Fim - Frete

                    //Duplicata
                    XContainer concobr = null;
                    belCobr objcob;
                    try
                    {
                        objcob = nota.cobr;
                        #region XML_Cobrança
                        if (Acesso.NM_EMPRESA != "LORENZON")
                        {
                            if (objcob.Fat != null)
                            {
                                concobr = (new XElement(pf + "cobr",
                                                          new XElement(pf + "fat",
                                                              new XElement(pf + "nFat", objcob.Fat.Nfat.ToString()),
                                                              (objcob.Fat.Vorig != 0 ? new XElement(pf + "vOrig", objcob.Fat.Vorig.ToString("#0.00").Replace(",", ".")) : null),
                                                              (objcob.Fat.Vdesc != null && objcob.Fat.Vdesc != 0 ? new XElement(pf + "vDesc", objcob.Fat.Vdesc.ToString("#0.00").Replace(",", ".")) : null),
                                                              (objcob.Fat.Vliq != 0 ? new XElement(pf + "vLiq", objcob.Fat.Vliq.ToString("#0.00").Replace(",", ".")) : null)),
                                                              (objcob.Fat.belDup != null ? from dup in objcob.Fat.belDup
                                                                                           select new XElement(pf + "dup", new XElement(pf + "nDup", dup.Ndup.ToString()),
                                                                                                  new XElement(pf + "dVenc", dup.Dvenc.ToString("yyyy-MM-dd")),
                                                                                                  (Acesso.NM_EMPRESA != "LORENZON" ? new XElement(pf + "vDup", dup.Vdup.ToString("#0.00").Replace(",", ".")) : null)) : null)));
                            }
                        }

                        #endregion
                    }
                    catch (Exception x)
                    {
                        throw new Exception("Nota de Sequência - " + nota.ide.Cnf + "Erro na geração do XML, Region XML_Cobrança - " + x.Message);
                    }
                    //Fim - Duplicata

                    //Obs
                    XContainer conobs;
                    belInfAdic objobs;
                    try
                    {
                        objobs = nota.infAdic;
                        #region XML_Obs

                        if (sUF.Equals("EX") && objobs.Infcpl == null)
                        {
                            objobs.Infcpl = "SEM OBSERVACAO";
                        }

                        conobs = new XElement(pf + "infAdic",
                                                    (!String.IsNullOrEmpty(objobs.Infcpl) ?
                                                    new XElement(pf + "infCpl", objobs.Infcpl.ToString()) : null));
                        #endregion
                    }
                    catch (Exception x)
                    {
                        throw new Exception("Nota de Sequência - " + nota.ide.Cnf + "Erro na geração do XML,Regiao XML_Obs - " + x.Message);
                    }
                    //Fim - Obs

                    //OS_25679

                    #region Exporta
                    XContainer conExporta = null;

                    belExporta objExporta = nota.exporta;

                    if ((objExporta.Ufembarq != "") && (objExporta.Xlocembarq != ""))
                    {
                        conExporta = new XElement(pf + "exporta",
                                                    new XElement(pf + "UFEmbarq", objExporta.Ufembarq),
                                                    new XElement(pf + "xLocEmbarq", objExporta.Xlocembarq));
                    }

                    #endregion

                    //Uniao dos Containers
                    try
                    {

                        concabec.Add(coninfnfe);
                        coninfnfe.Add(conide);
                        conide.AddAfterSelf(conemit);
                        conemit.AddAfterSelf(condest);
                        condest.AddAfterSelf(contotal);
                        contotal.AddAfterSelf(contransp);

                        if (concobr != null)
                        {
                            contransp.AddAfterSelf(concobr);
                            if (objobs.Infcpl != null)
                                concobr.AddAfterSelf(conobs);
                        }
                        else
                        {
                            if (objobs.Infcpl != null)
                                contransp.AddAfterSelf(conobs);
                        }
                        if (conExporta != null)
                            conobs.AddAfterSelf(conExporta);

                        foreach (XElement x in lcondet)
                        {
                            contotal.AddBeforeSelf(x);
                        }
                    }
                    catch (Exception x)
                    {
                        throw new Exception("Nota de Sequência - " + nota.ide.Cnf + "Erro na montagem do XML, União dos Containers - " + x.Message);
                    }
                    try
                    {
                        belAssinaXml Assinatura = new belAssinaXml();
                        string nfe = Assinatura.ConfigurarArquivo(concabec.ToString(), "infNFe", Acesso.cert_NFe);
                        nfes.Add(nfe);
                        XElement xnfe = XElement.Parse(nfe);
                        XDocument xdocsalvanfesemlot = new XDocument(xnfe);

                        DirectoryInfo dPastaData = new DirectoryInfo(Pastas.ENVIO + "\\" + nota.chaveNFe.Substring(5, 4));
                        if (!dPastaData.Exists) { dPastaData.Create(); }
                        if (Acesso.TP_EMIS == 2)
                        {
                            xdocsalvanfesemlot.Save(Pastas.CONTINGENCIA + "\\" + nota.chaveNFe.Replace("NFe", "") + "-nfe.xml");
                        }
                        else
                        {
                            xdocsalvanfesemlot.Save(Pastas.ENVIO + "\\" + nota.chaveNFe.Substring(5, 4) + "\\" + nota.chaveNFe.Replace("NFe", "") + "-nfe.xml");
                        }
                    }
                    catch (Exception x)
                    {
                        throw new Exception("Nota de Sequência - " + nota.ide.Cnf + "Erro ao assinar a nfe de sequencia " + nota.ide.Cnf + x.Message);
                    }

                    iCount++;
                }


                string sXmlComp = "";
                foreach (var i in nfes)
                {
                    sXmlComp = sXmlComp + i;
                }
                //Estou inserindo o enviNFe pois se eu transformar o arquivo xml assinado em xml e depois em texto usando um toString,
                //a assinatura se torna invalida. Então depois de assinado do trabalho em forma de texto como xml ateh envia-lo pra fazenda.                        
                string sXmlfull = "<?xml version=\"1.0\" encoding=\"utf-8\"?><enviNFe xmlns=\"http://www.portalfiscal.inf.br/nfe\" versao=\"2.00\"><idLote>" +
                             sNomeArquivo.Substring(7, 15) + "</idLote>" + sXmlComp + "</enviNFe>";


                StreamWriter sw = new StreamWriter(sPathLote);
                sw.Write(sXmlfull);
                sw.Close();

                belValidaXml.ValidarXml("http://www.portalfiscal.inf.br/nfe", Pastas.SCHEMA_NFE + "\\enviNFe_v2.00.xsd", sPathLote);

                for (int i = 0; i < lNotas.Count; i++)
                {


                }

            }
            catch (Exception ex)
            {
                if (!ex.Message.Contains("'vTotTrib'"))
                    throw ex;
            }

        }
    }
}
