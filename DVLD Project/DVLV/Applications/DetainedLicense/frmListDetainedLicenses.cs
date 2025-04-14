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
    public partial class frmListDetainedLicenses : Form
    {
        private static DataTable _dtListDetainedLicenses;
        public frmListDetainedLicenses()
        {
            InitializeComponent();
        }

        private void _RefreshListDetainedLicenses()
        {
            _dtListDetainedLicenses = clsDetainLicense.GetAllDetainLicenses();
            dgvDetainedLicenses.DataSource = _dtListDetainedLicenses;
            dgvDetainedLicenses.Refresh();
            _FormatDataGridView();
            lblNumberOfRecords.Text = dgvDetainedLicenses.RowCount.ToString();
        }
        private void _FormatDataGridView()
        {
            dgvDetainedLicenses.Columns["DetainID"].HeaderText = "Detain ID";
            dgvDetainedLicenses.Columns["DetainID"].Width = 100;

            dgvDetainedLicenses.Columns["LicenseID"].HeaderText = "License ID";
            dgvDetainedLicenses.Columns["LicenseID"].Width = 100;

            dgvDetainedLicenses.Columns["FineFees"].HeaderText = "Fine Fees";
            dgvDetainedLicenses.Columns["FineFees"].Width = 100;

            dgvDetainedLicenses.Columns["IsReleased"].HeaderText = "Is Released";
            dgvDetainedLicenses.Columns["IsReleased"].Width = 100;

            dgvDetainedLicenses.Columns["ReleaseApplicationID"].HeaderText = "Release Application ID";
            dgvDetainedLicenses.Columns["ReleaseApplicationID"].Width = 100;

            dgvDetainedLicenses.Columns["FullName"].HeaderText = "Full Name";
            dgvDetainedLicenses.Columns["FullName"].Width = 300;

            dgvDetainedLicenses.Columns["NationalNO"].HeaderText = "National NO";
            dgvDetainedLicenses.Columns["NationalNO"].Width = 100;

            dgvDetainedLicenses.Columns["DetainDate"].HeaderText = "Detain Date";
            dgvDetainedLicenses.Columns["DetainDate"].Width = 150;

            dgvDetainedLicenses.Columns["ReleaseDate"].HeaderText = "Release Date";
            dgvDetainedLicenses.Columns["ReleaseDate"].Width = 150;
        }
        private string _GetFilterColumnName()
        {

            if (cbFilterBy.Text == "None") return "None";
            if (cbFilterBy.Text == "Detain ID") return "DetainID";
            if (cbFilterBy.Text == "License ID") return "LicenseID";
            if (cbFilterBy.Text == "Is Released") return "IsReleased";
            if (cbFilterBy.Text == "Fine Fees") return "FineFees";
            if (cbFilterBy.Text == "National NO.") return "NationalNo";
            if (cbFilterBy.Text == "Full Name") return "FullName";
            if (cbFilterBy.Text == "Release Application ID") return "ReleaseApplicationID";
            return "";
        }
        private void frmListDetainedLicenses_Load(object sender, EventArgs e)
        {
            _RefreshListDetainedLicenses();
            cbFilterBy.SelectedIndex = 0;
            tbFilterValue.Visible = false;
        }
        private void _FilterListDetainedLicenses(string FilterColumn, string FilterValue)
        {
            if (FilterValue == "" || FilterColumn == "None") _dtListDetainedLicenses.DefaultView.RowFilter = "";
            else if (FilterColumn == "DetainID" || FilterColumn == "ReleaseApplicationID" || FilterColumn == "LicenseID")
            {
                _dtListDetainedLicenses.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, FilterValue);
            }
            else if (FilterColumn == "FineFees")
            {
                if(clsValidation.IsDecimal(FilterValue))
                {
                    _dtListDetainedLicenses.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, FilterValue);
                    errorProvider.SetError(tbFilterValue, "");
                } else
                {
                    errorProvider.SetError(tbFilterValue, "This field must to be real number");
                }
            }
            else if(FilterColumn == "IsReleased")
            {
                if(FilterValue == "All") _dtListDetainedLicenses.DefaultView.RowFilter = "";
                else _dtListDetainedLicenses.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, (FilterValue=="Yes"?1:0));
            }
            else _dtListDetainedLicenses.DefaultView.RowFilter = string.Format("[{0}] like '{1}%'", FilterColumn, FilterValue);

            lblNumberOfRecords.Text = dgvDetainedLicenses.RowCount.ToString();

        }
        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbIsReleased.SelectedIndex = 0;
            tbFilterValue.Text = "";

            if (cbFilterBy.Text == "Is Released")
            {
                tbFilterValue.Visible = false;
                cbIsReleased.Visible = true;
            }
            else if (cbFilterBy.Text == "None")
            {
                tbFilterValue.Visible = false;
                cbIsReleased.Visible = false;
            }
            else
            {
                cbIsReleased.Visible = false;
                tbFilterValue.Visible = true;
            }

            _FilterListDetainedLicenses("None", "");
        }
        private void tbFilterValue_TextChanged(object sender, EventArgs e)
        {
            _FilterListDetainedLicenses(_GetFilterColumnName(),tbFilterValue.Text.Trim());
        }

        private void cbIsReleased_SelectedIndexChanged(object sender, EventArgs e)
        {
            _FilterListDetainedLicenses(_GetFilterColumnName(), cbIsReleased.Text);
        }

        private void smiShowDetainedLicenseDetails_Click(object sender, EventArgs e)
        {
            int DetainID = (int)dgvDetainedLicenses.CurrentRow.Cells["DetainID"].Value;
            Form frm = new frmShowDetainLicenseInfo(DetainID);
            frm.ShowDialog();
        }

        private void btnDetainLicense_Click(object sender, EventArgs e)
        {
            Form frm = new frmDetainReleaseLicense(frmDetainReleaseLicense.enMode.Detain);
            frm.ShowDialog();
            _RefreshListDetainedLicenses();
        }

        private void btnReleaseLicense_Click(object sender, EventArgs e)
        {
            Form frm = new frmDetainReleaseLicense(frmDetainReleaseLicense.enMode.Release);
            frm.ShowDialog();
            _RefreshListDetainedLicenses();
        }

        private void smiRelease_Click(object sender, EventArgs e)
        {
            int LicenseID = (int)dgvDetainedLicenses.CurrentRow.Cells["LicenseID"].Value;
            Form frm = new frmDetainReleaseLicense(frmDetainReleaseLicense.enMode.Release, LicenseID);
            frm.ShowDialog();
            _RefreshListDetainedLicenses();
        }

        private void cmsDetainedLicense_Opening(object sender, CancelEventArgs e)
        {
            if (dgvDetainedLicenses.RowCount == 0)
            {
                cmsDetainedLicense.Enabled = false;
                return;
            }
            
            int DetainID = (int)dgvDetainedLicenses.CurrentRow.Cells["DetainID"].Value;
            clsDetainLicense Detain = clsDetainLicense.FindDetainLicenseByID(DetainID);
            smiRelease.Enabled = (!Detain.IsReleased);
        }
    }
}
