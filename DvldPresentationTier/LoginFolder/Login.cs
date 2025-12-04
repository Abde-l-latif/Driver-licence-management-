using DvldBusinessTier;
using System;
using System.IO;
using System.Windows.Forms;


namespace DvldProject
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void BTNlogin_Click(object sender, EventArgs e)
        {
            Users user = Users.userLogin(textBUserName.Text, textPassword.Text); 

            if (user != null)
            {
                if(user.isActive == false)
                    MessageBox.Show("this user is no longer active !!", "Authentication", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    Global.USER = user;

                    if (checkBox1.Checked)
                        Global.setCredential($"{textBUserName.Text}#//#{textPassword.Text}");
                    else 
                        Global.DeleteFile();

                    this.Hide(); 
                    MainForm Fm = new MainForm(this);
                    Fm.ShowDialog();
                }
            } 
            else
            {
                textBUserName.Focus(); 
                MessageBox.Show("user not found !!" , "Authentication" , MessageBoxButtons.OK , MessageBoxIcon.Error);
            }
        }

        public void Form1_Load(object sender, EventArgs e)
        {
            string username = "", password = "";

            Global.getCredential(ref username, ref password);
   
            textBUserName.Text = username;
            textPassword.Text = password;

            if (!(textBUserName.Text == "") && !(textPassword.Text == ""))
                checkBox1.Checked = true;
            else
                checkBox1.Checked = false;

        }


    }
}
