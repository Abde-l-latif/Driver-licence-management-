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

        public people Person;
        public int CreatedByUserID { get; set; }
        public DateTime CreatedDate { get; set; }


        public Driver(int personID, int CreatedByUserID)
        {
            this.personID = personID;
            Person = people.Find(this.personID);
            this.CreatedByUserID = CreatedByUserID;
        }

        public Driver(int driverID , int personID, int CreatedByUserID , DateTime CreateDate)
        {
            this.DriverID = driverID;
            this.personID = personID;
            Person = people.Find(this.personID);
            this.CreatedByUserID = CreatedByUserID;
            this.CreatedDate = CreateDate;
        }

        public static Driver FindByDriverID(int DriverID)
        {

            int PersonID = -1; int CreatedByUserID = -1; DateTime CreatedDate = DateTime.Now;

            if (dataDriver.GetDriverInfoByDriverID(DriverID, ref PersonID, ref CreatedByUserID, ref CreatedDate))

                return new Driver(DriverID, PersonID, CreatedByUserID, CreatedDate);
            else
                return null;

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

    }
            
}
