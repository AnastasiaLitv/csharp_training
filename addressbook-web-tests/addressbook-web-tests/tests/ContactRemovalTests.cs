using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressBookTests
{
    [TestFixture]
    public class ContactRemovalTests : ContactTestBase
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
            contact.HomePhone = "(22)2-22-3";
            contact.Mobile = "wmwmw";
            contact.Email = "rfefe@d.d";
            contact.Email2 = "qqeeeq@ss.s";
            contact.Email3 = "qqeeeq@test.s";
            contact.Notes = "wekrweprkw";

            app.Contact.IsContactExist(contact);
           
            List<ContactData> oldContacts = ContactData.GetAll();
            ContactData toBeRemoved = oldContacts[0];

            app.Contact.Remove(toBeRemoved);

            Assert.AreEqual(oldContacts.Count - 1, app.Contact.GetContactCount());

            List<ContactData> newContacts = ContactData.GetAll();

            oldContacts.RemoveAt(0);
            Assert.AreEqual(oldContacts, newContacts);

            foreach (ContactData contacts in newContacts)
            {
                Assert.AreNotEqual(contacts.Id, toBeRemoved.Id);
            }
        }
    }
}
