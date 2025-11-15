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

        public DateTime appointmentDate { get; set; }

        public decimal PaidFees { get; set; }

        public int CreateByUserID { get; set; }

        public bool isLocked { get; set; }

        public TestAppointment()
        {
            appointmentID = -1;
            testTypeID = -1;
            LDL_ID = -1;
            appointmentDate = new DateTime();
            PaidFees = 0;
            CreateByUserID = -1; 
            isLocked = false;
            Mode = enMode.addMode; 
        }

        public TestAppointment(int AppointmentID , DateTime appointmentDate)
        {
            appointmentID = AppointmentID;
            this.appointmentDate = appointmentDate;
            Mode = enMode.UpdateMode;
        }

        private bool addTestAppointments()
        {
            this.appointmentID = dataTest.insertTestAppointments(this.testTypeID, this.LDL_ID, this.appointmentDate, this.PaidFees,
                    this.CreateByUserID, this.isLocked);
            return (this.appointmentID != -1); 
        }

        private bool UpdateAppointmentDate()
        {
            return dataTest.updateAppointmentDate(this.appointmentID, this.appointmentDate); 
        }

        static public DataTable getTestAppointments(int id, int TestType)
        {
            return dataTest.getTestAppointments(id , TestType);
        }

        static public bool updateIsLocked(int id)
        {
            return dataTest.updateIsLocked(id);
        }

        static public bool isAppointmentExists(int id, int testType)
        {
            return dataTest.isAppointmentExists(id , testType);
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
