using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HLP.GeraXml.bel.NFe;
using HLP.GeraXml.dao.NFes.DSF;
using System.Data;
using HLP.GeraXml.Comum.Static;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using HLP.GeraXml.Comum;
using HLP.GeraXml.dao;

namespace HLP.GeraXml.bel.NFes.DSF
{
    /// <summary>
    /// Carrega Dados no RPS
    /// </summary>
    public class belCarregaDadosRPS : daoRPS
    {
        private List<belPesquisaNotas> lNotas { get; set; }
        public ReqEnvioLoteRPS objLoteEnvio;
        public XmlDocument xmlLote { get; set; }

        public bool bBuscaRetonro = false;

        /// <summary>
        /// Contrutor que já carrega as notas no RPS e gera o XML de Envio
        /// </summary>
        /// <param name="lNotas"></param>
        public belCarregaDadosRPS(List<belPesquisaNotas> lNotas, string sNumeroLote = "")
        {
            this.lNotas = lNotas;

            if (sNumeroLote != "")
            {
                bBuscaRetonro = true;
            }
            objLoteEnvio = new ReqEnvioLoteRPS();
            objLoteEnvio.cabec = CarregaCabecalho();
            objLoteEnvio.cabec.NumeroLote = sNumeroLote;
            objLoteEnvio.lote = new Lote();
            daoUtil objdaoUtil = new daoUtil();
            objLoteEnvio.lote.Id = "Lote:" + objdaoUtil.RetornaProximoValorGenerator("GEN_LOTE_NFES", 7);
            objLoteEnvio.lote.RPS = new List<LoteRPS>();
            Principal principal = new Principal("http://issdigital.campinas.sp.gov.br/WsNFe2/LoteRps.jws");
            //int inumero = 0;//Ultima nota enviada.
            //principal.dllConsultarSequencial(Convert.ToInt32(objLoteEnvio.cabec.CodCidade), objLoteEnvio.cabec.CPFCNPJRemetente, base.GetInscricaoMunicipal(), "99", ref inumero);
            foreach (belPesquisaNotas nota in lNotas)
            {
                objLoteEnvio.lote.RPS.Add(CarregaLote(nota.sCD_NFSEQ));
            }

            objLoteEnvio.cabec.QtdRPS = objLoteEnvio.lote.RPS.Count();
            objLoteEnvio.cabec.ValorTotalDeducoes = objLoteEnvio.lote.RPS.Sum(c => c.Deducoes.Deducao.Sum(x => x.ValorDeduzir));
            objLoteEnvio.cabec.ValorTotalServicos = objLoteEnvio.lote.RPS.Sum(c => c.Itens.Item.Sum(x => x.ValorTotal));
        }

        public void CriarXml()
        {
            if (objLoteEnvio.cabec.NumeroLote == "")
            {
                this.Serialize();
            }
        }


        private Cabecalho CarregaCabecalho()
        {
            Cabecalho objCabec = new Cabecalho();
            objCabec.CodCidade = daoUtil.GetCodigoSiafiByNome(Acesso.CIDADE_EMPRESA);
            objCabec.CPFCNPJRemetente = Util.RetiraCaracterCNPJ(Acesso.CNPJ_EMPRESA.ToString());
            objCabec.RazaoSocialRemetente = Acesso.NM_RAZAOSOCIAL;
            objCabec.transacao = true;
            objCabec.dtInicio = DateTime.Today;
            objCabec.dtFim = DateTime.Today;
            objCabec.Versao = 1;
            objCabec.MetodoEnvio = "WS";
            return objCabec;
        }

        private LoteRPS CarregaLote(string cd_nfseq)
        {
            try
            {
                base.GetRps(cd_nfseq);

                LoteRPS rps = null;
                foreach (DataRow row in dtRPS.Rows)
                {
                    rps = new LoteRPS();
                    rps.CD_NFSEQ = cd_nfseq;

                    #region Carrega as propriedades do RPS
                    rps.InscricaoMunicipalPrestador = Util.TiraSimbolo(row["InscricaoMunicipalPrestador"].ToString()).PadLeft(9, '0');
                    rps.TipoRPS = "RPS";
                    rps.SerieRPS = "NF";
                    rps.RazaoSocialPrestador = row["RazaoSocialPrestador"].ToString();
                    //rps.NumeroRPS = sNumeroRps;
                    rps.DataEmissaoRPS = DateTime.Today;// Convert.ToDateTime(row["DataEmissaoRPS"].ToString());
                    rps.SituacaoRPS = row["SituacaoRPS"].ToString();
                    rps.SerieRPSSubstituido = row["SerieRPSSubstituido"].ToString();
                    rps.NumeroRPSSubstituido = Convert.ToByte(row["NumeroRPSSubstituido"].ToString());
                    rps.NumeroNFSeSubstituida = Convert.ToByte(row["NumeroNFSeSubstituida"].ToString());
                    rps.DataEmissaoNFSeSubstituida = Convert.ToDateTime(row["DataEmissaoNFSeSubstituida"].ToString());
                    rps.SeriePrestacao = Convert.ToByte(row["SeriePrestacao"].ToString());
                    rps.InscricaoMunicipalTomador = row["InscricaoMunicipalTomador"].ToString().PadLeft(9,'0');
                    rps.CPFCNPJTomador = Util.TiraSimbolo(row["CNPJ_Tomador"].ToString() == "" ? row["CPF_Tomador"].ToString() : row["CNPJ_Tomador"].ToString());
                    rps.RazaoSocialTomador = row["RazaoSocialTomador"].ToString().Trim();
                    rps.DocTomadorEstrangeiro = row["DocTomadorEstrangeiro"].ToString();
                    rps.TipoLogradouroTomador = row["TipoLogradouroTomador"].ToString();
                    rps.LogradouroTomador = row["LogradouroTomador"].ToString();
                    rps.NumeroEnderecoTomador = row["NumeroEnderecoTomador"].ToString();
                    rps.TipoBairroTomador = "Bairro";
                    rps.ComplementoEnderecoTomador = row["ComplementoEnderecoTomador"].ToString();
                    rps.BairroTomador = row["BairroTomador"].ToString();
                    rps.CidadeTomador = daoUtil.GetCodigoSiafiByCodigo((row["CidadeTomador"].ToString()));
                    rps.CidadeTomadorDescricao = row["CidadeTomadorDescricao"].ToString();
                    rps.CEPTomador = Util.TiraSimbolo(row["CEPTomador"].ToString());
                    rps.EmailTomador = row["EmailTomador"].ToString();
                    rps.CodigoAtividade = row["CodigoAtividade"].ToString();
                    rps.TipoRecolhimento = row["TipoRecolhimento"].ToString();
                    if (row["cd_munPrestacao"].ToString() == "")
                    {
                        rps.MunicipioPrestacao = rps.CidadeTomador; // VERIFICAR TRATAMENTO
                        rps.MunicipioPrestacaoDescricao = rps.CidadeTomadorDescricao; // VERIFICAR TRATAMENTO   
                    }
                    else
                    {
                        rps.MunicipioPrestacao = daoUtil.GetCodigoSiafiByCodigo(row["cd_munPrestacao"].ToString());
                        rps.MunicipioPrestacaoDescricao = daoUtil.GetNM_MUNICIPIO(row["cd_munPrestacao"].ToString());
                    }
                    rps.Operacao = row["Operacao"].ToString();
                    rps.Tributacao = row["Tributacao"].ToString();

                    rps.ValorPIS = row["ValorPIS"].ToString();
                    rps.ValorCOFINS = row["ValorCOFINS"].ToString();
                    rps.ValorINSS = row["ValorINSS"].ToString();
                    rps.ValorCSLL = row["ValorCSLL"].ToString();


                    rps.ValorIR = GetValorIR(cd_nfseq).ToString();



                    rps.AliquotaPIS = Convert.ToDecimal(row["AliquotaPIS"].ToString());
                    rps.AliquotaCOFINS = Convert.ToDecimal(row["AliquotaCOFINS"].ToString());
                    rps.AliquotaINSS = Convert.ToDecimal(row["AliquotaINSS"].ToString());
                    rps.AliquotaIR = Convert.ToDecimal(row["AliquotaIR"].ToString());    //Convert.ToDecimal(GetValorIR(cd_nfseq));
                    rps.AliquotaCSLL = Convert.ToDecimal(row["AliquotaCSLL"].ToString());




                    rps.DescricaoRPS = daoUtil.GetTotImpostosServ(cd_nfseq) + GetDescricaoRPS(cd_nfseq);
                    if (Acesso.TRANSPARENCIA == 0 || Acesso.TRANSPARENCIA == 2)
                    {
                        rps.DescricaoRPS += Environment.NewLine + daoUtil.CarregaObsTransparenciaNF(cd_nfseq);
                    }

                    rps.TelefonePrestador = row["TelefonePrestador"].ToString();
                    rps.TelefoneTomador = row["TelefoneTomador"].ToString();
                    rps.MotCancelamento = "";

                    #endregion

                    rps.Itens = new LoteRPSItens();
                    rps.Itens.Item = new List<LoteRPSItensItem>();
                    // Carregos os Itens da Nota
                    base.GetItens(cd_nfseq);
                    LoteRPSItensItem item;
                    foreach (DataRow rowItem in dtItem.Rows)
                    {
                        rps.AliquotaAtividade = base.GetAliquotaAtividade(rowItem["cd_clifor"].ToString(), rowItem["cd_oper"].ToString()).ToString();
                        item = new LoteRPSItensItem();
                        item.DiscriminacaoServico = rowItem["DiscriminacaoServico"].ToString();
                        if (Acesso.TRANSPARENCIA == 1 || Acesso.TRANSPARENCIA == 2)
                        {
                            item.DiscriminacaoServico += Environment.NewLine + daoUtil.CarregaObsTransparenciaITEM(rowItem["nr_lanc"].ToString());
                        }
                        item.Quantidade = Convert.ToByte(rowItem["Quantidade"].ToString());
                        item.ValorUnitario = Convert.ToDecimal(rowItem["ValorUnitario"].ToString());
                        item.ValorTotal = Convert.ToDecimal(rowItem["ValorTotal"].ToString());
                        rps.Itens.Item.Add(item);
                    }

                    // Verificar de onde ira puxar as deduções.
                    rps.Deducoes = new LoteRPSDeducoes();
                    rps.Deducoes.Deducao = new List<LoteRPSDeducoesDeducao>();

                    belConsultaSequencia seq = new belConsultaSequencia();
                    if (!bBuscaRetonro)
                    {
                        rps.NumeroRPS = seq.GetSequenciaNota(rps.InscricaoMunicipalPrestador, cd_nfseq);
                        this.SaveNumRPS(cd_nfseq, rps.NumeroRPS);
                    }
                    else
                    {
                        rps.NumeroRPS = this.GetNumeroRPSsalvo(cd_nfseq);
                    }

                    rps.Assinatura = belCarregaDadosRPS.GetAssinatura(rps);

                }
                return rps;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string GetAssinatura(LoteRPS rps)
        {
            StringBuilder ass = new StringBuilder();

            ass.Append(rps.InscricaoMunicipalPrestador.PadLeft(11, '0'));
            ass.Append(rps.SerieRPS.PadRight(5, ' '));
            ass.Append(rps.NumeroRPS.ToString().PadLeft(12, '0'));
            ass.Append(rps.DataEmissaoRPS.ToString("yyyyMMdd"));
            ass.Append(rps.Tributacao.ToString().PadRight(2, ' '));
            ass.Append(rps.SituacaoRPS);
            ass.Append(rps.TipoRecolhimento == "A" ? "N" : "S");
            decimal dTotal = Truncate(rps.Itens.Item.Sum(c => c.ValorUnitario), 2);
            decimal dTotalDeducao = Truncate(rps.Deducoes.Deducao.Sum(c => c.ValorDeduzir), 2);
            ass.Append((dTotal - dTotalDeducao).ToString("#0.00").Replace(",", "").PadLeft(15, '0'));
            ass.Append(dTotalDeducao.ToString("#0.00").Replace(",", "").PadLeft(15, '0'));
            ass.Append(rps.CodigoAtividade.PadLeft(10, '0'));
            ass.Append(Util.TiraSimbolo(rps.CPFCNPJTomador).PadLeft(14, '0'));

            return Util.StringToHashSHA1(ass.ToString());
        }


        public static decimal Truncate(decimal number, int digits)
        {
            decimal stepper = (decimal)(Math.Pow(10.0, (double)digits));
            int temp = (int)(stepper * number);
            return (decimal)temp / stepper;
        }

        private void Serialize()
        {
            try
            {
                string sPathXml = GetFilePathLoteServico();
                if (File.Exists(sPathXml))
                {
                    File.Delete(sPathXml);
                }

                XmlSerializerNamespaces nameSpaces = new XmlSerializerNamespaces();
                nameSpaces.Add("xsi", "http://www.w3.org/2001/XMLSchema-instance");
                nameSpaces.Add("tipos", "http://localhost:8080/WsNFe2/tp");
                nameSpaces.Add("ns1", "http://localhost:8080/WsNFe2/lote");

                //XmlTextWriter xmlTextWriter = new
                //XmlTextWriter(sPathXml, Encoding.UTF8);
                //xmlTextWriter.Formatting = Formatting.Indented;
                //XmlSerializer xs = new XmlSerializer(typeof(ReqEnvioLoteRPS));
                //xs.Serialize(xmlTextWriter, objLoteEnvio, nameSpaces);
                //xmlTextWriter.Close();

                foreach (LoteRPS item in objLoteEnvio.lote.RPS)
                {
                    item.bSerialize = true;
                }

                String XmlizedString = null;
                XmlSerializer x = new XmlSerializer(objLoteEnvio.GetType());
                MemoryStream memoryStream = new MemoryStream();
                XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);
                x.Serialize(xmlTextWriter, objLoteEnvio, nameSpaces);
                memoryStream = (MemoryStream)xmlTextWriter.BaseStream;
                UTF8Encoding encoding = new UTF8Encoding();
                XmlizedString = encoding.GetString(memoryStream.ToArray());
                XmlizedString = XmlizedString.Substring(1);
                if (Acesso.TP_AMB_SERV == 1)
                {
                    belAssinaXml Assinatura = new belAssinaXml();
                    XmlizedString = Assinatura.ConfigurarArquivo(XmlizedString, "Lote", Acesso.cert_NFs);
                }

                this.xmlLote = new XmlDocument();
                this.xmlLote.LoadXml(XmlizedString);
                this.xmlLote.Save(sPathXml);
                this.ValidaXml(sPathXml);

                foreach (LoteRPS lot in objLoteEnvio.lote.RPS)
                {
                    sPathXml = GetFilePathMonthServico(false, lot.NumeroRPS);
                    if (File.Exists(sPathXml))
                    {
                        LoteRPS lotExistente = SerializeClassToXml.DeserializeClasse<LoteRPS>(sPathXml);

                        string sCD_NFSEQ = daoUtil.GetNFSEQbyNumeroRPS(lotExistente.NumeroRPS);

                        if (lot.CD_NFSEQ == sCD_NFSEQ)
                        {
                            File.Delete(sPathXml);
                        }
                        else
                        {
                            throw new Exception(string.Format("A Nota de sequencia '{0}' já esta utilizando o RPS de numero '{1}', é necessário envia-la para que o RPS possa ser incrementado.", sCD_NFSEQ, lotExistente.NumeroRPS));
                        }

                    }


                    SerializeClassToXml.SerializeClasse<LoteRPS>(lot, sPathXml);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ValidaXml(string sPath)
        {
            try
            {
                belValidaXml.ValidarXml("http://localhost:8080/WsNFe2/lote", Pastas.SCHEMA_NFSE_DSF + "\\ReqEnvioLoteRPS.xsd", sPath);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string GetFilePathLoteServico()
        {

            string sDirectory = Pastas.ENVIO + "\\Servicos\\";

            string sName = "Lote";
            foreach (LoteRPS rps in objLoteEnvio.lote.RPS)
            {
                sName += "_" + rps.NumeroRPS;
            }

            return sDirectory + sName + ".xml";
        }

        /// <summary>
        /// true- enviados
        /// false-envio
        /// </summary>
        /// <param name="bStatus"></param>
        /// <param name="sNumero">NUMERO DO RPS </param>
        /// <returns></returns>
        public static string GetFilePathMonthServico(bool bStatus, string sNumero)
        {

            string sDirectory = (bStatus ? Pastas.ENVIADOS : Pastas.ENVIO) + "\\Servicos\\" + DateTime.Today.Date.Year.ToString().Substring(2, 2) + DateTime.Today.Month.ToString().PadLeft(2, '0') + "\\";
            if (!Directory.Exists(sDirectory))
            {
                Directory.CreateDirectory(sDirectory);
            }

            string sName = (bStatus ? "NFSE_" : "RPS_") + sNumero;

            return sDirectory + sName + ".xml";
        }


    }
}
