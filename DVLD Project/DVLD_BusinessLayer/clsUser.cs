using DVLD_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DVLD_BusinessLayer
{
    public class clsUser
    {
        public int UserID { get; private set; }

        private int _PersonID;
        public int PersonID {
            get { return _PersonID; }
            set
            {
                _PersonID = value;
                PersonInfo = clsPerson.FindPersonByID(value);
            }
        }
        public clsPerson PersonInfo { get; private set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; } 

        public enum enMode { eAddNew = 1, eUpdate = 2 };
        public enMode Mode { get; private set; }

        public clsUser()
        {
            Mode = enMode.eAddNew;
            PersonID = UserID = -1;
            Username = Password = "";
            IsActive = false;
        }

        private clsUser(int UserID,int PersonID,string Username,string Password,bool IsActive)
        {
            Mode = enMode.eUpdate;
            this.UserID = UserID;
            this.PersonID = PersonID;
            this.Username = Username;
            this.Password = Password;
            this.IsActive = IsActive;
        }


        private bool _AddNew()
        {
            UserID = clsDataUser.AddNewUser(PersonID,Username,Password,IsActive);
            return (UserID != -1);
        }

        private bool _Update()
        {
            return clsDataUser.UpdateUser(UserID, PersonID, Username,Password, IsActive);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.eAddNew:
                    if (_AddNew())
                    {
                        Mode = enMode.eUpdate;
                        return true;
                    }
                    break;
                case enMode.eUpdate:
                    return _Update();
                    break;
            }
            return false;
        }

        public static clsUser FindUserByID(int UserID)
        {
            if (!clsDataUser.IsUserExistByID(UserID)) return null;

            int PersonID = -1;
            string Username = "", Password = "";
            bool IsActive = false;

            bool Found = clsDataUser.GetAllUserInfoByID(UserID,ref PersonID,ref Username,ref Password,ref IsActive);
            if (Found)
            {
                return new clsUser(UserID,PersonID,Username,Password,IsActive);
            }
            return null;
        }

        public static clsUser FindUserByUsername(string Username)
        {
            if (!clsDataUser.IsUserExistByUsername(Username)) return null;

            int PersonID = -1, UserID = -1;
            string Password = "";
            bool IsActive = false;

            bool Found = clsDataUser.GetAllUserInfoByUsername(Username,ref UserID,ref PersonID,ref Password,ref IsActive);
            if (Found)
            {
                return new clsUser(UserID, PersonID, Username, Password, IsActive);
            }
            return null;
        }

        public static bool IsUserExistByID (int UserID)
        {
            return clsDataUser.IsUserExistByID(UserID);
        }

        public static bool IsUserExistByUsername (string Username)
        {
            return clsDataUser.IsUserExistByUsername(Username);
        }

        public static bool IsUserExistByUsernameAndPassword (string Username , string Password )
        {
            return clsDataUser.IsUserExistByUsernameAndPassword(Username,Password);
        }
        public bool Delete()
        {
            if (clsDataUser.DeleteUserByID(UserID))
            {
                Mode = enMode.eAddNew;
                UserID = -1;
                return true;
            }
            return false;
        }

        public static bool DeleteUserByID (int UserID)
        {
            return clsDataUser.DeleteUserByID(UserID);
        }
        public static DataTable GetAllUsers()
        {
            return clsDataUser.GetAllUsers();
        }
    
        public static bool ChangePassword (int UserID,string NewPassword)
        {
            clsUser User = clsUser.FindUserByID(UserID);
            return clsDataUser.ChangePassword(UserID, User.Password,NewPassword);
        }
        
        public bool ChangePassword (string NewPassword)
        {
            if(ChangePassword(UserID,NewPassword))
            {
                Password = NewPassword;
                return true;
            }
            return false;
        }
    }
}
