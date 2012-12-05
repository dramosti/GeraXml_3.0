using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HLP.GeraXml.Comum.Static;

namespace HLP.GeraXml.bel.CCe
{
    public class _infEvento
    {



        /// <summary>
        /// Descrição: Código do órgão de recepção do Evento. Utilizar a Tabela  do IBGE, utilizar 90 para identificar o Ambiente Nacional.
        /// Ocorrencia:1-1
        /// Tamanho:2
        /// </summary>
        public string cOrgao { get; set; }

        /// <summary>
        /// Descrição: dentificação do Ambiente: 1 - Produção / 2 – Homologação 
        /// Ocorrencia:1-1
        /// Tamanho:1
        /// </summary>       
        public int tpAmb { get; set; }

        /// <summary>
        /// Descrição: Informar o CNPJ ou o CPF do autor do Evento 
        /// Ocorrencia:1-1
        /// Tamanho:14
        private string _CNPJ;

        public string CNPJ
        {
            get { return _CNPJ; }
            set { _CNPJ =  Util.TiraSimbolo(value, ""); }
        }
        /// <summary>
        /// Descrição: Informar o CNPJ ou o CPF do autor do Evento 
        /// Ocorrencia:1-1
        /// Tamanho:11
        private string _CPF;

        public string CPF
        {
            get { return _CPF; }
            set { _CPF = Util.TiraSimbolo(value, ""); }
        }

        /// <summary>
        /// Descrição:chave de Acesso da NF-e vinculada ao Evento
        /// Ocorrencia:1-1
        /// Tamanho:44
        /// </summary>
        public string chNFe { get; set; }
        /// <summary>
        /// Descrição: ta e hora do evento no formato AAAA-MM-DDThh:mm:ssTZD (UTC - Universal Coordinated Time, onde TZD pode ser -02:00 (Fernando de Noronha), -03:00 (Brasília) ou -04:00 (Manaus), no horário de verão serão -01:00, -02:00 e -03:00. Ex.: 2010-08-19T13:00:15-03:00.
        /// Ocorrencia:11
        /// </summary>
        public string dhEvento { get; set; }
        /// <summary>
        /// Descrição: Código do de evento = 110110 
        /// Ocorrencia:1-1
        /// Tamanho:6
        /// </summary>
        public string tpEvento { get { return "110110"; } }
        /// <summary>
        /// Descrição: eqüencial do evento para o mesmo tipo de evento.  Para maioria dos eventos será 1, nos casos em que possa existir mais de um evento, como é o caso da carta de correção, o autor do evento deve numerar de forma seqüencial. 
        /// Ocorrencia:1-1
        /// Tamanho:1-2
        /// </summary>
        public int nSeqEvento { get; set; }
        /// <summary>
        /// Descrição: Versão do evento 
        /// Ocorrencia:1-1
        /// Tamanho:1-4
        /// </summary>
        public string verEvento { get; set; }
        /// <summary>
        /// Descrição: formações da carta de correção 
        /// Ocorrencia:1-1
        /// </summary>
        public _detEvento detEvento { get; set; }



    }
}
