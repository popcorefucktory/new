using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;
using TestProjectNew.Actions;

namespace TestProjectNew
{
    [TestClass]
    public class GetPopup
    {
        private static RemoteWebDriver _session;

        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            _session = SetupActions.LaunchApp();
            //_fiddler = LaunchFiddlerAcions.LaunchFiddler();// неудачная попытка вкрячить фиддлер

        }

        [ClassCleanup]
        public static void TearDown()
        {
            _session.Dispose();
            _session = null;
        }

        [TestMethod]
        public void ageless()
        {
            //Debug.WriteLine("start");
            Popup18plusActions.plus_popup(_session);
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
    
