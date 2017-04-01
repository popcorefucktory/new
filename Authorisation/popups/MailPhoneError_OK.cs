using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Remote;
using TestProjectNew.Actions;

namespace TestProjectNew
{
    [TestClass]
    public class MailPhoneError_OK
    {
        private static RemoteWebDriver _session;

        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            _session = SetupActions.LaunchApp();
        }

        [ClassCleanup]
        public static void TearDown()
        {
            _session.Dispose();
            _session = null;
        }

        [TestMethod]
        public void click_OK()
        {
            NavigationActions.OpenMyIvi(_session);

            _session.FindElementByClassName("TextBlock").SendKeys("kivyanskaya@ivi");
            _session.FindElementByClassName("Button").Click();
            _session.FindElementByName("OK").Click();
            string reg = _session.FindElementByName("Регистрация").Text;
            Console.WriteLine(reg);

            Assert.IsNotNull(reg);
        }
    }
}
