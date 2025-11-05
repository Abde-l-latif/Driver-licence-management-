using System.Windows.Forms;

namespace DvldProject
{
    public partial class Form9 : Form
    {
    
        public Form9(int personID , int userID)
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
