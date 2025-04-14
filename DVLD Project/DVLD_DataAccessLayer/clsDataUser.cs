using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccessLayer
{
    public class clsDataUser
    {
        public static bool GetAllUserInfoByID(int UserID,ref int PersonID,ref string Username,ref string Password, ref bool IsActive)
        {
            bool Found = false;
            string Query = "Select * From Users Where UserID = @UserID";
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@UserID", UserID);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.Read())
                {
                    PersonID = (int)Reader["PersonID"];
                    Username = (string)Reader["Username"];
                    Password = (string)Reader["Password"];
                    IsActive = (bool)Reader["IsActive"];

                    Found = true;
                }
            }
            catch (Exception ex) { }
            finally
            {
                Connection.Close();
            }
            return Found;
        }

        public static bool GetAllUserInfoByUsername(string Username , ref int UserID, ref int PersonID, ref string Password, ref bool IsActive)
        {
            bool Found = false;
            string Query = "Select * From Users Where Username = @Username";
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@Username", Username);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.Read())
                {
                    UserID = (int)Reader["UserID"];
                    PersonID = (int)Reader["PersonID"];
                    Username = (string)Reader["Username"];
                    Password = (string)Reader["Password"];
                    IsActive = (bool)Reader["IsActive"];

                    Found = true;
                }
            }
            catch (Exception ex) { }
            finally
            {
                Connection.Close();
            }
            return Found;
        }

        public static int AddNewUser(int PersonID,string Username,string Password,bool IsActive)
        {
            int UserID = -1;
            string Query = "Insert Into Users (PersonID, Username, Password, IsActive)  " +
                "Values (@PersonID, @Username, @Password, @IsActive) " +
                "Select SCOPE_IDENTITY()";

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@PersonID", PersonID);
            Command.Parameters.AddWithValue("@Username", Username);
            Command.Parameters.AddWithValue("@Password", Password);
            Command.Parameters.AddWithValue("@IsActive", IsActive);

            try
            {
                Connection.Open();
                object ob = Command.ExecuteScalar();
                if (ob != null && int.TryParse(ob.ToString(), out UserID)) ;
            }
            catch (Exception ex) { }
            finally
            {
                Connection.Close();
            }
            return UserID;
        }

        public static bool UpdateUser(int UserID,int PersonID, string Username, string Password, bool IsActive)
        {
            string Query = "Update Users " +
                "Set PersonID = @PersonID," +
                "Username = @Username," +
                "Password = @Password," +
                "IsActive = @IsActive " +
                "Where UserID = @UserID";

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@UserID", UserID);
            Command.Parameters.AddWithValue("@PersonID", PersonID);
            Command.Parameters.AddWithValue("@Username", Username);
            Command.Parameters.AddWithValue("@Password", Password);
            Command.Parameters.AddWithValue("@IsActive", IsActive);


            try
            {
                Connection.Open();
                int NumberOfAffectedRows = Command.ExecuteNonQuery();
                return (NumberOfAffectedRows > 0);
            }
            catch (Exception ex) { }
            finally
            {
                Connection.Close();
            }

            return false;
        }

        public static bool DeleteUserByID(int UserID)
        {
            string Query = "Delete From Users Where UserID = @UserID";
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@UserID", UserID);

            try
            {
                Connection.Open();
                int NumberOfAffectedRows = Command.ExecuteNonQuery();
                return (NumberOfAffectedRows > 0);
            }
            catch (Exception ex) { }
            finally
            {
                Connection.Close();
            }

            return false;
        }

        public static bool DeleteUserByUsername(string Username)
        {
            string Query = "Delete From Users Where Username = @Username";
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@Username", Username);

            try
            {
                Connection.Open();
                int NumberOfAffectedRows = Command.ExecuteNonQuery();
                return (NumberOfAffectedRows > 0);
            }
            catch (Exception ex) { }
            finally
            {
                Connection.Close();
            }

            return false;
        }
        public static bool IsUserExistByID(int UserID)
        {
            bool Found = false;
            string Query = "Select Top 1 Found=1 From Users Where UserID = @UserID";
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@UserID", UserID);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                Found = Reader.HasRows;
                Reader.Close();
                return Found;
            }
            catch (Exception ex) { }
            finally
            {
                Connection.Close();
            }
            return Found;
        }

        public static bool IsUserExistByUsername(string Username)
        {
            bool Found = false;
            string Query = "Select Top 1 Found=1 From Users Where Username = @Username";
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@Username", Username);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                Found = Reader.HasRows;
                Reader.Close();
                return Found;
            }
            catch (Exception ex) { }
            finally
            {
                Connection.Close();
            }
            return Found;
        }

        public static bool IsUserExistByUsernameAndPassword (string Username,string Password)
        {
            bool Found = false;
            string Query = "Select Top 1 Found=1 From Users Where Username = @Username and Password = @Password";
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@Username", Username);
            Command.Parameters.AddWithValue("@Password", Password);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                Found = Reader.HasRows;
                Reader.Close();
                return Found;
            }
            catch (Exception ex) { }
            finally
            {
                Connection.Close();
            }
            return Found;
        }
        public static DataTable GetAllUsers()
        {
            DataTable dt = new DataTable();
            string Query = "Select UserID,PersonID,Username,IsActive from Users";
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand Command = new SqlCommand(Query, Connection);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                dt.Load(Reader);
                Reader.Close();
            }
            catch (Exception ex) { }
            finally
            {
                Connection.Close();
            }
            return dt;
        }

        public static bool ChangePassword (int UserID,string OldPassword, string NewPassword)
        {
            string Query = "update Users " +
                "set [Password] = @NewPassword " +
                "where UserID=@UserID and [Password]=@OldPassword";
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@UserID", UserID);
            Command.Parameters.AddWithValue("@NewPassword", NewPassword);
            Command.Parameters.AddWithValue("@OldPassword", OldPassword);

            try
            {
                Connection.Open();
                int NumberOfAffectedRows = Command.ExecuteNonQuery();
                return (NumberOfAffectedRows > 0);
            }
            catch (Exception ex) { }
            finally
            {
                Connection.Close();
            }

            return false;
        }

    }
}
