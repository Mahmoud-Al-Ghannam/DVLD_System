using DVLD_BusinessLayer;
using System.Collections.Generic;
using System.IO;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

namespace DVLD.Global_Classes
{
    public class clsGlobalClass
    {
        public static clsUser CurrentUser { get; set; }

        public static void RememberUsernameAndPassword(string Username, string Password)
        {
            string Path = @"HKEY_CURRENT_USER\Software\DVLD";
            try
            {
                Registry.SetValue(Path,"Username",Username,RegistryValueKind.String);
                Registry.SetValue(Path,"Password",Password,RegistryValueKind.String);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        public static bool GetTheRememberedUsernameAndPassword(ref string Username, ref string Password)
        {
            string Path = @"HKEY_CURRENT_USER\Software\DVLD";

            try
            {
                Username = Registry.GetValue(Path, "Username", "") as string;
                Password = Registry.GetValue(Path, "Password", "") as string;
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message , "Error" ,MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return false;
        }
    }
}
