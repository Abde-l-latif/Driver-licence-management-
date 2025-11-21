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
    public partial class ChangePasswordForm : Form
    {
        private int PersonID;
        private int UserID; 
        public ChangePasswordForm(int personID , int userID)
        {
            InitializeComponent();
            PersonID = personID;
            UserID = userID;
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            userInfo1.setUserID(UserID);
            personDetails1.setPersonId(PersonID);
            personDetails1.reload();
            userInfo1.reload();

        }

        private void BTNclose_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }

        private void textCurrentPass_Validating(object sender, CancelEventArgs e)
        {
            if(!Users.isPasswordCorrect(textCurrentPass.Text , UserID))
            {
                e.Cancel = true;
                errorProvider1.SetError(textCurrentPass, "incorrect password!!");
            }
            else
            {
                errorProvider1.SetError(textCurrentPass, "");
            }
        }

        private void textConfirmPass_Validating(object sender, CancelEventArgs e)
        {
            if(textConfirmPass.Text != textNewPass.Text)
            {
                e.Cancel = true;
                errorProvider1.SetError(textConfirmPass, "password does not match the new password!!");
            }
            else
            {
                errorProvider1.SetError(textConfirmPass, "");
            }
        }

        private void BTNsave_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(textCurrentPass.Text) && !string.IsNullOrEmpty(textConfirmPass.Text) && !string.IsNullOrEmpty(textNewPass.Text))
            {
                if(Users.UpdatePassword(textNewPass.Text, UserID))
                {
                    MessageBox.Show("Operation Done Successfully", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    BTNsave.Enabled = false; 
                }
                else
                {
                    MessageBox.Show("Operation failed!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            else
            {
                MessageBox.Show("Fill the information first", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
