using DvldBusinessTier;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DvldProject
{
    public partial class AddUpdateLdlApp : Form
    {
        enum enMode { AddMode , UpdateMode };

        enMode Mode; 

        private LdlApplication LocalDrivingLicenseApplication;
        private int _LocalDrivingLicenseApplicationID;
        int _selectedPersonID;

        public AddUpdateLdlApp()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterParent;
            Mode = enMode.AddMode;
            BTNNext.Enabled = false; 
        }

        public AddUpdateLdlApp(int id)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterParent;
            Mode = enMode.UpdateMode;
            _LocalDrivingLicenseApplicationID = id;
            BTNNext.Enabled = true;
        }

        private void _LoadData()
        {
            comboBox1.DataSource = LicenseClass.GetAllLicenseClasses();
            comboBox1.DisplayMember = "ClassName";

            personDetailsFilter1.FilterPerson = false;
            LocalDrivingLicenseApplication = LdlApplication.FindByLocalDrivingAppLicenseID(_LocalDrivingLicenseApplicationID);

            if (LocalDrivingLicenseApplication == null)
            {
                MessageBox.Show("No Application with ID = " + _LocalDrivingLicenseApplicationID, "Application Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();

                return;
            }

            personDetailsFilter1.LoadPersonInfo(LocalDrivingLicenseApplication.ApplicantPersonID);

            LBdlID.Text = LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID.ToString();

            LbDate.Text = LocalDrivingLicenseApplication.ApplicationDate.ToShortDateString();

            comboBox1.SelectedIndex = comboBox1.FindString(LocalDrivingLicenseApplication.License_Class.ClassName);

            LBCoins.Text = LocalDrivingLicenseApplication.PaidFees.ToString();

            LBCreatedBy.Text = Users.getUserByUserID(LocalDrivingLicenseApplication.CreatedByUserID).UserName;

        }

        private void _reloadForm()
        {
            if(Mode  == enMode.AddMode)
            {
                label1.Text = "New Local Driving License Application";
                LocalDrivingLicenseApplication = new LdlApplication();
                AddApplication();
            }
            else
            {
                label1.Text = "Update Local Driving License Application";
            }
        }

        private void NewLdlApp_Load(object sender, EventArgs e)
        {
            _reloadForm();
            if (Mode == enMode.UpdateMode)
                _LoadData();

        }

        private void BTNclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void personDetailsFilter1_OnPersonSelected(int obj)
        {
            BTNNext.Enabled = true;
            _selectedPersonID = obj;
        }

        private void BTNNext_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
        }

        private void AddApplication()
        {
            LbDate.Text = DateTime.Now.ToString();
            LBCreatedBy.Text = Global.USER.UserName.ToString();
            comboBox1.DataSource = LicenseClass.GetAllLicenseClasses();
            comboBox1.DisplayMember = "ClassName";
            comboBox1.SelectedIndex = 2;
            comboBox1.ValueMember = "LicenseClassID";
            LBCoins.Text = ApplicationType.Find((int)application.enAppTypes.newLocalLicense).ApplicationFees.ToString("0.00");
        }




        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(tabControl1.SelectedIndex == 1)
            {
                if (BTNNext.Enabled == false)
                {
                    tabControl1.SelectedIndex = 0;
                    MessageBox.Show("You have to fill person info !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void BTNsave_Click(object sender, EventArgs e)
        {


            int LicenseClassID = LicenseClass.Find(comboBox1.Text).LicenseClassID;


            int ActiveApplicationID = application.GetActiveApplicationIDForLicenseClass(_selectedPersonID, application.enAppTypes.newLocalLicense, LicenseClassID);

            if (ActiveApplicationID != -1)
            {
                MessageBox.Show("Choose another License Class, the selected Person Already have an active application for the selected class with id=" + ActiveApplicationID, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboBox1.Focus();
                return;
            }


            if (Licenses.IsLicenseExistByPersonID(_selectedPersonID, LicenseClassID))
            {

                MessageBox.Show("Person already have a license with the same applied driving class, Choose diffrent driving class", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            LocalDrivingLicenseApplication.ApplicantPersonID = _selectedPersonID;
            LocalDrivingLicenseApplication.ApplicationTypeID = application.enAppTypes.newLocalLicense;
            LocalDrivingLicenseApplication.ApplicationStatus = application.enAppStatus.New;
            LocalDrivingLicenseApplication.LastStatusDate = DateTime.Now;
            LocalDrivingLicenseApplication.PaidFees = Convert.ToDecimal(LBCoins.Text);
            LocalDrivingLicenseApplication.CreatedByUserID = Global.USER.UserID;
            LocalDrivingLicenseApplication.LicenseClassID = LicenseClassID;


            if (LocalDrivingLicenseApplication.Save())
            {
                LBdlID.Text = LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID.ToString();

                Mode = enMode.UpdateMode;
                label1.Text = "Update Local Driving License Application";

                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BTNsave.Enabled = false;

            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


        }


    }
}
