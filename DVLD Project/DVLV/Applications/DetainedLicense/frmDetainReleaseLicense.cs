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

namespace DVLD.Applications.DetainedLicense
{
    public partial class frmDetainReleaseLicense : Form
    {
        public enum enMode { Detain = 1, Release = 2 };
        private enMode _Mode;
        private int _LicenseID;
        private clsLicense _License;
        public frmDetainReleaseLicense(enMode Mode, int LicenseID = -1)
        {
            InitializeComponent();
            ctrlLicenseInfoWithFilter1.FilterEnabled = true;
            _Mode = Mode;

            if (_Mode == enMode.Detain)
            {
                tbFineFees.Enabled = true;
                btnIssue.Text = "Detain";
                lblTitle.Text = "Detain License";
                this.Text = "Detain License Form";
            }
            else
            {
                tbFineFees.Enabled = false;
                btnIssue.Text = "Release";
                lblTitle.Text = "Release Detained License";
                this.Text = "Release License Form";
            }

            if (LicenseID != -1)
            {
                _LicenseID = LicenseID;
                _License = clsLicense.FindLicenseByID(LicenseID);
                ctrlLicenseInfoWithFilter1.LoadInfo(LicenseID);
                ctrlLicenseInfoWithFilter1.FilterEnabled = false;
            }
        }

        private void tbFineFees_TextChanged(object sender, EventArgs e)
        {

            string FineFeesStr = tbFineFees.Text.Trim();
            if (!clsValidation.IsDecimal(FineFeesStr))
            {
                errorProvider1.SetError(tbFineFees, "This field must to be real number");
                tbFineFees.Focus();
                return;
            }
            else
            {
                errorProvider1.SetError(tbFineFees, "");
            }
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            if (_License == null)
            {
                MessageBox.Show("Error: Select license to detain", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!clsValidation.IsDecimal(tbFineFees.Text.Trim()))
            {
                errorProvider1.SetError(tbFineFees, "This field must to be real number");
                tbFineFees.Focus();
                return;
            }

            if (_Mode == enMode.Detain)
            {
                if (_License.Detain(clsGlobalClass.CurrentUser.UserID, Convert.ToDecimal(tbFineFees.Text.Trim())))
                {
                    MessageBox.Show($"License with ID = {_LicenseID} is detained successfully", "Detain License", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    llblDetainLicenseInfo.Enabled = true;
                    tbFineFees.Enabled = false;
                }
                else
                {
                    MessageBox.Show($"Error: License with ID = {_LicenseID} is not detained", "Detain License", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                if (_License.Release(clsGlobalClass.CurrentUser.UserID))
                {
                    MessageBox.Show($"License with ID = {_LicenseID} is released successfully", "Release License", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    llblDetainLicenseInfo.Enabled = false;
                }
                else
                {
                    MessageBox.Show($"Error: License with ID = {_LicenseID} is not released", "Release License", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            btnIssue.Enabled = false;
        }

        private void ctrlLicenseInfoWithFilter1_OnLicenseSelected(object sender, Licenses.LocalLicenses.Controls.ctrlLicenseInfoWithFilter.LicenseEventArgs e)
        {
            _LicenseID = e.LicenseID;
            _License = ctrlLicenseInfoWithFilter1.SelectedLicense;
            if (_License == null) return;

            if (!_License.IsActive)
            {
                MessageBox.Show($"Error: License with ID = {_LicenseID} is not active", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnIssue.Enabled = false;
                return;
            }

            if (_Mode == enMode.Release && !clsLicense.IsDetained(_LicenseID))
            {
                MessageBox.Show($"Error: License with ID = {_LicenseID} is not detained", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnIssue.Enabled = false;
                return;
            }

            if (_Mode == enMode.Detain && clsLicense.IsDetained(_LicenseID))
            {
                MessageBox.Show($"Error: License with ID = {_LicenseID} is already detained", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnIssue.Enabled = false;
                return;
            }
            btnIssue.Enabled = true;

            if (_Mode == enMode.Release)
            {
                llblDetainLicenseInfo.Enabled = true;
                tbFineFees.Enabled = false;
                if (_License.DetainLicenseInfo != null)
                    tbFineFees.Text = _License.DetainLicenseInfo.FineFees.ToString();
            } else
            {
                tbFineFees.Enabled = true;
                llblDetainLicenseInfo.Enabled = false;
            }
        }

        private void llblDetainLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form frm = new frmShowDetainLicenseInfo(_License.DetainLicenseInfo.DetainID);
            frm.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
