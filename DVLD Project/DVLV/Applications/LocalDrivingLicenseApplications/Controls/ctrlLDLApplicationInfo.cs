using DVLD.Licenses.LocalLicenses;
using DVLD_BusinessLayer;
using System;
using System.Windows.Forms;

namespace DVLD.Applications.LocalDrivingLicenseApplications.Controls
{
    public partial class ctrlLDLApplicationInfo : UserControl
    {
        public class LDLApplicationEventArgs : EventArgs
        {
            public int LDLApplicationID { get; }
            public LDLApplicationEventArgs(int LDLApplicationID)
            {
                this.LDLApplicationID = LDLApplicationID;
            }
        }
        public event EventHandler<LDLApplicationEventArgs> On_LoadedLDLApplicationInfo;
        private void _RaiseEventOnLoadedLDLApplicationInfo(LDLApplicationEventArgs e)
        {
            if (On_LoadedLDLApplicationInfo != null)
                On_LoadedLDLApplicationInfo?.Invoke(this, e);
        }

        public clsLocalDrivingLicenseApplication SelectedLDLApplication { get; private set; }
        public int LDLApplicationID { get;private set; }
        public ctrlLDLApplicationInfo()
        {
            InitializeComponent();
        }
        public void LoadInfo(int LDLApplicationID)
        {
            SelectedLDLApplication = clsLocalDrivingLicenseApplication.FindLocalDrivingLicenseApplicationByID(LDLApplicationID);
            if (SelectedLDLApplication == null)
            {
                MessageBox.Show($"Error: The local driving license application with ID = {LDLApplicationID} is not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.LDLApplicationID = -1;
                ResetInfo();
            }
            else
            {
                this.LDLApplicationID = LDLApplicationID;
                _FillInfo();
            }
        }
        public void ResetInfo()
        {
            lblLicenseID.Text = "N/A";
            llblLicenseInfo.Enabled = false;
            lblClassName.Text = "[?????]";
            lblLDLApplicationID.Text = "[?????]";
            lblPassedTestCount.Text = "[?????]";
            ctrlBasicApplicationInfo1.ResetInfo();
        }
        private void _FillInfo ()
        {
            if (SelectedLDLApplication.LicenseInfo == null)
            {
                llblLicenseInfo.Enabled = false;
                lblLicenseID.Text = "N/A";
            }
            else
            {
                llblLicenseInfo.Enabled = true;
                lblLicenseID.Text = SelectedLDLApplication.LicenseInfo.LicenseID.ToString();
            }

            ctrlBasicApplicationInfo1.LoadInfo(SelectedLDLApplication.ApplicationID);

            lblLDLApplicationID.Text = this.LDLApplicationID.ToString();
            lblPassedTestCount.Text = SelectedLDLApplication.GetNumberOfPassedTests().ToString();
            lblClassName.Text = SelectedLDLApplication.LicenseClassInfo.ClassName;
            _RaiseEventOnLoadedLDLApplicationInfo(new LDLApplicationEventArgs(LDLApplicationID));
        }
        private void llblLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (SelectedLDLApplication.LicenseInfo == null) return;
            Form from = new frmShowLicenseInfo(SelectedLDLApplication.LicenseInfo.LicenseID);
            from.ShowDialog();
        }
    }
}
