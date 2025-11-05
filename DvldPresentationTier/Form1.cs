using DvldBusinessTier;
using System;
using System.IO;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

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
                if(user.isActive == 0)
                    MessageBox.Show("this user is no longer active !!", "Authentication", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    Global.USER = user;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            } 
            else
            {
                MessageBox.Show("user not found !!" , "Authentication" , MessageBoxButtons.OK , MessageBoxIcon.Error);
            }
        }

        private void getDataFromFile(string filePath , ref string username , ref string password)
        {
            string savedText = File.ReadAllText(filePath);

            string[] parts = savedText.Split(new string[] { "#//#" }, StringSplitOptions.None);

            if (parts.Length >= 2)
            {
                username = parts[0];
                password = parts[1];
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

            string fileName = "loginInfo.txt";
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string filePath = Path.Combine(folderPath, fileName);


            if (checkBox1.Checked)
            {
                string textToSave = $"{textBUserName.Text}#//#{textPassword.Text}";
                File.WriteAllText(filePath , textToSave);
            } else
            {
                if(File.Exists(filePath))
                    File.Delete(filePath);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string fileName = "loginInfo.txt";
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string filePath = Path.Combine(folderPath, fileName);

            if (File.Exists(filePath))
            {
                string username = "", password = "";

                getDataFromFile(filePath, ref username, ref password);

                textBUserName.Text = username;

                textPassword.Text = password; 

                if (!(textBUserName.Text == "") || !(textPassword.Text == ""))
                    checkBox1.Checked = true;

            }
        }
    }
}
