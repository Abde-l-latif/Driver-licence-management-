using DvldDataTier;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvldBusinessTier
{
    public class Tests
    {
        static public Decimal getTestFee(int id)
        {
            return dataTest.getTestFee(id);
        }

        static public void GetScheduleTestInfo(int id, int testType, ref string ClassName, ref string fullName, ref Decimal fees, ref int Trials)
        {
            dataTest.GetScheduleTestInfo(id, testType, ref ClassName, ref fullName, ref fees, ref Trials);
        }

        static public bool insertTest(int TestAppointmentID, bool TestResult, string Notes, int CreatedByUserID , ref int TestID)
        {
            if(String.IsNullOrEmpty(Notes))
            {
                Notes = ""; 
            }

            return dataTest.insertTest(TestAppointmentID, TestResult, Notes, CreatedByUserID , ref TestID);
        }

        static public bool isTestFailedExists(int LdlID, int TestType)
        {
            return dataTest.isTestFailedExists(LdlID, TestType); 
        }

        static public bool isTestPassedExists(int LdlID, int TestType)
        {
            return dataTest.isTestPassedExists(LdlID, TestType);
        }

        static public int getPassedTests(int LocalDrivingLicenseApplicationID)
        {
            return dataTest.getPassedTests(LocalDrivingLicenseApplicationID);
        }


    }
}
