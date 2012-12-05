using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HLP.GeraXml.bel.CTe
{
    public static class belTrataMensagem
    {
        public static string sNumCte = "";

        public enum Tipo
        {
            Cancelamento,
            Inutilizacao,
            Status,
            Envio,
            Individual,
            Situacao

        }


        public static string RetornaMensagem(List<belStatusCte> ListaStatus, Tipo tipo)
        {
            try
            {
                string sMensagem = "";
                if (tipo == Tipo.Status)
                {
                    foreach (belStatusCte item in ListaStatus)
                    {
                        sMensagem = "Código de Retorno: " + item.CodRetorno + Environment.NewLine +
                            "Motivo: " + item.Motivo;
                    }
                }
                else if (tipo == Tipo.Envio)
                {
                    foreach (belStatusCte item in ListaStatus)
                    {
                        sMensagem += "Conhecimento Sequência " + item.NumeroSeq + Environment.NewLine +
                            "Código de Retorno: " + item.CodRetorno + Environment.NewLine +
                            "Motivo: " + item.Motivo + Environment.NewLine + "____________________________________________" + Environment.NewLine + Environment.NewLine;
                    }
                }
                else if (tipo == Tipo.Individual)
                {
                    foreach (belStatusCte item in ListaStatus)
                    {
                        if (item.NumeroSeq != null)
                        {
                            if (item.NumeroSeq == sNumCte)
                            {
                                sMensagem = "Código de Retorno: " + item.CodRetorno + Environment.NewLine +
                                    "Motivo: " + item.Motivo;
                                break;
                            }
                        }
                        else
                        {
                            sMensagem = "Código de Retorno: " + item.CodRetorno + Environment.NewLine +
                                   "Motivo: " + item.Motivo;
                            break;
                        }
                    }
                }
                else if (tipo == Tipo.Cancelamento)
                {
                    foreach (belStatusCte item in ListaStatus)
                    {
                        sMensagem += "Código de Retorno: " + item.CodRetorno + Environment.NewLine +
                            "Motivo: " + item.Motivo;
                        break;
                    }
                }
                else if (tipo == Tipo.Inutilizacao)
                {
                    foreach (belStatusCte item in ListaStatus)
                    {
                        sMensagem += "Código de Retorno: " + item.CodRetorno + Environment.NewLine +
                            "Motivo: " + item.Motivo;
                        break;
                    }
                }
                else if (tipo == Tipo.Situacao)
                {
                    foreach (belStatusCte item in ListaStatus)
                    {


                        sMensagem += "Conhecimento Sequência " + item.NumeroSeq + Environment.NewLine +
                                              "Número do conhecimento: " + sNumCte + Environment.NewLine + Environment.NewLine +
                                              "Código de Retorno: " + item.CodRetorno + Environment.NewLine +
                                              "Motivo: " + item.Motivo + Environment.NewLine +
                                              "Chave de Acesso - " + item.Chave + Environment.NewLine +
                                              "Data do Recebimento - " + item.DataRecebimento + Environment.NewLine +
                                              "Número do Protocolo - " + item.Protocolo;

                    }
                }

                return sMensagem;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
