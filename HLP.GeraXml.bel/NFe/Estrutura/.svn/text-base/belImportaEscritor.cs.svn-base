using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace HLP.GeraXml.bel.NFe.Estrutura
{
    public class belImportaEscritor
    {
        private XmlDocument xDoc = new XmlDocument();


        public XmlDocument XDoc
        {
            get { return xDoc; }
            set { xDoc = value; }
        }

        public bool XmlValido()
        {
            bool bValido = false;
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
                objIde.Dsaient = Convert.ToDateTime(xIde.GetElementsByTagName("dSaiEnt")[0].InnerText);

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
                xEmit.LoadXml(xDoc.GetElementsByTagName("emit")[0].OuterXml);

                objEmit.Cnpj = xEmit.GetElementsByTagName("CNPJ")[0].InnerText;
                objEmit.Xnome = xEmit.GetElementsByTagName("xNome")[0].InnerText;
                objEmit.Xfant = xEmit.GetElementsByTagName("xFant")[0].InnerText;

                xEnderEmi.LoadXml(xEmit.GetElementsByTagName("enderEmit")[0].OuterXml);
                objEmit.Xlgr = xEnderEmi.GetElementsByTagName("xLgr")[0].InnerText;
                objEmit.Nro = xEnderEmi.GetElementsByTagName("nro")[0].InnerText;
                objEmit.Xbairro = xEnderEmi.GetElementsByTagName("xBairro")[0].InnerText;
                objEmit.Cmun = xEnderEmi.GetElementsByTagName("cMun")[0].InnerText;
                objEmit.Xmun = xEnderEmi.GetElementsByTagName("xMun")[0].InnerText;
                objEmit.Uf = xEnderEmi.GetElementsByTagName("UF")[0].InnerText;
                objEmit.Cep = xEnderEmi.GetElementsByTagName("CEP")[0].InnerText;
                objEmit.Cpais = xEnderEmi.GetElementsByTagName("cPais")[0].InnerText;
                objEmit.Xpais = xEnderEmi.GetElementsByTagName("xPais")[0].InnerText;
                objEmit.Fone = xEnderEmi.GetElementsByTagName("fone")[0].InnerText;

                objEmit.Ie = xEmit.GetElementsByTagName("IE")[0].InnerText;


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
                xDest.LoadXml(xDoc.GetElementsByTagName("dest")[0].OuterXml);

                objDest.Cnpj = xDest.GetElementsByTagName("CNPJ")[0].InnerText;
                objDest.Xnome = xDest.GetElementsByTagName("xNome")[0].InnerText;

                xEnderDest.LoadXml(xDest.GetElementsByTagName("enderDest")[0].OuterXml);
                objDest.Xlgr = xEnderDest.GetElementsByTagName("xLgr")[0].InnerText;
                objDest.Nro = xEnderDest.GetElementsByTagName("nro")[0].InnerText;
                objDest.Xbairro = xEnderDest.GetElementsByTagName("xBairro")[0].InnerText;
                objDest.Cmun = xEnderDest.GetElementsByTagName("cMun")[0].InnerText;
                objDest.Xmun = xEnderDest.GetElementsByTagName("cMun")[0].InnerText;
                objDest.Uf = xEnderDest.GetElementsByTagName("UF")[0].InnerText;
                objDest.Cep = xEnderDest.GetElementsByTagName("CEP")[0].InnerText;
                objDest.Cpais = xEnderDest.GetElementsByTagName("cPais")[0].InnerText;
                objDest.Xpais = xEnderDest.GetElementsByTagName("xPais")[0].InnerText;
                objDest.Fone = xEnderDest.GetElementsByTagName("fone")[0].InnerText;

                objDest.Ie = xDest.GetElementsByTagName("IE")[0].InnerText;

            }
            catch (Exception ex)
            {

                throw new Exception(string.Format("Problemas lendo a Tag Destinatário, Erro.: {0}",
                                                  ex.Message));
            }

            return objDest;

        }

        public List<belDet> xmlBuscaDet()
        {
            XmlDocument xDet = new XmlDocument();
            XmlDocument xProd = new XmlDocument();
            XmlDocument xImpostos = new XmlDocument();
            XmlDocument xIcms = new XmlDocument();
            XmlDocument xIcmsN = new XmlDocument();

            List<belDet> lobjDet = new List<belDet>();
            belDet objDet = new belDet();
            belProd objProd = new belProd();
            belIcms objIcms = new belIcms();

            try
            {
                for (int i = 0; i < xDoc.GetElementsByTagName("det").Count; i++)
                {
                    xDet.LoadXml(xDoc.GetElementsByTagName("det")[i].OuterXml);
                    xProd.LoadXml(xDet.GetElementsByTagName("prod")[i].OuterXml);
                    objProd.Cprod = xProd.GetElementsByTagName("cProd")[0].InnerText;
                    objProd.Cean = xProd.GetElementsByTagName("cEAN")[0].InnerText;
                    objProd.Xprod = xProd.GetElementsByTagName("xProd")[0].InnerText;
                    objProd.Ncm = xProd.GetElementsByTagName("NCM")[0].InnerText;
                    objProd.Cfop = xProd.GetElementsByTagName("CFOP")[0].InnerText;
                    objProd.Ucom = xProd.GetElementsByTagName("uCom")[0].InnerText;
                    objProd.Qcom = Convert.ToDecimal(xProd.GetElementsByTagName("qCom")[0].InnerText);
                    objProd.Vuncom = Convert.ToDecimal(xProd.GetElementsByTagName("vUnCom")[0].InnerText);
                    objProd.Vprod = Convert.ToDecimal(xProd.GetElementsByTagName("vProd")[0].InnerText);
                    objProd.Ceantrib = Convert.ToString(xProd.GetElementsByTagName("cEANTrib")[0].InnerText);
                    objProd.Utrib = xProd.GetElementsByTagName("uTrib")[0].InnerText;
                    objProd.Qtrib = Convert.ToDecimal(xProd.GetElementsByTagName("qTrib")[0].InnerText);
                    objProd.Vuntrib = Convert.ToDecimal(xProd.GetElementsByTagName("vUnTrib")[0].InnerText);

                    xImpostos.LoadXml(xDet.GetElementsByTagName("imposto")[0].OuterXml);
                    xIcms.LoadXml(xImpostos.GetElementsByTagName("ICMS")[0].OuterXml);

                    objIcms = xmlBuscaDetICMS(xIcms);

                    belIpi objIPI = xmlBuscaDetIPI(xImpostos);

                    belIi objII = xmlBuscaDetII(xImpostos);

                    belPis objPis = xmlBuscaDetPis(xImpostos);

                    belCofins objCofins = xmlBuscaDetCofins(xImpostos);








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
                            belIcms00 objIcms00 = new belIcms00();
                            xIcmsN.LoadXml(Xdoc.GetElementsByTagName("ICMS00")[0].OuterXml);

                            objIcms00.Orig = xIcmsN.GetElementsByTagName("orig")[0].InnerText;
                            objIcms00.Cst = xIcmsN.GetElementsByTagName("CST")[0].InnerText;
                            objIcms00.Modbc = xIcmsN.GetElementsByTagName("modBC")[0].InnerText;
                            objIcms00.Vbc = Convert.ToDecimal(xIcmsN.GetElementsByTagName("vBC")[0].InnerText);
                            objIcms00.Picms = Convert.ToDecimal(xIcmsN.GetElementsByTagName("pICMS")[0].InnerText);
                            objIcms00.Vicms = Convert.ToDecimal(xIcmsN.GetElementsByTagName("vICMS")[0].InnerText);
                            objIcms.belIcms00 = objIcms00;
                            break;
                        }
                    case "ICMS10":
                        {
                            xIcmsN.LoadXml(Xdoc.GetElementsByTagName("ICMS10")[0].OuterXml);

                            belIcms10 objIcms10 = new belIcms10();
                            objIcms10.Orig = xIcmsN.GetElementsByTagName("orig")[0].InnerText;
                            objIcms10.Cst = xIcmsN.GetElementsByTagName("CST")[0].InnerText;
                            objIcms10.Modbc = xIcmsN.GetElementsByTagName("modBC")[0].InnerText;
                            objIcms10.Vbc = Convert.ToDecimal(xIcmsN.GetElementsByTagName("vBC")[0].InnerText);
                            objIcms10.Picms = Convert.ToDecimal(xIcmsN.GetElementsByTagName("pICMS")[0].InnerText);
                            objIcms10.Vicms = Convert.ToDecimal(xIcmsN.GetElementsByTagName("vICMS")[0].InnerText);
                            objIcms10.Modbcst = Convert.ToDecimal(xIcmsN.GetElementsByTagName("modBCST")[0].InnerText);
                            objIcms10.Pmvast = Convert.ToDecimal(xIcmsN.GetElementsByTagName("pMVAST")[0].InnerText);
                            objIcms10.Predbcst = Convert.ToDecimal(xIcmsN.GetElementsByTagName("pRedBCST")[0].InnerText);
                            objIcms10.Vbcst = Convert.ToDecimal(xIcmsN.GetElementsByTagName("vBCST")[0].InnerText);
                            objIcms10.Picmsst = Convert.ToDecimal(xIcmsN.GetElementsByTagName("pICMSST")[0].InnerText);
                            objIcms10.Vicmsst = Convert.ToDecimal(xIcmsN.GetElementsByTagName("vICMSST")[0].InnerText);
                            objIcms.belIcms10 = objIcms10;
                            break;
                        }
                    case "ICMS20":
                        {
                            xIcmsN.LoadXml(Xdoc.GetElementsByTagName("ICMS20")[0].OuterXml);
                            belIcms20 objIcms20 = new belIcms20();

                            objIcms20.Orig = xIcmsN.GetElementsByTagName("orig")[0].InnerText;
                            objIcms20.Cst = xIcmsN.GetElementsByTagName("CST")[0].InnerText;
                            objIcms20.Modbc = xIcmsN.GetElementsByTagName("modBC")[0].InnerText;
                            objIcms20.Predbc = Convert.ToDecimal(xIcmsN.GetElementsByTagName("pRedBC")[0].InnerText);
                            objIcms20.Vbc = Convert.ToDecimal(xIcmsN.GetElementsByTagName("vBC")[0].InnerText);
                            objIcms20.Picms = Convert.ToDecimal(xIcmsN.GetElementsByTagName("pICMS")[0].InnerText);
                            objIcms20.Vicms = Convert.ToDecimal(xIcmsN.GetElementsByTagName("vICMS")[0].InnerText);
                            objIcms.belIcms20 = objIcms20;
                            break;
                        }
                    case "ICMS30":
                        {
                            xIcmsN.LoadXml(Xdoc.GetElementsByTagName("ICMS20")[0].OuterXml);
                            belIcms30 objIcms30 = new belIcms30();

                            objIcms30.Orig = xIcmsN.GetElementsByTagName("orig")[0].InnerText;
                            objIcms30.Cst = xIcmsN.GetElementsByTagName("CST")[0].InnerText;
                            objIcms30.Modbcst = Convert.ToDecimal(xIcmsN.GetElementsByTagName("modBCST")[0].InnerText);
                            objIcms30.Pmvast = Convert.ToDecimal(xIcmsN.GetElementsByTagName("pMVAST")[0].InnerText);
                            objIcms30.Predbcst = Convert.ToDecimal(xIcmsN.GetElementsByTagName("")[0].InnerText);
                            objIcms30.Vbcst = Convert.ToDecimal(xIcmsN.GetElementsByTagName("vBCST")[0].InnerText);
                            objIcms30.Picmsst = Convert.ToDecimal(xIcmsN.GetElementsByTagName("pICMSST")[0].InnerText);
                            objIcms30.Vicmsst = Convert.ToDecimal(xIcmsN.GetElementsByTagName("vICMSST")[0].InnerText);

                            objIcms.belIcms30 = objIcms30;
                            break;
                        }
                    case "ICMS40":
                        {
                            xIcmsN.LoadXml(Xdoc.GetElementsByTagName("ICMS40")[0].OuterXml);
                            belIcms40 objIcms40 = new belIcms40();
                            objIcms40.Orig = xIcmsN.GetElementsByTagName("orig")[0].InnerText;
                            objIcms40.Cst = xIcmsN.GetElementsByTagName("CST")[0].InnerText;

                            objIcms.belIcms40 = objIcms40;
                            break;
                        }
                    case "ICMS51":
                        {
                            xIcmsN.LoadXml(Xdoc.GetElementsByTagName("ICMS51")[0].OuterXml);
                            belIcms51 objIcms51 = new belIcms51();

                            objIcms51.Orig = xIcmsN.GetElementsByTagName("orig")[0].InnerText;
                            objIcms51.Cst = xIcmsN.GetElementsByTagName("CST")[0].InnerText;
                            objIcms51.Modbc = xIcmsN.GetElementsByTagName("modBC")[0].InnerText;
                            objIcms51.Predbc = Convert.ToDecimal(xIcmsN.GetElementsByTagName("")[0].InnerText);
                            objIcms51.Vbc = Convert.ToDecimal(xIcmsN.GetElementsByTagName("vBC")[0].InnerText);
                            objIcms51.Picms = Convert.ToDecimal(xIcmsN.GetElementsByTagName("pICMS")[0].InnerText);
                            objIcms51.Vicms = Convert.ToDecimal(xIcmsN.GetElementsByTagName("vICMS")[0].InnerText);

                            objIcms.belIcms51 = objIcms51;
                            break;
                        }
                    case "ICMS60":
                        {
                            xIcmsN.LoadXml(Xdoc.GetElementsByTagName("ICMS60")[0].OuterXml);
                            belIcms60 objIcms60 = new belIcms60();

                            objIcms60.Orig = xIcmsN.GetElementsByTagName("orig")[0].InnerText;
                            objIcms60.Cst = xIcmsN.GetElementsByTagName("CST")[0].InnerText;
                            objIcms60.Vbcstret = Convert.ToDecimal(xIcmsN.GetElementsByTagName("vBCST")[0].InnerText);
                            objIcms60.Vicmsstret = Convert.ToDecimal(xIcmsN.GetElementsByTagName("vICMSST")[0].InnerText);

                            objIcms.belIcms60 = objIcms60;
                            break;
                        }
                    case "ICMS70":
                        {
                            xIcmsN.LoadXml(Xdoc.GetElementsByTagName("ICMS70")[0].OuterXml);
                            belIcms70 objIcms70 = new belIcms70();
                            objIcms70.Orig = xIcmsN.GetElementsByTagName("orig")[0].InnerText;
                            objIcms70.Cst = xIcmsN.GetElementsByTagName("CST")[0].InnerText;
                            objIcms70.Modbc = xIcmsN.GetElementsByTagName("modBC")[0].InnerText;
                            objIcms70.Predbc = Convert.ToDecimal(xIcmsN.GetElementsByTagName("pRedBC")[0].InnerText);
                            objIcms70.Vbc = Convert.ToDecimal(xIcmsN.GetElementsByTagName("vBC")[0].InnerText);
                            objIcms70.Picms = Convert.ToDecimal(xIcmsN.GetElementsByTagName("pICMS")[0].InnerText);
                            objIcms70.Vicms = Convert.ToDecimal(xIcmsN.GetElementsByTagName("vICMS")[0].InnerText);
                            objIcms70.Modbcst = Convert.ToDecimal(xIcmsN.GetElementsByTagName("modBCST")[0].InnerText);
                            objIcms70.Pmvast = Convert.ToDecimal(xIcmsN.GetElementsByTagName("pMVAST")[0].InnerText);
                            objIcms70.Predbcst = Convert.ToDecimal(xIcmsN.GetElementsByTagName("pRedBCST")[0].InnerText);
                            objIcms70.Vbcst = Convert.ToDecimal(xIcmsN.GetElementsByTagName("vBCST")[0].InnerText);
                            objIcms70.Picmsst = Convert.ToDecimal(xIcmsN.GetElementsByTagName("pICMSST")[0].InnerText);
                            objIcms70.Vicmsst = Convert.ToDecimal(xIcmsN.GetElementsByTagName("vICMSST")[0].InnerText);

                            objIcms.belIcms70 = objIcms70;
                            break;

                        }
                    case "ICMS90":
                        {
                            xIcmsN.LoadXml(Xdoc.GetElementsByTagName("ICMS90")[0].OuterXml);
                            belIcms90 objICms90 = new belIcms90();

                            objICms90.Orig = xIcmsN.GetElementsByTagName("orig")[0].InnerText;
                            objICms90.Cst = xIcmsN.GetElementsByTagName("CST")[0].InnerText;
                            objICms90.Modbc = xIcmsN.GetElementsByTagName("modBC")[0].InnerText;
                            objICms90.Vbc = Convert.ToDecimal(xIcmsN.GetElementsByTagName("vBC")[0].InnerText);
                            objICms90.Predbc = Convert.ToDecimal(xIcmsN.GetElementsByTagName("pRedBC")[0].InnerText);
                            objICms90.Picms = Convert.ToDecimal(xIcmsN.GetElementsByTagName("pICMS")[0].InnerText);
                            objICms90.Vicms = Convert.ToDecimal(xIcmsN.GetElementsByTagName("vICMS")[0].InnerText);
                            objICms90.Modbcst = Convert.ToDecimal(xIcmsN.GetElementsByTagName("modBCST")[0].InnerText);
                            objICms90.Pmvast = Convert.ToDecimal(xIcmsN.GetElementsByTagName("pMVAST")[0].InnerText);
                            objICms90.Predbcst = Convert.ToDecimal(xIcmsN.GetElementsByTagName("pRedBCST")[0].InnerText);
                            objICms90.Vbcst = Convert.ToDecimal(xIcmsN.GetElementsByTagName("vBCST")[0].InnerText);
                            objICms90.Picmsst = Convert.ToDecimal(xIcmsN.GetElementsByTagName("pICMSST")[0].InnerText);
                            objICms90.Vicmsst = Convert.ToDecimal(xIcmsN.GetElementsByTagName("vICMSST")[0].InnerText);

                            objIcms.belIcms90 = objICms90;
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


            XmlDocument xIpiN = new XmlDocument();

            try
            {
                switch (Xdoc.GetElementsByTagName("IPI")[0].LastChild.Name)
                {
                    case "IPITrib":
                        {
                            belIpitrib objIpiTrib = new belIpitrib();
                            xIpiN.LoadXml(Xdoc.GetElementsByTagName("IPITrib")[0].OuterXml);

                            objIpiTrib.Cst = xIpiN.GetElementsByTagName("CST")[0].InnerText;
                            objIpiTrib.Vbc = Convert.ToDecimal(xIpiN.GetElementsByTagName("vBC")[0].InnerText);
                            objIpiTrib.Qunid = Convert.ToDecimal(xIpiN.GetElementsByTagName("qUnid")[0].InnerText);
                            objIpiTrib.Vunid = Convert.ToDecimal(xIpiN.GetElementsByTagName("vUnid")[0].InnerText);
                            objIpiTrib.Pipi = Convert.ToDecimal(xIpiN.GetElementsByTagName("pIPI")[0].InnerText);
                            objIpiTrib.Vipi = Convert.ToDecimal(xIpiN.GetElementsByTagName("vIPI")[0].InnerText);

                            objIpi.belIpitrib = objIpiTrib;
                            break;
                        }
                    case "IPINT":
                        {
                            belIpint objIpiNT = new belIpint();
                            xIpiN.LoadXml(Xdoc.GetElementsByTagName("IPINT")[0].OuterXml);

                            objIpiNT.Cst = xIpiN.GetElementsByTagName("CST")[0].InnerText;

                            objIpi.belIpint = objIpiNT;
                            break;
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

                xII.LoadXml(xDoc.GetElementsByTagName("II")[0].OuterXml);

                if (xII.GetElementsByTagName("vBC").Count > 0)
                {
                    objII.Vbc = Convert.ToDecimal(xII.GetElementsByTagName("vBC")[0].InnerText);
                }

                if (xII.GetElementsByTagName("vDespAdu").Count > 0)
                {
                    objII.Vdespadu = Convert.ToDecimal(xII.GetElementsByTagName("vDespAdu")[0].InnerText);
                }

                if (xII.GetElementsByTagName("vII").Count > 0)
                {
                    objII.Vii = Convert.ToDecimal(xII.GetElementsByTagName("vII")[0].InnerText);
                }

                if (xII.GetElementsByTagName("vIOF").Count > 0)
                {
                    objII.Viof = Convert.ToDecimal(xII.GetElementsByTagName("vIOF")[0].InnerText);
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
                            xPisN.LoadXml(Xdoc.GetElementsByTagName("PISAliq")[0].OuterXml);

                            objPisAliq.Cst = xPisN.GetElementsByTagName("CST")[0].InnerText;
                            objPisAliq.Vbc = Convert.ToDecimal(xPisN.GetElementsByTagName("vBC")[0].InnerText);
                            objPisAliq.Ppis = Convert.ToDecimal(xPisN.GetElementsByTagName("pPIS")[0].InnerText);
                            objPisAliq.Vpis = Convert.ToDecimal(xPisN.GetElementsByTagName("vPIS")[0].InnerText);

                            objPis.belPisaliq = objPisAliq;
                            break;
                        }
                    case "PISQtde":
                        {
                            belPisqtde objPisQtde = new belPisqtde();

                            xPisN.LoadXml(Xdoc.GetElementsByTagName("PISQtde")[0].OuterXml);

                            objPisQtde.Cst = xPisN.GetElementsByTagName("CST")[0].InnerText;
                            objPisQtde.Qbcprod = Convert.ToDecimal(xPisN.GetElementsByTagName("qBCProd")[0].InnerText);
                            objPisQtde.Valiqprod = Convert.ToDecimal(xPisN.GetElementsByTagName("vAliqProd")[0].InnerText);
                            objPisQtde.Vpis = Convert.ToDecimal(xPisN.GetElementsByTagName("vPIS")[0].InnerText);

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

                            objPisOutr.Cst = xPisN.GetElementsByTagName("CST")[0].InnerText;
                            objPisOutr.Vbc = Convert.ToDecimal(xPisN.GetElementsByTagName("")[0].InnerText);
                            objPisOutr.Ppis = Convert.ToDecimal(xPisN.GetElementsByTagName("pPIS")[0].InnerText);
                            objPisOutr.Qbcprod = Convert.ToDecimal(xPisN.GetElementsByTagName("qBCProd")[0].InnerText);
                            objPisOutr.Valiqprod = Convert.ToDecimal(xPisN.GetElementsByTagName("")[0].InnerText);
                            objPisOutr.Vpis = Convert.ToDecimal(xPisN.GetElementsByTagName("")[0].InnerText);

                            objPis.belPisoutr = objPisOutr;
                            break;
                        }
                    case "PISST":
                        {
                            belPisst objPisST = new belPisst();

                            xPisN.LoadXml(Xdoc.GetElementsByTagName("PISST")[0].OuterXml);

                            objPisST.Vbc = Convert.ToDecimal(xPisN.GetElementsByTagName("vBC")[0].InnerText);
                            objPisST.Ppis = Convert.ToDecimal(xPisN.GetElementsByTagName("pPIS")[0].InnerText);
                            objPisST.Qbcprod = Convert.ToDecimal(xPisN.GetElementsByTagName("qBCProd")[0].InnerText);
                            objPisST.Valiqprod = Convert.ToDecimal(xPisN.GetElementsByTagName("vAliqProd")[0].InnerText);
                            objPisST.Vpis = Convert.ToDecimal(xPisN.GetElementsByTagName("vPIS")[0].InnerText);

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

                            objCofinsAliq.Cst = xCofinsN.GetElementsByTagName("CST")[0].InnerText;
                            objCofinsAliq.Vbc = Convert.ToDecimal(xCofinsN.GetElementsByTagName("vBC")[0].InnerText);
                            objCofinsAliq.Pcofins = Convert.ToDecimal(xCofinsN.GetElementsByTagName("pCOFINS")[0].InnerText);
                            objCofinsAliq.Vcofins = Convert.ToDecimal(xCofinsN.GetElementsByTagName("vCOFINS")[0].InnerText);

                            objCofins.belCofinsaliq = objCofinsAliq;
                            break;
                        }
                    case "COFINSQtde":
                        {
                            belCofinsqtde objCofinsQtde = new belCofinsqtde();

                            xCofinsN.LoadXml(Xdoc.GetElementsByTagName("COFINSQtde")[0].OuterXml);

                            objCofinsQtde.Cst = xCofinsN.GetElementsByTagName("CST")[0].InnerText;
                            objCofinsQtde.Qbcprod = Convert.ToDecimal(xCofinsN.GetElementsByTagName("qBCProd")[0].InnerText);
                            objCofinsQtde.Valiqprod = Convert.ToDecimal(xCofinsN.GetElementsByTagName("vAliqProd")[0].InnerText);
                            objCofinsQtde.Vcofins = Convert.ToDecimal(xCofinsN.GetElementsByTagName("vCOFINS")[0].InnerText);

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

                            objCofinsOutr.Cst = xCofinsN.GetElementsByTagName("CST")[0].InnerText;
                            objCofinsOutr.Vbc = Convert.ToDecimal(xCofinsN.GetElementsByTagName("vBC")[0].InnerText);
                            objCofinsOutr.Pcofins = Convert.ToDecimal(xCofinsN.GetElementsByTagName("pCOFINS")[0].InnerText);
                            objCofinsOutr.Qbcprod = Convert.ToDecimal(xCofinsN.GetElementsByTagName("qBCProd")[0].InnerText);
                            objCofinsOutr.Valiqprod = Convert.ToDecimal(xCofinsN.GetElementsByTagName("vAliqProd")[0].InnerText);
                            objCofinsOutr.Vcofins = Convert.ToDecimal(xCofinsN.GetElementsByTagName("vCOFINS")[0].InnerText);

                            objCofins.belCofinsoutr = objCofinsOutr;
                            break;
                        }
                    case "COFINSST":
                        {
                            belCofinsst objCofinsST = new belCofinsst();

                            xCofinsN.LoadXml(Xdoc.GetElementsByTagName("COFINSST")[0].OuterXml);
                                                        
                            objCofinsST.Vbc = Convert.ToDecimal(xCofinsN.GetElementsByTagName("vBC")[0].InnerText);
                            objCofinsST.Pcofins = Convert.ToDecimal(xCofinsN.GetElementsByTagName("pCOFINS")[0].InnerText);
                            objCofinsST.Qbcprod = Convert.ToDecimal(xCofinsN.GetElementsByTagName("qBCProd")[0].InnerText);
                            objCofinsST.Valiqprod = Convert.ToDecimal(xCofinsN.GetElementsByTagName("vAliqProd")[0].InnerText);
                            objCofinsST.Vcofins = Convert.ToDecimal(xCofinsN.GetElementsByTagName("vCOFINS")[0].InnerText);

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



        public belImportaEscritor(string sXML)
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
    }
}
