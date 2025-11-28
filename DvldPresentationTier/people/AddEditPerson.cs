using DvldBusinessTier;
using DvldProject.Properties;
using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using System.Drawing;



namespace DvldProject
{
    public partial class AddEditPerson : Form
    {

        people Person; 

        int PersonID = -1;

        private bool _isImageMarkedForDeletion = false;

        private string _imageToDeletePath = null;


        public delegate void storePersonID(int personID);

        public event storePersonID personIDAdded;

        public AddEditPerson(int PersonID)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterParent;
            this.PersonID = PersonID;
        }

        private void fillDataForm(people person)
        {
            if (person == null)
            {
                MessageBox.Show("Person doesn't exists , operation failed !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            textFirstName.Text = person.FirstName;
            textSecondName.Text = person.SecondName;
            textThirdName.Text = person.ThirdName;
            textLastName.Text = person.LastName;
            textNationalNo.Text = person.NationalNo;
            dateTimePicker1.Value = person.DateOfBirth;
            textPhone.Text = person.Phone;
            textEmail.Text = person.Email;
            textAddress.Text = person.Address;

            if (person.Gender == "Male")
                radioMale.Checked = true;
            else
                radioFemale.Checked = true;

            comboCountries.SelectedValue = person.Country.CountryName;

            if(person.ImagePath != "")
            {
                using (var stream = new MemoryStream(File.ReadAllBytes(person.ImagePath)))
                {
                    pictureProfile.Image = Image.FromStream(stream);
                }
                pictureProfile.Tag = person.ImagePath;

                linkRemoveImage.Enabled = true;
                linkRemoveImage.Visible = true;
                linkProfileImage.Visible = false;
                linkProfileImage.Enabled = false;
            }

          
        }

        private void preCustomUI()
        {
            if (PersonID == -1)
            {
                LBTitle.Text = "Add new person";
                LBpersonID.Image = Resources.block_list2;
                LBpersonID.Text = "N/A";
                Person = new people();
            }
            else
            {
                LBTitle.Text = "Update person";
                LBpersonID.Text = PersonID.ToString();
                Person = people.Find(PersonID);
                fillDataForm(Person);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            _isImageMarkedForDeletion = false;
            _imageToDeletePath = null;
            this.Close(); 
        }

        private void BTNclose_Click(object sender, EventArgs e)
        {
            _isImageMarkedForDeletion = false;
            _imageToDeletePath = null;
            this.Close();
        }

        private void CheckedChanged(object sender, EventArgs e)
        {
            if(pictureProfile.Tag == null)
            {
                if ((RadioButton)sender == radioMale)
                {
                    pictureProfile.Image = Resources.user__22_;
                }
                else
                {
                    pictureProfile.Image = Resources.admin_female;
                }
            }
        }

        private void FillComboCountries()
        {
            comboCountries.DataSource = Countries.getAllCountries();
            comboCountries.DisplayMember = "CountryName";
            comboCountries.ValueMember = "CountryName";
            comboCountries.SelectedIndex = 0;
        }

        private void setDate()
        {
            string MinimumDate = $"{DateTime.Now.Day} / {DateTime.Now.Month} / {DateTime.Now.Year - 100}";
            string MaximumDate = $"{DateTime.Now.Day} / {DateTime.Now.Month} / {DateTime.Now.Year - 18}";
            DateTime @MaxDate = DateTime.ParseExact(MaximumDate, "d / M / yyyy", null);
            DateTime @MinDate = DateTime.ParseExact(MinimumDate, "d / M / yyyy", null);
            dateTimePicker1.MaxDate = @MaxDate;
            dateTimePicker1.MinDate = @MinDate;
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            FillComboCountries();
            preCustomUI();
            setDate();
        }

        private void linkProfileImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
            openFileDialog.Multiselect = false;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;

                string DestinationFolder = "C:/DVLD-People-Images";

                string newFileName = Guid.NewGuid().ToString() + Path.GetExtension(filePath);

                string DestinationPath = Path.Combine(DestinationFolder, newFileName);

                File.Copy(filePath, DestinationPath, true);

                using (var stream = new MemoryStream(File.ReadAllBytes(DestinationPath)))
                {
                    pictureProfile.Image = Image.FromStream(stream);
                }
                pictureProfile.Tag = DestinationPath;

                linkRemoveImage.Enabled = true;
                linkRemoveImage.Visible = true;
                linkProfileImage.Visible = false;
                linkProfileImage.Enabled = false;
            }
        }

        private void linkRemoveImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            string path = pictureProfile.Tag as string;


            if (pictureProfile.Image != null)
            {
                pictureProfile.Image.Dispose();
                pictureProfile.Image = null;
            }

            if (!String.IsNullOrEmpty(path) && File.Exists(path))
            {

                _isImageMarkedForDeletion = true;
                _imageToDeletePath = path;

            }

            if (radioMale.Checked)
            {
                pictureProfile.Image = Resources.user__22_;
            }
            else
            {
                pictureProfile.Image = Resources.admin_female;
            }

            linkRemoveImage.Enabled = false;
            linkRemoveImage.Visible = false;
            linkProfileImage.Visible = true;
            linkProfileImage.Enabled = true;
        }


        /*  =======  Validation ======  */

        private void textFirstName_Validating(object sender, CancelEventArgs e)
        {
            if(String.IsNullOrEmpty(textFirstName.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(textFirstName, "this field is required!");
            }
            else
            {
                errorProvider1.SetError(textFirstName, "");
            }
        }

        private void textLastName_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(textLastName.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(textLastName, "this field is required!");
            }
            else
            {
                errorProvider1.SetError(textLastName, "");
            }
        }

        private void textNationalNo_Validating(object sender, CancelEventArgs e)
        {
            string text = textNationalNo.Text;

            if (!System.Text.RegularExpressions.Regex.IsMatch(text, @"^[A-Za-z]{2}\d{3,6}$"))
            {
                e.Cancel = true;
                errorProvider1.SetError(textNationalNo, "it must contain 2 letters followed by 3 to 6 numbers!");
            }
            else if(people.checkNationalNoExists(text))
            {
                e.Cancel = true;
                errorProvider1.SetError(textNationalNo, "This National No Already Exists");
            }
            else
            {
                errorProvider1.SetError(textNationalNo, "");
            }
        }

        private void textPhone_Validating(object sender, CancelEventArgs e)
        {
            string text = textPhone.Text;

            if (!System.Text.RegularExpressions.Regex.IsMatch(text, @"^\d{10}$"))
            {
                e.Cancel = true;
                errorProvider1.SetError(textPhone, "it must contain 10 numbers!");
            }
            else
            {
                errorProvider1.SetError(textPhone, "");
            }
        }

        private void textAddress_Validating(object sender, CancelEventArgs e)
        {
            string text = textAddress.Text;

            if (!System.Text.RegularExpressions.Regex.IsMatch(text, @"^[A-Za-z]{5,}$"))
            {
                e.Cancel = true;
                errorProvider1.SetError(textAddress, "it must contain 5 letters minimum !");
            }
            else
            {
                errorProvider1.SetError(textAddress, "");
            }
        }

        private void textEmail_Validating(object sender, CancelEventArgs e)
        {
            string text = textEmail.Text;

            if (!System.Text.RegularExpressions.Regex.IsMatch(text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$") && text != "")
            {
                e.Cancel = true;
                errorProvider1.SetError(textEmail, "Invalid email format!");
            }
            else
            {
                errorProvider1.SetError(textEmail, "");
            }
        }




        /* ======== Saving  ======== */

        private void DeletePictureFromFile()
        {
            if (_isImageMarkedForDeletion && !string.IsNullOrEmpty(_imageToDeletePath))
            {
                if (File.Exists(_imageToDeletePath))
                {
                    File.Delete(_imageToDeletePath);
                    pictureProfile.Tag = null;
                }

                _isImageMarkedForDeletion = false;
                _imageToDeletePath = null;
            }
        }

        private void fillPerson()
        {
            Person.NationalNo = textNationalNo.Text;
            Person.FirstName = textFirstName.Text;
            Person.SecondName = textSecondName.Text;
            if (String.IsNullOrEmpty(textThirdName.Text))
                Person.ThirdName = "";
            else
                Person.ThirdName = textThirdName.Text;
            Person.LastName = textLastName.Text;
            Person.DateOfBirth = dateTimePicker1.Value;
            Person.Phone = textPhone.Text;
            if(String.IsNullOrEmpty(textEmail.Text))
                Person.Email = "";
            else 
                Person.Email = textEmail.Text;
            Person.Address = textAddress.Text;
            if (radioMale.Checked)
                Person.Gender = "Male";
            else
                Person.Gender = "Female";
            Person.Country.CountryName = comboCountries.Text;

            if (pictureProfile.Tag != null && !String.IsNullOrEmpty(pictureProfile.Tag.ToString()))
            {
                Person.ImagePath = pictureProfile.Tag.ToString();
            }
            else
                Person.ImagePath = ""; 
        }

        private void BTNsave_Click(object sender, EventArgs e)
        {
            DeletePictureFromFile();

            fillPerson();

            if (Person.Save())
            {
                MessageBox.Show("The Operation Has Been Done Successfully", "Information", MessageBoxButtons.OK);

                if(PersonID == -1)
                {
                    LBpersonID.Text = Person.PersonID.ToString();
                    personIDAdded?.Invoke(Person.PersonID);
                }

                foreach (Form frm in Application.OpenForms)
                {
                    if (frm is ManagePeopleForm peopleListForm)
                    {
                        peopleListForm.FillDataGridWithPeople();
                        break;
                    }
                    if(frm is AddNewUserForm editFromUser)
                    {
                        editFromUser.reloadPersonCard();
                        break;
                    }
                }
                BTNsave.Enabled = false; 
            }
            else
                MessageBox.Show("Operation has been Failed !!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            
        } 
    }
}
