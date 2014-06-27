using HLP.GeraXml.Comum.Static;
using HLP.GeraXml.dao;
using HLP.GeraXml.dao.CTe.MDFe;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

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
        string numero { get; set; }
        string sequencia { get; set; }
        EnumerableRowCollection<DataRow> infDoc;
        public rodo objRodo { get; set; }




        public belDadosManifesto(string numero, string sequencia)
        {
            this.numero = numero;
            this.sequencia = sequencia;
            this.enviMDFe = new TEnviMDFe();
            this.enviMDFe.MDFe = new TMDFe();
            this.enviMDFe.MDFe.infMDFe = new TMDFeInfMDFe();
            this.getIDE();
            this.getEmit();
            this.GetInfDoc();
            this.GetTot();
            this.enviMDFe.MDFe.infMDFe.infAdic = new TMDFeInfMDFeInfAdic();
            this.enviMDFe.MDFe.infMDFe.infAdic.infCpl = daoManifesto.GetObs(sequencia);

            this.GetRodoviarioPrincipal();

            this.enviMDFe.MDFe.infMDFe.infModal = new TMDFeInfMDFeInfModal();
            this.enviMDFe.MDFe.infMDFe.infModal.Any = null;

        }
        #region Estrutura Genérica
        void getIDE()
        {
            this.enviMDFe.MDFe.infMDFe.ide = daoManifesto.GetIDE(sequencia).AsEnumerable().Select(c =>
                new TMDFeInfMDFeIde
                {
                    cUF = Acesso.cUF.ToString(),
                    tpAmb = Acesso.TP_AMB == 1 ? TAmb.Item1 : TAmb.Item2,
                    tpEmit = c["tpEmit"].ToString() == "1" ? TEmit.Item1 : TEmit.Item2,
                    mod = TModMD.Item58,
                    serie = c["serie"].ToString(),
                    nMDF = numero,
                    cMDF = sequencia,
                    cDV = "",
                    modal = TModalMD.Item1,
                    dhEmi = daoUtil.GetDateServidor().ToString("yyyy-MM-ddTHH:mm:ss"),
                    tpEmis = TMDFeInfMDFeIdeTpEmis.Item1,
                    procEmi = TMDFeInfMDFeIdeProcEmi.Item0,
                    verProc = Acesso.versaoMDFe,
                    UFIni = c["UFIni"].ToString(),
                    UFFim = c["UFFim"].ToString(),

                }).FirstOrDefault();

            EnumerableRowCollection<DataRow> infMun = daoManifesto.GetInfMunCarrega(sequencia).AsEnumerable();
            this.enviMDFe.MDFe.infMDFe.ide.infMunCarrega = infMun.Select(c =>
                    new TMDFeInfMDFeIdeInfMunCarrega
                    {
                        cMunCarrega = c["cMunCarrega"].ToString(),
                        xMunCarrega = c["xMunCarrega"].ToString()
                    }
                ).ToList();
            List<string> lUFPer = infMun.Select(c => c["UFPer"].ToString()).Distinct().ToList();
            this.enviMDFe.MDFe.infMDFe.ide.infPercurso = new List<TMDFeInfMDFeIdeInfPercurso>();
            foreach (string uf in lUFPer)
            {
                this.enviMDFe.MDFe.infMDFe.ide.infPercurso.Add(new TMDFeInfMDFeIdeInfPercurso { UFPer = uf });
            }


        }
        void getEmit()
        {
            try
            {
                this.enviMDFe.MDFe.infMDFe.emit = daoManifesto.GetEmit().AsEnumerable().Select(c => new TMDFeInfMDFeEmit
                {
                    CNPJ = c["CNPJ"].ToString(),
                    enderEmit = new TEndeEmi
                        {
                            CEP = c["CEP"].ToString(),
                            cMun = c["cMun"].ToString(),
                            email = c["email"].ToString(),
                            fone = c["fone"].ToString(),
                            nro = c["nro"].ToString(),
                            UF = c["UF"].ToString(),
                            xBairro = c["xBairro"].ToString(),
                            xCpl = c["xCpl"].ToString(),
                            xLgr = c["xLgr"].ToString(),
                            xMun = c["xMun"].ToString()
                        },
                    IE = c["IE"].ToString(),
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
                infDoc = daoManifesto.GetInfDoc(sequencia).AsEnumerable();

                this.enviMDFe.MDFe.infMDFe.infDoc = infDoc.Select(c => new TMDFeInfMDFeInfMunDescarga
                {
                    cMunDescarga = c["cMunDescarga"].ToString(),
                    xMunDescarga = c["xMunDescarga"].ToString()
                }
                ).Distinct().ToList();

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
                        vCarga = i["vCarga"].ToString()
                    }
                   ).ToArray();

                    EnumerableRowCollection<DataRow> lNFs;

                    foreach (string nr_lanc in infDoc.Where(w => w["xMunDescarga"].ToString() == doc.xMunDescarga).Select(c => c["nr_lanc"]).ToList())
                    {
                        lNFs = daoManifesto.GetInfNF(nrlanc: nr_lanc).AsEnumerable();

                        doc.infNFe = lNFs.Where(c => c["chNFe"] != null).Select(c => new TMDFeInfMDFeInfMunDescargaInfNFe
                        {
                            chNFe = c["chNFe"].ToString()
                        }).ToArray();

                        doc.infNF = lNFs.Where(c => c["chNFe"] == null).Select(c => new TMDFeInfMDFeInfMunDescargaInfNF
                        {
                            CNPJ = c["CNPJ"].ToString(),
                            dEmi = Convert.ToDateTime(c["dEmi"].ToString()).ToString("yyyy-MM-dd"),
                            nNF = c["nNF"].ToString(),
                            serie = c["serie"].ToString(),
                            UF = c["UF"].ToString(),
                            vNF = c["vNF"].ToString(),
                        }).ToArray();

                    }
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

                foreach (string nr_lanc in infDoc.Select(c => c["nr_lanc"].ToString()).ToList())
                {
                    foreach (DataRow row in daoManifesto.GetTot(nrLanc: nr_lanc).Rows)
                    {
                        vCarga += Convert.ToDecimal(row["vCarga"].ToString());
                        qCarga += Convert.ToDecimal(row["qCarga"].ToString());
                    }
                }

                this.enviMDFe.MDFe.infMDFe.tot.qCarga = qCarga.ToString();
                this.enviMDFe.MDFe.infMDFe.tot.vCarga = vCarga.ToString();
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
                foreach (DataRow row in daoManifesto.GetVeiculoTracao(sequencia).Rows)
                {
                    objRodo.RNTRC = row["RNTRC"].ToString();
                    objRodo.CIOT = row["CIOT"].ToString();

                    objRodo.veicTracao = new rodoVeicTracao();
                    objRodo.veicTracao.cInt = row["cInt"].ToString();
                    objRodo.veicTracao.placa = row["placa"].ToString();
                    objRodo.veicTracao.tara = row["tara"].ToString();
                    objRodo.veicTracao.capKG = row["capKG"].ToString();
                    objRodo.veicTracao.capM3 = row["capM3"].ToString();
                    if (row["st_veiculo"].ToString().Equals("N"))
                    {
                        objRodo.veicTracao.prop = daoManifesto.GetVeiculoProp(sequencia).AsEnumerable().Select(c => new rodoVeicTracaoProp
                        {
                            IE = c["IE"].ToString(),
                            RNTRC = c["RNTRC"].ToString(),
                            tpProp = c["tpProp"].ToString().Equals("P") ? rodoVeicTracaoPropTpProp.Item0 : rodoVeicTracaoPropTpProp.Item1,
                            UF = c["UF"].ToString(),
                            xNome = c["xNome"].ToString(),
                            Item = c["CNPJ"].ToString(),
                            ItemElementName = ItemChoiceType.CNPJ
                        }).FirstOrDefault();
                    }

                }

                objRodo.veicReboque = daoManifesto.GetVeiculoReboque(sequencia).AsEnumerable().Select(c => new rodoVeicReboque
                     {
                         capKG = c["capKG"].ToString(),
                         capM3 = c["capM3"].ToString(),
                         cInt = c["cInt"].ToString(),
                         placa = c["placa"].ToString(),
                         //prop = c[""].ToString(), VERIFICAR
                         tara = c["tara"].ToString(),
                         tpCar = c["tpCar"].ToString().Equals("0") ? rodoVeicReboqueTpCar.Item00 : rodoVeicReboqueTpCar.Item01, //VERIFICAR
                         UF = c["UF"].ToString()                      
                     }).ToList();

                objRodo.valePed = daoManifesto.GetValePed(sequencia).AsEnumerable().Select(c => new rodoDisp 
                {
                    CNPJForn = c["CNPJForn"].ToString(),
                    CNPJPg = c["CNPJPg"].ToString(),
                    nCompra = c["nCompra"].ToString()
                }).ToArray();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        #endregion


    }
}
