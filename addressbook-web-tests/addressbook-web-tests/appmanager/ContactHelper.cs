using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace WebAddressBookTests
{
    public class ContactHelper : HelperBase
    {
        public ContactHelper(ApplicationManager manager)
            : base(manager)
        { 
        }
        public ContactHelper Create(ContactData contact)
        {
            manager.Navigator.GoToContactPage();

            FillContactForm(contact);
            Submit();
            ReturnToHomePage(); 
            return this;
        }

        public ContactData GetContactInfoFromEditForm(int index)
        {
            manager.Navigator.GoToHomePage();
            EditContact(index + 1);

            string firstname = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string lastname = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");
            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string email = driver.FindElement(By.Name("email")).GetAttribute("value");

            return new ContactData(firstname, lastname)
            {
                Address = address,
                Email = email,
                Home = homePhone,
                Mobile = mobilePhone
                
            };
        }

        public ContactData GetContactInfoFromTable(int index)
        {
            manager.Navigator.GoToHomePage();
            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"));
            string lastname = cells[1].Text;
            string firstname = cells[2].Text;
            string address = cells[3].Text;
            string email = cells[4].Text;
            string allPhones = cells[5].Text;

            return new ContactData(firstname, lastname)
            {
                Address = address,
                Email = email,
                AllPhones = allPhones
            };

        }

        private List<ContactData> contactCache = null;

        public List<ContactData> GetContactList()
        {
            if (contactCache == null)
            {
                contactCache = new List<ContactData>();
                List<ContactData> contacts = new List<ContactData>();
                manager.Navigator.GoToHomePage();
                ICollection<IWebElement> elements = driver.FindElements(By.XPath("//tr[@class]"));

                foreach (IWebElement element in elements)
                {
                    IList<IWebElement> cells = element.FindElements(By.TagName("td"));
                    contactCache.Add(new ContactData(cells[2].Text, cells[1].Text)
                    {
                        Id = element.FindElement(By.TagName("input")).GetAttribute("value")
                    });
                }
            }

            return new List<ContactData>(contactCache);
        }

        public int GetContactCount()
        {
            return driver.FindElements(By.XPath("//tr[@class]")).Count;
        }

        public ContactHelper Modify(int p, ContactData newData)
        {
            EditContact(p);
            FillContactForm(newData);
            SubmitContactModification();
            ReturnToHomePage();
            return this;
        }
       

        public ContactHelper Remove(int p)
        {
            SelectContact(p);
            RemoveContact();
            return this;
        }

        public bool IsContactExist()
        {
            return IsElementPresent(By.XPath("//img[@title = 'Edit']"));
        }

        public bool IsContactExist(ContactData contact)
        {
            if (!IsContactExist())
            {
                Create(contact);
            }
            return true;
        }

        public ContactHelper ReturnToHomePage()
        {
            driver.FindElement(By.LinkText("home page")).Click();
            return this;
        }

        public ContactHelper Submit()
        {
            driver.FindElement(By.Name("submit")).Click();
            contactCache = null;
            return this;
        }

        public ContactHelper FillContactForm(ContactData contact)
        {
            Type(By.Name("firstname"), contact.Firstname);
            Type(By.Name("middlename"), contact.Middlename);
            Type(By.Name("lastname"), contact.Lastname);
            Type(By.Name("nickname"), contact.Nickname);
            Type(By.Name("title"), contact.Title);
            Type(By.Name("company"), contact.Company);
            Type(By.Name("address"), contact.Address);
            Type(By.Name("home"), contact.Home);
            Type(By.Name("mobile"), contact.Mobile);
            Type(By.Name("email"), contact.Email);
            Type(By.Name("notes"), contact.Notes);
            return this;
        }
        public ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.Name("update")).Click();
            contactCache = null;
            return this;
        }

        public ContactHelper EditContact(int index)
        {
            driver.FindElement(By.XPath("//img[@title = 'Edit'][" + index + "]")).Click();
            return this;
        }
        public ContactHelper SelectContact(int index)
        {
            driver.FindElement(By.XPath("//td[" + index + "]/input")).Click();
            return this;
        }
        public ContactHelper RemoveContact()
        {
            driver.FindElement(By.XPath("//input[@value = 'Delete']")).Click();
            driver.SwitchTo().Alert().Accept();
            contactCache = null;
            return this;
        }

        public int GetNumberOfSearchResult()
        {
            manager.Navigator.GoToHomePage();
           string text =  driver.FindElement(By.TagName("label")).Text;
            Match m = new Regex(@"\d+").Match(text);
            return Int32.Parse(m.Value);

        }
    }
}
