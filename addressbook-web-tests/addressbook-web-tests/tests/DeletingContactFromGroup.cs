using NUnit.Framework;
using System.IO;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;
using System.Linq;
using Excel = Microsoft.Office.Interop.Excel;

namespace WebAddressBookTests

{
    public class DeletingContactFromGroup : AuthTestBase
    {
        [Test]
        public void TestDeletingContactToGroup()
        {
            List<GroupData> group = GroupData.GetAll();
            if( group.Count == 0)
            {
                GroupData gr = new GroupData("test");
                gr.Header = "new";
                gr.Footer = "lalala";

                app.Group.Create(gr);
            }

            List<ContactData> cn = ContactData.GetAll();
            if (cn.Count == 0)
            {
                ContactData contc = new ContactData("qqq", "www");
                contc.Middlename = "erwe";
                contc.Title = "qqsq";
                contc.Nickname = "erwse";
                contc.Company = "qewq";
                contc.Address = "xxxs";
                contc.HomePhone = "(22)2-22-3";
                contc.Mobile = "wmwmw";
                contc.Email = "rfefe@d.d";
                contc.Email2 = "qqeeeq@ss.s";
                contc.Email3 = "qqeeeq@test.s";
                contc.Notes = "wekrweprkw";

                app.Contact.Create(contc);

            }

            GroupData groups = GroupData.GetAll()[0];

            List<ContactData> oldList = groups.GetContacts();
            ContactData contact = ContactData.GetAll().Except(oldList).First();

            if (oldList.Count == 0)
            {
                app.Contact.AddContactToGroup(contact, groups);
                oldList.Add(contact);
            }
            
             app.Contact.DeleteContactFromGroup(contact, groups);

            List<ContactData> newList = groups.GetContacts();
            oldList.Remove(contact);
            newList.Sort();
            oldList.Sort();
            Assert.AreEqual(oldList, newList);  

        }
    }
}
