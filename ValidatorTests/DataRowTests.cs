using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidatorLibrary;

namespace ValidatorTests
{
    [TestClass]
    class DataRowTests
    {
        [DataTestMethod]
        [DataRow("username", true)]
        [DataRow("short", false)]
        [DataRow("too_long_username_to_validate", false)]
        [DataRow("username123", false)]
        public void TestLoginValidation(string login, bool expected)
        {
            var validator = new LoginValidator();
            var result = validator.Validate(login);
            Assert.AreEqual(expected, result);
        }

        [DataTestMethod]
        [DataRow("Password1!", true)]
        [DataRow("weak", false)]
        [DataRow("too_long_password_to_validate_1234", false)]
        [DataRow("PasswordNoSpecialChar1", false)]
        [DataRow("NoDigitsOrSpecialChars", false)]
        public void TestPasswordValidation(string password, bool expected)
        {
            var validator = new PasswordValidator();
            var result = validator.Validate(password);
            Assert.AreEqual(expected, result);
        }
    }
}
