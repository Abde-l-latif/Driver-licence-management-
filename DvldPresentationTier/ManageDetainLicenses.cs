using DvldBusinessTier;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DvldProject
{
    public partial class ManageDetainLicenses : Form
    {

        string ComboText = "";
        string text = "";
        public ManageDetainLicenses()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
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
            dataGridView1.DataSource = Licenses.getListDetainedLicenses(); 
            LbRecords.Text = dataGridView1.Rows.Count.ToString() + " Record(s)";
        }

        public void reload()
        {
            FillDataGrid();
            initializeDataGrid();
        }

        private void ManageDetainLicenses_Load(object sender, EventArgs e)
        {
            reload();
        }

        private void pictureRelease_Click(object sender, EventArgs e)
        {
            ReleaseDetainForm Fm = new ReleaseDetainForm();
            Fm.ShowDialog();
        }

        private void pictureDetain_Click(object sender, EventArgs e)
        {
            DetainLicenseForm Fm = new DetainLicenseForm();
            Fm.ShowDialog();
        }

        private void releaseDetainedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int LicenseID = (int)dataGridView1.SelectedRows[0].Cells[1].Value;
                ReleaseDetainForm Fm = new ReleaseDetainForm(LicenseID);
                Fm.ShowDialog();
            }
            else
            {
                MessageBox.Show("You have to select a row First !!", "Selection", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void showPersonDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                string NationalNo = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
                PersonDetailsForm fm = new PersonDetailsForm(people.getPersonIDbyNationalNo(NationalNo));
                fm.ShowDialog();
            }
            else
            {
                MessageBox.Show("You have to select a row First !!", "Selection", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void showLicenseDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int LicenseID = (int)dataGridView1.SelectedRows[0].Cells[1].Value;
                ShowLicenseInfo fm = new ShowLicenseInfo(Licenses.getAppIDByLicenseID(LicenseID));
                fm.ShowDialog();
            }
            else
            {
                MessageBox.Show("You have to select a row First !!", "Selection", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                string NationalNo = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
                LicenseHistory fm = new LicenseHistory(people.getPersonIDbyNationalNo(NationalNo));
                fm.ShowDialog();
            }
            else
            {
                MessageBox.Show("You have to select a row First !!", "Selection", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                bool Released = Convert.ToBoolean(dataGridView1.SelectedRows[0].Cells[3].Value);
                if(Released == true)
                {
                    contextMenuStrip1.Items[3].Enabled = false;
                    return;
                }
                contextMenuStrip1.Items[3].Enabled = true;
            }
            else
            {
                MessageBox.Show("You have to select a row First !!", "Selection", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboText = comboBox1.SelectedItem.ToString();
            textBox1.KeyPress -= textBox1_KeyPress;

            textBox1.Text = "";
            textBox1.Enabled = false;
            textBox1.Visible = false;
            comboBox2.Enabled = false;
            comboBox2.Visible = false;

            if (comboBox1.SelectedItem.ToString() == "none")
            {
                FillDataGrid();
                return; 
            }

            if (comboBox1.SelectedItem.ToString() == "Is Released")
            {
                comboBox2.Enabled = true;
                comboBox2.Visible = true; 
                return;
            }

            if(comboBox1.SelectedItem.ToString() == "Detain ID" || comboBox1.SelectedItem.ToString() == "Release Application ID")
                textBox1.KeyPress += textBox1_KeyPress;

            if (comboBox1.SelectedItem.ToString() != "none")
            {
                textBox1.Text = ""; 
                textBox1.Enabled = true;
                textBox1.Visible = true;
                return;
            }

        }

        private void FillFilterdDataGrid()
        {
            dataGridView1.DataSource = Licenses.FillWithFiltredData(text , ComboText);
            LbRecords.Text = dataGridView1.Rows.Count.ToString() + " Record(s)";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            text = textBox1.Text;
            FillFilterdDataGrid();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            text = comboBox2.SelectedItem.ToString();
            FillFilterdDataGrid();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; 
            }
        }
    }
}
