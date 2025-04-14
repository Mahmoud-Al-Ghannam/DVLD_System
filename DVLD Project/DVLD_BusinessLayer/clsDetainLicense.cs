using DVLD_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BusinessLayer
{
    public class clsDetainLicense
    {
        public int DetainID { get; private set; }

        private int _LicenseID;
        public int LicenseID
        {
            get { return _LicenseID; }
            set
            {
                _LicenseID = value; 
                LicenseInfo = clsLicense.FindLicenseByID(value);
            }
        }
        public clsLicense LicenseInfo { get; private set; }

        public DateTime DetainDate { get; set; }
        public decimal FineFees { get; set; }


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


        public bool IsReleased { get; set; }
        public Nullable<DateTime> ReleaseDate { get; set; } // It may be Null

        private Nullable<int> _ReleasedByUserID;
        public Nullable<int> ReleasedByUserID
        {
            get { return _ReleasedByUserID; }
            set
            {
                _ReleasedByUserID = value;
                if (value != null) ReleasedByUserInfo = clsUser.FindUserByID(value.Value);
                else ReleasedByUserInfo = null;
            }
        }
        public clsUser ReleasedByUserInfo { get; private set; }


        private Nullable<int> _ReleaseApplicationID;
        public Nullable<int> ReleaseApplicationID
        {
            get { return _ReleaseApplicationID; }
            set
            {
                _ReleaseApplicationID = value;
                if (value != null) ReleaseApplicationInfo = clsApplication.FindApplicationByID(value.Value);
                else ReleaseApplicationInfo = null;
            }
        }
        public clsApplication ReleaseApplicationInfo { get; private set; }


        public enum enMode { eAddNew = 1, eUpdate = 2 };
        public enMode Mode { get; private set; }

        public clsDetainLicense()
        {
            Mode = enMode.eAddNew;
            CreatedByUserID = LicenseID = DetainID = -1;
            DetainDate = DateTime.Now;
            FineFees = 0;
            IsReleased = false;
            ReleaseDate = null;
            ReleaseApplicationID = ReleasedByUserID = null;
        }

        private clsDetainLicense(int DetainID, int LicenseID, DateTime DetainDate, decimal FineFees, int CreatedByUserID, bool IsReleased,
            Nullable<DateTime> ReleaseDate, Nullable<int> ReleasedByUserID, Nullable<int> ReleaseApplicationID)
        {
            Mode = enMode.eUpdate;
            this.DetainID = DetainID;
            this.LicenseID = LicenseID;
            this.DetainDate = DetainDate;
            this.FineFees = FineFees;
            this.CreatedByUserID = CreatedByUserID;
            this.IsReleased = IsReleased;
            this.ReleaseDate = ReleaseDate;
            this.ReleasedByUserID = ReleasedByUserID;
            this.ReleaseApplicationID = ReleaseApplicationID;
        }


        private bool _AddNew()
        {
            DetainID = clsDataDetainLicense.AddNewDetainLicense(LicenseID, DetainDate, FineFees, CreatedByUserID, IsReleased, ReleaseDate,ReleasedByUserID, ReleaseApplicationID);
            return (DetainID != -1);
        }

        private bool _Update()
        {
            return clsDataDetainLicense.UpdateDetainLicense(DetainID, LicenseID, DetainDate, FineFees, CreatedByUserID, IsReleased, ReleaseDate,ReleasedByUserID, ReleaseApplicationID);
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

        public static clsDetainLicense FindDetainLicenseByID(int DetainID)
        {
            if (!clsDataDetainLicense.IsDetainLicenseExistByID(DetainID)) return null;

            int LicenseID = 0 , CreatedByUserID = 0;
            Nullable<int> ReleaseApplicationID = null, ReleasedByUserID = null;
            Nullable<DateTime> ReleaseDate = null;
            DateTime DetainDate = DateTime.Now;
            decimal FineFees = 0;
            bool IsReleased = false;

            bool Found = clsDataDetainLicense.GetAllDetainLicenseInfoByID(DetainID, ref LicenseID, ref DetainDate, ref FineFees, ref CreatedByUserID, ref IsReleased, ref ReleaseDate, ref ReleasedByUserID, ref ReleaseApplicationID);
            if (Found)
            {
                return new clsDetainLicense(DetainID, LicenseID, DetainDate, FineFees, CreatedByUserID, IsReleased, ReleaseDate,ReleasedByUserID, ReleaseApplicationID);
            }
            return null;
        }

        public static clsDetainLicense FindDetainLicenseByLicenseID(int LicenseID)
        {
            
            int DetainID = 0, CreatedByUserID = 0;
            Nullable<int> ReleaseApplicationID = null, ReleasedByUserID = null;
            Nullable<DateTime> ReleaseDate = null;
            DateTime DetainDate = DateTime.Now;
            decimal FineFees = 0;
            bool IsReleased = false;

            bool Found = clsDataDetainLicense.GetAllDetainLicenseInfoByLicenseID(LicenseID,ref DetainID, ref DetainDate, ref FineFees, ref CreatedByUserID, ref IsReleased, ref ReleaseDate, ref ReleasedByUserID, ref ReleaseApplicationID);
            if (Found)
            {
                return new clsDetainLicense(DetainID, LicenseID, DetainDate, FineFees, CreatedByUserID, IsReleased, ReleaseDate, ReleasedByUserID, ReleaseApplicationID);
            }
            return null;
        }

        public bool Delete()
        {
            if (clsDataDetainLicense.DeleteDetainLicense(DetainID))
            {
                Mode = enMode.eAddNew;
                DetainID = -1;
                return true;
            }
            return false;
        }
        public static DataTable GetAllDetainLicenses()
        {
            return clsDataDetainLicense.GetAllDetainLicenses();
        }

        public bool Release(int CreatedByUserID)
        {
            if (IsReleased) return false;
            clsApplication ReleaseApplication = new clsApplication();
            ReleaseApplication.ApplicationDate = DateTime.Now;
            ReleaseApplication.LastStatusDate = DateTime.Now;
            ReleaseApplication.ApplicantPersonID = LicenseInfo.DriverInfo.PersonID;
            ReleaseApplication.ApplicationStatus = clsApplication.enApplicationStatus.Complete;
            ReleaseApplication.ApplicationTypeID = clsApplicationType.enApplicationType.eReleaseDetainedDL;
            ReleaseApplication.CreatedByUserID = CreatedByUserID;
            ReleaseApplication.PaidFees = clsApplicationType.FindApplicationTypeByID(clsApplicationType.enApplicationType.eReleaseDetainedDL).ApplicationTypeFees;
            if (!ReleaseApplication.Save()) return false;

            IsReleased = true;
            ReleaseDate = DateTime.Now;
            ReleaseApplicationID = ReleaseApplication.ApplicationID;
            ReleasedByUserID = CreatedByUserID;

            if (!Save()) return false;
            return true;
        }
    }
}
