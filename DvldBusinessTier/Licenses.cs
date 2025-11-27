using DvldDataTier;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvldBusinessTier
{
    public class Licenses
    {
        
        public enum enReason {FirstTime = 1, Renew = 2, ReplacementforDamaged = 3, ReplacementforLost = 4}

        public enReason Reason;
        public int LicenseID { get; set; }
        public int ApplicationID { get; set; }
        public int DriverID {get; set;}
        public int LicenseClass {get; set;}
        public DateTime IssueDate {get; set;} 
        public DateTime ExpirationDate {get; set;}
        public string Notes {get; set;}
        public decimal PaidFees {get; set;}
        public bool IsActive {get; set;}
        public int IssueReason {get; set;}
        public int CreatedByUserID {get; set;}

        public Licenses() { }

        public Licenses(int ApplicationID, int DriverID, int LicenseClass, DateTime IssueDate, string Notes,
            bool IsActive, int IssueReason, int CreatedByUserID)
        {
            this.LicenseID = -1; 
            this.ApplicationID = ApplicationID;
            this.DriverID = DriverID;
            this.LicenseClass = LicenseClass;
            this.IssueDate = IssueDate;
            this.Notes = Notes;
            this.IsActive = IsActive;
            this.IssueReason = IssueReason;
            this.CreatedByUserID = CreatedByUserID;
        }

        public void FillExpirationDateOfLicense()
        {
            DateTime Date = IssueDate;
            byte Years = dataLicense.getValiditylengthOfLicenseClass(this.LicenseClass);
            this.ExpirationDate = Date.AddYears(Years);
        }

        static public decimal getLicenseFees(int LicenseID)
        {
            return dataLicense.getLicenseClassFees(LicenseID);
        }

        static public bool unActiveLicense(int LicenseID)
        {
            if (dataLicense.updateIsActiveOfLicense(LicenseID, false))
                return true;

            return false;
        }

        static public bool isLicenseDetained(int LicenseID)
        {
            return dataLicense.isLicenseDetained(LicenseID);
        }

        static public bool getDetainDetails(int LicenseID, ref int DetainID, ref DateTime DetainDate, ref Decimal FineFees)
        {
            dataLicense.getDetainDetails(LicenseID, ref DetainID, ref DetainDate, ref FineFees);
            if (DetainID != -1)
                return true;
            return false; 
        }

        static public DataTable getListDetainedLicenses()
        {
            return dataLicense.getListDetainedLicenses(); 
        }


        static public DataTable FillWithFiltredData(string text , string ComboText)
        {
            text = text == "yes" ? "1" : text == "no" ? "0" : text;
            return dataLicense.getFiltredData(text, ComboText);
        }
        private void FillPaidFees()
        {
            this.PaidFees = dataLicense.getLicenseFees(this.ApplicationID);
        }

        static public int getLicenseClassIdByLdlID(int LdlID)
        {
            return dataLicense.getLicenseClassIdByLdlID(LdlID);
        }

        private void fillExpirationDate()
        {
            int Years = dataLicense.getLicenseYears(this.ApplicationID);
            DateTime Date = this.IssueDate.AddYears(Years);
            this.ExpirationDate = Date; 
        }

        static public byte getValiditylengthOfLicense(int LicenseID)
        {
            return dataLicense.getValiditylengthOfLicense(LicenseID);
        }

        public bool AddFirstTimeLicense()
        {
            fillExpirationDate();
            FillPaidFees();
            this.LicenseID = dataLicense.insertLicense(ApplicationID, DriverID, LicenseClass, IssueDate, ExpirationDate, Notes, PaidFees, IsActive, IssueReason, CreatedByUserID);
            return (LicenseID != -1);
        }

        public bool AddLicense()
        {
            this.LicenseID = dataLicense.insertLicense(ApplicationID, DriverID, LicenseClass, IssueDate, ExpirationDate, Notes, PaidFees, IsActive, IssueReason, CreatedByUserID);
            return (LicenseID != -1);
        }

        static public void LicenseDetails(int ApplicationID, ref int LicenseID, ref int DriverID, ref DateTime IssueDate, ref DateTime ExpirationDate,
           ref string Notes, ref byte IssueReason, ref bool IsActive, ref string ClassName, ref string FullName, ref string NationalNo, ref byte Gender,
           ref DateTime BirthDate, ref string ImagePath)
        {
            dataLicense.GetLicenseDetails(ApplicationID, ref LicenseID, ref DriverID, ref IssueDate, ref ExpirationDate,
           ref Notes, ref IssueReason, ref IsActive, ref ClassName, ref FullName, ref NationalNo, ref Gender,
           ref BirthDate, ref ImagePath);
        }


        static public DataTable getLocalLicenseHistory(int PersonID)
        {
            return dataLicense.getLocalLicenseHistory(PersonID);
        }

        static public DataTable getInterLicenseHistory(int personID)
        {
            return dataLicense.getInterLicenseHistory(personID);

        }

        static public int getAppIDByLicenseID(int LicenseID)
        {
            return dataLicense.getAppIDByLicenseID(LicenseID);
        }

        static public bool isinterLicenseExists(int LicenseID, ref DateTime ExpirationDate)
        {
            return dataLicense.isinterLicenseExists(LicenseID, ref ExpirationDate);
        }

        static public bool isLicenseExists(int LicenseID, ref DateTime ExpirationDate)
        {
            return dataLicense.isLicenseExists(LicenseID, ref ExpirationDate);
        }

        static public bool isLicenseExists(int LicenseID)
        {
            return dataLicense.isLicenseExists(LicenseID);
        }

        static public int insertinterLicense(int AppID, DateTime ExpirationDate, DateTime IssueDate, int CreatedByUserID)
        {
            return dataLicense.insertinterLicense(AppID, ExpirationDate, IssueDate, CreatedByUserID);
        }

        static public bool isinterLicenseActive(int LicenseID)
        {
            return dataLicense.isinterLicenseActive(LicenseID);
        }
        static public bool isLicenseActive(int LicenseID)
        {
            return dataLicense.isLicenseActive(LicenseID);
        }

        static public int getLicenseClassByLicenseID(int LicenseID)
        {
            return dataLicense.getLicenseClassByLicenseID(LicenseID);
        }

        static public bool updateIsActiveOfLicense(int LicenseID, bool value)
        {
            if(isLicenseActive(LicenseID))
            {
                return dataLicense.updateIsActiveOfLicense(LicenseID, value);  
            }
            return true;
        }

        static public bool DetainLicense(ref int detainID, int LicenseID, string DetainDate, string FineFees, int CreatedByUserID)
        {
            bool IsReleased = false;
            decimal Fees = Convert.ToDecimal(FineFees);
            DateTime Date = Convert.ToDateTime(DetainDate);
            detainID = dataLicense.DetainLicense(LicenseID, Date, Fees, CreatedByUserID, IsReleased);
            if (detainID != -1)
                return true;
            return false; 
        }

        static public bool ReleaseDetainedLicense(int LicenseID ,DateTime ReleaseDate ,  int UserID , int AppID)
        {
            bool IsReleased = true;
            int Effected = dataLicense.ReleaseDetainedLicense(LicenseID, IsReleased, ReleaseDate, UserID, AppID); 
            if(Effected > 0)
                return true;
            return false;
        }
    }
}
