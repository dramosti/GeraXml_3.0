using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace HLP.GeraXml.bel.NFe.Estrutura
{
    public class belImportaXmlNFe
    {
        private XmlDocument xDoc = new XmlDocument();


        public XmlDocument XDoc
        {
            get { return xDoc; }
            set { xDoc = value; }
        }

        public bool XmlValido()
        {
            bool bValido = true;
            if (xDoc.GetElementsByTagName("protNFe").Count > 0)
            {
                bValido = true;
            }
            return bValido;
        }

        public bool xmlAnalizado()
        {
            bool bValido = false;

            bValido = XmlValido();

            if (bValido)
            {
                belInfNFe objInfNFe;
                objInfNFe = xmlBuscaInfNFe();

            }

            return bValido;
        }

        public belInfNFe xmlBuscaInfNFe()
        {
            belInfNFe objInfNFe = new belInfNFe();

            return objInfNFe;

        }

        public belIde xmlBuscaIde()
        {
            XmlDocument xIde = new XmlDocument();
            belIde objIde = new belIde();

            try
            {
                xIde.LoadXml(xDoc.GetElementsByTagName("ide")[0].OuterXml);


                objIde.Cuf = xIde.GetElementsByTagName("cUF")[0].InnerText;
                objIde.Mod = xIde.GetElementsByTagName("mod")[0].InnerText;
                objIde.Serie = xIde.GetElementsByTagName("serie")[0].InnerText;
                objIde.Nnf = xIde.GetElementsByTagName("nNF")[0].InnerText;
                objIde.Demi = Convert.ToDateTime(xIde.GetElementsByTagName("dEmi")[0].InnerText);
                objIde.Dsaient = (xIde.GetElementsByTagName("dSaiEnt")[0] != null ? Convert.ToDateTime(xIde.GetElementsByTagName("dSaiEnt")[0].InnerText) : Convert.ToDateTime(xIde.GetElementsByTagName("dEmi")[0].InnerText));
                objIde.Tpnf = xIde.GetElementsByTagName("tpNF")[0].InnerText;

            }
            catch (Exception ex)
            {

                throw new Exception(string.Format("Problemas lendo a Tag IDE, Erro.: {0}",
                                                  ex.Message));
            }

            return objIde;
        }

        public belEmit xmlBuscaEmit()
        {
            XmlDocument xEmit = new XmlDocument();
            XmlDocument xEnderEmi = new XmlDocument();
            belEmit objEmit = new belEmit();

            try
            {
                if (xDoc.GetElementsByTagName("emit").Count > 0)
                {
                    xEmit.LoadXml(xDoc.GetElementsByTagName("emit")[0].OuterXml);

                    if (xEmit.GetElementsByTagName("CNPJ").Count > 0)
                    {
                        objEmit.Cnpj = xEmit.GetElementsByTagName("CNPJ")[0].InnerText;
                    }
                    if (xEmit.GetElementsByTagName("xNome").Count > 0)
                    {
                        objEmit.Xnome = xEmit.GetElementsByTagName("xNome")[0].InnerText;
                    }
                    if (xEmit.GetElementsByTagName("xFant").Count > 0)
                    {
                        objEmit.Xfant = xEmit.GetElementsByTagName("xFant")[0].InnerText;
                    }
                    if (xEmit.GetElementsByTagName("enderEmit").Count > 0)
                    {
                        xEnderEmi.LoadXml(xEmit.GetElementsByTagName("enderEmit")[0].OuterXml);
                    }
                    if (xEnderEmi.GetElementsByTagName("xLgr").Count > 0)
                    {
                        objEmit.Xlgr = xEnderEmi.GetElementsByTagName("xLgr")[0].InnerText;
                    }
                    if (xEnderEmi.GetElementsByTagName("nro").Count > 0)
                    {
                        objEmit.Nro = xEnderEmi.GetElementsByTagName("nro")[0].InnerText;
                    }
                    if (xEnderEmi.GetElementsByTagName("xBairro").Count > 0)
                    {
                        objEmit.Xbairro = xEnderEmi.GetElementsByTagName("xBairro")[0].InnerText;
                    }
                    if (xEnderEmi.GetElementsByTagName("cMun").Count > 0)
                    {
                        objEmit.Cmun = xEnderEmi.GetElementsByTagName("cMun")[0].InnerText;
                    }
                    if (xEnderEmi.GetElementsByTagName("xMun").Count > 0)
                    {
                        objEmit.Xmun = xEnderEmi.GetElementsByTagName("xMun")[0].InnerText;
                    }
                    if (xEnderEmi.GetElementsByTagName("UF").Count > 0)
                    {
                        objEmit.Uf = xEnderEmi.GetElementsByTagName("UF")[0].InnerText;
                    }
                    if (xEnderEmi.GetElementsByTagName("CEP").Count > 0)
                    {
                        objEmit.Cep = xEnderEmi.GetElementsByTagName("CEP")[0].InnerText;
                    }
                    if (xEnderEmi.GetElementsByTagName("cPais").Count > 0)
                    {
                        objEmit.Cpais = xEnderEmi.GetElementsByTagName("cPais")[0].InnerText;
                    }
                    if (xEnderEmi.GetElementsByTagName("xPais").Count > 0)
                    {
                        objEmit.Xpais = xEnderEmi.GetElementsByTagName("xPais")[0].InnerText;
                    }
                    if (xEnderEmi.GetElementsByTagName("fone").Count > 0)
                    {
                        objEmit.Fone = xEnderEmi.GetElementsByTagName("fone")[0].InnerText;
                    }
                    if (xEmit.GetElementsByTagName("IE").Count > 0)
                    {
                        objEmit.Ie = xEmit.GetElementsByTagName("IE")[0].InnerText;
                    }


                }
            }
            catch (Exception ex)
            {

                throw new Exception(string.Format("Problemas lendo a Tag Emitente, Erro.: {0}",
                                                  ex.Message));
            }

            return objEmit;
        }

        public belDest xmlBuscaDest()
        {
            XmlDocument xDest = new XmlDocument();
            belDest objDest = new belDest();
            XmlDocument xEnderDest = new XmlDocument();

            try
            {
                if (xDoc.GetElementsByTagName("dest").Count > 0)
                {
                    xDest.LoadXml(xDoc.GetElementsByTagName("dest")[0].OuterXml);
                    if (xDest.GetElementsByTagName("CNPJ").Count > 0)
                    {
                        objDest.Cnpj = xDest.GetElementsByTagName("CNPJ")[0].InnerText;
                    }

                    if (xDest.GetElementsByTagName("CPF").Count > 0)
                    {
                        objDest.Cpf = xDest.GetElementsByTagName("CPF")[0].InnerText;
                    }
                    if (xDest.GetElementsByTagName("xNome").Count > 0)
                    {
                        objDest.Xnome = xDest.GetElementsByTagName("xNome")[0].InnerText;
                    }

                    if (xDest.GetElementsByTagName("enderDest").Count > 0)
                    {
                        xEnderDest.LoadXml(xDest.GetElementsByTagName("enderDest")[0].OuterXml);
                        if (xEnderDest.GetElementsByTagName("xLgr").Count > 0)
                        {
                            objDest.Xlgr = xEnderDest.GetElementsByTagName("xLgr")[0].InnerText;
                        }
                        if (xEnderDest.GetElementsByTagName("nro").Count > 0)
                        {
                            objDest.Nro = xEnderDest.GetElementsByTagName("nro")[0].InnerText;
                        }
                        if (xEnderDest.GetElementsByTagName("xBairro").Count > 0)
                        {
                            objDest.Xbairro = xEnderDest.GetElementsByTagName("xBairro")[0].InnerText;
                        }
                        if (xEnderDest.GetElementsByTagName("cMun").Count > 0)
                        {
                            objDest.Cmun = xEnderDest.GetElementsByTagName("cMun")[0].InnerText;
                        }
                        if (xEnderDest.GetElementsByTagName("xMun").Count > 0)
                        {
                            objDest.Xmun = xEnderDest.GetElementsByTagName("xMun")[0].InnerText;
                        }
                        if (xEnderDest.GetElementsByTagName("UF").Count > 0)
                        {
                            objDest.Uf = xEnderDest.GetElementsByTagName("UF")[0].InnerText;
                        }
                        if (xEnderDest.GetElementsByTagName("CEP").Count > 0)
                        {
                            objDest.Cep = xEnderDest.GetElementsByTagName("CEP")[0].InnerText;
                        }
                        if (xEnderDest.GetElementsByTagName("cPais").Count > 0)
                        {
                            objDest.Cpais = xEnderDest.GetElementsByTagName("cPais")[0].InnerText;
                        }
                        if (xEnderDest.GetElementsByTagName("xPais").Count > 0)
                        {
                            objDest.Xpais = xEnderDest.GetElementsByTagName("xPais")[0].InnerText;
                        }
                        if (xEnderDest.GetElementsByTagName("fone").Count > 0)
                        {
                            objDest.Fone = xEnderDest.GetElementsByTagName("fone")[0].InnerText;
                        }

                    }

                    objDest.Ie = xDest.GetElementsByTagName("IE")[0].InnerText;
                }
            }
            catch (Exception ex)
            {

                throw new Exception(string.Format("Problemas lendo a Tag Destinatário, Erro.: {0}",
                                                  ex.Message));
            }

            return objDest;

        }

        public belTotal xmlBuscaTotal()
        {
            belTotal objTotal = new belTotal();
            XmlDocument xTotalN = new XmlDocument();

            try
            {
                switch (xDoc.GetElementsByTagName("total")[0].FirstChild.Name)
                {
                    case "ICMSTot":
                        {
                            xTotalN.LoadXml(xDoc.GetElementsByTagName("ICMSTot")[0].OuterXml);

                            belIcmstot objIcmsTot = new belIcmstot();
                            objIcmsTot.Vbc = Convert.ToDecimal(xTotalN.GetElementsByTagName("vBC")[0].InnerText.ToString().Replace(".", ","));
                            objIcmsTot.Vicms = Convert.ToDecimal(xTotalN.GetElementsByTagName("vICMS")[0].InnerText.ToString().Replace(".", ","));
                            objIcmsTot.Vbcst = Convert.ToDecimal(xTotalN.GetElementsByTagName("vBCST")[0].InnerText.ToString().Replace(".", ","));
                            objIcmsTot.Vst = Convert.ToDecimal(xTotalN.GetElementsByTagName("vST")[0].InnerText.ToString().Replace(".", ","));
                            objIcmsTot.Vprod = Convert.ToDecimal(xTotalN.GetElementsByTagName("vProd")[0].InnerText.ToString().Replace(".", ","));
                            objIcmsTot.Vfrete = Convert.ToDecimal(xTotalN.GetElementsByTagName("vFrete")[0].InnerText.ToString().Replace(".", ","));
                            objIcmsTot.Vseg = Convert.ToDecimal(xTotalN.GetElementsByTagName("vSeg")[0].InnerText.ToString().Replace(".", ","));
                            objIcmsTot.Vdesc = Convert.ToDecimal(xTotalN.GetElementsByTagName("vDesc")[0].InnerText.ToString().Replace(".", ","));
                            objIcmsTot.Vii = Convert.ToDecimal(xTotalN.GetElementsByTagName("vII")[0].InnerText.ToString().Replace(".", ","));
                            objIcmsTot.Vipi = Convert.ToDecimal(xTotalN.GetElementsByTagName("vIPI")[0].InnerText.ToString().Replace(".", ","));
                            objIcmsTot.Vpis = Convert.ToDecimal(xTotalN.GetElementsByTagName("vPIS")[0].InnerText.ToString().Replace(".", ","));
                            objIcmsTot.Vcofins = Convert.ToDecimal(xTotalN.GetElementsByTagName("vCOFINS")[0].InnerText.ToString().Replace(".", ","));
                            objIcmsTot.Voutro = Convert.ToDecimal(xTotalN.GetElementsByTagName("vOutro")[0].InnerText.ToString().Replace(".", ","));
                            objIcmsTot.Vnf = Convert.ToDecimal(xTotalN.GetElementsByTagName("vNF")[0].InnerText.ToString().Replace(".", ","));

                            objTotal.belIcmstot = objIcmsTot;
                            break;
                        }
                    case "ISSQNTot":
                        {
                            xTotalN.LoadXml(xDoc.GetElementsByTagName("ISSQNTot")[0].OuterXml);

                            belIssqntot objIssqntot = new belIssqntot();
                            objIssqntot.Vserv = Convert.ToDecimal(xTotalN.GetElementsByTagName("vServ")[0].InnerText.ToString().Replace(".", ","));
                            objIssqntot.Vbc = Convert.ToDecimal(xTotalN.GetElementsByTagName("vBC")[0].InnerText.ToString().Replace(".", ","));
                            objIssqntot.Viss = Convert.ToDecimal(xTotalN.GetElementsByTagName("vISS")[0].InnerText.ToString().Replace(".", ","));
                            objIssqntot.Vpis = Convert.ToDecimal(xTotalN.GetElementsByTagName("vPIS")[0].InnerText.ToString().Replace(".", ","));
                            objIssqntot.Vcofins = Convert.ToDecimal(xTotalN.GetElementsByTagName("vCONFIS")[0].InnerText.ToString().Replace(".", ","));

                            objTotal.belIssqntot = objIssqntot;

                            break;
                        }
                    case "retTrib":
                        {
                            xTotalN.LoadXml(xDoc.GetElementsByTagName("retTrib")[0].OuterXml);

                            belRetTrib objRettrib = new belRetTrib();
                            objRettrib.Vretpis = Convert.ToDecimal(xTotalN.GetElementsByTagName("vRetPIS")[0].InnerText.ToString().Replace(".", ","));
                            objRettrib.Vretcofins = Convert.ToDecimal(xTotalN.GetElementsByTagName("vRetCOFINS")[0].InnerText.ToString().Replace(".", ","));
                            objRettrib.Vretcsll = Convert.ToDecimal(xTotalN.GetElementsByTagName("vRetCSLL")[0].InnerText.ToString().Replace(".", ","));
                            objRettrib.Vbcirrf = Convert.ToDecimal(xTotalN.GetElementsByTagName("vBCIRRF")[0].InnerText.ToString().Replace(".", ","));
                            objRettrib.Virrf = Convert.ToDecimal(xTotalN.GetElementsByTagName("vIRRF")[0].InnerText.ToString().Replace(".", ","));
                            objRettrib.Vbcretprev = Convert.ToDecimal(xTotalN.GetElementsByTagName("vBCRetPrev")[0].InnerText.ToString().Replace(".", ","));
                            objRettrib.Vretprev = Convert.ToDecimal(xTotalN.GetElementsByTagName("vRetPrev")[0].InnerText.ToString().Replace(".", ","));

                            objTotal.belRetTrib = objRettrib;

                            break;
                        }
                }

            }
            catch (Exception ex)
            {

                throw new Exception(string.Format("Problemas lendo a Tag Total, Erro.: {0}",
                                                  ex.Message));
            }

            return objTotal;

        }



        public belCobr xmlBuscaCobr()
        {
            belCobr objCobr = new belCobr();
            XmlDocument xCobr = new XmlDocument();
            belFat objFat = new belFat();

            try
            {
                if (xDoc.GetElementsByTagName("cobr").Count > 0)
                {
                    xCobr.LoadXml(xDoc.GetElementsByTagName("cobr")[0].OuterXml);

                    if (xCobr.GetElementsByTagName("fat").Count > 0)
                    {
                        XmlDocument xFat = new XmlDocument();
                        xFat.LoadXml(xCobr.GetElementsByTagName("fat")[0].OuterXml);

                        if (xFat.GetElementsByTagName("nFat").Count > 0)
                        {
                            objFat.Nfat = xFat.GetElementsByTagName("nFat")[0].InnerText;
                        }

                        if (xFat.GetElementsByTagName("vOrig").Count > 0)
                        {
                            objFat.Vorig = Convert.ToDecimal(xFat.GetElementsByTagName("vOrig")[0].InnerText.ToString().Replace(".", ","));
                        }

                        if (xFat.GetElementsByTagName("vDesc").Count > 0)
                        {
                            objFat.Vdesc = Convert.ToDecimal(xFat.GetElementsByTagName("vDesc")[0].InnerText.ToString().Replace(".", ","));
                        }

                        if (xFat.GetElementsByTagName("vLiq").Count > 0)
                        {
                            objFat.Vliq = Convert.ToDecimal(xFat.GetElementsByTagName("vLiq")[0].InnerText.ToString().Replace(".", ","));
                        }
                    }
                    List<belDup> lobjDup = new List<belDup>();

                    for (int i = 0; i < xCobr.GetElementsByTagName("dup").Count; i++)
                    {
                        XmlDocument xDup = new XmlDocument();
                        xDup.LoadXml(xCobr.GetElementsByTagName("dup")[i].OuterXml);

                        belDup objDup = new belDup();

                        if (xDup.GetElementsByTagName("nDup").Count > 0)
                        {
                            objDup.Ndup = xDup.GetElementsByTagName("nDup")[0].InnerText;
                        }

                        if (xDup.GetElementsByTagName("dVenc").Count > 0)
                        {
                            objDup.Dvenc = Convert.ToDateTime(xDup.GetElementsByTagName("dVenc")[0].InnerText);
                        }

                        if (xDup.GetElementsByTagName("vDup").Count > 0)
                        {
                            objDup.Vdup = Convert.ToDecimal(xDup.GetElementsByTagName("vDup")[0].InnerText.ToString().Replace(".", ","));
                        }

                        lobjDup.Add(objDup);

                    }

                    objFat.belDup = lobjDup;
                    objCobr.Fat = objFat;



                }


            }
            catch (Exception ex)
            {

                throw new Exception(string.Format("Problemas lendo a Tag Transp, Cobr.: {0}",
                                                  ex.Message));
            }
            return objCobr;
        }


        public belTransp xmlBuscaTransp()
        {
            belTransp objTransp = new belTransp();
            XmlDocument xTransp = new XmlDocument();

            try
            {
                xTransp.LoadXml(xDoc.GetElementsByTagName("transp")[0].OuterXml);

                objTransp.Modfrete = xTransp.GetElementsByTagName("modFrete")[0].InnerText;

                XmlDocument xTransporta = new XmlDocument();

                if (xTransp.GetElementsByTagName("transporta")[0] != null)
                {
                    xTransporta.LoadXml(xTransp.GetElementsByTagName("transporta")[0].OuterXml);

                    belTransportadora objTransportadora = new belTransportadora();
                    if (xTransporta.GetElementsByTagName("CNPJ").Count > 0)
                    {
                        objTransportadora.Cnpj = xTransporta.GetElementsByTagName("CNPJ")[0].InnerText;
                    }
                    if (xTransporta.GetElementsByTagName("CPF").Count > 0)
                    {
                        objTransportadora.Cpf = xTransporta.GetElementsByTagName("CPF")[0].InnerText;
                    }
                    if (xTransporta.GetElementsByTagName("xNome").Count > 0)
                    {
                        objTransportadora.Xnome = xTransporta.GetElementsByTagName("xNome")[0].InnerText;
                    }
                    if (xTransporta.GetElementsByTagName("IE").Count > 0)
                    {
                        objTransportadora.Ie = xTransporta.GetElementsByTagName("IE")[0].InnerText;
                    }
                    if (xTransporta.GetElementsByTagName("xEnder").Count > 0)
                    {
                        objTransportadora.Xender = xTransporta.GetElementsByTagName("xEnder")[0].InnerText;
                    }
                    if (xTransporta.GetElementsByTagName("xMun").Count > 0)
                    {
                        objTransportadora.Xmun = xTransporta.GetElementsByTagName("xMun")[0].InnerText;
                    }
                    if (xTransporta.GetElementsByTagName("UF").Count > 0)
                    {
                        objTransportadora.Uf = xTransporta.GetElementsByTagName("UF")[0].InnerText;
                    }

                    objTransp.belTransportadora = objTransportadora;
                }



                if (xTransp.GetElementsByTagName("retTransp").Count > 0)
                {
                    XmlDocument xRetTransp = new XmlDocument();
                    xRetTransp.LoadXml(xTransp.GetElementsByTagName("retTransp")[0].OuterXml);

                    belRetTransp objRetTransp = new belRetTransp();
                    if (xRetTransp.GetElementsByTagName("vServ").Count > 0)
                    {
                        objRetTransp.Vserv = Convert.ToDecimal(xRetTransp.GetElementsByTagName("vServ")[0].InnerText.ToString().Replace(".", ","));
                    }
                    if (xRetTransp.GetElementsByTagName("vBCRet").Count > 0)
                    {
                        objRetTransp.Vbvret = Convert.ToDecimal(xRetTransp.GetElementsByTagName("vBCRet")[0].InnerText.ToString().Replace(".", ","));
                    }
                    if (xRetTransp.GetElementsByTagName("pICMSRet").Count > 0)
                    {
                        objRetTransp.Picmsret = Convert.ToDecimal(xRetTransp.GetElementsByTagName("pICMSRet")[0].InnerText.ToString().Replace(".", ","));
                    }
                    if (xRetTransp.GetElementsByTagName("vICMSRet").Count > 0)
                    {
                        objRetTransp.Vicmsret = Convert.ToDecimal(xRetTransp.GetElementsByTagName("vICMSRet")[0].InnerText.ToString().Replace(".", ","));
                    }
                    if (xRetTransp.GetElementsByTagName("CFOP").Count > 0)
                    {
                        objRetTransp.Cfop = xRetTransp.GetElementsByTagName("CFOP")[0].InnerText;
                    }
                    if (xRetTransp.GetElementsByTagName("cMunFG").Count > 0)
                    {
                        objRetTransp.Cmunfg = xRetTransp.GetElementsByTagName("cMunFG")[0].InnerText;
                    }
                    objTransp.belRetTransp = objRetTransp;

                }

                if (xTransp.GetElementsByTagName("veicTransp").Count > 0)
                {
                    XmlDocument xveicTransp = new XmlDocument();
                    xveicTransp.LoadXml(xTransp.GetElementsByTagName("veicTransp")[0].OuterXml);

                    belVeicTransp objVeictransp = new belVeicTransp();
                    if (xveicTransp.GetElementsByTagName("placa").Count > 0)
                    {
                        objVeictransp.Placa = xveicTransp.GetElementsByTagName("placa")[0].InnerText;
                    }

                    if (xveicTransp.GetElementsByTagName("UF").Count > 0)
                    {
                        objVeictransp.Uf = xveicTransp.GetElementsByTagName("UF")[0].InnerText;
                    }

                    if (xveicTransp.GetElementsByTagName("RNTC").Count > 0)
                    {
                        objVeictransp.Rntc = xveicTransp.GetElementsByTagName("RNTC")[0].InnerText;
                    }

                    objTransp.belVeicTransp = objVeictransp;
                }

                if (xTransp.GetElementsByTagName("reboque").Count > 0)
                {
                    XmlDocument xReboque = new XmlDocument();
                    xReboque.LoadXml(xTransp.GetElementsByTagName("reboque")[0].OuterXml);

                    belReboque objReboque = new belReboque();

                    if (xReboque.GetElementsByTagName("placa").Count > 0)
                    {
                        objReboque.Placa = xReboque.GetElementsByTagName("placa")[0].InnerText;
                    }
                    if (xReboque.GetElementsByTagName("UF").Count > 0)
                    {
                        objReboque.Uf = xReboque.GetElementsByTagName("UF")[0].InnerText;
                    }
                    if (xReboque.GetElementsByTagName("RNTC").Count > 0)
                    {
                        objReboque.Rntc = xReboque.GetElementsByTagName("RNTC")[0].InnerText;
                    }

                    objTransp.belReboque = objReboque;

                }

                if (xTransp.GetElementsByTagName("vol").Count > 0)
                {
                    XmlDocument xVol = new XmlDocument();
                    xVol.LoadXml(xTransp.GetElementsByTagName("vol")[0].OuterXml);

                    belVol objVol = new belVol();

                    if (xVol.GetElementsByTagName("qVol").Count > 0)
                    {
                        objVol.Qvol = Convert.ToDecimal(xVol.GetElementsByTagName("qVol")[0].InnerText.ToString().Replace(".", ","));
                    }

                    if (xVol.GetElementsByTagName("esp").Count > 0)
                    {
                        objVol.Esp = xVol.GetElementsByTagName("esp")[0].InnerText;
                    }

                    if (xVol.GetElementsByTagName("marca").Count > 0)
                    {
                        objVol.Marca = xVol.GetElementsByTagName("marca")[0].InnerText;
                    }

                    if (xVol.GetElementsByTagName("nVol").Count > 0)
                    {
                        objVol.Nvol = xVol.GetElementsByTagName("nVol")[0].InnerText;//Danner - o.s. 24432 - 04/05/2010
                    }

                    if (xVol.GetElementsByTagName("pesoL").Count > 0)
                    {
                        objVol.PesoL = Convert.ToDecimal(xVol.GetElementsByTagName("pesoL")[0].InnerText.ToString().Replace(".", ","));
                    }

                    if (xVol.GetElementsByTagName("pesoB").Count > 0)
                    {
                        objVol.PesoB = Convert.ToDecimal(xVol.GetElementsByTagName("pesoB")[0].InnerText.ToString().Replace(".", ","));
                    }

                    objTransp.belVol = objVol;

                }

                if (xTransp.GetElementsByTagName("lacres").Count > 0)
                {
                    XmlDocument xLacres = new XmlDocument();
                    xLacres.LoadXml(xTransp.GetElementsByTagName("lacres")[0].OuterXml);

                    belLacres objLacres = new belLacres();

                    if (xLacres.GetElementsByTagName("nLacre").Count > 0)
                    {
                        objLacres.Nlacre = xLacres.GetElementsByTagName("nLacre")[0].InnerText;
                    }

                    objTransp.belLacres = objLacres;

                }


            }
            catch (Exception ex)
            {

                throw new Exception(string.Format("Problemas lendo a Tag Transp, Erro.: {0}",
                                                  ex.Message));
            }

            return objTransp;

        }


        public List<belDet> xmlBuscaDet()
        {
            XmlDocument xDet = new XmlDocument();
            XmlDocument xProd = new XmlDocument();
            XmlDocument xImpostos = new XmlDocument();
            XmlDocument xIcms = new XmlDocument();
            XmlDocument xIcmsN = new XmlDocument();

            List<belDet> lobjDet = new List<belDet>();

            try
            {
                for (int i = 0; i < xDoc.GetElementsByTagName("det").Count; i++)
                {
                    belDet objDet = new belDet();
                    belProd objProd = new belProd();
                    if (xDoc.GetElementsByTagName("det").Count > 0)
                    {
                        xDet.LoadXml(xDoc.GetElementsByTagName("det")[i].OuterXml);

                        if (xDet.GetElementsByTagName("prod").Count > 0)
                        {
                            xProd.LoadXml(xDet.GetElementsByTagName("prod")[0].OuterXml);
                            if (xProd.GetElementsByTagName("cProd").Count > 0)
                            {
                                objProd.Cprod = xProd.GetElementsByTagName("cProd")[0].InnerText;
                            }
                            if (xProd.GetElementsByTagName("cEAN").Count > 0)
                            {
                                objProd.Cean = xProd.GetElementsByTagName("cEAN")[0].InnerText;
                            }
                            if (xProd.GetElementsByTagName("xProd").Count > 0)
                            {
                                objProd.Xprod = xProd.GetElementsByTagName("xProd")[0].InnerText;
                            }
                            if (xProd.GetElementsByTagName("NCM").Count > 0)
                            {
                                objProd.Ncm = xProd.GetElementsByTagName("NCM")[0].InnerText;
                            }
                            else
                            {
                                objProd.Ncm = "GERAL";
                            }
                            if (xProd.GetElementsByTagName("CFOP").Count > 0)
                            {
                                objProd.Cfop = xProd.GetElementsByTagName("CFOP")[0].InnerText;
                            }
                            if (xProd.GetElementsByTagName("uTrib").Count > 0)
                            {
                                objProd.Utrib = xProd.GetElementsByTagName("uTrib")[0].InnerText;
                            }
                            if (xProd.GetElementsByTagName("uCom").Count > 0)
                            {
                                if (objProd.Utrib != "")
                                {
                                    objProd.Ucom = objProd.Utrib;
                                }
                                else
                                {
                                    objProd.Ucom = xProd.GetElementsByTagName("uCom")[0].InnerText.ToString();
                                }
                            }
                            if (xProd.GetElementsByTagName("qCom").Count > 0)
                            {
                                objProd.Qcom = Convert.ToDecimal(xProd.GetElementsByTagName("qCom")[0].InnerText.ToString().Replace(".", ","));
                            }
                            if (xProd.GetElementsByTagName("vUnCom").Count > 0)
                            {
                                objProd.Vuncom = Convert.ToDecimal(xProd.GetElementsByTagName("vUnCom")[0].InnerText.ToString().Replace(".", ","));
                            }
                            if (xProd.GetElementsByTagName("vProd").Count > 0)
                            {
                                objProd.Vprod = Convert.ToDecimal(xProd.GetElementsByTagName("vProd")[0].InnerText.ToString().Replace(".", ","));
                            }
                            if (xProd.GetElementsByTagName("vFrete").Count > 0) // os_25272
                            {
                                objProd.Vfrete = Convert.ToDecimal(xProd.GetElementsByTagName("vFrete")[0].InnerText.ToString().Replace(".", ","));
                            }
                            if (xProd.GetElementsByTagName("cEANTrib").Count > 0)
                            {
                                objProd.Ceantrib = Convert.ToString((xProd.GetElementsByTagName("cEANTrib")[0].InnerText == "" ? "0" : xProd.GetElementsByTagName("cEANTrib")[0].InnerText.ToString().Replace(".", ",")));
                            }

                            if (xProd.GetElementsByTagName("qTrib").Count > 0)
                            {
                                objProd.Qtrib = Convert.ToDecimal(xProd.GetElementsByTagName("qTrib")[0].InnerText.ToString().Replace(".", ","));
                            }
                            if (xProd.GetElementsByTagName("vUnTrib").Count > 0)
                            {
                                objProd.Vuntrib = Convert.ToDecimal(xProd.GetElementsByTagName("vUnTrib")[0].InnerText.ToString().Replace(".", ","));
                            }

                            if (xProd.GetElementsByTagName("vDesc").Count > 0)
                            {
                                objProd.Vdesc = Convert.ToDecimal(xProd.GetElementsByTagName("vDesc")[0].InnerText.ToString().Replace(".", ","));
                            }

                            if (xDet.GetElementsByTagName("imposto").Count > 0)
                            {
                                xImpostos.LoadXml(xDet.GetElementsByTagName("imposto")[0].OuterXml);
                            }

                            if (xImpostos.GetElementsByTagName("ICMS").Count > 0)
                            {
                                xIcms.LoadXml(xImpostos.GetElementsByTagName("ICMS")[0].OuterXml);

                                belIcms objIcms = new belIcms();
                                objIcms = xmlBuscaDetICMS(xIcms);

                                belIpi objIPI = xmlBuscaDetIPI(xImpostos);

                                belIi objII = xmlBuscaDetII(xImpostos);

                                belPis objPis = xmlBuscaDetPis(xImpostos);

                                belCofins objCofins = xmlBuscaDetCofins(xImpostos);

                                belIss objIss = xmlBuscaDetIssqn(xImpostos);

                                belInfadprod objInfadProd = new belInfadprod();
                                if (xDet.GetElementsByTagName("inAdProd").Count > 0)
                                {

                                    objInfadProd.Infadprid = xDet.GetElementsByTagName("inAdProd")[i].InnerText;
                                }

                                objDet.prod = objProd;

                                belImposto objImpostos = new belImposto();
                                objImpostos.belIcms = objIcms;
                                objImpostos.belIpi = objIPI;
                                objImpostos.belIi = objII;
                                objImpostos.belPis = objPis;
                                objImpostos.belCofins = objCofins;
                                objImpostos.belIss = objIss;

                                objDet.imposto = objImpostos;
                                objDet.infAdProd = objInfadProd;


                                lobjDet.Add(objDet);

                            }


                        }

                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Problemas lendo a Tag Det, Erro.: {0}",
                                                  ex.Message));

            }
            return lobjDet;

        }

        public belIcms xmlBuscaDetICMS(XmlDocument Xdoc)
        {
            belIcms objIcms = new belIcms();
            XmlDocument xIcmsN = new XmlDocument();

            try
            {
                switch (Xdoc.GetElementsByTagName("ICMS")[0].FirstChild.Name)
                {
                    case "ICMS00":
                        {
                            #region ICMS00
                            belIcms00 objIcms00 = new belIcms00();
                            xIcmsN.LoadXml(Xdoc.GetElementsByTagName("ICMS00")[0].OuterXml);
                            for (int i = 0; i < xIcmsN.ChildNodes[0].ChildNodes.Count; i++)
                            {
                                switch (xIcmsN.ChildNodes[0].ChildNodes[i].Name)
                                {
                                    case "orig":
                                        {
                                            objIcms00.Orig = xIcmsN.GetElementsByTagName("orig")[0].InnerText;
                                        }
                                        break;
                                    case "CST":
                                        {
                                            objIcms00.Cst = xIcmsN.GetElementsByTagName("CST")[0].InnerText;
                                        }
                                        break;
                                    case "modBC":
                                        {
                                            objIcms00.Modbc = xIcmsN.GetElementsByTagName("modBC")[0].InnerText;
                                        }
                                        break;
                                    case "vBC":
                                        {
                                            objIcms00.Vbc = Convert.ToDecimal(xIcmsN.GetElementsByTagName("vBC")[0].InnerText.ToString().Replace(".", ","));
                                        }
                                        break;
                                    case "pICMS":
                                        {
                                            objIcms00.Picms = Convert.ToDecimal(xIcmsN.GetElementsByTagName("pICMS")[0].InnerText.ToString().Replace(".", ","));
                                        }
                                        break;
                                    case "vICMS":
                                        {
                                            objIcms00.Vicms = Convert.ToDecimal(xIcmsN.GetElementsByTagName("vICMS")[0].InnerText.ToString().Replace(".", ","));
                                        }
                                        break;
                                }
                            }
                            objIcms.belIcms00 = objIcms00;

                            #endregion
                            break;
                        }
                    case "ICMS10":
                        {
                            #region ICMS10
                            xIcmsN.LoadXml(Xdoc.GetElementsByTagName("ICMS10")[0].OuterXml);
                            belIcms10 objIcms10 = new belIcms10();
                            for (int i = 0; i < xIcmsN.ChildNodes[0].ChildNodes.Count; i++)
                            {
                                switch (xIcmsN.ChildNodes[0].ChildNodes[i].Name)
                                {
                                    case "orig":
                                        {
                                            objIcms10.Orig = xIcmsN.GetElementsByTagName("orig")[0].InnerText;
                                        }
                                        break;
                                    case "CST":
                                        {
                                            objIcms10.Cst = xIcmsN.GetElementsByTagName("CST")[0].InnerText;
                                        }
                                        break;
                                    case "modBC":
                                        {
                                            objIcms10.Modbc = xIcmsN.GetElementsByTagName("modBC")[0].InnerText;
                                        }
                                        break;
                                    case "vBC":
                                        {
                                            objIcms10.Vbc = Convert.ToDecimal(xIcmsN.GetElementsByTagName("vBC")[0].InnerText.ToString().Replace(".", ","));
                                        }
                                        break;
                                    case "pICMS":
                                        {
                                            objIcms10.Picms = Convert.ToDecimal(xIcmsN.GetElementsByTagName("pICMS")[0].InnerText.ToString().Replace(".", ","));
                                        }
                                        break;
                                    case "vICMS":
                                        {
                                            objIcms10.Vicms = Convert.ToDecimal(xIcmsN.GetElementsByTagName("vICMS")[0].InnerText.ToString().Replace(".", ","));
                                        }
                                        break;
                                    case "modBCST":
                                        {
                                            objIcms10.Modbcst = Convert.ToDecimal(xIcmsN.GetElementsByTagName("modBCST")[0].InnerText.ToString().Replace(".", ","));
                                        }
                                        break;
                                    case "pMVAST":
                                        {
                                            objIcms10.Pmvast = Convert.ToDecimal(xIcmsN.GetElementsByTagName("pMVAST")[0].InnerText.ToString().Replace(".", ","));
                                        }
                                        break;
                                    case "pRedBCST":
                                        {
                                            objIcms10.Predbcst = Convert.ToDecimal(xIcmsN.GetElementsByTagName("pRedBCST")[0].InnerText.ToString().Replace(".", ","));
                                        }
                                        break;
                                    case "vBCST":
                                        {
                                            objIcms10.Vbcst = Convert.ToDecimal(xIcmsN.GetElementsByTagName("vBCST")[0].InnerText.ToString().Replace(".", ","));
                                        }
                                        break;
                                    case "pICMSST":
                                        {
                                            objIcms10.Picmsst = Convert.ToDecimal(xIcmsN.GetElementsByTagName("pICMSST")[0].InnerText.ToString().Replace(".", ","));
                                        }
                                        break;
                                    case "vICMSST":
                                        {
                                            objIcms10.Vicmsst = Convert.ToDecimal(xIcmsN.GetElementsByTagName("vICMSST")[0].InnerText.ToString().Replace(".", ","));
                                        }
                                        break;
                                }
                            }
                            objIcms.belIcms10 = objIcms10;

                            #endregion
                            break;
                        }
                    case "ICMS20":
                        {
                            #region ICMS20
                            xIcmsN.LoadXml(Xdoc.GetElementsByTagName("ICMS20")[0].OuterXml);
                            belIcms20 objIcms20 = new belIcms20();

                            for (int i = 0; i < xIcmsN.ChildNodes[0].ChildNodes.Count; i++)
                            {
                                switch (xIcmsN.ChildNodes[0].ChildNodes[i].Name)
                                {
                                    case "orig":
                                        {
                                            objIcms20.Orig = xIcmsN.GetElementsByTagName("orig")[0].InnerText;
                                        }
                                        break;
                                    case "CST":
                                        {
                                            objIcms20.Cst = xIcmsN.GetElementsByTagName("CST")[0].InnerText;
                                        }
                                        break;
                                    case "modBC":
                                        {
                                            objIcms20.Modbc = xIcmsN.GetElementsByTagName("modBC")[0].InnerText;
                                        }
                                        break;
                                    case "pRedBC":
                                        {
                                            objIcms20.Predbc = Convert.ToDecimal(xIcmsN.GetElementsByTagName("pRedBC")[0].InnerText.ToString().Replace(".", ","));
                                        }
                                        break;
                                    case "vBC":
                                        {
                                            objIcms20.Vbc = Convert.ToDecimal(xIcmsN.GetElementsByTagName("vBC")[0].InnerText.ToString().Replace(".", ","));
                                        }
                                        break;
                                    case "pICMS":
                                        {
                                            objIcms20.Picms = Convert.ToDecimal(xIcmsN.GetElementsByTagName("pICMS")[0].InnerText.ToString().Replace(".", ","));
                                        }
                                        break;
                                    case "vICMS":
                                        {
                                            objIcms20.Vicms = Convert.ToDecimal(xIcmsN.GetElementsByTagName("vICMS")[0].InnerText.ToString().Replace(".", ","));
                                        }
                                        break;
                                }
                            }
                            objIcms.belIcms20 = objIcms20;
                            #endregion
                            break;
                        }
                    case "ICMS30":
                        {
                            #region ICMS30
                            xIcmsN.LoadXml(Xdoc.GetElementsByTagName("ICMS30")[0].OuterXml);
                            belIcms30 objIcms30 = new belIcms30();
                            for (int i = 0; i < xIcmsN.ChildNodes[0].ChildNodes.Count; i++)
                            {
                                switch (xIcmsN.ChildNodes[0].ChildNodes[i].Name)
                                {
                                    case "orig":
                                        {
                                            objIcms30.Orig = xIcmsN.GetElementsByTagName("orig")[0].InnerText;
                                        }
                                        break;
                                    case "CST":
                                        {
                                            objIcms30.Cst = xIcmsN.GetElementsByTagName("CST")[0].InnerText;
                                        }
                                        break;
                                    case "modBCST":
                                        {
                                            objIcms30.Modbcst = Convert.ToDecimal(xIcmsN.GetElementsByTagName("modBCST")[0].InnerText.ToString().Replace(".", ","));
                                        }
                                        break;
                                    case "pMVAST":
                                        {
                                            objIcms30.Pmvast = Convert.ToDecimal(xIcmsN.GetElementsByTagName("pMVAST")[0].InnerText.ToString().Replace(".", ","));
                                        }
                                        break;
                                    case "pRedBCST":
                                        {
                                            objIcms30.Predbcst = Convert.ToDecimal(xIcmsN.GetElementsByTagName("pRedBCST")[0].InnerText.ToString().Replace(".", ","));
                                        }
                                        break;
                                    case "vBCST":
                                        {

                                            objIcms30.Vbcst = Convert.ToDecimal(xIcmsN.GetElementsByTagName("vBCST")[0].InnerText.ToString().Replace(".", ","));
                                        }
                                        break;
                                    case "pICMSST":
                                        {

                                            objIcms30.Picmsst = Convert.ToDecimal(xIcmsN.GetElementsByTagName("pICMSST")[0].InnerText.ToString().Replace(".", ","));
                                        }
                                        break;
                                    case "vICMSST":
                                        {
                                            objIcms30.Vicmsst = Convert.ToDecimal(xIcmsN.GetElementsByTagName("vICMSST")[0].InnerText.ToString().Replace(".", ","));
                                        }
                                        break;
                                }

                            }

                            objIcms.belIcms30 = objIcms30;
                            #endregion
                            break;
                        }
                    case "ICMS40":
                        {
                            #region ICMS40
                            xIcmsN.LoadXml(Xdoc.GetElementsByTagName("ICMS40")[0].OuterXml);
                            belIcms40 objIcms40 = new belIcms40();

                            for (int i = 0; i < xIcmsN.ChildNodes[0].ChildNodes.Count; i++)
                            {
                                switch (xIcmsN.ChildNodes[0].ChildNodes[i].Name)
                                {
                                    case "orig":
                                        {
                                            objIcms40.Orig = xIcmsN.GetElementsByTagName("orig")[0].InnerText;
                                        }
                                        break;
                                    case "CST":
                                        {
                                            objIcms40.Cst = xIcmsN.GetElementsByTagName("CST")[0].InnerText;
                                        }
                                        break;
                                }
                            }
                            objIcms.belIcms40 = objIcms40;
                            #endregion
                            break;
                        }
                    case "ICMS51":
                        {
                            #region ICMS51
                            xIcmsN.LoadXml(Xdoc.GetElementsByTagName("ICMS51")[0].OuterXml);
                            belIcms51 objIcms51 = new belIcms51();

                            for (int i = 0; i < xIcmsN.ChildNodes[0].ChildNodes.Count; i++)
                            {
                                switch (xIcmsN.ChildNodes[0].ChildNodes[i].Name)
                                {
                                    case "orig":
                                        {
                                            objIcms51.Orig = xIcmsN.GetElementsByTagName("orig")[0].InnerText;
                                        }
                                        break;
                                    case "CST":
                                        {
                                            objIcms51.Cst = xIcmsN.GetElementsByTagName("CST")[0].InnerText;
                                        }
                                        break;
                                    case "modBC":
                                        {
                                            objIcms51.Modbc = xIcmsN.GetElementsByTagName("modBC")[0].InnerText;
                                        }
                                        break;
                                    case "pRedBC":
                                        {
                                            objIcms51.Predbc = Convert.ToDecimal(xIcmsN.GetElementsByTagName("pRedBC")[0].InnerText.ToString().Replace(".", ","));
                                        }
                                        break;
                                    case "vBC":
                                        {
                                            objIcms51.Vbc = Convert.ToDecimal(xIcmsN.GetElementsByTagName("vBC")[0].InnerText.ToString().Replace(".", ","));
                                        }
                                        break;
                                    case "pICMS":
                                        {
                                            objIcms51.Picms = Convert.ToDecimal(xIcmsN.GetElementsByTagName("pICMS")[0].InnerText.ToString().Replace(".", ","));
                                        }
                                        break;
                                    case "vICMS":
                                        {
                                            objIcms51.Vicms = Convert.ToDecimal(xIcmsN.GetElementsByTagName("vICMS")[0].InnerText.ToString().Replace(".", ","));
                                        }
                                        break;
                                }
                            }
                            objIcms.belIcms51 = objIcms51;
                            #endregion
                            break;
                        }
                    case "ICMS60":
                        {
                            #region ICMS60
                            xIcmsN.LoadXml(Xdoc.GetElementsByTagName("ICMS60")[0].OuterXml);
                            belIcms60 objIcms60 = new belIcms60();

                            for (int i = 0; i < xIcmsN.ChildNodes[0].ChildNodes.Count; i++)
                            {
                                switch (xIcmsN.ChildNodes[0].ChildNodes[i].Name)
                                {
                                    case "orig":
                                        {
                                            objIcms60.Orig = xIcmsN.GetElementsByTagName("orig")[0].InnerText;
                                        }
                                        break;
                                    case "CST":
                                        {
                                            objIcms60.Cst = xIcmsN.GetElementsByTagName("CST")[0].InnerText;
                                        }
                                        break;
                                    case "vBCSTRet":
                                        {
                                            objIcms60.Vbcstret = Convert.ToDecimal(xIcmsN.GetElementsByTagName("vBCSTRet")[0].InnerText.ToString().Replace(".", ","));
                                        }
                                        break;
                                    case "vICMSSTRet":
                                        {
                                            objIcms60.Vicmsstret = Convert.ToDecimal(xIcmsN.GetElementsByTagName("vICMSSTRet")[0].InnerText.ToString().Replace(".", ","));
                                        }
                                        break;
                                }
                            }
                            objIcms.belIcms60 = objIcms60;
                            #endregion
                            break;
                        }
                    case "ICMS70":
                        {
                            #region ICMS70
                            xIcmsN.LoadXml(Xdoc.GetElementsByTagName("ICMS70")[0].OuterXml);
                            belIcms70 objIcms70 = new belIcms70();

                            for (int i = 0; i < xIcmsN.ChildNodes[0].ChildNodes.Count; i++)
                            {
                                switch (xIcmsN.ChildNodes[0].ChildNodes[i].Name)
                                {
                                    case "orig":
                                        {
                                            objIcms70.Orig = xIcmsN.GetElementsByTagName("orig")[0].InnerText;
                                        }
                                        break;
                                    case "CST":
                                        {
                                            objIcms70.Cst = xIcmsN.GetElementsByTagName("CST")[0].InnerText;
                                        }
                                        break;
                                    case "modBC":
                                        {
                                            objIcms70.Modbc = xIcmsN.GetElementsByTagName("modBC")[0].InnerText;
                                        }
                                        break;
                                    case "pRedBC":
                                        {
                                            objIcms70.Predbc = Convert.ToDecimal(xIcmsN.GetElementsByTagName("pRedBC")[0].InnerText.ToString().Replace(".", ","));
                                        }
                                        break;
                                    case "vBC":
                                        {
                                            objIcms70.Vbc = Convert.ToDecimal(xIcmsN.GetElementsByTagName("vBC")[0].InnerText.ToString().Replace(".", ","));
                                        }
                                        break;
                                    case "pICMS":
                                        {
                                            objIcms70.Picms = Convert.ToDecimal(xIcmsN.GetElementsByTagName("pICMS")[0].InnerText.ToString().Replace(".", ","));
                                        }
                                        break;
                                    case "vICMS":
                                        {
                                            objIcms70.Vicms = Convert.ToDecimal(xIcmsN.GetElementsByTagName("vICMS")[0].InnerText.ToString().Replace(".", ","));
                                        }
                                        break;
                                    case "modBCST":
                                        {
                                            objIcms70.Modbcst = Convert.ToDecimal(xIcmsN.GetElementsByTagName("modBCST")[0].InnerText.ToString().Replace(".", ","));
                                        }
                                        break;
                                    case "pMVAST":
                                        {
                                            objIcms70.Pmvast = Convert.ToDecimal(xIcmsN.GetElementsByTagName("pMVAST")[0].InnerText.ToString().Replace(".", ","));
                                        }
                                        break;
                                    case "pRedBCST":
                                        {

                                            objIcms70.Predbcst = Convert.ToDecimal(xIcmsN.GetElementsByTagName("pRedBCST")[0].InnerText.ToString().Replace(".", ","));
                                        }
                                        break;
                                    case "vBCST":
                                        {
                                            objIcms70.Vbcst = Convert.ToDecimal(xIcmsN.GetElementsByTagName("vBCST")[0].InnerText.ToString().Replace(".", ","));
                                        }
                                        break;
                                    case "pICMSST":
                                        {
                                            objIcms70.Picmsst = Convert.ToDecimal(xIcmsN.GetElementsByTagName("pICMSST")[0].InnerText.ToString().Replace(".", ","));
                                        }
                                        break;
                                    case "vICMSST":
                                        {
                                            objIcms70.Vicmsst = Convert.ToDecimal(xIcmsN.GetElementsByTagName("vICMSST")[0].InnerText.ToString().Replace(".", ","));
                                        }
                                        break;
                                }
                            }
                            objIcms.belIcms70 = objIcms70;
                            #endregion
                            break;

                        }
                    case "ICMS90":
                        {
                            #region ICMS90
                            xIcmsN.LoadXml(Xdoc.GetElementsByTagName("ICMS90")[0].OuterXml);
                            belIcms90 objICms90 = new belIcms90();

                            for (int i = 0; i < xIcmsN.ChildNodes[0].ChildNodes.Count; i++)
                            {
                                switch (xIcmsN.ChildNodes[0].ChildNodes[i].Name)
                                {
                                    case "orig":
                                        {
                                            objICms90.Orig = xIcmsN.GetElementsByTagName("orig")[0].InnerText;
                                        }
                                        break;
                                    case "CST":
                                        {
                                            objICms90.Cst = xIcmsN.GetElementsByTagName("CST")[0].InnerText;
                                        }
                                        break;
                                    case "modBC":
                                        {
                                            objICms90.Modbc = xIcmsN.GetElementsByTagName("modBC")[0].InnerText;
                                        }
                                        break;
                                    case "vBC":
                                        {
                                            objICms90.Vbc = Convert.ToDecimal(xIcmsN.GetElementsByTagName("vBC")[0].InnerText.ToString().Replace(".", ","));
                                        }
                                        break;
                                    case "pRedBC":
                                        {
                                            objICms90.Predbc = Convert.ToDecimal(xIcmsN.GetElementsByTagName("pRedBC")[0].InnerText.ToString().Replace(".", ","));
                                        }
                                        break;
                                    case "pICMS":
                                        {
                                            objICms90.Picms = Convert.ToDecimal(xIcmsN.GetElementsByTagName("pICMS")[0].InnerText.ToString().Replace(".", ","));
                                        }
                                        break;
                                    case "vICMS":
                                        {
                                            objICms90.Vicms = Convert.ToDecimal(xIcmsN.GetElementsByTagName("vICMS")[0].InnerText.ToString().Replace(".", ","));
                                        }
                                        break;
                                    case "modBCST":
                                        {
                                            objICms90.Modbcst = Convert.ToDecimal(xIcmsN.GetElementsByTagName("modBCST")[0].InnerText.ToString().Replace(".", ","));
                                        }
                                        break;
                                    case "pMVAST":
                                        {
                                            objICms90.Pmvast = Convert.ToDecimal(xIcmsN.GetElementsByTagName("pMVAST")[0].InnerText.ToString().Replace(".", ","));
                                        }
                                        break;
                                    case "pRedBCST":
                                        {
                                            objICms90.Predbcst = Convert.ToDecimal(xIcmsN.GetElementsByTagName("pRedBCST")[0].InnerText.ToString().Replace(".", ","));
                                        }
                                        break;
                                    case "vBCST":
                                        {
                                            objICms90.Vbcst = Convert.ToDecimal(xIcmsN.GetElementsByTagName("vBCST")[0].InnerText.ToString().Replace(".", ","));
                                        }
                                        break;
                                    case "pICMSST":
                                        {

                                            objICms90.Picmsst = Convert.ToDecimal(xIcmsN.GetElementsByTagName("pICMSST")[0].InnerText.ToString().Replace(".", ","));
                                        }
                                        break;
                                    case "vICMSST":
                                        {
                                            objICms90.Vicmsst = Convert.ToDecimal(xIcmsN.GetElementsByTagName("vICMSST")[0].InnerText.ToString().Replace(".", ","));
                                        }
                                        break;
                                }
                            }
                            objIcms.belIcms90 = objICms90;
                            #endregion
                            break;
                        }
                    case "ICMSSN101":
                        {
                            #region ICMSSN101
                            xIcmsN.LoadXml(Xdoc.GetElementsByTagName("ICMSSN101")[0].OuterXml);
                            belICMSSN101 objICms101 = new belICMSSN101();

                            for (int i = 0; i < xIcmsN.ChildNodes[0].ChildNodes.Count; i++)
                            {
                                switch (xIcmsN.ChildNodes[0].ChildNodes[i].Name)
                                {
                                    case "orig":
                                        {
                                            objICms101.orig = xIcmsN.GetElementsByTagName("orig")[0].InnerText;
                                        }
                                        break;
                                    case "CSOSN":
                                        {
                                            objICms101.CSOSN = xIcmsN.GetElementsByTagName("CSOSN")[0].InnerText;
                                        }
                                        break;
                                    case "pCredSN":
                                        {
                                            objICms101.pCredSN = Convert.ToDecimal(xIcmsN.GetElementsByTagName("pCredSN")[0].InnerText.Replace(".", ","));
                                        }
                                        break;
                                    case "vCredICMSSN":
                                        {
                                            objICms101.vCredICMSSN = Convert.ToDecimal(xIcmsN.GetElementsByTagName("vCredICMSSN")[0].InnerText.Replace(".", ","));
                                        }
                                        break;
                                }
                                objIcms.belICMSSN101 = objICms101;
                            }

                            #endregion
                            break;
                        }
                    case "ICMSSN102":
                        {
                            #region ICMSSN102
                            xIcmsN.LoadXml(Xdoc.GetElementsByTagName("ICMSSN102")[0].OuterXml);
                            belICMSSN102 objICms102 = new belICMSSN102();

                            for (int i = 0; i < xIcmsN.ChildNodes[0].ChildNodes.Count; i++)
                            {
                                switch (xIcmsN.ChildNodes[0].ChildNodes[i].Name)
                                {
                                    case "orig":
                                        {
                                            objICms102.orig = xIcmsN.GetElementsByTagName("orig")[0].InnerText;
                                        }
                                        break;
                                    case "CSOSN":
                                        {
                                            objICms102.CSOSN = xIcmsN.GetElementsByTagName("CSOSN")[0].InnerText;
                                        }
                                        break;
                                }
                                objIcms.belICMSSN102 = objICms102;
                            }

                            #endregion
                            break;
                        }
                    case "ICMSSN201":
                        {
                            #region ICMSSN201
                            xIcmsN.LoadXml(Xdoc.GetElementsByTagName("ICMSSN201")[0].OuterXml);
                            belICMSSN201 objICms201 = new belICMSSN201();

                            for (int i = 0; i < xIcmsN.ChildNodes[0].ChildNodes.Count; i++)
                            {
                                switch (xIcmsN.ChildNodes[0].ChildNodes[i].Name)
                                {
                                    case "orig":
                                        {
                                            objICms201.orig = xIcmsN.GetElementsByTagName("orig")[0].InnerText;
                                        }
                                        break;
                                    case "CSOSN":
                                        {
                                            objICms201.CSOSN = xIcmsN.GetElementsByTagName("CSOSN")[0].InnerText;
                                        }
                                        break;
                                    case "modBCST":
                                        {
                                            objICms201.modBCST = Convert.ToInt32(xIcmsN.GetElementsByTagName("modBCST")[0].InnerText);
                                        }
                                        break;
                                    case "pMVAST":
                                        {
                                            objICms201.pMVAST = Convert.ToDecimal(xIcmsN.GetElementsByTagName("pMVAST")[0].InnerText.Replace(".", ","));
                                        }
                                        break;
                                    case "pRedBCST":
                                        {
                                            objICms201.pRedBCST = Convert.ToDecimal(xIcmsN.GetElementsByTagName("pRedBCST")[0].InnerText.Replace(".", ","));
                                        }
                                        break;
                                    case "vBCST":
                                        {
                                            objICms201.vBCST = Convert.ToDecimal(xIcmsN.GetElementsByTagName("vBCST")[0].InnerText.Replace(".", ","));
                                        }
                                        break;
                                    case "pICMSST":
                                        {
                                            objICms201.pICMSST = Convert.ToDecimal(xIcmsN.GetElementsByTagName("pICMSST")[0].InnerText.Replace(".", ","));
                                        }
                                        break;
                                    case "vICMSST":
                                        {
                                            objICms201.vICMSST = Convert.ToDecimal(xIcmsN.GetElementsByTagName("vICMSST")[0].InnerText.Replace(".", ","));
                                        }
                                        break;
                                    case "pCredSN":
                                        {
                                            objICms201.pCredSN = Convert.ToDecimal(xIcmsN.GetElementsByTagName("pCredSN")[0].InnerText.Replace(".", ","));
                                        }
                                        break;
                                    case "vCredICMSSN":
                                        {
                                            objICms201.vCredICMSSN = Convert.ToDecimal(xIcmsN.GetElementsByTagName("vCredICMSSN")[0].InnerText.Replace(".", ","));
                                        }
                                        break;
                                }
                                objIcms.belICMSSN201 = objICms201;
                            }

                            #endregion
                            break;
                        }
                    case "ICMSSN202":
                        {
                            #region ICMSSN202
                            xIcmsN.LoadXml(Xdoc.GetElementsByTagName("ICMSSN202")[0].OuterXml);
                            belICMSSN201 objICms201 = new belICMSSN201();

                            for (int i = 0; i < xIcmsN.ChildNodes[0].ChildNodes.Count; i++)
                            {
                                switch (xIcmsN.ChildNodes[0].ChildNodes[i].Name)
                                {
                                    case "orig":
                                        {
                                            objICms201.orig = xIcmsN.GetElementsByTagName("orig")[0].InnerText;
                                        }
                                        break;
                                    case "CSOSN":
                                        {
                                            objICms201.CSOSN = xIcmsN.GetElementsByTagName("CSOSN")[0].InnerText;
                                        }
                                        break;
                                    case "modBCST":
                                        {
                                            objICms201.modBCST = Convert.ToInt32(xIcmsN.GetElementsByTagName("modBCST")[0].InnerText);
                                        }
                                        break;
                                    case "pMVAST":
                                        {
                                            objICms201.pMVAST = Convert.ToDecimal(xIcmsN.GetElementsByTagName("pMVAST")[0].InnerText.Replace(".", ","));
                                        }
                                        break;
                                    case "pRedBCST":
                                        {
                                            objICms201.pRedBCST = Convert.ToDecimal(xIcmsN.GetElementsByTagName("pRedBCST")[0].InnerText.Replace(".", ","));
                                        }
                                        break;
                                    case "vBCST":
                                        {
                                            objICms201.vBCST = Convert.ToDecimal(xIcmsN.GetElementsByTagName("vBCST")[0].InnerText.Replace(".", ","));
                                        }
                                        break;
                                    case "pICMSST":
                                        {
                                            objICms201.pICMSST = Convert.ToDecimal(xIcmsN.GetElementsByTagName("pICMSST")[0].InnerText.Replace(".", ","));
                                        }
                                        break;
                                    case "vICMSST":
                                        {
                                            objICms201.vICMSST = Convert.ToDecimal(xIcmsN.GetElementsByTagName("vICMSST")[0].InnerText.Replace(".", ","));
                                        }
                                        break;
                                }
                                objIcms.belICMSSN201 = objICms201;
                            }

                            #endregion
                            break;
                        }
                    case "ICMSSN500":
                        {
                            #region ICMSSN500
                            xIcmsN.LoadXml(Xdoc.GetElementsByTagName("ICMSSN500")[0].OuterXml);
                            belICMSSN500 objICms500 = new belICMSSN500();

                            for (int i = 0; i < xIcmsN.ChildNodes[0].ChildNodes.Count; i++)
                            {
                                switch (xIcmsN.ChildNodes[0].ChildNodes[i].Name)
                                {
                                    case "orig":
                                        {
                                            objICms500.orig = xIcmsN.GetElementsByTagName("orig")[0].InnerText;
                                        }
                                        break;
                                    case "CSOSN":
                                        {
                                            objICms500.CSOSN = xIcmsN.GetElementsByTagName("CSOSN")[0].InnerText;
                                        }
                                        break;
                                    case "pCredSN":
                                        {
                                            objICms500.vBCSTRet = Convert.ToDecimal(xIcmsN.GetElementsByTagName("vBCSTRet")[0].InnerText.Replace(".", ","));
                                        }
                                        break;
                                    case "vCredICMSSN":
                                        {
                                            objICms500.vICMSSTRet = Convert.ToDecimal(xIcmsN.GetElementsByTagName("vICMSSTRet")[0].InnerText.Replace(".", ","));
                                        }
                                        break;
                                }
                                objIcms.belICMSSN500 = objICms500;
                            }

                            #endregion
                            break;
                        }
                    case "ICMSSN900":
                        {
                            #region ICMSSN900
                            xIcmsN.LoadXml(Xdoc.GetElementsByTagName("ICMSSN900")[0].OuterXml);
                            belICMSSN900 objICms900 = new belICMSSN900();

                            for (int i = 0; i < xIcmsN.ChildNodes[0].ChildNodes.Count; i++)
                            {
                                switch (xIcmsN.ChildNodes[0].ChildNodes[i].Name)
                                {
                                    case "orig":
                                        {
                                            objICms900.orig = xIcmsN.GetElementsByTagName("orig")[0].InnerText;
                                        }
                                        break;
                                    case "CSOSN":
                                        {
                                            objICms900.CSOSN = xIcmsN.GetElementsByTagName("CSOSN")[0].InnerText;
                                        }
                                        break;
                                    case "modBC":
                                        {
                                            objICms900.modBC = Convert.ToInt32(xIcmsN.GetElementsByTagName("modBC")[0].InnerText);
                                        }
                                        break;
                                    case "vBC":
                                        {
                                            objICms900.vBC = Convert.ToDecimal(xIcmsN.GetElementsByTagName("vBC")[0].InnerText.Replace(".", ","));
                                        }
                                        break;
                                    case "pRedBC":
                                        {
                                            objICms900.pRedBC = Convert.ToDecimal(xIcmsN.GetElementsByTagName("pRedBC")[0].InnerText.Replace(".", ","));
                                        }
                                        break;
                                    case "pICMS":
                                        {
                                            objICms900.pICMS = Convert.ToDecimal(xIcmsN.GetElementsByTagName("pICMS")[0].InnerText.Replace(".", ","));
                                        }
                                        break;
                                    case "vICMS":
                                        {
                                            objICms900.vICMS = Convert.ToDecimal(xIcmsN.GetElementsByTagName("vICMS")[0].InnerText.Replace(".", ","));
                                        }
                                        break;
                                    case "modBCST":
                                        {
                                            objICms900.modBCST = Convert.ToInt32(xIcmsN.GetElementsByTagName("modBCST")[0].InnerText);
                                        }
                                        break;
                                    case "pMVAST":
                                        {
                                            objICms900.pMVAST = Convert.ToDecimal(xIcmsN.GetElementsByTagName("pMVAST")[0].InnerText.Replace(".", ","));
                                        }
                                        break;
                                    case "pRedBCST":
                                        {
                                            objICms900.pRedBCST = Convert.ToDecimal(xIcmsN.GetElementsByTagName("pRedBCST")[0].InnerText.Replace(".", ","));
                                        }
                                        break;
                                    case "vBCST":
                                        {
                                            objICms900.vBCST = Convert.ToDecimal(xIcmsN.GetElementsByTagName("vBCST")[0].InnerText.Replace(".", ","));
                                        }
                                        break;
                                    case "pICMSST":
                                        {
                                            objICms900.pICMSST = Convert.ToDecimal(xIcmsN.GetElementsByTagName("pICMSST")[0].InnerText.Replace(".", ","));
                                        }
                                        break;
                                    case "vICMSST":
                                        {
                                            objICms900.vICMSST = Convert.ToDecimal(xIcmsN.GetElementsByTagName("vICMSST")[0].InnerText.Replace(".", ","));
                                        }
                                        break;
                                    case "vBCSTRet":
                                        {
                                            objICms900.vBCSTRet = Convert.ToDecimal(xIcmsN.GetElementsByTagName("vBCSTRet")[0].InnerText.Replace(".", ","));
                                        }
                                        break;
                                    case "vICMSSTRet":
                                        {
                                            objICms900.vICMSSTRet = Convert.ToDecimal(xIcmsN.GetElementsByTagName("vICMSSTRet")[0].InnerText.Replace(".", ","));
                                        }
                                        break;
                                    case "pCredSN":
                                        {
                                            objICms900.pCredSN = Convert.ToDecimal(xIcmsN.GetElementsByTagName("pCredSN")[0].InnerText.Replace(".", ","));
                                        }
                                        break;
                                    case "vCredICMSSN":
                                        {
                                            objICms900.vCredICMSSN = Convert.ToDecimal(xIcmsN.GetElementsByTagName("vCredICMSSN")[0].InnerText.Replace(".", ","));
                                        }
                                        break;
                                }
                                objIcms.belICMSSN900 = objICms900;
                            }

                            #endregion
                            break;
                        }
                }
            }
            catch (Exception ex)
            {

                throw new Exception(string.Format("Erro buscando ICMS.: {0}",
                                    ex.Message));
            }
            return objIcms;
        }

        public belIpi xmlBuscaDetIPI(XmlDocument Xdoc)
        {
            belIpi objIpi = new belIpi();
            XmlDocument xIPI = new XmlDocument();

            if (xDoc.GetElementsByTagName("IPI").Count > 0)
            {


                xIPI.LoadXml(xDoc.GetElementsByTagName("IPI")[0].OuterXml);

                if (xIPI.GetElementsByTagName("clEnq").Count > 0)
                {
                    objIpi.Clenq = xIPI.GetElementsByTagName("clEnq")[0].InnerText;
                }

                if (xIPI.GetElementsByTagName("CNPJProd").Count > 0)
                {
                    objIpi.Cnpjprod = xIPI.GetElementsByTagName("CNPJProd")[0].InnerText;
                }

                if (xIPI.GetElementsByTagName("cSelo").Count > 0)
                {
                    objIpi.Cselo = xIPI.GetElementsByTagName("cSelo")[0].InnerText;
                }
                if (xIPI.GetElementsByTagName("qSelo").Count > 0)
                {
                    objIpi.Qselo = xIPI.GetElementsByTagName("qSelo")[0].InnerText;
                }

                if (xIPI.GetElementsByTagName("cEnq").Count > 0)
                {
                    objIpi.Cenq = xIPI.GetElementsByTagName("cEnq")[0].InnerText;
                }

            }
            XmlDocument xIpiN = new XmlDocument();

            try
            {
                if (Xdoc.GetElementsByTagName("IPI").Count > 0)
                {


                    switch (Xdoc.GetElementsByTagName("IPI")[0].LastChild.Name)
                    {
                        case "IPITrib":
                            {
                                belIpitrib objIpiTrib = new belIpitrib();
                                xIpiN.LoadXml(Xdoc.GetElementsByTagName("IPITrib")[0].OuterXml);

                                if (xIpiN.GetElementsByTagName("CST").Count > 0)
                                {
                                    objIpiTrib.Cst = xIpiN.GetElementsByTagName("CST")[0].InnerText;
                                }

                                if (xIpiN.GetElementsByTagName("vBC").Count > 0)
                                {
                                    objIpiTrib.Vbc = Convert.ToDecimal(xIpiN.GetElementsByTagName("vBC")[0].InnerText.ToString().Replace(".", ","));
                                }

                                if (xIpiN.GetElementsByTagName("qUnid").Count > 0)
                                {
                                    objIpiTrib.Qunid =Convert.ToDecimal(xIpiN.GetElementsByTagName("qUnid")[0].InnerText.ToString().Replace(".",","));
                                }

                                if (xIpiN.GetElementsByTagName("vUnid").Count > 0)
                                {
                                    objIpiTrib.Vunid = Convert.ToDecimal(xIpiN.GetElementsByTagName("vUnid")[0].InnerText.ToString().Replace(".", ","));
                                }

                                if (xIpiN.GetElementsByTagName("pIPI").Count > 0)
                                {
                                    objIpiTrib.Vipi = Convert.ToDecimal(xIpiN.GetElementsByTagName("vIPI")[0].InnerText.ToString().Replace(".", ","));

                                }


                                objIpi.belIpitrib = objIpiTrib;
                                break;
                            }
                        case "IPINT":
                            {
                                belIpint objIpiNT = new belIpint();

                                if (Xdoc.GetElementsByTagName("IPINT").Count > 0)
                                {
                                    xIpiN.LoadXml(Xdoc.GetElementsByTagName("IPINT")[0].OuterXml);

                                    objIpiNT.Cst = xIpiN.GetElementsByTagName("CST")[0].InnerText;
                                }
                                objIpi.belIpint = objIpiNT;
                                break;
                            }

                    }
                }
            }
            catch (Exception ex)
            {

                throw new Exception(string.Format("Erro buscando IPI.: {0}",
                                    ex.Message));
            }
            return objIpi;
        }

        public belIi xmlBuscaDetII(XmlDocument Xdoc)
        {
            belIi objII = new belIi();
            try
            {

                XmlDocument xII = new XmlDocument();

                if (xDoc.GetElementsByTagName("II").Count > 0)
                {

                    xII.LoadXml(xDoc.GetElementsByTagName("II")[0].OuterXml);

                    if (xII.GetElementsByTagName("vBC").Count > 0)
                    {
                        objII.Vbc = Convert.ToDecimal(xII.GetElementsByTagName("vBC")[0].InnerText.ToString().Replace(".", ","));
                    }

                    if (xII.GetElementsByTagName("vDespAdu").Count > 0)
                    {
                        objII.Vdespadu = Convert.ToDecimal(xII.GetElementsByTagName("vDespAdu")[0].InnerText.ToString().Replace(".", ","));
                    }

                    if (xII.GetElementsByTagName("vII").Count > 0)
                    {
                        objII.Vii = Convert.ToDecimal(xII.GetElementsByTagName("vII")[0].InnerText.ToString().Replace(".", ","));
                    }

                    if (xII.GetElementsByTagName("vIOF").Count > 0)
                    {
                        objII.Viof = Convert.ToDecimal(xII.GetElementsByTagName("vIOF")[0].InnerText.ToString().Replace(".", ","));
                    }
                }
            }
            catch (Exception ex)
            {

                throw new Exception(string.Format("Erro buscando II.: {0}",
                                    ex.Message));
            }
            return objII;
        }

        public belPis xmlBuscaDetPis(XmlDocument Xdoc)
        {
            belPis objPis = new belPis();
            try
            {

                XmlDocument xPisN = new XmlDocument();


                switch (Xdoc.GetElementsByTagName("PIS")[0].FirstChild.Name)
                {
                    case "PISAliq":
                        {
                            belPisaliq objPisAliq = new belPisaliq();
                            if (Xdoc.GetElementsByTagName("PISAliq").Count > 0)
                            {
                                xPisN.LoadXml(Xdoc.GetElementsByTagName("PISAliq")[0].OuterXml);

                                if (xPisN.GetElementsByTagName("CST").Count > 0)
                                {
                                    objPisAliq.Cst = xPisN.GetElementsByTagName("CST")[0].InnerText;
                                }

                                if (xPisN.GetElementsByTagName("vBC").Count > 0)
                                {
                                    objPisAliq.Vbc = Convert.ToDecimal(xPisN.GetElementsByTagName("vBC")[0].InnerText.ToString().Replace(".", ","));
                                }

                                if (xPisN.GetElementsByTagName("pPIS").Count > 0)
                                {
                                    objPisAliq.Ppis = Convert.ToDecimal(xPisN.GetElementsByTagName("pPIS")[0].InnerText.ToString().Replace(".", ","));
                                }

                                if (xPisN.GetElementsByTagName("vPIS").Count > 0)
                                {
                                    objPisAliq.Vpis = Convert.ToDecimal(xPisN.GetElementsByTagName("vPIS")[0].InnerText.ToString().Replace(".", ","));
                                }
                            }

                            objPis.belPisaliq = objPisAliq;
                            break;
                        }
                    case "PISQtde":
                        {
                            belPisqtde objPisQtde = new belPisqtde();
                            if (Xdoc.GetElementsByTagName("PISQtde").Count > 0)
                            {
                                xPisN.LoadXml(Xdoc.GetElementsByTagName("PISQtde")[0].OuterXml);

                                if (xPisN.GetElementsByTagName("CST").Count > 0)
                                {
                                    objPisQtde.Cst = xPisN.GetElementsByTagName("CST")[0].InnerText;
                                }

                                if (xPisN.GetElementsByTagName("qBCProd").Count > 0)
                                {
                                    objPisQtde.Qbcprod = Convert.ToDecimal(xPisN.GetElementsByTagName("qBCProd")[0].InnerText.ToString().Replace(".", ","));
                                }

                                if (xPisN.GetElementsByTagName("vAliqProd").Count > 0)
                                {
                                    objPisQtde.Valiqprod = Convert.ToDecimal(xPisN.GetElementsByTagName("vAliqProd")[0].InnerText.ToString().Replace(".", ","));
                                }

                                if (xPisN.GetElementsByTagName("vPIS").Count > 0)
                                {
                                    objPisQtde.Vpis = Convert.ToDecimal(xPisN.GetElementsByTagName("vPIS")[0].InnerText.ToString().Replace(".", ","));
                                }

                            }

                            objPis.belPisqtde = objPisQtde;
                            break;

                        }
                    case "PISNT":
                        {
                            belPisnt objPisNT = new belPisnt();

                            xPisN.LoadXml(Xdoc.GetElementsByTagName("PISNT")[0].OuterXml);

                            objPisNT.Cst = xPisN.GetElementsByTagName("CST")[0].InnerText;

                            objPis.belPisnt = objPisNT;
                            break;
                        }
                    case "PISOutr":
                        {
                            belPisoutr objPisOutr = new belPisoutr();

                            xPisN.LoadXml(Xdoc.GetElementsByTagName("PISOutr")[0].OuterXml);

                            if (xPisN.GetElementsByTagName("CST").Count > 0)
                            {
                                objPisOutr.Cst = xPisN.GetElementsByTagName("CST")[0].InnerText;
                            }

                            if (xPisN.GetElementsByTagName("vBC").Count > 0)
                            {
                                objPisOutr.Vbc = Convert.ToDecimal(xPisN.GetElementsByTagName("vBC")[0].InnerText.ToString().Replace(".", ","));
                            }

                            if (xPisN.GetElementsByTagName("pPIS").Count > 0)
                            {
                                objPisOutr.Ppis = Convert.ToDecimal(xPisN.GetElementsByTagName("pPIS")[0].InnerText.ToString().Replace(".", ","));
                            }

                            if (xPisN.GetElementsByTagName("qBCProd").Count > 0)
                            {
                                objPisOutr.Qbcprod = Convert.ToDecimal(xPisN.GetElementsByTagName("qBCProd")[0].InnerText.ToString().Replace(".", ","));
                            }

                            if (xPisN.GetElementsByTagName("vAliqProd").Count > 0)
                            {
                                objPisOutr.Valiqprod = Convert.ToDecimal(xPisN.GetElementsByTagName("vAliqProd")[0].InnerText.ToString().Replace(".", ","));
                            }

                            if (xPisN.GetElementsByTagName("vPis").Count > 0)
                            {
                                objPisOutr.Vpis = Convert.ToDecimal(xPisN.GetElementsByTagName("vPis")[0].InnerText.ToString().Replace(".", ","));
                            }

                            objPis.belPisoutr = objPisOutr;
                            break;
                        }
                    case "PISST":
                        {
                            belPisst objPisST = new belPisst();

                            xPisN.LoadXml(Xdoc.GetElementsByTagName("PISST")[0].OuterXml);

                            if (xPisN.GetElementsByTagName("vBC").Count > 0)
                            {
                                objPisST.Vbc = Convert.ToDecimal(xPisN.GetElementsByTagName("vBC")[0].InnerText.ToString().Replace(".", ","));
                            }

                            if (xPisN.GetElementsByTagName("pPIS").Count > 0)
                            {
                                objPisST.Ppis = Convert.ToDecimal(xPisN.GetElementsByTagName("pPIS")[0].InnerText.ToString().Replace(".", ","));
                            }

                            if (xPisN.GetElementsByTagName("qBCProd").Count > 0)
                            {
                                objPisST.Qbcprod = Convert.ToDecimal(xPisN.GetElementsByTagName("qBCProd")[0].InnerText.ToString().Replace(".", ","));
                            }

                            if (xPisN.GetElementsByTagName("vAliqProd").Count > 0)
                            {
                                objPisST.Valiqprod = Convert.ToDecimal(xPisN.GetElementsByTagName("vAliqProd")[0].InnerText.ToString().Replace(".", ","));
                            }

                            if (xPisN.GetElementsByTagName("vPIS").Count > 0)
                            {
                                objPisST.Vpis = Convert.ToDecimal(xPisN.GetElementsByTagName("vPIS")[0].InnerText.ToString().Replace(".", ","));
                            }

                            objPis.belPisst = objPisST;
                            break;
                        }
                }


            }
            catch (Exception ex)
            {

                throw new Exception(string.Format("Erro buscando PIS.: {0}",
                                    ex.Message));
            }
            return objPis;
        }

        public belCofins xmlBuscaDetCofins(XmlDocument Xdoc)
        {
            belCofins objCofins = new belCofins();
            try
            {

                XmlDocument xCofinsN = new XmlDocument();


                switch (Xdoc.GetElementsByTagName("COFINS")[0].FirstChild.Name)
                {
                    case "COFINSAliq":
                        {
                            belCofinsaliq objCofinsAliq = new belCofinsaliq();

                            xCofinsN.LoadXml(Xdoc.GetElementsByTagName("COFINSAliq")[0].OuterXml);

                            if (xCofinsN.GetElementsByTagName("CST").Count > 0)
                            {
                                objCofinsAliq.Cst = xCofinsN.GetElementsByTagName("CST")[0].InnerText;
                            }

                            if (xCofinsN.GetElementsByTagName("vBC").Count > 0)
                            {
                                objCofinsAliq.Vbc = Convert.ToDecimal(xCofinsN.GetElementsByTagName("vBC")[0].InnerText.ToString().Replace(".", ","));
                            }

                            if (xCofinsN.GetElementsByTagName("pCOFINS").Count > 0)
                            {
                                objCofinsAliq.Pcofins = Convert.ToDecimal(xCofinsN.GetElementsByTagName("pCOFINS")[0].InnerText.ToString().Replace(".", ","));
                            }

                            if (xCofinsN.GetElementsByTagName("vCOFINS").Count > 0)
                            {
                                objCofinsAliq.Vcofins = Convert.ToDecimal(xCofinsN.GetElementsByTagName("vCOFINS")[0].InnerText.ToString().Replace(".", ","));
                            }


                            objCofins.belCofinsaliq = objCofinsAliq;
                            break;
                        }
                    case "COFINSQtde":
                        {
                            belCofinsqtde objCofinsQtde = new belCofinsqtde();

                            xCofinsN.LoadXml(Xdoc.GetElementsByTagName("COFINSQtde")[0].OuterXml);

                            if (xCofinsN.GetElementsByTagName("CST").Count > 0)
                            {
                                objCofinsQtde.Cst = xCofinsN.GetElementsByTagName("CST")[0].InnerText;
                            }

                            if (xCofinsN.GetElementsByTagName("qBCProd").Count > 0)
                            {
                                objCofinsQtde.Qbcprod = Convert.ToDecimal(xCofinsN.GetElementsByTagName("qBCProd")[0].InnerText.ToString().Replace(".", ","));
                            }

                            if (xCofinsN.GetElementsByTagName("vAliqProd").Count > 0)
                            {
                                objCofinsQtde.Valiqprod = Convert.ToDecimal(xCofinsN.GetElementsByTagName("vAliqProd")[0].InnerText.ToString().Replace(".", ","));
                            }

                            if (xCofinsN.GetElementsByTagName("vCOFINS").Count > 0)
                            {
                                objCofinsQtde.Vcofins = Convert.ToDecimal(xCofinsN.GetElementsByTagName("vCOFINS")[0].InnerText.ToString().Replace(".", ","));
                            }


                            objCofins.belCofinsqtde = objCofinsQtde;

                            break;
                        }
                    case "COFINSNT":
                        {
                            belCofinsnt objCofinsNT = new belCofinsnt();

                            xCofinsN.LoadXml(Xdoc.GetElementsByTagName("COFINSNT")[0].OuterXml);

                            objCofinsNT.Cst = xCofinsN.GetElementsByTagName("CST")[0].InnerText;
                            objCofins.belCofinsnt = objCofinsNT;
                            break;
                        }
                    case "COFINSOutr":
                        {
                            belCofinsoutr objCofinsOutr = new belCofinsoutr();

                            xCofinsN.LoadXml(Xdoc.GetElementsByTagName("COFINSOutr")[0].OuterXml);

                            if (xCofinsN.GetElementsByTagName("CST").Count > 0)
                            {
                                objCofinsOutr.Cst = xCofinsN.GetElementsByTagName("CST")[0].InnerText;
                            }

                            if (xCofinsN.GetElementsByTagName("vBC").Count > 0)
                            {
                                objCofinsOutr.Vbc = Convert.ToDecimal(xCofinsN.GetElementsByTagName("vBC")[0].InnerText.ToString().Replace(".", ","));
                            }

                            if (xCofinsN.GetElementsByTagName("pCOFINS").Count > 0)
                            {
                                objCofinsOutr.Pcofins = Convert.ToDecimal(xCofinsN.GetElementsByTagName("pCOFINS")[0].InnerText.ToString().Replace(".", ","));
                            }

                            if (xCofinsN.GetElementsByTagName("qBCProd").Count > 0)
                            {
                                objCofinsOutr.Qbcprod = Convert.ToDecimal(xCofinsN.GetElementsByTagName("qBCProd")[0].InnerText.ToString().Replace(".", ","));
                            }

                            if (xCofinsN.GetElementsByTagName("vAliqProd").Count > 0)
                            {
                                objCofinsOutr.Valiqprod = Convert.ToDecimal(xCofinsN.GetElementsByTagName("vAliqProd")[0].InnerText.ToString().Replace(".", ","));
                            }

                            if (xCofinsN.GetElementsByTagName("vCOFINS").Count > 0)
                            {
                                objCofinsOutr.Vcofins = Convert.ToDecimal(xCofinsN.GetElementsByTagName("vCOFINS")[0].InnerText.ToString().Replace(".", ","));
                            }


                            objCofins.belCofinsoutr = objCofinsOutr;
                            break;
                        }
                    case "COFINSST":
                        {
                            belCofinsst objCofinsST = new belCofinsst();

                            xCofinsN.LoadXml(Xdoc.GetElementsByTagName("COFINSST")[0].OuterXml);

                            if (xCofinsN.GetElementsByTagName("vBC").Count > 0)
                            {
                                objCofinsST.Vbc = Convert.ToDecimal(xCofinsN.GetElementsByTagName("vBC")[0].InnerText.ToString().Replace(".", ","));
                            }

                            if (xCofinsN.GetElementsByTagName("pCOFINS").Count > 0)
                            {
                                objCofinsST.Pcofins = Convert.ToDecimal(xCofinsN.GetElementsByTagName("pCOFINS")[0].InnerText.ToString().Replace(".", ","));
                            }

                            if (xCofinsN.GetElementsByTagName("qBCProd").Count > 0)
                            {
                                objCofinsST.Qbcprod = Convert.ToDecimal(xCofinsN.GetElementsByTagName("qBCProd")[0].InnerText.ToString().Replace(".", ","));
                            }

                            if (xCofinsN.GetElementsByTagName("vAliqProd").Count > 0)
                            {
                                objCofinsST.Valiqprod = Convert.ToDecimal(xCofinsN.GetElementsByTagName("vAliqProd")[0].InnerText.ToString().Replace(".", ","));
                            }

                            if (xCofinsN.GetElementsByTagName("vCOFINS").Count > 0)
                            {
                                objCofinsST.Vcofins = Convert.ToDecimal(xCofinsN.GetElementsByTagName("vCOFINS")[0].InnerText.ToString().Replace(".", ","));
                            }

                            objCofins.belCofinsst = objCofinsST;
                            break;
                        }


                }


            }
            catch (Exception ex)
            {

                throw new Exception(string.Format("Erro buscando COFINS.: {0}",
                                    ex.Message));
            }
            return objCofins;
        }

        public belIss xmlBuscaDetIssqn(XmlDocument Xdoc)
        {
            belIss objIss = new belIss();
            try
            {

                XmlDocument xIss = new XmlDocument();

                if (xDoc.GetElementsByTagName("ISSQN").Count > 0)
                {
                    xIss.LoadXml(xDoc.GetElementsByTagName("ISSQN")[0].OuterXml);

                    if (xIss.GetElementsByTagName("vBC").Count > 0)
                    {
                        objIss.Vbc = Convert.ToDecimal(xIss.GetElementsByTagName("vBC")[0].InnerText.ToString().Replace(".", ","));
                    }

                    if (xIss.GetElementsByTagName("vAliq").Count > 0)
                    {
                        objIss.Valiq = Convert.ToDecimal(xIss.GetElementsByTagName("vAliq")[0].InnerText.ToString().Replace(".", ","));
                    }

                    if (xIss.GetElementsByTagName("vISSQN").Count > 0)
                    {
                        objIss.Vissqn = Convert.ToDecimal(xIss.GetElementsByTagName("vISSQN")[0].InnerText.ToString().Replace(".", ","));
                    }

                    if (xIss.GetElementsByTagName("cMunFG").Count > 0)
                    {
                        objIss.Cmunfg = xIss.GetElementsByTagName("cMunFG")[0].InnerText;
                    }

                    if (xIss.GetElementsByTagName("ListServ").Count > 0)
                    {
                        objIss.Clistserv = Convert.ToInt64(xIss.GetElementsByTagName("ListServ")[0].InnerText);
                    }
                }

            }
            catch (Exception ex)
            {

                throw new Exception(string.Format("Erro buscando ISSQN.: {0}",
                                    ex.Message));
            }
            return objIss;
        }




        public belImportaXmlNFe(string sXML)
        {
            try
            {
                XDoc.Load(@sXML);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possivel abrir o Xml:" + sXML + ex.Message);

            }

        }

        public belInfAdic xmlBuscaInfAdic()
        {
            belInfAdic objInfAdic = new belInfAdic();
            XmlDocument xInfAdic = new XmlDocument();
            try
            {
                if (xDoc.GetElementsByTagName("infAdic").Count > 0)
                {
                    xInfAdic.LoadXml(xDoc.GetElementsByTagName("infAdic")[0].OuterXml);

                    if (xInfAdic.GetElementsByTagName("infAdFisco").Count > 0)
                    {
                        objInfAdic.Infadfisco = xInfAdic.GetElementsByTagName("infAdFisco")[0].InnerText;
                    }

                    if (xInfAdic.GetElementsByTagName("infCpl").Count > 0)
                    {
                        objInfAdic.Infcpl = xInfAdic.GetElementsByTagName("infCpl")[0].InnerText;
                    }

                    if (xInfAdic.GetElementsByTagName("obsCont").Count > 0)
                    {
                        XmlDocument xobsCont = new XmlDocument();
                        belObsCont objObsCount = new belObsCont();

                        xobsCont.LoadXml(xInfAdic.GetElementsByTagName("obsCont")[0].OuterXml);

                        if (xobsCont.GetElementsByTagName("xCampo").Count > 0)
                        {
                            objObsCount.Xcampo = xobsCont.GetElementsByTagName("xCampo")[0].InnerText;
                        }

                        if (xobsCont.GetElementsByTagName("xTexto").Count > 0)
                        {
                            objObsCount.Xtexto = xobsCont.GetElementsByTagName("xTexto")[0].InnerText;
                        }

                        objInfAdic.belObsCont = objObsCount;

                    }

                    if (xInfAdic.GetElementsByTagName("obsFisco").Count > 0)
                    {
                        XmlDocument xobsFisco = new XmlDocument();
                        belObsCont objObsFisco = new belObsCont();

                        xobsFisco.LoadXml(xInfAdic.GetElementsByTagName("obsFisco")[0].OuterXml);

                        if (xobsFisco.GetElementsByTagName("xCampo").Count > 0)
                        {
                            objObsFisco.Xcampo = xobsFisco.GetElementsByTagName("xCampo")[0].InnerText;
                        }

                        if (xobsFisco.GetElementsByTagName("xTexto").Count > 0)
                        {
                            objObsFisco.Xtexto = xobsFisco.GetElementsByTagName("xTexto")[0].InnerText;
                        }

                        objInfAdic.belObsCont = objObsFisco;

                    }

                    if (xInfAdic.GetElementsByTagName("procRef").Count > 0)
                    {
                        XmlDocument xProcRef = new XmlDocument();
                        belProcRef objProcRef = new belProcRef();

                        xProcRef.LoadXml(xInfAdic.GetElementsByTagName("procRef")[0].OuterXml);

                        if (xProcRef.GetElementsByTagName("nProc").Count > 0)
                        {
                            objProcRef.Nproc = xProcRef.GetElementsByTagName("nProc")[0].InnerText;
                        }

                        if (xProcRef.GetElementsByTagName("indProc").Count > 0)
                        {
                            objProcRef.Indproc = xProcRef.GetElementsByTagName("indProc")[0].InnerText;
                        }

                        objInfAdic.belProcRef = objProcRef;

                    }
                }

            }
            catch (Exception ex)
            {

                throw new Exception(string.Format("Problemas lendo a Tag infAdic, Erro.: {0}",
                                                  ex.Message));
            }
            return objInfAdic;
        }



        public belExporta xmlBuscaExporta()
        {
            belExporta objExporta = new belExporta();
            XmlDocument xExporta = new XmlDocument();

            try
            {
                if (xDoc.GetElementsByTagName("exporta").Count > 0)
                {
                    xExporta.LoadXml(xDoc.GetElementsByTagName("exporta")[0].OuterXml);

                    if (xExporta.GetElementsByTagName("UFEmbarq").Count > 0)
                    {
                        objExporta.Ufembarq = xExporta.GetElementsByTagName("UFEmbarq")[0].InnerText;
                    }

                    if (xExporta.GetElementsByTagName("xLocEmbarq").Count > 0)
                    {
                        objExporta.Xlocembarq = xExporta.GetElementsByTagName("xLocEmbarq")[0].InnerText;
                    }
                }

            }
            catch (Exception ex)
            {

                throw new Exception(string.Format("Problemas lendo a Tag Exporta, Erro.: {0}",
                                                  ex.Message));
            }
            return objExporta;
        }

        public belCompra xmlBuscaCompra()
        {
            belCompra objCompra = new belCompra();
            XmlDocument xCompra = new XmlDocument();

            try
            {
                if (xDoc.GetElementsByTagName("compra").Count > 0)
                {
                    xCompra.LoadXml(xDoc.GetElementsByTagName("compra")[0].OuterXml);

                    if (xCompra.GetElementsByTagName("xNEmp").Count > 0)
                    {
                        objCompra.Xnemp = xCompra.GetElementsByTagName("xNEmp")[0].InnerText;
                    }

                    if (xCompra.GetElementsByTagName("xPed").Count > 0)
                    {
                        objCompra.Xped = xCompra.GetElementsByTagName("xPed")[0].InnerText;
                    }

                    if (xCompra.GetElementsByTagName("xCont").Count > 0)
                    {
                        objCompra.Xcont = xCompra.GetElementsByTagName("xCont")[0].InnerText;
                    }

                }

            }
            catch (Exception ex)
            {

                throw new Exception(string.Format("Problemas lendo a Tag Compra, Erro.: {0}",
                                                  ex.Message));
            }
            return objCompra;
        }



        public belprotNFe xmlBuscaProNFe()
        {
            belprotNFe objprotNFe = new belprotNFe();
            XmlDocument xproNFe = new XmlDocument();

            try
            {
                if (xDoc.GetElementsByTagName("protNFe").Count > 0)
                {
                    xproNFe.LoadXml(xDoc.GetElementsByTagName("protNFe")[0].OuterXml);


                    if (xproNFe.DocumentElement.GetAttribute("versao").ToString() != "")
                    {
                        objprotNFe.Versao = xproNFe.DocumentElement.GetAttribute("versao").ToString();
                    }

                    if (xproNFe.GetElementsByTagName("infProt").Count > 0)
                    {
                        belinfProt objInfProt = new belinfProt();
                        XmlDocument xInfProt = new XmlDocument();

                        xInfProt.LoadXml(xproNFe.GetElementsByTagName("infProt")[0].OuterXml);

                        if (xInfProt.GetElementsByTagName("tpAmb").Count > 0)
                        {
                            objInfProt.TpAmb = Convert.ToInt16(xInfProt.GetElementsByTagName("tpAmb")[0].InnerText);
                        }

                        if (xInfProt.GetElementsByTagName("verAplic").Count > 0)
                        {
                            objInfProt.VerAplic = xInfProt.GetElementsByTagName("verAplic")[0].InnerText;
                        }

                        if (xInfProt.GetElementsByTagName("chNFe").Count > 0)
                        {
                            objInfProt.ChNFe = xInfProt.GetElementsByTagName("chNFe")[0].InnerText;
                        }

                        if (xInfProt.GetElementsByTagName("dhRecbto").Count > 0)
                        {
                            objInfProt.ChRecbto = Convert.ToDateTime(xInfProt.GetElementsByTagName("dhRecbto")[0].InnerText);
                        }

                        if (xInfProt.GetElementsByTagName("nProt").Count > 0)
                        {
                            objInfProt.NProt = xInfProt.GetElementsByTagName("nProt")[0].InnerText;
                        }

                        if (xInfProt.GetElementsByTagName("digVal").Count > 0)
                        {
                            objInfProt.DigVal = xInfProt.GetElementsByTagName("digVal")[0].InnerText;
                        }

                        if (xInfProt.GetElementsByTagName("cStat").Count > 0)
                        {
                            objInfProt.CStat = xInfProt.GetElementsByTagName("cStat")[0].InnerText;
                        }

                        if (xInfProt.GetElementsByTagName("xMotivo").Count > 0)
                        {
                            objInfProt.XMotivo = xInfProt.GetElementsByTagName("xMotivo")[0].InnerText;
                        }
                        objprotNFe.BelinfProt = objInfProt;
                    }
                }
            }
            catch (Exception ex)
            {

                throw new Exception(string.Format("Problemas lendo a Tag ProNFe, Erro.: {0}",
                                                  ex.Message));
            }
            return objprotNFe;
        }

        public belInfNFe MontaInfNFe()
        {
            belInfNFe objInfNFe = null;
            if (xmlAnalizado())
            {
                objInfNFe = new belInfNFe();
                objInfNFe.id = xmlBuscaId();
                objInfNFe.ide = xmlBuscaIde();
                objInfNFe.emit = xmlBuscaEmit();
                objInfNFe.dest = xmlBuscaDest();
                objInfNFe.det = xmlBuscaDet();
                objInfNFe.total = xmlBuscaTotal();
                objInfNFe.transp = xmlBuscaTransp();
                objInfNFe.cobr = xmlBuscaCobr();
                objInfNFe.infAdic = xmlBuscaInfAdic();
                objInfNFe.exporta = xmlBuscaExporta();
                objInfNFe.compra = xmlBuscaCompra();
                objInfNFe.protNFe = xmlBuscaProNFe();

            }
            //else
            //{
            //    throw new Exception("XML não pode ser Analisado");
            //} // Diego - tratar lista não validada
            return objInfNFe;
        }

        private string xmlBuscaId()
        {
            string sID = string.Empty;

            XmlDocument xInf = new XmlDocument();


            try
            {
                //xInf.LoadXml(xDoc.GetElementsByTagName("infNFe")[0].OuterXml);
                //XmlAttributeCollection _Uri = xInf.GetElementsByTagName("Id").Item(0).Attributes;

                foreach (XmlAttribute _atributo in xDoc.GetElementsByTagName("infNFe").Item(0).Attributes)
                {
                    if (_atributo.Name == "Id")
                    {
                        sID = _atributo.InnerText.Replace("NFe", "");
                    }
                }

            }
            catch (Exception ex)
            {

                throw new Exception(string.Format("Não foi possivel localizar o ID, Erro.: {0}", ex.Message));
            }

            return sID;

        }
    }
}
