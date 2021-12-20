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
    public class AddingContactToGroupTests: AuthTestBase
    {
        [Test]
        public void TestAddingContactToGroup()
        {
            List<GroupData> group = GroupData.GetAll();
            if (group.Count == 0)
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
                app.Contact.Create(contc);
            }

            GroupData groups = GroupData.GetAll()[0];
            List<ContactData> oldList = groups.GetContacts();
            ContactData contact = ContactData.GetAll().Except(oldList).FirstOrDefault();

            if (contact == null)
            {
                ContactData cont = new ContactData("asd", "zxc");
                app.Contact.Create(cont);
                contact = ContactData.GetAll().Except(oldList).First();
            }

            app.Contact.AddContactToGroup(contact, groups);

            List<ContactData> newList = groups.GetContacts();
            oldList.Add(contact);
            newList.Sort();
            oldList.Sort();

            Assert.AreEqual(oldList, newList);
        }
    }
}
