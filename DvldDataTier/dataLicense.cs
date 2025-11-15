using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DvldDataTier
{
    public class dataLicense
    {

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

        static public int getLicenseClassIdByLdlID(int LdlID)
        {
            int LicenseClassID = -1;  

            string query = @"select LicenseClassID from LocalDrivingLicenseApplications
            where LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = @LdlID;";

            SqlConnection connection = new SqlConnection(dataSettings.ConnectionString);

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LdlID", LdlID);

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

        static public void GetLicenseDetails(int ApplicationID , ref int LicenseID , ref int DriverID , ref DateTime IssueDate , ref DateTime ExpirationDate ,
            ref string Notes , ref byte IssueReason , ref bool IsActive , ref string ClassName , ref string FullName , ref string NationalNo , ref byte Gender,
            ref DateTime BirthDate , ref string ImagePath)
        {
            string query = @"select 
            LicenseID , DriverID , IssueDate , ExpirationDate , Notes , IssueReason , IsActive , LicenseClasses.ClassName as ClassName ,
            (
            select FirstName + ' ' +
            case when SecondName is null then '' else SecondName end + ' ' +
            case when ThirdName is null then '' else ThirdName end + ' ' +
            LastName from People where PersonID = Applications.ApplicantPersonID 
            ) as FullName  ,
            (select NationalNo from People where PersonID = Applications.ApplicantPersonID) as NationalNo,
            (select Gendor from People where PersonID = Applications.ApplicantPersonID) as Gender,
            (select DateOfBirth from People where PersonID = Applications.ApplicantPersonID) as BirthDate,
            (select ImagePath from People where PersonID = Applications.ApplicantPersonID) as ImagePath
            from Licenses
            inner join LicenseClasses on LicenseClasses.LicenseClassID = Licenses.LicenseClass
            inner join Applications on Applications.ApplicationID = Licenses.ApplicationID
            where Applications.ApplicationID = @ApplicationID;";

            SqlConnection connection = new SqlConnection(dataSettings.ConnectionString);

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

            try
            {
                connection.Open();
                SqlDataReader Reader = command.ExecuteReader();
                if (Reader.Read())
                {
                    LicenseID = (int)Reader["LicenseID"];
                    DriverID = (int)Reader["DriverID"];
                    IssueReason = (byte)Reader["IssueReason"];
                    IssueDate = (DateTime)Reader["IssueDate"];
                    ExpirationDate = (DateTime)Reader["ExpirationDate"];
                    BirthDate = (DateTime)Reader["BirthDate"];
                    Gender = (byte)Reader["Gender"];
                    ClassName = Reader["ClassName"].ToString();
                    FullName = Reader["FullName"].ToString();
                    NationalNo = Reader["NationalNo"].ToString();
                    IsActive = (bool)Reader["IsActive"];

                    if (String.IsNullOrEmpty(Reader["Notes"].ToString()))
                        Notes = "";
                    else
                        Notes = Reader["Notes"].ToString();

                    if (String.IsNullOrEmpty(Reader["ImagePath"].ToString()))
                        ImagePath = "";
                    else
                        ImagePath = Reader["ImagePath"].ToString();
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

        }

    }
}
