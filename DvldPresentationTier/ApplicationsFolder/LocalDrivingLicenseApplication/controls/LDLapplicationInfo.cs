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
    public partial class LDLapplicationInfo : UserControl
    {
        LdlApplication LocalDrivingLicenseApplication;
        public LDLapplicationInfo()
        {
            InitializeComponent();
            linkLabel1.Enabled = false;
        }

        public void LoadDataByLdlApplication(int id)
        {
            LocalDrivingLicenseApplication = LdlApplication.FindByLocalDrivingAppLicenseID(id);

            if( LocalDrivingLicenseApplication != null )
            {

                LBid.Text = LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID.ToString();
                LBAppliedL.Text = LocalDrivingLicenseApplication.License_Class.ClassName;
                LBpassedTest.Text =  Tests.getPassedTests(LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID).ToString() + "/3";
                if (LocalDrivingLicenseApplication.ApplicationStatus == application.enAppStatus.Completed)
                {
                    linkLabel1.Enabled = true;
                }

            }
            else
                MessageBox.Show("wrong id try again" , "not Found" , MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
        }
    }
}
