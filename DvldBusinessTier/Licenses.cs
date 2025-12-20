using DvldDataTier;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DvldBusinessTier.application;

namespace DvldBusinessTier
{
    public class Licenses
    {
        
        public enum enReason {FirstTime = 1, Renew = 2, ReplacementforDamaged = 3, ReplacementforLost = 4}

        public enReason Reason;

        public int LicenseID { get; set; }
        public int ApplicationID { get; set; }

        public application App;
        public int DriverID {get; set;}
        public int Licenseclass {get; set;}

        public LicenseClass License_class; 

        public DateTime IssueDate {get; set;} 
        public DateTime ExpirationDate {get; set;}
        public string Notes {get; set;}
        public decimal PaidFees {get; set;}
        public bool IsActive {get; set;}
        public byte IssueReason {get; set;}
        public int CreatedByUserID {get; set;}

        public Licenses() { }

        public Licenses(int LicenseID, int ApplicationID, int DriverID, int Licenseclass, DateTime IssueDate, DateTime ExpirationDate, string Notes, decimal PaidFees,
            bool IsActive, byte IssueReason, int CreatedByUserID)
        {
            this.LicenseID = LicenseID; 

            this.ApplicationID = ApplicationID;
            App = application.FindBaseApplication(ApplicationID);

            this.DriverID = DriverID;

            this.Licenseclass = Licenseclass;
            License_class = LicenseClass.Find(this.Licenseclass);

            this.PaidFees = PaidFees;
            this.ExpirationDate = ExpirationDate;
            this.IssueDate = IssueDate;
            this.Notes = Notes;
            this.IsActive = IsActive;
            this.IssueReason = IssueReason;
            this.CreatedByUserID = CreatedByUserID;
        }

        public static Licenses Find(int LicenseID)
        {
            int ApplicationID = -1; int DriverID = -1; int LicenseClass = -1;
            DateTime IssueDate = DateTime.Now; DateTime ExpirationDate = DateTime.Now;
            string Notes = "";
            decimal PaidFees = 0; bool IsActive = true; int CreatedByUserID = 1;
            byte IssueReason = 1;

            if (dataLicense.GetLicenseInfoByID(LicenseID, ref ApplicationID, ref DriverID, ref LicenseClass,
            ref IssueDate, ref ExpirationDate, ref Notes,
            ref PaidFees, ref IsActive, ref IssueReason, ref CreatedByUserID))

                return new Licenses(LicenseID, ApplicationID, DriverID, LicenseClass,
                                     IssueDate, ExpirationDate, Notes,
                                     PaidFees, IsActive, IssueReason, CreatedByUserID);
            else
                return null;

        }

        static public int getLicenseIDByLdlID(int LdlId)
        {
            return dataLicense.getLicenseIDByLdlID(LdlId);
        }


        public bool isExpired()
        {
            return (ExpirationDate <  DateTime.Now);
        }

        public Licenses renewLicense(string Note, int userID)
        {
            application app = new application();
            app.ApplicantPersonID = App.Person.PersonID;
            app.ApplicationTypeID = application.enAppTypes.renewLicense;
            app.CreatedByUserID = userID;
            app.PaidFees = ApplicationType.Find((int)enReason.Renew).ApplicationFees;

            if (!app.Save())
                return null;

            Licenses license = new Licenses();

            license.Notes = Note;
            license.CreatedByUserID = userID;
            license.ApplicationID = app.ApplicationID;
            license.App = application.FindBaseApplication(license.ApplicationID);
            license.DriverID = this.DriverID;
            license.Licenseclass = this.Licenseclass;
            license.License_class = LicenseClass.Find(license.Licenseclass);
            license.IsActive = true; 
            license.IssueReason = (byte)enReason.Renew;
            license.IssueDate = DateTime.Now;
            license.ExpirationDate = DateTime.Now.AddYears(license.License_class.DefaultValidityLength);
            license.PaidFees = this.PaidFees;

            unActiveLicense(this.LicenseID);

            if (!license.AddLicense())
                return null;



            return license;
        }

        public Licenses ReplaceLicense(enReason issueReason ,  int userID)
        {
            application app = new application();

            if (issueReason == enReason.ReplacementforLost)
                app.ApplicationTypeID = application.enAppTypes.replaceLostLicense;
            else if (issueReason == enReason.ReplacementforDamaged)
                app.ApplicationTypeID = application.enAppTypes.replaceDamagedLicense;

            app.ApplicantPersonID = App.Person.PersonID;
            app.CreatedByUserID = userID;
            app.PaidFees = ApplicationType.Find((int)enReason.Renew).ApplicationFees;

            if (!app.Save())
                return null;

            Licenses license = new Licenses();

            license.Notes = this.Notes;
            license.CreatedByUserID = userID;
            license.ApplicationID = app.ApplicationID;
            license.App = application.FindBaseApplication(license.ApplicationID);
            license.DriverID = this.DriverID;
            license.Licenseclass = this.Licenseclass;
            license.License_class = LicenseClass.Find(license.Licenseclass);
            license.IsActive = true;
            license.IssueReason = (byte)issueReason;
            license.IssueDate = DateTime.Now;
            license.ExpirationDate = DateTime.Now.AddYears(license.License_class.DefaultValidityLength);
            license.PaidFees = this.PaidFees;

            unActiveLicense(this.LicenseID);

            if (!license.AddLicense())
                return null;



            return license;
        }

        static public bool IsLicenseExistByPersonID(int personID , int licenseClassID)
        {
            return (dataLicense.GetActiveLicenseIDByPersonID(personID, licenseClassID) != -1);
        }

        public void FillExpirationDateOfLicense()
        {
            DateTime Date = IssueDate;
            byte Years = dataLicense.getValiditylengthOfLicenseClass(this.Licenseclass);
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

        private void fillExpirationDate()
        {
            int Years = dataLicense.getLicenseYears(this.ApplicationID);
            DateTime Date = this.IssueDate.AddYears(Years);
            this.ExpirationDate = Date; 
        }

        public bool AddFirstTimeLicense()
        {
            fillExpirationDate();
            FillPaidFees();
            this.LicenseID = dataLicense.insertLicense(ApplicationID, DriverID, this.Licenseclass, IssueDate, ExpirationDate, Notes, PaidFees, IsActive, IssueReason, CreatedByUserID);
            return (LicenseID != -1);
        }

        public bool AddLicense()
        {
            this.LicenseID = dataLicense.insertLicense(ApplicationID, DriverID, this.Licenseclass, IssueDate, ExpirationDate, Notes, PaidFees, IsActive, IssueReason, CreatedByUserID);
            return (LicenseID != -1);
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
