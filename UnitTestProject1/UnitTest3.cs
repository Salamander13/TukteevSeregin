using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WpfApp8.Pages;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest3
    {
        [TestMethod]
        public void AuthTestSuccess()
        {
            var page = new AuthPage();
            Assert.IsTrue(page.Auth("Admin", "Admin"));
            Assert.IsTrue(page.Auth("Test1", "Test"));
            Assert.IsTrue(page.Auth("Director", "Director"));
            Assert.IsFalse(page.Auth("111", "1111"));
        }
    }
}
