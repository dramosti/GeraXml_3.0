using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;
using System.Security.AccessControl;

namespace HLP.GeraXml.Comum
{
    public class belRegedit
    {
        public static string BuscaCodigoEmpresa()
        {
            RegistryKey key = Registry.CurrentConfig.OpenSubKey("hlp\\nivel0006");
            string sCodEmpresaPadrao = (key != null ? key.GetValue("Código da firma digitado no início do Sistema", "").ToString() : "");
            return sCodEmpresaPadrao;
        }

        public static string BuscaNomeSkin()
        {
            RegistryKey key = Registry.CurrentConfig.OpenSubKey("hlp\\Skin");
            string skin = (key != null ? key.GetValue("VisualGeraXml", "").ToString() : "");
            return skin;
        }

        public static void SalvarRegistro(string sSubKey, string sKey, string sValor)
        {
            string user = Environment.UserDomainName + "\\" + Environment.UserName;
            RegistrySecurity  rs = new RegistrySecurity();
            rs.AddAccessRule(new RegistryAccessRule(user,
            RegistryRights.FullControl,
            InheritanceFlags.None,
            PropagationFlags.None,
            AccessControlType.Allow));

            RegistryKey rk = Registry.CurrentConfig.OpenSubKey("hlp", true);
            rk = rk.CreateSubKey(sSubKey, RegistryKeyPermissionCheck.Default, rs);
            rk.SetValue(sKey, sValor);

        }
    }
}
