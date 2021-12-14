using System;
using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressBookTests
{
    [TestFixture]
    public class GroupModificationTests: GroupTestBase
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

            List<GroupData> oldGroups = GroupData.GetAll();
            GroupData oldData = oldGroups[0];

            app.Group.Modify(oldData, newData);

            Assert.AreEqual(oldGroups.Count, app.Group.GetGroupCount());

            List<GroupData> newGroups = GroupData.GetAll();
            oldGroups[0].Name = newData.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

            foreach (GroupData groups in newGroups)
            {
                if(groups.Id == oldData.Id)
                {
                    Assert.AreEqual(newData.Name, groups.Name);
                }
            }
        }
    }
}
