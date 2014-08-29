using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HLP.GeraXml.dao.NFe.Estrutura;
using System.Data;
using HLP.GeraXml.Comum.Static;
using HLP.GeraXml.dao;

namespace HLP.GeraXml.bel.NFe.Estrutura
{
    public class belIde : daoIde
    {
        /// <summary>
        /// Código da UF do emitente do Documento Fiscal
        /// </summary>
        private string _cuf;

        public string Cuf
        {
            get { return _cuf; }
            set
            {
                belUF objuf = new belUF();
                if (objuf.RetornaUF(value) == true)
                {
                    _cuf = value;
                }

            }
        }
        /// <summary>
        /// Código Numérico que compõe a Chave de Acesso
        /// </summary>
        private string _cnf;

        /// <summary>
        /// Numero Sequencial - NFSEQ
        /// </summary>
        public string Cnf
        {
            get { return _cnf; }
            set
            {
                bool ctrl = true;
                for (int i = 0; i < value.Length; i++)
                {
                    if ((value[i] != '0') &&
                        (value[i] != '1') &&
                        (value[i] != '2') &&
                        (value[i] != '3') &&
                        (value[i] != '4') &&
                        (value[i] != '5') &&
                        (value[i] != '6') &&
                        (value[i] != '7') &&
                        (value[i] != '8') &&
                        (value[i] != '9'))
                    {
                        ctrl = false;
                        break;
                    }

                }
                if (ctrl == true)
                    _cnf = value;
                else
                    throw new Exception("Cnf contém Letras ou Caracteres Especiais");

            }
        }
        /// <summary>
        /// Descrição da Natureza da Operação
        /// </summary>
        private string _natop;

        public string Natop
        {
            get { return _natop; }
            set { _natop = HLP.GeraXml.Comum.Static.Util.TiraSimbolo(value, ""); }
        }
        /// <summary>
        /// Indicador da forma de pagamento
        /// </summary>
        private string _indpag;

        public string Indpag
        {
            get { return _indpag; }
            set
            {
                if ((value == "1") || (value == "0") || (value == "2"))
                    _indpag = value;
                else
                    throw new Exception("Valor Invalido. Valor esperado 0, 1 ou 2");

            }
        }
        /// <summary>
        /// Código do Modelo do Documento Fiscal
        /// </summary>
        private string _mod;

        public string Mod
        {
            get { return _mod; }
            set { _mod = value; }
        }
        /// <summary>
        /// Série do Documento Fiscal
        /// </summary>
        private string _serie;

        public string Serie
        {
            get { return _serie; }
            set
            {
                bool ctrl = true;
                for (int i = 0; i < value.Length; i++)
                {
                    if ((value[i] != '0') &&
                        (value[i] != '1') &&
                        (value[i] != '2') &&
                        (value[i] != '3') &&
                        (value[i] != '4') &&
                        (value[i] != '5') &&
                        (value[i] != '6') &&
                        (value[i] != '7') &&
                        (value[i] != '8') &&
                        (value[i] != '9'))
                    {
                        ctrl = false;
                        break;
                    }

                }
                if (ctrl == true)
                    _serie = value;
                else
                    throw new Exception("Serie contém Letras ou Caracteres Especiais");

            }
        }
        /// <summary>
        /// Número do Documento Fiscal
        /// </summary>
        private string _nnf;

        public string Nnf
        {
            get { return _nnf; }
            set
            {
                bool ctrl = true;
                for (int i = 0; i < value.Length; i++)
                {
                    if ((value[i] != '0') &&
                        (value[i] != '1') &&
                        (value[i] != '2') &&
                        (value[i] != '3') &&
                        (value[i] != '4') &&
                        (value[i] != '5') &&
                        (value[i] != '6') &&
                        (value[i] != '7') &&
                        (value[i] != '8') &&
                        (value[i] != '9'))
                    {
                        ctrl = false;
                        break;
                    }

                }
                if (ctrl == true)
                    _nnf = value;
                else
                    throw new Exception("Nnf contém Letras ou Caracteres Especiais");

            }
        }
        /// <summary>
        /// Data de emissão do Documento Fiscal - Formato "AAAA-MM-DD"
        /// </summary>
        private DateTime _demi;

        public DateTime Demi
        {
            get { return _demi; }
            set { _demi = value; }
        }
        /// <summary>
        /// Data de Sída ou da Entrada da Mecadoria/Produto
        /// </summary>
        private DateTime _dsaient;

        public DateTime HSaiEnt { get; set; }

        public DateTime Dsaient
        {
            get { return _dsaient; }
            set { _dsaient = value; }
        }

        public DateTime DSaiEnt { get; set; }

        /// <summary>
        /// Tipo do Documento  Fiscal,  0- entrada, 1- saída
        /// </summary>
        private string _tpnf;

        public string Tpnf
        {
            get { return _tpnf; }
            set { _tpnf = value; }
        }
        /// <summary>
        /// Código do Município de Ocorrência do Fato Gerador
        /// </summary>
        private string _cmunfg;

        public string Cmunfg
        {
            get { return _cmunfg; }
            set { _cmunfg = HLP.GeraXml.Comum.Static.Util.TiraSimbolo(value, ""); }
        }
        /// <summary>
        /// Formato de impressão do DANFE, 1-Retrato, 2-Paisagem
        /// </summary>
        private string _tpimp;

        public string Tpimp
        {
            get { return _tpimp; }
            set
            {
                if ((value == "1") || (value == "2"))
                    _tpimp = value;
                else
                    throw new Exception("Numero " + value + "do Tpimp Inválido. Valores aceito 1 ou 2");
            }

        }
        /// <summary>
        /// Forma de Emissão da NF-e, 1-Normal-Emissão normal; 2-Contingência  FS - emissão em contingência com impressão do DNFE  em Formulário de Sgurança; 3-Continência SCAN - emissão em contingência no Sistema de Contingência do Ambient Nacional - SCAN; 4-Contingência DPEC - emissão em contingência com envioda Declaração Prévia de Emissão em Contingência - DPEC; 5-Contingencia FS-DA - emissão em contingÇencia  com impressão do DANFE em Formulário de Segurança para Impressão de Documento Auxiliar de Documento Fiscal Eletrônico
        /// </summary>
        private string _tpemis;

        public string Tpemis
        {
            get { return _tpemis; }
            set
            {
                if ((value == "1") || (value == "2") || (value == "3") || (value == "4") || (value == "5") || (value == "6") || (value == "7"))
                    _tpemis = value;
                else
                    throw new Exception("Numero " + value + "do Tpemis Inválido. Valores aceito 1, 2, 3, 4, 5,6 e 7");
            }
        }
        /// <summary>
        /// Dígito Verificador da Chave de Acesso da NF-e
        /// </summary>
        private string _cdv;

        public string Cdv
        {
            get { return _cdv; }
            set { _cdv = value; }
        }
        /// <summary>
        /// Identificador do Ambiente; 1-Produção; 2- Homologaço
        /// </summary>
        private string _tpamb;

        public string Tpamb
        {
            get { return _tpamb; }
            set
            {
                if ((value == "1") || (value == "2"))
                    _tpamb = value;
                else
                    throw new Exception("Numero " + value + "do Tpamb Inválido. Valores aceito 1 ou 2");
            }

        }
        /// <summary>
        /// Finalidade de emissão da NF-E; 1-NF-e normal; 2-Complementar; 3 NF-e de ajuste
        /// </summary>
        private string _finnfe;

        public string Finnfe
        {
            get { return _finnfe; }
            set
            {
                if ((value == "1") || (value == "2") || (value == "3"))
                    _finnfe = value;
                else
                    throw new Exception("Numero " + value + "do Finnfe Inválido. Valores aceito 1, 2 ou 3");
            }

        }
        /// <summary>
        /// Processo de emissão da NF-e
        /// </summary>
        private string _procemi;

        public string Procemi
        {
            get { return _procemi; }
            set
            {
                if ((value == "1") || (value == "2") || (value == "3") || (value == "0"))
                    _procemi = value;
                else
                    throw new Exception("Numero " + value + "do Procemi Inválido. Valores aceito 0, 1, 2 ou 3");
            }
        }
        /// <summary>
        /// Versão do Processo de emissão da NF-e
        /// </summary>
        private string _verproc;

        public string Verproc
        {
            get { return _verproc; }
            set { _verproc = value; }
        }

        public DateTime DhCont { get; set; }

        public string XJust { get; set; }

        public bool bReferenciaNF { get; set; }

        private List<belNFref> _belNFref = new List<belNFref>();
        /// <summary>
        /// Lista de NFreferenciadas
        /// </summary>
        public List<belNFref> belNFref
        {
            get
            {
                return _belNFref;
            }
            set
            {
                _belNFref = value;
            }
        }

        public belIde Carrega(string seqNF, string sDigVerif)
        {
            DataTable dt = BuscaIde(seqNF);


            foreach (DataRow drIde in dt.Rows)
            {
                this.Cuf = drIde["cUF"].ToString();
                Int32 icNF = Convert.ToInt32(drIde["cNF"].ToString());
                this.Cnf = icNF.ToString().PadLeft(8, '0'); // NFe_2.0
                string snatop = drIde["natop"].ToString();
                if (snatop.Length > 60)
                {

                    snatop = snatop.Substring(0, 59);
                }
                this.Natop = Util.TiraSimbolo(snatop, "");
                this.Indpag = drIde["indPag"].ToString();
                this.Mod = drIde["mod"].ToString();
                this.Serie = (Acesso.TP_EMIS != 3 ? drIde["serie"].ToString().Replace("U", "1") : Acesso.SERIE_SCAN);
                Int32 inNF = Convert.ToInt32(drIde["nNF"].ToString());
                this.Nnf = inNF.ToString().Trim();
                this.Demi = System.DateTime.Parse(drIde["dEmi"].ToString());
                if (drIde["dSaiEnt"].ToString() != "")
                {
                    this.Dsaient = System.DateTime.Parse(drIde["dSaiEnt"].ToString());
                    this.HSaiEnt = System.DateTime.Parse(drIde["dSaiEnt"].ToString());
                }
                else
                {
                    this.Dsaient = daoUtil.GetDateServidor();
                    this.HSaiEnt = this.Dsaient;
                }
                this.Tpnf = drIde["tpNF"].ToString();
                this.Cmunfg = Util.TiraSimbolo(drIde["cMunFG"].ToString(), "");
                this.Tpimp = Acesso.TIPO_IMPRESSAO.ToString().Equals("Retrato") ? "1" : "2";
                this.Tpemis = Acesso.TP_EMIS.ToString();
                this.Cdv = sDigVerif;
                this.Tpamb = Acesso.TP_AMB.ToString();
                this.Finnfe = drIde["finNFe"].ToString();
                this.Procemi = drIde["procEmi"].ToString();
                this.Verproc = drIde["verProc"].ToString();
                this.bReferenciaNF = (drIde["st_ref_outra_nf"].ToString().Equals("N") ? false : true);
                break;
            }
            return this;
        }

    }
}
