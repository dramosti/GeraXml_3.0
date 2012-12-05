using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using System.Threading;

namespace HLP.GeraXml.bel
{
    public class InternetCS
    {

        public bool Conexao()
        {
            try
            {
                bool bvalida = VerificaUOL();

                if (!bvalida)
                {
                    bvalida = VerificaGoogle();
                }
                return bvalida;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public bool VerificaGoogle()
        {
            System.Net.WebRequest webReq;

            try
            {
                System.Uri Url = new System.Uri("http://www.google.com.br");
                System.Net.WebResponse resp;
                webReq = System.Net.WebRequest.Create(Url);
                resp = webReq.GetResponse();
                resp.Close();
                webReq = null;
                return true;
            }
            catch
            {
                webReq = null;
                return false;
            }
        }

        public bool VerificaUOL()
        {
            System.Net.WebRequest webReq;

            try
            {
                System.Uri Url = new System.Uri("http://www.uol.com.br");
                System.Net.WebResponse resp;
                webReq = System.Net.WebRequest.Create(Url);
                resp = webReq.GetResponse();
                resp.Close();
                webReq = null;
                return true;
            }
            catch
            {
                webReq = null;
                return false;
            }
        }


    }

}
