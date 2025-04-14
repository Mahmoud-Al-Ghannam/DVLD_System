using DVLD_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BusinessLayer
{
    public class clsLicense
    {
        public enum enMode { eAddNew = 1, eUpdate = 2 };
        public enum enIssueReason { eFirstTime = 1, eRenew = 2, eDamagedReplacement = 3, LostReplacement = 4 };

        public int LicenseID { get; private set; }

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


        private int _LicenseClassID;
        public int LicenseClassID
        {
            get { return _LicenseClassID; }
            set
            {
                _LicenseClassID = value;
                LicenseClassInfo = clsLicenseClass.FindLicenseClassByID(value);
            }
        }
        public clsLicenseClass LicenseClassInfo { get; private set; }

        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Notes { get; set; } // It may be Null
        public decimal PaidFees { get; set; }
        public bool IsActive { get; set; }
        public enIssueReason IssueReason { get; set; }
        public string IssueReasonText
        {
            get
            {
                if (IssueReason == enIssueReason.eFirstTime) return "For First Time";
                if (IssueReason == enIssueReason.eRenew) return "Renew";
                if (IssueReason == enIssueReason.LostReplacement) return "Replacement For Lost";
                if (IssueReason == enIssueReason.eDamagedReplacement) return "Replacement For Damage";
                return "Unknown";
            }
        }


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

        public clsDetainLicense DetainLicenseInfo 
        {
            get { return clsDetainLicense.FindDetainLicenseByLicenseID(LicenseID); }
        }
        public enMode Mode { get; private set; }

        public clsLicense()
        {
            Mode = enMode.eAddNew;
            CreatedByUserID = ApplicationID = DriverID = LicenseClassID = LicenseID = -1;
            IsActive = false;
            IssueReason = enIssueReason.eFirstTime;
            PaidFees = 0;
            Notes = null;
            IssueDate = ExpirationDate = DateTime.MinValue;
        }

        private clsLicense(int LicenseID, int ApplicationID, int DriverID, int LicenseClassID, DateTime IssueDate, DateTime ExpirationDate,
            string Notes, decimal PaidFees, bool IsActive, enIssueReason IssueReason, int CreatedByUserID)
        {
            Mode = enMode.eUpdate;
            this.LicenseID = LicenseID;
            this.ApplicationID = ApplicationID;
            this.DriverID = DriverID;
            this.LicenseClassID = LicenseClassID;
            this.IssueDate = IssueDate;
            this.ExpirationDate = ExpirationDate;
            this.Notes = Notes;
            this.PaidFees = PaidFees;
            this.IsActive = IsActive;
            this.IssueReason = IssueReason;
            this.CreatedByUserID = CreatedByUserID;
        }


        private bool _AddNew()
        {
            LicenseID = clsDataLicense.AddNewLicense(ApplicationID, DriverID, LicenseClassID, IssueDate, ExpirationDate, Notes, PaidFees, IsActive, Convert.ToByte(IssueReason), CreatedByUserID);
            return (LicenseID != -1);
        }

        private bool _Update()
        {
            return clsDataLicense.UpdateLicense(LicenseID, ApplicationID, DriverID, LicenseClassID, IssueDate, ExpirationDate, Notes, PaidFees, IsActive, Convert.ToByte(IssueReason), CreatedByUserID);
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

        public static clsLicense FindLicenseByID(int LicenseID)
        {
            if (!clsDataLicense.IsLicenseExistByID(LicenseID)) return null;

            int ApplicationID = 0, DriverID = 0, LicenseClassID = 0, CreatedByUserID = 0;
            DateTime IssueDate = DateTime.Now, ExpirationDate = DateTime.Now;
            byte IssueReason = 1;
            string Notes = null;
            decimal PaidFees = 0;
            bool IsActive = false;

            bool Found = clsDataLicense.GetAllLicenseInfoByID(LicenseID, ref ApplicationID, ref DriverID, ref LicenseClassID, ref IssueDate, ref ExpirationDate, ref Notes, ref PaidFees, ref IsActive, ref IssueReason, ref CreatedByUserID);
            if (Found)
            {
                return new clsLicense(LicenseID, ApplicationID, DriverID, LicenseClassID, IssueDate, ExpirationDate, Notes, PaidFees, IsActive, (enIssueReason)IssueReason, CreatedByUserID);
            }
            return null;
        }
        public static clsLicense FindLicenseByPersonID(int PersonID, int LicenseClassID)
        {
            int ApplicationID = 0, LicenseID = -1, DriverID = 0, CreatedByUserID = 0;
            DateTime IssueDate = DateTime.Now, ExpirationDate = DateTime.Now;
            byte IssueReason = 1;
            string Notes = null;
            decimal PaidFees = 0;
            bool IsActive = false;

            bool Found = clsDataLicense.GetAllLicenseInfoByPersonID(PersonID, LicenseClassID, ref LicenseID, ref ApplicationID, ref DriverID, ref IssueDate, ref ExpirationDate, ref Notes, ref PaidFees, ref IsActive, ref IssueReason, ref CreatedByUserID);
            if (Found)
            {
                return new clsLicense(LicenseID, ApplicationID, DriverID, LicenseClassID, IssueDate, ExpirationDate, Notes, PaidFees, IsActive, (enIssueReason)IssueReason, CreatedByUserID);
            }
            return null;
        }
        public static clsLicense FindLicenseByLocalDrivingLicenseApplicationID(int LocalDrivingLicenseApplicationID)
        {

            int ApplicationID = 0, LicenseID = -1, DriverID = 0, LicenseClassID = 0, CreatedByUserID = 0;
            DateTime IssueDate = DateTime.Now, ExpirationDate = DateTime.Now;
            byte IssueReason = 1;
            string Notes = null;
            decimal PaidFees = 0;
            bool IsActive = false;

            bool Found = clsDataLicense.GetAllLicenseInfoByLocalDrivingLicenseApplicationID(LocalDrivingLicenseApplicationID, ref LicenseID, ref ApplicationID, ref DriverID, ref LicenseClassID, ref IssueDate, ref ExpirationDate, ref Notes, ref PaidFees, ref IsActive, ref IssueReason, ref CreatedByUserID);
            if (Found)
            {
                return new clsLicense(LicenseID, ApplicationID, DriverID, LicenseClassID, IssueDate, ExpirationDate, Notes, PaidFees, IsActive, (enIssueReason)IssueReason, CreatedByUserID);
            }
            return null;
        }
        public static clsLicense FindLicenseByApplicationID(int ApplicationID)
        {
            int LicenseID = -1, DriverID = 0, LicenseClassID = 0, CreatedByUserID = 0;
            DateTime IssueDate = DateTime.Now, ExpirationDate = DateTime.Now;
            byte IssueReason = 1;
            string Notes = null;
            decimal PaidFees = 0;
            bool IsActive = false;

            bool Found = clsDataLicense.GetAllLicenseInfoByApplicationID(ApplicationID, ref LicenseID, ref DriverID, ref LicenseClassID, ref IssueDate, ref ExpirationDate, ref Notes, ref PaidFees, ref IsActive, ref IssueReason, ref CreatedByUserID);
            if (Found)
            {
                return new clsLicense(LicenseID, ApplicationID, DriverID, LicenseClassID, IssueDate, ExpirationDate, Notes, PaidFees, IsActive, (enIssueReason)IssueReason, CreatedByUserID);
            }
            return null;
        }

        public static bool IsLicenseExistByID(int LicenseID)
        {
            return clsDataLicense.IsLicenseExistByID(LicenseID);
        }
        public bool Delete()
        {
            if (clsDataLicense.DeleteLicense(LicenseID))
            {
                Mode = enMode.eAddNew;
                LicenseID = -1;
                return true;
            }
            return false;
        }
        public static DataTable GetAllLicenses()
        {
            return clsDataLicense.GetAllLicenses();
        }
        public static DataTable GetAllLocalDrivingLicensesForDriver(int DriverID)
        {
            return clsDataLicense.GetAllLocalDrivingLicensesForDriver(DriverID);
        }
        public static bool IsDetained(int LicenseID)
        {
            return clsDataLicense.IsDetained(LicenseID);
        }
        public bool IsDetained()
        {
            return IsDetained(LicenseID);
        }

        private int _RenewAccordingToTheReason(int ApplicationID, enIssueReason IssueReason, int CreatedByUserID, string Notes)
        {
            clsLicense License = new clsLicense();
            License.ApplicationID = ApplicationID;
            License.IssueReason = IssueReason;
            License.CreatedByUserID = CreatedByUserID;
            License.Notes = Notes;

            License.LicenseClassID = LicenseClassID;
            License.IssueDate = DateTime.Now;
            License.ExpirationDate = DateTime.Now.AddYears(LicenseClassInfo.DefaultValidityLength);
            License.IsActive = true;
            License.DriverID = DriverID;
            License.PaidFees = LicenseClassInfo.ClassFees;
            
            IsActive = false;
            if (Save() && License.Save())
            {
                return License.LicenseID;
            }
            return -1;
        }
        public int ReplaceForDamage(int CreatedByUserID, string Notes)
        {
            clsApplication Application = new clsApplication();
            Application.ApplicationDate = DateTime.Now;
            Application.LastStatusDate = DateTime.Now;
            Application.ApplicantPersonID = DriverInfo.PersonID;
            Application.ApplicationStatus = clsApplication.enApplicationStatus.Complete;
            Application.ApplicationTypeID = clsApplicationType.enApplicationType.eReplacmentForDamagedDL;
            Application.CreatedByUserID = CreatedByUserID;
            Application.PaidFees = clsApplicationType.FindApplicationTypeByID(clsApplicationType.enApplicationType.eReplacmentForDamagedDL).ApplicationTypeFees;
            if (!Application.Save()) return -1;
            return _RenewAccordingToTheReason(Application.ApplicationID, enIssueReason.eDamagedReplacement, CreatedByUserID, Notes);
        }
        public int ReplaceForLost(int CreatedByUserID, string Notes)
        {
            clsApplication Application = new clsApplication();
            Application.ApplicationDate = DateTime.Now;
            Application.LastStatusDate = DateTime.Now;
            Application.ApplicantPersonID = DriverInfo.PersonID;
            Application.ApplicationStatus = clsApplication.enApplicationStatus.Complete;
            Application.ApplicationTypeID = clsApplicationType.enApplicationType.eReplacmentForLostDL;
            Application.CreatedByUserID = CreatedByUserID;
            Application.PaidFees = clsApplicationType.FindApplicationTypeByID(clsApplicationType.enApplicationType.eReplacmentForLostDL).ApplicationTypeFees;
            if (!Application.Save()) return -1;
            return _RenewAccordingToTheReason(Application.ApplicationID, enIssueReason.LostReplacement, CreatedByUserID, Notes);
        }
        public int Renew(int CreatedByUserID, string Notes)
        {
            clsApplication Application = new clsApplication();
            Application.ApplicationDate = DateTime.Now;
            Application.LastStatusDate = DateTime.Now;
            Application.ApplicantPersonID = DriverInfo.PersonID;
            Application.ApplicationStatus = clsApplication.enApplicationStatus.Complete;
            Application.ApplicationTypeID = clsApplicationType.enApplicationType.eRenewLDL;
            Application.CreatedByUserID = CreatedByUserID;
            Application.PaidFees = clsApplicationType.FindApplicationTypeByID(clsApplicationType.enApplicationType.eRenewLDL).ApplicationTypeFees;
            if (!Application.Save()) return -1;
            return _RenewAccordingToTheReason(Application.ApplicationID, enIssueReason.eRenew, CreatedByUserID, Notes);
        }
        public bool Release(int CreatedByUserID)
        {
            if (DetainLicenseInfo.Release(CreatedByUserID))
            {
                return true;
            }
            return false;
        }
        public bool Detain(int CreatedByUserID, decimal FineFees)
        {
            if (IsDetained()) return false;

            clsDetainLicense DetainLicense = new clsDetainLicense();
            DetainLicense.CreatedByUserID = CreatedByUserID;
            DetainLicense.DetainDate = DateTime.Now;
            DetainLicense.FineFees = FineFees;
            DetainLicense.LicenseID = LicenseID;
            DetainLicense.IsReleased = false;
            DetainLicense.ReleaseApplicationID = null;
            DetainLicense.ReleaseDate = null;
            DetainLicense.ReleasedByUserID = null;
            if (!DetainLicense.Save()) return false;

            return true;
        }

    }
}
