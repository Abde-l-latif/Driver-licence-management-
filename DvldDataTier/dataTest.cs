using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DvldDataTier
{
    public class dataTest
    {
      
        static public void GetScheduleTestInfo(int id , int testType , ref string ClassName , ref string fullName , ref Decimal fees , ref int Trials) 
        {
            string query = @"select ClassName ,
            (select FirstName + ' ' +
	                            case when SecondName is null then '' else SecondName end + ' ' +
	                            case when ThirdName is null then '' else ThirdName end + ' ' + 
	                            LastName
	                            from People where PersonID = A.ApplicantPersonID) as FullName,
	            (select TestTypeFees from TestTypes where TestTypeID = @testType) as Fees,
	            (select count(TestResult) as trial from Tests inner join
		            (select * from TestAppointments where LocalDrivingLicenseApplicationID = @id) T on T.TestAppointmentID = Tests.TestAppointmentID 
            where T.TestTypeID = @testType and TestResult = 0) as Trials
	            from LocalDrivingLicenseApplications L 
            inner join Applications A on A.ApplicationID = L.ApplicationID 
            inner join LicenseClasses C on L.LicenseClassID = C.LicenseClassID 
            where L.LocalDrivingLicenseApplicationID = @id;";

            SqlConnection connection = new SqlConnection(dataSettings.ConnectionString);
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@id", id);
            command.Parameters.AddWithValue("@testType", testType);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    ClassName = reader["ClassName"].ToString();
                    fullName = reader["FullName"].ToString();
                    fees = (decimal)reader["Fees"];
                    Trials = (int)reader["Trials"];
                }

                reader.Close();

            }
            catch (Exception E)
            {
                Console.WriteLine(E.Message);
            }
            finally
            {
                connection.Close();
            }

        }

        static public bool updateIsLocked(int id)
        {
            int effectedRows = 0;

            SqlConnection Connection = new SqlConnection(dataSettings.ConnectionString);

            string Query = "update TestAppointments set IsLocked = @Locked where TestAppointmentID = @id ;";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@Locked", true);
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

        static public Decimal getTestFee(int id)
        {
            decimal fee = 0;
            SqlConnection Connection = new SqlConnection(dataSettings.ConnectionString);

            string Query = @"select TestTypeFees from TestTypes where TestTypeID = @id;";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@id", id);

            try
            {
                Connection.Open();
                object result = Command.ExecuteScalar();

                if (result != null)
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

        static public bool insertTest(int TestAppointmentID, bool TestResult, string Notes, int CreatedByUserID , ref int TestID)
        {
            int id = 0;

            SqlConnection connection = new SqlConnection(dataSettings.ConnectionString);

            string query = @"insert into Tests (TestAppointmentID, TestResult, Notes, CreatedByUserID)
            values(@TestAppointmentID, @TestResult, @Notes, @CreatedByUserID);
            select SCOPE_IDENTITY()";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
            command.Parameters.AddWithValue("@TestResult", TestResult);
            if(Notes != "")
                command.Parameters.AddWithValue("@Notes", Notes);
            else
                command.Parameters.AddWithValue("@Notes", DBNull.Value);

            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if(result != null)
                {
                    id = Convert.ToInt32(result);
                    TestID = id; 
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

            return id > 0 ;
        }

        static public bool isTestFailedExists(int LdlID , int TestType)
        {
            bool exists = false; 
            string query = @"select count(TestAppointments.TestTypeID) from Tests
            inner join TestAppointments on TestAppointments.TestAppointmentID = Tests.TestAppointmentID
            where TestAppointments.LocalDrivingLicenseApplicationID = @LdlID and TestAppointments.TestTypeID = @TestType and Tests.TestResult = 0 ;";

            SqlConnection Connection = new SqlConnection(dataSettings.ConnectionString);

            SqlCommand command = new SqlCommand(query, Connection);

            command.Parameters.AddWithValue("@LdlID", LdlID);
            command.Parameters.AddWithValue("@TestType", TestType);


            try
            {
                Connection.Open();
                object result = command.ExecuteScalar();
                if (result != null)
                {
                    int TestFailed = Convert.ToInt32(result);
                    exists = (TestFailed > 0);
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

        static public bool isTestPassedExists(int LdlID, int TestType)
        {
            bool exists = false;
            string query = @"select count(TestAppointments.TestTypeID) from Tests
            inner join TestAppointments on TestAppointments.TestAppointmentID = Tests.TestAppointmentID
            where TestAppointments.LocalDrivingLicenseApplicationID = @LdlID and TestAppointments.TestTypeID = @TestType and Tests.TestResult = 1;";

            SqlConnection Connection = new SqlConnection(dataSettings.ConnectionString);

            SqlCommand command = new SqlCommand(query, Connection);

            command.Parameters.AddWithValue("@LdlID", LdlID);
            command.Parameters.AddWithValue("@TestType", TestType);


            try
            {
                Connection.Open();
                object result = command.ExecuteScalar();
                if (result != null)
                {
                    int TestPassed = Convert.ToInt32(result);
                    exists = (TestPassed > 0);
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

        static public int getPassedTests(int LocalDrivingLicenseApplicationID)
        {
            int passedTests = 0;

            SqlConnection Connection = new SqlConnection(dataSettings.ConnectionString);

            string Query = @"select count(TestResult) as passedTest from Tests
            inner join TestAppointments on TestAppointments.TestAppointmentID = Tests.TestAppointmentID
            where LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID and TestResult = 1";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);

            try
            {

                Connection.Open();

                object result = Command.ExecuteScalar();

                if (result != null)
                {
                    passedTests = Convert.ToInt32(result);
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

            return passedTests;
        }
     


    }
}
