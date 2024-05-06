using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidatorLibrary
{
    public class LoginValidator : IValidator
    {
        public bool Validate(string validateObject)
        {
            // Check for login null or empty
            if (string.IsNullOrEmpty(validateObject))
            {
                return false;
            }

            // Check for length between 6 and 16
            if (validateObject.Length < 6 || validateObject.Length > 16)
            {
                return false;
            }

            // Check for only Latin characters
            if (!validateObject.All(char.IsLetter))
            {
                return false;
            }
            return true;
        }
    }
}