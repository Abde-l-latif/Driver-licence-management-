using DvldDataTier;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvldBusinessTier
{
    public class Driver
    {

        public int DriverID { get; set; }
        public int personID { get; set; }
        public int CreatedByUserID { get; set; }
        public DateTime CreatedDate { get; set; }


        public Driver(int personID, int CreatedByUserID)
        {
            this.personID = personID;
            this.CreatedByUserID = CreatedByUserID;
        }

        public void addDriver()
        {
            this.CreatedDate = DateTime.Now;
            this.DriverID = dataDriver.insertDriver(this.personID, this.CreatedByUserID, this.CreatedDate);
        }

        static public bool isDriverExists(int personID)
        {
            return dataDriver.isDriverExists(personID);
        }

        static public int getDriverIdByPersonID(int personID)
        {
            return dataDriver.getDriverIdByPersonID(personID);
        }

        static public DataTable getAllDrivers()
        {
            return dataDriver.getAllDrivers();
        }

        static public DataTable getFiltredDrivers(string Text, string Filter)
        {
            return dataDriver.getFiltredDrivers(Text, Filter);
        }
    }
            
}
