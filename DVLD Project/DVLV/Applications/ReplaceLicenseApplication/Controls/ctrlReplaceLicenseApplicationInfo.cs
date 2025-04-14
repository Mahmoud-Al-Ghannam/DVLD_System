using DVLD.Global_Classes;
using DVLD.Licenses.LocalLicenses;
using DVLD_BusinessLayer;
using System;
using System.Windows.Forms;

namespace DVLD.Applications.ReplaceLicenseApplication.Controls
{
    public partial class ctrlReplaceLicenseApplicationInfo : UserControl
    {
        public enum enReplaceFor { Renew=1,Lost=2,Damage=3 }
        public enReplaceFor ReplaceFor { get; private set; }
        public int OldLicenseID { get;private set; }    
        public clsLicense OldLicense { get;private set; }

        public int NewLicenseID { get; private set; }
        public clsLicense NewLicense { get; private set; }

        public string Note
        {
            get { return tbNote.Text.Trim(); }
        }

        public ctrlReplaceLicenseApplicationInfo()
        {
            InitializeComponent();
        }

        public void LoadInfo(int OldLicenseID , enReplaceFor ReplaceFor) // before create a new license
        {
            if(!clsLicense.IsLicenseExistByID(OldLicenseID))
            {
                MessageBox.Show($"Error: The license with ID = {OldLicenseID} is not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ResetInfo();
            } else
            {
                this.OldLicenseID = OldLicenseID;
                this.ReplaceFor = ReplaceFor;
                _FillInfo();
            }
        }

        public void LoadInfo (int OldLicenseID , int NewLicenseID) // after create a new license
        {
            if(!clsLicense.IsLicenseExistByID(OldLicenseID) || !clsLicense.IsLicenseExistByID(NewLicenseID))
            {
                ResetInfo();
                return;
            }
            this.OldLicenseID = OldLicenseID;
            this.NewLicenseID = NewLicenseID;
            OldLicense = clsLicense.FindLicenseByID(OldLicenseID);
            NewLicense = clsLicense.FindLicenseByID(NewLicenseID);

            ctrlBasicApplicationInfo.LoadInfo(NewLicense.ApplicationID);
            lblOldLicenseID.Text = OldLicenseID.ToString();
            lblNewLicenseID.Text = NewLicenseID.ToString();
            lblLicenseClass.Text = NewLicense.LicenseClassInfo.ClassName;
            lblLicenseFees.Text = NewLicense.LicenseClassInfo.ClassFees.ToString();
            lblIssueDate.Text = NewLicense.IssueDate.ToString("yyyy MMM dd hh:mm:ss");
            lblExpirtationDate.Text = NewLicense.ExpirationDate.ToString("yyyy MMM dd hh:mm:ss");
            tbNote.Text = NewLicense.Notes;
            tbNote.Enabled = false;

            llblNewLicenseInfo.Enabled = true;
        }

        public void ResetInfo()
        {
            NewLicenseID = OldLicenseID = -1;
            NewLicense = OldLicense = null;
            ctrlBasicApplicationInfo.ResetInfo();
            llblNewLicenseInfo.Enabled = false;
            lblNewLicenseID.Text = "[?????]";
            lblOldLicenseID.Text = "[?????]";
            lblLicenseClass.Text = "[?????]";
            lblLicenseFees.Text = "[?????]";
            lblIssueDate.Text = "[?????]";
            lblExpirtationDate.Text = "[?????]";
            tbNote.Text = "";
            tbNote.Enabled = true;
        }

        private void _FillInfo()
        {
            OldLicense = clsLicense.FindLicenseByID(OldLicenseID);
            if(OldLicense == null)
            {
                ResetInfo();
                return;
            }

            ctrlBasicApplicationInfo.Field_ApplicationDate = DateTime.Now.ToString("yyyy MMM dd hh:mm:ss");
            ctrlBasicApplicationInfo.Field_ApplicantPersonID = OldLicense.DriverInfo.PersonID;
            ctrlBasicApplicationInfo.Field_CreatedByUser = clsGlobalClass.CurrentUser.Username;
            clsApplicationType ApplicationTypeTemp = null ;
            switch(ReplaceFor)
            {
                case enReplaceFor.Renew:
                    ApplicationTypeTemp = clsApplicationType.FindApplicationTypeByID(clsApplicationType.enApplicationType.eRenewLDL);
                    break;
                case enReplaceFor.Damage:
                    ApplicationTypeTemp = clsApplicationType.FindApplicationTypeByID(clsApplicationType.enApplicationType.eReplacmentForDamagedDL);
                    break;
                case enReplaceFor.Lost:
                    ApplicationTypeTemp = clsApplicationType.FindApplicationTypeByID(clsApplicationType.enApplicationType.eReplacmentForLostDL);
                    break;
            }

            ctrlBasicApplicationInfo.Field_ApplicationType = ApplicationTypeTemp.ApplicationTypeText;
            ctrlBasicApplicationInfo.Field_ApplicationFees = ApplicationTypeTemp.ApplicationTypeFees.ToString();


            lblOldLicenseID.Text = OldLicenseID.ToString();
            lblLicenseClass.Text = OldLicense.LicenseClassInfo.ClassName;
            lblLicenseFees.Text = OldLicense.LicenseClassInfo.ClassFees.ToString();
            lblIssueDate.Text = DateTime.Now.ToString("yyyy MMM dd hh:mm:ss");
            lblExpirtationDate.Text = DateTime.Now.AddYears(OldLicense.LicenseClassInfo.DefaultValidityLength).ToString("yyyy MMM dd hh:mm:ss");
            llblNewLicenseInfo.Enabled = false;

        }

        private void llblNewLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!clsLicense.IsLicenseExistByID(NewLicenseID)) return;
            Form frm = new frmShowLicenseInfo(NewLicenseID);
            frm.ShowDialog();
        }
    }
}
