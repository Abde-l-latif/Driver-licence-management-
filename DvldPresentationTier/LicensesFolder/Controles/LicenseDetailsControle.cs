using DvldBusinessTier;
using DvldProject.Properties;
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
    public partial class LicenseDetailsControle : UserControl
    {
        private int _LicenseID;

        private Licenses _LicenseInfo;

        public LicenseDetailsControle()
        {
            InitializeComponent();
        }

        public int GetLicenseID()
            { return _LicenseID; }

        public Licenses GetLicenseInfo() { return _LicenseInfo; }

        public void LoadLicenseInfoByLicenseID(int id)
        {
            _LicenseInfo = Licenses.Find(id); 

            if( _LicenseInfo != null )
            {
                _LicenseID = _LicenseInfo.LicenseID;
                FillLicenseDetails();
                initializeGenderPec();
                initializeProfileImage();
            }
            else
                MessageBox.Show("License id Not Found !" , "Not Found" , MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private string _FullName()
        {
            return  _LicenseInfo.App.Person.FirstName + " " +
                    _LicenseInfo.App.Person.SecondName + " " +
                    _LicenseInfo.App.Person.ThirdName + " " +
                    _LicenseInfo.App.Person.LastName;
        }

        private void FillLicenseDetails()
        {
            LbClass.Text = _LicenseInfo.License_class.ClassName;
            LbBirth.Text = Convert.ToString(_LicenseInfo.App.Person.DateOfBirth);
            LbExpirationDate.Text = Convert.ToString(_LicenseInfo.ExpirationDate);
            LbIssueDate.Text = Convert.ToString(_LicenseInfo.IssueDate);
            lbName.Text = _FullName();
            LbNational.Text = _LicenseInfo.App.Person.NationalNo;
            LbNote.Text = _LicenseInfo.Notes == "" ? "No Notes" : _LicenseInfo.Notes;
            LbLicenseID.Text = _LicenseInfo.LicenseID.ToString();
            LbDriverID.Text = _LicenseInfo.DriverID.ToString();
            LbIsActive.Text = _LicenseInfo.IsActive ? "Yes" : "No";
            LbGender.Text = _LicenseInfo.App.Person.Gender;
            LbIssueReason.Text = ((Licenses.enReason)_LicenseInfo.IssueReason).ToString();
            LbIsDetained.Text = Licenses.isLicenseDetained(_LicenseInfo.LicenseID) ? "Yes" : "No"; 
        }

        private void initializeGenderPec()
        {
            if (LbGender.Text == "Male")
            {
                pictureGender.Image = Resources.man_gentleman_husband_male_guy;
            }
            else
            {
                pictureGender.Image = Resources.administrator_female;
            }
        }

        private void initializeProfileImage()
        {
            if (_LicenseInfo.App.Person.ImagePath == "")
            {
                if (LbGender.Text == "Male")
                {
                    pictureProfile.Image = Resources.user__22_;
                }
                else 
                {
                    pictureProfile.Image = Resources.admin_female;
                }
            }
            else
            {
                pictureProfile.ImageLocation = _LicenseInfo.App.Person.ImagePath;
            }
        }

    }
}
