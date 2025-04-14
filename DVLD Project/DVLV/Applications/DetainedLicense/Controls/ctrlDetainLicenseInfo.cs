using DVLD.Global_Classes;
using DVLD.Licenses.LocalLicenses;
using DVLD_BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Applications.DetainedLicense.Controls
{
    public partial class ctrlDetainLicenseInfo : UserControl
    {
        public int DetainedLicenseID { get; private set; }
        public int? DetainID
        {
            get
            {
                if (clsValidation.IsInteger(lblDetainID.Text.Trim()))
                    return Convert.ToInt32(lblDetainID.Text.Trim());
                return null;
            }
        }
        public decimal? FineFees
        {
            get
            {
                if (clsValidation.IsDecimal(tbFineFees.Text.Trim()))
                    return Convert.ToDecimal(tbFineFees.Text.Trim());
                return null;
            }
        }
        public string DetainedByUser
        {
            get { return lblDetainedByUser.Text; }
        }

        public ctrlDetainLicenseInfo()
        {
            InitializeComponent();
        }

        public void LoadInfo(int DetainedLicenseID)
        {
            if (clsLicense.IsLicenseExistByID(DetainedLicenseID))
            {
                this.DetainedLicenseID = DetainedLicenseID;
                _FillInfo();
            }
            else
            {
                MessageBox.Show($"Error: The license with ID = {DetainedLicenseID} is not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DetainedLicenseID = -1;
                ResetInfo();
            }
        }

        public void ResetInfo()
        {
            lblDetainedLicenseID.Text = "[?????]";
            lblDetainDate.Text = "[?????]";
            lblDetainedByUser.Text = "[?????]";
            lblDetainID.Text = "[?????";
            tbFineFees.Text = "";

            llblDetainedLicenseInfo.Enabled = false;
        }
        private void _FillInfo()
        {
            lblDetainedLicenseID.Text = DetainedLicenseID.ToString();
            lblDetainDate.Text = DateTime.Now.ToString("yyyy MMM dd hh:mm:ss");
            lblDetainedByUser.Text = clsGlobalClass.CurrentUser.Username;
            llblDetainedLicenseInfo.Enabled = true;

            clsDetainLicense Detain = clsDetainLicense.FindDetainLicenseByLicenseID(DetainedLicenseID);
            if (Detain == null) return;
            lblDetainID.Text = Detain.DetainID.ToString();
            tbFineFees.Text = Detain.FineFees.ToString();
        }

        private void llblDetainedLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!clsLicense.IsLicenseExistByID(DetainedLicenseID)) return;
            frmShowLicenseInfo form = new frmShowLicenseInfo(DetainedLicenseID);
            form.ShowDialog();
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
            errorProvider1.SetError(tbFineFees, "");
        }
    }
}
