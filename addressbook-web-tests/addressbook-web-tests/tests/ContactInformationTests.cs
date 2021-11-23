using System;
using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressBookTests
{
    [TestFixture]
    public class ContactInformationTests : AuthTestBase
    {
        [Test]
        public void ContactInformationTest()
        {
            ContactData fromTable = app.Contact.GetContactInfoFromTable(0);
            ContactData fromForm = app.Contact.GetContactInfoFromEditForm(0);

            //Assert
            Assert.AreEqual(fromTable, fromForm);
            Assert.AreEqual(fromTable.Address, fromForm.Address);
            Assert.AreEqual(fromTable.AllEmails, fromForm.AllEmails);
            Assert.AreEqual(fromTable.AllPhones, fromForm.AllPhones);
        }
        [Test]
        public void ContactInformationDetailsTest()
        {
            ContactData fromDetails = app.Contact.GetContactInfoFromDetailsPage(0);
            ContactData fromForm = app.Contact.GetContactInfoFromEditForm(0);

            //Assert
            Assert.AreEqual(fromDetails.AllElements, fromForm.AllElements);
            Assert.AreEqual(fromDetails.AllNames, fromForm.AllNames);
        }
    }
}

