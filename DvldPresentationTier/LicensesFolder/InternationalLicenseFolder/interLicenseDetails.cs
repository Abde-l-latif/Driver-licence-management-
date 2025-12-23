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

        InternationalLicense InterLicense;

        people person;

        public interLicenseDetails(int interID)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterParent;
            InterLicense = InternationalLicense.Find(interID);
            person = InterLicense.DriverInfo.Person;
        }

        private void FillPrimaryData()
        {
            labelAppID.Text = InterLicense.ApplicationID.ToString(); 
            LbInterLicenseID.Text = InterLicense.InternationalLicenseID.ToString();
            LbLicenseID.Text = InterLicense.IssuedUsingLocalLicenseID.ToString();
    
            if(person != null)
            {
                lbName.Text = person.FirstName + " " + person.SecondName + " " + person.ThirdName + " " + person.LastName;
                LbNational.Text = person.NationalNo;
                LbBirth.Text = Convert.ToString(person.DateOfBirth);
                LbGender.Text = person.Gender;
                LbIssueDate.Text = InterLicense.IssueDate.ToShortDateString();
                LbExpirationDate.Text = InterLicense.ExpirationDate.ToShortDateString();
                LbDriverID.Text = InterLicense.DriverID.ToString();
                if (InterLicense.IsActive)
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

        private void interLicenseDetails_Load(object sender, EventArgs e)
        {
        
            FillPrimaryData();
        }

    }
}
