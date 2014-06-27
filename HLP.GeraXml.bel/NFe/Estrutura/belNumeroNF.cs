using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HLP.GeraXml.dao.NFe;
using HLP.GeraXml.Comum.Static;
using System.Windows.Forms;
using HLP.GeraXml.bel.MDFe;

namespace HLP.GeraXml.bel.NFe.Estrutura
{
    public class belNumeroNF : dao.NFe.daoNumeroNF
    {
        public List<belPesquisaNotas> lobjPesquisa = new List<belPesquisaNotas>();


        public belNumeroNF(List<belPesquisaNotas> _lobjPesquisa)
        {
            this.lobjPesquisa = _lobjPesquisa;
            ValidaGruposFaturamento();
            if (Acesso.TP_EMIS == 3)
            {
                if (string.IsNullOrEmpty(Acesso.GRUPO_SCAN))
                {
                    throw new Exception("Favor configurar o Grupo de SCAN na configuração do GeraXml");
                }

                if (lobjPesquisa.FirstOrDefault().sCD_GRUPONF != Acesso.GRUPO_SCAN)
                {
                    if (MessageBox.Show(null, "Deseja que o Sistema altere o Grupo de faturamento da Nota ?", "A V I S O", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        sGrupoNF = Acesso.GRUPO_SCAN;
                        AlteraGrupoFaturamentoToSCAN(this.lobjPesquisa.Select(c => c.sCD_NFSEQ).ToArray());
                    }
                    else
                    {
                        throw new Exception("Sistema em modo SCAN e grupo de faturamento configurado no Gera não bate com grupo de faturameto da nota.");
                    }
                }
                else
                {
                    sGrupoNF = lobjPesquisa.FirstOrDefault().sCD_GRUPONF;
                }
            }
            else
            {
                sGrupoNF = lobjPesquisa.FirstOrDefault().sCD_GRUPONF;
            }
            foreach (belPesquisaNotas item in lobjPesquisa)
            {
                lsNotas.Add(item.sCD_NFSEQ);
            }
        }
        
        private void ValidaGruposFaturamento()
        {

            if (lobjPesquisa.Where(c => c.sCD_GRUPONF == lobjPesquisa[0].sCD_GRUPONF).Count() != lobjPesquisa.Count())
            {
                throw new Exception("Não é possivel Gerar Numeração de notas com Grupo de Faturamento Diferente.");
            }
        }



        public void AlteraDuplicatas(bool bNotaServico)
        {
            try
            {
                foreach (daoNumeroNF.DadosGerar nota in lDadosGerar)
                {
                    daoRegras.AlteraDuplicatasNfe(nota.nNF, nota.seqNF, bNotaServico);
                    if (Acesso.NM_EMPRESA.Equals("LORENZON") || Acesso.NM_EMPRESA.Equals("LOCON"))
                    {
                        belLorenzon objbelLorenzon = new belLorenzon();
                        objbelLorenzon.AlteraDuplicataLorenzon(nota.nNF, nota.seqNF);
                    }
                    AtualizaMovitem(nota);
                    belDuplicata objbelDuplicata = new belDuplicata();
                    objbelDuplicata.BuscaVencto(nota.seqNF, nota.nNF);
                }

            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public void AlteraDuplicatasNFe()
        {
            try
            {
                foreach (daoNumeroNF.DadosGerar nota in lDadosGerar)
                {
                    daoRegras.AlteraDuplicatasNfe(nota.nNF, nota.seqNF, false);
                    if (Acesso.NM_EMPRESA.Equals("LORENZON"))
                    {
                        belLorenzon objbelLorenzon = new belLorenzon();
                        objbelLorenzon.AlteraDuplicataLorenzon(nota.nNF, nota.seqNF);
                    }
                    AtualizaMovitem(nota);
                    belDuplicata objbelDuplicata = new belDuplicata();
                    objbelDuplicata.BuscaVencto(nota.seqNF, nota.nNF);
                }

            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
