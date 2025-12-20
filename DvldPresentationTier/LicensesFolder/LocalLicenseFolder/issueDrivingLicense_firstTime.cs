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
    public partial class issueDrivingLicense_firstTime : Form
    {

        private int LDLid;
        LdlApplication _LocalDrivingLicenseApplication; 
        public issueDrivingLicense_firstTime(int LDLid)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            this.LDLid = LDLid;
        }

        private void issueDrivingLicense_firstTime_Load(object sender, EventArgs e)
        {
            _LocalDrivingLicenseApplication = LdlApplication.FindByLocalDrivingAppLicenseID(this.LDLid);

            if(_LocalDrivingLicenseApplication != null)
            {
                if(Licenses.IsLicenseExistByPersonID(_LocalDrivingLicenseApplication.ApplicantPersonID, _LocalDrivingLicenseApplication.LicenseClassID))
                {
                    MessageBox.Show("This person already has license !", "Already Exists", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if(Tests.getPassedTests(_LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID) != 3)
                {
                    MessageBox.Show("the targeted person hasn't passed all tests !", " Failed ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                ldLapplicationInfo1.LoadDataByLdlApplication(_LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID);
                appDetails1.LoadApplicationById(_LocalDrivingLicenseApplication.ApplicationID);

            }
            else
                MessageBox.Show("Local Driving License Id not found !" , "Not Found" , MessageBoxButtons.OK, MessageBoxIcon.Error);
        }


        private void BTNclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BTNsave_Click(object sender, EventArgs e)
        {

            int LicenseID = _LocalDrivingLicenseApplication.IssueDrivingLicenseFirstTime(textNote.Text, Global.USER.UserID);
            
            if(LicenseID != -1)
            {
                MessageBox.Show("License issued successfully with LicenseID = " + LicenseID, "succeeded", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BTNsave.Enabled = false;
            }
            else
                MessageBox.Show("License issue Failed !!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

    }
}
