using DvldBusinessTier;
using System;
using System.Collections.Generic;
using System.Data;
using System.Security.Policy;
using System.Windows.Forms;
using System.Xml.Linq;



namespace DvldProject
{
    public partial class ManagePeopleForm : Form
    {
        string Filter = "";

        DataTable DtPeople;

        public ManagePeopleForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            initializeDataGrid();
            filterPeople1.OnTextChangedInside += MyTextChangedEvent;
            filterPeople1.OnSelectChange += selectChanged;
            InitializeDataPeople();
        }

        private void InitializeDataPeople()
        {
            DataTable DtAllPeople = people.getAllPeople();
            DtPeople = DtAllPeople.DefaultView.ToTable(false, "PersonID", "NationalNo", "FirstName", "SecondName", "ThirdName", "LastName", "Gender", "DateOfBirth",
                      "Country", "Phone", "Email");
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void initializeDataGrid()
        {
            dataGridView1.ContextMenuStrip = contextMenuStrip1;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AllowUserToAddRows = false;
        }

        public void FillDataGridWithPeople()
        {
            dataGridView1.DataSource = DtPeople;
            records.Text = dataGridView1.RowCount.ToString() + " Records";
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            FillDataGridWithPeople();
        }

        /* Events */
        private void selectChanged(string text)
        {
                InitializeSelectedFilter(text); 
        }

        private void InitializeSelectedFilter(string text)
        {
            switch (text)
            {
                case "person ID":
                    Filter = "PersonID";
                    break;
                case "national No":
                    Filter = "NationalNo";
                    break;
                case "first name":
                    Filter = "FirstName";
                    break;
                case "second name":
                    Filter = "SecondName";
                    break;
                case "third name":
                    Filter = "ThirdName";
                    break;
                case "last name":
                    Filter = "LastName";
                    break;
                case "nationality":
                    Filter = "Country";
                    break;
                case "gender":
                    Filter = "Gender";
                    break;
                case "phone":
                    Filter = "Phone";
                    break;
                case "email":
                    Filter = "Email";
                    break;
                default:
                    Filter = "none"; 
                    break;
            }
        }

        private void MyTextChangedEvent(string text)
        {
            if(Filter == "none" || text == "")
            {
                DtPeople.DefaultView.RowFilter = ""; 
                records.Text = dataGridView1.RowCount.ToString() + " Records";
                return;
            }
                if(Filter == "PersonID")
                DtPeople.DefaultView.RowFilter = string.Format("[{0}] = {1}", Filter, text);
            else
                DtPeople.DefaultView.RowFilter = string.Format("[{0}] Like '{1}%'", Filter, text);
            records.Text = dataGridView1.RowCount.ToString() + " Records";
        }

        /* ========= Events ========= */

        private void pictureAddPerson_Click(object sender, EventArgs e)
        {
            AddEditPerson fm = new AddEditPerson();
            fm.ShowDialog();
        }

        /* Context Menu Strip Events */

        private void addNewPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count > 0)
            {
                MessageBox.Show("there is a selected Raw, unselect Rows !! " , "Error" , MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            AddEditPerson fm = new AddEditPerson();
            fm.ShowDialog();

            InitializeDataPeople();
            FillDataGridWithPeople();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count > 0 )
            {
                int PersonID = (int)dataGridView1.SelectedRows[0].Cells["PersonID"].Value;
                AddEditPerson fm = new AddEditPerson(PersonID);
                fm.ShowDialog();

                InitializeDataPeople();
                FillDataGridWithPeople();
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
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int PersonID = (int)dataGridView1.SelectedRows[0].Cells["PersonID"].Value;
                if(people.DeletePerson(PersonID))
                {
                    InitializeDataPeople();
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

        /* ============= Context Menu Strip Events ============ */

        private void Form3_Click(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
        }

        private void sendEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This operation is not implemented yet ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void phoneCallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This operation is not implemented yet ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    }
}
