using DvldBusinessTier;
using System;
using System.Windows.Forms;

namespace DvldProject
{
    public partial class replacementDamagedLostLicenseForm : Form
    {

        Licenses.enReason Reason = Licenses.enReason.ReplacementforDamaged;
        int AppType = (int)application.enAppTypes.replaceDamagedLicense;
        public replacementDamagedLostLicenseForm()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            licenseDetailsFilter1.onSelectedLicenseID += LicenseSelected;
        }

        private void InitializeUi()
        {
            radioDamaged.Checked = true;
            IssueBTN.Enabled = false; 
            LicenseHistory.Enabled = false;
            LicenseInfo.Enabled = false; 
        }

        private void fillData()
        {
            AppDate.Text = DateTime.Now.ToShortDateString();
            AppFees.Text = ApplicationType.Find(AppType).ApplicationFees.ToString();
            LBoldLicenseID.Text = licenseDetailsFilter1.LicenseInfo.LicenseID.ToString();
            LbCreatedBy.Text = Global.USER.UserName;
        }

        private void LicenseSelected(int licenseID)
        {
            if(!Licenses.isLicenseActive(licenseID))
            {
                MessageBox.Show("this license is not active !" , "Not Active", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            fillData();
            IssueBTN.Enabled = true;
            LicenseHistory.Enabled = true;
        }

        private void radio_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;

            if (!radioButton.Checked)
                return;

            if (radioButton == radioDamaged)
            {
                LbTitle.Text = "Replacement for Damaged License";
                Reason = Licenses.enReason.ReplacementforDamaged;
                AppType = (int)application.enAppTypes.replaceDamagedLicense;
            }
            else if (radioButton == radioLost)
            {
                LbTitle.Text = "Replacement for Lost License";
                Reason = Licenses.enReason.ReplacementforLost;
                AppType = (int)application.enAppTypes.replaceLostLicense;

            }
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
            LicenseHistory fm = new LicenseHistory(licenseDetailsFilter1.LicenseInfo.App.Person.PersonID);
            fm.ShowDialog();
        }

        private void IssueBTN_Click(object sender, EventArgs e)
        {
            Licenses License = licenseDetailsFilter1.LicenseInfo.ReplaceLicense(Reason , Global.USER.UserID);

            if( License == null )
            {

                MessageBox.Show("Operation Failed !", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;

            }

            LRAppID.Text = License.App.ApplicationID.ToString();
            LBreplacedLicenseID.Text = License.LicenseID.ToString();

            MessageBox.Show("Operation Done Successfully License Id = " + LBreplacedLicenseID.Text, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            IssueBTN.Enabled = false;
            LicenseInfo.Enabled = true; 
        }

        private void LicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form fm = new ShowLicenseInfo(Convert.ToInt32(LBreplacedLicenseID.Text));
            fm.ShowDialog();
        }
    }
}
