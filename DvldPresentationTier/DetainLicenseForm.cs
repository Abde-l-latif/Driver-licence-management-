using DvldBusinessTier;
using System;
using System.Windows.Forms;

namespace DvldProject
{
    public partial class DetainLicenseForm : Form
    {

        int LicenseID;
        int PersonID;
        public DetainLicenseForm()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            InitializeUi();
        }

        private void InitializeUi()
        {
            DetainBTN.Enabled = false;
            LicenseHistory.Enabled = false;
            LicenseInfo.Enabled = false;
            LbCreatedBy.Text = Global.USER.UserName;
            DetainDate.Text = DateTime.Now.ToShortDateString();
        }

        private void BTNclose_Click(object sender, System.EventArgs e)
        {
            this.Close(); 
        }

        private void fillDriverLicenseInfo(int AppID)
        {
            //licenseDetailsControle1.SetApplicationID(AppID);
            //licenseDetailsControle1.Reload();
        }

        private void pictureAddInterLicense_Click(object sender, System.EventArgs e)
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

            int ApplicationID = Licenses.getAppIDByLicenseID(LicenseID);
            //PersonID = application.getPersonIDByAppID(ApplicationID);
            fillDriverLicenseInfo(ApplicationID);
            LBLicenseID.Text = LicenseID.ToString();
            LicenseHistory.Enabled = true;
            DetainBTN.Enabled = true; 
        }

        private void LicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LicenseHistory fm = new LicenseHistory(PersonID);
            fm.ShowDialog(); 
        }

        private void textFineFees_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(textFineFees.Text))
            {
                errorProvider1.SetError(textFineFees, "Field cannot be empty!");
                e.Cancel = true;
                return;
            }

            if (!int.TryParse(textFineFees.Text, out int value) || value <= 0)
            {
                errorProvider1.SetError(textFineFees, "You must enter a number > 0");
                e.Cancel = true;
                return;
            }

            errorProvider1.SetError(textFineFees, "");
        }

        private void textFineFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true; 
        }

        private void ReloadDataGrid()
        {
            foreach (Form fm in Application.OpenForms)
            {
                if (fm is ManageDetainLicenses manageDetain)
                    manageDetain.reload();
            }
        }

        private void DetainBTN_Click(object sender, EventArgs e)
        {
            if(Licenses.isLicenseDetained(LicenseID))
            {
                MessageBox.Show("this License Already Detained !!", "Detained", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; 
            }

            int DetaineID = -1;

            if(!Licenses.DetainLicense(ref DetaineID, LicenseID, DetainDate.Text , textFineFees.Text , Global.USER.UserID))
            {
                MessageBox.Show("Failed To Detaine License !!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show($"License with id = {LicenseID} has been detained Successfully ", "Succeeded", MessageBoxButtons.OK, MessageBoxIcon.Information);

            detainID.Text = DetaineID.ToString(); 

            DetainBTN.Enabled = false;
            groupBox1.Enabled = false;
            LicenseInfo.Enabled = true;
            ReloadDataGrid();
        }

        private void LicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ShowLicenseInfo fm = new ShowLicenseInfo(Licenses.getAppIDByLicenseID(LicenseID));
            fm.ShowDialog(); 
        }
    }
}
