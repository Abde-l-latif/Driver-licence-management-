using DvldBusinessTier;
using DvldProject.Properties;
using System;
using System.Windows.Forms;

namespace DvldProject
{
    public partial class ManageAppointments : Form
    {

        enum enMode { addMode , upDateMode}


        enMode Mode;


        private int DL_AppID = -1; 
        private TestAppointment appointment;
        private int TestType;
        application app;


        public ManageAppointments(int id , int TestType)
        {

            InitializeComponent();

            appointment = new TestAppointment();

            DL_AppID = id;

            appointment.LocalDrivingLicenseApplication = LdlApplication.FindByLocalDrivingAppLicenseID(DL_AppID);

            this.TestType = TestType;

            StartPosition = FormStartPosition.CenterParent;

            Mode = enMode.addMode; 

        }

        public ManageAppointments(int appointmentID)
        {
            InitializeComponent();
    
            StartPosition = FormStartPosition.CenterParent;

            appointment = TestAppointment.Find(appointmentID);

            DL_AppID = appointment.LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID;

            TestType = appointment.testTypeID;

            labelRAppID.Text = appointment.retakeTestId == -1 ? "" : appointment.retakeTestId.ToString(); 

            disenableEditingIfLocked(appointment.isLocked, appointment.appointmentDate);

            Mode = enMode.upDateMode; 
        }

        private void disenableEditingIfLocked(bool isLocked , DateTime Date)
        {
            if (isLocked)
            {
                labelDate.Text = Date.ToString();

                dateTimePicker1.Enabled = false;

                dateTimePicker1.Visible = false;

                BTNsave.Enabled = false;
            }
            else
            {

                dateTimePicker1.Focus();

                dateTimePicker1.Value = Date; 

                dateTimePicker1.MinDate = Date;

            }
        }

        private void FillApp()
        {
            app = new application();

            app.ApplicantPersonID = appointment.LocalDrivingLicenseApplication.ApplicantPersonID;

            app.CreatedByUserID = Global.USER.UserID;

            app.ApplicationStatus = application.enAppStatus.New;

            app.ApplicationTypeID = application.enAppTypes.renewLicense;

            app.PaidFees = application.getApplicationFee(7);

        }

        private void initializeUI()
        {
            groupBox2.Enabled = false;

            if (appointment.isLocked == true && Mode == enMode.upDateMode)
            {
                labelTitle.Text = "Schedule Retake Test";
                labelMsg.Visible = true;
            }

            if(Tests.isTestFailedExists(DL_AppID , TestType))
            {
                labelTitle.Text = "Schedule Retake Test";
                groupBox2.Enabled = true; 
                FillApp();
                labelRetakeFees.Text = app.PaidFees.ToString();
            }

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
            int trials = 0;
            Tests.GetScheduleTestInfo(DL_AppID, this.TestType, ref className, ref FullName, ref fees, ref trials);
            labelClass.Text = className;
            labelFees.Text = fees.ToString("0.00");
            labelName.Text = FullName;
            labelID.Text = DL_AppID.ToString();
            labelTrial.Text = trials.ToString();
            labelTotalFees.Text = (Convert.ToDecimal(labelFees.Text) + Convert.ToDecimal(labelRetakeFees.Text)).ToString("0.00"); 
        }

        private void Form17_Load(object sender, EventArgs e)
        {
            initializeUI();
            setValues(); 
        }

        private void BTNclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FillAppointment(TestAppointment appointment)
        {
            appointment.PaidFees = Convert.ToDecimal(labelFees.Text) + Convert.ToDecimal(labelRetakeFees.Text);
            appointment.appointmentDate = dateTimePicker1.Value;
            appointment.testTypeID = this.TestType;
            appointment.LDL_ID = this.DL_AppID;
            appointment.CreateByUserID = Global.USER.UserID;
            appointment.isLocked = false;

        }

        private void BTNsave_Click(object sender, EventArgs e)
        {
            if (labelTitle.Text == "Schedule Retake Test")
            {
                if (!app.Save())
                {
                    MessageBox.Show("Operation Failed!!", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                labelRAppID.Text = app.ApplicationID.ToString();
                appointment.retakeTestId = app.ApplicationID;
            }

            FillAppointment(appointment);


            if (appointment.Save())
            {
                MessageBox.Show("Operation Done Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BTNsave.Enabled = false;
            }
            else
                MessageBox.Show("Operation Failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

    }
}
