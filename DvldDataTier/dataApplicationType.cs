using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvldDataTier
{
    public class dataApplicationType
    {

        static public DataTable getAllApplictionTypes()
        {

            DataTable dt = new DataTable();

            SqlConnection Connection = new SqlConnection(dataSettings.ConnectionString);

            string Query = "select * from ApplicationTypes;";

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

        static public bool UpdateApplicationType(int id, string title, decimal fee)
        {
            int effectedRows = 0;

            SqlConnection Connection = new SqlConnection(dataSettings.ConnectionString);

            string Query = "update ApplicationTypes set ApplicationFees = @fee , ApplicationTypeTitle = @title where ApplicationTypeID = @id;";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@fee", fee);
            Command.Parameters.AddWithValue("@title", title);
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

        static public bool FindApplicationTypeInfo(int id , ref string title , ref decimal fee)
        {
            bool found = false; 

            SqlConnection Connection = new SqlConnection(dataSettings.ConnectionString);

            string Query = "select top 1 * from ApplicationTypes where ApplicationTypeID = @id;";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@id", id);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                if(Reader.Read())
                {
                    found = true;
                    title = Reader["ApplicationTypeTitle"].ToString();
                    fee = Convert.ToDecimal(Reader["ApplicationFees"]);
                }

            }
            catch (Exception E)
            {
                found = false;
                Console.WriteLine(E.Message);
            }
            finally
            {
                Connection.Close() ;
            }

            return found;
        }

    }
}
