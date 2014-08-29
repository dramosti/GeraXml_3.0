using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HLP.GeraXml.dao.ADO;
using System.Data;
using FirebirdSql.Data.FirebirdClient;
using HLP.GeraXml.Comum.Static;
using System.IO;

namespace HLP.GeraXml.dao
{
    public class daoUtil
    {
        public static string GetStatusManifestacao(string sChaveNFe)
        {
            try
            {
                return HlpDbFuncoes.qrySeekValue("MANIDEST", "coalesce(st_manifesto,'')st_manifesto", string.Format("CD_CHAVE_NFE = '{0}' and cd_empresa = '{1}'", sChaveNFe, Acesso.CD_EMPRESA));
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static void SetStatusManifestacao(string xChaveNFe, string xStatus)
        {
            try
            {
                int icount = Convert.ToInt32(HlpDbFuncoes.qrySeekValue("manidest", "count(*) total", string.Format("CD_CHAVE_NFE = '{0}'", xChaveNFe)));
                string sQuery = "";
                if (icount == 0)
                {
                    sQuery = string.Format("INSERT INTO MANIDEST (CD_CHAVE_NFE, CD_EMPRESA, ST_MANIFESTO) VALUES ('{0}', '{1}', '{2}')", xChaveNFe, Acesso.CD_EMPRESA, xStatus);
                    HlpDbFuncoes.qrySeekInsert(sQuery);
                }
                else
                {
                    sQuery = string.Format("UPDATE MANIDEST SET ST_MANIFESTO = '{0}' WHERE (CD_CHAVE_NFE = '{1}') AND (CD_EMPRESA = '{2}')", xStatus, xChaveNFe, Acesso.CD_EMPRESA);
                    HlpDbFuncoes.qrySeekUpdate(sQuery);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static DataTable GetMunicipios()
        {
            string Squery = "select (c.nm_cidnor || ' - ' || c.cd_ufnor) xMun, c.cd_municipio cMun, c.cd_ufnor xUF from cidades c " +
                "where c.nm_cidnor is not null and c.cd_municipio is not null     and c.cd_ufnor  is not null order by c.nm_cidnor ";
            return HlpDbFuncoes.qrySeekRet(Squery);
        }

        public static DateTime GetDateServidor()
        {

            try
            {
                DataTable dt = HlpDbFuncoes.qrySeekRet("Select current_timestamp d from empresa");

                string d = dt.Rows[0]["d"].ToString();
                DateTime dtRet = Convert.ToDateTime(d);
                return dtRet;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string GetTotImpostosServ(string sCD_NFSEQ)
        {
            try
            {
                string sTotal = "";
                if (HlpDbFuncoes.fExisteCampo("VL_FAT_SERVICO", "MOVITEM"))
                {
                    sTotal = HlpDbFuncoes.qrySeekValue("MOVITEM", "SUM(COALESCE(vl_fat_servico,0))", string.Format("cd_nfseq = '{0}' AND CD_EMPRESA = '{1}'", sCD_NFSEQ, Acesso.CD_EMPRESA));

                    if (sTotal != "0")
                    {
                        sTotal = string.Format("VALOR APROXIMADO DOS TRIBUTOS = R$ {0} - FONTE IBPT ", sTotal) + Environment.NewLine;
                    }
                }
                return sTotal;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string GetNumRPSbyCD_NFSEQ(string sCD_NFSEQ)
        {
            try
            {
                string sRPS = "";
                sRPS = HlpDbFuncoes.qrySeekValue("NF", "COALESCE(cd_rps,'')", string.Format("cd_nfseq = '{0}' AND CD_EMPRESA = '{1}'", sCD_NFSEQ, Acesso.CD_EMPRESA));
                return sRPS;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string GetNumRPSbyNumeroNFSE(string sNumNFSe)
        {
            try
            {
                string sRPS = "";
                sRPS = HlpDbFuncoes.qrySeekValue("NF", "COALESCE(cd_rps,'')", string.Format("cd_numero_nfse = '{0}' AND CD_EMPRESA = '{1}'", sNumNFSe, Acesso.CD_EMPRESA));
                return sRPS;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string GetNFSEQbyNumeroRPS(string sRPS)
        {
            try
            {
                string sCD_NFSEQ = "";
                sCD_NFSEQ = HlpDbFuncoes.qrySeekValue("NF", "COALESCE(cd_nfseq,'')", string.Format("cd_rps = '{0}' AND CD_EMPRESA = '{1}'", sRPS, Acesso.CD_EMPRESA));
                return sCD_NFSEQ;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string BuscaNumNotas(string scd_nrlanc)
        {

            scd_nrlanc = Convert.ToInt32(scd_nrlanc).ToString().PadLeft(7, '0');

            string sQuery = string.Format("select cd_nf from nfconhec where   cd_empresa = '{0}' and nr_lancconhecim = '{1}'", Acesso.CD_EMPRESA, scd_nrlanc);


            DataTable dt = HlpDbFuncoes.qrySeekRet(sQuery);
            string sretorno = "";
            foreach (DataRow item in dt.Rows)
            {
                sretorno += "- Nota nº" + item["cd_nf"].ToString();
            }
            return sretorno;
        }

        public static string GetMOTIVO_CANC(string sCD_NFSEQ)
        {
            try
            {
                string sMOTIVO_CANC = "";
                sMOTIVO_CANC = HlpDbFuncoes.qrySeekValue("NF", "COALESCE(DS_MOTIVO_CANC,'')", string.Format("cd_nfseq = '{0}' AND CD_EMPRESA = '{1}'", sCD_NFSEQ, Acesso.CD_EMPRESA));
                return sMOTIVO_CANC;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string GetUfByNome(string sNmMunicipio)
        {
            try
            {
                string sUF = "";
                sUF = HlpDbFuncoes.qrySeekValue("CIDADES", "COALESCE(cd_ufnor,'')", "nm_cidnor = '" + sNmMunicipio + "'");
                return sUF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static string GetUfTomador(string cd_nfseq)
        {
            try
            {
                string sUF = "";
                sUF = HlpDbFuncoes.qrySeekValue("nf inner join clifor on nf.cd_clifor = clifor.cd_clifor", "COALESCE(clifor.cd_ufnor,'')cd_ufnor ", string.Format("nf.cd_nfseq = '{0}' and nf.cd_empresa = '{1}'", cd_nfseq, Acesso.CD_EMPRESA));
                return sUF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string GetCodVerificacaoByCD_NFSEQ(string sCD_NFSEQ)
        {
            try
            {
                string sCD_VERIFICACAO = "";
                sCD_VERIFICACAO = HlpDbFuncoes.qrySeekValue("NF", "COALESCE(cd_verificacao_nfse,'')", string.Format("cd_nfseq = '{0}' AND CD_EMPRESA = '{1}'", sCD_NFSEQ, Acesso.CD_EMPRESA));
                return sCD_VERIFICACAO;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string GetCodigoSiafiByNome(string sNmMunicipio)
        {
            try
            {
                string sCD_SIAFI = "";
                if (HlpDbFuncoes.fExisteCampo("CD_SIAFI", "CIDADES"))
                {
                    sCD_SIAFI = HlpDbFuncoes.qrySeekValue("CIDADES", "COALESCE(CD_SIAFI,'')", "nm_cidnor = '" + sNmMunicipio + "'");
                }
                if (sCD_SIAFI != "")
                {
                    if (sCD_SIAFI.Length == 6)
                    {
                        sCD_SIAFI = sCD_SIAFI.Substring(2, 4);
                    }
                }

                return sCD_SIAFI;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool ValidaUserToCancel()
        {
            try
            {
                string sValida = "S";
                if (HlpDbFuncoes.fExisteCampo("ST_CANCELA_NFE_GERAXML", "ACESSO"))
                {
                    sValida = HlpDbFuncoes.qrySeekValue("ACESSO", "COALESCE(ST_CANCELA_NFE_GERAXML,'S')", "CD_OPERADO = '" + Acesso.NM_USER + "'");
                }
                if (sValida == "S")
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string GetCodigoSiafiByCodigo(string sCodigoMun)
        {
            try
            {
                string sCD_SIAFI = "";
                if (HlpDbFuncoes.fExisteCampo("CD_SIAFI", "CIDADES"))
                {
                    sCD_SIAFI = HlpDbFuncoes.qrySeekValue("CIDADES", "COALESCE(CD_SIAFI,'')", "cd_municipio = '" + sCodigoMun + "'");
                }

                if (sCD_SIAFI != "")
                {
                    if (sCD_SIAFI.Length == 6)
                    {
                        sCD_SIAFI = sCD_SIAFI.Substring(2, 4);
                    }
                }

                return sCD_SIAFI;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static string GetNM_MUNICIPIO(string sCodigoMun)
        {
            try
            {
                string sNM_MUN = HlpDbFuncoes.qrySeekValue("CIDADES", "nm_cidnor", "cd_municipio = '" + sCodigoMun + "'");
                return sNM_MUN;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static decimal GetValorTransparenciaCTe(string sCTe)
        {
            try
            {
                string sValor = HlpDbFuncoes.qrySeekValue("CONHECIM", "COALESCE(vl_total_impostos,0)vl_total_impostos", string.Format("nr_lanc  = '{0}' and cd_empresa = '{1}'", sCTe, Acesso.CD_EMPRESA));

                decimal dReturn = 0;
                if (sValor != "")
                    dReturn = Convert.ToDecimal(sValor);
                return dReturn;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool VerificaConexaoOk()
        {
            try
            {
                FbConnection cx = new FbConnection(HlpDbFuncoesGeral.MontaStringConexao());
                if (cx.State == ConnectionState.Closed)
                {
                    cx.Open();
                    cx.Close();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static string GeraChaveNFe(string seqNFe)
        {
            try
            {
                StringBuilder sSql = new StringBuilder();
                sSql.Append("Select ");
                sSql.Append("coalesce(nf.cd_serie, 1) serie, ");
                sSql.Append("nf.cd_notafis nNF, ");
                sSql.Append("nf.dt_emi dEmi, ");
                sSql.Append("nf.cd_nfseq cNF ");
                sSql.Append(" From ");
                sSql.Append("NF ");
                sSql.Append("inner join empresa on (empresa.cd_empresa = nf.cd_empresa) ");
                sSql.Append("left join uf on (uf.cd_uf = empresa.cd_ufnor) ");
                sSql.Append("where ");
                sSql.Append("(nf.cd_empresa ='");
                sSql.Append(Acesso.CD_EMPRESA);
                sSql.Append("')");
                sSql.Append(" and ");
                sSql.Append("(nf.cd_nfseq = '");
                sSql.Append(seqNFe);
                sSql.Append("')");
                DataTable dt = HLP.GeraXml.dao.ADO.HlpDbFuncoes.qrySeekRet(sSql.ToString());

                string sAAmM, sCNPJ, sMod, sSerie, snNF, scNF;
                string sChave = "";

                foreach (DataRow drChave in dt.Rows)
                {
                    sAAmM = drChave["demi"].ToString().Replace("/", "").Substring(6, 2).ToString() +
                            drChave["demi"].ToString().Replace("/", "").Substring(2, 2).ToString();
                    sCNPJ = Util.TiraSimbolo(Acesso.CNPJ_EMPRESA, "");
                    sCNPJ = sCNPJ.PadLeft(14, '0');
                    sMod = "55";

                    if (Acesso.TP_EMIS == 3) // SCAN
                    {
                        sSerie = Acesso.SERIE_SCAN;
                    }
                    else if (Util.IsNumeric(drChave["serie"].ToString()))
                    {
                        sSerie = drChave["serie"].ToString().PadLeft(3, '0');
                    }
                    else
                    {
                        sSerie = "001";
                    }
                    snNF = drChave["nNF"].ToString().PadLeft(9, '0');
                    scNF = drChave["cNF"].ToString().PadLeft(8, '0');
                    string sChaveantDig = "";
                    string sDig = "";

                    sChaveantDig = Acesso.cUF.ToString().Trim() + sAAmM.Trim() + sCNPJ.Trim() + sMod.Trim() + sSerie.Trim() + snNF.Trim() + Acesso.TP_EMIS + scNF.Trim();
                    sDig = daoUtil.CalculaDig11(sChaveantDig).ToString();
                    sChave = sChaveantDig + sDig;
                    GravaNumeroChaveNota(seqNFe, sChave);
                    break;
                }
                return sChave;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static void GravaNumeroChaveNota(string seqNF, string sChave)
        {
            StringBuilder sSql = new StringBuilder();
            sSql.Append("update nf set cd_chavenfe = '");
            sSql.Append(sChave);
            sSql.Append("'");
            sSql.Append(" Where nf.cd_empresa = '");
            sSql.Append(Acesso.CD_EMPRESA);
            sSql.Append("' and ");
            sSql.Append("nf.cd_nfseq = '");
            sSql.Append(seqNF);
            sSql.Append("'");
            try
            {
                HlpDbFuncoes.qrySeekUpdate(sSql.ToString());
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int CalculaDig11(string sChave)
        {

            int iDig = 0;
            int iMult = 2;
            int iTotal = 0;

            for (int i = (sChave.Length - 1); i >= 0; i--)
            {
                iTotal += Convert.ToInt32(sChave[i].ToString()) * iMult;
                iMult++;
                if (iMult > 9)//Danner - o.s. 29/10/2009
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

        public static string RetornaBlob(string sQuery)
        {
            string texto = "";
            FbConnection Conn = HlpDbFuncoesGeral.conexao;
            FbCommand comando = new FbCommand(sQuery.ToString(), Conn);
            if (Conn.State == ConnectionState.Closed)
            {
                Conn.Open();
            }
            FbDataReader Reader = comando.ExecuteReader();
            Byte[] blob = null;
            MemoryStream ms = new MemoryStream();
            while (Reader.Read())
            {
                blob = new Byte[(Reader.GetBytes(0, 0, null, 0, int.MaxValue))];
                try
                {
                    Reader.GetBytes(0, 0, blob, 0, blob.Length);
                }
                catch
                {
                    texto = "";
                }
                ms = new MemoryStream(blob);
            }
            Conn.Close();

            StreamReader Ler = new StreamReader(ms);
            Ler.ReadLine();
            while (Ler.Peek() != -1)
            {
                texto += Ler.ReadLine();
            }
            if ((Acesso.NM_EMPRESA == "MACROTEX") || (Acesso.NM_EMPRESA == "PAVAX"))
            {
                string sVendedor = string.Empty;
                string sPedidoCliente = string.Empty;

                if (Conn.State != ConnectionState.Open)
                {
                    Conn.Open();
                }
                FbCommand cmd = new FbCommand(sQuery.ToString().Replace("nf.ds_anota ,", ""), Conn);
                cmd.ExecuteNonQuery();
                FbDataReader dr = cmd.ExecuteReader();
                dr.Read();

                sVendedor = dr["nm_vend"].ToString();
                sPedidoCliente = dr["DS_DOCORIG"].ToString();

                if ((Acesso.NM_EMPRESA == "MACROTEX"))
                {
                    if (texto == "")
                    {
                        texto += string.Format("Vendedor.: {0} Pedido N.: {1}",
                                               sVendedor,
                                               sPedidoCliente);

                    }
                    else
                    {
                        texto += string.Format(" Vendedor.: {0} Pedido N.: {1}",
                                               sVendedor,
                                               sPedidoCliente);
                    }
                }
                else
                {
                    if (texto == "")
                    {
                        texto += string.Format("Pedido N.: {0}",
                                               sPedidoCliente);

                    }
                    else
                    {
                        texto += string.Format(" Pedido N.: {0}",
                                               sPedidoCliente);
                    }
                }
            }
            if (((Acesso.NM_EMPRESA == "MOGPLAST") || (Acesso.NM_EMPRESA == "TSA")) && (Acesso.CD_EMPRESA == "003"))
            {
                string sNFOrigem = string.Empty;
                string sEmiOrigem = string.Empty;


                if (Conn.State != ConnectionState.Open)
                {
                    Conn.Open();
                }
                FbCommand cmd = new FbCommand(sQuery.ToString().Replace("nf.ds_anota ,", ""), Conn);
                cmd.ExecuteNonQuery();
                FbDataReader dr = cmd.ExecuteReader();
                dr.Read();

                //Claudinei - o.s. sem - 02/03/2010
                if (dr["cd_nfseq_fat_origem"].ToString() != "")
                {
                    //Fim - Claudinei - o.s. sem - 02/03/2010
                    StringBuilder sSqlNFOrigem = new StringBuilder();
                    sSqlNFOrigem.Append("Select ");
                    sSqlNFOrigem.Append("cd_notafis, ");
                    sSqlNFOrigem.Append("dt_emi ");
                    sSqlNFOrigem.Append("From NF ");
                    sSqlNFOrigem.Append("Where nf.cd_empresa = '");
                    sSqlNFOrigem.Append("001");
                    sSqlNFOrigem.Append("'");
                    sSqlNFOrigem.Append(" and ");
                    sSqlNFOrigem.Append("cd_nfseq = '");
                    sSqlNFOrigem.Append(dr["cd_nfseq_fat_origem"].ToString());
                    sSqlNFOrigem.Append("'");

                    FbCommand cmdNFOrigem = new FbCommand(sSqlNFOrigem.ToString(), Conn);
                    cmdNFOrigem.ExecuteNonQuery();

                    FbDataReader drNFOrigem = cmdNFOrigem.ExecuteReader();

                    drNFOrigem.Read();

                    sNFOrigem = drNFOrigem["cd_notafis"].ToString();
                    sEmiOrigem = System.DateTime.Parse(drNFOrigem["dt_emi"].ToString()).ToString("dd/MM/yyyy");

                    if (texto == "")
                    {
                        texto += string.Format("DEV TOTAL REF A NF {0} DE {1}",
                                               sNFOrigem,
                                               sEmiOrigem);

                    }
                    else
                    {
                        texto += string.Format(" DEV TOTAL REF A NF {0} DE {1}",
                                               sNFOrigem,
                                               sEmiOrigem);
                    }
                }
            }
            return Util.TiraCaracterEstranho(texto).Trim();
        }

        public string RetornaProximoValorGenerator(string sNomeGernerator, int sTamanho)
        {
            try
            {
                string sNumArq = "";

                FbCommand sSql = new FbCommand();
                FbConnection Conn = HlpDbFuncoesGeral.conexao;
                sSql.Connection = Conn;
                Conn.Open();
                sSql.CommandText = "SP_CHAVEPRI";
                sSql.CommandType = CommandType.StoredProcedure;
                sSql.Parameters.Clear();

                sSql.Parameters.Add("@SNOMEGENERATOR", FbDbType.VarChar, 31).Value = sNomeGernerator;

                sNumArq = sSql.ExecuteScalar().ToString();
                return sNumArq.PadLeft(sTamanho, '0');
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string RetornaNomeArqNFe()
        {
            string sNumArq = "";
            FbCommand sSql = new FbCommand();
            try
            {
                sSql.Connection = HlpDbFuncoesGeral.conexao;
                if (sSql.Connection.State == ConnectionState.Closed)
                {
                    sSql.Connection.Open();
                }
                sSql.CommandText = "SP_CHAVEPRI";
                sSql.CommandType = CommandType.StoredProcedure;
                sSql.Parameters.Clear();

                sSql.Parameters.Add("@SNOMEGENERATOR", FbDbType.VarChar, 31).Value = "GEN_NOMEARQXML";

                sNumArq = sSql.ExecuteScalar().ToString();

            }
            catch (FbException Ex)
            {
                Console.WriteLine("Erro.: ", Ex.Message);
            }
            finally
            {

                sSql.Connection.Close();
            }

            string sVALOR = "Nfe_" + Acesso.CD_EMPRESA + sNumArq.PadLeft(15, '0') + ".xml"; ;
            return sVALOR;
        }

        public static string BuscaSerieEmpresa()
        {
            return HlpDbFuncoes.qrySeekValue("EMPRESA", "coalesce ( empresa.cd_serie,'1') Serie ", "cd_empresa = '" + Acesso.CD_EMPRESA + "'").PadLeft(3, '0');
        }

        #region Dados Empresa - Usado no relatorio NFEs Susesu
        private string _bairroEmpresa;
        public string BairroEmpresa
        {
            get { return _bairroEmpresa; }
        }
        private string _ruaEmpresa;
        public string RuaEmpresa
        {
            get { return _ruaEmpresa; }
        }
        public string _fone;
        public string FoneEmpresa
        {
            get { return _fone; }
        }
        private string _ieEmpresa;
        public string IeEmpresa
        {
            get { return _ieEmpresa; }
        }
        private string _imEmpresa;
        public string ImEmpresa
        {
            get { return _imEmpresa; }
        }
        private string _email;
        public string EmailEmpresa
        {
            get { return _email; }
        }

        public void SetDadosEmpresa()
        {
            try
            {
                DataTable dt = HlpDbFuncoes.qrySeekRet("EMPRESA", "coalesce(cd_cepnor, '')cd_cepnor, coalesce(cd_email,'')cd_email, coalesce(cd_inscrmu, '')cd_inscrmu, coalesce(cd_insest,'')cd_insest, coalesce(nm_bairronor,'')nm_bairronor, coalesce(ds_endnor,'')ds_endnor, coalesce(ds_endcomp,'') nro, coalesce(cd_fonenor,'')fone", "cd_empresa = '" + Acesso.CD_EMPRESA + "'");

                _bairroEmpresa = dt.Rows[0]["nm_bairronor"].ToString() + " - CEP: " + dt.Rows[0]["cd_cepnor"].ToString();
                _ruaEmpresa = dt.Rows[0]["ds_endnor"].ToString() + ", " + dt.Rows[0]["nro"].ToString();
                _fone = dt.Rows[0]["fone"].ToString();
                _ieEmpresa = dt.Rows[0]["cd_insest"].ToString();
                _imEmpresa = dt.Rows[0]["cd_inscrmu"].ToString();
                _email = dt.Rows[0]["cd_email"].ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        public static string GetEnderecoEmpresa()
        {
            try
            {
                DataTable dt = HlpDbFuncoes.qrySeekRet("EMPRESA", "coalesce(nm_bairronor,'')nm_bairronor, coalesce(ds_endnor,'')ds_endnor, coalesce(ds_endcomp,'') nro, coalesce(cd_fonenor,'')fone", "cd_empresa = '" + Acesso.CD_EMPRESA + "'");
                string dadosEmp = "RAZÃO SOCIAL:{0}  CNPJ:{1} - RUA:{2} BAIRRO:{3} Nº{4}, {5}/{6} - FONE:{7}";
                dadosEmp = string.Format(dadosEmp, Acesso.NM_RAZAOSOCIAL, Acesso.CNPJ_EMPRESA, dt.Rows[0]["nm_bairronor"].ToString(), dt.Rows[0]["ds_endnor"].ToString(), dt.Rows[0]["nro"].ToString(), Acesso.CIDADE_EMPRESA, Acesso.xUF, dt.Rows[0]["fone"].ToString());
                return dadosEmp;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public static bool VerificaExistenciaGenerator(string sNomeGen)
        {
            try
            {
                //StringBuilder sQuery = new StringBuilder();
                //sQuery.Append("SELECT RDB$GENERATORS.RDB$GENERATOR_NAME ");
                //sQuery.Append("FROM RDB$GENERATORS ");
                //sQuery.Append("WHERE (RDB$GENERATORS.RDB$GENERATOR_NAME = '" + sNomeGen + "')");

                if ((HlpDbFuncoes.qrySeekValue("RDB$GENERATORS", "RDB$GENERATORS.RDB$GENERATOR_NAME", "(RDB$GENERATORS.RDB$GENERATOR_NAME = '" + sNomeGen + "')")) == "")
                {
                    return false;
                }
                else
                {
                    return true;
                }
                //return (command.ExecuteScalar().ToString().Trim() != "" ? true : false);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static void CreateGenerator(string sNomeGen, int iValorIni)
        {
            try
            {
                StringBuilder sQuery = new StringBuilder();
                sQuery.Append(" CREATE GENERATOR " + sNomeGen);
                HlpDbFuncoes.qrySeekInsert(sQuery.ToString());

                sQuery = new StringBuilder();
                sQuery.Append(" SET GENERATOR " + sNomeGen + " TO " + iValorIni.ToString());
                HlpDbFuncoes.qrySeekInsert(sQuery.ToString());

            }
            catch (Exception ex)
            {
                throw;
            }
        }


        /// <summary>
        /// DataValueMember = idMunicipio
        /// DisplayMember = xMunicipio
        /// </summary>
        /// <returns></returns>
        public static DataTable GetCidades()
        {
            try
            {
                StringBuilder sQuery = new StringBuilder();
                sQuery.Append("SELECT ");
                sQuery.Append("cd_municipio idMunicipio, nm_cidnor xMunicipio ");
                sQuery.Append("FROM CIDADES");

                return HlpDbFuncoes.qrySeekRet(sQuery.ToString());
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static string CarregaObsTransparenciaNF(string sNFSEQ)
        {
            try
            {

                string sMsg = "Val Aprox dos Tributos R$ {0} - ({1}) % Fonte: IBPT ;";

                decimal dVL_IMP = 0;
                decimal dVL_TOT = 0;
                string sQuery = "select cast(sum(coalesce(m.vl_fattransp,0)) as numeric(10,4)) total from movitem m where m.cd_nfseq = '{0}' and m.cd_empresa = '{1}'";
                DataTable dt = HlpDbFuncoes.qrySeekRet(string.Format(sQuery, sNFSEQ, Acesso.CD_EMPRESA));
                if (dt.Rows.Count > 0)
                    dVL_IMP = Convert.ToDecimal(dt.Rows[0][0].ToString());

                sQuery = "select nf.vl_totnf from nf where nf.cd_nfseq = '{0}' and nf.cd_empresa = '{1}'";
                dt = HlpDbFuncoes.qrySeekRet(string.Format(sQuery, sNFSEQ, Acesso.CD_EMPRESA));
                if (dt.Rows.Count > 0)
                    dVL_TOT = Convert.ToDecimal(dt.Rows[0][0].ToString());

                if (dVL_IMP > 0)
                    return string.Format(sMsg, dVL_IMP.ToString("#0.00"), ((dVL_IMP / dVL_TOT) * 100).ToString("#0.00"));
                else
                    return "";
            }
            catch (Exception)
            {
                return "";
            }
        }

        public static string CarregaObsTransparenciaITEM(string sNR_LANC, string sVl_fattransp = "0", string sVl_aliqtransp = "0")
        {
            try
            {
                decimal dVL_ALIQ = 0;
                decimal dVL_TRANSPAR = 0;
                if (sNR_LANC != "0")
                {
                    string sQuery = "select coalesce(m.vl_fattransp,0)vl_fattransp, coalesce(m.vl_aliqtransp,0)vl_aliqtransp from movitem m where m.nr_lanc = '{0}' and m.cd_empresa = '{1}'";
                    DataTable dt = HlpDbFuncoes.qrySeekRet(string.Format(sQuery, sNR_LANC, Acesso.CD_EMPRESA));
                    if (dt.Rows.Count > 0)
                    {
                        dVL_TRANSPAR = Convert.ToDecimal(dt.Rows[0]["vl_fattransp"].ToString());
                        dVL_ALIQ = Convert.ToDecimal(dt.Rows[0]["vl_aliqtransp"].ToString());
                    }
                }
                else
                {
                    dVL_ALIQ = Convert.ToDecimal(sVl_aliqtransp);
                    dVL_TRANSPAR = Convert.ToDecimal(sVl_fattransp);
                }
                string sMsg = "Val Aprox dos Tributos R$ {0} - ({1}) % Fonte: IBPT ;";
                if (dVL_TRANSPAR > 0)
                    return string.Format(sMsg, dVL_TRANSPAR.ToString("#0.00"), dVL_ALIQ.ToString("#0.00"));
                else
                    return "";
            }
            catch (Exception ex)
            {
                return "";
            }
        }

    }
}
