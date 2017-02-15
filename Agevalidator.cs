using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Remote;
using System;
using System.Diagnostics;
using System.Threading;

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
            //launch the app
            DesiredCapabilities appCapabilities = new DesiredCapabilities();
            appCapabilities.SetCapability("app", "ivi.ru.ivi-xbox_17t6d7vatm0nm!App");
            appCapabilities.SetCapability("platformName", "Windows");
            appCapabilities.SetCapability("deviceName", "WindowsPC");
            IviSession = new RemoteWebDriver(new Uri(WindowsApplicationDriverUrl), appCapabilities);
            Assert.IsNotNull(IviSession);
            IviSession.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(2));

            //IviSession.FindElementByName("//Button[starts-with(@Name, \"ListViewItem-14\")]").Click();
            //Assert.IsNotNull(IviResult);
        }


        [ClassCleanup]
        public static void TearDown()
        {
            IviResult = null;
            IviSession.Dispose();
            IviSession = null;
        }
        public void Get_ageValidatorpopup()
        {
            OpenTheSearch();
            _session.FindElementByClassName("TextBlock").SendKeys("Убить Билла");
            _session.FindElementByClassName("TextBlock").SendKeys(Keys.Tab);
            _session.FindElementByClassName("Button").SendKeys(Keys.Enter);
            var popup = _session.FindElementByClassName("TextBlock").Text;
            Console.WriteLine(popup);

            Assert.IsNotNull(popup);
        }

        private void OpenTheSearch()
        {
            throw new NotImplementedException();
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
    
