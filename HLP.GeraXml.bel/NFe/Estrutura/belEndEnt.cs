using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HLP.GeraXml.dao.NFe.Estrutura;
using HLP.GeraXml.Comum.Static;

namespace HLP.GeraXml.bel.NFe.Estrutura
{
    public class belEndEnt : daoEndEnt
    {
        /// <summary>
        /// CNPJ, informar os zeros não signifacitvos
        /// </summary>
        private string _cnpj;

        public string Cnpj
        {
            get { return _cnpj; }
            set { _cnpj = HLP.GeraXml.Comum.Static.Util.TiraSimbolo(value, ""); }
        }

        private string _cpf;

        public string Cpf
        {
            get { return _cpf; }
            set { _cpf = HLP.GeraXml.Comum.Static.Util.TiraSimbolo(value, ""); }
        }


        /// <summary>
        /// Logradouro
        /// </summary>
        private string _xlgr;

        public string Xlgr
        {
            get { return _xlgr; }
            set { _xlgr = HLP.GeraXml.Comum.Static.Util.TiraSimbolo(value, ""); }
        }
        /// <summary>
        /// Numero do Estabelecimento
        /// </summary>
        private string _nro;

        public string Nro
        {
            get { return _nro; }
            set { _nro = HLP.GeraXml.Comum.Static.Util.TiraSimbolo(value, ""); }
        }
        /// <summary>
        /// Complemento
        /// </summary>
        private string _xcpl;

        public string Xcpl
        {
            get { return _xcpl; }
            set { _xcpl = value; }
        }
        /// <summary>
        /// Nome do Bairro
        /// </summary>
        private string _xbairro;

        public string Xbairro
        {
            get { return _xbairro; }
            set { _xbairro = HLP.GeraXml.Comum.Static.Util.TiraSimbolo(value, ""); }
        }
        /// <summary>
        /// Código do município, Utilizar a Tabela do IBGE (Anexo IV - Tabela de UF, Município e País).
        /// </summary>
        private string _cmun;

        public string Cmun
        {
            get { return _cmun; }
            set { _cmun = HLP.GeraXml.Comum.Static.Util.TiraSimbolo(value, ""); }
        }
        /// <summary>
        /// Nome do Município, Informar 'EXTERIOR' para operações com o exterior
        /// </summary>
        private string _xmun;

        public string Xmun
        {
            get { return _xmun; }
            set { _xmun = HLP.GeraXml.Comum.Static.Util.TiraSimbolo(value, ""); }
        }
        /// <summary>
        /// UF, Informar 'EX' para operações com o exterior
        /// </summary>
        private string _uf;

        public string Uf
        {
            get { return _uf; }
            set { _uf = HLP.GeraXml.Comum.Static.Util.TiraSimbolo(value, ""); }
        }

        public void Carrega(string seqNF)
        {
            try
            {
                DataTable dt = BuscaEndEnt(seqNF);
                foreach (DataRow drEndent in dt.Rows)
                {
                    if (drEndent["CNPJ"].ToString() != "")
                    {
                        this.Cnpj = Util.TiraSimbolo(drEndent["CNPJ"].ToString().PadLeft(14, '0'), "");
                    }

                    if (drEndent["xLgr"].ToString() != "")
                    {
                        this.Xlgr = Util.TiraSimbolo(drEndent["xLgr"].ToString().Trim(), "");
                    }
                    if (drEndent["nro"].ToString() != "")
                    {
                        this.Nro = Util.TiraSimbolo(drEndent["nro"].ToString().Trim(), "");
                    }

                    if (drEndent["xBairro"].ToString() != "")
                    {
                        this.Xbairro = Util.TiraSimbolo(drEndent["xBairro"].ToString().Trim(), "");
                    }
                    if (drEndent["cMun"].ToString() != "")
                    {
                        this.Cmun = Util.TiraSimbolo(drEndent["cMun"].ToString().Trim(), "");
                    }

                    if (drEndent["xMun"].ToString() != "")
                    {
                        this.Xmun = Util.TiraSimbolo(drEndent["xMun"].ToString().Trim(), "");
                    }

                    if (drEndent["UF"].ToString() != "")
                    {
                        this.Uf = Util.TiraSimbolo(drEndent["UF"].ToString().Trim(), "");
                    }
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
