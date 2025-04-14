using DVLD_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BusinessLayer
{
    public class clsLicenseClass
    {
        public int LicenseClassID { get; private set; }
        public string ClassName { get; set; }
        public string ClassDescription { get; set; }
        public byte MinimumAllowedAge { get; set; }
        public byte DefaultValidityLength { get; set; } 
        public decimal ClassFees { get; set; }
        public enum enMode { eAddNew = 1, eUpdate = 2 };
        public enMode Mode { get; private set; }

        public clsLicenseClass()
        {
            Mode = enMode.eAddNew;
            LicenseClassID = -1;
            decimal ClassFees = 0;
            string ClassName = "", ClassDescription = "";
            byte MinimumAllowedAge = 0,DefaultValidityLength=0;
        }

        private clsLicenseClass(int LicenseClassID,string ClassName,string ClassDescription,byte MinimumAllowedAge,byte DefaultValidityLength,decimal ClassFees)
        {
            Mode = enMode.eUpdate;
            this.LicenseClassID = LicenseClassID;
            this.ClassName = ClassName;
            this.ClassDescription = ClassDescription;
            this.MinimumAllowedAge = MinimumAllowedAge;
            this.DefaultValidityLength = DefaultValidityLength;
            this.ClassFees = ClassFees;
        }

        public static int GetLicenseClassIDByClassName(string ClassName)
        {
            return clsDataLicenseClass.GetLicenseClassIDByClassName(ClassName);
        }
        private bool _AddNew()
        {
            LicenseClassID = clsDataLicenseClass.AddNewLicenseClass(ClassName,ClassDescription,MinimumAllowedAge,DefaultValidityLength,ClassFees);
            return (LicenseClassID != -1);
        }

        private bool _Update()
        {
            return clsDataLicenseClass.UpdateLicenseClass(LicenseClassID, ClassName, ClassDescription, MinimumAllowedAge, DefaultValidityLength, ClassFees);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.eAddNew:
                    if (_AddNew())
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

        public static clsLicenseClass FindLicenseClassByID(int LicenseClassID)
        {
            if (!clsDataLicenseClass.IsLicenseClassExistByID(LicenseClassID)) return null;

            byte MinimumAllowedAge = 0 , DefaulValidityLength = 0 ;
            string ClassName = "", ClassDescription = "";
            decimal ClassFees = 0;

            bool Found = clsDataLicenseClass.GetAllLicenseClassInfoByID(LicenseClassID, ref ClassName, ref ClassDescription, ref MinimumAllowedAge, ref DefaulValidityLength,ref ClassFees);
            if (Found)
            {
                return new clsLicenseClass(LicenseClassID,ClassName,ClassDescription,MinimumAllowedAge,DefaulValidityLength,ClassFees);
            }
            return null;
        }

        public bool Delete()
        {
            if (clsDataLicenseClass.DeleteLicenseClass(LicenseClassID))
            {
                Mode = enMode.eAddNew;
                LicenseClassID = -1;
                return true;
            }
            return false;
        }
        public static DataTable GetAllLicenseClasses()
        {
            return clsDataLicenseClass.GetAllLicenseClasses();
        }

    }
}
