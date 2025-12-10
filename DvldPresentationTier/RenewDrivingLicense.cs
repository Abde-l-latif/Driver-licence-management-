using DvldBusinessTier;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DvldProject
{
    public partial class RenewDrivingLicense : Form
    {
        int PersonID; 
        public RenewDrivingLicense()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            LicenseInfo.Enabled = false;
            LicenseHistory.Enabled = false;
            renewBTN.Enabled = false;
        }
        private void BTNclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FillPrimaryData()
        {
            LbCreatedBy.Text = Global.USER.UserName;
            AppDate.Text = DateTime.Now.ToString(); 
            IssueDate.Text = DateTime.Now.ToShortDateString().ToString();
            AppFees.Text = application.getApplicationFee(2).ToString("0.00");
        }

        private void fillLicenseDetails(int LicenseID)
        {
            DateTime Date = DateTime.Now; 

            int AppID = Licenses.getAppIDByLicenseID(LicenseID);

            licenseDetailsControle1.SetApplicationID(AppID);
            licenseDetailsControle1.Reload();
            PersonID = application.getPersonIDByAppID(licenseDetailsControle1.GetApplicationID());
            LBoldLicenseID.Text = Convert.ToString(LicenseID);
            LicenseFees.Text = Licenses.getLicenseFees(LicenseID).ToString("0.00");
            LbTotalFees.Text = (Convert.ToDecimal(LicenseFees.Text) + Convert.ToDecimal(AppFees.Text)).ToString("0.00");
            LbExpirationDate.Text = Convert.ToString((Date.Day) + "/" + (Date.Month) + "/" + (Date.Year + Licenses.getValiditylengthOfLicense(LicenseID))); 
        } 

        private void pictureAddInterLicense_Click(object sender, EventArgs e)
        {
            DateTime ExpirationDate = DateTime.Now;
            int LicenseID = Convert.ToInt32(txtLicenseID.Text); 

            if(Licenses.isLicenseExists(LicenseID , ref ExpirationDate) && ExpirationDate > DateTime.Now)
            {
                MessageBox.Show("this License still isn't Expired !!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error); 
                return;
            }


            if (!Licenses.isLicenseExists(LicenseID))
            {
                MessageBox.Show("this License Doesn't Exists !!", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(!Licenses.isLicenseActive(LicenseID))
            {
                MessageBox.Show("this License is not active !!", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            fillLicenseDetails(LicenseID);
            LicenseHistory.Enabled = true;
            renewBTN.Enabled = true;
            pictureAddInterLicense.Enabled = false; 

        }

        private void RenewDrivingLicense_Load(object sender, EventArgs e)
        {
            FillPrimaryData();
        }

        private void LicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LicenseHistory fm = new LicenseHistory(PersonID);
            fm.ShowDialog();
        }

        private void setApp()
        {
            application app = new application();
            app.CreatedByUserID = Global.USER.UserID;
            app.PaidFees = Convert.ToDecimal(AppFees.Text);
            //app.ApplicationStatus = 3;
            app.LastStatusDate = Convert.ToDateTime(AppDate.Text);
            app.ApplicationDate = Convert.ToDateTime(AppDate.Text);
            //app.ApplicationTypeID = 2;
            app.ApplicantPersonID = PersonID;
            if (!app.Save())
            {
                MessageBox.Show("saving application Operation failed !!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                RLicenseAppID.Text = app.ApplicationID.ToString();
        }

        private void setLicense()
        {
            Licenses License = new Licenses();
            License.ApplicationID = Convert.ToInt32(RLicenseAppID.Text);
            License.DriverID = Driver.getDriverIdByPersonID(PersonID);
            License.LicenseClass = Licenses.getLicenseClassByLicenseID(Convert.ToInt32(LBoldLicenseID.Text));
            License.IssueDate = Convert.ToDateTime(IssueDate.Text);
            License.ExpirationDate = Convert.ToDateTime(LbExpirationDate.Text);
            License.PaidFees = Convert.ToDecimal(LicenseFees.Text); 
            License.Notes = textBox1.Text;
            License.IsActive = true;
            License.IssueReason = 2;
            License.CreatedByUserID = Global.USER.UserID;
            if (!License.AddLicense())
            {
                MessageBox.Show("saving License Operation failed !!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                LBrenewLicenseID.Text = License.LicenseID.ToString();
        }

        private void renewBTN_Click(object sender, EventArgs e)
        {
            if(Licenses.updateIsActiveOfLicense(Convert.ToInt32(LBoldLicenseID.Text) , false))
            {
                setApp();
                setLicense();
                renewBTN.Enabled = false;
                MessageBox.Show("Operation Done Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LicenseInfo.Enabled = true;
            }

        }

        private void LicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form fm = new ShowLicenseInfo(Convert.ToInt32(RLicenseAppID.Text));
            fm.ShowDialog();
        }

    }
}
