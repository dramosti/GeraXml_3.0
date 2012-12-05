using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HLP.GeraXml.bel.NFe.Estrutura
{
    public class belCampoPesquisa
    {
        public string NumeroNF { get; set; }
        public string SeqNF { get; set; }
        public string ChaveAcesso { get; set; }
        public string sCli_For { get; set; }
        public string cUF { get; set; }
        public string AAMM { get; set; }
        public string CNPJ { get; set; }
        public string serie { get; set; }

        public belCampoPesquisa RetornaCampoSelecionado(List<belCampoPesquisa> objLista, string sSeq_Lanc) 
        {
            try
            {
                return objLista.FirstOrDefault(C => C.SeqNF == sSeq_Lanc) as belCampoPesquisa;
            }
            catch (Exception ex)
            {                
                throw ex;
            }

        }
    }



   
}
