using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HLP.GeraXml.dao.CTe;
using System.Data;
using HLP.GeraXml.bel.CTe.infCte.infCTeNorm;
using HLP.GeraXml.Comum.Static;

namespace HLP.GeraXml.bel.CTe
{
    public class belDadosrodo : daoDadosrodo
    {
        public void PopulaRodo(belinfCte objbelinfCte, string sCte)
        {
            try
            {
                DataTable dt = BuscaDadosRodo(sCte);


                objbelinfCte.infCTeNorm.seg = new belseg();
                objbelinfCte.infCTeNorm.rodo = new belrodo();

                foreach (DataRow dr in dt.Rows)
                {
                    objbelinfCte.infCTeNorm.seg.respSeg = dr["respSeg"].ToString() != "" ? dr["respSeg"].ToString().Substring(0, 1) : "";
                    objbelinfCte.infCTeNorm.seg.nApol = dr["nApol"].ToString() != "" ? Util.TiraSimbolo(dr["nApol"].ToString()) : "";
                    objbelinfCte.infCTeNorm.rodo.RNTRC = dr["RNTRC"].ToString();
                    objbelinfCte.infCTeNorm.rodo.dPrev = dr["dPrev"].ToString();
                    objbelinfCte.infCTeNorm.rodo.lota = dr["lota"].ToString();
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        public void PopulaVeiculo(belinfCte objbelinfCte, string sCte)
        {
            try
            {
                objbelinfCte.infCTeNorm.rodo.veic = new List<belveic>();
                if (objbelinfCte.infCTeNorm.rodo.lota == "1")
                {
                    for (int tot = 0; tot < objbelinfCte.ide.Veiculo.Count; tot++)
                    {
                        DataTable dt = BuscaDadosVeiculo(objbelinfCte.ide.Veiculo[tot]);

                        foreach (DataRow dr in dt.Rows)
                        {
                            belveic veic = new belveic();
                            veic.RENAVAM = dr["RENAVAM"].ToString();
                            veic.placa = dr["placa"].ToString();
                            veic.tara = dr["tara"].ToString().Substring(0, dr["tara"].ToString().IndexOf('.'));
                            veic.capKG = dr["capKG"].ToString().Substring(0, dr["capKG"].ToString().IndexOf('.'));
                            veic.capM3 = dr["capM3"].ToString().Substring(0, dr["capM3"].ToString().IndexOf('.'));
                            veic.tpProp = dr["tpProp"].ToString();
                            veic.tpVeic = dr["tpVeic"].ToString();
                            veic.tpRod = dr["tpRod"].ToString();
                            veic.tpCar = dr["tpCar"].ToString();
                            veic.UF = dr["UF"].ToString();

                            objbelinfCte.infCTeNorm.rodo.veic.Add(veic);
                        }

                        if (objbelinfCte.infCTeNorm.rodo.veic[tot].tpProp == "T")
                        {
                            DataTable dtP = BuscaDadosProprietarioVeiculo(objbelinfCte.ide.Veiculo[tot]);

                            objbelinfCte.infCTeNorm.rodo.veic[tot].prop = new belprop();
                            foreach (DataRow dr in dtP.Rows)
                            {
                                objbelinfCte.infCTeNorm.rodo.veic[tot].prop.CPFCNPJ = Util.TiraSimbolo(dr["CPF"].ToString());
                                objbelinfCte.infCTeNorm.rodo.veic[tot].prop.RNTRC = dr["RNTRC"].ToString();
                                objbelinfCte.infCTeNorm.rodo.veic[tot].prop.xNome = Util.TiraSimbolo(dr["xNome"].ToString(), "");
                                objbelinfCte.infCTeNorm.rodo.veic[tot].prop.IE = Util.TiraSimbolo(dr["IE"].ToString());
                                objbelinfCte.infCTeNorm.rodo.veic[tot].prop.UF = dr["UF"].ToString();
                                objbelinfCte.infCTeNorm.rodo.veic[tot].prop.tpProp = dr["tpProp"].ToString();
                            }

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        public void PopulaMotorista(belinfCte objbelinfCte, string sCte)
        {
            try
            {
                if (objbelinfCte.infCTeNorm.rodo.veic.Count() > 0)
                {
                    DataTable dt = BuscaDadosMotorista(objbelinfCte.ide.Motorista);
                    if (objbelinfCte.infCTeNorm.rodo.lota == "1")
                    {
                        objbelinfCte.infCTeNorm.rodo.moto = new belmoto();
                    }
                    foreach (DataRow dr in dt.Rows)
                    {
                        objbelinfCte.infCTeNorm.rodo.moto = new belmoto();
                        objbelinfCte.infCTeNorm.rodo.moto.xNome = Util.TiraSimbolo(dr["xNome"].ToString(), "");
                        objbelinfCte.infCTeNorm.rodo.moto.CPF = Util.TiraSimbolo(dr["CPF"].ToString());
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }




        }
    }
}
