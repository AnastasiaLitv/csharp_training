using NUnit.Framework;

namespace WebAddressBookTests
{
    [TestFixture]
    public class ContactRemovalTests : AuthTestBase
    {

        [Test]
        public void ContactRemovalTest()
        {
            ContactData contact = new ContactData("qqq", "www");
            contact.Middlename = "erwe";
            contact.Title = "qqsq";
            contact.Nickname = "erwse";
            contact.Company = "qewq";
            contact.Address = "xxxs";
            contact.Home = "pepe";
            contact.Mobile = "wmwmw";
            contact.Email = "qqeeeq";
            contact.Notes = "wekrweprkw";

            app.Contact.Remove(1, contact);
        }
    }
}
