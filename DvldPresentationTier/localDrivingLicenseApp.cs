using DvldBusinessTier;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DvldProject
{
    public partial class localDrivingLicenseApp : Form
    {

        enum enTest
        {
            visionTest = 1 , writtenTest = 2 , carTest = 3
        }

        enum enReason { FirstTime = 1, Renew, Replacement, Damaged, ReplacementForLost }

        enReason reason;

        enTest TestType; 
        public localDrivingLicenseApp()
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
            dataGridView1.DataSource = application.getAll_LDL_ApplicationPeople();
        }

        public void reload()
        {
            FillDataGrid();
            initializeDataGrid();
            LBrecord.Text = dataGridView1.Rows.Count.ToString() + " Record(s)";
        }

        private void Form14_Load(object sender, EventArgs e)
        {
            reload(); 
        }

        private void Form14_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
                dataGridView1.ClearSelection();
        }

        private void BTNclose_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }

        private void pictureAddPerson_Click(object sender, EventArgs e)
        {
            NewLdlApp fm = new NewLdlApp();
            fm.ShowDialog();

            foreach (Form frm in Application.OpenForms)
            {
                if (frm is localDrivingLicenseApp ldlManage)
                {
                    ldlManage.reload();
                    return; 
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.SelectedItem.ToString() != "none")
            {
                textBox1.KeyPress -= textBox1_KeyPress;
                if (comboBox1.SelectedItem.ToString() == "LDLAppId")
                    textBox1.KeyPress += textBox1_KeyPress;

                textBox1.Text = "";
                textBox1.Enabled = true;
                textBox1.Visible = true;
            }
            else
            {
                textBox1.Text = ""; 
                textBox1.Enabled = false;
                textBox1.Visible = false;
                reload();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = application.getFiltred_LDL_ApplicationPeople(textBox1.Text, comboBox1.SelectedItem.ToString());
            LBrecord.Text = dataGridView1.Rows.Count.ToString() + " Record(s)";
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void scheduleVisionTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count > 0)
            {
                TestType = enTest.visionTest;
                int LDLid = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
                string NationalNo = dataGridView1.SelectedRows[0].Cells["NationalNo"].Value.ToString();
                AppointmentTests fm = new AppointmentTests(LDLid , NationalNo , (int)TestType);
                fm.ShowDialog();
            }
            else
            {
                MessageBox.Show("You have to select a person before setting an appointment", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); 
            }
        }


        private void scheduleWrittenTestToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                TestType = enTest.writtenTest;
                int LDLid = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
                string NationalNo = dataGridView1.SelectedRows[0].Cells["NationalNo"].Value.ToString();
                AppointmentTests fm = new AppointmentTests(LDLid, NationalNo, (int)TestType);
                fm.ShowDialog();
            }
            else
            {
                MessageBox.Show("You have to select a person before setting an appointment", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                contextMenuStrip1.Items["scheduleTests"].Enabled = true;
                contextMenuStrip1.Items["showLicenseToolStripMenuItem"].Enabled = false;

                string Status = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();

                contextMenuStrip1.Items["issueDrivingLicenseFirstTimeToolStripMenuItem"].Enabled = false;

                int passedTest = (int)dataGridView1.SelectedRows[0].Cells[5].Value;

                switch(passedTest)
                {
                    case 0:
                        {
                            scheduleTests.DropDownItems[0].Enabled = true;
                            scheduleTests.DropDownItems[1].Enabled = false;
                            scheduleTests.DropDownItems[2].Enabled = false;
                            break; 
                        }
                    case 1:
                        {
                            scheduleTests.DropDownItems[0].Enabled = false;
                            scheduleTests.DropDownItems[1].Enabled = true;
                            scheduleTests.DropDownItems[2].Enabled = false;
                            break;
                        }
                    case 2:
                        {
                            scheduleTests.DropDownItems[0].Enabled = false;
                            scheduleTests.DropDownItems[1].Enabled = false;
                            scheduleTests.DropDownItems[2].Enabled = true;
                            break;
                        }
                    case 3:
                        {
                            scheduleTests.DropDownItems[0].Enabled = false;
                            scheduleTests.DropDownItems[1].Enabled = false;
                            scheduleTests.DropDownItems[2].Enabled = false;
                            contextMenuStrip1.Items["issueDrivingLicenseFirstTimeToolStripMenuItem"].Enabled = true; 
                            break;
                        }
                }

                if (Status == "Completed")
                {
                    contextMenuStrip1.Items["scheduleTests"].Enabled = false; 
                    contextMenuStrip1.Items["issueDrivingLicenseFirstTimeToolStripMenuItem"].Enabled = false;
                    contextMenuStrip1.Items["showLicenseToolStripMenuItem"].Enabled = true;

                }

            }
        }

        private void scheduleStreetTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                TestType = enTest.carTest;
                int LDLid = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
                string NationalNo = dataGridView1.SelectedRows[0].Cells["NationalNo"].Value.ToString();
                AppointmentTests fm = new AppointmentTests(LDLid, NationalNo, (int)TestType);
                fm.ShowDialog();
            }
            else
            {
                MessageBox.Show("You have to select a person before setting an appointment", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void issueDrivingLicenseFirstTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (dataGridView1.SelectedRows.Count > 0)
            {
                reason = enReason.FirstTime;
                int LDLid = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
                string NationalNo = dataGridView1.SelectedRows[0].Cells["NationalNo"].Value.ToString();
                Form fm = new issueDrivingLicense_firstTime(LDLid , NationalNo , (int)reason);
                fm.ShowDialog();

            }
            else
            {
                MessageBox.Show("You have to select a person before setting an appointment", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void showLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int LDLid = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
                int AppID = application.getAppIdByLDLid(LDLid);
                Form fm = new ShowLicenseInfo(AppID);
                fm.ShowDialog(); 
            }
            else
            {
                MessageBox.Show("You have to select a person before setting an appointment", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
