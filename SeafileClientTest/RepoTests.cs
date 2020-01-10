using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeafileClientTest
{
    [TestClass]
    public class RepoTests: TestsBase
    {
        [TestMethod]
        public void TestListRepos()
        {
            var defaultRepo = Api.GetDefaultRepo(AccessToken);
            Assert.AreEqual(true, defaultRepo.Exists);
            var list = Api.ListRepos(AccessToken);
            Assert.IsTrue(list.Count > 0);
        }

        [TestMethod]
        public void TestShareRepo()
        {
            var sharedRepo = Api.CreatePublicRepo(AccessToken, "test_for_api", "rw");
            Assert.IsNotNull(sharedRepo.Id);
            var result = Api.RemoveRepoFromPublic(AccessToken, sharedRepo.Id);
            Assert.IsTrue(result);
            result = Api.ShareExistedRepoToPublic(AccessToken, sharedRepo.Id, "rw");
            Assert.IsTrue(result);
            Api.DeleteRepo(AccessToken, sharedRepo.Id);
        }
    }
}
