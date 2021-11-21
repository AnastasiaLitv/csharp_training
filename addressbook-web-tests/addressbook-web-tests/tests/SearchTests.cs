using System;
using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressBookTests
{
    [TestFixture]
    public class SearchTests : AuthTestBase
    {
        [Test]
        public void SearchTest()
        {
            System.Console.Out.Write(app.Contact.GetNumberOfSearchResult());

        }
    }
}
