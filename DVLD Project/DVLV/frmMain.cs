using DVLD.Applications;
using DVLD.Applications.DetainedLicense;
using DVLD.Applications.LocalDrivingLicenseApplications;
using DVLD.Applications.RenewLicenseApplication;
using DVLD.Applications.ReplaceLicenseApplication;
using DVLD.Drivers;
using DVLD.Global_Classes;
using DVLD.People;
using DVLD.Tests.TestTypes;
using DVLD.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD
{
    public partial class frmMain : System.Windows.Forms.Form
    {
        private frmLogin _LoginForm;
        public frmMain(frmLogin LoginForm)
        {
            InitializeComponent();
            _LoginForm = LoginForm;
        }

        private void peopleToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmListPeople form = new frmListPeople();
            form.MdiParent = this;
            form.Show();
        }

        private void smiUsers_Click(object sender, EventArgs e)
        {
            frmListUsers form = new frmListUsers();
            form.MdiParent = this;
            form.Show();
        }

        private void smiCurrentUserInfo_Click(object sender, EventArgs e)
        {
            frmShowUserInfo form = new frmShowUserInfo(clsGlobalClass.CurrentUser.UserID);
            form.ShowDialog();
        }

        private void smiChangePassword_Click(object sender, EventArgs e)
        {
            frmChangePasswordOfUser form = new frmChangePasswordOfUser(clsGlobalClass.CurrentUser.UserID);
            form.ShowDialog();
        }

        private void smiSignOut_Click(object sender, EventArgs e)
        {
            clsGlobalClass.CurrentUser = null;
            _LoginForm.Show();
            Close();
        }

        private void smiDrivers_Click(object sender, EventArgs e)
        {
            frmListDrivers form = new frmListDrivers();
            form.MdiParent = this;
            form.Show();
        }

        private void manageApplicationTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListApplicationTypes form = new frmListApplicationTypes();
            form.MdiParent = this;
            form.Show();
        }

        private void smiManageLocalDrivingLicenseApplications_Click(object sender, EventArgs e)
        {
            frmListLDLApplicaions form = new frmListLDLApplicaions();
            form.MdiParent = this;
            form.Show();
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            _LoginForm.Show();
        }

        private void smiAddNewLocalDrivingLicenseApplication_Click(object sender, EventArgs e)
        {
            frmAddUpdateLDLApplication form = new frmAddUpdateLDLApplication();
            form.MdiParent = this;
            form.Show();
        }

        private void smiManageTestTypes_Click(object sender, EventArgs e)
        {
            frmListTestTypes form = new frmListTestTypes();
            form.MdiParent = this;
            form.Show();
        }

        private void renewDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmRenewLicenseApplication();
            frm.ShowDialog();
        }

        private void replaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmReplaceLIcenseApplicationForLostOrDamage();
            frm.ShowDialog();
        }

        private void retakeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmListLDLApplicaions();
            frm.ShowDialog();
        }

        private void manageDetainedLicensesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmListDetainedLicenses();
            frm.ShowDialog();
        }

        private void smiDetainLicense_Click(object sender, EventArgs e)
        {
            Form frm = new frmDetainReleaseLicense(frmDetainReleaseLicense.enMode.Detain);
            frm.ShowDialog();
        }

        private void smiReleaseDetainedLicense_Click(object sender, EventArgs e)
        {
            Form frm = new frmDetainReleaseLicense(frmDetainReleaseLicense.enMode.Release);
            frm.ShowDialog();
        }

        private void smiReleaseDetainedDrivingLicense_Click(object sender, EventArgs e)
        {
            Form frm = new frmDetainReleaseLicense(frmDetainReleaseLicense.enMode.Release);
            frm.ShowDialog();
        }

        private void smiAddNewInternationalLicense_Click(object sender, EventArgs e)
        {
            MessageBox.Show("It is not implemented yet", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void smiManageInternationalLicenseApplications_Click(object sender, EventArgs e)
        {
            MessageBox.Show("It is not implemented yet", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
