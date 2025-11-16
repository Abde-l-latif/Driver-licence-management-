using DvldBusinessTier;
using System;
using System.Windows.Forms;

namespace DvldProject
{
    public partial class DriverForm : Form
    {
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
            dataGridView1.DataSource = Driver.getAllDrivers();
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
            }
            else 
            {
                textBox1.Text = "";
                textBox1.Enabled = true;
                textBox1.Visible = true;
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
            dataGridView1.DataSource = Driver.getFiltredDrivers(textBox1.Text , comboBox1.SelectedItem.ToString());
            LbRecords.Text = dataGridView1.Rows.Count.ToString() + " Records";
        }
    }
}
