using DvldBusinessTier;
using DvldProject.Properties;
using System;
using System.Windows.Forms;

namespace DvldProject
{
    public partial class TakeTestForm : Form
    {
        private int DL_AppID = -1;
        private int TestType = -1;
        private int AppointmentID = -1;
        private string Date;
        private string Fees; 

        public TakeTestForm(int id, int TestType, int AppointmentID, string Date , string fees)
        {
            InitializeComponent();
            DL_AppID = id;
            this.TestType = TestType;
            this.AppointmentID = AppointmentID;
            this.Date = Date;
            this.Fees = fees;
            StartPosition = FormStartPosition.CenterParent;
        }

        private void BTNclose_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }

        private void initializeUI()
        {
            if (TestType == 1)
            {
                groupBox1.Text = "Vision Test";
                pictureTest.Image = Resources.eye_open;
                return;
            }
            if (TestType == 2)
            {
                groupBox1.Text = "Written Test";
                pictureTest.Image = Resources.test_edit;
                return;
            }
            if (TestType == 3)
            {
                groupBox1.Text = "Street Test";
                pictureTest.Image = Resources.car_alarm;
                return;
            }
        }

        private void setValues()
        {
            string className = "", FullName = "";
            decimal fees = 0;
            int trials = -1;
            Tests.GetScheduleTestInfo(DL_AppID, this.TestType, ref className, ref FullName, ref fees, ref trials);
            labelClass.Text = className;
            labelFees.Text = this.Fees.ToString();
            labelName.Text = FullName;
            labelID.Text = DL_AppID.ToString();
            labelTrial.Text = trials.ToString();
            labelDate.Text = this.Date; 
        }

        private void Form18_Load(object sender, EventArgs e)
        {
            initializeUI();
            setValues();
            radioPass.Checked = true; 
        }

        private void reloadForms()
        {
            foreach (Form fm in Application.OpenForms)
            {
                if (fm is AppointmentTests schedule)
                {
                    schedule.reloadDataGrid();
                    schedule.reloadLDLapplication();
                }

                if (fm is localDrivingLicenseApp ldlapp)
                {
                    ldlapp.reload();
                }
            }
        }

 

        private void BTNsave_Click(object sender, EventArgs e)
        {
            bool testResult = radioPass.Checked ? true : false;
            int testID = 0;
            if(Tests.insertTest(AppointmentID, testResult, textNote.Text , Global.USER.UserID , ref testID))
            {
                labelTestId.Text = testID.ToString(); 
                if(TestAppointment.updateIsLocked(AppointmentID))
                {
                    MessageBox.Show("Operation Done Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    reloadForms();
                    BTNsave.Enabled = false;
                }
                else
                    MessageBox.Show("Failed to Locked Appointment ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Failed to take Test ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

    }
}
