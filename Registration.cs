using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;
using System.Threading;
using TestProjectNew.Actions;

namespace TestProjectNew
{

    [TestClass]
    public class Registration
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
        public void _registrationByPhone_success()
            
        {
            NavigationActions.OpenMyIvi(_session);

            _session.FindElementByClassName("TextBlock").SendKeys("79999999999");
            _session.FindElementByName("Регистрация").Click();
            _session.FindElementByClassName("Button").Click();
            _session.FindElementByClassName("Button").SendKeys(Keys.Enter);
            Phone_MailCatcherActions.OpenMailcatcher(_session);
            var maintheme = _session.FindElementByClassName("ListView");

            Assert.IsNotNull(maintheme);
         }

        [TestMethod]
        public void _registrationByMail_success()
        {
            NavigationActions.OpenMyIvi(_session);
            _session.FindElementByName("Регистрация").Click();
            ChromeDriver EmailGenerator = new ChromeDriver();
            EmailGenerator.Url = "http://www.yopmail.com/ru/email-generator.php";
            EmailGenerator.Navigate();
            var randomMail = EmailGenerator.FindElementByXPath("//*[@id='login']").GetAttribute("value");
            _session.FindElementByClassName("TextBlock").SendKeys(randomMail);
            _session.FindElementByClassName("Button").Click();
            _session.FindElementByClassName("TextBlock").SendKeys("1");
            _session.FindElementByClassName("Button").Click();
            _session.FindElementByClassName("Button").Click();
            Thread.Sleep(2000);

            //Console.WriteLine(a);

            // _session.FindElementByClassName("TextBlock").SendKeys(key);
        }

    }
}
