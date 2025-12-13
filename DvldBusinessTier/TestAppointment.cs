using DvldDataTier;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DvldBusinessTier
{
    public class TestAppointment
    {

        enum enMode { addMode , UpdateMode }

        enMode Mode;
        public int appointmentID { get; set; }

        public int testTypeID { get; set; }

        public int LDL_ID { get; set; }


        public LdlApplication LocalDrivingLicenseApplication;

        public DateTime appointmentDate { get; set; }

        public decimal PaidFees { get; set; }

        public int CreateByUserID { get; set; }

        public bool isLocked { get; set; }

        public int retakeTestId { get; set; }


        public TestAppointment()
        {
            appointmentID = -1;
            testTypeID = -1;
            LDL_ID = -1;
            appointmentDate = new DateTime();
            PaidFees = 0;
            CreateByUserID = -1; 
            isLocked = false;
            retakeTestId = -1;
            Mode = enMode.addMode; 
        }

        public TestAppointment(int TestAppointmentID, int TestTypeID, int LocalDrivingLicenseApplicationID,
             DateTime AppointmentDate, decimal PaidFees, int CreatedByUserID, bool IsLocked, int RetakeTestApplicationID)
        {
            appointmentID = TestAppointmentID;
            testTypeID = TestTypeID;
            LDL_ID = LocalDrivingLicenseApplicationID;
            LocalDrivingLicenseApplication = LdlApplication.FindByLocalDrivingAppLicenseID(LocalDrivingLicenseApplicationID);
            this.appointmentDate = AppointmentDate;
            this.PaidFees = PaidFees; 
            this.CreateByUserID  = CreatedByUserID;
            this.isLocked = IsLocked;
            retakeTestId = RetakeTestApplicationID;
            Mode = enMode.UpdateMode;
        }

        private bool addTestAppointments()
        {
            this.appointmentID = dataTestAppointments.insertTestAppointments(this.testTypeID, this.LDL_ID, this.appointmentDate, this.PaidFees,
                    this.CreateByUserID, this.isLocked, this.retakeTestId);
            return (this.appointmentID != -1); 
        }

        public static TestAppointment Find(int TestAppointmentID)
        {
            int TestTypeID = 1; int LocalDrivingLicenseApplicationID = -1;
            DateTime AppointmentDate = DateTime.Now; decimal PaidFees = 0;
            int CreatedByUserID = -1; bool IsLocked = false; int RetakeTestApplicationID = -1;

            if (dataTestAppointments.GetTestAppointmentInfoByID(TestAppointmentID, ref TestTypeID, ref LocalDrivingLicenseApplicationID,
            ref AppointmentDate, ref PaidFees, ref CreatedByUserID, ref IsLocked, ref RetakeTestApplicationID))

                return new TestAppointment(TestAppointmentID, TestTypeID, LocalDrivingLicenseApplicationID,
             AppointmentDate, PaidFees, CreatedByUserID, IsLocked, RetakeTestApplicationID);
            else
                return null;

        }

        private bool UpdateAppointmentDate()
        {
            return dataTestAppointments.updateAppointmentDate(this.appointmentID, this.appointmentDate); 
        }

        static public DataTable getTestAppointments(int id, int TestType)
        {
            return dataTestAppointments.getTestAppointments(id , TestType);
        }

        static public bool updateIsLocked(int id)
        {
            return dataTest.updateIsLocked(id);
        }

        static public bool isAppointmentExists(int id, int testType)
        {
            return dataTestAppointments.isAppointmentExists(id , testType);
        }


        public bool Save()
        {
            if (Mode == enMode.addMode)
                return addTestAppointments(); 
            else
                return UpdateAppointmentDate(); 
        }
    }
}
