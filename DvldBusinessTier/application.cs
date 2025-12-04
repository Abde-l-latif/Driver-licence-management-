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

        enum enMode { addMode , updateMode }

        /* ================== */

        public enAppTypes ApplicationType;

        public enAppStatus Status; 

        private enMode Mode;

        public int ApplicationID { get; set; }

        public int ApplicantPersonID { get; set; }

        public DateTime ApplicationDate { get; set; }

        public int ApplicationTypeID { get; set; }

        public int ApplicationStatus { get; set; }

        public DateTime LastStatusDate { get; set; }

        public Decimal PaidFees { get; set; }

        public int CreatedByUserID {get ; set; }

        public application()
        {
            Mode = enMode.addMode;
            ApplicationID = -1;
            ApplicantPersonID = -1;
            ApplicationDate = DateTime.Now;
            ApplicationTypeID = -1;
            ApplicationStatus = -1;
            LastStatusDate = DateTime.Now;
            PaidFees = 0;
            CreatedByUserID = -1;
        }

        public application(int AppID)
        {
            Mode = enMode.updateMode;
            ApplicationID = AppID;
        }

        public decimal getApplicationFee()
        {
            int id = Convert.ToInt32(ApplicationType);
            PaidFees = dataApplication.getApplicationFee(id);
            return PaidFees;
        }
        static public DataTable getAll_LDL_ApplicationPeople()
        {
            return dataApplication.getAll_LDL_ApplicationPeople();
        }

        static public DataTable getFiltred_LDL_ApplicationPeople(string text, string Filter)
        {
            return dataApplication.getFiltred_LDL_ApplicationPeople(text, Filter);
        }

        static public DataTable getAllLicenseClasses()
        {
            return dataApplication.getAllLicenseClasses();
        }

        static public decimal getApplicationFee(int id)
        {
            return dataApplication.getApplicationFee(id);
        }

        private bool AddApplication()
        {
            this.ApplicationID = dataApplication.insertApplication(this.ApplicantPersonID , this.ApplicationDate , this.ApplicationTypeID , this.ApplicationStatus
                , this.LastStatusDate , this.PaidFees , this.CreatedByUserID);
            return (this.ApplicationID != -1);
        }

        private void updateApplication()
        {
            dataApplication.updateApplicationStatus(this.ApplicationID, this.ApplicationStatus); 
        }

        static public void GetLDLpersonDetails(int id, ref string AppliedLicense, ref int passedTest)
        {
             dataApplication.GetLDLpersonDetails(id, ref AppliedLicense, ref passedTest);
        }

        static public int getAppIdByLDLid(int LDLid)
        {
            return dataApplication.getAppIdByLDLid(LDLid); 
        }

        static public void getApplicationDetails(int ApplicationID , ref string status , ref string type , ref string applicant , ref string createdBy,
                ref decimal fees , ref DateTime date , ref DateTime statusDate)
        {
            dataApplication.getApplicationDetails(ApplicationID, ref status, ref type, ref applicant, ref createdBy,
                ref fees, ref date, ref statusDate); 
        }

        static public bool insert_LDL_Application(int applicationID, int licenseClassID , ref int L_D_Lid)
        {
            return dataApplication.insert_LDL_Application(applicationID , licenseClassID, ref L_D_Lid);
        }

        static public bool isPersonAppalreadyExists(string ClassName, string NationalNo)
        {
            return dataApplication.isPersonAppalreadyExists(ClassName, NationalNo);
        }

        static public bool DeleteLdlApp(int id)
        {
            return dataApplication.Delete_LDL_App(id);
        }

        static public bool UpdateApplicationDate(int id , DateTime ApplicationDate)
        {
            return dataApplication.updateApplicationDate(id , ApplicationDate) > 0 ? true : false;
        }

        static public DataTable getAll_InterDL_ApplicationPeople()
        {
            return dataApplication.getAll_InterDL_ApplicationPeople();
        }

        static public DataTable getFiltredInterDlApp(string text , string Filter)
        {
            return dataApplication.getFiltredInterDLapp(text , Filter); 
        }

        static public int getPersonIDByAppID(int AppID)
        {
            return dataApplication.getPersonIDByAppID(AppID);
        }

        public bool Save(int applicationStatus = 1)
        {

            if(Mode == enMode.addMode)
            {
                return AddApplication(); 
            } else if (Mode == enMode.updateMode)
            {
                this.ApplicationStatus = applicationStatus; 
                updateApplication(); 
                return true;
            }
            return false; 
        }

    }
}
