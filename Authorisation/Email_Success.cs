using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;
using System.Threading;
using TestProjectNew.Actions;

namespace TestProjectNew
{
    [TestClass]
    public class Email_Success
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
        public void login_by_email_successfull()
        {
           
            NavigationActions.OpenMyIvi(_session);            

            IWebElement textField = _session.FindElementByClassName("TextBox");
            TestUtils.set_en_keyboard_layout(_session, textField);
            textField.SendKeys("kivyanskaya@ivi.ru");
            _session.FindElementByClassName("Button").Click();
            var passpage = _session.FindElementByClassName("PasswordBox");

            Assert.IsNotNull(passpage);
        }
    }
}