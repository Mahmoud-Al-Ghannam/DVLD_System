using DVLD_BusinessLayer;
using DVLD.Drivers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using DVLD.Properties;
using System.IO;

namespace DVLD.LocalLicenses.Controls
{
    public partial class ctrlLicenseInfo : UserControl
    {
        public class LicenseEventArgs : EventArgs
        {
            public int LicenseID { get; }
            public LicenseEventArgs(int LicenseID)
            {
                this.LicenseID = LicenseID;
            }
        }
        public event EventHandler<LicenseEventArgs> On_LoadedLicenseInfo;
        private void _RaiseEventOnLoadedLicenseInfo(LicenseEventArgs e)
        {
            if (On_LoadedLicenseInfo != null)
                On_LoadedLicenseInfo?.Invoke(this, e);
        }

        public clsLicense SelectedLicense { get; private set; }
        public int LicenseID { get; private set; }

        public ctrlLicenseInfo()
        {
            InitializeComponent();
        }

        public void LoadInfo (int LicenseID)
        {
            SelectedLicense = clsLicense.FindLicenseByID(LicenseID);
            if(SelectedLicense == null ) 
            {
                MessageBox.Show($"Error: The license with ID = {LicenseID} is not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.LicenseID = -1;
                ResetInfo();
            } else
            {
                this.LicenseID = LicenseID;
                _FillInfo();
            }
        }

        private void _FillInfo ()
        {
            if (SelectedLicense == null)
            {
                ResetInfo();
                return;
            }

            lblName.Text = SelectedLicense.DriverInfo.PersonInfo.FullName;
            lblNationalNO.Text = SelectedLicense.DriverInfo.PersonInfo.NationalNO;
            lblLicenseID.Text = SelectedLicense.LicenseID.ToString();
            lblApplicationID.Text = SelectedLicense.ApplicationID.ToString();
            lblDriverID.Text = SelectedLicense.DriverID.ToString();
            lblCreatedByUser.Text = SelectedLicense.ApplicationInfo.CreatedByUserInfo.Username;
            lblClassName.Text = SelectedLicense.LicenseClassInfo.ClassName;
            lblIsActive.Text = SelectedLicense.IsActive.ToString();
            lblIssueDate.Text = SelectedLicense.IssueDate.ToString();
            lblExpirtationDate.Text = SelectedLicense.ExpirationDate.ToString();
            lblIssueReason.Text = SelectedLicense.IssueReasonText;
            lblNotes.Text = SelectedLicense.Notes;
            lblPaidFees.Text = SelectedLicense.PaidFees.ToString();
            _LoadImage();
            llblDriverInfo.Enabled = true;
            _RaiseEventOnLoadedLicenseInfo(new LicenseEventArgs(LicenseID));
        }
        public void ResetInfo ()
        {
            LicenseID = -1;
            SelectedLicense = null;
            lblName.Text = "[?????]";
            lblNationalNO.Text = "[?????]";
            lblLicenseID.Text = "[?????]";
            lblApplicationID.Text = "[?????]";
            lblDriverID.Text = "[?????]";
            lblCreatedByUser.Text = "[?????]";
            lblClassName.Text = "[?????]";
            lblIsActive.Text = "[?????]";
            lblIssueDate.Text = "[?????]";
            lblExpirtationDate.Text = "[?????]";
            lblIssueReason.Text = "[?????]";
            lblNotes.Text = "[?????]";
            lblPaidFees.Text = "[?????]";
            pbPersonImage.Image = Resources.Male_512;
            llblDriverInfo.Enabled = false;
        }

        private void _LoadImage()
        {
            clsPerson Person = SelectedLicense.DriverInfo.PersonInfo;
            if (Person.Gendor == clsPerson.enGendor.Male)
                pbPersonImage.Image = Resources.Male_512;
            else
                pbPersonImage.Image = Resources.Female_512;

            if (Person.ImagePath != null && Person.ImagePath != "")
            {
                if (File.Exists(Person.ImagePath))
                    pbPersonImage.ImageLocation = Person.ImagePath;
                else
                    MessageBox.Show($"Could not find the image ({Person.ImagePath}) of person", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void llblDriverInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form frm = new frmShowDriverInfo(SelectedLicense.DriverID);
            frm.ShowDialog();
            LoadInfo(LicenseID);
        }

        
    }
}
 