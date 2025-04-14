using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccessLayer
{
    public class clsDataCountry
    {
        public static bool GetAllCountryInfoByID (int CountryID,ref string CountryName)
        {
            bool Found = false;
            string Query = "Select * from Countries Where CountryID = @CountryID";
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.Add("@CountryID", CountryID);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if(Reader.Read())
                {
                    CountryName = (string)Reader["CountryName"];
                    Found = true;
                }
                Reader.Close();
            } catch (Exception ex) { }
            finally
            {
                Connection.Close();
            }
            return Found;
        }
    
        public static bool GetAllCountryInfoByName (string CountryName,ref int CountryID)
        {
            bool Found = false;
            string Query = "Select * from Countries Where CountryName = @CountryName";
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.Add("@CountryName", CountryName);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.Read())
                {
                    CountryID = (int)Reader["CountryID"];
                    Found = true;
                }
                Reader.Close();
            }
            catch (Exception ex) { }
            finally
            {
                Connection.Close();
            }
            return Found;
        }
    
        public static bool IsCountryExistByID (int CountryID)
        {
            bool Found = false;
            string Query = "Select Top 1 Found=1 From Countries Where CountryID = @CountryID";
            SqlConnection Connection = new SqlConnection (clsDataAccessSettings.ConnectionString);
            SqlCommand Command = new SqlCommand (Query, Connection);

            Command.Parameters.AddWithValue("@CountryID", CountryID);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                Found = Reader.HasRows;
                Reader.Close();
            } catch (Exception ex) { }
            finally
            {
                Connection.Close();
            }
            return Found;
        }

        public static bool IsCountryExistByName(string CountryName)
        {
            bool Found = false;
            string Query = "Select Top 1 Found=1 From Countries Where CountryName = @CountryName";
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@CountryName", CountryName);

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

        public static DataTable GetAllCountries ()
        {
            DataTable dt = new DataTable();
            string Query = "Select * From Countries";
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand Command = new SqlCommand (Query, Connection);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                dt.Load(Reader);
                Reader.Close();
            } catch (Exception ex) { }
            finally
            {
                Connection.Close();
            }
            return dt;
        }
    }
}
