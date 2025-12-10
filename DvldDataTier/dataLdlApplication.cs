using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvldDataTier
{
    public class dataLdlApplication
    {

        public static DataTable GetAllLocalDrivingLicenseApplications()
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(dataSettings.ConnectionString);

            string query = @"SELECT *
                              FROM LocalDrivingLicenseApplications_View
                              order by ApplicationDate Desc";


            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)

                {
                    dt.Load(reader);
                }

                reader.Close();


            }

            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return dt;
        }

        public static bool GetLdlApplicationInfoByID(
        int LdlApplicationID, ref int ApplicationID,
        ref int LicenseClassID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(dataSettings.ConnectionString);


            string query = "SELECT * FROM LocalDrivingLicenseApplications WHERE LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LdlApplicationID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    ApplicationID = (int)reader["ApplicationID"];
                    LicenseClassID = (int)reader["LicenseClassID"];
                }
                else
                {
                    isFound = false;
                }

                reader.Close();


            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }

        public static bool GetLdlApplicationInfoByApplicationID(
         int ApplicationID, ref int LocalDrivingLicenseApplicationID,
         ref int LicenseClassID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(dataSettings.ConnectionString);

            string query = "SELECT * FROM LocalDrivingLicenseApplications WHERE ApplicationID = @ApplicationID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    LocalDrivingLicenseApplicationID = (int)reader["LocalDrivingLicenseApplicationID"];
                    LicenseClassID = (int)reader["LicenseClassID"];

                }
                else
                {
                    isFound = false;
                }

                reader.Close();


            }
            catch (Exception ex)
            {
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }

        static public int insert_LDL_Application(int applicationID, int licenseClassID)
        {
            int @ID = -1;

            SqlConnection connection = new SqlConnection(dataSettings.ConnectionString);

            string query = @"insert into LocalDrivingLicenseApplications (ApplicationID , LicenseClassID) 
            values(@ApplicationID , @LicenseClassID);
            select SCOPE_IDENTITY()";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicationID", applicationID);
            command.Parameters.AddWithValue("@LicenseClassID", licenseClassID);

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

        static public bool update_LDL_Application(int id , int applicationID, int licenseClassID)
        {
            int EffectedRow = -1;

            SqlConnection connection = new SqlConnection(dataSettings.ConnectionString);

            string query = @"update LocalDrivingLicenseApplications set ApplicationID = @applicationID, LicenseClassID = @licenseClassID
            where LocalDrivingLicenseApplicationID = @id ; ";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicationID", applicationID);
            command.Parameters.AddWithValue("@LicenseClassID", licenseClassID);
            command.Parameters.AddWithValue("@id", id);


            try
            {
                connection.Open();
                int result = command.ExecuteNonQuery();

                EffectedRow = Convert.ToInt32(result);
               

            }
            catch (Exception e)
            {
                EffectedRow = -1; 
                Console.WriteLine($"error detected : {e}");
            }
            finally
            {
                connection.Close();
            }


            return EffectedRow != -1;
        }

        static public bool Delete_LDL_App(int id)
        {
            int effectedRows = 0;

            SqlConnection Connection = new SqlConnection(dataSettings.ConnectionString);

            string Query = "delete from LocalDrivingLicenseApplications where LocalDrivingLicenseApplicationID = @id;";

            SqlCommand Command = new SqlCommand(Query, Connection);

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
