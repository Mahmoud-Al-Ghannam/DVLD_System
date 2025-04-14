using DVLD_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BusinessLayer
{
    public class clsPerson
    {
        public int PersonID { get; private set; }
        public string NationalNO { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; } // It may be Null
        public string LastName { get; set; }
        public string FullName
        {
            get
            {
                return FirstName + " " + SecondName + " " + (ThirdName == null? "":ThirdName) + " " + LastName;
            }
        }
        public DateTime DateOfBirth { get; set; }
        public enGendor Gendor { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; } // It may be Null

        private int _NationalityCountryID;
        public int NationalityCountryID { 
            get { return _NationalityCountryID; }
            set
            {
                _NationalityCountryID = value;
                NationalityCountryInfo = clsCountry.FindCountryByID(value);
            }
        }

        public clsCountry NationalityCountryInfo { get; private set; }
        public string ImagePath { get; set; } // It may be Null


        public enum enMode { eAddNew=1,eUpdate=2};
        public enum enGendor {Male=0,Female=1};
        public enMode Mode { get;private set; }

        public clsPerson ()
        {
            Mode = enMode.eAddNew;
            NationalityCountryID = PersonID = -1;
            NationalNO = FirstName = SecondName = ThirdName = LastName = Address = Phone = Email = ImagePath = "";
            Gendor = enGendor.Male;
            DateOfBirth = DateTime.MinValue;
        }

        private clsPerson(int PersonID, string NationalNO, string FirstName, string SecondName, string ThirdName, string LastName,
            DateTime DateOfBirth, enGendor Gendor,string Address,string Phone,string Email,int NationalityCountryID,string ImagePath)
        {
            Mode = enMode.eUpdate;
            this.PersonID = PersonID;
            this.NationalNO = NationalNO;
            this.FirstName = FirstName;
            this.SecondName = SecondName;
            this.ThirdName = ThirdName;
            this.LastName = LastName;
            this.DateOfBirth = DateOfBirth;
            this.Gendor = Gendor;
            this.Address = Address;
            this.Phone = Phone;
            this.Email = Email;
            this.NationalityCountryID = NationalityCountryID;
            this.ImagePath = ImagePath;
        }


        private bool _AddNew ()
        {
            PersonID = clsDataPerson.AddNewPerson(NationalNO, FirstName, SecondName, ThirdName, LastName,DateOfBirth, Convert.ToByte(Gendor) , Address, Phone, Email, NationalityCountryID, ImagePath);
            return (PersonID != -1);
        }

        private bool _Update ()
        {
            return clsDataPerson.UpdatePerson(PersonID, NationalNO, FirstName, SecondName, ThirdName, LastName, DateOfBirth, Convert.ToByte(Gendor), Address, Phone, Email, NationalityCountryID, ImagePath);
        }

        public bool Save ()
        {
            switch(Mode)
            {
                case enMode.eAddNew:
                    if(_AddNew())
                    {
                        Mode = enMode.eUpdate;
                        return true;
                    }
                    break;
                case enMode.eUpdate:
                    return _Update();
                    break;
            }
            return false;
        }

        public static clsPerson FindPersonByID (int PersonID)
        {
            if (!clsDataPerson.IsPersonExistByID(PersonID)) return null;

            int NationalityCountryID=-1;
            string NationalNO="", FirstName = "", SecondName = "", ThirdName = null, LastName = "", Address = "", Phone = "", Email = null,ImagePath = null;
            DateTime DateOfBirth = DateTime.Now;
            byte Gendor= 3;

            bool Found = clsDataPerson.GetAllPersonInfoByID(PersonID, ref NationalNO, ref FirstName, ref SecondName, ref ThirdName, ref LastName, ref DateOfBirth, ref Gendor, ref Address, ref Phone, ref Email, ref NationalityCountryID, ref ImagePath);
            if(Found)
            {
                return new clsPerson(PersonID, NationalNO, FirstName, SecondName, ThirdName, LastName, DateOfBirth, (enGendor) Gendor, Address, Phone, Email, NationalityCountryID, ImagePath);
            }
            return null;
        }

        public static clsPerson FindPersonByNationalNO(string NationalNO)
        {
            if(!clsDataPerson.IsPersonExistByNationalNO(NationalNO)) return null;

            int NationalityCountryID = -1,PersonID=-1;
            string FirstName = "", SecondName = "", ThirdName = null, LastName = "", Address = "", Phone = "", Email = null, ImagePath = null;
            DateTime DateOfBirth = DateTime.Now;
            byte Gendor = 3;

            bool Found = clsDataPerson.GetAllPersonInfoByNationalNO(NationalNO,ref PersonID, ref FirstName, ref SecondName, ref ThirdName, ref LastName, ref DateOfBirth, ref Gendor, ref Address, ref Phone, ref Email, ref NationalityCountryID, ref ImagePath);
            if (Found)
            {
                return new clsPerson(PersonID, NationalNO, FirstName, SecondName, ThirdName, LastName, DateOfBirth, (enGendor) Gendor, Address, Phone, Email, NationalityCountryID, ImagePath);
            }
            return null;
        }

        public static bool IsPersonExistByID (int PersonID)
        {
            return clsDataPerson.IsPersonExistByID(PersonID);
        }

        public static bool IsPersonExistByNationalNO(string NationalNO)
        {
            return clsDataPerson.IsPersonExistByNationalNO(NationalNO);
        }

        public static bool IsPersonActiveUserByID(int PersonID)
        {
            return clsDataPerson.IsPersonActiveUserByID(PersonID);
        }
        public bool Delete ()
        {
            if(DeletePersonByID(PersonID))
            {
                PersonID = -1;
                Mode = enMode.eAddNew;
                return true;
            }
            return false;
        }
        public static bool DeletePersonByID(int PersonID)
        {
            return clsDataPerson.DeletePersonByID(PersonID);
        }
        public static DataTable GetAllPeople()
        {
            return clsDataPerson.GetAllPeople();
        }

        public static bool DoesPersonHaveLicenseWithLicenseClass(int PersonID, int LicenseClassID)
        {
            return clsDataPerson.DoesPersonHaveLicenseWithLicenseClass(PersonID, LicenseClassID);   
        }
        public static int GetPersonIDByDriverID(int DriverID)
        {
            return clsDataPerson.GetPersonIDByDriverID(DriverID);
        }
    }
}
