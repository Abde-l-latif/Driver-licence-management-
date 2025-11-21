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
    public partial class interLicenseDetails : Form
    {
        int interLicenseID;
        int AppID;
        int PersonID;
        int LicenseID;
        string issueDate;
        string ExpirationDate;
        bool isActive;
        int DriverID;
        people person;
        public interLicenseDetails(int interID , int AppID , int PersonID , int LicenseID , string issueDate , string ExpirationDate , bool isActive , int DriverID)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterParent; 
            this.interLicenseID = interID;
            this.AppID = AppID;
            this.PersonID = PersonID;
            this.LicenseID = LicenseID;
            this.issueDate = issueDate;
            this.ExpirationDate = ExpirationDate;
            this.isActive = isActive;
            this.DriverID = DriverID;
            FillPrimaryData(); 
        }


        private void FillPrimaryData()
        {
            labelAppID.Text = AppID.ToString(); 
            LbInterLicenseID.Text = interLicenseID.ToString();
            LbLicenseID.Text = LicenseID.ToString();
            person = people.Find(PersonID); 
            if(person != null)
            {
                lbName.Text = person.FirstName + " " + person.SecondName + " " + person.ThirdName + " " + person.LastName;
                LbNational.Text = person.NationalNo;
                LbBirth.Text = Convert.ToString(person.DateOfBirth);
                LbGender.Text = person.Gender;
                LbIssueDate.Text = issueDate;
                LbExpirationDate.Text = ExpirationDate;
                LbDriverID.Text = DriverID.ToString();
                if (isActive)
                    LbIsActive.Text = "yes";
                else
                    LbIsActive.Text = "No";

                initializeGenderPec();
                initializeProfileImage(); 

            }
            else
            {
                MessageBox.Show(" person Not Found !! ", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            if (person.ImagePath == "")
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
                pictureProfile.ImageLocation = person.ImagePath;
        }

        private void BTNclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
