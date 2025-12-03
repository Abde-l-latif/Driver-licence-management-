using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvldDataTier
{
    public class dataUser
    {


        /* modification*/

        static public bool isUserExist(string username, string password, ref int userID, ref int personID, ref sbyte isActive)
        {
            bool isExists = false;

            SqlConnection connection = new SqlConnection(dataSettings.ConnectionString);

            string query = @"select * from Users
            where UserName=@UserName and Password=@Password;";

            SqlCommand Command = new SqlCommand(query, connection);

            Command.Parameters.AddWithValue("@UserName", username);
            Command.Parameters.AddWithValue("@Password", password);

            try
            {
                connection.Open();

                SqlDataReader reader = Command.ExecuteReader();

                if (reader.Read())
                {
                    isExists = true;

                    userID = (int)reader["UserID"];
                    personID = (int)reader["PersonID"];
                    isActive = (bool)reader["IsActive"] ? (sbyte)1 : (sbyte)0;

                }

                reader.Close();
            }
            catch (Exception ex)
            {
                isExists = false;
            }
            finally
            {
                connection.Close();
            }

            return isExists;

        }


        /* ========= modification ========= */

        static public bool isUserExistsByPersonID(int PersonID)
        {
            bool isExists = false;

            SqlConnection connection = new SqlConnection(dataSettings.ConnectionString);

            string query = @"select found = 1 from Users
            where PersonID=@PersonID;";

            SqlCommand Command = new SqlCommand(query, connection);

            Command.Parameters.AddWithValue("@PersonID", PersonID);


            try
            {
                connection.Open();

                object result = Command.ExecuteScalar();

                if(result != null)
                {
                    isExists = ((int)result == 1);
                }

            }
            catch (Exception ex)
            {
                isExists = false;
            }
            finally
            {
                connection.Close();
            }

            return isExists;
        }

        static public bool getUserByPersonID(ref int userID , int PersonID ,ref string UserName , ref string Password , ref byte isActive)
        {
            bool isExists = false;

            SqlConnection connection = new SqlConnection(dataSettings.ConnectionString);

            string query = @"select * from Users
            where PersonID=@PersonID;";

            SqlCommand Command = new SqlCommand(query, connection);

            Command.Parameters.AddWithValue("@PersonID", PersonID);


            try
            {
                connection.Open();

                SqlDataReader reader = Command.ExecuteReader();

                if (reader.Read())
                {
                    isExists = true;

                    userID = (int)reader["UserID"];
                    UserName = reader["UserName"].ToString(); 
                    Password = reader["Password"].ToString();
                    isActive = ((bool)reader["IsActive"] ? (byte)1 : (byte)0);
                }

            }
            catch (Exception ex)
            {
                isExists = false;
            }
            finally
            {
                connection.Close();
            }

            return isExists;
        }

        static public bool getUserByUserID(int userID, ref int PersonID, ref string UserName, ref string Password, ref byte isActive)
        {
            bool isExists = false;

            SqlConnection connection = new SqlConnection(dataSettings.ConnectionString);

            string query = @"select * from Users
            where UserID=@UserID;";

            SqlCommand Command = new SqlCommand(query, connection);

            Command.Parameters.AddWithValue("@UserID", userID);


            try
            {
                connection.Open();

                SqlDataReader reader = Command.ExecuteReader();

                if (reader.Read())
                {
                    isExists = true;

                    PersonID = (int)reader["PersonID"];
                    UserName = reader["UserName"].ToString();
                    Password = reader["Password"].ToString();
                    isActive = ((bool)reader["IsActive"] ? (byte)1 : (byte)0);
                }

            }
            catch (Exception ex)
            {
                isExists = false;
            }
            finally
            {
                connection.Close();
            }

            return isExists;
        }


        static public DataTable GetAllUsers()
        {
            DataTable DT = new DataTable();
            SqlConnection connection = new SqlConnection(dataSettings.ConnectionString);

            string Query = @"select
                             UserID ,
                             U.PersonID ,
                             P.FirstName + ' ' + case when P.SecondName is null then '' else  P.SecondName end + ' ' +
                             case when P.ThirdName is null then '' else P.ThirdName end + ' ' + P.LastName as FullName ,
                             UserName ,
                             IsActive 
                             from Users U
                             inner join People P on P.PersonID = U.PersonID ;";

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

        static public int insertUser(int PersonID , string UserName , string Password , byte IsActive)
        {
            int @ID = -1;

            SqlConnection Connection = new SqlConnection(dataSettings.ConnectionString);

            string query = @"INSERT INTO Users (PersonID, UserName, Password, IsActive) VALUES (@PersonID , @UserName , @Password , @IsActive);
             select SCOPE_IDENTITY()";

            SqlCommand Command = new SqlCommand(query, Connection);

            Command.Parameters.AddWithValue("@PersonID", PersonID);
            Command.Parameters.AddWithValue("@UserName", UserName);
            Command.Parameters.AddWithValue("@Password", Password);
            Command.Parameters.AddWithValue("@IsActive", IsActive);

            try
            {
                Connection.Open();
                object result = Command.ExecuteScalar();


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
                Connection.Close();
            }

            return @ID;
        }

        static public bool UpdateUser(int UserID , string UserName , string password , byte IsActive)
        {
            int effectedRow = 0;

            string query = "update Users set UserName = @UserName , Password = @password , IsActive = @IsActive where UserID = @UserID; ";

            SqlConnection Connection = new SqlConnection(dataSettings.ConnectionString);

            SqlCommand Command = new SqlCommand(query, Connection);

            Command.Parameters.AddWithValue("@UserName", UserName);
            Command.Parameters.AddWithValue("@password", password);
            Command.Parameters.AddWithValue("@IsActive", IsActive);
            Command.Parameters.AddWithValue("@UserID", UserID);

            try
            {
                Connection.Open();
                effectedRow = Command.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                Console.WriteLine($"error detected : {e}");
            }
            finally
            {
                Connection.Close();
            }

            return effectedRow > 0;

        }

        /* delete */

        static public bool UpdatePassword(string password , int userID)
        {
            int effectedRow = 0;

            string query = "update Users set Password = @password where UserID = @UserID; ";

            SqlConnection Connection = new SqlConnection(dataSettings.ConnectionString);

            SqlCommand Command = new SqlCommand(query, Connection);


            Command.Parameters.AddWithValue("@password", password);   
            Command.Parameters.AddWithValue("@UserID", userID);


            try
            {
                Connection.Open();
                effectedRow = Command.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                Console.WriteLine($"error detected : {e}");
            }
            finally
            {
                Connection.Close();
            }

            return effectedRow > 0;
        }

        static public DataTable filterUser(string user, string Filter)
        {
            DataTable DT = new DataTable();

            string Query = "";

            SqlConnection connection = new SqlConnection(dataSettings.ConnectionString);

            switch (Filter)
            {
                case "user ID":
                    Query = @"select
                            UserID ,
                            U.PersonID ,
                            P.FirstName + ' ' + P.SecondName + ' ' + P.ThirdName + ' ' + P.LastName as FullName ,
                            UserName ,
                            IsActive 
                            from Users U
                            inner join People P on P.PersonID = U.PersonID
                            where UserID = @UserID ; ";
                    break;
                case "person ID":
                    Query = @"select
                            UserID ,
                            U.PersonID ,
                            P.FirstName + ' ' + P.SecondName + ' ' + P.ThirdName + ' ' + P.LastName as FullName ,
                            UserName ,
                            IsActive 
                            from Users U
                            inner join People P on P.PersonID = U.PersonID
                            where U.PersonID = @PersonID ; ";
                    break;
                case "UserName":
                    Query = @"select
                            UserID ,
                            U.PersonID ,
                            P.FirstName + ' ' + P.SecondName + ' ' + P.ThirdName + ' ' + P.LastName as FullName ,
                            UserName ,
                            IsActive 
                            from Users U
                            inner join People P on P.PersonID = U.PersonID
                            where UserName = @UserName ; ";
                    break;
                case "is Active":
                    Query = @"select
                            UserID ,
                            U.PersonID ,
                            P.FirstName + ' ' + P.SecondName + ' ' + P.ThirdName + ' ' + P.LastName as FullName ,
                            UserName ,
                            IsActive 
                            from Users U
                            inner join People P on P.PersonID = U.PersonID
                            where IsActive = @IsActive ; ";
                    break;
                case "FullName":
                    Query = @"select * from (
                            select
                            UserID ,
                            U.PersonID ,
                            P.FirstName + ' ' + P.SecondName + ' ' + P.ThirdName + ' ' + P.LastName as FullName ,
                            UserName ,
                            IsActive 
                            from Users U
                            inner join People P on P.PersonID = U.PersonID) T 
                            where T.FullName = @FullName";
                    break;

            }
   ;

            SqlCommand command = new SqlCommand(Query, connection);


            switch (Filter)
            {
                case "person ID":
                    command.Parameters.AddWithValue("@PersonID", user);
                    break;
                case "user ID":
                    command.Parameters.AddWithValue("@UserID", user);
                    break;
                case "UserName":
                    command.Parameters.AddWithValue("@UserName", user);
                    break;
                case "is Active":
                    command.Parameters.AddWithValue("@IsActive", user);
                    break;
                case "FullName":
                    command.Parameters.AddWithValue("@FullName", user);
                    break;
            }
   ;


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

        static public bool isPasswordCorrect(string password, int userID)
        {
            bool isCorrect = false;

            SqlConnection connection = new SqlConnection(dataSettings.ConnectionString);

            string query = @"select found = 1 from Users
            where Password=@password and UserID = @UserID;";

            SqlCommand Command = new SqlCommand(query, connection);

            Command.Parameters.AddWithValue("@UserID", userID);
            Command.Parameters.AddWithValue("@password", password);


            try
            {
                connection.Open();

                object result = Command.ExecuteScalar();

                if (result != null)
                {
                    isCorrect = true;
                }

            }
            catch (Exception ex)
            {
                isCorrect = false;
            }
            finally
            {
                connection.Close();
            }

            return isCorrect;
        }


        /* ========= delete ========= */

        static public bool DeleteUserById(int UserID)
        {
            bool Status = false;

            SqlConnection Connection = new SqlConnection(dataSettings.ConnectionString);

            string query = "delete from Users where UserID = @UserID;";

            SqlCommand Command = new SqlCommand(query, Connection);

            Command.Parameters.AddWithValue("@UserID", UserID);

            try
            {
                Connection.Open();

                int result = Command.ExecuteNonQuery();

                Status = result > 0;

            }
            catch (Exception e)
            {
                Status = false;
            }
            finally
            {
                Connection.Close();
            }

            return Status;
        }

    }
}
