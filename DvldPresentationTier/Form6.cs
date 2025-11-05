using DvldBusinessTier;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DvldProject
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterParent;
            filterUser1.textChangedFilter += getFilterText;
            filterUser1.comboBoxText += getComboText; 
        }

        private string ComboFilter = "none"; 


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
            dataGridView1.DataSource = Users.GetAllUsers();
            initializeDataGrid();
            LBRecords.Text = dataGridView1.Rows.Count.ToString() + " Records";

        }

        private void Form6_Load(object sender, EventArgs e)
        {
            fillDataGrid();
        }

        private void Form6_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count > 0)
            {
                dataGridView1.ClearSelection(); 
            }
        }

        private void fillDataGridFiltredInfo(string text)
        {
            dataGridView1.DataSource = Users.GetFiltredUsers(text , ComboFilter);
            initializeDataGrid();
            LBRecords.Text = dataGridView1.Rows.Count.ToString() + " Records";
        }

        private void getComboText(string text)
        {
            if (text == "none")
            {
                fillDataGrid();
            }
            ComboFilter = text;
        }

        private void getFilterText(string text)
        {
            fillDataGridFiltredInfo(text);
        }

        private void BTNclose_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }

        private void pictureAddPerson_Click(object sender, EventArgs e)
        {
            Form fm = new Form7(-1);
            fm.ShowDialog();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count > 0)
            {
                int personID = (int)dataGridView1.SelectedRows[0].Cells[1].Value;
                Form fm = new Form7(personID);
                fm.ShowDialog(); 
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

            Form fm = new Form7(-1);
            fm.ShowDialog();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int PersonID = (int)dataGridView1.SelectedRows[0].Cells[1].Value; 
                int UserID = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
                Form fm = new Form8(PersonID , UserID);
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
                int PersonID = (int)dataGridView1.SelectedRows[0].Cells[1].Value;
                int UserID = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
                Form fm = new Form9(PersonID, UserID);
                fm.ShowDialog();
            }
            else
            {
                MessageBox.Show("You have to select a user First !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
