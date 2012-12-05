using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HLP.GeraXml.bel.CTe.infCte.ide
{
    public class belide
    {
        /// <summary>
        /// Campo apenas para parametro - Não incluido no Xml
        /// </summary>
        public List<string> Veiculo = new List<string>();

        /// <summary>


        /// <summary>
        /// Campo apenas para parametro - Não incluido no Xml
        /// </summary>
        public string Motorista = "";

        private string _cUF = "";
        /// <summary>
        /// 1:1 N TAMANHO 2
        /// </summary>
        public string cUF
        {
            get { return _cUF; }
            set { _cUF = value; }
        }

        private string _cCT = "";
        /// <summary>
        /// 1:1 N TAMANHO 9
        /// </summary>
        public string cCT
        {
            get { return _cCT.PadLeft(8, '0'); }
            set { _cCT = value; }
        }

        private string _CFOP = "";
        /// <summary>
        /// 1:1 N TAMANHO 4
        /// </summary>
        public string CFOP
        {
            get { return _CFOP; }
            set { _CFOP = value; }
        }

        private string _natOp = "";
        /// <summary>
        /// 1:1 C TAMANHO 1-60
        /// </summary>
        public string natOp
        {
            get { return _natOp; }
            set { _natOp = value; }
        }

        /// <summary>
        /// 1:1 N TAMANHO 1  0 - Pago; 1 - A pagar; 2 - outros
        /// </summary>
        public int forPag { get; set; }

        private string _mod = "";
        /// <summary>
        /// 1:1 C TAMANHO 2
        /// </summary>
        public string mod
        {
            get { return _mod; }
            set { _mod = value; }
        }

        private string _serie = "";
        /// <summary>
        /// 1:1 N TAMANHO 1-3
        /// </summary>
        public string serie
        {
            get { return _serie; }
            set { _serie = value; }
        }

        private string _nCT = "";
        /// <summary>
        /// 1:1 N TAMANHO 1-9
        /// </summary>
        public string nCT
        {
            get { return _nCT; }
            set { _nCT = value.PadLeft(6, '0'); }
        }

        private string _dhEmi = "";
        /// <summary>
        /// 1:1 C TAMANHO 19
        /// </summary>
        public string dhEmi
        {
            get { return _dhEmi; }
            set { _dhEmi = value; }
        }

        private string _tpImp = "";
        /// <summary>
        /// 1:1 N TAMANHO 1 
        /// </summary>
        public string tpImp
        {
            get { return _tpImp; }
            set { _tpImp = value; }
        }

        private string _tpEmis = "";
        /// <summary>
        /// 1:1 N TAMANHO 1 
        /// </summary>
        public string tpEmis
        {
            get { return _tpEmis; }
            set { _tpEmis = value; }
        }

        private string _cDV = "";
        /// <summary>
        /// 1:1 N TAMANHO 1 
        /// </summary>
        public string cDV
        {
            get { return _cDV; }
            set { _cDV = value; }
        }

        private string _tpAmb = "";
        /// <summary>
        /// 1:1 N TAMANHO 1-9   1 - Produção 2 - Homologação
        /// </summary>
        public string tpAmb
        {
            get { return _tpAmb; }
            set { _tpAmb = value; }
        }

        /// <summary>
        /// 1:1 N TAMANHO 1   0 - CT-e Normal,1 - CT-e de Complemento de Valores,2 - CT-e de Anulação de Valores,3 - CT-e Substituto
        /// </summary>
        public int tpCTe { get; set; }

        /// <summary>
        /// 1:1 N TAMANHO 1 
        /// 0 - emissão de CT-e com aplicativo do
        ///contribuinte;
        ///1 - emissão de CT-e avulsa pelo Fisco;
        ///2 - emissão de CT-e avulsa, pelo
        ///contribuinte com seu certificado digital,
        ///através do site do Fisco;
        ///3- emissão CT-e pelo contribuinte com
        ///aplicativo fornecido pelo Fisco.
        /// </summary>
        public int procEmi { get; set; }

        private string _verProc = "";
        /// <summary>
        /// 1:1 C TAMANHO 1-20    
        /// </summary>
        public string verProc
        {
            get { return _verProc; }
            set { _verProc = value; }
        }

        /// <summary>
        /// 0:1 N TAMANHO 1-20    
        /// </summary>
        public int refCTE { get; set; }

        private string _cMunEnv = "";
        /// <summary>
        /// 1:1 N TAMANHO 7
        /// </summary>
        public string cMunEnv
        {
            get { return _cMunEnv; }
            set { _cMunEnv = value; }
        }

        private string _xMunEnv = "";
        /// <summary>
        /// 1:1 C TAMANHO 1-60
        /// </summary>
        public string xMunEnv
        {
            get { return _xMunEnv; }
            set { _xMunEnv = value; }
        }

        private string _UFEnv = "";
        /// <summary>
        /// 1:1 C TAMANHO 2
        /// </summary>
        public string UFEnv
        {
            get { return _UFEnv; }
            set { _UFEnv = value; }
        }

        private string _modal = "";
        /// <summary>
        /// 1:1 N TAMANHO 2
        /// </summary>
        public string modal
        {
            get { return _modal; }
            set { _modal = value; }
        }

        /// <summary>
        /// 1:1 N TAMANHO 1 
        /// 0 - Normal;
        ///1 - Subcontratação;
        ///2 - Redespacho;
        ///3 - Redespacho Intermediário
        /// </summary>
        public int tpServ { get; set; }

        private string _cMunIni = "";
        /// <summary>
        /// 1:1 N TAMANHO 7
        /// </summary>
        public string cMunIni
        {
            get { return _cMunIni; }
            set { _cMunIni = value; }
        }

        private string _xMunIni = "";
        /// <summary>
        /// 1:1 C TAMANHO 1-60
        /// </summary>
        public string xMunIni
        {
            get { return _xMunIni; }
            set { _xMunIni = value; }
        }

        private string _UFIni = "";
        /// <summary>
        /// 1:1 C TAMANHO 2
        /// </summary>
        public string UFIni
        {
            get { return _UFIni; }
            set { _UFIni = value; }
        }

        private string _cMunFim = "";
        /// <summary>
        /// 1:1 N TAMANHO 7
        /// </summary>
        public string cMunFim
        {
            get { return _cMunFim; }
            set { _cMunFim = value; }
        }

        private string _xMunFim = "";
        /// <summary>
        /// 1:1 C TAMANHO 1-60
        /// </summary>
        public string xMunFim
        {
            get { return _xMunFim; }
            set { _xMunFim = value; }
        }

        private string _UFFim = "";
        /// <summary>
        /// 1:1 C TAMANHO 2
        /// </summary>
        public string UFFim
        {
            get { return _UFFim; }
            set { _UFFim = value; }
        }

        /// <summary>
        /// 1:1 N TAMANHO 1
        /// 0 - sim;
        ///1 - não
        /// </summary>
        public int retira { get; set; }

        private string _xDetRetira = "";
        /// <summary>
        /// 0:1 C TAMANHO 1-160
        /// </summary>
        public string xDetRetira
        {
            get { return _xDetRetira; }
            set { _xDetRetira = value; }
        }


        /// <summary>
        /// 1:1 
        /// </summary>
        public beltoma03 toma03 { get; set; }


        /// <summary>
        /// 1:1 
        /// </summary>
        public beltoma04 toma04 { get; set; }










    }
}
