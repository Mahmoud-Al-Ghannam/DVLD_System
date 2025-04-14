using DVLD.Global_Classes;
using DVLD_BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Applications.RenewLicenseApplication
{
    public partial class frmRenewLicenseApplication : Form
    {
        private int _OldLicenseID;
        private int _NewLicenseID;

        private clsLicense _OldLicense, _NewLicense;
        public frmRenewLicenseApplication(int LicenseID = -1)
        {
            InitializeComponent();
            if (!clsLicense.IsLicenseExistByID(LicenseID)) LicenseID = -1;
            if (LicenseID != -1)
            {
                _OldLicenseID = LicenseID;
                _OldLicense = clsLicense.FindLicenseByID(_OldLicenseID);
                ctrlLicenseInfoWithFilter1.LoadInfo(LicenseID);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ctrlLicenseInfoWithFilter1_On_LicenseSelected(object sender, Licenses.LocalLicenses.Controls.ctrlLicenseInfoWithFilter.LicenseEventArgs e)
        {
            _OldLicenseID = e.LicenseID;
            _OldLicense = clsLicense.FindLicenseByID(e.LicenseID);
            if (_OldLicense == null) _OldLicenseID = -1;
            ctrlReplaceLicenseApplicationInfo1.ResetInfo();
            btnRenew.Enabled = true;
            ctrlReplaceLicenseApplicationInfo1.LoadInfo(_OldLicenseID, ReplaceLicenseApplication.Controls.ctrlReplaceLicenseApplicationInfo.enReplaceFor.Renew);
        }

        private void btnRenew_Click(object sender, EventArgs e)
        {
            string Notes = ctrlReplaceLicenseApplicationInfo1.Note;
            if (Notes.Length == 0) Notes = null;

            if (_OldLicense == null)
            {
                MessageBox.Show("Please,select a license to replace it", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!_OldLicense.IsActive)
            {
                MessageBox.Show($"The license with ID = {_OldLicenseID} is not active, so you can't replace it", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_OldLicense.ExpirationDate > DateTime.Now)
            {
                MessageBox.Show($"The license with ID = {_OldLicenseID} has not expired yet", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _NewLicenseID = _OldLicense.Renew(clsGlobalClass.CurrentUser.UserID, Notes);
            if (_NewLicenseID == -1)
            {
                MessageBox.Show($"Error: The license was not renewed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _NewLicense = clsLicense.FindLicenseByID(_NewLicenseID);
            ctrlReplaceLicenseApplicationInfo1.LoadInfo(_OldLicenseID,_NewLicenseID);
            btnRenew.Enabled = false;
        }
    }
}
