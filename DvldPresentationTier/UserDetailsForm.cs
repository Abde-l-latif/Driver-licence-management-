using System.Windows.Forms;

namespace DvldProject
{
    public partial class UserDetailsForm : Form
    {
    
        public UserDetailsForm(int personID , int userID)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterParent;
            userInfo1.setUserID(userID);
            personDetails1.setPersonId(personID);
            userInfo1.reload();
            personDetails1.reload();
        }
    }
}
