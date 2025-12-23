using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DvldDataTier
{
    public class dataLicense
    {

        public static int GetActiveLicenseIDByPersonID(int PersonID, int LicenseClassID)
        {
            int LicenseID = -1;

            SqlConnection connection = new SqlConnection(dataSettings.ConnectionString);

            string query = @"SELECT        Licenses.LicenseID
                            FROM Licenses INNER JOIN
                                                     Drivers ON Licenses.DriverID = Drivers.DriverID
                            WHERE  
                             
                             Licenses.LicenseClass = @LicenseClass 
                              AND Drivers.PersonID = @PersonID
                              And IsActive=1;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@LicenseClass", LicenseClassID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    LicenseID = insertedID;
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);

            }

            finally
            {
                connection.Close();
            }


            return LicenseID;
        }


        public static bool GetLicenseInfoByID(int LicenseID, ref int ApplicationID, ref int DriverID, ref int LicenseClass,
           ref DateTime IssueDate, ref DateTime ExpirationDate, ref string Notes,
           ref decimal PaidFees, ref bool IsActive, ref byte IssueReason, ref int CreatedByUserID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(dataSettings.ConnectionString);

            string query = "SELECT * FROM Licenses WHERE LicenseID = @LicenseID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LicenseID", LicenseID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    // The record was found
                    isFound = true;
                    ApplicationID = (int)reader["ApplicationID"];
                    DriverID = (int)reader["DriverID"];
                    LicenseClass = (int)reader["LicenseClass"];
                    IssueDate = (DateTime)reader["IssueDate"];
                    ExpirationDate = (DateTime)reader["ExpirationDate"];

                    if (reader["Notes"] == DBNull.Value)
                        Notes = "";
                    else
                        Notes = (string)reader["Notes"];

                    PaidFees = Convert.ToDecimal(reader["PaidFees"]);
                    IsActive = (bool)reader["IsActive"];
                    IssueReason = (byte)reader["IssueReason"];
                    CreatedByUserID = (int)reader["DriverID"];


                }
                else
                {
                    // The record was not found
                    isFound = false;
                }

                reader.Close();


            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }


        static public int getLicenseIDByLdlID(int LdlId)
        {
            int LicenseID = -1;

            string query = @"select top 1 LicenseID from Licenses where
                            ApplicationID = (select top 1 ApplicationID from LocalDrivingLicenseApplications where LocalDrivingLicenseApplicationID = @id);";

            SqlConnection connection = new SqlConnection(dataSettings.ConnectionString);

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@id", LdlId);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();


                if (result != null)
                {
                    LicenseID = Convert.ToInt32(result);
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

            return LicenseID;
        }


        static public int insertLicense(int ApplicationID , int DriverID , int LicenseClass, DateTime IssueDate , DateTime ExpirationDate , string Notes ,
            decimal PaidFees , bool IsActive , int IssueReason , int CreatedByUserID)
        {

            string query = @"insert into Licenses
            (ApplicationID , DriverID , LicenseClass, IssueDate , ExpirationDate , Notes , PaidFees , IsActive , IssueReason , CreatedByUserID)
            values (@ApplicationID , @DriverID , @LicenseClass, @IssueDate , @ExpirationDate , @Notes , @PaidFees , @IsActive , @IssueReason , @CreatedByUserID);
            select scope_identity()";

            int @ID = -1;

            SqlConnection connection = new SqlConnection(dataSettings.ConnectionString);

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@DriverID", DriverID);
            command.Parameters.AddWithValue("@LicenseClass", LicenseClass);
            command.Parameters.AddWithValue("@IssueDate", IssueDate);
            command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);

            if(Notes != "")
                command.Parameters.AddWithValue("@Notes", Notes);
            else
                command.Parameters.AddWithValue("@Notes", DBNull.Value);

            command.Parameters.AddWithValue("@PaidFees", PaidFees);
            command.Parameters.AddWithValue("@IsActive", IsActive);
            command.Parameters.AddWithValue("@IssueReason", IssueReason);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

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

        static public byte getLicenseYears(int ApplicationID)
        {
            byte years = 0;

            string query = @"select LicenseClasses.DefaultValidityLength as yearLength from LocalDrivingLicenseApplications
            inner join LicenseClasses on LocalDrivingLicenseApplications.LicenseClassID = LicenseClasses.LicenseClassID
            where ApplicationID = @ApplicationID;";

            SqlConnection connection = new SqlConnection(dataSettings.ConnectionString);

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();


                if (result != null)
                {
                    years = (byte)result;
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

            return years; 
        }

        static public decimal getLicenseFees(int ApplicationID)
        {
            decimal Fees = 0;

            string query = @"select LicenseClasses.ClassFees as Fees from LocalDrivingLicenseApplications
            inner join LicenseClasses on LocalDrivingLicenseApplications.LicenseClassID = LicenseClasses.LicenseClassID
            where ApplicationID = @ApplicationID;";

            SqlConnection connection = new SqlConnection(dataSettings.ConnectionString);

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();


                if (result != null)
                {
                    Fees = Convert.ToDecimal(result);
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

            return Fees;
        }


        static public int getLicenseClassByLicenseID(int LicenseID)
        {
            int LicenseClassID = -1;

            string query = "select LicenseClass from Licenses where LicenseID = @LicenseID;";

            SqlConnection connection = new SqlConnection(dataSettings.ConnectionString);

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LicenseID", LicenseID);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();


                if (result != null)
                {
                    LicenseClassID = Convert.ToInt32(result);
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

            return LicenseClassID;

        }


        static public DataTable getLocalLicenseHistory(int personID)
        {
            DataTable DT = new DataTable();

            SqlConnection connection = new SqlConnection(dataSettings.ConnectionString);

            string Query = @"select LicenseID , ApplicationID , LicenseClasses.ClassName as ClassName, IssueDate , ExpirationDate, IsActive from Licenses
                           inner join LicenseClasses on LicenseClasses.LicenseClassID = Licenses.LicenseClass
                           where DriverID = (
                           select DriverID from Drivers where PersonID = @personID
                           )";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@personID", personID);

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

        static public DataTable getInterLicenseHistory(int personID)
        {
            DataTable DT = new DataTable();

            SqlConnection connection = new SqlConnection(dataSettings.ConnectionString);

            string Query = @"select InternationalLicenseID as internationalID , ApplicationID , IssuedUsingLocalLicenseID as LicenseID ,
                            IssueDate , ExpirationDate, isActive from InternationalLicenses
                            where DriverID = (
                              select DriverID from Drivers where PersonID = @personID
                              )";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@personID", personID);

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


        static public int getAppIDByLicenseID(int LicenseID)
        {
            int AppID = -1;

            string query = @"select ApplicationID from Licenses where LicenseID = @LicenseID;";

            SqlConnection connection = new SqlConnection(dataSettings.ConnectionString);

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LicenseID", LicenseID);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();


                if (result != null)
                {
                    AppID = Convert.ToInt32(result);
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

            return AppID;
        }

        static public bool isinterLicenseExists(int LicenseID , ref DateTime ExpirationDate)
        {
            bool isExists = false;

            string query = "select ExpirationDate from InternationalLicenses where IssuedUsingLocalLicenseID = @LicenseID;"; 

            SqlConnection connection = new SqlConnection(dataSettings.ConnectionString);

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LicenseID", LicenseID);


            try
            {
                connection.Open();
                object result = command.ExecuteScalar();


                if (result != null)
                {
                    ExpirationDate = Convert.ToDateTime(result); 
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

        static public bool isLicenseExists(int LicenseID, ref DateTime ExpirationDate)
        {
            bool isExists = false;

            string query = "select ExpirationDate from Licenses where LicenseID = @LicenseID;";

            SqlConnection connection = new SqlConnection(dataSettings.ConnectionString);

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LicenseID", LicenseID);


            try
            {
                connection.Open();
                object result = command.ExecuteScalar();


                if (result != null)
                {
                    ExpirationDate = Convert.ToDateTime(result);
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

        static public bool isLicenseExists(int LicenseID)
        {
            bool isExists = false;

            string query = "select top 1 found = 1 from Licenses where LicenseID = @LicenseID;";

            SqlConnection connection = new SqlConnection(dataSettings.ConnectionString);

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LicenseID", LicenseID);


            try
            {
                connection.Open();
                object result = command.ExecuteScalar();


                if (result != null && int.TryParse(Convert.ToString(result) , out int found))
                {
                    isExists = (found == 1);
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

        static public int insertinterLicense(int AppID , DateTime ExpirationDate , DateTime IssueDate , int CreatedByUserID)
        {
            int @ID = -1; 
            string query = @"INSERT INTO InternationalLicenses (ApplicationID, DriverID, IssuedUsingLocalLicenseID , IssueDate , ExpirationDate , IsActive , CreatedByUserID)
                            SELECT ApplicationID, DriverID, LicenseID , @IssueDate , @ExpirationDate , 1, @CreatedByUserID
                            FROM Licenses
                            WHERE ApplicationID = @AppID; 
                            select scope_identity() ;";


            SqlConnection connection = new SqlConnection(dataSettings.ConnectionString);

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
            command.Parameters.AddWithValue("@IssueDate", IssueDate);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            command.Parameters.AddWithValue("@AppID", AppID);


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

        static public bool isinterLicenseActive(int LicenseID)
        {
            bool isActive = false;

            string query = "select IsActive from InternationalLicenses where IssuedUsingLocalLicenseID = @LicenseID;";

            SqlConnection connection = new SqlConnection(dataSettings.ConnectionString);

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LicenseID", LicenseID);


            try
            {
                connection.Open();
                object result = command.ExecuteScalar();


                if (result != null)
                {
                    isActive = Convert.ToBoolean(result);
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


            return isActive;
        }

        static public bool isLicenseActive(int LicenseID)
        {
            bool isActive = false;

            string query = "select IsActive from Licenses where LicenseID = @LicenseID;";

            SqlConnection connection = new SqlConnection(dataSettings.ConnectionString);

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LicenseID", LicenseID);


            try
            {
                connection.Open();
                object result = command.ExecuteScalar();


                if (result != null)
                {
                    isActive = Convert.ToBoolean(result);
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


            return isActive;
        }

        static public bool updateIsActiveOfLicense(int LicenseID , bool value)
        {
            int EffectedRows = 0;

            string query = "update Licenses set IsActive = @value where LicenseID = @LicenseID;";

            SqlConnection connection = new SqlConnection(dataSettings.ConnectionString);

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LicenseID", LicenseID);
            command.Parameters.AddWithValue("@value", value);


            try
            {
                connection.Open();
                int result = command.ExecuteNonQuery();
                EffectedRows = result;

            }
            catch (Exception e)
            {
                Console.WriteLine($"error detected : {e}");
            }
            finally
            {
                connection.Close();
            }


            return EffectedRows > 0 ;
        }


    }
}
