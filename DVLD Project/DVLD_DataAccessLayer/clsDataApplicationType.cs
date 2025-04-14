using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccessLayer
{
    public class clsDataApplicationType
    {
        public static bool GetAllApplicationTypeInfoByID(int ApplicationTypeID,ref string ApplicationTypeTitle,ref decimal ApplicationTypeFees)
        {
            bool Found = false;
            string Query = "Select * From ApplicationTypes Where ApplicationTypeID = @ApplicationTypeID";
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.Read())
                {
                    ApplicationTypeTitle = (string)Reader["ApplicationTypeTitle"];
                    ApplicationTypeFees = (decimal)Reader["ApplicationTypeFees"];
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
        public static int AddNewApplicationType(string ApplicationTypeTitle, decimal ApplicationTypeFees)
        {
            int ApplicationTypeID = -1;
            string Query = "Insert Into ApplicationTypes (ApplicationTypeTitle, ApplicationTypeFees)  " +
                "Values (@ApplicationTypeTitle, @ApplicationTypeFees) " +
                "Select SCOPE_IDENTITY()";

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@ApplicationTypeTitle", ApplicationTypeTitle);
            Command.Parameters.AddWithValue("@ApplicationTypeFees", ApplicationTypeFees);

            try
            {
                Connection.Open();
                object ob = Command.ExecuteScalar();
                if (ob != null && int.TryParse(ob.ToString(), out ApplicationTypeID)) ;
            }
            catch (Exception ex) { }
            finally
            {
                Connection.Close();
            }
            return ApplicationTypeID;
        }
        public static bool UpdateApplicationType(int ApplicationTypeID,string ApplicationTypeTitle, decimal ApplicationTypeFees)
        {
            string Query = "Update ApplicationTypes " +
                "Set ApplicationTypeTitle = @ApplicationTypeTitle," +
                "ApplicationTypeFees = @ApplicationTypeFees " +
                "Where ApplicationTypeID = @ApplicationTypeID";

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
            Command.Parameters.AddWithValue("@ApplicationTypeTitle", ApplicationTypeTitle);
            Command.Parameters.AddWithValue("@ApplicationTypeFees", ApplicationTypeFees);
            

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
        public static bool DeleteApplicationType(int ApplicationTypeID)
        {
            string Query = "Delete From ApplicationTypes Where ApplicationTypeID = @ApplicationTypeID";
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);

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
        public static bool IsApplicationTypeExistByID(int ApplicationTypeID)
        {
            bool Found = false;
            string Query = "Select Top 1 Found=1 From ApplicationTypes Where ApplicationTypeID = @ApplicationTypeID";
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);

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
        public static DataTable GetAllApplicationTypes()
        {
            DataTable dt = new DataTable();
            string Query = "Select * from ApplicationTypes";
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
    }
}
