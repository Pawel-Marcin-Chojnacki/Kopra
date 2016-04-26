using Kopra;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace KopraTests
{
    [TestClass]
    public class ConnectionManagerTests
    {
        [TestMethod]
        public void GetApiFromWebService_WithCorrectData_ShouldPass()
        {
            //Arrange
            var credentials = new SettingsManager();
            //Act
            ConnectionManager.GetWebApiKeyFromService();
            //Assert
            Assert.IsNotNull(credentials.KokosWebApiKey);
        }
    }
}