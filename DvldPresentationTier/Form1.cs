using System;
using System.Windows.Forms;
using DvldBusinessTier;

namespace DvldProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void BTNlogin_Click(object sender, EventArgs e)
        {
            Users user = Users.userLogin(textBUserName.Text, textPassword.Text); 

            if (user != null)
            {
                Global.USER = user;
                this.DialogResult = DialogResult.OK;
                this.Close();
            } 
            else
            {
                MessageBox.Show("user not found !!" , "Authentication" , MessageBoxButtons.OK , MessageBoxIcon.Error);
            }
        }
    }
}
