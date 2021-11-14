using System;
using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressBookTests
{
    [TestFixture]
    public class ContactModificationTests : AuthTestBase
    {
        [Test]
        public void ContactModificationTest()
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

            ContactData newData = new ContactData("test", "name");
            newData.Middlename = "qqq";
            newData.Title = "www";
            newData.Nickname = "dfgdfdfg";
            newData.Company = "dgfdrterter";
            newData.Address = "pepepe";
            newData.Home = "srsrs";
            newData.Mobile = "mgjdy";
            newData.Email = "222uuu";
            newData.Notes = "ppppp";

            app.Contact.IsContactExist(contact);

            List<ContactData> oldContacts = app.Contact.GetContactList();

            app.Contact.Modify(1, newData);
          
            List<ContactData> newContacts = app.Contact.GetContactList();
            oldContacts[0].Lastname = newData.Lastname;
            oldContacts[0].Firstname = newData.Firstname;
            oldContacts.Sort();
            newContacts.Sort();

            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
