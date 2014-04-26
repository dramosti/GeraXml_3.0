using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HLP.GeraXml.dao.NFe.Estrutura;
using System.Data;
using HLP.GeraXml.Comum.Static;

namespace HLP.GeraXml.bel.NFe.Estrutura
{
    public class belTransp : daoTransp
    {
        private string _modfrete;
        public string Modfrete
        {
            get { return _modfrete; }
            set { _modfrete = value; }
        }

        public belReboque belReboque = new belReboque();
        public belTransportadora belTransportadora = new belTransportadora();
        public belRetTransp belRetTransp = new belRetTransp();
        public belVeicTransp belVeicTransp = new belVeicTransp();
        public belVol belVol = new belVol();
        public belLacres belLacres = new belLacres();

        public void Carrega(string seqNF)
        {
            try
            {
                DataTable dt = BuscaFrete(seqNF);

                if (dt.Rows.Count > 0)
                {
                    DataRow drTranspor = dt.Rows[0];
                    if (drTranspor["modFrete"].ToString() == "0")
                    {
                        this.Modfrete = "0";
                    }
                    else if (drTranspor["modFrete"].ToString() == "1") // destinatario
                    {
                        this.Modfrete = "1";
                    }
                    else if (drTranspor["modFrete"].ToString() == "2")
                    {
                        this.Modfrete = "2";
                    }
                    else
                    {
                        this.Modfrete = "9";
                    }
                    belTransportadora thisortadora = new belTransportadora();

                    if (drTranspor["st_pessoaj"].ToString() == "S")
                    {
                        if (drTranspor["CNPJ"].ToString() != "")
                        {
                            thisortadora.Cnpj = Util.TiraSimbolo(drTranspor["CNPJ"].ToString().PadLeft(14, '0'), "");
                        }
                    }
                    else
                    {
                        if (drTranspor["CD_CPF"].ToString() != "")
                        {
                            thisortadora.Cpf = Util.TiraSimbolo(drTranspor["CD_CPF"].ToString().PadLeft(11, '0'), "");
                        }

                    }

                    if (drTranspor["xnome"] != null)
                    {

                        int iTamanho = drTranspor["xnome"].ToString().Length - 1;
                        if (iTamanho > 59)
                        {
                            iTamanho = 59;
                            thisortadora.Xnome = Util.TiraSimbolo(drTranspor["xnome"].ToString().Substring(0, iTamanho), "");
                        }
                        else
                        {
                            thisortadora.Xnome = Util.TiraSimbolo(drTranspor["xnome"].ToString().Substring(0, drTranspor["xnome"].ToString().Length), "");
                        }
                    }

                    if (drTranspor["IE"].ToString() != "")
                    {
                        thisortadora.Ie = Util.TiraSimbolo(drTranspor["IE"].ToString(), "");
                    }

                    if (drTranspor["xEnder"].ToString() != "")
                    {
                        thisortadora.Xender = Util.TiraSimbolo(drTranspor["xEnder"].ToString(), "");
                    }
                    if (drTranspor["xMun"].ToString() != "")
                    {
                        thisortadora.Xmun = Util.TiraSimbolo(drTranspor["xMun"].ToString(), "");
                    }
                    if (drTranspor["UF"].ToString() != "")
                    {
                        thisortadora.Uf = drTranspor["UF"].ToString();
                    }
                    this.belTransportadora = thisortadora;
                    if ((drTranspor["placa"].ToString() != "") && (drTranspor["placa"].ToString() != null))
                    {
                        this.belVeicTransp.Placa = Util.TiraSimbolo(drTranspor["placa"].ToString().Replace(" ", "").Trim(), "");
                        if (drTranspor["UF"].ToString() != "")
                        {
                            this.belVeicTransp.Uf = drTranspor["UF"].ToString().Trim();
                        }

                        if (drTranspor["RNTC"].ToString() != "")
                        {
                            this.belVeicTransp.Rntc = drTranspor["RNTC"].ToString().Trim();
                        }
                        else
                        {
                            this.belVeicTransp.Rntc = "00";
                        }
                    }


                    try
                    {
                        decimal dqVol = Convert.ToDecimal(drTranspor["qVol"].ToString());
                        if ((drTranspor["qVol"].ToString() == "") || (drTranspor["qVol"].ToString() == "0"))
                        {
                            if (Acesso.NM_EMPRESA != "ZINCOBRIL")
                            {
                                dqVol = 1;
                            }
                            else
                            {
                                dqVol = 0;
                            }

                        }
                        this.belVol.Qvol = dqVol;
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(string.Format("{0} - Campo de Quantidade de Volumes na tela de Montar NF",
                                            ex.Message));
                    }

                    if (drTranspor["nVol"].ToString() != "")
                    {
                        this.belVol.Nvol = drTranspor["nVol"].ToString();
                    }

                    if (drTranspor["esp"].ToString() != "")
                    {
                        this.belVol.Esp = Util.TiraSimbolo(drTranspor["esp"].ToString(), "");
                    }

                    if (drTranspor["marca"].ToString() != "")
                    {
                        this.belVol.Marca = drTranspor["marca"].ToString();
                    }
                    if (drTranspor["pesoL"].ToString() != "")
                    {
                        try
                        {
                            decimal dpesoL = Math.Round(Convert.ToDecimal(drTranspor["pesoL"].ToString()), 3);
                            this.belVol.PesoL = dpesoL;
                        }
                        catch (Exception ex)
                        {
                            throw new Exception(string.Format("{0} - Campo Peso Liquido",
                                                              ex.Message));
                        }
                    }
                    if (drTranspor["pesoB"].ToString() != "")
                    {
                        try
                        {
                            decimal dpesoB = Math.Round(Convert.ToDecimal(drTranspor["pesoB"].ToString()), 3);
                            this.belVol.PesoB = dpesoB;
                        }
                        catch (Exception ex)
                        {
                            throw new Exception(string.Format("{0} - Campo Peso Bruto",
                                                             ex.Message));
                        }
                    }
                }
                else
                {
                    this.Modfrete = "9";
                }                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
