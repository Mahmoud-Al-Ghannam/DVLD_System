using DVLD_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BusinessLayer
{
    public class clsCountry
    {
        public int CountryID { get; private set; }
        public string CountryName { get; private set; }

        private clsCountry(int CountryID, string CountryName)
        {
            this.CountryID = CountryID;
            this.CountryName = CountryName;
        }
        public static clsCountry FindCountryByID(int CountryID)
        {
            if (!clsDataCountry.IsCountryExistByID(CountryID)) return null;

            string CountryName = "";

            bool Found = clsDataCountry.GetAllCountryInfoByID(CountryID, ref CountryName);
            if (Found)
            {
                return new clsCountry(CountryID,CountryName);
            }
            return null;
        }
        public static clsCountry FindCountryByName(string CountryName)
        {
            if (!clsDataCountry.IsCountryExistByName(CountryName)) return null;

            int CountryID = -1;

            bool Found = clsDataCountry.GetAllCountryInfoByName(CountryName, ref CountryID);
            if (Found)
            {
                return new clsCountry(CountryID, CountryName);
            }
            return null;
        }
        public static DataTable GetAllCountries()
        {
            return clsDataCountry.GetAllCountries();
        }
    }
}
