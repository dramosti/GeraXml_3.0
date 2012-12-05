using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using System.Threading;
using HLP.GeraXml.bel.NFe;

namespace HLP.GeraXml.UI.NFe
{
    public partial class frmBuscaRetorno : ComponentFactory.Krypton.Toolkit.KryptonForm 
    {
        belBusRetFazenda _objbelBuscaRetFazendo;
        Thread workThread;

        public frmBuscaRetorno(belBusRetFazenda objbusretfazenda)
        {
            InitializeComponent();
            _objbelBuscaRetFazendo = objbusretfazenda;
            _objbelBuscaRetFazendo._lblQtde = this.lblTentativas;
            workThread = new Thread(_objbelBuscaRetFazendo.BuscaRetorno);
            _objbelBuscaRetFazendo.bStopRetorno = false;
            tempo.Start();
            workThread.Start();
            while (!workThread.IsAlive) ;
            Thread.Sleep(1);
        }

        private void btnCancelaBusca_Click(object sender, EventArgs e)
        {
            _objbelBuscaRetFazendo.bStopRetorno = true;
            workThread.Join();
            this.Close();
        }

        private void tempo_Tick(object sender, EventArgs e)
        {
            if (_objbelBuscaRetFazendo.bStopRetorno)
            {
                workThread.Join();
                this.Close();
            }
        }
    }
}