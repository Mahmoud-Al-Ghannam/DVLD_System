using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccessLayer
{
    public class clsDataDetainLicense
    {
        public static bool GetAllDetainLicenseInfoByID(int DetainID,ref int LicenseID,ref DateTime DetainDate,ref decimal FineFees,
            ref int CreatedByUserID,ref bool IsReleased,ref Nullable<DateTime> ReleaseDate,ref Nullable<int> ReleasedByUserID,ref Nullable<int> ReleaseApplicationID)
        {
            bool Found = false;
            string Query = "Select * From DetainedLicenses Where DetainID = @DetainID";
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@DetainID", DetainID);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.Read())
                {
                    LicenseID = (int) Reader["LicenseID"];
                    DetainDate = (DateTime) Reader["DetainDate"];
                    FineFees = (decimal) Reader["FineFees"];
                    CreatedByUserID = (int) Reader["CreatedByUserID"];
                    IsReleased = (bool) Reader["IsReleased"];

                    if (Reader["ReleaseDate"] == DBNull.Value) ReleaseDate = null;
                    else ReleaseDate = (DateTime) Reader["ReleaseDate"];

                    if (Reader["ReleasedByUserID"] == DBNull.Value) ReleasedByUserID = null;
                    else ReleasedByUserID = (int) Reader["ReleasedByUserID"];

                    if (Reader["ReleaseApplicationID"] == DBNull.Value) ReleaseApplicationID = null;
                    else ReleaseApplicationID = (int) Reader["ReleaseApplicationID"];

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

        public static bool GetAllDetainLicenseInfoByLicenseID(int LicenseID,ref int DetainID, ref DateTime DetainDate, ref decimal FineFees,
            ref int CreatedByUserID, ref bool IsReleased, ref Nullable<DateTime> ReleaseDate, ref Nullable<int> ReleasedByUserID, ref Nullable<int> ReleaseApplicationID)
        {
            bool Found = false;
            string Query = "Select * From DetainedLicenses Where LicenseID = @LicenseID and IsReleased=0";
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@LicenseID",LicenseID);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.Read())
                {
                    DetainID = (int)Reader["DetainID"];
                    DetainDate = (DateTime)Reader["DetainDate"];
                    FineFees = (decimal)Reader["FineFees"];
                    CreatedByUserID = (int)Reader["CreatedByUserID"];
                    IsReleased = (bool)Reader["IsReleased"];

                    if (Reader["ReleaseDate"] == DBNull.Value) ReleaseDate = null;
                    else ReleaseDate = (DateTime)Reader["ReleaseDate"];

                    if (Reader["ReleasedByUserID"] == DBNull.Value) ReleasedByUserID = null;
                    else ReleasedByUserID = (int)Reader["ReleasedByUserID"];

                    if (Reader["ReleaseApplicationID"] == DBNull.Value) ReleaseApplicationID = null;
                    else ReleaseApplicationID = (int)Reader["ReleaseApplicationID"];

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

        public static int AddNewDetainLicense(int LicenseID, DateTime DetainDate, decimal FineFees,
            int CreatedByUserID, bool IsReleased, Nullable<DateTime> ReleaseDate, Nullable<int> ReleasedByUserID, Nullable<int> ReleaseApplicationID)
        {
            int DetainID = -1;
            string Query = "Insert Into DetainedLicenses (LicenseID, DetainDate, FineFees,CreatedByUserID, IsReleased, ReleaseDate, ReleasedByUserID, ReleaseApplicationID)  " +
                "Values (@LicenseID, @DetainDate, @FineFees,@CreatedByUserID, @IsReleased, @ReleaseDate, @ReleasedByUserID, @ReleaseApplicationID) " +
                "Select SCOPE_IDENTITY()";

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@LicenseID", LicenseID);
            Command.Parameters.AddWithValue("@DetainDate", DetainDate);
            Command.Parameters.AddWithValue("@FineFees", FineFees);
            Command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            Command.Parameters.AddWithValue("@IsReleased", IsReleased);

            if (ReleaseDate == null) Command.Parameters.AddWithValue("@ReleaseDate", DBNull.Value);
            else Command.Parameters.AddWithValue("@ReleaseDate", ReleaseDate);

            if (ReleasedByUserID == null) Command.Parameters.AddWithValue("@ReleasedByUserID", DBNull.Value);
            else Command.Parameters.AddWithValue("@ReleasedByUserID", ReleasedByUserID);

            if (ReleaseApplicationID == null) Command.Parameters.AddWithValue("@ReleaseApplicationID", DBNull.Value);
            else Command.Parameters.AddWithValue("@ReleaseApplicationID", ReleaseApplicationID);
            
            try
            {
                Connection.Open();
                object ob = Command.ExecuteScalar();
                if (ob != null && int.TryParse(ob.ToString(), out DetainID)) ;
            }
            catch (Exception ex) { }
            finally
            {
                Connection.Close();
            }
            return DetainID;
        }

        public static bool UpdateDetainLicense(int DetainID, int LicenseID, DateTime DetainDate, decimal FineFees,
            int CreatedByUserID, bool IsReleased, Nullable<DateTime> ReleaseDate, Nullable<int> ReleasedByUserID, Nullable<int> ReleaseApplicationID)
        {
            string Query = "Update DetainedLicenses " +
                "Set LicenseID = @LicenseID," +
                "DetainDate = @DetainDate," +
                "FineFees = @FineFees," +
                "CreatedByUserID = @CreatedByUserID," +
                "IsReleased = @IsReleased," +
                "ReleaseDate = @ReleaseDate," +
                "ReleasedByUserID = @ReleasedByUserID," +
                "ReleaseApplicationID = @ReleaseApplicationID " +
                "Where DetainID = @DetainID";

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@DetainID", DetainID);
            Command.Parameters.AddWithValue("@LicenseID", LicenseID);
            Command.Parameters.AddWithValue("@DetainDate", DetainDate);
            Command.Parameters.AddWithValue("@FineFees", FineFees);
            Command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            Command.Parameters.AddWithValue("@IsReleased", IsReleased);

            if (ReleaseDate == null) Command.Parameters.AddWithValue("@ReleaseDate", DBNull.Value);
            else Command.Parameters.AddWithValue("@ReleaseDate", ReleaseDate);

            if (ReleasedByUserID == null) Command.Parameters.AddWithValue("@ReleasedByUserID", DBNull.Value);
            else Command.Parameters.AddWithValue("@ReleasedByUserID", ReleasedByUserID);

            if (ReleaseApplicationID == null) Command.Parameters.AddWithValue("@ReleaseApplicationID", DBNull.Value);
            else Command.Parameters.AddWithValue("@ReleaseApplicationID", ReleaseApplicationID);


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

        public static bool DeleteDetainLicense(int DetainID)
        {
            string Query = "Delete From DetainedLicenses Where DetainID = @DetainID";
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@DetainID", DetainID);

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

        public static bool IsDetainLicenseExistByID(int DetainID)
        {
            bool Found = false;
            string Query = "Select Top 1 Found=1 From DetainedLicenses Where DetainID = @DetainID";
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@DetainID", DetainID);

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

        public static DataTable GetAllDetainLicenses()
        {
            DataTable dt = new DataTable();
            string Query = "Select * from DetainedLicenses_View";
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
