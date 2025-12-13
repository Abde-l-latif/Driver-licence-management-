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
                LDLapplicationInfo_Load(null, null);

            }
            else
                MessageBox.Show("wrong id try again" , "not Found" , MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void LDLapplicationInfo_Load(object sender, EventArgs e)
        {
            if(LBpassedTest.Text == "3/3")
            {
                linkLabel1.Enabled = true;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
        }
    }
}
