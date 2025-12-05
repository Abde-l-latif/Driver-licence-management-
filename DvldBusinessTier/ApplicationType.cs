using DvldDataTier;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvldBusinessTier
{
    public class ApplicationType
    {
        private int ApplicationID { get; set; }

        public string ApplicationTypeTitle { get; set; }

        public decimal ApplicationFees { get; set; }

        public ApplicationType() { }

        public ApplicationType(int id , string title , decimal fees)
        {
            ApplicationID = id;
            ApplicationTypeTitle = title;
            ApplicationFees = fees;
        }

        static public DataTable getAllApplicationType()
        {
            return dataApplicationType.getAllApplictionTypes();
        }

        static public ApplicationType Find(int id)
        {
            string title = ""; 
            decimal fees = 0;   

            if(dataApplicationType.FindApplicationTypeInfo(id, ref title , ref fees))
            {
                return new ApplicationType(id , title , fees);
            }

            return null;
        }

        private bool _UpdateAppType()
        {
            return dataApplicationType.UpdateApplicationType(ApplicationID, ApplicationTypeTitle, ApplicationFees);
        }

        public bool Save()
        {
            return _UpdateAppType();
        }


    }
}
