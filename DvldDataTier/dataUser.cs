using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DvldDataTier
{
    public class dataUser
    {
        static public bool isUserExist(string username , string password, ref int userID , ref int personID , ref sbyte isActive)
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

                if(reader.Read())
                {
                    isExists = true;

                    userID = (int)reader["UserID"];
                    personID = (int)reader["PersonID"];
                    isActive = (bool)reader["IsActive"] ? (sbyte) 1 : (sbyte)0;

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

    }
}
