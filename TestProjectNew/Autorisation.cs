using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Remote;
using System.Threading;
using OpenQA.Selenium;
using TestProjectNew.Actions;

namespace TestProjectNew
{
    [TestClass]
    public class Autorisation
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
        public void OpenMyIviEntrance()
        {
            // Act
            NavigationActions.OpenMyIvi(_session);

            // Assert
            
        }

        [TestMethod]
        public void EnterTheEmailSuccessful()
        {
            // Arrange
            NavigationActions.OpenMyIvi(_session);

            // Act
            _session.FindElementByClassName("TextBlock").SendKeys("kivyanskaya@ivi.ru");
            _session.FindElementByClassName("Button").Click();
            var passpage = _session.FindElementByClassName("PasswordBox");

            Assert.IsNotNull(passpage);
         
        }

        [TestMethod]
        public void AutoNon_ExistentMail()
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

        [TestMethod]
        public void AutoNon_ExistentMailBack()
        {
            NavigationActions.OpenMyIvi(_session);

            _session.FindElementByClassName("TextBlock").SendKeys("111111");
            _session.FindElementByClassName("Button").Click();
            _session.FindElementByClassName("Button").SendKeys(Keys.Escape);

        }

        [TestMethod]
        public void ClearType()
        {
            NavigationActions.OpenMyIvi(_session);

            _session.FindElementByClassName("TextBlock").SendKeys("111111");
            Thread.Sleep(1000);
            _session.FindElementByClassName("TextBox").Clear();
            Thread.Sleep(1000);
        }
        [TestMethod]
        public void EnterThePasswordSuccsessful()
        {
            EnterTheEmailSuccessful();
            _session.FindElementByClassName("PasswordBox").SendKeys("12345");
            _session.FindElementByClassName("Button").Click();
        }
        [TestMethod]
        public void EnterThePasswordFail()
        {
            EnterTheEmailSuccessful();
            _session.FindElementByClassName("PasswordBox").SendKeys("1234");
            _session.FindElementByClassName("Button").Click();
        }
        [TestMethod]
        public void AddPhoneSuccess()
        {

        }
        [TestMethod]
        public void AddPhoneFail()
        {

        }
    }
}


