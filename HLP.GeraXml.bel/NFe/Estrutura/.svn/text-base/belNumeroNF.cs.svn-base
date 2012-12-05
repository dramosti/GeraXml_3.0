using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HLP.GeraXml.dao.NFe;
using HLP.GeraXml.Comum.Static;

namespace HLP.GeraXml.bel.NFe.Estrutura
{
    public class belNumeroNF : dao.NFe.daoNumeroNF
    {
        public List<belPesquisaNotas> lobjPesquisa = new List<belPesquisaNotas>();


        public belNumeroNF(List<belPesquisaNotas> _lobjPesquisa)
        {
            this.lobjPesquisa = _lobjPesquisa;
            ValidaGruposFaturamento();
            sGrupoNF = lobjPesquisa.FirstOrDefault().sCD_GRUPONF;
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
