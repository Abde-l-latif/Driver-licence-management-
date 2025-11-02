using DvldBusinessTier;
using DvldProject.Properties;
using System;
using System.IO;
using System.Windows.Forms;
using System.Drawing;

namespace DvldProject
{
    public partial class PersonDetails : UserControl
    {

        private int _PersonID = -1;

        public PersonDetails()
        {
            InitializeComponent();
        }

        public void setProductId(int productID)
        {
            _PersonID = productID;
        }

        private void HandelGenderIcon()
        {
            if (LBGender.Text == "Male")
                pictureBox9.Image = Resources.man_gentleman_husband_male_guy;
            else
                pictureBox9.Image = Resources.administrator_female;
        }

        private void HandelPofilePicture()
        {
            if(pictureProfile.Image == null)
            {
                if (LBGender.Text == "Male")
                    pictureProfile.Image = Resources.user__22_;
                else
                    pictureProfile.Image = Resources.admin_female;
            }
        }

        private void fillPersonDetails()
        {
            people person = people.Find(_PersonID);

            if(person != null)
            {
                LBPersonID.Text = _PersonID.ToString();
                LBName.Text = $"{person.FirstName} {person.SecondName} {person.ThirdName} {person.LastName}";
                LBNationaNo.Text = person.NationalNo;
                LBDate.Text = person.DateOfBirth.ToString();
                LBPhone.Text = person.Phone;
                LBEmail.Text = person.Email;
                LBAddress.Text = person.Address;
                LBGender.Text = person.Gender;
                LBCountry.Text = person.Country;

                if (person.ImagePath != "")
                {
                    using (var stream = new MemoryStream(File.ReadAllBytes(person.ImagePath)))
                    {
                        pictureProfile.Image = Image.FromStream(stream);
                    }
                    pictureProfile.Tag = person.ImagePath;
                }
            }

        }

        private void PersonDetails_Load(object sender, EventArgs e)
        {
            fillPersonDetails();
            HandelGenderIcon();
            HandelPofilePicture();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form4 fm = new Form4(_PersonID);
            fm.ShowDialog();
        }
    }
}
