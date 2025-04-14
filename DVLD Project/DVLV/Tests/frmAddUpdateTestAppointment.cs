using DVLD_BusinessLayer;
using DVLD.Global_Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Tests
{
    public partial class frmAddUpdateTestAppointment : Form
    {
        public enum enMode { Update = 1, AddNew = 2 };
        private enMode _Mode;
        private int _TestAppointmentID;
        private clsTestAppointment _TestAppointment;
        public frmAddUpdateTestAppointment(clsTestType.enTestType TestTypeID, int LDLApplicationID) // For Add New
        {
            InitializeComponent();
            _TestAppointmentID = -1;
            _LoadForAddNew(TestTypeID, LDLApplicationID);
        }

        public frmAddUpdateTestAppointment(int TestAppointmentID) // For Update
        {
            InitializeComponent();
            _TestAppointmentID = TestAppointmentID;
            _LoadForUpdate();
        }

        private void _LoadForAddNew(clsTestType.enTestType TestTypeID, int LDLApplicationID)
        {
            _Mode = enMode.AddNew;
            _TestAppointment = new clsTestAppointment();
            _TestAppointment.LocalDrivingLicenseApplicationID = LDLApplicationID;
            lblTitle.Text = "Add New Test Appointment";
            this.Text = "Add Test Appointment Form";
            if (clsTestAppointment.IsThereAnyTestAppointmentForLocalDrivingLicenseApplication(TestTypeID, LDLApplicationID))
            {
                lblRetakeTestFees.Text = clsApplicationType.FindApplicationTypeByID(clsApplicationType.enApplicationType.eRetakeTest).ApplicationTypeFees.ToString();
            }
            else
            {
                lblRetakeTestFees.Text = "0";
            }


            _TestAppointment.TestTypeID = TestTypeID;
            _TestAppointment.AppointmentDate = DateTime.Now;
            _TestAppointment.CreatedByUserID = clsGlobalClass.CurrentUser.UserID;
            _TestAppointment.PaidFees = _TestAppointment.TestTypeInfo.TestTypeFees;
            dtpAppointmentDate.MinDate = DateTime.Now.AddMinutes(-1);
            _TestAppointment.LocalDrivingLicenseApplicationID = LDLApplicationID;

            _LoadDataToControls();
        }

        private void _LoadForUpdate()
        {
            _Mode = enMode.Update;
            lblTitle.Text = "Update Test Appointment";
            this.Text = "Update Test Appointment Form";
            _TestAppointment = clsTestAppointment.FindTestAppointmentByID(_TestAppointmentID);
            dtpAppointmentDate.MinDate = DateTime.Now.AddMinutes(-1);

            _LoadDataToControls();
        }
        private void _LoadDataToControls()
        {
            lblCreatedByUser.Text = _TestAppointment.CreatedByUserInfo.Username;
            if (_Mode == enMode.Update) lblTestAppointmentID.Text = _TestAppointment.TestAppointmentID.ToString();
            lblLDLApplicationID.Text = _TestAppointment.LocalDrivingLicenseApplicationID.ToString();
            dtpAppointmentDate.Value = _TestAppointment.AppointmentDate;
            lblTestType.Text = _TestAppointment.TestTypeInfo.TestTypeTitle;
            lblPaidFees.Text = _TestAppointment.PaidFees.ToString();

            decimal totalFees = _TestAppointment.PaidFees;

            if (_Mode == enMode.Update)
            {
                if (_TestAppointment.RetakeTestApplicationInfo == null)
                {
                    gbRetakeApplicationInfo.Enabled = false;
                    lblRetakeTestFees.Text = "0";
                    lblRetakeTestApplicationID.Text = "N/A";
                }
                else
                {
                    lblRetakeTestApplicationID.Text = _TestAppointment.RetakeTestApplicationID.ToString();
                    lblRetakeTestFees.Text = _TestAppointment.RetakeTestApplicationInfo.ApplicationTypeInfo.ApplicationTypeFees.ToString();
                    totalFees += _TestAppointment.RetakeTestApplicationInfo.PaidFees;
                }
            } else
            {
                if(clsTestAppointment.IsThereAnyTestAppointmentForLocalDrivingLicenseApplication(_TestAppointment.TestTypeID,_TestAppointment.LocalDrivingLicenseApplicationID))
                {
                    lblRetakeTestFees.Text = clsApplicationType.FindApplicationTypeByID(clsApplicationType.enApplicationType.eRetakeTest).ApplicationTypeFees.ToString();
                    totalFees += Convert.ToDecimal(lblRetakeTestFees.Text);
                } else
                {
                    gbRetakeApplicationInfo.Enabled = false;
                    lblRetakeTestFees.Text = "0";
                }
                lblRetakeTestApplicationID.Text = "N/A";
            }
            
            lblTotalFees.Text = totalFees.ToString();
        }

        private void _LoadDataToTestAppointmentObject()
        {
            _TestAppointment.AppointmentDate = dtpAppointmentDate.Value;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _LoadDataToTestAppointmentObject();
            if (_TestAppointment.Save())
            {
                _TestAppointmentID = _TestAppointment.TestAppointmentID;
                _LoadForUpdate();
                MessageBox.Show("Test appointment info is saved successfully", "Save Test Appointment", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error: Test appointment info is not saved", "Save Test Appointment", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
