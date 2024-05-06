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
    class DynamicDataTests
    {
        [DynamicData(nameof(GetLoginTestData), DynamicDataSourceType.Method)]
        [TestMethod]
        public void TestLoginValidation(string login, bool expected)
        {
            var validator = new LoginValidator();
            var result = validator.Validate(login);
            Assert.AreEqual(expected, result);
        }

        public static IEnumerable<object[]> GetLoginTestData()
        {
            yield return new object[] { "username", true };
            yield return new object[] { "short", false };
            yield return new object[] { "too_long_username_to_validate", false };
            yield return new object[] { "username123", false };
        }

        [DynamicData(nameof(GetPasswordTestData), DynamicDataSourceType.Method)]
        [TestMethod]
        public void TestPasswordValidation(string password, bool expected)
        {
            var validator = new PasswordValidator();
            var result = validator.Validate(password);
            Assert.AreEqual(expected, result);
        }

        public static IEnumerable<object[]> GetPasswordTestData()
        {
            yield return new object[] { "Password1!", true };
            yield return new object[] { "weak", false };
            yield return new object[] { "too_long_password_to_validate_1234", false };
            yield return new object[] { "PasswordNoSpecialChar1", false };
            yield return new object[] { "NoDigitsOrSpecialChars", false };
        }
    }
}
