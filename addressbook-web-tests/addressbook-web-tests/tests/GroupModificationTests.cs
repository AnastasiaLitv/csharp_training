using System;
using NUnit.Framework;

namespace WebAddressBookTests
{
    [TestFixture]
    public class GroupModificationTests: TestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            GroupData newData = new GroupData("eww");
            newData.Header = "zzz";
            newData.Footer = "aaa";

            app.Group.Modify(1, newData);
        }
    }
}
