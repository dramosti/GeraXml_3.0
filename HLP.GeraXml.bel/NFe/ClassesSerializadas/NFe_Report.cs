using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HLP.GeraXml.bel.NFe.ClassesSerializadas
{
    /// <summary>
    /// Classe principal
    /// </summary>
    [Serializable]
    public class NFe_Report
    {
        public List<HLP.GeraXml.bel.NFe.ClassesSerializadas.NFe_HLP> Notas = new List<HLP.GeraXml.bel.NFe.ClassesSerializadas.NFe_HLP>();
    }
    /// <summary>
    /// Notas
    /// </summary>
    [Serializable]
    public class NFe_HLP
    {
        private string ConfigFone(string sValor)
        {
            string sFoneReturn = "";
            if (!string.IsNullOrEmpty(sValor))
            {
                if (sValor.Length == 11)
                {
                    sFoneReturn = string.Format("({0}) {1}-{2}", sValor.Substring(0, 3), sValor.Substring(3, 4), sValor.Substring(7, 4));
                }
                else if (sValor.Length == 10)
                {
                    sFoneReturn = string.Format("({0}) {1}-{2}", sValor.Substring(0, 2), sValor.Substring(2, 4), sValor.Substring(6, 4));
                }
                else
                {
                    sFoneReturn = sValor;
                }
            }
            return sFoneReturn;

        }

        //Regra de negócio
        public string tipoPDF { get; set; }
        public string PathPDF { get; set; }

        public string Id { get; set; }
        public string infprot_nprot { get; set; }
        public string natOP { get; set; }
        public string tpEmis { get; set; }
        public string dadosNFe { get; set; }
        public string xCANC { get; set; }

        #region ide
        private string _ide_nNF;

        public string ide_nNF
        {
            get { return _ide_nNF; }
            //right(("000000" + totext({ide.nNF})),6)
            set { _ide_nNF = value.PadLeft(6, '0'); }
        }
        private string _ide_serie;

        public string ide_serie
        {
            get { return _ide_serie; }
            //right(("000" + totext({ide.serie})),3)
            set { _ide_serie = value.PadLeft(3, '0'); }
        }
        public string ide_tpNF { get; set; }
        public string ide_dEmi { get; set; }
        public string ide_dSaiEnt { get; set; }
        #endregion

        #region Emit
        public string emit_xNome { get; set; }
        public string emit_xFant { get; set; }
        public string emit_CPF_CNPJ { get; set; }
        public string emit_IE { get; set; }
        public string emit_IEST { get; set; }

        public string enderEmit_xLgr { get; set; }
        public string enderEmit_nro { get; set; }
        public string enderEmit_xCpl { get; set; }
        public string enderEmit_xBairro { get; set; }
        public string enderEmit_cMun { get; set; }
        public string enderEmit_xMun { get; set; }
        public string enderEmit_UF { get; set; }
        public string enderEmit_CEP { get; set; }
        private string _enderEmit_fone;

        public string enderEmit_fone
        {
            get { return _enderEmit_fone; }
            set { _enderEmit_fone = this.ConfigFone(value); }
        }
        #endregion

        #region dest
        public string dest_xNome { get; set; }
        public string dest_CPF_CNPJ { get; set; }
        public string dest_IE { get; set; }
        private string _enderDest_xLgr = "";

        public string enderDest_xLgr
        {
            get { return _enderDest_xLgr; }
            set { _enderDest_xLgr = value; }
        }
        private string _enderDest_nro = "";

        public string enderDest_nro
        {
            get { return _enderDest_nro; }
            set { _enderDest_nro = value; }
        }
        private string _enderDest_xCpl;

        public string enderDest_xCpl
        {
            get { return _enderDest_xCpl; }
            set { _enderDest_xCpl = value; }
        }
        private string _enderDest_xBairro = "";

        public string enderDest_xBairro
        {
            get { return _enderDest_xBairro; }
            set { _enderDest_xBairro = value; }
        }
        private string _enderDest_cMun = "";

        public string enderDest_cMun
        {
            get { return _enderDest_cMun; }
            set { _enderDest_cMun = value; }
        }
        private string _enderDest_xMun = "";

        public string enderDest_xMun
        {
            get { return _enderDest_xMun; }
            set { _enderDest_xMun = value; }
        }
        private string _enderDest_UF = "";

        public string enderDest_UF
        {
            get { return _enderDest_UF; }
            set { _enderDest_UF = value; }
        }
        public string enderDest_CEP { get; set; }
        private string _enderDest_fone;

        public string enderDest_fone
        {
            get { return _enderDest_fone; }
            set { _enderDest_fone = this.ConfigFone(value); }
        }
        #endregion

        #region Transpor
        public string transp_xNome { get; set; }
        private string _transp_modFrete;
        public string transp_modFrete
        {
            get { return _transp_modFrete; }
            set
            {
                if (value.Equals("0"))
                    _transp_modFrete = "0-EMITENTE";
                else if (value.Equals("1"))
                    _transp_modFrete = "1-DESTINATÁRIO";
                else if (value.Equals("2"))
                    _transp_modFrete = "2-TERCEIROS";
                else
                    _transp_modFrete = "9-SEM FRETE";
            }
        }
        public string transp_RNTCVeic { get; set; }
        public string transp_placaVeic { get; set; }
        public string transp_UFVeic { get; set; }
        public string transp_CFP_CNPJ { get; set; }
        public string transp_xEnder { get; set; }
        public string transp_xMun { get; set; }
        public string transp_UF { get; set; }
        public string transp_qVol { get; set; }
        public string transp_esp { get; set; }
        public string transp_marca { get; set; }
        public string transp_nVol { get; set; }
        public string transp_PesoB { get; set; }
        public string transp_PesoL { get; set; }
        public string transp_IE { get; set; }



        #endregion

        #region TotalICMS

        private string _ICMSTot_vBC = "0,00";

        public string ICMSTot_vBC
        {
            get { return _ICMSTot_vBC; }
            set { _ICMSTot_vBC = value; }
        }
        private string _ICMSTot_vICMS = "0,00";

        public string ICMSTot_vICMS
        {
            get { return _ICMSTot_vICMS; }
            set { _ICMSTot_vICMS = value; }
        }
        private string _ICMSTot_vBCST = "0,00";

        public string ICMSTot_vBCST
        {
            get { return _ICMSTot_vBCST; }
            set { _ICMSTot_vBCST = value; }
        }
        private string _ICMSTot_vST = "0,00";

        public string ICMSTot_vST
        {
            get { return _ICMSTot_vST; }
            set { _ICMSTot_vST = value; }
        }
        private string _ICMSTot_vProd = "0,00";

        public string ICMSTot_vProd
        {
            get { return _ICMSTot_vProd; }
            set { _ICMSTot_vProd = value; }
        }
        private string _ICMSTot_vFrete = "0,00";

        public string ICMSTot_vFrete
        {
            get { return _ICMSTot_vFrete; }
            set { _ICMSTot_vFrete = value; }
        }
        private string _ICMSTot_vSeg = "0,00";

        public string ICMSTot_vSeg
        {
            get { return _ICMSTot_vSeg; }
            set { _ICMSTot_vSeg = value; }
        }
        private string _ICMSTot_vDesc = "0,00";

        public string ICMSTot_vDesc
        {
            get { return _ICMSTot_vDesc; }
            set { _ICMSTot_vDesc = value; }
        }
        private string _ICMSTot_vII = "0,00";

        public string ICMSTot_vII
        {
            get { return _ICMSTot_vII; }
            set { _ICMSTot_vII = value; }
        }
        private string _ICMSTot_vIPI = "0,00";

        public string ICMSTot_vIPI
        {
            get { return _ICMSTot_vIPI; }
            set { _ICMSTot_vIPI = value; }
        }
        private string _ICMSTot_vPIS = "0,00";

        public string ICMSTot_vPIS
        {
            get { return _ICMSTot_vPIS; }
            set { _ICMSTot_vPIS = value; }
        }
        private string _ICMSTot_vCOFINS = "0,00";

        public string ICMSTot_vCOFINS
        {
            get { return _ICMSTot_vCOFINS; }
            set { _ICMSTot_vCOFINS = value; }
        }
        private string _ICMSTot_vOutro = "0,00";

        public string ICMSTot_vOutro
        {
            get { return _ICMSTot_vOutro; }
            set { _ICMSTot_vOutro = value; }
        }
        private string _ICMSTot_vNF = "0,00";

        public string ICMSTot_vNF
        {
            get { return _ICMSTot_vNF; }
            set { _ICMSTot_vNF = value; }
        }
        private string _ICMSTot_vTotTrib = "0,00";

        public string ICMSTot_vTotTrib
        {
            get { return _ICMSTot_vTotTrib; }
            set { _ICMSTot_vTotTrib = value; }
        }
        #endregion

        /// <summary>
        /// infAdic.infCpl
        /// </summary>      
        public string xObs { get; set; }

        private string _ISSQNtot_vServ = "0,00";

        public string ISSQNtot_vServ
        {
            get { return _ISSQNtot_vServ; }
            set { _ISSQNtot_vServ = value; }
        }
        private string _ISSQNtot_vBC = "0,00";

        public string ISSQNtot_vBC
        {
            get { return _ISSQNtot_vBC; }
            set { _ISSQNtot_vBC = value; }
        }
        private string _ISSQNtot_vISS = "0,00";

        public string ISSQNtot_vISS
        {
            get { return _ISSQNtot_vISS; }
            set { _ISSQNtot_vISS = value; }
        }

        public List<Produto> Produtos { get; set; }

        private string _xDuplicatas = "";

        public string xDuplicatas
        {
            get { return _xDuplicatas; }
            set { _xDuplicatas = value; }
        }
        private string _xDupli = "";

        public string xDupli
        {
            get { return _xDupli; }
            set { _xDupli = value; }
        }

    }

    /// <summary>
    /// Protutos da Nota e suas informações
    /// </summary>
    public class Produto
    {
        public int count { get; set; }
        public string ide_nNF { get; set; }
        public string cProd { get; set; }
        public string xProd { get; set; }
        public string ncm { get; set; }
        public string cfop { get; set; }
        public string uCom { get; set; }
        private string _qCom = "0";

        public string qCom
        {
            get { return _qCom; }
            set { _qCom = value; }
        }
        private string _vUnCom = "0,00";

        public string vUnCom
        {
            get { return _vUnCom; }
            set { _vUnCom = value; }
        }
        private string _vProd = "0,00";

        public string vProd
        {
            get { return _vProd; }
            set { _vProd = value; }
        }

        private string _vBC = "0,00";

        public string vBC
        {
            get { return _vBC; }
            set { _vBC = value; }
        }
        private string _vICMS = "0,00";

        public string vICMS
        {
            get { return _vICMS; }
            set { _vICMS = value; }
        }
        private string _pICMS = "0";

        public string pICMS
        {
            get { return _pICMS; }
            set { _pICMS = value != "" ? Convert.ToInt32(Convert.ToDecimal(value)).ToString() : "0"; }
        }


        private string _vIPI = "0,00";

        public string vIPI
        {
            get { return _vIPI; }
            set { _vIPI = value; }
        }
        private string _pIPI = "0";

        public string pIPI
        {
            get { return _pIPI; }
            set { _pIPI = value != "" ? Convert.ToInt32(Convert.ToDecimal(value)).ToString() : "0"; }
        }

        public string cst { get; set; }
        public string xObs { get; set; }


        private string _cEAN = string.Empty;

        public string cEAN
        {
            get { return _cEAN; }
            set { _cEAN = value; }
        }

    }





}
