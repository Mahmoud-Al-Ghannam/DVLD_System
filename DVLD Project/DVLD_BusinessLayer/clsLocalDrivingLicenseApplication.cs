using DVLD_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BusinessLayer
{
    public class clsLocalDrivingLicenseApplication : clsApplication
    {
        public int LocalDrivingLicenseApplicationID { get; private set; }

        private int _LicenseClassID;
        public int LicenseClassID { 
            get { return _LicenseClassID; }
            set
            {
                _LicenseClassID = value;
                LicenseClassInfo = clsLicenseClass.FindLicenseClassByID(value);
            }
        }

        public clsLicenseClass LicenseClassInfo {  get; private set; }
        public enum enMode { eAddNew = 1, eUpdate = 2 };
        public enMode Mode { get; private set; }

        public clsLicense LicenseInfo {  get; private set; }
        public clsLocalDrivingLicenseApplication() : base()
        {
            Mode = enMode.eAddNew;
            LocalDrivingLicenseApplicationID = LicenseClassID = -1;
        }

        private clsLocalDrivingLicenseApplication(int ApplicationID, int ApplicantPersonID, DateTime ApplicationDate, clsApplicationType.enApplicationType ApplicationTypeID,
            enApplicationStatus ApplicationStatus, DateTime LastStatusDate, decimal PaidFees, int CreatedByUserID , int LocalDrivingLicenseApplicationID,int LicenseClassID)
        : base(ApplicationID, ApplicantPersonID, ApplicationDate, ApplicationTypeID,
            ApplicationStatus, LastStatusDate, PaidFees, CreatedByUserID)
        {

            Mode = enMode.eUpdate;
            this.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            this.LicenseClassID = LicenseClassID;
            LicenseInfo = clsLicense.FindLicenseByLocalDrivingLicenseApplicationID(LocalDrivingLicenseApplicationID);
        }


        private bool _AddNew()
        {
            if (!base._AddNew()) return false;
            LocalDrivingLicenseApplicationID = clsDataLocalDrivingLicenseApplication.AddNewLocalDrivingLicenseApplication(ApplicationID,LicenseClassID);
            return (LocalDrivingLicenseApplicationID != -1);
        }

        private bool _Update()
        {
            if (!base._Update()) return false;
            return clsDataLocalDrivingLicenseApplication.UpdateLocalDrivingLicenseApplication(LocalDrivingLicenseApplicationID, ApplicationID, LicenseClassID);
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

        public static clsLocalDrivingLicenseApplication FindLocalDrivingLicenseApplicationByID(int LocalDrivingLicenseApplicationID)
        {
            if (!clsDataLocalDrivingLicenseApplication.IsLocalDrivingLicenseApplicationExistByID(LocalDrivingLicenseApplicationID)) return null;

            int ApplicationID = -1, LicenseClassID = -1;
            int ApplicantPersonID = -1, CreatedByUserID = -1, ApplicationTypeID = -1;
            DateTime LastStatusDate = DateTime.MinValue;
            DateTime ApplicationDate = DateTime.MinValue;
            decimal PaidFees = 0;
            byte ApplicationStatus = 0;

            bool Found = clsDataLocalDrivingLicenseApplication.GetAllLocalDrivingLicenseApplicationInfoByID(LocalDrivingLicenseApplicationID,ref ApplicationID,ref LicenseClassID);
            if (Found)
            {
                bool Found1 = clsDataApplication.GetAllApplicationInfoByID(ApplicationID,ref ApplicantPersonID,ref ApplicationDate,ref ApplicationTypeID,
                    ref ApplicationStatus,ref LastStatusDate,ref PaidFees,ref CreatedByUserID);
                if (!Found1) return null;
                return new clsLocalDrivingLicenseApplication(ApplicationID,ApplicantPersonID,ApplicationDate,(clsApplicationType.enApplicationType) ApplicationTypeID,
                    (enApplicationStatus) ApplicationStatus,LastStatusDate,PaidFees,CreatedByUserID,LocalDrivingLicenseApplicationID,LicenseClassID);
            }
            return null;
        }

        public static bool IsLocalDrivingLicenseApplicationExistByID (int LocalDrivingLicenseApplicationID)
        {
            return clsDataLocalDrivingLicenseApplication.IsLocalDrivingLicenseApplicationExistByID(LocalDrivingLicenseApplicationID);
        }
        public bool Delete()
        { 
            if (clsDataLocalDrivingLicenseApplication.DeleteLocalDrivingLicenseApplication(LocalDrivingLicenseApplicationID))
            {
                Mode = enMode.eAddNew;
                LocalDrivingLicenseApplicationID = -1;
                if(!base.Delete()) return false;
                return true;
            }
            return false;
        }
        public static DataTable GetAllLocalDrivingLicenseApplications()
        {
            return clsDataLocalDrivingLicenseApplication.GetAllLocalDrivingLicenseApplications();
        }
        
        public static int GetNumberOfPassedTests(int LocalDrivingLicenseApplicationID)
        {
            return clsDataLocalDrivingLicenseApplication.GetNumberOfPassedTests(LocalDrivingLicenseApplicationID);
        }
        public int GetNumberOfPassedTests()
        {
            return GetNumberOfPassedTests(LocalDrivingLicenseApplicationID);
        }

        public static bool DoesPassTestType(int LocalDrivingLicenseApplicationID, clsTestType.enTestType TestTypeID)
        {
            int NumberOfPassedTests = GetNumberOfPassedTests(LocalDrivingLicenseApplicationID);
            if (TestTypeID == clsTestType.enTestType.Vision) return NumberOfPassedTests >= 1;
            if (TestTypeID == clsTestType.enTestType.Written) return NumberOfPassedTests >= 2;
            if (TestTypeID == clsTestType.enTestType.Partical) return NumberOfPassedTests >= 3;
            return false;

        }
        public bool DoesPassTestType (clsTestType.enTestType TestTypeID)
        {
            return DoesPassTestType(LocalDrivingLicenseApplicationID , TestTypeID);
        }

        public static bool DoesPassAllTests (int LocalDrivingLicenseApplicationID)
        {
            return GetNumberOfPassedTests(LocalDrivingLicenseApplicationID) == 3;
        }
        public bool DoesPassAllTests ()
        {
            return DoesPassAllTests(LocalDrivingLicenseApplicationID);
        }
        
        public static int GetAnActiveTestAppointment (int LocalDrivingLicenseApplicationID , clsTestType.enTestType TestTypeID)
        {
            return clsTestAppointment.GetAnActiveTestAppointmentForLocalDrivingLicenseApplication(LocalDrivingLicenseApplicationID, TestTypeID);
        }
        public int GetAnActiveTestAppointment(clsTestType.enTestType TestTypeID)
        {
            return GetAnActiveTestAppointment(LocalDrivingLicenseApplicationID,TestTypeID); 
        }
        public int IssueLicenseForFirstTime(string Notes, int CreatedByUserID)
        {
            if (ApplicationStatus != enApplicationStatus.New) return -1;

            clsLicense License = new clsLicense();
            License.Notes = Notes;
            License.CreatedByUserID = CreatedByUserID;
            License.LicenseClassID = LicenseClassID;
            License.ApplicationID = ApplicationID;
            License.IssueDate = DateTime.Now;
            License.ExpirationDate = DateTime.Now.AddYears(License.LicenseClassInfo.DefaultValidityLength);
            License.IssueReason = clsLicense.enIssueReason.eFirstTime;
            License.IsActive = true;
            License.PaidFees = License.LicenseClassInfo.ClassFees;

            clsDriver Driver = clsDriver.FindDriverByPersonID(License.ApplicationInfo.ApplicantPersonID);
            if(Driver != null)
            {
                License.DriverID = Driver.DriverID;
            } else
            {
                Driver = new clsDriver();
                Driver.PersonID = License.ApplicationInfo.ApplicantPersonID;
                Driver.CreatedByUserID = CreatedByUserID;
                Driver.CreatedDate = DateTime.Now;
                if (Driver.Save()) License.DriverID = Driver.DriverID;
                else return -1;
            }

            if (License.Save())
            {
                LicenseInfo = License;
                SetComplete();
                return License.LicenseID;
            }
            return -1;
        }
    }
}
