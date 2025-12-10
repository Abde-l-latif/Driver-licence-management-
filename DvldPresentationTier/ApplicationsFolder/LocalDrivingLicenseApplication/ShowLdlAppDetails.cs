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
    public partial class ShowLdlAppDetails : Form
    {

        private LdlApplication _LocalDrivingLicenseApplication; 
        public ShowLdlAppDetails(int LdlAppID)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterParent;
            _LocalDrivingLicenseApplication = LdlApplication.FindByLocalDrivingAppLicenseID(LdlAppID);
        }

        private void BTNclose_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }

        private void ShowLdlAppDetails_Load(object sender, EventArgs e)
        {
            if(_LocalDrivingLicenseApplication != null)
            {
                ldLapplicationInfo1.LoadDataByLdlApplication(_LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID);
                appDetails1.LoadApplicationById(_LocalDrivingLicenseApplication.ApplicationID);
            }
        }
    }
}
