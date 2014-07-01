using HLP.GeraXml.Comum.Static;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
namespace HLP.GeraXml.bel.MDFe.Acoes
{
    public class belCancelamentoMDFe
    {
        PesquisaManifestosModel objPesquisa;
        belEventoMDFe objEvento;
        string xJust;
        public belCancelamentoMDFe(PesquisaManifestosModel objPesquisa, string xJust)
        {
            this.xJust = xJust;
            this.objPesquisa = objPesquisa;
            XNamespace pf = "http://www.portalfiscal.inf.br/mdfe";
            XContainer envCTe = new XElement(pf + "evCancMDFe",
                 new XElement(pf + "descEvento", "Cancelamento"),
                 new XElement(pf + "nProt", objPesquisa.protocolo),
                 new XElement(pf + "xJust", xJust.Trim()));


            XmlDocument xmlCanc = new XmlDocument();
            xmlCanc.LoadXml(envCTe.ToString());

            objEvento = new belEventoMDFe(xmlCanc.DocumentElement, objPesquisa, "110111");

           // ExecuteCancelamento();
        }

        public string ExecuteCancelamento()
        {            
            bool bRet = objEvento.ExecuteEvento();

            if (bRet)
            {
                dao.CTe.MDFe.daoManifesto.GravarReciboCancelamento(objPesquisa.sequencia, objEvento.retorno.infEvento.nProt, xJust);
                this.MoveArquivoParaPastaCancelada();
            }
            return objEvento.sMessage;
        }

        private void MoveArquivoParaPastaCancelada()
        {

            DirectoryInfo dinfo = new DirectoryInfo(Pastas.ENVIADOS + "\\" + objPesquisa.chaveMDFe.Substring(2, 4));
            FileInfo f;

            try
            {
                FileInfo[] finfo = dinfo.GetFiles();

                if (finfo.Where(c => c.Name.Contains(objPesquisa.chaveMDFe)).Count() > 0)
                {
                    f = finfo.FirstOrDefault(c => c.Name.Contains(objPesquisa.chaveMDFe));
                    DirectoryInfo dinfoPasta = new DirectoryInfo(Pastas.CANCELADOS + "\\" + objPesquisa.dt_manife.ToDateTime().Date.ToString("yyMM"));
                    if (!dinfoPasta.Exists) { dinfoPasta.Create(); }
                    File.Move(f.FullName, dinfoPasta.FullName + "\\" + f.Name.Replace("mdfe", "can") + ".xml");
                    File.Delete(f.FullName);
                }
            }
            catch (Exception x)
            {
                throw new Exception("Erro ao tentar mover o arquivo - " + x.Message);
            }
        }
    }
}
