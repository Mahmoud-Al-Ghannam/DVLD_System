using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccessLayer
{
    public class clsDataTestType
    {
        public static bool GetAllTestTypeInfoByID(int TestTypeID,ref string TestTypeTitle,ref string TestTypeDescription,ref decimal TestTypeFees)
        {
            bool Found = false;
            string Query = "Select * From TestTypes Where TestTypeID = @TestTypeID";
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.Read())
                {
                    TestTypeTitle = (string)Reader["TestTypeTitle"];
                    TestTypeDescription = (string)Reader["TestTypeDescription"];
                    TestTypeFees = (decimal)Reader["TestTypeFees"];
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

        public static int AddNewTestType(string TestTypeTitle, string TestTypeDescription, decimal TestTypeFees)
        {
            int TestTypeID = -1;
            string Query = "Insert Into TestTypes (TestTypeTitle,TestTypeDescription,TestTypeFees)  " +
                "Values (@TestTypeTitle,@TestTypeDescription,@TestTypeFees) " +
                "Select SCOPE_IDENTITY()";

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@TestTypeTitle", TestTypeTitle);
            Command.Parameters.AddWithValue("@TestTypeDescription", TestTypeDescription);
            Command.Parameters.AddWithValue("@TestTypeFees", TestTypeFees);

            try
            {
                Connection.Open();
                object ob = Command.ExecuteScalar();
                if (ob != null && int.TryParse(ob.ToString(), out TestTypeID)) ;
            }
            catch (Exception ex) { }
            finally
            {
                Connection.Close();
            }
            return TestTypeID;
        }

        public static bool UpdateTestType(int TestTypeID, string TestTypeTitle, string TestTypeDescription, decimal TestTypeFees)
        {
            string Query = "Update TestTypes " +
                "Set TestTypeTitle = @TestTypeTitle," +
                "TestTypeDescription = @TestTypeDescription," +
                "TestTypeFees = @TestTypeFees " +
                "Where TestTypeID = @TestTypeID";

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            Command.Parameters.AddWithValue("@TestTypeTitle", TestTypeTitle);
            Command.Parameters.AddWithValue("@TestTypeDescription", TestTypeDescription);
            Command.Parameters.AddWithValue("@TestTypeFees", TestTypeFees);


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

        public static bool DeleteTestType(int TestTypeID)
        {
            string Query = "Delete From TestTypes Where TestTypeID = @TestTypeID";
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

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

        public static bool IsTestTypeExistByID(int TestTypeID)
        {
            bool Found = false;
            string Query = "Select Top 1 Found=1 From TestTypes Where TestTypeID = @TestTypeID";
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

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

        public static DataTable GetAllTestTypes()
        {
            DataTable dt = new DataTable();
            string Query = "Select * from TestTypes";
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
