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
        public ShowLicenseInfo(int LicenseID)
        {
            StartPosition = FormStartPosition.CenterParent;
            InitializeComponent();
            licenseDetailsControle1.LoadLicenseInfoByLicenseID(LicenseID);
        }

        private void BTNclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
