using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;
using ValidatorLibrary;

namespace ValidatorTests
{
    [TestClass]
    public class CustomValidationDataAttributeTests
    {
        [CustomValidationData]
        [TestMethod]
        public void TestLoginValidator_WithCustomData(string login, bool expected)
        {
            // Arrange
            var validator = new LoginValidator();

            // Act
            var result = validator.Validate(login);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [CustomValidationData]
        [TestMethod]
        public void TestPasswordValidator_WithCustomData(string password, bool expected)
        {
            // Arrange
            var validator = new PasswordValidator();

            // Act
            var result = validator.Validate(password);

            // Assert
            Assert.AreEqual(expected, result);
        }

        /*
        [CustomValidationData]
        public void TestMethod(string data, bool expected)
        {
            // Test logic here
        }
        */
    }
}
