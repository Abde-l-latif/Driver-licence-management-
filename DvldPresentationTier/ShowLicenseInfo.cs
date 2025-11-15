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

        enum enReason { FirstTime = 1, Renew, Replacement, Damaged, ReplacementForLost }

        struct sLicense
        {
            public int LicenseID ;
            public int DriverID ;
            public DateTime expirationDate;
            public DateTime IssueDate;
            public DateTime BirthDate ;
            public string Notes;
            public string ClassName;
            public string FullName;
            public string NationalNo;
            public string ImagePath ;
            public byte IssueReason;
            public byte Gender;
            public bool isActive;
        }

        sLicense LicenseDetails = new sLicense
        {
            LicenseID = -1,
            Gender = 0,
            ImagePath = "",
            BirthDate = DateTime.Now,
            ClassName = "",
            DriverID = -1,
            expirationDate = DateTime.Now,
            isActive = false,
            FullName = "",
            IssueDate = DateTime.Now,
            IssueReason = 0,
            NationalNo = "",
            Notes = ""
        };
        public ShowLicenseInfo(int AppID)
        {
            StartPosition = FormStartPosition.CenterParent;
            InitializeComponent();
            ApplicationID = AppID; 
        }

        public void getLicenseDetails()
        {
            Licenses.LicenseDetails(ApplicationID, ref LicenseDetails.LicenseID, ref LicenseDetails.DriverID, ref LicenseDetails.IssueDate, ref LicenseDetails.expirationDate, 
                ref LicenseDetails.Notes, ref LicenseDetails.IssueReason, ref LicenseDetails.isActive, ref LicenseDetails.ClassName,
                ref LicenseDetails.FullName, ref LicenseDetails.NationalNo, ref LicenseDetails.Gender, ref LicenseDetails.BirthDate, ref LicenseDetails.ImagePath);
        }

        public void FillLicenseDetails()
        {
            LbClass.Text = LicenseDetails.ClassName;
            LbBirth.Text = Convert.ToString(LicenseDetails.BirthDate); 
            LbExpirationDate.Text = Convert.ToString(LicenseDetails.expirationDate);
            LbIssueDate.Text = Convert.ToString(LicenseDetails.IssueDate);
            lbName.Text = LicenseDetails.FullName; 
            LbNational.Text = LicenseDetails.NationalNo;
            LbNote.Text = LicenseDetails.Notes == "" ? "No Notes" : LicenseDetails.Notes;
            LbLicenseID.Text = LicenseDetails.LicenseID.ToString();
            LbDriverID.Text = LicenseDetails.DriverID.ToString();
            LbIsActive.Text = LicenseDetails.isActive ? "Yes" : "No";
            LbGender.Text = LicenseDetails.Gender == 0 ? "Male" : "Female";

            enReason reason = (enReason)LicenseDetails.IssueReason;

            switch(reason)
            {
                case enReason.FirstTime:
                    LbIssueReason.Text = "First time";
                    break;
                case enReason.Replacement:
                    LbIssueReason.Text = "Replacement";
                    break;
                case enReason.Renew:
                    LbIssueReason.Text = "Renew";
                    break;
                case enReason.ReplacementForLost:
                    LbIssueReason.Text = "Replacement For Lost";
                    break;
                case enReason.Damaged:
                    LbIssueReason.Text = "Damaged";
                    break;
            }
        }

        public void initializeGenderPec()
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

        public void initializeProfileImage()
        {
            if (LicenseDetails.ImagePath == "")
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
                pictureProfile.ImageLocation = LicenseDetails.ImagePath;
        }

        private void BTNclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ShowLicenseInfo_Load(object sender, EventArgs e)
        {
            getLicenseDetails();
            FillLicenseDetails();
            initializeGenderPec();
            initializeProfileImage();
        }
    }
}
