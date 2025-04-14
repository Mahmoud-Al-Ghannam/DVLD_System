using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.SessionState;

namespace DVLD_DataAccessLayer
{
    public class clsDataApplication
    {
        public static bool GetAllApplicationInfoByID(int ApplicationID,ref int ApplicantPersonID,ref DateTime ApplicationDate,ref int ApplicationTypeID,
            ref byte ApplicationStatus,ref DateTime LastStatusDate,ref decimal PaidFees,ref int CreatedByUserID)
        {
            bool Found = false;
            string Query = "Select * From Applications Where ApplicationID = @ApplicationID";
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.Read())
                {
                    ApplicantPersonID = (int)Reader["ApplicantPersonID"];
                    ApplicationDate = (DateTime)Reader["ApplicationDate"];
                    ApplicationTypeID = (int)Reader["ApplicationTypeID"];
                    ApplicationStatus = (byte)Reader["ApplicationStatus"];
                    LastStatusDate = (DateTime)Reader["LastStatusDate"];
                    PaidFees = (decimal)Reader["PaidFees"];
                    CreatedByUserID = (int)Reader["CreatedByUserID"];

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

        public static int AddNewApplication (int ApplicantPersonID, DateTime ApplicationDate, int ApplicationTypeID,
            byte ApplicationStatus, DateTime LastStatusDate, decimal PaidFees, int CreatedByUserID)
        {
            int ApplicationID = -1;
            string Query = "Insert Into Applications (ApplicantPersonID,ApplicationDate,ApplicationTypeID,ApplicationStatus,LastStatusDate,PaidFees,CreatedByUserID)  " +
                "Values (@ApplicantPersonID,@ApplicationDate,@ApplicationTypeID,@ApplicationStatus,@LastStatusDate,@PaidFees,@CreatedByUserID) " +
                "Select SCOPE_IDENTITY()";

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@ApplicantPersonID", ApplicantPersonID);
            Command.Parameters.AddWithValue("@ApplicationDate", ApplicationDate);
            Command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
            Command.Parameters.AddWithValue("@ApplicationStatus", ApplicationStatus);
            Command.Parameters.AddWithValue("@LastStatusDate", LastStatusDate);
            Command.Parameters.AddWithValue("@PaidFees", PaidFees);
            Command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            try
            {
                Connection.Open();
                object ob = Command.ExecuteScalar();
                if (ob != null && int.TryParse(ob.ToString(), out ApplicationID)) ;
            }
            catch (Exception ex) { }
            finally
            {
                Connection.Close();
            }
            return ApplicationID;
        }

        public static bool UpdateApplication(int ApplicationID, int ApplicantPersonID, DateTime ApplicationDate, int ApplicationTypeID,
            byte ApplicationStatus, DateTime LastStatusDate, decimal PaidFees, int CreatedByUserID)
        {
            string Query = "Update Applications " +
                "Set ApplicantPersonID = @ApplicantPersonID," +
                "ApplicationDate = @ApplicationDate," +
                "ApplicationTypeID = @ApplicationTypeID," +
                "ApplicationStatus = @ApplicationStatus," +
                "LastStatusDate = @LastStatusDate," +
                "PaidFees = @PaidFees," +
                "CreatedByUserID = @CreatedByUserID " +
                "Where ApplicationID = @ApplicationID";

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            Command.Parameters.AddWithValue("@ApplicantPersonID", ApplicantPersonID);
            Command.Parameters.AddWithValue("@ApplicationDate", ApplicationDate);
            Command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
            Command.Parameters.AddWithValue("@ApplicationStatus", ApplicationStatus);
            Command.Parameters.AddWithValue("@LastStatusDate", LastStatusDate);
            Command.Parameters.AddWithValue("@PaidFees", PaidFees);
            Command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);


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

        public static bool DeleteApplication(int ApplicationID)
        {
            string Query = "Delete From Applications Where ApplicationID = @ApplicationID";
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

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

        public static bool IsApplicationExistByID(int ApplicationID)
        {
            bool Found = false;
            string Query = "Select Top 1 Found=1 From Applications Where ApplicationID = @ApplicationID";
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

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

        public static DataTable GetAllApplications()
        {
            DataTable dt = new DataTable();
            string Query = "Select * from Applications";
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
    
        public static bool UpdateStatus (int ApplicationID , int ApplicationStatus)
        {
            string Query = "update Applications " +
                "set LastStatusDate = GetDate() , ApplicationStatus = @ApplicationStatus " +
                "where ApplicationID = @ApplicationID";
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            Command.Parameters.AddWithValue("@ApplicationStatus", ApplicationStatus);

            try
            {
                Connection.Open();
                int NumberOfAffectedRows = Command.ExecuteNonQuery();
                return (NumberOfAffectedRows > 0);
            } catch (Exception ex) { }
            finally
            {
                Connection.Close();
            }
            return false;
        }
    
        public static int GetAnActiveApplicationIDForPersonAndApplicationType (int ApplicantPersonID, int ApplicationTypeID)
        {
            int ApplicationID = -1;
            string Query = "select ApplicationID " +
                "from Applications " +
                "where ApplicantPersonID = @ApplicantPersonID and ApplicationTypeID = @ApplicationTypeID and  ApplicationStatus = 1";

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@ApplicantPersonID", ApplicantPersonID);
            Command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);

            try
            {
                Connection.Open();
                object ob = Command.ExecuteScalar();
                if (ob != null && int.TryParse(ob.ToString(), out ApplicationID)) ;
            }
            catch (Exception ex) { }
            finally
            {
                Connection.Close();
            }
            return ApplicationID;
        }
    }
}
