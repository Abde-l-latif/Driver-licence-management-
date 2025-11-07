using System;
using DvldBusinessTier;
using System.Windows.Forms;

namespace DvldProject
{
    public partial class Form10 : Form
    {
        public Form10()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterParent;
        }

        private void BTNclose_Click(object sender, EventArgs e)
        {
            this.Close();
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
            dataGridView1.DataSource = application.getApplicationTypes();
        }

        public void reloadDataGrid()
        {
            initializeDataGrid();
            getAllAppTypes();
        }

        private void Form10_Load(object sender, EventArgs e)
        {
            reloadDataGrid();
            LbRecord.Text = dataGridView1.Rows.Count.ToString() + " Records"; 
        }

        private void Form10_Click(object sender, EventArgs e)
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
                string fee = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                Form11 fm = new Form11(ID , title , fee);
                fm.ShowDialog();
            }
            else
            {
                MessageBox.Show("you have to select a type!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
          
        }
    }
}
