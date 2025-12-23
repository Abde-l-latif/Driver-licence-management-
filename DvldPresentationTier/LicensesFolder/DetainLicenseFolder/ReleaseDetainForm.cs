using DvldBusinessTier;
using System;
using System.Windows.Forms;

namespace DvldProject
{
    public partial class ReleaseDetainForm : Form
    {
        Licenses License;

        public ReleaseDetainForm()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            InitializeUi();
        }
        public ReleaseDetainForm(int LicenseID)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            License = Licenses.Find(LicenseID); 
            licenseDetailsFilter1.LoadLicenseDetailsFilter(License.LicenseID);
            FillRestInformation();
            licenseDetailsFilter1.FilterLicense = false;
            LicenseInfo.Enabled = false;
        }

        private void InitializeUi()
        {
            ReleaseBTN.Enabled = false;
            LicenseHistory.Enabled = false;
            LicenseInfo.Enabled = false;
        }

        private void FillRestInformation()
        {
            detainID.Text = License.DetainInfo.DetainID.ToString();
            detainDate.Text = License.DetainInfo.DetainDate.ToShortDateString();
            lbFineFees.Text = License.DetainInfo.FineFees.ToString("0.00");
            LBLicenseID.Text = License.LicenseID.ToString();
            LbCreatedBy.Text = Global.USER.UserName;
            LbAppFees.Text = ApplicationType.Find((int)application.enAppTypes.releaseAndDetainedLicense).ApplicationFees.ToString("0.00");
            LbTotalFees.Text = (Convert.ToSingle(LbAppFees.Text) + Convert.ToSingle(lbFineFees.Text)).ToString("0.00"); 
        }

        private void licenseDetailsFilter1_onSelectedLicenseID(int obj)
        {
            License = Licenses.Find(obj);

            if(License == null)
            {
                MessageBox.Show("Operation failed license object not found !!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return ;
            }

            if(License.DetainInfo == null)
            {
                MessageBox.Show("Operation failed license is not detained !!", "Not Detained", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; 
            }

            ReleaseBTN.Enabled = true;
            LicenseHistory.Enabled = true;

            FillRestInformation();

        }

        private void LicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LicenseHistory fm = new LicenseHistory(License.App.Person.PersonID);
            fm.ShowDialog();
        }

        private void LicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ShowLicenseInfo fm = new ShowLicenseInfo(License.LicenseID);
            fm.ShowDialog();
        }


        private void ReleaseBTN_Click(object sender, EventArgs e)
        {
            int appID = -1; 

            if (License.releaseLicense(Global.USER.UserID , ref appID))
            {
                MessageBox.Show("Operation Done Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            LbAppID.Text = appID.ToString();

            LicenseInfo.Enabled = true;

            ReleaseBTN.Enabled = false;

        }


        private void BTNclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
