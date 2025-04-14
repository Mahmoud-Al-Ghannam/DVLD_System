using DVLD_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BusinessLayer
{
    public class clsApplicationType
    {

        public enum enMode { eAddNew = 1, eUpdate = 2 };
        public enum enApplicationType
        {
            eNewLDL = 1, eRenewLDL = 2, eReplacmentForLostDL = 3, eReplacmentForDamagedDL = 4,
            eReleaseDetainedDL = 5, eNewInternationalLicense = 6, eRetakeTest = 7, Unknown = -1
        }

        public enApplicationType ApplicationTypeID { get; private set; }
        public string ApplicationTypeTitle { get; set; }
        public decimal ApplicationTypeFees { get; set; }
        public enMode Mode { get; private set; }

        public string ApplicationTypeText
        {
            get
            {
                if (ApplicationTypeID == enApplicationType.eNewLDL) return "New Local Driving License Application";
                if (ApplicationTypeID == enApplicationType.eRetakeTest) return "Retake A Test Application";
                if (ApplicationTypeID == enApplicationType.eNewInternationalLicense) return "New International Driving License Application";
                if (ApplicationTypeID == enApplicationType.eReplacmentForLostDL) return "Replacement For Lost Local Driving License Application";
                if (ApplicationTypeID == enApplicationType.eReplacmentForDamagedDL) return "Replacement For Damage Local Driving License Application";
                if (ApplicationTypeID == enApplicationType.eReleaseDetainedDL) return "Release Detained Driving License Application";
                if (ApplicationTypeID == enApplicationType.eRenewLDL) return "Renew Local Driving License Application";
                return "Unknow";
            }
        }

        public clsApplicationType()
        {
            Mode = enMode.eAddNew;
            ApplicationTypeID = enApplicationType.Unknown;
            ApplicationTypeTitle = "";
            ApplicationTypeFees = 0;
        }

        private clsApplicationType(enApplicationType ApplicationTypeID,string ApplicationTypeTitle,decimal ApplicationTypeFees)
        {
            Mode = enMode.eUpdate;
            this.ApplicationTypeID = ApplicationTypeID;
            this.ApplicationTypeTitle = ApplicationTypeTitle;
            this.ApplicationTypeFees = ApplicationTypeFees;
        }

        private bool _AddNew()
        {
            ApplicationTypeID = (enApplicationType) clsDataApplicationType.AddNewApplicationType(ApplicationTypeTitle,ApplicationTypeFees);
            return (ApplicationTypeID != enApplicationType.Unknown);
        }

        private bool _Update()
        {
            return clsDataApplicationType.UpdateApplicationType((int) ApplicationTypeID, ApplicationTypeTitle, ApplicationTypeFees);
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

        public static clsApplicationType FindApplicationTypeByID(enApplicationType ApplicationTypeID)
        {
            if (!clsDataApplicationType.IsApplicationTypeExistByID((int)ApplicationTypeID)) return null;

            decimal ApplicationTypeFees = -1;
            string ApplicationTypeTitle = "";

            bool Found = clsDataApplicationType.GetAllApplicationTypeInfoByID((int)ApplicationTypeID,ref ApplicationTypeTitle,ref ApplicationTypeFees);
            if (Found)
            {
                return new clsApplicationType(ApplicationTypeID,ApplicationTypeTitle,ApplicationTypeFees);
            }
            return null;
        }

        public bool Delete()
        {
            if (clsDataApplicationType.DeleteApplicationType((int)ApplicationTypeID))
            {
                Mode = enMode.eAddNew;
                ApplicationTypeID = enApplicationType.Unknown;
                return true;
            }
            return false;
        }

        public static DataTable GetAllApplicationTypes()
        {
            return clsDataApplicationType.GetAllApplicationTypes();
        }
    }
}
