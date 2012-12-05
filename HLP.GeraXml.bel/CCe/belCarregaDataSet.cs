using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HLP.GeraXml.Comum.DataSet;
using HLP.GeraXml.Comum.Static;
using HLP.GeraXml.dao.CCe;
using System.IO;
using HLP.GeraXml.dao;

namespace HLP.GeraXml.bel.CCe
{
    public class belCarregaDataSet : daoCarregaDataSet
    {
        public dsCCe objDS = new dsCCe();
        public List<dsCCe> objListaDS = new List<dsCCe>();
        private List<belPesquisaCCe> objListCCe;

        public belCarregaDataSet(List<belPesquisaCCe> _objListCCe)
        {
            this.objListCCe = _objListCCe;
            CarregaInformacoes();
        }

        private void CarregaInformacoes()
        {
            dsCCe.CCeRow drCCe;
            Byte[] bimagem = Util.CarregaLogoEmpresa();
            try
            {
                for (int i = 0; i < objListCCe.Count; i++)
                {
                    drCCe = objDS.CCe.NewCCeRow();
                    drCCe = CarregaLinha(drCCe, bimagem, i);
                    objDS.CCe.AddCCeRow(drCCe);

                    dsCCe objDSlista = new dsCCe();
                    objDSlista.CCe.AddCCeRow(CarregaLinha(objDSlista.CCe.NewCCeRow(), bimagem, 0));
                    objListaDS.Add(objDSlista);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private dsCCe.CCeRow CarregaLinha(dsCCe.CCeRow drCCe, Byte[] bimagem, int i)
        {
            drCCe.ID = i;
            drCCe.DADOS_EMPRESA = daoUtil.GetEnderecoEmpresa();// BuscaDadosEmpresa();
            drCCe.DADOS_CLIENTE = BuscaDadosCliente(objListCCe[i].CD_CLIFOR);
            drCCe.CHAVE = objListCCe[i].CHNFE;
            drCCe.NFE = objListCCe[i].CD_NOTAFIS;
            drCCe.DT_EMISSAO = objListCCe[i].DT_EMI.ToString("dd/MM/yyyy");
            belGeraCCe objdaoGeraCCe = new belGeraCCe();
            drCCe.RETIFICACAO = objdaoGeraCCe.BuscaCorrecoesPulandoLinha(objListCCe[i].CD_NRLANC);
            drCCe.LOGO = bimagem;
            Byte[] bCodBarras = SalvaCodBarras(drCCe.CHAVE);
            drCCe.BARRAS = bCodBarras;
            return drCCe;
        }

        private Byte[] SalvaCodBarras(string sValor)
        {
            DirectoryInfo dBarras = new DirectoryInfo(Pastas.CBARRAS);
            if (!dBarras.Exists) { dBarras.Create(); }

            BarcodeLib.Barcode barcod = new BarcodeLib.Barcode(sValor, BarcodeLib.TYPE.CODE128C);
            barcod.Encode(BarcodeLib.TYPE.CODE128, sValor, 300, 150);

            string sCaminho = dBarras.ToString() + sValor + ".JPG";

            barcod.SaveImage(@sCaminho, BarcodeLib.SaveTypes.JPG);

            return Util.CarregaImagem(sCaminho);
        }


    }
}
