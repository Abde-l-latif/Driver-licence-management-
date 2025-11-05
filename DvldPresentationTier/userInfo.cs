using DvldBusinessTier;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DvldProject
{
    public partial class userInfo : UserControl
    {

        private int UserID;

        private Users User; 

        public userInfo()
        {
            InitializeComponent();
        }

        public void setUserID(int UserID)
        {
            this.UserID = UserID;
        }

        public void reload()
        {
            User = Users.getUserByUserID(UserID);
            if(User != null)
            {
                TxtID.Text = UserID.ToString();
                TxtUserName.Text = User.UserName;
                TxtActive.Text = User.isActive == 1 ? "Yes" : "No";
            }
            else
            {
                MessageBox.Show("User Not Found !!", "Error", MessageBoxButtons.OK , MessageBoxIcon.Error); 
            }
        }
    }
}
