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
using System.Diagnostics.Eventing.Reader;
using DVLD.Drivers;

namespace DVLD.People
{
    public partial class frmListPeople : System.Windows.Forms.Form
    {
        private DataTable _dtListPeople;
        public frmListPeople()
        {
            InitializeComponent();
        }


        private void _RefreshListPeople()
        {
            _dtListPeople = clsPerson.GetAllPeople();
            dgvPeople.DataSource = _dtListPeople;
            dgvPeople.Refresh();
            _FormatDataGridView();
            lblNumberOfRecords.Text = dgvPeople.RowCount.ToString();
        }
        private string _GetFilterColumnName()
        {

            if (cbFilterBy.Text == "None") return "None";
            if (cbFilterBy.Text == "Person ID") return "PersonID";
            if (cbFilterBy.Text == "National NO") return "NationalNO";
            if (cbFilterBy.Text == "First Name") return "FirstName";
            if (cbFilterBy.Text == "Second Name") return "SecondName";
            if (cbFilterBy.Text == "Third Name") return "ThirdName";
            if (cbFilterBy.Text == "Last Name") return "LastName";
            if (cbFilterBy.Text == "Email") return "Email";
            if (cbFilterBy.Text == "Phone") return "Phone";
            if (cbFilterBy.Text == "Address") return "Address";
            if (cbFilterBy.Text == "Gendor Caption") return "GendorCaption";
            if (cbFilterBy.Text == "Country Name") return "CountryName";
            if (cbFilterBy.Text == "Image Path") return "ImagePath";
            return "";
        }
        private void frmPeopleManagment_Load(object sender, EventArgs e)
        {
            _RefreshListPeople();
            cbFilterBy.SelectedIndex = 0;
            tbFilterValue.Visible = false;
        }
        private void _FilterListPeople(string FilterColumn, string FilterValue)
        {
            if (FilterValue == "" || FilterColumn == "None") _dtListPeople.DefaultView.RowFilter = "";
            else if (FilterColumn == "PersonID")
            {
                _dtListPeople.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, tbFilterValue.Text.Trim());
            }
            else _dtListPeople.DefaultView.RowFilter = string.Format("[{0}] like '{1}%'", FilterColumn, tbFilterValue.Text.Trim());

            lblNumberOfRecords.Text = dgvPeople.RowCount.ToString();
        }
        private void _FormatDataGridView()
        {
            dgvPeople.Columns["PersonID"].HeaderText = "Person ID";
            dgvPeople.Columns["PersonID"].Width = 100;

            dgvPeople.Columns["NationalNO"].HeaderText = "National NO.";
            dgvPeople.Columns["NationalNO"].Width = 100;

            dgvPeople.Columns["FirstName"].HeaderText = "First Name";
            dgvPeople.Columns["FirstName"].Width = 150;

            dgvPeople.Columns["SecondName"].HeaderText = "Second Name";
            dgvPeople.Columns["SecondName"].Width = 150;

            dgvPeople.Columns["ThirdName"].HeaderText = "Third Name";
            dgvPeople.Columns["ThirdName"].Width = 150;

            dgvPeople.Columns["LastName"].HeaderText = "Last Name";
            dgvPeople.Columns["LastName"].Width = 150;

            dgvPeople.Columns["Gendor"].HeaderText = "Gendor";
            dgvPeople.Columns["Gendor"].Width = 50;

            dgvPeople.Columns["GendorCaption"].HeaderText = "Gendor Caption";
            dgvPeople.Columns["GendorCaption"].Width = 50;

            dgvPeople.Columns["DateOfBirth"].HeaderText = "Date Of Birth";
            dgvPeople.Columns["DateOfBirth"].Width = 150;

            dgvPeople.Columns["Address"].HeaderText = "Address";
            dgvPeople.Columns["Address"].Width = 200;

            dgvPeople.Columns["Email"].HeaderText = "Email";
            dgvPeople.Columns["Email"].Width = 200;

            dgvPeople.Columns["Phone"].HeaderText = "Phone";
            dgvPeople.Columns["Phone"].Width = 100;

            dgvPeople.Columns["NationalityCountryID"].HeaderText = "Nationality Country ID";
            dgvPeople.Columns["NationalityCountryID"].Width = 100;

            dgvPeople.Columns["CountryName"].HeaderText = "Country Name";
            dgvPeople.Columns["CountryName"].Width = 150;

            dgvPeople.Columns["ImagePath"].HeaderText = "Image Path";
            dgvPeople.Columns["ImagePath"].Width = 200;
        }
        private void smiShowDetails_Click(object sender, EventArgs e)
        {
            int PersonID = (int)dgvPeople.SelectedRows[0].Cells["PersonID"].Value;
            Form form = new frmShowPersonInfo(PersonID);
            form.ShowDialog();
        }
        private void smiAddNewPerson_Click(object sender, EventArgs e)
        {
            frmAddUpdatePerson form = new frmAddUpdatePerson();
            form.ShowDialog();

            _RefreshListPeople();
        }

        private void smiDelete_Click(object sender, EventArgs e)
        {
            int PersonID = (int)dgvPeople.SelectedRows[0].Cells["PersonID"].Value;

            DialogResult dr = MessageBox.Show($"Are you sure you want to delete person with ID = {PersonID} ? ", "Confirm!", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                if (clsPerson.DeletePersonByID(PersonID)) MessageBox.Show("Person is deleted successfully", "Delete Person", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else MessageBox.Show("Person is not deleted", "Delete Person", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            _RefreshListPeople();
        }

        private void smiEdit_Click(object sender, EventArgs e)
        {
            int PersonID = (int)dgvPeople.SelectedRows[0].Cells["PersonID"].Value;
            frmAddUpdatePerson form = new frmAddUpdatePerson(PersonID);
            form.ShowDialog();

            _RefreshListPeople();
        }

        private void pbAddNewPerson_Click(object sender, EventArgs e)
        {
            frmAddUpdatePerson form = new frmAddUpdatePerson();
            form.ShowDialog();

            _RefreshListPeople();
        }
        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {
            frmAddUpdatePerson form = new frmAddUpdatePerson();
            form.ShowDialog();

            _RefreshListPeople();
        }
        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbFilterValue.Visible = (cbFilterBy.SelectedIndex != 0);
            tbFilterValue.Text = "";
            _FilterListPeople("None", "");
        }
        private void tbFilterValue_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = _GetFilterColumnName();
            string FilterValue = "";
            if (FilterColumn != "None") FilterValue = tbFilterValue.Text.Trim();

            _FilterListPeople(FilterColumn, FilterValue);
        }

        private void tbFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            string FilterColumn = _GetFilterColumnName();
            switch (FilterColumn)
            {
                case "PersonID":
                    e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
                    break;
                default:
                    e.Handled = false;
                    break;
            }
        }
        private void cmsPerson_Opening(object sender, CancelEventArgs e)
        {
            if (dgvPeople.RowCount == 0) cmsPerson.Enabled = false;
        }
    }
}
