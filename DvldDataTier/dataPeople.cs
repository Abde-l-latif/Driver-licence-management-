using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;


namespace DvldDataTier
{
    public class dataPeople
    {

        static public bool FindPersonByID(int PersonID , ref string NationalNo , ref string FirstName , ref string SecondName , ref string ThirdName ,
            ref string LastName , ref DateTime DateOfBirth, ref string Gender, ref string Address , ref string Phone , ref string Email ,
            ref string Country , ref string ImagePath )
        {

            bool Found = false; 

            SqlConnection connection = new SqlConnection(dataSettings.ConnectionString); 

            string query = @"select top 1 NationalNo , FirstName , SecondName , ThirdName , LastName , DateOfBirth , Gendor , Address , Phone
                  ,Email , C.CountryName as Country , ImagePath 
                  from People P INNER JOIN Countries C on C.CountryID = P.NationalityCountryID
                  where PersonID = @PersonID ; ";

            SqlCommand Command = new SqlCommand(query, connection);

            Command.Parameters.AddWithValue("@PersonID", PersonID); 

            try
            {
                connection.Open();
                SqlDataReader reader = Command.ExecuteReader();

                if(reader.Read() )
                {
                    Found = true; 

                    NationalNo = reader["NationalNo"].ToString();
                    FirstName = reader["FirstName"].ToString();
                    SecondName = reader["SecondName"].ToString();

                    if (reader["ThirdName"] != DBNull.Value)
                        ThirdName = reader["ThirdName"].ToString();
                    else
                        ThirdName = ""; 

                    LastName = reader["LastName"].ToString();
                    DateOfBirth = (DateTime)reader["DateOfBirth"];
                    Gender = (byte)reader["Gendor"] == 0 ? "Male" : "Female";
                    Address = reader["Address"].ToString();
                    Phone = reader["Phone"].ToString();
                    Country = reader["Country"].ToString(); 

                    if (reader["Email"] != DBNull.Value)
                        Email = reader["Email"].ToString();
                    else
                        Email = "";

                    if (reader["ImagePath"] != DBNull.Value)
                        ImagePath = reader["ImagePath"].ToString();
                    else
                        ImagePath = "";

                }

                reader.Close(); 
            }
            catch(Exception e)
            {
                Console.WriteLine($"error detected : {e}");
            }
            finally
            {
                connection.Close(); 
            }

            return Found;
        }

        static public DataTable getAllPeople()
        {
            DataTable DT = new DataTable();
            SqlConnection connection = new SqlConnection(dataSettings.ConnectionString);

            string Query = @"select PersonID , NationalNo , FirstName, SecondName , ThirdName , LastName , case when Gendor = 0 then 'Male' else 'Female' end as Gender , DateOfBirth ,
            Countries.CountryName, Phone , Email from People 
            inner join Countries on Countries.CountryID = People.NationalityCountryID ; ";

            SqlCommand command = new SqlCommand(Query , connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if(reader.HasRows)
                {
                    DT.Load(reader);
                }

                reader.Close();

            } 
            catch (Exception e)
            {
                Console.WriteLine($"error detected : {e}");
            }
            finally
            {
                connection.Close();
            } 

            return DT; 
        }

        static public DataTable filterPeople(string person , string Filter)
        {
            DataTable DT = new DataTable();

            string Query = "";

            SqlConnection connection = new SqlConnection(dataSettings.ConnectionString);

            switch(Filter)
            {
                case "person ID":
                    Query = @"select PersonID , NationalNo , FirstName, SecondName , ThirdName , LastName , case when Gendor = 0 then 'Male' else 'Female' end as Gender , DateOfBirth ,
                    Countries.CountryName, Phone , Email from People 
                    inner join Countries on Countries.CountryID = People.NationalityCountryID 
                    where PersonID = @PersonID; ";
                    break; 
                case "national No":
                    Query = @"select PersonID , NationalNo , FirstName, SecondName , ThirdName , LastName , case when Gendor = 0 then 'Male' else 'Female' end as Gender , DateOfBirth ,
                    Countries.CountryName, Phone , Email from People 
                    inner join Countries on Countries.CountryID = People.NationalityCountryID 
                    where NationalNo = @NationalNo; ";
                    break;
                case "first name":
                    Query = @"select PersonID , NationalNo , FirstName, SecondName , ThirdName , LastName , case when Gendor = 0 then 'Male' else 'Female' end as Gender , DateOfBirth ,
                    Countries.CountryName, Phone , Email from People 
                    inner join Countries on Countries.CountryID = People.NationalityCountryID 
                    where FirstName = @FirstName; ";
                    break;
                case "second name":
                    Query = @"select PersonID , NationalNo , FirstName, SecondName , ThirdName , LastName , case when Gendor = 0 then 'Male' else 'Female' end as Gender , DateOfBirth ,
                    Countries.CountryName, Phone , Email from People 
                    inner join Countries on Countries.CountryID = People.NationalityCountryID 
                    where SecondName = @SecondName; ";
                    break;
                case "third name":
                    Query = @"select PersonID , NationalNo , FirstName, SecondName , ThirdName , LastName , case when Gendor = 0 then 'Male' else 'Female' end as Gender , DateOfBirth ,
                    Countries.CountryName, Phone , Email from People 
                    inner join Countries on Countries.CountryID = People.NationalityCountryID 
                    where ThirdName = @ThirdName; ";
                    break;
                case "last name":
                    Query = @"select PersonID , NationalNo , FirstName, SecondName , ThirdName , LastName , case when Gendor = 0 then 'Male' else 'Female' end as Gender , DateOfBirth ,
                    Countries.CountryName, Phone , Email from People 
                    inner join Countries on Countries.CountryID = People.NationalityCountryID 
                    where LastName = @LastName; ";
                    break;
                case "nationality":
                    Query = @"select PersonID , NationalNo , FirstName, SecondName , ThirdName , LastName , case when Gendor = 0 then 'Male' else 'Female' end as Gender , DateOfBirth ,
                    Countries.CountryName, Phone , Email from People 
                    inner join Countries on Countries.CountryID = People.NationalityCountryID 
                    where Countries.CountryName = @Country; ";
                    break; 
                case "gender":
                    Query = @"select * from 
                    (
                    select PersonID , NationalNo , FirstName, SecondName , ThirdName , LastName , case when Gendor = 0 then 'Male' else 'Female'
                    end as Gender , DateOfBirth , Countries.CountryName, Phone , Email from People 
                    inner join Countries on Countries.CountryID = People.NationalityCountryID 
                    )t 
                    where Gender = @Gender;";
                    break; 
                case "phone":
                    Query = @"select PersonID , NationalNo , FirstName, SecondName , ThirdName , LastName , case when Gendor = 0 then 'Male' else 'Female' end as Gender , DateOfBirth ,
                    Countries.CountryName, Phone , Email from People 
                    inner join Countries on Countries.CountryID = People.NationalityCountryID 
                    where Phone = @Phone; ";
                    break; 
                case "email":
                    Query = @"select PersonID , NationalNo , FirstName, SecondName , ThirdName , LastName , case when Gendor = 0 then 'Male' else 'Female' end as Gender , DateOfBirth ,
                    Countries.CountryName, Phone , Email from People 
                    inner join Countries on Countries.CountryID = People.NationalityCountryID 
                    where Email = @Email; ";
                    break; 
            }
            ;

            SqlCommand command = new SqlCommand(Query, connection);


            switch (Filter)
            {
                case "person ID":
                    command.Parameters.AddWithValue("@PersonID", person);
                    break;
                case "national No":
                    command.Parameters.AddWithValue("@NationalNo", person);
                    break;
                case "first name":
                    command.Parameters.AddWithValue("@FirstName", person);
                    break;
                case "second name":
                    command.Parameters.AddWithValue("@SecondName", person);
                    break;
                case "third name":
                    command.Parameters.AddWithValue("@ThirdName", person);
                    break;
                case "last name":
                    command.Parameters.AddWithValue("@LastName", person);
                    break;
                case "nationality":
                    command.Parameters.AddWithValue("@Country", person);
                    break;
                case "gender":
                    command.Parameters.AddWithValue("@Gender", person);
                    break;
                case "phone":
                    command.Parameters.AddWithValue("@Phone", person);
                    break;
                case "email":
                    command.Parameters.AddWithValue("@Email", person);
                    break;

            }
            ;


            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    DT.Load(reader);
                }

                reader.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine($"error detected : {e}");
            }
            finally
            {
                connection.Close();
            }

            return DT;
        }

        static public DataTable getAllCountries()
        {
            DataTable DT = new DataTable();
            SqlConnection connection = new SqlConnection(dataSettings.ConnectionString);

            string Query = @"select CountryName from Countries ;";

            SqlCommand command = new SqlCommand(Query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    DT.Load(reader);
                }

                reader.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine($"error detected : {e}");
            }
            finally
            {
                connection.Close();
            }

            return DT;
        }

        static public bool checkNationalNoExists(string text)
        {
            bool isExists = false;

            SqlConnection connection = new SqlConnection(dataSettings.ConnectionString);

            string query = @"select found = 1 from People where NationalNo = @NationalNo ;";

            SqlCommand command = new SqlCommand(query , connection);

            command.Parameters.AddWithValue("@NationalNo", text);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();

                if(result != null && int.TryParse(result.ToString() , out int number))
                {
                    isExists = true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"error detected : {e}");
            }
            finally
            {
                connection.Close(); 
            }

            return isExists;
        }

        static public int insertPerson(string NationalNo , string FirstName , string SecondName, string ThirdName , string LastName,
                DateTime DateOfBirth , string Gender, string Address , string Phone , string Email , string Country , string ImagePath)
        {
            int @ID = -1;


            SqlConnection connection = new SqlConnection(dataSettings.ConnectionString);

            string query = @"insert into People (NationalNo, FirstName, SecondName, ThirdName, LastName, DateOfBirth,
            Gendor, Address, Phone, Email, NationalityCountryID, ImagePath) values(@NationalNo , @FirstName , @SecondName
            , @ThirdName , @LastName , @DateOfBirth , @Gender , @Address,
            @Phone , @Email , (select CountryID from Countries where CountryName = @Country) , @ImagePath);
            select SCOPE_IDENTITY()";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@NationalNo", NationalNo);
            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@SecondName", SecondName);
            command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            command.Parameters.AddWithValue("@Gender", Gender == "Male" ? 0 : 1);
            command.Parameters.AddWithValue("@Phone", Phone);
            command.Parameters.AddWithValue("@Country", Country);
            command.Parameters.AddWithValue("@Address", Address);

            if (Email == "")
                command.Parameters.AddWithValue("@Email", DBNull.Value);
            else
                command.Parameters.AddWithValue("@Email", Email);

            if (ThirdName == "")
                command.Parameters.AddWithValue("@ThirdName", DBNull.Value);
            else
                command.Parameters.AddWithValue("@ThirdName", ThirdName);

            if (ImagePath == "")
                command.Parameters.AddWithValue("@ImagePath", DBNull.Value);
            else
                command.Parameters.AddWithValue("@ImagePath", ImagePath);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();

             
                if (result != null)
                {
                    @ID = Convert.ToInt32(result);
                }
       
            }
            catch (Exception e)
            {
                Console.WriteLine($"error detected : {e}");
            }
            finally
            {
                connection.Close();
            }

            return @ID;
        }


        static public bool UpdatePerson(int PersonID , string NationalNo, string FirstName, string SecondName, string ThirdName,
            string LastName, DateTime DateOfBirth, string Gender, string Address, string Phone, string Email,
            string Country, string ImagePath)
        {

            int EffectedRows = -1; 

            SqlConnection Connection = new SqlConnection(dataSettings.ConnectionString);

            string query = @"update People set NationalNo = @NationalNo , FirstName = @FirstName , SecondName = @SecondName , ThirdName = @ThirdName ,LastName = @LastName
            , DateOfBirth = @DateOfBirth , Gendor = @Gender , Address = @Address , Phone = @Phone , Email = @Email , NationalityCountryID = 
            (select top 1 CountryID from Countries where CountryName = @Country) , ImagePath = @ImagePath
            where PersonID = @PersonID ; ";

            SqlCommand command = new SqlCommand(query, Connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@NationalNo", NationalNo);
            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@SecondName", SecondName);
            command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            command.Parameters.AddWithValue("@Gender", Gender == "Male" ? 0 : 1);
            command.Parameters.AddWithValue("@Phone", Phone);
            command.Parameters.AddWithValue("@Country", Country);
            command.Parameters.AddWithValue("@Address", Address);

            if (Email == "")
                command.Parameters.AddWithValue("@Email", DBNull.Value);
            else
                command.Parameters.AddWithValue("@Email", Email);

            if (ThirdName == "")
                command.Parameters.AddWithValue("@ThirdName", DBNull.Value);
            else
                command.Parameters.AddWithValue("@ThirdName", ThirdName);

            if (ImagePath == "")
                command.Parameters.AddWithValue("@ImagePath", DBNull.Value);
            else
                command.Parameters.AddWithValue("@ImagePath", ImagePath);

            try
            {
                Connection.Open();

                int result = command.ExecuteNonQuery();

                EffectedRows = result;

            }
            catch(Exception e)
            {
                Console.WriteLine($"error detected : {e}");
            }
            finally
            {
                Connection.Close(); 
            }


            return EffectedRows >= 1; 
        }


        static public bool deletePerson(int PersonID)
        {
            bool Status = false;

            SqlConnection Connection = new SqlConnection(dataSettings.ConnectionString);

            string query = "delete from People where PersonID = @PersonID;";

            SqlCommand Command = new SqlCommand(query, Connection);

            Command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                Connection.Open();

                int result = Command.ExecuteNonQuery();

                Status = result > 0;

            }
            catch (Exception e)
            {
                Status = false;
            }
            finally
            {
                Connection.Close();
            }

            return Status;
        }
    }
}
