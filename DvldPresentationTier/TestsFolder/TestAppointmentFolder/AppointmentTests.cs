using DvldBusinessTier;
using DvldProject.Properties;
using System;
using System.Windows.Forms;

namespace DvldProject
{
    public partial class AppointmentTests : Form
    {
        enum enTest
        {
            visionTest = 1, writtenTest = 2 , carTest = 3
        }

        LdlApplication LocalDrivingLicenseApplication; 
        private int TestType;

        private void initializeDataGrid()
        {
            dataGridView1.MultiSelect = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.ReadOnly = true;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AllowUserToAddRows = false;
        }

        private void initializeUI()
        {
            enTest Test = (enTest)TestType; 

            switch(Test)
            {
                case enTest.visionTest:
                    {
                        this.Text = "Vision test appointment";
                        pictureTitle.Image = Resources.eye2;
                        Title.Text = "vision test appointment";
                        break; 
                    }
                case enTest.writtenTest:
                    {
                        this.Text = "Written test appointment";
                        pictureTitle.Image = Resources.test_edit;
                        Title.Text = "Written test appointment"; 
                        break;
                    }
                case enTest.carTest:
                    {
                        this.Text = "Street test appointment";
                        pictureTitle.Image = Resources.car_alarm;
                        Title.Text = "Street test appointment";
                        break;
                    }
            }
 
        }

        private void getAllAppointments()
        {
            dataGridView1.DataSource = TestAppointment.getTestAppointments(LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID, TestType);
        }

        public void reloadDataGrid()
        {
            initializeDataGrid();
            getAllAppointments();
            labelRecord.Text = dataGridView1.Rows.Count.ToString() + " Records";
        }

        public AppointmentTests(int lDLid , int testType)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterParent;

            this.TestType = testType;

            LocalDrivingLicenseApplication = LdlApplication.FindByLocalDrivingAppLicenseID(lDLid);
            ldLapplicationInfo1.LoadDataByLdlApplication(LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID);
            appDetails1.LoadApplicationById(LocalDrivingLicenseApplication.ApplicationID);

            reloadDataGrid(); 
        }

        private void BTNclose_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }
 
        private void pictureAddPerson_Click(object sender, EventArgs e)
        {

            if(Tests.isTestPassedExists(LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID, TestType))
            {
                MessageBox.Show("this person Already passed the test", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if(TestAppointment.isAppointmentExists(LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID, TestType))
            {
                MessageBox.Show("this person Already has an appointment", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ManageAppointments fm = new ManageAppointments(LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID, TestType);
            fm.ShowDialog();
            getAllAppointments();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count > 0)
            {
                int AppointmentID = (int)dataGridView1.SelectedRows[0].Cells[0].Value;

                ManageAppointments fm = new ManageAppointments(AppointmentID);
                fm.ShowDialog();
                getAllAppointments();
            }
            else
            {
                MessageBox.Show("You have to select an appointment", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); 
            }
        }






        private void takeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                bool isLocked = (bool)dataGridView1.SelectedRows[0].Cells[3].Value;
                if(isLocked != true)
                {
                    int AppointmentID = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
                    string Date = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                    string fees = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                    TakeTestForm fm = new TakeTestForm(LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID, TestType, AppointmentID, Date, fees);
                    fm.ShowDialog();
                }
                else
                {
                    MessageBox.Show("You have already toke the test !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("You have to select an appointment", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private void Form16_Load(object sender, EventArgs e)
        {
            initializeUI();
        }
    }
}
