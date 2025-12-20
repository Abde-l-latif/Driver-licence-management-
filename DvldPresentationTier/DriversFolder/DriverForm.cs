using DvldBusinessTier;
using System;
using System.Data;
using System.Windows.Forms;

namespace DvldProject
{
    public partial class DriverForm : Form
    {

        private DataTable DT;

        string FilterText = ""; 

        public DriverForm()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterParent;
            comboBox1.SelectedIndex = 0;    
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
            DT = Driver.getAllDrivers();
            dataGridView1.DataSource = DT;
            LbRecords.Text = dataGridView1.Rows.Count.ToString() + " Records";
        }
        private void BTNclose_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }

        private void DriverForm_Load(object sender, EventArgs e)
        {
            initializeDataGrid();
            FillDataGrid(); 
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.KeyPress -= textBox1_KeyPress;

            if (comboBox1.SelectedItem.ToString() == "Driver ID" || comboBox1.SelectedItem.ToString() == "Person ID")
                textBox1.KeyPress += textBox1_KeyPress;

            if (comboBox1.SelectedItem.ToString() == "None")
            {
                textBox1.Text = ""; 
                textBox1.Enabled = false;
                textBox1.Visible = false;
                FillDataGrid();
                return;
            }
            else 
            {
                textBox1.Text = "";
                textBox1.Enabled = true;
                textBox1.Visible = true;
            }

            getFilterText();
        }

        private void getFilterText()
        {
            switch(comboBox1.SelectedItem.ToString())
            {
                case "Driver ID":
                {
                    FilterText = "DriverID";
                    break;
                }
                case "Person ID":
                {
                     FilterText = "PersonID";
                     break;
                }
                case "National No":
                {
                     FilterText = "NationalNo";
                     break;
                }
                case "Full Name":
                {
                     FilterText = "FullName";
                     break;
                }
                default:
                    FilterText = "";
                    break;

            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(String.IsNullOrEmpty(textBox1.Text))
            {
                DT.DefaultView.RowFilter = ""; 
                return;
            }

            if(FilterText != "DriverID" && FilterText != "PersonID")
            {
                DT.DefaultView.RowFilter = String.Format("[{0}] LIKE '{1}%'" , FilterText , textBox1.Text);
            }
            else
                DT.DefaultView.RowFilter = String.Format("[{0}] = {1}", FilterText, Convert.ToInt32(textBox1.Text));

            LbRecords.Text = DT.Rows.Count.ToString() + " Records";
        }

        private void showPersonInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int personID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[1].Value);
                PersonDetailsForm fm = new PersonDetailsForm(personID);
                fm.ShowDialog();
            }
            else
            {
                MessageBox.Show("You have to select a person before setting an appointment", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void showLicenseHistorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int personID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[1].Value);
                Form fm = new LicenseHistory(personID);
                fm.ShowDialog();
            }
            else
            {
                MessageBox.Show("You have to select a person before setting an appointment", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
