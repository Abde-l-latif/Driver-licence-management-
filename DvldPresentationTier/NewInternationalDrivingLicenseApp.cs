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
    public partial class NewInternationalDrivingLicenseApp : Form
    {
        int AppID;
        int PersonID;
        public NewInternationalDrivingLicenseApp()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterParent;
            initializeUI();
            issueBTN.Enabled = false; 
        }

        private void initializeUI()
        {
            LicenseHistory.Enabled = false;
            LicenseInfo.Enabled = false; 
        }

        private void BTNclose_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }

        private void fillPrimaryData()
        {
            DateTime date = DateTime.Now;
            labelIssueDate.Text = date.ToShortDateString();
            labelExpirationDate.Text = date.Day + "/" + date.Month + "/" + (date.Year + 1).ToString();
            labelLocalLicenseID.Text = licenseDetailsControle1.getLicenseID().ToString();
            createdBy.Text = Global.USER.UserName.ToString();
            labelFees.Text = application.getApplicationFee(6).ToString("0.00");
        }

        private void LicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LicenseHistory fm = new LicenseHistory(PersonID);
            fm.ShowDialog();
        }

        private void issueBTN_Click(object sender, EventArgs e)
        {
            DateTime ExpiredDate = new DateTime();

            if (!Licenses.isinterLicenseExists(Convert.ToInt32(txtLicenseID.Text) , ref ExpiredDate) ||
               (Licenses.isinterLicenseExists(Convert.ToInt32(txtLicenseID.Text), ref ExpiredDate) && ExpiredDate < DateTime.Now))
            {
                if (Licenses.isinterLicenseActive(Convert.ToInt32(txtLicenseID.Text)))
                {
                    MessageBox.Show("This person already has an Active international License", "already Exists", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                application interApplication = new application();
                //interApplication.ApplicationStatus = 3;
                interApplication.ApplicantPersonID = PersonID;
                interApplication.ApplicationDate = DateTime.Now;
                interApplication.LastStatusDate = DateTime.Now;
                //interApplication.ApplicationTypeID = 6;
                interApplication.CreatedByUserID = Global.USER.UserID;
                interApplication.PaidFees = Convert.ToDecimal(labelFees.Text);
                if(interApplication.Save())
                {
                    labelInterAppID.Text = interApplication.ApplicationID.ToString();
                    labelAppDate.Text = interApplication.ApplicationDate.ToString();
                    int interLicenseID = Licenses.insertinterLicense(AppID, Convert.ToDateTime(labelExpirationDate.Text), Convert.ToDateTime(labelIssueDate.Text), Global.USER.UserID);
                    labelInterLicenseID.Text = Convert.ToString(interLicenseID);
                    issueBTN.Enabled = false;
                    LicenseInfo.Enabled = true;
                    MessageBox.Show("Operation Done Successfully International License ID = " + interLicenseID.ToString(), "succeeded", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show("Operation failed !!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            } 
            else
            {
                MessageBox.Show("This person already has an international License" , "already Exists" , MessageBoxButtons.OK , MessageBoxIcon.Error);
            }
        }

        private void LicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int driverID = Driver.getDriverIdByPersonID(PersonID); 
            interLicenseDetails fm = new interLicenseDetails(Convert.ToInt32(labelInterAppID.Text) , Convert.ToInt32(labelInterLicenseID.Text) , PersonID , Convert.ToInt32(txtLicenseID.Text) ,
               labelIssueDate.Text, labelExpirationDate.Text , true , driverID);
            fm.ShowDialog(); 
        }

        private void pictureAddInterLicense_Click(object sender, EventArgs e)
        {
            DateTime ExpiredDate = new DateTime();

            int LicenseClassID = Licenses.getLicenseClassByLicenseID(Convert.ToInt32(txtLicenseID.Text));

            if (Licenses.isLicenseExists(Convert.ToInt32(txtLicenseID.Text), ref ExpiredDate) && ExpiredDate < DateTime.Now)
            {
                MessageBox.Show("Operation failed , this license is Expired !!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!Licenses.isLicenseActive(Convert.ToInt32(txtLicenseID.Text)))
            {
                MessageBox.Show("Operation failed , this license is not active !!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (LicenseClassID != 3)
            {
                MessageBox.Show("Operation failed , you need ordinary driving license class", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            AppID = Licenses.getAppIDByLicenseID(Convert.ToInt32(txtLicenseID.Text));
            PersonID = application.getPersonIDByAppID(AppID);
            if (AppID != -1)
            {
                licenseDetailsControle1.SetApplicationID(AppID);
                licenseDetailsControle1.Reload();
                fillPrimaryData();
                issueBTN.Enabled = true;
                LicenseHistory.Enabled = true;
            }
            else
            {
                MessageBox.Show("License Note Found!!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
