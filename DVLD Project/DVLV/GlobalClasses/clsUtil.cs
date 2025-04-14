using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.GlobalClasses
{
    public class clsUtil
    {
        public static string ComputeHash(string str)
        {
            using (SHA256 SHA = SHA256.Create())
            {
                byte[] HashBytes = SHA.ComputeHash(Encoding.UTF8.GetBytes(str));
                return BitConverter.ToString(HashBytes).Replace("-", "");
            }
        }
    }
}
