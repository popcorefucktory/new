using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Remote;
using System;
using System.Diagnostics;
using System.Threading;
using TestProjectNew.Actions;

namespace TestProjectNew

{
    [TestClass]
    public class AgeValidator
    {
        private static RemoteWebDriver _session;

        protected const string WindowsApplicationDriverUrl = "http://127.0.0.1:4723/wd/hub";
        protected static RemoteWebDriver IviSession;
        protected static RemoteWebElement IviResult;
        protected static string OriginalIviMode;

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
        public void Get_ageValidatorpopup()
        {
            OpenContent18Actions.Open18(_session);
            var popup = _session.FindElementByClassName("TextBlock").Text;
            Console.WriteLine(popup);

            Assert.IsNotNull(popup);
        }

        [TestMethod]
        public void SayYes_ageValidatorpopup_IsHere()
        {
            Get_ageValidatorpopup();
            var a = _session.FindElementByClassName("Button").Text;

            Console.WriteLine(a);

            Assert.IsNotNull(a);
        }
        [TestMethod]
        public void SayYes_ageValidatorpopup_Click()
        {
            Get_ageValidatorpopup();
            _session.FindElementByClassName("Button").Click();

            //Assert.IsNotNull(дописать страницу);
        }

        [TestMethod]
        public void SayNo_ageValidatorpopup()
        {
            Debug.WriteLine("start");
            Get_ageValidatorpopup();
            Thread.Sleep(1500);
            Debug.WriteLine("Get_ageValidatorpopup");

            var a = _session.FindElementByClassName("Button");
            a.SendKeys(Keys.Tab);
            a.SendKeys(Keys.Enter);

            

            //_session.FindElementByXPath("//Button[contains[@ClassName='Button' and @id='iamnot18']]");

            //IWebElement a = _session.FindElementByAccessibilityId("iamnot18") as WindowsElement;
            //_session.FindElementByXPath("//*[@AutomationId='iamnot18']");
            //var a = _session.FindElementsByClassName("Button");
            //a.FindElementByXPath("//Button[@AutomationId=\"iamnot18\"]");
            //_session.FindElementByXPath("//Button[@TextBlock='Нет, мне менее 18 лет' and @id='iamnot18']");

            Debug.WriteLine("FindElementByXPath");

            Thread.Sleep(4000);

        }
    }
}
    
