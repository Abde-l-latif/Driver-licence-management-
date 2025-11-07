using System;
using System.Data;
using DvldDataTier;


namespace DvldBusinessTier
{
    public class application
    {


        static public DataTable getApplicationTypes()
        {
            return dataApplication.getAllApplictionTypes();
        }

        static public bool updateApplicationTypes(int id, string title , string fee)
        {
            return dataApplication.UpdateApplicationType(id , title , Convert.ToDecimal(fee));
        }



    }
}
