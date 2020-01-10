using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeafileClientTest
{
    [TestClass]
    public class ServerTests: TestsBase
    {
        [TestMethod]
        public void TestPing()
        {
            var result = Api.Ping();
            Assert.AreEqual("pong", result);
        }

        [TestMethod]
        public void TestGetServerInfo()
        {
            var result = Api.GetServerInfo();
            Assert.AreEqual(2, result.EncryptedLibraryVersion);
        }
    }
}
