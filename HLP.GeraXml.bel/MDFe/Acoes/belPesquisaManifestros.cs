using HLP.GeraXml.Comum.Static;
using HLP.GeraXml.dao.CTe.MDFe;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace HLP.GeraXml.bel.MDFe.Acoes
{
    public class belPesquisaManifestros : daoPesquisaManifesto
    {
        private List<PesquisaManifestosModel> _resultado;
        public enum status { Enviados, NaoEnviados, Ambos };
        public List<PesquisaManifestosModel> resultado
        {
            get { return _resultado; }
            set { _resultado = value; }
        }


        public belPesquisaManifestros()
        {
            resultado = new List<PesquisaManifestosModel>();
        }

        public List<PesquisaManifestosModel> ExecutePesquisa(status st, DateTime dtIni, DateTime dtFim)
        {
            try
            {
                string sWhere = string.Format(" m.dt_cad between '{0}' and '{1}' and m.cd_empresa = '{2}' ",
                    dtIni.ToString("dd.MM.yyyy"),
                    dtFim.ToString("dd.MM.yyyy"),
                    Acesso.CD_EMPRESA);

                if (st != status.Ambos)
                {
                    sWhere += (st == status.NaoEnviados ? "and (m.st_mdfe = 'N' or m.st_mdfe is null or m.st_mdfe = '') " : "and m.st_mdfe = 'S'  ");
                }

                this.resultado = base.Execute(sWhere).AsEnumerable().Select(c => new PesquisaManifestosModel
                 {
                     numero = c["numero"].ToString(),
                     sequencia = c["sequencia"].ToString(),
                     dt_manife = (c["dt_cad"].ToString() != "" ? Convert.ToDateTime(c["dt_cad"].ToString()).ToString("dd/MM/yyyy") : ""),
                     descricao = c["descricao"].ToString(),
                     protocolo = c["protocolo"].ToString(),
                     cd_empresa = c["cd_empresa"].ToString(),
                     chaveMDFe = c["chave"].ToString(),
                     recibo = c["recibo"].ToString(),
                     status = c["status"].ToString(),
                     bEnviado = c["bEnviado"].ToString() == "0" ? false : true,
                     bCancelado = c["bCancelado"].ToString() == "0" ? false : true,
                 }).ToList();

                return this.resultado;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
