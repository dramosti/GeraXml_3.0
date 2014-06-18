using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HLP.GeraXml.Comum.Static;
using HLP.GeraXml.dao;

namespace HLP.GeraXml.bel.CTe
{
    public class belcompl
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sCTE">nr_lanc</param>
        public belcompl(string sCTE)
        {
            this.ObsCont = new obsCont();
            this.ObsCont.xTexto = daoUtil.RetornaBlob(string.Format("select c.ds_obs from conhecim c where c.nr_lanc  = '{0}' and c.cd_empresa = '{1}'", sCTE, Acesso.CD_EMPRESA));

            this.ObsCont.xTexto = Util.TiraCaracterEstranho(this.ObsCont.xTexto).Trim();

            decimal dTransparencia = daoUtil.GetValorTransparenciaCTe(sCTE);

            if (dTransparencia > 0)
            {
                this.ObsCont.xTexto += (this.ObsCont.xTexto != "" ? " - " : "") + string.Format("O VALOR APROXIMADO DE TRIBUTOS INCIDENTES SOBRE O PRECO DESTE SERVICO É DE R${0}", dTransparencia.ToString());
            }


        }
        public belcompl() { this.ObsCont = new obsCont(); }

        public obsCont ObsCont { get; set; }
    }

    public class obsCont
    {
        public string xCampo = "OBSERVACAO";
        private string _xTexto = "";

        public string xTexto
        {
            get { return _xTexto; }
            set { _xTexto = Util.TiraCaracterEstranho(value); }
        }
    }
}
