using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Global_Classes
{
    public static class clsValidation
    {
        public static bool IsInteger (string value)
        {
            if (value == null || value == "") return false;
            try
            {
                Convert.ToInt32(value);
            } catch (Exception ex)
            {
                return false;
            }
            return true;
        } 

        public static bool IsDecimal (string value)
        {
            if (value == null || value == "") return false;
            try
            {
                Convert.ToDecimal(value);
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
    }
}
