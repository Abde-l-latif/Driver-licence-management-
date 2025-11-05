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
        public sbyte isActive { get; set; }

        public Users()
        {
            this.UserID = -1;
            this.PersonID = -1;
            this.UserName = "";
            this.Password = "";
            this.isActive = -1;
            Mode = enMode.addMode;
        }

        public Users(int userID , int personID , string UserName , string Password , sbyte isActive)
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

            if(dataUser.isUserExist(username, password , ref userID , ref personID , ref isActive))
            {
                return new Users(userID, personID, username, password, isActive); 
            }
            return null; 
        }

        static public bool isUserExist(int personID)
        {
            return dataUser.isUserExistsByPersonID(personID);
        }

        static public DataTable GetAllUsers()
        {
            return dataUser.GetAllUsers();
        }

        static public DataTable GetFiltredUsers(string text , string filter)
        {
            return dataUser.filterUser(text, filter); 
        }

        static public Users getUserByPersonID(int personID)
        {
            int userID = -1;
            string username = "", password = "";
            byte isActive = 0 ;
            if(dataUser.getUserByPersonID(ref userID , personID , ref username , ref password , ref isActive))
            {
                return new Users(userID, personID, username, password, (sbyte)isActive);
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
                return new Users(UserID, personID, username, password, (sbyte)isActive);
            }
            return null;
        }

        static public bool isPasswordCorrect(string password , int userID)
        {
            return dataUser.isPasswordCorrect(password, userID);
        }

        static public bool DeleteUser(int userID)
        {
            return dataUser.DeleteUserById(userID);
        }

        private bool addUser()
        {
            this.UserID = dataUser.insertUser(this.PersonID , this.UserName , this.Password, (byte)this.isActive);
            return (this.UserID != -1);
        }

        static public bool UpdatePassword(string password, int userID)
        {
            return dataUser.UpdatePassword(password, userID); 
        }

        private bool UpdateUser()
        {
            return dataUser.UpdateUser(this.UserID, this.UserName , this.Password , (byte)this.isActive); 
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
