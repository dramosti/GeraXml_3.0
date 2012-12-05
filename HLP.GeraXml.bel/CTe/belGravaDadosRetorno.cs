using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HLP.GeraXml.dao.CTe;

namespace HLP.GeraXml.bel.CTe
{
    public class belGravaDadosRetorno : daoGravaDadosRetorno
    {
        public void GravarChave(belPopulaObjetos objObjetos)
        {
            try
            {
                for (int i = 0; i < objObjetos.objListaConhecimentos.Count; i++)
                {
                    string sChave = objObjetos.objListaConhecimentos[i].id.Replace("CTe", "");

                    SalvaChave(sChave, objObjetos.objListaConhecimentos[i].ide.nCT);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Gravar a Chave no Banco de Dados.");
            }


        }

        public void GravarRecibo(belPopulaObjetos objObjetos, string sRecibo)
        {
            try
            {
                for (int i = 0; i < objObjetos.objListaConhecimentos.Count; i++)
                {
                    SalvarRecibo(sRecibo, objObjetos.objListaConhecimentos[i].ide.nCT);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Gravar o Recibo no Banco de Dados.");
            }
        }
    }
}
