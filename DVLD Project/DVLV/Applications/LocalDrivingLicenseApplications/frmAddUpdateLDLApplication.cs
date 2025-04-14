using DVLD_BusinessLayer;
using DVLD.Global_Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Applications.LocalDrivingLicenseApplications
{
    public partial class frmAddUpdateLDLApplication : Form
    {
        private int _LDLApplicationID;
        private clsLocalDrivingLicenseApplication _LDLApplication;
        public enum enMode { Update = 1, AddNew = 2 };
        private enMode _Mode;
        public frmAddUpdateLDLApplication(int LDLApplicationID = -1)
        {
            InitializeComponent();
            _FillComboBoxOfLicenseClasses();
            cbLicenseClasses.SelectedIndex = 0;

            if (!clsLocalDrivingLicenseApplication.IsLocalDrivingLicenseApplicationExistByID(LDLApplicationID))
            {
                _LDLApplicationID = -1;
                _LoadForAddNew();
            }
            else
            {
                _LDLApplicationID = LDLApplicationID;
                _LoadForUpdate();
            }
        }

        private void _LoadForAddNew()
        {
            _Mode = enMode.AddNew;
            lblTitle.Text = "Add New Local Driving License Application";
            this.Text = "Add Local Driving License Application Form";
            _LDLApplication = new clsLocalDrivingLicenseApplication();
            _LDLApplication.CreatedByUserID = clsGlobalClass.CurrentUser.UserID;
            _LDLApplication.ApplicationTypeID = clsApplicationType.enApplicationType.eNewLDL;
            _LDLApplication.ApplicationDate = DateTime.Now;
            _LDLApplication.ApplicationStatus = clsApplication.enApplicationStatus.New;
            _LDLApplication.LastStatusDate = DateTime.Now;
            _LDLApplication.PaidFees = _LDLApplication.ApplicationTypeInfo.ApplicationTypeFees;
            _LoadDataToControls();
        }
        private void _LoadForUpdate()
        {
            _Mode = enMode.Update;
            lblTitle.Text = "Update Local Driving License Application";
            this.Text = "Update Local Driving License Application Form";
            _LDLApplication = clsLocalDrivingLicenseApplication.FindLocalDrivingLicenseApplicationByID(_LDLApplicationID);
            _LoadDataToControls();
        }
        private void _FillComboBoxOfLicenseClasses()
        {
            DataTable LicenseClasses = clsLicenseClass.GetAllLicenseClasses();
            foreach (DataRow Row in LicenseClasses.Rows)
            {
                cbLicenseClasses.Items.Add(Row["ClassName"].ToString());
            }
        }
        private void _LoadDataToControls()
        {
            if (_Mode == enMode.Update) PersonCardWithFilter.LoadInfo(_LDLApplication.ApplicantPersonID);
            lblApplicationDate.Text = _LDLApplication.ApplicationDate.ToString("yyyy MMM dd hh:mm:ss");
            if (_Mode == enMode.Update) lblLDLApplicationID.Text = _LDLApplication.LocalDrivingLicenseApplicationID.ToString();
            lblPaidFees.Text = _LDLApplication.PaidFees.ToString();
            lblCreatedBy.Text = _LDLApplication.CreatedByUserInfo.Username;
            if (_Mode == enMode.Update) cbLicenseClasses.SelectedIndex = cbLicenseClasses.FindString(_LDLApplication.LicenseClassInfo.ClassName);
        }

        private void _LoadDataToLDLApplicationObject()
        {
            _LDLApplication.ApplicantPersonID = PersonCardWithFilter.PersonID;
            _LDLApplication.LicenseClassID = clsLicenseClass.GetLicenseClassIDByClassName(cbLicenseClasses.Text);
        }

        private bool _IsDataValidated()
        {
            clsPerson Person = PersonCardWithFilter.SelectedPerson;
            if (Person == null)
            {
                MessageBox.Show("You have to select a person", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (_Mode == enMode.AddNew && clsPerson.DoesPersonHaveLicenseWithLicenseClass(Person.PersonID, _LDLApplication.LicenseClassID))
            {
                MessageBox.Show($"Person with ID = {Person.PersonID} has already license with class = {cbLicenseClasses.Text}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (PersonCardWithFilter.PersonID == -1)
            {
                MessageBox.Show("Error: You have to select a person", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _LoadDataToLDLApplicationObject();
            if (!_IsDataValidated()) return;

            if (_LDLApplication.Save())
            {
                _LDLApplicationID = _LDLApplication.LocalDrivingLicenseApplicationID;
                _LoadForUpdate();
                MessageBox.Show("Local Driving License is saved successfully", "Local Driving License Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error: Local Driving License is not added successfully", "LDL Save", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
    }
}
