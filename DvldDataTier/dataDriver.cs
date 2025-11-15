using System;
using System.Collections.Generic;
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


    }
}
