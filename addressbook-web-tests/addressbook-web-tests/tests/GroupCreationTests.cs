using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressBookTests
{
    [TestFixture]
    public class GroupCreationTests : AuthTestBase
    {
        [Test]
        public void GroupCreationTest()
        {
            GroupData group = new GroupData("asdas");
            group.Header = "erwe";
            group.Footer = "qqq";

            //List<GroupData> oldGroups = app.Group.GetGroupList();

            app.Group.Create(group);

           // List<GroupData> newGroups = app.Group.GetGroupList();
           // Assert.AreEqual(oldGroups.Count + 1, newGroups.Count);
        }

        [Test]
        public void EmptyGroupCreationTest()
        {
            GroupData group = new GroupData("");
            group.Header = "";
            group.Footer = "";

            app.Group.Create(group);
        }
    }
}
