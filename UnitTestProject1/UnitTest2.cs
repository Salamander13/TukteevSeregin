using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WpfApp8.Pages;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void Authtest()
        {
            var page = new AuthPage();
            Assert.IsTrue(page.Auth("Admin","Admin"));
            Assert.IsFalse(page.Auth("Admin", "Admin"));
            Assert.IsFalse(page.Auth(" ", " "));
            Assert.IsFalse(page.Auth("", ""));
        }
    }
}
