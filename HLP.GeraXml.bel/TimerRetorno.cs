using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HLP.GeraXml.bel
{
    [Serializable]
    public class TimerRetorno
    {
        public List<Recibos> lRecibos = new List<Recibos>();
    }

    public class Recibos
    {
        public string cd_recibo { get; set; }
        public DateTime dataHora { get; set; }
    }
}
