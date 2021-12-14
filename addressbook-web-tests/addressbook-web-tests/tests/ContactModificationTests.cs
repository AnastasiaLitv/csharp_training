using System;
using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressBookTests
{
    [TestFixture]
    public class ContactModificationTests : ContactTestBase
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
            contact.HomePhone = "(31)-11-1111";
            contact.Mobile = "(33)33-33-333";
            contact.Email = "qqeeeq@u.w";
            contact.Email2 = "qqewwweq@u.w";
            contact.Email3 = "eddeq@u.w";
            contact.Notes = "wekrweprkw";

            ContactData newData = new ContactData("test", "name");
            newData.Middlename = "qqq";
            newData.Title = "www";
            newData.Nickname = "dfgdfdfg";
            newData.Company = "dgfdrterter";
            newData.Address = "pepepe";
            newData.HomePhone = "(44)44-44-444";
            newData.Mobile = "(11)11-11-11";
            newData.Email = "222uuu@o.o";
            contact.Email2 = "ieieoe@u.w";
            contact.Email3 = "pepepe@u.w";
            newData.Notes = "ppppp";

            app.Contact.IsContactExist(contact);

            List<ContactData> oldContacts = ContactData.GetAll();
            ContactData oldData = oldContacts[0];

            app.Contact.Modify(oldData, newData);

            Assert.AreEqual(oldContacts.Count, app.Contact.GetContactCount());

            List<ContactData> newContacts = ContactData.GetAll();
            oldContacts[0].Lastname = newData.Lastname;
            oldContacts[0].Firstname = newData.Firstname;
            oldContacts.Sort();
            newContacts.Sort();

            Assert.AreEqual(oldContacts, newContacts);
           
            foreach (ContactData contacts in newContacts)
            {
                if (contacts.Id == oldData.Id)
                {
                    Assert.AreEqual(newData.Lastname, contacts.Lastname);
                    Assert.AreEqual(newData.Firstname, contacts.Firstname);
                }
            }
        }
    }
}
