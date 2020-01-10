using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeafileClientTest
{
    [TestClass]
    public class DirectoryTests: TestsBase
    {
        [TestMethod]
        public void TestDirectory()
        {
            var repo = Api.CreateRepo(AccessToken, "test-repo");


            var dirName = "/test";
            var subDirName = "/sub_test";
            var createResult = Api.CreateDirectory(AccessToken, repo.Id, dirName);
            Assert.AreEqual(true, createResult);
            createResult = Api.CreateDirectory(AccessToken, repo.Id, dirName + subDirName);
            Assert.AreEqual(true, createResult);

            var dirs = Api.ListDirectories(AccessToken, repo.Id, dirName).ToArray();

            Assert.AreEqual(1, dirs.Length);
            Assert.AreEqual(subDirName, "/" + dirs[0].Name);

            var renameResult = Api.RenameDirectory(AccessToken, repo.Id, dirName + subDirName, dirName + subDirName + "1");
            Assert.AreEqual(true, renameResult);

            var deleteResult = Api.DeleteDirectory(AccessToken, repo.Id, dirName);

        }
    }
}
