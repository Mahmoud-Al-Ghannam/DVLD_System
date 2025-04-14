using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccessLayer
{
    public class clsDataTest
    {
        public static bool GetAllTestInfoByID(int TestID,ref int TestAppointmentID,ref bool TestResult,ref string Notes,ref int CreatedByUserID)
        {
            bool Found = false;
            string Query = "Select * From Tests Where TestID = @TestID";
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@TestID", TestID);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.Read())
                {
                    TestAppointmentID = (int) Reader["TestAppointmentID"];
                    TestResult = (bool) Reader["TestResult"];

                    if (Reader["Notes"] == DBNull.Value) Notes = null;
                    else Notes = (string)Reader["Notes"];

                    CreatedByUserID = (int) Reader["CreatedByUserID"];

                    

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

        public static bool GetAllTestInfoByTestAppointmentID(int TestAppointmentID,ref int TestID, ref bool TestResult, ref string Notes, ref int CreatedByUserID)
        {
            bool Found = false;
            string Query = "Select * From Tests Where TestAppointmentID = @TestAppointmentID";
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.Read())
                {
                    TestID = (int)Reader["TestID"];
                    TestResult = (bool)Reader["TestResult"];

                    if (Reader["Notes"] == DBNull.Value) Notes = null;
                    else Notes = (string)Reader["Notes"];

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
        public static int AddNewTest(int TestAppointmentID,bool TestResult,string Notes,int CreatedByUserID)
        {
            int TestID = -1;
            string Query = "Insert Into Tests (TestAppointmentID,TestResult,Notes,CreatedByUserID)  " +
                "Values (@TestAppointmentID,@TestResult,@Notes,@CreatedByUserID) " +
                
                "update TestAppointments " +
                "set IsLocked = 1 " +
                "where TestAppointmentID = @TestAppointmentID " +

                "Select SCOPE_IDENTITY()";

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
            Command.Parameters.AddWithValue("@TestResult", TestResult);
            Command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            
            if (Notes == null) Command.Parameters.AddWithValue("@Notes", DBNull.Value);
            else Command.Parameters.AddWithValue("@Notes", Notes);

            try
            {
                Connection.Open();
                object ob = Command.ExecuteScalar();
                if (ob != null && int.TryParse(ob.ToString(), out TestID)) ;
            }
            catch (Exception ex) { }
            finally
            {
                Connection.Close();
            }
            return TestID;
        }

        public static bool UpdateTest(int TestID, int TestAppointmentID, bool TestResult, string Notes, int CreatedByUserID)
        {
            string Query = "Update Tests " +
                "Set TestAppointmentID = @TestAppointmentID," +
                "TestResult = @TestResult," +
                "Notes = @Notes," +
                "CreatedByUserID = @CreatedByUserID " +
                "Where TestID = @TestID";

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@TestID", TestID);
            Command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
            Command.Parameters.AddWithValue("@TestResult", TestResult);
            Command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            if (Notes == null) Command.Parameters.AddWithValue("@Notes", DBNull.Value);
            else Command.Parameters.AddWithValue("@Notes", Notes);

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

        public static bool DeleteTest(int TestID)
        {
            string Query = "Delete From Tests Where TestID = @TestID";
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@TestID", TestID);

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

        public static bool IsTestExistByID(int TestID)
        {
            bool Found = false;
            string Query = "Select Top 1 Found=1 From Tests Where TestID = @TestID";
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@TestID", TestID);

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

        public static DataTable GetAllTests()
        {
            DataTable dt = new DataTable();
            string Query = "Select * from Tests";
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

        public static DataTable GetAllTestsAccordingToTestTypeAndLDLApplication(int TestTypeID, int LocalDrivingLicenseApplicationID)
        {
            DataTable dt = new DataTable();
            string Query = "select t.* " +
                "from Tests t inner join TestAppointments tp on t.TestAppointmentID = tp.TestAppointmentID " +
                "inner join TestTypes tt on tp.TestTypeID = tt.TestTypeID " +
                "where tt.TestTypeID = @TestTypeID and tp.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID";
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            Command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);

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
    
        public static bool UpdateNotes (int TestID , string Notes)
        {
            string Query = "update Tests " +
                "set Notes = @Notes " +
                "where TestID = @TestID";
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@TestID", TestID);
            Command.Parameters.AddWithValue("@Notes", Notes);

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
