using NUnit.Framework;

namespace WebAddressBookTests
{
    [TestFixture]
    public class GroupRemovalTests : TestBase
    {

        [Test]
        public void GroupRemovalTest()
        {
            app.Group.Remove(1);
        }
    }
}
