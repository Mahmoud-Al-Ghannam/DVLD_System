using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DVLD_DataAccessLayer
{
    public class clsDataTestAppointment
    {
        public static bool GetAllTestAppointmentInfoByID(int TestAppointmentID,ref int TestTypeID,ref int LocalDrivingLicenseApplicationID,ref DateTime AppointmentDate,
            ref decimal PaidFees,ref int CreatedByUserID,ref bool IsLocked,ref Nullable<int> RetakeTestApplicationID)
        {
            bool Found = false;
            string Query = "Select * From TestAppointments Where TestAppointmentID = @TestAppointmentID";
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.Read())
                {
                    TestTypeID = (int) Reader["TestTypeID"];
                    LocalDrivingLicenseApplicationID = (int) Reader["LocalDrivingLicenseApplicationID"];
                    AppointmentDate = (DateTime) Reader["AppointmentDate"];
                    PaidFees = (decimal) Reader["PaidFees"];
                    CreatedByUserID = (int) Reader["CreatedByUserID"];
                    IsLocked = (bool) Reader["IsLocked"];

                    if (Reader["RetakeTestApplicationID"] == DBNull.Value) RetakeTestApplicationID = null;
                    else RetakeTestApplicationID = (int) Reader["RetakeTestApplicationID"];

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

        public static int AddNewTestAppointment(int TestTypeID,int LocalDrivingLicenseApplicationID, DateTime AppointmentDate,
            decimal PaidFees, int CreatedByUserID, bool IsLocked, Nullable<int> RetakeTestApplicationID)
        {
            int TestAppointmentID = -1;
            string Query = "Insert Into TestAppointments (TestTypeID,LocalDrivingLicenseApplicationID, AppointmentDate,PaidFees, CreatedByUserID, IsLocked, RetakeTestApplicationID)  " +
                "Values (@TestTypeID,@LocalDrivingLicenseApplicationID, @AppointmentDate,@PaidFees, @CreatedByUserID, @IsLocked, @RetakeTestApplicationID) " +
                "Select SCOPE_IDENTITY()";

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            Command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            Command.Parameters.AddWithValue("@AppointmentDate", AppointmentDate);
            Command.Parameters.AddWithValue("@PaidFees", PaidFees);
            Command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            Command.Parameters.AddWithValue("@IsLocked", IsLocked);

            if (RetakeTestApplicationID == null) Command.Parameters.AddWithValue("@RetakeTestApplicationID", DBNull.Value);
            else Command.Parameters.AddWithValue("@RetakeTestApplicationID", RetakeTestApplicationID);

            try
            {
                Connection.Open();
                object ob = Command.ExecuteScalar();
                if (ob != null && int.TryParse(ob.ToString(), out TestAppointmentID)) ;
            }
            catch (Exception ex) { }
            finally
            {
                Connection.Close();
            }
            return TestAppointmentID;
        }

        public static bool UpdateTestAppointment(int TestAppointmentID, int TestTypeID, int LocalDrivingLicenseApplicationID, DateTime AppointmentDate,
            decimal PaidFees, int CreatedByUserID, bool IsLocked, Nullable<int> RetakeTestApplicationID)
        {
            string Query = "Update TestAppointments " +
                "Set TestTypeID = @TestTypeID," +
                "LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID," +
                "AppointmentDate = @AppointmentDate," +
                "PaidFees = @PaidFees," +
                "CreatedByUserID = @CreatedByUserID," +
                "IsLocked = @IsLocked," +
                "RetakeTestApplicationID = @RetakeTestApplicationID " +
                "Where TestAppointmentID = @TestAppointmentID";

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
            Command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            Command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            Command.Parameters.AddWithValue("@AppointmentDate", AppointmentDate);
            Command.Parameters.AddWithValue("@PaidFees", PaidFees);
            Command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            Command.Parameters.AddWithValue("@IsLocked", IsLocked);

            if (RetakeTestApplicationID == null) Command.Parameters.AddWithValue("@RetakeTestApplicationID", DBNull.Value);
            else Command.Parameters.AddWithValue("@RetakeTestApplicationID", RetakeTestApplicationID);

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

        public static bool DeleteTestAppointment(int TestAppointmentID)
        {
            string Query = "Delete From TestAppointments Where TestAppointmentID = @TestAppointmentID";
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);

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

        public static bool IsTestAppointmentExistByID(int TestAppointmentID)
        {
            bool Found = false;
            string Query = "Select Top 1 Found=1 From TestAppointments Where TestAppointmentID = @TestAppointmentID";
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);

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

        public static DataTable GetAllTestAppointments()
        {
            DataTable dt = new DataTable();
            string Query = "Select * from TestAppointments_View";
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
    
        public static bool CanAddANewTestAppointmentForLocalDrivingLicneseApplictaion (int TestTypeID,int LDLApplicationID)
        {
            bool Can = true;
            DataTable dt = new DataTable();
            string Query = "select top 1 CanAddNew=0 " +
                "from TestAppointments tp left outer join Tests t on tp.TestAppointmentID = t.TestAppointmentID " +
                "where (tp.IsLocked = 0 or t.TestResult = 1) and tp.TestTypeID = @TestTypeID and tp.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID";
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LDLApplicationID);
            Command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                Can = !Reader.HasRows;
                Reader.Close();
            }
            catch (Exception ex) { }
            finally
            {
                Connection.Close();
            }

            Can = Can && (clsDataLocalDrivingLicenseApplication.GetNumberOfPassedTests(LDLApplicationID) == (int) TestTypeID-1);
            
            return Can;
        }

        public static DataTable GetAllTestAppointmentsAccordingToTestTypeAndLDLApplication (int TestTypeID, int LocalDrivingLicenseApplicationID)
        {
            DataTable dt = new DataTable();
            string Query = "select tpv.* " +
                "from TestAppointments_View tpv inner join TestAppointments tp on tpv.TestAppointmentID = tp.TestAppointmentID " +
                "where tp.TestTypeID = @TestTypeID and tp.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID";
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

        public static bool IsThereAnyTestAppointmentAccordingToTestTypeAndLDLApplication(int TestTypeID, int LocalDrivingLicenseApplicationID)
        {
            bool Found = false;
            string Query = "select top 1 Found=1 " +
                "from TestAppointments_View tpv inner join TestAppointments tp on tpv.TestAppointmentID = tp.TestAppointmentID " +
                "where tp.TestTypeID = @TestTypeID and tp.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID";
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            Command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                Found = Reader.HasRows;
                Reader.Close();
            }
            catch (Exception ex) { }
            finally
            {
                Connection.Close();
            }
            return Found;
        }

        public static int GetAnActiveTestAppointmentForLocalDrivingLicenseApplication (int LocalDrivingLicenseApplicationID,int TestTypeID)
        {
            int TestAppointmentID = -1;
            string Query = "select TestAppointmentID " +
                "from TestAppointments " +
                "where LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID and TestTypeID = @TestTypeID and IsLocked = 0";

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            Command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);

            try
            {
                Connection.Open();
                object ob = Command.ExecuteScalar();
                if (ob != null && int.TryParse(ob.ToString(), out TestAppointmentID)) ;
            }
            catch (Exception ex) { }
            finally
            {
                Connection.Close();
            }
            return TestAppointmentID;
        }
        
        public static bool UpdateAppointmentDate (int TestAppointmentID,DateTime AppointmentDate)
        {
            if (AppointmentDate < DateTime.Now) return false;

            string Query = "update TestAppointments " +
                "set AppointmentDate = @AppointmentDate " +
                "where TestAppointmentID = @TestAppointmentID";

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
            Command.Parameters.AddWithValue("@AppointmentDate", AppointmentDate);

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
