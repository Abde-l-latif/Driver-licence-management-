using DvldBusinessTier;
using System;
using System.Windows.Forms;

namespace DvldProject
{
    public partial class ManageInternationalDrivingLicense : Form
    {
        public ManageInternationalDrivingLicense()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterParent;
            comboBox1.SelectedIndex = 0; 
        }

        private void BTNclose_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }

        private void initializeDataGrid()
        {

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AllowUserToAddRows = false;
        }

        private void FillDataGrid()
        {
            dataGridView1.DataSource = application.getAll_InterDL_ApplicationPeople();
            LBrecord.Text = dataGridView1.Rows.Count.ToString() + " Record(s)";
        }

        public void reload()
        {
            FillDataGrid();
            initializeDataGrid();
        }

        private void ManageInternationalDrivingLicense_Load(object sender, EventArgs e)
        {
            reload();
        }

        private void ManageInternationalDrivingLicense_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
                dataGridView1.ClearSelection(); 
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.SelectedItem.ToString() != "none")
            {
                textBox1.Text = "";
                textBox1.Enabled = true;
                textBox1.Visible = true; 
            }
            else
            {
                textBox1.Text = "";
                textBox1.Enabled = false;
                textBox1.Visible = false;
                FillDataGrid(); 
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = application.getFiltredInterDlApp(textBox1.Text, comboBox1.SelectedItem.ToString());
            LBrecord.Text = dataGridView1.Rows.Count.ToString() + " Record(s)";
        }

        private void pictureAddPerson_Click(object sender, EventArgs e)
        {
            NewInternationalDrivingLicenseApp fm = new NewInternationalDrivingLicenseApp();
            fm.ShowDialog(); 
        }

        private void showPersonDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count > 0)
            {
                int AppId = (int)dataGridView1.SelectedRows[0].Cells[1].Value;
                //PersonDetailsForm fm = new PersonDetailsForm(application.getPersonIDByAppID(AppId));
                //fm.ShowDialog(); 
            }
            else
            {
                MessageBox.Show("You have to select License First !!" , "Selection" , MessageBoxButtons.OK , MessageBoxIcon.Error);
            }
        }

        private void showLicenseDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int interLicenseID = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            int AppId = (int)dataGridView1.SelectedRows[0].Cells[1].Value;
            int DriverID = (int)dataGridView1.SelectedRows[0].Cells[2].Value;
            int LicenseID = (int)dataGridView1.SelectedRows[0].Cells[3].Value;
            //int PersonID = application.getPersonIDByAppID(AppId);
            string issueDate = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            string ExpirationDate = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            bool isActive = (bool)dataGridView1.SelectedRows[0].Cells[6].Value;
            if (dataGridView1.SelectedRows.Count > 0)
            {
                //interLicenseDetails fm = new interLicenseDetails(interLicenseID, AppId, PersonID, LicenseID, issueDate, ExpirationDate, isActive , DriverID);
                //fm.ShowDialog();
            }
            else
            {
                MessageBox.Show("You have to select License First !!", "Selection", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int AppId = (int)dataGridView1.SelectedRows[0].Cells[1].Value;
                //LicenseHistory fm = new LicenseHistory(application.getPersonIDByAppID(AppId));
                //fm.ShowDialog();
            }
            else
            {
                MessageBox.Show("You have to select License First !!", "Selection", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
