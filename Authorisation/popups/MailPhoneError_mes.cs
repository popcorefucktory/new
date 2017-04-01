using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium;
using TestProjectNew.Actions;
using System;

namespace TestProjectNew
{
    [TestClass]
    public class MailPhoneError_mes
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
        public void mail_or_phone_error()
        {
            // Arrange 
            NavigationActions.OpenMyIvi(_session);

            // Act
            _session.FindElementByClassName("TextBlock").SendKeys("111111");
            _session.FindElementByClassName("Button").Click();
            string errorMsg = _session.FindElementByName("Вы ввели несуществующий телефон или email.").Text;
            Console.WriteLine(errorMsg);

            // Assert
            Assert.IsNotNull(errorMsg);
        }
    }
}