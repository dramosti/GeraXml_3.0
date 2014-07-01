using HLP.GeraXml.Comum;
using HLP.GeraXml.Comum.Static;
using HLP.GeraXml.dao;
using HLP.GeraXml.dao.CTe.MDFe;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using CrystalDecisions.CrystalReports.Engine;

namespace HLP.GeraXml.bel.MDFe.Acoes
{
    public sealed class belDadosManifesto
    {

        private TEnviMDFe _enviMDFe;
        public TEnviMDFe enviMDFe
        {
            get { return _enviMDFe; }
            set
            {
                _enviMDFe = value;
            }
        }
        public PesquisaManifestosModel objManifesto { get; set; }
        EnumerableRowCollection<DataRow> infDoc;
        public rodo objRodo { get; set; }
        public string sPathLote = string.Empty;
        public belTransmiteMDFe Envio { get; set; }
        public string xmlFinal;

        public belDadosManifesto(PesquisaManifestosModel objManifesto)
        {
            this.objManifesto = objManifesto;
            this.enviMDFe = new TEnviMDFe();

            this.enviMDFe.MDFe = new TMDFe();
            this.enviMDFe.MDFe.infMDFe = new TMDFeInfMDFe();
            this.enviMDFe.MDFe.infMDFe.versao = Acesso.versaoMDFe;

            this.getIDE();
            this.getEmit();
            this.enviMDFe.idLote = this.enviMDFe.MDFe.infMDFe.ide.nMDF; // numero do lote.
            this.enviMDFe.versao = Acesso.versaoMDFe;
            this.GetInfDoc();
            this.GetTot();
            string sObs = daoManifesto.GetObs(objManifesto.sequencia);
            if (!(string.IsNullOrEmpty(sObs)))
            {
                this.enviMDFe.MDFe.infMDFe.infAdic = new TMDFeInfMDFeInfAdic();
                this.enviMDFe.MDFe.infMDFe.infAdic.infCpl = daoManifesto.GetObs(objManifesto.sequencia);
            }
            this.GetRodoviarioPrincipal();
            this.enviMDFe.MDFe.infMDFe.infModal = new TMDFeInfMDFeInfModal();
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("", "http://www.portalfiscal.inf.br/mdfe");
            string sRodo = SerializeToString<rodo>(objRodo, ns);
            System.Xml.XmlDocument xml = new XmlDocument();
            xml.LoadXml(sRodo);
            this.enviMDFe.MDFe.infMDFe.infModal.Any = xml.DocumentElement;
            this.enviMDFe.MDFe.infMDFe.infModal.versaoModal = Acesso.versaoMDFe;
            this.enviMDFe.MDFe.infMDFe.ide.cDV = GeraChaveMDFe().ToString();
            this.GeraXmlAndValida();

            string sPathRodo = Pastas.ENVIO + this.enviMDFe.MDFe.infMDFe.Id.Substring(6, 4) + "\\rodo_" + this.enviMDFe.idLote + ".xml";
            if (File.Exists(sPathRodo))
                File.Delete(sPathRodo);
            xml.Save(sPathRodo);

            try
            {
                belValidaXml.ValidarXml("http://www.portalfiscal.inf.br/mdfe", Pastas.SCHEMA_MDFe + "\\mdfeModalRodoviario_v1.00.xsd", sPathRodo);
            }
            catch (Exception ex)
            {
                throw ex;
            }


            Envio = new belTransmiteMDFe(this.sPathLote, this.enviMDFe, this.xmlFinal);
        }

        #region BuscaDados
        #region Estrutura Genérica
        void getIDE()
        {
            this.enviMDFe.MDFe.infMDFe.ide = daoManifesto.GetIDE(objManifesto.sequencia).AsEnumerable().Select(c =>
                new TMDFeInfMDFeIde
                {
                    cUF = Acesso.cUF.ToString(),
                    tpAmb = Acesso.TP_AMB == 1 ? TAmb.Item1 : TAmb.Item2,
                    tpEmit = c["tpEmit"].ToString() == "1" ? TEmit.Item1 : TEmit.Item2,
                    mod = TModMD.Item58,
                    serie = Convert.ToInt32(c["serie"].ToString()).ToString(),
                    nMDF = (Convert.ToInt32(objManifesto.numero)).ToString(),
                    cMDF = objManifesto.sequencia.ToString().PadLeft(8, '0'),
                    cDV = "",
                    modal = TModalMD.Item1,
                    dhEmi = daoUtil.GetDateServidor().ToString("yyyy-MM-ddTHH:mm:ss"),
                    tpEmis = TMDFeInfMDFeIdeTpEmis.Item1,
                    procEmi = TMDFeInfMDFeIdeProcEmi.Item0,
                    verProc = Acesso.versaoMDFe,
                    UFIni = c["UFIni"].ToString(),
                    UFFim = c["UFFim"].ToString(),

                }).FirstOrDefault();

            EnumerableRowCollection<DataRow> infMun = daoManifesto.GetInfMunCarrega(objManifesto.sequencia).AsEnumerable();
            this.enviMDFe.MDFe.infMDFe.ide.infMunCarrega = infMun.Select(c =>
                    new TMDFeInfMDFeIdeInfMunCarrega
                    {
                        cMunCarrega = c["cMunCarrega"].ToString(),
                        xMunCarrega = c["xMunCarrega"].ToString()
                    }
                ).ToList();
            List<string> lUFPer = infMun.Select(c => c["UFPer"].ToString()).Distinct().ToList();
            foreach (string uf in lUFPer)
            {
                if (this.enviMDFe.MDFe.infMDFe.ide.UFFim.Equals(uf) || this.enviMDFe.MDFe.infMDFe.ide.UFIni.Equals(uf))
                {
                    this.enviMDFe.MDFe.infMDFe.ide.infPercurso = null;
                }
                else
                {
                    if (this.enviMDFe.MDFe.infMDFe.ide.infPercurso == null)
                    {
                        this.enviMDFe.MDFe.infMDFe.ide.infPercurso = new List<TMDFeInfMDFeIdeInfPercurso>();
                    }
                    this.enviMDFe.MDFe.infMDFe.ide.infPercurso.Add(new TMDFeInfMDFeIdeInfPercurso { UFPer = uf });
                }
            }


        }
        void getEmit()
        {
            try
            {
                this.enviMDFe.MDFe.infMDFe.emit = daoManifesto.GetEmit().AsEnumerable().Select(c => new TMDFeInfMDFeEmit
                {
                    CNPJ = Util.RetiraCaracterCNPJ(c["CNPJ"].ToString()),
                    enderEmit = new TEndeEmi
                        {
                            CEP = Util.TiraSimbolo(c["CEP"].ToString()),
                            cMun = c["cMun"].ToString(),
                            email = c["email"].ToString(),
                            fone = Util.TiraSimbolo(c["fone"].ToString()),
                            nro = c["nro"].ToString(),
                            UF = c["UF"].ToString(),
                            xBairro = c["xBairro"].ToString(),
                            xCpl = c["xCpl"].ToString() == "" ? null : c["xCpl"].ToString(),
                            xLgr = c["xLgr"].ToString(),
                            xMun = c["xMun"].ToString()
                        },
                    IE = c["IE"].ToString().Replace(".", "").Trim(),
                    xFant = c["xFant"].ToString(),
                    xNome = c["xNome"].ToString()

                }).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        void GetInfDoc()
        {
            try
            {
                infDoc = daoManifesto.GetInfDoc(objManifesto.sequencia).AsEnumerable();

                foreach (DataRow row in infDoc)
                {
                    if (this.enviMDFe.MDFe.infMDFe.infDoc == null)
                        this.enviMDFe.MDFe.infMDFe.infDoc = new List<TMDFeInfMDFeInfMunDescarga>();

                    if (this.enviMDFe.MDFe.infMDFe.infDoc.Where(C => C.cMunDescarga == row["cMunDescarga"].ToString()).Count() == 0)
                    {
                        this.enviMDFe.MDFe.infMDFe.infDoc.Add(new TMDFeInfMDFeInfMunDescarga
                            {
                                cMunDescarga = row["cMunDescarga"].ToString(),
                                xMunDescarga = row["xMunDescarga"].ToString()
                            });
                    }
                }

                //this.enviMDFe.MDFe.infMDFe.infDoc = infDoc.Select(c => new TMDFeInfMDFeInfMunDescarga
                //{
                //    cMunDescarga = c["cMunDescarga"].ToString(),
                //    xMunDescarga = c["xMunDescarga"].ToString()
                //}
                //).ToList().Distinct().ToList();

                foreach (TMDFeInfMDFeInfMunDescarga doc in enviMDFe.MDFe.infMDFe.infDoc)
                {
                    doc.infCTe = infDoc.Where(w => w["chCTe"] != null && w["xMunDescarga"].ToString() == doc.xMunDescarga).Select(i => new TMDFeInfMDFeInfMunDescargaInfCTe
                    {
                        chCTe = i["chCTe"].ToString()
                    }
                    ).ToArray();

                    doc.infCT = infDoc.Where(w => w["chCTe"] == null && w["xMunDescarga"].ToString() == doc.xMunDescarga).Select(i => new TMDFeInfMDFeInfMunDescargaInfCT
                    {
                        dEmi = Convert.ToDateTime(i["dEmi"].ToString()).ToString("yyyy-mm-dd"),
                        nCT = i["nCT"].ToString(),
                        serie = i["serie"].ToString(),
                        subser = i["subser"].ToString(),
                        vCarga = i["vCarga"].ToString().Replace(",", ".")
                    }
                   ).ToArray();

                    //EnumerableRowCollection<DataRow> lNFs;

                    //foreach (string nr_lanc in infDoc.Where(w => w["xMunDescarga"].ToString() == doc.xMunDescarga).Select(c => c["nr_lanc"]).ToList())
                    //{
                    //    lNFs = daoManifesto.GetInfNF(nrlanc: nr_lanc).AsEnumerable();

                    //    doc.infNFe = lNFs.Where(c => c["chNFe"] != null).Select(c => new TMDFeInfMDFeInfMunDescargaInfNFe
                    //    {
                    //        chNFe = c["chNFe"].ToString()
                    //    }).ToArray();

                    //    doc.infNF = lNFs.Where(c => c["chNFe"] == null).Select(c => new TMDFeInfMDFeInfMunDescargaInfNF
                    //    {
                    //        CNPJ = Util.RetiraCaracterCNPJ(c["CNPJ"].ToString()),
                    //        dEmi = Convert.ToDateTime(c["dEmi"].ToString()).ToString("yyyy-MM-dd"),
                    //        nNF = c["nNF"].ToString(),
                    //        serie = c["serie"].ToString(),
                    //        UF = c["UF"].ToString(),
                    //        vNF = c["vNF"].ToString(),
                    //    }).ToArray();

                    //}
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        void GetTot()
        {
            try
            {
                this.enviMDFe.MDFe.infMDFe.tot = new TMDFeInfMDFeTot();
                this.enviMDFe.MDFe.infMDFe.tot.qCT = this.enviMDFe.MDFe.infMDFe.infDoc.Select(c => c.infCT != null ? c.infCT.Count() : 0).ToList().Sum().ToString();
                this.enviMDFe.MDFe.infMDFe.tot.qCTe = this.enviMDFe.MDFe.infMDFe.infDoc.Select(c => c.infCTe != null ? c.infCTe.Count() : 0).ToList().Sum().ToString();
                this.enviMDFe.MDFe.infMDFe.tot.qNFe = this.enviMDFe.MDFe.infMDFe.infDoc.Select(c => c.infNFe != null ? c.infNFe.Count() : 0).ToList().Sum().ToString();
                this.enviMDFe.MDFe.infMDFe.tot.qNF = this.enviMDFe.MDFe.infMDFe.infDoc.Select(c => c.infNF != null ? c.infNF.Count() : 0).ToList().Sum().ToString();




                this.enviMDFe.MDFe.infMDFe.tot.cUnid = TMDFeInfMDFeTotCUnid.Item01;

                decimal vCarga = 0;
                decimal qCarga = 0;

                //foreach (string nr_lanc in infDoc.Select(c => c["nr_lanc"].ToString()).ToList())
                //{
                //    foreach (DataRow row in daoManifesto.GetTot(nrLanc: nr_lanc).Rows)
                //    {
                //        vCarga += Convert.ToDecimal(row["vCarga"].ToString());
                //        qCarga += Convert.ToDecimal(row["qCarga"].ToString());
                //    }
                //}

                foreach (string nr_lanc in infDoc.Select(c => c["nr_lanc"].ToString()).ToList())
                {
                    foreach (DataRow row in daoManifesto.GetTotTemporario(nrLanc: nr_lanc).Rows)
                    {
                        vCarga += Convert.ToDecimal(row["vl_nf"].ToString());
                        qCarga += Convert.ToDecimal(row["vl_peso"].ToString());
                    }
                }



                this.enviMDFe.MDFe.infMDFe.tot.vCarga = vCarga.ToString("#0.00").Replace(",", ".");
                this.enviMDFe.MDFe.infMDFe.tot.qCarga = qCarga.ToString("#0.0000").Replace(",", ".");
            }
            catch (Exception)
            {
                throw;
            }

        }
        #endregion

        #region Rodoviário

        private void GetRodoviarioPrincipal()
        {
            try
            {
                objRodo = new rodo();
                foreach (DataRow row in daoManifesto.GetVeiculoTracao(objManifesto.sequencia).Rows)
                {
                    objRodo.RNTRC = row["RNTRC"].ToString();
                    objRodo.CIOT = row["CIOT"].ToString();
                    if (objRodo.CIOT == "")
                        objRodo.CIOT = null;

                    objRodo.veicTracao = new rodoVeicTracao();
                    objRodo.veicTracao.cInt = row["cInt"].ToString();
                    objRodo.veicTracao.placa = row["placa"].ToString();
                    objRodo.veicTracao.tara = row["tara"].ToString();
                    objRodo.veicTracao.capKG = row["capKG"].ToString();
                    objRodo.veicTracao.capM3 = row["capM3"].ToString();
                    if (row["st_veiculo"].ToString().Equals("N"))
                    {
                        objRodo.veicTracao.prop = daoManifesto.GetVeiculoProp(objManifesto.sequencia).AsEnumerable().Select(c => new rodoVeicTracaoProp
                        {
                            IE = c["IE"].ToString().Replace(".", "").Trim(),
                            RNTRC = c["RNTRC"].ToString(),
                            tpProp = c["tpProp"].ToString().Equals("P") ? rodoVeicTracaoPropTpProp.Item0 : rodoVeicTracaoPropTpProp.Item1,
                            UF = c["UF"].ToString(),
                            xNome = c["xNome"].ToString(),
                            Item = Util.RetiraCaracterCNPJ(c["CNPJ"].ToString()),
                        }).FirstOrDefault();

                        objRodo.veicTracao.prop.ItemElementName = objRodo.veicTracao.prop.Item.ToString().Count() == 14 ? ItemChoiceType.CNPJ : ItemChoiceType.CPF;

                        objRodo.veicTracao.condutor = daoManifesto.GetMotorista(objManifesto.sequencia).AsEnumerable().Select(c => new rodoVeicTracaoCondutor
                        {
                            xNome = c["xNome"].ToString(),
                            CPF = Util.RetiraCaracterCNPJ(c["cpf"].ToString())
                        }).ToArray();
                    }

                }

                objRodo.veicReboque = new List<rodoVeicReboque>();
                foreach (DataRow c in daoManifesto.GetVeiculoReboque(objManifesto.sequencia).AsEnumerable())
                {
                    rodoVeicReboque reboc = new rodoVeicReboque
                    {
                        capKG = c["capKG"].ToString(),
                        capM3 = c["capM3"].ToString(),
                        cInt = c["cInt"].ToString(),
                        placa = c["placa"].ToString(),
                        tara = c["tara"].ToString(),
                        tpCar = c["tpCar"].ToString().Equals("0") ? rodoVeicReboqueTpCar.Item00 : rodoVeicReboqueTpCar.Item01, //VERIFICAR
                        UF = c["UF"].ToString()
                    };

                    if (c["st_proprietario"].ToString().Equals("S"))
                    {
                        reboc.prop = new rodoVeicReboqueProp();
                        reboc.prop.Item = Util.RetiraCaracterCNPJ(c["CNPJ"].ToString());
                        reboc.prop.ItemElementName = reboc.prop.Item.ToString().Count() == 14 ? ItemChoiceType1.CNPJ : ItemChoiceType1.CPF;
                        reboc.prop.RNTRC = c["RNTRC"].ToString();
                        reboc.prop.xNome = c["xNome"].ToString();
                        reboc.prop.IE = c["IE"].ToString().Replace(".", "").Trim();
                        reboc.prop.UF = c["UF"].ToString();
                        reboc.prop.tpProp = c["tpProp"].ToString().Equals("0") ? rodoVeicReboquePropTpProp.Item0 : rodoVeicReboquePropTpProp.Item1;
                    }
                    objRodo.veicReboque.Add(reboc);

                }


                foreach (DataRow c in daoManifesto.GetValePed(objManifesto.sequencia).Rows)
                {
                    if (objRodo.valePed == null) objRodo.valePed = new List<rodoDisp>();
                    objRodo.valePed.Add(new rodoDisp
                    {
                        CNPJForn = Util.RetiraCaracterCNPJ(c["CNPJForn"].ToString()),
                        CNPJPg = Util.RetiraCaracterCNPJ(c["CNPJPg"].ToString()),
                        nCompra = c["nCompra"].ToString()
                    }); ;
                }



            }
            catch (Exception ex)
            {
                throw ex;
            }
        }




        #endregion
        #endregion

        /// <summary>
        /// Retorna o codigo do digito veririfcador
        /// </summary>
        /// <returns></returns>
        public int GeraChaveMDFe()
        {
            string cUF, AAMM, CNPJ, mod, serie, nMDFe, tpEmis, cMDFe = "";

            cUF = Acesso.cUF.ToString();
            AAMM = daoUtil.GetDateServidor().ToString("yyMM");
            CNPJ = this.enviMDFe.MDFe.infMDFe.emit.CNPJ.PadLeft(14, '0');
            mod = this.enviMDFe.MDFe.infMDFe.ide.mod.ToString().Replace("Item", "");
            serie = this.enviMDFe.MDFe.infMDFe.ide.serie;
            nMDFe = this.enviMDFe.MDFe.infMDFe.ide.nMDF.ToString();
            tpEmis = this.enviMDFe.MDFe.infMDFe.ide.tpEmis.ToString().Replace("Item", "");
            cMDFe = this.enviMDFe.MDFe.infMDFe.ide.cMDF.ToString();

            string sChave = cUF.PadLeft(2, '0').Trim() +
                            AAMM.Trim() +
                            CNPJ.PadLeft(14, '0').Trim() +
                            mod.PadLeft(2, '0').Trim() +
                            serie.PadLeft(3, '0').Trim() +
                            nMDFe.PadLeft(9, '0').Trim() +
                            tpEmis.Trim() +
                            cMDFe.PadLeft(8, '0').Trim();


            int i = daoUtil.CalculaDig11(sChave);

            this.enviMDFe.MDFe.infMDFe.Id = "MDFe" + sChave + i.ToString();

            return i;

        }
        private string SerializeToString<T>(object objToSerialize, XmlSerializerNamespaces ns) where T : class
        {
            XmlSerializer xs = new XmlSerializer(typeof(T));
            MemoryStream memory = new MemoryStream();
            XmlTextWriter xmltext = new XmlTextWriter(memory, Encoding.UTF8);
            xs.Serialize(xmltext, objToSerialize, ns);
            UTF8Encoding encoding = new UTF8Encoding();
            string sResult = encoding.GetString(memory.ToArray());
            sResult = sResult.Substring(1);
            return sResult.Replace("<?xml version=\"1.0\" encoding=\"utf-8\"?>", "");
        }
        public void GeraXmlAndValida()
        {
            try
            {
                // Path do lote.
                if (!Directory.Exists(Pastas.ENVIO + this.enviMDFe.MDFe.infMDFe.Id.Substring(6, 4)))
                    Directory.CreateDirectory(Pastas.ENVIO + this.enviMDFe.MDFe.infMDFe.Id.Substring(6, 4));
                sPathLote = Pastas.ENVIO + this.enviMDFe.MDFe.infMDFe.Id.Substring(6, 4) + "\\Lote_" + this.enviMDFe.idLote + ".xml";

                if (File.Exists(sPathLote))
                    File.Delete(sPathLote);




                belAssinaXml Assinatura = new belAssinaXml();
                XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                ns.Add("", "http://www.portalfiscal.inf.br/mdfe");
                string xmlToAssinar = SerializeToString<TMDFe>(this.enviMDFe.MDFe, ns);
                string xmlAssinado = Assinatura.ConfigurarArquivo(xmlToAssinar, "infMDFe", Acesso.cert_CTe);
                //Estou inserindo o enviNFe pois se eu transformar o arquivo xml assinado em xml e depois em texto usando um toString,
                //a assinatura se torna invalida. Então depois de assinado do trabalho em forma de texto como xml ateh envia-lo pra fazenda.   
                xmlFinal = "<?xml version=\"1.0\" encoding=\"utf-8\"?><enviMDFe xmlns=\"http://www.portalfiscal.inf.br/mdfe\" versao=\"1.00\"><idLote>" +
                    this.enviMDFe.idLote.PadLeft(15, '0') + "</idLote>" + xmlAssinado + "</enviMDFe>";

                XElement xnfe = XElement.Parse(xmlFinal);
                XDocument xdSave = new XDocument(xnfe);

                xdSave.Save(sPathLote);

                belValidaXml.ValidarXml("http://www.portalfiscal.inf.br/mdfe", Pastas.SCHEMA_MDFe + "\\enviMDFe_v1.00.xsd", sPathLote);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
