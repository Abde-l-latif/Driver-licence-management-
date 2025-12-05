using DvldDataTier;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvldBusinessTier
{
    public class TestType
    {

        public enum enTestType { visionTest , writtenTest , streetTest }

        private enTestType _TestTypeID { get; set; }

        public string TestTypeTitle { get; set; }

        public string TestTypeDescription { get; set; }

        public decimal TestTypeFees { get; set; }

        public TestType() { }

        public TestType(enTestType id, string title, string description, decimal fees)
        {
            _TestTypeID = id;
            TestTypeTitle = title;
            TestTypeDescription = description;
            TestTypeFees = fees;
        }

        static public DataTable getAllTestsType()
        {
            return dataTestType.getAllTestTypes();
        }

        static public TestType Find(enTestType id)
        {
            string title = "";
            string description = ""; 
            decimal fees = 0;

            if (dataTestType.getTestTypeById((int)id, ref title, ref description, ref fees))
            {
                return new TestType(id, title, description, fees);
            }

            return null;
        }

        private bool _UpdateAppType()
        {
            return dataTestType.UpdateTestType((int)_TestTypeID, TestTypeTitle, TestTypeDescription , TestTypeFees);
        }

        public bool Save()
        {
            return _UpdateAppType();
        }
    }
}
