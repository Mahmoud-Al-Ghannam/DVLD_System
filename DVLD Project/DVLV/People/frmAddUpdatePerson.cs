using DVLD_BusinessLayer;
using DVLD.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.People
{
    public partial class frmAddUpdatePerson : System.Windows.Forms.Form
    {

        public delegate void DataBackEventHandler(object sender, int PersonID);
        public event DataBackEventHandler DataBack;
        public enum enMode { Update = 1, AddNew = 2 };
        private enMode _Mode;

        private int _PersonID;
        private clsPerson _Person;
        public frmAddUpdatePerson(int PersonID = -1)
        {
            InitializeComponent();
            _LoadCountries();

            if (!clsPerson.IsPersonExistByID(PersonID))
            {
                PersonID = -1;
                _LoadForAddNew();
            }
            else
            {
                _PersonID = PersonID;
                _LoadForUpdate();
            }

        }

        private void _LoadForUpdate()
        {
            _Mode = enMode.Update;
            _Person = clsPerson.FindPersonByID(_PersonID);
            lblTitle.Text = "Update Person";
            this.Text = "Update Person Form";
            _LoadDataToControls();
        }
        private void _LoadForAddNew()
        {
            _Mode = enMode.AddNew;
            _Person = new clsPerson();
            lblTitle.Text = "Add New Person";
            this.Text = "Add Person Form";
        }
        private void _LoadDataToControls()
        {
            if (_Mode == enMode.AddNew || _Person == null) return;

            lblPersonID.Text = _Person.PersonID.ToString();
            tbFirstName.Text = _Person.FirstName;
            tbSecondName.Text = _Person.SecondName;
            tbThirdName.Text = _Person.ThirdName;
            tbLastName.Text = _Person.LastName;
            tbEmail.Text = _Person.Email;
            tbPhone.Text = _Person.Phone;
            tbAddress.Text = _Person.Address;
            tbNationalNO.Text = _Person.NationalNO;
            dtpDateOfBirth.Text = _Person.DateOfBirth.ToString();
            cbCountries.SelectedIndex = cbCountries.FindString(_Person.NationalityCountryInfo.CountryName);

            if (_Person.Gendor == clsPerson.enGendor.Female) rbGendorWoman.Checked = true;
            else rbGendorMan.Checked = true;

            _LoadPersonImage();
        }
        private void _LoadPersonImage()
        {
            if (_Person.Gendor == clsPerson.enGendor.Male)
                pbPersonImage.Image = Resources.Male_512;
            else
                pbPersonImage.Image = Resources.Female_512;

            if (_Person.ImagePath != null && _Person.ImagePath != "")
            {
                if (File.Exists(_Person.ImagePath))
                {
                    pbPersonImage.ImageLocation = _Person.ImagePath;
                    llblRemoveImage.Visible = true;
                    return;
                }
                MessageBox.Show($"Could not find the image ({_Person.ImagePath}) of person", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            pbPersonImage.ImageLocation = "";
            llblRemoveImage.Visible = false;
        }
        private void _LoadDataToPersonObject()
        {
            _Person.FirstName = tbFirstName.Text;
            _Person.SecondName = tbSecondName.Text;
            _Person.ThirdName = tbThirdName.Text;
            _Person.LastName = tbLastName.Text;
            _Person.Email = tbEmail.Text;
            _Person.Phone = tbPhone.Text;
            _Person.Address = tbAddress.Text;
            _Person.NationalNO = tbNationalNO.Text;
            _Person.DateOfBirth = dtpDateOfBirth.Value;
            _Person.NationalityCountryID = clsCountry.FindCountryByName(cbCountries.Text).CountryID;

            if (rbGendorMan.Checked) _Person.Gendor = clsPerson.enGendor.Male;
            else _Person.Gendor = clsPerson.enGendor.Female;

            _Person.ImagePath = pbPersonImage.ImageLocation;
        }
        private void _LoadCountries()
        {
            DataTable CountriesTable = clsCountry.GetAllCountries();

            foreach (DataRow dr in CountriesTable.Rows)
            {
                cbCountries.Items.Add(dr["CountryName"].ToString());
            }
            cbCountries.SelectedIndex = 0;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            if (_Person.Mode == clsPerson.enMode.eUpdate)
                DataBack?.Invoke(this, _Person.PersonID);
            Close();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!_IsDataValidated())
            {
                MessageBox.Show("Error: Some fields are incomplete", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _LoadDataToPersonObject();
            if (_Person.Save())
            {
                _PersonID = _Person.PersonID;
                _LoadForUpdate();
                MessageBox.Show("Person info is saved successfully", "Save Person", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error: Person info is not saved successfully", "Save Person", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private bool _IsDataValidated()
        {
            if (tbFirstName.Text.Length == 0)
            {
                errorProvider.SetError(tbFirstName, "First name must to be non-empty");
                return false;
            }

            if (tbSecondName.Text.Length == 0)
            {
                errorProvider.SetError(tbSecondName, "Second name must to be non-empty");
                return false;
            }

            if (tbLastName.Text.Length == 0)
            {
                errorProvider.SetError(tbLastName, "Last name must to be non-empty");
                return false;
            }

            if (tbAddress.Text.Length == 0)
            {
                errorProvider.SetError(tbAddress, "Address must to be non-empty");
                return false;
            }

            if (tbPhone.Text.Length == 0)
            {
                errorProvider.SetError(tbPhone, "Phone must to be non-empty");
                return false;
            }

            if (tbEmail.Text.Length == 0)
            {
                errorProvider.SetError(tbEmail, "Email must to be non-empty");
                return false;
            }

            if (tbNationalNO.Text.Length == 0)
            {
                errorProvider.SetError(tbNationalNO, "National NO. must to be non-empty");
                return false;
            }

            if (_Mode == enMode.AddNew || (!tbNationalNO.Text.Trim().Equals(_Person.NationalNO)))
            {
                if (clsPerson.IsPersonExistByNationalNO(tbNationalNO.Text.Trim()))
                {
                    errorProvider.SetError(tbNationalNO, $"National NO = {tbNationalNO.Text.Trim()} is already used");
                    return false;
                }
            }


            return true;
        }
        private void tbField_TextChanged(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text.Length > 0) errorProvider.SetError(tb, "");
        }

        private void llblSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {

        }
    }
}
