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

        /* === Application Type === */
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

                if(reader.HasRows)
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

        static public bool UpdateApplicationType(int id , string title , decimal fee)
        {
            int effectedRows = 0;

            SqlConnection Connection = new SqlConnection(dataSettings.ConnectionString);

            string Query = "update ApplicationTypes set ApplicationFees = @fee , ApplicationTypeTitle = @title where ApplicationTypeID = @id;";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@fee" , fee);
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


        /* === Local Driving License Application === */
        static public DataTable getAll_LDL_ApplicationPeople()
        {
            DataTable dt = new DataTable();

            SqlConnection Connection = new SqlConnection(dataSettings.ConnectionString);

            string Query = @"select 
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
                inner join Applications A on A.ApplicationID = L.ApplicationID;";

            SqlCommand Command = new SqlCommand(Query, Connection);

            try
            {
                Connection.Open();
                SqlDataReader reader = Command.ExecuteReader();

                if(reader.HasRows)
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

        static public DataTable getFiltred_LDL_ApplicationPeople(string text , string Filter)
        {
            DataTable dt = new DataTable();

            SqlConnection Connection = new SqlConnection(dataSettings.ConnectionString);

           string Query = @"select * from 
            (
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
            ) T " + (Filter == "National No" ? $"where NationalNo = @text;" : Filter == "Status" ? $"where Status = @text;" : Filter == "Full Name"
            ? $"where FullName = @text;" : Filter == "LDLAppId" ? $"where LDLAppId = @text;" : "")
            ;

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@text", text); 


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

        static public void GetLDLpersonDetails(int id , ref string AppliedLicense , ref int passedTest )
        {
            string query = @"select ClassName , PassedTest from (
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
                where LDLAppId = @id;";

            SqlConnection Connection = new SqlConnection(dataSettings.ConnectionString);
            SqlCommand Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@id", id);
            try
            {
                Connection.Open();
                SqlDataReader reader = Command.ExecuteReader();

                if (reader.Read())
                {
                    AppliedLicense = reader["ClassName"].ToString();
                    passedTest = (int)reader["PassedTest"]; 
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

        static public bool insert_LDL_Application(int applicationID , int licenseClassID, ref int L_D_Lid)
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
                    L_D_Lid = @ID; 
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


            return @ID != -1 ;
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


        /* === Application === */
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

        static public byte updateApplicationStatus(int ApplicationID , int ApplicationStatus)
        {
            int effectedRows = 0; 

            string query = @"update Applications set ApplicationStatus = @ApplicationStatus, LastStatusDate = GETDATE() 
            where ApplicationID = @ApplicationID;";

            SqlConnection Connection = new SqlConnection(dataSettings.ConnectionString);

            SqlCommand Command = new SqlCommand(query, Connection);

            Command.Parameters.AddWithValue("@ApplicationStatus", ApplicationStatus);
            Command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

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

            return (byte)effectedRows ;


        }

        static public byte updateApplicationDate(int ApplicationID, DateTime ApplicationDate)
        {
            int effectedRows = 0;

            string query = @"update Applications set ApplicationDate = @ApplicationDate 
            where ApplicationID = @ApplicationID;";

            SqlConnection Connection = new SqlConnection(dataSettings.ConnectionString);

            SqlCommand Command = new SqlCommand(query, Connection);

            Command.Parameters.AddWithValue("@ApplicationDate", ApplicationDate);
            Command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

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

            return (byte)effectedRows;


        }

    }
}
