using DvldBusinessTier;
using System;
using System.Data;
using System.Windows.Forms;

namespace DvldProject
{
    public partial class ManageUsersForm : Form
    {

        string _SelectedFilter = ""; 

        DataTable DtAllUsers;
        
        public ManageUsersForm()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterParent;
            comboBox2.Visible = false; 
            DtAllUsers = Users.GetAllUsers();
        }

        private void initializeDataGrid()
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AllowUserToAddRows = false;
        }

        public void fillDataGrid()
        {
            initializeDataGrid();
            dataGridView1.DataSource = DtAllUsers;
            LBRecords.Text = dataGridView1.Rows.Count.ToString() + " Records";
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            fillDataGrid();
        }

        private void Form6_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count > 0)
            {
                dataGridView1.ClearSelection(); 
            }
        }

        private void BTNclose_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }

        private void pictureAddPerson_Click(object sender, EventArgs e)
        {
            AddUpdateUserForm fm = new AddUpdateUserForm();
            fm.ShowDialog();
            fillDataGrid();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count > 0)
            {
                int userID = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
                AddUpdateUserForm fm = new AddUpdateUserForm(userID);
                fm.ShowDialog();
                fillDataGrid();
            }
            else
            {
                MessageBox.Show("You have to select a user First !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int userID = (int)dataGridView1.SelectedRows[0].Cells[0].Value;

                if (Users.DeleteUser(userID))
                {
                    fillDataGrid();
                }
                else
                {
                    MessageBox.Show("This user Is used in other places on the system!! you can't delete it", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            else
            {
                MessageBox.Show("You have to select a user First !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void addNewPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                MessageBox.Show("You have selected a user !! , unselect it", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; 
            }

            AddUpdateUserForm fm = new AddUpdateUserForm();
            fm.ShowDialog();

            fillDataGrid();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int UserID = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
                Form fm = new ChangePasswordForm(UserID);
                fm.ShowDialog();
            }
            else
            {
                MessageBox.Show("You have to select a user First !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int UserID = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
                Form fm = new UserDetailsForm(UserID);
                fm.ShowDialog();
            }
            else
            {
                MessageBox.Show("You have to select a user First !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GetSelectedFilter(string Filter)
        {
            switch(Filter)
            {
                case "user ID":
                    _SelectedFilter = "UserID";
                    break;
                case "person ID":
                    _SelectedFilter = "PersonID";
                    break;            
                case "UserName":
                    _SelectedFilter = "UserName";
                    break;
                case "is Active":
                    _SelectedFilter = "IsActive";
                    break;
                case "FullName":
                    _SelectedFilter = "FullName";
                    break;
                case "none":
                    _SelectedFilter = "none";
                    break;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.KeyPress -= textBox1_KeyPress;

            textBox1.Text = "";

            if(comboBox1.SelectedItem.ToString() == "is Active")
            {
                comboBox2.SelectedIndex = 0;
                comboBox2.Visible = true;
            }

            textBox1.Visible = (comboBox1.SelectedItem.ToString() != "is Active" && comboBox1.SelectedItem.ToString() != "none");


            if (comboBox1.SelectedItem.ToString() == "user ID" || comboBox1.SelectedItem.ToString() == "person ID")
            {
                textBox1.KeyPress += textBox1_KeyPress;
            }

            if (comboBox1.SelectedItem.ToString() == "none")
            {
                DtAllUsers.DefaultView.RowFilter = "";
                LBRecords.Text = dataGridView1.RowCount.ToString() + " Records";
            }

            GetSelectedFilter(comboBox1.SelectedItem.ToString());
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                DtAllUsers.DefaultView.RowFilter = "";
                LBRecords.Text = dataGridView1.RowCount.ToString() + " Records";
                return;
            }

            if (_SelectedFilter == "UserID" || _SelectedFilter == "PersonID")
            {
                DtAllUsers.DefaultView.RowFilter = String.Format("[{0}] = {1}", _SelectedFilter, textBox1.Text);
            }
            else
                DtAllUsers.DefaultView.RowFilter = String.Format("[{0}] like '{1}%'", _SelectedFilter, textBox1.Text);

            LBRecords.Text = dataGridView1.Rows.Count.ToString() + " Records";
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool value = false;

            if(comboBox2.SelectedItem.ToString() == "All")
            {
                DtAllUsers.DefaultView.RowFilter = "";
                LBRecords.Text = dataGridView1.Rows.Count.ToString() + " Records";
                return; 
            }

            if (comboBox2.SelectedItem.ToString() == "Yes")
                value = true;
            else if (comboBox2.SelectedItem.ToString() == "No")
                value = false;

            DtAllUsers.DefaultView.RowFilter = String.Format("[{0}] = {1}", _SelectedFilter, value);
            LBRecords.Text = dataGridView1.Rows.Count.ToString() + " Records";
        }
    }
}
