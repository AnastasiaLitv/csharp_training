using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace WebAddressBookTests
{
    public class DeletingContactFromGroup : AuthTestBase
    {
        [Test]
        public void TestDeletingContactToGroup()
        {
            List<GroupData> group = GroupData.GetAll();
            if(group.Count == 0)
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
