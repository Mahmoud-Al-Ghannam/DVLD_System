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
using System.Runtime.InteropServices;

namespace DVLD.Licenses.LocalLicenses.Controls
{
    public partial class ctrlLicenseInfoWithFilter : UserControl
    {

        public class LicenseEventArgs : EventArgs
        {
            public int LicenseID { get; }
            public LicenseEventArgs(int LicenseID)
            {
                this.LicenseID = LicenseID;
            }
        }
        public event EventHandler<LicenseEventArgs> On_LicenseSelected;
        private void _RaiseEventOnLicenseSelected(LicenseEventArgs e)
        {
            if (On_LicenseSelected != null)
                On_LicenseSelected?.Invoke(this, e);
        }

        public clsLicense SelectedLicense
        {
            get { return LicenseCard.SelectedLicense; }
        }
        public int LicenseID
        {
            get { return LicenseCard.LicenseID; }
        }

        private bool _FilterEnabled;
        public bool FilterEnabled
        {
            get { return _FilterEnabled; }
            set
            {
                _FilterEnabled = value;
                gbFilter.Enabled = value;
            }
        }
        public ctrlLicenseInfoWithFilter()
        {
            InitializeComponent();
        }

        private void pbSearchForLicense_Click(object sender, EventArgs e)
        {

            if (!clsValidation.IsInteger(tbLicenseID.Text.Trim()))
            {
                MessageBox.Show("License ID must to be integer", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int LicenseID = Convert.ToInt32(tbLicenseID.Text.Trim());
            clsLicense License = clsLicense.FindLicenseByID(LicenseID);
            if (License == null)
            {
                MessageBox.Show($"There is no license with ID = {LicenseID} ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            LicenseCard.LoadInfo(LicenseID);
        }

        public void LoadInfo (int LicenseID, bool FilterEnabled = false)
        {
            LicenseCard.LoadInfo(LicenseID);
            if(SelectedLicense != null)
            {
                this.FilterEnabled = FilterEnabled;
                tbLicenseID.Text = LicenseID.ToString();
            }
        }
    
        public void ResetInfo ()
        {
            LicenseCard.ResetInfo();
            FilterEnabled = true;
            tbLicenseID.Text = "";
        }

        private void LicenseCard_On_LoadedLicenseInfo(object sender, DVLD.LocalLicenses.Controls.ctrlLicenseInfo.LicenseEventArgs e)
        {
            _RaiseEventOnLicenseSelected(new LicenseEventArgs(e.LicenseID));
        }

    }
}
