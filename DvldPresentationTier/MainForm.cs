using System;
using System.Windows.Forms;


namespace DvldProject
{
    public partial class MainForm : Form
    {
        
        public MainForm()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        private void peopleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form fm = new ManagePeopleForm();
            fm.ShowDialog();
        }

        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form fm = new ManageUsersForm();
            fm.ShowDialog(); 
        }

        private void currentUserInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserDetailsForm fm = new UserDetailsForm(Global.USER.PersonID, Global.USER.UserID);
            fm.ShowDialog();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangePasswordForm fm = new ChangePasswordForm(Global.USER.PersonID, Global.USER.UserID);
            fm.ShowDialog();
        }

        private void manageApplicationTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageAppTypeForm fm = new ManageAppTypeForm();
            fm.ShowDialog();
        }

        private void manageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageTestType fm = new ManageTestType();
            fm.ShowDialog();
        }

        private void localLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewLdlApp fm = new NewLdlApp();
            fm.ShowDialog();
        }

        private void localDrivingLicenseApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            localDrivingLicenseApp fm = new localDrivingLicenseApp();
            fm.ShowDialog();
        }

        private void driversToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DriverForm fm = new DriverForm();
            fm.ShowDialog();
        }

        private void internationalDrivingLicenseApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageInternationalDrivingLicense fm = new ManageInternationalDrivingLicense();
            fm.ShowDialog();
        }

        private void internationalLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewInternationalDrivingLicenseApp fm = new NewInternationalDrivingLicenseApp();
            fm.ShowDialog();    
        }

        private void renewDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RenewDrivingLicense fm = new RenewDrivingLicense();
            fm.ShowDialog();
        }

        private void replacmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            replacementLicenseForm fm = new replacementLicenseForm();
            fm.ShowDialog();
        }

        private void detainLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DetainLicenseForm fm = new DetainLicenseForm();
            fm.ShowDialog(); 
        }

        private void releaseDetainedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReleaseDetainForm fm = new ReleaseDetainForm();
            fm.ShowDialog(); 
        }

        private void manageDetainedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageDetainLicenses fm = new ManageDetainLicenses();
            fm.ShowDialog();
        }
    }
}
