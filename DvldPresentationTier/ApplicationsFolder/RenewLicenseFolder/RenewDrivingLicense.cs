using DvldBusinessTier;
using System;
using System.Windows.Forms;

namespace DvldProject
{
    public partial class RenewDrivingLicense : Form
    {

        public RenewDrivingLicense()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            LicenseInfo.Enabled = false;
            LicenseHistory.Enabled = false;
            renewBTN.Enabled = false;
            licenseDetailsFilter1.onSelectedLicenseID += LicenseSelected;
        }
        private void BTNclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FillPrimaryData()
        {
            LbCreatedBy.Text = Global.USER.UserName;
            AppDate.Text = DateTime.Now.ToShortDateString().ToString(); 
            IssueDate.Text = DateTime.Now.ToShortDateString().ToString();
            AppFees.Text = application.getApplicationFee((int)application.enAppTypes.renewLicense).ToString("0.00");
        }

        private void fillLicenseDetails(int LicenseID)
        {
            DateTime Date = DateTime.Now; 
            
            LBoldLicenseID.Text = Convert.ToString(LicenseID);
            LicenseFees.Text = licenseDetailsFilter1.LicenseInfo.License_class.ClassFees.ToString("0.00");
            LbTotalFees.Text = (Convert.ToDecimal(LicenseFees.Text) + Convert.ToDecimal(AppFees.Text)).ToString("0.00");
            LbExpirationDate.Text = Date.AddYears(licenseDetailsFilter1.LicenseInfo.License_class.DefaultValidityLength).ToShortDateString(); 
        }

        private void LicenseSelected(int LicenseID)
        {
            if (licenseDetailsFilter1.LicenseInfo == null)
                return;
            if(!licenseDetailsFilter1.LicenseInfo.isExpired())
                MessageBox.Show("this license is not expired !!" , "Expired" , MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                fillLicenseDetails(LicenseID);
                LicenseHistory.Enabled = true;
                renewBTN.Enabled = true;
            }
        }

        private void RenewDrivingLicense_Load(object sender, EventArgs e)
        {
            FillPrimaryData();
        }


        private void renewBTN_Click(object sender, EventArgs e)
        {
            Licenses License = licenseDetailsFilter1.LicenseInfo.renewLicense(textBox1.Text , Global.USER.UserID);

            if (License != null)
            {
                renewBTN.Enabled = false;
                MessageBox.Show("Operation Done Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LicenseInfo.Enabled = true;
                LBrenewLicenseID.Text = License.LicenseID.ToString();
                RLicenseAppID.Text = License.App.ApplicationID.ToString();
            }
        }

        private void LicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LicenseHistory fm = new LicenseHistory(licenseDetailsFilter1.LicenseInfo.App.Person.PersonID);
            fm.ShowDialog();
        }
        private void LicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form fm = new ShowLicenseInfo(Convert.ToInt32(LBrenewLicenseID.Text));
            fm.ShowDialog();
        }

    }
}
