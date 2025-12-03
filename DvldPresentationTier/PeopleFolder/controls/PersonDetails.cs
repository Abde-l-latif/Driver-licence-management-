
using DvldProject.Properties;
using System;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using DvldBusinessTier; 


namespace DvldProject
{
    public partial class PersonDetails : UserControl
    {
        people person; 
        private int _PersonID = -1;

        public PersonDetails()
        {
            InitializeComponent();
        }

        public void setPersonId(int personID)
        {
            _PersonID = personID;
        }

        public int getPersonID()
        {
            return _PersonID;
        }

        public string getNationalNo()
        {
            return LBNationaNo.Text; 
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

        private void initializeEmptyPerson()
        {
            LBPersonID.Text = "";
            LBName.Text = "";
            LBNationaNo.Text = "";
            LBDate.Text = "";
            LBPhone.Text = "";
            LBEmail.Text = "";
            LBAddress.Text = "";
            LBGender.Text = "";
            LBCountry.Text = "";
            pictureProfile.Image = Resources.user__22_;
        }

        public void LoadPersonByID(int personID)
        {
            _PersonID = personID;
            person = people.Find(_PersonID);
            if (person != null)
                fillPersonDetails();
            else
            {
                linkLabel1.Enabled = false;
                initializeEmptyPerson();
            }
        }

        public void LoadPersonByNationalNo(string NationalNo)
        {
            person = people.Find(NationalNo);
            if (person != null)
            {
                _PersonID = person.PersonID;
                fillPersonDetails();
            }
            else
            {
                linkLabel1.Enabled = false;
                initializeEmptyPerson();
            }
        }

        private void LoadPersonDetails()
        {
            person = people.Find(_PersonID);
            if (person != null)
                fillPersonDetails();
            else
            {
                linkLabel1.Enabled = false;
                initializeEmptyPerson();
            }
        }

        private void fillPersonDetails()
        {      
            linkLabel1.Enabled = true;
            LBPersonID.Text = _PersonID.ToString();
            LBName.Text = $"{person.FirstName} {person.SecondName} {person.ThirdName} {person.LastName}";
            LBNationaNo.Text = person.NationalNo;
            LBDate.Text = person.DateOfBirth.ToShortDateString();
            LBPhone.Text = person.Phone;
            LBEmail.Text = person.Email;
            LBAddress.Text = person.Address;
            LBGender.Text = person.Gender;
            LBCountry.Text = person.Country.CountryName.ToString();
        
            if (person.ImagePath != "")
            {
                using (var stream = new MemoryStream(File.ReadAllBytes(person.ImagePath)))
                {
                    pictureProfile.Image = Image.FromStream(stream);
                }
        
                pictureProfile.Tag = person.ImagePath;
            }

            HandelGenderIcon();
            HandelPofilePicture();
        }

        public void reload()
        {
            LoadPersonDetails();
        }

        private void PersonDetails_Load(object sender, EventArgs e)
        {
            reload();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AddEditPerson fm = new AddEditPerson(_PersonID);
            fm.ShowDialog();

            reload();
        }
    }
}
