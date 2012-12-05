using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HLP.GeraXml.Comum.Static;
using HLP.GeraXml.dao.ADO;

namespace HLP.GeraXml.dao.CTe
{
    public class daoDadosrodo
    {
        public DataTable BuscaDadosRodo(string sCte)
        {
            try
            {
                StringBuilder sQuery = new StringBuilder();
                sQuery.Append("Select ");
                sQuery.Append("coalesce(conhecim.ds_respseg,'')respSeg, ");
                sQuery.Append("coalesce(empresa.CD_APOBRIG,'')nApol, ");
                sQuery.Append("coalesce(empresa.cd_rtb,'')RNTRC, ");
                sQuery.Append("coalesce(conhecim.DT_PREV,'')dPrev, ");
                sQuery.Append("coalesce(conhecim.CD_LOTA,'')lota ");
                sQuery.Append("from conhecim ");
                sQuery.Append("join empresa on conhecim.cd_empresa = empresa.cd_empresa ");
                sQuery.Append("where conhecim.nr_lanc ='" + sCte + "' ");
                sQuery.Append("and empresa.cd_empresa ='" + Acesso.CD_EMPRESA + "'");

                return HlpDbFuncoes.qrySeekRet(sQuery.ToString());

            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        public DataTable BuscaDadosVeiculo(string Veiculo)
        {
            try
            {

                StringBuilder sQuery = new StringBuilder();
                sQuery.Append("Select ");
                sQuery.Append("coalesce(veiculo.cd_renavam,'')RENAVAM, ");
                sQuery.Append("coalesce(veiculo.cd_placa,'')placa, ");
                sQuery.Append("coalesce(veiculo.cd_tara,'0.00')tara, ");
                sQuery.Append("coalesce(veiculo.cd_tonela,'0.00')capKG, ");
                sQuery.Append("coalesce(veiculo.cd_m3,'0.00')capM3, ");
                sQuery.Append("coalesce(veiculo.st_tpproprietario,'')tpProp, ");
                sQuery.Append("coalesce(veiculo.cd_tipo,'')tpVeic, ");
                sQuery.Append("coalesce(veiculo.st_rodado,'')tpRod, ");
                sQuery.Append("coalesce(veiculo.st_carroceria,'')tpCar, ");
                sQuery.Append("coalesce(veiculo.cd_uf,'')UF ");
                sQuery.Append("from veiculo ");
                sQuery.Append("where veiculo.cd_veiculo ='" + Veiculo + "' ");


                return HlpDbFuncoes.qrySeekRet(sQuery.ToString());

            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        public DataTable BuscaDadosProprietarioVeiculo(string Veiculo)
        {
            try
            {

                StringBuilder sQuery = new StringBuilder();
                sQuery.Append("Select ");
                sQuery.Append("coalesce(veiculo.cd_cgc,'')CPF, ");
                sQuery.Append("coalesce(veiculo.cd_rtb,'')RNTRC, ");
                sQuery.Append("coalesce(veiculo.nm_proprie,'')xNome, ");
                sQuery.Append("coalesce(veiculo.cd_ie,'ISENTO')IE, ");
                sQuery.Append("coalesce(veiculo.cd_uf,'')UF, ");
                sQuery.Append("coalesce(veiculo.ST_TPPROP,'')tpProp ");
                sQuery.Append("from veiculo ");
                sQuery.Append("where veiculo.cd_veiculo ='" + Veiculo + "' ");

                return HlpDbFuncoes.qrySeekRet(sQuery.ToString());

            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        public DataTable BuscaDadosMotorista(string Motorista)
        {
            try
            {

                StringBuilder sQuery = new StringBuilder();
                sQuery.Append("Select ");
                sQuery.Append("coalesce(motorista.nm_motoris,'')xNome, ");
                sQuery.Append("coalesce(motorista.cd_cgc,'')CPF ");
                sQuery.Append("from motorista ");
                sQuery.Append("where motorista.cd_motoris ='" + Motorista + "' ");

                return HlpDbFuncoes.qrySeekRet(sQuery.ToString());

            }
            catch (Exception ex)
            {
                throw ex;
            }




        }
    }
}
