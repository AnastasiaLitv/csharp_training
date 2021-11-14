using System;
using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressBookTests
{
    [TestFixture]
    public class GroupModificationTests: AuthTestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            GroupData group = new GroupData("test");
            group.Header = "new";
            group.Footer = "lalala";

            GroupData newData = new GroupData("eww");
            newData.Header = "zzz";
            newData.Footer = "aaa";

            app.Group.IsGroupExist(group);

            List<GroupData> oldGroups = app.Group.GetGroupList();

            app.Group.Modify(0, newData);
            List<GroupData> newGroups = app.Group.GetGroupList();
            oldGroups[0].Name = newData.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}
