using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Linq;
using HLP.GeraXml.dao;
using System.Security.Cryptography.X509Certificates;
using System.Xml;
using HLP.GeraXml.Comum.Static;
using HLP.GeraXml.bel.CTe.infCte.imp;
using System.Xml.Schema;
using HLP.GeraXml.Comum;

namespace HLP.GeraXml.bel.CTe
{
    public class belCriaXml
    {

        public belCriaXml()
        {

        }



        public string GerarXml(belPopulaObjetos objObjetos, int iNumLote)
        {

            try
            {
                List<string> listXml = new List<string>();

                DirectoryInfo dPastaMesAtual = null;
                DirectoryInfo dPastaEnvio = null;
                string sData = daoUtil.GetDateServidor().Date.ToString("dd-MM-yyyy");
                string sRecibo = "";

                XContainer CTe = null;
                XContainer infCte = null;
                XContainer ide = null;
                XContainer toma03 = null;
                XContainer toma4 = null;
                XContainer enderToma = null;
                XContainer emit = null;
                XContainer enderEmit = null;
                XContainer rem = null;
                XContainer enderReme = null;
                XContainer infNF = null;
                XContainer infNFe = null;
                XContainer infOutros = null;
                XContainer exped = null;
                XContainer enderExped = null;
                XContainer receb = null;
                XContainer enderReceb = null;
                XContainer dest = null;
                XContainer enderDest = null;
                XContainer vPrest = null;
                XContainer Comp = null;
                XContainer imp = null;
                XContainer ICMS = null;
                XContainer ICMS00 = null;
                XContainer ICMS20 = null;
                XContainer ICMS45 = null;
                XContainer ICMS60 = null;
                XContainer ICMS90 = null;
                XContainer ICMSOutraUF = null;
                XContainer infCTeNorm = null;
                XContainer seg = null;
                XContainer infModal = null;
                XContainer rodo = null;
                XContainer veic = null;
                XContainer prop = null;
                XContainer moto = null;


                #region Monta Cabecalho

                XNamespace pf = "http://www.portalfiscal.inf.br/cte";
                XNamespace ns = "http://www.w3.org/2001/XMLSchema-instance";



                #endregion

                for (int i = 0; i < objObjetos.objListaConhecimentos.Count; i++)
                {
                    CTe = new XElement(pf + "CTe");
                    belinfCte obj = objObjetos.objListaConhecimentos[i];

                    infCte = (new XElement(pf + "infCte", new XAttribute("versao", Acesso.versaoCTe),
                                                             new XAttribute("Id", obj.id)));

                    #region ide
                    ide = (new XElement(pf + "ide", new XElement(pf + "cUF", obj.ide.cUF),
                                                                new XElement(pf + "cCT", obj.ide.cCT),
                                                                new XElement(pf + "CFOP", obj.ide.CFOP),
                                                                new XElement(pf + "natOp", obj.ide.natOp),
                                                                new XElement(pf + "forPag", obj.ide.forPag),
                                                                new XElement(pf + "mod", obj.ide.mod),
                                                                new XElement(pf + "serie", obj.ide.serie),
                                                                new XElement(pf + "nCT", Convert.ToInt32(obj.ide.nCT).ToString()),
                                                                new XElement(pf + "dhEmi", (daoUtil.GetDateServidor()).ToString("yyyy-MM-ddTHH:MM:ss")),
                                                                new XElement(pf + "tpImp", obj.ide.tpImp),
                                                                new XElement(pf + "tpEmis", obj.ide.tpEmis),
                                                                new XElement(pf + "cDV", obj.ide.cDV),
                                                                new XElement(pf + "tpAmb", obj.ide.tpAmb),
                                                                new XElement(pf + "tpCTe", obj.ide.tpCTe),
                                                                new XElement(pf + "procEmi", obj.ide.procEmi),
                                                                new XElement(pf + "verProc", obj.ide.verProc),
                                                                new XElement(pf + "cMunEnv", obj.ide.cMunEnv),
                                                                new XElement(pf + "xMunEnv", obj.ide.xMunEnv),
                                                                new XElement(pf + "UFEnv", obj.ide.UFEnv),
                                                                new XElement(pf + "modal", obj.ide.modal),
                                                                new XElement(pf + "tpServ", obj.ide.tpServ),
                                                                new XElement(pf + "cMunIni", obj.ide.cMunIni),
                                                                new XElement(pf + "xMunIni", obj.ide.xMunIni),
                                                                new XElement(pf + "UFIni", obj.ide.UFIni),
                                                                new XElement(pf + "cMunFim", obj.ide.cMunFim),
                                                                new XElement(pf + "xMunFim", obj.ide.xMunFim),
                                                                new XElement(pf + "UFFim", obj.ide.UFFim),
                                                                new XElement(pf + "retira", obj.ide.retira)));



                    if (obj.ide.toma03 != null)
                    {
                        toma03 = (new XElement(pf + "toma03", new XElement(pf + "toma", obj.ide.toma03.toma)));
                        ide.Add(toma03);
                    }
                    else if (obj.ide.toma04 != null)
                    {
                        toma4 = (new XElement(pf + "toma4", new XElement(pf + "toma", obj.ide.toma04),
                                                              obj.ide.toma04.CNPJ != "" ? new XElement(pf + "CNPJ", obj.ide.toma04.CNPJ) : null,
                                                              obj.ide.toma04.CPF != "" ? new XElement(pf + "CPF", obj.ide.toma04.CPF) : null,
                                                              obj.ide.toma04.IE != "" ? new XElement(pf + "IE", obj.ide.toma04.IE) : null,
                                                              new XElement(pf + "xNome", obj.ide.toma04.xNome),
                                                              obj.ide.toma04.xFant != "" ? new XElement(pf + "xFant", obj.ide.toma04.xFant) : null,
                                                              obj.ide.toma04.fone != "" ? new XElement(pf + "fone", obj.ide.toma04.fone) : null));

                        enderToma = (new XElement(pf + "enderToma", new XElement(pf + "xLgr", obj.ide.toma04.enderToma.xLgr),
                                                              new XElement(pf + "nro", obj.ide.toma04.enderToma.nro),
                                                              obj.ide.toma04.enderToma.xCpl != "" ? new XElement(pf + "xCpl", obj.ide.toma04.enderToma.xCpl) : null,
                                                              new XElement(pf + "xBairro", obj.ide.toma04.enderToma.xBairro),
                                                              new XElement(pf + "cMun", obj.ide.toma04.enderToma.cMun),
                                                              new XElement(pf + "xMun", obj.ide.toma04.enderToma.xMun),
                                                              obj.ide.toma04.enderToma.CEP != "" ? new XElement(pf + "CEP", obj.ide.toma04.enderToma.CEP) : null,
                                                              new XElement(pf + "UF", obj.ide.toma04.enderToma.UF),
                                                              obj.ide.toma04.enderToma.cPais != "" ? new XElement(pf + "cPais", obj.ide.toma04.enderToma.cPais) : null,
                                                              obj.ide.toma04.enderToma.xPais != null ? new XElement(pf + "xPais", obj.ide.toma04.enderToma.xPais) : null));

                        toma4.Add(enderToma);
                        ide.Add(toma4);
                    }

                    if (obj.ide.tpEmis == "5")
                    {
                        ide.Add(new XElement(pf + "dhCont", (daoUtil.GetDateServidor()).ToString("yyyy-MM-ddTHH:MM:ss")),
                                new XElement(pf + "xJust", "Falha na Internet"));
                    }

                    #endregion

                    #region emit

                    emit = (new XElement(pf + "emit", new XElement(pf + "CNPJ", obj.emit.CNPJ),
                                                          new XElement(pf + "IE", obj.emit.IE),
                                                          new XElement(pf + "xNome", obj.emit.xNome),
                                                          obj.emit.xFant != "" ? new XElement(pf + "xFant", obj.emit.xFant) : null));

                    enderEmit = (new XElement(pf + "enderEmit", new XElement(pf + "xLgr", obj.emit.enderEmit.xLgr),
                                                                   new XElement(pf + "nro", obj.emit.enderEmit.nro),
                                                                   obj.emit.enderEmit.xCpl != "" ? new XElement(pf + "xCpl", obj.emit.enderEmit.xCpl) : null,
                                                                   new XElement(pf + "xBairro", obj.emit.enderEmit.xBairro),
                                                                   new XElement(pf + "cMun", obj.emit.enderEmit.cMun),
                                                                   new XElement(pf + "xMun", obj.emit.enderEmit.xMun),
                                                                   obj.emit.enderEmit.CEP != "" ? new XElement(pf + "CEP", obj.emit.enderEmit.CEP) : null,
                                                                   new XElement(pf + "UF", obj.emit.enderEmit.UF),
                                                                   obj.emit.enderEmit.fone != "" ? new XElement(pf + "fone", obj.emit.enderEmit.fone) : null));


                    emit.Add(enderEmit);
                    #endregion

                    #region rem

                    rem = (new XElement(pf + "rem", obj.rem.CNPJ != "" ? new XElement(pf + "CNPJ", obj.rem.CNPJ) : null,
                                                    obj.rem.CPF != "" ? new XElement(pf + "CPF", obj.rem.CPF) : null,
                                                          new XElement(pf + "IE", obj.rem.IE),
                                                          new XElement(pf + "xNome", obj.rem.xNome),
                                                          obj.rem.xFant != "" ? new XElement(pf + "xFant", obj.rem.xFant) : null,
                                                          obj.rem.fone != "" ? new XElement(pf + "fone", obj.rem.fone) : null));

                    enderReme = (new XElement(pf + "enderReme", new XElement(pf + "xLgr", obj.rem.enderReme.xLgr),
                                                                   new XElement(pf + "nro", obj.rem.enderReme.nro),
                                                                   obj.rem.enderReme.xCpl != "" ? new XElement(pf + "xCpl", obj.rem.enderReme.xCpl) : null,
                                                                   new XElement(pf + "xBairro", obj.rem.enderReme.xBairro),
                                                                   new XElement(pf + "cMun", obj.rem.enderReme.cMun),
                                                                   new XElement(pf + "xMun", obj.rem.enderReme.xMun),
                                                                   obj.rem.enderReme.CEP != "" ? new XElement(pf + "CEP", obj.rem.enderReme.CEP) : null,
                                                                   new XElement(pf + "UF", obj.rem.enderReme.UF),
                                                                   obj.rem.enderReme.cPais != "" ? new XElement(pf + "cPais", obj.rem.enderReme.cPais) : null,
                                                                   obj.rem.enderReme.xPais != "" ? new XElement(pf + "xPais", obj.rem.enderReme.xPais) : null,
                                                                   obj.rem.enderReme.email != "" ? new XElement(pf + "email", obj.rem.enderReme.email) : null));

                    rem.Add(enderReme);


                    for (int j = 0; j < obj.rem.infNF.Count; j++)
                    {
                        infNF = new XElement(pf + "infNF",
                                   new XElement(pf + "mod", obj.rem.infNF[j].mod),
                                   new XElement(pf + "serie", obj.rem.infNF[j].serie),
                                   new XElement(pf + "nDoc", obj.rem.infNF[j].nDoc.Replace(",", ".")),
                                   new XElement(pf + "dEmi", (Convert.ToDateTime(obj.rem.infNF[j].dEmi)).ToString("yyyy-MM-dd")),
                                   new XElement(pf + "vBC", obj.rem.infNF[j].vBC.Replace(",", ".")),
                                   new XElement(pf + "vICMS", obj.rem.infNF[j].vICMS.Replace(",", ".")),
                                   new XElement(pf + "vBCST", obj.rem.infNF[j].vBCST.Replace(",", ".")),
                                   new XElement(pf + "vST", obj.rem.infNF[j].vST.Replace(",", ".")),
                                   new XElement(pf + "vProd", obj.rem.infNF[j].vProd.Replace(",", ".")),
                                   new XElement(pf + "vNF", obj.rem.infNF[j].vNF.Replace(",", ".")),
                                   new XElement(pf + "nCFOP", obj.rem.infNF[j].nCFOP.Replace(",", ".")));

                        rem.Add(infNF);
                    }



                    for (int nfe = 0; nfe < obj.rem.infNFe.Count; nfe++)
                    {
                        infNFe = new XElement(pf + "infNFe", new XElement(pf + "chave", obj.rem.infNFe[nfe].chave));
                        rem.Add(infNFe);
                    }

                    for (int j = 0; j < obj.rem.infOutros.Count; j++)
                    {
                        infOutros = new XElement(pf + "infOutros", new XElement(pf + "tpDoc", obj.rem.infOutros[j].tpDoc),
                                                obj.rem.infOutros[j].descOutros != "" ? new XElement(pf + "descOutros", obj.rem.infOutros[j].descOutros) : null,
                                                new XElement(pf + "nDoc", obj.rem.infOutros[j].nDoc),
                                                new XElement(pf + "dEmi", Convert.ToDateTime(obj.rem.infOutros[j].dEmi).ToString("yyyy-MM-dd")),
                                                new XElement(pf + "vDocFisc", obj.rem.infOutros[j].vDocFisc.Replace(",", ".")));
                        rem.Add(infOutros);
                    }



                    #endregion

                    #region exped

                    if (obj.exped != null)
                    {
                        exped = (new XElement(pf + "exped", obj.exped.CNPJ != "" ? new XElement(pf + "CNPJ", obj.exped.CNPJ) : null,
                                                        obj.exped.CPF != "" ? new XElement(pf + "CPF", obj.exped.CPF) : null,
                                                                              new XElement(pf + "IE", obj.exped.IE),
                                                                              new XElement(pf + "xNome", obj.exped.xNome),
                                                       obj.exped.fone != "" ? new XElement(pf + "fone", obj.exped.fone) : null));

                        enderExped = (new XElement(pf + "enderExped", new XElement(pf + "xLgr", obj.exped.enderExped.xLgr),
                                                                       new XElement(pf + "nro", obj.exped.enderExped.nro),
                                                                       obj.exped.enderExped.xCpl != "" ? new XElement(pf + "xCpl", obj.exped.enderExped.xCpl) : null,
                                                                       new XElement(pf + "xBairro", obj.exped.enderExped.xBairro),
                                                                       new XElement(pf + "cMun", obj.exped.enderExped.cMun),
                                                                       new XElement(pf + "xMun", obj.exped.enderExped.xMun),
                                                                       obj.exped.enderExped.CEP != "" ? new XElement(pf + "CEP", obj.exped.enderExped.CEP) : null,
                                                                       new XElement(pf + "UF", obj.exped.enderExped.UF),
                                                                       obj.exped.enderExped.cPais != "" ? new XElement(pf + "cPais", obj.exped.enderExped.cPais) : null,
                                                                       obj.exped.enderExped.xPais != "" ? new XElement(pf + "xPais", obj.exped.enderExped.xPais) : null));

                        exped.Add(enderExped);
                    }


                    #endregion

                    #region receb

                    if (obj.receb != null)
                    {
                        receb = (new XElement(pf + "receb", obj.receb.CNPJ != "" ? new XElement(pf + "CNPJ", obj.receb.CNPJ) : null,
                                                        obj.receb.CPF != "" ? new XElement(pf + "CPF", obj.receb.CPF) : null,
                                                                              new XElement(pf + "IE", obj.receb.IE),
                                                                              new XElement(pf + "xNome", obj.receb.xNome),
                                                       obj.receb.fone != "" ? new XElement(pf + "fone", obj.receb.fone) : null));

                        enderReceb = (new XElement(pf + "enderReceb", new XElement(pf + "xLgr", obj.receb.enderReceb.xLgr),
                                                                       new XElement(pf + "nro", obj.receb.enderReceb.nro),
                                                                       obj.receb.enderReceb.xCpl != "" ? new XElement(pf + "xCpl", obj.receb.enderReceb.xCpl) : null,
                                                                       new XElement(pf + "xBairro", obj.receb.enderReceb.xBairro),
                                                                       new XElement(pf + "cMun", obj.receb.enderReceb.cMun),
                                                                       new XElement(pf + "xMun", obj.receb.enderReceb.xMun),
                                                                       obj.receb.enderReceb.CEP != "" ? new XElement(pf + "CEP", obj.receb.enderReceb.CEP) : null,
                                                                       new XElement(pf + "UF", obj.receb.enderReceb.UF),
                                                                       obj.receb.enderReceb.cPais != "" ? new XElement(pf + "cPais", obj.receb.enderReceb.cPais) : null,
                                                                       obj.receb.enderReceb.xPais != "" ? new XElement(pf + "xPais", obj.receb.enderReceb.xPais) : null));

                        receb.Add(enderReceb);
                    }


                    #endregion

                    #region dest

                    dest = (new XElement(pf + "dest", obj.dest.CNPJ != "" ? new XElement(pf + "CNPJ", obj.dest.CNPJ) : null,
                                                      obj.dest.CPF != "" ? new XElement(pf + "CPF", obj.dest.CPF) : null,
                                                      obj.dest.IE != "" ? new XElement(pf + "IE", obj.dest.IE) : null,
                                                                          new XElement(pf + "xNome", obj.dest.xNome),
                                                      obj.dest.fone != "" ? new XElement(pf + "fone", obj.dest.fone) : null,
                                                      obj.dest.ISUF != "" ? new XElement(pf + "ISUF", obj.dest.ISUF) : null));


                    enderDest = (new XElement(pf + "enderDest", new XElement(pf + "xLgr", obj.dest.enderDest.xLgr),
                                                                   new XElement(pf + "nro", obj.dest.enderDest.nro),
                                                                   obj.dest.enderDest.xCpl != "" ? new XElement(pf + "xCpl", obj.dest.enderDest.xCpl) : null,
                                                                   new XElement(pf + "xBairro", obj.dest.enderDest.xBairro),
                                                                   new XElement(pf + "cMun", obj.dest.enderDest.cMun),
                                                                   new XElement(pf + "xMun", obj.dest.enderDest.xMun),
                                                                   obj.dest.enderDest.CEP != "" ? new XElement(pf + "CEP", obj.dest.enderDest.CEP) : null,
                                                                   new XElement(pf + "UF", obj.dest.enderDest.UF),
                                                                   obj.dest.enderDest.cPais != "" ? new XElement(pf + "cPais", obj.dest.enderDest.cPais) : null,
                                                                   obj.dest.enderDest.xPais != "" ? new XElement(pf + "xPais", obj.dest.enderDest.xPais) : null));

                    dest.Add(enderDest);
                    #endregion

                    #region vPrest

                    vPrest = (new XElement(pf + "vPrest", new XElement(pf + "vTPrest", obj.vPrest.vTPrest.Replace(",", ".")),
                                                          new XElement(pf + "vRec", obj.vPrest.vRec.Replace(",", "."))));

                    for (int j = 0; j < obj.vPrest.Comp.Count; j++)
                    {
                        Comp = new XElement(pf + "Comp", new XElement(pf + "xNome", obj.vPrest.Comp[j].xNome),
                                                         new XElement(pf + "vComp", obj.vPrest.Comp[j].vComp.Replace(",", ".")));

                        vPrest.Add(Comp);
                    }

                    #endregion

                    #region imp

                    imp = new XElement(pf + "imp");
                    ICMS = new XElement(pf + "ICMS");

                    if (obj.imp.ICMS.ICMS00 != null)
                    {
                        belICMS00 objICMS00 = obj.imp.ICMS.ICMS00;
                        ICMS00 = (new XElement(pf + "ICMS00", new XElement(pf + "CST", objICMS00.CST),
                                                                new XElement(pf + "vBC", objICMS00.vBC),
                                                                new XElement(pf + "pICMS", objICMS00.pICMS),
                                                                new XElement(pf + "vICMS", objICMS00.vICMS)));
                        ICMS.Add(ICMS00);
                    }
                    else if (obj.imp.ICMS.ICMS20 != null)
                    {
                        belICMS20 objICMS20 = obj.imp.ICMS.ICMS20;
                        ICMS20 = (new XElement(pf + "ICMS20", new XElement(pf + "CST", objICMS20.CST),
                                                               new XElement(pf + "pRedBC", objICMS20.pRedBC),
                                                               new XElement(pf + "vBC", objICMS20.vBC),
                                                               new XElement(pf + "pICMS", objICMS20.pICMS),
                                                               new XElement(pf + "vICMS", objICMS20.vICMS)));
                        ICMS.Add(ICMS20);
                    }
                    else if (obj.imp.ICMS.ICMS45 != null)
                    {
                        ICMS45 = (new XElement(pf + "ICMS45", new XElement(pf + "CST", obj.imp.ICMS.ICMS45.CST)));
                        ICMS.Add(ICMS45);
                    }
                    else if (obj.imp.ICMS.ICMS60 != null)
                    {
                        belICMS60 objICMS60 = obj.imp.ICMS.ICMS60;
                        ICMS60 = (new XElement(pf + "ICMS60", new XElement(pf + "CST", objICMS60.CST),
                                                                new XElement(pf + "vBCSTRet", objICMS60.vBCSTRet),
                                                                new XElement(pf + "vICMSSTRet", objICMS60.vICMSSTRet),
                                                                new XElement(pf + "pICMSSTRet", objICMS60.pICMSSTRet)));
                        ICMS.Add(ICMS60);
                    }
                    else if (obj.imp.ICMS.ICMS90 != null)
                    {
                        belICMS90 objICMS90 = obj.imp.ICMS.ICMS90;
                        ICMS60 = (new XElement(pf + "ICMS90", new XElement(pf + "CST", objICMS90.CST),
                                                                new XElement(pf + "vBC", objICMS90.vBC),
                                                                new XElement(pf + "pICMS", objICMS90.pICMS),
                                                                new XElement(pf + "vICMS", objICMS90.vICMS)));
                        ICMS.Add(ICMS90);
                    }
                    else if (obj.imp.ICMS.ICMSOutraUF != null)
                    {
                        belICMSOutraUF objICMSOutraUF = obj.imp.ICMS.ICMSOutraUF;
                        ICMSOutraUF = (new XElement(pf + "ICMSOutraUF", new XElement(pf + "CST", objICMSOutraUF.CST),
                                                                 objICMSOutraUF.pRedBCOutraUF != "" ? new XElement(pf + "pRedBCOutraUF", objICMSOutraUF.pRedBCOutraUF) : null,
                                                                 new XElement(pf + "vBCOutraUF", objICMSOutraUF.vBCOutraUF),
                                                                 new XElement(pf + "pICMSOutraUF", objICMSOutraUF.pICMSOutraUF),
                                                                 new XElement(pf + "vICMSOutraUF", objICMSOutraUF.vICMSOutraUF)));
                        ICMS.Add(ICMSOutraUF);
                    }


                    imp.Add(ICMS);
                    #endregion

                    #region infCTeNorm

                    infCTeNorm = new XElement(pf + "infCTeNorm", new XElement(pf + "infCarga",
                                                                                  new XElement(pf + "vCarga", obj.infCTeNorm.infCarga.vCarga),
                                                                                  new XElement(pf + "proPred", obj.infCTeNorm.infCarga.proPred),
                                                                                  obj.infCTeNorm.infCarga.xOutCat != "" ? new XElement(pf + "xOutCat", obj.infCTeNorm.infCarga.xOutCat) : null,
                                                                                  obj.infCTeNorm.infCarga.infQ != null ?
                                                                                  (from c in obj.infCTeNorm.infCarga.infQ
                                                                                   select new XElement(pf + "infQ", new XElement(pf + "cUnid", c.cUnid),
                                                                                                               new XElement(pf + "tpMed", c.tpMed),
                                                                                                               new XElement(pf + "qCarga", c.qCarga.ToString().Replace(",", ".") + "00"))) : null));


                    seg = new XElement(pf + "seg", new XElement(pf + "respSeg", obj.infCTeNorm.seg.respSeg),
                                                            new XElement(pf + "nApol", obj.infCTeNorm.seg.nApol));
                    infCTeNorm.Add(seg);


                    #region Modal Rodoviario

                    infModal = new XElement(pf + "infModal", new XAttribute("versaoModal", Acesso.versaoCTe));

                    rodo = new XElement(pf + "rodo", new XElement(pf + "RNTRC", obj.infCTeNorm.rodo.RNTRC),
                                                              new XElement(pf + "dPrev", Convert.ToDateTime(obj.infCTeNorm.rodo.dPrev).ToString("yyyy-MM-dd")),
                                                              new XElement(pf + "lota", obj.infCTeNorm.rodo.lota));



                    for (int v = 0; v < obj.infCTeNorm.rodo.veic.Count; v++)
                    {

                        veic = new XElement(pf + "veic", new XElement(pf + "RENAVAM", obj.infCTeNorm.rodo.veic[v].RENAVAM),
                                              new XElement(pf + "placa", obj.infCTeNorm.rodo.veic[v].placa),
                                              new XElement(pf + "tara", obj.infCTeNorm.rodo.veic[v].tara),
                                              new XElement(pf + "capKG", obj.infCTeNorm.rodo.veic[v].capKG),
                                              new XElement(pf + "capM3", obj.infCTeNorm.rodo.veic[v].capM3),
                                              new XElement(pf + "tpProp", obj.infCTeNorm.rodo.veic[v].tpProp),
                                              new XElement(pf + "tpVeic", obj.infCTeNorm.rodo.veic[v].tpVeic),
                                              new XElement(pf + "tpRod", obj.infCTeNorm.rodo.veic[v].tpRod),
                                              new XElement(pf + "tpCar", obj.infCTeNorm.rodo.veic[v].tpCar),
                                              new XElement(pf + "UF", obj.infCTeNorm.rodo.veic[v].UF));

                        if (obj.infCTeNorm.rodo.veic[v].prop != null)
                        {
                            prop = new XElement(pf + "prop", new XElement(pf + (obj.infCTeNorm.rodo.veic[v].prop.CPFCNPJ.Length == 11 ? "CPF" : "CNPJ"), obj.infCTeNorm.rodo.veic[v].prop.CPFCNPJ),
                                     new XElement(pf + "RNTRC", obj.infCTeNorm.rodo.veic[v].prop.RNTRC),
                                                  new XElement(pf + "xNome", obj.infCTeNorm.rodo.veic[v].prop.xNome),
                                                  new XElement(pf + "IE", obj.infCTeNorm.rodo.veic[v].prop.IE),
                                                  new XElement(pf + "UF", obj.infCTeNorm.rodo.veic[v].prop.UF),
                                                  new XElement(pf + "tpProp", obj.infCTeNorm.rodo.veic[v].prop.tpProp));

                            veic.Add(prop);
                        }
                        rodo.Add(veic);
                    }
                    if (obj.infCTeNorm.rodo.moto != null)
                    {
                        moto = new XElement(pf + "moto", new XElement(pf + "xNome", obj.infCTeNorm.rodo.moto.xNome),
                               new XElement(pf + "CPF", obj.infCTeNorm.rodo.moto.CPF));
                        rodo.Add(moto);
                    }

                    #endregion

                    infModal.Add(rodo);
                    infCTeNorm.Add(infModal);


                    #endregion

                    #region Monta CTe

                    infCte.Add(ide);
                    infCte.Add(emit);
                    infCte.Add(rem);
                    infCte.Add(exped);
                    infCte.Add(receb);
                    infCte.Add(dest);
                    infCte.Add(vPrest);
                    infCte.Add(imp);
                    infCte.Add(infCTeNorm);
                    CTe.Add(infCte);

                    #endregion

                    #region Assinatura

                    belAssinaXml Assinatura = new belAssinaXml();
                    string sCte = Assinatura.ConfigurarArquivo(CTe.ToString(), "infCte", Acesso.cert_CTe);

                    listXml.Add(sCte);

                    #endregion

                    #region SalvaCteIndividual

                    XDocument XmlCte = XDocument.Parse(sCte);

                    string sNumCte = obj.ide.nCT;

                    if (Acesso.TP_EMIS != 1)
                    {
                        dPastaEnvio = new DirectoryInfo(Pastas.CONTINGENCIA);
                    }
                    else
                    {
                        dPastaEnvio = new DirectoryInfo(Pastas.ENVIO);
                    }
                    if (!dPastaEnvio.Exists) { dPastaEnvio.Create(); }

                    dPastaMesAtual = new DirectoryInfo(dPastaEnvio + @"\\" + sData.Substring(3, 2) + "-" + sData.Substring(8, 2));
                    if (!dPastaMesAtual.Exists) { dPastaMesAtual.Create(); }

                    XmlCte.Save(dPastaMesAtual.ToString() + "\\" + "Cte_" + sNumCte + ".xml");

                    #endregion


                }

                #region Salva Lote

                string sXml = "";
                foreach (var xml in listXml)
                {
                    sXml = sXml + xml;
                }

                string sXmlCte = ("<?xml version=\"1.0\" encoding=\"UTF-8\"?><enviCTe versao=\"1.04\" " +
                                 "xsi:schemaLocation=\"http://www.portalfiscal.inf.br/cte enviCte_v1.04.xsd\" " +
                                 "xmlns=\"http://www.portalfiscal.inf.br/cte\" xmlns:ds=\"http://www.w3.org/2000/09/xmldsig#\" " +
                                 "xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\"><idLote>" + iNumLote + "</idLote>" + sXml + "</enviCTe>");


                string sCaminho = dPastaEnvio.ToString() + "\\" + "Cte_Lote_" + iNumLote + "_" + sData + ".xml";
                StreamWriter sw = new StreamWriter(sCaminho);
                sw.Write(sXmlCte);
                sw.Close();


                #endregion

                #region Valida_Xml

                belValidaXml.ValidarXml("http://www.portalfiscal.inf.br/cte", Pastas.SCHEMA_CTE + "\\enviCte_v1.04.xsd", sCaminho);


                #endregion

                #region Envia e Busca Recibo Lote WebService

                if (Acesso.TP_EMIS == 1)
                {
                    XmlDocument doc = new XmlDocument();
                    doc.Load(dPastaEnvio.ToString() + "\\" + "Cte_Lote_" + iNumLote + "_" + sData + ".xml");


                    //busca retorno
                    string sRetorno = TransmitirLote(doc);
                    sRecibo = BuscaReciboRetornoEnvio(sRetorno);
                }

                #endregion

                return sRecibo;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<belStatusCte> GerarXmlCancelamento(belCancelaCte objCancelaCte)
        {
            try
            {
                XNamespace pf = "http://www.portalfiscal.inf.br/cte";
                XNamespace ns = "http://www.w3.org/2001/XMLSchema-instance";

                XContainer cancCTe = new XElement(pf + "cancCTe", new XAttribute("versao", Acesso.versaoCTe),
                                                                     new XAttribute(ns + "schemaLocation", "http://www.portalfiscal.inf.br/cancCte_v1.04.xsd"),
                                                                     new XAttribute("xmlns", "http://www.portalfiscal.inf.br/cte"),
                                                                     new XAttribute(XNamespace.Xmlns + "ds", "http://www.w3.org/2000/09/xmldsig#"),
                                                                     new XAttribute(XNamespace.Xmlns + "xsi", "http://www.w3.org/2001/XMLSchema-instance"));

                XContainer infCanc = new XElement(pf + "infCanc", new XAttribute("Id", objCancelaCte.Id),
                                                                  new XElement(pf + "tpAmb", objCancelaCte.tpAmb),
                                                                  new XElement(pf + "xServ", objCancelaCte.xServ),
                                                                  new XElement(pf + "chCTe", objCancelaCte.chCTe),
                                                                  new XElement(pf + "nProt", objCancelaCte.nProt),
                                                                  new XElement(pf + "xJust", objCancelaCte.xJust));

                cancCTe.Add(infCanc);

                #region Assinatura

                belAssinaXml Assinatura = new belAssinaXml();
                string sInfCanc = Assinatura.ConfigurarArquivo(cancCTe.ToString(), "infCanc", Acesso.cert_CTe);
                XElement xInfCanc = XElement.Parse(sInfCanc);



                #endregion

                #region Salva Xml

                string sData = daoUtil.GetDateServidor().Date.ToString("dd-MM-yyyy");

                DirectoryInfo dPastaProtocolo = new DirectoryInfo(Pastas.PROTOCOLOS);
                if (!dPastaProtocolo.Exists) { dPastaProtocolo.Create(); }
                DirectoryInfo dPastaMesAtual = new DirectoryInfo(dPastaProtocolo + @"\\" + sData.Substring(3, 2) + "-" + sData.Substring(8, 2));
                if (!dPastaMesAtual.Exists) { dPastaMesAtual.Create(); }

                string sCaminho = dPastaMesAtual.ToString() + "\\" + "Canc_" + objCancelaCte.chCTe + ".xml";
                XDocument XmlCanc = new XDocument(xInfCanc);
                XmlCanc.Save(sCaminho);

                #endregion

                #region Valida_Xml

                belValidaXml.ValidarXml("http://www.portalfiscal.inf.br/cte", Pastas.SCHEMA_CTE + "\\cancCte_v1.04.xsd", sCaminho);

                #endregion




                #region Cancelar Cte


                XmlDocument doc = new XmlDocument();
                doc.Load(sCaminho);

                string sRetorno = CancelarCte(doc);
                List<belStatusCte> ListaStatus = TrataDadosRetorno(sRetorno);

                foreach (belStatusCte cte in ListaStatus)
                {
                    if (cte.CodRetorno == "101")
                    {
                        XDocument xRet = XDocument.Parse(sRetorno);
                        xRet.Save(sCaminho);
                    }
                    else
                    {
                        File.Delete(sCaminho);
                    }
                }

                #endregion

                return ListaStatus;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<belStatusCte> GerarXmlInutilizacao(belInutilizaFaixaCte objInutiliza)
        {
            XNamespace pf = "http://www.portalfiscal.inf.br/cte";
            XNamespace ns = "http://www.w3.org/2001/XMLSchema-instance";

            XContainer inutCTe = new XElement(pf + "inutCTe", new XAttribute("versao", Acesso.versaoCTe),
                                                                 new XAttribute(ns + "schemaLocation", "http://www.portalfiscal.inf.br/inutCte_v1.04.xsd"),
                                                                 new XAttribute("xmlns", "http://www.portalfiscal.inf.br/cte"),
                                                                 new XAttribute(XNamespace.Xmlns + "ds", "http://www.w3.org/2000/09/xmldsig#"),
                                                                 new XAttribute(XNamespace.Xmlns + "xsi", "http://www.w3.org/2001/XMLSchema-instance"));

            XContainer infInut = new XElement(pf + "infInut", new XAttribute("Id", objInutiliza.Id),
                                                                 new XElement(pf + "tpAmb", objInutiliza.tpAmb),
                                                                 new XElement(pf + "xServ", objInutiliza.xServ),
                                                                 new XElement(pf + "cUF", objInutiliza.cUF),
                                                                 new XElement(pf + "ano", objInutiliza.ano),
                                                                 new XElement(pf + "CNPJ", objInutiliza.CNPJ),
                                                                 new XElement(pf + "mod", objInutiliza.mod),
                                                                 new XElement(pf + "serie", objInutiliza.serie),
                                                                 new XElement(pf + "nCTIni", objInutiliza.nCTIni),
                                                                 new XElement(pf + "nCTFin", objInutiliza.nCTFin),
                                                                 new XElement(pf + "xJust", objInutiliza.xJust));


            inutCTe.Add(infInut);

            #region Assinatura

            belAssinaXml Assinatura = new belAssinaXml();
            string sInutCte = Assinatura.ConfigurarArquivo(inutCTe.ToString(), "infInut", Acesso.cert_CTe);
            XElement xInutCTe = XElement.Parse(sInutCte);


            #endregion

            #region Salva Xml

            string sData = daoUtil.GetDateServidor().Date.ToString("dd-MM-yyyy");
            DirectoryInfo dPastaProtocolo = new DirectoryInfo(Pastas.PROTOCOLOS);
            if (!dPastaProtocolo.Exists) { dPastaProtocolo.Create(); }

            DirectoryInfo dPastaMesAtual = new DirectoryInfo(dPastaProtocolo + @"\\" + sData.Substring(3, 2) + "-" + sData.Substring(8, 2));
            if (!dPastaMesAtual.Exists) { dPastaMesAtual.Create(); }

            string sCaminho = dPastaMesAtual.ToString() + "\\" + "Inut_" + objInutiliza.nCTIni + "_" + objInutiliza.nCTFin + ".xml";

            XDocument XmlInut = new XDocument(xInutCTe);
            XmlInut.Save(sCaminho);

            #endregion

            #region Valida_Xml


            belValidaXml.ValidarXml("http://www.portalfiscal.inf.br/cte", Pastas.SCHEMA_CTE + "\\inutCte_v1.04.xsd", sCaminho);



            #endregion

            #region Inutilizar Cte


            XmlDocument doc = new XmlDocument();
            doc.Load(sCaminho);

            string sRetorno = InutilizaFaixaCte(doc);
            List<belStatusCte> ListaStatus = TrataDadosRetorno(sRetorno);

            foreach (belStatusCte cte in ListaStatus)
            {
                if (cte.CodRetorno == "102")
                {
                    XDocument xRet = XDocument.Parse(sRetorno);
                    xRet.Save(sCaminho);
                }
                else
                {
                    File.Delete(sCaminho);
                }
            }
            #endregion


            return ListaStatus;

        }
        public List<belStatusCte> GerarXmlConsultaStatus()
        {

            XNamespace pf = "http://www.portalfiscal.inf.br/cte";
            XNamespace ns = "http://www.w3.org/2001/XMLSchema-instance";


            XContainer consStatServ = new XElement(pf + "consStatServCte", new XAttribute("versao", Acesso.versaoCTe),
                                                                 new XAttribute(ns + "schemaLocation", "http://www.portalfiscal.inf.br/consStatServCte_v1.04.xsd"),
                                                                 new XAttribute("xmlns", "http://www.portalfiscal.inf.br/cte"),
                                                                 new XAttribute(XNamespace.Xmlns + "ds", "http://www.w3.org/2000/09/xmldsig#"),
                                                                 new XAttribute(XNamespace.Xmlns + "xsi", "http://www.w3.org/2001/XMLSchema-instance"));

            XContainer tpAmb = new XElement(pf + "tpAmb", Acesso.TP_AMB);
            XContainer status = new XElement(pf + "xServ", "STATUS");

            consStatServ.Add(tpAmb);
            consStatServ.Add(status);

            #region Valida Xml

            string sData = daoUtil.GetDateServidor().Date.ToString("dd-MM-yyyy");
            DirectoryInfo dPastaProtocolo = new DirectoryInfo(Pastas.PROTOCOLOS);
            if (!dPastaProtocolo.Exists) { dPastaProtocolo.Create(); }

            DirectoryInfo dPastaMesAtual = new DirectoryInfo(dPastaProtocolo + @"\\" + sData.Substring(3, 2) + "-" + sData.Substring(8, 2));
            if (!dPastaMesAtual.Exists) { dPastaMesAtual.Create(); }
            string sCaminho = dPastaMesAtual.ToString() + "\\" + "Status_" + DateTime.Now.Day + "_" + DateTime.Now.ToLongTimeString().Replace(":", "-") + ".xml";

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(consStatServ.ToString());
            doc.Save(sCaminho);


            belValidaXml.ValidarXml("http://www.portalfiscal.inf.br/cte", Pastas.SCHEMA_CTE + "\\consStatServCte_v1.04.xsd", sCaminho);




            #endregion

            #region Consultar Status



            string sRetorno = ConsultarStatus(doc);
            List<belStatusCte> ListaStatus = TrataDadosRetorno(sRetorno);

            #endregion


            return ListaStatus;

        }
        private string MontaXmlBuscaRetorno(string sRecibo)
        {
            try
            {
                XNamespace pf = "http://www.portalfiscal.inf.br/cte";
                XNamespace ns = "http://www.w3.org/2001/XMLSchema-instance";

                XContainer consReciCTe = new XElement(pf + "consReciCTe", new XAttribute("versao", Acesso.versaoCTe),
                                                                     new XAttribute(ns + "schemaLocation", "http://www.portalfiscal.inf.br/consReciCte_v1.04.xsd"),
                                                                     new XAttribute("xmlns", "http://www.portalfiscal.inf.br/cte"),
                                                                     new XAttribute(XNamespace.Xmlns + "ds", "http://www.w3.org/2000/09/xmldsig#"),
                                                                     new XAttribute(XNamespace.Xmlns + "xsi", "http://www.w3.org/2001/XMLSchema-instance"),
                new XElement(pf + "tpAmb", Acesso.TP_AMB),
                new XElement(pf + "nRec", sRecibo));






                #region Valida_Xml

                string sData = daoUtil.GetDateServidor().Date.ToString("dd-MM-yyyy");
                DirectoryInfo dPastaProtocolo = new DirectoryInfo(Pastas.PROTOCOLOS);
                if (!dPastaProtocolo.Exists) { dPastaProtocolo.Create(); }

                DirectoryInfo dPastaMesAtual = new DirectoryInfo(dPastaProtocolo + @"\\" + sData.Substring(3, 2) + "-" + sData.Substring(8, 2));
                if (!dPastaMesAtual.Exists) { dPastaMesAtual.Create(); }
                string sCaminho = dPastaMesAtual.ToString() + "\\" + "ConsRecibo_" + DateTime.Now.Day + "_" + DateTime.Now.ToLongTimeString().Replace(":", "-") + ".xml";

                XmlDocument doc = new XmlDocument();
                doc.LoadXml(consReciCTe.ToString());
                doc.Save(sCaminho);

                belValidaXml.ValidarXml("http://www.portalfiscal.inf.br/cte", Pastas.SCHEMA_CTE + "\\consReciCte_v1.04.xsd", sCaminho);

                #endregion

                return consReciCTe.ToString();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<belStatusCte> GerarXmlConsultaSituacao(string sChave, bool SalvarXml)
        {
            try
            {
                XmlDocument doc = MontaXmlConsultaSituacao(sChave);

                string sRetorno = ConsultarSituacao(doc, SalvarXml, sChave);
                List<belStatusCte> ListaStatus = TrataDadosRetorno(sRetorno);

                return ListaStatus;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private static XmlDocument MontaXmlConsultaSituacao(string sChave)
        {

            XNamespace pf = "http://www.portalfiscal.inf.br/cte";
            XNamespace ns = "http://www.w3.org/2001/XMLSchema-instance";

            XContainer consReciCTe = new XElement(pf + "consSitCTe", new XAttribute("versao", Acesso.versaoCTe),
                                                                 new XAttribute(ns + "schemaLocation", "http://www.portalfiscal.inf.br/consSitCte_v1.04.xsd"),
                                                                 new XAttribute("xmlns", "http://www.portalfiscal.inf.br/cte"),
                                                                 new XAttribute(XNamespace.Xmlns + "ds", "http://www.w3.org/2000/09/xmldsig#"),
                                                                 new XAttribute(XNamespace.Xmlns + "xsi", "http://www.w3.org/2001/XMLSchema-instance"),
            new XElement(pf + "tpAmb", Acesso.TP_AMB),
            new XElement(pf + "xServ", "CONSULTAR"),
            new XElement(pf + "chCTe", sChave));



            #region Valida_Xml

            string sData = daoUtil.GetDateServidor().Date.ToString("dd-MM-yyyy");
            DirectoryInfo dPastaProtocolo = new DirectoryInfo(Pastas.PROTOCOLOS);
            if (!dPastaProtocolo.Exists) { dPastaProtocolo.Create(); }

            DirectoryInfo dPastaMesAtual = new DirectoryInfo(dPastaProtocolo + @"\\" + sData.Substring(3, 2) + "-" + sData.Substring(8, 2));
            if (!dPastaMesAtual.Exists) { dPastaMesAtual.Create(); }
            string sCaminho = dPastaMesAtual.ToString() + "\\" + "ConsSituacao_" + DateTime.Now.Day + "_" + DateTime.Now.ToLongTimeString().Replace(":", "-") + ".xml";

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(consReciCTe.ToString());
            doc.Save(sCaminho);

            belValidaXml.ValidarXml("http://www.portalfiscal.inf.br/cte", Pastas.SCHEMA_CTE + "\\consSitCte_v1.04.xsd", sCaminho);


            #endregion


            return doc;
        }




        public string TransmitirLote(XmlDocument doc)
        {
            string sRetorno = "";

            try
            {
                belUF objUf = new belUF();
                objUf.SiglaUF = "SP";

                //Homologação
                if (Acesso.TP_AMB == 2)
                {
                    HLP.GeraXml.WebService.CTe_Homologacao_cteRecepcao.cteCabecMsg objCabecRecepcao = new HLP.GeraXml.WebService.CTe_Homologacao_cteRecepcao.cteCabecMsg();
                    objCabecRecepcao.cUF = objUf.CUF;
                    objCabecRecepcao.versaoDados = Acesso.versaoCTe;

                    HLP.GeraXml.WebService.CTe_Homologacao_cteRecepcao.CteRecepcao objRecepcao = new HLP.GeraXml.WebService.CTe_Homologacao_cteRecepcao.CteRecepcao();
                    objRecepcao.cteCabecMsgValue = objCabecRecepcao;
                    objRecepcao.ClientCertificates.Add(Acesso.cert_CTe);
                    sRetorno = objRecepcao.cteRecepcaoLote(doc).OuterXml;
                }
                //Produção
                else if (Acesso.TP_AMB == 1)
                {
                    HLP.GeraXml.WebService.CTe_Producao_cteRecepcao.cteCabecMsg objCabecRecepcao = new HLP.GeraXml.WebService.CTe_Producao_cteRecepcao.cteCabecMsg();
                    objCabecRecepcao.cUF = objUf.CUF;
                    objCabecRecepcao.versaoDados = Acesso.versaoCTe;

                    HLP.GeraXml.WebService.CTe_Producao_cteRecepcao.CteRecepcao objRecepcao = new HLP.GeraXml.WebService.CTe_Producao_cteRecepcao.CteRecepcao();
                    objRecepcao.cteCabecMsgValue = objCabecRecepcao;
                    objRecepcao.ClientCertificates.Add(Acesso.cert_CTe);
                    sRetorno = objRecepcao.cteRecepcaoLote(doc).OuterXml;
                }
                return sRetorno;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string CancelarCte(XmlDocument doc)
        {
            string sRetorno = "";

            try
            {
                belUF objUf = new belUF();
                objUf.SiglaUF = "SP";

                //Homologação
                if (Acesso.TP_AMB == 2)
                {
                    HLP.GeraXml.WebService.CTe_Homologacao_cteCancelamento.cteCabecMsg objCabecCancelamento = new HLP.GeraXml.WebService.CTe_Homologacao_cteCancelamento.cteCabecMsg();
                    objCabecCancelamento.cUF = objUf.CUF;
                    objCabecCancelamento.versaoDados = Acesso.versaoCTe;

                    HLP.GeraXml.WebService.CTe_Homologacao_cteCancelamento.CteCancelamento objCancelamento = new HLP.GeraXml.WebService.CTe_Homologacao_cteCancelamento.CteCancelamento();
                    objCancelamento.cteCabecMsgValue = objCabecCancelamento;
                    objCancelamento.ClientCertificates.Add(Acesso.cert_CTe);
                    sRetorno = objCancelamento.cteCancelamentoCT(doc).OuterXml;
                }
                //Produção
                else if (Acesso.TP_AMB == 1)
                {
                    HLP.GeraXml.WebService.CTe_Producao_cteCancelamento.cteCabecMsg objCabecCancelamento = new HLP.GeraXml.WebService.CTe_Producao_cteCancelamento.cteCabecMsg();
                    objCabecCancelamento.cUF = objUf.CUF;
                    objCabecCancelamento.versaoDados = Acesso.versaoCTe;

                    HLP.GeraXml.WebService.CTe_Producao_cteCancelamento.CteCancelamento objCancelamento = new HLP.GeraXml.WebService.CTe_Producao_cteCancelamento.CteCancelamento();
                    objCancelamento.cteCabecMsgValue = objCabecCancelamento;
                    objCancelamento.ClientCertificates.Add(Acesso.cert_CTe);
                    sRetorno = objCancelamento.cteCancelamentoCT(doc).OuterXml;
                }
                return sRetorno;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string InutilizaFaixaCte(XmlDocument doc)
        {
            string sRetorno = "";

            try
            {
                belUF objUf = new belUF();
                objUf.SiglaUF = "SP";

                //Homologação
                if (Acesso.TP_AMB == 2)
                {
                    HLP.GeraXml.WebService.CTe_Homologacao_cteInutilizacao.cteCabecMsg objCabecInutiliza = new HLP.GeraXml.WebService.CTe_Homologacao_cteInutilizacao.cteCabecMsg();
                    objCabecInutiliza.cUF = objUf.CUF;
                    objCabecInutiliza.versaoDados = Acesso.versaoCTe;

                    HLP.GeraXml.WebService.CTe_Homologacao_cteInutilizacao.CteInutilizacao objInutilizacao = new HLP.GeraXml.WebService.CTe_Homologacao_cteInutilizacao.CteInutilizacao();
                    objInutilizacao.cteCabecMsgValue = objCabecInutiliza;
                    objInutilizacao.ClientCertificates.Add(Acesso.cert_CTe);
                    sRetorno = objInutilizacao.cteInutilizacaoCT(doc).OuterXml;
                }
                //Produção
                else if (Acesso.TP_AMB == 1)
                {
                    HLP.GeraXml.WebService.CTe_Producao_cteInutilizacao.cteCabecMsg objCabecInutiliza = new HLP.GeraXml.WebService.CTe_Producao_cteInutilizacao.cteCabecMsg();
                    objCabecInutiliza.cUF = objUf.CUF;
                    objCabecInutiliza.versaoDados = Acesso.versaoCTe;

                    HLP.GeraXml.WebService.CTe_Producao_cteInutilizacao.CteInutilizacao objInutilizacao = new HLP.GeraXml.WebService.CTe_Producao_cteInutilizacao.CteInutilizacao();
                    objInutilizacao.cteCabecMsgValue = objCabecInutiliza;
                    objInutilizacao.ClientCertificates.Add(Acesso.cert_CTe);
                    sRetorno = objInutilizacao.cteInutilizacaoCT(doc).OuterXml;
                }
                return sRetorno;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string ConsultarStatus(XmlDocument doc)
        {
            string sRetorno = "";

            try
            {
                belUF objUf = new belUF();
                objUf.SiglaUF = "SP";

                //Homologação
                if (Acesso.TP_AMB == 2)
                {
                    HLP.GeraXml.WebService.CTe_Homologacao_cteStatusServico.cteCabecMsg objCabecStatus = new HLP.GeraXml.WebService.CTe_Homologacao_cteStatusServico.cteCabecMsg();
                    objCabecStatus.cUF = objUf.CUF;
                    objCabecStatus.versaoDados = Acesso.versaoCTe;

                    HLP.GeraXml.WebService.CTe_Homologacao_cteStatusServico.CteStatusServico objStatus = new HLP.GeraXml.WebService.CTe_Homologacao_cteStatusServico.CteStatusServico();
                    objStatus.cteCabecMsgValue = objCabecStatus;
                    objStatus.ClientCertificates.Add(Acesso.cert_CTe);
                    sRetorno = objStatus.cteStatusServicoCT(doc).OuterXml;
                }
                //Produção
                else if (Acesso.TP_AMB == 1)
                {
                    HLP.GeraXml.WebService.CTe_Producao_cteStatusServico.cteCabecMsg objCabecStatus = new HLP.GeraXml.WebService.CTe_Producao_cteStatusServico.cteCabecMsg();
                    objCabecStatus.cUF = objUf.CUF;
                    objCabecStatus.versaoDados = Acesso.versaoCTe;

                    HLP.GeraXml.WebService.CTe_Producao_cteStatusServico.CteStatusServico objStatus = new HLP.GeraXml.WebService.CTe_Producao_cteStatusServico.CteStatusServico();
                    objStatus.cteCabecMsgValue = objCabecStatus;
                    objStatus.ClientCertificates.Add(Acesso.cert_CTe);
                    sRetorno = objStatus.cteStatusServicoCT(doc).OuterXml;
                }
                return sRetorno;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string ConsultarSituacao(XmlDocument doc, bool SalvarXml, string sChave)
        {
            string sRetorno = "";

            try
            {
                belUF objUf = new belUF();
                objUf.SiglaUF = "SP";

                //Homologação
                if (Acesso.TP_AMB == 2)
                {
                    HLP.GeraXml.WebService.CTe_Homologacao_cteConsulta.cteCabecMsg objCabecStatus = new HLP.GeraXml.WebService.CTe_Homologacao_cteConsulta.cteCabecMsg();
                    objCabecStatus.cUF = objUf.CUF;
                    objCabecStatus.versaoDados = Acesso.versaoCTe;

                    HLP.GeraXml.WebService.CTe_Homologacao_cteConsulta.CteConsulta objConsulta = new HLP.GeraXml.WebService.CTe_Homologacao_cteConsulta.CteConsulta();
                    objConsulta.cteCabecMsgValue = objCabecStatus;
                    objConsulta.ClientCertificates.Add(Acesso.cert_CTe);
                    sRetorno = objConsulta.cteConsultaCT(doc).OuterXml;
                }
                //Produção
                else if (Acesso.TP_AMB == 1)
                {
                    HLP.GeraXml.WebService.CTe_Producao_cteConsulta.cteCabecMsg objCabecStatus = new HLP.GeraXml.WebService.CTe_Producao_cteConsulta.cteCabecMsg();
                    objCabecStatus.cUF = objUf.CUF;
                    objCabecStatus.versaoDados = Acesso.versaoCTe;

                    HLP.GeraXml.WebService.CTe_Producao_cteConsulta.CteConsulta objConsulta = new HLP.GeraXml.WebService.CTe_Producao_cteConsulta.CteConsulta();
                    objConsulta.cteCabecMsgValue = objCabecStatus;
                    objConsulta.ClientCertificates.Add(Acesso.cert_CTe);
                    sRetorno = objConsulta.cteConsultaCT(doc).OuterXml;
                }

                if (SalvarXml)
                {
                    string sData = daoUtil.GetDateServidor().Date.ToString("dd-MM-yyyy");

                    DirectoryInfo dPastaProtocolo = new DirectoryInfo(Pastas.PROTOCOLOS);
                    if (!dPastaProtocolo.Exists) { dPastaProtocolo.Create(); }
                    DirectoryInfo dPastaMesAtual = new DirectoryInfo(dPastaProtocolo + @"\\" + sData.Substring(3, 2) + "-" + sData.Substring(8, 2));
                    if (!dPastaMesAtual.Exists) { dPastaMesAtual.Create(); }

                    XDocument docRet = XDocument.Parse(sRetorno);
                    docRet.Save(dPastaMesAtual + "\\Env_" + sChave + ".xml");

                }
                return sRetorno;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public List<belStatusCte> ConsultaLoteEnviado(string sRecibo)
        {

            try
            {
                belUF objUf = new belUF();
                objUf.SiglaUF = "SP";
                List<belStatusCte> ListaStatus = null;

                //Homologação
                if (Acesso.TP_AMB == 2)
                {
                    HLP.GeraXml.WebService.CTe_Homologacao_cteRetRecepcao.cteCabecMsg objCabecRetorno = new HLP.GeraXml.WebService.CTe_Homologacao_cteRetRecepcao.cteCabecMsg();
                    objCabecRetorno.cUF = objUf.CUF;
                    objCabecRetorno.versaoDados = Acesso.versaoCTe;

                    string sConsulta = MontaXmlBuscaRetorno(sRecibo);

                    HLP.GeraXml.WebService.CTe_Homologacao_cteRetRecepcao.CteRetRecepcao objRetRecepcao = new HLP.GeraXml.WebService.CTe_Homologacao_cteRetRecepcao.CteRetRecepcao();
                    objRetRecepcao.cteCabecMsgValue = objCabecRetorno;
                    objRetRecepcao.ClientCertificates.Add(Acesso.cert_CTe);

                    XmlDocument docRetorno = new XmlDocument();
                    docRetorno.LoadXml(sConsulta);

                    string ret = objRetRecepcao.cteRetRecepcao(docRetorno).OuterXml;
                    ListaStatus = TrataDadosRetorno(ret);
                }

                //Produção
                else if (Acesso.TP_AMB == 1)
                {
                    HLP.GeraXml.WebService.CTe_Producao_cteRetRecepcao.cteCabecMsg objCabecRetorno = new HLP.GeraXml.WebService.CTe_Producao_cteRetRecepcao.cteCabecMsg();
                    objCabecRetorno.cUF = objUf.CUF;
                    objCabecRetorno.versaoDados = Acesso.versaoCTe;

                    string sConsulta = MontaXmlBuscaRetorno(sRecibo);

                    HLP.GeraXml.WebService.CTe_Producao_cteRetRecepcao.CteRetRecepcao objRetRecepcao = new HLP.GeraXml.WebService.CTe_Producao_cteRetRecepcao.CteRetRecepcao();
                    objRetRecepcao.cteCabecMsgValue = objCabecRetorno;
                    objRetRecepcao.ClientCertificates.Add(Acesso.cert_CTe);

                    XmlDocument docRetorno = new XmlDocument();
                    docRetorno.LoadXml(sConsulta);

                    string ret = objRetRecepcao.cteRetRecepcao(docRetorno).OuterXml;
                    ListaStatus = TrataDadosRetorno(ret);
                }
                return ListaStatus;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public string BuscaReciboRetornoEnvio(string sRetorno)
        {
            try
            {
                string sRecibo = "";

                XmlDocument docRetorno = new XmlDocument();
                docRetorno.LoadXml(sRetorno);

                XmlNodeList xNodeList = null;

                if (docRetorno.GetElementsByTagName("nRec").Count > 0)
                {
                    xNodeList = docRetorno.GetElementsByTagName("nRec");
                }
                sRecibo = xNodeList[0].InnerText;

                return sRecibo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private List<belStatusCte> TrataDadosRetorno(string sRetorno)
        {
            try
            {
                List<belStatusCte> ListaStatus = new List<belStatusCte>();

                XmlDocument docRetorno = new XmlDocument();
                docRetorno.LoadXml(sRetorno);

                XmlNodeList xNodeList = null;

                if (docRetorno.GetElementsByTagName("infProt").Count > 0)
                {
                    xNodeList = docRetorno.GetElementsByTagName("infProt");
                }
                else if (docRetorno.GetElementsByTagName("infCanc").Count > 0)
                {
                    xNodeList = docRetorno.GetElementsByTagName("infCanc");
                }
                else if (docRetorno.GetElementsByTagName("infInut").Count > 0)
                {
                    xNodeList = docRetorno.GetElementsByTagName("infInut");
                }
                else if (docRetorno.GetElementsByTagName("retConsStatServCte").Count > 0)
                {
                    xNodeList = docRetorno.GetElementsByTagName("retConsStatServCte");
                }
                else if (docRetorno.GetElementsByTagName("retConsReciCTe").Count > 0)
                {
                    xNodeList = docRetorno.GetElementsByTagName("retConsReciCTe");
                }
                else if (docRetorno.GetElementsByTagName("retConsSitCTe").Count > 0)
                {
                    xNodeList = docRetorno.GetElementsByTagName("retConsSitCTe");
                }


                foreach (XmlNode node in xNodeList)
                {
                    belStatusCte cte = new belStatusCte();
                    if (node["chCTe"] != null)
                    {
                        cte.NumeroSeq = node["chCTe"].InnerText.Substring(36, 7);
                        cte.Chave = node["chCTe"].InnerText;
                    }
                    if (node["cStat"] != null)
                    {
                        cte.CodRetorno = node["cStat"].InnerText;
                        if (cte.CodRetorno == "100")
                        {
                            cte.Enviado = true;
                        }
                    }
                    if (node["xMotivo"] != null)
                    {
                        cte.Motivo = node["xMotivo"].InnerText;
                    }
                    //Protocolo de Retorno
                    if (node["nProt"] != null)
                    {
                        cte.Protocolo = node["nProt"].InnerText;
                    }
                    if (node["dhRecbto"] != null)
                    {
                        DateTime data = Convert.ToDateTime(node["dhRecbto"].InnerText);
                        cte.DataRecebimento = data.ToLongDateString() + " às " + data.ToShortTimeString();
                    }
                    ListaStatus.Add(cte);
                }

                
                return ListaStatus;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void SalvaArquivoPastaEnviado(string sNumCte, string sChaveCte)
        {
            try
            {
                string sData = daoUtil.GetDateServidor().Date.ToString("dd-MM-yyyy");

                DirectoryInfo dPastaEnviados = new DirectoryInfo(Pastas.ENVIADOS);
                if (!dPastaEnviados.Exists) { dPastaEnviados.Create(); }
                DirectoryInfo dPastaEnviadosMesAtual = new DirectoryInfo(dPastaEnviados + @"\\" + sData.Substring(3, 2) + "-" + sData.Substring(8, 2));
                if (!dPastaEnviadosMesAtual.Exists) { dPastaEnviadosMesAtual.Create(); }


                DirectoryInfo dPastaEnvio = new DirectoryInfo(Pastas.ENVIO);
                if (dPastaEnvio.Exists)
                {
                    DirectoryInfo dPastaEnvioMesAtual = new DirectoryInfo(dPastaEnvio + @"\\" + sData.Substring(3, 2) + "-" + sData.Substring(8, 2));
                    XDocument XmlCte = XDocument.Load(dPastaEnvioMesAtual.ToString() + "\\" + "Cte_" + sNumCte + ".xml");

                    if (XmlCte != null)
                    {
                        XmlDocument doc = MontaXmlConsultaSituacao(sChaveCte);
                        string sRetorno = ConsultarSituacao(doc, true, sChaveCte);

                        sRetorno = sRetorno.Substring(sRetorno.IndexOf("<protCTe"), sRetorno.IndexOf("</retConsSitCTe>") - sRetorno.IndexOf("<protCTe"));


                        string sX = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
                                    "<cteProc versao=\"1.04\" xmlns=\"http://www.portalfiscal.inf.br/cte\">" +
                             XmlCte.ToString() + sRetorno + "</cteProc>";

                        StreamWriter sw = new StreamWriter(dPastaEnviadosMesAtual + "\\Cte_" + sChaveCte + ".xml");
                        sw.Write(sX);
                        sw.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Salvar o CT-e " + sNumCte + " na pasta Enviados");
            }
        }

        public void SalvaArquivoPastaCancelado(string sChaveCte)
        {
            try
            {
                string sData = daoUtil.GetDateServidor().Date.ToString("dd-MM-yyyy");

                DirectoryInfo dPastaCancelados = new DirectoryInfo(Pastas.CANCELADOS);
                if (!dPastaCancelados.Exists) { dPastaCancelados.Create(); }
                DirectoryInfo dPastaCanceladosMesAtual = new DirectoryInfo(dPastaCancelados + @"\\" + sData.Substring(3, 2) + "-" + sData.Substring(8, 2));
                if (!dPastaCanceladosMesAtual.Exists) { dPastaCanceladosMesAtual.Create(); }


                DirectoryInfo dPastaEnviados = new DirectoryInfo(Pastas.ENVIADOS);
                if (dPastaEnviados.Exists)
                {
                    DirectoryInfo dPastaEnviadosMesAtual = new DirectoryInfo(dPastaEnviados + @"\\" + sData.Substring(3, 2) + "-" + sData.Substring(8, 2));
                    XDocument XmlCte = XDocument.Load(dPastaEnviadosMesAtual.ToString() + "\\" + "Cte_" + sChaveCte + ".xml");
                    if (XmlCte != null)
                    {
                        XmlCte.Save(dPastaCanceladosMesAtual + "\\Cte_" + sChaveCte + ".xml");
                        File.Delete(dPastaEnviadosMesAtual.ToString() + "\\" + "Cte_" + sChaveCte + ".xml");
                    }
                }
            }
            catch (Exception)
            {
                throw new Exception("Erro ao Salvar o CT-e de Chave " + sChaveCte + " na pasta Cancelados");
            }
        }


    }
}
