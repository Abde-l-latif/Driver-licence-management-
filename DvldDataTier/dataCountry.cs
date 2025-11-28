using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvldDataTier
{
    public class dataCountry
    {
        static public bool FindCountryByName(string countryName, ref int CountryID)
        {
            bool isFound = false;

            string query = "select top 1 * from Countries where CountryName = @countryName;";

            SqlConnection Connection = new SqlConnection(dataSettings.ConnectionString);

            SqlCommand command = new SqlCommand(query, Connection);

            command.Parameters.AddWithValue("@countryName" , countryName);

            try
            {
                Connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if(reader.Read())
                {
                    isFound = true;
                    CountryID = (int)reader["CountryID"];
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                isFound = false;
            }
            finally
            {
                Connection.Close();
            }

            return isFound;
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

    }
}
