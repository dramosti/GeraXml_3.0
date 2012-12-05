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
    public class belDI : daoDI
    {
        /// <summary>
        /// 1-10 Número do Documento de Importação (DI/DSI/DA)
        /// </summary>
        public string _nDI;

        public string nDI
        {
            get { return _nDI; }
            set { _nDI = value.ToUpper(); }
        }

        /// <summary>
        /// Data de Registro da DI/DSI/DA / Formato “AAAA-MM-DD”
        /// </summary>
        public DateTime DDI { get; set; }

        /// <summary>
        /// 1-60 Local de desembaraço
        /// </summary>
        public string _xLocDesemb;

        public string xLocDesemb
        {
            get { return _xLocDesemb; }
            set { _xLocDesemb = value.ToUpper(); }
        }

        /// <summary>
        /// 2 Sigla da UF onde ocorreu o Desembaraço Aduaneiro
        /// </summary>
        private string _uFDesemb;

        public string UFDesemb
        {
            get { return _uFDesemb; }
            set { _uFDesemb = value.ToUpper(); }
        }
        /// <summary>
        /// Data do Desembaraço Aduaneiro / Formato “AAAA-MM-DD”
        /// </summary>
        public DateTime dDesemb { get; set; }
        /// <summary>
        /// 1-60 Código do exportador
        /// </summary>
        private string _cExportador;

        public string cExportador
        {
            get { return _cExportador; }
            set { _cExportador = value.ToUpper(); }
        }

        public List<beladi> adi = new List<beladi>();


        public List<belDI> Carrega(string snrLanc)
        {
            try
            {
                List<belDI> objListaRet = new List<belDI>();
                foreach (DataRow dr in BuscaDI(snrLanc).Rows)
                {
                    belDI objDI = new belDI();
                    objDI.nDI = dr["nDI"].ToString();
                    objDI.DDI = (dr["dDI"].ToString() != "" ? Convert.ToDateTime(dr["dDI"].ToString()) : daoUtil.GetDateServidor().Date);
                    objDI.xLocDesemb = dr["xLocDesemb"].ToString();
                    objDI.UFDesemb = dr["UFDesemb"].ToString();
                    objDI.dDesemb = (dr["dDesemb"].ToString() != "" ? Convert.ToDateTime(dr["dDesemb"].ToString()) : daoUtil.GetDateServidor().Date);
                    objDI.cExportador = dr["cExportador"].ToString();

                    foreach (DataRow dr2 in BuscaADI(dr["nr_lanc"].ToString()).Rows)
                    {
                        beladi objadi = new beladi();
                        objadi.cFabricante = dr2["cFabricante"].ToString();
                        objadi.nAdicao = Convert.ToInt32(dr2["nAdicao"].ToString());
                        objadi.nSeqAdic = Convert.ToInt32(dr2["nSeqAdic"].ToString().Replace("0", ""));
                        objadi.vDescDI = Convert.ToDecimal(dr2["vDescDI"].ToString().Replace(".", ","));
                        objDI.adi.Add(objadi);
                    }

                    objListaRet.Add(objDI);
                }
                return objListaRet;

            }
            catch (Exception)
            {
                throw;
            }

        }


    }
}
