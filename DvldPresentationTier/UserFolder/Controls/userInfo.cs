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

        private int _UserID;

        private Users User; 

        public userInfo()
        {
            InitializeComponent();
        }

        private void FillUserDetails()
        {
            TxtID.Text = _UserID.ToString();
            TxtUserName.Text = User.UserName;
            TxtActive.Text = User.isActive == true ? "Yes" : "No";
        }

        public void LoadUserInfo(int UserID)
        {
            User = Users.getUserByUserID(UserID);
            if (User != null)
            {
                this._UserID = UserID;
                personDetails1.LoadPersonByID(User.PersonID);
                FillUserDetails();
            }
            else
            {
                MessageBox.Show("User Not Found !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
