using DVLD_BusinessLayer;
using DVLD.People;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using DVLD.Global_Classes;
using System.Security.Policy;

namespace DVLD.Applications.Controls
{
    public partial class ctrlBasicApplicationInfo : UserControl
    {
        public class ApplicationEventArgs : EventArgs
        {
            public int PersonID { get; }
            public ApplicationEventArgs(int PersonID)
            {
                this.PersonID = PersonID;
            }
        }
        public event EventHandler<ApplicationEventArgs> On_LoadedApplicationInfo;
        private void _RaiseEventOnLoadedApplicationInfo(ApplicationEventArgs e)
        {
            if (On_LoadedApplicationInfo != null)
                On_LoadedApplicationInfo?.Invoke(this, e);
        }

        public clsApplication SelectedApplication { get; private set; }
        public int ApplicationID { get; private set; }

        public string Field_ApplicationStatus
        {
            get { return lblApplicationStatus.Text; }
            set { lblApplicationStatus.Text = value; }
        }

        public string Field_ApplicationType
        {
            get { return lblApplicationType.Text; }
            set { lblApplicationType.Text = value; }
        }

        public string Field_ApplicationDate
        {
            get { return lblApplicationDate.Text; }
            set { lblApplicationDate.Text = value; }
        }

        public string Field_LastStatusDate
        {
            get { return lblLastStatusDate.Text; }
            set { lblLastStatusDate.Text = value; }
        }

        public string Field_ApplicationFees
        {
            get { return lblPaidFees.Text; }
            set { lblPaidFees.Text = value; }
        }
        public string Field_CreatedByUser
        {
            get { return lblCreatedByUser.Text; }
            set { lblCreatedByUser.Text = value; }
        }
        public int? Field_ApplicantPersonID
        {
            get
            {
                if (clsValidation.IsInteger(lblApplicantPersonID.Text.Trim())) 
                    return Convert.ToInt32(lblApplicantPersonID.Text.Trim());
                return null;
            }
            set
            {
                if (!value.HasValue) lblApplicantPersonID.Text = "[?????]";
                else lblApplicantPersonID.Text = value.Value.ToString();
            }
        }
        public ctrlBasicApplicationInfo()
        {
            InitializeComponent();
        }

        public void LoadInfo(int ApplicationID)
        {
            SelectedApplication = clsApplication.FindApplicationByID(ApplicationID);

            if (SelectedApplication == null)
            {
                MessageBox.Show($"Error: The application with ID = {ApplicationID} is not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.ApplicationID = -1;
                ResetInfo();
            }
            else
            {
                this.ApplicationID = SelectedApplication.ApplicationID;
                _FillInfo();
            }
        }

        public void ResetInfo()
        {
            SelectedApplication = null;
            ApplicationID = -1;

            lblApplicationID.Text = "[?????]";
            lblApplicationType.Text = "[?????]";
            lblCreatedByUser.Text = "[?????]";
            lblApplicantPersonID.Text = "[?????]";
            lblPaidFees.Text = "[?????]";
            lblApplicationStatus.Text = "[?????]";
            lblApplicationDate.Text = "[?????]";
            lblLastStatusDate.Text = "[?????]";
            llblPersonInfo.Enabled = false;
        }

        private void _FillInfo()
        {
            lblApplicationID.Text = SelectedApplication.ApplicationID.ToString();
            lblApplicationType.Text = SelectedApplication.ApplicationTypeInfo.ApplicationTypeTitle;
            lblCreatedByUser.Text = SelectedApplication.CreatedByUserInfo.Username;
            lblApplicantPersonID.Text = SelectedApplication.ApplicantPersonID.ToString();
            lblPaidFees.Text = SelectedApplication.PaidFees.ToString();
            lblApplicationStatus.Text = SelectedApplication.ApplicationStatus.ToString();
            lblApplicationDate.Text = SelectedApplication.ApplicationDate.ToString("yyyy MMM dd hh:mm:ss");
            lblLastStatusDate.Text = SelectedApplication.LastStatusDate.ToString("yyyy MMM dd hh:mm:ss");

            llblPersonInfo.Enabled = true;
        }
        private void llblPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (SelectedApplication == null) return;

            Form frm = new frmShowPersonInfo(SelectedApplication.ApplicantPersonID);
            frm.ShowDialog();
            LoadInfo(ApplicationID);
        }
    }
}
