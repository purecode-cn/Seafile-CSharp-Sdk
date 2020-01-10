using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeafileClient.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeafileClientTest
{
    [TestClass]
    public class FileTests : TestsBase
    {
        [TestMethod]
        public void TestFiles()
        {
            var repo = Api.CreateRepo(AccessToken, "test-repo");

            var parentPath = "/test/";
            Api.CreateDirectory(AccessToken, repo.Id, parentPath);
            var uploadLink = Api.CreateUploadLink(AccessToken, repo.Id, parentPath);

            var result = Api.UploadFiles(AccessToken, uploadLink, new string[] { "avatar_demo.jpg", "avatar_demo.jpg", "avatar_demo.jpg" }, parentPath, null, true);
            Assert.IsTrue(result != null && result.ToArray().Length == 3);
            UploadResult firstFile = null;
            foreach (var file in result)
            {
                if (firstFile != null)
                {
                    Assert.AreEqual(firstFile.Name, file.Name);
                }
                else
                {
                    firstFile = file;
                }
            }

            result = Api.UploadFiles(AccessToken, uploadLink, new string[] { "avatar_demo.jpg", "avatar_demo.jpg", "avatar_demo.jpg" }, parentPath, null);
            Assert.IsTrue(result != null && result.ToArray().Length > 0);
            foreach (var file in result)
            {
                Assert.IsTrue(file.Name.StartsWith(firstFile.Name.Split('.')[0]));
                Api.DeleteFile(AccessToken, repo.Id, parentPath + file.Name);
            }
            Api.DeleteFile(AccessToken, repo.Id, parentPath + firstFile.Name);
            Api.DeleteRepo(AccessToken, repo.Id);
        }
    }
}
