using NUnit.Framework;

namespace WebAddressBookTests
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {

        [Test]
        public void GroupRemovalTest()
        {
            GroupData group = new GroupData("test");
            group.Header = "new";
            group.Footer = "lalala";

            app.Group.IsGroupExist(group);

            app.Group.Remove(1);
        }
    }
}
