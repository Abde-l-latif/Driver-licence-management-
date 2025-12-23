using DvldBusinessTier;
using System;
using System.Windows.Forms;

namespace DvldProject
{
    public partial class DetainLicenseForm : Form
    {
        Licenses License;
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

        private void LicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LicenseHistory fm = new LicenseHistory(License.App.Person.PersonID);
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


        private void DetainBTN_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("You need to fill all information !!", "NOT ALLOWED", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (DetainLicense.IsLicenseDetained(License.LicenseID))
            {
                MessageBox.Show("this License Already Detained !!", "Detained", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DetainLicense Detain = License.DetainCurrentLicense(Global.USER.UserID, Convert.ToSingle(textFineFees.Text));

            if (Detain == null)
            {
                MessageBox.Show("Failed To Detaine License !!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show($"License with id = {License.LicenseID} has been detained Successfully ", "Succeeded", MessageBoxButtons.OK, MessageBoxIcon.Information);

            detainID.Text = Detain.DetainID.ToString();
            DetainBTN.Enabled = false;
            LicenseInfo.Enabled = true;

        }

        private void LicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ShowLicenseInfo fm = new ShowLicenseInfo(License.LicenseID);
            fm.ShowDialog();
        }

        private void licenseDetailsFilter1_onSelectedLicenseID(int obj)
        {

            License = Licenses.Find(obj);

            if (License == null)
            {
                MessageBox.Show("License Not Found !!", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; 
            }

            DetainBTN.Enabled = true;
            LicenseHistory.Enabled = true;
            LBLicenseID.Text = License.LicenseID.ToString();

        }

        private void DetainLicenseForm_Shown(object sender, EventArgs e)
        {
            licenseDetailsFilter1.FocusText();
        }
    }
}
