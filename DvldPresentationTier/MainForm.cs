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
            Form fm = new Form3();
            fm.ShowDialog();
        }

        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form fm = new Form6();
            fm.ShowDialog(); 
        }

        private void currentUserInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form9 fm = new Form9(Global.USER.PersonID, Global.USER.UserID);
            fm.ShowDialog();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form8 fm = new Form8(Global.USER.PersonID, Global.USER.UserID);
            fm.ShowDialog();
        }

        private void manageApplicationTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form10 fm = new Form10();
            fm.ShowDialog();
        }

        private void manageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form12 fm = new Form12();
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
    }
}
