using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using HLP.GeraXml.Comum.Static;
using System.Xml;
using HLP.GeraXml.Comum.DataSet;
using System.Data;
using HLP.GeraXml.dao.ADO;

namespace HLP.GeraXml.bel.CTe
{
    public class belPopulaDataSet
    {

        dsCTe.LogotipoRow dsLogo;
        dsCTe.CodBarrasRow dsCodBarras;

        dsCTe.infCteRow dsInfCte;
        dsCTe.ideRow dsIde;
        dsCTe.toma03Row dsToma03;
        dsCTe.toma4Row dsToma4;
        dsCTe.enderTomaRow dsEnderToma;
        dsCTe.emitRow dsEmit;
        dsCTe.enderEmitRow dsEnderEmit;
        dsCTe.remRow dsRem;
        dsCTe.enderRemeRow dsEnderReme;
        dsCTe.infNFRow dsInfNF;
        dsCTe.expedRow dsExped;
        dsCTe.enderExpedRow dsEnderExped;
        dsCTe.recebRow dsReceb;
        dsCTe.enderRecebRow dsEnderReceb;
        dsCTe.destRow dsDest;
        dsCTe.enderDestRow dsEnderDest;
        dsCTe.vPrestRow dsVprest;
        dsCTe.CompRow dsComp;
        dsCTe.impRow dsImp;
        dsCTe.ICMSRow dsICMS;
        dsCTe.ICMS00Row dsICMS00;
        dsCTe.ICMS20Row dsICMS20;
        dsCTe.ICMS45Row dsICMS45;
        dsCTe.ICMS60Row dsICMS60;
        dsCTe.ICMSOutraUFRow dsICMSOutraUF;
        dsCTe.ICMS90Row dsICMS90;
        dsCTe.infCTeNormRow dsInfCTeNorm;
        dsCTe.infCargaRow dsInfCarga;
        dsCTe.infQRow dsInfQ;
        dsCTe.segRow dsSeg;
        dsCTe.rodoRow dsRodo;
        dsCTe.motoRow dsMoto;
        dsCTe.veicRow dsVeic;

        int iChaveNota = 1;
        int iChaveCarga = 1;
        int iChaveComp = 1;
        int iChaveVeic = 1;


        public void PopulaDataSet(dsCTe dsCte, string sCaminho, int iChave, string sProtocolo)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(sCaminho);



                Byte[] bLogo = carregaImagem(Acesso.LOGOTIPO);
                dsLogo = dsCte.Logotipo.NewLogotipoRow();
                if (bLogo != null)
                {
                    dsLogo.Logo = bLogo;
                }
                dsCte.Logotipo.AddLogotipoRow(dsLogo);
                dsLogo = dsCte.Logotipo.NewLogotipoRow();

                #region infCte

                string sCodBarras = "";
                dsCodBarras = dsCte.CodBarras.NewCodBarrasRow();
                dsCodBarras.codId = iChave;
                dsCodBarras.pk_infCte = iChave;

                dsInfCte = dsCte.infCte.NewinfCteRow();

                XmlNodeList infCte = doc.GetElementsByTagName("infCte");
                for (int i = 0; i < infCte.Count; i++)
                {
                    for (int j = 0; j < infCte[i].Attributes.Count; j++)
                    {
                        switch (infCte[i].Attributes[j].LocalName)
                        {
                            case "Id": sCodBarras = infCte[i].Attributes[j].Value.ToString();
                                dsInfCte.Id = sCodBarras.Substring(3, sCodBarras.Length - 3);
                                break;

                            case "versao": dsInfCte.versao = infCte[i].Attributes[j].Value;
                                break;
                        }
                    }

                }

                XmlNodeList infProt = doc.GetElementsByTagName("infProt");
                string nProt = "";
                string dhRecbto = "";
                for (int i = 0; i < infProt.Count; i++)
                {
                    for (int j = 0; j < infProt[i].ChildNodes.Count; j++)
                    {
                        switch (infProt[i].ChildNodes[j].LocalName)
                        {
                            case "nProt": nProt = infProt[i].ChildNodes[j].InnerText;
                                break;
                            case "dhRecbto": dhRecbto = Convert.ToDateTime(infProt[i].ChildNodes[j].InnerText).ToString();
                                break;
                        }
                    }
                }
                dsInfCte.nProt = nProt + "  " + dhRecbto;

                string sBar = sCodBarras.Substring(3, sCodBarras.Length - 3);
                Byte[] bimagem = SalvaCodBarras(sBar);
                dsCodBarras.cod_barras = bimagem;
                dsCte.CodBarras.AddCodBarrasRow(dsCodBarras);
                dsCodBarras = dsCte.CodBarras.NewCodBarrasRow();

                dsInfCte.pk_infCte = iChave;

                dsCte.infCte.AddinfCteRow(dsInfCte);
                dsInfCte = dsCte.infCte.NewinfCteRow();

                #endregion

                #region ide

                dsIde = dsCte.ide.NewideRow();
                XmlNodeList ide = doc.GetElementsByTagName("ide");
                for (int i = 0; i < ide.Count; i++)
                {
                    for (int j = 0; j < ide[i].ChildNodes.Count; j++)
                    {
                        switch (ide[i].ChildNodes[j].LocalName)
                        {
                            case "cUF": dsIde.cUF = ide[i].ChildNodes[j].InnerText;
                                break;

                            case "cCT": dsIde.cCT = ide[i].ChildNodes[j].InnerText;
                                break;

                            case "CFOP": dsIde.CFOP = ide[i].ChildNodes[j].InnerText;
                                break;

                            case "natOp": dsIde.natOp = ide[i].ChildNodes[j].InnerText;
                                break;

                            case "forPag": dsIde.forPag = ide[i].ChildNodes[j].InnerText;
                                break;

                            case "mod": dsIde.mod = ide[i].ChildNodes[j].InnerText;
                                break;

                            case "serie": dsIde.serie = ide[i].ChildNodes[j].InnerText;
                                break;

                            case "nCT": dsIde.nCT = ide[i].ChildNodes[j].InnerText;
                                break;

                            case "dhEmi":

                                dsIde.dhEmi = Convert.ToDateTime(ide[i].ChildNodes[j].InnerText).ToString();
                                break;

                            case "tpImp": dsIde.tpImp = ide[i].ChildNodes[j].InnerText;
                                break;

                            case "tpEmis": dsIde.tpEmis = ide[i].ChildNodes[j].InnerText;
                                break;

                            case "cDV": dsIde.cDV = ide[i].ChildNodes[j].InnerText;
                                break;

                            case "tpAmb": dsIde.tpAmb = ide[i].ChildNodes[j].InnerText;
                                break;

                            case "tpCTe": dsIde.tpCTe = ide[i].ChildNodes[j].InnerText;
                                break;

                            case "procEmi": dsIde.procEmi = ide[i].ChildNodes[j].InnerText;
                                break;

                            case "verProc": dsIde.verProc = ide[i].ChildNodes[j].InnerText;
                                break;

                            case "cMunEmi": dsIde.cMunEmi = ide[i].ChildNodes[j].InnerText;
                                break;

                            case "xMunEmi": dsIde.xMunEmi = ide[i].ChildNodes[j].InnerText;
                                break;

                            case "UFEmi": dsIde.UFEmi = ide[i].ChildNodes[j].InnerText;
                                break;

                            case "modal": dsIde.modal = ide[i].ChildNodes[j].InnerText;
                                break;

                            case "tpServ": dsIde.tpServ = ide[i].ChildNodes[j].InnerText;
                                break;

                            case "cMunIni": dsIde.cMunIni = ide[i].ChildNodes[j].InnerText;
                                break;

                            case "xMunIni": dsIde.xMunIni = ide[i].ChildNodes[j].InnerText;
                                break;

                            case "UFIni": dsIde.UFIni = ide[i].ChildNodes[j].InnerText;
                                break;

                            case "cMunFim": dsIde.cMunFim = ide[i].ChildNodes[j].InnerText;
                                break;

                            case "xMunFim": dsIde.xMunFim = ide[i].ChildNodes[j].InnerText;
                                break;

                            case "UFFim": dsIde.UFFim = ide[i].ChildNodes[j].InnerText;
                                break;

                            case "retira": dsIde.retira = ide[i].ChildNodes[j].InnerText;
                                break;
                        }
                    }

                }

                dsIde.nProt = sProtocolo;
                dsIde.pk_ide = iChave;
                dsIde.pk_infCte = iChave;
                dsIde.Notas = dao.daoUtil.BuscaNumNotas(dsIde.cCT);

                dsCte.ide.AddideRow(dsIde);
                dsIde = dsCte.ide.NewideRow();

                #endregion

                #region Tomador


                XmlNodeList toma03 = doc.GetElementsByTagName("toma03");
                XmlNodeList toma4 = doc.GetElementsByTagName("toma4");
                XmlNodeList enderToma = doc.GetElementsByTagName("enderToma");

                if (toma03.Count > 0)
                {
                    dsToma03 = dsCte.toma03.Newtoma03Row();
                    for (int i = 0; i < toma03.Count; i++)
                    {
                        for (int j = 0; j < toma03[i].ChildNodes.Count; j++)
                        {
                            switch (toma03[i].ChildNodes[j].LocalName)
                            {
                                case "toma": dsToma03.toma = toma03[i].ChildNodes[j].InnerText;
                                    break;

                            }
                        }
                    }
                    dsToma03.pk_toma03 = iChave;
                    dsToma03.pk_ide = iChave;

                    dsCte.toma03.Addtoma03Row(dsToma03);
                    dsToma03 = dsCte.toma03.Newtoma03Row();
                }
                else if (toma4.Count > 0)
                {
                    dsToma4 = dsCte.toma4.Newtoma4Row();
                    dsEnderToma = dsCte.enderToma.NewenderTomaRow();

                    #region Dados Tomador
                    for (int i = 0; i < toma4.Count; i++)
                    {
                        for (int j = 0; j < toma4[i].ChildNodes.Count; j++)
                        {
                            switch (toma4[i].ChildNodes[j].LocalName)
                            {
                                case "toma": dsToma4.toma = toma4[i].ChildNodes[j].InnerText;
                                    break;

                                case "CNPJ": dsToma4.CNPJ = toma4[i].ChildNodes[j].InnerText;
                                    break;

                                case "CPF": dsToma4.CPF = toma4[i].ChildNodes[j].InnerText;
                                    break;

                                case "IE": dsToma4.IE = toma4[i].ChildNodes[j].InnerText;
                                    break;

                                case "xNome": dsToma4.xNome = toma4[i].ChildNodes[j].InnerText;
                                    break;

                                case "xFant": dsToma4.xFant = toma4[i].ChildNodes[j].InnerText;
                                    break;

                                case "fone": dsToma4.fone = toma4[i].ChildNodes[j].InnerText;
                                    break;

                            }
                        }
                    }

                    dsToma4.pk_toma4 = iChave;
                    dsToma4.pk_ide = iChave;

                    dsCte.toma4.Addtoma4Row(dsToma4);
                    dsToma4 = dsCte.toma4.Newtoma4Row();
                    #endregion

                    #region EnderecoToma

                    for (int i = 0; i < enderToma.Count; i++)
                    {
                        for (int j = 0; j < enderToma[i].ChildNodes.Count; j++)
                        {
                            switch (enderToma[i].ChildNodes[j].LocalName)
                            {
                                case "xLgr": dsEnderToma.xLgr = enderToma[i].ChildNodes[j].InnerText;
                                    break;

                                case "nro": dsEnderToma.nro = enderToma[i].ChildNodes[j].InnerText;
                                    break;

                                case "xCpl": dsEnderToma.xCpl = enderToma[i].ChildNodes[j].InnerText;
                                    break;

                                case "xBairro": dsEnderToma.xBairro = enderToma[i].ChildNodes[j].InnerText;
                                    break;

                                case "cMun": dsEnderToma.cMun = toma4[i].ChildNodes[j].InnerText;
                                    break;

                                case "xMun": dsEnderToma.xMun = toma4[i].ChildNodes[j].InnerText;
                                    break;

                                case "CEP": dsEnderToma.CEP = toma4[i].ChildNodes[j].InnerText;
                                    break;

                                case "UF": dsEnderToma.UF = toma4[i].ChildNodes[j].InnerText;
                                    break;

                                case "cPais": dsEnderToma.cPais = toma4[i].ChildNodes[j].InnerText;
                                    break;

                                case "xPais": dsEnderToma.xPais = toma4[i].ChildNodes[j].InnerText;
                                    break;

                            }
                        }
                    }

                    dsEnderToma.pk_toma4 = iChave;
                    dsEnderToma.pk_enderToma = iChave;

                    dsCte.enderToma.AddenderTomaRow(dsEnderToma);
                    dsEnderToma = dsCte.enderToma.NewenderTomaRow();

                    #endregion
                }

                #endregion

                #region emit

                #region Dados Emit

                dsEmit = dsCte.emit.NewemitRow();
                XmlNodeList emit = doc.GetElementsByTagName("emit");

                for (int i = 0; i < emit.Count; i++)
                {
                    for (int j = 0; j < emit[i].ChildNodes.Count; j++)
                    {
                        switch (emit[i].ChildNodes[j].LocalName)
                        {
                            case "CNPJ": dsEmit.CNPJ = emit[i].ChildNodes[j].InnerText;
                                break;

                            case "IE": dsEmit.IE = emit[i].ChildNodes[j].InnerText;
                                break;

                            case "xNome": dsEmit.xNome = emit[i].ChildNodes[j].InnerText;
                                break;

                            case "xFant": dsEmit.xFant = emit[i].ChildNodes[j].InnerText;
                                break;

                        }
                    }
                }

                dsEmit.pk_emit = iChave;
                dsEmit.pk_infCte = iChave;

                dsCte.emit.AddemitRow(dsEmit);
                dsEmit = dsCte.emit.NewemitRow();

                #endregion

                #region EnderEmit

                dsEnderEmit = dsCte.enderEmit.NewenderEmitRow();
                XmlNodeList enderEmit = doc.GetElementsByTagName("enderEmit");

                for (int i = 0; i < enderEmit.Count; i++)
                {
                    for (int j = 0; j < enderEmit[i].ChildNodes.Count; j++)
                    {
                        switch (enderEmit[i].ChildNodes[j].LocalName)
                        {
                            case "xLgr": dsEnderEmit.xLgr = enderEmit[i].ChildNodes[j].InnerText;
                                break;

                            case "nro": dsEnderEmit.nro = enderEmit[i].ChildNodes[j].InnerText;
                                break;

                            case "xCpl": dsEnderEmit.xCpl = enderEmit[i].ChildNodes[j].InnerText;
                                break;

                            case "xBairro": dsEnderEmit.xBairro = enderEmit[i].ChildNodes[j].InnerText;
                                break;

                            case "cMun": dsEnderEmit.cMun = enderEmit[i].ChildNodes[j].InnerText;
                                break;

                            case "xMun": dsEnderEmit.xMun = enderEmit[i].ChildNodes[j].InnerText;
                                break;

                            case "CEP": dsEnderEmit.CEP = enderEmit[i].ChildNodes[j].InnerText;
                                break;

                            case "UF": dsEnderEmit.UF = enderEmit[i].ChildNodes[j].InnerText;
                                break;

                            case "cPais": dsEnderEmit.cPais = enderEmit[i].ChildNodes[j].InnerText;
                                break;

                            case "xPais": dsEnderEmit.xPais = enderEmit[i].ChildNodes[j].InnerText;
                                break;

                            case "fone": dsEnderEmit.fone = enderEmit[i].ChildNodes[j].InnerText;
                                break;

                        }
                    }
                }

                dsEnderEmit.pk_emit = iChave;
                dsEnderEmit.pk_enderEmit = iChave;

                dsCte.enderEmit.AddenderEmitRow(dsEnderEmit);
                dsEnderEmit = dsCte.enderEmit.NewenderEmitRow();

                #endregion


                #endregion

                #region rem

                #region Dados Rem
                dsRem = dsCte.rem.NewremRow();
                XmlNodeList rem = doc.GetElementsByTagName("rem");

                for (int i = 0; i < rem.Count; i++)
                {
                    for (int j = 0; j < rem[i].ChildNodes.Count; j++)
                    {
                        switch (rem[i].ChildNodes[j].LocalName)
                        {
                            case "CNPJ": dsRem.CNPJ = rem[i].ChildNodes[j].InnerText;
                                break;

                            case "CPF": dsRem.CPF = rem[i].ChildNodes[j].InnerText;
                                break;

                            case "IE": dsRem.IE = rem[i].ChildNodes[j].InnerText;
                                break;

                            case "xNome": dsRem.xNome = rem[i].ChildNodes[j].InnerText;
                                break;

                            case "xFant": dsRem.xFant = rem[i].ChildNodes[j].InnerText;
                                break;

                            case "fone": dsRem.fone = rem[i].ChildNodes[j].InnerText;
                                break;

                        }
                    }
                }
                dsRem.pk_infCte = iChave;
                dsRem.pk_rem = iChave;
                dsCte.rem.AddremRow(dsRem);
                dsRem = dsCte.rem.NewremRow();





                #endregion

                #region EnderReme

                dsEnderReme = dsCte.enderReme.NewenderRemeRow();
                XmlNodeList enderReme = doc.GetElementsByTagName("enderReme");

                for (int i = 0; i < enderReme.Count; i++)
                {
                    for (int j = 0; j < enderReme[i].ChildNodes.Count; j++)
                    {
                        switch (enderReme[i].ChildNodes[j].LocalName)
                        {
                            case "xLgr": dsEnderReme.xLgr = enderReme[i].ChildNodes[j].InnerText;
                                break;

                            case "nro": dsEnderReme.nro = enderReme[i].ChildNodes[j].InnerText;
                                break;

                            case "xCpl": dsEnderReme.xCpl = enderReme[i].ChildNodes[j].InnerText;
                                break;

                            case "xBairro": dsEnderReme.xBairro = enderReme[i].ChildNodes[j].InnerText;
                                break;

                            case "cMun": dsEnderReme.cMun = enderReme[i].ChildNodes[j].InnerText;
                                break;

                            case "xMun": dsEnderReme.xMun = enderReme[i].ChildNodes[j].InnerText;
                                break;

                            case "CEP": dsEnderReme.CEP = enderReme[i].ChildNodes[j].InnerText;
                                break;

                            case "UF": dsEnderReme.UF = enderReme[i].ChildNodes[j].InnerText;
                                break;

                            case "cPais": dsEnderReme.cPais = enderReme[i].ChildNodes[j].InnerText;
                                break;

                            case "xPais": dsEnderReme.xPais = enderReme[i].ChildNodes[j].InnerText;
                                break;

                        }
                    }
                }

                dsEnderReme.pk_enderReme = iChave;
                dsEnderReme.pk_rem = iChave;

                dsCte.enderReme.AddenderRemeRow(dsEnderReme);
                dsEnderReme = dsCte.enderReme.NewenderRemeRow();

                #endregion

                #region infNF

                dsInfNF = dsCte.infNF.NewinfNFRow();

                XmlNodeList infNF = doc.GetElementsByTagName("infNF");

                for (int i = 0; i < infNF.Count; i++)
                {
                    string sNumNF = "";
                    for (int j = 0; j < infNF[i].ChildNodes.Count; j++)
                    {
                        switch (infNF[i].ChildNodes[j].LocalName)
                        {
                            case "serie": dsInfNF.serie = infNF[i].ChildNodes[j].InnerText;
                                break;

                            case "nDoc": dsInfNF.nDoc = infNF[i].ChildNodes[j].InnerText;
                                sNumNF = dsInfNF.nDoc;
                                break;

                            case "dEmi": dsInfNF.dEmi = infNF[i].ChildNodes[j].InnerText;
                                break;

                            case "vBC": dsInfNF.vBC = infNF[i].ChildNodes[j].InnerText;
                                break;

                            case "vICMS": dsInfNF.vICMS = infNF[i].ChildNodes[j].InnerText;
                                break;

                            case "vBCST": dsInfNF.vBCST = infNF[i].ChildNodes[j].InnerText;
                                break;

                            case "vST": dsInfNF.vST = infNF[i].ChildNodes[j].InnerText;
                                break;

                            case "vProd": dsInfNF.vProd = infNF[i].ChildNodes[j].InnerText;
                                break;

                            case "vNF": dsInfNF.vNF = infNF[i].ChildNodes[j].InnerText;
                                break;

                            case "nCFOP": dsInfNF.nCFOP = infNF[i].ChildNodes[j].InnerText;
                                break;
                        }

                    }
                    dsInfNF.TipoNf = "NF";
                    PopulaDadosNf(sNumNF);
                    dsInfNF.pk_infNF = iChaveNota;
                    iChaveNota++;
                    dsInfNF.pk_rem = iChave;

                    dsCte.infNF.AddinfNFRow(dsInfNF);
                    dsInfNF = dsCte.infNF.NewinfNFRow();
                }


                dsInfNF = dsCte.infNF.NewinfNFRow();
                XmlNodeList infNFe = doc.GetElementsByTagName("infNFe");
                for (int i = 0; i < infNFe.Count; i++)
                {

                    for (int j = 0; j < infNFe[i].ChildNodes.Count; j++)
                    {
                        switch (infNFe[i].ChildNodes[j].LocalName)
                        {
                            case "chave": dsInfNF.ChaveNfe = infNFe[i].ChildNodes[j].InnerText;
                                break;
                        }
                    }

                    dsInfNF.TipoNf = "NF-e";
                    dsInfNF.pk_infNF = iChaveNota;
                    iChaveNota++;
                    dsInfNF.pk_rem = iChave;

                    dsCte.infNF.AddinfNFRow(dsInfNF);
                    dsInfNF = dsCte.infNF.NewinfNFRow();
                }

                #endregion

                #region Outros Documentos


                XmlNodeList infOutros = doc.GetElementsByTagName("infOutros");


                dsInfNF = dsCte.infNF.NewinfNFRow();
                for (int i = 0; i < infOutros.Count; i++)
                {
                    string sNumNF = "";
                    for (int j = 0; j < infOutros[i].ChildNodes.Count; j++)
                    {

                        switch (infOutros[i].ChildNodes[j].LocalName)
                        {
                            case "tpDoc": dsInfNF.TipoNf = infOutros[i].ChildNodes[j].InnerText == "00" ? "00-Declaração" : "99-Outros";
                                break;
                            case "nDoc": dsInfNF.nDoc = infOutros[i].ChildNodes[j].InnerText;
                                sNumNF = dsInfNF.nDoc;
                                break;
                            case "dEmi": dsInfNF.dEmi = infOutros[i].ChildNodes[j].InnerText;
                                break;
                        }
                    }

                    PopulaDadosNf(sNumNF);
                    dsInfNF.pk_infNF = iChaveNota;
                    iChaveNota++;
                    dsInfNF.pk_rem = iChave;

                    dsCte.infNF.AddinfNFRow(dsInfNF);
                    dsInfNF = dsCte.infNF.NewinfNFRow();
                }

                #endregion


                #endregion

                #region exped

                #region Dados Exped

                dsExped = dsCte.exped.NewexpedRow();
                XmlNodeList exped = doc.GetElementsByTagName("exped");

                for (int i = 0; i < exped.Count; i++)
                {
                    for (int j = 0; j < exped[i].ChildNodes.Count; j++)
                    {
                        switch (rem[i].ChildNodes[j].LocalName)
                        {
                            case "CNPJ": dsExped.CNPJ = exped[i].ChildNodes[j].InnerText;
                                break;

                            case "CPF": dsExped.CPF = exped[i].ChildNodes[j].InnerText;
                                break;

                            case "IE": dsExped.IE = exped[i].ChildNodes[j].InnerText;
                                break;

                            case "xNome": dsExped.xNome = exped[i].ChildNodes[j].InnerText;
                                break;

                            case "fone": dsExped.fone = exped[i].ChildNodes[j].InnerText;
                                break;

                        }
                    }
                }
                dsExped.pk_infCte = iChave;
                dsExped.pk_exped = iChave;
                dsCte.exped.AddexpedRow(dsExped);
                dsExped = dsCte.exped.NewexpedRow();

                #endregion

                #region EnderExped

                dsEnderExped = dsCte.enderExped.NewenderExpedRow();
                XmlNodeList enderExped = doc.GetElementsByTagName("enderExped");

                for (int i = 0; i < enderExped.Count; i++)
                {
                    for (int j = 0; j < enderExped[i].ChildNodes.Count; j++)
                    {
                        switch (enderReme[i].ChildNodes[j].LocalName)
                        {
                            case "xLgr": dsEnderExped.xLgr = enderExped[i].ChildNodes[j].InnerText;
                                break;

                            case "nro": dsEnderExped.nro = enderExped[i].ChildNodes[j].InnerText;
                                break;

                            case "xCpl": dsEnderExped.xCpl = enderExped[i].ChildNodes[j].InnerText;
                                break;

                            case "xBairro": dsEnderExped.xBairro = enderExped[i].ChildNodes[j].InnerText;
                                break;

                            case "cMun": dsEnderExped.cMun = enderExped[i].ChildNodes[j].InnerText;
                                break;

                            case "xMun": dsEnderExped.xMun = enderExped[i].ChildNodes[j].InnerText;
                                break;

                            case "CEP": dsEnderExped.CEP = enderExped[i].ChildNodes[j].InnerText;
                                break;

                            case "UF": dsEnderExped.UF = enderExped[i].ChildNodes[j].InnerText;
                                break;

                            case "cPais": dsEnderExped.cPais = enderExped[i].ChildNodes[j].InnerText;
                                break;

                            case "xPais": dsEnderExped.xPais = enderExped[i].ChildNodes[j].InnerText;
                                break;

                        }
                    }
                }

                dsEnderExped.pk_enderExped = iChave;
                dsEnderExped.pk_exped = iChave;

                dsCte.enderExped.AddenderExpedRow(dsEnderExped);
                dsEnderExped = dsCte.enderExped.NewenderExpedRow();

                #endregion

                #endregion

                #region receb

                #region Dados Receb

                dsReceb = dsCte.receb.NewrecebRow();
                XmlNodeList receb = doc.GetElementsByTagName("receb");

                for (int i = 0; i < receb.Count; i++)
                {
                    for (int j = 0; j < receb[i].ChildNodes.Count; j++)
                    {
                        switch (receb[i].ChildNodes[j].LocalName)
                        {
                            case "CNPJ": dsReceb.CNPJ = receb[i].ChildNodes[j].InnerText;
                                break;

                            case "CPF": dsReceb.CPF = receb[i].ChildNodes[j].InnerText;
                                break;

                            case "IE": dsReceb.IE = receb[i].ChildNodes[j].InnerText;
                                break;

                            case "xNome": dsReceb.xNome = receb[i].ChildNodes[j].InnerText;
                                break;

                            case "fone": dsReceb.fone = receb[i].ChildNodes[j].InnerText;
                                break;

                        }
                    }
                }
                dsReceb.pk_infCte = iChave;
                dsReceb.pk_receb = iChave;
                dsCte.receb.AddrecebRow(dsReceb);
                dsReceb = dsCte.receb.NewrecebRow();

                #endregion

                #region EnderReceb

                dsEnderReceb = dsCte.enderReceb.NewenderRecebRow();
                XmlNodeList enderReceb = doc.GetElementsByTagName("enderReceb");

                for (int i = 0; i < enderReceb.Count; i++)
                {
                    for (int j = 0; j < enderReceb[i].ChildNodes.Count; j++)
                    {
                        switch (enderReceb[i].ChildNodes[j].LocalName)
                        {
                            case "xLgr": dsEnderReceb.xLgr = enderReceb[i].ChildNodes[j].InnerText;
                                break;

                            case "nro": dsEnderReceb.nro = enderReceb[i].ChildNodes[j].InnerText;
                                break;

                            case "xCpl": dsEnderReceb.xCpl = enderReceb[i].ChildNodes[j].InnerText;
                                break;

                            case "xBairro": dsEnderReceb.xBairro = enderReceb[i].ChildNodes[j].InnerText;
                                break;

                            case "cMun": dsEnderReceb.cMun = enderReceb[i].ChildNodes[j].InnerText;
                                break;

                            case "xMun": dsEnderReceb.xMun = enderReceb[i].ChildNodes[j].InnerText;
                                break;

                            case "CEP": dsEnderReceb.CEP = enderReceb[i].ChildNodes[j].InnerText;
                                break;

                            case "UF": dsEnderReceb.UF = enderReceb[i].ChildNodes[j].InnerText;
                                break;

                            case "cPais": dsEnderReceb.cPais = enderReceb[i].ChildNodes[j].InnerText;
                                break;

                            case "xPais": dsEnderReceb.xPais = enderReceb[i].ChildNodes[j].InnerText;
                                break;

                        }
                    }
                }

                dsEnderReceb.pk_enderReceb = iChave;
                dsEnderReceb.pk_receb = iChave;

                dsCte.enderReceb.AddenderRecebRow(dsEnderReceb);
                dsEnderReceb = dsCte.enderReceb.NewenderRecebRow();

                #endregion

                #endregion

                #region dest

                #region Dados Dest

                dsDest = dsCte.dest.NewdestRow();
                XmlNodeList dest = doc.GetElementsByTagName("dest");

                for (int i = 0; i < dest.Count; i++)
                {
                    for (int j = 0; j < dest[i].ChildNodes.Count; j++)
                    {
                        switch (dest[i].ChildNodes[j].LocalName)
                        {
                            case "CNPJ": dsDest.CNPJ = dest[i].ChildNodes[j].InnerText;
                                break;

                            case "CPF": dsDest.CPF = dest[i].ChildNodes[j].InnerText;
                                break;

                            case "IE": dsDest.IE = dest[i].ChildNodes[j].InnerText;
                                break;

                            case "xNome": dsDest.xNome = dest[i].ChildNodes[j].InnerText;
                                break;

                            case "fone": dsDest.fone = dest[i].ChildNodes[j].InnerText;
                                break;

                            case "ISUF": dsDest.ISUF = dest[i].ChildNodes[j].InnerText;
                                break;

                        }
                    }
                }

                dsDest.pk_dest = iChave;
                dsDest.pk_infCte = iChave;

                dsCte.dest.AdddestRow(dsDest);
                dsDest = dsCte.dest.NewdestRow();

                #endregion

                #region  EnderDest

                dsEnderDest = dsCte.enderDest.NewenderDestRow();
                XmlNodeList enderDest = doc.GetElementsByTagName("enderDest");

                for (int i = 0; i < enderDest.Count; i++)
                {
                    for (int j = 0; j < enderDest[i].ChildNodes.Count; j++)
                    {
                        switch (enderDest[i].ChildNodes[j].LocalName)
                        {
                            case "xLgr": dsEnderDest.xLgr = enderDest[i].ChildNodes[j].InnerText;
                                break;

                            case "nro": dsEnderDest.nro = enderDest[i].ChildNodes[j].InnerText;
                                break;

                            case "xCpl": dsEnderDest.xCpl = enderDest[i].ChildNodes[j].InnerText;
                                break;

                            case "xBairro": dsEnderDest.xBairro = enderDest[i].ChildNodes[j].InnerText;
                                break;

                            case "cMun": dsEnderDest.cMun = enderDest[i].ChildNodes[j].InnerText;
                                break;

                            case "xMun": dsEnderDest.xMun = enderDest[i].ChildNodes[j].InnerText;
                                break;

                            case "CEP": dsEnderDest.CEP = enderDest[i].ChildNodes[j].InnerText;
                                break;

                            case "UF": dsEnderDest.UF = enderDest[i].ChildNodes[j].InnerText;
                                break;

                            case "cPais": dsEnderDest.cPais = enderDest[i].ChildNodes[j].InnerText;
                                break;

                            case "xPais": dsEnderDest.xPais = enderDest[i].ChildNodes[j].InnerText;
                                break;

                        }
                    }
                }

                dsEnderDest.pk_dest = iChave;
                dsEnderDest.pk_enderDest = iChave;

                dsCte.enderDest.AddenderDestRow(dsEnderDest);
                dsEnderDest = dsCte.enderDest.NewenderDestRow();

                #endregion


                #endregion

                #region  vPrest

                dsVprest = dsCte.vPrest.NewvPrestRow();
                XmlNodeList vPrest = doc.GetElementsByTagName("vPrest");


                for (int i = 0; i < vPrest.Count; i++)
                {
                    for (int j = 0; j < vPrest[i].ChildNodes.Count; j++)
                    {
                        switch (vPrest[i].ChildNodes[j].LocalName)
                        {
                            case "vTPrest": dsVprest.vTPrest = vPrest[i].ChildNodes[j].InnerText;
                                break;

                            case "vRec": dsVprest.vRec = vPrest[i].ChildNodes[j].InnerText;
                                break;

                        }
                    }
                }

                dsVprest.pk_vPrest = iChave;
                dsVprest.pk_infCte = iChave;

                dsCte.vPrest.AddvPrestRow(dsVprest);
                dsVprest = dsCte.vPrest.NewvPrestRow();

                dsComp = dsCte.Comp.NewCompRow();
                XmlNodeList Comp = doc.GetElementsByTagName("Comp");


                for (int i = 0; i < Comp.Count; i++)
                {
                    for (int j = 0; j < Comp[i].ChildNodes.Count; j++)
                    {
                        switch (Comp[i].ChildNodes[j].LocalName)
                        {
                            case "xNome": dsComp.xNome = Comp[i].ChildNodes[j].InnerText;
                                break;

                            case "vComp": dsComp.vComp = Comp[i].ChildNodes[j].InnerText;
                                break;

                        }
                    }

                    dsComp.pk_vPrest = iChave;
                    dsComp.pk_Comp = iChaveComp;
                    iChaveComp++;

                    dsCte.Comp.AddCompRow(dsComp);
                    dsComp = dsCte.Comp.NewCompRow();
                }

                #endregion

                #region imp

                dsImp = dsCte.imp.NewimpRow();
                dsImp.pk_imp = iChave;
                dsImp.pk_infCte = iChave;
                dsCte.imp.AddimpRow(dsImp);

                dsICMS = dsCte.ICMS.NewICMSRow();
                dsICMS.pk_ICMS = iChave;
                dsICMS.pk_imp = iChave;
                dsCte.ICMS.AddICMSRow(dsICMS);



                XmlNodeList ICMS00 = doc.GetElementsByTagName("ICMS00");
                XmlNodeList ICMS20 = doc.GetElementsByTagName("ICMS20");
                XmlNodeList ICMS45 = doc.GetElementsByTagName("ICMS45");
                XmlNodeList ICMS60 = doc.GetElementsByTagName("ICMS60");
                XmlNodeList ICMSOutraUF = doc.GetElementsByTagName("ICMSOutraUF");
                XmlNodeList ICMS90 = doc.GetElementsByTagName("ICMS90");

                if (ICMS00.Count > 0)
                {
                    #region ICMS00

                    dsICMS00 = dsCte.ICMS00.NewICMS00Row();

                    for (int i = 0; i < ICMS00.Count; i++)
                    {
                        for (int j = 0; j < ICMS00[i].ChildNodes.Count; j++)
                        {
                            switch (ICMS00[i].ChildNodes[j].LocalName)
                            {
                                case "CST": dsICMS00.CST = ICMS00[i].ChildNodes[j].InnerText;
                                    break;

                                case "vBC": dsICMS00.vBC = ICMS00[i].ChildNodes[j].InnerText;
                                    break;

                                case "pICMS": dsICMS00.pICMS = ICMS00[i].ChildNodes[j].InnerText;
                                    break;

                                case "vICMS": dsICMS00.vICMS = ICMS00[i].ChildNodes[j].InnerText;
                                    break;

                            }
                        }
                    }
                    dsICMS00.pk_ICMS00 = iChave;
                    dsICMS00.pk_ICMS = iChave;
                    dsCte.ICMS00.AddICMS00Row(dsICMS00);
                    dsICMS00 = dsCte.ICMS00.NewICMS00Row();

                    #endregion
                }
                else if (ICMS20.Count > 0)
                {
                    #region ICMS20
                    dsICMS20 = dsCte.ICMS20.NewICMS20Row();

                    for (int i = 0; i < ICMS20.Count; i++)
                    {
                        for (int j = 0; j < ICMS20[i].ChildNodes.Count; j++)
                        {
                            switch (ICMS20[i].ChildNodes[j].LocalName)
                            {
                                case "CST": dsICMS20.CST = ICMS20[i].ChildNodes[j].InnerText;
                                    break;

                                case "pRedBC": dsICMS20.pRedBC = ICMS20[i].ChildNodes[j].InnerText;
                                    break;

                                case "vBC": dsICMS20.vBC = ICMS20[i].ChildNodes[j].InnerText;
                                    break;

                                case "pICMS": dsICMS20.pICMS = ICMS20[i].ChildNodes[j].InnerText;
                                    break;

                                case "vICMS": dsICMS20.vICMS = ICMS20[i].ChildNodes[j].InnerText;
                                    break;

                            }
                        }
                    }
                    dsICMS20.pk_ICMS20 = iChave;
                    dsICMS20.pk_ICMS = iChave;
                    dsCte.ICMS20.AddICMS20Row(dsICMS20);
                    dsICMS20 = dsCte.ICMS20.NewICMS20Row();

                    #endregion
                }
                else if (ICMS45.Count > 0)
                {
                    #region ICMS45
                    dsICMS45 = dsCte.ICMS45.NewICMS45Row();

                    for (int i = 0; i < ICMS45.Count; i++)
                    {
                        for (int j = 0; j < ICMS45[i].ChildNodes.Count; j++)
                        {
                            switch (ICMS45[i].ChildNodes[j].LocalName)
                            {
                                case "CST": dsICMS45.CST = ICMS45[i].ChildNodes[j].InnerText;
                                    break;

                            }
                        }
                    }
                    dsICMS45.pk_ICMS45 = iChave;
                    dsICMS45.pk_ICMS = iChave;
                    dsCte.ICMS45.AddICMS45Row(dsICMS45);
                    dsICMS45 = dsCte.ICMS45.NewICMS45Row();

                    #endregion
                }
                else if (ICMS60.Count > 0)
                {
                    #region ICMS60
                    dsICMS60 = dsCte.ICMS60.NewICMS60Row();

                    for (int i = 0; i < ICMS60.Count; i++)
                    {
                        for (int j = 0; j < ICMS60[i].ChildNodes.Count; j++)
                        {
                            switch (ICMS60[i].ChildNodes[j].LocalName)
                            {
                                case "CST": dsICMS60.CST = ICMS60[i].ChildNodes[j].InnerText;
                                    break;

                                case "vBCSTRet": dsICMS60.vBCSTRet = ICMS60[i].ChildNodes[j].InnerText;
                                    break;

                                case "vICMSSTRet": dsICMS60.vICMSSTRet = ICMS60[i].ChildNodes[j].InnerText;
                                    break;

                                case "pICMSSTRet": dsICMS60.pICMSSTRet = ICMS60[i].ChildNodes[j].InnerText;
                                    break;

                                case "vCred": dsICMS60.vCred = ICMS60[i].ChildNodes[j].InnerText;
                                    break;

                            }
                        }
                    }
                    dsICMS60.pk_ICMS60 = iChave;
                    dsICMS60.pk_ICMS = iChave;
                    dsCte.ICMS60.AddICMS60Row(dsICMS60);
                    dsICMS60 = dsCte.ICMS60.NewICMS60Row();

                    #endregion
                }
                else if (ICMSOutraUF.Count > 0)
                {
                    #region ICMSOutraUF
                    dsICMSOutraUF = dsCte.ICMSOutraUF.NewICMSOutraUFRow();

                    for (int i = 0; i < ICMSOutraUF.Count; i++)
                    {
                        for (int j = 0; j < ICMSOutraUF[i].ChildNodes.Count; j++)
                        {
                            switch (ICMSOutraUF[i].ChildNodes[j].LocalName)
                            {
                                case "CST": dsICMSOutraUF.CST = ICMSOutraUF[i].ChildNodes[j].InnerText;
                                    break;

                                case "pRedBCOutraUF": dsICMSOutraUF.pRedBCOutraUF = ICMSOutraUF[i].ChildNodes[j].InnerText;
                                    break;

                                case "vBCOutraUF": dsICMSOutraUF.vBCOutraUF = ICMSOutraUF[i].ChildNodes[j].InnerText;
                                    break;

                                case "pICMSOutraUF": dsICMSOutraUF.pICMSOutraUF = ICMSOutraUF[i].ChildNodes[j].InnerText;
                                    break;

                                case "vICMSOutraUF": dsICMSOutraUF.vICMSOutraUF = ICMS60[i].ChildNodes[j].InnerText;
                                    break;

                            }
                        }
                    }
                    dsICMSOutraUF.pk_ICMSOutraUF = iChave;
                    dsICMSOutraUF.pk_ICMS = iChave;
                    dsCte.ICMSOutraUF.AddICMSOutraUFRow(dsICMSOutraUF);
                    dsICMSOutraUF = dsCte.ICMSOutraUF.NewICMSOutraUFRow();

                    #endregion
                }
                else if (ICMS90.Count > 0)
                {
                    #region ICMS90
                    dsICMS90 = dsCte.ICMS90.NewICMS90Row();

                    for (int i = 0; i < ICMS90.Count; i++)
                    {
                        for (int j = 0; j < ICMS90[i].ChildNodes.Count; j++)
                        {
                            switch (ICMS90[i].ChildNodes[j].LocalName)
                            {
                                case "CST": dsICMS90.CST = ICMS90[i].ChildNodes[j].InnerText;
                                    break;

                                case "pRedBC": dsICMS90.pRedBC = ICMS90[i].ChildNodes[j].InnerText;
                                    break;

                                case "vBC": dsICMS90.vBC = ICMS90[i].ChildNodes[j].InnerText;
                                    break;

                                case "vICMS": dsICMS90.vICMS = ICMS90[i].ChildNodes[j].InnerText;
                                    break;

                                case "pICMS": dsICMS90.pICMS = ICMS90[i].ChildNodes[j].InnerText;
                                    break;

                                case "vCred": dsICMS90.vCred = ICMS90[i].ChildNodes[j].InnerText;
                                    break;

                            }
                        }
                    }
                    dsICMS90.pk_ICMS90 = iChave;
                    dsICMS90.pk_ICMS = iChave;
                    dsCte.ICMS90.AddICMS90Row(dsICMS90);
                    dsICMS90 = dsCte.ICMS90.NewICMS90Row();

                    #endregion
                }

                dsImp = dsCte.imp.NewimpRow();
                dsICMS = dsCte.ICMS.NewICMSRow();
                #endregion

                #region infCTeNorm

                dsInfCTeNorm = dsCte.infCTeNorm.NewinfCTeNormRow();
                dsInfCTeNorm.pk_infCte = iChave;
                dsInfCTeNorm.pk_infCTeNorm = iChave;

                #region infCarga

                dsInfCarga = dsCte.infCarga.NewinfCargaRow();
                XmlNodeList infCarga = doc.GetElementsByTagName("infCarga");

                for (int i = 0; i < infCarga.Count; i++)
                {
                    for (int j = 0; j < infCarga[i].ChildNodes.Count; j++)
                    {
                        switch (infCarga[i].ChildNodes[j].LocalName)
                        {
                            case "vMerc": dsInfCarga.vMerc = infCarga[i].ChildNodes[j].InnerText;
                                break;

                            case "proPred": dsInfCarga.proPred = infCarga[i].ChildNodes[j].InnerText;
                                break;

                            case "xOutCat": dsInfCarga.proPred = infCarga[i].ChildNodes[j].InnerText;
                                break;

                        }
                    }
                }
                dsInfCarga.pk_infCarga = iChave;
                dsInfCarga.pk_infCTeNorm = iChave;

                dsCte.infCTeNorm.AddinfCTeNormRow(dsInfCTeNorm);
                dsCte.infCarga.AddinfCargaRow(dsInfCarga);

                dsInfCTeNorm = dsCte.infCTeNorm.NewinfCTeNormRow();
                dsInfCarga = dsCte.infCarga.NewinfCargaRow();

                #endregion

                #region infQ

                dsInfQ = dsCte.infQ.NewinfQRow();
                XmlNodeList infQ = doc.GetElementsByTagName("infQ");

                for (int i = 0; i < infQ.Count; i++)
                {
                    for (int j = 0; j < infQ[i].ChildNodes.Count; j++)
                    {
                        switch (infQ[i].ChildNodes[j].LocalName)
                        {
                            case "cUnid": dsInfQ.cUnid = infQ[i].ChildNodes[j].InnerText;
                                break;

                            case "tpMed": dsInfQ.tpMed = infQ[i].ChildNodes[j].InnerText;
                                break;

                            case "qCarga": dsInfQ.qCarga = Convert.ToDecimal(infQ[i].ChildNodes[j].InnerText.Replace(".", ",")).ToString("N0");
                                break;

                        }
                    }
                    dsInfQ.pk_infCarga = iChave;
                    dsInfQ.pk_infQ = iChaveCarga;
                    iChaveCarga++;

                    dsCte.infQ.AddinfQRow(dsInfQ);
                    dsInfQ = dsCte.infQ.NewinfQRow();
                }

                #endregion

                #region seg

                dsSeg = dsCte.seg.NewsegRow();
                XmlNodeList seg = doc.GetElementsByTagName("seg");

                for (int i = 0; i < seg.Count; i++)
                {
                    for (int j = 0; j < seg[i].ChildNodes.Count; j++)
                    {
                        switch (seg[i].ChildNodes[j].LocalName)
                        {
                            case "respSeg": dsSeg.respSeg = seg[i].ChildNodes[j].InnerText;
                                break;

                            case "nApol": dsSeg.nApol = seg[i].ChildNodes[j].InnerText;
                                break;

                        }
                    }
                }

                dsSeg.pk_infCTeNorm = iChave;
                dsSeg.pk_seg = iChave;

                dsCte.seg.AddsegRow(dsSeg);
                dsSeg = dsCte.seg.NewsegRow();

                #endregion

                #region rodo

                dsRodo = dsCte.rodo.NewrodoRow();
                XmlNodeList rodo = doc.GetElementsByTagName("rodo");

                for (int i = 0; i < rodo.Count; i++)
                {
                    for (int j = 0; j < rodo[i].ChildNodes.Count; j++)
                    {
                        switch (rodo[i].ChildNodes[j].LocalName)
                        {
                            case "RNTRC": dsRodo.RNTRC = rodo[i].ChildNodes[j].InnerText;
                                break;

                            case "dPrev": dsRodo.dPrev = Convert.ToDateTime(rodo[i].ChildNodes[j].InnerText);
                                break;

                            case "lota": dsRodo.lota = rodo[i].ChildNodes[j].InnerText;
                                break;

                        }
                    }
                }

                dsRodo.pk_infCTeNorm = iChave;
                dsRodo.pk_rodo = iChave;

                dsCte.rodo.AddrodoRow(dsRodo);
                dsRodo = dsCte.rodo.NewrodoRow();

                #endregion

                # region moto
                dsMoto = dsCte.moto.NewmotoRow();
                XmlNodeList moto = doc.GetElementsByTagName("moto");

                for (int i = 0; i < moto.Count; i++)
                {
                    for (int j = 0; j < moto[i].ChildNodes.Count; j++)
                    {
                        switch (moto[i].ChildNodes[j].LocalName)
                        {
                            case "xNome": dsMoto.xNome = moto[i].ChildNodes[j].InnerText;
                                break;

                            case "CPF": dsMoto.CPF = moto[i].ChildNodes[j].InnerText;
                                break;


                        }
                    }
                }

                dsMoto.pk_rodo = iChave;
                dsMoto.pk_moto = iChave;

                dsCte.moto.AddmotoRow(dsMoto);
                dsMoto = dsCte.moto.NewmotoRow();
                #endregion

                #region veic
                dsVeic = dsCte.veic.NewveicRow();

                XmlNodeList veic = doc.GetElementsByTagName("veic");

                for (int i = 0; i < veic.Count; i++)
                {

                    for (int j = 0; j < veic[i].ChildNodes.Count; j++)
                    {
                        switch (veic[i].ChildNodes[j].LocalName)
                        {
                            case "RENAVAM": dsVeic.RENAVAM = veic[i].ChildNodes[j].InnerText;
                                break;

                            case "placa": dsVeic.placa = veic[i].ChildNodes[j].InnerText;
                                break;

                            case "tara": dsVeic.tara = veic[i].ChildNodes[j].InnerText;
                                break;

                            case "capKG": dsVeic.capKG = veic[i].ChildNodes[j].InnerText;
                                break;

                            case "capM3": dsVeic.capM3 = veic[i].ChildNodes[j].InnerText;
                                break;

                            case "tpProp": dsVeic.tpProp = veic[i].ChildNodes[j].InnerText;
                                break;

                            case "tpVeic": dsVeic.tpVeic = veic[i].ChildNodes[j].InnerText;
                                break;

                            case "tpRod": dsVeic.tpRod = veic[i].ChildNodes[j].InnerText;
                                break;

                            case "tpCar": dsVeic.tpCar = veic[i].ChildNodes[j].InnerText;
                                break;

                            case "UF": dsVeic.UF = veic[i].ChildNodes[j].InnerText;
                                break;

                            case "prop": dsVeic.RNTRC = veic[i].ChildNodes[j].ChildNodes.Item(1).InnerText;
                                break;

                        }

                    }

                    dsVeic.pk_rodo = iChave;
                    dsVeic.pk_veic = iChaveVeic;
                    iChaveVeic++;

                    dsCte.veic.AddveicRow(dsVeic);
                    dsVeic = dsCte.veic.NewveicRow();
                }



                #endregion

                dsInfCTeNorm = dsCte.infCTeNorm.NewinfCTeNormRow();

                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        private void PopulaDadosNf(string sNumNf)
        {


            try
            {
                StringBuilder sQuery = new StringBuilder();
                sQuery.Append("Select ");
                sQuery.Append("coalesce(nfconhec.cd_cgc,'')cnpj, ");
                sQuery.Append("coalesce(nfconhec.cd_cpf,'')cpf, ");
                sQuery.Append("coalesce(nfconhec.cd_serie,'')serie ");
                sQuery.Append("from nfconhec ");
                sQuery.Append("join empresa on nfconhec.cd_empresa ='" + Acesso.CD_EMPRESA + "' ");
                sQuery.Append("where nfconhec.cd_nf ='" + sNumNf + "' ");
                sQuery.Append("and empresa.cd_empresa ='" + Acesso.CD_EMPRESA + "'");



                DataTable dt = HlpDbFuncoes.qrySeekRet(sQuery.ToString());
                foreach (DataRow dr in dt.Rows)
                {
                    if (dr["cnpj"].ToString() != "")
                    {
                        dsInfNF.CPFCNPJ = dr["cnpj"].ToString();
                    }
                    else if (dr["cpf"].ToString() != "")
                    {
                        dsInfNF.CPFCNPJ = dr["cpf"].ToString();
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
        public bool VerificaLotacao(string sCaminho)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(sCaminho);

                XmlNodeList rodo = doc.GetElementsByTagName("rodo");

                bool Ret = false;
                for (int i = 0; i < rodo.Count; i++)
                {
                    for (int j = 0; j < rodo[i].ChildNodes.Count; j++)
                    {
                        switch (rodo[i].ChildNodes[j].LocalName)
                        {

                            case "lota":
                                if (rodo[i].ChildNodes[j].InnerText == "1")
                                {
                                    Ret = true;
                                }
                                break;

                        }
                    }
                }
                return Ret;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        private Byte[] SalvaCodBarras(string sValor)
        {
            DirectoryInfo dBarras = new DirectoryInfo(Pastas.CBARRAS);
            if (!dBarras.Exists) { dBarras.Create(); }

            BarcodeLib.Barcode barcod = new BarcodeLib.Barcode(sValor, BarcodeLib.TYPE.CODE128C);
            barcod.Encode(BarcodeLib.TYPE.CODE128, sValor, 300, 150);

            string sCaminho = dBarras.ToString() + sValor + ".JPG";

            barcod.SaveImage(@sCaminho, BarcodeLib.SaveTypes.JPG);

            return carregaImagem(sCaminho);
        }
        private Byte[] carregaImagem(string fileName)
        {
            FileStream fs = null;
            BinaryReader br = null;
            try
            {
                fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                br = new BinaryReader(fs);
            }
            catch (Exception ex)
            {

                br = null;
            }

            if (br != null)
            {
                return (br.ReadBytes(Convert.ToInt32(br.BaseStream.Length)));
            }
            else
            {
                return null;
            }


        }
    }
}
