using HLP.GeraXml.Comum.Static;
using HLP.GeraXml.dao.ADO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace HLP.GeraXml.dao.CTe.MDFe
{
    public class daoManifesto
    {

        public static void GravarReciboCancelamento(string sequencia, string sReciboCancelamento, string sJustificativa)
        {
            try
            {
                StringBuilder sQuery = new StringBuilder();
                sQuery.Append("Update manifest ");
                sQuery.Append("set manifest.cd_recibocanc ='" + sReciboCancelamento + "', ");
                sQuery.Append("manifest.ds_cancelamento='" + sJustificativa + "' ");
                sQuery.Append("where manifest.cd_manifest='" + sequencia + "' ");
                sQuery.Append("and manifest.cd_empresa ='" + Acesso.CD_EMPRESA + "'");
                HlpDbFuncoes.qrySeekUpdate(sQuery.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public static void gravaChave(string sChave, string sequencia)
        {
            try
            {
                StringBuilder sSql = new StringBuilder();
                sSql.Append("update MANIFEST ");
                sSql.Append("set CD_CHAVEMDFE ='");
                sSql.Append(sChave);
                sSql.Append("' ");
                sSql.Append("where ");
                sSql.Append("cd_empresa ='");
                sSql.Append(Acesso.CD_EMPRESA);
                sSql.Append("' ");
                sSql.Append("and ");
                sSql.Append("cd_manifest ='");
                sSql.Append(sequencia);
                sSql.Append("' ");

                HLP.GeraXml.dao.ADO.HlpDbFuncoes.qrySeekUpdate(sSql.ToString());

            }
            catch (Exception)
            {
                throw;
            }

        }

        public static void gravaRecibo(string sRecibo, string sequencia)
        {
            try
            {
                StringBuilder sSql = new StringBuilder();
                sSql.Append("update MANIFEST ");
                sSql.Append("set CD_RECIBOMDFE ='");
                sSql.Append(sRecibo);
                sSql.Append("' ");
                sSql.Append("where ");
                sSql.Append("cd_empresa ='");
                sSql.Append(Acesso.CD_EMPRESA);
                sSql.Append("' ");
                sSql.Append("and ");
                sSql.Append("cd_manifest ='");
                sSql.Append(sequencia);
                sSql.Append("'");
                //sSql.Append(" and coalesce(CD_RECIBOMDFE, '') = ''");

                HLP.GeraXml.dao.ADO.HlpDbFuncoes.qrySeekUpdate(sSql.ToString());

            }
            catch (Exception)
            {
                throw;
            }

        }      

        public static void LimpaRecibo(string sequencia)
        {
            try
            {
                StringBuilder sSql = new StringBuilder();
                sSql.Append("update MANIFEST ");
                sSql.Append("set CD_RECIBOMDFE ='");
                sSql.Append("' ");
                sSql.Append("where ");
                sSql.Append("cd_empresa ='");
                sSql.Append(Acesso.CD_EMPRESA);
                sSql.Append("' ");
                sSql.Append("and ");
                sSql.Append("cd_manifest ='");
                sSql.Append(sequencia);
                sSql.Append("' ");

                HLP.GeraXml.dao.ADO.HlpDbFuncoes.qrySeekUpdate(sSql.ToString());

            }
            catch (Exception)
            {
                throw;
            }

        }

        public static void gravaProtocolo(string sProtocolo, string sequencia)
        {
            try
            {
                StringBuilder sSql = new StringBuilder();
                sSql.Append("update MANIFEST ");
                sSql.Append("set CD_PROTMDFE ='");
                sSql.Append(sProtocolo);
                sSql.Append("' ");
                sSql.Append("where ");
                sSql.Append("cd_empresa ='");
                sSql.Append(Acesso.CD_EMPRESA);
                sSql.Append("' ");
                sSql.Append("and ");
                sSql.Append("cd_manifest ='");
                sSql.Append(sequencia);
                sSql.Append("'");
                HLP.GeraXml.dao.ADO.HlpDbFuncoes.qrySeekUpdate(sSql.ToString());

            }
            catch (Exception)
            {
                throw;
            }

        }

        public static void AlteraStatusMDFe(string sequencia, string status)
        {
            try
            {
                StringBuilder sSql = new StringBuilder();
                sSql.Append("update MANIFEST ");
                sSql.Append("set ST_MDFE ='" + status + "' ");
                sSql.Append("where ");
                sSql.Append("cd_empresa ='");
                sSql.Append(Acesso.CD_EMPRESA);
                sSql.Append("' ");
                sSql.Append("and ");
                sSql.Append("cd_manifest ='");
                sSql.Append(sequencia);
                sSql.Append("'");
                HLP.GeraXml.dao.ADO.HlpDbFuncoes.qrySeekUpdate(sSql.ToString());

            }
            catch (Exception)
            {
                throw;
            }

        }

        public static void AlteraUltimoRetorno(string sequencia)
        {
            try
            {
                StringBuilder sSql = new StringBuilder();
                sSql.Append("update MANIFEST ");
                sSql.Append("set DS_ULTIMORET ='" + daoUtil.GetDateServidor().ToString() + "' ");
                sSql.Append("where ");
                sSql.Append("cd_empresa ='");
                sSql.Append(Acesso.CD_EMPRESA);
                sSql.Append("' ");
                sSql.Append("and ");
                sSql.Append("cd_manifest ='");
                sSql.Append(sequencia);
                sSql.Append("'");
                HLP.GeraXml.dao.ADO.HlpDbFuncoes.qrySeekUpdate(sSql.ToString());

            }
            catch (Exception)
            {
                throw;
            }

        }

        public static void AlteraUltimoRetornoNULL(string sequencia)
        {
            try
            {
                StringBuilder sSql = new StringBuilder();
                sSql.Append("update MANIFEST ");
                sSql.Append("set DS_ULTIMORET = NULL ");
                sSql.Append("where ");
                sSql.Append("cd_empresa ='");
                sSql.Append(Acesso.CD_EMPRESA);
                sSql.Append("' ");
                sSql.Append("and ");
                sSql.Append("cd_manifest ='");
                sSql.Append(sequencia);
                sSql.Append("'");
                HLP.GeraXml.dao.ADO.HlpDbFuncoes.qrySeekUpdate(sSql.ToString());

            }
            catch (Exception)
            {
                throw;
            }

        }


        public static DateTime? GetUltimoRetorno(string sequencia)
        {
            try
            {
                string s = HlpDbFuncoes.qrySeekValue("MANIFEST",
                    "coalesce(DS_ULTIMORET,'')",
                    string.Format("cd_manifest = '{0}' and cd_empresa = '{1}'", sequencia, Acesso.CD_EMPRESA));
                if (s != "")
                    return Convert.ToDateTime(s);
                else
                    return null;

            }
            catch (Exception)
            {

                throw;
            }

        }




        public static DataTable GetIDE(string sequencia)
        {
            try
            {
                StringBuilder sQuery = new StringBuilder();
                sQuery.Append("Select ");
                sQuery.Append("e.cd_tpemitente tpEmit, ");
                sQuery.Append("coalesce(m.cd_seriemanifest,'0') serie, ");
                sQuery.Append("coalesce(m.cd_ufini,'') UFIni , ");
                sQuery.Append("coalesce(m.cd_uffim,'') UFFim ");
                sQuery.Append("from manifest m inner join Empresa e on m.cd_empresa = e.cd_empresa ");
                sQuery.Append("where m.cd_manifest = '{0}' and m.cd_empresa = '{1}' ");


                return HlpDbFuncoes.qrySeekRet(string.Format(sQuery.ToString(), sequencia, Acesso.CD_EMPRESA));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetInfMunCarrega(string sequencia)
        {
            try
            {
                StringBuilder sQuery = new StringBuilder();
                sQuery.Append("Select ");
                sQuery.Append("c.cd_muncarrega cMunCarrega, ");
                sQuery.Append("c.nm_muncarrega xMunCarrega, ");
                sQuery.Append("c.uf_muncarrega UFPer ");
                sQuery.Append("from carregamu c ");
                sQuery.Append("where c.cd_manidesmembra= '{0}' and c.cd_empresa = '{1}'");

                return HlpDbFuncoes.qrySeekRet(string.Format(sQuery.ToString(), sequencia, Acesso.CD_EMPRESA));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetEmit()
        {
            try
            {
                StringBuilder sQuery = new StringBuilder();
                sQuery.Append("Select ");
                sQuery.Append("e.cd_empresa , ");
                sQuery.Append("e.cd_cgc CNPJ , ");
                sQuery.Append("e.cd_insest IE , ");
                sQuery.Append("e.nm_empresa xNome , ");
                sQuery.Append("e.nm_guerra xFant , ");
                sQuery.Append("e.ds_endnor xLgr , ");
                sQuery.Append("e.nr_end nro , ");
                sQuery.Append("e.ds_endcomp xCpl , ");
                sQuery.Append("e.nm_bairronor xBairro , ");
                sQuery.Append("cid.cd_municipio cMun , ");
                sQuery.Append("e.nm_cidnor xMun , ");
                sQuery.Append("e.cd_cepnor CEP , ");
                sQuery.Append("e.cd_ufnor uf , ");
                sQuery.Append("e.cd_fonenor fone , ");
                sQuery.Append("e.cd_email email ");
                sQuery.Append("from empresa e inner join cidades cid on ");
                sQuery.Append("e.nm_cidnor = cid.nm_cidnor ");
                sQuery.Append("where e.cd_empresa = '{0}'");

                return HlpDbFuncoes.qrySeekRet(string.Format(sQuery.ToString(), Acesso.CD_EMPRESA));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetInfDoc(string sequencia)
        {
            try
            {
                StringBuilder sQuery = new StringBuilder();
                sQuery.Append("Select ");
                sQuery.Append("c.nr_lanc, ");
                sQuery.Append("c.cd_cidnorate cMunDescarga , ");
                sQuery.Append("cid.nm_cidnor xMunDescarga, ");
                sQuery.Append("c.cd_chavecte chCTe, ");
                sQuery.Append("c.cd_conheci  nCT, ");
                sQuery.Append("c.cd_serie serie, ");
                sQuery.Append("c.cd_subse subser, ");
                sQuery.Append("c.dt_emissao dEmi, ");
                sQuery.Append("c.vl_total vCarga ");
                sQuery.Append("from maniftab m ");
                sQuery.Append("inner join conhecim c  ");
                sQuery.Append("on m.nr_lancconhecim = c.nr_lanc and m.cd_empresa = c.cd_empresa ");
                sQuery.Append("inner join cidades cid ");
                sQuery.Append("on c.cd_cidnorate = cid.cd_municipio ");
                sQuery.Append("where m.cd_manifest = '{0}'  and m.cd_empresa = '{1}'");

                return HlpDbFuncoes.qrySeekRet(string.Format(sQuery.ToString(), sequencia, Acesso.CD_EMPRESA));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static void ValidaInfDoc(string sequencia)
        {
            string sMessage = "";
            try
            {
                StringBuilder sQuery = new StringBuilder();
                sQuery.Append("Select ");
                sQuery.Append("c.cd_conheci, c.cd_cidnorate ");
                sQuery.Append("from maniftab m inner join conhecim c on m.nr_lancconhecim = c.nr_lanc and m.cd_empresa = c.cd_empresa ");
                sQuery.Append("where m.cd_manifest = '{0}'  and m.cd_empresa = '{1}' and c.cd_cidnorate is null");

                foreach (DataRow row in HlpDbFuncoes.qrySeekRet(string.Format(sQuery.ToString(), sequencia, Acesso.CD_EMPRESA)).Rows)
                {
                    sMessage += string.Format("Conhecimento: {0}, não contem município de (calculado até){1}", row["cd_conheci"].ToString(), Environment.NewLine);
                }
                if (sMessage != "")
                {
                    throw new Exception(sMessage);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetInfNF(string nrlanc)
        {
            try
            {
                StringBuilder sQuery = new StringBuilder();
                sQuery.Append("Select ");
                sQuery.Append("nfc.cd_chave chNFe, ");
                sQuery.Append("'1111111111' CNPJ, ");
                sQuery.Append("'SP' uf,  ");
                sQuery.Append("nfc.cd_nf nNF, ");
                sQuery.Append("nfc.cd_serie serie, ");
                sQuery.Append("nfc.dt_emi dEmi, ");
                sQuery.Append("nfc.vl_nf vCarga");
                sQuery.Append(" from nfconhec nfc ");
                sQuery.Append("where nfc.nr_lancconhecim = '{0}' and nfc.cd_empresa = '{1}'");

                return HlpDbFuncoes.qrySeekRet(string.Format(sQuery.ToString(), nrlanc, Acesso.CD_EMPRESA));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetTot(string nrLanc)
        {
            try
            {
                StringBuilder sQuery = new StringBuilder();
                sQuery.Append("SELECT ");
                sQuery.Append("coalesce(c.vl_pesomerctransp,0)qCarga, ");
                sQuery.Append("coalesce(c.vl_totmerctransp,0)vCarga ");
                sQuery.Append("FROM conhecim c ");
                sQuery.Append("where c.nr_lanc = '{0}' and c.cd_empresa = '{1}'");

                return HlpDbFuncoes.qrySeekRet(string.Format(sQuery.ToString(), nrLanc, Acesso.CD_EMPRESA));
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static DataTable GetTotTemporario(string nrLanc)
        {
            try
            {
                StringBuilder sQuery = new StringBuilder();
                sQuery.Append("SELECT ");
                sQuery.Append("sum(nfconhec.vl_nf) vl_nf, sum(nfconhec.vl_peso) vl_peso ");
                sQuery.Append("FROM nfconhec ");
                sQuery.Append("where nfconhec.nr_lancconhecim = '{0}' and nfconhec.cd_empresa = '{1}'");

                return HlpDbFuncoes.qrySeekRet(string.Format(sQuery.ToString(), nrLanc, Acesso.CD_EMPRESA));
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static string GetObs(string sequencia)
        {
            try
            {
                string sobs = daoUtil.RetornaBlob(string.Format("SELECT cd_obscontrib FROM MANIFEST WHERE cd_manifest = '{0}' and cd_empresa = '{1}'",
                    sequencia, Acesso.CD_EMPRESA));
                if (sobs != "")
                    return Util.TiraCaracterEstranho(sobs);
                else
                    return null;

            }
            catch (Exception)
            {

                throw;
            }

        }



        // DADOS RODO

        public static DataTable GetMotorista(string sequencia)
        {
            try
            {
                StringBuilder sQuery = new StringBuilder();
                sQuery.Append("SELECT ");
                sQuery.Append("mot.nm_motoris xNome, mot.cd_cgc cpf  from manifest m inner join motorista mot on m.cd_motoris = mot.cd_motoris ");
                sQuery.Append("where m.cd_manifest = '{0}' and m.cd_empresa = '{1}'");

                return HlpDbFuncoes.qrySeekRet(string.Format(sQuery.ToString(), sequencia, Acesso.CD_EMPRESA));
            }
            catch (Exception)
            {

                throw;
            }

        }

        public static DataTable GetVeiculoTracao(string sequencia)
        {
            try
            {
                StringBuilder sQuery = new StringBuilder();
                sQuery.Append("SELECT ");
                sQuery.Append("coalesce(v.st_veiculo,'S') st_veiculo, ");
                sQuery.Append("e.cd_rtb RNTRC, ");
                sQuery.Append("m.cd_ciot CIOT, ");
                sQuery.Append("m.cd_veiculo cint, ");
                sQuery.Append("v.cd_placa placa, ");
                sQuery.Append("v.cd_tara tara, ");
                sQuery.Append("v.cd_tonela capKG, ");
                sQuery.Append("v.cd_m3 capM3 ");
                sQuery.Append("from manifest m  inner join empresa e on m.cd_empresa = e.cd_empresa ");
                sQuery.Append("inner join veiculo v on v.cd_veiculo = m.cd_veiculo ");
                sQuery.Append("inner join motorista mot on m.cd_motoris = mot.cd_motoris ");
                sQuery.Append("where m.cd_manifest = '{0}' and m.cd_empresa = '{1}'");

                return HlpDbFuncoes.qrySeekRet(string.Format(sQuery.ToString(), sequencia, Acesso.CD_EMPRESA));

            }
            catch (Exception)
            {

                throw;
            }

        }

        public static DataTable GetVeiculoProp(string sequencia)
        {
            try
            {
                StringBuilder sQuery = new StringBuilder();
                sQuery.Append("SELECT ");
                sQuery.Append("v.cd_uf prop_UF, ");
                sQuery.Append("v.cd_cgc CNPJ, ");
                sQuery.Append("v.cd_rtb RNTRC, ");
                sQuery.Append("v.nm_proprie xNome, ");
                sQuery.Append("v.cd_ie IE, ");
                sQuery.Append("v.cd_uf_proprietario uf, ");
                sQuery.Append("v.st_tpproprietario tpProp ");
                sQuery.Append("from manifest m  inner join empresa e on m.cd_empresa = e.cd_empresa ");
                sQuery.Append("inner join veiculo v on v.cd_veiculo = m.cd_veiculo ");
                sQuery.Append("inner join motorista mot on m.cd_motoris = mot.cd_motoris ");
                sQuery.Append("where m.cd_manifest = '{0}' and m.cd_empresa = '{1}'");

                return HlpDbFuncoes.qrySeekRet(string.Format(sQuery.ToString(), sequencia, Acesso.CD_EMPRESA));

            }
            catch (Exception)
            {

                throw;
            }

        }

        public static DataTable GetVeiculoReboque(string sequencia)
        {
            try
            {
                StringBuilder sQuery = new StringBuilder();
                sQuery.Append("SELECT ");
                sQuery.Append("rm.cd_reboque cInt, ");
                sQuery.Append("rm.cd_placareb_ma placa, ");
                sQuery.Append("r.cd_tarareb tara, ");
                sQuery.Append("r.cd_ufreb uf, ");
                sQuery.Append("r.cd_TPCARROCERIA tpCar, ");
                sQuery.Append("r.cd_capacidadereb capKG, ");
                sQuery.Append("r.cd_capamcreb capM3, ");
                sQuery.Append("coalesce(r.st_proprietario,'N')st_proprietario , ");
                sQuery.Append("r.cd_cgccpfreb CNPJ, ");
                sQuery.Append("r.cd_rntrc RNTRC, ");
                sQuery.Append("r.nm_propreb xNome, ");
                sQuery.Append("r.cd_inscest IE, ");
                sQuery.Append("r.cd_tpproreb tpProp, ");
                sQuery.Append("r.cd_tpcarroceria tpCar ");
                sQuery.Append("from reboquema rm inner join reboque r on rm.cd_reboque = r.cd_reboque ");
                sQuery.Append("where rm.cd_manifest = '{0}' and rm.cd_empresa = '{1}'");
                return HlpDbFuncoes.qrySeekRet(string.Format(sQuery.ToString(), sequencia, Acesso.CD_EMPRESA));

            }
            catch (Exception)
            {

                throw;
            }

        }

        public static DataTable GetValePed(string sequencia)
        {
            try
            {
                StringBuilder sQuery = new StringBuilder();
                sQuery.Append("SELECT ");
                sQuery.Append("m.cd_cgcfornec CNPJForn, ");
                sQuery.Append("m.cd_cgcpagante CNPJPg, ");
                sQuery.Append("m.cd_comprovavale nCompra ");
                sQuery.Append("from manifest m where m.cd_manifest = '{0}' and m.cd_empresa = '{1}' and m.cd_cgcfornec is not null and m.cd_comprovavale is not null");
                return HlpDbFuncoes.qrySeekRet(string.Format(sQuery.ToString(), sequencia, Acesso.CD_EMPRESA));

            }
            catch (Exception)
            {

                throw;
            }

        }









    }
}

