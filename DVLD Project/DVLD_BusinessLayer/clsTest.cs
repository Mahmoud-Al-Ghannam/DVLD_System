using DVLD_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BusinessLayer
{
    public class clsTest
    {
        public int TestID { get; private set; }

        private int _TestAppointmentID;
        public int TestAppointmentID {
            get { return _TestAppointmentID; } 
            set
            {
                _TestAppointmentID = value;
                TestAppointmentInfo = clsTestAppointment.FindTestAppointmentByID(value);
            }
        }

        public clsTestAppointment TestAppointmentInfo { get; private set; }
        
        public bool TestResult { get; set; }
        public string Notes { get; set; } // It may be Null
        
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

        public clsTest()
        {
            Mode = enMode.eAddNew;
            CreatedByUserID = TestAppointmentID = TestID = -1;
            TestResult = false;
            Notes = null;
        }

        private clsTest(int TestID, int TestAppointmentID, bool TestResult, string Notes, int CreatedByUserID)
        {
            Mode = enMode.eUpdate;
            this.TestID = TestID;
            this.TestAppointmentID = TestAppointmentID;
            this.TestResult = TestResult;
            this.Notes = Notes;
            this.CreatedByUserID = CreatedByUserID;
        }

        private bool _AddNew()
        {
            TestID = clsDataTest.AddNewTest(TestAppointmentID, TestResult, Notes, CreatedByUserID);
            return (TestID != -1);
        }

        private bool _Update()
        {
            return clsDataTest.UpdateTest(TestID, TestAppointmentID, TestResult, Notes, CreatedByUserID);
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

        public static clsTest FindTestByID(int TestID)
        {
            if (!clsDataTest.IsTestExistByID(TestID)) return null;

            int  TestAppointmentID = 0, CreatedByUserID = 0;
            bool TestResult = false;
            string Notes = "";

            bool Found = clsDataTest.GetAllTestInfoByID(TestID, ref TestAppointmentID, ref TestResult, ref Notes, ref CreatedByUserID);
            if (Found)
            {
                return new clsTest(TestID, TestAppointmentID, TestResult, Notes, CreatedByUserID);
            }
            return null;
        }

        public static clsTest FindTestByTestAppointmentID(int TestAppointmentID)
        {

            int TestID = -1, CreatedByUserID = 0;
            bool TestResult = false;
            string Notes = "";

            bool Found = clsDataTest.GetAllTestInfoByTestAppointmentID(TestAppointmentID,ref TestID, ref TestResult, ref Notes, ref CreatedByUserID);
            if (Found)
            {
                return new clsTest(TestID, TestAppointmentID, TestResult, Notes, CreatedByUserID);
            }
            return null;
        }
        public bool Delete()
        {
            if (clsDataTest.DeleteTest(TestID))
            {
                Mode = enMode.eAddNew;
                TestID = -1;
                return true;
            }
            return false;
        }

        public static DataTable GetAllTests()
        {
            return clsDataTest.GetAllTests();
        }

        public static DataTable GetAllTestsAccordingToTestTypeAndLDLApplication(clsTestType.enTestType TestTypeID, int LocalDrivingLicenseApplicationID)
        {
            return clsDataTest.GetAllTestsAccordingToTestTypeAndLDLApplication((int)TestTypeID, LocalDrivingLicenseApplicationID);
        }

        public static bool UpdateNotes (int TestID,string Notes)
        {
            return clsDataTest.UpdateNotes(TestID,Notes);
        }

        public bool UpdateNotes(string Notes)
        {
            return UpdateNotes(TestID, Notes);
        }
    }
}
