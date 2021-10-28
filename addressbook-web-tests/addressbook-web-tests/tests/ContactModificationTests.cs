using System;
using NUnit.Framework;

namespace WebAddressBookTests
{
    [TestFixture]
    public class ContactModificationTests : TestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            ContactData newData = new ContactData("qqq", "www");
            newData.Middlename = "erwe";
            newData.Title = "qqsq";
            newData.Nickname = "erwse";
            newData.Company = "qewq";
            newData.Address = "xxxs";
            newData.Home = "pepe";
            newData.Mobile = "wmwmw";
            newData.Email = "qqeeeq";
            newData.Notes = "wekrweprkw";

            app.Contact.Modify(1, newData);
        }
    }
}
