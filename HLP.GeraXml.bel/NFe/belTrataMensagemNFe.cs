using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HLP.GeraXml.bel.NFe
{
    public class belTrataMensagemNFe
    {
        public enum Tipo
        {
            Cancelamento,
            Inutilizacao,
            Status,
            Envio,
            Individual,
            Situacao,
            SituacaoCadastral,
            ContingenciaFS

        }


        public static string RetornaMensagem(object objStatus, Tipo tipo)
        {
            try
            {
                string sMensagem = "";
                if (tipo == Tipo.Status)
                {
                    belStatusServicoNFe.DadosRetorno dRet = (belStatusServicoNFe.DadosRetorno)objStatus;
                    sMensagem = "Código de Retorno: " + dRet.cStat + Environment.NewLine +
                            "Motivo: " + dRet.xMotivo;
                }
                else if (tipo == Tipo.Situacao)
                {
                    belConsultaStatusNota.DadosRetorno dRet = (belConsultaStatusNota.DadosRetorno)objStatus;
                    sMensagem = "Nota Fiscal Eletronica de Sequência: " + dRet.seqNota + Environment.NewLine +
                                              "Número da Nota: " + dRet.nNota + Environment.NewLine + Environment.NewLine +
                                              "Cód. do Status - " + dRet.cStat + Environment.NewLine +
                                              "Status - " + dRet.xMotivo + Environment.NewLine +
                                              "Chave de Acesso - " + dRet.chNFe + Environment.NewLine +
                                              "Data do Recebimento - " + dRet.dhRecbto + Environment.NewLine +
                                              "Número do Protocolo - " + dRet.nProt + Environment.NewLine +
                                              "Valor do Digest - " + dRet.digVal;


                }
                else if (tipo == Tipo.Cancelamento)
                {
                    belCancelamento.DadosRetorno dRet = (belCancelamento.DadosRetorno)objStatus;

                    sMensagem = string.Format("Nota Fiscal Eletrônica de Sequência: {0}{1}" +
                                "Número da Nota: {2}{1}" +
                                "Chave NFe: {3}{1}" +
                                "Protocolo: {4}{1}{1}" +
                                "Status do Processo: {5}{1}" +
                                "Informação: {6}{1}",
                                                dRet.seqNF,
                                                Environment.NewLine,
                                                dRet.nNF,
                                                dRet.chnfe,
                                                dRet.nprot,
                                                dRet.cstat,
                                                dRet.xMotivo);

                }
                else if (tipo == Tipo.SituacaoCadastral)
                {
                    belConsultaStatusCliente.DadosRetorno dRet = (belConsultaStatusCliente.DadosRetorno)objStatus;
                    sMensagem = string.Format("Cod. Status: {0}{1}" +
                                "Status: {2}{1}" +
                                "Situação do contribuinte: {3}{1}" +
                                "Data e hora de processamento da consulta: {4}{1}" +
                                "Razão Social: {5}{1}" +
                                "Regime de Apuração do ICMS do Contribuinte: {6}{1}" +
                                "CNAE principal do contribuinte: {7}{1}" +
                                "Data de Início da Atividade do Contribuinte: {8}{1}" +
                                "Data da última modificação da situação cadastral do contribuinte: {9}{1}" +
                                "Data de ocorrência da baixa do contribuinte: {10}{1}",
                                                dRet.cStat,
                                                Environment.NewLine,
                                                dRet.xMotivo,
                                                dRet.cSit,
                                                dRet.dhCons,
                                                dRet.xNome,
                                                dRet.xRegApur,
                                                dRet.CNAE,
                                                dRet.dIniAtiv,
                                                dRet.dUltSit,
                                                dRet.dBaixa);

                }
                else if (tipo == Tipo.Envio)
                {
                    List<belBusRetFazenda.DadosRetorno> lRet = (List<belBusRetFazenda.DadosRetorno>)objStatus;
                    sMensagem = "Dados da Consulta ao Sefaz..." + Environment.NewLine + Environment.NewLine;
                    foreach (belBusRetFazenda.DadosRetorno dRet in lRet)
                    {
                        sMensagem += string.Format("Seq: {0} - Status: {1} - {2}{3}",
                            (String.IsNullOrEmpty(dRet.seqNota) ? "Lote" : dRet.seqNota),
                                                    dRet.cStat,
                                                    dRet.xMotivo,
                                                    Environment.NewLine);
                    }
                }
                else if (tipo == Tipo.ContingenciaFS)
                {
                    List<belPesquisaNotas> lRet = (List<belPesquisaNotas>)objStatus;
                    sMensagem = "Arquivos gerados em Modo de FS(Formulário de Segurança)" + Environment.NewLine + Environment.NewLine;
                    foreach (belPesquisaNotas dRet in lRet)
                    {
                        sMensagem += string.Format("Seq :{0} - Arquivo Gerado com sucesso.{1}",
                                                    dRet.sCD_NFSEQ,
                                                    Environment.NewLine);
                    }
                }
                else if (tipo == Tipo.Inutilizacao)
                {
                    belInutilizacao.DadosRetorno lRet = (belInutilizacao.DadosRetorno)objStatus;

                    if (lRet.cStat.Equals("102"))
                    {
                        sMensagem = "Tipo Ambiente: " + lRet.tpAmb + Environment.NewLine +
                                              "Status: " + lRet.cStat + Environment.NewLine +
                                              "Descrição: " + lRet.xMotivo + Environment.NewLine +
                                              "Ano: " + lRet.ano + Environment.NewLine +
                                              "Modelo da NF-e: " + lRet.mod + Environment.NewLine +
                                              "Serie da NF-e: " + lRet.serie + Environment.NewLine +
                                              "Número Inicial: " + lRet.nNFIni + Environment.NewLine +
                                              "Número Final: " + lRet.nNFFin + Environment.NewLine +
                                              "Data do Recbto: " + lRet.dhRecbto + Environment.NewLine +
                                              "Número do Protocolo: " + lRet.nProt;
                    }
                    else
                    {
                        sMensagem = "Status: " + lRet.cStat + Environment.NewLine +
                                              "Descrição: " + lRet.xMotivo + Environment.NewLine;
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
