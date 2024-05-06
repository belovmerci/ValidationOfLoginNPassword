using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ValidatorTests
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class CustomValidationDataAttribute : Attribute, ITestDataSource
    {
        public IEnumerable<object[]> GetData(MethodInfo methodInfo)
    {
        // Custom data generation logic
        // Here you can generate test data dynamically or read it from an external source

        // Example: Generate test data for login validation
        yield return new object[] { "validLogin", true };
        yield return new object[] { "short", false };
        yield return new object[] { "tooLongToBeAValidLogin", false };

        // Example: Generate test data for password validation
        yield return new object[] { "ValidPassword123!", true };
        yield return new object[] { "weak", false };
        yield return new object[] { "passwordWithoutDigits", false };

        // You can add more test data as needed
    }

    public string GetDisplayName(MethodInfo methodInfo, object[] data)
    {
        // Display name logic
        // Here you can format the display name based on the test data

        // Example: Format display name for login validation
        if (methodInfo.Name.StartsWith("TestLoginValidator"))
        {
            string login = (string)data[0];
            bool expected = (bool)data[1];
            return $"{methodInfo.Name} (Login: {login}, Expected: {expected})";
        }

        // Example: Format display name for password validation
        if (methodInfo.Name.StartsWith("TestPasswordValidator"))
        {
            string password = (string)data[0];
            bool expected = (bool)data[1];
            return $"{methodInfo.Name} (Password: {password}, Expected: {expected})";
        }

        // Default display name
        return methodInfo.Name;
    }
}
}
