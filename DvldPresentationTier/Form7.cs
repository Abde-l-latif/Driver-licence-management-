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
    public partial class Form7 : Form
    {

        string ComboBoxText = "";
        string FilterWithText = "";

        private int personID;

        public Form7(int personID)
        {
            InitializeComponent();
            filterPeople1.OnSelectChange += getSelectedFilter;
            filterPeople1.OnTextChangedInside += getText;
            BTNNext.Enabled = false;
            BTNsave.Enabled = true;
            this.personID = personID;
        }

        private void getText(string text)
        {
            FilterWithText = text; 
        }

        private void getSelectedFilter(string text)
        {
            ComboBoxText = text; 
        }

        private void BTNfilterSearch_Click(object sender, EventArgs e)
        {
            DataTable Person =  people.filterPeople(FilterWithText , ComboBoxText);
            if(Person != null && Person.Rows.Count > 0)
            {
               int PersonID = (int)Person.Rows[0]["PersonID"];
               personDetails1.setPersonId(PersonID);
               personDetails1.reload();
               BTNNext.Enabled = true;
            } else
            {
                MessageBox.Show("We didn't found any person !!", "Error", MessageBoxButtons.OK , MessageBoxIcon.Error);
                BTNNext.Enabled = false;
                personDetails1.setPersonId(-1);
                personDetails1.reload();
            }
        }

        private void BTNNext_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(1); 
        }

        private void BTNclose_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }

        private void reloadDataGrid()
        {
            foreach(Form fm in Application.OpenForms)
            {
                if(fm is Form6 userFormGrid)
                {
                    userFormGrid.fillDataGrid();
                    break;
                }
            }
        }

        private Users addUser()
        {
            Users User = new Users();

            sbyte isActive = checkBox1.Checked == true ? (sbyte)1 : (sbyte)0;

            User.PersonID = personDetails1.getPersonID();
            User.UserName = textUserName.Text;
            User.Password = textPassword22.Text;
            User.isActive = isActive;

            return User;
        }

        private Users updateUser()
        {
            Users User = Users.getUserByPersonID(personID);

            sbyte isActive = checkBox1.Checked == true ? (sbyte)1 : (sbyte)0;

            User.UserName = textUserName.Text;
            User.Password = textPassword22.Text;
            User.isActive = isActive;

            return User;
        }

        private void BTNsave_Click(object sender, EventArgs e)
        {

            Users User;

            if(textPassword22.Text == "" || textUserName.Text == "" || textConfirm.Text == "")
            {
                MessageBox.Show("You need More Info To add a user !! fill the rest of information", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; 
            }

            if(textPassword22.Text != textConfirm.Text)
            {
                MessageBox.Show("Passwords doesn't match", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(personID == -1)
            {
                
                User = addUser(); 

                if(Users.isUserExist(User.PersonID) == true)
                {
                    MessageBox.Show("Operation failed, This person is already a user !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; 
                }
            } else
            {
                User = updateUser(); 
            }


            if (User.Save())
            {
                UserIDValue.Text = User.UserID.ToString();
                MessageBox.Show("Operation Done successfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                reloadDataGrid();
                BTNsave.Enabled = false;
            }
            else
            {
                MessageBox.Show("Operation failed !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void tabControl1_Click(object sender, EventArgs e)
        {
            if(personDetails1.getPersonID() == -1 )
            {
                MessageBox.Show("You didn't select any Person !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tabControl1.SelectTab(0); 
            }
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            if(personID != -1)
            {
                Users User = Users.getUserByPersonID(personID);
                if(User != null)
                {
                    label1.Text = "Update User";
                    personDetails1.setPersonId(personID);
                    personDetails1.reload();
                    BTNNext.Enabled = true;
                    filterPeople1.customFilter(personID.ToString(), "person ID");
                    groupBox1.Enabled = false;
                    textUserName.Text = User.UserName;
                    textPassword22.Text = User.Password;
                    textConfirm.Text = User.Password;
                    checkBox1.Checked = User.isActive == 1 ? true : false;
                }
                else
                {
                    MessageBox.Show("Something went wrong !!");
                    return;
                }

            }
            else
            {
                label1.Text = "Add New User";
            }

            

        }

        public void reloadPersonCard()
        {
            personDetails1.reload();
        }

        private void OnPersonIDAdded(int personID)
        {
            personDetails1.setPersonId(personID);
            BTNNext.Enabled = true; 
        }

        private void BTNAddPerson_Click(object sender, EventArgs e)
        {
            Form4 fm = new Form4(-1);
            fm.personIDAdded += OnPersonIDAdded;
            fm.ShowDialog();
            
        }
    }
}
