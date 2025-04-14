using DVLD_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BusinessLayer
{
    public class clsApplication
    {
        public int ApplicationID { get; private set; }

        private int _ApplicantPersonID;
        public int ApplicantPersonID
        {
            get { return _ApplicantPersonID; }
            set
            {
                _ApplicantPersonID = value;
                ApplicantPersonInfo = clsPerson.FindPersonByID(value);
            }
        }
        public clsPerson ApplicantPersonInfo { get;private set; }


        public DateTime ApplicationDate { get; set; }

        private clsApplicationType.enApplicationType _ApplicationTypeID;
        public clsApplicationType.enApplicationType ApplicationTypeID
        {
            get { return _ApplicationTypeID; }
            set
            {
                _ApplicationTypeID = value;
                ApplicationTypeInfo = clsApplicationType.FindApplicationTypeByID(value);
            }
        }
        public clsApplicationType ApplicationTypeInfo {  get; private set; }
        
        public enApplicationStatus ApplicationStatus { get;set; }
        public DateTime LastStatusDate { get; set; }
        public decimal PaidFees { get; set; }
        
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

        public enum enMode { eAddNew = 1, eUpdate = 2 }
        public enum enApplicationStatus {New = 1,Cancel=2,Complete=3 }
        public enMode Mode { get; private set; }

        public clsApplication()
        {
            Mode = enMode.eAddNew;
            ApplicationID = ApplicantPersonID = CreatedByUserID = -1;
            ApplicationTypeID = clsApplicationType.enApplicationType.Unknown;
            ApplicationDate = LastStatusDate = DateTime.Now;
            PaidFees = 0;
            ApplicationStatus = enApplicationStatus.New;
        }

        protected clsApplication(int ApplicationID,int ApplicantPersonID,DateTime ApplicationDate,clsApplicationType.enApplicationType ApplicationTypeID,
            enApplicationStatus ApplicationStatus,DateTime LastStatusDate,decimal PaidFees,int CreatedByUserID)
        {
            Mode = enMode.eUpdate;
            this.ApplicationID = ApplicationID;
            this.ApplicantPersonID = ApplicantPersonID;
            this.ApplicationDate = ApplicationDate;
            this.ApplicationTypeID = ApplicationTypeID;
            this.ApplicationStatus = ApplicationStatus;
            this.LastStatusDate = LastStatusDate;
            this.PaidFees = PaidFees;
            this.CreatedByUserID = CreatedByUserID;
        }


        protected bool _AddNew()
        {
            ApplicationID = clsDataApplication.AddNewApplication(ApplicantPersonID,ApplicationDate,(int) ApplicationTypeID,Convert.ToByte(ApplicationStatus),LastStatusDate,PaidFees,CreatedByUserID);
            return (ApplicationID != -1);
        }

        protected bool _Update()
        {
            return clsDataApplication.UpdateApplication(ApplicationID, ApplicantPersonID, ApplicationDate, (int)ApplicationTypeID, Convert.ToByte(ApplicationStatus), LastStatusDate, PaidFees, CreatedByUserID);
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

        public static clsApplication FindApplicationByID(int ApplicationID)
        {
            if (!clsDataApplication.IsApplicationExistByID(ApplicationID)) return null;

            int ApplicantPersonID = -1, CreatedByUserID = -1, ApplicationTypeID = -1;
            DateTime LastStatusDate = DateTime.MinValue;
            DateTime ApplicationDate = DateTime.MinValue;
            decimal PaidFees = 0;
            byte ApplicationStatus = 0;

            bool Found = clsDataApplication.GetAllApplicationInfoByID(ApplicationID,ref ApplicantPersonID,ref ApplicationDate,ref ApplicationTypeID,ref ApplicationStatus,ref LastStatusDate,ref PaidFees,ref CreatedByUserID);
            if (Found)
            {
                return new clsApplication(ApplicationID,ApplicantPersonID,ApplicationDate,(clsApplicationType.enApplicationType) ApplicationTypeID,(enApplicationStatus)ApplicationStatus,LastStatusDate,PaidFees,CreatedByUserID);
            }
            return null;
        }

        public bool Delete()
        {
            if (clsDataApplication.DeleteApplication(ApplicationID))
            {
                Mode = enMode.eAddNew;
                ApplicationID = -1;
                return true;
            }
            return false;
        }
        public static DataTable GetAllApplications()
        {
            return clsDataApplication.GetAllApplications();
        }

        public bool SetCancel ()
        {
            if(ApplicationStatus == clsApplication.enApplicationStatus.Complete) return false;
            if (ApplicationStatus == clsApplication.enApplicationStatus.Cancel) return true;
            return clsDataApplication.UpdateStatus(ApplicationID, (int)clsApplication.enApplicationStatus.Cancel);
        }

        public bool SetComplete ()
        {
            if (ApplicationStatus == clsApplication.enApplicationStatus.Cancel) return false;
            if (ApplicationStatus == clsApplication.enApplicationStatus.Complete) return true;
            return clsDataApplication.UpdateStatus(ApplicationID, (int)clsApplication.enApplicationStatus.Complete);
        }

        public static int GetAnActiveApplicationIDForPersonAndApplicationType (int ApplicantPersonID,clsApplicationType.enApplicationType ApplicationTypeID)
        {
            return clsDataApplication.GetAnActiveApplicationIDForPersonAndApplicationType(ApplicantPersonID,(int)ApplicationTypeID);
        }

    }
}
