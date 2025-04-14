using DVLD_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BusinessLayer
{
    public class clsTestType
    {
        public enum enMode { eAddNew = 1, eUpdate = 2 };
        public enum enTestType { Vision = 1, Written = 2, Partical = 3, Unknown = -1 };
        
        public enTestType TestTypeID { get; private set; }
        public string TestTypeTitle { get; set; }
        public string TestTypeDescription { get; set; }
        public decimal TestTypeFees { get; set; }
        public enMode Mode { get; private set; }

        public string TestTypeText
        {
            get 
            {
                if (TestTypeID == enTestType.Vision) return "Vision Test";
                if (TestTypeID == enTestType.Written) return "Written Test";
                if (TestTypeID == enTestType.Partical) return "Partical Test";
                return "Unknow";
            }
        }
        

        public clsTestType()
        {
            Mode = enMode.eAddNew;
            TestTypeID = enTestType.Unknown;
            TestTypeTitle = TestTypeDescription = "";
            TestTypeFees = 0;
        }

        private clsTestType(enTestType TestTypeID, string TestTypeTitle, string TestTypeDescription,decimal TestTypeFees)
        {
            Mode = enMode.eUpdate;
            this.TestTypeID = TestTypeID;
            this.TestTypeTitle = TestTypeTitle;
            this.TestTypeDescription = TestTypeDescription;
            this.TestTypeFees = TestTypeFees;
        }


        private bool _AddNew()
        {
            TestTypeID = (enTestType) clsDataTestType.AddNewTestType(TestTypeTitle, TestTypeDescription,TestTypeFees);
            return (TestTypeID != enTestType.Unknown);
        }

        private bool _Update()
        {
            return clsDataTestType.UpdateTestType((int) TestTypeID, TestTypeTitle, TestTypeDescription, TestTypeFees);
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

        public static clsTestType FindTestTypeByID(enTestType TestTypeID)
        {
            if (!clsDataTestType.IsTestTypeExistByID((int)TestTypeID)) return null;

            string TestTypeTitle = "", TestTypeDescription = "";
            decimal TestTypeFees = 0;

            bool Found = clsDataTestType.GetAllTestTypeInfoByID((int)TestTypeID, ref TestTypeTitle, ref TestTypeDescription, ref TestTypeFees);
            if (Found)
            {
                return new clsTestType(TestTypeID, TestTypeTitle, TestTypeDescription,TestTypeFees);
            }
            return null;
        }

        public bool Delete()
        {
            if (clsDataTestType.DeleteTestType((int)TestTypeID))
            {
                Mode = enMode.eAddNew;
                TestTypeID = enTestType.Unknown;
                return true;
            }
            return false;
        }
        public static DataTable GetAllTestTypes()
        {
            return clsDataTestType.GetAllTestTypes();
        }
        
    }
}
