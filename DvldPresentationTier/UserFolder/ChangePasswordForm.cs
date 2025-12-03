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
        private int _UserID;
        Users User;
        public ChangePasswordForm(int userID)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterParent;
            _UserID = userID;
        }

        private void FillUserInfo()
        {
            userInfo1.LoadUserInfo(_UserID);
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            User = Users.getUserByUserID(_UserID);
            if( User != null )
            {
                FillUserInfo();
            }
            else
                MessageBox.Show("Operation failed ! , User Not Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void BTNclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textCurrentPass_Validating(object sender, CancelEventArgs e)
        {
            if (User.Password != textCurrentPass.Text)
            {
                e.Cancel = true;
                errorProvider1.SetError(textCurrentPass, "incorrect password!!");
            }
            else
            {
                errorProvider1.SetError(textCurrentPass, "");
            }
        }

        private void textNewPass_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(textNewPass.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(textNewPass, "Fiels is required !!");
            }
            else
            {
                errorProvider1.SetError(textNewPass, "");
            }
        }

        private void textConfirmPass_Validating(object sender, CancelEventArgs e)
        {
            if (textConfirmPass.Text != textNewPass.Text)
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

            if (!this.ValidateChildren())
            {
                MessageBox.Show("Fill the information first", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; 
           
            }

            User.Password = textNewPass.Text;
            if (User.Save())
            {
                MessageBox.Show("Operation Done Successfully", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BTNsave.Enabled = false;
            }
            else
            {
                MessageBox.Show("Operation failed!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

    }
}
