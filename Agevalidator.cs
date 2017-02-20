using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
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
        public void SayNo_ageValidatorpopup_fromSearch()
        {
            //Debug.WriteLine("start");
            Get_ageValidatorpopup();
            //Thread.Sleep(1500);нет
            //Debug.WriteLine("Get_ageValidatorpopup");

            var a = _session.FindElementsByClassName("Button");
            Console.WriteLine(a[2]);
            a[2].SendKeys(Keys.Enter);
            var b = _session.FindElementByClassName("TextBlock");

            Assert.IsNotNull(b);
        }
    }
}
    
