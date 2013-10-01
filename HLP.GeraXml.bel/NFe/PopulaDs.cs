using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using HLP.GeraXml.Comum.DataSet;
using HLP.GeraXml.Comum.Static;

namespace HLP.GeraXml.bel.NFe
{
    public class PopulaDs
    {


        int icountxNdIPI = 0;
        int icontxNdIPInt = 0;




        int iqtdeComercial = 0;



        #region Criação dos DataRows


        dsDanfe.infNFeRow drInfNFe; //1


        dsDanfe.codigo_barrasRow drCodigoBarras;


        dsDanfe.refNFRow drrefNF;
        dsDanfe.NFrefRow drNFref;
        dsDanfe.ideRow drIde;


        dsDanfe.enderEmitRow drenderEmit; //1
        dsDanfe.emitRow dremit; //2


        dsDanfe.enderDestRow drEnderDest;
        dsDanfe.destRow drDest;



        dsDanfe.retiradaRow drRetira;


        dsDanfe.entregaRow drEntrega;



        dsDanfe.detRow drDet;

        dsDanfe.impostoRow drImposto;
        dsDanfe.ICMSRow drICMS;
        dsDanfe.ICMS00Row drICMS00;
        dsDanfe.ICMS10Row drICMS10;
        dsDanfe.ICMS20Row drICMS20;
        dsDanfe.ICMS30Row drICMS30;
        dsDanfe.ICMS40Row drICMS40;
        dsDanfe.ICMS51Row drICMS51;
        dsDanfe.ICMS60Row drICMS60;
        dsDanfe.ICMS70Row drICMS70;
        dsDanfe.ICMS90Row drICMS90;
        dsDanfe.ICMSPartRow drICMSPart; //NFe_2.0
        dsDanfe.ICMSSTRow drICMSST;//NFe_2.0
        dsDanfe.ICMSSN101Row drICMSSN101;//NFe_2.0
        dsDanfe.ICMSSN102Row drICMSSN102;//NFe_2.0
        dsDanfe.ICMSSN201Row drICMSSN201;//NFe_2.0
        dsDanfe.ICMSSN500Row drICMSSN500;//NFe_2.0
        dsDanfe.ICMSSN900Row drICMSSN900;//NFe_2.0
        dsDanfe.IPIRow drIPI;
        dsDanfe.IPITribRow drIPItrib;
        dsDanfe.IPINTRow drIPInt;
        dsDanfe.IIRow drII;
        dsDanfe.PISRow drPIS;
        dsDanfe.PISAliqRow drPisAliq;
        dsDanfe.PISQtdeRow drPisQtde;
        dsDanfe.PISNTRow drPisNT;
        dsDanfe.PISOutrRow drPisOutr;
        dsDanfe.PISSTRow drPisST;
        dsDanfe.COFINSRow drCofins;
        dsDanfe.COFINSAliqRow drCofinsAliq;
        dsDanfe.COFINSQtdeRow drCofinsQtde;
        dsDanfe.COFINSNTRow drCofinsNT;
        dsDanfe.COFINSOutrRow drCofinsOutr;
        dsDanfe.COFINSSTRow drCofinsST;
        dsDanfe.ISSQNRow drISSQN;
        dsDanfe.infAdProdRow drInfAdProd;
        dsDanfe.prodRow drProd;



        dsDanfe.totalRow drTotal;
        dsDanfe.ICMSTotRow drICMStot;
        dsDanfe.ISSQNtotRow drISSQNtot;
        dsDanfe.retTribRow drRetTrib;



        dsDanfe.transpRow drTransp;
        dsDanfe.transportaRow drTransportadora;
        dsDanfe.retTranspRow drRetTransp;
        dsDanfe.veicTranspRow drVeicTransp;
        dsDanfe.reboqueRow drReboque;
        dsDanfe.volRow drVol;
        dsDanfe.lacresRow drLacres;



        dsDanfe.cobrRow drCobr;
        dsDanfe.fatRow drFat;
        dsDanfe.dupRow drDup;


        dsDanfe.infAdicRow drInfAdic;
        dsDanfe.obsContRow drObsCont;
        dsDanfe.obsFiscoRow drObsFisco;
        dsDanfe.procRefRow drProcRef;


        dsDanfe.exportaRow drExporta;


        dsDanfe.compraRow drCompra;



        dsDanfe.infProtRow drInfProt;


        dsDanfe.LogoRow drLogo;

        #endregion

        #region Popula Tag InfNFe

        public void populaTagInfNFe(dsDanfe dsdanfe, XmlDocument xml, string CodinfNfeId, int ihoraImpDanfe, int iDataImpDanfe)
        {
            XmlNodeList xNinfNFe = xml.GetElementsByTagName("infNFe");

            drInfNFe = dsdanfe.infNFe.NewinfNFeRow();



            if (xNinfNFe.Count > 0)
            {
                for (int i = 0; i < xNinfNFe.Count; i++)
                {
                    string InfNFeId = CodinfNfeId; //Codigo
                    // qtde de nodes 
                    for (int j = 0; j < xNinfNFe[i].Attributes.Count; j++)
                    {
                        populaDadosInfNFe(xNinfNFe[i].Attributes[j].LocalName, xNinfNFe[i].Attributes[j].Value, InfNFeId.ToString());
                    }

                    string sCodDadosNfe = GeraChaveDadosNfe(i, xml);
                    dsdanfe.infNFe.AddinfNFeRow(drInfNFe);
                    drInfNFe = dsdanfe.infNFe.NewinfNFeRow();

                    // Diego - O.S 24205 - 02/03/2010 
                    if (dsdanfe.infNFe[Convert.ToInt16(CodinfNfeId) - 1].Id != "") // Diego - OS_24302 - 01/04/2010
                    {
                        XmlNodeList xDet = xml.GetElementsByTagName("det"); //Para Verificar a Qtde de Pag.
                        drCodigoBarras = dsdanfe.codigo_barras.Newcodigo_barrasRow();
                        drCodigoBarras.codId = Convert.ToInt32(InfNFeId);
                        drCodigoBarras.InfNFeId = InfNFeId.ToString();

                        // DIEGO - 05/05/2010
                        drCodigoBarras.horaImpDanfe = ihoraImpDanfe;
                        drCodigoBarras.dataImpDanfe = iDataImpDanfe;
                        // DIEGO - 05/05/2010 - FIM                       

                        Byte[] bimagem = SalvaCodBarras(dsdanfe.infNFe[Convert.ToInt16(CodinfNfeId) - 1].Id);
                        Byte[] bImagemDadosNfe = SalvaCodBarras(sCodDadosNfe);
                        drCodigoBarras.cod_Barras = bimagem;
                        drCodigoBarras.cod_BarrasContingenciaDadosNfe = bImagemDadosNfe;
                        drCodigoBarras.cod_DadosNfe = sCodDadosNfe;
                        // Diego - OS_24302 - 01/04/2010
                        if (xDet.Count < 19)
                        {
                            drCodigoBarras.qtdePagRetrato = "1";
                        }
                        else
                        {
                            double dx = (xDet.Count - 19) / 44.0;
                            int ix = (xDet.Count - 19) / 44;

                            if (dx == Convert.ToDouble(ix))
                            {
                                drCodigoBarras.qtdePagRetrato = ix.ToString();
                            }
                            else
                            {
                                drCodigoBarras.qtdePagRetrato = (ix + 2).ToString();
                            }
                        }
                        // Diego - OS_24302 - 01/04/2010 - fim
                        dsdanfe.codigo_barras.Addcodigo_barrasRow(drCodigoBarras);
                        drCodigoBarras = dsdanfe.codigo_barras.Newcodigo_barrasRow();
                    }
                    // Diego - O.S 24205 - 02/03/2010  - FIM
                }
            }
        }







        private void populaDadosInfNFe(string atributo, string valor, string InfNFeId)
        {
            switch (atributo)
            {
                case "Id": drInfNFe.Id = valor.Substring(3, 44);
                    break;
                case "versao": drInfNFe.versao = valor;
                    break;
                case "pk_nitem": drInfNFe.pk_nitem = InfNFeId;
                    break;
            }
            drInfNFe.InfNFeId = InfNFeId;
        }

        #endregion

        #region Popula Tag IDE
        public void populaTagIDE(dsDanfe dsdanfe, XmlDocument xml, string CodinfNfeId)
        {

            XmlNodeList xNdrefNF = xml.GetElementsByTagName("refNF");
            XmlNodeList xNdNFref = xml.GetElementsByTagName("NFref");
            XmlNodeList xNdIde = xml.GetElementsByTagName("ide");

            drrefNF = dsdanfe.refNF.NewrefNFRow();
            drNFref = dsdanfe.NFref.NewNFrefRow();
            drIde = dsdanfe.ide.NewideRow();


            // Verficação se as tags estão criadas.
            if (xNdrefNF.Count > 0)
            {
                //Danner - o.s. 24184 - 01/03/2010
                //for (int i = 0; i < xNdrefNF.Count; i++)
                //{
                //    int NFrefId = i + 1;
                //    for (int j = 0; j < xNdrefNF[i].ChildNodes.Count; j++)
                //    {
                //        populaDadosRefNF(xNdrefNF[i].ChildNodes[j].LocalName, xNdrefNF[i].ChildNodes[j].InnerText, NFrefId.ToString());
                //    }
                //    dsdanfe.refNF.AddrefNFRow(drrefNF);
                //    drrefNF = dsdanfe.refNF.NewrefNFRow();
                //}
                //Fim - Danner - o.s. 24184 - 01/03/2010
            }

            if (xNdNFref.Count > 0)
            {
                //Danner - o.s. 24184 - 01/03/2010
                //for (int i = 0; i < xNdNFref.Count; i++)
                //{
                //    int ideID = 0;
                //    int NFrefId = dsdanfe.NFref.Count;

                //    if (dsdanfe.NFref.Count > 0)
                //    {
                //        ideID = dsdanfe.ide.Count + 1;
                //    }
                //    else
                //    {
                //        ideID = i + 1;
                //    }



                //    int Id = i + 1; // Chave primária e estrangeira
                //    for (int j = 0; j < xNdNFref[i].ChildNodes.Count; j++)
                //    {
                //        populaDadosRefNF(xNdNFref[i].ChildNodes[j].LocalName, xNdNFref[i].ChildNodes[j].InnerText, Id.ToString());
                //    }
                //    dsdanfe.NFref.AddNFrefRow(drNFref);
                //    drNFref = dsdanfe.NFref.NewNFrefRow();
                //}
                //Fim - Danner - o.s. 24184 - 01/03/2010
            }

            if (xNdIde.Count > 0)
            {
                // verifico qtas tags existem do mesmo tipo dentro do XML
                for (int i = 0; i < xNdIde.Count; i++)
                {
                    int ideID = 0;

                    if (dsdanfe.ide.Count > 0)
                    {
                        ideID = dsdanfe.ide.Count + 1;
                    }
                    else
                    {
                        ideID = i + 1;
                    }

                    // qtde de nodes 
                    for (int j = 0; j < xNdIde[i].ChildNodes.Count; j++)
                    {
                        populaDadosIDE(xNdIde[i].ChildNodes[j].LocalName, xNdIde[i].ChildNodes[j].InnerText, ideID.ToString(), CodinfNfeId);
                    }
                    dsdanfe.ide.AddideRow(drIde);
                    drIde = dsdanfe.ide.NewideRow();
                }
            }
        }

        private void populaDadosRefNF(string tag, string valor, string NFrefId)
        {
            switch (tag)
            {
                case "cUF": drrefNF.cUF = valor;
                    break;
                case "AAMM": drrefNF.AAMM = valor;
                    break;
                case "CNPJ": drrefNF.CNPJ = valor;
                    break;
                case "mod": drrefNF.mod = valor;
                    break;
                case "serie": drrefNF.serie = valor;
                    break;
                case "nNF": drrefNF.nNF = valor;
                    break;
                case "NFrefId": drrefNF.NFrefId = valor;
                    break;
            }
            drrefNF.NFrefId = NFrefId;
        }

        private void populaDadosNfRef(string tag, string valor, string Id)
        {
            switch (tag)
            {
                case "RefNfe": drNFref.RefNfe = valor;
                    break;
            }
            drNFref.ideId = Id;
            drNFref.NFrefId = Id;
        }

        private void populaDadosIDE(string tag, string valor, string ideID, string CodinfNfeId)
        {
            switch (tag)
            {
                case "cUF": drIde.cUF = valor;
                    break;
                case "cNF": drIde.cNF = valor;
                    break;
                case "natOp": drIde.natOp = valor;
                    break;
                case "indPag": drIde.indPag = valor;
                    break;
                case "mod": drIde.mod = valor;
                    break;
                case "serie": drIde.serie = valor;
                    break;
                case "nNF": drIde.nNF = valor;
                    break;
                case "dEmi": drIde.dEmi = valor;
                    break;
                case "dSaiEnt": drIde.dSaiEnt = valor;
                    break;
                case "tpNF": drIde.tpNF = valor;
                    break;
                case "cMunFG": drIde.cMunFG = valor;
                    break;
                case "tplmp": drIde.tplmp = valor;
                    break;
                case "tpEmis": drIde.tpEmis = valor;
                    break;
                case "cDV": drIde.cDV = valor;
                    break;
                case "tpAmb": drIde.tpAmb = valor;
                    break;
                case "finNFe": drIde.finNFe = valor;
                    break;
                case "procEmi": drIde.procEmi = valor;
                    break;
                case "verProc": drIde.verProc = valor;
                    break;
            }
            drIde.ideId = ideID;
            drIde.InfNFeId = CodinfNfeId;
        }


        #endregion

        #region Popula Tag Emit

        public void populaTagEmit(dsDanfe dsdanfe, XmlDocument xml, string CodinfNfeId)
        {

            XmlNodeList xNdenderEmit = xml.GetElementsByTagName("enderEmit");
            XmlNodeList xNdEmit = xml.GetElementsByTagName("emit");

            drenderEmit = dsdanfe.enderEmit.NewenderEmitRow();
            dremit = dsdanfe.emit.NewemitRow();

            if (xNdenderEmit.Count > 0)
            {
                for (int i = 0; i < xNdenderEmit.Count; i++)
                {
                    int emitID = dsdanfe.emit.Count + 1;
                    // qtde de nodes 
                    for (int j = 0; j < xNdenderEmit[i].ChildNodes.Count; j++)
                    {
                        populaDadosEndeEmit(xNdenderEmit[i].ChildNodes[j].LocalName, xNdenderEmit[i].ChildNodes[j].InnerText, emitID.ToString());
                    }
                    dsdanfe.enderEmit.AddenderEmitRow(drenderEmit);
                    drenderEmit = dsdanfe.enderEmit.NewenderEmitRow();
                }
            }
            if (xNdEmit.Count > 0)
            {
                // verifico qtas tags existem do mesmo tipo dentro do XML
                for (int i = 0; i < xNdEmit.Count; i++)
                {
                    int emitID = 0;

                    if (dsdanfe.emit.Count > 0)
                    {
                        emitID = dsdanfe.emit.Count + 1;
                    }
                    else
                    {
                        emitID = i + 1;
                    }

                    // qtde de nodes 
                    for (int j = 0; j < xNdEmit[i].ChildNodes.Count; j++)
                    {
                        populaDadosEmit(xNdEmit[i].ChildNodes[j].LocalName, xNdEmit[i].ChildNodes[j].InnerText, emitID.ToString(), CodinfNfeId);
                    }
                    dsdanfe.emit.AddemitRow(dremit);
                    dremit = dsdanfe.emit.NewemitRow();
                }
            }
        }

        private void populaDadosEndeEmit(string tag, string valor, string ideID)
        {
            switch (tag)
            {
                case "xLgr": drenderEmit.xLrg = valor;
                    break;
                case "nro": drenderEmit.nro = valor;
                    break;
                case "xCpl": drenderEmit.xCpl = valor;
                    break;
                case "xBairro": drenderEmit.xBairro = valor;
                    break;
                case "cMun": drenderEmit.cMun = valor;
                    break;
                case "xMun": drenderEmit.xMun = valor;
                    break;
                case "UF": drenderEmit.UF = valor;
                    break;
                case "CEP": drenderEmit.CEP = valor;
                    break;
                case "cPais": drenderEmit.cPais = valor;
                    break;
                case "xPais": drenderEmit.xPais = valor;
                    break;
                case "fone": drenderEmit.fone = valor;
                    break;
            }
            drenderEmit.emitId = ideID;
        }

        private void populaDadosEmit(string tag, string valor, string ideID, string CodinfNfeId)
        {
            switch (tag)
            {
                case "CNPJ": dremit.CNPJ = valor;
                    break;
                case "CPF": dremit.CPF = valor;
                    break;
                case "xNome": dremit.xNome = valor;
                    break;
                case "xFant": dremit.xFant = valor;
                    break;
                case "IE": dremit.IE = valor;
                    break;
                case "IEST": dremit.IEST = valor;
                    break;
                case "IM": dremit.IM = valor;
                    break;
                case "CNAE": dremit.CNAE = valor;
                    break;
            }
            dremit.InfNFeId = CodinfNfeId;
            dremit.emitId = ideID;
        }

        #endregion

        #region Popula TAG Dest


        public void populaTagDest(dsDanfe dsdanfe, XmlDocument xml, string CodinfNfeId)
        {
            XmlNodeList xNenderDest = xml.GetElementsByTagName("enderDest");
            XmlNodeList xNdest = xml.GetElementsByTagName("dest");

            drEnderDest = dsdanfe.enderDest.NewenderDestRow();
            drDest = dsdanfe.dest.NewdestRow();

            if (xNenderDest.Count > 0)
            {
                for (int i = 0; i < xNenderDest.Count; i++)
                {
                    int destId = dsdanfe.emit.Count;

                    // qtde de nodes 
                    for (int j = 0; j < xNenderDest[i].ChildNodes.Count; j++)
                    {
                        populaDadosEnderDest(xNenderDest[i].ChildNodes[j].LocalName, xNenderDest[i].ChildNodes[j].InnerText, destId.ToString());
                    }
                    dsdanfe.enderDest.AddenderDestRow(drEnderDest);
                    drEnderDest = dsdanfe.enderDest.NewenderDestRow();
                }
            }
            if (xNdest.Count > 0)
            {
                for (int i = 0; i < xNdest.Count; i++)
                {
                    int destID = 0;
                    if (dsdanfe.dest.Count > 0)
                    {
                        destID = dsdanfe.dest.Count + 1;
                    }
                    else
                    {
                        destID = i + 1;
                    }

                    // qtde de nodes 
                    for (int j = 0; j < xNdest[i].ChildNodes.Count; j++)
                    {
                        populaDadosDest(xNdest[i].ChildNodes[j].LocalName, xNdest[i].ChildNodes[j].InnerText, destID.ToString(), CodinfNfeId);
                    }
                    dsdanfe.dest.AdddestRow(drDest);
                    drDest = dsdanfe.dest.NewdestRow();
                }
            }
        }

        private void populaDadosEnderDest(string tag, string valor, string destId)
        {
            switch (tag)
            {
                case "xLgr": drEnderDest.xLrg = valor;
                    break;
                case "nro": drEnderDest.nro = valor;
                    break;
                case "xCpl": drEnderDest.xCpl = valor;
                    break;
                case "xBairro": drEnderDest.xBairro = valor;
                    break;
                case "cMun": drEnderDest.cMun = valor;
                    break;
                case "xMun": drEnderDest.xMun = valor;
                    break;
                case "UF": drEnderDest.UF = valor;
                    break;
                case "CEP": drEnderDest.CEP = valor;
                    break;
                case "cPais": drEnderDest.cPais = valor;
                    break;
                case "xPais": drEnderDest.xPais = valor;
                    break;
                case "fone": drEnderDest.fone = valor;
                    break;
            }
            drEnderDest.destId = destId;
        }

        private void populaDadosDest(string tag, string valor, string id, string CodinfNfeId)
        {
            switch (tag)
            {
                case "CNPJ": drDest.CNPJ = valor;
                    break;
                case "CPF": drDest.CPF = valor;
                    break;
                case "xNome": drDest.xNome = valor;
                    break;
                case "IE": drDest.IE = valor;
                    break;
                case "ISUF": drDest.ISUF = valor;
                    break;
            }
            drDest.destId = id;
            drDest.InfNFeId = CodinfNfeId;
        }

        #endregion

        #region Popula TAG Det

        public void populaTagdet(dsDanfe dsdanfe, XmlDocument xml, string CodinfNfeId)
        {
            XmlNodeList xNdDet = xml.GetElementsByTagName("det");
            XmlNodeList xNdProd = xml.GetElementsByTagName("prod");
            XmlNodeList xNdImposto = xml.GetElementsByTagName("imposto");
            XmlNodeList xNdICMS = xml.GetElementsByTagName("ICMS");
            XmlNodeList xNdICMS00 = xml.GetElementsByTagName("ICMS00");
            XmlNodeList xNdICMS10 = xml.GetElementsByTagName("ICMS10");
            XmlNodeList xNdICMS20 = xml.GetElementsByTagName("ICMS20");
            XmlNodeList xNdICMS30 = xml.GetElementsByTagName("ICMS30");
            XmlNodeList xNdICMS40 = xml.GetElementsByTagName("ICMS40");
            XmlNodeList xNdICMS51 = xml.GetElementsByTagName("ICMS51");
            XmlNodeList xNdICMS60 = xml.GetElementsByTagName("ICMS60");
            XmlNodeList xNdICMS70 = xml.GetElementsByTagName("ICMS70");
            XmlNodeList xNdICMS90 = xml.GetElementsByTagName("ICMS90");
            XmlNodeList xNdICMSPart = xml.GetElementsByTagName("ICMSPart");
            XmlNodeList xNdICMSST = xml.GetElementsByTagName("ICMSST");
            XmlNodeList xNdICMSSN101 = xml.GetElementsByTagName("ICMSSN101");
            XmlNodeList xNdICMSSN102 = xml.GetElementsByTagName("ICMSSN102");
            XmlNodeList xNdICMSSN201 = xml.GetElementsByTagName("ICMSSN201");
            XmlNodeList xNdICMSSN500 = xml.GetElementsByTagName("ICMSSN500");
            XmlNodeList xNdICMSSN900 = xml.GetElementsByTagName("ICMSSN900");
            XmlNodeList xNdIPI = xml.GetElementsByTagName("IPI");
            XmlNodeList xNdIPItrib = xml.GetElementsByTagName("IPITrib");
            XmlNodeList xNdIPInt = xml.GetElementsByTagName("IPINT");
            XmlNodeList xndII = xml.GetElementsByTagName("II");
            XmlNodeList xndPIS = xml.GetElementsByTagName("PIS");
            XmlNodeList xndPISAliq = xml.GetElementsByTagName("PISAliq");
            XmlNodeList xndPISQtde = xml.GetElementsByTagName("PISQtde");
            XmlNodeList xndPISNT = xml.GetElementsByTagName("PISNT");
            XmlNodeList xndPISOutr = xml.GetElementsByTagName("PISOutr");
            XmlNodeList xndPISST = xml.GetElementsByTagName("PISST");
            XmlNodeList xndCOFINS = xml.GetElementsByTagName("COFINS");
            XmlNodeList xndCOFINSaliq = xml.GetElementsByTagName("COFINSAliq");
            XmlNodeList xndCOFINSqtde = xml.GetElementsByTagName("COFINSQtde");
            XmlNodeList xndCOFINSnt = xml.GetElementsByTagName("COFINSNT");
            XmlNodeList xndCOFINSoutr = xml.GetElementsByTagName("COFINSOutr");
            XmlNodeList xndCOFINSst = xml.GetElementsByTagName("COFINSST");
            XmlNodeList xndISSQN = xml.GetElementsByTagName("ISSQN");
            XmlNodeList xndInfAdProd = xml.GetElementsByTagName("infAdProd");

            drDet = dsdanfe.det.NewdetRow();
            drProd = dsdanfe.prod.NewprodRow();
            drImposto = dsdanfe.imposto.NewimpostoRow();
            drICMS = dsdanfe.ICMS.NewICMSRow();
            drICMS00 = dsdanfe.ICMS00.NewICMS00Row();
            drICMS10 = dsdanfe.ICMS10.NewICMS10Row();
            drICMS20 = dsdanfe.ICMS20.NewICMS20Row();
            drICMS30 = dsdanfe.ICMS30.NewICMS30Row();
            drICMS40 = dsdanfe.ICMS40.NewICMS40Row();
            drICMS60 = dsdanfe.ICMS60.NewICMS60Row();
            drICMS70 = dsdanfe.ICMS70.NewICMS70Row();
            drICMS90 = dsdanfe.ICMS90.NewICMS90Row();

            drICMSPart = dsdanfe.ICMSPart.NewICMSPartRow();
            drICMSST = dsdanfe.ICMSST.NewICMSSTRow();

            drICMSSN101 = dsdanfe.ICMSSN101.NewICMSSN101Row();
            drICMSSN102 = dsdanfe.ICMSSN102.NewICMSSN102Row();
            drICMSSN201 = dsdanfe.ICMSSN201.NewICMSSN201Row();
            drICMSSN500 = dsdanfe.ICMSSN500.NewICMSSN500Row();
            drICMSSN900 = dsdanfe.ICMSSN900.NewICMSSN900Row();

            //Claudinei - o.s. sem - 18/12/2009
            drICMS51 = dsdanfe.ICMS51.NewICMS51Row();
            //Fim - Claudinei - o.s. sem - 18/12/2009
            drIPI = dsdanfe.IPI.NewIPIRow();
            drIPItrib = dsdanfe.IPITrib.NewIPITribRow();
            drIPInt = dsdanfe.IPINT.NewIPINTRow();
            drII = dsdanfe.II.NewIIRow();
            drPIS = dsdanfe.PIS.NewPISRow();
            drPisAliq = dsdanfe.PISAliq.NewPISAliqRow();
            drPisQtde = dsdanfe.PISQtde.NewPISQtdeRow();
            drPisNT = dsdanfe.PISNT.NewPISNTRow();
            drPisOutr = dsdanfe.PISOutr.NewPISOutrRow();
            drPisST = dsdanfe.PISST.NewPISSTRow();
            drCofins = dsdanfe.COFINS.NewCOFINSRow();
            drCofinsAliq = dsdanfe.COFINSAliq.NewCOFINSAliqRow();
            drCofinsNT = dsdanfe.COFINSNT.NewCOFINSNTRow();
            drCofinsOutr = dsdanfe.COFINSOutr.NewCOFINSOutrRow();
            drCofinsST = dsdanfe.COFINSST.NewCOFINSSTRow();
            drISSQN = dsdanfe.ISSQN.NewISSQNRow();
            drInfAdProd = dsdanfe.infAdProd.NewinfAdProdRow();
            // Diego - OS. 24144 - 19/02/2010
            drRetira = dsdanfe.retirada.NewretiradaRow();
            // Diego - OS. 24144 - 19/02/2010 - FIM

            // Diego - OS_24302 - 01/04/2010
            int iPK_itens_notaAnterior = dsdanfe.det.Count;
            // Diego - OS_24302 - 01/04/2010 Fim 


            if (xNdProd.Count > 0)
            {
                int i = 0;
                int detID = 0;
                while (i < xNdProd.Count)
                {
                    if (dsdanfe.det.Count > 0)
                    {
                        detID = dsdanfe.det.Count + 1;
                    }
                    else
                    {
                        detID = i + 1;
                    }
                    drDet = dsdanfe.det.NewdetRow();
                    populaDadosDet(detID, CodinfNfeId);
                    dsdanfe.det.AdddetRow(drDet);
                    i++;
                }
            }
            if (xNdProd.Count > 0)
            {
                for (int i = 0; i < xNdProd.Count; i++)
                {
                    int prodId = 0;

                    if (dsdanfe.prod.Count > 0)
                    {
                        prodId = dsdanfe.prod.Count + 1;
                    }
                    else
                    {
                        prodId = i + 1;
                    }



                    iqtdeComercial = Convert.ToInt16(Acesso.QTDE_CASAS_PRODUTOS);
                    for (int j = 0; j < xNdProd[i].ChildNodes.Count; j++)
                    {
                        populaDadosProd(xNdProd[i].ChildNodes[j].LocalName, xNdProd[i].ChildNodes[j].InnerText, prodId.ToString());
                    }
                    dsdanfe.prod.AddprodRow(drProd);
                    drProd = dsdanfe.prod.NewprodRow();
                }
            }

            if (xNdImposto.Count > 0)
            {
                int i = 0;
                int impostoID = 0;
                while (i < xNdImposto.Count)
                {
                    impostoID = dsdanfe.imposto.Count + 1;
                    drImposto = dsdanfe.imposto.NewimpostoRow();
                    drICMS = dsdanfe.ICMS.NewICMSRow();
                    drPIS = dsdanfe.PIS.NewPISRow();
                    drCofins = dsdanfe.COFINS.NewCOFINSRow();

                    populaDadosImposto_ICMS_PIS_COFINS(impostoID);

                    dsdanfe.ICMS.AddICMSRow(drICMS);
                    dsdanfe.imposto.AddimpostoRow(drImposto);
                    dsdanfe.PIS.AddPISRow(drPIS);
                    dsdanfe.COFINS.AddCOFINSRow(drCofins);
                    i++;
                }
            }

            int i00 = 0;
            int i10 = 0;
            int i20 = 0;
            int i30 = 0;
            int i40 = 0;
            int i51 = 0;
            int i60 = 0;
            int i70 = 0;
            int i90 = 0;

            int iPart = 0;
            int iST = 0;
            int i101 = 0;
            int i102 = 0;
            int i201 = 0;
            int i202 = 0;
            int i500 = 0;
            int i900 = 0;


            for (int i = 0; i < xNdICMS.Count; i++)
            {
                try
                {
                    // Diego - OS_24302 - 01/04/2010
                    iPK_itens_notaAnterior++;

                    switch (xNdICMS[i].FirstChild.Name)
                    {
                        case "ICMS00":
                            for (int j = 0; j < xNdICMS00[i00].ChildNodes.Count; j++)
                            {
                                populaDadosICMS00(xNdICMS00[i00].ChildNodes[j].LocalName, xNdICMS00[i00].ChildNodes[j].InnerText, (iPK_itens_notaAnterior).ToString());
                            }
                            dsdanfe.ICMS00.AddICMS00Row(drICMS00);
                            drICMS00 = dsdanfe.ICMS00.NewICMS00Row();

                            i00++;
                            break;
                        case "ICMS10":
                            for (int j = 0; j < xNdICMS10[i10].ChildNodes.Count; j++)
                            {
                                populaDadosICMS10(xNdICMS10[i10].ChildNodes[j].LocalName, xNdICMS10[i10].ChildNodes[j].InnerText, (iPK_itens_notaAnterior).ToString());
                            }
                            dsdanfe.ICMS10.AddICMS10Row(drICMS10);
                            drICMS10 = dsdanfe.ICMS10.NewICMS10Row();
                            i10++;
                            break;
                        case "ICMS20":
                            for (int j = 0; j < xNdICMS20[i20].ChildNodes.Count; j++)
                            {
                                populaDadosICMS20(xNdICMS20[i20].ChildNodes[j].LocalName, xNdICMS20[i20].ChildNodes[j].InnerText, (iPK_itens_notaAnterior).ToString());
                            }
                            dsdanfe.ICMS20.AddICMS20Row(drICMS20);
                            drICMS20 = dsdanfe.ICMS20.NewICMS20Row();
                            i20++;
                            break;
                        case "ICMS30":
                            for (int j = 0; j < xNdICMS30[i30].ChildNodes.Count; j++)
                            {
                                populaDadosICMS30(xNdICMS30[i30].ChildNodes[j].LocalName, xNdICMS30[i30].ChildNodes[j].InnerText, (iPK_itens_notaAnterior).ToString());
                            }
                            dsdanfe.ICMS30.AddICMS30Row(drICMS30);
                            drICMS30 = dsdanfe.ICMS30.NewICMS30Row();
                            i30++;
                            break;
                        case "ICMS40":
                            for (int j = 0; j < xNdICMS40[i40].ChildNodes.Count; j++)
                            {
                                populaDadosICMS40(xNdICMS40[i40].ChildNodes[j].LocalName, xNdICMS40[i40].ChildNodes[j].InnerText, (iPK_itens_notaAnterior).ToString());
                            }
                            dsdanfe.ICMS40.AddICMS40Row(drICMS40);
                            drICMS40 = dsdanfe.ICMS40.NewICMS40Row();
                            i40++;
                            break;
                        case "ICMS51":
                            for (int j = 0; j < xNdICMS51[i51].ChildNodes.Count; j++)
                            {
                                populaDadosICMS51(xNdICMS51[i51].ChildNodes[j].LocalName, xNdICMS51[i51].ChildNodes[j].InnerText, (iPK_itens_notaAnterior).ToString());
                            }
                            dsdanfe.ICMS51.AddICMS51Row(drICMS51);
                            drICMS51 = dsdanfe.ICMS51.NewICMS51Row();
                            i51++;
                            break;
                        case "ICMS60":
                            for (int j = 0; j < xNdICMS60[i60].ChildNodes.Count; j++)
                            {
                                populaDadosICMS60(xNdICMS60[i60].ChildNodes[j].LocalName, xNdICMS60[i60].ChildNodes[j].InnerText, (iPK_itens_notaAnterior).ToString());
                            }
                            dsdanfe.ICMS60.AddICMS60Row(drICMS60);
                            drICMS60 = dsdanfe.ICMS60.NewICMS60Row();
                            i60++;
                            break;
                        case "ICMS70":
                            for (int j = 0; j < xNdICMS70[i70].ChildNodes.Count; j++)
                            {
                                populaDadosICMS70(xNdICMS70[i70].ChildNodes[j].LocalName, xNdICMS70[i70].ChildNodes[j].InnerText, (iPK_itens_notaAnterior).ToString());
                            }
                            dsdanfe.ICMS70.AddICMS70Row(drICMS70);
                            drICMS70 = dsdanfe.ICMS70.NewICMS70Row();
                            i70++;
                            break;
                        case "ICMS90":
                            for (int j = 0; j < xNdICMS90[i90].ChildNodes.Count; j++)
                            {
                                populaDadosICMS90(xNdICMS90[i90].ChildNodes[j].LocalName, xNdICMS90[i90].ChildNodes[j].InnerText, (iPK_itens_notaAnterior).ToString());
                            }
                            dsdanfe.ICMS90.AddICMS90Row(drICMS90);
                            drICMS90 = dsdanfe.ICMS90.NewICMS90Row();
                            i90++;
                            break;
                        case "ICMSPart":
                            for (int j = 0; j < xNdICMSPart[iPart].ChildNodes.Count; j++)
                            {
                                populaDadosICMSPart(xNdICMSPart[iPart].ChildNodes[j].LocalName, xNdICMSPart[iPart].ChildNodes[j].InnerText, (iPK_itens_notaAnterior).ToString());
                            }
                            dsdanfe.ICMSPart.AddICMSPartRow(drICMSPart);
                            drICMSPart = dsdanfe.ICMSPart.NewICMSPartRow();
                            iPart++;
                            break;
                        case "ICMSST":
                            for (int j = 0; j < xNdICMSST[iST].ChildNodes.Count; j++)
                            {
                                populaDadosICMSST(xNdICMSST[iST].ChildNodes[j].LocalName, xNdICMSST[iST].ChildNodes[j].InnerText, (iPK_itens_notaAnterior).ToString());
                            }
                            dsdanfe.ICMSST.AddICMSSTRow(drICMSST);
                            drICMSST = dsdanfe.ICMSST.NewICMSSTRow();
                            iST++;
                            break;
                        case "ICMSSN101":
                            for (int j = 0; j < xNdICMSSN101[i101].ChildNodes.Count; j++)
                            {
                                populaDadosICMSSN101(xNdICMSSN101[i101].ChildNodes[j].LocalName, xNdICMSSN101[i101].ChildNodes[j].InnerText, (iPK_itens_notaAnterior).ToString());
                            }
                            dsdanfe.ICMSSN101.AddICMSSN101Row(drICMSSN101);
                            drICMSSN101 = dsdanfe.ICMSSN101.NewICMSSN101Row();
                            i101++;
                            break;
                        case "ICMSSN102":
                            for (int j = 0; j < xNdICMSSN102[i102].ChildNodes.Count; j++)
                            {
                                populaDadosICMSSN102(xNdICMSSN102[i102].ChildNodes[j].LocalName, xNdICMSSN102[i102].ChildNodes[j].InnerText, (iPK_itens_notaAnterior).ToString());
                            }
                            dsdanfe.ICMSSN102.AddICMSSN102Row(drICMSSN102);
                            drICMSSN102 = dsdanfe.ICMSSN102.NewICMSSN102Row();
                            i102++;
                            break;
                        case "ICMSSN201":
                            for (int j = 0; j < xNdICMSSN201[i201].ChildNodes.Count; j++)
                            {
                                populaDadosICMSSN201(xNdICMSSN201[i201].ChildNodes[j].LocalName, xNdICMSSN201[i201].ChildNodes[j].InnerText, (iPK_itens_notaAnterior).ToString());
                            }
                            dsdanfe.ICMSSN201.AddICMSSN201Row(drICMSSN201);
                            drICMSSN201 = dsdanfe.ICMSSN201.NewICMSSN201Row();
                            i201++;
                            break;
                        case "ICMSSN202":
                            xNdICMSSN201 = xml.GetElementsByTagName("ICMSSN202");
                            for (int j = 0; j < xNdICMSSN201[i202].ChildNodes.Count; j++)
                            {
                                populaDadosICMSSN201(xNdICMSSN201[i202].ChildNodes[j].LocalName, xNdICMSSN201[i202].ChildNodes[j].InnerText, (iPK_itens_notaAnterior).ToString());
                            }
                            dsdanfe.ICMSSN201.AddICMSSN201Row(drICMSSN201);
                            drICMSSN201 = dsdanfe.ICMSSN201.NewICMSSN201Row();
                            i202++;
                            break;
                        case "ICMSSN500":
                            for (int j = 0; j < xNdICMSSN500[i500].ChildNodes.Count; j++)
                            {
                                populaDadosICMSSN500(xNdICMSSN500[i500].ChildNodes[j].LocalName, xNdICMSSN500[i500].ChildNodes[j].InnerText, (iPK_itens_notaAnterior).ToString());
                            }
                            dsdanfe.ICMSSN500.AddICMSSN500Row(drICMSSN500);
                            drICMSSN500 = dsdanfe.ICMSSN500.NewICMSSN500Row();
                            i500++;
                            break;
                        case "ICMSSN900":
                            for (int j = 0; j < xNdICMSSN900[i900].ChildNodes.Count; j++)
                            {
                                populaDadosICMSSN900(xNdICMSSN900[i900].ChildNodes[j].LocalName, xNdICMSSN900[i900].ChildNodes[j].InnerText, (iPK_itens_notaAnterior).ToString());
                            }
                            dsdanfe.ICMSSN900.AddICMSSN900Row(drICMSSN900);
                            drICMSSN900 = dsdanfe.ICMSSN900.NewICMSSN900Row();
                            i900++;
                            break;

                    } // Diego - OS_24302 - 01/04/2010 - Fim

                    if (xNdIPI.Count > 0)
                    {
                        for (int j = 0; j < xNdIPI[i].ChildNodes.Count; j++)
                        {
                            populaDadosIPI(xNdIPI[i].ChildNodes[j].LocalName, xNdIPI[i].ChildNodes[j].InnerText, (iPK_itens_notaAnterior), (iPK_itens_notaAnterior).ToString());
                        }
                        dsdanfe.IPI.AddIPIRow(drIPI);
                        drIPI = dsdanfe.IPI.NewIPIRow();

                        //Claudinei - o.s. sem - 18/02/2010
                        // Diego - Sem O.S - 18/02/2010 

                        for (int x = 0; x < xNdIPI[i].ChildNodes.Count; x++)
                        {
                            if (xNdIPI[i].ChildNodes[x].Name.Equals("IPITrib"))
                            {
                                if (xNdIPItrib[icountxNdIPI] != null)
                                {
                                    for (int j = 0; j < xNdIPItrib[icountxNdIPI].ChildNodes.Count; j++)
                                    {
                                        populaDadosIPItrib(xNdIPItrib[icountxNdIPI].ChildNodes[j].LocalName, xNdIPItrib[icountxNdIPI].ChildNodes[j].InnerText, (iPK_itens_notaAnterior).ToString());

                                    }
                                    icountxNdIPI++;
                                    dsdanfe.IPITrib.AddIPITribRow(drIPItrib);
                                    drIPItrib = dsdanfe.IPITrib.NewIPITribRow();
                                }
                            }
                        }



                        for (int x = 0; x < xNdIPI[i].ChildNodes.Count; x++)
                        {
                            if (xNdIPI[i].ChildNodes[x].Name.Equals("IPINT"))
                            {
                                if (xNdIPInt[icontxNdIPInt] != null)
                                {

                                    for (int j = 0; j < xNdIPInt[icontxNdIPInt].ChildNodes.Count; j++)
                                    {
                                        populaDadosIPInt(xNdIPInt[icontxNdIPInt].ChildNodes[j].LocalName, xNdIPInt[icontxNdIPInt].ChildNodes[j].InnerText, (iPK_itens_notaAnterior).ToString());

                                    }
                                    icontxNdIPInt++;
                                    dsdanfe.IPINT.AddIPINTRow(drIPInt);
                                    drIPInt = dsdanfe.IPINT.NewIPINTRow();
                                }
                            }
                        }
                    }

                    // Diego - Sem O.S - 18/02/2010 - fIM


                    if (xndII.Count > 0)
                    {
                        for (int j = 0; j < xndII[i].ChildNodes.Count; j++)
                        {
                            populaDadosII(xndII[i].ChildNodes[j].LocalName, xndII[i].ChildNodes[j].InnerText, (iPK_itens_notaAnterior).ToString());
                        }
                        dsdanfe.II.AddIIRow(drII);
                        drII = dsdanfe.II.NewIIRow();
                    }
                    if (xndPISAliq.Count > 0)
                    {
                        if (xndPISAliq[i] != null)
                        {
                            for (int j = 0; j < xndPISAliq[i].ChildNodes.Count; j++) //Claudinei - sem - 20/01/2010
                            {
                                populaDadosPisAliq(xndPISAliq[i].ChildNodes[j].LocalName, xndPISAliq[i].ChildNodes[j].InnerText, (iPK_itens_notaAnterior).ToString());
                            }
                            dsdanfe.PISAliq.AddPISAliqRow(drPisAliq);
                            drPisAliq = dsdanfe.PISAliq.NewPISAliqRow();
                        }
                    }
                    if (xndPISQtde.Count > 0)
                    {
                        for (int j = 0; j < xndPISQtde[i].ChildNodes.Count; j++) //Claudinei - sem - 20/01/2010
                        {
                            populaDadosPisQtde(xndPISQtde[i].ChildNodes[j].LocalName, xndPISQtde[i].ChildNodes[j].InnerText, (iPK_itens_notaAnterior).ToString());
                        }
                        dsdanfe.PISQtde.AddPISQtdeRow(drPisQtde);
                        drPisQtde = dsdanfe.PISQtde.NewPISQtdeRow();
                    }
                    if (xndPISNT.Count > 0)
                    {
                        if (xndPISNT[i] != null)
                        {

                            for (int j = 0; j < xndPISNT[i].ChildNodes.Count; j++)
                            {
                                populaDadosPisNT(xndPISNT[i].ChildNodes[j].LocalName, xndPISNT[i].ChildNodes[j].InnerText, (iPK_itens_notaAnterior).ToString());
                            }
                            dsdanfe.PISNT.AddPISNTRow(drPisNT);
                            drPisNT = dsdanfe.PISNT.NewPISNTRow();
                        }
                    }
                    if (xndPISOutr[i] != null)
                    {
                        if (xndPISOutr[i].ChildNodes.Count > 0)
                        {
                            for (int j = 0; j < xndPISOutr[i].ChildNodes.Count; j++)
                            {
                                populaDadosPisOut(xndPISOutr[i].ChildNodes[j].LocalName, xndPISOutr[i].ChildNodes[j].InnerText, (iPK_itens_notaAnterior).ToString());
                            }
                            dsdanfe.PISOutr.AddPISOutrRow(drPisOutr);
                            drPisOutr = dsdanfe.PISOutr.NewPISOutrRow();
                        }

                    }

                    if (xndPISST.Count > 0)
                    {
                        for (int j = 0; j < xndPISST[i].ChildNodes.Count; j++)
                        {
                            populaDadosPisST(xndPISST[i].ChildNodes[j].LocalName, xndPISST[i].ChildNodes[j].InnerText, (iPK_itens_notaAnterior).ToString());
                        }
                        dsdanfe.PISST.AddPISSTRow(drPisST);
                        drPisST = dsdanfe.PISST.NewPISSTRow();
                    }
                    if (xndCOFINSaliq.Count > 0)
                    {
                        if (xndCOFINSaliq[i] != null)
                        {
                            for (int j = 0; j < xndCOFINSaliq[i].ChildNodes.Count; j++)
                            {
                                populaDadosCofinsAliq(xndCOFINSaliq[i].ChildNodes[j].LocalName, xndCOFINSaliq[i].ChildNodes[j].InnerText, (iPK_itens_notaAnterior).ToString());
                            }
                            dsdanfe.COFINSAliq.AddCOFINSAliqRow(drCofinsAliq);
                            drCofinsAliq = dsdanfe.COFINSAliq.NewCOFINSAliqRow();
                        }
                    }
                    if (xndCOFINSqtde.Count > 0)
                    {
                        for (int j = 0; j < xndCOFINSqtde[i].ChildNodes.Count; j++)
                        {
                            populaDadosCofinsQtde(xndCOFINSqtde[i].ChildNodes[j].LocalName, xndCOFINSqtde[i].ChildNodes[j].InnerText, (iPK_itens_notaAnterior).ToString());
                        }
                        dsdanfe.COFINSQtde.AddCOFINSQtdeRow(drCofinsQtde);
                        drCofinsQtde = dsdanfe.COFINSQtde.NewCOFINSQtdeRow();
                    }
                    if (xndCOFINSnt.Count > 0)
                    {
                        if (xndCOFINSnt[i] != null)
                        {
                            for (int j = 0; j < xndCOFINSnt[i].ChildNodes.Count; j++)
                            {
                                populaDadosCofinsNT(xndCOFINSnt[i].ChildNodes[j].LocalName, xndCOFINSnt[i].ChildNodes[j].InnerText, (iPK_itens_notaAnterior).ToString());
                            }
                            dsdanfe.COFINSNT.AddCOFINSNTRow(drCofinsNT);
                            drCofinsNT = dsdanfe.COFINSNT.NewCOFINSNTRow();
                        }
                    }
                    if (xndCOFINSoutr[i] != null)
                    {
                        for (int j = 0; j < xndCOFINSoutr[i].ChildNodes.Count; j++)
                        {
                            populaDadosCofinsOutr(xndCOFINSoutr[i].ChildNodes[j].LocalName, xndCOFINSoutr[i].ChildNodes[j].InnerText, (iPK_itens_notaAnterior).ToString());
                        }
                        dsdanfe.COFINSOutr.AddCOFINSOutrRow(drCofinsOutr);
                        drCofinsOutr = dsdanfe.COFINSOutr.NewCOFINSOutrRow();
                    }
                    if (xndCOFINSst.Count > 0)
                    {
                        for (int j = 0; j < xndCOFINSst[i].ChildNodes.Count; j++)
                        {
                            populaDadosCofinsST(xndCOFINSst[i].ChildNodes[j].LocalName, xndCOFINSst[i].ChildNodes[j].InnerText, (iPK_itens_notaAnterior).ToString());
                        }
                        dsdanfe.COFINSST.AddCOFINSSTRow(drCofinsST);
                        drCofinsST = dsdanfe.COFINSST.NewCOFINSSTRow();
                    }
                    if (xndISSQN.Count > 0)
                    {
                        for (int j = 0; j < xndISSQN[i].ChildNodes.Count; j++)
                        {
                            populaDadosISSQN(xndISSQN[i].ChildNodes[j].LocalName, xndISSQN[i].ChildNodes[j].InnerText, (iPK_itens_notaAnterior).ToString());
                        }
                        dsdanfe.ISSQN.AddISSQNRow(drISSQN);
                        drISSQN = dsdanfe.ISSQN.NewISSQNRow();
                    }

                    //comentar

                    //Diego - o.s. sem - 09/02/2010
                    for (int x = 0; x < xNdDet[i].ChildNodes.Count; x++)
                    {
                        if (xNdDet[i].ChildNodes[x].Name.Equals("infAdProd"))
                        {
                            populaDadosInfAdProd(xNdDet[i].ChildNodes[x].InnerText, (iPK_itens_notaAnterior).ToString());
                        }
                    }
                    dsdanfe.infAdProd.AddinfAdProdRow(drInfAdProd);
                    drInfAdProd = dsdanfe.infAdProd.NewinfAdProdRow();


                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        private void populaDadosDet(int detId, string CodinfNfeId)
        {
            drDet.nIten = detId.ToString();
            drDet.detId = detId.ToString();
            drDet.InfNFeId = CodinfNfeId;
        }

        private void populaDadosProd(string tag, string valor, string InfNFeId)
        {
            switch (tag)
            {
                case "cProd": drProd.cProp = valor;
                    break;
                case "cEAN": drProd.cEAN = valor;
                    break;
                case "xProd": drProd.xProp = valor;
                    break;
                case "NCM": drProd.NCM = valor;
                    break;
                case "EXTIPI": drProd.EXTIPI = valor;
                    break;
                case "genero": drProd.genero = valor;
                    break;
                case "CFOP": drProd.CFOP = valor;
                    break;
                case "uCom": drProd.uCom = valor;
                    break;
                case "qCom":
                    drProd.qCom = FormataQtdeComercial(valor.Replace('.', ','));
                    break;
                case "vUnCom": drProd.vUnCom = valor;
                    break;
                case "vProd": drProd.vProd = valor;
                    break;
                case "cEANTrib": drProd.cEANTrib = valor;
                    break;
                case "uTrib": drProd.uTrib = valor;
                    break;
                case "qTrib": drProd.qTrib = valor;
                    break;
                case "vUnTrib": drProd.vUnTrib = valor;
                    break;
                case "vFrete": drProd.vFrete = valor;
                    break;
                case "vSeg": drProd.vSeg = valor;
                    break;
                case "vDesc": drProd.vDesc = valor;
                    break;
            }
            drProd.detId = InfNFeId;
            drProd.prodId = InfNFeId;
        }

        private void populaDadosImposto_ICMS_PIS_COFINS(int impostoID)
        {
            drImposto.detID = impostoID.ToString();
            drImposto.impostoID = impostoID.ToString();

            drICMS.icmsID = impostoID.ToString();
            drICMS.impostoID = impostoID.ToString();

            drPIS.impostoID = impostoID.ToString();
            drPIS.pisID = impostoID.ToString();

            drCofins.cofinsID = impostoID.ToString();
            drCofins.impostoID = impostoID.ToString();
        }

        private void populaDadosICMS00(string tag, string valor, string ID)
        {
            switch (tag)
            {
                case "orig": drICMS00.orig = valor;
                    break;
                case "CST": drICMS00.CST = valor;
                    break;
                case "modBC": drICMS00.modBC = valor;
                    break;
                case "vBC": drICMS00.vBC = valor;
                    break;
                case "pICMS": drICMS00.pICMS = valor;
                    break;
                case "vICMS": drICMS00.vICMS = valor;
                    break;
            }
            drICMS00.icmsID = ID;
        }

        private void populaDadosICMS10(string tag, string valor, string ID)
        {
            switch (tag)
            {
                case "orig": drICMS10.orig = valor;
                    break;
                case "CST": drICMS10.CST = valor;
                    break;
                case "modBC": drICMS10.modBC = valor;
                    break;
                case "vBC": drICMS10.vBC = valor;
                    break;
                case "pICMS": drICMS10.pICMS = valor;
                    break;
                case "vICMS": drICMS10.vICMS = valor;
                    break;
                case "modBCST": drICMS10.modBCST = valor;
                    break;
                case "pMVAST": drICMS10.pMVAST = valor;
                    break;
                case "pRedBCST": drICMS10.pRedBCST = valor;
                    break;
                case "vBCST": drICMS10.vBCST = valor;
                    break;
                case "pICMSST": drICMS10.pICMSST = valor;
                    break;
                case "vICMSST": drICMS10.vICMSST = valor;
                    break;
            }
            drICMS10.icmsID = ID;
        }

        private void populaDadosICMS20(string tag, string valor, string ID)
        {
            switch (tag)
            {
                case "orig": drICMS20.orig = valor;
                    break;
                case "CST": drICMS20.CST = valor;
                    break;
                case "modBC": drICMS20.modBC = valor;
                    break;
                case "pRedBC": drICMS20.pRedBC = valor;
                    break;
                case "vBC": drICMS20.vBC = valor;
                    break;
                case "pICMS": drICMS20.pICMS = valor;
                    break;
                case "vICMS": drICMS20.vICMS = valor;
                    break;
            }
            drICMS20.icmsID = ID;
        }

        private void populaDadosICMS30(string tag, string valor, string ID)
        {
            switch (tag)
            {
                case "orig": drICMS30.orig = valor;
                    break;
                case "CST": drICMS30.CST = valor;
                    break;
                case "modBCST": drICMS30.modBCST = valor;
                    break;
                case "pMVAST": drICMS30.pMVAST = valor;
                    break;
                case "pRedBCST": drICMS30.pRedBCST = valor;
                    break;
                case "vBCST": drICMS30.vBCST = valor;
                    break;
                case "pICMSST": drICMS30.pICMSST = valor;
                    break;
                case "vICMSST": drICMS30.vICMSST = valor;
                    break;
            }
            drICMS30.icmsID = ID;
        }

        private void populaDadosICMS40(string tag, string valor, string ID)
        {
            switch (tag)
            {
                case "orig": drICMS40.orig = valor;
                    break;
                case "CST": drICMS40.CST = valor;
                    break;
            }
            drICMS40.icmsID = ID;
        }

        private void populaDadosICMS51(string tag, string valor, string ID)
        {
            switch (tag)
            {
                case "orig": drICMS51.orig = valor;
                    break;
                case "CST": drICMS51.CST = valor;
                    break;
                case "modBC": drICMS51.modBC = valor;
                    break;
                case "pRedBC": drICMS51.pRedBC = valor;
                    break;
                case "vBC": drICMS51.vBC = valor;
                    break;
                case "pICMS": drICMS51.pICMS = valor;
                    break;
                case "vICMS": drICMS51.vICMS = valor;
                    break;
            }
            drICMS51.icmsID = ID;
        }

        private void populaDadosICMS60(string tag, string valor, string ID)
        {
            switch (tag)
            {
                case "orig": drICMS60.orig = valor;
                    break;
                case "CST": drICMS60.CST = valor;
                    break;
                case "vBCSTRet": drICMS60.vBCST = valor; // NFe_2.0 - Alterado o nm Campo
                    break;
                case "vICMSSTRet": drICMS60.vICMSST = valor; // Nfe_2.0 - Alterado o nm Campo
                    break;
            }
            drICMS60.icmsID = ID;
        }

        private void populaDadosICMS70(string tag, string valor, string ID)
        {
            switch (tag)
            {
                case "orig": drICMS70.orig = valor;
                    break;
                case "CST": drICMS70.CST = valor;
                    break;
                case "modBC": drICMS70.modBC = valor;
                    break;
                case "pRedBC": drICMS70.pRedBC = valor;
                    break;
                case "vBC": drICMS70.vBC = valor;
                    break;
                case "pICMS": drICMS70.pICMS = valor;
                    break;
                case "vICMS": drICMS70.vICMS = valor;
                    break;
                case "modBCST": drICMS70.modBCST = valor;
                    break;
                case "pMVAST": drICMS70.pMVAST = valor;
                    break;
                case "pRedBCST": drICMS70.pRedBCST = valor;
                    break;
                case "vBCST": drICMS70.vBCST = valor;
                    break;
                case "pICMSST": drICMS70.pICMSST = valor;
                    break;
                case "vICMSST": drICMS70.vICMSST = valor;
                    break;
            }
            drICMS70.icmsID = ID;
        }

        private void populaDadosICMS90(string tag, string valor, string ID)
        {
            switch (tag)
            {
                case "orig": drICMS90.orig = valor;
                    break;
                case "CST": drICMS90.CST = valor;
                    break;
                case "modBC": drICMS90.modBC = valor;
                    break;
                case "vBC": drICMS90.vBC = valor;
                    break;
                case "pRedBC": drICMS90.pRedBC = valor;
                    break;
                case "pICMS": drICMS90.pICMS = valor;
                    break;
                case "vICMS": drICMS90.vICMS = valor;
                    break;
                case "modBCST": drICMS90.modBCST = valor;
                    break;
                case "pMVAST": drICMS90.pMVAST = valor;
                    break;
                case "pRedBCST": drICMS90.pRedBCST = valor;
                    break;
                case "vBCST": drICMS90.vBCST = valor;
                    break;
                case "pICMSST": drICMS90.pICMSST = valor;
                    break;
                case "vICMSST": drICMS90.vICMSST = valor;
                    break;
            }
            drICMS90.icmsID = ID; //Claudinei - o.s. sem - 24/02/2010
        }

        private void populaDadosICMSPart(string tag, string valor, string ID)
        {
            switch (tag)
            {
                case "orig": drICMS90.orig = valor;
                    break;
                case "CST": drICMS90.CST = valor;
                    break;
                case "modBC": drICMS90.modBC = valor;
                    break;
                case "vBC": drICMS90.vBC = valor;
                    break;
                case "pRedBC": drICMS90.pRedBC = valor;
                    break;
                case "pICMS": drICMS90.pICMS = valor;
                    break;
                case "vICMS": drICMS90.vICMS = valor;
                    break;
                case "modBCST": drICMS90.modBCST = valor;
                    break;
                case "pMVAST": drICMS90.pMVAST = valor;
                    break;
                case "pRedBCST": drICMS90.pRedBCST = valor;
                    break;
                case "vBCST": drICMS90.vBCST = valor;
                    break;
                case "pICMSST": drICMS90.pICMSST = valor;
                    break;
                case "vICMSST": drICMS90.vICMSST = valor;
                    break;
            }
            drICMS90.icmsID = ID; //Claudinei - o.s. sem - 24/02/2010
        }

        private void populaDadosICMSST(string tag, string valor, string ID)
        {
            switch (tag)
            {
                case "orig": drICMS90.orig = valor;
                    break;
                case "CST": drICMS90.CST = valor;
                    break;
                case "modBC": drICMS90.modBC = valor;
                    break;
                case "vBC": drICMS90.vBC = valor;
                    break;
                case "pRedBC": drICMS90.pRedBC = valor;
                    break;
                case "pICMS": drICMS90.pICMS = valor;
                    break;
                case "vICMS": drICMS90.vICMS = valor;
                    break;
                case "modBCST": drICMS90.modBCST = valor;
                    break;
                case "pMVAST": drICMS90.pMVAST = valor;
                    break;
                case "pRedBCST": drICMS90.pRedBCST = valor;
                    break;
                case "vBCST": drICMS90.vBCST = valor;
                    break;
                case "pICMSST": drICMS90.pICMSST = valor;
                    break;
                case "vICMSST": drICMS90.vICMSST = valor;
                    break;
            }
            drICMS90.icmsID = ID; //Claudinei - o.s. sem - 24/02/2010
        }
        private void populaDadosICMSSN101(string tag, string valor, string ID)
        {
            switch (tag)
            {
                case "orig": drICMSSN101.Orig = valor;
                    break;
                case "CSOSN": drICMSSN101.CSOSN = valor;
                    break;
                case "pCredSN": drICMSSN101.pCredSN = valor;
                    break;
                case "vCredICMSSN": drICMSSN101.vCredICMSSN = valor;
                    break;
            }
            drICMSSN101.icmsID = ID;
        }
        private void populaDadosICMSSN102(string tag, string valor, string ID)
        {
            switch (tag)
            {
                case "orig": drICMSSN102.Orig = valor;
                    break;
                case "CSOSN": drICMSSN102.CSOSN = valor;
                    break;
            }
            drICMSSN102.icmsID = ID;
        }
        private void populaDadosICMSSN201(string tag, string valor, string ID)
        {
            switch (tag)
            {
                case "orig": drICMSSN201.Orig = valor;
                    break;
                case "CSOSN": drICMSSN201.CSOSN = valor;
                    break;
                case "modBCST": drICMSSN201.modBCST = valor;
                    break;
                case "pMVAST": drICMSSN201.pMVAST = valor;
                    break;
                case "pRedBCST": drICMSSN201.pRedBCST = valor;
                    break;
                case "vBCST": drICMSSN201.vBCST = valor;
                    break;
                case "pICMSST": drICMSSN201.pICMSST = valor;
                    break;
                case "vICMSST": drICMSSN201.vICMSST = valor;
                    break;
                case "pCredSN": drICMSSN201.pCredSN = valor;
                    break;
                case "vCredICMSSN": drICMSSN201.vCredICMSSN = valor;
                    break;
            }
            drICMSSN201.icmsID = ID;
        }
        private void populaDadosICMSSN500(string tag, string valor, string ID)
        {
            switch (tag)
            {
                case "orig": drICMSSN500.Orig = valor;
                    break;
                case "CSOSN": drICMSSN500.CSOSN = valor;
                    break;
                case "vBCSTRet": drICMSSN500.vBCSTRet = valor;
                    break;
                case "vICMSSTRet": drICMSSN500.vICMSSTRet = valor;
                    break;
            }
            drICMSSN500.icmsID = ID;
        }
        private void populaDadosICMSSN900(string tag, string valor, string ID)
        {
            switch (tag)
            {
                case "orig": drICMSSN900.Orig = valor;
                    break;
                case "CSOSN": drICMSSN900.CSOSN = valor;
                    break;
                case "modBC": drICMSSN900.modBC = valor;
                    break;
                case "vBC": drICMSSN900.vBC = valor;
                    break;
                case "pRedBC": drICMSSN900.pRedBC = valor;
                    break;
                case "pICMS": drICMSSN900.pICMS = valor;
                    break;
                case "vICMS": drICMSSN900.vICMS = valor;
                    break;
                case "modBCST": drICMSSN900.modBCST = valor;
                    break;
                case "pMVAST": drICMSSN900.pMVAST = valor;
                    break;
                case "pRedBCST": drICMSSN900.pRedBCST = valor;
                    break;
                case "vBCST": drICMSSN900.vBCST = valor;
                    break;
                case "pICMSST": drICMSSN900.pICMSST = valor;
                    break;
                case "vICMSST": drICMSSN900.vICMSST = valor;
                    break;
                case "vBCSTRet": drICMSSN900.vBCSTRet = valor;
                    break;
            }
            drICMSSN900.icmsID = ID;
        }


        private void populaDadosIPI(string tag, string valor, int impostoID, string ipiID)
        {
            switch (tag)
            {
                case "clEnq": drIPI.clEnq = valor;
                    break;
                case "CNPJProd": drIPI.CNPJProd = valor;
                    break;
                case "cSelo": drIPI.cSelo = valor;
                    break;
                case "qSelo": drIPI.qSelo = valor;
                    break;
                case "cEnq": drIPI.cEnq = valor;
                    break;
            }
            drIPI.impostoID = impostoID.ToString();
            drIPI.ipiID = ipiID;
        }

        private void populaDadosIPItrib(string tag, string valor, string ipiID)
        {
            switch (tag)
            {
                case "CST": drIPItrib.CST = valor;
                    break;
                case "vBC": drIPItrib.vBC = valor;
                    break;
                case "qUnid": drIPItrib.qUnid = valor;
                    break;
                case "vUnid": drIPItrib.vUnid = valor;
                    break;
                case "pIPI": drIPItrib.pIPI = valor;
                    break;
                case "vIPI": drIPItrib.vIPI = valor;
                    break;
            }
            drIPItrib.ipiID = ipiID;
        }

        private void populaDadosIPInt(string tag, string valor, string ipiID)
        {
            switch (tag)
            {
                case "CST": drIPInt.CST = valor;
                    break;
            }
            drIPInt.ipiID = ipiID;
        }

        private void populaDadosII(string tag, string valor, string impostoID)
        {
            switch (tag)
            {
                case "vBC": drII.vBC = valor;
                    break;
                case "vDespAdu": drII.vDespAdu = valor;
                    break;
                case "vII": drII.vII = valor;
                    break;
                case "vIOF": drII.vIOF = valor;
                    break;
            }
            drII.impostoID = impostoID;
        }

        private void populaDadosPisAliq(string tag, string valor, string pisID)
        {
            switch (tag)
            {
                case "CST": drPisAliq.CST = valor;
                    break;
                case "vBC": drPisAliq.vBC = valor;
                    break;
                case "pPIS": drPisAliq.pPIS = valor;
                    break;
                case "vPIS": drPisAliq.vPIS = valor;
                    break;
            }
            drPisAliq.pisID = pisID;
        }

        private void populaDadosPisQtde(string tag, string valor, string pisID)
        {
            switch (tag)
            {
                case "CST": drPisQtde.CST = valor;
                    break;
                case "qBCProd": drPisQtde.qBCProd = valor;
                    break;
                case "vAliqProd": drPisQtde.vAliqProd = valor;
                    break;
                case "vPIS": drPisQtde.vPIS = valor;
                    break;
            }
            drPisQtde.pisID = pisID;
        }

        private void populaDadosPisNT(string tag, string valor, string pisID)
        {
            switch (tag)
            {
                case "CST": drPisNT.CST = valor;
                    break;
            }
            drPisNT.pisID = pisID;
        }

        private void populaDadosPisOut(string tag, string valor, string pisID)
        {
            switch (tag)
            {
                case "CST": drPisOutr.CST = valor;
                    break;
                case "vBC": drPisOutr.vBC = valor;
                    break;
                case "pPIS": drPisOutr.pPIS = valor;
                    break;
                case "qBCProd": drPisOutr.qBCProd = valor;
                    break;
                case "vAliqProd": drPisOutr.vAliqProd = valor;
                    break;
                case "vPIS": drPisOutr.vPIS = valor;
                    break;
            }
            drPisOutr.pisID = pisID;
        }

        private void populaDadosPisST(string tag, string valor, string impostoID)
        {
            switch (tag)
            {
                case "vBC": drPisST.vBC = valor;
                    break;
                case "pPIS": drPisST.pPIS = valor;
                    break;
                case "qBCProd": drPisST.qBCProd = valor;
                    break;
                case "vAliqProd": drPisST.vAliqProd = valor;
                    break;
                case "vPIS": drPisST.vPIS = valor;
                    break;

            }
            drPisST.impostoID = impostoID;
        }

        private void populaDadosCofinsAliq(string tag, string valor, string cofinsID)
        {
            switch (tag)
            {
                case "CST": drCofinsAliq.CST = valor;
                    break;
                case "vBC": drCofinsAliq.vBC = valor;
                    break;
                case "pCOFINS": drCofinsAliq.pCOFINS = valor;
                    break;
                case "vCOFINS": drCofinsAliq.vCOFINS = valor;
                    break;

            }
            drCofinsAliq.cofinsID = cofinsID;
        }

        private void populaDadosCofinsQtde(string tag, string valor, string cofinsID)
        {
            switch (tag)
            {
                case "CST": drCofinsQtde.CST = valor;
                    break;
                case "qBCProd": drCofinsQtde.qBCProd = valor;
                    break;
                case "vAliqProd": drCofinsQtde.vAliqProd = valor;
                    break;
                case "vCOFINS": drCofinsQtde.vCOFINS = valor;
                    break;


            }
            drCofinsQtde.cofinsID = cofinsID;
        }

        private void populaDadosCofinsNT(string tag, string valor, string cofinsID)
        {
            switch (tag)
            {
                case "CST": drCofinsNT.CST = valor;
                    break;
            }
            drCofinsNT.cofinsID = cofinsID;
        }

        private void populaDadosCofinsOutr(string tag, string valor, string cofinsID)
        {
            switch (tag)
            {
                case "CST": drCofinsOutr.CST = valor;
                    break;
                case "vBC": drCofinsOutr.vBC = valor;
                    break;
                case "pCOFINS": drCofinsOutr.pCOFINS = valor;
                    break;
                case "qBCProd": drCofinsOutr.qBCProd = valor;
                    break;
                case "vAliqProd": drCofinsOutr.vAliqProd = valor;
                    break;
                case "vCOFINS": drCofinsOutr.vCOFINS = valor;
                    break;

            }
            drCofinsOutr.cofinsID = cofinsID;
        }

        private void populaDadosCofinsST(string tag, string valor, string impostoID)
        {
            switch (tag)
            {
                case "vBC": drCofinsST.vBC = valor;
                    break;
                case "pCOFINS": drCofinsST.pCOFINS = valor;
                    break;
                case "qBCProd": drCofinsST.qBCProd = valor;
                    break;
                case "vAliqProd": drCofinsST.vAliqProd = valor;
                    break;
                case "vCOFINS": drCofinsST.vCOFINS = valor;
                    break;

            }
            drCofinsST.impostoID = impostoID;
        }


        private void populaDadosISSQN(string tag, string valor, string impostoID)
        {
            switch (tag)
            {
                case "vBC": drISSQN.vBC = valor;
                    break;
                case "vAliq": drISSQN.vAliq = valor;
                    break;
                case "vISSQN": drISSQN.vISSQN = valor;
                    break;
                case "cMunFG": drISSQN.cMunFG = valor;
                    break;
                case "cListServ": drISSQN.cListServ = valor;
                    break;

            }
            drISSQN.impostoID = impostoID;
        }

        private void populaDadosInfAdProd(string valor, string detId)
        {
            drInfAdProd.detId = detId;
            drInfAdProd.infAdProd = valor;
        }




        #endregion

        #region Popula TAG Total

        public void populaTagTotal(dsDanfe dsdanfe, XmlDocument xml, string CodinfNfeId)
        {
            XmlNodeList xndtotal = xml.GetElementsByTagName("total");
            XmlNodeList xndICMStot = xml.GetElementsByTagName("ICMSTot");
            XmlNodeList xndISSQNtot = xml.GetElementsByTagName("ISSQNtot");
            XmlNodeList xndretTrib = xml.GetElementsByTagName("retTrib");

            drTotal = dsdanfe.total.NewtotalRow();
            drICMStot = dsdanfe.ICMSTot.NewICMSTotRow();
            drISSQNtot = dsdanfe.ISSQNtot.NewISSQNtotRow();
            drRetTrib = dsdanfe.retTrib.NewretTribRow();

            if (xndtotal.Count > 0)
            {
                int i = 0;
                while (i < xndtotal.Count)
                {
                    drTotal = dsdanfe.total.NewtotalRow();
                    populaDadosTotal(CodinfNfeId);
                    dsdanfe.total.AddtotalRow(drTotal);
                    i++;
                }
            }

            if (xndICMStot.Count > 0)
            {
                for (int i = 0; i < xndICMStot.Count; i++)
                {
                    int totalID = dsdanfe.total.Count;
                    // qtde de nodes 
                    for (int j = 0; j < xndICMStot[i].ChildNodes.Count; j++)
                    {
                        populaDadosICMStot(xndICMStot[i].ChildNodes[j].LocalName, xndICMStot[i].ChildNodes[j].InnerText, totalID.ToString());
                    }
                    dsdanfe.ICMSTot.AddICMSTotRow(drICMStot);
                    drICMStot = dsdanfe.ICMSTot.NewICMSTotRow();
                }
            }

            if (xndISSQNtot.Count > 0)
            {
                for (int i = 0; i < xndISSQNtot.Count; i++)
                {
                    int totalID = dsdanfe.total.Count;
                    // qtde de nodes 
                    for (int j = 0; j < xndISSQNtot[i].ChildNodes.Count; j++)
                    {
                        populaDadosISSQNtot(xndISSQNtot[i].ChildNodes[j].LocalName, xndISSQNtot[i].ChildNodes[j].InnerText, totalID.ToString());
                    }
                    dsdanfe.ISSQNtot.AddISSQNtotRow(drISSQNtot);
                    drISSQNtot = dsdanfe.ISSQNtot.NewISSQNtotRow();
                }
            }



            if (xndretTrib.Count > 0)
            {
                for (int i = 0; i < xndretTrib.Count; i++)
                {
                    int totalID = dsdanfe.total.Count;
                    // qtde de nodes 
                    for (int j = 0; j < xndretTrib[i].ChildNodes.Count; j++)
                    {
                        populaDadosretTrib(xndretTrib[i].ChildNodes[j].LocalName, xndretTrib[i].ChildNodes[j].InnerText, totalID.ToString());
                    }
                    dsdanfe.retTrib.AddretTribRow(drRetTrib);
                    drRetTrib = dsdanfe.retTrib.NewretTribRow();
                }
            }
        }

        private void populaDadosTotal(string CodinfNfeId)
        {
            drTotal.InfNFeId = CodinfNfeId;
            drTotal.totalID = CodinfNfeId;
        }

        private void populaDadosICMStot(string tag, string valor, string totalID)
        {
            switch (tag)
            {
                case "vBC": drICMStot.vBC = double.Parse(valor.Replace('.', ','));
                    break;
                case "vICMS": drICMStot.vICMS = double.Parse(valor.Replace('.', ','));
                    break;
                case "vBCST": drICMStot.vBCST = double.Parse(valor.Replace('.', ','));
                    break;
                case "vST": drICMStot.vST = double.Parse(valor.Replace('.', ','));
                    break;
                case "vProd": drICMStot.vProd = double.Parse(valor.Replace('.', ','));
                    break;
                case "vFrete": drICMStot.vFrete = double.Parse(valor.Replace('.', ','));
                    break;
                case "vSeg": drICMStot.vSeg = double.Parse(valor.Replace('.', ','));
                    break;
                case "vDesc": drICMStot.vDesc = double.Parse(valor.Replace('.', ','));
                    break;
                case "vII": drICMStot.vII = double.Parse(valor.Replace('.', ','));
                    break;
                case "vIPI": drICMStot.vIPI = double.Parse(valor.Replace('.', ','));
                    break;
                case "vPIS": drICMStot.vPIS = double.Parse(valor.Replace('.', ','));
                    break;
                case "vCOFINS": drICMStot.vCOFINS = double.Parse(valor.Replace('.', ','));
                    break;
                case "vOutro": drICMStot.vOutro = double.Parse(valor.Replace('.', ','));
                    break;
                case "vNF": drICMStot.vNF = double.Parse(valor.Replace('.', ','));
                    break;
            }
            drICMStot.totalID = totalID;
        }

        private void populaDadosISSQNtot(string tag, string valor, string totalID)
        {
            switch (tag)
            {
                case "vServ": drISSQNtot.vServ = valor;
                    break;
                case "vBC": drISSQNtot.vBC = valor;
                    break;
                case "vISS": drISSQNtot.vISS = valor;
                    break;
                case "vPIS": drISSQNtot.vPIS = valor;
                    break;
                case "vCOFINS": drISSQNtot.vCOFINS = valor;
                    break;

            }
            drISSQNtot.totalID = totalID;
        }

        private void populaDadosretTrib(string tag, string valor, string totalID)
        {
            switch (tag)
            {
                case "vRetPIS": drRetTrib.vRetPIS = valor;
                    break;
                case "vRetCOFINS": drRetTrib.vRetCOFINS = valor;
                    break;
                case "vRetCSLL": drRetTrib.vRetCSLL = valor;
                    break;
                case "vBCIRRF": drRetTrib.vBCIRRF = valor;
                    break;
                case "vIRRF": drRetTrib.vIRRF = valor;
                    break;
                case "vBCRetPrev": drRetTrib.vBCRetPrev = valor;
                    break;
                case "vRetPrev": drRetTrib.vRetPrev = valor;
                    break;
            }
            drRetTrib.totalID = totalID;
        }

        #endregion

        #region Popula TAG Transp

        public void PopulaTagTransp(dsDanfe dsdanfe, XmlDocument xml, string CodinfNfeId)
        {

            XmlNodeList xndTransp = xml.GetElementsByTagName("transp");
            XmlNodeList xndTransportadora = xml.GetElementsByTagName("transporta");
            XmlNodeList xndRetTransp = xml.GetElementsByTagName("retTransp");
            XmlNodeList xndVeicTransp = xml.GetElementsByTagName("veicTransp");
            XmlNodeList xndReboque = xml.GetElementsByTagName("reboque ");
            XmlNodeList xndVol = xml.GetElementsByTagName("vol");
            XmlNodeList xndLacres = xml.GetElementsByTagName("lacres");

            drTransp = dsdanfe.transp.NewtranspRow();
            drTransportadora = dsdanfe.transporta.NewtransportaRow();
            drRetTransp = dsdanfe.retTransp.NewretTranspRow();
            drVeicTransp = dsdanfe.veicTransp.NewveicTranspRow();
            drReboque = dsdanfe.reboque.NewreboqueRow();
            drVol = dsdanfe.vol.NewvolRow();
            drLacres = dsdanfe.lacres.NewlacresRow();



            if (xndTransp.Count > 0)
            {
                for (int i = 0; i < xndTransp.Count; i++)
                {
                    int transpID = 0;

                    if (dsdanfe.transp.Count > 0)
                    {
                        transpID = dsdanfe.transp.Count + 1;
                    }
                    else
                    {
                        transpID = i + 1;
                    }


                    // qtde de nodes 
                    for (int j = 0; j < xndTransp[i].ChildNodes.Count; j++)
                    {
                        populaDadostransp(xndTransp[i].ChildNodes[j].LocalName, xndTransp[i].ChildNodes[j].InnerText, transpID.ToString(), CodinfNfeId);
                    }
                    dsdanfe.transp.AddtranspRow(drTransp);
                    drTransp = dsdanfe.transp.NewtranspRow();
                }
            }

            if (xndTransportadora.Count > 0)
            {
                for (int i = 0; i < xndTransportadora.Count; i++)
                {
                    int transpID = dsdanfe.transp.Count;
                    // qtde de nodes 
                    for (int j = 0; j < xndTransportadora[i].ChildNodes.Count; j++)
                    {
                        populaDadosTransportadora(xndTransportadora[i].ChildNodes[j].LocalName, xndTransportadora[i].ChildNodes[j].InnerText, transpID.ToString());
                    }
                    dsdanfe.transporta.AddtransportaRow(drTransportadora);
                    drTransportadora = dsdanfe.transporta.NewtransportaRow();
                }
            }

            if (xndRetTransp.Count > 0)
            {
                for (int i = 0; i < xndRetTransp.Count; i++)
                {
                    int transpID = i + 1;
                    // qtde de nodes 
                    for (int j = 0; j < xndRetTransp[i].ChildNodes.Count; j++)
                    {
                        populaDadosretTransp(xndRetTransp[i].ChildNodes[j].LocalName, xndRetTransp[i].ChildNodes[j].InnerText, transpID.ToString());
                    }
                    dsdanfe.retTransp.AddretTranspRow(drRetTransp);
                    drRetTransp = dsdanfe.retTransp.NewretTranspRow();
                }
            }

            if (xndVeicTransp.Count > 0)
            {
                for (int i = 0; i < xndVeicTransp.Count; i++)
                {
                    int transpID = i + 1;
                    // qtde de nodes 
                    for (int j = 0; j < xndVeicTransp[i].ChildNodes.Count; j++)
                    {
                        populaDadosVeicTransp(xndVeicTransp[i].ChildNodes[j].LocalName, xndVeicTransp[i].ChildNodes[j].InnerText, transpID.ToString());
                    }
                    dsdanfe.veicTransp.AddveicTranspRow(drVeicTransp);
                    drVeicTransp = dsdanfe.veicTransp.NewveicTranspRow();
                }
            }

            if (xndReboque.Count > 0)
            {
                for (int i = 0; i < xndReboque.Count; i++)
                {
                    int transpID = i + 1;
                    // qtde de nodes 
                    for (int j = 0; j < xndReboque[i].ChildNodes.Count; j++)
                    {
                        populaDadosReboque(xndReboque[i].ChildNodes[j].LocalName, xndReboque[i].ChildNodes[j].InnerText, transpID.ToString());
                    }
                    dsdanfe.reboque.AddreboqueRow(drReboque);
                    drReboque = dsdanfe.reboque.NewreboqueRow();
                }
            }

            if (xndVol.Count > 0)
            {
                for (int i = 0; i < xndVol.Count; i++)
                {
                    int transpID = dsdanfe.transp.Count;
                    int volID = 0;
                    if (dsdanfe.vol.Count > 0)
                    {
                        volID = dsdanfe.vol.Count + 1;
                    }
                    else
                    {
                        volID = i + 1;
                    }

                    // qtde de nodes 
                    for (int j = 0; j < xndVol[i].ChildNodes.Count; j++)
                    {
                        populaDadosVol(xndVol[i].ChildNodes[j].LocalName, xndVol[i].ChildNodes[j].InnerText, transpID.ToString(), volID.ToString());
                    }
                    dsdanfe.vol.AddvolRow(drVol);
                    drVol = dsdanfe.vol.NewvolRow();
                }
            }
            if (xndLacres.Count > 0)
            {
                for (int i = 0; i < xndLacres.Count; i++)
                {
                    int volID = i + 1;
                    // qtde de nodes 
                    for (int j = 0; j < xndLacres[i].ChildNodes.Count; j++)
                    {
                        populaDadosLacres(xndLacres[i].ChildNodes[j].LocalName, xndLacres[i].ChildNodes[j].InnerText, volID.ToString());
                    }
                    dsdanfe.lacres.AddlacresRow(drLacres);
                    drLacres = dsdanfe.lacres.NewlacresRow();
                }
            }
        }


        private void populaDadostransp(string tag, string valor, string transpID, string CodinfNfeId)
        {
            switch (tag)
            {
                case "modFrete": drTransp.modFrete = valor;
                    break;
            }
            drTransp.transpID = CodinfNfeId;
            drTransp.InfNFeId = transpID;
        }

        private void populaDadosTransportadora(string tag, string valor, string transpID)
        {
            switch (tag)
            {
                case "CNPJ": drTransportadora.CNPJ = valor;
                    break;
                case "CPF": drTransportadora.CPF = valor;
                    break;
                case "xNome": drTransportadora.xNome = valor;
                    break;
                case "IE": drTransportadora.IE = valor;
                    break;
                case "xEnder": drTransportadora.xEnder = valor;
                    break;
                case "xMun": drTransportadora.xMun = valor;
                    break;
                case "UF": drTransportadora.UF = valor;
                    break;
            }
            drTransportadora.transpID = transpID;
        }

        private void populaDadosretTransp(string tag, string valor, string transpID)
        {
            switch (tag)
            {
                case "vServ": drRetTransp.vServ = valor;
                    break;
                case "vBCRet": drRetTransp.vBCRet = valor;
                    break;
                case "pICMSRet": drRetTransp.pICMSRet = valor;
                    break;
                case "vICMSRet": drRetTransp.vICMSRet = valor;
                    break;
                case "CFOP": drRetTransp.CFOP = valor;
                    break;
                case "cMunFG": drRetTransp.cMunFG = valor;
                    break;
            }
            drRetTransp.transpID = transpID;
        }

        private void populaDadosVeicTransp(string tag, string valor, string transpID)
        {
            switch (tag)
            {
                case "placa": drVeicTransp.placa = valor;
                    break;
                case "UF": drVeicTransp.UF = valor;
                    break;
                case "RNTC": drVeicTransp.RNTC = valor;
                    break;

            }
            drVeicTransp.transpID = transpID;
        }

        private void populaDadosReboque(string tag, string valor, string transpID)
        {
            switch (tag)
            {
                case "placa": drReboque.placa = valor;
                    break;
                case "UF": drReboque.UF = valor;
                    break;
                case "RNTC": drReboque.RNTC = valor;
                    break;

            }
            drReboque.transpID = transpID;
        }

        private void populaDadosVol(string tag, string valor, string volID, string transpID)
        {
            switch (tag)
            {
                case "qVol": drVol.qVol = valor;
                    break;
                case "esp": drVol.esp = valor;
                    break;
                case "marca": drVol.marca = valor;
                    break;
                case "nVol": drVol.nVol = valor;
                    break;
                case "pesoL": drVol.pesoL = double.Parse(valor.Replace('.', ','));
                    break;
                case "pesoB": drVol.pesoB = double.Parse(valor.Replace('.', ','));
                    break;
            }
            drVol.transpID = transpID;
            drVol.volID = volID;
        }

        private void populaDadosLacres(string tag, string valor, string volID)
        {
            switch (tag)
            {
                case "nLacre": drLacres.nLacre = valor;
                    break;
            }
            drLacres.volID = volID;
        }

        #endregion

        #region Popula TAG Cobr


        public void PopulaTagCobr(dsDanfe dsdanfe, XmlDocument xml, string CodinfNfeId)
        {

            XmlNodeList xndCobr = xml.GetElementsByTagName("cobr");
            XmlNodeList xndFat = xml.GetElementsByTagName("fat");
            XmlNodeList xndDup = xml.GetElementsByTagName("dup");

            drCobr = dsdanfe.cobr.NewcobrRow();
            drFat = dsdanfe.fat.NewfatRow();
            drDup = dsdanfe.dup.NewdupRow();

            if (xndCobr.Count > 0) // POPULA TABLE COBR
            {
                int i = 0;
                int cobr = 0;
                while (i < xndCobr.Count)
                {
                    if (dsdanfe.cobr.Count > 0)
                    {
                        cobr = dsdanfe.cobr.Count + 1;
                    }
                    else
                    {
                        cobr = i + 1;
                    }
                    drCobr = dsdanfe.cobr.NewcobrRow();
                    populaDadosCobr(cobr.ToString(), CodinfNfeId);
                    dsdanfe.cobr.AddcobrRow(drCobr);

                    i++;
                }
            }

            if (xndFat.Count > 0)
            {
                for (int i = 0; i < xndFat.Count; i++)
                {
                    int cobrID = dsdanfe.cobr.Count;
                    // qtde de nodes 
                    for (int j = 0; j < xndFat[i].ChildNodes.Count; j++)
                    {
                        populaDadosFat(xndFat[i].ChildNodes[j].LocalName, xndFat[i].ChildNodes[j].InnerText, cobrID.ToString());
                    }
                    dsdanfe.fat.AddfatRow(drFat);
                    drFat = dsdanfe.fat.NewfatRow();
                }
            }

            if (xndDup.Count > 0)
            {
                for (int i = 0; i < xndDup.Count; i++)
                {
                    int cobrID = dsdanfe.cobr.Count;
                    // qtde de nodes 
                    for (int j = 0; j < xndDup[i].ChildNodes.Count; j++)
                    {
                        populaDadosDup(xndDup[i].ChildNodes[j].LocalName, xndDup[i].ChildNodes[j].InnerText, cobrID.ToString());
                    }
                    dsdanfe.dup.AdddupRow(drDup);
                    drDup = dsdanfe.dup.NewdupRow();
                }
            }
        }


        private void populaDadosCobr(string ID, string CodinfNfeId)
        {
            drCobr.cobrID = ID;
            drCobr.InfNFeId = CodinfNfeId;
        }

        private void populaDadosFat(string tag, string valor, string cobrID)
        {
            switch (tag)
            {
                case "nFat": drFat.nFat = valor;
                    break;
                case "vOrig": drFat.vOrig = valor;
                    break;
                case "vDesc": drFat.vDesc = valor;
                    break;
                case "vLiq": drFat.vLiq = valor;
                    break;

            }
            drFat.cobrID = cobrID;
        }

        private void populaDadosDup(string tag, string valor, string cobrID)
        {
            drDup.vDup = "";
            switch (tag)
            {
                case "nDup": drDup.nDup = valor;
                    break;
                case "dVenc": drDup.dVenc = valor;
                    break;
                case "vDup": drDup.vDup = valor;
                    break;

            }
            drDup.cobrID = cobrID;
        }


        #endregion

        #region Popula TAG InfAdic

        public void PopulaTagInfAdic(dsDanfe dsdanfe, XmlDocument xml, string CodinfNfeId)
        {

            XmlNodeList xndInfAdic = xml.GetElementsByTagName("infAdic");
            XmlNodeList xndObsCont = xml.GetElementsByTagName("obsCont");
            XmlNodeList xndObsFisco = xml.GetElementsByTagName("obsFisco");
            XmlNodeList xndprocRef = xml.GetElementsByTagName("procRef");

            drInfAdic = dsdanfe.infAdic.NewinfAdicRow();
            drObsCont = dsdanfe.obsCont.NewobsContRow();
            drFat = dsdanfe.fat.NewfatRow();
            drDup = dsdanfe.dup.NewdupRow();

            if (xndInfAdic.Count > 0)
            {
                for (int i = 0; i < xndInfAdic.Count; i++)
                {
                    int infNFe = dsdanfe.infAdic.Count;
                    int infAdicID = 0;
                    if (dsdanfe.infAdic.Count > 0)
                    {
                        infAdicID = dsdanfe.infAdic.Count + 1;
                    }
                    else
                    {
                        infAdicID = i + 1;
                    }

                    // qtde de nodes 
                    for (int j = 0; j < xndInfAdic[i].ChildNodes.Count; j++)
                    {
                        populaDadosInfAdic(xndInfAdic[i].ChildNodes[j].LocalName, xndInfAdic[i].ChildNodes[j].InnerText, infAdicID.ToString(), CodinfNfeId);
                    }
                    if (xndInfAdic[i].ChildNodes.Count > 0)
                    {
                        dsdanfe.infAdic.AddinfAdicRow(drInfAdic);
                        drInfAdic = dsdanfe.infAdic.NewinfAdicRow();
                    }

                }
            }

            if (xndObsCont.Count > 0)
            {
                for (int i = 0; i < xndObsCont.Count; i++)
                {
                    int infAdicID = i + 1;
                    // qtde de nodes 
                    for (int j = 0; j < xndObsCont[i].ChildNodes.Count; j++)
                    {
                        populaDadosObsCont(xndObsCont[i].ChildNodes[j].LocalName, xndObsCont[i].ChildNodes[j].InnerText, infAdicID.ToString());
                    }
                    dsdanfe.obsCont.AddobsContRow(drObsCont);
                    drObsCont = dsdanfe.obsCont.NewobsContRow();
                }
            }


            if (xndObsFisco.Count > 0)
            {
                for (int i = 0; i < xndObsFisco.Count; i++)
                {
                    int infAdicID = i + 1;
                    // qtde de nodes 
                    for (int j = 0; j < xndObsFisco[i].ChildNodes.Count; j++)
                    {
                        populaDadosObsFisco(xndObsFisco[i].ChildNodes[j].LocalName, xndObsFisco[i].ChildNodes[j].InnerText, infAdicID.ToString());
                    }
                    dsdanfe.obsFisco.AddobsFiscoRow(drObsFisco);
                    drObsFisco = dsdanfe.obsFisco.NewobsFiscoRow();
                }
            }

            if (xndprocRef.Count > 0)
            {
                for (int i = 0; i < xndprocRef.Count; i++)
                {
                    int infAdicID = i + 1;
                    // qtde de nodes 
                    for (int j = 0; j < xndprocRef[i].ChildNodes.Count; j++)
                    {
                        populaDadosProcRef(xndprocRef[i].ChildNodes[j].LocalName, xndprocRef[i].ChildNodes[j].InnerText, infAdicID.ToString());
                    }
                    dsdanfe.procRef.AddprocRefRow(drProcRef);
                    drProcRef = dsdanfe.procRef.NewprocRefRow();
                }
            }
        }

        private void populaDadosInfAdic(string tag, string valor, string infAdicID, string CodinfNfeId)
        {
            switch (tag)
            {
                case "infAdFisco": drInfAdic.infAdFisco = valor;
                    break;
                case "infCpl": drInfAdic.infCpl = valor;
                    break;
            }

            drInfAdic.InfNFeId = CodinfNfeId;
            drInfAdic.infAdicID = infAdicID;
        }

        private void populaDadosObsCont(string tag, string valor, string infAdicID)
        {
            switch (tag)
            {
                case "xCampo": drObsCont.xCampo = valor;
                    break;
                case "xTexto": drObsCont.xTexto = valor;
                    break;
            }
            drObsCont.infAdicID = infAdicID;
        }

        private void populaDadosObsFisco(string tag, string valor, string infAdicID)
        {
            switch (tag)
            {
                case "xCampo": drObsFisco.xCampo = valor;
                    break;
                case "xTexto": drObsFisco.xTexto = valor;
                    break;
            }
            drObsFisco.infAdicID = infAdicID;
        }

        private void populaDadosProcRef(string tag, string valor, string infAdicID)
        {
            switch (tag)
            {
                case "nProc": drProcRef.nProc = valor;
                    break;
                case "indProc": drProcRef.indProc = valor;
                    break;
            }
            drProcRef.infAdicID = infAdicID;
        }

        #endregion

        #region Popula Tag Exporta
        public void PopulaTagExporta(dsDanfe dsdanfe, XmlDocument xml, string CodinfNfeId)
        {

            XmlNodeList xNdExporta = xml.GetElementsByTagName("exporta");
            drExporta = dsdanfe.exporta.NewexportaRow();
            if (xNdExporta.Count > 0)
            {
                for (int i = 0; i < xNdExporta.Count; i++)
                {
                    int InfNFeId = i + 1;
                    // qtde de nodes 
                    for (int j = 0; j < xNdExporta[i].ChildNodes.Count; j++)
                    {
                        populaDadosExporta(xNdExporta[i].ChildNodes[j].LocalName, xNdExporta[i].ChildNodes[j].InnerText, InfNFeId.ToString(), CodinfNfeId);
                    }
                    dsdanfe.exporta.AddexportaRow(drExporta);
                    drExporta = dsdanfe.exporta.NewexportaRow();
                }
            }
        }

        private void populaDadosExporta(string tag, string valor, string InfNFeId, string CodinfNfeId)
        {
            switch (tag)
            {
                case "UFEmbarq": drExporta.UFEmbarq = valor;
                    break;
                case "xLocEmbarq": drExporta.xLocEmbarq = valor;
                    break;
            }
            drExporta.InfNFeId = CodinfNfeId;
        }
        #endregion

        #region Popula Tag Compra

        public void PopulaTagCompra(dsDanfe dsdanfe, XmlDocument xml, string CodinfNfeId)
        {

            XmlNodeList xNdCompra = xml.GetElementsByTagName("compra");

            if (xNdCompra.Count > 0)
            {
                for (int i = 0; i < xNdCompra.Count; i++)
                {
                    int InfNFeId = i + 1;
                    // qtde de nodes 
                    for (int j = 0; j < xNdCompra[i].ChildNodes.Count; j++)
                    {
                        populaDadosCompra(xNdCompra[i].ChildNodes[j].LocalName, xNdCompra[i].ChildNodes[j].InnerText, InfNFeId.ToString(), CodinfNfeId);
                    }
                    dsdanfe.compra.AddcompraRow(drCompra);
                    drCompra = dsdanfe.compra.NewcompraRow();
                }
            }
        }

        private void populaDadosCompra(string tag, string valor, string InfNFeId, string CodinfNfeId)
        {
            switch (tag)
            {
                case "xNEmp": drCompra.xNEmp = valor;
                    break;
                case "xPed": drCompra.xPed = valor;
                    break;
                case "xCont": drCompra.xCont = valor;
                    break;
            }
            drCompra.InfNFeId = CodinfNfeId;
        }

        #endregion

        #region Popula Tag Retirada

        public void PopulaTagRetirada(dsDanfe dsdanfe, XmlDocument xml, string CodinfNfeId)
        {
            XmlNodeList xNdRetirada = xml.GetElementsByTagName("retirada");

            if (xNdRetirada.Count > 0)
            {
                for (int i = 0; i < xNdRetirada.Count; i++)
                {
                    int InfNFeId = i + 1;
                    // qtde de nodes 
                    for (int j = 0; j < xNdRetirada[i].ChildNodes.Count; j++)
                    {
                        populaDadosRetirada(xNdRetirada[i].ChildNodes[j].LocalName, xNdRetirada[i].ChildNodes[j].InnerText, InfNFeId.ToString(), CodinfNfeId);
                    }
                    dsdanfe.retirada.AddretiradaRow(drRetira);
                    drRetira = dsdanfe.retirada.NewretiradaRow();
                }
            }
        }

        private void populaDadosRetirada(string tag, string valor, string InfNFeId, string CodinfNfeId)
        {
            switch (tag)
            {
                case "CNPJ": drRetira.CNPJ = valor;
                    break;
                case "xLgr": drRetira.xLgr = valor;
                    break;
                case "nro": drRetira.nro = valor;
                    break;
                case "xCpl": drRetira.xCpl = valor;
                    break;
                case "xBairro": drRetira.xBairro = valor;
                    break;
                case "cMun": drRetira.cMun = valor;
                    break;
                case "xMun": drRetira.xMun = valor;
                    break;
                case "UF": drRetira.UF = valor;
                    break;

            }
            drRetira.InfNFeId = CodinfNfeId;
        }

        #endregion

        #region Popula Tag Entrega

        public void PopulaTagEntrega(dsDanfe dsdanfe, XmlDocument xml, string CodinfNfeId)
        {
            XmlNodeList xNdEntrega = xml.GetElementsByTagName("entrega");

            if (xNdEntrega.Count > 0)
            {
                for (int i = 0; i < xNdEntrega.Count; i++)
                {
                    int InfNFeId = i + 1;
                    // qtde de nodes 
                    for (int j = 0; j < xNdEntrega[i].ChildNodes.Count; j++)
                    {
                        populaDadosEntrega(xNdEntrega[i].ChildNodes[j].LocalName, xNdEntrega[i].ChildNodes[j].InnerText, InfNFeId.ToString(), CodinfNfeId);
                    }
                    dsdanfe.entrega.AddentregaRow(drEntrega);
                    drEntrega = dsdanfe.entrega.NewentregaRow();
                }
            }
        }

        private void populaDadosEntrega(string tag, string valor, string InfNFeId, string CodinfNfeId)
        {
            switch (tag)
            {
                case "CNPJ": drEntrega.CNPJ = valor;
                    break;
                case "xLgr": drEntrega.xLgr = valor;
                    break;
                case "nro": drEntrega.nro = valor;
                    break;
                case "xCpl": drEntrega.xCpl = valor;
                    break;
                case "xBairro": drEntrega.xBairro = valor;
                    break;
                case "cMun": drEntrega.cMun = valor;
                    break;
                case "xMun": drEntrega.xMun = valor;
                    break;
                case "UF": drEntrega.UF = valor;
                    break;

            }
            drEntrega.InfNFeId = CodinfNfeId;
        }

        #endregion

        #region Popula Tag InfProd

        public void PopulaTagInfProt(dsDanfe dsdanfe, XmlDocument xml, string CodinfNfeId)
        {
            XmlNodeList xNdInfProt = xml.GetElementsByTagName("infProt");
            drInfProt = dsdanfe.infProt.NewinfProtRow();

            if (xNdInfProt.Count > 0)
            {
                for (int i = 0; i < xNdInfProt.Count; i++)
                {
                    int InfNFeId = i + 1;
                    // qtde de nodes 
                    for (int j = 0; j < xNdInfProt[i].ChildNodes.Count; j++)
                    {
                        populaDadosInfProt(xNdInfProt[i].ChildNodes[j].LocalName, xNdInfProt[i].ChildNodes[j].InnerText, InfNFeId.ToString(), CodinfNfeId);
                    }
                    dsdanfe.infProt.AddinfProtRow(drInfProt);
                    drInfProt = dsdanfe.infProt.NewinfProtRow();
                }
            }
        }

        private void populaDadosInfProt(string tag, string valor, string InfNFeId, string CodinfNfeId)
        {
            switch (tag)
            {
                case "tpAmb": drInfProt.tpAmb = valor;
                    break;
                case "verAplic": drInfProt.verAplic = valor;
                    break;
                case "chNFe": drInfProt.chNFe = valor;
                    break;
                case "dhRecbto": drInfProt.dhRecbto = valor;
                    break;
                case "nProt": drInfProt.nProt = valor;
                    break;
                case "digVal": drInfProt.digVal = valor;
                    break;
                case "cStat": drInfProt.cStat = valor;
                    break;
                case "xMotivo": drInfProt.xMotivo = valor;
                    break;
            }
            drInfProt.InfNFeId = CodinfNfeId;
        }

        #endregion

        #region Popula Imagem

        // Diego - OS_23723 - 11/06/2009
        public void PopulaImagem(dsDanfe dsdanfe, Byte[] imagem)
        {
            drLogo = dsdanfe.Logo.NewLogoRow();

            drLogo.Imagem = imagem;

            dsdanfe.Logo.AddLogoRow(drLogo);

        }
        //Fim - Diego - OS_23723 - 11/06/2009

        #endregion



        public static string FormataQtdeComercial(string dvalor)
        {
            int iqtdeComercial = Convert.ToInt16(Acesso.QTDE_CASAS_PRODUTOS);
            if (iqtdeComercial == 0)
            {
                if (dvalor[dvalor.Length - 1].ToString() != "0") // 4 casas
                {
                    return dvalor;
                }
                else if (dvalor[dvalor.Length - 2].ToString() != "0") // 3 casas
                {
                    return decimal.Round(Convert.ToDecimal(dvalor), 3).ToString();
                }
                else if (dvalor[dvalor.Length - 3].ToString() != "0") // 2 casas
                {
                    return decimal.Round(Convert.ToDecimal(dvalor), 2).ToString();
                }
                else if (dvalor[dvalor.Length - 4].ToString() != "0") // 1 casa
                {
                    return decimal.Round(Convert.ToDecimal(dvalor), 1).ToString();
                }
                else  // nenhuma Casa decimal 
                {
                    return Convert.ToDouble(dvalor).ToString();
                }
            }
            else if (iqtdeComercial == 1)
            {
                if (dvalor[dvalor.Length - 1].ToString() != "0") // 4 casas
                {
                    return dvalor;
                }
                else if (dvalor[dvalor.Length - 2].ToString() != "0") // 3 casas
                {
                    return decimal.Round(Convert.ToDecimal(dvalor), 3).ToString();
                }
                else if (dvalor[dvalor.Length - 3].ToString() != "0") // 2 casas
                {
                    return decimal.Round(Convert.ToDecimal(dvalor), 2).ToString();
                }
                else  // 1 Casa decimal 
                {
                    return decimal.Round(Convert.ToDecimal(dvalor), 1).ToString();
                }
            }
            else if (iqtdeComercial == 2)
            {
                if (dvalor[dvalor.Length - 1].ToString() != "0") // 4 casas
                {
                    return dvalor;
                }
                else if (dvalor[dvalor.Length - 2].ToString() != "0") // 3 casas
                {
                    return decimal.Round(Convert.ToDecimal(dvalor), 3).ToString();
                }
                else  // 2 Casa decimal 
                {
                    return decimal.Round(Convert.ToDecimal(dvalor), 2).ToString();
                }
            }
            else if (iqtdeComercial == 3)
            {
                if (dvalor[dvalor.Length - 1].ToString() != "0") // 4 casas
                {
                    return dvalor;
                }
                else  // 3 Casa decimal 
                {
                    return decimal.Round(Convert.ToDecimal(dvalor), 3).ToString();
                }
            }
            else
            {
                return dvalor; // valor com 4 casas decimais
            }
        }





        public string GeraChaveDadosNfe(int i, XmlDocument xml)
        {
            string scUF = "";
            string stpEmis = "";
            string sCNPJ = "";
            string svNF = "";
            string sICMSp = "0";
            string sICMSs = "0";
            string sDD = "";
            string sDV = "";

            string sDadosNfe = "";

            XmlNodeList xNdIde = xml.GetElementsByTagName("ide");
            XmlNodeList xNdEmit = xml.GetElementsByTagName("emit");
            XmlNodeList xNdenderEmit = xml.GetElementsByTagName("enderEmit");
            XmlNodeList xndICMStot = xml.GetElementsByTagName("ICMSTot");
            XmlNodeList xNdImposto = xml.GetElementsByTagName("imposto");
            XmlNodeList xNdICMS = null;



            for (int j = 0; j < xNdIde[i].ChildNodes.Count; j++)
            {
                switch (xNdIde[i].ChildNodes[j].LocalName)
                {
                    case "tpEmis": stpEmis = xNdIde[i].ChildNodes[j].InnerText;
                        break;
                    case "dEmi": sDD = Convert.ToDateTime(xNdIde[i].ChildNodes[j].InnerText).Day.ToString();
                        break;
                    case "cUF": scUF = xNdIde[i].ChildNodes[j].InnerText;
                        break;
                }
            }

            for (int j = 0; j < xNdEmit[i].ChildNodes.Count; j++)
            {
                switch (xNdEmit[i].ChildNodes[j].LocalName)
                {
                    case "CNPJ": { sCNPJ = xNdEmit[i].ChildNodes[j].InnerText; }
                        break;
                }
            }

            for (int j = 0; j < xndICMStot[i].ChildNodes.Count; j++)
            {
                switch (xndICMStot[i].ChildNodes[j].LocalName)
                {
                    case "vNF":
                        {
                            svNF = xndICMStot[i].ChildNodes[j].InnerText.Replace(".", "").PadLeft(14, '0');
                        }
                        break;
                }
            }



            switch (xNdImposto[i].ChildNodes[i].FirstChild.Name.Replace("ICMS", ""))
            {
                case "00":
                    {
                        sICMSp = "1";
                        sICMSs = "0";

                    }
                    break;
                case "10":
                    {
                        sICMSp = "1";
                        sICMSs = "1";
                    }
                    break;
                case "20":
                    {
                        sICMSp = "1";
                        sICMSs = "0";
                    }
                    break;
                case "30":
                    {
                        sICMSp = "0";
                        sICMSs = "1";
                    }
                    break;
                case "40":
                    {
                        sICMSp = "0";
                        sICMSs = "0";
                    }
                    break;
                case "51":
                    {
                        sICMSp = "1";
                        sICMSs = "0";
                    }
                    break;
                case "60":
                    {
                        xNdICMS = xml.GetElementsByTagName(xNdImposto[i].ChildNodes[i].FirstChild.Name);

                        for (int j = 0; j < xNdICMS[i].ChildNodes.Count; j++)
                        {
                            switch (xNdICMS[i].ChildNodes[j].LocalName)
                            {
                                case "vICMS":
                                    {
                                        sICMSp = xNdICMS[i].ChildNodes[j].InnerText;
                                    }
                                    break;
                                case "vICMSST":
                                    {
                                        sICMSs = xNdICMS[i].ChildNodes[j].InnerText;
                                    }
                                    break;
                            }
                        }
                        sICMSs = (sICMSs != "0" ? "1" : "0");
                        sICMSp = (sICMSp != "0" ? "1" : "0");
                    }
                    break;
                case "70":
                    {
                        sICMSp = "1";
                        sICMSs = "1";
                    }
                    break;
                case "90":
                    {
                        xNdICMS = xml.GetElementsByTagName(xNdImposto[i].ChildNodes[i].FirstChild.Name);

                        for (int j = 0; j < xNdICMS[i].ChildNodes.Count; j++)
                        {
                            switch (xNdICMS[i].ChildNodes[j].LocalName)
                            {
                                case "vICMS":
                                    {
                                        sICMSp = xNdICMS[i].ChildNodes[j].InnerText;
                                    }
                                    break;
                                case "vICMSST":
                                    {
                                        sICMSs = xNdICMS[i].ChildNodes[j].InnerText;
                                    }
                                    break;
                            }
                        }
                        sICMSs = (sICMSs != "0" ? "1" : "0");
                        sICMSp = (sICMSp != "0" ? "1" : "0");
                    }
                    break;
            }
            sDadosNfe = scUF + stpEmis + sCNPJ + svNF + sICMSp + sICMSs + sDD;

            string sDig = CalculaDig11(sDadosNfe).ToString();

            return (sDadosNfe + sDig).Trim();
        }
        public int CalculaDig11(string sChave)
        {

            int iDig = 0;
            int iMult = 2;
            int iTotal = 0;

            for (int i = (sChave.Length - 1); i >= 0; i--)
            {
                iTotal += Convert.ToInt32(sChave[i].ToString()) * iMult;
                iMult++;
                if (iMult > 9)
                {
                    iMult = 2;
                }

            }
            int iresto = (iTotal % 11);
            if ((iresto == 0) || (iresto == 1))
            {
                iDig = 0;
            }
            else
            {
                iDig = 11 - iresto;
            }
            return iDig;
        }


        public static Byte[] SalvaCodBarras(string sValor)
        {
            BarcodeLib.Barcode barcod = new BarcodeLib.Barcode(sValor, BarcodeLib.TYPE.CODE128C);
            barcod.Encode(BarcodeLib.TYPE.CODE128, sValor, 300, 150);

            string sCaminho = "";
            sCaminho = Pastas.CBARRAS + "\\Barras_" + sValor + ".JPG";
            barcod.SaveImage(@sCaminho, BarcodeLib.SaveTypes.JPG);

            return Util.CarregaImagem(sCaminho);
        }



    }
}
