﻿using HLP.GeraXml.dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace HLP.GeraXml.bel.MDFe.Acoes
{

    public class belEncerramentoMDFe
    {
        PesquisaManifestosModel objPesquisa;
        public belEventoMDFe objEvento;
        public belEncerramentoMDFe(PesquisaManifestosModel objPesquisa, string cUF, string cMun)
        {
            this.objPesquisa = objPesquisa;
            XNamespace pf = "http://www.portalfiscal.inf.br/mdfe";
            XContainer envCTe = new XElement(pf + "evEncMDFe",
                 new XElement(pf + "descEvento", "Encerramento"),
                 new XElement(pf + "nProt", objPesquisa.protocolo),
                 new XElement(pf + "dtEnc", daoUtil.GetDateServidor().ToString("yyyy-MM-ddTHH:mm:ss")),
                 new XElement(pf + "cUF", cUF),
                 new XElement(pf + "cMun", cMun.Trim()));
            XmlDocument xmlCanc = new XmlDocument();
            xmlCanc.LoadXml(envCTe.ToString());

            objEvento = new belEventoMDFe(xmlCanc.DocumentElement, objPesquisa, "110112");

            Encerramento();
        }
        public string Encerramento()
        {
            bool bRet = objEvento.ExecuteEvento();

            if (bRet)
            {
                dao.CTe.MDFe.daoManifesto.AlteraStatusMDFe(objPesquisa.sequencia, "E");
            }
            return objEvento.sMessage;
        }
    }
}
