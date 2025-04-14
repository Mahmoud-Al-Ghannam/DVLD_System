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

namespace DVLD.LocalLicenses
{
    public partial class frmIssueLicenseForFirstTime : Form
    {
        private int _LDLApplicationID;
        private clsLocalDrivingLicenseApplication _LDLApplication;
        public frmIssueLicenseForFirstTime(int LDLApplicationID)  
        {
            InitializeComponent();
            _LDLApplicationID = LDLApplicationID;
            _LDLApplication = clsLocalDrivingLicenseApplication.FindLocalDrivingLicenseApplicationByID(_LDLApplicationID);
            if(_LDLApplication == null)
            {
                MessageBox.Show($"Error: Local driving license application with ID = {LDLApplicationID} is not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnIssue.Enabled = false;
            }
            ctrlLDLApplicationInfo1.LoadInfo(_LDLApplicationID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            string Notes;
            if(tbNote.Text.Trim().Length == 0)
            {
                Notes = null;
            } else
            {
                Notes = tbNote.Text.Trim();
            }

            int LicenseID = _LDLApplication.IssueLicenseForFirstTime(Notes,clsGlobalClass.CurrentUser.UserID);
            if(LicenseID == -1)
            {
                MessageBox.Show("Error: License is not issued", "Issue License", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else
            {
                MessageBox.Show("License is issued successfully", "Issue License", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnIssue.Enabled = false;
                ctrlLDLApplicationInfo1.LoadInfo(_LDLApplicationID);
            }
        }
    }
}
