using DvldBusinessTier;
using System;
using System.Windows.Forms;

namespace DvldProject
{
    public partial class ReleaseDetainForm : Form
    {
        application App = new application(); 

        int LicenseID;
        int PersonID;

        public ReleaseDetainForm()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            InitializeUi();
            //App.ApplicationType = application.enAppTypes.releaseAndDetainedLicense;
            //App.Status = application.enAppStatus.Completed; 
        }
        public ReleaseDetainForm(int LicenseID)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            //App.ApplicationType = application.enAppTypes.releaseAndDetainedLicense;
            //App.Status = application.enAppStatus.Completed;
            this.LicenseID = LicenseID; 
            txtLicenseID.Text = LicenseID.ToString();
            LicenseInfo.Enabled = false;
        }

        private void InitializeUi()
        {
            ReleaseBTN.Enabled = false;
            LicenseHistory.Enabled = false;
            LicenseInfo.Enabled = false;
            LbCreatedBy.Text = Global.USER.UserName;
            detainDate.Text = DateTime.Now.ToShortDateString();
        }

        private void fillDriverLicenseInfo(int AppID)
        {
            licenseDetailsControle1.SetApplicationID(AppID);
            licenseDetailsControle1.Reload();
        }

        private void setDetainInformation()
        {
            int DetainID = -1;
            DateTime DetainDate = DateTime.Now; 
            Decimal FineFees = 0; 
            if(Licenses.getDetainDetails(LicenseID , ref DetainID , ref DetainDate , ref FineFees))
            {
                detainID.Text = DetainID.ToString();
                detainDate.Text = DetainDate.ToShortDateString();
                lbFineFees.Text = FineFees.ToString("0.00"); 
            }
        }

        private void LicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LicenseHistory fm = new LicenseHistory(PersonID);
            fm.ShowDialog();
        }

        private void LicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ShowLicenseInfo fm = new ShowLicenseInfo(Licenses.getAppIDByLicenseID(LicenseID));
            fm.ShowDialog();
        }

        private void FillApplicationInfo()
        {
            App.ApplicantPersonID = PersonID;
            App.ApplicationDate = DateTime.Now;
            //App.ApplicationTypeID = (int)App.ApplicationType;
            //App.ApplicationStatus = (int)App.Status; 
            App.LastStatusDate = DateTime.Now;
            App.CreatedByUserID = Global.USER.UserID; 
        }

        private void ReloadDataGrid()
        {
            foreach(Form fm in Application.OpenForms)
            {
                if (fm is ManageDetainLicenses manageDetain)
                    manageDetain.reload();
            }
        }

        private void ReleaseBTN_Click(object sender, EventArgs e)
        {
            FillApplicationInfo(); 

            if(!App.Save())
            {
                MessageBox.Show("saving application Operation failed !!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; 
            }

            LbAppID.Text = App.ApplicationID.ToString(); 

            if(!Licenses.ReleaseDetainedLicense(LicenseID , DateTime.Now, Global.USER.UserID, App.ApplicationID))
            {
                MessageBox.Show("Release Operation failed !!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Operation Done Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            LicenseInfo.Enabled = true;
            groupBox1.Enabled = false;
            ReloadDataGrid();
        }

        private void FillAllInfo()
        {
            setDetainInformation();
            int ApplicationID = Licenses.getAppIDByLicenseID(LicenseID);
            PersonID = application.getPersonIDByAppID(ApplicationID);
            fillDriverLicenseInfo(ApplicationID);
            LBLicenseID.Text = LicenseID.ToString();
            //LbAppFees.Text = App.getApplicationFee().ToString("0.00");
            LbTotalFees.Text = (Convert.ToDecimal(LbAppFees.Text) + Convert.ToDecimal(lbFineFees.Text)).ToString("0.00");
        }

        private void pictureShowLicense_Click(object sender, EventArgs e)
        {
            LicenseID = Convert.ToInt32(txtLicenseID.Text);

            if (!Licenses.isLicenseExists(LicenseID))
            {
                MessageBox.Show("this License Doesn't Exists !!", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!Licenses.isLicenseActive(LicenseID))
            {
                MessageBox.Show("this License is not active !!", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!Licenses.isLicenseDetained(LicenseID))
            {
                MessageBox.Show("this License is not Detained !!", "Detained", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            FillAllInfo();

            LicenseHistory.Enabled = true;
            ReleaseBTN.Enabled = true;
        }

        private void BTNclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ReleaseDetainForm_Load(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtLicenseID.Text))
            {
                groupBox1.Enabled = false;
                LbCreatedBy.Text = Global.USER.UserName;
                detainDate.Text = DateTime.Now.ToShortDateString();
                FillAllInfo();
            }
        }
    }
}
