using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HLP.GeraXml.bel.CCe
{
    public class belEvento
    {
        /// <summary>
        /// Descrição: Versão do leiaute do evento 
        /// Ocorrencia:1-1
        /// Tamanho:1-4 /2
        /// </summary>
        public string versao { get; set; }

        private string _idLote;

        public string idLote
        {
            get { return _idLote; }
            set { _idLote = value; }
        }

        /// <summary>
        /// Descrição: Grupo de informações do registro do Evento
        /// Ocorrencia:1-1
        /// </summary>
        public _infEvento infEvento;
    }
}
