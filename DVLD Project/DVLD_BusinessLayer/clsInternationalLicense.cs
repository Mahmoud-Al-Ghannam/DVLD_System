using DVLD_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BusinessLayer
{
    public class clsInternationalLicense
    {
        public int InternationalLicenseID { get; private set; }
        
        
        private int _DriverID;
        public int DriverID
        {
            get { return _DriverID; }
            set
            {
                _DriverID = value;
                DriverInfo = clsDriver.FindDriverByID(value);
            }
        }
        public clsDriver DriverInfo { get; private set; }


        private int _ApplicationID;
        public int ApplicationID
        {
            get { return _ApplicationID; }
            set
            {
                _ApplicationID = value;
                ApplicationInfo = clsApplication.FindApplicationByID(value);
            }
        }
        public clsApplication ApplicationInfo { get; private set; }


        private int _IssuedUsingLocalLicenseID;
        public int IssuedUsingLocalLicenseID
        {
            get { return _IssuedUsingLocalLicenseID; }
            set
            {
                _IssuedUsingLocalLicenseID = value;
                IssuedUsingLocalLicenseInfo = clsLicense.FindLicenseByID(value);
            }
        }
        public clsLicense IssuedUsingLocalLicenseInfo {  get; private set; }
        
        
        public DateTime IssueDate { get; set; } 
        public DateTime ExpirationDate { get; set; }
        public bool IsActive { get; set; }
        
        
        private int _CreatedByUserID;
        public int CreatedByUserID
        {
            get { return _CreatedByUserID; }
            set
            {
                _CreatedByUserID = value;
                CreatedByUserInfo = clsUser.FindUserByID(value);
            }
        }
        public clsUser CreatedByUserInfo { get; private set; }


        public enum enMode { eAddNew = 1, eUpdate = 2 };
        public enMode Mode { get; private set; }

        public clsInternationalLicense()
        {
            Mode = enMode.eAddNew;
            CreatedByUserID = ApplicationID = DriverID = IssuedUsingLocalLicenseID = InternationalLicenseID = -1;
            IssueDate = ExpirationDate = DateTime.MinValue;
            IsActive = false;
        }

        private clsInternationalLicense(int InternationalLicenseID, int ApplicationID, int DriverID, int IssuedUsingLocalLicenseID, DateTime IssueDate, DateTime ExpirationDate,
            bool IsActive, int CreatedByUserID)
        {
            Mode = enMode.eUpdate;
            this.InternationalLicenseID = InternationalLicenseID;
            this.ApplicationID = ApplicationID;
            this.DriverID = DriverID;
            this.IssuedUsingLocalLicenseID = IssuedUsingLocalLicenseID;
            this.IssueDate = IssueDate;
            this.ExpirationDate = ExpirationDate;
            this.IsActive = IsActive;
            this.CreatedByUserID = CreatedByUserID;
        }


        private bool _AddNew()
        {
            InternationalLicenseID = clsDataInternationalLicense.AddNewInternationalLicense(ApplicationID, DriverID, IssuedUsingLocalLicenseID, IssueDate, ExpirationDate, IsActive,CreatedByUserID);
            return (InternationalLicenseID != -1);
        }

        private bool _Update()
        {
            return clsDataInternationalLicense.UpdateInternationalLicense(InternationalLicenseID, ApplicationID, DriverID, IssuedUsingLocalLicenseID, IssueDate, ExpirationDate, IsActive,CreatedByUserID);
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

        public static clsInternationalLicense FindInternationalLicenseByID(int InternationalLicenseID)
        {
            if (!clsDataInternationalLicense.IsInternationalLicenseExistByID(InternationalLicenseID)) return null;

            int CreatedByUserID = 0,ApplicationID = 0, DriverID = 0, IssuedUsingLocalLicenseID = 0;
            DateTime IssueDate = DateTime.Now, ExpirationDate = DateTime.Now;
            bool IsActive = false;

            bool Found = clsDataInternationalLicense.GetAllInternationalLicenseInfoByID(InternationalLicenseID, ref ApplicationID, ref DriverID, ref IssuedUsingLocalLicenseID, ref IssueDate, ref ExpirationDate, ref IsActive, ref CreatedByUserID);
            if (Found)
            {
                return new clsInternationalLicense(InternationalLicenseID, ApplicationID, DriverID, IssuedUsingLocalLicenseID, IssueDate, ExpirationDate, IsActive,CreatedByUserID);
            }
            return null;
        }

        public bool Delete()
        {
            if (clsDataInternationalLicense.DeleteInternationalLicense(InternationalLicenseID))
            {
                Mode = enMode.eAddNew;
                InternationalLicenseID = -1;
                return true;
            }
            return false;
        }
        public static DataTable GetAllInternationalLicenses()
        {
            return clsDataInternationalLicense.GetAllInternationalLicenses();
        }

        public static DataTable GetAllInternationalLicensesForDriver (int DriverID)
        {
            return clsDataInternationalLicense.GetAllInternationalLicensesForDriver(DriverID);
        }
    }
}
