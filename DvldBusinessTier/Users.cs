using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DvldDataTier; 

namespace DvldBusinessTier
{
    public class Users
    {

        public int UserID { get; set; }
        public int PersonID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public sbyte isActive { get; set; }

        public Users()
        {
            this.UserID = -1;
            this.PersonID = -1;
            this.UserName = "";
            this.Password = "";
            this.isActive = -1;
        }

        public Users(int userID , int personID , string UserName , string Password , sbyte isActive)
        {
            this.UserID = userID; 
            this.PersonID = personID;
            this.UserName = UserName;
            this.Password = Password;
            this.isActive = isActive;   
        }


        static public Users userLogin(string username , string password)
        {
            int userID = -1 , personID = -1;
            sbyte isActive = -1;

            if(dataUser.isUserExist(username, password , ref userID , ref personID , ref isActive))
            {
                return new Users(userID, personID, username, password, isActive); 
            }
            return null; 
        }



    }
}
