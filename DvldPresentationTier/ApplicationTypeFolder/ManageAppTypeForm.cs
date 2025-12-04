using System;
using DvldBusinessTier;
using System.Windows.Forms;

namespace DvldProject
{
    public partial class ManageAppTypeForm : Form
    {
        public ManageAppTypeForm()
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
            dataGridView1.DataSource = ApplicationType.getAllApplicationType();
        }

        private void updateApplicationTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int ID = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
                UpdateAppTypeForm fm = new UpdateAppTypeForm(ID);
                fm.ShowDialog();

                ManageAppTypeForm_Load(null, null); 
            }
            else
            {
                MessageBox.Show("you have to select a type!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
          
        }

        private void ManageAppTypeForm_Load(object sender, EventArgs e)
        {
            initializeDataGrid();
            getAllAppTypes();
            LbRecord.Text = dataGridView1.Rows.Count.ToString() + " Records";
        }

        private void ManageAppTypeForm_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
                dataGridView1.ClearSelection();
        }
    }
}
