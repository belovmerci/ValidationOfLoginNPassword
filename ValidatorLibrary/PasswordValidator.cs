using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidatorLibrary
{
    public class PasswordValidator : IValidator
    {
        public bool Validate(string validateObject)
        {
            // Check for password is null or empty
            if (string.IsNullOrEmpty(validateObject))
            {
                return false;
            }

            // Check for password length is between 8 and 20 characters
            if (validateObject.Length < 8 || validateObject.Length > 20)
            {
                return false;
            }

            // Check for password >= one uppercase letter, one digit, and one special character
            if (!validateObject.Any(char.IsUpper) ||
                !validateObject.Any(char.IsDigit) ||
                !validateObject.Any(IsSpecialCharacter))
            {
                return false;
            }
            return true;
        }

        private bool IsSpecialCharacter(char c)
        {
            return "!@#$%^&*-_".Contains(c);
        }
    }
}