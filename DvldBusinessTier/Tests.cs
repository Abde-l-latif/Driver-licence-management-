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


        static public DataTable getAllTestTypes()
        {
            return dataTest.getAllTestTypes();
        }

        static public bool UpdateTestType(int id , string title, string description , string fee)
        {
            return dataTest.UpdateTestType(id, title, description, Convert.ToDecimal(fee));
        }


    }
}
