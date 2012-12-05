using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HLP.GeraXml.Comum.DataSet;
using System.Xml;
using HLP.GeraXml.Comum.Static;
using ComponentFactory.Krypton.Toolkit;
using System.Windows.Forms;

namespace HLP.GeraXml.bel.NFe
{
    public class belPopulaDataSetNfe
    {
        public void PopulaDataSetXML(dsDanfe dsdanfe, string caminho, string codigo)
        {
            XmlDocument xml = new XmlDocument();
            xml.Load(@caminho);


            int ihoraImpDanfe = (Acesso.VISUALIZA_HORA_DANFE == "True" ? 1 : 0);
            int idataImpDanfe = (Acesso.VISUALIZA_DATA_DANFE == "True" ? 1 : 0);

            PopulaDs populads = new PopulaDs();

            populads.populaTagInfNFe(dsdanfe, xml, codigo, ihoraImpDanfe, idataImpDanfe);
            populads.populaTagIDE(dsdanfe, xml, codigo);
            populads.populaTagEmit(dsdanfe, xml, codigo);
            populads.populaTagDest(dsdanfe, xml, codigo);
            populads.populaTagdet(dsdanfe, xml, codigo);
            populads.populaTagTotal(dsdanfe, xml, codigo);
            populads.PopulaTagTransp(dsdanfe, xml, codigo);
            populads.PopulaTagCobr(dsdanfe, xml, codigo);
            populads.PopulaTagInfAdic(dsdanfe, xml, codigo);
            populads.PopulaTagExporta(dsdanfe, xml, codigo);
            populads.PopulaTagCompra(dsdanfe, xml, codigo);
            populads.PopulaTagEntrega(dsdanfe, xml, codigo);
            populads.PopulaTagRetirada(dsdanfe, xml, codigo);
            populads.PopulaTagInfProt(dsdanfe, xml, codigo);

            if ((Acesso.LOGOTIPO != "\r\n"))
            {
                Byte[] bimagem = Util.CarregaImagem(Acesso.LOGOTIPO);

                if (bimagem != null)
                {
                    if (bimagem.Length <= 100000)
                    {
                        populads.PopulaImagem(dsdanfe, bimagem);
                    }
                    else
                    {
                        KryptonMessageBox.Show(null, "Logotipo muito Grande, Favor reduzir os para menos de 100KB"
                            + Environment.NewLine + Environment.NewLine
                            + "A Danfe não sairá com logotipo néssa visualização!", "A V I S O", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }
    }
}
