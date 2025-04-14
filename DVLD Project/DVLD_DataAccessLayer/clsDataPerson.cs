using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccessLayer
{
    public class clsDataPerson
    {
        public static bool GetAllPersonInfoByID (int PersonID,ref string NationalNO , ref string FirstName,ref string SecondName,ref string ThirdName,ref string LastName,
            ref DateTime DateOfBirth,ref byte Gendor,ref string Address , ref string Phone,ref string Email,ref int NationalityCountryID,ref string ImagePath)
        {
            bool Found = false;
            string Query = "Select * From People Where PersonID = @PersonID";
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand Command = new SqlCommand(Query,Connection);

            Command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                if(Reader.Read())
                {
                    NationalNO = (string)Reader["NationalNO"];
                    FirstName = (string)Reader["FirstName"];
                    SecondName = (string)Reader["SecondName"];

                    if (Reader["ThirdName"] == DBNull.Value) ThirdName = null;
                    else ThirdName = (string)Reader["ThirdName"];

                    LastName = (string)Reader["LastName"];
                    DateOfBirth = (DateTime)Reader["DateOfBirth"];
                    Gendor = (byte)Reader["Gendor"];
                    Address = (string)Reader["Address"];
                    Phone = (string)Reader["Phone"];

                    if (Reader["Email"] == DBNull.Value) Email = null;
                    else Email = (string)Reader["Email"];

                    NationalityCountryID = (int)Reader["NationalityCountryID"];

                    if (Reader["ImagePath"] == DBNull.Value) ImagePath = null;
                    else ImagePath = (string) Reader["ImagePath"];

                    Found = true;
                }
            } catch (Exception ex) { }
            finally
            {
                Connection.Close();
            }
            return Found;
        }

        public static bool GetAllPersonInfoByNationalNO(string NationalNO,ref int PersonID, ref string FirstName, ref string SecondName, ref string ThirdName, ref string LastName,
            ref DateTime DateOfBirth, ref byte Gendor, ref string Address, ref string Phone, ref string Email, ref int NationalityCountryID, ref string ImagePath)
        {
            bool Found = false;
            string Query = "Select * From People Where NationalNO = @NationalNO";
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@NationalNO", NationalNO);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.Read())
                {
                    PersonID = (int)Reader["PersonID"];
                    FirstName = (string)Reader["FirstName"];
                    SecondName = (string)Reader["SecondName"];

                    if (Reader["ThirdName"] == DBNull.Value) ThirdName = null;
                    else ThirdName = (string)Reader["ThirdName"];

                    LastName = (string)Reader["LastName"];
                    DateOfBirth = (DateTime)Reader["DateOfBirth"];
                    Gendor = (byte)Reader["Gendor"];
                    Address = (string)Reader["Address"];
                    Phone = (string)Reader["Phone"];

                    if (Reader["Email"] == DBNull.Value) Email = null;
                    else Email = (string)Reader["Email"];

                    NationalityCountryID = (int)Reader["NationalityCountryID"];

                    if (Reader["ImagePath"] == DBNull.Value) ImagePath = null;
                    else ImagePath = (string)Reader["ImagePath"];

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

        public static int AddNewPerson (string NationalNO, string FirstName, string SecondName, string ThirdName, string LastName,
            DateTime DateOfBirth, byte Gendor, string Address, string Phone, string Email, int NationalityCountryID, string ImagePath)
        {
            int PersonID = -1;
            string Query = "Insert Into People (NationalNO, FirstName, SecondName, ThirdName, LastName,DateOfBirth, Gendor, Address, Phone,Email,NationalityCountryID,ImagePath)  " +
                "Values (@NationalNO, @FirstName, @SecondName, @ThirdName, @LastName,@DateOfBirth,@Gendor,@Address,@Phone,@Email,@NationalityCountryID,@ImagePath) " +
                "Select SCOPE_IDENTITY()";

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@NationalNO", NationalNO);
            Command.Parameters.AddWithValue("@FirstName", FirstName);
            Command.Parameters.AddWithValue("@SecondName", SecondName);

            if(ThirdName == null) Command.Parameters.AddWithValue("@ThirdName", DBNull.Value);
            else Command.Parameters.AddWithValue("@ThirdName", ThirdName);

            Command.Parameters.AddWithValue("@LastName", LastName);
            Command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            Command.Parameters.AddWithValue("@Gendor", Gendor);
            Command.Parameters.AddWithValue("@Address", Address);
            Command.Parameters.AddWithValue("@Phone", Phone);
            
            if (Email == null) Command.Parameters.AddWithValue("@Email", DBNull.Value);
            else Command.Parameters.AddWithValue("@Email", Email);
                
            Command.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);

            if (ImagePath == null || ImagePath == "") Command.Parameters.AddWithValue("@ImagePath", DBNull.Value);
            else Command.Parameters.AddWithValue("@ImagePath", ImagePath);

            try
            {
                Connection.Open();
                object ob = Command.ExecuteScalar();
                if (ob != null && int.TryParse(ob.ToString(), out PersonID));
            } catch (Exception ex) { }
            finally
            {
                Connection.Close();
            }
            return PersonID;
        }

        public static bool UpdatePerson (int PersonID , string NationalNO, string FirstName, string SecondName, string ThirdName, string LastName,
            DateTime DateOfBirth, byte Gendor, string Address, string Phone, string Email, int NationalityCountryID, string ImagePath)
        {
            string Query = "Update People " +
                "Set NationalNo = @NationalNo," +
                "FirstName = @FirstName," +
                "SecondName = @SecondName," +
                "ThirdName = @ThirdName," +
                "LastName = @LastName," +
                "DateOfBirth = @DateOfBirth," +
                "Gendor = @Gendor," +
                "Address = @Address," +
                "Phone = @Phone," +
                "Email = @Email," +
                "NationalityCountryID = NationalityCountryID," +
                "ImagePath = @ImagePath  " +
                "Where PersonID = @PersonID";

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@PersonID", PersonID);
            Command.Parameters.AddWithValue("@NationalNO", NationalNO);
            Command.Parameters.AddWithValue("@FirstName", FirstName);
            Command.Parameters.AddWithValue("@SecondName", SecondName);

            if (ThirdName == null) Command.Parameters.AddWithValue("@ThirdName", DBNull.Value);
            else Command.Parameters.AddWithValue("@ThirdName", ThirdName);

            Command.Parameters.AddWithValue("@LastName", LastName);
            Command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            Command.Parameters.AddWithValue("@Gendor", Gendor);
            Command.Parameters.AddWithValue("@Address", Address);
            Command.Parameters.AddWithValue("@Phone", Phone);

            if (Email == null) Command.Parameters.AddWithValue("@Email", DBNull.Value);
            else Command.Parameters.AddWithValue("@Email", Email);

            Command.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);

            if (ImagePath == null || ImagePath == "") Command.Parameters.AddWithValue("@ImagePath", DBNull.Value);
            else Command.Parameters.AddWithValue("@ImagePath", ImagePath);


            try
            {
                Connection.Open();
                int NumberOfAffectedRows = Command.ExecuteNonQuery();
                return (NumberOfAffectedRows>0);
            } catch (Exception ex) { }
            finally
            {
                Connection.Close();
            }

            return false;
        }
    
        public static bool DeletePersonByID (int PersonID)
        {
            string Query = "Delete From People Where PersonID = @PersonID";
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@PersonID", PersonID);

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

        public static bool DeletePersonByNationalNO(string NationalNO)
        {
            string Query = "Delete From People Where NationalNO = @NationalNO";
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@NationalNO", NationalNO);

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

        public static bool IsPersonExistByID (int PersonID)
        {
            bool Found = false;
            string Query = "Select Top 1 Found=1 From People Where PersonID = @PersonID";
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@PersonID", PersonID);

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

        public static bool IsPersonExistByNationalNO(string NationalNO)
        {
            bool Found = false;
            string Query = "Select Top 1 Found=1 From People Where NationalNO = @NationalNO";
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@NationalNO", NationalNO);

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

        public static bool IsPersonActiveUserByID (int PersonID)
        {
            bool Found = false;
            string Query = "Select Top 1 Found=1 From Users Where PersonID = @PersonID and IsActive = 1";
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@PersonID", PersonID);

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
        public static DataTable GetAllPeople ()
        {
            DataTable dt = new DataTable();

            string Query = "select p.PersonID , p.NationalNo ," +
                "p.FirstName , p.SecondName , p.ThirdName , p.LastName ," +
                "p.DateOfBirth , p.Gendor , " +
                "case " +
                "when p.Gendor = 0 then 'Male' " +
                "else 'Female' " +
                "end as GendorCaption , " +
                "p.Address , p.Phone , p.Email , p.NationalityCountryID , c.CountryName , p.ImagePath " +
                "from People p inner join Countries c on p.NationalityCountryID = c.CountryID";

            SqlConnection Connection = new SqlConnection( clsDataAccessSettings.ConnectionString);
            SqlCommand Command = new SqlCommand(Query, Connection);

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

        public static bool DoesPersonHaveLicenseWithLicenseClass (int PersonID,int LicenseClassID)
        {
            bool Found = false;
            string Query = "select Top 1 Found=1 " +
                "from People p inner join Drivers d on p.PersonID = d.PersonID " +
                "inner join Licenses l on d.DriverID = l.DriverID " +
                "where p.PersonID = @PersonID and l.LicenseClassID = @LicenseClassID";
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@PersonID", PersonID);
            Command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

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

        public static int GetPersonIDByDriverID (int DriverID)
        {
            int PersonID = -1;
            string Query = "select p.PersonID " +
                "from People p inner join Drivers d on p.PersonID = d.PersonID " +
                "where d.DriverID = @DriverID";
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@DriverID", DriverID);

            try
            {
                Connection.Open();
                object ob = Command.ExecuteScalar();
                if (ob != null && int.TryParse(ob.ToString(), out PersonID)) ;
            }
            catch (Exception ex) { }
            finally
            {
                Connection.Close();
            }

            return PersonID;
        }

    }
}
