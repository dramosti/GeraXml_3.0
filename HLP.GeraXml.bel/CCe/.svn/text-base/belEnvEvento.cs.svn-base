using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HLP.GeraXml.bel.CCe
{
    public class belEnvEvento
    {
        /// <summary>
        /// Descrição: Versão do leiaute
        /// Ocorrencia:1-1
        /// Tamanho:1-4 / 2
        /// </summary>
        public string versao { get; set; }

        /// <summary>
        /// Descrição: Identificador de controle do Lote de envio do Evento. Número seqüencial autoincremental único para identificação do Lote. A responsabilidade de gerar e controlar é exclusiva do autor do evento. O Web Service não faz qualquer uso deste identificador.
        /// Ocorrencia:1-1
        /// Tamanho:1-15
        /// </summary>
        private string _id;

        public string id
        {
            get { return _id; }
            set { _id = value.PadLeft(15, '0'); }
        }

        /// <summary>
        /// Descrição: Evento, um lote pode conter até 20 eventos
        /// Ocorrencia:1-20
        /// </summary>
        public List<belEvento> evento = new List<belEvento>();
    }
}
