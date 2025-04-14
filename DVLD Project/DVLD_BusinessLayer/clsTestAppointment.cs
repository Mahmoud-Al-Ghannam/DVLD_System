using DVLD_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BusinessLayer
{
    public class clsTestAppointment
    {
        public int TestAppointmentID { get; private set; }

        private clsTestType.enTestType _TestTypeID;
        public clsTestType.enTestType TestTypeID { 
            get { return _TestTypeID; }
            set
            {
                _TestTypeID = value;
                TestTypeInfo = clsTestType.FindTestTypeByID(value);
            }
        }
        public clsTestType TestTypeInfo { get;private set; }

        private int _LocalDrivingLicenseApplicationID;
        public int LocalDrivingLicenseApplicationID 
        {
            get { return _LocalDrivingLicenseApplicationID;} 
            set
            {
                _LocalDrivingLicenseApplicationID = value;
                LocalDrivingLicenseApplicationInfo = clsLocalDrivingLicenseApplication.FindLocalDrivingLicenseApplicationByID(value);
            } 
        }

        public clsLocalDrivingLicenseApplication LocalDrivingLicenseApplicationInfo { get; private set; }
        public DateTime AppointmentDate { get; set; }
        public decimal PaidFees { get; set; }

        private int _CreatedByUserID;
        public int CreatedByUserID {
            get { return _CreatedByUserID; }
            set
            {
                _CreatedByUserID = value;
                CreatedByUserInfo = clsUser.FindUserByID(value);
            }
        }
        public clsUser CreatedByUserInfo { get; private set; }
        public bool IsLocked { get; private set; }

        private Nullable<int> _RetakeTestApplicationID;
        public Nullable<int> RetakeTestApplicationID 
        { get { return _RetakeTestApplicationID; } 
           set
            {
                _RetakeTestApplicationID = value;
                if(value != null) RetakeTestApplicationInfo = clsApplication.FindApplicationByID(value.Value);
                else RetakeTestApplicationInfo = null;
            }
        }

        public clsApplication RetakeTestApplicationInfo {  get; private set; }
       
        public enum enMode { eAddNew = 1, eUpdate = 2 };
        public enMode Mode { get; private set; }

        public clsTestAppointment()
        {
            Mode = enMode.eAddNew;
            RetakeTestApplicationID = null;
            CreatedByUserID = LocalDrivingLicenseApplicationID = TestAppointmentID = -1;
            TestTypeID = clsTestType.enTestType.Unknown;
            PaidFees = 0;
            IsLocked = false;
            AppointmentDate = DateTime.MinValue;
        }

        private clsTestAppointment(int TestAppointmentID, clsTestType.enTestType TestTypeID, int LocalDrivingLicenseApplicationID, DateTime AppointmentDate, decimal PaidFees, int CreatedByUserID,
            bool IsLocked, Nullable<int> RetakeTestApplicationID)
        {
            Mode = enMode.eUpdate;
            this.TestAppointmentID = TestAppointmentID;
            this.TestTypeID = TestTypeID;
            this.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            this.AppointmentDate = AppointmentDate;
            this.PaidFees = PaidFees;
            this.CreatedByUserID = CreatedByUserID;
            this.IsLocked = IsLocked;
            this.RetakeTestApplicationID = RetakeTestApplicationID;
        }


        private bool _AddNew()
        {
            if(!CanAddANewTestAppointmentForLocalDrivingLicneseApplictaion(TestTypeID,LocalDrivingLicenseApplicationID)) return false;
            _RetakeATestApplicationWhenAddNewTestAppointment();
            TestAppointmentID = clsDataTestAppointment.AddNewTestAppointment((int) TestTypeID, LocalDrivingLicenseApplicationID, AppointmentDate, PaidFees, CreatedByUserID, IsLocked,RetakeTestApplicationID);
            return (TestAppointmentID != -1);
        }

        private bool _Update()
        {
            return clsDataTestAppointment.UpdateTestAppointment(TestAppointmentID,(int) TestTypeID, LocalDrivingLicenseApplicationID, AppointmentDate, PaidFees, CreatedByUserID, IsLocked,RetakeTestApplicationID);
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

        public static clsTestAppointment FindTestAppointmentByID(int TestAppointmentID)
        {
            if (!clsDataTestAppointment.IsTestAppointmentExistByID(TestAppointmentID)) return null;

            int TestTypeID = 0, LocalDrivingLicenseApplicationID = 0, CreatedByUserID = 0;
            Nullable<int> RetakeTestApplicationID = 0;
            bool IsLocked = false;
            DateTime AppointmentDate = DateTime.Now;
            decimal PaidFees = 0;

            bool Found = clsDataTestAppointment.GetAllTestAppointmentInfoByID(TestAppointmentID, ref TestTypeID, ref LocalDrivingLicenseApplicationID, ref AppointmentDate, ref PaidFees, ref CreatedByUserID, ref IsLocked, ref RetakeTestApplicationID);
            if (Found)
            {
                return new clsTestAppointment(TestAppointmentID,(clsTestType.enTestType) TestTypeID, LocalDrivingLicenseApplicationID, AppointmentDate, PaidFees, CreatedByUserID, IsLocked,RetakeTestApplicationID);
            }
            return null;
        }

        public static bool IsTestAppointmentExistByID(int TestAppointmentID)
        {
            return clsDataTestAppointment.IsTestAppointmentExistByID(TestAppointmentID);
        }
        public bool Delete()
        {
            if (clsDataTestAppointment.DeleteTestAppointment(TestAppointmentID))
            {
                Mode = enMode.eAddNew;
                TestAppointmentID = -1;
                return true;
            }
            return false;
        }
        public static DataTable GetAllTestAppointments()
        {
            return clsDataTestAppointment.GetAllTestAppointments();
        }
        public override string ToString()
        {
            string str = $"TestAppointment (TestAppointmentID={TestAppointmentID},TestTypeID={TestTypeID},LocalDrivingLicenseApplicationID={LocalDrivingLicenseApplicationID},AppointmentDate={AppointmentDate},PaidFees={PaidFees},CreatedByUserID={CreatedByUserID},IsLocked={IsLocked},RetakeTestApplicationID=";
            if (RetakeTestApplicationID == null) str += "Null";
            else str += RetakeTestApplicationID.ToString();
            str += ")";
            return str;
        }

        public static bool CanAddANewTestAppointmentForLocalDrivingLicneseApplictaion(clsTestType.enTestType TestTypeID, int LocalDrivingLicenseApplicationID)
        {
            if (clsLocalDrivingLicenseApplication.DoesPassTestType(LocalDrivingLicenseApplicationID, TestTypeID)) return false;
            if (GetAnActiveTestAppointmentForLocalDrivingLicenseApplication(LocalDrivingLicenseApplicationID, TestTypeID) != -1) return false;
            return true;
        }

        public static int GetAnActiveTestAppointmentForLocalDrivingLicenseApplication(int LocalDrivingLicenseApplicationID, clsTestType.enTestType TestTypeID)
        {
            return clsDataTestAppointment.GetAnActiveTestAppointmentForLocalDrivingLicenseApplication(LocalDrivingLicenseApplicationID, (int) TestTypeID);
        }
        public static DataTable GetAllTestAppointmentsAccordingToTestTypeAndLDLApplication(clsTestType.enTestType TestTypeID, int LocalDrivingLicenseApplicationID)
        {
            return clsDataTestAppointment.GetAllTestAppointmentsAccordingToTestTypeAndLDLApplication((int)TestTypeID, LocalDrivingLicenseApplicationID);
        }

        public static bool IsThereAnyTestAppointmentForLocalDrivingLicenseApplication(clsTestType.enTestType TestTypeID, int LocalDrivingLicenseApplicationID)
        {
            return clsDataTestAppointment.IsThereAnyTestAppointmentAccordingToTestTypeAndLDLApplication((int)TestTypeID, LocalDrivingLicenseApplicationID);
        }

        public static bool UpdateAppointmentDate(int TestAppointmentID, DateTime AppointmentDate)
        {
            return clsDataTestAppointment.UpdateAppointmentDate(TestAppointmentID, AppointmentDate);
        }

        public bool UpdateAppointmentDate(DateTime AppointmentDate)
        {
            return UpdateAppointmentDate(TestAppointmentID, AppointmentDate);
        }
    
        private int _RetakeATestApplicationWhenAddNewTestAppointment  ()
        {
            if (!IsThereAnyTestAppointmentForLocalDrivingLicenseApplication(TestTypeID, LocalDrivingLicenseApplicationID)) return -1;

            clsApplication RetakeTestApplication = new clsApplication();
            RetakeTestApplication.ApplicantPersonID = LocalDrivingLicenseApplicationInfo.ApplicantPersonID;
            RetakeTestApplication.ApplicationDate = DateTime.Now;
            RetakeTestApplication.LastStatusDate = DateTime.Now;
            RetakeTestApplication.ApplicationTypeID = clsApplicationType.enApplicationType.eRetakeTest;
            RetakeTestApplication.ApplicationStatus = clsApplication.enApplicationStatus.Complete;
            RetakeTestApplication.PaidFees = RetakeTestApplication.ApplicationTypeInfo.ApplicationTypeFees;
            RetakeTestApplication.CreatedByUserID = CreatedByUserID;

            if (RetakeTestApplication.Save())
            {
                RetakeTestApplicationID = RetakeTestApplication.ApplicationID;
                return RetakeTestApplication.ApplicationID;
            }
            throw new Exception("Error: Retake a test application is not saved");
        }
        public int TakeATest (bool TestResult , string Notes , int CreatedByUserID)
        {
            if (IsLocked) return -1;

            clsTest Test = new clsTest();
            Test.Notes = Notes;
            Test.TestResult = TestResult;
            Test.CreatedByUserID = CreatedByUserID;
            Test.TestAppointmentID = TestAppointmentID;

            if (Test.Save()) return Test.TestID;
            return -1;
        }
    }
}
