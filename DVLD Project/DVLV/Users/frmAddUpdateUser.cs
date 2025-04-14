using DVLD_BusinessLayer;
using DVLD.People.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;
using System.Windows.Forms;
using DVLD.Global_Classes;
using DVLD.GlobalClasses;

namespace DVLD.Users
{
    public partial class frmAddUpdateUser : System.Windows.Forms.Form
    {
        public delegate void DataBackEventHandler(object sender, int PersonID);
        public event DataBackEventHandler DataBack;

        public enum enMode { Update = 1, AddNew = 2 };
        private enMode _Mode;
        private int _UserID;
        private clsUser _User;
        public frmAddUpdateUser(int UserID = -1)
        {
            InitializeComponent();

            if (!clsUser.IsUserExistByID(UserID))
            {
                _UserID = -1;
                _LoadForAddNew();
            }
            else
            {
                _UserID = UserID;
                _LoadForUpdate();
            }
        }

        private bool _IsDataValidated()
        {
            if (tbUsername.Text.Trim().Length == 0)
            {
                errorProvider.SetError(tbUsername, "This field must to be non-empty");
                return false;
            }
            else errorProvider.SetError(tbUsername, "");

            if (tbPassword.Text.Trim().Length == 0)
            {
                errorProvider.SetError(tbPassword, "This field must to be non-empty");
                return false;
            }
            else errorProvider.SetError(tbPassword, "");

            if (tbConfirmPassword.Text.Trim().Length == 0)
            {
                errorProvider.SetError(tbConfirmPassword, "This field must to be non-empty");
                return false;
            }
            else errorProvider.SetError(tbConfirmPassword, "");

            if (!tbConfirmPassword.Text.Trim().Equals(tbPassword.Text.Trim()))
            {
                MessageBox.Show("Confirm password does not match password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (_Mode == enMode.AddNew || (!tbUsername.Text.Trim().Equals(_User.Username)))
            {
                if (clsUser.IsUserExistByUsername(tbUsername.Text.Trim()))
                {
                    MessageBox.Show($"Username = {tbUsername.Text.Trim()} is already used", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            return true;
        }

        private void _LoadForUpdate()
        {
            _Mode = enMode.Update;
            _User = clsUser.FindUserByID(_UserID);
            lblTitle.Text = "Update User";
            this.Text = "Update User Form";
            PersonCardWithFilter.FilterEnabled = false;
            tbPassword.Enabled = false;
            tbConfirmPassword.Enabled = false;

            _LoadDataToControls();
        }
        private void _LoadForAddNew()
        {
            _Mode = enMode.AddNew;
            _User = new clsUser();
            lblTitle.Text = "Add New User";
            this.Text = "Add User Form";
            PersonCardWithFilter.FilterEnabled = true;
            tbPassword.Enabled = true;
            tbConfirmPassword.Enabled = true;
        }
        private void _LoadDataToUserObject()
        {
            _User.PersonID = PersonCardWithFilter.PersonID;
            _User.Username = tbUsername.Text.Trim();
            if(_Mode == enMode.AddNew) _User.Password = clsUtil.ComputeHash(tbPassword.Text.Trim());
            _User.IsActive = cbIsActive.Checked;
        }
        private void _LoadDataToControls()
        {
            if (_Mode == enMode.AddNew || _User == null) return;

            PersonCardWithFilter.LoadInfo(_User.PersonID);
            lblUserID.Text = _UserID.ToString();
            tbUsername.Text = _User.Username;
            tbPassword.Text = _User.Password;
            tbConfirmPassword.Text = _User.Password;
            cbIsActive.Checked = _User.IsActive;

            if ((clsGlobalClass.CurrentUser.UserID == _UserID) || (clsPerson.IsPersonActiveUserByID(_User.PersonID) && !_User.IsActive))
            {
                cbIsActive.Enabled = false;
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            if (_User.Mode == clsUser.enMode.eUpdate)
                DataBack?.Invoke(this, _User.UserID);
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (PersonCardWithFilter.PersonID == -1)
            {
                MessageBox.Show("Error: You have to select a person", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!_IsDataValidated()) return;

            _LoadDataToUserObject();
            if (_User.Save())
            {
                _UserID = _User.UserID;
                _LoadForUpdate();
                MessageBox.Show("User info is saved successfully", "Save User", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error: User info is not saved successfully", "Save User", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PersonCardWithFilter_On_PersonSelected(object sender, ctrlPersonCardWithFilter.PersonEventArgs e)
        {
            if (_Mode == enMode.AddNew)
            {
                if (clsPerson.IsPersonActiveUserByID(e.PersonID))
                {
                    MessageBox.Show($"Please , change person that you selected because person with ID = {e.PersonID} is already active user", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    PersonCardWithFilter.ResetInfo();
                }
            }
        }
    }
}
