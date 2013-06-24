using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HLP.GeraXml.dao.NFe.Estrutura;
using HLP.GeraXml.Comum.Static;

namespace HLP.GeraXml.bel.NFe.Estrutura
{
    public class belDest : daoDest
    {
        /// <summary>
        /// Informar o CNPJ ou o CPF do destinatário, preenchendo os zeros não significativos. Não informar o conteúdo da TAG se a operação for realizada com o exterior.
        /// </summary>
        private string _cnpj;

        public string Cnpj
        {
            get { return _cnpj; }
            set { _cnpj = HLP.GeraXml.Comum.Static.Util.TiraSimbolo(value, ""); }
        }
        /// <summary>
        /// Informar o CNPJ ou o CPF do destinatário, preenchendo os zeros não significativos. Não informar o conteúdo da TAG se a operação for realizada com o exterior.
        /// </summary>
        private string _cpf;

        public string Cpf
        {
            get { return _cpf; }
            set { _cpf = HLP.GeraXml.Comum.Static.Util.TiraSimbolo(value, ""); }
        }
        /// <summary>
        /// Razão Social ou nome do Destinatario
        /// </summary>
        private string _xnome;

        public string Xnome
        {
            get { return _xnome; }
            set { _xnome = value; }
        }

        private string _tpLgr;

        public string tpLgr
        {
            get { return _tpLgr; }
            set { _tpLgr = BuscaTipoLogradouro(value); }
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
        /// Numero da Residência ou Estabelecimento
        /// </summary>
        private string _nro;

        public string Nro
        {
            get { return _nro; }
            set { _nro = value; }
        }
        /// <summary>
        /// Complemento
        /// </summary>
        private string _xcpl = "";

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
        /// 0-Fisica / 1-Juridica
        /// </summary>
        public int tpEmit { get; set; }

        /// <summary>
        /// Código do Município
        /// </summary>
        private string _cmun;

        public string Cmun
        {
            get { return _cmun; }
            set { _cmun = value; }
        }
        /// <summary>
        /// Nome do Município
        /// </summary>
        private string _xmun;

        public string Xmun
        {
            get { return _xmun; }
            set { _xmun = value; }
        }
        /// <summary>
        /// Nome do Uf
        /// </summary>
        private string _uf;

        public string Uf
        {
            get { return _uf; }
            set { _uf = value; }
        }
        /// <summary>
        /// CEP
        /// </summary>
        private string _cep;

        public string Cep
        {
            get { return _cep; }
            set { _cep = HLP.GeraXml.Comum.Static.Util.TiraSimbolo(value, ""); }
        }
        /// <summary>
        /// Código do Pais
        /// </summary>
        private string _cpais;

        public string Cpais
        {
            get { return _cpais; }
            set { _cpais = value; }
        }
        /// <summary>
        /// Nome do País
        /// </summary>
        private string _xpais;

        public string Xpais
        {
            get { return _xpais; }
            set { _xpais = value; }
        }
        /// <summary>
        /// Telefone do Destinatário
        /// </summary>
        private string _fone;

        public string Fone
        {
            get { return _fone; }
            set { _fone = value; }
        }
        /// <summary>
        /// Inscrição Estadual, caso pessoa fisica deixar tag em brando ex.  <IE/>
        /// </summary>
        private string _ie;

        public string Ie
        {
            get { return _ie; }
            set { _ie = HLP.GeraXml.Comum.Static.Util.TiraSimbolo(value, ""); }
        }
        /// <summary>
        /// Inscrição do SUFRAMA, caso pessoa fisica deixar  a tag em branco ex. <IE/>
        /// </summary>
        private string _isuf;

        public string Isuf
        {
            get { return _isuf; }
            set { _isuf = HLP.GeraXml.Comum.Static.Util.TiraSimbolo(value, ""); }
        }

        public string email { get; set; }

        public void Carrega(string seqNF)
        {
            try
            {
                DataTable dt = BuscaDest(seqNF);

                foreach (DataRow drDest in dt.Rows)
                {
                    if (drDest["st_prodrural"].ToString() == "S")
                    {
                        if (drDest["CNPJ"].ToString() != "")
                        {
                            this.Cnpj = Util.TiraSimbolo(drDest["CNPJ"].ToString(), "");
                        }
                        else
                        {
                            this.Cpf = Util.TiraSimbolo(drDest["CPF"].ToString(), "");
                        }
                    }
                    else
                    {
                        if (drDest["st_pessoaj"].ToString() == "S")
                        {
                            this.Cnpj = Util.TiraSimbolo(drDest["CNPJ"].ToString(), "");
                        }
                        else
                        {
                            this.Cpf = Util.TiraSimbolo(drDest["CPF"].ToString(), "");
                        }
                    }

                    if (drDest["st_pessoaj"].ToString() == "S")
                    {
                        this.tpEmit = 1;
                    }
                    else
                    {
                        this.tpEmit = 0;
                    }
                    if (Acesso.TP_AMB == 2)
                    {
                        this.Xnome = "NF-E EMITIDA EM AMBIENTE DE HOMOLOGACAO - SEM VALOR FISCAL";
                    }
                    else
                    {
                        if (drDest["xNome"].ToString() != "")
                        {
                            string sNome = Util.TiraSimbolo(drDest["xNome"].ToString().Trim(), "");
                            if (sNome.Length > 60)
                            {
                                sNome = sNome.Substring(0, 60);
                            }
                            this.Xnome = sNome;
                        }
                    }
                    if (drDest["tpLgr"].ToString() != "")
                    {
                        this.tpLgr = drDest["tpLgr"].ToString();
                    }

                    if (drDest["xlgr"].ToString() != "")
                    {
                        this.Xlgr = (String.IsNullOrEmpty(this.tpLgr) ? "" : this.tpLgr + " ") + Util.TiraSimbolo(drDest["xlgr"].ToString(), "");
                    }

                    if (drDest["xCpl"].ToString() != "") //OS_26347
                    {
                        this.Xcpl = Util.TiraSimbolo(drDest["xCpl"].ToString(), "");
                    }
                    if (drDest["email"].ToString() != "")
                    {
                        this.email = drDest["email"].ToString().Trim(); // NFe_2.0
                    }
                    if (drDest["nro"].ToString() != "")
                    {
                        this.Nro = drDest["nro"].ToString();
                    }
                    if (drDest["xBairro"].ToString() != "")
                    {
                        this.Xbairro = Util.TiraSimbolo(drDest["xBairro"].ToString(), "");
                    }
                    if (drDest["cMun"].ToString() != "")
                    {
                        this.Cmun = drDest["cMun"].ToString();
                    }
                    if (drDest["cMun"].ToString() != "")
                    {
                        this.Xmun = Util.TiraSimbolo(drDest["xMun"].ToString(), "");
                    }
                    if (drDest["uf"].ToString() != "")
                    {
                        this.Uf = drDest["uf"].ToString();
                    }
                    if (drDest["cep"].ToString() != "")
                    {
                        this.Cep = Util.TiraSimbolo(drDest["cep"].ToString(), "");
                    }

                    if (drDest["cPais"].ToString() != "")
                    {
                        this.Cpais = drDest["cPais"].ToString();
                    }
                    if (drDest["xPais"].ToString() != "")
                    {
                        this.Xpais = drDest["xPais"].ToString();
                    }
                    if (drDest["fone"].ToString() != "")
                    {
                        string sFone = Util.TiraSimbolo(drDest["fone"].ToString());
                        if (sFone.Trim().Length > 12)
                        {
                            throw new Exception("Telefone com formato inválido no Destinátário, tamanho maior que 12 caracteres!");
                        }
                        this.Fone = sFone;
                    }
                    if (drDest["IE"].ToString() != "")
                    {
                        this.Ie = drDest["IE"].ToString();
                    }
                    else
                    {
                        if (drDest["st_pessoaj"].ToString() != "S")
                        {
                            this.Ie = "ISENTO";
                        }
                    }
                    if (drDest["cd_suframa"].ToString() != "")
                    {
                        this.Isuf = Util.TiraSimbolo(drDest["cd_suframa"].ToString(), "");
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
