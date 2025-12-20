using DvldDataTier;
using System;
using System.Data;



namespace DvldBusinessTier
{
    public class application
    {   
        /* ENUMS */
        public enum enAppTypes { newLocalLicense = 1, renewLicense = 2, replaceLostLicense = 3, replaceDamagedLicense = 4, releaseAndDetainedLicense = 5, 
            newInternationalLicense = 6, retakeTest = 7}

        public enum enAppStatus { New = 1, Cancelled = 2, Completed = 3 }

        public enum enMode { addMode , updateMode }


        /* ================== */


        public enMode Mode;

        public int ApplicationID { get; set; }

        public int ApplicantPersonID { get; set; }

        public people Person;

        public DateTime ApplicationDate { get; set; }

        public enAppTypes ApplicationTypeID { get; set; }

        public ApplicationType AppType; 

        public enAppStatus ApplicationStatus { get; set; }

        public DateTime LastStatusDate { get; set; }

        public Decimal PaidFees { get; set; }

        public int CreatedByUserID {get ; set; }

        public Users user;

        public application()
        {
            Mode = enMode.addMode;
            ApplicationID = -1;
            ApplicantPersonID = -1;
            ApplicationDate = DateTime.Now;
            ApplicationTypeID = enAppTypes.newLocalLicense;
            ApplicationStatus = enAppStatus.New;
            LastStatusDate = DateTime.Now;
            PaidFees = 0;
            CreatedByUserID = -1;
        }

        public application(int AppID, int personID , DateTime AppDate , enAppTypes AppType , enAppStatus AppStatus , DateTime LastStatusDate , Decimal fees , int CreatedByUser)
        {
            Mode = enMode.updateMode;
            ApplicationID = AppID;
            ApplicantPersonID = personID;
            Person = people.Find(personID);
            ApplicationDate = AppDate;
            ApplicationTypeID = AppType;
            this.AppType = ApplicationType.Find((int)AppType);
            ApplicationStatus = AppStatus;
            this.LastStatusDate = LastStatusDate;
            PaidFees = fees;
            this.CreatedByUserID = CreatedByUser;
            user = Users.getUserByUserID(CreatedByUser);
        }

        private bool AddApplication()
        {
            this.ApplicationID = dataApplication.insertApplication(this.ApplicantPersonID , this.ApplicationDate , (int)this.ApplicationTypeID , (byte)this.ApplicationStatus
                , this.LastStatusDate , this.PaidFees , this.CreatedByUserID);
            return (this.ApplicationID != -1);
        }

        private bool updateApplicationInfo()
        {
            return dataApplication.updateApplication(this.ApplicationID, this.ApplicationDate , (int)this.ApplicationTypeID, (byte)this.ApplicationStatus
                , this.LastStatusDate, this.PaidFees, this.CreatedByUserID); 
        }

        public bool Save(int applicationStatus = 1)
        {

            if(Mode == enMode.addMode)
            {
                return AddApplication(); 
            } else if (Mode == enMode.updateMode)
            {
                return updateApplicationInfo(); 
            }
            return false; 
        }

        public static application FindBaseApplication(int ApplicationID)
        {
            int ApplicantPersonID = -1;
            DateTime ApplicationDate = DateTime.Now; int ApplicationTypeID = -1;
            byte ApplicationStatus = 1; DateTime LastStatusDate = DateTime.Now;
            decimal PaidFees = 0; int CreatedByUserID = -1;

            bool IsFound = dataApplication.GetApplicationInfoByID
                                (
                                    ApplicationID, ref ApplicantPersonID,
                                    ref ApplicationDate, ref ApplicationTypeID,
                                    ref ApplicationStatus, ref LastStatusDate,
                                    ref PaidFees, ref CreatedByUserID
                                );

            if (IsFound)
                return new application(ApplicationID, ApplicantPersonID,
                                     ApplicationDate, (enAppTypes)ApplicationTypeID,
                                    (enAppStatus)ApplicationStatus, LastStatusDate,
                                     PaidFees, CreatedByUserID);
            else
                return null;
        }

        public bool Cancel()
        {
            return dataApplication.UpdateStatus(ApplicationID, (int)enAppStatus.Cancelled);
        }

        public bool SetComplete()

        {
            return dataApplication.UpdateStatus(ApplicationID, (int)enAppStatus.Completed);
        }

        public bool Delete()
        {
            return dataApplication.DeleteApplication(this.ApplicationID);
        }

        public static bool IsApplicationExist(int ApplicationID)
        {
            return dataApplication.IsApplicationExist(ApplicationID);
        }

        public static bool DoesPersonHaveActiveApplication(int PersonID, int ApplicationTypeID)
        {
            return dataApplication.DoesPersonHaveActiveApplication(PersonID, ApplicationTypeID);
        }

        public bool DoesPersonHaveActiveApplication(int ApplicationTypeID)
        {
            return DoesPersonHaveActiveApplication(this.ApplicantPersonID, ApplicationTypeID);
        }

        public static int GetActiveApplicationID(int PersonID, enAppTypes ApplicationTypeID)
        {
            return dataApplication.GetActiveApplicationID(PersonID, (int)ApplicationTypeID);
        }

        public int GetActiveApplicationID(enAppTypes ApplicationTypeID)
        {
            return GetActiveApplicationID(this.ApplicantPersonID, ApplicationTypeID);
        }

        public static int GetActiveApplicationIDForLicenseClass(int PersonID, enAppTypes ApplicationTypeID, int LicenseClassID)
        {
            return dataApplication.GetActiveApplicationIDForLicenseClass(PersonID, (int)ApplicationTypeID, LicenseClassID);
        }

        static public decimal getApplicationFee(int id)
        {
            return dataApplication.getApplicationFee(id);
        }













        static public DataTable getAll_InterDL_ApplicationPeople()
        {
            return dataApplication.getAll_InterDL_ApplicationPeople();
        }

        static public DataTable getFiltredInterDlApp(string text , string Filter)
        {
            return dataApplication.getFiltredInterDLapp(text , Filter); 
        }

    }
}
