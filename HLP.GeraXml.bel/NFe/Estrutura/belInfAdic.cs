using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HLP.GeraXml.Comum.Static;
using HLP.GeraXml.dao.NFe.Estrutura;

namespace HLP.GeraXml.bel.NFe.Estrutura
{
    public class belInfAdic : daoInfAdic
    {
        /// <summary>
        /// Informaçoes dicionais de Inderesse do Fisco
        /// </summary>
        private string _infadfisco;

        public string Infadfisco
        {
            get { return _infadfisco; }
            set { _infadfisco = value; }
        }
        /// <summary>
        /// Informações Complementares de Interesses do Contribuintes
        /// </summary>
        private string _infcpl = "";

        public string Infcpl
        {
            get { return _infcpl; }
            set
            {
                if (value == null)
                {
                    _infcpl = string.Empty;
                }
                else
                {
                    _infcpl = _infcpl + ((_infcpl != "" && value != "") ? " - " : "") + value.Trim();
                }
            }

        }

        public belObsCont belObsCont
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public belObsFisco belObsFisco
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public belProcRef belProcRef
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public void Carrega(string seqNF, List<belDet> ldet, string sCNPJ, decimal dVbcIcmsRt, decimal dVIcmsRt)
        {
            try
            {

                this.Infcpl = BuscaMsgJAMAICA(seqNF, sCNPJ);
                this.Infcpl = BuscaMsgLORENZON(seqNF);
                bool cfopsValidos = (ldet.Count(p => (p.prod.Cfop.Equals("5101"))
                                                                   || (p.prod.Cfop.Equals("6107"))
                                                                   || (p.prod.Cfop.Equals("6101"))) > 0 ? true : false);
                this.Infcpl = MensagemSuperSimples(seqNF, cfopsValidos, sCNPJ);
                this.Infcpl = BuscaObs(seqNF);
                this.Infcpl = BuscaMsgPIS_COFINS(seqNF);
                this.Infcpl = BuscaMsgICMSrecolhido(seqNF);
                this.Infcpl = MessagemTotalizaCFOP(seqNF);
                this.Infcpl = MessagemFunRural(seqNF);
                if ((dVbcIcmsRt > 0) && (dVIcmsRt > 0))
                {
                    this.Infcpl = "VbcIcmsRetido: " + dVbcIcmsRt.ToString("#0.00") + " | VIcmsRetido: " + dVIcmsRt.ToString("#0.00") + " ;";
                }
                this.Infcpl = MsgInsumosZINCOBRIL(ldet);
                if (Acesso.NM_EMPRESA.Equals("GIWA"))
                    this.Infcpl = MsgGiwa(seqNF);


            }
            catch (Exception ex)
            {
                throw;
            }
        }



        private string MsgInsumosZINCOBRIL(List<belDet> ldet)
        {
            string msgInsumos = "";
            if (Acesso.NM_EMPRESA.Equals("ZINCOBRIL")) // OS_25787
            {
                decimal dmaoObra = ldet.Where(p => p.tp_industrializacao.Equals("M")).Sum(P => P.prod.Vprod);
                decimal dinsumos = ldet.Where(p => p.tp_industrializacao.Equals("I")).Sum(P => P.prod.Vprod);

                if (dmaoObra > 0)
                {
                    msgInsumos += "VALOR DA MÃO DE OBRA = R$" + dmaoObra.ToString() + ";";
                }
                if (dinsumos > 0)
                {
                    msgInsumos += "VALOR DOS INSUMOS = R$" + dinsumos.ToString() + ";";
                }
            }
            return msgInsumos;
        }
    }
}
