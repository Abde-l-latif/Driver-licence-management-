using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvldBusinessTier
{
    static public class Validation
    {

        static public bool EmailValidition(string text)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$") && text != "")
            {
                return false;
            }

            return true;
        }

        static public bool NationalNumberValidation(string text)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(text, @"^[A-Za-z]{2}\d{3,6}$"))
            {
                return false;
            }

            return true;
        }

        static public bool PhoneNumberValidation(string text)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(text, @"^\d{10}$"))
            {
                return false;
            }

            return true;
        }

        static public bool AddressValidation(string text)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(text, @"^[A-Za-z]{5,}$"))
            {
                return false;
            }

            return true;
        }



              
    }
}
