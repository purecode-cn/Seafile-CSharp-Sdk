using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeafileClient.Common;
using System.Linq;

namespace SeafileClientTest
{
    [TestClass]
    public class AccountTests: TestsBase
    {

        [TestMethod]
        public void TestLogin()
        {
            try
            {
                var result = Api.Login(UserName, Password);
                Assert.IsNotNull(result);
            } catch (SeafileException e)
            {
                Assert.IsNotNull(e.Message);
            }
        }

        [TestMethod]
        public void TestLoginFailed()
        {
            try
            {
                var result = Api.Login(UserName, "123456");
                Assert.IsNotNull(result);
            }
            catch (SeafileException e)
            {
                Assert.IsNotNull(e.Message);
            }
        }

        [TestMethod]
        public void TestUpdateAvatar()
        {
            var result = Api.UpdateAvatar(AccessToken, "avatar_demo.jpg");
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TestGetAccountInfo()
        {
            var result = Api.GetAccountInfo(AccessToken);
            Assert.AreEqual(result.Email, UserName);
        }

        [TestMethod]
        public void TestGetClientLoginUrl()
        {
            var result = Api.GetClientLoginUrl(AccessToken);
            Assert.IsTrue(result.Length > 0);
        }

        [TestMethod]
        public void TestGetActivities()
        {
            var result = Api.GetActivities(AccessToken);
            Assert.IsTrue(result.ToArray().Length > 0);
        }
    }
}
