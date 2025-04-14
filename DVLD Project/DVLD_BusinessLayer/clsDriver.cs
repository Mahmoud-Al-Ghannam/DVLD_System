using DVLD_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BusinessLayer
{
    public class clsDriver
    {
        public int DriverID { get; private set; }

        private int _PersonID;
        public int PersonID
        {
            get { return _PersonID; }
            set
            {
                _PersonID = value;
                PersonInfo = clsPerson.FindPersonByID(value);
            }
        }
        public clsPerson PersonInfo { get; private set; }
        
        
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


        public DateTime CreatedDate { get; set; }


        public enum enMode { eAddNew = 1, eUpdate = 2 };
        public enMode Mode { get; private set; }

        public clsDriver()
        {
            Mode = enMode.eAddNew;
            PersonID = CreatedByUserID = DriverID = -1;
            CreatedDate = DateTime.MinValue;
        }

        private clsDriver(int DriverID,int PersonID,int CreatedByUserID,DateTime CreatedDate)
        {
            Mode = enMode.eUpdate;
            this.DriverID = DriverID;
            this.PersonID = PersonID;
            this.CreatedByUserID = CreatedByUserID;
            this.CreatedDate = CreatedDate;
        }

        private bool _AddNew()
        {
            DriverID = clsDataDriver.AddNewDriver(PersonID,CreatedByUserID,CreatedDate);
            return (DriverID != -1);
        }

        private bool _Update()
        {
            return clsDataDriver.UpdateDriver(DriverID, PersonID, CreatedByUserID, CreatedDate);
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

        public static clsDriver FindDriverByID(int DriverID)
        {
            if (!clsDataDriver.IsDriverExistByID(DriverID)) return null;

            int PersonID = -1,CreatedByUserID=-1;
            DateTime CreatedDate = DateTime.Now;

            bool Found = clsDataDriver.GetAllDriverInfoByID(DriverID,ref PersonID,ref CreatedByUserID,ref CreatedDate);
            if (Found)
            {
                return new clsDriver(DriverID,PersonID,CreatedByUserID,CreatedDate);
            }
            return null;
        }
        public static clsDriver FindDriverByPersonID(int PersonID)
        {
            if (!clsDataDriver.IsDriverExistByPersonID(PersonID)) return null;

            int DriverID = -1, CreatedByUserID = -1;
            DateTime CreatedDate = DateTime.Now;

            bool Found = clsDataDriver.GetAllDriverInfoByPersonID(PersonID, ref DriverID, ref CreatedByUserID, ref CreatedDate);
            if (Found)
            {
                return new clsDriver(DriverID, PersonID, CreatedByUserID, CreatedDate);
            }
            return null;
        }

        public static bool IsDriverExistByID (int DriverID)
        {
            return clsDataDriver.IsDriverExistByID (DriverID);
        }
        public bool Delete()
        {
            if (clsDataDriver.DeleteDriver(DriverID))
            {
                Mode = enMode.eAddNew;
                DriverID = -1;
                return true;
            }
            return false;
        }

        public static DataTable GetAllDrivers()
        {
            return clsDataDriver.GetAllDrivers();
        }
    
        public static DataTable GetAllLocalDrivingLicenses (int DriverID)
        {
            return clsLicense.GetAllLocalDrivingLicensesForDriver(DriverID);
        }
        public DataTable GetAllLocalDrivingLicenses()
        {
            return GetAllLocalDrivingLicenses(DriverID);    
        }

        public static DataTable GetAllInternationalDrivingLicenses(int DriverID)
        {
            return clsInternationalLicense.GetAllInternationalLicensesForDriver(DriverID);
        }
        public DataTable GetAllInternationalDrivingLicenses()
        {
            return GetAllInternationalDrivingLicenses(DriverID);
        }
    }
}
