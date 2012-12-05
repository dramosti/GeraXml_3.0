using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HLP.GeraXml.bel.NFes
{
    /// <summary>
    /// Representa a estrutura da Nota Fiscal de Serviços Eletrônica assinada
    /// </summary>
    public class TcNfse
    {
        public TcInfNfse InfNfse { get; set; }

        public string Signature { get; set; }
    }
}
