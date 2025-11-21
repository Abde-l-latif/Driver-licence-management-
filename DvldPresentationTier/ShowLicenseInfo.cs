using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DvldBusinessTier;
using DvldProject.Properties;

namespace DvldProject
{
    public partial class ShowLicenseInfo : Form
    {
        public int ApplicationID;
        public ShowLicenseInfo(int AppID)
        {
            StartPosition = FormStartPosition.CenterParent;
            InitializeComponent();
            ApplicationID = AppID; 
        }

        private void BTNclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ShowLicenseInfo_Load(object sender, EventArgs e)
        {
            licenseDetailsControle1.SetApplicationID(ApplicationID);
            licenseDetailsControle1.Reload();
        }
    }
}
