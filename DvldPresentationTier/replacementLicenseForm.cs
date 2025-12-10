using DvldBusinessTier;
using System;
using System.Windows.Forms;

namespace DvldProject
{
    public partial class replacementLicenseForm : Form
    {
        private application App =  new application();
        private Licenses License = new Licenses();
        public replacementLicenseForm()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            //App.ApplicationType = application.enAppTypes.replaceDamagedLicense;
            //App.Status = application.enAppStatus.Completed;
            License.Reason = Licenses.enReason.ReplacementforDamaged;
        }

        int OldLicenseID = -1;
        int PersonID; 

        private void InitializeUi()
        {
            IssueBTN.Enabled = false; 
            LicenseHistory.Enabled = false;
            LicenseInfo.Enabled = false; 
        }

        private void radio_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;

            if (!radioButton.Checked)
                return;

            if (radioButton == radioDamaged)
            {
                LbTitle.Text = "Replacement for Damaged License";
                //App.ApplicationType = application.enAppTypes.replaceDamagedLicense;
                License.Reason = Licenses.enReason.ReplacementforDamaged;
            }
            else if (radioButton == radioLost)
            {
                LbTitle.Text = "Replacement for Lost License";
                //App.ApplicationType = application.enAppTypes.replaceLostLicense;
                License.Reason = Licenses.enReason.ReplacementforLost;
            }
        }

        private void fillDriverLicenseInfo(int AppID)
        {
            licenseDetailsControle1.SetApplicationID(AppID);
            licenseDetailsControle1.Reload(); 
        }

        private void fillApplication()
        {
            //App.getApplicationFee();
            //App.ApplicationDate = DateTime.Now;
            //App.CreatedByUserID = Global.USER.UserID;
            //App.ApplicantPersonID = PersonID;
            //App.ApplicationTypeID = (int)App.ApplicationType; 
            //App.LastStatusDate = DateTime.Now;
            //App.ApplicationStatus = (int)App.Status; 

        }

        private void fillLicense()
        {
            License.ApplicationID = App.ApplicationID;
            License.DriverID = Driver.getDriverIdByPersonID(PersonID);
            License.LicenseClass = Licenses.getLicenseClassByLicenseID(OldLicenseID);
            License.IssueDate = DateTime.Now;
            License.FillExpirationDateOfLicense();
            License.CreatedByUserID = Global.USER.UserID;
            License.Notes = ""; 
            License.IsActive = true;
            License.IssueReason = (int)License.Reason;
            License.PaidFees = Licenses.getLicenseFees(OldLicenseID);
        }

        private void InitializeAppInfoForReplacementUI()
        {
            fillApplication();
            AppDate.Text = App.ApplicationDate.ToShortDateString().ToString();
            AppFees.Text = App.PaidFees.ToString("0.00");
            LbCreatedBy.Text = Global.USER.UserName;
            LBoldLicenseID.Text = OldLicenseID.ToString(); 
        }

        private void pictureGetLicenseInfo_Click(object sender, EventArgs e)
        {
            OldLicenseID = Convert.ToInt32(txtLicenseID.Text);

            if(!Licenses.isLicenseExists(OldLicenseID))
            {
                MessageBox.Show("this License Doesn't Exists !!", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!Licenses.isLicenseActive(OldLicenseID))
            {
                MessageBox.Show("this License is not active !!", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int ApplicationID = Licenses.getAppIDByLicenseID(OldLicenseID);
            PersonID = application.getPersonIDByAppID(ApplicationID);
            fillDriverLicenseInfo(ApplicationID);
            InitializeAppInfoForReplacementUI();
            IssueBTN.Enabled = true;
            LicenseHistory.Enabled = true;
        }

        private void BTNclose_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }

        private void replacementLicenseForm_Load(object sender, EventArgs e)
        {
            InitializeUi();
        }

        private void LicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LicenseHistory fm = new LicenseHistory(PersonID);
            fm.ShowDialog();
        }

        private void disabledUI()
        {
            groupBox1.Enabled = false;
            groupBox2.Enabled = false;
        }

        private void IssueBTN_Click(object sender, EventArgs e)
        {

            if (!Licenses.unActiveLicense(OldLicenseID))
            {
                MessageBox.Show("Old license failed to disActivate !!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            disabledUI(); 

            if(!App.Save())
            {
                MessageBox.Show("saving application Operation failed !!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; 
            }

            fillLicense(); 

            if(!License.AddLicense())
            {
                MessageBox.Show("saving License Operation failed !!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; 
            }

            LBreplacedLicenseID.Text = License.LicenseID.ToString();
            LRAppID.Text = App.ApplicationID.ToString();

            MessageBox.Show("Operation Done Successfully License Id = " + LBreplacedLicenseID.Text, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            IssueBTN.Enabled = false;
            LicenseInfo.Enabled = true; 
        }

        private void LicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form fm = new ShowLicenseInfo(Convert.ToInt32(LRAppID.Text));
            fm.ShowDialog();
        }
    }
}
