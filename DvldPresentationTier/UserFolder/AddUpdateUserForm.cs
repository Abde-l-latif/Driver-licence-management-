using DvldBusinessTier;
using System;
using System.Windows.Forms;

namespace DvldProject
{
    public partial class AddUpdateUserForm : Form
    {
        enum enMode { addMode , UpdateMode }
        enMode Mode;
        private int userID;
        Users User;
        private int _PersonID = -1;

        public AddUpdateUserForm()
        {
            InitializeComponent();
            Mode = enMode.addMode;
            StartPosition = FormStartPosition.CenterParent;
            SubscribeWithEvent(); 
        }

        public AddUpdateUserForm(int userID)
        {
            InitializeComponent();
            this.userID = userID;
            Mode = enMode.UpdateMode;
            StartPosition = FormStartPosition.CenterParent;
            SubscribeWithEvent();
        }

        private void SubscribeWithEvent()
        {
            personDetailsFilter1.OnPersonSelected += getPersonID;
        }

        private void getPersonID(int PersonID)
        {
            _PersonID = PersonID;
            BTNNext.Enabled = true;
        }

        private void InitializeValues()
        {
            if (Mode == enMode.addMode)
            {
                label1.Text = "Add New User";
                User = new Users();
                BTNNext.Enabled = false;
                personDetailsFilter1.FocusFilter(); 
            }

            if (Mode == enMode.UpdateMode)
            {
                label1.Text = "Update User";
                BTNNext.Enabled = true;
                BTNsave.Enabled = true;
            }

            textUserName.Text = "";
            textPassword22.Text = "";
            textConfirm.Text = "";
            checkBox1.Checked = true;
        }

        private void LoadData()
        {
            User = Users.getUserByUserID(userID);

            if( User == null )
            {
                MessageBox.Show("User Not Found  !!", "Error", MessageBoxButtons.OK , MessageBoxIcon.Error);
                return;
            }
            textUserName.Text = User.UserName;
            textPassword22.Text = User.Password;
            textConfirm.Text = User.Password;
            checkBox1.Checked = User.isActive;
            personDetailsFilter1.LoadPersonInfo(User.PersonID);
            personDetailsFilter1.FilterPerson = false;

        }

        private void Form7_Load(object sender, EventArgs e)
        {
            InitializeValues();

            if (Mode == enMode.UpdateMode)
                LoadData();

        }

        private void BTNclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BTNNext_Click(object sender, EventArgs e)
        {
            if (ErrorIfPersonIsUser())
                return;
            tabControl1.SelectTab(1);
        }

        private void UpdateAddUser()
        {
            User.UserName = textUserName.Text;
            User.Password = textPassword22.Text;
            User.isActive = checkBox1.Checked;
            User.PersonID = _PersonID;
        }


        private void BTNsave_Click(object sender, EventArgs e)
        {
            if (ErrorIfPersonIsUser())
                return;

            if (textPassword22.Text == "" || textUserName.Text == "" || textConfirm.Text == "")
            {
                MessageBox.Show("You need More Info To add a user !! fill the rest of information", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (textPassword22.Text != textConfirm.Text)
            {
                MessageBox.Show("Passwords doesn't match", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            UpdateAddUser(); 

            if (User.Save())
            {
                UserIDValue.Text = User.UserID.ToString();
                MessageBox.Show("Operation Done successfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Mode = enMode.UpdateMode; 
                BTNsave.Enabled = false;
            }
            else
            {
                MessageBox.Show("Operation failed !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        /* Validation */

        private void textUserName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if(string.IsNullOrEmpty(textUserName.Text))
            {
                errorProvider1.SetError(textUserName, "You have to write a username !! ");
            }
            else
                errorProvider1.SetError(textUserName, null);
        }

        private void textPassword22_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(textPassword22.Text))
            {
                errorProvider1.SetError(textPassword22, "You have to Fill Password !!");
            }
            else
                errorProvider1.SetError(textPassword22, null);
        }

        private void textConfirm_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (textPassword22.Text != textConfirm.Text)
            {
                errorProvider1.SetError(textConfirm, "Confirmation failed it doesn't match the password !!");
            }
            else
                errorProvider1.SetError(textConfirm, null);
        }

        private bool ErrorIfPersonIsUser()
        {
            if (Mode == enMode.addMode)
            {

                if (Users.isUserExistByPersonID(_PersonID))
                {
                    MessageBox.Show("this person is already a user ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tabControl1.SelectTab(0);
                    return true;
                }
            }
            return false; 
        }


        /* ================ Validation ================== */



        private void tabControl1_Click(object sender, EventArgs e)
        {
            if (_PersonID == -1)
            {
                MessageBox.Show("You didn't select any Person !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tabControl1.SelectTab(0);
                return; 
            }

            ErrorIfPersonIsUser(); 
        }


    }
}
