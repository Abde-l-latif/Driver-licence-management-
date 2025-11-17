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
    public partial class ManageTestType : Form
    {
        public ManageTestType()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterParent; 
        }

        private void initializeDataGrid()
        {
            dataGridView1.MultiSelect = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.ReadOnly = true;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AllowUserToAddRows = false;
        }

        private void getAllAppTypes()
        {
            dataGridView1.DataSource = Tests.getAllTestTypes();
        }

        public void reloadDataGrid()
        {
            initializeDataGrid();
            getAllAppTypes();
            LBrecords.Text = dataGridView1.Rows.Count.ToString() + " Records";
        }

        private void BTNclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form12_Load(object sender, EventArgs e)
        {
            reloadDataGrid();
        }

        private void Form12_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
                dataGridView1.ClearSelection();
        }

        private void updateApplicationTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int ID = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
                string title = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                string description = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                string fee = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                UpdateTestTypeForm fm = new UpdateTestTypeForm(ID, title, description, fee);
                fm.ShowDialog();
            }
            else
            {
                MessageBox.Show("you have to select a type!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
