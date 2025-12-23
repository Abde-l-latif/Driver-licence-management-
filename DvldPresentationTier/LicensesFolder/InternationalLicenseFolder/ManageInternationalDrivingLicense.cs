using DvldBusinessTier;
using System;
using System.Data;
using System.Security.Policy;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace DvldProject
{
    public partial class ManageInternationalDrivingLicense : Form
    {

        DataTable dt;

        string FilterText = ""; 
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
            dt = InternationalLicense.getAll_InterDL_ApplicationPeople();
            dataGridView1.DataSource = dt;
            LBrecord.Text = dataGridView1.Rows.Count.ToString() + " Record(s)";
        }

        public void reload()
        {
            initializeDataGrid();
            FillDataGrid();
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

        private void InitializeFilterText(string comboText)
        {
            switch(comboText)
            {
                case "IntLicense":
                    {
                        FilterText = "IntLicense";
                        break;
                    }
                case "ApplicationID":
                    {
                        FilterText = "ApplicationID";
                        break;
                    }
                case "DriverID":
                    {
                        FilterText = "DriverID";
                        break;
                    }
                case "LocalLicenseID":
                    {
                        FilterText = "LocalLicenseID";
                        break;
                    }
            }
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
                return; 
            }

            InitializeFilterText(comboBox1.SelectedItem.ToString());
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(String.IsNullOrEmpty(textBox1.Text))
            {
                dt.DefaultView.RowFilter = "";
                LBrecord.Text = dataGridView1.Rows.Count.ToString() + " Record(s)";
                return;
            }

            dt.DefaultView.RowFilter = String.Format("[{0}] = {1}" , FilterText , Convert.ToInt32(textBox1.Text));
            LBrecord.Text = dataGridView1.Rows.Count.ToString() + " Record(s)";

        }

        private void showPersonDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count > 0)
            {
                int InterId = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
                InternationalLicense InterObject = InternationalLicense.Find(InterId);
                if(InterObject != null)
                {
                    PersonDetailsForm fm = new PersonDetailsForm(InterObject.DriverInfo.personID);
                    fm.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("You have to select License First !!" , "Selection" , MessageBoxButtons.OK , MessageBoxIcon.Error);
            }
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int InterId = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
                InternationalLicense InterObject = InternationalLicense.Find(InterId);

                if (InterObject != null)
                {
                    LicenseHistory fm = new LicenseHistory(InterObject.DriverInfo.personID);
                    fm.ShowDialog();
                }
  
            }
            else
            {
                MessageBox.Show("You have to select License First !!", "Selection", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void showLicenseDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int interLicenseID = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
   
            if (dataGridView1.SelectedRows.Count > 0)
            {
                interLicenseDetails fm = new interLicenseDetails(interLicenseID);
                fm.ShowDialog();
            }
            else
            {
                MessageBox.Show("You have to select License First !!", "Selection", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureAddPerson_Click(object sender, EventArgs e)
        {
            NewInternationalDrivingLicenseApp fm = new NewInternationalDrivingLicenseApp();
            fm.ShowDialog();
            reload();
        }
    }
}
