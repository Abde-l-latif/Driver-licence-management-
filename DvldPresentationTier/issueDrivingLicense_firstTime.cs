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
        private string NationalNo;
        private int appID;
        private int personID;
        private int reason;
        public issueDrivingLicense_firstTime(int LDLid , string NationalNo , int reason)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            this.reason = reason;
            this.LDLid = LDLid;
            this.NationalNo = NationalNo;
            this.appID = application.getAppIdByLDLid(LDLid);
            this.personID = people.getPersonIDbyNationalNo(this.NationalNo);
            //ldLapplicationInfo1.setDldId(this.LDLid);
            //appDetails1.setAppID(this.appID);
            //appDetails1.setPersonID(this.personID);
        }

        private void issueDrivingLicense_firstTime_Load(object sender, EventArgs e)
        {
            //ldLapplicationInfo1.reload(); 
            //appDetails1.reload();
        }

        private void BTNclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void reloadForms()
        {
            foreach (Form fm in Application.OpenForms)
            {
                if (fm is localDrivingLicenseApp ldlapp)
                {
                    ldlapp.reload();
                }
            }
        }

        private void BTNsave_Click(object sender, EventArgs e)
        {
            int DriverId = -1;
            if(!Driver.isDriverExists(personID))
            {
                Driver driver = new Driver(personID, Global.USER.UserID);
                driver.addDriver();
                DriverId = driver.DriverID;
            }
            else
            {
                DriverId = Driver.getDriverIdByPersonID(personID); 
            }

            int LicenseClassID = Licenses.getLicenseClassIdByLdlID(this.LDLid); 

            Licenses license = new Licenses(this.appID , DriverId , LicenseClassID , DateTime.Now , textNote.Text, true , reason , Global.USER.UserID);

            if (license.AddFirstTimeLicense())
            {
                //application app = new application(appID);
                //if(app.Save(3))
                //{
                //    MessageBox.Show("License issued successfully with LicenseID = " + license.LicenseID, "succeeded", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    BTNsave.Enabled = false;
                //    reloadForms(); 
                //}

            }
            else
                MessageBox.Show("License issue Failed !!" , "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
