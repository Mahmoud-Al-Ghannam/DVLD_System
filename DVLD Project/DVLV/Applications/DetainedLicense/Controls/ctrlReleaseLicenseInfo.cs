using DVLD.Global_Classes;
using DVLD.Licenses.LocalLicenses;
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

namespace DVLD.Applications.DetainedLicense.Controls
{
    public partial class ctrlReleaseLicenseInfo : UserControl
    {
        public class DetainEventArgs : EventArgs
        {
            public int DetainID { get; }
            public DetainEventArgs(int DetainID)
            {
                this.DetainID = DetainID;
            }
        }
        public event EventHandler<DetainEventArgs> On_LoadedDetainInfo;
        private void _RaiseEventOnLoadedDetainInfo(DetainEventArgs e)
        {
            if (On_LoadedDetainInfo != null)
                On_LoadedDetainInfo?.Invoke(this, e);
        }
        public int DetainID { get; private set; }
        public clsDetainLicense SelectedDetain { get; private set; } 

        public ctrlReleaseLicenseInfo()
        {
            InitializeComponent();
            ResetInfo();
        }

        public void LoadInfo(int DetainID)
        {
            SelectedDetain = clsDetainLicense.FindDetainLicenseByID(DetainID);
            if (SelectedDetain == null)
            {
                this.DetainID = -1;
                ResetInfo();
            } else
            {
                this.DetainID = DetainID;
                _FillInfo();
            }
        }
        public void ResetInfo ()
        {
            SelectedDetain = null;
            DetainID = -1;

            lblDetainID.Text = "[?????]";
            lblDetainDate.Text = "[?????]";
            lblDetainedByUser.Text = "[?????]";
            lblDetainedLicenseID.Text = "[?????]";
            lblIsReleased.Text = "[?????]";
            lblFineFees.Text = "[?????]";
            lblReleaseApplicationID.Text = "[?????]";
            lblReleaseDate.Text = "[?????]";
            lblReleasedByUser.Text = "[?????]";

            llblDetainedLicenseInfo.Enabled = false;
        }
        private void _FillInfo ()
        {
            lblDetainID.Text = this.DetainID.ToString();
            lblDetainDate.Text = SelectedDetain.DetainDate.ToString("yyyy MMM dd hh:mm:ss");
            lblDetainedByUser.Text = SelectedDetain.CreatedByUserInfo.Username;
            lblDetainedLicenseID.Text = SelectedDetain.LicenseID.ToString();
            lblIsReleased.Text = SelectedDetain.IsReleased.ToString();
            lblFineFees.Text = SelectedDetain.FineFees.ToString();

            if (SelectedDetain.IsReleased)
            {
                lblReleaseApplicationID.Text = SelectedDetain.ReleaseApplicationID.ToString();
                lblReleaseDate.Text = SelectedDetain.ReleaseDate.Value.ToString("yyyy MMM dd hh:mm:ss");
                lblReleasedByUser.Text = SelectedDetain.ReleasedByUserInfo.Username;
            }
            else
            {
                lblReleaseApplicationID.Text = "N/A";
                lblReleaseDate.Text = "N/A";
                lblReleasedByUser.Text = "N/A";
            }
            llblDetainedLicenseInfo.Enabled = true;
            _RaiseEventOnLoadedDetainInfo(new DetainEventArgs(DetainID));
        }

        private void llblDetainedLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!clsLicense.IsLicenseExistByID(SelectedDetain.LicenseID)) return;

            Form frm = new frmShowLicenseInfo(SelectedDetain.LicenseID);
            frm.ShowDialog();
        }
    }
}
