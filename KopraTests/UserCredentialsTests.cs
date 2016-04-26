using System;
using Kopra;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
namespace KopraTests
{
    [TestClass]
    public class UserCredentialsTests
    {
        [TestMethod]
        [Microsoft.VisualStudio.TestTools.UnitTesting.ExpectedException(typeof(ArgumentNullException))]
        public void EmailToUserName_EmailIsNull_NullArgumentException()
        {
            //Arrange
            UserCredentials userCredentials = new UserCredentials();

            //Act
            userCredentials.EmailToUserName(null);

            //Assert
            //ExpectedException will take care of it.
        }

        [TestMethod]
        public void EmailToUserName_CorrectEmail_Pass()
        {
            // Arrange
            UserCredentials userCredentials = new UserCredentials();
            string email = "john.bravo@gmail.com";
            //Act
            var result = userCredentials.EmailToUserName(email);
            //Assert
            Assert.AreEqual(email, result+"@gmail.com");
        }
    }

}
