using DVLD.Global_Classes;
using DVLD.People;
using DVLD_BusinessLayer;
using System;
using System.Windows.Forms;
using System.Windows.Navigation;

namespace DVLD.Users.Controls
{
    public partial class ctrlUserCardWithFilter : UserControl
    {
        public class UserEventArgs : EventArgs
        {
            public int UserID { get; }
            public UserEventArgs(int UserID)
            {
                this.UserID = UserID;
            }
        }
        public event EventHandler<UserEventArgs> On_UserSelected;
        private void _RaiseEventOnUserSelected(UserEventArgs e)
        {
            if (On_UserSelected != null)
                On_UserSelected?.Invoke(this, e);
        }

        public clsUser SelectedUser
        {
            get { return UserCard.SelectedUser; }
        }
        public int UserID
        {
            get { return UserCard.UserID; }
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
        public ctrlUserCardWithFilter()
        {
            InitializeComponent();
        }

        public void LoadInfo(int UserID , bool FilterEnabled=false)
        {
            UserCard.LoadInfo(UserID);
            if (SelectedUser != null)
            {
                this.FilterEnabled = FilterEnabled;
                cbFilterBy.SelectedIndex = cbFilterBy.FindString("UserID");
                tbFilterValue.Text = UserID.ToString();
            }
        }
        public void ResetInfo()
        {
            UserCard.ResetInfo();
            FilterEnabled = true;
            cbFilterBy.SelectedIndex = 0;
            tbFilterValue.Text = "";
        }
        private void pbSearchForUser_Click(object sender, EventArgs e)
        {
            string FilterBy = cbFilterBy.Text;
            string FilterValue = tbFilterValue.Text.ToString();

            if (FilterValue == "")
            {
                errorProvider.SetError(tbFilterValue, "This field must to be non-empty");
                return;
            }

            if (FilterBy == "User ID")
            {
                if (!clsValidation.IsInteger(FilterValue))
                {
                    errorProvider.SetError(tbFilterValue, "User ID must to be integer");
                    return;
                }

                clsUser User = clsUser.FindUserByID(Convert.ToInt32(FilterValue));
                if (User != null)
                {
                    UserCard.LoadInfo(User.UserID);
                }
                else
                {
                    MessageBox.Show($"User With ID = {FilterValue} is not found", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else if (FilterBy == "Username")
            {
                clsUser User = clsUser.FindUserByUsername(FilterValue);
                if (User != null)
                {
                    UserCard.LoadInfo(User.UserID);
                }
                else
                {
                    MessageBox.Show($"User With Username = {FilterValue} is not found", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        private void tbFilterValue_TextChanged(object sender, EventArgs e)
        {
            if (tbFilterValue.Text.Length > 0) errorProvider.SetError(tbFilterValue, "");
        }
        private void UserCard_On_LoadedUserInfo(object sender, ctrlUserCard.UserEventArgs e)
        {
            _RaiseEventOnUserSelected(new UserEventArgs(e.UserID));
        }
        private void pbAddNewUser_Click(object sender, EventArgs e)
        {
            frmAddUpdateUser form = new frmAddUpdateUser();
            form.DataBack += UserID_DataBackEvent;
            form.ShowDialog();
        }
        private void UserID_DataBackEvent (object sender,int UserID)
        {
            LoadInfo(UserID,true);
        }
        private void ctrlUserCardWithFilter_Load(object sender, EventArgs e)
        {
            cbFilterBy.SelectedIndex = 0;
        }
    }
}
