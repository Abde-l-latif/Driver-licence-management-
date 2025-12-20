using DvldBusinessTier;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DvldProject
{
    public partial class localDrivingLicenseApp : Form
    {

        enum enTest
        {
            visionTest = 1, writtenTest = 2, carTest = 3
        }



        enum enReason { FirstTime = 1, Renew, Replacement, Damaged, ReplacementForLost }

        enReason reason;

        enTest TestType;

        string FilterWith = ""; 


        DataTable _dt;

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
            _dt = LdlApplication.GetAllLocalDrivingLicenseApplications();
            dataGridView1.DataSource = _dt;
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
            AddUpdateLdlApp fm = new AddUpdateLdlApp();
            fm.ShowDialog();
            reload(); 
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() != "none")
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

            FilterWith = comboBox1.SelectedItem.ToString();
        }

        private void InitializeFilterWith()
        {
            switch (FilterWith)
            {
                case "LDLAppId":
                    FilterWith = "LocalDrivingLicenseApplicationID";
                    break;
                case "National No":
                    FilterWith = "NationalNo";
                    break;
                case "Full Name":
                    FilterWith = "FullName";
                    break;
                case "Status":
                    FilterWith = "Status";
                    break;
                case "none":
                    FilterWith = "none";
                    break;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            InitializeFilterWith();
            if (String.IsNullOrEmpty(textBox1.Text))
            {
                _dt.DefaultView.RowFilter = "";
                return; 
            }

            if(FilterWith == "LocalDrivingLicenseApplicationID")
                _dt.DefaultView.RowFilter = String.Format("[{0}] = {1}", FilterWith, Convert.ToInt32(textBox1.Text));
            else
                _dt.DefaultView.RowFilter = String.Format("[{0}] like '{1}%'", FilterWith, textBox1.Text);

            LBrecord.Text = dataGridView1.Rows.Count.ToString() + " Record(s)";
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void editApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int LdlAppID = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
                AddUpdateLdlApp fm = new AddUpdateLdlApp(LdlAppID);
                fm.ShowDialog();

                reload();
            }
            else
            {
                MessageBox.Show("You have to select a person before setting an appointment", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void showApplicationDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int LdlAppID = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
                ShowLdlAppDetails fm = new ShowLdlAppDetails(LdlAppID);
                fm.ShowDialog();

            }
            else
            {
                MessageBox.Show("You have to select a person before setting an appointment", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void deleteApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int LdlAppID = (int)dataGridView1.SelectedRows[0].Cells[0].Value;

                LdlApplication LocalDrivingLicenseApplication = LdlApplication.FindByLocalDrivingAppLicenseID(LdlAppID); 

                if( LocalDrivingLicenseApplication != null )
                {
                    if(LocalDrivingLicenseApplication.LdlDelete())
                    {
                        MessageBox.Show("Application has been deleted successfully", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        FillDataGrid();
                    }
                    else
                        MessageBox.Show("this person has Appointments you can't delete it ", "warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show(" something went wrong with ID passed ", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("You have to select a person before setting an appointment", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cancelApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {

                int LdlAppID = (int)dataGridView1.SelectedRows[0].Cells[0].Value;

                LdlApplication LocalDrivingLicenseApplication = LdlApplication.FindByLocalDrivingAppLicenseID(LdlAppID);

                if (LocalDrivingLicenseApplication != null)
                {
                    if (LocalDrivingLicenseApplication.Cancel())
                    {
                        MessageBox.Show("Application has been Cancelled successfully", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        FillDataGrid();
                    }
                    else
                        MessageBox.Show("Cancelled Operation failed!!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show("something went wrong with ID passed", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                MessageBox.Show("You have to select a person before setting an appointment", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void scheduleVisionTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                TestType = enTest.visionTest;
                int LDLid = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
                AppointmentTests fm = new AppointmentTests(LDLid, (int)TestType);
                fm.ShowDialog();
                FillDataGrid();
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
                AppointmentTests fm = new AppointmentTests(LDLid, (int)TestType);
                fm.ShowDialog();
                FillDataGrid();
            }
            else
            {
                MessageBox.Show("You have to select a person before setting an appointment", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void scheduleStreetTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                TestType = enTest.carTest;
                int LDLid = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
                AppointmentTests fm = new AppointmentTests(LDLid, (int)TestType);
                fm.ShowDialog();
                FillDataGrid();
            }
            else
            {
                MessageBox.Show("You have to select a person before setting an appointment", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void initializeStatus(string status)
        {
            if (status == "Completed")
            {
                contextMenuStrip1.Items["scheduleTests"].Enabled = false;
                contextMenuStrip1.Items["issueDrivingLicenseFirstTimeToolStripMenuItem"].Enabled = false;
                contextMenuStrip1.Items["cancelApplicationToolStripMenuItem"].Enabled = false;
                contextMenuStrip1.Items["deleteApplicationToolStripMenuItem"].Enabled = false;
                contextMenuStrip1.Items["showLicenseToolStripMenuItem"].Enabled = true;
                contextMenuStrip1.Items["editApplicationToolStripMenuItem"].Enabled = false;

            }
            if (status == "Cancelled")
            {
                contextMenuStrip1.Items["cancelApplicationToolStripMenuItem"].Enabled = false;
                contextMenuStrip1.Items["scheduleTests"].Enabled = false;
                contextMenuStrip1.Items["editApplicationToolStripMenuItem"].Enabled = false;
            }
        }

        private void initializeTestUI(int passedTest)
        {
            switch (passedTest)
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
        }

        private void initializeContextMenu()
        {
            contextMenuStrip1.Items["scheduleTests"].Enabled = true;
            contextMenuStrip1.Items["cancelApplicationToolStripMenuItem"].Enabled = true;
            contextMenuStrip1.Items["deleteApplicationToolStripMenuItem"].Enabled = true;
            contextMenuStrip1.Items["showLicenseToolStripMenuItem"].Enabled = false;
            contextMenuStrip1.Items["issueDrivingLicenseFirstTimeToolStripMenuItem"].Enabled = false;
            contextMenuStrip1.Items["editApplicationToolStripMenuItem"].Enabled = true;

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                initializeContextMenu();

                string Status = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
                int passedTest = (int)dataGridView1.SelectedRows[0].Cells[5].Value;

                initializeTestUI(passedTest);

                initializeStatus(Status);
            }
        }

        private void issueDrivingLicenseFirstTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (dataGridView1.SelectedRows.Count > 0)
            {
                reason = enReason.FirstTime;
                int LDLid = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
                Form fm = new issueDrivingLicense_firstTime(LDLid);
                fm.ShowDialog();
                FillDataGrid();
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
                int LicenseID = Licenses.getLicenseIDByLdlID(LDLid);
                if (LicenseID != -1)
                {
                    ShowLicenseInfo fm = new ShowLicenseInfo(LicenseID);
                    fm.ShowDialog();
                }

            }
            else
            {
                MessageBox.Show("You have to select a person before setting an appointment", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                string NationalNo = dataGridView1.SelectedRows[0].Cells["NationalNo"].Value.ToString();
                Form fm = new LicenseHistory(people.getPersonIDbyNationalNo(NationalNo));
                fm.ShowDialog();
            }
            else
            {
                MessageBox.Show("You have to select a person before setting an appointment", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
