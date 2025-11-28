using DvldDataTier;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvldBusinessTier
{
    public class Countries
    {

        public int CountryID {  get; set; }
        public string CountryName { get; set; }

        public Countries() { }

        public Countries(int CountryID , string CountryName)
        { 
            this.CountryID = CountryID;
            this.CountryName = CountryName;
        }

        static public Countries FindCountryByName(string CountryName)
        {
            int ID = -1; 
            if(dataCountry.FindCountryByName(CountryName , ref ID))
                return new Countries(ID , CountryName);
            else
                return null;
        }

        static public DataTable getAllCountries()
        {
            return dataCountry.getAllCountries();
        }
    }
}
