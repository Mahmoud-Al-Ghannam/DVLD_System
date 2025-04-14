using DVLD.People;
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

namespace DVLD.Users.Controls
{
    public partial class ctrlUserCard : UserControl
    {
        public class UserEventArgs : EventArgs
        {
            public int UserID { get; }
            public UserEventArgs(int UserID)
            {
                this.UserID = UserID;
            }
        }
        public event EventHandler<UserEventArgs> On_LoadedUserInfo;
        private void _RaiseEventOnLoadedUserInfo(UserEventArgs e)
        {
            if (On_LoadedUserInfo != null)
                On_LoadedUserInfo?.Invoke(this, e);
        }


        public clsUser SelectedUser { get; private set; }
        public int UserID { get; private set; }
        public ctrlUserCard()
        {
            InitializeComponent();
        }

        public void LoadInfo (int UserID)
        {
            SelectedUser = clsUser.FindUserByID(UserID);
            if(SelectedUser == null)
            {
                MessageBox.Show($"Error: The user with ID = {UserID} is not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.UserID = -1;
                ResetInfo();
            } else
            {
                this.UserID = SelectedUser.UserID;
                _FillInfo();
            }
        }
        public void _FillInfo ()
        {
            if(SelectedUser == null )
            {
                ResetInfo();
                return;
            }

            PersonCard.LoadInfo(SelectedUser.PersonID);
            lblUserID.Text = SelectedUser.UserID.ToString();
            lblUsername.Text = SelectedUser.Username;
            lblIsActive.Text = (SelectedUser.IsActive ? "YES" : "NO");
            _RaiseEventOnLoadedUserInfo(new UserEventArgs(UserID));
        }
        public void ResetInfo()
        {
            UserID = -1;
            SelectedUser = null;
            PersonCard.ResetInfo();

            lblUserID.Text = "[?????]";
            lblUsername.Text = "[?????]";
            lblIsActive.Text = "[?????]";
        }

        private void lblEditUserInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (SelectedUser == null) return;
            frmAddUpdateUser form = new frmAddUpdateUser(UserID);
            form.ShowDialog();
            LoadInfo(UserID);
        }
    }
}
