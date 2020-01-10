using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeafileClientTest
{
    [TestClass]
    public class GroupTests: TestsBase
    {
        [TestMethod]
        public void TestGroup()
        {
            var groupName = "test-group";
            var testUserEmail1 = "testuser1@mock.com";
            
            var testUserEmail2 = "testuser2@mock.com";
            var testUserEmail3 = "testuser3@mock.com";
            var testUserEmail4 = "testuser4@mock.com";
            var tempUser1 = Api.AdminCreateUser(AccessToken, testUserEmail1, "password");
            var tempUser2 = Api.AdminCreateUser(AccessToken, testUserEmail2, "password");
            var tempUser3 = Api.AdminCreateUser(AccessToken, testUserEmail3, "password");
            var tempUser4 = Api.AdminCreateUser(AccessToken, testUserEmail4, "password");
            Assert.IsNotNull(tempUser1);
            var group = Api.CreateGroup(AccessToken, groupName);
            Assert.IsNotNull(group);
            var groupMember = Api.AddGroupMember(AccessToken, group.Id, testUserEmail1);
            Assert.IsNotNull(groupMember);
            groupMember = Api.ToggleGroupAdmin(AccessToken, group.Id, testUserEmail1, true);
            Assert.IsTrue(groupMember.IsGroupAdmin);

            var result = Api.BulkAddGroupMembers(AccessToken, group.Id, new string[] { testUserEmail1, testUserEmail2, testUserEmail3, testUserEmail4 });
            Assert.AreEqual(1, result.Failed.Count());
            Assert.AreEqual(testUserEmail1, result.Failed.First().Email);
            Assert.AreEqual(3, result.Success.Count());

            var members = Api.ListGroupMembers(AccessToken, group.Id).ToList();
            Assert.AreEqual(5, members.Count);
            Api.DeleteGroup(AccessToken, group.Id);
            Api.AdminDeleteUser(AccessToken, testUserEmail1);
            Api.AdminDeleteUser(AccessToken, testUserEmail2);
            Api.AdminDeleteUser(AccessToken, testUserEmail3);
            Api.AdminDeleteUser(AccessToken, testUserEmail4);
        }
    }
}
