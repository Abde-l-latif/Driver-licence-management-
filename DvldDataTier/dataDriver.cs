using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvldDataTier
{
    public class dataDriver
    {

        static public bool isDriverExists(int personID)
        {
            bool exists = false;

            string query = @"select top 1 found = 1 from Drivers where PersonID = @personID;";

            SqlConnection Connection = new SqlConnection(dataSettings.ConnectionString);

            SqlCommand command = new SqlCommand(query, Connection);

            command.Parameters.AddWithValue("@personID", personID);

            try
            {
                Connection.Open();
                object result = command.ExecuteScalar();

                if (result != null)
                {
                    int found = Convert.ToInt32(result);
                    exists = (found == 1);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"error detected : {e}");
            }
            finally
            {
                Connection.Close();
            }

            return exists;
        }

        static public int insertDriver(int personID , int CreatedByUserID , DateTime CreatedDate)
        {

            int id = -1; 

            string query = @"insert into Drivers (PersonID , CreatedByUserID , CreatedDate) values (@PersonID, @CreatedByUserID , @CreatedDate);
            select scope_identity();";

            SqlConnection Connection = new SqlConnection(dataSettings.ConnectionString);

            SqlCommand command = new SqlCommand(query, Connection);

            command.Parameters.AddWithValue("@personID", personID);

            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            command.Parameters.AddWithValue("@CreatedDate", CreatedDate);

            try
            {
                Connection.Open();
                object result = command.ExecuteScalar();

                if(result != null)
                    id = Convert.ToInt32(result); 

            }
            catch (Exception e)
            {
                Console.WriteLine($"error detected : {e}");
            }
            finally
            {
                Connection.Close();
            }

            return id;

        }

        static public int getDriverIdByPersonID(int personID)
        {
            int id = -1;

            string query = @"select DriverID from Drivers where PersonID = @personID ;";

            SqlConnection Connection = new SqlConnection(dataSettings.ConnectionString);

            SqlCommand command = new SqlCommand(query, Connection);

            command.Parameters.AddWithValue("@personID", personID);

            try
            {

                Connection.Open();
                object result = command.ExecuteScalar();

                if (result != null)
                    id = (int)result;

            }
            catch (Exception e)
            {
                Console.WriteLine($"error detected : {e}");
            }
            finally
            {
                Connection.Close();
            }

            return id;
        }
        
        static public DataTable getAllDrivers()
        {
            DataTable DT = new DataTable();

            SqlConnection connection = new SqlConnection(dataSettings.ConnectionString);

            string Query = @"select distinct D.DriverID , D.PersonID , P.NationalNo ,
                            (
                                select P.FirstName + ' ' +
                                case when P.SecondName is null then '' else P.SecondName end + ' ' +
                                case when P.ThirdName is null then '' else P.ThirdName end + ' ' +
                                P.LastName 
                            ) as FullName, 
                            D.CreatedDate as Date , 
                            TT.ActiveLicenses
                            from Drivers D
                            inner join People P on D.PersonID = P.PersonID
                            inner join Licenses L on L.DriverID = D.DriverID
                            inner join (select T.DriverID , count(T.isActive) as ActiveLicenses  from
                            (
                            select * from Licenses where IsActive = 1
                            ) T
                            group by T.DriverID) TT on D.DriverID = TT.DriverID;";

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

        static public DataTable getFiltredDrivers(string Text , string Filter)
        {
            DataTable DT = new DataTable();

            SqlConnection connection = new SqlConnection(dataSettings.ConnectionString);

            string Query = @"SELECT * FROM (
                            select distinct D.DriverID , D.PersonID , P.NationalNo ,
                            (
                                select P.FirstName + ' ' +
                                case when P.SecondName is null then '' else P.SecondName end + ' ' +
                                case when P.ThirdName is null then '' else P.ThirdName end + ' ' +
                                P.LastName 
                            ) as FullName, 
                            D.CreatedDate as Date , 
                            TT.ActiveLicenses
                            from Drivers D
                            inner join People P on D.PersonID = P.PersonID
                            inner join Licenses L on L.DriverID = D.DriverID
                            inner join (select T.DriverID , count(T.isActive) as ActiveLicenses  from
                            (
                            select * from Licenses where IsActive = 1
                            ) T
                            group by T.DriverID) TT on D.DriverID = TT.DriverID
                            )TB where " + (Filter == "Driver ID" ? "TB.DriverID" : Filter == "Person ID" ? "TB.PersonID" : Filter == "Full Name" ? "TB.FullName" :
                            Filter == "National No" ? "TB.NationalNo" : "") + " like @Text;";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@Text", Text + "%"); 

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

    }
}
