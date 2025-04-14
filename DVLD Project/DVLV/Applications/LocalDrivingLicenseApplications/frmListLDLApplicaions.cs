using DVLD.Global_Classes;
using DVLD.LocalLicenses;
using DVLD.Tests.Type_Tests;
using DVLD_BusinessLayer;
using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace DVLD.Applications.LocalDrivingLicenseApplications
{
    public partial class frmListLDLApplicaions : Form
    {
        private DataTable _dtListLocalDrivingLicenseApplications;
        public frmListLDLApplicaions()
        {
            InitializeComponent();
        }

        private void frmListLocalDrivingLicenseApplicaions_Load(object sender, EventArgs e)
        {
            _RefreshListLocalDrivingLicenseApplications();
            _FillComboBoxLicenseClasses();
            _FillComboBoxStatus();
            cbFilterBy.SelectedIndex = 0;
            cbStatus.SelectedIndex = 0;
            cbLicenseClasses.SelectedIndex = 0;
            tbFilterValue.Text = "";

            cbLicenseClasses.Visible = false;
            cbStatus.Visible = false;
            tbFilterValue.Visible = false;
        }
        private void _RefreshListLocalDrivingLicenseApplications()
        {
            _dtListLocalDrivingLicenseApplications = clsLocalDrivingLicenseApplication.GetAllLocalDrivingLicenseApplications();
            dgvLocalDrivingLicenseApplications.DataSource = _dtListLocalDrivingLicenseApplications;
            dgvLocalDrivingLicenseApplications.Refresh();
            _FormatDataGridView();
            lblNumberOfRecords.Text = dgvLocalDrivingLicenseApplications.RowCount.ToString();
        }
        private void _FormatDataGridView()
        {
            dgvLocalDrivingLicenseApplications.Columns["LocalDrivingLicenseApplicationID"].HeaderText = "L.D.L App ID";
            dgvLocalDrivingLicenseApplications.Columns["LocalDrivingLicenseApplicationID"].Width = 100;

            dgvLocalDrivingLicenseApplications.Columns["ClassName"].HeaderText = "Driving Class";
            dgvLocalDrivingLicenseApplications.Columns["ClassName"].Width = 200;

            dgvLocalDrivingLicenseApplications.Columns["NationalNO"].HeaderText = "National NO.";
            dgvLocalDrivingLicenseApplications.Columns["NationalNO"].Width = 100;

            dgvLocalDrivingLicenseApplications.Columns["FullName"].HeaderText = "Full Name";
            dgvLocalDrivingLicenseApplications.Columns["FullName"].Width = 300;

            dgvLocalDrivingLicenseApplications.Columns["ApplicationDate"].HeaderText = "Application Date";
            dgvLocalDrivingLicenseApplications.Columns["ApplicationDate"].Width = 150;

            dgvLocalDrivingLicenseApplications.Columns["PassedTestCount"].HeaderText = "Passed Tests";
            dgvLocalDrivingLicenseApplications.Columns["PassedTestCount"].Width = 100;

            dgvLocalDrivingLicenseApplications.Columns["Status"].HeaderText = "Status";
            dgvLocalDrivingLicenseApplications.Columns["Status"].Width = 100;
        }

        private void _FillComboBoxStatus()
        {
            cbStatus.Items.Clear();
            cbStatus.Items.Add("All");
            cbStatus.Items.Add(clsApplication.enApplicationStatus.New);
            cbStatus.Items.Add(clsApplication.enApplicationStatus.Cancel);
            cbStatus.Items.Add(clsApplication.enApplicationStatus.Complete);
        }
        private void _FillComboBoxLicenseClasses()
        {
            cbLicenseClasses.Items.Clear();
            DataTable LicenseClasses = clsLicenseClass.GetAllLicenseClasses();
            foreach (DataRow Row in LicenseClasses.Rows)
            {
                cbLicenseClasses.Items.Add(Row["ClassName"].ToString());
            }
        }
        private void cbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            _FilterListLDLApplications(_GetFilterColumnName(), cbStatus.Text.Trim());
        }

        private void cbLicenseClasses_SelectedIndexChanged(object sender, EventArgs e)
        {
            _FilterListLDLApplications(_GetFilterColumnName(), cbLicenseClasses.Text.Trim());
        }

        private void tbFilterValue_TextChanged(object sender, EventArgs e)
        {
            _FilterListLDLApplications(_GetFilterColumnName(), tbFilterValue.Text.Trim());
        }

        private string _GetFilterColumnName()
        {
            if (cbFilterBy.Text == "None") return "None";
            if (cbFilterBy.Text == "LDL Application ID") return "LocalDrivingLicenseApplicationID";
            if (cbFilterBy.Text == "Driving Class") return "ClassName";
            if (cbFilterBy.Text == "National NO") return "NationalNO";
            if (cbFilterBy.Text == "Full Name") return "FullName";
            if (cbFilterBy.Text == "Passed Tests") return "PassedTestCount";
            if (cbFilterBy.Text == "Status") return "Status";
            return "";
        }
        private void _FilterListLDLApplications(string FilterColumn, string FilterValue)
        {
            if (FilterColumn == "None" || FilterValue == "")
                _dtListLocalDrivingLicenseApplications.DefaultView.RowFilter = "";
            else if (FilterColumn == "LocalDrivingLicenseApplicationID" || FilterColumn == "PassedTestCount")
            {
                _dtListLocalDrivingLicenseApplications.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, FilterValue);
            }
            else
                _dtListLocalDrivingLicenseApplications.DefaultView.RowFilter = string.Format("[{0}] like '{1}%'", FilterColumn, FilterValue);

            lblNumberOfRecords.Text = dgvLocalDrivingLicenseApplications.RowCount.ToString();
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilterBy.Text == "None")
            {
                cbStatus.Visible = false;
                cbLicenseClasses.Visible = false;
                tbFilterValue.Visible = false;
            }
            else if (cbFilterBy.Text == "Driving Class")
            {
                cbStatus.Visible = false;
                cbLicenseClasses.Visible = true;
                tbFilterValue.Visible = false;
            }
            else if (cbFilterBy.Text == "Status")
            {
                cbStatus.Visible = true;
                cbLicenseClasses.Visible = false;
                tbFilterValue.Visible = false;
            }
            else
            {
                cbStatus.Visible = false;
                cbLicenseClasses.Visible = false;
                tbFilterValue.Visible = true;
            }

            tbFilterValue.Text = "";
            cbStatus.SelectedIndex = 0;
            cbLicenseClasses.SelectedIndex = 0;
            _FilterListLDLApplications("None", "");
        }

        private void btnAddNewLocalDrivingLicenseApplication_Click(object sender, EventArgs e)
        {
            frmAddUpdateLDLApplication form = new frmAddUpdateLDLApplication();
            form.ShowDialog();

            _RefreshListLocalDrivingLicenseApplications();
        }

        private void smiAddNewLocalDrivingLicenseApplication_Click(object sender, EventArgs e)
        {
            frmAddUpdateLDLApplication form = new frmAddUpdateLDLApplication();
            form.ShowDialog();

            _RefreshListLocalDrivingLicenseApplications();
        }

        private void smiEditLDLApp_Click(object sender, EventArgs e)
        {
            int LDLAppID = (int)dgvLocalDrivingLicenseApplications.SelectedRows[0].Cells["LocalDrivingLicenseApplicationID"].Value;
            frmAddUpdateLDLApplication form = new frmAddUpdateLDLApplication(LDLAppID);
            form.ShowDialog();

            _RefreshListLocalDrivingLicenseApplications();
        }

        private void cmsLDLApp_Opening(object sender, CancelEventArgs e)
        {
            if (dgvLocalDrivingLicenseApplications.RowCount == 0)
            {
                cmsLDLApp.Enabled = false;
                return;
            }

            int LDLAppID = (int)dgvLocalDrivingLicenseApplications.SelectedRows[0].Cells["LocalDrivingLicenseApplicationID"].Value;
            int numberOfPassedTests = (int)dgvLocalDrivingLicenseApplications.SelectedRows[0].Cells["PassedTestCount"].Value;
            clsLocalDrivingLicenseApplication LDLApp = clsLocalDrivingLicenseApplication.FindLocalDrivingLicenseApplicationByID(LDLAppID);
            
            if (LDLApp.ApplicationStatus != clsApplication.enApplicationStatus.New)
            {
                smiCancelLDLApp.Enabled = false;
                smiDeleteLDLApp.Enabled = false;
                smiEditLDLApp.Enabled = false;
                smiScheduleTest.Enabled = LDLApp.ApplicationStatus == clsApplication.enApplicationStatus.Complete;
                smiIssueDrivingLicenseForFirstTime.Enabled = false;
            }
            else
            {
                smiCancelLDLApp.Enabled = true;
                smiDeleteLDLApp.Enabled = true;
                smiEditLDLApp.Enabled = true;
                smiScheduleTest.Enabled = true;
                smiIssueDrivingLicenseForFirstTime.Enabled = (numberOfPassedTests == 3);
            }
        }
        private void smiDeleteLDLApp_Click(object sender, EventArgs e)
        {
            int LDLAppID = (int)dgvLocalDrivingLicenseApplications.SelectedRows[0].Cells["LocalDrivingLicenseApplicationID"].Value;
            DialogResult dr = MessageBox.Show($"Are you sure you want to delete local driving license application with ID = {LDLAppID} ? ", "Confirm!", MessageBoxButtons.YesNo);
            bool isDeleted = false;
            if (dr == DialogResult.Yes)
            {
                isDeleted = clsLocalDrivingLicenseApplication.FindLocalDrivingLicenseApplicationByID(LDLAppID).Delete();
                if (isDeleted) MessageBox.Show("Local driving license application is deleted successfully", "Delete LDL.App", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else MessageBox.Show("Error: Local driving license application is not deleted", "Delete LDL.App", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            _RefreshListLocalDrivingLicenseApplications();
        }

        private void smiCancelLDLApp_Click(object sender, EventArgs e)
        {
            int LDLAppID = (int)dgvLocalDrivingLicenseApplications.SelectedRows[0].Cells["LocalDrivingLicenseApplicationID"].Value;
            clsLocalDrivingLicenseApplication LDLApp = clsLocalDrivingLicenseApplication.FindLocalDrivingLicenseApplicationByID(LDLAppID);
            if(LDLApp.SetCancel()) MessageBox.Show("Local driving license application is canceled successfully", "Cancel LDL.App", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else MessageBox.Show("Error: Local driving license application is not canceled", "Cancel LDL.App", MessageBoxButtons.OK, MessageBoxIcon.Error);
            _RefreshListLocalDrivingLicenseApplications();
        }

        private void smiLDLApplicationInfo_Click(object sender, EventArgs e)
        {
            int LDLAppID = (int)dgvLocalDrivingLicenseApplications.SelectedRows[0].Cells["LocalDrivingLicenseApplicationID"].Value;
            Form frm = new frmShowLDLApplicationInfo(LDLAppID);
            frm.ShowDialog();
        }

        private void smiScheduleVisionTest_Click(object sender, EventArgs e)
        {
            int LDLAppID = (int)dgvLocalDrivingLicenseApplications.SelectedRows[0].Cells["LocalDrivingLicenseApplicationID"].Value;
            Form frm = new frmScheduleTest(clsTestType.enTestType.Vision, LDLAppID);
            frm.ShowDialog();
            _RefreshListLocalDrivingLicenseApplications();
        }

        private void smiScheduleWrittenTest_Click(object sender, EventArgs e)
        {
            int LDLAppID = (int)dgvLocalDrivingLicenseApplications.SelectedRows[0].Cells["LocalDrivingLicenseApplicationID"].Value;
            Form frm = new frmScheduleTest(clsTestType.enTestType.Written, LDLAppID);
            frm.ShowDialog();
            _RefreshListLocalDrivingLicenseApplications();
        }

        private void smiScheduleParticalTest_Click(object sender, EventArgs e)
        {
            int LDLAppID = (int)dgvLocalDrivingLicenseApplications.SelectedRows[0].Cells["LocalDrivingLicenseApplicationID"].Value;
            Form frm = new frmScheduleTest(clsTestType.enTestType.Partical, LDLAppID);
            frm.ShowDialog();
            _RefreshListLocalDrivingLicenseApplications();
        }

        private void smiIssueDrivingLicenseForFirstTime_Click(object sender, EventArgs e)
        {
            int LDLApplicationID = (int)dgvLocalDrivingLicenseApplications.SelectedRows[0].Cells["LocalDrivingLicenseApplicationID"].Value;
            Form frm = new frmIssueLicenseForFirstTime(LDLApplicationID);
            frm.ShowDialog();
            _RefreshListLocalDrivingLicenseApplications();
        }

        private void tbFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            string FilterColumn = _GetFilterColumnName();
            switch (FilterColumn)
            {
                case "LocalDrivingLicenseApplicationID":
                case "PassedTestCount":
                    e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
                    break;
                default:
                    e.Handled = false;
                    break;
            }
        }
    }
}
