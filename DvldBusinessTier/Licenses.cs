using DvldDataTier;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvldBusinessTier
{
    public class Licenses
    {
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

        private void FillPaidFees()
        {
            this.PaidFees = dataLicense.getLicenseFees(this.ApplicationID);
        }

        public bool AddLicense()
        {
            fillExpirationDate();
            FillPaidFees();
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


    }
}
