using System;
using System.Data;
using DvldDataTier; 

namespace DvldBusinessTier
{
    public class Users
    {

        enum enMode { addMode , updateMode}

        enMode Mode; 

        public int UserID { get; set; }
        public int PersonID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool isActive { get; set; }

        public Users()
        {
            this.UserID = -1;
            this.PersonID = -1;
            this.UserName = "";
            this.Password = "";
            this.isActive = true;
            Mode = enMode.addMode;
        }

        public Users(int userID , int personID , string UserName , string Password , bool isActive)
        {
            this.UserID = userID; 
            this.PersonID = personID;
            this.UserName = UserName;
            this.Password = Password;
            this.isActive = isActive;
            Mode = enMode.updateMode; 
        }


        static public Users userLogin(string username , string password)
        {
            int userID = -1 , personID = -1;
            sbyte isActive = -1;

            if(dataUser.GetUserByUsernamePassword(username, password , ref userID , ref personID , ref isActive))
            {
                return new Users(userID, personID, username, password, isActive == 1 ? true : false); 
            }
            return null; 
        }

        static public bool isUserExistByPersonID(int personID)
        {
            return dataUser.isUserExistsByPersonID(personID);
        }

        static public DataTable GetAllUsers()
        {
            return dataUser.GetAllUsers();
        }

        static public Users getUserByPersonID(int personID)
        {
            int userID = -1;
            string username = "", password = "";
            byte isActive = 0 ;
            if(dataUser.getUserByPersonID(ref userID , personID , ref username , ref password , ref isActive))
            {
                return new Users(userID, personID, username, password, isActive == 1 ? true : false);
            }
            return null;
        }

        static public Users getUserByUserID(int UserID)
        {
            int personID = -1;
            string username = "", password = "";
            byte isActive = 0;
            if (dataUser.getUserByUserID(UserID, ref personID, ref username, ref password, ref isActive))
            {
                return new Users(UserID, personID, username, password, isActive == 1 ? true : false);
            }
            return null;
        }


        static public bool DeleteUser(int userID)
        {
            return dataUser.DeleteUserById(userID);
        }

        private bool addUser()
        {
            this.UserID = dataUser.insertUser(this.PersonID , this.UserName , this.Password, Convert.ToByte(this.isActive));
            return (this.UserID != -1);
        }

        private bool UpdateUser()
        {
            return dataUser.UpdateUser(this.UserID, this.UserName , this.Password , Convert.ToByte(this.isActive)); 
        }

        public bool Save()
        {
            if(Mode == enMode.addMode)
            {
                if (addUser())
                {
                    Mode = enMode.updateMode; 
                    return true;
                }
                return false; 
            }  else if (Mode == enMode.updateMode)
            {
                return UpdateUser();
            }

            return false;
        }

    }
}
