using System;
using System.Windows.Forms;
using DvldBusinessTier;

namespace DvldProject
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            filterPeople1.OnTextChangedInside += MyTextChangedEvent;
            filterPeople1.OnSelectChange += selectChanged;
        }

        string Filter = "";

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void FillDataGridWithPeople()
        {
            dataGridView1.DataSource = people.getAllPeople();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AllowUserToAddRows = false;
            records.Text = dataGridView1.RowCount.ToString() + " Records";
            dataGridView1.ContextMenuStrip = contextMenuStrip1;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            FillDataGridWithPeople();
        }

        private void selectChanged(string text)
        {
            if (text == "none")
                FillDataGridWithPeople();
            else
                Filter = text; 
        }

        private void MyTextChangedEvent(string text)
        {
            dataGridView1.DataSource = people.filterPeople(text , Filter);
            records.Text = dataGridView1.RowCount.ToString() + " Records";
        }

        private void pictureAddPerson_Click(object sender, EventArgs e)
        {
            addNewPerson fm = new addNewPerson(-1);
            fm.ShowDialog();
        }

        private void addNewPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count > 0)
            {
                MessageBox.Show("there is a selected Raw, unselect Rows !! " , "Error" , MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            addNewPerson fm = new addNewPerson(-1);
            fm.ShowDialog();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count > 0 )
            {
                int PersonID = (int)dataGridView1.SelectedRows[0].Cells["PersonID"].Value;
                addNewPerson fm = new addNewPerson(PersonID);
                fm.ShowDialog();
            }
            else
            {
                MessageBox.Show("You haven't select any Person, select a person to do the operation !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int PersonID = (int)dataGridView1.SelectedRows[0].Cells["PersonID"].Value;
                PersonDetailsForm fm = new PersonDetailsForm(PersonID);
                fm.ShowDialog();
            }
            else
            {
                MessageBox.Show("You haven't select any Person, select a person to do the operation !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void Form3_Click(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int PersonID = (int)dataGridView1.SelectedRows[0].Cells["PersonID"].Value;
                if(people.DeletePerson(PersonID))
                {
                    FillDataGridWithPeople();
                }
                else
                {
                    MessageBox.Show("This Person Is used in other places on the system!! you can't delete it", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            else
            {
                MessageBox.Show("You haven't select any Person, select a person to do the operation !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
