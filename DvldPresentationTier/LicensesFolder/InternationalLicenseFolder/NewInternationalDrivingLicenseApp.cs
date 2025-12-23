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

        Licenses License; 
        public NewInternationalDrivingLicenseApp()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterParent;
            initializeUI();
        }

        private void initializeUI()
        {
            LicenseHistory.Enabled = false;
            LicenseInfo.Enabled = false;
            issueBTN.Enabled = false;
        }

        private void BTNclose_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }

        private void licenseDetailsFilter1_onSelectedLicenseID(int obj)
        {
            License = Licenses.Find(obj);

            if(License == null)
            {
                MessageBox.Show("License object not found !", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!Licenses.isLicenseActive(License.LicenseID))
            {
                MessageBox.Show("Operation failed , this license is not active !!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (License.License_class.LicenseClassID != 3)
            {
                MessageBox.Show("Operation failed , you need ordinary driving license class", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            fillPrimaryData();
            issueBTN.Enabled = true;
            LicenseHistory.Enabled = true;

        }

        private void fillPrimaryData()
        {
            DateTime date = DateTime.Now;
            labelIssueDate.Text = date.ToShortDateString();
            labelExpirationDate.Text = date.Day + "/" + date.Month + "/" + (date.Year + 1).ToString();
            labelLocalLicenseID.Text = License.LicenseID.ToString();
            createdBy.Text = Global.USER.UserName.ToString();
            labelFees.Text = application.getApplicationFee((int)application.enAppTypes.newInternationalLicense).ToString("0.00");
        }

        private void LicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LicenseHistory fm = new LicenseHistory(License.App.Person.PersonID);
            fm.ShowDialog();
        }

        private void LicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            interLicenseDetails fm = new interLicenseDetails(Convert.ToInt32(labelInterLicenseID.Text));
            fm.ShowDialog();
        }

        private void issueBTN_Click(object sender, EventArgs e)
        {
            DateTime ExpiredDate = new DateTime();

            if (!Licenses.isinterLicenseExists(Convert.ToInt32(License.LicenseID) , ref ExpiredDate) ||
               (Licenses.isinterLicenseExists(Convert.ToInt32(License.LicenseID), ref ExpiredDate) && ExpiredDate < DateTime.Now))

            {

                InternationalLicense interLicense = new InternationalLicense();

                interLicense.ApplicationStatus = application.enAppStatus.New;
                interLicense.ApplicantPersonID = License.App.Person.PersonID;
                interLicense.ApplicationDate = DateTime.Now;
                interLicense.LastStatusDate = DateTime.Now;
                interLicense.ApplicationTypeID = application.enAppTypes.newInternationalLicense;
                interLicense.CreatedByUserID = Global.USER.UserID;
                interLicense.PaidFees = Convert.ToDecimal(labelFees.Text);

                interLicense.DriverID = License.DriverID;
                interLicense.IssuedUsingLocalLicenseID = License.LicenseID;
                interLicense.IssueDate = DateTime.Now;
                interLicense.ExpirationDate = DateTime.Now.AddYears(1);


                if (interLicense.Save())
                {
                    labelInterAppID.Text = interLicense.ApplicationID.ToString();
                    labelAppDate.Text = interLicense.ApplicationDate.ToString();
                    labelInterLicenseID.Text = Convert.ToString(interLicense.InternationalLicenseID);
                    issueBTN.Enabled = false;
                    LicenseInfo.Enabled = true;
                    MessageBox.Show("Operation Done Successfully International License ID = " + labelInterLicenseID.Text, "succeeded", MessageBoxButtons.OK, MessageBoxIcon.Information);

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


    }
}
