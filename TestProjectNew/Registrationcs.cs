using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Remote;
using System;
using System.Threading;

namespace TestProjectNew
{

    [TestClass]
    public class Registration 
    {

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

        [TestMethod]
        public void AddNumber()
            
        { 
            
            IviSession.FindElementByClassName("TextBlock").SendKeys("79999999999");
            Thread.Sleep(1000);
            IviSession.FindElementByClassName("Button").Click();
        }
    
        private void OpenMyIviEntrance()
        {
            throw new NotImplementedException();
        }
    }
}
