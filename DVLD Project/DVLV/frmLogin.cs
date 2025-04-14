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
using DVLD.LocalLicenses;
using DVLD.GlobalClasses;

namespace DVLD
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();

            string Username = "", Password = "";
            if (clsGlobalClass.GetTheRememberedUsernameAndPassword(ref Username, ref Password))
            {
                chkRememberMe.Checked = true;
                tbUsername.Text = Username;
                tbPassword.Text = Password;
            }
            else
            {
                chkRememberMe.Checked = false;
                tbUsername.Text = "";
                tbPassword.Text = "";
            }
        }

        private bool _IsDataValidated ()
        {
            if(tbUsername.Text.Trim().Length == 0)
            {
                errorProvider.SetError(tbUsername, "This field must to be non-empty");
                return false;
            } else errorProvider.SetError(tbUsername, "");


            if (tbPassword.Text.Trim().Length == 0)
            {
                errorProvider.SetError(tbPassword, "This field must to be non-empty");
                return false;
            }
            else errorProvider.SetError(tbPassword, "");

            if(!clsUser.IsUserExistByUsernameAndPassword(tbUsername.Text.Trim(),clsUtil.ComputeHash(tbPassword.Text.Trim()))) {
                MessageBox.Show("Username or password are not correct","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);  
                return false;
            }

            return true;
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (!_IsDataValidated()) return;

            clsUser User = clsUser.FindUserByUsername(tbUsername.Text.Trim());
            if(!User.IsActive)
            {
                MessageBox.Show("Your account is not active", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (chkRememberMe.Checked)
            {
                clsGlobalClass.RememberUsernameAndPassword(tbUsername.Text.Trim(), tbPassword.Text.Trim());
            }
            else
            {
                clsGlobalClass.RememberUsernameAndPassword("", "");
            }

            clsGlobalClass.CurrentUser = User;
            frmMain form = new frmMain(this);
            Hide();
            form.Show();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
