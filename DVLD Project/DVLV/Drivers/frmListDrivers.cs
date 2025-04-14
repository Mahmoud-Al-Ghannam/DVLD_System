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

namespace DVLD.Drivers
{
    public partial class frmListDrivers : Form
    {
        private DataTable _dtListDrivers;
        public frmListDrivers()
        {
            InitializeComponent();
        }

        private void frmListDrivers_Load(object sender, EventArgs e)
        {
            _RefreshListDrivers();
            cbFilterBy.SelectedIndex = 0;
            tbFilterValue.Visible = false;
        }
        private void _RefreshListDrivers()
        {
            _dtListDrivers = clsDriver.GetAllDrivers();
            dgvDrivers.DataSource = _dtListDrivers;
            dgvDrivers.Refresh();
            _FormatDataGridView();
            lblNumberOfRecords.Text = dgvDrivers.RowCount.ToString();
        }
        private void _FormatDataGridView ()
        {
            dgvDrivers.Columns["DriverID"].HeaderText = "Driver ID";
            dgvDrivers.Columns["DriverID"].Width = 100;

            dgvDrivers.Columns["PersonID"].HeaderText = "Person ID";
            dgvDrivers.Columns["PersonID"].Width = 100;

            dgvDrivers.Columns["NationalNO"].HeaderText = "National NO";
            dgvDrivers.Columns["NationalNO"].Width = 100;

            dgvDrivers.Columns["FullName"].HeaderText = "Full Name";
            dgvDrivers.Columns["FullName"].Width = 300;

            dgvDrivers.Columns["CreatedDate"].HeaderText = "Created Date";
            dgvDrivers.Columns["CreatedDate"].Width = 150;

            dgvDrivers.Columns["NumberOfActiveLicenses"].HeaderText = "Number Of Active Licenses";
            dgvDrivers.Columns["NumberOfActiveLicenses"].Width = 100;
        }

        private string _GetFilterColumnName()
        {
            if (cbFilterBy.Text == "None") return "None";
            if (cbFilterBy.Text == "Driver ID") return "DriverID";
            if (cbFilterBy.Text == "Person ID") return "PersonID";
            if (cbFilterBy.Text == "National NO") return "NationalNO";
            if (cbFilterBy.Text == "Full Name") return "FullName";
            if (cbFilterBy.Text == "Number Of Active Licenses") return "NumberOfActiveLicenses";
            return "";
        }

        private void _FilterListDrivers(string FilterColumn, string FilterValue)
        {
            if (FilterValue == "" || FilterColumn == "None") _dtListDrivers.DefaultView.RowFilter = "";
            else if (FilterColumn == "PersonID" || FilterColumn == "DriverID" || FilterColumn == "NumberOfActiveLicenses")
            {
                _dtListDrivers.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, FilterValue);
            }
            else _dtListDrivers.DefaultView.RowFilter = string.Format("[{0}] like '{1}%'", FilterColumn, FilterValue);

            lblNumberOfRecords.Text = dgvDrivers.RowCount.ToString();
        }
        private void smiShowPersonDetails_Click(object sender, EventArgs e)
        {
            int DriverID = (int)dgvDrivers.SelectedRows[0].Cells["DriverID"].Value;
            Form form = new frmShowDriverInfo(DriverID);
            form.ShowDialog();
        }

        private void tbFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            string FilterColumn = _GetFilterColumnName();
            switch (FilterColumn)
            {
                case "PersonID":
                case "DriverID":
                case "NumberOfActiveLicenses":
                    e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
                    break;
                default:
                    e.Handled = false;
                    break;
            }
        }

        private void tbFilterValue_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = _GetFilterColumnName();
            string FilterValue = "";
            if (FilterColumn != "None") FilterValue = tbFilterValue.Text.Trim();

            _FilterListDrivers(FilterColumn, FilterValue);
        }

        private void cmsDriver_Opening(object sender, CancelEventArgs e)
        {
            if (dgvDrivers.RowCount == 0) cmsDriver.Enabled = false;
        }
        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbFilterValue.Visible = (cbFilterBy.SelectedIndex != 0);
            tbFilterValue.Text = "";
            _FilterListDrivers("None", "");
        }

        private void smiShowLicensesHistory_Click(object sender, EventArgs e)
        {
            int PersonID = (int)dgvDrivers.SelectedRows[0].Cells["PersonID"].Value;
            frmShowLicensesHistory frm = new frmShowLicensesHistory(PersonID);
            frm.ShowDialog();
        }
    }
}
