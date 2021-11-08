using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace WebAddressBookTests
{
    public class AuthTestBase : TestBase
    {
        [SetUp]
        public void SetupLogin()
        { 
            app.Auth.Login(new AccountData("admin", "secret"));
        }
    }
}
