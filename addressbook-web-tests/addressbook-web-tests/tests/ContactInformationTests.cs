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
            Assert.AreEqual(fromTable.Email, fromForm.Email);
            Assert.AreEqual(fromTable.AllPhones, fromForm.AllPhones);
        }
    }
}

