using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace DvldDataTier
{
    public class dataApplication
    {


        static public DataTable getAll_InterDL_ApplicationPeople()
        {
            DataTable dt = new DataTable();

            SqlConnection Connection = new SqlConnection(dataSettings.ConnectionString);

            string Query = @"select InternationalLicenseID as IntLicense , ApplicationID , DriverID , IssuedUsingLocalLicenseID as LocalLicenseID , 
            IssueDate, ExpirationDate , IsActive from InternationalLicenses;";

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

        static public DataTable getFiltredInterDLapp(string text, string Filter)
        {
            DataTable dt = new DataTable();

            SqlConnection Connection = new SqlConnection(dataSettings.ConnectionString);

            string Query = @" select InternationalLicenseID as IntLicense , ApplicationID , DriverID , IssuedUsingLocalLicenseID as LocalLicenseID , 
            IssueDate, ExpirationDate , IsActive from InternationalLicenses
            where " + (Filter == "IntLicense" ? "InternationalLicenseID" : Filter == "ApplicationID" ? "ApplicationID" : Filter == "DriverID" ? "DriverID" : Filter == "LocalLicenseID" ?
            "IssuedUsingLocalLicenseID" : "") + " like @text ;";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@text", text + "%");


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


        /* === License Classes === */

        static public DataTable getAllLicenseClasses()
        {
            DataTable dt = new DataTable();

            SqlConnection Connection = new SqlConnection(dataSettings.ConnectionString);

            string Query = @"select LicenseClassID , ClassName from LicenseClasses ;";

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


  
        static public decimal getApplicationFee(int id)
        {
            decimal fee = 0; 
            SqlConnection Connection = new SqlConnection(dataSettings.ConnectionString);

            string Query = @"select ApplicationFees from ApplicationTypes where ApplicationTypeID = @id;";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@id", id); 

            try
            {
                Connection.Open();
                object result = Command.ExecuteScalar();

                if(result != null)
                {
                    fee = Convert.ToDecimal(result);
                }

            }
            catch (Exception E)
            {
                Console.WriteLine(E.Message);
            }
            finally
            {
                Connection.Close();
            }

            return fee; 
        }

        static public bool isPersonAppalreadyExists(string ClassName , string NationalNo)
        {
            bool isExists = false; 

            string query = @"select found = 1  from (
                select 
                L.LocalDrivingLicenseApplicationID as LDLAppId,
                C.ClassName ,

                (select NationalNo from People where PersonID = A.ApplicantPersonID) as NationalNo ,

                (select FirstName + ' ' +
	                case when SecondName is null then '' else SecondName end + ' ' +
	                case when ThirdName is null then '' else ThirdName end + ' ' + 
	                LastName
	                from People where PersonID = A.ApplicantPersonID) as FullName,
                A.ApplicationDate , 
                (select Count(TestAppointments.TestTypeID) from Tests inner join TestAppointments on Tests.TestAppointmentID = TestAppointments.TestAppointmentID
                where TestAppointments.LocalDrivingLicenseApplicationID = L.LocalDrivingLicenseApplicationID and Tests.TestResult = 1) as PassedTest,
                case when A.ApplicationStatus = 1 then 'New'
                     when A.ApplicationStatus = 2 then 'Cancelled'
	                 when A.ApplicationStatus = 3 then 'Completed' end as Status
                from LocalDrivingLicenseApplications L
                inner join LicenseClasses C on C.LicenseClassID = L.LicenseClassID
                inner join Applications A on A.ApplicationID = L.ApplicationID
                )T
                where ClassName = @ClassName and NationalNo = @NationalNo and Status != 'Cancelled';";

            SqlConnection connection = new SqlConnection(dataSettings.ConnectionString);

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ClassName", ClassName);
            command.Parameters.AddWithValue("@NationalNo", NationalNo);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();


                if (result != null)
                {
                    isExists = (Convert.ToInt32(result) == 1);
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

        static public int getAppIdByLDLid(int LDLid)
        {
            int AppId = -1;

            SqlConnection connection = new SqlConnection(dataSettings.ConnectionString);

            string query = @"select ApplicationID from LocalDrivingLicenseApplications L where L.LocalDrivingLicenseApplicationID = @id;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@id", LDLid);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();


                if (result != null)
                {
                    AppId = Convert.ToInt32(result);
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

            return AppId;
        }


        static public int getPersonIDByAppID(int AppID)
        {
            int Id = -1;

            SqlConnection connection = new SqlConnection(dataSettings.ConnectionString);

            string query = @"select ApplicantPersonID from Applications where ApplicationID = @id;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@id", AppID);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();


                if (result != null)
                {
                    Id = Convert.ToInt32(result);
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

            return Id;
        }

        static public void getApplicationDetails(int ApplicationID, ref string status, ref string type, ref string applicant, ref string createdBy,
                ref decimal fees, ref DateTime date, ref DateTime statusDate)
        {
            string query = @"   select 
	                            A.ApplicationID,
	                            case when A.ApplicationStatus = 3 then 'Completed' 
	                            when A.ApplicationStatus = 2 then 'Cancelled'
	                            when A.ApplicationStatus = 1 then 'New'
	                            end as Status ,
	                            PaidFees as Fees,
	                            (select ApplicationTypeTitle from ApplicationTypes where ApplicationTypeID = A.ApplicationTypeID) as Type,
	                            (select FirstName + ' ' + 
	                            case when SecondName is null then '' else SecondName end + ' ' +
	                            case when ThirdName is null then '' else ThirdName end  + ' ' + 
	                            LastName 
	                            from People where PersonID = A.ApplicantPersonID) as FullName , 
	                            ApplicationDate as Date,
	                            LastStatusDate as StatusDate,
	                            (select UserName from Users where UserID = A.CreatedByUserID) as UserName
	                            from Applications A
                            where A.ApplicationID = @id;";

            SqlConnection Connection = new SqlConnection(dataSettings.ConnectionString);
            SqlCommand Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@id", ApplicationID);

            try
            {
                Connection.Open();
                SqlDataReader reader = Command.ExecuteReader();

                if (reader.Read())
                {
                    status = reader["status"].ToString();
                    type = reader["Type"].ToString();
                    applicant = reader["FullName"].ToString();
                    createdBy = reader["UserName"].ToString();
                    fees = (decimal)reader["Fees"];
                    date = (DateTime)reader["Date"];
                    statusDate = (DateTime)reader["StatusDate"];
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

        }


        /* === Application === */

        static public int insertApplication(int ApplicantPersonID , DateTime ApplicationDate , int ApplicationTypeID , int ApplicationStatus
                , DateTime LastStatusDate , Decimal PaidFees , int CreatedByUserID)
        {

            int @ID = -1;

            SqlConnection connection = new SqlConnection(dataSettings.ConnectionString);

            string query = @"insert into Applications (ApplicantPersonID, ApplicationDate, ApplicationTypeID, ApplicationStatus, LastStatusDate, PaidFees,
            CreatedByUserID) values(@ApplicantPersonID, @ApplicationDate, @ApplicationTypeID, @ApplicationStatus, @LastStatusDate, @PaidFees,
            @CreatedByUserID);
            select SCOPE_IDENTITY()";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicantPersonID", ApplicantPersonID);
            command.Parameters.AddWithValue("@ApplicationDate", ApplicationDate);
            command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
            command.Parameters.AddWithValue("@ApplicationStatus", ApplicationStatus);
            command.Parameters.AddWithValue("@LastStatusDate", LastStatusDate);
            command.Parameters.AddWithValue("@PaidFees", PaidFees);
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


        static public bool updateApplication(int ApplicationID , DateTime ApplicationDate , int ApplicationTypeID, byte ApplicationStatus
                , DateTime LastStatusDate, Decimal PaidFees, int CreatedByUserID)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(dataSettings.ConnectionString);

            string query = @"Update  Applications  
                            set 
                                ApplicationDate = @ApplicationDate,
                                ApplicationTypeID = @ApplicationTypeID,
                                ApplicationStatus = @ApplicationStatus, 
                                LastStatusDate = @LastStatusDate,
                                PaidFees = @PaidFees,
                                CreatedByUserID=@CreatedByUserID
                            where ApplicationID=@ApplicationID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("ApplicationDate", @ApplicationDate);
            command.Parameters.AddWithValue("ApplicationTypeID", @ApplicationTypeID);
            command.Parameters.AddWithValue("ApplicationStatus", @ApplicationStatus);
            command.Parameters.AddWithValue("LastStatusDate", @LastStatusDate);
            command.Parameters.AddWithValue("PaidFees", @PaidFees);
            command.Parameters.AddWithValue("CreatedByUserID", @CreatedByUserID);


            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                return false;
            }

            finally
            {
                connection.Close();
            }

            return (rowsAffected > 0);
        }


        public static bool GetApplicationInfoByID(int ApplicationID,
             ref int ApplicantPersonID, ref DateTime ApplicationDate, ref int ApplicationTypeID,
             ref byte ApplicationStatus, ref DateTime LastStatusDate,
             ref decimal PaidFees, ref int CreatedByUserID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(dataSettings.ConnectionString);

            string query = "SELECT * FROM Applications WHERE ApplicationID = @ApplicationID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    // The record was found
                    isFound = true;

                    ApplicantPersonID = (int)reader["ApplicantPersonID"];
                    ApplicationDate = (DateTime)reader["ApplicationDate"];
                    ApplicationTypeID = (int)reader["ApplicationTypeID"];
                    ApplicationStatus = (byte)reader["ApplicationStatus"];
                    LastStatusDate = (DateTime)reader["LastStatusDate"];
                    PaidFees = Convert.ToDecimal(reader["PaidFees"]);
                    CreatedByUserID = (int)reader["CreatedByUserID"];


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

        public static bool DeleteApplication(int ApplicationID)
        {

            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(dataSettings.ConnectionString);

            string query = @"Delete Applications 
                                where ApplicationID = @ApplicationID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

            try
            {
                connection.Open();

                rowsAffected = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                // Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {

                connection.Close();

            }

            return (rowsAffected > 0);

        }

        public static bool IsApplicationExist(int ApplicationID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(dataSettings.ConnectionString);

            string query = "SELECT Found=1 FROM Applications WHERE ApplicationID = @ApplicationID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                isFound = reader.HasRows;

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

        public static bool DoesPersonHaveActiveApplication(int PersonID, int ApplicationTypeID)
        {

            //incase the ActiveApplication ID !=-1 return true.
            return (GetActiveApplicationID(PersonID, ApplicationTypeID) != -1);
        }

        public static int GetActiveApplicationID(int PersonID, int ApplicationTypeID)
        {
            int ActiveApplicationID = -1;

            SqlConnection connection = new SqlConnection(dataSettings.ConnectionString);

            string query = @"SELECT ActiveApplicationID=ApplicationID FROM Applications WHERE
             ApplicantPersonID = @ApplicantPersonID and ApplicationTypeID=@ApplicationTypeID and ApplicationStatus=1";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicantPersonID", PersonID);
            command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();


                if (result != null && int.TryParse(result.ToString(), out int AppID))
                {
                    ActiveApplicationID = AppID;
                }
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                return ActiveApplicationID;
            }
            finally
            {
                connection.Close();
            }

            return ActiveApplicationID;
        }

        public static int GetActiveApplicationIDForLicenseClass(int PersonID, int ApplicationTypeID, int LicenseClassID)
        {
            int ActiveApplicationID = -1;

            SqlConnection connection = new SqlConnection(dataSettings.ConnectionString);

            string query = @"SELECT ActiveApplicationID=Applications.ApplicationID  
                            From
                            Applications INNER JOIN
                            LocalDrivingLicenseApplications ON Applications.ApplicationID = LocalDrivingLicenseApplications.ApplicationID
                            WHERE ApplicantPersonID = @ApplicantPersonID 
                            and ApplicationTypeID=@ApplicationTypeID 
							and LocalDrivingLicenseApplications.LicenseClassID = @LicenseClassID
                            and ApplicationStatus=1";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicantPersonID", PersonID);
            command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
            try
            {
                connection.Open();
                object result = command.ExecuteScalar();


                if (result != null && int.TryParse(result.ToString(), out int AppID))
                {
                    ActiveApplicationID = AppID;
                }
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                return ActiveApplicationID;
            }
            finally
            {
                connection.Close();
            }

            return ActiveApplicationID;
        }

        public static bool UpdateStatus(int ApplicationID, short NewStatus)
        {

            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(dataSettings.ConnectionString);

            string query = @"Update  Applications  
                            set 
                                ApplicationStatus = @NewStatus, 
                                LastStatusDate = @LastStatusDate
                            where ApplicationID=@ApplicationID;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@NewStatus", NewStatus);
            command.Parameters.AddWithValue("LastStatusDate", DateTime.Now);


            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                return false;
            }

            finally
            {
                connection.Close();
            }

            return (rowsAffected > 0);
        }

    }
}
