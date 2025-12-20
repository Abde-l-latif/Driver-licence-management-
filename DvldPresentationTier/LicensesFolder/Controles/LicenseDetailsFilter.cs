using DvldBusinessTier;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DvldProject.LicensesFolder.Controles
{
    public partial class LicenseDetailsFilter : UserControl
    {

        public event Action<int> onSelectedLicenseID;

        protected virtual void SelectedLicense(int LicenseID)
        {
            Action<int> Handler = onSelectedLicenseID;

            if (Handler != null)
                Handler(LicenseID);
        }

        public LicenseDetailsFilter()
        {
            InitializeComponent();
        }

        public Licenses LicenseInfo { get { return licenseDetailsControle1.GetLicenseInfo(); } } 

        private bool _FilterLicense = true;

        public bool FilterLicense
        {
            get 
            {
                return _FilterLicense;
            }
            set
            {
                _FilterLicense = value;
                groupBox1.Enabled = _FilterLicense;
            }
        }

        public void LoadLicenseDetailsFilter(int LicenseID)
        {
            licenseDetailsControle1.LoadLicenseInfoByLicenseID(LicenseID);
            SelectedLicense(LicenseID);
        }
        private void pictureAddInterLicense_Click(object sender, EventArgs e)
        {
            licenseDetailsControle1.LoadLicenseInfoByLicenseID(Convert.ToInt32(txtLicenseID.Text));
            SelectedLicense(Convert.ToInt32(txtLicenseID.Text));
        }

        private void txtLicenseID_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if(String.IsNullOrEmpty(txtLicenseID.Text))
            {
                errorProvider1.SetError(txtLicenseID, "this field is required");
                e.Cancel = true;
            } 
            else
            {
                errorProvider1.SetError(txtLicenseID, "");
            }
        }

        private void txtLicenseID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
