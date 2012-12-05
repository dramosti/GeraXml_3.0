﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HLP.GeraXml.dao.ADO;
using System.Data;

namespace HLP.GeraXml.dao
{
    public class daoConfiguracao
    {
        /// <summary>
        /// Struct para configurar combobox de configuração
        /// </summary>
        public struct ComboBoxConfiguracao
        {
            public string ds_descvalor { get; set; }
            public string ds_valor { get; set; }
        }

        public object populaComboGruposFat()
        {
            try
            {
                DataTable dt = HlpDbFuncoes.qrySeekRet("HLPSTATUS", "ds_descvalor, ds_valor", "ds_referencia = 'CD_GRUPONF'");
                List<ComboBoxConfiguracao> objLista = new List<ComboBoxConfiguracao>();
                foreach (DataRow dr in dt.Rows)
                {
                    objLista.Add(new ComboBoxConfiguracao
                    {
                        ds_descvalor = dr["ds_valor"].ToString() + " - " + dr["ds_descvalor"].ToString(),
                        ds_valor = dr["ds_valor"].ToString()
                    });
                }
                return objLista;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public object CarregaComboModoSistema()
        {
            try
            {
                List<ComboBoxConfiguracao> objLista = new List<ComboBoxConfiguracao>();
                objLista.Add(new ComboBoxConfiguracao { ds_descvalor = "Normal", ds_valor = "1" });
                objLista.Add(new ComboBoxConfiguracao { ds_descvalor = "Contingência FS", ds_valor = "2" });
                objLista.Add(new ComboBoxConfiguracao { ds_descvalor = "Contingência SCAN", ds_valor = "3" });

                return objLista;
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
