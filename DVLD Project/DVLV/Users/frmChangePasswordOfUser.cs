using DVLD.GlobalClasses;
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

namespace DVLD.Users
{
    public partial class frmChangePasswordOfUser : System.Windows.Forms.Form
    {
        public int UserID { get; set; }
        private clsUser _User;
        public frmChangePasswordOfUser(int UserID)
        {
            InitializeComponent();
            this.UserID = UserID;
            _User = clsUser.FindUserByID(UserID);
            UserCard.LoadInfo(UserID);
            if(_User == null)
            {
                btnSave.Enabled = false;
                tbConfirmPassword.Enabled = false;
                tbCurrentPassword.Enabled = false;
                tbNewPassword.Enabled = false;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private bool _IsDataValidated ()
        {
            if (tbCurrentPassword.Text.Trim().Length == 0)
            {
                errorProvider.SetError(tbCurrentPassword, "This field must to bo non-empty");
                return false;
            }    
            else if(_User.Password != clsUtil.ComputeHash(tbCurrentPassword.Text.Trim()))
            {
                MessageBox.Show("Password is not correct", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
                errorProvider.SetError(tbCurrentPassword, "");

            if (tbNewPassword.Text.Trim().Length == 0)
            {
                errorProvider.SetError(tbNewPassword, "This field must to bo non-empty");
                return false;
            }
            else
                errorProvider.SetError(tbNewPassword, "");

            if (tbConfirmPassword.Text.Trim().Length == 0)
            {
                errorProvider.SetError(tbConfirmPassword, "This field must to bo non-empty");
                return false;
            }
            else
                errorProvider.SetError(tbConfirmPassword, "");

            if(!tbConfirmPassword.Text.Trim().Equals(tbNewPassword.Text.Trim()))
            {
                MessageBox.Show("Confirm password does not match new password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(_IsDataValidated())
            {
                if(_User.ChangePassword(clsUtil.ComputeHash(tbNewPassword.Text.Trim())))
                {
                    MessageBox.Show("Password is saved successfully", "Save Password", MessageBoxButtons.OK, MessageBoxIcon.Information);
                } else
                {
                    MessageBox.Show("Error: Password is not saved successfully", "Save Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
