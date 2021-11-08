using System;
using NUnit.Framework;

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

            app.Group.Modify(1, group, newData);
        }
    }
}
