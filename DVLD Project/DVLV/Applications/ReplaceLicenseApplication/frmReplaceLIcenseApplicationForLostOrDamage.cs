using DVLD.Applications.ReplaceLicenseApplication.Controls;
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

namespace DVLD.Applications.ReplaceLicenseApplication
{
    public partial class frmReplaceLIcenseApplicationForLostOrDamage : Form
    {
        private int _OldLicenseID;
        private int _NewLicenseID;

        private clsLicense _OldLicense, _NewLicense;
        public frmReplaceLIcenseApplicationForLostOrDamage(int LicenseID=-1)
        {
            InitializeComponent();
            if (!clsLicense.IsLicenseExistByID(LicenseID)) LicenseID = -1;
            if (LicenseID != -1)
            {
                _OldLicenseID = LicenseID;
                _OldLicense = clsLicense.FindLicenseByID(_OldLicenseID);
                ctrlLicenseInfoWithFilter1.LoadInfo(LicenseID);
                ctrlLicenseInfoWithFilter1.FilterEnabled = false;
            }
        }

        private void ctrlLicenseInfoWithFilter1_On_LicenseSelected(object sender, Licenses.LocalLicenses.Controls.ctrlLicenseInfoWithFilter.LicenseEventArgs e)
        {
            _OldLicenseID = e.LicenseID;
            _OldLicense = clsLicense.FindLicenseByID(e.LicenseID);
            if (_OldLicense == null) _OldLicenseID = -1;
            ctrlReplaceLicenseApplicationInfo1.ResetInfo();
            btnReplace.Enabled = true;
            if (rbReplaceForDamage.Checked) ctrlReplaceLicenseApplicationInfo1.LoadInfo(_OldLicenseID, ctrlReplaceLicenseApplicationInfo.enReplaceFor.Damage);
            else ctrlReplaceLicenseApplicationInfo1.LoadInfo(_OldLicenseID, ctrlReplaceLicenseApplicationInfo.enReplaceFor.Lost);
        }

        private void rbReplaceForDamage_CheckedChanged(object sender, EventArgs e)
        {
            if(rbReplaceForDamage.Checked) ctrlReplaceLicenseApplicationInfo1.LoadInfo(_OldLicenseID, ctrlReplaceLicenseApplicationInfo.enReplaceFor.Damage);
            else ctrlReplaceLicenseApplicationInfo1.LoadInfo(_OldLicenseID, ctrlReplaceLicenseApplicationInfo.enReplaceFor.Lost);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnReplace_Click(object sender, EventArgs e)
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

            if(rbReplaceForDamage.Checked)
            {
                _NewLicenseID = _OldLicense.ReplaceForDamage(clsGlobalClass.CurrentUser.UserID, Notes);
            } else
            {
                _NewLicenseID = _OldLicense.ReplaceForLost(clsGlobalClass.CurrentUser.UserID, Notes);
            }
            if (_NewLicenseID == -1)
            {
                MessageBox.Show($"Error: The license was not replaced", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _NewLicense = clsLicense.FindLicenseByID(_NewLicenseID);
            ctrlReplaceLicenseApplicationInfo1.LoadInfo(_OldLicenseID,_NewLicenseID);

            btnReplace.Enabled = false;
        }
    }
}
