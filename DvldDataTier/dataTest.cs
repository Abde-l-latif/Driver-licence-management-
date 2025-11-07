using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvldDataTier
{
    public class dataTest
    {
        static public DataTable getAllTestTypes()
        {
            DataTable dt = new DataTable();

            SqlConnection Connection = new SqlConnection(dataSettings.ConnectionString);

            string Query = "select * from TestTypes ;";

            SqlCommand Command = new SqlCommand(Query, Connection);

            try
            {
                Connection.Open();
                SqlDataReader reader = Command.ExecuteReader();

                if (reader.HasRows)
                {
                    dt.Load(reader);
                }

                reader.Close();

            }
            catch (Exception E)
            {
                Console.WriteLine(E.Message);
            }
            finally
            {
                Connection.Close();
            }

            return dt;
        }

        static public bool UpdateTestType(int id, string title, string description , decimal fee)
        {
            int effectedRows = 0;

            SqlConnection Connection = new SqlConnection(dataSettings.ConnectionString);

            string Query = "update TestTypes set TestTypeFees = @fee , TestTypeTitle = @title , TestTypeDescription = @description where TestTypeID = @id";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@fee", fee);
            Command.Parameters.AddWithValue("@title", title);
            Command.Parameters.AddWithValue("@description", description);
            Command.Parameters.AddWithValue("@id", id);

            try
            {
                Connection.Open();
                effectedRows = Command.ExecuteNonQuery();
            }
            catch (Exception E)
            {
                Console.WriteLine(E.Message);
            }
            finally
            {
                Connection.Close();
            }

            return effectedRows > 0;
        }
    }
}
