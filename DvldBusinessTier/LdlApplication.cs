using DvldDataTier;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvldBusinessTier
{
    public class LdlApplication : application
    {

        enum enMode { AddMode , UpdateMode };

        enMode _Mode;

        public int LocalDrivingLicenseApplicationID { get; set; }

        public int LicenseClassID { get; set; }

        public LicenseClass License_Class { get; set; }

        public LdlApplication()
        { 
            _Mode = enMode.AddMode;
            this.LocalDrivingLicenseApplicationID = -1;
            LicenseClassID = -1;
        }

        public LdlApplication(int LocalDrivingLicenseApplicationID, int ApplicationID, int ApplicantPersonID,
            DateTime ApplicationDate, enAppTypes ApplicationTypeID,
             enAppStatus ApplicationStatus, DateTime LastStatusDate,
             decimal PaidFees, int CreatedByUserID, int LicenseClassID)
        {

            this.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID; ;
            this.ApplicationID = ApplicationID;
            this.ApplicantPersonID = ApplicantPersonID;
            this.ApplicationDate = ApplicationDate;
            this.ApplicationTypeID = ApplicationTypeID;
            this.ApplicationStatus = ApplicationStatus;
            this.LastStatusDate = LastStatusDate;
            this.PaidFees = PaidFees;
            this.CreatedByUserID = CreatedByUserID;
            this.LicenseClassID = LicenseClassID;
            this.License_Class = LicenseClass.Find(LicenseClassID);
            _Mode = enMode.UpdateMode;

        }

        public int IssueDrivingLicenseFirstTime(string Note, int userID)
        {
            if(!Driver.isDriverExists(ApplicantPersonID))
            {
                Driver DRIVER = new Driver(ApplicantPersonID, userID);
                DRIVER.addDriver(); 
            }

            Licenses License = new Licenses();
            License.ApplicationID = this.ApplicationID;
            License.DriverID = dataDriver.getDriverIdByPersonID(this.ApplicantPersonID);
            License.Licenseclass = this.LicenseClassID;
            License.IssueDate = DateTime.Now;
            License.Notes = Note;
            License.IsActive = true;
            License.IssueReason = (int)application.enAppTypes.newLocalLicense;         
            License.CreatedByUserID = userID;

            if (License.AddFirstTimeLicense())
            {
                this.SetComplete();
                return License.LicenseID;
            }
            else
                return -1;
        }

        private bool _AddNewLocalDrivingLicenseApplication()
        {


            this.LocalDrivingLicenseApplicationID = dataLdlApplication.insert_LDL_Application(this.ApplicationID, this.LicenseClassID);

            return (this.LocalDrivingLicenseApplicationID != -1);
        }

        private bool _UpdateLocalDrivingLicenseApplication()
        {

            return dataLdlApplication.update_LDL_Application
                (
                this.LocalDrivingLicenseApplicationID, this.ApplicationID, this.LicenseClassID);

        }

        public static LdlApplication FindByLocalDrivingAppLicenseID(int LocalDrivingLicenseApplicationID)
        {

            int ApplicationID = -1, LicenseClassID = -1;

            bool IsFound = dataLdlApplication.GetLdlApplicationInfoByID
                (LocalDrivingLicenseApplicationID, ref ApplicationID, ref LicenseClassID);


            if (IsFound)
            {
                application Application = application.FindBaseApplication(ApplicationID);

        
                return new LdlApplication(
                    LocalDrivingLicenseApplicationID, Application.ApplicationID,
                    Application.ApplicantPersonID,
                                     Application.ApplicationDate, Application.ApplicationTypeID,
                                     Application.ApplicationStatus, Application.LastStatusDate,
                                     Application.PaidFees, Application.CreatedByUserID, LicenseClassID);
            }
            else
                return null;

        }

        public static LdlApplication FindByApplicationID(int ApplicationID)
        {

            int LocalDrivingLicenseApplicationID = -1, LicenseClassID = -1;

            bool IsFound = dataLdlApplication.GetLdlApplicationInfoByApplicationID
                (ApplicationID, ref LocalDrivingLicenseApplicationID, ref LicenseClassID);


            if (IsFound)
            {
 
                application Application = application.FindBaseApplication(ApplicationID);

      
                return new LdlApplication(
                     LocalDrivingLicenseApplicationID, Application.ApplicationID,
                     Application.ApplicantPersonID,
                     Application.ApplicationDate, Application.ApplicationTypeID,
                     Application.ApplicationStatus, Application.LastStatusDate,
                     Application.PaidFees, Application.CreatedByUserID, LicenseClassID);
            }
            else
                return null;

        }

        public bool Save()
        {

            base.Mode = (application.enMode)_Mode;

            if (!base.Save())
                return false;


            switch (_Mode)
            {
                case enMode.AddMode:
                    if (_AddNewLocalDrivingLicenseApplication())
                    {

                        _Mode = enMode.UpdateMode;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.UpdateMode:

                    return _UpdateLocalDrivingLicenseApplication();

            }

            return false;
        }

        public static DataTable GetAllLocalDrivingLicenseApplications()
        {
            return dataLdlApplication.GetAllLocalDrivingLicenseApplications();
        }

        public bool LdlDelete()
        {
            bool IsLocalDrivingApplicationDeleted = false;
            bool IsBaseApplicationDeleted = false;

            IsLocalDrivingApplicationDeleted = dataLdlApplication.Delete_LDL_App(this.LocalDrivingLicenseApplicationID);
            IsBaseApplicationDeleted = base.Delete();

            if (!IsLocalDrivingApplicationDeleted || !IsBaseApplicationDeleted)
                return false;
 
            return true;

        }

    }
}
