using System;
using System.Data;
using DvldDataTier;

namespace DvldBusinessTier
{
    public class people
    {
        enum enMode { addMode , updateMode };
        enMode Mode;

        public int PersonID { get; set; }
        public string NationalNo { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public Countries Country { get; set; }
        public string ImagePath { get; set; }

        public people()
        {
            PersonID = -1;
            NationalNo = "";
            FirstName = "";
            SecondName = "";
            ThirdName = "";
            LastName = "";
            DateOfBirth = DateTime.Now;
            Gender = "";
            Address = "";
            Phone = "";
            Email = "";
            Country = new Countries();
            ImagePath = "";
            Mode = enMode.addMode;
        }
        public people(int PersonID, string NationalNo, string FirstName, string SecondName, string ThirdName,
            string LastName, DateTime DateOfBirth, string Gender, string Address, string Phone, string Email,
            string Country, string ImagePath)
        {
            this.PersonID = PersonID;
            this.NationalNo = NationalNo;
            this.FirstName = FirstName;
            this.SecondName = SecondName;
            this.ThirdName = ThirdName;
            this.LastName = LastName;
            this.DateOfBirth = DateOfBirth;
            this.Gender = Gender;
            this.Address = Address;
            this.Phone = Phone;
            this.Email = Email;
            this.Country = Countries.FindCountryByName(Country);
            this.ImagePath = ImagePath;
            Mode = enMode.updateMode;
        }

        static public DataTable getAllPeople()
        {
            return dataPeople.getAllPeople();
        }

        static public bool checkNationalNoExists(string text)
        {
            return dataPeople.checkNationalNoExists(text); 
        }

        static public bool checkPersonIdExists(string text)
        {
            return dataPeople.checkPersonIdExists(text);    
        }

        static public people Find(int PersonID)
        {
            string NationalNo = "", FirstName = "", SecondName = "", ThirdName = "", LastName = "";
            DateTime DateOfBirth = DateTime.Now;
            string Gender = "", Address = "", Phone = "", Email = "", Country = "", ImagePath = "";


            if(dataPeople.FindPersonByID(PersonID ,ref NationalNo ,ref FirstName ,ref SecondName ,ref ThirdName ,ref LastName ,ref DateOfBirth,ref Gender,
            ref Address ,ref Phone , ref Email , ref Country , ref ImagePath))
            {
                return new people(PersonID, NationalNo, FirstName, SecondName, ThirdName, LastName, DateOfBirth, Gender,
                       Address, Phone, Email, Country, ImagePath);
            }

            return null; 
        }

        static public people Find(string nationalNo)
        {
            int PersonID = -1;
            string FirstName = "", SecondName = "", ThirdName = "", LastName = "";
            DateTime DateOfBirth = DateTime.Now;
            string Gender = "", Address = "", Phone = "", Email = "", Country = "", ImagePath = "";


            if (dataPeople.FindPersonByNationalNo(ref PersonID, nationalNo, ref FirstName, ref SecondName, ref ThirdName, ref LastName, ref DateOfBirth, ref Gender,
            ref Address, ref Phone, ref Email, ref Country, ref ImagePath))
            {
                return new people(PersonID, nationalNo, FirstName, SecondName, ThirdName, LastName, DateOfBirth, Gender,
                       Address, Phone, Email, Country, ImagePath);
            }

            return null;
        }


        bool _AddPerson()
        {
            this.Country = Countries.FindCountryByName(Country.CountryName);
            this.PersonID = dataPeople.insertPerson(this.NationalNo , this.FirstName , this.SecondName, this.ThirdName , this.LastName,
                this.DateOfBirth , this.Gender, this.Address , this.Phone , this.Email , this.Country.CountryID , this.ImagePath);
            return (this.PersonID != -1);
        }

        bool _UpdatePerson()
        {
            return dataPeople.UpdatePerson(this.PersonID , this.NationalNo, this.FirstName, this.SecondName, this.ThirdName,
            this.LastName, this.DateOfBirth, this.Gender, this.Address, this.Phone, this.Email,
            this.Country.CountryID, this.ImagePath); 
        }

        static public bool DeletePerson(int PersonID)
        {
            return dataPeople.deletePerson(PersonID);
        }

        static public int getPersonIDbyNationalNo(string NationalNo)
        {
            return dataPeople.getPersonIDbyNationalNo(NationalNo); 
        }

        public bool Save()
        {
            if(Mode == enMode.addMode)
            {
                if (_AddPerson())
                {
                    Mode = enMode.updateMode;
                    return true;
                }
                else
                    return false;
            }
            else if(Mode == enMode.updateMode)
            {
                return _UpdatePerson();
            }

            return false; 
        }


    }
}
