using System;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace KopraTests
{
    [TestClass]
    public class LoginTest
    {
        [TestMethod]
        public void InternetConnectionFailedTest()
        {
            Assert.AreEqual(3,4);
        }

        [TestMethod]
        public void InternetConnectionRestoredTest()
        {
            
        }

        [TestMethod]
        public void EmailFieldEmpyTest()
        {
            
        }

        [TestMethod]
        public void PasswordFieldEmptyTest()
        {
            
        }
    }
}
